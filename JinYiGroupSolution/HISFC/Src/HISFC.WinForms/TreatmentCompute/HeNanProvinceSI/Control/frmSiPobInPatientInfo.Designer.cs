namespace HeNanProvinceSI.Control
{
    partial class frmSiPobInPatientInfo
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucSiPatientInfoInPatient1 = new ucSiPatientInfoInPatient();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.cmbOperate3 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbOperate1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbOperate2 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbPDiagnose = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbMedicalType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDiagNose = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuGroupBox1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(618, 240);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.ucSiPatientInfoInPatient1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(618, 240);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "患者信息";
            // 
            // ucSiPatientInfoInPatient1
            // 
            this.ucSiPatientInfoInPatient1.Location = new System.Drawing.Point(12, 26);
            this.ucSiPatientInfoInPatient1.Name = "ucSiPatientInfoInPatient1";
            this.ucSiPatientInfoInPatient1.Patient = null;
            this.ucSiPatientInfoInPatient1.Size = new System.Drawing.Size(600, 208);
            this.ucSiPatientInfoInPatient1.TabIndex = 0;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.cmbOperate3);
            this.neuGroupBox2.Controls.Add(this.neuLabel4);
            this.neuGroupBox2.Controls.Add(this.cmbOperate1);
            this.neuGroupBox2.Controls.Add(this.cmbOperate2);
            this.neuGroupBox2.Controls.Add(this.neuLabel5);
            this.neuGroupBox2.Controls.Add(this.neuLabel6);
            this.neuGroupBox2.Controls.Add(this.cmbPDiagnose);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Controls.Add(this.cmbMedicalType);
            this.neuGroupBox2.Controls.Add(this.cmbDiagNose);
            this.neuGroupBox2.Controls.Add(this.neuLabel1);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Location = new System.Drawing.Point(2, 245);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(616, 100);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "输入信息";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btnCancel);
            this.neuPanel2.Controls.Add(this.btnOK);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 351);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(618, 42);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(319, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbOperate3
            // 
            this.cmbOperate3.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOperate3.FormattingEnabled = true;
            this.cmbOperate3.IsEnter2Tab = false;
            this.cmbOperate3.IsFlat = true;
            this.cmbOperate3.IsLike = true;
            this.cmbOperate3.Location = new System.Drawing.Point(406, 68);
            this.cmbOperate3.Name = "cmbOperate3";
            this.cmbOperate3.PopForm = null;
            this.cmbOperate3.ShowCustomerList = false;
            this.cmbOperate3.ShowID = false;
            this.cmbOperate3.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate3.TabIndex = 33;
            this.cmbOperate3.Tag = "";
            this.cmbOperate3.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(347, 71);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(41, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 34;
            this.neuLabel4.Text = "手术三";
            // 
            // cmbOperate1
            // 
            this.cmbOperate1.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOperate1.FormattingEnabled = true;
            this.cmbOperate1.IsEnter2Tab = false;
            this.cmbOperate1.IsFlat = true;
            this.cmbOperate1.IsLike = true;
            this.cmbOperate1.Location = new System.Drawing.Point(406, 13);
            this.cmbOperate1.Name = "cmbOperate1";
            this.cmbOperate1.PopForm = null;
            this.cmbOperate1.ShowCustomerList = false;
            this.cmbOperate1.ShowID = false;
            this.cmbOperate1.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate1.TabIndex = 29;
            this.cmbOperate1.Tag = "";
            this.cmbOperate1.ToolBarUse = false;
            // 
            // cmbOperate2
            // 
            this.cmbOperate2.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOperate2.FormattingEnabled = true;
            this.cmbOperate2.IsEnter2Tab = false;
            this.cmbOperate2.IsFlat = true;
            this.cmbOperate2.IsLike = true;
            this.cmbOperate2.Location = new System.Drawing.Point(406, 40);
            this.cmbOperate2.Name = "cmbOperate2";
            this.cmbOperate2.PopForm = null;
            this.cmbOperate2.ShowCustomerList = false;
            this.cmbOperate2.ShowID = false;
            this.cmbOperate2.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate2.TabIndex = 31;
            this.cmbOperate2.Tag = "";
            this.cmbOperate2.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(346, 15);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 30;
            this.neuLabel5.Text = "手术一";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(347, 43);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(41, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 32;
            this.neuLabel6.Text = "手术二";
            // 
            // cmbPDiagnose
            // 
            this.cmbPDiagnose.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPDiagnose.FormattingEnabled = true;
            this.cmbPDiagnose.IsEnter2Tab = false;
            this.cmbPDiagnose.IsFlat = true;
            this.cmbPDiagnose.IsLike = true;
            this.cmbPDiagnose.Location = new System.Drawing.Point(157, 68);
            this.cmbPDiagnose.Name = "cmbPDiagnose";
            this.cmbPDiagnose.PopForm = null;
            this.cmbPDiagnose.ShowCustomerList = false;
            this.cmbPDiagnose.ShowID = false;
            this.cmbPDiagnose.Size = new System.Drawing.Size(157, 20);
            this.cmbPDiagnose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPDiagnose.TabIndex = 27;
            this.cmbPDiagnose.Tag = "";
            this.cmbPDiagnose.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(58, 68);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 28;
            this.neuLabel3.Text = "标识名称";
            // 
            // cmbMedicalType
            // 
            this.cmbMedicalType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMedicalType.FormattingEnabled = true;
            this.cmbMedicalType.IsEnter2Tab = false;
            this.cmbMedicalType.IsFlat = true;
            this.cmbMedicalType.IsLike = true;
            this.cmbMedicalType.Location = new System.Drawing.Point(157, 13);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(157, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMedicalType.TabIndex = 23;
            this.cmbMedicalType.Tag = "";
            this.cmbMedicalType.ToolBarUse = false;
            // 
            // cmbDiagNose
            // 
            this.cmbDiagNose.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDiagNose.FormattingEnabled = true;
            this.cmbDiagNose.IsEnter2Tab = false;
            this.cmbDiagNose.IsFlat = true;
            this.cmbDiagNose.IsLike = true;
            this.cmbDiagNose.Location = new System.Drawing.Point(157, 40);
            this.cmbDiagNose.Name = "cmbDiagNose";
            this.cmbDiagNose.PopForm = null;
            this.cmbDiagNose.ShowCustomerList = false;
            this.cmbDiagNose.ShowID = false;
            this.cmbDiagNose.Size = new System.Drawing.Size(157, 20);
            this.cmbDiagNose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDiagNose.TabIndex = 25;
            this.cmbDiagNose.Tag = "";
            this.cmbDiagNose.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(57, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 24;
            this.neuLabel1.Text = "选择医保类别";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(58, 40);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 26;
            this.neuLabel2.Text = "诊断名称";
            // 
            // frmSiPobInpatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 393);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSiPobInpatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSiPobInpatientInfo";
            this.Load += new System.EventHandler(this.frmSiPobInpatientInfo_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private ucSiPatientInfoInPatient ucSiPatientInfoInPatient1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOperate3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOperate1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOperate2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPDiagnose;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMedicalType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDiagNose;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
    }
}