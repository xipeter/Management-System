namespace Neusoft.HISFC.Components.Account.Controls
{
    partial class ucEmpowerInfo
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

            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ckflag = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.txtconfirmpwd = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtnewpwd = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtoldpw = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtMoney = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Location = new System.Drawing.Point(9, 7);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(272, 249);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuLabel5);
            this.tabPage1.Controls.Add(this.btCancel);
            this.tabPage1.Controls.Add(this.btOK);
            this.tabPage1.Controls.Add(this.neuGroupBox2);
            this.tabPage1.Controls.Add(this.neuGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(264, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "授权信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuLabel5
            // 
            this.neuLabel5.ForeColor = System.Drawing.Color.Red;
            this.neuLabel5.Location = new System.Drawing.Point(4, 190);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(84, 28);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 4;
            this.neuLabel5.Text = "注：密码为0-9\r\n　　的数字";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(177, 189);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 27);
            this.btCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "取消(&C)";
            this.btCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(94, 189);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 27);
            this.btOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOK.TabIndex = 5;
            this.btOK.Text = "确认(&O)";
            this.btOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.ckflag);
            this.neuGroupBox2.Controls.Add(this.txtconfirmpwd);
            this.neuGroupBox2.Controls.Add(this.txtnewpwd);
            this.neuGroupBox2.Controls.Add(this.txtoldpw);
            this.neuGroupBox2.Controls.Add(this.neuLabel4);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Location = new System.Drawing.Point(14, 47);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(236, 133);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            // 
            // ckflag
            // 
            this.ckflag.AutoSize = true;
            this.ckflag.Checked = true;
            this.ckflag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckflag.ForeColor = System.Drawing.Color.Red;
            this.ckflag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckflag.Location = new System.Drawing.Point(11, 13);
            this.ckflag.Name = "ckflag";
            this.ckflag.Size = new System.Drawing.Size(96, 16);
            this.ckflag.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckflag.TabIndex = 5;
            this.ckflag.Text = "是否修改密码";
            this.ckflag.UseVisualStyleBackColor = true;
            this.ckflag.CheckedChanged += new System.EventHandler(this.ckflag_CheckedChanged);
            // 
            // txtconfirmpwd
            // 
            this.txtconfirmpwd.IsEnter2Tab = true;
            this.txtconfirmpwd.Location = new System.Drawing.Point(70, 100);
            this.txtconfirmpwd.MaxLength = 6;
            this.txtconfirmpwd.Name = "txtconfirmpwd";
            this.txtconfirmpwd.PasswordChar = '*';
            this.txtconfirmpwd.Size = new System.Drawing.Size(140, 21);
            this.txtconfirmpwd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtconfirmpwd.TabIndex = 4;
            this.txtconfirmpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtconfirmpwd_KeyDown);
            // 
            // txtnewpwd
            // 
            this.txtnewpwd.IsEnter2Tab = true;
            this.txtnewpwd.Location = new System.Drawing.Point(70, 66);
            this.txtnewpwd.MaxLength = 6;
            this.txtnewpwd.Name = "txtnewpwd";
            this.txtnewpwd.PasswordChar = '*';
            this.txtnewpwd.Size = new System.Drawing.Size(140, 21);
            this.txtnewpwd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtnewpwd.TabIndex = 3;
            // 
            // txtoldpw
            // 
            this.txtoldpw.IsEnter2Tab = true;
            this.txtoldpw.Location = new System.Drawing.Point(70, 32);
            this.txtoldpw.MaxLength = 6;
            this.txtoldpw.Name = "txtoldpw";
            this.txtoldpw.PasswordChar = '*';
            this.txtoldpw.Size = new System.Drawing.Size(140, 21);
            this.txtoldpw.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtoldpw.TabIndex = 2;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(9, 106);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 2;
            this.neuLabel4.Text = "确认密码：";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(9, 72);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 1;
            this.neuLabel3.Text = "新 密 码：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(9, 37);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "原始密码：";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtMoney);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(14, 4);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(236, 43);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // txtMoney
            // 
            this.txtMoney.AllowNegative = false;
            this.txtMoney.IsAutoRemoveDecimalZero = false;
            this.txtMoney.IsEnter2Tab = true;
            this.txtMoney.Location = new System.Drawing.Point(71, 17);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.NumericPrecision = 11;
            this.txtMoney.NumericScaleOnFocus = 2;
            this.txtMoney.NumericScaleOnLostFocus = 2;
            this.txtMoney.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMoney.SetRange = new System.Drawing.Size(-1, -1);
            this.txtMoney.Size = new System.Drawing.Size(137, 21);
            this.txtMoney.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMoney.TabIndex = 1;
            this.txtMoney.Text = "0.00";
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoney.UseGroupSeperator = true;
            this.txtMoney.ZeroIsValid = true;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(9, 20);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "授权限额：";
            // 
            // ucEmpowerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucEmpowerInfo";
            this.Size = new System.Drawing.Size(288, 260);
            this.Load += new System.EventHandler(this.ucEmpowerInfo_Load);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtconfirmpwd;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtnewpwd;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtoldpw;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtMoney;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckflag;
    }
}
