namespace Neusoft.HISFC.Components.EPR
{
    partial class ucPrintPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrintPicture));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cboPage = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.cboTimes = new System.Windows.Forms.ToolStripComboBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.printImage = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboPage,
            this.btnRefresh,
            this.cboTimes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(225, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cboPage
            // 
            this.cboPage.AutoToolTip = true;
            this.cboPage.Name = "cboPage";
            this.cboPage.Size = new System.Drawing.Size(75, 31);
            this.cboPage.ToolTipText = "页码";
            this.cboPage.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Neusoft.HISFC.Components.EPR.Properties.Resources.刷新;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.ToolTipText = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboTimes
            // 
            this.cboTimes.AutoToolTip = true;
            this.cboTimes.Items.AddRange(new object[] {
            "500%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "25%",
            "10%"});
            this.cboTimes.Name = "cboTimes";
            this.cboTimes.Size = new System.Drawing.Size(75, 31);
            this.cboTimes.Text = "100%";
            this.cboTimes.ToolTipText = "显示比率";
            this.cboTimes.SelectedIndexChanged += new System.EventHandler(this.cboTimes_SelectedIndexChanged);
            this.cboTimes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTimes_KeyUp);
            // 
            // Panel2
            // 
            this.Panel2.AutoScroll = true;
            this.Panel2.AutoScrollMinSize = new System.Drawing.Size(827, 1169);
            this.Panel2.AutoSize = true;
            this.Panel2.BackColor = System.Drawing.Color.Gray;
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 37);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(800, 680);
            this.Panel2.TabIndex = 7;
            // 
            // printImage
            // 
            this.printImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("printImage.ImageStream")));
            this.printImage.TransparentColor = System.Drawing.Color.Transparent;
            this.printImage.Images.SetKeyName(0, "gChecked");
            this.printImage.Images.SetKeyName(1, "gUnchecked");
            this.printImage.Images.SetKeyName(2, "gRadioChecked");
            this.printImage.Images.SetKeyName(3, "gRadioUnchecked");
            this.printImage.Images.SetKeyName(4, "报警.ico");
            this.printImage.Images.SetKeyName(5, "安排.ico");
            // 
            // ucPrintPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPrintPicture";
            this.Size = new System.Drawing.Size(800, 717);
            this.Load += new System.EventHandler(this.ucPrintPicture_Load);
            this.Resize += new System.EventHandler(this.ucPrintPicture_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ImageList printImage;
        protected System.Windows.Forms.Panel Panel2;
        public System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripComboBox cboPage;
        protected System.Windows.Forms.ToolStripButton btnRefresh;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripComboBox cboTimes;
    }
}