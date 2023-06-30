namespace AGVSHotrun
{
    partial class uscTaskDispatcher
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
            cmbAGVSelect = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbActionSelect = new ComboBox();
            label3 = new Label();
            cmbToStationSelect = new ComboBox();
            label4 = new Label();
            cmbToSlotSelect = new ComboBox();
            label5 = new Label();
            txbCSTID = new TextBox();
            button1 = new Button();
            pnlFromStationInfo = new Panel();
            label6 = new Label();
            cmbFromSlotSelect = new ComboBox();
            label7 = new Label();
            cmbFromStationSelect = new ComboBox();
            label8 = new Label();
            pnlFromStationInfo.SuspendLayout();
            SuspendLayout();
            // 
            // cmbAGVSelect
            // 
            cmbAGVSelect.FormattingEnabled = true;
            cmbAGVSelect.Location = new Point(78, 59);
            cmbAGVSelect.Name = "cmbAGVSelect";
            cmbAGVSelect.Size = new Size(172, 23);
            cmbAGVSelect.TabIndex = 0;
            cmbAGVSelect.DropDown += cmbAGVSelect_DropDown;
            cmbAGVSelect.SelectedIndexChanged += cmbAGVSelect_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(8, 62);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "選擇車輛";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(8, 92);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "動作";
            // 
            // cmbActionSelect
            // 
            cmbActionSelect.FormattingEnabled = true;
            cmbActionSelect.Location = new Point(78, 89);
            cmbActionSelect.Name = "cmbActionSelect";
            cmbActionSelect.Size = new Size(172, 23);
            cmbActionSelect.TabIndex = 2;
            cmbActionSelect.SelectedIndexChanged += cmbActionSelect_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(8, 158);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 5;
            label3.Text = "To";
            // 
            // cmbToStationSelect
            // 
            cmbToStationSelect.FormattingEnabled = true;
            cmbToStationSelect.Location = new Point(78, 156);
            cmbToStationSelect.Name = "cmbToStationSelect";
            cmbToStationSelect.Size = new Size(172, 23);
            cmbToStationSelect.TabIndex = 4;
            cmbToStationSelect.SelectedIndexChanged += cmbToStationSelect_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 159);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 7;
            label4.Text = "Slot";
            // 
            // cmbToSlotSelect
            // 
            cmbToSlotSelect.Enabled = false;
            cmbToSlotSelect.FormattingEnabled = true;
            cmbToSlotSelect.Location = new Point(293, 156);
            cmbToSlotSelect.Name = "cmbToSlotSelect";
            cmbToSlotSelect.Size = new Size(75, 23);
            cmbToSlotSelect.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(8, 189);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 8;
            label5.Text = "CST ID";
            // 
            // txbCSTID
            // 
            txbCSTID.BorderStyle = BorderStyle.FixedSingle;
            txbCSTID.Location = new Point(78, 186);
            txbCSTID.Name = "txbCSTID";
            txbCSTID.Size = new Size(172, 23);
            txbCSTID.TabIndex = 9;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(3, 216);
            button1.Name = "button1";
            button1.Padding = new Padding(2);
            button1.Size = new Size(371, 52);
            button1.TabIndex = 10;
            button1.Text = "派送任務";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pnlFromStationInfo
            // 
            pnlFromStationInfo.Controls.Add(label6);
            pnlFromStationInfo.Controls.Add(cmbFromSlotSelect);
            pnlFromStationInfo.Controls.Add(label7);
            pnlFromStationInfo.Controls.Add(cmbFromStationSelect);
            pnlFromStationInfo.Enabled = false;
            pnlFromStationInfo.Location = new Point(0, 121);
            pnlFromStationInfo.Name = "pnlFromStationInfo";
            pnlFromStationInfo.Size = new Size(382, 26);
            pnlFromStationInfo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(259, 5);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 11;
            label6.Text = "Slot";
            // 
            // cmbFromSlotSelect
            // 
            cmbFromSlotSelect.FormattingEnabled = true;
            cmbFromSlotSelect.Location = new Point(293, 2);
            cmbFromSlotSelect.Name = "cmbFromSlotSelect";
            cmbFromSlotSelect.Size = new Size(75, 23);
            cmbFromSlotSelect.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(8, 5);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 9;
            label7.Text = "From";
            // 
            // cmbFromStationSelect
            // 
            cmbFromStationSelect.FormattingEnabled = true;
            cmbFromStationSelect.Location = new Point(78, 2);
            cmbFromStationSelect.Name = "cmbFromStationSelect";
            cmbFromStationSelect.Size = new Size(172, 23);
            cmbFromStationSelect.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(2, 3);
            label8.Name = "label8";
            label8.Size = new Size(141, 40);
            label8.TabIndex = 12;
            label8.Text = "手動任務";
            // 
            // uscTaskDispatcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(pnlFromStationInfo);
            Controls.Add(button1);
            Controls.Add(txbCSTID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cmbToSlotSelect);
            Controls.Add(label3);
            Controls.Add(cmbToStationSelect);
            Controls.Add(label2);
            Controls.Add(cmbActionSelect);
            Controls.Add(label1);
            Controls.Add(cmbAGVSelect);
            Name = "uscTaskDispatcher";
            Size = new Size(382, 271);
            Load += uscTaskDispatcher_Load;
            pnlFromStationInfo.ResumeLayout(false);
            pnlFromStationInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAGVSelect;
        private Label label1;
        private Label label2;
        private ComboBox cmbActionSelect;
        private Label label3;
        private ComboBox cmbToStationSelect;
        private Label label4;
        private ComboBox cmbToSlotSelect;
        private Label label5;
        private TextBox txbCSTID;
        private Button button1;
        private Panel pnlFromStationInfo;
        private Label label6;
        private ComboBox cmbFromSlotSelect;
        private Label label7;
        private ComboBox cmbFromStationSelect;
        private Label label8;
    }
}
