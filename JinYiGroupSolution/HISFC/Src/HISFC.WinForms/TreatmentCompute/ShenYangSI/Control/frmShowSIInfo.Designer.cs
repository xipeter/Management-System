namespace ShenYangCitySI.Control
{
    partial class frmShowSIInfo
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
            this.gbPatient = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucSiPatientInfoOutPatient1 = new ShenYangCitySI.Control.ucSiPatientInfoOutPatient();
            this.gbPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPatient
            // 
            this.gbPatient.Controls.Add(this.ucSiPatientInfoOutPatient1);
            this.gbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPatient.Location = new System.Drawing.Point(0, 0);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Size = new System.Drawing.Size(571, 333);
            this.gbPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbPatient.TabIndex = 1;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "医保患者信息";
            // 
            // ucSiPatientInfoOutPatient1
            // 
            this.ucSiPatientInfoOutPatient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSiPatientInfoOutPatient1.Location = new System.Drawing.Point(3, 17);
            this.ucSiPatientInfoOutPatient1.Name = "ucSiPatientInfoOutPatient1";
            this.ucSiPatientInfoOutPatient1.Patient = null;
            this.ucSiPatientInfoOutPatient1.Size = new System.Drawing.Size(565, 313);
            this.ucSiPatientInfoOutPatient1.TabIndex = 0;
            // 
            // frmShowSIInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 333);
            this.Controls.Add(this.gbPatient);
            this.Name = "frmShowSIInfo";
            this.Text = "市医保患者帐户信息";
            this.Load += new System.EventHandler(this.frmShowSIInfo_Load);
            this.gbPatient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ucSiPatientInfoOutPatient ucSiPatientInfoOutPatient1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbPatient;
    }
}