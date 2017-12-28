namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    partial class ucOutPatientTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOutPatientTree));
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.linkLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTreeView1 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuTreeView2 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.ucQuerySeeNoByCardNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQuerySeeNoByCardNo();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.linkLabel1);
            this.neuPanel1.Controls.Add(this.ucQuerySeeNoByCardNo1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(179, 86);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(147, 70);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "已诊";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuTreeView1);
            this.neuPanel2.Controls.Add(this.neuTreeView2);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 86);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(179, 374);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.ImageIndex = 0;
            this.neuTreeView1.ImageList = this.imageList1;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.SelectedImageIndex = 0;
            this.neuTreeView1.Size = new System.Drawing.Size(179, 374);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            // 
            // neuTreeView2
            // 
            this.neuTreeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTreeView2.HideSelection = false;
            this.neuTreeView2.ImageIndex = 0;
            this.neuTreeView2.ImageList = this.imageList1;
            this.neuTreeView2.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView2.Name = "neuTreeView2";
            this.neuTreeView2.SelectedImageIndex = 0;
            this.neuTreeView2.Size = new System.Drawing.Size(179, 374);
            this.neuTreeView2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView2.TabIndex = 1;
            // 
            // ucQuerySeeNoByCardNo1
            // 
            this.ucQuerySeeNoByCardNo1.InputType = 0;
            this.ucQuerySeeNoByCardNo1.IsICCard = false;
            this.ucQuerySeeNoByCardNo1.Label = null;
            this.ucQuerySeeNoByCardNo1.Location = new System.Drawing.Point(2, 6);
            this.ucQuerySeeNoByCardNo1.Name = "ucQuerySeeNoByCardNo1";
            this.ucQuerySeeNoByCardNo1.Size = new System.Drawing.Size(147, 76);
            this.ucQuerySeeNoByCardNo1.TabIndex = 1;
            // 
            // ucOutPatientTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucOutPatientTree";
            this.Size = new System.Drawing.Size(179, 460);
            this.Load += new System.EventHandler(this.ucOutPatientTree_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        //{22571B58-A56B-4dc3-A32C-EC17D74423A2}
        public Neusoft.FrameWork.WinForms.Controls.NeuTreeView neuTreeView1;
        private System.Windows.Forms.ImageList imageList1;
        //{22571B58-A56B-4dc3-A32C-EC17D74423A2}
        public Neusoft.FrameWork.WinForms.Controls.NeuTreeView neuTreeView2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel linkLabel1;
        private Neusoft.HISFC.Components.Common.Controls.ucQuerySeeNoByCardNo ucQuerySeeNoByCardNo1;
        //= new Neusoft.HISFC.Components.Common.Controls.ucQuerySeeNoByCardNo();
    }
}
