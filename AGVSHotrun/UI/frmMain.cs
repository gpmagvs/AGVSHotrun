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
                MessageBox.Show(this, "無法與派車系統通訊", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void ClsHotRunScript_OnLoginExpireExcetionOccur(object? sender, clsHotRunScript e)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(this, "需要重新登入派車系統", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void ClsHotRunScript_OnHotRunFinish(object? sender, clsHotRunScript script)
        {
            Invoke(new Action(() =>
            {
                HotRunProgressStateChange(sender, script);
                if (!script.Success)
                {
                    MessageBox.Show(this, $"{script.AGVName} -Hot Run 執行失敗:\r\n{script.FailureReason}", $"{script.AGVName} -{script.FailureReason}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(this, $"{script.AGVName} - Hot Run 執行完成", "Hot Run 執行完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Note = "無效的檔案路徑"
                };
                MessageBox.Show($"圖資檔案不存在-Path={Store.SysConfigs.MapFile}", "圖資載入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Logger.Info("資料庫連線中...");
            labSystemInformation.Text = "資料庫連線中...";
            var dbconn_task = Task.Run(async () =>
            {

                bool sql_connected = await CheckSqlServerConnection();
                Invoke(new Action(() =>
                {
                    Enabled = true;
                    if (sql_connected)
                    {
                        Logger.Info("資料庫已連線");
                        labSystemInformation.Text = "資料庫已連線";
                        //Store.StartAGVLocSyncProcess(aGVSDBHelper);
                        Store.OnExecutingTaskUpdate += Store_OnExecutingTaskUpdate;
                        Store.OnAGVInfosUpdate += Store_OnAGVInfosUpdate;

                        Store.StartReadDataFromDataBase(aGVSDBHelper);
                    }
                    else
                    {
                        Logger.Info("資料庫連線失敗");
                        labSystemInformation.Text = "資料庫連線失敗";
                        Task.Run(() =>
                        {
                            MessageBox.Show("資料庫連線失敗..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (MessageBox.Show("腳本已經在執行中 ,確定要中斷?", "STOP", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Logger.Info($"User STOP Script _{script.ID}");
                        script.Abort();
                    }
                    return;
                }

                //確認AGV狀態 > 如果是運轉中

                if (!script.IsRandomTransferTaskCreateMode && script.RunTasksDesigning.Count == 0)
                {
                    MessageBox.Show($"測試腳本中未設定任務動作，請先進行腳本任務動作設定", "SCRIPT RUN FORBIDDEN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var agvNamesInScript = script.RunTasksDesigning.Select(task => task.AGVName).ToList();
                List<string> notIdleAGVNames = agvNamesInScript.FindAll(agvName => aGVSDBHelper.GetAGVMainStatus(agvName).RunStatus == RUN_STATE.RUN);
                if (notIdleAGVNames.Count != 0)
                {
                    var names = string.Join(",", notIdleAGVNames);
                    MessageBox.Show($"測試腳本中 {names} 狀態不為IDLE/CHARGE，請先確認各AGV狀態為IDLE/CHARGE方可執行腳本", "SCRIPT RUN FORBIDDEN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Task.Run(() =>
                {

                    if (Store.SysConfigs.Field != FIELD_NAME.UMTC_3F_AOI && script.IsRandomTransferTaskCreateMode)
                    {
                        var result = MessageBox.Show("此腳本為隨機生成搬運任務,請確認 : \n- 派車系統已開啟測試模式。\n- 車載程式已開啟空取空放功能。\n\n是否繼續 ? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                if (MessageBox.Show("確定要移除此腳本?", "Script Remove ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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