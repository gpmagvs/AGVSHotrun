using AGVSHotrun.Models;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6.MAP;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AGVSHotrun.HotRun
{
    public class clsHotRunScript
    {
        public static event EventHandler<clsHotRunScript> OnHotRunStart;
        public static event EventHandler<clsHotRunScript> OnHotRunFinish;

        public string ID { get; set; }
        public string AGVName { get; set; }

        [JsonIgnore]
        public int TotalActionNum
        {
            get
            {
                return RunTasksDesigning.Count;
            }
        }
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
        private bool IsRunning { get; set; }
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

        public bool Start(out string message)
        {
            message = "";
            RunTasksQueue.Clear();
            if (RunTasksDesigning.Any(tk => tk.ToStation == null))
            {
                var indexes = RunTasksDesigning.FindAll(tk => tk.ToStation == null).Select(tk => RunTasksDesigning.IndexOf(tk) + 1);
                message = $"動作 {string.Join(",", indexes)}  [目標站點_To Station] 設定有誤";
                return false;
            }
            foreach (var item in RunTasksDesigning)
                RunTasksQueue.Enqueue(item);
            Task.Run(() => _ExecutingTasksAsync());
            return true;
        }

        private async Task _ExecutingTasksAsync()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            AGVSDBHelper dbhelper = new AGVSDBHelper();
            int agvid = dbhelper.GetAGVID(AGVName);
            IsRunning = true;
            OnHotRunStart?.Invoke(this, this);
            FailureReason = "";
            while (RunTasksQueue.Count != 0)
            {
                Thread.Sleep(1);
                RunTasksQueue.TryDequeue(out clsRunTask _RunningTask);
                string? TaskName = "";
                //Call API And Check Task Exist

                bool taskCreated, task_finish;
                if (_RunningTask.Action == ACTION_TYPE.CARRY)
                {
                    _RunningTask.PostFromStationReq(AGVName, agvid);
                    _RunningTask.TaskName = TaskName;
                    taskCreated = WaitTaskCreated(agvid, out TaskName);
                    if (!taskCreated)
                    {
                        FailureReason = "等待任務生成Timeout";
                        Success = false;
                        break;
                    }
                    _RunningTask.StartTime = DateTime.Now;
                    task_finish = await WaitTaskFinish(TaskName);
                    if (!task_finish)
                    {
                        FailureReason = "等待任務完成Timeout";
                        Success = false;
                        break;
                    }
                }

                _RunningTask.StartTime = DateTime.Now;
                _RunningTask.PostToStationReq(AGVName, agvid);
                taskCreated = WaitTaskCreated(agvid, out TaskName);
                if (!taskCreated)
                {
                    FailureReason = "等待任務生成Timeout";
                    Success = false;
                    break;
                }
                task_finish = await WaitTaskFinish(TaskName);
                if (!task_finish)
                {
                    FailureReason = "等待任務完成Timeout";
                    Success = false;
                    break;
                }
                _RunningTask.EndTime = DateTime.Now;
            }
            IsRunning = false;
            EndTime = DateTime.Now;
            OnHotRunFinish?.Invoke(this, this);
        }
        private bool WaitTaskCreated(int agvid, out string taskName)
        {
            taskName = "";
            var conn = DBHelper.DBConn;
            using (conn)
            {
                ExecutingTask? createdTaskDto = null;
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                while (createdTaskDto == null)
                {
                    if (cts.IsCancellationRequested)
                    {
                        return false;
                    }
                    try
                    {
                        var tsks=conn.ExecutingTasks.Where(t => t.AGVID == agvid);
                        createdTaskDto = tsks.OrderBy(t => t.Receive_Time).FirstOrDefault();
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
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(180));
                while (finishTaskDto == null)
                {
                    if (cts.IsCancellationRequested)
                    {
                        return false;
                    }
                    finishTaskDto = conn.Tasks.Where(t=>t.Name==taskName).FirstOrDefault(task => task.Status == 100);
                }
                return true;
            }
        }

    }


    public class clsRunTask
    {
        public string TaskName { get; set; }
        public ACTION_TYPE Action { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string CSTID { get; set; } = "";

        internal void PostFromStationReq(string AgvName, int AgvID)
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = FromStation;
            if (Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == FromStation).Value;
                MapPoint hotRunToStationPt = map_points[toStationPt.Target.First().Key].Value;
                _toStation = hotRunToStationPt.Name;
            }
            PostTaskHttpRequest(AgvName, AgvID, _toStation);
        }

        internal void PostToStationReq(string AgvName, int AgvID)
        {
            var map_points = Store.MapData.Points.ToList();
            string _toStation = ToStation;
            if (Action != ACTION_TYPE.MOVE && Action != ACTION_TYPE.PARK) //從圖資抓到二次定位點前的Point名稱
            {
                MapPoint toStationPt = map_points.First(pt => pt.Value.Name == ToStation).Value;
                MapPoint hotRunToStationPt = Store.MapData.Points[toStationPt.Target.First().Key];
                _toStation = hotRunToStationPt.Name;
            }
            PostTaskHttpRequest(AgvName, AgvID, _toStation);
        }

        private async Task<bool> PostTaskHttpRequest(string AgvName, int AgvID, string to_station)
        {
          
            AGVS_Dispath_Emulator dispatcher_helper = new AGVS_Dispath_Emulator();
            var result = await dispatcher_helper.Move(AgvName, AgvID, to_station);
            return result.Success;
        }

    }
}
