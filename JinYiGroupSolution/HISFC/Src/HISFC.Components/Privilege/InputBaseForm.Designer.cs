namespace Neusoft.Privilege.WinForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBaseForm));
            this.TitlePanel = new Neusoft.WinForms.NPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BottomPanel = new Neusoft.WinForms.NPanel();
            this.ContentPanel = new Neusoft.WinForms.NPanel();
            this.nLabel1 = new Neusoft.WinForms.NLabel();
            this.TitlePanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TitlePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitlePanel.BackgroundImage")));
            this.TitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitlePanel.Controls.Add(this.groupBox1);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(478, 50);
            this.TitlePanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 2);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 293);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(478, 48);
            this.BottomPanel.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.nLabel1);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 50);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(478, 243);
            this.ContentPanel.TabIndex = 0;
            // 
            // nLabel1
            // 
            this.nLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.nLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nLabel1.Enabled = false;
            this.nLabel1.Location = new System.Drawing.Point(0, 242);
            this.nLabel1.Name = "nLabel1";
            this.nLabel1.Size = new System.Drawing.Size(478, 1);
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
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.WinForms.NLabel nLabel1;
        protected Neusoft.WinForms.NPanel ContentPanel;
        protected Neusoft.WinForms.NPanel TitlePanel;
        protected Neusoft.WinForms.NPanel BottomPanel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
