namespace AGVSHotrun.UI
{
    partial class uscMapDisplay
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
            picMap = new PictureBox();
            hScrollBar1 = new HScrollBar();
            labCursorInfo = new Label();
            NormalPointContextMenuStrip = new ContextMenuStrip(components);
            btnAddNormalMoveAction = new ToolStripMenuItem();
            LDULDStationMenuStrip = new ContextMenuStrip(components);
            btnAddULDRunTaskAction = new ToolStripMenuItem();
            btnAddLDRunTaskAction = new ToolStripMenuItem();
            btnParkStripitem = new ToolStripMenuItem();
            radbtn_Show_IDName = new RadioButton();
            radbtn_Show_GraphDislay = new RadioButton();
            radbtn_Show_Index = new RadioButton();
            radbtn_Show_Tag = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)picMap).BeginInit();
            NormalPointContextMenuStrip.SuspendLayout();
            LDULDStationMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // picMap
            // 
            picMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picMap.BackColor = Color.White;
            picMap.BorderStyle = BorderStyle.FixedSingle;
            picMap.Location = new Point(134, 31);
            picMap.Name = "picMap";
            picMap.Size = new Size(904, 600);
            picMap.TabIndex = 0;
            picMap.TabStop = false;
            picMap.Click += picMap_Click;
            picMap.Paint += picMap_Paint;
            picMap.MouseClick += picMap_MouseClick;
            picMap.MouseDown += picMap_MouseDown;
            picMap.MouseHover += picMap_MouseHover;
            picMap.MouseMove += picMap_MouseMove;
            picMap.MouseUp += picMap_MouseUp;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(134, 7);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(411, 21);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Value = 1;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // labCursorInfo
            // 
            labCursorInfo.AutoSize = true;
            labCursorInfo.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labCursorInfo.ForeColor = Color.White;
            labCursorInfo.Location = new Point(548, 8);
            labCursorInfo.Name = "labCursorInfo";
            labCursorInfo.Size = new Size(54, 20);
            labCursorInfo.TabIndex = 2;
            labCursorInfo.Text = "label1";
            // 
            // NormalPointContextMenuStrip
            // 
            NormalPointContextMenuStrip.Items.AddRange(new ToolStripItem[] { btnAddNormalMoveAction });
            NormalPointContextMenuStrip.Name = "NormalPointContextMenuStrip";
            NormalPointContextMenuStrip.Size = new Size(99, 26);
            // 
            // btnAddNormalMoveAction
            // 
            btnAddNormalMoveAction.Name = "btnAddNormalMoveAction";
            btnAddNormalMoveAction.Size = new Size(98, 22);
            btnAddNormalMoveAction.Text = "加入";
            btnAddNormalMoveAction.Click += btnAddNormalMoveAction_Click;
            // 
            // LDULDStationMenuStrip
            // 
            LDULDStationMenuStrip.Items.AddRange(new ToolStripItem[] { btnAddULDRunTaskAction, btnAddLDRunTaskAction, btnParkStripitem });
            LDULDStationMenuStrip.Name = "NormalPointContextMenuStrip";
            LDULDStationMenuStrip.Size = new Size(99, 70);
            // 
            // btnAddULDRunTaskAction
            // 
            btnAddULDRunTaskAction.Name = "btnAddULDRunTaskAction";
            btnAddULDRunTaskAction.Size = new Size(98, 22);
            btnAddULDRunTaskAction.Text = "取貨";
            btnAddULDRunTaskAction.Click += btnAddULDRunTaskAction_Click;
            // 
            // btnAddLDRunTaskAction
            // 
            btnAddLDRunTaskAction.Name = "btnAddLDRunTaskAction";
            btnAddLDRunTaskAction.Size = new Size(98, 22);
            btnAddLDRunTaskAction.Text = "放貨";
            btnAddLDRunTaskAction.Click += btnAddLDRunTaskAction_Click;
            // 
            // btnParkStripitem
            // 
            btnParkStripitem.Name = "btnParkStripitem";
            btnParkStripitem.Size = new Size(98, 22);
            btnParkStripitem.Text = "停車";
            btnParkStripitem.Click += btnParkStripitem_Click;
            // 
            // radbtn_Show_IDName
            // 
            radbtn_Show_IDName.AutoSize = true;
            radbtn_Show_IDName.ForeColor = Color.White;
            radbtn_Show_IDName.Location = new Point(13, 41);
            radbtn_Show_IDName.Name = "radbtn_Show_IDName";
            radbtn_Show_IDName.Size = new Size(61, 19);
            radbtn_Show_IDName.TabIndex = 3;
            radbtn_Show_IDName.TabStop = true;
            radbtn_Show_IDName.Text = "ID名稱";
            radbtn_Show_IDName.UseVisualStyleBackColor = true;
            radbtn_Show_IDName.CheckedChanged += radbtn_Show_IDName_CheckedChanged;
            // 
            // radbtn_Show_GraphDislay
            // 
            radbtn_Show_GraphDislay.AutoSize = true;
            radbtn_Show_GraphDislay.Checked = true;
            radbtn_Show_GraphDislay.ForeColor = Color.White;
            radbtn_Show_GraphDislay.Location = new Point(13, 66);
            radbtn_Show_GraphDislay.Name = "radbtn_Show_GraphDislay";
            radbtn_Show_GraphDislay.Size = new Size(98, 19);
            radbtn_Show_GraphDislay.TabIndex = 4;
            radbtn_Show_GraphDislay.TabStop = true;
            radbtn_Show_GraphDislay.Text = "名稱(Display)";
            radbtn_Show_GraphDislay.UseVisualStyleBackColor = true;
            radbtn_Show_GraphDislay.CheckedChanged += radbtn_Show_IDName_CheckedChanged;
            // 
            // radbtn_Show_Index
            // 
            radbtn_Show_Index.AutoSize = true;
            radbtn_Show_Index.ForeColor = Color.White;
            radbtn_Show_Index.Location = new Point(13, 116);
            radbtn_Show_Index.Name = "radbtn_Show_Index";
            radbtn_Show_Index.Size = new Size(56, 19);
            radbtn_Show_Index.TabIndex = 5;
            radbtn_Show_Index.TabStop = true;
            radbtn_Show_Index.Text = "Index";
            radbtn_Show_Index.UseVisualStyleBackColor = true;
            radbtn_Show_Index.CheckedChanged += radbtn_Show_IDName_CheckedChanged;
            // 
            // radbtn_Show_Tag
            // 
            radbtn_Show_Tag.AutoSize = true;
            radbtn_Show_Tag.ForeColor = Color.White;
            radbtn_Show_Tag.Location = new Point(13, 91);
            radbtn_Show_Tag.Name = "radbtn_Show_Tag";
            radbtn_Show_Tag.Size = new Size(47, 19);
            radbtn_Show_Tag.TabIndex = 6;
            radbtn_Show_Tag.TabStop = true;
            radbtn_Show_Tag.Text = "Tag";
            radbtn_Show_Tag.UseVisualStyleBackColor = true;
            // 
            // uscMapDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(radbtn_Show_Tag);
            Controls.Add(radbtn_Show_Index);
            Controls.Add(radbtn_Show_GraphDislay);
            Controls.Add(radbtn_Show_IDName);
            Controls.Add(labCursorInfo);
            Controls.Add(hScrollBar1);
            Controls.Add(picMap);
            Name = "uscMapDisplay";
            Size = new Size(1052, 662);
            ((System.ComponentModel.ISupportInitialize)picMap).EndInit();
            NormalPointContextMenuStrip.ResumeLayout(false);
            LDULDStationMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picMap;
        private HScrollBar hScrollBar1;
        private Label labCursorInfo;
        private ContextMenuStrip NormalPointContextMenuStrip;
        private ToolStripMenuItem btnAddNormalMoveAction;
        private ContextMenuStrip LDULDStationMenuStrip;
        private ToolStripMenuItem btnAddULDRunTaskAction;
        private ToolStripMenuItem btnAddLDRunTaskAction;
        private ToolStripMenuItem btnParkStripitem;
        private RadioButton radbtn_Show_IDName;
        private RadioButton radbtn_Show_GraphDislay;
        private RadioButton radbtn_Show_Index;
        private RadioButton radbtn_Show_Tag;
    }
}
