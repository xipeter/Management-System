using Neusoft.WinForms.Controls;
namespace HIS
{
    partial class SystemErrorForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TitlePanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.BottomPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ContentPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnDetail = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnContinue = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtMessage = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtMethod = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtObject = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.nLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.详细信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(573, 44);
            this.TitlePanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.TitlePanel.TabIndex = 2;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomPanel.Location = new System.Drawing.Point(0, 233);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(573, 134);
            this.BottomPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.BottomPanel.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentPanel.Controls.Add(this.btnDetail);
            this.ContentPanel.Controls.Add(this.btnContinue);
            this.ContentPanel.Controls.Add(this.btnExit);
            this.ContentPanel.Controls.Add(this.txtMessage);
            this.ContentPanel.Controls.Add(this.txtMethod);
            this.ContentPanel.Controls.Add(this.txtObject);
            this.ContentPanel.Controls.Add(this.nLabel4);
            this.ContentPanel.Controls.Add(this.nLabel3);
            this.ContentPanel.Controls.Add(this.nLabel2);
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(573, 234);
            this.ContentPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ContentPanel.TabIndex = 0;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetail.Location = new System.Drawing.Point(466, 120);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(95, 23);
            this.btnDetail.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "详细信息>>";
            this.btnDetail.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnDetail.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnContinue.Location = new System.Drawing.Point(466, 38);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(95, 23);
            this.btnContinue.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "继续(&C)";
            this.btnContinue.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.Location = new System.Drawing.Point(466, 67);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.IsEnter2Tab = false;
            this.txtMessage.Location = new System.Drawing.Point(17, 108);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(429, 90);
            this.txtMessage.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMessage.TabIndex = 4;
            // 
            // txtMethod
            // 
            this.txtMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMethod.IsEnter2Tab = false;
            this.txtMethod.Location = new System.Drawing.Point(17, 67);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(429, 21);
            this.txtMethod.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMethod.TabIndex = 3;
            // 
            // txtObject
            // 
            this.txtObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObject.IsEnter2Tab = false;
            this.txtObject.Location = new System.Drawing.Point(17, 26);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(429, 21);
            this.txtObject.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtObject.TabIndex = 1;
            // 
            // nLabel4
            // 
            this.nLabel4.AutoSize = true;
            this.nLabel4.Location = new System.Drawing.Point(18, 93);
            this.nLabel4.Name = "nLabel4";
            this.nLabel4.Size = new System.Drawing.Size(53, 12);
            this.nLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel4.TabIndex = 2;
            this.nLabel4.Text = "错误信息";
            // 
            // nLabel3
            // 
            this.nLabel3.AutoSize = true;
            this.nLabel3.Location = new System.Drawing.Point(18, 52);
            this.nLabel3.Name = "nLabel3";
            this.nLabel3.Size = new System.Drawing.Size(53, 12);
            this.nLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel3.TabIndex = 2;
            this.nLabel3.Text = "错误方法";
            // 
            // nLabel2
            // 
            this.nLabel2.AutoSize = true;
            this.nLabel2.Location = new System.Drawing.Point(18, 9);
            this.nLabel2.Name = "nLabel2";
            this.nLabel2.Size = new System.Drawing.Size(53, 12);
            this.nLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel2.TabIndex = 2;
            this.nLabel2.Text = "错误对象";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.详细信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // 详细信息ToolStripMenuItem
            // 
            this.详细信息ToolStripMenuItem.Name = "详细信息ToolStripMenuItem";
            this.详细信息ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.详细信息ToolStripMenuItem.Text = "详细信息";
            this.详细信息ToolStripMenuItem.Click += new System.EventHandler(this.详细信息ToolStripMenuItem_Click);
            // 
            // SystemErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 392);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TitlePanel);
            this.Name = "SystemErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统错误";
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel ContentPanel;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel TitlePanel;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel BottomPanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip nContextMenuStrip1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnContinue;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMethod;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtObject;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel nLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMessage;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel nLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel nLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnDetail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 详细信息ToolStripMenuItem;
    }
}