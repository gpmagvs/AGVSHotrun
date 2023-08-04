using AGVSHotrun.HotRun;
using AGVSHotrun.Models;
using AGVSHotrun.UI;
using AGVSHotrun.VirtualAGVSystem;
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
            clsHotRunScript.OnLoopStateChange += HotRunProgressStateChange;
            clsHotRunScript.OnLoginExpireExcetionOccur += ClsHotRunScript_OnLoginExpireExcetionOccur;
            clsHotRunScript.OnHttpExcetionOccur += ClsHotRunScript_OnHttpExcetionOccur;
        }

        private void ClsHotRunScript_OnHttpExcetionOccur(object? sender, clsHotRunScript e)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(this, "�L�k�P�����t�γq�T", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void ClsHotRunScript_OnLoginExpireExcetionOccur(object? sender, clsHotRunScript e)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(this, "�ݭn���s�n�J�����t��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void ClsHotRunScript_OnHotRunFinish(object? sender, clsHotRunScript script)
        {
            Invoke(new Action(() =>
            {
                HotRunProgressStateChange(sender, script);
                if (!script.Success)
                {
                    MessageBox.Show(this, $"{script.AGVName} -Hot Run ���楢��:\r\n{script.FailureReason}", $"{script.AGVName} -{script.FailureReason}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, $"{script.AGVName} - Hot Run ���槹��", "Hot Run ���槹��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }));
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
            Logger.onLogAdded += Logger_onLogAdded;
            Logger.Info("SystemStart");

            btnWaitTaskDoneMode.CheckState = Store.SysConfigs.WaitTaskDoneDispatchMode ? CheckState.Checked : CheckState.Unchecked;
            btnCancelChargeTaskMode.CheckState = Store.SysConfigs.CancelChargeTaskWhenHotRun ? CheckState.Checked : CheckState.Unchecked;
            hotRunScripts = new BindingList<clsHotRunScript>(Store.RunScriptsList);
            dgvHotRunScripts.DataSource = hotRunScripts;
            hotRunScripts.ResetBindings();

            Logger.Info("��Ʈw�s�u��...");
            labSystemInformation.Text = "��Ʈw�s�u��...";
            Task.Run(async () =>
            {

                bool sql_connected = await CheckSqlServerConnection();
                Invoke(new Action(() =>
                {
                    Enabled = true;
                    if (sql_connected)
                    {
                        Logger.Info("��Ʈw�w�s�u");
                        labSystemInformation.Text = "��Ʈw�w�s�u";
                        uscExecuteTasks1.StartRender();
                        uscagvStatus1.StartRender();
                    }
                    else
                    {
                        Logger.Info("��Ʈw�s�u����");
                        labSystemInformation.Text = "��Ʈw�s�u����";
                        Task.Run(() =>
                        {
                            MessageBox.Show("��Ʈw�s�u����..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }));
            });
        }

        private void Logger_onLogAdded(object? sender, Logger.LogEventArgs log_args)
        {
            string lineText = $"{DateTime.Now.ToString()} |{log_args.level}| {log_args.msg}";
            Invoke(new Action(() =>
            {
                if (rtxbLogShow.Text.Length > 65535)
                    rtxbLogShow.ResetText();
                rtxbLogShow.AppendText(lineText + "\r\n");
                rtxbLogShow.ScrollToCaret();
            }));
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
            if (e.ColumnIndex < 0 | e.RowIndex < 0)
                return;

            var click_column = dgvHotRunScripts.CurrentCell.OwningColumn;
            clsHotRunScript script = dgvHotRunScripts.CurrentRow.DataBoundItem as clsHotRunScript;
            if (script == null)
                return;
            if (click_column == colHotRunStart)
            {
                if (script.IsRunning | script.IsWaitLogin)
                {
                    if (MessageBox.Show("�}���w�g�b���椤 ,�T�w�n���_?", "STOP", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Logger.Info($"User STOP Script _{script.ID}");
                        script.Abort();
                    }
                    return;
                }

                //�T�{AGV���A > �p�G�O�B�त
                if (!Debugger.IsAttached)
                {

                    var agv_states = aGVSDBHelper.GetAGVMainStatus(script.AGVName);
                    if (agv_states.RunStatus != RUN_STATE.IDLE)
                    {
                        if (MessageBox.Show($"{script.AGVName} �ثe���A�O {agv_states.RunStatus} , �T�w�n����}��?", "STOP", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                            return;
                    }
                }
                Task.Run(() =>
                {
                    Logger.Info($"User Start Run Script _{script.ID}");
                    if (!script.Start(out string errMsg))
                    {
                        Logger.Info($"Run Script _{script.ID} FAIL:{errMsg}");
                        if (errMsg == "")
                            return;
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                });

            }
            if (click_column == colHotRunEdit)
            {
                UI.frmHotRunCreateHelper editHelper = new UI.frmHotRunCreateHelper(script);
                editHelper.ShowDialog();
            }
            if (click_column == colScriptRemove)
            {
                if (MessageBox.Show("�T�w�n�������}��?", "Script Remove ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Logger.Info($"User Remove Script _{script.ID}");
                    Store.RemoveHotRunScript(script);
                }
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            frmAGVSHost fm = new frmAGVSHost();
            fm.ShowDialog();
        }

        private void btnWaitTaskDoneMode_Click(object sender, EventArgs e)
        {
            Store.SysConfigs.WaitTaskDoneDispatchMode = !Store.SysConfigs.WaitTaskDoneDispatchMode;
            Store.SaveSystemConfig();
            btnWaitTaskDoneMode.CheckState = Store.SysConfigs.WaitTaskDoneDispatchMode ? CheckState.Checked : CheckState.Unchecked;
        }
        private void btnCancelChargeTaskWhenRunning_Click(object sender, EventArgs e)
        {
            Store.SysConfigs.CancelChargeTaskWhenHotRun = !Store.SysConfigs.CancelChargeTaskWhenHotRun;
            Store.SaveSystemConfig();
            btnCancelChargeTaskMode.CheckState = Store.SysConfigs.CancelChargeTaskWhenHotRun ? CheckState.Checked : CheckState.Unchecked;
        }
    }
}