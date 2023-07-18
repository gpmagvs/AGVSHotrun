using AGVSHotrun.Models;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6;
using AGVSystemCommonNet6.AGVDispatch.Messages;
using AGVSystemCommonNet6.MAP;
using Azure.Identity;
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
            AbortTestCTS = new CancellationTokenSource();
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
                KeyValuePair<AGVInfo, MapPoint> agv = Store.AGVlocStore.First(ke => ke.Key.AGVName == AGVName);
                StartTime = DateTime.Now;
                EndTime = DateTime.MinValue;
                AGVSDBHelper dbhelper = new AGVSDBHelper();
                int agvid = Debugger.IsAttached ? 1 : dbhelper.GetAGVID(AGVName);
                OnHotRunStart?.Invoke(this, this);
                FailureReason = "";
                FinishNum = 0;
                clsRunTask interupt_move_task = null;
                clsRunTask last_loop_final_task_action = null;

                bool isQueueMonitorStart = false;
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
                                if (tsks.Count() == 0 && isQueueMonitorStart && FinishNum == RepeatNum)
                                {
                                    Success = true;
                                    IsRunning = false;
                                    OnLoopStateChange?.Invoke(this, this);
                                    OnHotRunFinish?.Invoke(this, this);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                });



                //TEST Loop迴圈
                for (int i = 0; i < RepeatNum; i++)
                {
                    Queue<clsTaskState> tasknameQueue = new Queue<clsTaskState>();
                    IsRunning = true;
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
                            if (task_action.Action == ACTION_TYPE.CARRY)
                            {

                                await task_action.PostToStationReq(AGVName, agvid);
                                taskCreated = WaitTaskCreated(agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskNameNormal);
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
                            if (interupt_move_task != null)
                            {
                                AGVS_Dispath_Emulator.CancelTask(interupt_move_task.TaskName);
                            }

                            taskCreated = WaitTaskCreated(agvid, task_action.Action.ToString().ToLower(), out var RunningTaskName);
                            task_action.TaskName = RunningTaskName;

                            tasknameQueue.Enqueue(new clsTaskState
                            {
                                task_name = RunningTaskName,
                                task_action = task_action
                            });

                            clsRunTask? next_action = action_index + 1 == RunTasksDesigning.Count ? null : RunTasksDesigning[action_index + 1];
                            if (next_action != null)
                            {
                                bool issamesource = IsSameSource(tasknameQueue, next_action);
                                if (issamesource && next_action.Action != ACTION_TYPE.MOVE)
                                {
                                    //
                                    MapPoint chargePoint = Store.MapData.Points.ToList().First(pt => pt.Value.IsChargeAble()).Value;
                                    interupt_move_task = new clsRunTask()
                                    {
                                        Action = ACTION_TYPE.MOVE,
                                        FromStation = chargePoint.Name,
                                    };
                                    interupt_move_task.FromStation = interupt_move_task.GetSecondaryPt(interupt_move_task.FromStation);
                                    await interupt_move_task.PostActionReq(AGVName, agvid);
                                    var interupt_move_taskCreated = WaitTaskCreated(agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskName);
                                    interupt_move_task.TaskName = _TaskName;
                                    //等待結束
                                    bool isRunningTaskFinish = await WaitTaskFinish(RunningTaskName);
                                    //取消任務

                                }
                                else
                                {
                                    interupt_move_task = null;
                                }
                            }
                            //tasknameQueue.Enqueue(new clsTaskState
                            //{
                            //    task_name = RunningTaskName,
                            //    task_action = task_action
                            //});
                            //最後一個動作
                            if (action_index == RunTasksDesigning.Count - 1)
                            {

                                if (i < RepeatNum - 1) //1J6G4YJO4C.4U H4
                                {
                                    if (task_action.Action != ACTION_TYPE.MOVE)
                                    {
                                        MapPoint chargePoint = Store.MapData.Points.ToList().First(pt => pt.Value.IsChargeAble()).Value;

                                        interupt_move_task = new clsRunTask()
                                        {
                                            Action = ACTION_TYPE.MOVE,
                                            FromStation = chargePoint.Name,
                                        };
                                        interupt_move_task.FromStation = interupt_move_task.GetSecondaryPt(interupt_move_task.FromStation);
                                        await interupt_move_task.PostActionReq(AGVName, agvid);
                                        var interupt_move_taskCreated = WaitTaskCreated(agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskName);
                                        interupt_move_task.TaskName = _TaskName;
                                        //等待結束
                                        bool isRunningTaskFinish = await WaitTaskFinish(RunningTaskName);
                                    }
                                }
                            }

                        }
                        isQueueMonitorStart = true;


                    }

                    FinishNum = i + 1;
                    OnLoopStateChange?.Invoke(this, this);
                }

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
                    if (AbortTestCTS.IsCancellationRequested)
                        throw new TaskCanceledException();

                    if (cts.IsCancellationRequested)
                    {
                        return false;
                    }
                    try
                    {
                        var tsks = conn.ExecutingTasks.Where(t => t.AGVID == agvid);
                        createdTaskDto = tsks.Where(t => t.ActionType.ToLower() == action_type).OrderBy(t => t.Receive_Time).LastOrDefault();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                taskName = createdTaskDto.Name;
                return true;
            }
        }
        private async Task<bool> WaitTaskFinish(string taskName)
        {
            var conn = DBHelper.DBConn;
            using (conn)
            {
                TaskDto? finishTaskDto = null;
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(600));
                while (true)
                {
                    try
                    {

                        if (AbortTestCTS.IsCancellationRequested)
                            throw new TaskCanceledException();

                        if (cts.IsCancellationRequested)
                        {
                            return false;
                        }
                        IQueryable<TaskDto> TaskDto = conn.Tasks.Where(t => t.Name == taskName); //101 cancel, 100 finish
                        if (TaskDto.Count() > 0)
                        {
                            return true;
                        }
                    }
                    catch (TaskCanceledException)
                    {
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
                    case ACTION_TYPE.CARRY:
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
