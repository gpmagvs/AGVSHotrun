using AGVSHotrun.HotRun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVSHotrun.UI
{
    public partial class uscRandomHotRunningInformation : UserControl
    {
        public uscRandomHotRunningInformation()
        {
            InitializeComponent();
        }
        clsHotRunScript _script = new clsHotRunScript();
        internal void ChangeScriptToDisplay(clsHotRunScript script)
        {
            _script.history.OnHistoryChanged -= History_OnHistoryChanged;

            _script = script;
            ReadHistory();
            _script.history.OnHistoryChanged += History_OnHistoryChanged;
        }

        private async void ReadHistory()
        {
            var his = _script.ReadHisotry();
            int totalTaskNum = his.Sum(h => h.TaskList.Count);
            labTotalTaskNum.Text = totalTaskNum + "";
        }

        private void History_OnHistoryChanged(object? sender, EventArgs e)
        {
            //ReadHistory();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            labScriptID.Text = _script.ID;
            labRunningTaskNum.Text = _script.history.RunningTaskNum + "";
            labFinishTaskNum.Text = _script.history.FinishTaskNum + "";
            ReadHistory();

        }
    }
}
