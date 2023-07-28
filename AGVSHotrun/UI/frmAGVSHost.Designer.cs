namespace AGVSHotrun.UI
{
    partial class frmAGVSHost
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
            label1 = new Label();
            txbAGVSIP = new TextBox();
            label2 = new Label();
            numudAGVSPort = new NumericUpDown();
            btnSave = new Button();
            btnLeave = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numudAGVSPort).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "派車系統 IP";
            // 
            // txbAGVSIP
            // 
            txbAGVSIP.Location = new Point(121, 15);
            txbAGVSIP.Name = "txbAGVSIP";
            txbAGVSIP.Size = new Size(171, 23);
            txbAGVSIP.TabIndex = 1;
            txbAGVSIP.Text = "192.168.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 2;
            label2.Text = "派車系統 Port";
            // 
            // numudAGVSPort
            // 
            numudAGVSPort.Location = new Point(121, 56);
            numudAGVSPort.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numudAGVSPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numudAGVSPort.Name = "numudAGVSPort";
            numudAGVSPort.Size = new Size(171, 23);
            numudAGVSPort.TabIndex = 3;
            numudAGVSPort.Value = new decimal(new int[] { 6600, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 103);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(280, 52);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLeave
            // 
            btnLeave.Location = new Point(12, 161);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(280, 52);
            btnLeave.TabIndex = 5;
            btnLeave.Text = "Leave";
            btnLeave.UseVisualStyleBackColor = true;
            btnLeave.Click += btnLeave_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 220);
            button1.Name = "button1";
            button1.Size = new Size(280, 52);
            button1.TabIndex = 6;
            button1.Text = "Connection Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmAGVSHost
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnLeave;
            ClientSize = new Size(307, 284);
            Controls.Add(button1);
            Controls.Add(btnLeave);
            Controls.Add(btnSave);
            Controls.Add(numudAGVSPort);
            Controls.Add(label2);
            Controls.Add(txbAGVSIP);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmAGVSHost";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGVS Host Settings";
            TopMost = true;
            Load += frmAGVSHost_Load;
            ((System.ComponentModel.ISupportInitialize)numudAGVSPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbAGVSIP;
        private Label label2;
        private NumericUpDown numudAGVSPort;
        private Button btnSave;
        private Button btnLeave;
        private Button button1;
    }
}