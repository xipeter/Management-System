namespace HIS
{
    partial class frmSelectGroup
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectGroup));
            this.lvGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvGroup.LargeImageList = this.imageList1;
            this.lvGroup.Location = new System.Drawing.Point(9, 12);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(225, 249);
            this.lvGroup.SmallImageList = this.imageList1;
            this.lvGroup.StateImageList = this.imageList1;
            this.lvGroup.TabIndex = 0;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.DoubleClick += new System.EventHandler(this.lvGroup_DoubleClick);
            this.lvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvGroup_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "选择组";
            this.columnHeader1.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "G2 Folder Blue.ico");
            this.imageList1.Images.SetKeyName(1, "G2 Folder Grey.ico");
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(12, 275);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "登录科室：";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(83, 272);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(150, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.cmbDept.TabIndex = 2;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDept_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(14, 304);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(158, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.Exit;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.neuButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(110, 301);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 25);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "";
            // 
            // frmSelectGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 346);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.lvGroup);
            this.MaximumSize = new System.Drawing.Size(255, 390);
            this.MinimumSize = new System.Drawing.Size(255, 380);
            this.Name = "frmSelectGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择组和科室";
            this.Load += new System.EventHandler(this.frmSelectGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}