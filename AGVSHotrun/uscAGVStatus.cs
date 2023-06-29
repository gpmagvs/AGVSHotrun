using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVSHotrun
{
    public partial class uscAGVStatus : UserControl
    {
        BindingList<Models.AGVInfo> agv_infos_binding = new BindingList<Models.AGVInfo>();

        AGVSDBHelper dbHelper = new AGVSDBHelper();
        public uscAGVStatus()
        {
            InitializeComponent();
        }

        private void uscAGVStatus_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = agv_infos_binding;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var agv_infos = dbHelper.DBConn.AGVInfos.ToList();
            agv_infos_binding = new BindingList<Models.AGVInfo>(agv_infos);
            dataGridView1.Invalidate();
        }
    }
}
