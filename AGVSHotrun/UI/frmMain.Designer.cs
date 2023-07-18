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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            AGVSDBHelper agvsdbHelper3 = new AGVSDBHelper();
            AGVSDBHelper agvsdbHelper4 = new AGVSDBHelper();
            statusStrip1 = new StatusStrip();
            labSystemInformation = new ToolStripStatusLabel();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            panel2 = new Panel();
            uscMapDisplay2 = new UI.uscMapDisplay();
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
            tabPage1 = new TabPage();
            panel1 = new Panel();
            uscagvStatus1 = new uscAGVStatus();
            uscExecuteTasks1 = new uscExecuteTasks();
            tabPage2 = new TabPage();
            uscMapDisplay1 = new UI.uscMapDisplay();
            toolTip1 = new ToolTip(components);
            toolStrip1 = new ToolStrip();
            btnNewHotRun = new ToolStripLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHotRunScripts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsHotRunScriptBindingSource).BeginInit();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labSystemInformation });
            statusStrip1.Location = new Point(0, 604);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1260, 22);
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
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.ItemSize = new Size(96, 30);
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1260, 573);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1252, 535);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "HOT RUN";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(uscMapDisplay2);
            panel2.Controls.Add(dgvHotRunScripts);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1246, 529);
            panel2.TabIndex = 0;
            // 
            // uscMapDisplay2
            // 
            uscMapDisplay2.AllowRunTaskDispatch = false;
            uscMapDisplay2.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay2.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay2.Dock = DockStyle.Fill;
            uscMapDisplay2.HighlightAGVName = "";
            uscMapDisplay2.Location = new Point(0, 256);
            uscMapDisplay2.Margin = new Padding(4);
            uscMapDisplay2.Name = "uscMapDisplay2";
            uscMapDisplay2.OnMapPointAddToRunActionClick = null;
            uscMapDisplay2.Size = new Size(1246, 273);
            uscMapDisplay2.TabIndex = 2;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHotRunScripts.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvHotRunScripts.RowTemplate.Height = 25;
            dgvHotRunScripts.Size = new Size(1246, 256);
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
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1252, 535);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "狀態";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(uscagvStatus1);
            panel1.Controls.Add(uscExecuteTasks1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1246, 529);
            panel1.TabIndex = 0;
            // 
            // uscagvStatus1
            // 
            uscagvStatus1.dbHelper = agvsdbHelper3;
            uscagvStatus1.Dock = DockStyle.Fill;
            uscagvStatus1.Location = new Point(0, 0);
            uscagvStatus1.Name = "uscagvStatus1";
            uscagvStatus1.Size = new Size(1246, 153);
            uscagvStatus1.TabIndex = 4;
            // 
            // uscExecuteTasks1
            // 
            uscExecuteTasks1.dbHelper = agvsdbHelper4;
            uscExecuteTasks1.Dock = DockStyle.Bottom;
            uscExecuteTasks1.Location = new Point(0, 153);
            uscExecuteTasks1.Name = "uscExecuteTasks1";
            uscExecuteTasks1.Size = new Size(1246, 376);
            uscExecuteTasks1.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(uscMapDisplay1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1252, 535);
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
            uscMapDisplay1.Size = new Size(1246, 529);
            uscMapDisplay1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNewHotRun, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(1260, 25);
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
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 626);
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
            ((System.ComponentModel.ISupportInitialize)dgvHotRunScripts).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsHotRunScriptBindingSource).EndInit();
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labSystemInformation;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private TabPage tabPage2;
        private uscAGVStatus uscagvStatus1;
        private uscExecuteTasks uscExecuteTasks1;
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
    }
}