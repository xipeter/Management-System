namespace Neusoft.Privilege.WinForms
{
    partial class ZZZZAddUserForm
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
            this.nTabControl1 = new NFC.Interface.Controls.NeuTabControl();
            this.tpBase = new System.Windows.Forms.TabPage();
            this.chbOriginPass = new NFC.Interface.Controls.NeuCheckBox();
            this.chbLock = new NFC.Interface.Controls.NeuCheckBox();
            this.btnSelectUser = new NFC.Interface.Controls.NeuButton();
            this.txtMemo = new NFC.Interface.Controls.NeuTextBox();
            this.txtAccount = new NFC.Interface.Controls.NeuTextBox();
            this.txtUserName = new NFC.Interface.Controls.NeuTextBox();
            this.nLabel6 = new NFC.Interface.Controls.NeuLabel();
            this.nLabel3 = new NFC.Interface.Controls.NeuLabel();
            this.nLabel2 = new NFC.Interface.Controls.NeuLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvRoleOfUser = new NFC.Interface.Controls.NeuListView();
            this.btnDel = new NFC.Interface.Controls.NeuButton();
            this.btnAdd = new NFC.Interface.Controls.NeuButton();
            this.tvAllRole = new NFC.Interface.Controls.NeuTreeView();
            this.btnOK = new NFC.Interface.Controls.NeuButton();
            this.btnCancel = new NFC.Interface.Controls.NeuButton();
            this.ContentPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.nTabControl1.SuspendLayout();
            this.tpBase.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.nTabControl1);
            this.ContentPanel.Size = new System.Drawing.Size(534, 280);
            this.ContentPanel.Controls.SetChildIndex(this.nTabControl1, 0);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(534, 50);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.btnCancel);
            this.BottomPanel.Controls.Add(this.btnOK);
            this.BottomPanel.Location = new System.Drawing.Point(0, 330);
            this.BottomPanel.Size = new System.Drawing.Size(534, 48);
            // 
            // nTabControl1
            // 
            this.nTabControl1.Controls.Add(this.tpBase);
            this.nTabControl1.Controls.Add(this.tabPage2);
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(534, 279);
            this.nTabControl1.TabIndex = 1;
            // 
            // tpBase
            // 
            this.tpBase.Controls.Add(this.chbOriginPass);
            this.tpBase.Controls.Add(this.chbLock);
            this.tpBase.Controls.Add(this.btnSelectUser);
            this.tpBase.Controls.Add(this.txtMemo);
            this.tpBase.Controls.Add(this.txtAccount);
            this.tpBase.Controls.Add(this.txtUserName);
            this.tpBase.Controls.Add(this.nLabel6);
            this.tpBase.Controls.Add(this.nLabel3);
            this.tpBase.Controls.Add(this.nLabel2);
            this.tpBase.Location = new System.Drawing.Point(4, 21);
            this.tpBase.Name = "tpBase";
            this.tpBase.Padding = new System.Windows.Forms.Padding(3);
            this.tpBase.Size = new System.Drawing.Size(526, 254);
            this.tpBase.TabIndex = 0;
            this.tpBase.Text = "基本信息";
            this.tpBase.UseVisualStyleBackColor = true;
            // 
            // chbOriginPass
            // 
            this.chbOriginPass.AutoSize = true;
            this.chbOriginPass.Checked = true;
            this.chbOriginPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOriginPass.Location = new System.Drawing.Point(145, 93);
            this.chbOriginPass.Name = "chbOriginPass";
            this.chbOriginPass.Size = new System.Drawing.Size(72, 16);
            this.chbOriginPass.TabIndex = 1;
            this.chbOriginPass.Text = "初始密码";
            this.chbOriginPass.UseVisualStyleBackColor = true;
            // 
            // chbLock
            // 
            this.chbLock.AutoSize = true;
            this.chbLock.Location = new System.Drawing.Point(246, 93);
            this.chbLock.Name = "chbLock";
            this.chbLock.Size = new System.Drawing.Size(72, 16);
            this.chbLock.TabIndex = 3;
            this.chbLock.Text = "锁定帐户";
            this.chbLock.UseVisualStyleBackColor = true;
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectUser.Location = new System.Drawing.Point(324, 37);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(30, 23);
            this.btnSelectUser.TabIndex = 0;
            this.btnSelectUser.Text = "*";
            this.btnSelectUser.Type = Neusoft.WinForms.ButtonType.None;
            this.btnSelectUser.UseVisualStyleBackColor = true;
            // 
            // txtMemo
            // 
            this.txtMemo.IsEnter2Tab = true;
            this.txtMemo.Location = new System.Drawing.Point(145, 115);
            this.txtMemo.MaxLength = 128;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(304, 93);
            this.txtMemo.TabIndex = 2;
            // 
            // txtAccount
            // 
            this.txtAccount.IsEnter2Tab = true;
            this.txtAccount.Location = new System.Drawing.Point(145, 66);
            this.txtAccount.MaxLength = 20;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(173, 21);
            this.txtAccount.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.IsEnter2Tab = false;
            this.txtUserName.Location = new System.Drawing.Point(145, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(173, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // nLabel6
            // 
            this.nLabel6.AutoSize = true;
            this.nLabel6.Location = new System.Drawing.Point(75, 118);
            this.nLabel6.Name = "nLabel6";
            this.nLabel6.Size = new System.Drawing.Size(29, 12);
            this.nLabel6.TabIndex = 0;
            this.nLabel6.Text = "备注";
            // 
            // nLabel3
            // 
            this.nLabel3.AutoSize = true;
            this.nLabel3.Location = new System.Drawing.Point(51, 69);
            this.nLabel3.Name = "nLabel3";
            this.nLabel3.Size = new System.Drawing.Size(53, 12);
            this.nLabel3.TabIndex = 0;
            this.nLabel3.Text = "登录帐户";
            // 
            // nLabel2
            // 
            this.nLabel2.AutoSize = true;
            this.nLabel2.Location = new System.Drawing.Point(51, 42);
            this.nLabel2.Name = "nLabel2";
            this.nLabel2.Size = new System.Drawing.Size(53, 12);
            this.nLabel2.TabIndex = 0;
            this.nLabel2.Text = "用户姓名";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvRoleOfUser);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.tvAllRole);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 254);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "所属角色";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvRoleOfUser
            // 
            this.lvRoleOfUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRoleOfUser.Location = new System.Drawing.Point(293, 3);
            this.lvRoleOfUser.Name = "lvRoleOfUser";
            this.lvRoleOfUser.Size = new System.Drawing.Size(241, 248);
            this.lvRoleOfUser.TabIndex = 3;
            this.lvRoleOfUser.UseCompatibleStateImageBehavior = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(212, 123);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "<<删除";
            this.btnDel.Type = Neusoft.WinForms.ButtonType.None;
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(212, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加>>";
            this.btnAdd.Type = Neusoft.WinForms.ButtonType.None;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tvAllRole
            // 
            this.tvAllRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvAllRole.HideSelection = false;
            this.tvAllRole.Location = new System.Drawing.Point(3, 3);
            this.tvAllRole.Name = "tvAllRole";
            this.tvAllRole.Size = new System.Drawing.Size(203, 248);
            this.tvAllRole.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(328, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "保存(&S)";
            this.btnOK.Type = Neusoft.WinForms.ButtonType.Save;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(423, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Type = Neusoft.WinForms.ButtonType.Close;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            this.ClientSize = new System.Drawing.Size(534, 400);
            this.Name = "AddUserForm";
            this.Text = "增加用户";
            this.ContentPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.nTabControl1.ResumeLayout(false);
            this.tpBase.ResumeLayout(false);
            this.tpBase.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NFC.Interface.Controls.NeuTabControl nTabControl1;
        private System.Windows.Forms.TabPage tpBase;
        private System.Windows.Forms.TabPage tabPage2;
        private NFC.Interface.Controls.NeuButton btnSelectUser;
        private NFC.Interface.Controls.NeuTextBox txtUserName;
        private NFC.Interface.Controls.NeuLabel nLabel3;
        private NFC.Interface.Controls.NeuLabel nLabel2;
        private NFC.Interface.Controls.NeuTextBox txtAccount;
        private NFC.Interface.Controls.NeuTextBox txtMemo;
        private NFC.Interface.Controls.NeuLabel nLabel6;
        private NFC.Interface.Controls.NeuCheckBox chbLock;
        private NFC.Interface.Controls.NeuButton btnCancel;
        private NFC.Interface.Controls.NeuButton btnOK;
        private NFC.Interface.Controls.NeuListView lvRoleOfUser;
        private NFC.Interface.Controls.NeuButton btnDel;
        private NFC.Interface.Controls.NeuButton btnAdd;
        private NFC.Interface.Controls.NeuTreeView tvAllRole;
        private NFC.Interface.Controls.NeuCheckBox chbOriginPass;
    }
}
