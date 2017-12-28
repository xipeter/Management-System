namespace Neusoft.HISFC.Components.Manager.Forms
{
    partial class frmSetUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetUserGroup));
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lblEmployee = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.chkManager = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chkPWD = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtLoginID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lsvGroup = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvGroup1 = new Neusoft.HISFC.Components.Manager.Controls.tvGroup();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lblEmployee);
            this.neuGroupBox1.Controls.Add(this.chkManager);
            this.neuGroupBox1.Controls.Add(this.chkPWD);
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.txtLoginID);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(240, 207);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "用户";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(11, 30);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(71, 12);
            this.lblEmployee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.TabStop = true;
            this.lblEmployee.Text = "选择人员...";
            this.lblEmployee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEmployee_LinkClicked);
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Location = new System.Drawing.Point(138, 170);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(84, 16);
            this.chkManager.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkManager.TabIndex = 5;
            this.chkManager.Text = "管理员标记";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // chkPWD
            // 
            this.chkPWD.AutoSize = true;
            this.chkPWD.Location = new System.Drawing.Point(13, 170);
            this.chkPWD.Name = "chkPWD";
            this.chkPWD.Size = new System.Drawing.Size(96, 16);
            this.chkPWD.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkPWD.TabIndex = 4;
            this.chkPWD.Text = "恢复初始密码";
            this.chkPWD.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(70, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 3;
            // 
            // txtLoginID
            // 
            this.txtLoginID.Location = new System.Drawing.Point(70, 77);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(153, 21);
            this.txtLoginID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtLoginID.TabIndex = 2;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(11, 111);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "姓　名：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(11, 80);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "登录名：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(25, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(159, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.Close;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lsvGroup
            // 
            this.lsvGroup.LargeImageList = this.imageList1;
            this.lsvGroup.Location = new System.Drawing.Point(258, 12);
            this.lsvGroup.Name = "lsvGroup";
            this.lsvGroup.Size = new System.Drawing.Size(159, 398);
            this.lsvGroup.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lsvGroup.TabIndex = 3;
            this.lsvGroup.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "G2 Folder Blue.ico");
            this.imageList1.Images.SetKeyName(1, "G2 Folder Grey.ico");
            this.imageList1.Images.SetKeyName(2, "hourse.bmp");
            this.imageList1.Images.SetKeyName(3, "hourse1.bmp");
            // 
            // tvGroup1
            // 
            this.tvGroup1.HideSelection = false;
            this.tvGroup1.ImageIndex = 0;
            this.tvGroup1.ImageList = this.imageList1;
            this.tvGroup1.Location = new System.Drawing.Point(423, 12);
            this.tvGroup1.Name = "tvGroup1";
            this.tvGroup1.SelectedImageIndex = 0;
            this.tvGroup1.Size = new System.Drawing.Size(151, 398);
            this.tvGroup1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvGroup1.TabIndex = 4;
            // 
            // frmSetUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 422);
            this.Controls.Add(this.tvGroup1);
            this.Controls.Add(this.lsvGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.neuGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSetUserGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户组管理";
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkPWD;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtLoginID;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkManager;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lsvGroup;
        private Manager.Controls.tvGroup tvGroup1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lblEmployee;
        private System.Windows.Forms.ImageList imageList1;
    }
}