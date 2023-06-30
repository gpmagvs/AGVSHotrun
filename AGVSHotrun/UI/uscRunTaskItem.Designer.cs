namespace AGVSHotrun.UI
{
    partial class uscRunTaskItem
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
            label1 = new Label();
            actionComboBox1 = new ActionComboBox();
            label2 = new Label();
            cmbFromStations = new MapStationCombBox();
            cmbToStations = new MapStationCombBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            txbCSTID = new TextBox();
            btnRemove = new Button();
            labActionIndex = new Label();
            panel2 = new Panel();
            btnMoveDown = new Button();
            btnMoveUp = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(82, 8);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "動作";
            // 
            // actionComboBox1
            // 
            actionComboBox1.Location = new Point(119, 3);
            actionComboBox1.Name = "actionComboBox1";
            actionComboBox1.Size = new Size(86, 29);
            actionComboBox1.TabIndex = 1;
            actionComboBox1.OnActionTypeSelected += actionComboBox1_OnActionTypeSelected;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(208, 8);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "From ";
            // 
            // cmbFromStations
            // 
            cmbFromStations.Enabled = false;
            cmbFromStations.Location = new Point(245, 2);
            cmbFromStations.Name = "cmbFromStations";
            cmbFromStations.ShowStaionByAction = Models.ACTION_TYPE.MOVE;
            cmbFromStations.Size = new Size(173, 29);
            cmbFromStations.TabIndex = 3;
            cmbFromStations.OnStationSelect += cmbFromStations_OnStationSelect;
            // 
            // cmbToStations
            // 
            cmbToStations.Location = new Point(540, 3);
            cmbToStations.Name = "cmbToStations";
            cmbToStations.ShowStaionByAction = Models.ACTION_TYPE.MOVE;
            cmbToStations.Size = new Size(173, 29);
            cmbToStations.TabIndex = 5;
            cmbToStations.OnStationSelect += cmbToStations_OnStationSelect;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(512, 8);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 4;
            label3.Text = "To";
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(424, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(67, 23);
            comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(719, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(67, 23);
            comboBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(792, 8);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 8;
            label4.Text = "CST ID";
            // 
            // txbCSTID
            // 
            txbCSTID.BorderStyle = BorderStyle.FixedSingle;
            txbCSTID.Location = new Point(842, 7);
            txbCSTID.Name = "txbCSTID";
            txbCSTID.Size = new Size(140, 23);
            txbCSTID.TabIndex = 9;
            txbCSTID.TextChanged += txbCSTID_TextChanged;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.BackColor = Color.Red;
            btnRemove.FlatAppearance.BorderColor = Color.Black;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(1012, 5);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(100, 26);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "移除";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // labActionIndex
            // 
            labActionIndex.BackColor = SystemColors.ActiveCaption;
            labActionIndex.Dock = DockStyle.Left;
            labActionIndex.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labActionIndex.ForeColor = Color.White;
            labActionIndex.Location = new Point(32, 0);
            labActionIndex.Name = "labActionIndex";
            labActionIndex.Size = new Size(42, 39);
            labActionIndex.TabIndex = 12;
            labActionIndex.Text = "1";
            labActionIndex.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Silver;
            panel2.Controls.Add(btnMoveDown);
            panel2.Controls.Add(btnMoveUp);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 39);
            panel2.TabIndex = 13;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Dock = DockStyle.Bottom;
            btnMoveDown.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnMoveDown.Location = new Point(0, 19);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(32, 20);
            btnMoveDown.TabIndex = 1;
            btnMoveDown.Text = "▼";
            btnMoveDown.TextAlign = ContentAlignment.TopCenter;
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Dock = DockStyle.Top;
            btnMoveUp.Font = new Font("Microsoft JhengHei UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnMoveUp.Location = new Point(0, 0);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(32, 23);
            btnMoveUp.TabIndex = 0;
            btnMoveUp.Text = "▲";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // uscRunTaskItem
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(labActionIndex);
            Controls.Add(btnRemove);
            Controls.Add(txbCSTID);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(cmbToStations);
            Controls.Add(label3);
            Controls.Add(cmbFromStations);
            Controls.Add(label2);
            Controls.Add(actionComboBox1);
            Controls.Add(label1);
            Controls.Add(panel2);
            MinimumSize = new Size(879, 35);
            Name = "uscRunTaskItem";
            Size = new Size(1115, 39);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ActionComboBox actionComboBox1;
        private Label label2;
        private MapStationCombBox cmbFromStations;
        private MapStationCombBox cmbToStations;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label4;
        private TextBox txbCSTID;
        private Button btnRemove;
        private Label labActionIndex;
        private Panel panel2;
        private Button btnMoveUp;
        private Button btnMoveDown;
    }
}
