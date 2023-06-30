namespace AGVSHotrun
{
    partial class uscAGVStatus
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
            dataGridView1 = new DataGridView();
            aGVIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVMainStatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVSubStatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVModeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            currentPosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doTaskNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            batteryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            battery2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alarmCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alarmDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            e82VehicleStateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            forkHeightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            processResultDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVInfoBindingSource1 = new BindingSource(components);
            aGVInfoBindingSource = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { aGVIDDataGridViewTextBoxColumn, aGVNameDataGridViewTextBoxColumn, aGVMainStatusDataGridViewTextBoxColumn, aGVSubStatusDataGridViewTextBoxColumn, aGVModeDataGridViewTextBoxColumn, currentPosDataGridViewTextBoxColumn, doTaskNameDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, batteryDataGridViewTextBoxColumn, battery2DataGridViewTextBoxColumn, alarmCodeDataGridViewTextBoxColumn, alarmDescriptionDataGridViewTextBoxColumn, e82VehicleStateDataGridViewTextBoxColumn, forkHeightDataGridViewTextBoxColumn, processResultDataGridViewTextBoxColumn });
            dataGridView1.DataSource = aGVInfoBindingSource1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1144, 396);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            aGVIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVNameDataGridViewTextBoxColumn
            // 
            aGVNameDataGridViewTextBoxColumn.DataPropertyName = "AGVName";
            aGVNameDataGridViewTextBoxColumn.HeaderText = "AGVName";
            aGVNameDataGridViewTextBoxColumn.Name = "aGVNameDataGridViewTextBoxColumn";
            aGVNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVMainStatusDataGridViewTextBoxColumn
            // 
            aGVMainStatusDataGridViewTextBoxColumn.DataPropertyName = "AGVMainStatus";
            aGVMainStatusDataGridViewTextBoxColumn.HeaderText = "AGVMainStatus";
            aGVMainStatusDataGridViewTextBoxColumn.Name = "aGVMainStatusDataGridViewTextBoxColumn";
            aGVMainStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVSubStatusDataGridViewTextBoxColumn
            // 
            aGVSubStatusDataGridViewTextBoxColumn.DataPropertyName = "AGVSubStatus";
            aGVSubStatusDataGridViewTextBoxColumn.HeaderText = "AGVSubStatus";
            aGVSubStatusDataGridViewTextBoxColumn.Name = "aGVSubStatusDataGridViewTextBoxColumn";
            aGVSubStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVModeDataGridViewTextBoxColumn
            // 
            aGVModeDataGridViewTextBoxColumn.DataPropertyName = "AGVMode";
            aGVModeDataGridViewTextBoxColumn.HeaderText = "AGVMode";
            aGVModeDataGridViewTextBoxColumn.Name = "aGVModeDataGridViewTextBoxColumn";
            aGVModeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentPosDataGridViewTextBoxColumn
            // 
            currentPosDataGridViewTextBoxColumn.DataPropertyName = "CurrentPos";
            currentPosDataGridViewTextBoxColumn.HeaderText = "CurrentPos";
            currentPosDataGridViewTextBoxColumn.Name = "currentPosDataGridViewTextBoxColumn";
            currentPosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doTaskNameDataGridViewTextBoxColumn
            // 
            doTaskNameDataGridViewTextBoxColumn.DataPropertyName = "DoTaskName";
            doTaskNameDataGridViewTextBoxColumn.HeaderText = "DoTaskName";
            doTaskNameDataGridViewTextBoxColumn.Name = "doTaskNameDataGridViewTextBoxColumn";
            doTaskNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            cSTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batteryDataGridViewTextBoxColumn
            // 
            batteryDataGridViewTextBoxColumn.DataPropertyName = "Battery";
            batteryDataGridViewTextBoxColumn.HeaderText = "Battery";
            batteryDataGridViewTextBoxColumn.Name = "batteryDataGridViewTextBoxColumn";
            batteryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // battery2DataGridViewTextBoxColumn
            // 
            battery2DataGridViewTextBoxColumn.DataPropertyName = "Battery2";
            battery2DataGridViewTextBoxColumn.HeaderText = "Battery2";
            battery2DataGridViewTextBoxColumn.Name = "battery2DataGridViewTextBoxColumn";
            battery2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alarmCodeDataGridViewTextBoxColumn
            // 
            alarmCodeDataGridViewTextBoxColumn.DataPropertyName = "AlarmCode";
            alarmCodeDataGridViewTextBoxColumn.HeaderText = "AlarmCode";
            alarmCodeDataGridViewTextBoxColumn.Name = "alarmCodeDataGridViewTextBoxColumn";
            alarmCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alarmDescriptionDataGridViewTextBoxColumn
            // 
            alarmDescriptionDataGridViewTextBoxColumn.DataPropertyName = "AlarmDescription";
            alarmDescriptionDataGridViewTextBoxColumn.HeaderText = "AlarmDescription";
            alarmDescriptionDataGridViewTextBoxColumn.Name = "alarmDescriptionDataGridViewTextBoxColumn";
            alarmDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // e82VehicleStateDataGridViewTextBoxColumn
            // 
            e82VehicleStateDataGridViewTextBoxColumn.DataPropertyName = "E82VehicleState";
            e82VehicleStateDataGridViewTextBoxColumn.HeaderText = "E82VehicleState";
            e82VehicleStateDataGridViewTextBoxColumn.Name = "e82VehicleStateDataGridViewTextBoxColumn";
            e82VehicleStateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // forkHeightDataGridViewTextBoxColumn
            // 
            forkHeightDataGridViewTextBoxColumn.DataPropertyName = "ForkHeight";
            forkHeightDataGridViewTextBoxColumn.HeaderText = "ForkHeight";
            forkHeightDataGridViewTextBoxColumn.Name = "forkHeightDataGridViewTextBoxColumn";
            forkHeightDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // processResultDataGridViewTextBoxColumn
            // 
            processResultDataGridViewTextBoxColumn.DataPropertyName = "ProcessResult";
            processResultDataGridViewTextBoxColumn.HeaderText = "ProcessResult";
            processResultDataGridViewTextBoxColumn.Name = "processResultDataGridViewTextBoxColumn";
            processResultDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVInfoBindingSource1
            // 
            aGVInfoBindingSource1.DataSource = typeof(Models.AGVInfo);
            // 
            // aGVInfoBindingSource
            // 
            aGVInfoBindingSource.DataSource = typeof(Models.AGVInfo);
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += UI_Render_TIMER_Tick;
            // 
            // uscAGVStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "uscAGVStatus";
            Size = new Size(1144, 396);
            Load += uscAGVStatus_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource aGVInfoBindingSource;
        private System.Windows.Forms.Timer timer1;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVMainStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVSubStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVModeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentPosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn doTaskNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn batteryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn battery2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alarmCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alarmDescriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn e82VehicleStateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn forkHeightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn processResultDataGridViewTextBoxColumn;
        private BindingSource aGVInfoBindingSource1;
    }
}
