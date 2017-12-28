namespace ShenYangCitySI.Control
{
    partial class frmSiPobInpatientInfo
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
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbDiagNose = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbMedicalType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lblDiagnose = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.ucSiPatientInfoInPatient1 = new ShenYangCitySI.Control.ucSiPatientInfoInPatient();
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
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.cmbDiagNose);
            this.neuGroupBox2.Controls.Add(this.cmbMedicalType);
            this.neuGroupBox2.Controls.Add(this.lblDiagnose);
            this.neuGroupBox2.Controls.Add(this.lblType);
            this.neuGroupBox2.Location = new System.Drawing.Point(2, 245);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(616, 100);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "输入信息";
            // 
            // cmbDiagNose
            // 
            this.cmbDiagNose.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDiagNose.FormattingEnabled = true;
            this.cmbDiagNose.IsFlat = true;
            this.cmbDiagNose.IsLike = true;
            this.cmbDiagNose.Location = new System.Drawing.Point(271, 68);
            this.cmbDiagNose.Name = "cmbDiagNose";
            this.cmbDiagNose.PopForm = null;
            this.cmbDiagNose.ShowCustomerList = false;
            this.cmbDiagNose.ShowID = false;
            this.cmbDiagNose.Size = new System.Drawing.Size(191, 20);
            this.cmbDiagNose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDiagNose.TabIndex = 1;
            this.cmbDiagNose.Tag = "";
            this.cmbDiagNose.ToolBarUse = false;
            this.cmbDiagNose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDiagNose_KeyDown);
            // 
            // cmbMedicalType
            // 
            this.cmbMedicalType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMedicalType.FormattingEnabled = true;
            this.cmbMedicalType.IsFlat = true;
            this.cmbMedicalType.IsLike = true;
            this.cmbMedicalType.Location = new System.Drawing.Point(271, 25);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(191, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMedicalType.TabIndex = 0;
            this.cmbMedicalType.Tag = "";
            this.cmbMedicalType.ToolBarUse = false;
            this.cmbMedicalType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMedicalType_KeyDown);
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Location = new System.Drawing.Point(153, 66);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(53, 12);
            this.lblDiagnose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDiagnose.TabIndex = 2;
            this.lblDiagnose.Text = "诊断名称";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(153, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(77, 12);
            this.lblType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblType.TabIndex = 0;
            this.lblType.Text = "选择医保类别";
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
            // ucSiPatientInfoInPatient1
            // 
            this.ucSiPatientInfoInPatient1.Location = new System.Drawing.Point(12, 26);
            this.ucSiPatientInfoInPatient1.Name = "ucSiPatientInfoInPatient1";
            this.ucSiPatientInfoInPatient1.Patient = null;
            this.ucSiPatientInfoInPatient1.Size = new System.Drawing.Size(600, 208);
            this.ucSiPatientInfoInPatient1.TabIndex = 0;
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
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDiagnose;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDiagNose;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMedicalType;
    }
}