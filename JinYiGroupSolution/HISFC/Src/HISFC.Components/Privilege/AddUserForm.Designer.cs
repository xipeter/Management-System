namespace Neusoft.HISFC.Components.Privilege
{
    partial class AddUserForm
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
            this.nTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tpBaseInfo = new System.Windows.Forms.TabPage();
            this.chbManager = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chbOriginPass = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chbLock = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.btnSelectUser = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtMemo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtAccount = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtUserName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.nLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tpRoleInfo = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRole = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnChanel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnDeleteUser = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.ContentPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.nTabControl1.SuspendLayout();
            this.tpBaseInfo.SuspendLayout();
            this.tpRoleInfo.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.nTabControl1);
            this.ContentPanel.Size = new System.Drawing.Size(628, 317);
            this.ContentPanel.Controls.SetChildIndex(this.nTabControl1, 0);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(628, 50);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.btnDeleteUser);
            this.BottomPanel.Controls.Add(this.btnChanel);
            this.BottomPanel.Controls.Add(this.btnSave);
            this.BottomPanel.Location = new System.Drawing.Point(0, 367);
            this.BottomPanel.Size = new System.Drawing.Size(628, 48);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 415);
            this.statusBar1.Size = new System.Drawing.Size(628, 24);
            // 
            // nTabControl1
            // 
            this.nTabControl1.Controls.Add(this.tpBaseInfo);
            this.nTabControl1.Controls.Add(this.tpRoleInfo);
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(628, 316);
            this.nTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.nTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nTabControl1.TabIndex = 1;
            this.nTabControl1.TabIndexChanged += new System.EventHandler(this.nTabControl1_TabIndexChanged);
            this.nTabControl1.SelectedIndexChanged += new System.EventHandler(this.nTabControl1_TabIndexChanged);
            // 
            // tpBaseInfo
            // 
            this.tpBaseInfo.Controls.Add(this.chbManager);
            this.tpBaseInfo.Controls.Add(this.chbOriginPass);
            this.tpBaseInfo.Controls.Add(this.chbLock);
            this.tpBaseInfo.Controls.Add(this.btnSelectUser);
            this.tpBaseInfo.Controls.Add(this.txtMemo);
            this.tpBaseInfo.Controls.Add(this.txtAccount);
            this.tpBaseInfo.Controls.Add(this.txtUserName);
            this.tpBaseInfo.Controls.Add(this.nLabel6);
            this.tpBaseInfo.Controls.Add(this.nLabel3);
            this.tpBaseInfo.Controls.Add(this.nLabel2);
            this.tpBaseInfo.Location = new System.Drawing.Point(4, 21);
            this.tpBaseInfo.Name = "tpBaseInfo";
            this.tpBaseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBaseInfo.Size = new System.Drawing.Size(620, 291);
            this.tpBaseInfo.TabIndex = 0;
            this.tpBaseInfo.Text = "基础信息";
            this.tpBaseInfo.UseVisualStyleBackColor = true;
            // 
            // chbManager
            // 
            this.chbManager.AutoSize = true;
            this.chbManager.Location = new System.Drawing.Point(349, 98);
            this.chbManager.Name = "chbManager";
            this.chbManager.Size = new System.Drawing.Size(60, 16);
            this.chbManager.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbManager.TabIndex = 22;
            this.chbManager.Text = "管理员";
            this.chbManager.UseVisualStyleBackColor = true;
            this.chbManager.Visible = false;
            // 
            // chbOriginPass
            // 
            this.chbOriginPass.AutoSize = true;
            this.chbOriginPass.Checked = true;
            this.chbOriginPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOriginPass.Location = new System.Drawing.Point(136, 98);
            this.chbOriginPass.Name = "chbOriginPass";
            this.chbOriginPass.Size = new System.Drawing.Size(72, 16);
            this.chbOriginPass.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbOriginPass.TabIndex = 18;
            this.chbOriginPass.Text = "初始密码";
            this.chbOriginPass.UseVisualStyleBackColor = true;
            // 
            // chbLock
            // 
            this.chbLock.AutoSize = true;
            this.chbLock.Location = new System.Drawing.Point(244, 98);
            this.chbLock.Name = "chbLock";
            this.chbLock.Size = new System.Drawing.Size(72, 16);
            this.chbLock.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbLock.TabIndex = 21;
            this.chbLock.Text = "锁定帐户";
            this.chbLock.UseVisualStyleBackColor = true;
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectUser.Location = new System.Drawing.Point(487, 40);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(24, 23);
            this.btnSelectUser.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSelectUser.TabIndex = 16;
            this.btnSelectUser.Text = "…";
            this.btnSelectUser.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.IsEnter2Tab = true;
            this.txtMemo.Location = new System.Drawing.Point(136, 120);
            this.txtMemo.MaxLength = 128;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(345, 131);
            this.txtMemo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMemo.TabIndex = 20;
            // 
            // txtAccount
            // 
            this.txtAccount.IsEnter2Tab = true;
            this.txtAccount.Location = new System.Drawing.Point(136, 71);
            this.txtAccount.MaxLength = 20;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(345, 21);
            this.txtAccount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtAccount.TabIndex = 17;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Enabled = false;
            this.txtUserName.IsEnter2Tab = false;
            this.txtUserName.Location = new System.Drawing.Point(136, 44);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(345, 21);
            this.txtUserName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtUserName.TabIndex = 19;
            // 
            // nLabel6
            // 
            this.nLabel6.AutoSize = true;
            this.nLabel6.Location = new System.Drawing.Point(66, 123);
            this.nLabel6.Name = "nLabel6";
            this.nLabel6.Size = new System.Drawing.Size(29, 12);
            this.nLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel6.TabIndex = 14;
            this.nLabel6.Text = "备注";
            // 
            // nLabel3
            // 
            this.nLabel3.AutoSize = true;
            this.nLabel3.Location = new System.Drawing.Point(42, 74);
            this.nLabel3.Name = "nLabel3";
            this.nLabel3.Size = new System.Drawing.Size(53, 12);
            this.nLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel3.TabIndex = 15;
            this.nLabel3.Text = "登录帐户";
            // 
            // nLabel2
            // 
            this.nLabel2.AutoSize = true;
            this.nLabel2.Location = new System.Drawing.Point(42, 47);
            this.nLabel2.Name = "nLabel2";
            this.nLabel2.Size = new System.Drawing.Size(53, 12);
            this.nLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel2.TabIndex = 13;
            this.nLabel2.Text = "用户姓名";
            // 
            // tpRoleInfo
            // 
            this.tpRoleInfo.Controls.Add(this.splitContainer1);
            this.tpRoleInfo.Location = new System.Drawing.Point(4, 21);
            this.tpRoleInfo.Name = "tpRoleInfo";
            this.tpRoleInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpRoleInfo.Size = new System.Drawing.Size(470, 215);
            this.tpRoleInfo.TabIndex = 1;
            this.tpRoleInfo.Text = "分配角色";
            this.tpRoleInfo.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tvRole);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Size = new System.Drawing.Size(464, 209);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvRole
            // 
            this.tvRole.AllowDrop = true;
            this.tvRole.CheckBoxes = true;
            this.tvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRole.HideSelection = false;
            this.tvRole.Location = new System.Drawing.Point(0, 0);
            this.tvRole.Name = "tvRole";
            this.tvRole.Size = new System.Drawing.Size(434, 209);
            this.tvRole.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvRole.TabIndex = 0;
            this.tvRole.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvRole_AfterCheck);
            this.tvRole.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRole_AfterSelect);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(414, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保 存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChanel
            // 
            this.btnChanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChanel.Location = new System.Drawing.Point(514, 15);
            this.btnChanel.Name = "btnChanel";
            this.btnChanel.Size = new System.Drawing.Size(75, 23);
            this.btnChanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnChanel.TabIndex = 1;
            this.btnChanel.Text = "关 闭";
            this.btnChanel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnChanel.UseVisualStyleBackColor = true;
            this.btnChanel.Click += new System.EventHandler(this.btnChanel_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(314, 15);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "删除用户";
            this.btnDeleteUser.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 439);
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ContentPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.nTabControl1.ResumeLayout(false);
            this.tpBaseInfo.ResumeLayout(false);
            this.tpBaseInfo.PerformLayout();
            this.tpRoleInfo.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.WinForms.Controls.NeuTabControl nTabControl1;
        private System.Windows.Forms.TabPage tpBaseInfo;
        private System.Windows.Forms.TabPage tpRoleInfo;
        private FrameWork.WinForms.Controls.NeuCheckBox chbOriginPass;
        private FrameWork.WinForms.Controls.NeuCheckBox chbLock;
        private FrameWork.WinForms.Controls.NeuButton btnSelectUser;
        private FrameWork.WinForms.Controls.NeuTextBox txtMemo;
        private FrameWork.WinForms.Controls.NeuTextBox txtAccount;
        private FrameWork.WinForms.Controls.NeuTextBox txtUserName;
        private FrameWork.WinForms.Controls.NeuLabel nLabel6;
        private FrameWork.WinForms.Controls.NeuLabel nLabel3;
        private FrameWork.WinForms.Controls.NeuLabel nLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FrameWork.WinForms.Controls.NeuTreeView tvRole;
        private FrameWork.WinForms.Controls.NeuButton btnChanel;
        private FrameWork.WinForms.Controls.NeuButton btnSave;
        private FrameWork.WinForms.Controls.NeuButton btnDeleteUser;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbManager;
    }
}