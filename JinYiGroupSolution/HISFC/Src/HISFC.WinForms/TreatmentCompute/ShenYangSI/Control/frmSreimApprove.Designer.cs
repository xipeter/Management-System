namespace ShenYangCitySI.Control
{
    partial class frmSreimApprove
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
            this.审批信息 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbApprKind = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbMarkNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbApprPerson = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbJBR = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.dtpSBRQ = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpSPRQ = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.tbDescribe = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbDesease = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnReadCard = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnClear = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnQuit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.审批信息.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 审批信息
            // 
            this.审批信息.Controls.Add(this.dtpSPRQ);
            this.审批信息.Controls.Add(this.dtpSBRQ);
            this.审批信息.Controls.Add(this.tbJBR);
            this.审批信息.Controls.Add(this.tbApprPerson);
            this.审批信息.Controls.Add(this.tbMarkNO);
            this.审批信息.Controls.Add(this.tbSex);
            this.审批信息.Controls.Add(this.tbName);
            this.审批信息.Controls.Add(this.neuLabel7);
            this.审批信息.Controls.Add(this.neuLabel8);
            this.审批信息.Controls.Add(this.neuLabel5);
            this.审批信息.Controls.Add(this.neuLabel6);
            this.审批信息.Controls.Add(this.neuLabel4);
            this.审批信息.Controls.Add(this.neuLabel3);
            this.审批信息.Controls.Add(this.neuLabel2);
            this.审批信息.Controls.Add(this.neuLabel1);
            this.审批信息.Controls.Add(this.cmbApprKind);
            this.审批信息.Location = new System.Drawing.Point(6, 12);
            this.审批信息.Name = "审批信息";
            this.审批信息.Size = new System.Drawing.Size(628, 116);
            this.审批信息.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.审批信息.TabIndex = 0;
            this.审批信息.TabStop = false;
            this.审批信息.Text = "审批信息";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbDesease);
            this.neuGroupBox1.Controls.Add(this.tbDescribe);
            this.neuGroupBox1.Controls.Add(this.neuLabel9);
            this.neuGroupBox1.Controls.Add(this.neuLabel10);
            this.neuGroupBox1.Location = new System.Drawing.Point(6, 138);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(628, 116);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "输入信息";
            // 
            // cmbApprKind
            // 
            this.cmbApprKind.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbApprKind.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbApprKind.FormattingEnabled = true;
            this.cmbApprKind.IsFlat = true;
            this.cmbApprKind.IsLike = true;
            this.cmbApprKind.Location = new System.Drawing.Point(60, 25);
            this.cmbApprKind.Name = "cmbApprKind";
            this.cmbApprKind.PopForm = null;
            this.cmbApprKind.ShowCustomerList = false;
            this.cmbApprKind.ShowID = false;
            this.cmbApprKind.Size = new System.Drawing.Size(106, 22);
            this.cmbApprKind.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbApprKind.TabIndex = 0;
            this.cmbApprKind.Tag = "";
            this.cmbApprKind.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(4, 30);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "审批类别";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(4, 70);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "申报日期";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(171, 30);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "患者姓名";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(171, 70);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 4;
            this.neuLabel4.Text = "审批日期";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(334, 70);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 6;
            this.neuLabel5.Text = "审 批 人";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(334, 30);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 5;
            this.neuLabel6.Text = "患者性别";
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(483, 70);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(53, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 8;
            this.neuLabel7.Text = "经 办 人";
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.Location = new System.Drawing.Point(483, 30);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(53, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 7;
            this.neuLabel8.Text = "个人编号";
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.Location = new System.Drawing.Point(4, 73);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(53, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 10;
            this.neuLabel9.Text = "备    注";
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.Location = new System.Drawing.Point(4, 35);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(53, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 9;
            this.neuLabel10.Text = "疾病编码";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(224, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(106, 21);
            this.tbName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbName.TabIndex = 9;
            // 
            // tbSex
            // 
            this.tbSex.Location = new System.Drawing.Point(390, 25);
            this.tbSex.Name = "tbSex";
            this.tbSex.Size = new System.Drawing.Size(88, 21);
            this.tbSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbSex.TabIndex = 10;
            // 
            // tbMarkNO
            // 
            this.tbMarkNO.Location = new System.Drawing.Point(537, 25);
            this.tbMarkNO.Name = "tbMarkNO";
            this.tbMarkNO.Size = new System.Drawing.Size(88, 21);
            this.tbMarkNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbMarkNO.TabIndex = 11;
            // 
            // tbApprPerson
            // 
            this.tbApprPerson.Location = new System.Drawing.Point(390, 66);
            this.tbApprPerson.Name = "tbApprPerson";
            this.tbApprPerson.Size = new System.Drawing.Size(88, 21);
            this.tbApprPerson.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbApprPerson.TabIndex = 12;
            // 
            // tbJBR
            // 
            this.tbJBR.Location = new System.Drawing.Point(537, 66);
            this.tbJBR.Name = "tbJBR";
            this.tbJBR.Size = new System.Drawing.Size(88, 21);
            this.tbJBR.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbJBR.TabIndex = 13;
            // 
            // dtpSBRQ
            // 
            this.dtpSBRQ.Location = new System.Drawing.Point(60, 66);
            this.dtpSBRQ.Name = "dtpSBRQ";
            this.dtpSBRQ.Size = new System.Drawing.Size(106, 21);
            this.dtpSBRQ.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpSBRQ.TabIndex = 14;
            // 
            // dtpSPRQ
            // 
            this.dtpSPRQ.Location = new System.Drawing.Point(224, 66);
            this.dtpSPRQ.Name = "dtpSPRQ";
            this.dtpSPRQ.Size = new System.Drawing.Size(106, 21);
            this.dtpSPRQ.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpSPRQ.TabIndex = 15;
            // 
            // tbDescribe
            // 
            this.tbDescribe.Location = new System.Drawing.Point(60, 71);
            this.tbDescribe.Name = "tbDescribe";
            this.tbDescribe.Size = new System.Drawing.Size(565, 21);
            this.tbDescribe.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbDescribe.TabIndex = 17;
            // 
            // cmbDesease
            // 
            this.cmbDesease.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDesease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDesease.FormattingEnabled = true;
            this.cmbDesease.IsFlat = true;
            this.cmbDesease.IsLike = true;
            this.cmbDesease.Location = new System.Drawing.Point(60, 31);
            this.cmbDesease.Name = "cmbDesease";
            this.cmbDesease.PopForm = null;
            this.cmbDesease.ShowCustomerList = false;
            this.cmbDesease.ShowID = false;
            this.cmbDesease.Size = new System.Drawing.Size(207, 22);
            this.cmbDesease.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDesease.TabIndex = 18;
            this.cmbDesease.Tag = "";
            this.cmbDesease.ToolBarUse = false;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(333, 276);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 23);
            this.btnReadCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnReadCard.TabIndex = 2;
            this.btnReadCard.Text = "市保读卡";
            this.btnReadCard.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(408, 276);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清屏";
            this.btnClear.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(482, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(556, 276);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "退出";
            this.btnQuit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmSreimApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 315);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.审批信息);
            this.Controls.Add(this.neuGroupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSreimApprove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "节育、生育审批申请";
            this.Load += new System.EventHandler(this.frmSreimApprove_Load);
            this.审批信息.ResumeLayout(false);
            this.审批信息.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox 审批信息;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbApprKind;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpSPRQ;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpSBRQ;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbJBR;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbApprPerson;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbMarkNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDesease;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbDescribe;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnReadCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnClear;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQuit;
    }
}