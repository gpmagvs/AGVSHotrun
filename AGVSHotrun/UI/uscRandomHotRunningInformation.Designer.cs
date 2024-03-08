namespace AGVSHotrun.UI
{
    partial class uscRandomHotRunningInformation
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            labRunningTaskNum = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            labFinishTaskNum = new Label();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            labTotalTaskNum = new Label();
            label6 = new Label();
            labScriptID = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLightLight;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(4, 4, 4, 4);
            label1.Size = new Size(975, 30);
            label1.TabIndex = 0;
            label1.Text = "Hot Run Information";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 303);
            dataGridView1.Margin = new Padding(4, 4, 4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(953, 237);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(51, 51, 51);
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 6, 6, 6);
            label2.Size = new Size(255, 48);
            label2.TabIndex = 2;
            label2.Text = "已結束任務數";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labRunningTaskNum
            // 
            labRunningTaskNum.Dock = DockStyle.Fill;
            labRunningTaskNum.Font = new Font("Microsoft JhengHei UI", 28F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            labRunningTaskNum.Location = new Point(0, 48);
            labRunningTaskNum.Margin = new Padding(4, 0, 4, 0);
            labRunningTaskNum.Name = "labRunningTaskNum";
            labRunningTaskNum.Size = new Size(255, 82);
            labRunningTaskNum.TabIndex = 5;
            labRunningTaskNum.Text = "0";
            labRunningTaskNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 51, 51);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 6, 6, 6);
            label5.Size = new Size(255, 48);
            label5.TabIndex = 4;
            label5.Text = "執行中任務數";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(38, 38, 38);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labRunningTaskNum);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(10, 108);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 132);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(38, 38, 38);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(labFinishTaskNum);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(275, 106);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(257, 132);
            panel2.TabIndex = 7;
            // 
            // labFinishTaskNum
            // 
            labFinishTaskNum.Dock = DockStyle.Fill;
            labFinishTaskNum.Font = new Font("Microsoft JhengHei UI", 28F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            labFinishTaskNum.Location = new Point(0, 48);
            labFinishTaskNum.Margin = new Padding(4, 0, 4, 0);
            labFinishTaskNum.Name = "labFinishTaskNum";
            labFinishTaskNum.Size = new Size(255, 82);
            labFinishTaskNum.TabIndex = 5;
            labFinishTaskNum.Text = "0";
            labFinishTaskNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.Location = new Point(5, 251);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 6, 6, 6);
            label3.Size = new Size(255, 48);
            label3.TabIndex = 8;
            label3.Text = "任務歷史";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(38, 38, 38);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(labTotalTaskNum);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(540, 106);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(257, 132);
            panel3.TabIndex = 9;
            // 
            // labTotalTaskNum
            // 
            labTotalTaskNum.Dock = DockStyle.Fill;
            labTotalTaskNum.Font = new Font("Microsoft JhengHei UI", 28F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            labTotalTaskNum.Location = new Point(0, 48);
            labTotalTaskNum.Margin = new Padding(4, 0, 4, 0);
            labTotalTaskNum.Name = "labTotalTaskNum";
            labTotalTaskNum.Size = new Size(255, 82);
            labTotalTaskNum.TabIndex = 5;
            labTotalTaskNum.Text = "0";
            labTotalTaskNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(51, 51, 51);
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 6, 6, 6);
            label6.Size = new Size(255, 48);
            label6.TabIndex = 2;
            label6.Text = "總累計任務數";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labScriptID
            // 
            labScriptID.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labScriptID.Location = new Point(6, 43);
            labScriptID.Margin = new Padding(4, 0, 4, 0);
            labScriptID.Name = "labScriptID";
            labScriptID.Padding = new Padding(6, 6, 6, 6);
            labScriptID.Size = new Size(789, 48);
            labScriptID.TabIndex = 10;
            labScriptID.Text = "-";
            labScriptID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uscRandomHotRunningInformation
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            Controls.Add(labScriptID);
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.White;
            Margin = new Padding(4, 4, 4, 4);
            Name = "uscRandomHotRunningInformation";
            Size = new Size(975, 557);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label labRunningTaskNum;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Label labFinishTaskNum;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private Panel panel3;
        private Label labTotalTaskNum;
        private Label label6;
        private Label labScriptID;
    }
}
