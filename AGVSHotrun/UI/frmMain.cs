using AGVSHotrun.HotRun;
using AGVSHotrun.Models;
using AGVSHotrun.UI;
using AGVSHotrun.VirtualAGVSystem;
using AGVSystemCommonNet6.Configuration;
using AGVSystemCommonNet6.MAP;
using System.ComponentModel;
using System.Diagnostics;
using static Azure.Core.HttpHeader;

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
            Logger.LOG_FOLDER = Store.SysConfigs.LogFolder;
            Logger.onLogAdded += Logger_onLogAdded;
            Logger.Info("SystemStart");
            if (!File.Exists(Store.SysConfigs.MapFile))
            {
                Store.MapData = new Map
                {
                    Note = "�L�Ī��ɮ׸��|"
                };
                MessageBox.Show($"�ϸ��ɮפ��s�b-Path={Store.SysConfigs.MapFile}", "�ϸ���J����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Store.MapData = MapManager.LoadMapFromFile(Store.SysConfigs.MapFile, out string msg, false, false);
                if (msg != "")
                {
                    MessageBox.Show(msg);
                    Logger.Error(msg);
                }
            }
            labMapNote.Text = "Map-" + Store.MapData.Note;
            labFieldName.Text = Store.SysConfigs.Field + "";
            Logger.Info($"Map Loaded.{Store.MapData.Name}, Note:{Store.MapData.Note}");
            btnWaitTaskDoneMode.CheckState = Store.SysConfigs.WaitTaskDoneDispatchMode ? CheckState.Checked : CheckState.Unchecked;
            btnCancelChargeTaskMode.CheckState = Store.SysConfigs.CancelChargeTaskWhenHotRun ? CheckState.Checked : CheckState.Unchecked;
            hotRunScripts = new BindingList<clsHotRunScript>(Store.RunScriptsList);
            dgvHotRunScripts.DataSource = hotRunScripts;
            hotRunScripts.ResetBindings();

            Logger.Info("��Ʈw�s�u��...");
            labSystemInformation.Text = "��Ʈw�s�u��...";
            var dbconn_task = Task.Run(async () =>
            {

                bool sql_connected = await CheckSqlServerConnection();
                Invoke(new Action(() =>
                {
                    Enabled = true;
                    if (sql_connected)
                    {
                        Logger.Info("��Ʈw�w�s�u");
                        labSystemInformation.Text = "��Ʈw�w�s�u";
                        //Store.StartAGVLocSyncProcess(aGVSDBHelper);
                        Store.OnExecutingTaskUpdate += Store_OnExecutingTaskUpdate;
                        Store.OnAGVInfosUpdate += Store_OnAGVInfosUpdate;

                        Store.StartReadDataFromDataBase(aGVSDBHelper);
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

        private void Store_OnAGVInfosUpdate(object? sender, List<AGVInfo> e)
        {
            uscagvStatus1.Render(e);
        }

        private void Store_OnExecutingTaskUpdate(object? sender, List<ExecutingTask> e)
        {
            uscExecuteTasks1.Render(e);
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
                aGVSDBHelper.Connect(auto_create_database: Store.SysConfigs.IsDebugger);
                aGVSDBHelper.DBConn.AGVInfos.Count();
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

            uscRandomHotRunningInformation1.ChangeScriptToDisplay(script);

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

                if (!script.IsRandomTransferTaskCreateMode && script.RunTasksDesigning.Count == 0)
                {
                    MessageBox.Show($"���ո}�������]�w���Ȱʧ@�A�Х��i��}�����Ȱʧ@�]�w", "SCRIPT RUN FORBIDDEN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var agvNamesInScript = script.RunTasksDesigning.Select(task => task.AGVName).ToList();
                List<string> notIdleAGVNames = agvNamesInScript.FindAll(agvName => aGVSDBHelper.GetAGVMainStatus(agvName).RunStatus == RUN_STATE.RUN);
                if (notIdleAGVNames.Count != 0)
                {
                    var names = string.Join(",", notIdleAGVNames);
                    MessageBox.Show($"���ո}���� {names} ���A����IDLE/CHARGE�A�Х��T�{�UAGV���A��IDLE/CHARGE��i����}��", "SCRIPT RUN FORBIDDEN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Task.Run(() =>
                {

                    if (Store.SysConfigs.Field != FIELD_NAME.UMTC_3F_AOI && script.IsRandomTransferTaskCreateMode)
                    {
                        var result = MessageBox.Show("���}�����H���ͦ��h�B����,�нT�{ : \n- �����t�Τw�}�Ҵ��ռҦ��C\n- �����{���w�}�ҪŨ��ũ�\��C\n\n�O�_�~�� ? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                    }

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