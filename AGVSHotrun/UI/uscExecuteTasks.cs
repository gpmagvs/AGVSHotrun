using AGVSHotrun.Models;
using AGVSHotrun.UI;
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
    public partial class uscExecuteTasks : UserControl, IDBINFODisplay
    {
        public uscExecuteTasks()
        {
            InitializeComponent();
        }

        public AGVSDBHelper dbHelper { get; set; } = new AGVSDBHelper();
        public BindingList<ExecutingTask> DataBinding { get; set; } = new BindingList<ExecutingTask>();

        public void StartRender()
        {
            dataGridView1.DataSource = DataBinding;
            timer1.Start();
        }
        int selectedRow = -1;
        int selectedColumn = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            selectedColumn = dataGridView1.CurrentCell.ColumnIndex;
        }
        public void UI_Render_TIMER_Tick(object sender, EventArgs e)
        {
            // 檢查目前選取的儲存格是否仍然存在
            if (selectedRow >= 0)
                dataGridView1.CurrentCell = dataGridView1[0, selectedRow];
            DataBinding.Clear();
          
                using (var conn = dbHelper.DBConn)
                {
                    var datas = dbHelper.DBConn.ExecutingTasks.ToList();
                    foreach (var data in datas)
                    {
                        DataBinding.Add(data);
                    }
                    DataBinding.ResetBindings();
                }

        }

    }
}
