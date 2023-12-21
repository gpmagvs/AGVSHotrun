using AGVSHotrun.HotRun;
using Newtonsoft.Json;
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
    public partial class frmHotRunCreateHelper : Form
    {
        clsHotRunScript script = new clsHotRunScript();
        bool isEditOld = false;
        public frmHotRunCreateHelper()
        {
            InitializeComponent();
            uscRunTaskItem.OnRemoveButtonPush += UscRunTaskItem_OnRemoveButtonPush;
            cmbCIMSimulationMode.SelectedIndex = 0;
            cmbTaskCreateMode.SelectedIndex = 0;

        }
        public frmHotRunCreateHelper(clsHotRunScript _script)
        {
            InitializeComponent();
            btnCreateNewHotRun.Text = "儲存";
            isEditOld = true;
            uscRunTaskItem.OnRemoveButtonPush += UscRunTaskItem_OnRemoveButtonPush;
            script = JsonConvert.DeserializeObject<clsHotRunScript>(JsonConvert.SerializeObject(_script)); //深層複製
            rtxbDescription.Text = script.Description;
            numudTRepeatTime.Value = script.RepeatNum;
            uscMapDisplay1.HighlightAGVName = agvCombox1.AGVSelected = this.script.AGVName;
            cmbCIMSimulationMode.SelectedIndex = script.UseCIMSimulation ? 1 : 0;
            cmbTaskCreateMode.SelectedIndex = script.IsRandomTransferTaskCreateMode ? 1 : 0;
            uscRunTaskCreater1.Add(this.script.RunTasksDesigning);
            numud_beginTaskNumber.Value = script.MaxTaskQueueSize;
        }
        bool isSaveAndExitFlag = false;
        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            isSaveAndExitFlag = true;
            btnCreateNewHotRun_Click(sender, e);
        }
        private void btnCreateNewHotRun_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"確定要{(isEditOld ? "儲存" : "新增")} ? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                script.RunTasksDesigning = uscRunTaskCreater1.runTaskItemUiList.Select(ui => ui.RunTaskDto).ToList();
                if (isEditOld)
                    Store.SaveHotRunScript(script);
                else
                {
                    script.Description = script.Description == "" ? $"Created at {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}" : script.Description;
                    Store.AddNewHotRunScript(script);
                }
                MessageBox.Show("Save Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isSaveAndExitFlag)
                    Close();
            }
        }

        private void agvCombox1_OnAGVSelected(object sender, string AGVName)
        {
            uscMapDisplay1.HighlightAGVName = AGVName;
        }
        private void UscRunTaskItem_OnRemoveButtonPush(object? sender, uscRunTaskItem RunTaskItemUI)
        {
            script.RemoveRunTask(RunTaskItemUI.RunTaskDto);
        }
        private void uscRunTaskCreater1_OnRunTaskItemCreated(object sender, uscRunTaskItem e)
        {
            script.AddRunTask(e.RunTaskDto);
        }

        private void frmHotRunCreateHelper_Load(object sender, EventArgs e)
        {
            uscMapDisplay1.OnMapPointAddToRunActionClick += MapPointActionAddHandle;
        }

        private void MapPointActionAddHandle(uscMapDisplay.clsPointAddToRunActionDto dto)
        {
            uscRunTaskCreater1.Add(new clsRunTask
            {
                Action = dto.action,
                FromStation = dto.map_point.Name
            });
        }

        private void rtxbDescription_TextChanged(object sender, EventArgs e)
        {
            script.Description = rtxbDescription.Text;
        }

        private void numudTRepeatTime_ValueChanged(object sender, EventArgs e)
        {
            script.RepeatNum = (int)numudTRepeatTime.Value;
        }

        private void cmbCIMSimulationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            script.UseCIMSimulation = cmbCIMSimulationMode.SelectedIndex == 1;
        }

        private void cmbTaskCreateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isRandomModeSelected = cmbTaskCreateMode.SelectedIndex == 1;

            script.IsRandomTransferTaskCreateMode = isRandomModeSelected;
            uscRunTaskCreater1.Enabled = !isRandomModeSelected;
            pnlOptionOfRandomMode.Visible = isRandomModeSelected;
        }

        private void numud_beginTaskNumber_ValueChanged(object sender, EventArgs e)
        {
            script.MaxTaskQueueSize = (int)numud_beginTaskNumber.Value;
        }
    }
}
