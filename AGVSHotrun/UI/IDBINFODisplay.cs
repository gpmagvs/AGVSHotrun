using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun.UI
{
    internal interface IDBINFODisplay
    {
        AGVSDBHelper dbHelper { get; set; }
        void StartRender();
        void UI_Render_TIMER_Tick(object sender, EventArgs e);
    }
}
