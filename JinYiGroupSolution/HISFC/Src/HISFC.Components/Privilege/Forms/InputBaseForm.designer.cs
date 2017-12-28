namespace Neusoft.HISFC.Components.Privilege
{
    partial class InputBaseForm
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
            this.TitlePanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.BottomPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ContentPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.nLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 338);
            this.statusBar1.Size = new System.Drawing.Size(478, 25);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.Transparent;
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(478, 50);
            this.TitlePanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.TitlePanel.TabIndex = 2;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 290);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(478, 48);
            this.BottomPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.BottomPanel.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.nLabel1);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 50);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(478, 240);
            this.ContentPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ContentPanel.TabIndex = 0;
            // 
            // nLabel1
            // 
            this.nLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.nLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nLabel1.Enabled = false;
            this.nLabel1.Location = new System.Drawing.Point(0, 239);
            this.nLabel1.Name = "nLabel1";
            this.nLabel1.Size = new System.Drawing.Size(478, 1);
            this.nLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel1.TabIndex = 0;
            // 
            // InputBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(478, 363);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TitlePanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBaseForm";
            this.Text = "frmInputBase";
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FrameWork.WinForms.Controls.NeuLabel nLabel1;
        protected FrameWork.WinForms.Controls.NeuPanel ContentPanel;
        protected FrameWork.WinForms.Controls.NeuPanel TitlePanel;
        protected FrameWork.WinForms.Controls.NeuPanel BottomPanel;
        
    }
}
