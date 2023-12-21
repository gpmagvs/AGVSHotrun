namespace AGVSHotrun
{
    partial class uscExecuteTasks
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            executingTaskBindingSource = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            btnCancelAllTasks = new Button();
            colCancelTaskBtn = new DataGridViewButtonColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            actionTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            receiveTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FromStationId = new DataGridViewTextBoxColumn();
            fromStationNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FromStationDisplayName = new DataGridViewTextBoxColumn();
            ToStationId = new DataGridViewTextBoxColumn();
            toStationNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ToStationDisplayName = new DataGridViewTextBoxColumn();
            aGVIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            exeVehicleIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assignUserNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priorityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCancelTaskBtn, nameDataGridViewTextBoxColumn, actionTypeDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, receiveTimeDataGridViewTextBoxColumn, startTimeDataGridViewTextBoxColumn, FromStationId, fromStationNameDataGridViewTextBoxColumn, FromStationDisplayName, ToStationId, toStationNameDataGridViewTextBoxColumn, ToStationDisplayName, aGVIDDataGridViewTextBoxColumn, exeVehicleIDDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, assignUserNameDataGridViewTextBoxColumn, priorityDataGridViewTextBoxColumn });
            dataGridView1.DataSource = executingTaskBindingSource;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Aquamarine;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(0, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1263, 345);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // executingTaskBindingSource
            // 
            executingTaskBindingSource.DataSource = typeof(Models.ExecutingTask);
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += UI_Render_TIMER_Tick;
            // 
            // btnCancelAllTasks
            // 
            btnCancelAllTasks.Location = new Point(3, 3);
            btnCancelAllTasks.Name = "btnCancelAllTasks";
            btnCancelAllTasks.Size = new Size(91, 37);
            btnCancelAllTasks.TabIndex = 1;
            btnCancelAllTasks.Text = "取消所有任務";
            btnCancelAllTasks.UseVisualStyleBackColor = true;
            btnCancelAllTasks.Click += btnCancelAllTasks_Click;
            // 
            // colCancelTaskBtn
            // 
            colCancelTaskBtn.HeaderText = "";
            colCancelTaskBtn.Name = "colCancelTaskBtn";
            colCancelTaskBtn.ReadOnly = true;
            colCancelTaskBtn.Text = "取消任務";
            colCancelTaskBtn.UseColumnTextForButtonValue = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "任務ID";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionTypeDataGridViewTextBoxColumn
            // 
            actionTypeDataGridViewTextBoxColumn.DataPropertyName = "ActionType";
            actionTypeDataGridViewTextBoxColumn.HeaderText = "任務動作";
            actionTypeDataGridViewTextBoxColumn.Name = "actionTypeDataGridViewTextBoxColumn";
            actionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "任務狀態";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiveTimeDataGridViewTextBoxColumn
            // 
            receiveTimeDataGridViewTextBoxColumn.DataPropertyName = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.HeaderText = "任務生成時間";
            receiveTimeDataGridViewTextBoxColumn.Name = "receiveTimeDataGridViewTextBoxColumn";
            receiveTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FromStationId
            // 
            FromStationId.DataPropertyName = "FromStationId";
            FromStationId.HeaderText = "起點ID";
            FromStationId.Name = "FromStationId";
            FromStationId.ReadOnly = true;
            // 
            // fromStationNameDataGridViewTextBoxColumn
            // 
            fromStationNameDataGridViewTextBoxColumn.DataPropertyName = "FromStationName";
            fromStationNameDataGridViewTextBoxColumn.HeaderText = "起點名稱";
            fromStationNameDataGridViewTextBoxColumn.Name = "fromStationNameDataGridViewTextBoxColumn";
            fromStationNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FromStationDisplayName
            // 
            FromStationDisplayName.DataPropertyName = "FromStationDisplayName";
            FromStationDisplayName.HeaderText = "起點顯示";
            FromStationDisplayName.Name = "FromStationDisplayName";
            FromStationDisplayName.ReadOnly = true;
            // 
            // ToStationId
            // 
            ToStationId.DataPropertyName = "ToStationId";
            ToStationId.HeaderText = "終點ID";
            ToStationId.Name = "ToStationId";
            ToStationId.ReadOnly = true;
            // 
            // toStationNameDataGridViewTextBoxColumn
            // 
            toStationNameDataGridViewTextBoxColumn.DataPropertyName = "ToStationName";
            toStationNameDataGridViewTextBoxColumn.HeaderText = "終點名稱";
            toStationNameDataGridViewTextBoxColumn.Name = "toStationNameDataGridViewTextBoxColumn";
            toStationNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ToStationDisplayName
            // 
            ToStationDisplayName.DataPropertyName = "ToStationDisplayName";
            ToStationDisplayName.HeaderText = "終點顯示";
            ToStationDisplayName.Name = "ToStationDisplayName";
            ToStationDisplayName.ReadOnly = true;
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            aGVIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // exeVehicleIDDataGridViewTextBoxColumn
            // 
            exeVehicleIDDataGridViewTextBoxColumn.DataPropertyName = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.HeaderText = "執行車輛ID";
            exeVehicleIDDataGridViewTextBoxColumn.Name = "exeVehicleIDDataGridViewTextBoxColumn";
            exeVehicleIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            cSTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assignUserNameDataGridViewTextBoxColumn
            // 
            assignUserNameDataGridViewTextBoxColumn.DataPropertyName = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.HeaderText = "派工者";
            assignUserNameDataGridViewTextBoxColumn.Name = "assignUserNameDataGridViewTextBoxColumn";
            assignUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            priorityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uscExecuteTasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(btnCancelAllTasks);
            Controls.Add(dataGridView1);
            Name = "uscExecuteTasks";
            Size = new Size(1263, 391);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource executingTaskBindingSource;
        private System.Windows.Forms.Timer timer1;
        private Button btnCancelAllTasks;
        private DataGridViewButtonColumn colCancelTaskBtn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn actionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn receiveTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FromStationId;
        private DataGridViewTextBoxColumn fromStationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FromStationDisplayName;
        private DataGridViewTextBoxColumn ToStationId;
        private DataGridViewTextBoxColumn toStationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ToStationDisplayName;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn exeVehicleIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assignUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
    }
}
