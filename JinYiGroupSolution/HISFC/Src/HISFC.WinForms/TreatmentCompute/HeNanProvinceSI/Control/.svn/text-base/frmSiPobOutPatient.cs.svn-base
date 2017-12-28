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
    /// [功能描述: 门诊登记]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>
    public partial class frmSiPobOutPatient : Form
    {
        #region 变量
       /// <summary>
       /// 患者实体
       /// </summary>
        private Neusoft.HISFC.Models.Registration.Register patient =null;

        /// <summary>
        /// 医疗类别
        /// </summary>
        public string medicalType = string.Empty;
        
        /// <summary>
        /// 本地业务层
        /// </summary>
        LocalManager lm = new LocalManager();
        
        /// <summary>
        /// 是否门诊挂号诊断
        /// </summary>
        public Boolean isInDiagnose = true;

        /// <summary>
        /// 诊断主码字典
        /// </summary>
        private Dictionary<string, ICDMedicare> diagnoseDictionary = new Dictionary<string, ICDMedicare>();

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
        public frmSiPobOutPatient()
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

            #region   {420CD8E8-4D29-4456-A5CD-B9622FFCDC86}

            al = this.lm.GetDiagnose();

            #endregion
            //al = this.lm.GetDiagnoseby(patient);
            if (al != null && al.Count != 0)
            {
                this.cmbDiagNose.AddItems(al);

                #region {33C28EDD-35C1-428c-9894-E38253DC3373}  初始化主诊断字典

                foreach (ICDMedicare icd in al)
                {
                    diagnoseDictionary.Add(icd.ID, icd);
                }

                #endregion
            }
            return 1;
        }

        #region {EEDAF17B-38D2-48cc-81FF-D8752303BD67}
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
            }
            return 1;
        }

        #endregion

        #region {3E0DDC00-1896-4670-963B-C20B5C4E27F0}

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
        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {

            #region {091937BE-1472-4d6f-BBB7-007B964EA3C9}

            if (this.Text == "市保—门诊挂号")
            {
                //医疗类别不能为空
                if (this.cmbMedicalType.Tag == null || this.cmbMedicalType.Text.Trim() == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别"));
                    this.cmbMedicalType.Focus();
                    return -1;
                }

                if (this.cmbMedicalType.Tag.ToString() == "12")
                {
                    if (this.cmbPDiagnose.Text == "")
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("特殊门诊必须输入特殊标识"));
                        this.cmbMedicalType.Focus();
                        return -1;
                    }
                }
            }
            if (this.Text == "市保—门诊结算")
            {
                #region {9640FCCD-7399-4e8d-BD9C-99B037B3B6A5} 必须录入诊断

                if (this.cmbDiagNose.Text == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请录入诊断"));
                    this.cmbDiagNose.Focus();
                    return -1;
                }

                #endregion
                if (this.cmbMedicalType.Tag.ToString() == "12" && this.cmbPDiagnose.Text == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("特殊门诊必须输入特殊标识"));
                    this.cmbPDiagnose.Focus();
                    return -1;
                }

                if (this.cmbMedicalType.Tag.ToString() == "41" || this.cmbMedicalType.Tag.ToString() == "43")
                {
                    if (this.cmbDiagNose.Text == "")
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("节育门诊、生育门诊必须输入主诊断"));
                        this.cmbDiagNose.Focus();
                        return -1;
                    }
                    if (this.cmbPDiagnose.Text == "")
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("节育门诊、生育门诊必须输入识别码"));
                        this.cmbPDiagnose.Focus();
                        return -1;
                    }
                }

                if (this.cmbMedicalType.Tag.ToString() == "11" || this.cmbMedicalType.Tag.ToString() == "15" || this.cmbMedicalType.Tag.ToString() == "27")
                {
                    if (this.cmbDiagNose.Text != "")
                    {
                        if ((this.diagnoseDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea != "0")
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
                    if (!((this.diagnoseDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea == "3" || (this.diagnoseDictionary[this.cmbDiagNose.Tag.ToString()] as ICDMedicare).UseArea == "4"))
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("节育门诊的主码只能录‘生育’和‘生育转住院’类别的主码"));
                        this.cmbPDiagnose.Focus();
                        return -1;
                    }
                }
            }

            #endregion 
            ////医疗类别不能为空
            //if (this.cmbMedicalType.Tag == null || this.cmbMedicalType.Text.Trim() == "")
            //{
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别") );
            //    this.cmbMedicalType.Focus();
            //    return -1;
            //}
            ////特殊门诊必须输入诊断
            //if (this.cmbMedicalType.Tag.ToString() == "12" && string.IsNullOrEmpty (this.cmbDiagNose.Tag.ToString()))
            //{
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("特殊门诊必须输入诊断"));
            //    this.cmbDiagNose.Focus();
            //    return -1;
            //}
            ////生育门诊必须输入诊断
            //if (this.cmbMedicalType.Tag.ToString() == "43" && string.IsNullOrEmpty(this.cmbDiagNose.Tag.ToString()))
            //{
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("生育门诊必须输入诊断"));
            //    this.cmbDiagNose.Focus();
            //    return -1;
            //}
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
                //this.patient.SIMainInfo.OutDiagnose.ID = this.cmbDiagNose.Tag.ToString();
                //this.patient.SIMainInfo.OutDiagnose.Name = this.cmbDiagNose.Text.ToString();

                #region {F235E65F-FC57-464b-8A5E-AC2824A08C72} 获得识别码和手术编码

                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = this.cmbPDiagnose.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = this.cmbPDiagnose.Text.Trim();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode1 = this.cmbOperate1.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode2 = this.cmbOperate2.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode3 = this.cmbOperate3.Tag.ToString();

                #endregion 
            }
            else
            {

                this.patient.SIMainInfo.OutDiagnose.ID = this.cmbDiagNose.Tag.ToString();
                this.patient.SIMainInfo.OutDiagnose.Name = this.cmbDiagNose.Text.ToString();
                #region {FAEC6E1E-3EF8-4d86-9466-9D75BE044BCD} 获得识别码和手术编码
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseCode = this.cmbPDiagnose.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).PrimaryDiagnoseName = this.cmbPDiagnose.Text.Trim();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode1 = this.cmbOperate1.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode2 = this.cmbOperate2.Tag.ToString();
                Process.ExtendProperty<Object.ExtendProperty>(Process.EXTEND_PROPERTY_KEY, this.patient.SIMainInfo.ExtendProperty).OperatorCode3 = this.cmbOperate3.Tag.ToString();

                #endregion
            }
            return 1;

        }
        #endregion

        #region 事件
        private void frmSiPob_Load(object sender, EventArgs e)
        {
            this.InitMedicalType();
            this.InitDiagnose();


            #region {DB2611B1-29E2-43ba-9E3A-8D3623FAA3C9} 让手术码无效

            this.InitPDiagnose();
            this.InitOperate();

            if (this.Text == "市保—门诊挂号")
            {
                this.cmbOperate1.Enabled = false;
                this.cmbOperate2.Enabled = false;
                this.cmbOperate3.Enabled = false;
            }

            #region {B2461A19-B430-4c4f-8087-439F28CACE6A}

            #endregion
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
            #endregion
        }

        #endregion
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


        private void cmbMedicalType_SelectedIndexChanged(object sender, EventArgs e)
        {

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
