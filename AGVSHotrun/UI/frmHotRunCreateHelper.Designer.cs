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
            uscMapDisplay1 = new uscMapDisplay();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreateNewHotRun
            // 
            btnCreateNewHotRun.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateNewHotRun.Location = new Point(3, 3);
            btnCreateNewHotRun.Name = "btnCreateNewHotRun";
            btnCreateNewHotRun.Size = new Size(283, 58);
            btnCreateNewHotRun.TabIndex = 1;
            btnCreateNewHotRun.Text = "儲存";
            btnCreateNewHotRun.UseVisualStyleBackColor = true;
            btnCreateNewHotRun.Click += btnCreateNewHotRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 79);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 4;
            label1.Text = "選擇車輛";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 125);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 5;
            label2.Text = "任務列表";
            // 
            // uscRunTaskCreater1
            // 
            uscRunTaskCreater1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uscRunTaskCreater1.BackColor = SystemColors.ControlLight;
            uscRunTaskCreater1.BorderStyle = BorderStyle.FixedSingle;
            uscRunTaskCreater1.Location = new Point(4, 153);
            uscRunTaskCreater1.Name = "uscRunTaskCreater1";
            uscRunTaskCreater1.Size = new Size(855, 529);
            uscRunTaskCreater1.TabIndex = 6;
            uscRunTaskCreater1.OnRunTaskItemCreated += uscRunTaskCreater1_OnRunTaskItemCreated;
            // 
            // agvCombox1
            // 
            agvCombox1.AGVSelected = null;
            agvCombox1.Location = new Point(101, 79);
            agvCombox1.Name = "agvCombox1";
            agvCombox1.Size = new Size(185, 29);
            agvCombox1.TabIndex = 7;
            agvCombox1.OnAGVSelected += agvCombox1_OnAGVSelected;
            // 
            // btnSaveAndExit
            // 
            btnSaveAndExit.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveAndExit.Location = new Point(292, 3);
            btnSaveAndExit.Name = "btnSaveAndExit";
            btnSaveAndExit.Size = new Size(283, 58);
            btnSaveAndExit.TabIndex = 8;
            btnSaveAndExit.Text = "儲存並離開";
            btnSaveAndExit.UseVisualStyleBackColor = true;
            btnSaveAndExit.Click += btnSaveAndExit_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.MenuHighlight;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(btnCreateNewHotRun);
            splitContainer1.Panel1.Controls.Add(btnSaveAndExit);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(agvCombox1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(uscRunTaskCreater1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(uscMapDisplay1);
            splitContainer1.Size = new Size(1441, 685);
            splitContainer1.SplitterDistance = 861;
            splitContainer1.TabIndex = 9;
            // 
            // uscMapDisplay1
            // 
            uscMapDisplay1.AllowRunTaskDispatch = true;
            uscMapDisplay1.BackColor = SystemColors.ControlDarkDark;
            uscMapDisplay1.BorderStyle = BorderStyle.FixedSingle;
            uscMapDisplay1.Dock = DockStyle.Fill;
            uscMapDisplay1.Location = new Point(0, 0);
            uscMapDisplay1.Name = "uscMapDisplay1";
            uscMapDisplay1.OnMapPointAddToRunActionClick = null;
            uscMapDisplay1.Size = new Size(576, 685);
            uscMapDisplay1.TabIndex = 1;
            // 
            // frmHotRunCreateHelper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1441, 685);
            Controls.Add(splitContainer1);
            Name = "frmHotRunCreateHelper";
            Text = "frmHotRunCreateHelper";
            WindowState = FormWindowState.Maximized;
            Load += frmHotRunCreateHelper_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}