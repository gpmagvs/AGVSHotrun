using AGVSHotrun.HotRun;
using AGVSHotrun.Models;
using AGVSystemCommonNet6.Configuration;
using AGVSystemCommonNet6.MAP;
using System.ComponentModel;
using System.Diagnostics;

namespace AGVSHotrun
{
    public partial class frmMain : Form
    {
        clsSysConfigs configs = new clsSysConfigs();
        AGVSDBHelper aGVSDBHelper = new AGVSDBHelper();
        public frmMain()
        {
            InitializeComponent();
            Store.OnScriptCreated += Store_OnScriptCreated;

            clsHotRunScript.OnHotRunStart += HotRunProgressStateChange;
            clsHotRunScript.OnHotRunFinish += ClsHotRunScript_OnHotRunFinish;

            clsHotRunScript.OnLoopFinish += HotRunProgressStateChange;
            clsHotRunScript.OnLoginExpireExcetionOccur += ClsHotRunScript_OnLoginExpireExcetionOccur;
        }

        private void ClsHotRunScript_OnLoginExpireExcetionOccur(object? sender, clsHotRunScript e)
        {
            MessageBox.Show("需要重新登入派車系統", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClsHotRunScript_OnHotRunFinish(object? sender, clsHotRunScript script)
        {
            HotRunProgressStateChange(sender, script);
            if (!script.Success)
            {
                MessageBox.Show($"Hot Run 執行失敗:{script.FailureReason}", script.FailureReason, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HotRunProgressStateChange(object? sender, clsHotRunScript script)
        {
            Invoke(new Action(() =>
            {
                hotRunScripts.ResetBindings();
            }));
        }

        private void Store_OnScriptCreated(object? sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                hotRunScripts.ResetBindings();
            }));
        }

        private BindingList<clsHotRunScript> hotRunScripts;
        private void Form1_Load(object sender, EventArgs e)
        {
            labSystemInformation.Text = "資料庫連線中...";
            Task.Run(async () =>
            {
                hotRunScripts = new BindingList<clsHotRunScript>(Store.RunScriptsList);
                dgvHotRunScripts.DataSource = hotRunScripts;
                hotRunScripts.ResetBindings();

                bool sql_connected = await CheckSqlServerConnection();
                Invoke(new Action(() =>
                {
                    Enabled = true;
                    if (sql_connected)
                    {
                        labSystemInformation.Text = "資料庫已連線";
                        uscExecuteTasks1.StartRender();
                        uscagvStatus1.StartRender();
                    }
                    else
                    {
                        labSystemInformation.Text = "資料庫連線失敗";
                        Task.Run(() =>
                        {
                            MessageBox.Show("資料庫連線失敗..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }));
            });
        }

        private async Task<bool> CheckSqlServerConnection()
        {
            try
            {
                aGVSDBHelper.DBConn.AGVInfos.First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var agv = aGVSDBHelper.DBConn.AGVInfos.FirstOrDefault(agv => agv.AGVID == 2);

            var ret = aGVSDBHelper.ADD_TASK(new Models.ExecutingTask
            {
                Name = $"*TEST_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}",
                AGVID = 1,
                ActionType = "Move",
                Status = 1,
                ToStationId = 60,
                FromStationId = 60,
                ToStationName = "3",
                FromStationName = "3",
                Receive_Time = DateTime.Now,
                RepeatTime = 1,

            });

            MessageBox.Show("TASK ADD_NUM:" + ret.ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNewHotRun_Click(object sender, EventArgs e)
        {
            UI.frmHotRunCreateHelper helper = new UI.frmHotRunCreateHelper();
            helper.ShowDialog();
        }

        private void dgvHotRunScripts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var click_column = dgvHotRunScripts.CurrentCell.OwningColumn;
            clsHotRunScript script = dgvHotRunScripts.CurrentRow.DataBoundItem as clsHotRunScript;
            if (script == null)
                return;
            if (click_column == colHotRunStart)
            {
                if (!script.Start(out string errMsg))
                {
                    MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (click_column == colHotRunEdit)
            {
                UI.frmHotRunCreateHelper editHelper = new UI.frmHotRunCreateHelper(script);
                editHelper.ShowDialog();
            }
            if (click_column == colScriptRemove)
            {
                if (MessageBox.Show("確定要移除此腳本?", "Script Remove ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    Store.RemoveHotRunScript(script);
            }
        }
    }
}