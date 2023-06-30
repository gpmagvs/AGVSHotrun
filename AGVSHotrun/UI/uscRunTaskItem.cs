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
    public partial class uscRunTaskItem : UserControl
    {
        public clsRunTask RunTaskDto { get; set; } = new clsRunTask();
        public static event EventHandler<uscRunTaskItem> OnRemoveButtonPush;
        public static event EventHandler<uscRunTaskItem> OnMoveUpButtonPush;
        public static event EventHandler<uscRunTaskItem> OnMoveDownButtonPush;
        private int _Index = 1;
        public int Index
        {
            get => _Index;
            set
            {
                _Index = value;
                labActionIndex.Text = _Index.ToString();
                btnMoveUp.Enabled = _Index > 1;
            }
        }

        public uscRunTaskItem()
        {
            InitializeComponent();
        }

        public uscRunTaskItem(clsRunTask runTask)
        {
            InitializeComponent();
            this.RunTaskDto = runTask;
            cmbFromStations.ShowStaionByAction =
            cmbToStations.ShowStaionByAction = runTask.Action;
            actionComboBox1.action_selected = runTask.Action;
            cmbFromStations.station = runTask.FromStation;
            cmbToStations.station = runTask.ToStation;
        }

        private void actionComboBox1_OnActionTypeSelected(object sender, Models.ACTION_TYPE action)
        {
            RunTaskDto.Action =
            cmbFromStations.ShowStaionByAction =
            cmbToStations.ShowStaionByAction = action;
            cmbFromStations.Enabled = comboBox1.Enabled = action == Models.ACTION_TYPE.CARRY;

        }

        private void cmbFromStations_OnStationSelect(object sender, AGVSystemCommonNet6.MAP.MapPoint point)
        {
            RunTaskDto.FromStation = point.Name;
        }

        private void cmbToStations_OnStationSelect(object sender, AGVSystemCommonNet6.MAP.MapPoint point)
        {
            RunTaskDto.ToStation = point.Name;
        }

        private void txbCSTID_TextChanged(object sender, EventArgs e)
        {
            RunTaskDto.CSTID = txbCSTID.Text;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemoveButtonPush?.Invoke(this, this);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            OnMoveUpButtonPush?.Invoke(this, this);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            OnMoveDownButtonPush?.Invoke(this, this);
        }
    }
}
