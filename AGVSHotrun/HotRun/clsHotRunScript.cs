using AGVSHotrun.Models;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6;
using AGVSystemCommonNet6.AGVDispatch.Messages;
using AGVSystemCommonNet6.MAP;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ACTION_TYPE = AGVSHotrun.Models.ACTION_TYPE;

namespace AGVSHotrun.HotRun
{
    public class clsHotRunScript
    {
        public static event EventHandler<clsHotRunScript> OnHotRunStart;
        public static event EventHandler<clsHotRunScript> OnHotRunFinish;
        public static event EventHandler<clsHotRunScript> OnLoginExpireExcetionOccur;
        public static event EventHandler<clsHotRunScript> OnHttpExcetionOccur;
        public static event EventHandler<clsHotRunScript> OnLoopStateChange;
        public string ID { get; set; }
        public string AGVName { get; set; }

        public int RepeatNum { get; set; } = 1;

        public int FinishNum { get; set; } = 0;
        public string Description { get; set; } = "";

        public string StartStatus
        {
            get
            {
                return IsWaitLogin ? "Wait Login..." : IsRunning ? "中止" : "開始";
            }
        }

        [JsonIgnore]
        public int TotalActionNum
        {
            get
            {
                return RunTasksDesigning.Count;
            }
        }
        public string CurrentAction
        {
            get
            {
                if (IsRunning && _RunningTask != null)
                {
                    return $"{_RunningTask.Action}-From {_RunningTask.FromStation} To {_RunningTask.ToStation}";
                }
                else
                    return "";
            }
        }

        public string ProgressText { get; set; } = "0/0";

        [JsonIgnore]
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        [JsonIgnore]
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        [JsonIgnore]
        public List<clsRunTask> RunTasksDesigning { get; set; } = new List<clsRunTask>();
        private ConcurrentQueue<clsRunTask> RunTasksQueue { get; set; } = new ConcurrentQueue<clsRunTask>();

        [JsonIgnore]
        public bool Success { get; private set; }

        [JsonIgnore]
        internal bool IsWaitLogin { get; set; }

        [JsonIgnore]
        internal bool IsRunning { get; set; }

        [JsonIgnore]
        public string ResultDisplay
        {
            get
            {
                return IsRunning ? "執行中" : Success ? "成功" : "失敗";
            }
        }
        [JsonIgnore]
        public string FailureReason { get; set; } = "";

        [JsonIgnore]
        AGVSDBHelper DBHelper = new AGVSDBHelper();

        public void AddRunTask(clsRunTask task)
        {
            RunTasksDesigning.Add(task);
        }

        internal void RemoveRunTask(clsRunTask runTaskDto)
        {
            RunTasksDesigning.Remove(runTaskDto);
        }
        CancellationTokenSource AbortTestCTS = new CancellationTokenSource();
        CancellationTokenSource AbortLoginCTS = new CancellationTokenSource();

        public void Abort()
        {
            AbortTestCTS.Cancel();
            AbortLoginCTS.Cancel();
            IsWaitLogin = false;
            IsRunning = false;
            OnLoopStateChange?.Invoke(this, this);
        }
        public bool Start(out string message)
        {
            IsWaitLogin = true;
            AbortLoginCTS = new CancellationTokenSource();
            OnLoopStateChange?.Invoke(this, this);
            var loginresult = Login().Result;
            if (!loginresult.success)
            {
                IsWaitLogin = false;
                message = loginresult.isCanceled ? "" : "登入派車系統失敗";
                return false;
            }
            IsWaitLogin = false;
            OnLoopStateChange?.Invoke(this, this);
            message = "";
            if (RunTasksDesigning.Any(tk => tk.ToStation == null))
            {
                var indexes = RunTasksDesigning.FindAll(tk => tk.ToStation == null).Select(tk => RunTasksDesigning.IndexOf(tk) + 1);
                message = $"動作 {string.Join(",", indexes)}  [目標站點_To Station] 設定有誤";
                return false;
            }
            IsRunning = true;
            Task.Run(() => _ExecutingTasksAsync());
            return true;
        }
        public async Task<(bool success, bool isCanceled)> Login()
        {
            AGVS_Dispath_Emulator.ExcuteResult result = await AGVS_Dispath_Emulator.Login(AbortLoginCTS.Token);
            return (result.Success, result.IsCanceled);
        }
        clsRunTask _RunningTask;
        public class clsTaskState
        {
            public string task_name;
            public clsRunTask task_action;
        }

        private async Task _ExecutingTasksAsync()
        {
            try
            {
                Logger.Info($"[{AGVName}] Hot Run Test Start !");

                AGVSDBHelper dbhelper = new AGVSDBHelper();
                int agvid = Debugger.IsAttached ? 1 : dbhelper.GetAGVID(AGVName);

                if (Store.SysConfigs.CancelChargeTaskWhenHotRun)
                    WatchChargeTaskAndCancelIt(agvid);
                if (!Store.SysConfigs.WaitTaskDoneDispatchMode)
                    HotrunFinishCheckWTD(agvid);

                KeyValuePair<AGVInfo, MapPoint> agv = Store.AGVlocStore.First(ke => ke.Key.AGVName == AGVName);
                StartTime = DateTime.Now;
                EndTime = DateTime.MinValue;
                OnHotRunStart?.Invoke(this, this);
                FailureReason = "";
                FinishNum = 0;
                clsRunTask interupt_move_task = null;
                clsRunTask last_loop_final_task_action = null;
                bool isQueueMonitorStart = false;
                for (int i = 0; i < RepeatNum; i++)
                {
                    Queue<clsTaskState> tasknameQueue = new Queue<clsTaskState>();
                    for (int action_index = 0; action_index < RunTasksDesigning.Count; action_index++)
                    {
                        clsRunTask task_action = RunTasksDesigning[action_index];

                        bool taskCreated, task_finish;
                        string? TaskName = "";
                        //惟Carry、Load Unload 且設定為僅移動
                        if (task_action.MoveOnly && task_action.Action != ACTION_TYPE.MOVE)
                        {
                            await task_action.PostFromStationReq(AGVName, agvid);
                            taskCreated = WaitTaskCreated(agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskName);
                            tasknameQueue.Enqueue(new clsTaskState
                            {
                                task_name = _TaskName,
                                task_action = task_action
                            });
                            OnLoopStateChange?.Invoke(this, this);
                            WaitTaskFinish(_TaskName);
                            if (task_action.Action == ACTION_TYPE.TRANSFER)
                            {
                                await task_action.PostToStationReq(AGVName, agvid);
                                taskCreated = WaitTaskCreated(agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskNameNormal);
                                WaitTaskFinish(_TaskNameNormal);
                                tasknameQueue.Enqueue(new clsTaskState
                                {
                                    task_name = _TaskNameNormal,
                                    task_action = task_action
                                });
                                task_action.TaskName = _TaskNameNormal;
                            }
                            else
                                task_action.TaskName = _TaskName;
                        }
                        else
                        {
                            await task_action.PostActionReq(AGVName, agvid);
                            Logger.Info($"[{AGVName}] Wait Task Created...");
                            taskCreated = WaitTaskCreated(agvid, task_action.Action.ToString().ToLower(), out var RunningTaskName);
                            Logger.Info($"[{AGVName}] Task-{RunningTaskName} Created!");
                            ProgressText = $"{action_index + 1}/{RunTasksDesigning.Count}";

                            OnLoopStateChange?.Invoke(this, this);
                            WaitTaskFinish(RunningTaskName);

                            task_action.TaskName = RunningTaskName;
                            tasknameQueue.Enqueue(new clsTaskState
                            {
                                task_name = RunningTaskName,
                                task_action = task_action
                            });
                        }
                        isQueueMonitorStart = true;
                    }
                    FinishNum = i + 1;
                    Logger.Info($"[{AGVName}] Hot Run Progress Updated:  {FinishNum}/{RepeatNum}");
                    OnLoopStateChange?.Invoke(this, this);
                }

                HotRunFinish();
            }
            catch (TaskCanceledException ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = "使用者中斷測試(AGV Will Stop when current action done)";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
            }
            catch (HttpRequestException ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = "無法與派車系統通訊";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
                OnHttpExcetionOccur?.Invoke(this, this);
            }
            catch (AuthenticationFailedException ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = "需要重新登入派車系統";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
                OnLoginExpireExcetionOccur?.Invoke(this, this);
            }
            catch (Exception ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = ex.Message;
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
            }
        }
        private void HotrunFinishCheckWTD(int agvid)
        {
            Logger.Warn($"[{AGVName}] Start HotrunFinishCheckWTD.");

            _ = Task.Run(async () =>
            {
                var conn = DBHelper.DBConn;
                using (conn)
                {
                    ExecutingTask? createdTaskDto = null;
                    while (createdTaskDto == null)
                    {
                        await Task.Delay(1000);
                        if (!IsRunning)
                            break;
                        try
                        {
                            var tsks = conn.ExecutingTasks.Where(t => t.AGVID == agvid);
                            if (tsks.Count() == 0 && FinishNum == RepeatNum)
                            {
                                HotRunFinish();
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            });
        }

        private void HotRunFinish()
        {
            Success = true;
            IsRunning = false;
            OnLoopStateChange?.Invoke(this, this);
            OnHotRunFinish?.Invoke(this, this);
        }

        private void WatchChargeTaskAndCancelIt(int agvid)
        {
            Task.Run(async () =>
            {
                using (var conn = DBHelper.DBConn)
                {
                    Logger.Warn($"[{AGVName}] Start Watch Charge Task Executing State, Hot run program will cancel Charge Task when task created.");
                    while (IsRunning)
                    {
                        await Task.Delay(10);
                        List<ExecutingTask> chargetasks = conn.ExecutingTasks.Where(t => t.AGVID == agvid && t.ActionType == "Charge").ToList();
                        if (chargetasks.Count() > 0)
                        {
                            for (int i = 0; i < chargetasks.Count(); i++)
                            {
                                await AGVS_Dispath_Emulator.CancelTask(chargetasks[i].Name);
                            }
                            Logger.Warn($"[{AGVName}] 充電任務已取消");
                        }
                    }
                    Logger.Warn($"[{AGVName}]  Charge Task WTD FINISH");

                }
            });
        }

        private bool IsSameSource(Queue<clsTaskState> tasknameQueue, clsRunTask next_action)
        {
            return tasknameQueue.Any(t => t.task_action.FromStation == next_action.FromStation |
                                          t.task_action.FromStation == next_action.ToStation |
                                          t.task_action.ToStation == next_action.FromStation |
                                          t.task_action.ToStation == next_action.ToStation);
        }
        private bool WaitTaskCreated(int agvid, string action_type, out string taskName)
        {
            taskName = "";
            var conn = DBHelper.DBConn;
            using (conn)
            {
                ExecutingTask? createdTaskDto = null;
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                while (createdTaskDto == null)
                {
                    Thread.Sleep(1000);
                    if (AbortTestCTS.IsCancellationRequested)
                    {
                        Logger.Error($"[{AGVName}] AbortTestCTS.IsCancellationRequested");
                        throw new TaskCanceledException();
                    }

                    if (cts.IsCancellationRequested)
                    {
                        Logger.Error($"[{AGVName}] WaitTaskCreated Timeout (20 sec)");
                        return false;
                    }
                    try
                    {
                        Logger.Info($"[{AGVName}] Search Task Action Type equal {action_type} and AGVID equl {agvid}");

                        IQueryable<ExecutingTask> tsks = conn.ExecutingTasks.Where(t => t.AGVID == agvid);
                        createdTaskDto = tsks.Where(t => t.ActionType.ToLower() == action_type).OrderBy(t => t.Receive_Time).LastOrDefault();
                        Logger.Info($"[{AGVName}] Search Task Action Type equal {action_type} and AGVID equl {agvid}---Find {tsks.Count()} Data");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"[{AGVName}] WaitTaskCreated Exception -{ex.Message}, Trace: {ex.StackTrace}");
                    }
                }
                taskName = createdTaskDto.Name;
                return true;
            }
        }
        private bool WaitTaskFinish(string taskName)
        {
            if (!Store.SysConfigs.WaitTaskDoneDispatchMode)
                return true;

            Logger.Info($"[{AGVName}] Wait Task-{taskName} Finish...");
            AbortTestCTS = new CancellationTokenSource();
            var conn = DBHelper.DBConn;
            using (conn)
            {
                TaskDto? finishTaskDto = null;
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(600));
                while (true)
                {
                    Thread.Sleep(10);
                    try
                    {
                        if (AbortTestCTS.IsCancellationRequested)
                            return true;

                        if (cts.IsCancellationRequested)
                        {
                            Logger.Error($"[{AGVName}] WaitTaskFinish Timeout (600 sec)");
                            return false;
                        }
                        IQueryable<TaskDto> TaskDto = conn.Tasks.Where(t => t.Name == taskName); //101 cancel, 100 finish
                        if (TaskDto.Count() > 0)
                        {
                            Logger.Info($"[{AGVName}] Task-{taskName} Finish!");
                            return true;
                        }
                    }
                    catch (TaskCanceledException ex)
                    {
                        Logger.Error($"[{AGVName}] WaitTaskFinish Exception -{ex.Message}, Trace: {ex.StackTrace}");
                        return false;
                    }
                }
            }
        }

    }


    public class clsRunTask
    {
        public string TaskName { get; set; }
        public ACTION_TYPE Action { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FromStation { get; set; } = "";
        public string FromSlot { get; set; } = "";
        public string ToStation { get; set; } = "";
        public string ToSlot { get; set; } = "";
        public string CSTID { get; set; } = "";
        public bool MoveOnly { get; set; } = true;

        public string GetSecondaryPt(string Station)
        {
            var map_points = Store.MapData.Points.ToList();
            MapPoint toStationPt = map_points.First(pt => pt.Value.Name == Station).Value;
            MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
            return hotRunToStationPt.Name;
        }

        public string GetActualFromStationName()
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = FromStation;
            if (MoveOnly && Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == FromStation).Value;
                MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
                _toStation = hotRunToStationPt.Name;
            }
            return _toStation;
        }
        public string GetActualToStationName()
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = ToStation;

            if (MoveOnly && Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == ToStation).Value;
                MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
                _toStation = hotRunToStationPt.Name;
            }
            return _toStation;
        }


        internal async Task<bool> PostActionReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, FromStation, FromSlot, ToStation, ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<bool> PostFromStationReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, GetActualFromStationName(), ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<bool> PostToStationReq(string AgvName, int AgvID)
        {
            try
            {
                return await PostTaskHttpRequest(AgvName, AgvID, GetActualToStationName(), ToSlot, CSTID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> PostTaskHttpRequest(string AgvName, int AgvID, string from_station, string from_slot, string to_station = "", string to_slot = "", string cstid = "")
        {
            AGVS_Dispath_Emulator dispatcher_helper = new AGVS_Dispath_Emulator();
            AGVS_Dispath_Emulator.ExcuteResult? result = null;
            if (MoveOnly)
                result = await dispatcher_helper.Move(AgvName, AgvID, from_station);
            else
            {
                switch (Action)
                {
                    case ACTION_TYPE.MOVE:
                        result = await dispatcher_helper.Move(AgvName, AgvID, from_station);
                        break;
                    case ACTION_TYPE.LOAD:
                        result = await dispatcher_helper.Load(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.UNLOAD:
                        result = await dispatcher_helper.Unload(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.TRANSFER:
                        result = await dispatcher_helper.Carry(AgvName, AgvID, from_station, from_slot, to_station, to_slot, cstid);
                        break;
                    case ACTION_TYPE.CHARGE:
                        result = await dispatcher_helper.Charge(AgvName, AgvID, from_station, from_slot, cstid);
                        break;
                    case ACTION_TYPE.PARK:
                        result = await dispatcher_helper.Park(AgvName, AgvID, from_station, from_slot);
                        break;
                    default:
                        break;
                }
            }
            if (result.ResponseMsg.Contains("系統已閒置過久,請重新登入再進行手動派工"))
            {
                throw new AuthenticationFailedException(result.ResponseMsg);
            }
            if (result.ResponseMsg.Contains("無法連接至遠端伺服器"))
            {
                throw new HttpRequestException(result.ResponseMsg);
            }
            return result.Success;
        }

    }
}
