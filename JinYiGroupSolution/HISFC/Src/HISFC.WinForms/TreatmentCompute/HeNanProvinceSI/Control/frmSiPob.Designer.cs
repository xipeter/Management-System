namespace HeNanProvinceSI.Control
{
    partial class frmSiPob
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
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.gbPatient = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucSiPatientInfoOutPatient1 = new HeNanProvinceSI.Control.ucSiPatientInfoOutPatient();
            this.gbInput = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
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
            this.gbPatient.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(385, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.neuButton2_Click);
            // 
            // gbPatient
            // 
            this.gbPatient.Controls.Add(this.ucSiPatientInfoOutPatient1);
            this.gbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPatient.Location = new System.Drawing.Point(0, 0);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Size = new System.Drawing.Size(613, 247);
            this.gbPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbPatient.TabIndex = 0;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "医保患者信息";
            // 
            // ucSiPatientInfoOutPatient1
            // 
            this.ucSiPatientInfoOutPatient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSiPatientInfoOutPatient1.Location = new System.Drawing.Point(3, 17);
            this.ucSiPatientInfoOutPatient1.Name = "ucSiPatientInfoOutPatient1";
            this.ucSiPatientInfoOutPatient1.Patient = null;
            this.ucSiPatientInfoOutPatient1.Size = new System.Drawing.Size(607, 227);
            this.ucSiPatientInfoOutPatient1.TabIndex = 0;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.cmbOperate3);
            this.gbInput.Controls.Add(this.neuLabel4);
            this.gbInput.Controls.Add(this.cmbOperate1);
            this.gbInput.Controls.Add(this.cmbOperate2);
            this.gbInput.Controls.Add(this.neuLabel5);
            this.gbInput.Controls.Add(this.neuLabel6);
            this.gbInput.Controls.Add(this.cmbPDiagnose);
            this.gbInput.Controls.Add(this.neuLabel3);
            this.gbInput.Controls.Add(this.cmbMedicalType);
            this.gbInput.Controls.Add(this.cmbDiagNose);
            this.gbInput.Controls.Add(this.neuLabel1);
            this.gbInput.Controls.Add(this.neuLabel2);
            this.gbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(610, 100);
            this.gbInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "输入信息";
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.gbPatient);
            this.neuPanel1.Location = new System.Drawing.Point(3, 5);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(613, 247);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 6;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.gbInput);
            this.neuPanel2.Location = new System.Drawing.Point(6, 258);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(610, 100);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.btnOK);
            this.neuPanel3.Controls.Add(this.btnCancel);
            this.neuPanel3.Location = new System.Drawing.Point(8, 364);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(608, 47);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 0;
            // 
            // cmbOperate3
            // 
            this.cmbOperate3.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOperate3.FormattingEnabled = true;
            this.cmbOperate3.IsEnter2Tab = false;
            this.cmbOperate3.IsFlat = true;
            this.cmbOperate3.IsLike = true;
            this.cmbOperate3.Location = new System.Drawing.Point(403, 68);
            this.cmbOperate3.Name = "cmbOperate3";
            this.cmbOperate3.PopForm = null;
            this.cmbOperate3.ShowCustomerList = false;
            this.cmbOperate3.ShowID = false;
            this.cmbOperate3.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate3.TabIndex = 21;
            this.cmbOperate3.Tag = "";
            this.cmbOperate3.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(344, 71);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(41, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 22;
            this.neuLabel4.Text = "手术三";
            // 
            // cmbOperate1
            // 
            this.cmbOperate1.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOperate1.FormattingEnabled = true;
            this.cmbOperate1.IsEnter2Tab = false;
            this.cmbOperate1.IsFlat = true;
            this.cmbOperate1.IsLike = true;
            this.cmbOperate1.Location = new System.Drawing.Point(403, 13);
            this.cmbOperate1.Name = "cmbOperate1";
            this.cmbOperate1.PopForm = null;
            this.cmbOperate1.ShowCustomerList = false;
            this.cmbOperate1.ShowID = false;
            this.cmbOperate1.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate1.TabIndex = 17;
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
            this.cmbOperate2.Location = new System.Drawing.Point(403, 40);
            this.cmbOperate2.Name = "cmbOperate2";
            this.cmbOperate2.PopForm = null;
            this.cmbOperate2.ShowCustomerList = false;
            this.cmbOperate2.ShowID = false;
            this.cmbOperate2.Size = new System.Drawing.Size(153, 20);
            this.cmbOperate2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOperate2.TabIndex = 19;
            this.cmbOperate2.Tag = "";
            this.cmbOperate2.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(343, 15);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 18;
            this.neuLabel5.Text = "手术一";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(344, 43);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(41, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 20;
            this.neuLabel6.Text = "手术二";
            // 
            // cmbPDiagnose
            // 
            this.cmbPDiagnose.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPDiagnose.FormattingEnabled = true;
            this.cmbPDiagnose.IsEnter2Tab = false;
            this.cmbPDiagnose.IsFlat = true;
            this.cmbPDiagnose.IsLike = true;
            this.cmbPDiagnose.Location = new System.Drawing.Point(154, 68);
            this.cmbPDiagnose.Name = "cmbPDiagnose";
            this.cmbPDiagnose.PopForm = null;
            this.cmbPDiagnose.ShowCustomerList = false;
            this.cmbPDiagnose.ShowID = false;
            this.cmbPDiagnose.Size = new System.Drawing.Size(157, 20);
            this.cmbPDiagnose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPDiagnose.TabIndex = 15;
            this.cmbPDiagnose.Tag = "";
            this.cmbPDiagnose.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(55, 68);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 16;
            this.neuLabel3.Text = "标识名称";
            // 
            // cmbMedicalType
            // 
            this.cmbMedicalType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMedicalType.FormattingEnabled = true;
            this.cmbMedicalType.IsEnter2Tab = false;
            this.cmbMedicalType.IsFlat = true;
            this.cmbMedicalType.IsLike = true;
            this.cmbMedicalType.Location = new System.Drawing.Point(154, 13);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(157, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMedicalType.TabIndex = 11;
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
            this.cmbDiagNose.Location = new System.Drawing.Point(154, 40);
            this.cmbDiagNose.Name = "cmbDiagNose";
            this.cmbDiagNose.PopForm = null;
            this.cmbDiagNose.ShowCustomerList = false;
            this.cmbDiagNose.ShowID = false;
            this.cmbDiagNose.Size = new System.Drawing.Size(157, 20);
            this.cmbDiagNose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDiagNose.TabIndex = 13;
            this.cmbDiagNose.Tag = "";
            this.cmbDiagNose.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(54, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 12;
            this.neuLabel1.Text = "选择医保类别";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(55, 40);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 14;
            this.neuLabel2.Text = "诊断名称";
            // 
            // frmSiPob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 416);
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSiPob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择医疗类别";
            this.Load += new System.EventHandler(this.frmSiPob_Load);
            this.gbPatient.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private ucSiPatientInfoOutPatient ucSiPatientInfoOutPatient1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
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