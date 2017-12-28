namespace Neusoft.HISFC.Components.Manager.Controls
{
	partial class ucDepartmentLevel
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDepartmentLevel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuListView1 = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.neuContextMenuStrip1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.menuItemAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddDept = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tvDepartmentLevelTree1 = new Manager.Controls.tvDepartmentLevelTree(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDepartmentLevelTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuListView1);
            this.splitContainer1.Size = new System.Drawing.Size(811, 491);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "medical-2.ico");
            this.imageList1.Images.SetKeyName(1, "hourse1.bmp");
            this.imageList1.Images.SetKeyName(2, "hourse.bmp");
            // 
            // neuListView1
            // 
            this.neuListView1.ContextMenuStrip = this.neuContextMenuStrip1;
            this.neuListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuListView1.LargeImageList = this.imageList2;
            this.neuListView1.Location = new System.Drawing.Point(0, 0);
            this.neuListView1.Name = "neuListView1";
            this.neuListView1.Size = new System.Drawing.Size(605, 491);
            this.neuListView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuListView1.TabIndex = 0;
            this.neuListView1.UseCompatibleStateImageBehavior = false;
            this.neuListView1.DoubleClick += new System.EventHandler(this.neuListView1_DoubleClick);
            this.neuListView1.SelectedIndexChanged += new System.EventHandler(this.neuListView1_SelectedIndexChanged);
            // 
            // neuContextMenuStrip1
            // 
            this.neuContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddUser,
            this.menuItemAddDept,
            this.toolStripSeparator1,
            this.menuItemDelete,
            this.menuItemProperty});
            this.neuContextMenuStrip1.Name = "neuContextMenuStrip1";
            this.neuContextMenuStrip1.Size = new System.Drawing.Size(137, 98);
            this.neuContextMenuStrip1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.neuContextMenuStrip1_Opening);
            // 
            // menuItemAddUser
            // 
            this.menuItemAddUser.Name = "menuItemAddUser";
            this.menuItemAddUser.Size = new System.Drawing.Size(136, 22);
            this.menuItemAddUser.Text = "添加人员(&P)";
            this.menuItemAddUser.Click += new System.EventHandler(this.menuItemAddUser_Click);
            // 
            // menuItemAddDept
            // 
            this.menuItemAddDept.Name = "menuItemAddDept";
            this.menuItemAddDept.Size = new System.Drawing.Size(136, 22);
            this.menuItemAddDept.Text = "添加科室(&A)";
            this.menuItemAddDept.Click += new System.EventHandler(this.menuItemAddDept_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(136, 22);
            this.menuItemDelete.Text = "删除(&D)";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemProperty
            // 
            this.menuItemProperty.Name = "menuItemProperty";
            this.menuItemProperty.Size = new System.Drawing.Size(136, 22);
            this.menuItemProperty.Text = "属性(&R)";
            this.menuItemProperty.Click += new System.EventHandler(this.menuItemProperty_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "hourse1.bmp");
            this.imageList2.Images.SetKeyName(1, "hourse.bmp");
            this.imageList2.Images.SetKeyName(2, "doctor.ico");
            this.imageList2.Images.SetKeyName(3, "CHARA015.ICO");
            // 
            // tvDepartmentLevelTree1
            // 
            this.tvDepartmentLevelTree1.AllowDrop = true;
            this.tvDepartmentLevelTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDepartmentLevelTree1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDepartmentLevelTree1.ImageIndex = 0;
            this.tvDepartmentLevelTree1.ImageList = this.imageList1;
            this.tvDepartmentLevelTree1.Location = new System.Drawing.Point(0, 0);
            this.tvDepartmentLevelTree1.Name = "tvDepartmentLevelTree1";
            this.tvDepartmentLevelTree1.SelectedImageIndex = 0;
            this.tvDepartmentLevelTree1.ShowNodeToolTips = true;
            this.tvDepartmentLevelTree1.Size = new System.Drawing.Size(202, 491);
            this.tvDepartmentLevelTree1.TabIndex = 0;
            this.tvDepartmentLevelTree1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvDepartmentLevelTree1_DragDrop);
            this.tvDepartmentLevelTree1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartmentLevelTree1_AfterSelect);
            this.tvDepartmentLevelTree1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvDepartmentLevelTree1_DragEnter);
            this.tvDepartmentLevelTree1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvDepartmentLevelTree1_ItemDrag);
            // 
            // ucDepartmentLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDepartmentLevel";
            this.Size = new System.Drawing.Size(811, 491);
            this.Load += new System.EventHandler(this.ucDepartmentLevel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView neuListView1;
        private System.Windows.Forms.ImageList imageList1;
        private tvDepartmentLevelTree tvDepartmentLevelTree1;
        private System.Windows.Forms.ImageList imageList2;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip neuContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddUser;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddDept;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemProperty;

    }
}
