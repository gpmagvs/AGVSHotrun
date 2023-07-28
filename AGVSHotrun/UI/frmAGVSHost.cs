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
            Store.SaveHostSetting(txbAGVSIP.Text, (int)numudAGVSPort.Value);
            Close();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAGVSHost_Load(object sender, EventArgs e)
        {
            txbAGVSIP.Text = AGVS_Dispath_Emulator.AGVSIP;
            numudAGVSPort.Value = AGVS_Dispath_Emulator.AGVSPORT;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await AGVS_Dispath_Emulator.Login(new CancellationToken());
            if (response.Success)
            {
                MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Fail \r\n{response.ResponseMsg}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
