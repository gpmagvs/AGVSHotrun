using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun.Models
{
    public class clsSysConfigs
    {
        public string MapFile { get; set; } = "C:\\CST\\ini\\Map_UMTC_AOI.json";
        public string AGVSHost { get; set; } = "http://127.0.0.1:6600";
        public string DBConnection { get; set; } = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";

        public string HotRunScriptStoredFile { get; set; } = "HotRunScripts.json";

    }
}
