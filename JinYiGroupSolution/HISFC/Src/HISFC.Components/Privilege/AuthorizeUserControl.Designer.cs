namespace Neusoft.HISFC.Components.Privilege
{
    partial class AuthorizeUserControl
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
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizeUserControl));
            this.nTreeListView1 = new FrameWork.WinForms.Controls.NeuTreeListView(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.cmpUser = new FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.tmspAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tmspModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tmspDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // nTreeListView1
            // 
            this.nTreeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.nTreeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.nTreeListView1.ContextMenuStrip = this.cmpUser;
            this.nTreeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeListView1.Location = new System.Drawing.Point(0, 0);
            this.nTreeListView1.Name = "nTreeListView1";
            this.nTreeListView1.Size = new System.Drawing.Size(656, 487);
            this.nTreeListView1.SmallImageList = this.imageList1;
            this.nTreeListView1.TabIndex = 0;
            this.nTreeListView1.UseCompatibleStateImageBehavior = false;
            this.nTreeListView1.DoubleClick += new System.EventHandler(this.nTreeListView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "人员编号";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "员工姓名";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "用户帐号";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "锁定？";
            this.columnHeader4.Width = 104;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "备注";
            this.columnHeader5.Width = 171;
            // 
            // cmpUser
            // 
            this.cmpUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmspAdd,
            this.tmspModify,
            this.tmspDelete});
            this.cmpUser.Name = "cmpUser";
            this.cmpUser.Size = new System.Drawing.Size(119, 70);
            // 
            // tmspAdd
            // 
            this.tmspAdd.Name = "tmspAdd";
            this.tmspAdd.Size = new System.Drawing.Size(118, 22);
            this.tmspAdd.Text = "添加用户";
            this.tmspAdd.Click += new System.EventHandler(this.tmspAdd_Click);
            // 
            // tmspModify
            // 
            this.tmspModify.Name = "tmspModify";
            this.tmspModify.Size = new System.Drawing.Size(118, 22);
            this.tmspModify.Text = "修改用户";
            this.tmspModify.Click += new System.EventHandler(this.tmspModify_Click);
            // 
            // tmspDelete
            // 
            this.tmspDelete.Name = "tmspDelete";
            this.tmspDelete.Size = new System.Drawing.Size(118, 22);
            this.tmspDelete.Text = "删除用户";
            this.tmspDelete.Visible = false;
            this.tmspDelete.Click += new System.EventHandler(this.tmspDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user_gray.png");
            // 
            // AuthorizeUserControl
            // 
            this.Controls.Add(this.nTreeListView1);
            this.Name = "AuthorizeUserControl";
            this.Size = new System.Drawing.Size(656, 487);
            this.Load += new System.EventHandler(this.AuthorizeUserControl_Load);
            this.cmpUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.WinForms.Controls.NeuTreeListView nTreeListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ImageList imageList1;
        private FrameWork.WinForms.Controls.NeuContextMenuStrip cmpUser;
        private System.Windows.Forms.ToolStripMenuItem tmspAdd;
        private System.Windows.Forms.ToolStripMenuItem tmspModify;
        private System.Windows.Forms.ToolStripMenuItem tmspDelete;
    }
}
