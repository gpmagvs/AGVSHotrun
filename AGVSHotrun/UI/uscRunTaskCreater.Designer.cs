namespace AGVSHotrun.UI
{
    partial class uscRunTaskCreater
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
            fpnlActionContainer = new FlowLayoutPanel();
            btnAddNewAction = new Button();
            SuspendLayout();
            // 
            // fpnlActionContainer
            // 
            fpnlActionContainer.AllowDrop = true;
            fpnlActionContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fpnlActionContainer.AutoScroll = true;
            fpnlActionContainer.BorderStyle = BorderStyle.FixedSingle;
            fpnlActionContainer.Location = new Point(3, 34);
            fpnlActionContainer.Name = "fpnlActionContainer";
            fpnlActionContainer.Size = new Size(890, 302);
            fpnlActionContainer.TabIndex = 1;
            fpnlActionContainer.DragDrop += fpnlActionContainer_DragDrop;
            // 
            // btnAddNewAction
            // 
            btnAddNewAction.Location = new Point(3, 5);
            btnAddNewAction.Name = "btnAddNewAction";
            btnAddNewAction.Size = new Size(75, 23);
            btnAddNewAction.TabIndex = 2;
            btnAddNewAction.Text = "新增動作";
            btnAddNewAction.UseVisualStyleBackColor = true;
            btnAddNewAction.Click += btnAddNewAction_Click;
            // 
            // uscRunTaskCreater
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(btnAddNewAction);
            Controls.Add(fpnlActionContainer);
            Name = "uscRunTaskCreater";
            Size = new Size(896, 339);
            ResumeLayout(false);
        }

        #endregion

        private uscRunTaskItem uscRunTaskItem1;
        private FlowLayoutPanel fpnlActionContainer;
        private Button btnAddNewAction;
    }
}
