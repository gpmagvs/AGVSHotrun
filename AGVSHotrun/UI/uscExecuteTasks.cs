using AGVSHotrun.Models;
using AGVSHotrun.UI;
using AGVSHotrun.VirtualAGVSystem;
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
            if (e.RowIndex < 0 | e.ColumnIndex < 0)
                return;

            ExecutingTask data = dataGridView1.Rows[e.RowIndex].DataBoundItem as ExecutingTask;
            var taskName = data.Name;
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show($"確定要取消任務? ({taskName})", "Task Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    AGVS_Dispath_Emulator.CancelTask(taskName);
            }


        }

        public void UI_Render_TIMER_Tick(object sender, EventArgs e)
        {
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

        private void btnCancelAllTasks_Click(object sender, EventArgs e)
        {
            if (DataBinding.Count == 0)
                return;
            if (MessageBox.Show("!!!!!!!注意!!!!! \r\n此操作將會取消派車系統所有任務\r\n確定要進行此操作?", "取消任務確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    var tasknames = DataBinding.Select(t => t.Name).ToList();
                    foreach (string taskname in tasknames)
                    {
                        await AGVS_Dispath_Emulator.CancelTask(taskname);
                    }
                });
            }
        }
    }
}
