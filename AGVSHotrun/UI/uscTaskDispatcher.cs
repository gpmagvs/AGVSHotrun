using AGVSHotrun.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGVSHotrun.VirtualAGVSystem;
using static SQLite.SQLite3;

namespace AGVSHotrun
{
    public partial class uscTaskDispatcher : UserControl
    {
        AGVSDBHelper dbhelper = new AGVSDBHelper();
        ACTION_TYPE _action_selected = ACTION_TYPE.PARK;
        string _AGVName_Selected;
        string ToStationName;

        public string AGVName_Selected
        {
            get => _AGVName_Selected;
            set
            {
                if (_AGVName_Selected != value)
                {
                    _AGVName_Selected = value;
                }
            }
        }
        public AGVInfo AgvSelected
        {
            get
            {
                if (_AGVName_Selected != null)
                {

                    return new AGVInfo()
                    {
                        AGVName = _AGVName_Selected,
                        AGVID = int.Parse(_AGVName_Selected.Split('_')[1])
                    };

                }
                else
                    return null;
            }
        }


        public ACTION_TYPE action_selected
        {
            get => _action_selected;
            set
            {
                if (_action_selected != value)
                {
                    _action_selected = value;
                    UpdateToStationCombox();
                }
            }
        }
        public uscTaskDispatcher()
        {
            InitializeComponent();
        }

        private void uscTaskDispatcher_Load(object sender, EventArgs e)
        {
            cmbActionSelect.Items.AddRange(Enum.GetValues(typeof(ACTION_TYPE)).Cast<object>().ToArray());
        }
        private void UpdateToStationCombox()
        {
            cmbToStationSelect.Text = "";
            cmbFromStationSelect.Text = "";
            cmbToSlotSelect.Text = "";
            cmbFromSlotSelect.Text = "";

            cmbToStationSelect.Items.Clear();
            cmbFromStationSelect.Items.Clear();

            cmbToSlotSelect.Items.Clear();
            cmbFromSlotSelect.Items.Clear();

            pnlFromStationInfo.Enabled = _action_selected == ACTION_TYPE.TRANSFER;
            cmbToSlotSelect.Enabled = cmbFromSlotSelect.Enabled = _action_selected != ACTION_TYPE.MOVE && _action_selected != ACTION_TYPE.PARK && _action_selected != ACTION_TYPE.CHARGE;

            var station_points = Store.MapData.Points;
            IEnumerable<KeyValuePair<int, AGVSystemCommonNet6.MAP.MapPoint>> filteredPoints = null;
            if (_action_selected == ACTION_TYPE.MOVE)
                filteredPoints = station_points.Where(pt => pt.Value.StationType == AGVSystemCommonNet6.AGVDispatch.Messages.STATION_TYPE.Normal);
            else if (_action_selected == ACTION_TYPE.LOAD | _action_selected == ACTION_TYPE.UNLOAD | _action_selected == ACTION_TYPE.TRANSFER)
                filteredPoints = station_points.Where(pt => pt.Value.IsEquipment | pt.Value.IsSTK);
            else if (_action_selected == ACTION_TYPE.PARK)
                filteredPoints = station_points.Where(pt => pt.Value.IsParking);
            else if (_action_selected == ACTION_TYPE.CHARGE)
                filteredPoints = station_points.Where(pt => pt.Value.IsCharge);

            if (filteredPoints != null)
            {
                var points_ = filteredPoints.OrderBy(pt => pt.Value.TagNumber).Select(pt => pt.Value.Name + $":[Tag:{pt.Value.TagNumber}]").ToArray();
                cmbFromStationSelect.Items.AddRange(points_);
                cmbToStationSelect.Items.AddRange(points_);
            }
        }
        private void cmbAGVSelect_DropDown(object sender, EventArgs e)
        {
            cmbAGVSelect.Items.Clear();


            using (var conn = dbhelper.DBConn)
            {
                var agv_names = conn.AGVInfos.ToList().Select(agv => agv.AGVName).ToArray();
                cmbAGVSelect.Items.AddRange(agv_names);
            }


        }
        private void cmbToStationSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToStationName = cmbToStationSelect.SelectedItem.ToString().Split(':')[0];
            }
            catch (Exception)
            {
                ToStationName = cmbToStationSelect.SelectedItem.ToString();
            }
        }
        private void cmbAGVSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            AGVName_Selected = cmbAGVSelect.SelectedItem.ToString();
        }
        private void cmbActionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            action_selected = (ACTION_TYPE)cmbActionSelect.SelectedItem;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AGVS_Dispath_Emulator agvs = new AGVS_Dispath_Emulator();
                var agv = AgvSelected;
                if (agv == null)
                {
                    MessageBox.Show($"請選擇AGV", "派送任務", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AGVS_Dispath_Emulator.ExcuteResult result = null;
                string cst_id = txbCSTID.Text;
                Enabled = false;
                await Task.Factory.StartNew(async () =>
                {
                    try
                    {

                        if (action_selected == ACTION_TYPE.MOVE)
                            result = await agvs.Move(agv.AGVName, agv.AGVID, ToStationName);
                        else if (action_selected == ACTION_TYPE.PARK)
                            result = await agvs.Park(agv.AGVName, agv.AGVID, ToStationName, "1");
                        else if (action_selected == ACTION_TYPE.LOAD)
                            result = await agvs.Load(agv.AGVName, agv.AGVID, ToStationName, "1", cst_id);
                        else if (action_selected == ACTION_TYPE.UNLOAD)
                            result = await agvs.Unload(agv.AGVName, agv.AGVID, ToStationName, "1", cst_id);
                        else if (action_selected == ACTION_TYPE.CHARGE)
                            result = await agvs.Charge(agv.AGVName, agv.AGVID, ToStationName, "1");

                    }
                    catch (Exception ex)
                    {
                        result = new AGVS_Dispath_Emulator.ExcuteResult
                        {
                            ErrorMsg = ex.Message,
                            ResponseMsg = ex.Message,
                        };
                    }

                    Invoke(new Action(() =>
                    {
                        Enabled = true;
                    }));
                    if (!result.Success)
                    {
                        MessageBox.Show($"派送任務失敗\r\n{result.ResponseMsg}", "派送任務", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show($"派送任務成功!", "派送任務", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                Enabled = true;
                MessageBox.Show($"派送任務失敗\r\n{ex.Message}", "派送任務", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
