namespace AGVSHotrun.UI
{
    partial class frmHotRunCreateHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreateNewHotRun = new Button();
            label1 = new Label();
            label2 = new Label();
            uscRunTaskCreater1 = new uscRunTaskCreater();
            agvCombox1 = new AGVCombox();
            btnSaveAndExit = new Button();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            pnlOptionOfRandomMode = new Panel();
            numud_beginTaskNumber = new NumericUpDown();
            label7 = new Label();
            labCIMSimText = new Label();
            cmbCIMSimulationMode = new ComboBox();
            cmbTaskCreateMode = new ComboBox();
            label6 = new Label();
            rtxbDescription = new RichTextBox();
            label4 = new Label();
            numudTRepeatTime = new NumericUpDown();
            labRepeatText = new Label();
            uscMapDisplay1 = new uscMapDisplay();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            pnlOptionOfRandomMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_beginTaskNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numudTRepeatTime).BeginInit();
            SuspendLayout();
            // 
            // btnCreateNewHotRun
            // 
            btnCreateNewHotRun.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateNewHotRun.Location = new Point(12, 12);
            btnCreateNewHotRun.Name = "btnCreateNewHotRun";
            btnCreateNewHotRun.Size = new Size(116, 58);
            btnCreateNewHotRun.TabIndex = 1;
            btnCreateNewHotRun.Text = "儲存";
            btnCreateNewHotRun.UseVisualStyleBackColor = true;
            btnCreateNewHotRun.Click += btnCreateNewHotRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(520, 158);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 4;
            label1.Text = "選擇車輛";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 5;
            label2.Text = "任務列表";
            // 
            // uscRunTaskCreater1
            // 
            uscRunTaskCreater1.BackColor = SystemColors.ControlLight;
            uscRunTaskCreater1.BorderStyle = BorderStyle.FixedSingle;
            uscRunTaskCreater1.Dock = DockStyle.Fill;
            uscRunTaskCreater1.Location = new Point(3, 25);
            uscRunTaskCreater1.Name = "uscRunTaskCreater1";
            uscRunTaskCreater1.Size = new Size(1073, 327);
            uscRunTaskCreater1.TabIndex = 6;
            uscRunTaskCreater1.OnRunTaskItemCreated += uscRunTaskCreater1_OnRunTaskItemCreated;
            // 
            // agvCombox1
            // 
            agvCombox1.AGVSelected = null;
            agvCombox1.Location = new Point(618, 154);
            agvCombox1.Name = "agvCombox1";
            agvCombox1.Size = new Size(194, 29);
            agvCombox1.TabIndex = 7;
            agvCombox1.Visible = false;
            agvCombox1.OnAGVSelected += agvCombox1_OnAGVSelected;
            // 
            // btnSaveAndExit
            // 
            btnSaveAndExit.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveAndExit.Location = new Point(134, 12);
            btnSaveAndExit.Name = "btnSaveAndExit";
            btnSaveAndExit.Size = new Size(188, 58);
            btnSaveAndExit.TabIndex = 8;
            btnSaveAndExit.Text = "儲存並離開";
            btnSaveAndExit.UseVisualStyleBackColor = true;
            btnSaveAndExit.Click += btnSaveAndExit_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Red;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(pnlOptionOfRandomMode);
            splitContainer1.Panel1.Controls.Add(cmbTaskCreateMode);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(rtxbDescription);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(numudTRepeatTime);
            splitContainer1.Panel1.Controls.Add(labRepeatText);
            splitContainer1.Panel1.Controls.Add(btnCreateNewHotRun);
            splitContainer1.Panel1.Controls.Add(btnSaveAndExit);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(agvCombox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(uscMapDisplay1);
            splitContainer1.Size = new Size(1441, 603);
            splitContainer1.SplitterDistance = 1100;
            splitContainer1.SplitterWidth = 8;
            splitContainer1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(uscRunTaskCreater1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(11, 239);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3, 0, 0, 0);
            panel1.Size = new Size(1076, 352);
            panel1.TabIndex = 18;
            // 
            // pnlOptionOfRandomMode
            // 
            pnlOptionOfRandomMode.Controls.Add(numud_beginTaskNumber);
            pnlOptionOfRandomMode.Controls.Add(label7);
            pnlOptionOfRandomMode.Controls.Add(labCIMSimText);
            pnlOptionOfRandomMode.Controls.Add(cmbCIMSimulationMode);
            pnlOptionOfRandomMode.Location = new Point(14, 146);
            pnlOptionOfRandomMode.Name = "pnlOptionOfRandomMode";
            pnlOptionOfRandomMode.Size = new Size(372, 75);
            pnlOptionOfRandomMode.TabIndex = 17;
            pnlOptionOfRandomMode.Visible = false;
            // 
            // numud_beginTaskNumber
            // 
            numud_beginTaskNumber.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            numud_beginTaskNumber.Location = new Point(179, 10);
            numud_beginTaskNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numud_beginTaskNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numud_beginTaskNumber.Name = "numud_beginTaskNumber";
            numud_beginTaskNumber.Size = new Size(184, 23);
            numud_beginTaskNumber.TabIndex = 12;
            numud_beginTaskNumber.TextAlign = HorizontalAlignment.Center;
            numud_beginTaskNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numud_beginTaskNumber.ValueChanged += numud_beginTaskNumber_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(-2, 8);
            label7.Name = "label7";
            label7.Size = new Size(112, 25);
            label7.TabIndex = 11;
            label7.Text = "上線車輛數";
            // 
            // labCIMSimText
            // 
            labCIMSimText.AutoSize = true;
            labCIMSimText.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labCIMSimText.Location = new Point(-2, 42);
            labCIMSimText.Name = "labCIMSimText";
            labCIMSimText.Size = new Size(171, 25);
            labCIMSimText.TabIndex = 13;
            labCIMSimText.Text = "CIM模擬設備狀態";
            // 
            // cmbCIMSimulationMode
            // 
            cmbCIMSimulationMode.FormattingEnabled = true;
            cmbCIMSimulationMode.Items.AddRange(new object[] { "關閉", "啟用" });
            cmbCIMSimulationMode.Location = new Point(179, 44);
            cmbCIMSimulationMode.Name = "cmbCIMSimulationMode";
            cmbCIMSimulationMode.Size = new Size(184, 23);
            cmbCIMSimulationMode.TabIndex = 14;
            cmbCIMSimulationMode.SelectedIndexChanged += cmbCIMSimulationMode_SelectedIndexChanged;
            // 
            // cmbTaskCreateMode
            // 
            cmbTaskCreateMode.FormattingEnabled = true;
            cmbTaskCreateMode.Items.AddRange(new object[] { "自訂", "隨機生成搬運任務" });
            cmbTaskCreateMode.Location = new Point(192, 81);
            cmbTaskCreateMode.Name = "cmbTaskCreateMode";
            cmbTaskCreateMode.Size = new Size(184, 23);
            cmbTaskCreateMode.TabIndex = 16;
            cmbTaskCreateMode.SelectedIndexChanged += cmbTaskCreateMode_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(11, 79);
            label6.Name = "label6";
            label6.Size = new Size(132, 25);
            label6.TabIndex = 15;
            label6.Text = "任務生成模式";
            // 
            // rtxbDescription
            // 
            rtxbDescription.Location = new Point(547, 79);
            rtxbDescription.Name = "rtxbDescription";
            rtxbDescription.Size = new Size(425, 61);
            rtxbDescription.TabIndex = 12;
            rtxbDescription.Text = "";
            rtxbDescription.TextChanged += rtxbDescription_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(409, 79);
            label4.Name = "label4";
            label4.Size = new Size(132, 25);
            label4.TabIndex = 11;
            label4.Text = "測試腳本描述";
            // 
            // numudTRepeatTime
            // 
            numudTRepeatTime.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            numudTRepeatTime.Location = new Point(193, 117);
            numudTRepeatTime.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numudTRepeatTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numudTRepeatTime.Name = "numudTRepeatTime";
            numudTRepeatTime.Size = new Size(184, 23);
            numudTRepeatTime.TabIndex = 10;
            numudTRepeatTime.TextAlign = HorizontalAlignment.Center;
            numudTRepeatTime.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numudTRepeatTime.ValueChanged += numudTRepeatTime_ValueChanged;
            // 
            // labRepeatText
            // 
            labRepeatText.AutoSize = true;
            labRepeatText.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labRepeatText.Location = new Point(12, 115);
            labRepeatText.Name = "labRepeatText";
            labRepeatText.Size = new Size(92, 25);
            labRepeatText.TabIndex = 9;
            labRepeatText.Text = "重複次數";
            // 
            // uscMapDisplay1
            // 
            uscMapDisplay1.AllowRunTaskDispatch = true;
            uscMapDisplay1.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay1.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay1.Dock = DockStyle.Fill;
            uscMapDisplay1.HighlightAGVName = "";
            uscMapDisplay1.Location = new Point(0, 0);
            uscMapDisplay1.Name = "uscMapDisplay1";
            uscMapDisplay1.OnMapPointAddToRunActionClick = null;
            uscMapDisplay1.Size = new Size(333, 603);
            uscMapDisplay1.TabIndex = 1;
            // 
            // frmHotRunCreateHelper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1441, 603);
            Controls.Add(splitContainer1);
            Name = "frmHotRunCreateHelper";
            Text = "HOT RUN 測試腳本編輯器";
            WindowState = FormWindowState.Maximized;
            Load += frmHotRunCreateHelper_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlOptionOfRandomMode.ResumeLayout(false);
            pnlOptionOfRandomMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numud_beginTaskNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)numudTRepeatTime).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCreateNewHotRun;
        private Label label1;
        private Label label2;
        private uscRunTaskCreater uscRunTaskCreater1;
        private AGVCombox agvCombox1;
        private Button btnSaveAndExit;
        private SplitContainer splitContainer1;
        private uscMapDisplay uscMapDisplay1;
        private Label label4;
        private NumericUpDown numudTRepeatTime;
        private Label labRepeatText;
        private RichTextBox rtxbDescription;
        private ComboBox cmbCIMSimulationMode;
        private Label labCIMSimText;
        private Label label6;
        private ComboBox cmbTaskCreateMode;
        private Panel pnlOptionOfRandomMode;
        private NumericUpDown numud_beginTaskNumber;
        private Label label7;
        private Panel panel1;
    }
}