using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ShenYangCitySI.Control
{
    public partial class frmSiPobInpatientInfo : Form
    {
        public frmSiPobInpatientInfo()
        {
            InitializeComponent();
        }
        #region 变量
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        public string medicalType = string.Empty;
        LocalManager lm = new LocalManager();
        public Boolean isInDiagnose = true;//是否是入院诊断
        #endregion

        #region 属性

        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
                if (!DesignMode)
                {

                    this.ucSiPatientInfoInPatient1.Patient = patient;

                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化医疗类别

        /// </summary>
        /// <returns></returns>
        protected int InitMedicalType()
        {
            EnumMedicalTypeServiceInhos es = new EnumMedicalTypeServiceInhos();
            this.cmbMedicalType.AddItems(EnumMedicalTypeServiceInhos.List());
            if (this.patient.SIMainInfo.MedicalType.ID != null && this.patient.SIMainInfo.MedicalType.ID != "")
            {
                this.cmbMedicalType.Tag = this.patient.SIMainInfo.MedicalType.ID;
            }
            else
            {
                //默认医保类别
                this.cmbMedicalType.Tag = "21";
            }

            return 1;
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <returns></returns>
        protected int InitDiagnose()
        {
            ArrayList al = new ArrayList();
            this.lm.SetTrans(Process.myTrans);

            al = this.lm.GetDiagnoseby(this.patient);
            if (al != null && al.Count != 0)
            {
                this.cmbDiagNose.AddItems(al);
            }
            return 1;
        }
        /// <summary>
        /// 输入值校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //必须输入类别
            if (this.cmbMedicalType.Tag == null || this.cmbMedicalType.Text.Trim() == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选这医疗类别"));
                this.cmbMedicalType.Focus();
                return -1;
            }
            //医保患者必须输入诊断
            if (this.cmbDiagNose.Tag == null || this.cmbDiagNose.Text.Trim() == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医保患者必须输入诊断"));
                this.cmbDiagNose.Focus();
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 赋值

        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            this.patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.Tag.ToString();

            if (isInDiagnose)
            {
                this.patient.SIMainInfo.InDiagnose.ID = this.cmbDiagNose.Tag.ToString();
                this.patient.SIMainInfo.InDiagnose.Name = this.cmbDiagNose.Text.Trim();
                this.patient.SIMainInfo.OutDiagnose.ID = this.cmbDiagNose.Tag.ToString();
                this.patient.SIMainInfo.OutDiagnose.Name = this.cmbDiagNose.Text.ToString();
            }
            else
            {

                this.patient.SIMainInfo.OutDiagnose.ID = this.cmbDiagNose.Tag.ToString();
                this.patient.SIMainInfo.OutDiagnose.Name = this.cmbDiagNose.Text.ToString();
            }
            return 1;

        }

        private void frmSiPobInpatientInfo_Load(object sender, EventArgs e)
        {
            this.InitMedicalType();
            this.InitDiagnose();
            this.cmbMedicalType.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //校验
            //校验
            if (this.Valid() == 1)
            {
                if (this.GetValue() == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }      

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbMedicalType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (cmbDiagNose.Enabled)
                {
                    cmbDiagNose.Focus();
                }
                else
                {
                    btnOK.Focus();
                }
            }
        }

        private void cmbDiagNose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                //if (cmbDiagNose.Enabled)
                //{
                //    cmbDiagNose.Focus();
                //}
                //else
                //{
                btnOK.Focus();
                //}
            }
        }
    }
}