using AGVSHotrun.Models;
using AGVSystemCommonNet6.MAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGVSHotrun.UI
{
    public partial class MapStationCombBox : UserControl
    {

        public MapStationCombBox()
        {
            InitializeComponent();
        }
        private ACTION_TYPE _action_selected = ACTION_TYPE.PARK;
        internal string station
        {
            set
            {
                var items = comboBox1.Items;
                if (value != null)
                {
                    string display = items.Cast<string>().FirstOrDefault(item => item.Contains(value));
                    comboBox1.Text = display;
                }
                else
                    comboBox1.Text = "";
            }
        }

        public event EventHandler<MapPoint> OnStationSelect;
        public ACTION_TYPE ShowStaionByAction
        {
            get => _action_selected;
            set
            {
                if (value != _action_selected)
                {
                    _action_selected = value;
                    if (Store.MapData == null)
                        return;
                    UpdateDropDownItems();
                }
            }
        }

        private void UpdateDropDownItems()
        {
            comboBox1.Items.Clear();
            var station_points = Store.MapData.Points;
            IEnumerable<KeyValuePair<int, AGVSystemCommonNet6.MAP.MapPoint>> filteredPoints = null;
            if (ShowStaionByAction == ACTION_TYPE.MOVE)
                filteredPoints = station_points.Where(pt => pt.Value.StationType == AGVSystemCommonNet6.AGVDispatch.Messages.STATION_TYPE.Normal);
            else if (ShowStaionByAction == ACTION_TYPE.LOAD | ShowStaionByAction == ACTION_TYPE.UNLOAD | ShowStaionByAction == ACTION_TYPE.TRANSFER)
                filteredPoints = station_points.Where(pt => pt.Value.IsEquipment | pt.Value.IsSTK);
            else if (ShowStaionByAction == ACTION_TYPE.PARK)
                filteredPoints = station_points.Where(pt => pt.Value.IsParking);
            else if (ShowStaionByAction == ACTION_TYPE.CHARGE)
                filteredPoints = station_points.Where(pt => pt.Value.IsCharge);
            if (filteredPoints != null)
            {
                var points_ = filteredPoints.OrderBy(pt => pt.Value.TagNumber).Select(pt => pt.Value.Name + $":[Tag:{pt.Value.TagNumber}]").ToArray();
                comboBox1.Items.AddRange(points_);
            }
        }

        private void MapStationCombBox_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string display = comboBox1.SelectedItem.ToString();
            string station_name = display.Split(':')[0];
            var station = Store.MapData.Points.Values.FirstOrDefault(pt => pt.Name == station_name);
            OnStationSelect?.Invoke(this, station);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            UpdateDropDownItems();
        }
    }
}
