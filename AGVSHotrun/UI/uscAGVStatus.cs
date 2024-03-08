using AGVSHotrun.Models;
using AGVSHotrun.UI;
using AGVSystemCommonNet6.Vehicle_Control.VCSDatabase;
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

namespace AGVSHotrun
{
    public partial class uscAGVStatus : UserControl, IDBINFODisplay
    {
        public BindingList<AGVInfo> DataBinding { get; set; } = new BindingList<AGVInfo>();
        public AGVSDBHelper dbHelper { get; set; } = new AGVSDBHelper();
        public uscAGVStatus()
        {
            InitializeComponent();
        }

        private void uscAGVStatus_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBinding;
        }

      
        int selectedRow = -1;
        int selectedColumn = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 儲存目前選取的儲存格的位置
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            selectedColumn = dataGridView1.CurrentCell.ColumnIndex;
        }


        internal void Render(List<AGVInfo> e)
        {
            Invoke(new Action(() =>
            {
                DataBinding.Clear();
                foreach (var info in e)
                {
                    DataBinding.Add(info);
                }
                DataBinding.ResetBindings();
            }));
        }
    }
}
