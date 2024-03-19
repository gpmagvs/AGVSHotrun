using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    public class clsSysConfigs
    {
        public Dictionary<string, string> Notes { get; set; } = new Dictionary<string, string>()
        {
            { "Field(場域名稱)","0:UMTC-3F-AOI, 1:UMTC-3F-YELLOW, 2:UMTC-3F-MEC" }
        };
        public bool IsDebugger { get; set; } = false;
        public FIELD_NAME Field { get; set; } = FIELD_NAME.UMTC_3F_YELLOW;
        public string MapFile { get; set; } = "C:\\CST\\ini\\Map_UMTC_AOI.json";
        public string LogFolder { get; set; } = "D:\\HotRunLog";
        public string AGVSHost { get; set; } = "http://127.0.0.1:6600";
        public string CIMHost { get; set; } = "http://localhost:5432/";
        public string DBConnection { get; set; } = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";
        public string HotRunScriptStoredFile { get; set; } = "HotRunScripts.json";
        internal string AGVSIP
        {
            get
            {
                return AGVSHost.Replace("http://", "").Split(':')[0];
            }
        }
        internal int AGVSPort
        {
            get
            {
                if (int.TryParse(AGVSHost.Replace("http://", "").Split(':')[1], out int _port))
                    return _port;
                return 6600;
            }
        }
        /// <summary>
        /// 派送任務後是否需要等待任務結束
        /// </summary>
        public bool WaitTaskDoneDispatchMode { get; set; } = false;
        /// <summary>
        /// 腳本執行過程中如有充電任務是否要取消
        /// </summary>
        public bool CancelChargeTaskWhenHotRun { get; set; } = false;

        public int[] DisableStationIDList { get; set; } = new int[0];
    }
}
