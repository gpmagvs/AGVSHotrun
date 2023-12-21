using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.WebServer.Models
{

    public enum IO_MODE
    {
        FromIOModule,
        FromCIMSimulation,
        Unknown
    }
    public enum LDULD_STATUS
    {
        UNLOADABLE,
        LOADABLE,
        DOWN
    }

    public class clsEQLDULDSimulationControl
    {
        public string PortName { get; set; } = "";
        public int TagNumber { get; set; }
        public IO_MODE IOMode { get; set; }
        public LDULD_STATUS Status { get; set; }
    }
}
