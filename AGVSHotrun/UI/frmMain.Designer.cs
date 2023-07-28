using AGVSHotrun.Models;

namespace AGVSHotrun
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            AGVSDBHelper agvsdbHelper1 = new AGVSDBHelper();
            AGVSDBHelper agvsdbHelper2 = new AGVSDBHelper();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            statusStrip1 = new StatusStrip();
            labSystemInformation = new ToolStripStatusLabel();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            panel2 = new Panel();
            splitContainer1 = new SplitContainer();
            uscExecuteTasks1 = new uscExecuteTasks();
            label2 = new Label();
            uscagvStatus1 = new uscAGVStatus();
            label1 = new Label();
            uscMapDisplay2 = new UI.uscMapDisplay();
            label3 = new Label();
            dgvHotRunScripts = new DataGridView();
            colHotRunStart = new DataGridViewButtonColumn();
            Description = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            aGVNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            CurrentAction = new DataGridViewTextBoxColumn();
            ProgressText = new DataGridViewTextBoxColumn();
            RepeatNum = new DataGridViewTextBoxColumn();
            FinishNum = new DataGridViewTextBoxColumn();
            TotalActionNum = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            EndTime = new DataGridViewTextBoxColumn();
            ResultDisplay = new DataGridViewTextBoxColumn();
            FailureReason = new DataGridViewTextBoxColumn();
            colHotRunEdit = new DataGridViewButtonColumn();
            colScriptRemove = new DataGridViewButtonColumn();
            clsHotRunScriptBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            uscMapDisplay1 = new UI.uscMapDisplay();
            tabPage1 = new TabPage();
            rtxbLogShow = new RichTextBox();
            toolTip1 = new ToolTip(components);
            toolStrip1 = new ToolStrip();
            btnNewHotRun = new ToolStripLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            btnWaitTaskDoneMode = new ToolStripMenuItem();
            btnCancelChargeTaskMode = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHotRunScripts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsHotRunScriptBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labSystemInformation });
            statusStrip1.Location = new Point(0, 799);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1382, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // labSystemInformation
            // 
            labSystemInformation.Name = "labSystemInformation";
            labSystemInformation.Size = new Size(12, 17);
            labSystemInformation.Text = "_";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.ItemSize = new Size(96, 30);
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1382, 768);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1374, 730);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "HOT RUN";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(splitContainer1);
            panel2.Controls.Add(dgvHotRunScripts);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1368, 724);
            panel2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ScrollBar;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 256);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(uscExecuteTasks1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(uscagvStatus1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(uscMapDisplay2);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(1368, 468);
            splitContainer1.SplitterDistance = 760;
            splitContainer1.TabIndex = 8;
            // 
            // uscExecuteTasks1
            // 
            uscExecuteTasks1.AutoScroll = true;
            uscExecuteTasks1.AutoSize = true;
            uscExecuteTasks1.dbHelper = agvsdbHelper1;
            uscExecuteTasks1.Dock = DockStyle.Fill;
            uscExecuteTasks1.Location = new Point(0, 187);
            uscExecuteTasks1.Margin = new Padding(5);
            uscExecuteTasks1.Name = "uscExecuteTasks1";
            uscExecuteTasks1.Size = new Size(760, 281);
            uscExecuteTasks1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 168);
            label2.Name = "label2";
            label2.Size = new Size(90, 19);
            label2.TabIndex = 9;
            label2.Text = "Task Status";
            // 
            // uscagvStatus1
            // 
            uscagvStatus1.dbHelper = agvsdbHelper2;
            uscagvStatus1.Dock = DockStyle.Top;
            uscagvStatus1.Location = new Point(0, 19);
            uscagvStatus1.Margin = new Padding(4);
            uscagvStatus1.Name = "uscagvStatus1";
            uscagvStatus1.Size = new Size(760, 149);
            uscagvStatus1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 19);
            label1.TabIndex = 8;
            label1.Text = "AGV Status";
            // 
            // uscMapDisplay2
            // 
            uscMapDisplay2.AllowRunTaskDispatch = false;
            uscMapDisplay2.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay2.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay2.Dock = DockStyle.Fill;
            uscMapDisplay2.HighlightAGVName = "";
            uscMapDisplay2.Location = new Point(0, 19);
            uscMapDisplay2.Margin = new Padding(4);
            uscMapDisplay2.Name = "uscMapDisplay2";
            uscMapDisplay2.OnMapPointAddToRunActionClick = null;
            uscMapDisplay2.Size = new Size(604, 449);
            uscMapDisplay2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(42, 19);
            label3.TabIndex = 9;
            label3.Text = "Map";
            // 
            // dgvHotRunScripts
            // 
            dgvHotRunScripts.AllowUserToAddRows = false;
            dgvHotRunScripts.AllowUserToDeleteRows = false;
            dgvHotRunScripts.AutoGenerateColumns = false;
            dgvHotRunScripts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHotRunScripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHotRunScripts.Columns.AddRange(new DataGridViewColumn[] { colHotRunStart, Description, ID, aGVNameDataGridViewTextBoxColumn, CurrentAction, ProgressText, RepeatNum, FinishNum, TotalActionNum, StartTime, EndTime, ResultDisplay, FailureReason, colHotRunEdit, colScriptRemove });
            dgvHotRunScripts.DataSource = clsHotRunScriptBindingSource;
            dgvHotRunScripts.Dock = DockStyle.Top;
            dgvHotRunScripts.Location = new Point(0, 0);
            dgvHotRunScripts.Name = "dgvHotRunScripts";
            dgvHotRunScripts.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHotRunScripts.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHotRunScripts.RowTemplate.Height = 25;
            dgvHotRunScripts.Size = new Size(1368, 256);
            dgvHotRunScripts.TabIndex = 1;
            dgvHotRunScripts.CellClick += dgvHotRunScripts_CellClick;
            // 
            // colHotRunStart
            // 
            colHotRunStart.DataPropertyName = "StartStatus";
            colHotRunStart.HeaderText = "Start";
            colHotRunStart.Name = "colHotRunStart";
            colHotRunStart.ReadOnly = true;
            colHotRunStart.Text = "開始";
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "腳本描述";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ID.DataPropertyName = "ID";
            ID.HeaderText = "創立時間(ID)";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 121;
            // 
            // aGVNameDataGridViewTextBoxColumn
            // 
            aGVNameDataGridViewTextBoxColumn.DataPropertyName = "AGVName";
            aGVNameDataGridViewTextBoxColumn.HeaderText = "AGVName";
            aGVNameDataGridViewTextBoxColumn.Name = "aGVNameDataGridViewTextBoxColumn";
            aGVNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CurrentAction
            // 
            CurrentAction.DataPropertyName = "CurrentAction";
            CurrentAction.HeaderText = "當前動作";
            CurrentAction.Name = "CurrentAction";
            CurrentAction.ReadOnly = true;
            // 
            // ProgressText
            // 
            ProgressText.DataPropertyName = "ProgressText";
            ProgressText.HeaderText = "Progress";
            ProgressText.Name = "ProgressText";
            ProgressText.ReadOnly = true;
            // 
            // RepeatNum
            // 
            RepeatNum.DataPropertyName = "RepeatNum";
            RepeatNum.HeaderText = "重複次數";
            RepeatNum.Name = "RepeatNum";
            RepeatNum.ReadOnly = true;
            // 
            // FinishNum
            // 
            FinishNum.DataPropertyName = "FinishNum";
            FinishNum.HeaderText = "已完成次數";
            FinishNum.Name = "FinishNum";
            FinishNum.ReadOnly = true;
            // 
            // TotalActionNum
            // 
            TotalActionNum.DataPropertyName = "TotalActionNum";
            TotalActionNum.HeaderText = "動作數";
            TotalActionNum.Name = "TotalActionNum";
            TotalActionNum.ReadOnly = true;
            // 
            // StartTime
            // 
            StartTime.DataPropertyName = "StartTime";
            StartTime.HeaderText = "開始時間";
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            EndTime.DataPropertyName = "EndTime";
            EndTime.HeaderText = "結束時間";
            EndTime.Name = "EndTime";
            EndTime.ReadOnly = true;
            // 
            // ResultDisplay
            // 
            ResultDisplay.DataPropertyName = "ResultDisplay";
            ResultDisplay.HeaderText = "執行結果";
            ResultDisplay.Name = "ResultDisplay";
            ResultDisplay.ReadOnly = true;
            // 
            // FailureReason
            // 
            FailureReason.DataPropertyName = "FailureReason";
            FailureReason.HeaderText = "失敗描述";
            FailureReason.Name = "FailureReason";
            FailureReason.ReadOnly = true;
            // 
            // colHotRunEdit
            // 
            colHotRunEdit.HeaderText = "Edit";
            colHotRunEdit.Name = "colHotRunEdit";
            colHotRunEdit.ReadOnly = true;
            colHotRunEdit.Text = "Edit";
            colHotRunEdit.UseColumnTextForButtonValue = true;
            // 
            // colScriptRemove
            // 
            colScriptRemove.HeaderText = "移除";
            colScriptRemove.Name = "colScriptRemove";
            colScriptRemove.ReadOnly = true;
            colScriptRemove.Text = "移除";
            colScriptRemove.UseColumnTextForButtonValue = true;
            // 
            // clsHotRunScriptBindingSource
            // 
            clsHotRunScriptBindingSource.DataSource = typeof(HotRun.clsHotRunScript);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(uscMapDisplay1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1374, 730);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "地圖";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // uscMapDisplay1
            // 
            uscMapDisplay1.AllowRunTaskDispatch = false;
            uscMapDisplay1.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay1.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay1.Dock = DockStyle.Fill;
            uscMapDisplay1.HighlightAGVName = "";
            uscMapDisplay1.Location = new Point(3, 3);
            uscMapDisplay1.Margin = new Padding(4);
            uscMapDisplay1.Name = "uscMapDisplay1";
            uscMapDisplay1.OnMapPointAddToRunActionClick = null;
            uscMapDisplay1.Size = new Size(1368, 724);
            uscMapDisplay1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(rtxbLogShow);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1374, 730);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtxbLogShow
            // 
            rtxbLogShow.BackColor = Color.Black;
            rtxbLogShow.Dock = DockStyle.Fill;
            rtxbLogShow.ForeColor = Color.White;
            rtxbLogShow.Location = new Point(3, 3);
            rtxbLogShow.Name = "rtxbLogShow";
            rtxbLogShow.Size = new Size(1368, 724);
            rtxbLogShow.TabIndex = 0;
            rtxbLogShow.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNewHotRun, toolStripDropDownButton1, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(1382, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNewHotRun
            // 
            btnNewHotRun.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnNewHotRun.Image = (Image)resources.GetObject("btnNewHotRun.Image");
            btnNewHotRun.ImageTransparentColor = Color.Magenta;
            btnNewHotRun.Name = "btnNewHotRun";
            btnNewHotRun.Size = new Size(108, 22);
            btnNewHotRun.Text = "New Hot Run Test";
            btnNewHotRun.Click += btnNewHotRun_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(70, 22);
            toolStripDropDownButton1.Text = "Host設定";
            toolStripDropDownButton1.Click += toolStripDropDownButton1_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { btnWaitTaskDoneMode, btnCancelChargeTaskMode });
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(68, 22);
            toolStripDropDownButton2.Text = "派工選項";
            // 
            // btnWaitTaskDoneMode
            // 
            btnWaitTaskDoneMode.Name = "btnWaitTaskDoneMode";
            btnWaitTaskDoneMode.Size = new Size(230, 22);
            btnWaitTaskDoneMode.Text = "任務下達後等待";
            btnWaitTaskDoneMode.Click += btnWaitTaskDoneMode_Click;
            // 
            // btnCancelChargeTaskMode
            // 
            btnCancelChargeTaskMode.Name = "btnCancelChargeTaskMode";
            btnCancelChargeTaskMode.Size = new Size(230, 22);
            btnCancelChargeTaskMode.Text = "測試過程中自動取消充電任務";
            btnCancelChargeTaskMode.Click += btnCancelChargeTaskWhenRunning_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 821);
            Controls.Add(toolStrip1);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Name = "frmMain";
            Text = "AGVS Hot Runner (Version 1.0,0)";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHotRunScripts).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsHotRunScriptBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labSystemInformation;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private UI.uscMapDisplay uscMapDisplay1;
        private ToolTip toolTip1;
        private ToolStrip toolStrip1;
        private ToolStripLabel btnNewHotRun;
        private TabPage tabPage3;
        private Panel panel2;
        private DataGridView dgvHotRunScripts;
        private BindingSource clsHotRunScriptBindingSource;
        private UI.uscMapDisplay uscMapDisplay2;
        private DataGridViewButtonColumn colHotRunStart;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn aGVNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CurrentAction;
        private DataGridViewTextBoxColumn ProgressText;
        private DataGridViewTextBoxColumn RepeatNum;
        private DataGridViewTextBoxColumn FinishNum;
        private DataGridViewTextBoxColumn TotalActionNum;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private DataGridViewTextBoxColumn ResultDisplay;
        private DataGridViewTextBoxColumn FailureReason;
        private DataGridViewButtonColumn colHotRunEdit;
        private DataGridViewButtonColumn colScriptRemove;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private SplitContainer splitContainer1;
        private uscAGVStatus uscagvStatus1;
        private Label label2;
        private Label label1;
        private Label label3;
        private uscExecuteTasks uscExecuteTasks1;
        private TabPage tabPage1;
        private RichTextBox rtxbLogShow;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem btnWaitTaskDoneMode;
        private ToolStripMenuItem btnCancelChargeTaskMode;
    }
}