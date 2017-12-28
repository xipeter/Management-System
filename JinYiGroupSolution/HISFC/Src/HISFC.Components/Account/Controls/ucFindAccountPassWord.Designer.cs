namespace Neusoft.HISFC.Components.Account.Controls
{
    partial class ucFindAccountPassWord
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
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucRegPatientInfo1 = new Neusoft.HISFC.Components.Account.Controls.ucRegPatientInfo();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbidNOType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPassWord = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtidenno = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
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
            this.neuTabControl1.ItemSize = new System.Drawing.Size(60, 23);
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(791, 398);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuGroupBox2);
            this.tabPage1.Controls.Add(this.neuGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查询帐户密码";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.ucRegPatientInfo1);
            this.neuGroupBox2.Location = new System.Drawing.Point(2, 65);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(778, 297);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 4;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "患者信息";
            // 
            // ucRegPatientInfo1
            // 
            this.ucRegPatientInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))));
            this.ucRegPatientInfo1.CardNO = "";
            this.ucRegPatientInfo1.CardWay = false;
            this.ucRegPatientInfo1.IsEnableEntry = true;
            this.ucRegPatientInfo1.IsEnableIDENO = true;
            this.ucRegPatientInfo1.IsEnableIDEType = true;
            this.ucRegPatientInfo1.IsEnablePact = true;
            this.ucRegPatientInfo1.IsEnableSiNO = true;
            this.ucRegPatientInfo1.IsEnableVip = true;
            this.ucRegPatientInfo1.IsInputBirthDay = false;
            this.ucRegPatientInfo1.IsInputIDENO = false;
            this.ucRegPatientInfo1.IsInputIDEType = false;
            this.ucRegPatientInfo1.IsInputName = false;
            this.ucRegPatientInfo1.IsInputPact = false;
            this.ucRegPatientInfo1.IsInputSex = false;
            this.ucRegPatientInfo1.IsInputSiNo = false;
            this.ucRegPatientInfo1.IsLocalOperation = true;
            this.ucRegPatientInfo1.IsMustInputTabIndex = false;
            this.ucRegPatientInfo1.IsPrint = false;
            this.ucRegPatientInfo1.IsShowTitle = false;
            this.ucRegPatientInfo1.IsTreatment = false;
            this.ucRegPatientInfo1.Location = new System.Drawing.Point(-4, 17);
            this.ucRegPatientInfo1.McardNO = "";
            this.ucRegPatientInfo1.Name = "ucRegPatientInfo1";
            this.ucRegPatientInfo1.Size = new System.Drawing.Size(778, 272);
            this.ucRegPatientInfo1.TabIndex = 1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbidNOType);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.txtPassWord);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.txtidenno);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 6);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(773, 53);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 2;
            this.neuGroupBox1.TabStop = false;
            // 
            // cmbidNOType
            // 
            this.cmbidNOType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbidNOType.FormattingEnabled = true;
            this.cmbidNOType.IsEnter2Tab = false;
            this.cmbidNOType.IsFlat = false;
            this.cmbidNOType.IsLike = true;
            this.cmbidNOType.IsListOnly = false;
            this.cmbidNOType.IsShowCustomerList = false;
            this.cmbidNOType.IsShowID = false;
            this.cmbidNOType.Location = new System.Drawing.Point(58, 20);
            this.cmbidNOType.Name = "cmbidNOType";
            this.cmbidNOType.PopForm = null;
            this.cmbidNOType.ShowCustomerList = false;
            this.cmbidNOType.ShowID = false;
            this.cmbidNOType.Size = new System.Drawing.Size(100, 20);
            this.cmbidNOType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbidNOType.TabIndex = 7;
            this.cmbidNOType.Tag = "";
            this.cmbidNOType.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(5, 23);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 6;
            this.neuLabel3.Text = "证件类型";
            // 
            // txtPassWord
            // 
            this.txtPassWord.BackColor = System.Drawing.Color.White;
            this.txtPassWord.IsEnter2Tab = false;
            this.txtPassWord.Location = new System.Drawing.Point(425, 21);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.ReadOnly = true;
            this.txtPassWord.Size = new System.Drawing.Size(121, 21);
            this.txtPassWord.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPassWord.TabIndex = 4;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(371, 26);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 3;
            this.neuLabel2.Text = "帐户密码";
            // 
            // txtidenno
            // 
            this.txtidenno.IsEnter2Tab = false;
            this.txtidenno.Location = new System.Drawing.Point(222, 20);
            this.txtidenno.Name = "txtidenno";
            this.txtidenno.Size = new System.Drawing.Size(140, 21);
            this.txtidenno.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtidenno.TabIndex = 1;
            this.txtidenno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtidenno_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(178, 25);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "证件号";
            // 
            // ucFindAccountPassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucFindAccountPassWord";
            this.Size = new System.Drawing.Size(795, 396);
            this.Load += new System.EventHandler(this.ucFindAccountPassWord_Load);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.HISFC.Components.Account.Controls.ucRegPatientInfo ucRegPatientInfo1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPassWord;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtidenno;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbidNOType;
    }
}
