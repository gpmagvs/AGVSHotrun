using AGVSHotrun.VirtualAGVSystem;
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
    public partial class frmAGVSHost : Form
    {
        public frmAGVSHost()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AGVS_Dispath_Emulator.AGVSHost = txbAGVSIP.Text;
            AGVS_Dispath_Emulator.AGVSPort = (int)numudAGVSPort.Value;
            AGVS_Dispath_Emulator.SaveHostSetting();
            Close();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAGVSHost_Load(object sender, EventArgs e)
        {
            txbAGVSIP.Text = AGVS_Dispath_Emulator.AGVSHost;
            numudAGVSPort.Value = AGVS_Dispath_Emulator.AGVSPort;
        }
    }
}
