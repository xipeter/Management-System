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
    public partial class frmSiPob : Form
    {
        #region 变量
        private Neusoft.HISFC.Models.Registration.Register patient =null;
        public string medicalType = string.Empty;
        LocalManager lm = new LocalManager();
        public Boolean isInDiagnose = true;//是否门诊挂号诊断
        #endregion

        #region 属性
        public Neusoft.HISFC.Models.Registration.Register Patient
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

                    this.ucSiPatientInfoOutPatient1.Patient = patient;

                 
                }
            }
        }
        #endregion

        #region 方法
        public frmSiPob()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化医疗类别
        /// </summary>
        /// <returns></returns>
        protected int InitMedicalType()
        {
            EnumMedicalTypeService es = new EnumMedicalTypeService();
            this.cmbMedicalType.AddItems(EnumMedicalTypeService.List());
            if (this.patient.SIMainInfo.MedicalType.ID != null && this.patient.SIMainInfo.MedicalType.ID != "")
            {
                this.cmbMedicalType.Tag = this.patient.SIMainInfo.MedicalType.ID;
            }
            else
            {
                //默认医保类别
                this.cmbMedicalType.Tag = "11";
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
            al = this.lm.GetDiagnoseby(patient);
            if (al != null && al.Count != 0)
            {
                this.cmbDiagNose.AddItems(al);
            }
            return 1;
        }
        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //医疗类别不能为空
            if (this.cmbMedicalType.Tag == null || this.cmbMedicalType.Text.Trim() == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别") );
                this.cmbMedicalType.Focus();
                return -1;
            }
            //特殊门诊必须输入诊断
            if (this.cmbMedicalType.Tag.ToString() == "12" && string.IsNullOrEmpty (this.cmbDiagNose.Tag.ToString()))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("特殊门诊必须输入诊断"));
                this.cmbDiagNose.Focus();
                return -1;
            }
            //生育门诊必须输入诊断
            if (this.cmbMedicalType.Tag.ToString() == "43" && string.IsNullOrEmpty(this.cmbDiagNose.Tag.ToString()))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("生育门诊必须输入诊断"));
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
        #endregion

        #region 事件
        private void frmSiPob_Load(object sender, EventArgs e)
        {
            this.InitMedicalType();
            this.InitDiagnose();
            if (this.cmbMedicalType.Text == "普通门诊")//普通门诊不能选诊断
            {
                this.cmbDiagNose.Enabled = false;
                this.cmbDiagNose.Text = string.Empty;
                this.cmbDiagNose.Tag = string.Empty;
            }
            if (this.patient.SIMainInfo.MedicalType.ID == "12" && !isInDiagnose)//特殊门诊 不能改变医保类别
            {
                this.cmbMedicalType.Text = "特殊门诊";
                this.cmbMedicalType.Enabled = false;
            }
            if (this.patient.SIMainInfo.MedicalType.ID == "43" && !isInDiagnose)//节育门诊 不能改变医保类别
            {
                this.cmbMedicalType.Text = "节育门诊";
                this.cmbMedicalType.Enabled = false;
            }
            if (this.patient.SIMainInfo.MedicalType.ID == "41" && !isInDiagnose)//生育门诊 不能改变医保类别
            {
                this.cmbMedicalType.Text = "生育门诊";
                this.cmbMedicalType.Enabled = false;
            }
        }


        private void neuButton1_Click(object sender, EventArgs e)
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

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        private void cmbMedicalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbMedicalType.Text == "普通门诊")//普通门诊不能选诊断
            {
                this.cmbDiagNose.Enabled = false;
                this.cmbDiagNose.Text = string.Empty;
                this.cmbDiagNose.Tag = string.Empty;
            }
            else
            {
                this.cmbDiagNose.Enabled = true;
            }
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