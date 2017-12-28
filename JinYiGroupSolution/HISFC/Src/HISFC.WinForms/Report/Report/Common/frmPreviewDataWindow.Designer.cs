namespace Neusoft.WinForms.Report.Common
{
    partial class frmPreviewDataWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreviewDataWindow));
            this.tbPrintView = new System.Windows.Forms.ToolStrip();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.dwPreview = new NeuDataWindow.Controls.NeuDataWindow();
            this.tbPrintView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPrintView
            // 
            this.tbPrintView.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tbPrintView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPrint,
            this.tbQuit,
            this.toolStripLabel1,
            this.cmbZoom});
            this.tbPrintView.Location = new System.Drawing.Point(0, 0);
            this.tbPrintView.Name = "tbPrintView";
            this.tbPrintView.Size = new System.Drawing.Size(1028, 26);
            this.tbPrintView.TabIndex = 1;
            this.tbPrintView.Text = "toolStrip1";
            // 
            // tbPrint
            // 
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(62, 23);
            this.tbPrint.Text = "打印(&P)";
            this.tbPrint.Click += new System.EventHandler(this.tbPrint_Click);
            // 
            // tbQuit
            // 
            this.tbQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbQuit.Image = ((System.Drawing.Image)(resources.GetObject("tbQuit.Image")));
            this.tbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuit.Name = "tbQuit";
            this.tbQuit.Size = new System.Drawing.Size(63, 23);
            this.tbQuit.Text = "关闭(&C)";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 23);
            this.toolStripLabel1.Text = "缩放";
            // 
            // cmbZoom
            // 
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Items.AddRange(new object[] {
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%",
            "120%",
            "140%",
            "160%",
            "180%",
            "200%",
            "300%",
            "500%"});
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(160, 26);
            // 
            // dwPreview
            // 
            this.dwPreview.DataWindowObject = "";
            this.dwPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwPreview.LibraryList = "";
            this.dwPreview.Location = new System.Drawing.Point(0, 26);
            this.dwPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dwPreview.Name = "dwPreview";
            this.dwPreview.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwPreview.Size = new System.Drawing.Size(1028, 545);
            this.dwPreview.TabIndex = 2;
            this.dwPreview.Text = "neuDataWindow1";
            // 
            // frmPreviewDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 571);
            this.Controls.Add(this.dwPreview);
            this.Controls.Add(this.tbPrintView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPreviewDataWindow";
            this.Text = "预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbPrintView.ResumeLayout(false);
            this.tbPrintView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbPrintView;
        private System.Windows.Forms.ToolStripButton tbPrint;
        private System.Windows.Forms.ToolStripButton tbQuit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbZoom;
        private NeuDataWindow.Controls.NeuDataWindow dwPreview;
    }
}