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
            picMap.Location = new Point(16, 54);
            picMap.Name = "picMap";
            picMap.Size = new Size(1022, 592);
            picMap.TabIndex = 0;
            picMap.TabStop = false;
            picMap.Click += picMap_Click;
            picMap.Paint += picMap_Paint;
            picMap.MouseClick += picMap_MouseClick;
            picMap.MouseHover += picMap_MouseHover;
            picMap.MouseMove += picMap_MouseMove;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(16, 18);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(411, 21);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Value = 50;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // labCursorInfo
            // 
            labCursorInfo.AutoSize = true;
            labCursorInfo.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labCursorInfo.ForeColor = Color.White;
            labCursorInfo.Location = new Point(439, 19);
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
            LDULDStationMenuStrip.Items.AddRange(new ToolStripItem[] { btnAddULDRunTaskAction, btnAddLDRunTaskAction });
            LDULDStationMenuStrip.Name = "NormalPointContextMenuStrip";
            LDULDStationMenuStrip.Size = new Size(99, 48);
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
            // uscMapDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            BorderStyle = BorderStyle.FixedSingle;
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
    }
}
