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
            currentPosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doTaskNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVModeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alarmCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alarmDescriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            batteryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            battery2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            e82VehicleStateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            forkHeightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            processResultDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVInfoBindingSource = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { aGVIDDataGridViewTextBoxColumn, aGVNameDataGridViewTextBoxColumn, aGVMainStatusDataGridViewTextBoxColumn, aGVSubStatusDataGridViewTextBoxColumn, currentPosDataGridViewTextBoxColumn, doTaskNameDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, aGVModeDataGridViewTextBoxColumn, alarmCodeDataGridViewTextBoxColumn, alarmDescriptionDataGridViewTextBoxColumn, batteryDataGridViewTextBoxColumn, battery2DataGridViewTextBoxColumn, e82VehicleStateDataGridViewTextBoxColumn, forkHeightDataGridViewTextBoxColumn, processResultDataGridViewTextBoxColumn });
            dataGridView1.DataSource = aGVInfoBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1144, 396);
            dataGridView1.TabIndex = 0;
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            // 
            // aGVNameDataGridViewTextBoxColumn
            // 
            aGVNameDataGridViewTextBoxColumn.DataPropertyName = "AGVName";
            aGVNameDataGridViewTextBoxColumn.HeaderText = "AGVName";
            aGVNameDataGridViewTextBoxColumn.Name = "aGVNameDataGridViewTextBoxColumn";
            // 
            // aGVMainStatusDataGridViewTextBoxColumn
            // 
            aGVMainStatusDataGridViewTextBoxColumn.DataPropertyName = "AGVMainStatus";
            aGVMainStatusDataGridViewTextBoxColumn.HeaderText = "AGVMainStatus";
            aGVMainStatusDataGridViewTextBoxColumn.Name = "aGVMainStatusDataGridViewTextBoxColumn";
            // 
            // aGVSubStatusDataGridViewTextBoxColumn
            // 
            aGVSubStatusDataGridViewTextBoxColumn.DataPropertyName = "AGVSubStatus";
            aGVSubStatusDataGridViewTextBoxColumn.HeaderText = "AGVSubStatus";
            aGVSubStatusDataGridViewTextBoxColumn.Name = "aGVSubStatusDataGridViewTextBoxColumn";
            // 
            // currentPosDataGridViewTextBoxColumn
            // 
            currentPosDataGridViewTextBoxColumn.DataPropertyName = "CurrentPos";
            currentPosDataGridViewTextBoxColumn.HeaderText = "CurrentPos";
            currentPosDataGridViewTextBoxColumn.Name = "currentPosDataGridViewTextBoxColumn";
            // 
            // doTaskNameDataGridViewTextBoxColumn
            // 
            doTaskNameDataGridViewTextBoxColumn.DataPropertyName = "DoTaskName";
            doTaskNameDataGridViewTextBoxColumn.HeaderText = "DoTaskName";
            doTaskNameDataGridViewTextBoxColumn.Name = "doTaskNameDataGridViewTextBoxColumn";
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            // 
            // aGVModeDataGridViewTextBoxColumn
            // 
            aGVModeDataGridViewTextBoxColumn.DataPropertyName = "AGVMode";
            aGVModeDataGridViewTextBoxColumn.HeaderText = "AGVMode";
            aGVModeDataGridViewTextBoxColumn.Name = "aGVModeDataGridViewTextBoxColumn";
            // 
            // alarmCodeDataGridViewTextBoxColumn
            // 
            alarmCodeDataGridViewTextBoxColumn.DataPropertyName = "AlarmCode";
            alarmCodeDataGridViewTextBoxColumn.HeaderText = "AlarmCode";
            alarmCodeDataGridViewTextBoxColumn.Name = "alarmCodeDataGridViewTextBoxColumn";
            // 
            // alarmDescriptionDataGridViewTextBoxColumn
            // 
            alarmDescriptionDataGridViewTextBoxColumn.DataPropertyName = "AlarmDescription";
            alarmDescriptionDataGridViewTextBoxColumn.HeaderText = "AlarmDescription";
            alarmDescriptionDataGridViewTextBoxColumn.Name = "alarmDescriptionDataGridViewTextBoxColumn";
            // 
            // batteryDataGridViewTextBoxColumn
            // 
            batteryDataGridViewTextBoxColumn.DataPropertyName = "Battery";
            batteryDataGridViewTextBoxColumn.HeaderText = "Battery";
            batteryDataGridViewTextBoxColumn.Name = "batteryDataGridViewTextBoxColumn";
            // 
            // battery2DataGridViewTextBoxColumn
            // 
            battery2DataGridViewTextBoxColumn.DataPropertyName = "Battery2";
            battery2DataGridViewTextBoxColumn.HeaderText = "Battery2";
            battery2DataGridViewTextBoxColumn.Name = "battery2DataGridViewTextBoxColumn";
            // 
            // e82VehicleStateDataGridViewTextBoxColumn
            // 
            e82VehicleStateDataGridViewTextBoxColumn.DataPropertyName = "E82VehicleState";
            e82VehicleStateDataGridViewTextBoxColumn.HeaderText = "E82VehicleState";
            e82VehicleStateDataGridViewTextBoxColumn.Name = "e82VehicleStateDataGridViewTextBoxColumn";
            // 
            // forkHeightDataGridViewTextBoxColumn
            // 
            forkHeightDataGridViewTextBoxColumn.DataPropertyName = "ForkHeight";
            forkHeightDataGridViewTextBoxColumn.HeaderText = "ForkHeight";
            forkHeightDataGridViewTextBoxColumn.Name = "forkHeightDataGridViewTextBoxColumn";
            // 
            // processResultDataGridViewTextBoxColumn
            // 
            processResultDataGridViewTextBoxColumn.DataPropertyName = "ProcessResult";
            processResultDataGridViewTextBoxColumn.HeaderText = "ProcessResult";
            processResultDataGridViewTextBoxColumn.Name = "processResultDataGridViewTextBoxColumn";
            // 
            // aGVInfoBindingSource
            // 
            aGVInfoBindingSource.DataSource = typeof(Models.AGVInfo);
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
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
            ((System.ComponentModel.ISupportInitialize)aGVInfoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource aGVInfoBindingSource;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVMainStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVSubStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn currentPosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn doTaskNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVModeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alarmCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alarmDescriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn batteryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn battery2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn e82VehicleStateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn forkHeightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn processResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timer1;
    }
}
