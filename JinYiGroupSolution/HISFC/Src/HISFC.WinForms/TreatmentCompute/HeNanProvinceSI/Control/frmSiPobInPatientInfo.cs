using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HeNanProvinceSI.Object;


namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// [功能描述: 住院登记]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>
    public partial class frmSiPobInPatientInfo : Form
    {
        public frmSiPobInPatientInfo()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 患者实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string medicalType = string.Empty;

        /// <summary>
        /// 本地业务层
        /// </summary>
        LocalManager lm = new LocalManager();

        /// <summary>
        /// 是否是入院诊断
        /// </summary>
        public Boolean isInDiagnose = true;

        #region {B670E7D1-C113-48a0-B9CC-2B98D92B3012} 添加诊断主码字典和手术码字典

        /// <summary>
        /// 主诊断字典表
        /// </summary>
        private Dictionary<string, ICDMedicare> diagDictionary = new Dictionary<string, ICDMedicare>();

        /// <summary>
        /// 识别码字典
        /// </summary>
        private Dictionary<string, ICDMedicare> pdiagDictionary = new Dictionary<string, ICDMedicare>();

        #endregion
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

        #region 方法
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

            #region {A1F6F711-51BF-40f7-B23A-5C715D86C869} 改变诊断信息

            al = this.lm.GetDiagnose();

            #endregion
            if (al != null && al.Count != 0)
            {
                this.cmbDiagNose.AddItems(al);
                #region  {D2782952-1941-4763-B05A-8F827C4489D9} 初始化主诊断字典

                foreach (ICDMedicare icd in al)
                {
                    diagDictionary.Add(icd.ID, icd);
                }

                #endregion
            }
            return 1;
        }

        #region {95FA3533-E8FB-45cf-9FBA-44BBEF1BF084} 添加识别码信息和手术信息

        /// <summary>
        /// 添加特殊标识信息
        /// </summary>
        /// <returns></returns>
        protected int InitPDiagnose()
        {
            ArrayList al = new ArrayList();
            this.lm.SetTrans(Process.myTrans);
            al = this.lm.GetPDiagnose();
            if (al != null && al.Count != 0)
            {
                this.cmbPDiagnose.AddItems(al);

                foreach (ICDMedicare icd in al)
                {
                    pdiagDictionary.Add(icd.ID, icd);
                }
            }
            return 1;
        }

        /// <summary>
        /// 添加手术信息
        /// </summary>
        /// <returns></returns>
        protected int InitOperate()
        {
            ArrayList al = new ArrayList();
            this.lm.SetTrans(Process.myTrans);
            al = this.lm.GetOperate();
            if (al != null && al.Count != 0)
            {
                this.cmbOperate1.AddItems(al);
                this.cmbOperate2.AddItems(al);
                this.cmbOperate3.AddItems(al);
            }
            return 1;
        }

        #endregion

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

            #region {3C2B5058-79CE-43dc-8049-EC45B7D7ED39} 增加有效性判断
            if (this.cmbMedicalType.Tag.ToString() == "21" || this.cmbMedicalType.Tag.ToString() == "22" || this.cmbMedicalType.Tag.ToString() == "24" || this.cmbMedicalType.Tag.ToString() == "29")
            {
                if ((this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea != "0")
                {
                    if ((this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea == "4")
                    {
                        if (this.cmbPDiagnose.Tag.ToString() != "10560")
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("范围内外为IV的主码，识别码必须为‘10560’"));
                            this.cmbDiagNose.Focus();
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("主码必须输入范围内外为生育或生育转住院的主码"));
                        this.cmbDiagNose.Focus();
                        return -1;
                    }
                }
                else
                {
                    if (!((this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).DisKind == "1" || (this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).DisKind == "2"))
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("主码必须输入病种类别为‘I类’、‘II类’的病种"));
                        this.cmbDiagNose.Focus();
                        return -1;
                    }
                }
            }


            if (this.cmbMedicalType.Tag.ToString() == "11" || this.cmbMedicalType.Tag.ToString() == "15" || this.cmbMedicalType.Tag.ToString() == "27")
            {
                if (this.cmbDiagNose.Text != "")
                {
                    if ((this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea != "0")
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("普通门诊、健康体检、定点医疗机构急诊的主诊断只能录非生育的诊断"));
                        this.cmbDiagNose.Focus();
                        return -1;
                    }
                }
            }

            if (this.cmbMedicalType.Tag.ToString() == "41")
            {
                if (this.cmbDiagNose.Tag.ToString() != "Z01.403")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("生育门诊的诊断主码只能录“Z01.403”"));
                    this.cmbDiagNose.Focus();
                    return -1;
                }
                if (this.cmbPDiagnose.Tag.ToString() != "20106")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("生育门诊的识别码只能录“20106”"));
                    this.cmbPDiagnose.Focus();
                    return -1;
                }
            }

            if (this.cmbMedicalType.Tag.ToString() == "43")
            {
                if (!((this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea == "3" || (this.diagDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea == "4"))
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("节育门诊的主码只能录‘生育’和‘生育转住院’类别的主码"));
                    this.cmbPDiagnose.Focus();
                    return -1;
                }
            }


            #endregion

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

            #region {A956CEBB-BCDA-4764-AD92-6907F31859EC} 获取识别码和手术信息

            if (this.cmbPDiagnose.Tag != null)
            {
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = this.cmbPDiagnose.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = this.cmbPDiagnose.Text.Trim();
            }
            if (this.cmbOperate1.Tag != null)
            {
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode1 = this.cmbOperate1.Tag.ToString();
            }
            if (this.cmbOperate2.Tag != null)
            {
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode2 = this.cmbOperate2.Tag.ToString();
            }
            if (this.cmbOperate1.Tag != null)
            {
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode3 = this.cmbOperate3.Tag.ToString();
            }

            #endregion
            return 1;

        }

        private void frmSiPobInpatientInfo_Load(object sender, EventArgs e)
        {
            this.InitMedicalType();
            this.InitDiagnose();

            #region {F66F0A8B-A692-49d7-BF26-75F800AE3E5A}

            this.InitPDiagnose();
            this.InitOperate();

            #endregion
            this.cmbMedicalType.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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
                btnOK.Focus();
            }
        }

        #endregion
    }
}