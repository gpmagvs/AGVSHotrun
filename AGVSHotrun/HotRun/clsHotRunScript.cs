using AGVSHotrun.HotRun.Models;
using AGVSHotrun.Models;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6;
using AGVSystemCommonNet6.AGVDispatch.Messages;
using AGVSystemCommonNet6.HttpTools;
using AGVSystemCommonNet6.Vehicle_Control.VCSDatabase;
using Azure;
using Azure.Identity;
using GPMCasstteConvertCIM.WebServer.Models;
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
using static AGVSHotrun.HotRun.HotRunExceptions;
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
        private HttpHelper cimHttp = new HttpHelper(Store.SysConfigs.CIMHost);
        public string ID { get; set; }
        public string AGVName
        {
            get
            {
                if (RunTasksDesigning.Count == 0)
                    return "";
                return string.Join(",", RunTasksDesigning.Select(t => t.AGVName));
            }
        }

        /// <summary>
        /// 使用CIM模擬Port的Load/Unload狀態
        /// </summary>
        public bool UseCIMSimulation { get; set; } = false;
        public bool IsRandomTransferTaskCreateMode { get; set; } = false;

        /// <summary>
        /// 起始任務數量
        /// </summary>
        public int MaxTaskQueueSize { get; set; } = 2;
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

        private List<AGVSystemCommonNet6.MAP.MapPoint> hasTaskPoints = new List<AGVSystemCommonNet6.MAP.MapPoint>();

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
        public virtual bool Start(out string message)
        {
            IsWaitLogin = true;
            DBHelper.Connect();
            hasTaskPoints.Clear();
            AbortLoginCTS = new CancellationTokenSource();
            OnLoopStateChange?.Invoke(this, this);
            var loginresult = Debugger.IsAttached ? new(true, false) : Login().Result;
            if (!loginresult.success)
            {
                IsWaitLogin = false;
                message = loginresult.isCanceled ? "" : "登入派車系統失敗";
                return false;
            }
            IsWaitLogin = false;
            OnLoopStateChange?.Invoke(this, this);
            message = "";

            if (!IsRandomTransferTaskCreateMode && RunTasksDesigning.Any(tk => tk.ToStation == null))
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
        /// <summary>
        /// 非同步執行運行測試任務。
        /// </summary>
        /// <remarks>
        /// 此方法執行以下動作：
        /// 1. 初始化用於中止任務的取消令牌。
        /// 2. 記錄熱運行測試的開始。
        /// 3. 準備必要的變量並觸發相關事件。
        /// 4. 遍歷每一個要在AGV上執行的設計任務。
        /// 5. 根據設計的任務類型（例如：MOVE，TRANSFER）發送請求到AGV。
        /// 6. 在執行下一個任務之前，等待任務的建立和完成。
        /// </remarks>
        /// <exception cref="TaskCanceledException">當任務被取消時拋出。</exception>
        /// <exception cref="HttpRequestException">當與派車系統的通訊發生問題時拋出。</exception>
        /// <exception cref="AuthenticationFailedException">當需要重新登入派車系統時拋出。</exception>
        private async Task _ExecutingTasksAsync()
        {
            AbortTestCTS = new CancellationTokenSource();
            try
            {
                Logger.Info($"Hot Run Test Start !");
                AGVSDBHelper dbhelper = new AGVSDBHelper();
                dbhelper.Connect();
                StartTime = DateTime.Now;
                EndTime = DateTime.MinValue;
                OnHotRunStart?.Invoke(this, this);

                if (IsRandomTransferTaskCreateMode)
                {
                    await RandomTransferTaskRun();
                }
                else
                {

                    FailureReason = "";
                    FinishNum = 0;
                    clsRunTask interupt_move_task = null;
                    clsRunTask last_loop_final_task_action = null;
                    bool isQueueMonitorStart = false;
                    for (int i = 0; i < RepeatNum; i++)
                    {
                        CheckScriptAbortAndThrowExpection();

                        Queue<clsTaskState> tasknameQueue = new Queue<clsTaskState>();
                        for (int action_index = 0; action_index < RunTasksDesigning.Count; action_index++)
                        {
                            CheckScriptAbortAndThrowExpection();
                            clsRunTask task_action = RunTasksDesigning[action_index];
                            bool taskCreated, task_finish;
                            string? TaskName = "";

                            int _agvid = task_action.AGVName == "自動派車" ? -1 : dbhelper.GetAGVID(task_action.AGVName);
                            if (task_action.MoveOnly && task_action.Action != ACTION_TYPE.MOVE)
                            {
                                await task_action.PostFromStationReq(task_action.AGVName, _agvid);
                                taskCreated = WaitTaskCreated(task_action.AGVName, _agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskName);
                                tasknameQueue.Enqueue(new clsTaskState
                                {
                                    task_name = _TaskName,
                                    task_action = task_action
                                });
                                OnLoopStateChange?.Invoke(this, this);
                                WaitTaskFinish(task_action.AGVName, _TaskName);
                                if (task_action.Action == ACTION_TYPE.TRANSFER)
                                {
                                    await task_action.PostToStationReq(task_action.AGVName, _agvid);
                                    taskCreated = WaitTaskCreated(task_action.AGVName, _agvid, ACTION_TYPE.MOVE.ToString().ToLower(), out var _TaskNameNormal);
                                    WaitTaskFinish(task_action.AGVName, _TaskNameNormal);
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
                                await task_action.PostActionReq(task_action.AGVName, _agvid);
                                Logger.Info($"[{task_action.AGVName}] Wait {task_action.Action} Task Created...");
                                taskCreated = WaitTaskCreated(task_action.AGVName, _agvid, task_action.Action.ToString().ToLower(), out var RunningTaskName);
                                Logger.Info($"[{task_action.AGVName}] Task-{RunningTaskName} Created!");
                                ProgressText = $"{action_index + 1}/{RunTasksDesigning.Count}";

                                OnLoopStateChange?.Invoke(this, this);
                                WaitTaskFinish(task_action.AGVName, RunningTaskName);

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
                }

                HotRunFinish();
            }
            catch (CIMSwitchHotRunModeFailFailException ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = "無法切換CIM為HOT RUN模式";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
            }
            catch (CIMSwitchPortLDULDStatusFailFailException ex)
            {
                IsRunning = false;
                EndTime = DateTime.Now;
                FailureReason = "無法切換CIM Port Load/Unload模擬狀態";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
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
                FailureReason = ex.Message + $"\r\n{ex.StackTrace}";
                Success = false;
                OnHotRunFinish?.Invoke(this, this);
            }
            DBHelper.Disconnect();
            if (UseCIMSimulation)
            {
                bool success = await CallCIMAPIToActiveHotRunMode(false);
            }

        }

        private async Task RandomTransferTaskRun()
        {
            IsRunning = true;
            if (UseCIMSimulation)
            {
                bool success = await CallCIMAPIToActiveHotRunMode(true);
                if (!success)
                {
                    throw new CIMSwitchHotRunModeFailFailException();
                }
            }
            await CreateTaskAndPostToAGVS(MaxTaskQueueSize);

            MonitorExecutingTask();
            while (true)
            {
                await Task.Delay(1000);
                if (UseCIMSimulation)
                {
                    bool isCimHotRunning = await CallCIMAPIGetIsHotRunning();
                    if (!isCimHotRunning)
                        break;
                }
                if (AbortTestCTS.IsCancellationRequested)
                    break;
            }
            CancelRemainTransferTasksAsync();
        }

        private async Task CancelRemainTransferTasksAsync()
        {
            List<ExecutingTask> hotRunDispatchTasks = previous_currentExecutingTransferTasks.Where(task => task.AssignUserName.ToLower() != "op").ToList();
            foreach (var _task in hotRunDispatchTasks)
            {
                await AGVS_Dispath_Emulator.CancelTask(_task.Name);
            }
        }

        private async Task CreateTaskAndPostToAGVS(int TaskNum)
        {
            for (int i = 0; i < TaskNum; i++)
            {
                clsRunTask beginTask = CreateTransferTask();

                if (UseCIMSimulation)
                {
                    bool success = await CallCIMAPIToSwitchLDULDSimulationStatusOfEqPorts(beginTask);
                    if (!success)
                        throw new CIMSwitchPortLDULDStatusFailFailException();
                    await Task.Delay(500);
                }
                try
                {
                    if (Debugger.IsAttached)
                    {
                        var ret = DBHelper.ADD_TASK(new ExecutingTask
                        {
                            Name = $"*TEST_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}",
                            AGVID = 1,
                            ActionType = "Transfer",
                            Status = 1,
                            ToStationId = beginTask.ToStationID,
                            FromStationId = beginTask.FromStationID,
                            ToStationName = beginTask.ToStation,
                            ToStation = beginTask.ToStation,
                            FromStationName = beginTask.FromStation,
                            FromStation = beginTask.FromStation,
                            Receive_Time = DateTime.Now,
                            RepeatTime = 1,
                        });
                        await Task.Delay(200);
                    }
                    else
                    {
                        bool post_success = await beginTask.PostActionReq("自動選車", -1);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        List<ExecutingTask> previous_currentExecutingTransferTasks = new List<ExecutingTask>();
        private void MonitorExecutingTask()
        {
            Task.Run(async () =>
            {
                previous_currentExecutingTransferTasks.Clear();
                while (IsRunning)
                {
                    await Task.Delay(1);
                    try
                    {
                        List<ExecutingTask> currentExecutingTransferTasks = DBHelper.DBConn.ExecutingTasks.Where(tk => tk.ActionType == "Transfer").ToList();
                        if (previous_currentExecutingTransferTasks.Count > currentExecutingTransferTasks.Count)
                        {
                            var completedTasks = previous_currentExecutingTransferTasks.Where(tk => !currentExecutingTransferTasks.Select(tk => tk.Name).Contains(tk.Name)).ToList();
                            RemovePointsFromHasTaskList(completedTasks);
                        }
                        if (currentExecutingTransferTasks.Count != MaxTaskQueueSize)//
                        {
                            await CreateTaskAndPostToAGVS(MaxTaskQueueSize - currentExecutingTransferTasks.Count);
                        }
                        previous_currentExecutingTransferTasks = currentExecutingTransferTasks;

                    }
                    catch (CIMSwitchPortLDULDStatusFailFailException ex)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            });
        }

        private void RemovePointsFromHasTaskList(List<ExecutingTask> completedTasks)
        {
            bool _TryRemovePtFromhasTaskList(int pointID)
            {
                if (Store.MapData.Points.TryGetValue(pointID, out AGVSystemCommonNet6.MAP.MapPoint? mapPoint))
                {
                    var pt = hasTaskPoints.FirstOrDefault(pt => pt.TagNumber == mapPoint.TagNumber);
                    if (pt != null)
                        return hasTaskPoints.Remove(pt);
                    else
                        return false;
                }
                else
                    return false;
            }
            foreach (var _executed_task in completedTasks)
            {
                _TryRemovePtFromhasTaskList(_executed_task.FromStationId);
                _TryRemovePtFromhasTaskList(_executed_task.ToStationId);
            }
        }
        private async Task<bool> CallCIMAPIGetIsHotRunning()
        {
            try
            {
                var response = await cimHttp.GetAsync<bool>("/api/hotrunning");
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async Task<bool> CallCIMAPIToActiveHotRunMode(bool active)
        {
            try
            {
                var response = await cimHttp.PostAsync<clsCIMAPIResponse, clsHotRunControl>("/api/sethotrun", new clsHotRunControl
                {
                    enableHotRun = active
                });
                return response.code == 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> CallCIMAPIToSwitchLDULDSimulationStatusOfEqPorts(clsRunTask beginTask)
        {
            try
            {
                List<clsEQLDULDSimulationControl> portsControls = new List<clsEQLDULDSimulationControl>
                {
                     new clsEQLDULDSimulationControl{
                          IOMode = IO_MODE.FromCIMSimulation,
                          Status = LDULD_STATUS.UNLOADABLE,
                          PortName = beginTask.FromStation,
                           TagNumber = beginTask.FromTag
                      },
                     new clsEQLDULDSimulationControl{
                        IOMode = IO_MODE.FromCIMSimulation,
                          Status = LDULD_STATUS.LOADABLE,
                          PortName = beginTask.ToStation,
                           TagNumber = beginTask.ToTag
                     }
                };
                var response = await cimHttp.PostAsync<clsCIMAPIResponse, List<clsEQLDULDSimulationControl>>("/api/set_ports_lduld_status", portsControls);
                return response.code == 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 檢查是否有請求中止測試，如果有則拋出任務取消異常。
        /// </summary>
        /// <remarks>
        /// 此方法會檢查`AbortTestCTS`的取消請求狀態。
        /// 如果取消請求已被觸發，則將記錄相應的錯誤並拋出`TaskCanceledException`異常。
        /// </remarks>
        /// <exception cref="TaskCanceledException">當有取消請求時拋出此異常。</exception>
        private void CheckScriptAbortAndThrowExpection()
        {
            if (AbortTestCTS.IsCancellationRequested)
            {
                Logger.Error($"[{AGVName}] AbortTestCTS.IsCancellationRequested");
                throw new TaskCanceledException();
            }
        }


        private void HotRunFinish()
        {
            Success = true;
            IsRunning = false;
            OnLoopStateChange?.Invoke(this, this);
            OnHotRunFinish?.Invoke(this, this);
        }


        private bool WaitTaskCreated(string AgvName, int agvid, string action_type, out string taskName)
        {
            taskName = "";
            var conn = DBHelper.DBConn;
            ExecutingTask? createdTaskDto = null;
            AbortTestCTS = new CancellationTokenSource();
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            while (createdTaskDto == null)
            {
                Thread.Sleep(1000);
                if (AbortTestCTS.IsCancellationRequested)
                {
                    Logger.Error($"[{AgvName}] AbortTestCTS.IsCancellationRequested");
                    throw new TaskCanceledException();
                }

                if (cts.IsCancellationRequested)
                {
                    Logger.Error($"[{AgvName}] WaitTaskCreated Timeout (20 sec)");
                    return false;
                }
                try
                {
                    Logger.Info($"[{AgvName}] Search Task Action Type equal {action_type} and AGVID equl {agvid}");

                    IQueryable<ExecutingTask> tsks = DBHelper.DBConn.ExecutingTasks.Where(t => t.AGVID == agvid);
                    createdTaskDto = tsks.Where(t => t.ActionType.ToLower() == action_type).OrderBy(t => t.Receive_Time).LastOrDefault();
                    Logger.Info($"[{AgvName}] Search Task Action Type equal {action_type} and AGVID equl {agvid}---Find {tsks.Count()} Data");
                }
                catch (Exception ex)
                {
                    Logger.Error($"[{AgvName}] WaitTaskCreated Exception -{ex.Message}, Trace: {ex.StackTrace}");
                }
            }
            taskName = createdTaskDto.Name;
            return true;
        }
        private bool WaitTaskFinish(string agvName, string taskName)
        {
            if (!Store.SysConfigs.WaitTaskDoneDispatchMode)
                return true;

            Logger.Info($"[{AGVName}] Wait Task-{taskName} Finish...");
            AbortTestCTS = new CancellationTokenSource();
            var conn = DBHelper.DBConn;

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
                        Logger.Error($"[{agvName}] WaitTaskFinish Timeout (600 sec)");
                        return false;
                    }
                    IQueryable<TaskDto> TaskDto = DBHelper.DBConn.Tasks.Where(t => t.Name == taskName); //101 cancel, 100 finish
                    if (TaskDto.Count() > 0)
                    {
                        Logger.Info($"[{agvName}] Task-{taskName} Finish!");
                        return true;
                    }
                }
                catch (TaskCanceledException ex)
                {
                    Logger.Error($"[{agvName}] WaitTaskFinish Exception -{ex.Message}, Trace: {ex.StackTrace}");
                    return false;
                }
            }
        }

        private clsRunTask CreateTransferTask()
        {
            var task = new clsRunTask();
            List<AGVSystemCommonNet6.MAP.MapPoint> eqStationPoints = Store.MapData.Points
                                                                    .Where(kp => !Store.SysConfigs.DisableStationIDList.Contains(kp.Key) && kp.Value.IsEquipment && !hasTaskPoints.Contains(kp.Value))
                                                                    .Select(p => p.Value).ToList();
            if (eqStationPoints.Count < 2)
            {
                return null;
            }
            int[] randomIndexes = GetRandomIndexs(0, eqStationPoints.Count);

            try
            {
                var sourceStation = eqStationPoints[randomIndexes[0]];
                var destineStation = eqStationPoints[randomIndexes[1]];

                hasTaskPoints.Add(sourceStation);
                hasTaskPoints.Add(destineStation);

                TryGetSlotByStationName(sourceStation.Name, out string[] fromSlots);
                TryGetSlotByStationName(destineStation.Name, out string[] destineSlots);

                task.AGVName = "自動選車";
                task.FromStation = sourceStation.Name;
                task.ToStation = destineStation.Name;

                task.FromSlot = sourceStation.IsSTK ? fromSlots[0] : "";
                task.ToSlot = sourceStation.IsSTK ? destineSlots[0] : "";

                task.Action = ACTION_TYPE.TRANSFER;
                task.MoveOnly = false;
                Logger.Info($"Created Transfer Task:\r\n{task.ToJson()}");

            }
            catch (Exception ex)
            {
                return null;
            }

            return task;
        }


        private bool TryGetSlotByStationName(string stationName, out string[] slots)
        {
            slots = new string[1] { "1" };
            try
            {
                //RACK_1_3,4,5
                //RACK$1$3,4,5
                stationName = stationName.Replace("_", "$");
                var splited = stationName.Split('$');
                slots = splited.Last().Split('|');
                return slots.Length == 3;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        Random rand = new Random();
        private int[] GetRandomIndexs(int from, int to)
        {
            List<int> numbers = new List<int>();
            // Keep generating numbers until we have 2 unique values
            while (numbers.Count < 2)
            {
                Thread.Sleep(1000);
                int num = rand.Next(from, to); // Generates a number between 0 and 20
                if (!numbers.Contains(num))
                {
                    Logger.Info($"Random int Created :{num}");
                    numbers.Add(num);
                }
            }
            return numbers.ToArray();
        }
    }
}
