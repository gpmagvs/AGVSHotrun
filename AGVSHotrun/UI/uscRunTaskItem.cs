using AGVSHotrun.HotRun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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
            cmbFromSlot.Text = runTask.FromSlot;
            cmbToSlot.Text = runTask.ToSlot;
            ckbMoveOnly.Checked = runTask.MoveOnly;
            txbCSTID.Text = runTask.CSTID;
        }

        private void actionComboBox1_OnActionTypeSelected(object sender, Models.ACTION_TYPE action)
        {
            RunTaskDto.Action =
            cmbFromStations.ShowStaionByAction =
            cmbToStations.ShowStaionByAction = action;
            cmbToStations.Enabled = cmbToSlot.Enabled = action == Models.ACTION_TYPE.CARRY;

        }

        private void cmbFromStations_OnStationSelect(object sender, AGVSystemCommonNet6.MAP.MapPoint point)
        {
            RunTaskDto.FromStation = point.Name;
            if (RunTaskDto.Action != Models.ACTION_TYPE.MOVE && RunTaskDto.Action != Models.ACTION_TYPE.CHARGE)
            {
                cmbFromSlot.Items.Clear();
                if (TryGetSlotByStationName(RunTaskDto.FromStation, out string[] slots))
                {
                    cmbFromSlot.Items.AddRange(slots);
                    cmbFromSlot.SelectedIndex = slots.ToList().IndexOf(RunTaskDto.FromSlot);
                }
            }
            else
            {

            }
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
        private void cmbToStations_OnStationSelect(object sender, AGVSystemCommonNet6.MAP.MapPoint point)
        {
            RunTaskDto.ToStation = point.Name;
            if (RunTaskDto.Action != Models.ACTION_TYPE.MOVE && RunTaskDto.Action != Models.ACTION_TYPE.CHARGE)
            {
                cmbToSlot.Items.Clear();
                if (TryGetSlotByStationName(RunTaskDto.ToStation, out string[] slots))
                {
                    cmbToSlot.Items.AddRange(slots);
                    cmbToSlot.SelectedIndex = slots.ToList().IndexOf(RunTaskDto.ToSlot);
                }
            }
            else
            {

            }
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

        private void ckbMoveOnly_CheckedChanged(object sender, EventArgs e)
        {
            RunTaskDto.MoveOnly = ckbMoveOnly.Checked;
        }

        private void cmbFromStations_Load(object sender, EventArgs e)
        {

        }

        private void cmbFromSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunTaskDto.FromSlot = cmbFromSlot.SelectedItem.ToString();
        }

        private void cmbToSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunTaskDto.ToSlot = cmbToSlot.SelectedItem.ToString();
        }

        private void cmbToStations_Load(object sender, EventArgs e)
        {

        }
    }
}
