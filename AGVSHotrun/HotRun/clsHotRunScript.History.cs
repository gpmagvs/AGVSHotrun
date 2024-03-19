using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun.HotRun
{
    public partial class clsHotRunScript
    {
        private static string ScriptHistoryStoreFoldr => Path.Combine(Environment.CurrentDirectory, "script history");
        public string HistoryFileFullName => Path.Combine(ScriptHistoryStoreFoldr, $"{ID}-History.json");


        public List<clsHotRunScriptHistory> ReadHisotry()
        {
            Directory.CreateDirectory(ScriptHistoryStoreFoldr);

            if (File.Exists(HistoryFileFullName))
            {
                var tempFileName = Path.GetTempFileName();
                File.Copy(HistoryFileFullName, tempFileName, true);
                var _result = JsonConvert.DeserializeObject<List<clsHotRunScriptHistory>>(File.ReadAllText(tempFileName));
                File.Delete(tempFileName);
                return _result;
            }
            else
            {
                return new List<clsHotRunScriptHistory>();
            }
        }

        private void SaveHistory(clsHotRunScriptHistory? _HotRunScriptHistory)
        {
            List<clsHotRunScriptHistory> _storedHistorys = ReadHisotry();
            bool is_hisotry_exist = _storedHistorys.Any(his => his.StartTime == _HotRunScriptHistory.StartTime);

            if (!is_hisotry_exist)
            {
                _storedHistorys.Add(_HotRunScriptHistory);
            }

            var existHistory = _storedHistorys.FirstOrDefault(d => d.StartTime == _HotRunScriptHistory.StartTime);
            var index = _storedHistorys.IndexOf(existHistory);
            _storedHistorys[index] = _HotRunScriptHistory;
            File.WriteAllText(HistoryFileFullName, JsonConvert.SerializeObject(_storedHistorys, Formatting.Indented));
        }

        public class clsHotRunScriptHistory
        {
            private DateTime _StartTime = DateTime.MinValue;
            private DateTime _EndTime = DateTime.MinValue;
            private int _FinishTaskNum = 0;

            public event EventHandler OnHistoryChanged;
            public DateTime StartTime
            {
                get => _StartTime;
                set
                {
                    if (_StartTime != value)
                    {
                        _StartTime = value;
                        InvokeChanged();
                    }
                }
            }
            public DateTime EndTime
            {
                get => _EndTime;
                set
                {
                    if (_EndTime != value)
                    {
                        RunningTaskNum = 0;
                        _EndTime = value;
                        InvokeChanged();
                    }
                }
            }
            public int FinishTaskNum
            {
                get => _FinishTaskNum;
                set
                {
                    if (value != _FinishTaskNum)
                    {
                        _FinishTaskNum = value;
                        InvokeChanged();
                    }
                }

            }

            public List<clsRunTaskItem> TaskList = new List<clsRunTaskItem>();

            internal int RunningTaskNum { get; set; } = 0;

            public class clsRunTaskItem
            {
                public string ID { get; set; } = "";
                public string Source { get; set; } = "";
                public string Destine { get; set; } = "";

            }

            internal void AddTask(clsRunTask transfer_task)
            {
                TaskList.Add(new clsRunTaskItem
                {
                    ID = transfer_task.TaskName,
                    Source = transfer_task.FromStation,
                    Destine = transfer_task.ToStation
                });
                InvokeChanged();
            }
            private void InvokeChanged()
            {
                OnHistoryChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
