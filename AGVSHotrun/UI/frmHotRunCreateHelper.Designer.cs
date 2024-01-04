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
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            cmbTaskCreateMode = new ComboBox();
            labRepeatText = new Label();
            numudTRepeatTime = new NumericUpDown();
            pnlOptionOfRandomMode = new Panel();
            numud_beginTaskNumber = new NumericUpDown();
            label7 = new Label();
            labCIMSimText = new Label();
            cmbCIMSimulationMode = new ComboBox();
            label4 = new Label();
            rtxbDescription = new RichTextBox();
            panel1 = new Panel();
            uscMapDisplay1 = new uscMapDisplay();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRandomOptions = new Panel();
            uscStationSelectCheckboxList1 = new uscStationSelectCheckboxList();
            label3 = new Label();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numudTRepeatTime).BeginInit();
            pnlOptionOfRandomMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_beginTaskNumber).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlRandomOptions.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreateNewHotRun
            // 
            btnCreateNewHotRun.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateNewHotRun.Location = new Point(3, 3);
            btnCreateNewHotRun.Name = "btnCreateNewHotRun";
            btnCreateNewHotRun.Size = new Size(197, 58);
            btnCreateNewHotRun.TabIndex = 1;
            btnCreateNewHotRun.Text = "儲存";
            btnCreateNewHotRun.UseVisualStyleBackColor = true;
            btnCreateNewHotRun.Click += btnCreateNewHotRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 303);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 4;
            label1.Text = "選擇車輛";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
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
            uscRunTaskCreater1.Size = new Size(854, 179);
            uscRunTaskCreater1.TabIndex = 6;
            uscRunTaskCreater1.OnRunTaskItemCreated += uscRunTaskCreater1_OnRunTaskItemCreated;
            // 
            // agvCombox1
            // 
            agvCombox1.AGVSelected = null;
            agvCombox1.Location = new Point(101, 306);
            agvCombox1.Name = "agvCombox1";
            agvCombox1.Size = new Size(194, 29);
            agvCombox1.TabIndex = 7;
            agvCombox1.Visible = false;
            agvCombox1.OnAGVSelected += agvCombox1_OnAGVSelected;
            // 
            // btnSaveAndExit
            // 
            btnSaveAndExit.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveAndExit.Location = new Point(201, 2);
            btnSaveAndExit.Name = "btnSaveAndExit";
            btnSaveAndExit.Size = new Size(197, 58);
            btnSaveAndExit.TabIndex = 8;
            btnSaveAndExit.Text = "儲存並離開";
            btnSaveAndExit.UseVisualStyleBackColor = true;
            btnSaveAndExit.Click += btnSaveAndExit_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(btnCreateNewHotRun);
            panel2.Controls.Add(btnSaveAndExit);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(405, 645);
            panel2.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(cmbTaskCreateMode);
            flowLayoutPanel1.Controls.Add(labRepeatText);
            flowLayoutPanel1.Controls.Add(numudTRepeatTime);
            flowLayoutPanel1.Controls.Add(pnlOptionOfRandomMode);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(rtxbDescription);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(agvCombox1);
            flowLayoutPanel1.Location = new Point(3, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 12, 0, 0);
            flowLayoutPanel1.Size = new Size(395, 573);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(3, 12);
            label6.Name = "label6";
            label6.Size = new Size(171, 25);
            label6.TabIndex = 15;
            label6.Text = "任務生成模式";
            // 
            // cmbTaskCreateMode
            // 
            cmbTaskCreateMode.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTaskCreateMode.FormattingEnabled = true;
            cmbTaskCreateMode.Items.AddRange(new object[] { "自訂", "隨機生成搬運任務" });
            cmbTaskCreateMode.Location = new Point(180, 15);
            cmbTaskCreateMode.Name = "cmbTaskCreateMode";
            cmbTaskCreateMode.Size = new Size(203, 28);
            cmbTaskCreateMode.TabIndex = 16;
            cmbTaskCreateMode.SelectedIndexChanged += cmbTaskCreateMode_SelectedIndexChanged;
            // 
            // labRepeatText
            // 
            labRepeatText.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labRepeatText.Location = new Point(3, 46);
            labRepeatText.Name = "labRepeatText";
            labRepeatText.Padding = new Padding(0, 0, 40, 0);
            labRepeatText.Size = new Size(171, 25);
            labRepeatText.TabIndex = 9;
            labRepeatText.Text = "重複次數";
            // 
            // numudTRepeatTime
            // 
            numudTRepeatTime.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numudTRepeatTime.Location = new Point(180, 49);
            numudTRepeatTime.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numudTRepeatTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numudTRepeatTime.Name = "numudTRepeatTime";
            numudTRepeatTime.Size = new Size(203, 28);
            numudTRepeatTime.TabIndex = 10;
            numudTRepeatTime.TextAlign = HorizontalAlignment.Center;
            numudTRepeatTime.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numudTRepeatTime.ValueChanged += numudTRepeatTime_ValueChanged;
            // 
            // pnlOptionOfRandomMode
            // 
            pnlOptionOfRandomMode.Controls.Add(numud_beginTaskNumber);
            pnlOptionOfRandomMode.Controls.Add(label7);
            pnlOptionOfRandomMode.Controls.Add(labCIMSimText);
            pnlOptionOfRandomMode.Controls.Add(cmbCIMSimulationMode);
            pnlOptionOfRandomMode.Location = new Point(3, 83);
            pnlOptionOfRandomMode.Name = "pnlOptionOfRandomMode";
            pnlOptionOfRandomMode.Size = new Size(392, 75);
            pnlOptionOfRandomMode.TabIndex = 17;
            pnlOptionOfRandomMode.Visible = false;
            // 
            // numud_beginTaskNumber
            // 
            numud_beginTaskNumber.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numud_beginTaskNumber.Location = new Point(179, 10);
            numud_beginTaskNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numud_beginTaskNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numud_beginTaskNumber.Name = "numud_beginTaskNumber";
            numud_beginTaskNumber.Size = new Size(201, 28);
            numud_beginTaskNumber.TabIndex = 12;
            numud_beginTaskNumber.TextAlign = HorizontalAlignment.Center;
            numud_beginTaskNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numud_beginTaskNumber.ValueChanged += numud_beginTaskNumber_ValueChanged;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(-2, 8);
            label7.Name = "label7";
            label7.Size = new Size(171, 25);
            label7.TabIndex = 11;
            label7.Text = "上線車輛數";
            // 
            // labCIMSimText
            // 
            labCIMSimText.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labCIMSimText.Location = new Point(-2, 42);
            labCIMSimText.Name = "labCIMSimText";
            labCIMSimText.Size = new Size(171, 25);
            labCIMSimText.TabIndex = 13;
            labCIMSimText.Text = "CIM模擬設備狀態";
            // 
            // cmbCIMSimulationMode
            // 
            cmbCIMSimulationMode.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCIMSimulationMode.FormattingEnabled = true;
            cmbCIMSimulationMode.Items.AddRange(new object[] { "關閉", "啟用" });
            cmbCIMSimulationMode.Location = new Point(179, 44);
            cmbCIMSimulationMode.Name = "cmbCIMSimulationMode";
            cmbCIMSimulationMode.Size = new Size(201, 28);
            cmbCIMSimulationMode.TabIndex = 14;
            cmbCIMSimulationMode.SelectedIndexChanged += cmbCIMSimulationMode_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 161);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 11;
            label4.Text = "測試腳本描述";
            // 
            // rtxbDescription
            // 
            rtxbDescription.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rtxbDescription.Location = new Point(180, 164);
            rtxbDescription.Name = "rtxbDescription";
            rtxbDescription.Size = new Size(203, 136);
            rtxbDescription.TabIndex = 12;
            rtxbDescription.Text = "";
            rtxbDescription.TextChanged += rtxbDescription_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(uscRunTaskCreater1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3, 0, 0, 0);
            panel1.Size = new Size(859, 206);
            panel1.TabIndex = 18;
            // 
            // uscMapDisplay1
            // 
            uscMapDisplay1.AllowRunTaskDispatch = true;
            uscMapDisplay1.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay1.BackgroundImageLayout = ImageLayout.Center;
            uscMapDisplay1.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay1.Dock = DockStyle.Fill;
            uscMapDisplay1.HighlightAGVName = "";
            uscMapDisplay1.Location = new Point(0, 0);
            uscMapDisplay1.Name = "uscMapDisplay1";
            uscMapDisplay1.OnMapPoinAddtoExceptListClick = null;
            uscMapDisplay1.OnMapPointAddToRunActionClick = null;
            uscMapDisplay1.Size = new Size(865, 216);
            uscMapDisplay1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(405, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(uscMapDisplay1);
            splitContainer1.Size = new Size(865, 645);
            splitContainer1.SplitterDistance = 425;
            splitContainer1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlRandomOptions, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(865, 425);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlRandomOptions
            // 
            pnlRandomOptions.BackColor = SystemColors.ControlLight;
            pnlRandomOptions.BorderStyle = BorderStyle.FixedSingle;
            pnlRandomOptions.Controls.Add(uscStationSelectCheckboxList1);
            pnlRandomOptions.Controls.Add(label3);
            pnlRandomOptions.Dock = DockStyle.Fill;
            pnlRandomOptions.Location = new Point(8, 215);
            pnlRandomOptions.Margin = new Padding(8, 3, 5, 3);
            pnlRandomOptions.Name = "pnlRandomOptions";
            pnlRandomOptions.Size = new Size(852, 207);
            pnlRandomOptions.TabIndex = 19;
            pnlRandomOptions.Visible = false;
            // 
            // uscStationSelectCheckboxList1
            // 
            uscStationSelectCheckboxList1.Dock = DockStyle.Fill;
            uscStationSelectCheckboxList1.Location = new Point(0, 25);
            uscStationSelectCheckboxList1.Name = "uscStationSelectCheckboxList1";
            uscStationSelectCheckboxList1.Size = new Size(850, 180);
            uscStationSelectCheckboxList1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(406, 25);
            label3.TabIndex = 6;
            label3.Text = "例外站點(被選取的站點將不會產生搬運任務)";
            // 
            // frmHotRunCreateHelper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 645);
            Controls.Add(splitContainer1);
            Controls.Add(panel2);
            Name = "frmHotRunCreateHelper";
            Text = "HOT RUN 測試腳本編輯器";
            WindowState = FormWindowState.Maximized;
            Load += frmHotRunCreateHelper_Load;
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numudTRepeatTime).EndInit();
            pnlOptionOfRandomMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numud_beginTaskNumber).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlRandomOptions.ResumeLayout(false);
            pnlRandomOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCreateNewHotRun;
        private Label label1;
        private Label label2;
        private uscRunTaskCreater uscRunTaskCreater1;
        private AGVCombox agvCombox1;
        private Button btnSaveAndExit;
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
        private Panel panel2;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRandomOptions;
        private Label label3;
        private uscStationSelectCheckboxList uscStationSelectCheckboxList1;
    }
}