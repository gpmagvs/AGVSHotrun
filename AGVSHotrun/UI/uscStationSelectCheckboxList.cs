using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class uscStationSelectCheckboxList : UserControl
    {
        IEnumerable<KeyValuePair<int, AGVSystemCommonNet6.MAP.MapPoint>> filteredPoints = null;
        public event EventHandler<List<int>> OnSelectedStationIndexChanged;
        public uscStationSelectCheckboxList()
        {
            InitializeComponent();
        }


        public List<int> IndexListOfSelectedStations
        {
            get
            {
                return new List<int>();
            }
        }

        private void UscStationSelectCheckboxList_Load(object sender, EventArgs e)
        {
            UpdateCheckBoxList();
        }
        private void UpdateCheckBoxList()
        {
            if (Store.MapData == null || Store.MapData.Points == null)
                return;

            checkedListBox1.Items.Clear();
            var station_points = Store.MapData.Points;
            filteredPoints = station_points.Where(pt => pt.Value.IsEquipment | pt.Value.IsSTK);
            if (filteredPoints != null)
            {
                var points_ = filteredPoints.OrderBy(pt => pt.Value.TagNumber).Select(pt => pt.Value.Graph.Display + $":[Tag:{pt.Value.TagNumber}]").ToArray();
                checkedListBox1.Items.AddRange(points_);
            }
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var station_indexList = checkedListBox1.CheckedItems.Cast<string>().Select(name => Store.MapData.GetPointIndexByGraphDisplayName(name.Split(':')[0])).ToList();
            OnSelectedStationIndexChanged?.Invoke(this, station_indexList);
        }

        internal async void UpdateSelectedItems(List<int> exceptStationIndexList)
        {
            while (checkedListBox1.Items.Count == 0)
            {
                await Task.Delay(10);
            }
            var exceptitems = checkedListBox1.Items.Cast<string>().Where(item => exceptStationIndexList.Contains(Store.MapData.GetPointIndexByGraphDisplayName(item.Split(':')[0]))).ToList();
            Invoke(new Action(() =>
            {
                checkedListBox1.SelectedIndexChanged -= CheckedListBox1_SelectedIndexChanged;

                List<string> items = checkedListBox1.Items.Cast<string>().ToList();

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                foreach (var item in exceptitems)
                {
                    var index = items.IndexOf(item);
                    checkedListBox1.SetItemChecked(index, true);
                }
                checkedListBox1.SelectedIndexChanged += CheckedListBox1_SelectedIndexChanged;
            }));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            OnSelectedStationIndexChanged?.Invoke(this, new List<int>());

        }
    }
}
