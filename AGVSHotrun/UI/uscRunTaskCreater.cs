using AGVSHotrun.HotRun;
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
    public partial class uscRunTaskCreater : UserControl
    {
        public List<uscRunTaskItem> runTaskItemUiList = new List<uscRunTaskItem>();
        public event EventHandler<uscRunTaskItem> OnRunTaskItemCreated;

        public uscRunTaskCreater()
        {
            InitializeComponent();
            uscRunTaskItem.OnRemoveButtonPush += UscRunTaskItem_OnRemoveButtonPush;
            uscRunTaskItem.OnMoveUpButtonPush += UscRunTaskItem_OnMoveUpButtonPush;
            uscRunTaskItem.OnMoveDownButtonPush += UscRunTaskItem_OnMoveDownButtonPush;
        }

        private void UscRunTaskItem_OnMoveDownButtonPush(object? sender, uscRunTaskItem RunTaskItemUI)
        {

            int current_index = runTaskItemUiList.IndexOf(RunTaskItemUI);
            int new_index = current_index + 1;

            if (runTaskItemUiList.Count == new_index)
                return;

            var to_change_ui = runTaskItemUiList[new_index];

            runTaskItemUiList[new_index] = RunTaskItemUI;
            runTaskItemUiList[current_index] = to_change_ui;
            fpnlActionContainer.Controls.Clear();
            fpnlActionContainer.Controls.AddRange(runTaskItemUiList.ToArray());

            ReIndex();
        }

        private void UscRunTaskItem_OnMoveUpButtonPush(object? sender, uscRunTaskItem RunTaskItemUI)
        {
            int current_index = runTaskItemUiList.IndexOf(RunTaskItemUI);
            int new_index = current_index - 1;
            if (new_index < 0)
                return;
            var to_change_ui = runTaskItemUiList[new_index];
            runTaskItemUiList[new_index] = RunTaskItemUI;
            runTaskItemUiList[current_index] = to_change_ui;
            fpnlActionContainer.Controls.Clear();
            fpnlActionContainer.Controls.AddRange(runTaskItemUiList.ToArray());

            ReIndex();
        }

        private void UscRunTaskItem_OnRemoveButtonPush(object? sender, uscRunTaskItem RunTaskItemUI)
        {
            runTaskItemUiList.Remove(RunTaskItemUI);
            fpnlActionContainer.Controls.Remove(RunTaskItemUI);
            ReIndex();
        }
        private void ReIndex(int start_index = 0)
        {
            for (int i = start_index; i < runTaskItemUiList.Count; i++)
            {
                runTaskItemUiList[i].Index = i + 1;
            }
        }
        internal void Add(List<clsRunTask> runTaskList)
        {
            foreach (var runTask in runTaskList)
            {
                Add(runTask, newAdd: false);
            }
        }
        internal void Add(clsRunTask runTask, bool newAdd = true)
        {
            uscRunTaskItem runTaskItem = new uscRunTaskItem(runTask);
            runTaskItemUiList.Add(runTaskItem);
            runTaskItem.Index = runTaskItemUiList.Count;
            fpnlActionContainer.Controls.Add(runTaskItem);
            if (newAdd)
                OnRunTaskItemCreated?.Invoke(this, runTaskItem);
        }

        private void btnAddNewAction_Click(object sender, EventArgs e)
        {
            Add(new clsRunTask());
        }

        private void fpnlActionContainer_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
