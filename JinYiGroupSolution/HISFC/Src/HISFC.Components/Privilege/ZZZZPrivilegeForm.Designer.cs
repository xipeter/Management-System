namespace Neusoft.Privilege.WinForms
{
    partial class ZZZZPrivilegeForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("已包含用户", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("未包含用户", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZZZZPrivilegeForm));
            this.nPanel1 = new NFC.Interface.Controls.NeuPanel();
            this.tvRole = new NFC.Interface.Controls.NeuTreeView();
            this.nRoleMenuStrip = new NFC.Interface.Controls.NeuContextMenuStrip();
            this.AddRoleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyRoleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DelRoleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.nSplitter1 = new NFC.Interface.Controls.NeuSplitter();
            this.nPanel2 = new NFC.Interface.Controls.NeuPanel();
            this.nTabControl1 = new NFC.Interface.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvUser = new NFC.Interface.Controls.NeuListView();
            this.H1 = new System.Windows.Forms.ColumnHeader();
            this.H2 = new System.Windows.Forms.ColumnHeader();
            this.H3 = new System.Windows.Forms.ColumnHeader();
            this.H4 = new System.Windows.Forms.ColumnHeader();
            this.H5 = new System.Windows.Forms.ColumnHeader();
            this.nUserMenuStrip = new NFC.Interface.Controls.NeuContextMenuStrip();
            this.AddUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSelectAll = new NFC.Interface.Controls.NeuButton();
            this.btnSelectNone = new NFC.Interface.Controls.NeuButton();
            this.btnReset = new NFC.Interface.Controls.NeuButton();
            this.btnSave = new NFC.Interface.Controls.NeuButton();
            this.tvMenu = new NFC.Interface.Controls.NeuTreeView();
            this.nPanel1.SuspendLayout();
            this.nRoleMenuStrip.SuspendLayout();
            this.nPanel2.SuspendLayout();
            this.nTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.nUserMenuStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nPanel1
            // 
            this.nPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nPanel1.Controls.Add(this.tvRole);
            this.nPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.nPanel1.Location = new System.Drawing.Point(0, 25);
            this.nPanel1.Name = "nPanel1";
            this.nPanel1.Size = new System.Drawing.Size(185, 349);
            this.nPanel1.TabIndex = 2;
            // 
            // tvRole
            // 
            this.tvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRole.HideSelection = false;
            this.tvRole.ImageIndex = 0;
            this.tvRole.ImageList = this.imageList1;
            this.tvRole.Location = new System.Drawing.Point(0, 0);
            this.tvRole.Name = "tvRole";
            this.tvRole.SelectedImageIndex = 0;
            this.tvRole.Size = new System.Drawing.Size(185, 349);
            this.tvRole.TabIndex = 0;
            // 
            // nRoleMenuStrip
            // 
            this.nRoleMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRoleMenu,
            this.ModifyRoleMenu,
            this.DelRoleMenu});
            this.nRoleMenuStrip.Name = "nRoleMenuStrip";
            this.nRoleMenuStrip.Size = new System.Drawing.Size(119, 70);
            // 
            // AddRoleMenu
            // 
            this.AddRoleMenu.Name = "AddRoleMenu";
            this.AddRoleMenu.Size = new System.Drawing.Size(118, 22);
            this.AddRoleMenu.Text = "增加角色";
            // 
            // ModifyRoleMenu
            // 
            this.ModifyRoleMenu.Name = "ModifyRoleMenu";
            this.ModifyRoleMenu.Size = new System.Drawing.Size(118, 22);
            this.ModifyRoleMenu.Text = "修改角色";
            // 
            // DelRoleMenu
            // 
            this.DelRoleMenu.Name = "DelRoleMenu";
            this.DelRoleMenu.Size = new System.Drawing.Size(118, 22);
            this.DelRoleMenu.Text = "删除角色";
            // 
            // nSplitter1
            // 
            this.nSplitter1.Location = new System.Drawing.Point(185, 25);
            this.nSplitter1.Name = "nSplitter1";
            this.nSplitter1.Size = new System.Drawing.Size(3, 349);
            this.nSplitter1.TabIndex = 3;
            this.nSplitter1.TabStop = false;
            // 
            // nPanel2
            // 
            this.nPanel2.Controls.Add(this.nTabControl1);
            this.nPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nPanel2.Location = new System.Drawing.Point(188, 25);
            this.nPanel2.Name = "nPanel2";
            this.nPanel2.Size = new System.Drawing.Size(415, 349);
            this.nPanel2.TabIndex = 4;
            // 
            // nTabControl1
            // 
            this.nTabControl1.Controls.Add(this.tabPage1);
            this.nTabControl1.Controls.Add(this.tabPage2);
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(415, 349);
            this.nTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage1.Controls.Add(this.lvUser);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvUser
            // 
            this.lvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.H1,
            this.H2,
            this.H3,
            this.H4,
            this.H5});
            this.lvUser.ContextMenuStrip = this.nUserMenuStrip;
            this.lvUser.FullRowSelect = true;
            listViewGroup1.Header = "已包含用户";
            listViewGroup1.Name = "group1";
            listViewGroup2.Header = "未包含用户";
            listViewGroup2.Name = "group2";
            this.lvUser.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvUser.LabelWrap = false;
            this.lvUser.Location = new System.Drawing.Point(0, 3);
            this.lvUser.MultiSelect = false;
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(404, 318);
            this.lvUser.SmallImageList = this.imageList1;
            this.lvUser.TabIndex = 0;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // H1
            // 
            this.H1.Text = "人员编号";
            this.H1.Width = 80;
            // 
            // H2
            // 
            this.H2.Text = "员工姓名";
            this.H2.Width = 120;
            // 
            // H3
            // 
            this.H3.Text = "用户账号";
            this.H3.Width = 80;
            // 
            // H4
            // 
            this.H4.Text = "锁定?";
            this.H4.Width = 50;
            // 
            // H5
            // 
            this.H5.Text = "备注";
            this.H5.Width = 200;
            // 
            // nUserMenuStrip
            // 
            this.nUserMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUserItem,
            this.ModifyUserItem,
            this.RemoveUserItem});
            this.nUserMenuStrip.Name = "nUserMenuStrip";
            this.nUserMenuStrip.Size = new System.Drawing.Size(119, 70);
            // 
            // AddUserItem
            // 
            this.AddUserItem.Name = "AddUserItem";
            this.AddUserItem.Size = new System.Drawing.Size(118, 22);
            this.AddUserItem.Text = "增加用户";
            // 
            // ModifyUserItem
            // 
            this.ModifyUserItem.Name = "ModifyUserItem";
            this.ModifyUserItem.Size = new System.Drawing.Size(118, 22);
            this.ModifyUserItem.Text = "修改用户";
            // 
            // RemoveUserItem
            // 
            this.RemoveUserItem.Name = "RemoveUserItem";
            this.RemoveUserItem.Size = new System.Drawing.Size(118, 22);
            this.RemoveUserItem.Text = "删除用户";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "权限24.ico");
            this.imageList1.Images.SetKeyName(1, "人员.ico");
            this.imageList1.Images.SetKeyName(2, "menu.gif");
            this.imageList1.Images.SetKeyName(3, "purview.gif");
            this.imageList1.Images.SetKeyName(4, "nonpurview.gif");
            this.imageList1.Images.SetKeyName(5, "roleparent.gif");
            this.imageList1.Images.SetKeyName(6, "folder.gif");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSelectAll);
            this.tabPage2.Controls.Add(this.btnSelectNone);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.tvMenu);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "菜单授权";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(53, 285);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全部选中";
            this.btnSelectAll.Type = 
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNone.Location = new System.Drawing.Point(134, 285);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNone.TabIndex = 3;
            this.btnSelectNone.Text = "全部取消";
            this.btnSelectNone.Type = Neusoft.WinForms.ButtonType.None;
            this.btnSelectNone.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(228, 285);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.Type = Neusoft.WinForms.ButtonType.None;
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(309, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.WinForms.ButtonType.Save;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tvMenu
            // 
            this.tvMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMenu.CheckBoxes = true;
            this.tvMenu.HideSelection = false;
            this.tvMenu.ImageIndex = 2;
            this.tvMenu.ImageList = this.imageList1;
            this.tvMenu.Location = new System.Drawing.Point(0, 3);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.SelectedImageIndex = 2;
            this.tvMenu.Size = new System.Drawing.Size(404, 276);
            this.tvMenu.TabIndex = 0;
            // 
            // PrivilegeForm
            // 
            this.ClientSize = new System.Drawing.Size(603, 396);
            this.Controls.Add(this.nPanel2);
            this.Controls.Add(this.nSplitter1);
            this.Controls.Add(this.nPanel1);
            this.Name = "PrivilegeForm";
            this.Text = "权限管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.nPanel1, 0);
            this.Controls.SetChildIndex(this.nSplitter1, 0);
            this.Controls.SetChildIndex(this.nPanel2, 0);
            this.nPanel1.ResumeLayout(false);
            this.nRoleMenuStrip.ResumeLayout(false);
            this.nPanel2.ResumeLayout(false);
            this.nTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.nUserMenuStrip.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NFC.Interface.Controls.NeuPanel nPanel1;
        private NFC.Interface.Controls.NeuTreeView tvRole;
        private NFC.Interface.Controls.NeuSplitter nSplitter1;
        private NFC.Interface.Controls.NeuPanel nPanel2;
        private NFC.Interface.Controls.NeuTabControl nTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private NFC.Interface.Controls.NeuListView lvUser;
        private NFC.Interface.Controls.NeuContextMenuStrip nRoleMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddRoleMenu;
        private System.Windows.Forms.ToolStripMenuItem DelRoleMenu;
        private System.Windows.Forms.ToolStripMenuItem ModifyRoleMenu;
        private System.Windows.Forms.ColumnHeader H1;
        private System.Windows.Forms.ColumnHeader H2;
        private System.Windows.Forms.ColumnHeader H3;
        private System.Windows.Forms.ColumnHeader H4;
        private System.Windows.Forms.ColumnHeader H5;
        private NFC.Interface.Controls.NeuTreeView tvMenu;
        private System.Windows.Forms.ImageList imageList1;
        private NFC.Interface.Controls.NeuContextMenuStrip nUserMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddUserItem;
        private System.Windows.Forms.ToolStripMenuItem ModifyUserItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveUserItem;
        private NFC.Interface.Controls.NeuButton btnReset;
        private NFC.Interface.Controls.NeuButton btnSave;
        private NFC.Interface.Controls.NeuButton btnSelectAll;
        private NFC.Interface.Controls.NeuButton btnSelectNone;
    }
}
