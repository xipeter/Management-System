namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    partial class frmSearchName
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbSearch;
        private System.Windows.Forms.ToolBarButton tbExport;
        private System.Windows.Forms.ToolBarButton tbPrint;
        private System.Windows.Forms.ToolBarButton tbExist;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private HealthRecord.Search.ucNameSreach ucNameSreach1;
        private HealthRecord.Search.ucShowCaseInfo ucShowCaseInfo1;

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSearchName));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbSearch = new System.Windows.Forms.ToolBarButton();
            this.tbExport = new System.Windows.Forms.ToolBarButton();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbExist = new System.Windows.Forms.ToolBarButton();
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucNameSreach1 = new ucNameSreach();
            this.ucShowCaseInfo1 = new ucShowCaseInfo();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbSearch,
																						this.tbExport,
																						this.tbPrint,
																						this.tbExist});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList32;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1016, 57);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbSearch
            // 
            this.tbSearch.ImageIndex = 11;
            this.tbSearch.Text = "查询(F4)";
            // 
            // tbExport
            // 
            this.tbExport.ImageIndex = 36;
            this.tbExport.Text = "导出(F5)";
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 12;
            this.tbPrint.Text = "打印(F8)";
            // 
            // tbExist
            // 
            this.tbExist.ImageIndex = 14;
            this.tbExist.Text = "退出(&X)";
            // 
            // imageList32
            // 
            this.imageList32.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList32.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 8);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucShowCaseInfo1);
            this.panel1.Controls.Add(this.ucNameSreach1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 684);
            this.panel1.TabIndex = 4;
            // 
            // ucNameSreach1
            // 
            this.ucNameSreach1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucNameSreach1.Location = new System.Drawing.Point(0, 8);
            this.ucNameSreach1.Name = "ucNameSreach1";
            this.ucNameSreach1.Size = new System.Drawing.Size(1016, 40);
            this.ucNameSreach1.TabIndex = 4;
            // 
            // ucShowCaseInfo1
            // 
            this.ucShowCaseInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShowCaseInfo1.Location = new System.Drawing.Point(0, 48);
            this.ucShowCaseInfo1.Name = "ucShowCaseInfo1";
            this.ucShowCaseInfo1.Size = new System.Drawing.Size(1016, 636);
            this.ucShowCaseInfo1.TabIndex = 5;
            // 
            // frmSearchName
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmSearchName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "姓名查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}