using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.BizLogic.Fee;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.WinForms.Forms;
using System.Xml;


namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    /// <summary>
    /// ucRegister<br></br>
    /// [功能描述: 住院登记UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRegister : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISIReadCard
    {
        /// <summary>
        /// 
        /// </summary>
        public ucRegister()
        {
            InitializeComponent();
        }

        #region 变量

        private string hl7 = "A01";

        /// <summary>
        /// 当前错误信息
        /// </summary>
        private string errText;

        /// <summary>
        /// 是否可以修改住院日期
        /// </summary>
        private bool isCanModifyInTime;

        /// <summary>
        /// 是否为修改状态
        /// </summary>
        private bool isModify = false;

        /// <summary>
        /// 必须输入的项文本显示颜色
        /// </summary>
        private Color mustInputColor = Color.Blue;

        /// <summary>
        /// 输入的门诊号是否必须输入
        /// </summary>
        private bool rdoClinicNOIsMustInput = false;

        /// <summary>
        /// 必须输入的控件列表
        /// </summary>
        private Hashtable mustInputHashTable = new Hashtable();

        /// <summary>
        /// 住院患者基本信息实体
        /// </summary>
        private PatientInfo patientInfomation = new PatientInfo();
        private bool homeAddressChangeLanguage = false; 
        private bool linkManAddressChangeLanguage = false;
        private bool isCreateMoneyAlert = false;
        private bool workAddressChangeLanguage = false;
        //担保类型
        private SuretyTypeEnumService suretyType = new SuretyTypeEnumService();

        /// <summary>
        /// 扩展信息接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IRegisterExtend registerExtend;


        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 是否按照TabIndex,回车切换焦点
        /// </summary>
        private bool isTabIndexFocused = true;

        /// <summary>
        /// 是否自动生成住院号
        /// </summary>
        private bool isAutoInpatientNO = true;

        /// <summary>
        /// 住院号临时生成参数
        /// </summary>
        private string autoPatientParms = string.Empty;

        /// <summary>
        /// 是否直接选择病床
        /// </summary>
        private bool isSelectBed = false;
        /// <summary>
        /// 是否读卡
        /// </summary>
        private bool isReadCard = false;

        /// <summary>
        /// 存储更新患者信息时的住院号(liu.xq加)
        /// </summary>
        private string tempUpdatePatientID;
        #region added by xizf 按比例欠费
        /// <summary>
        /// 按比例欠费业务层
        /// </summary>
        Components.InpatientFee.Function fun = new Function();
        #endregion
        /// <summary>
        /// 打印病案
        /// </summary>
        Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface healthPrint = null;

        #region 控件必须输入变量

        /// <summary>
        /// 住院号是否必须输入
        /// </summary>
        private bool rdoInpatientNOIsMustInput = false;

        /// <summary>
        /// 医疗证件号码是否必须输入
        /// </summary>
        private bool txtMCardIsMustInput = false;

        /// <summary>
        /// 入院日期是否必须输入
        /// </summary>
        private bool dtpInDateMustInput = false;

        /// <summary>
        /// 结算方式是否必须输入
        /// </summary>
        private bool cmbPactIsMustInput = false;

        /// <summary>
        /// 姓名是否必须输入
        /// </summary>
        private bool txtNameIsMustInput = false;

        /// <summary>
        /// 性别是否必须输入 默认必须输入
        /// </summary>
        private bool cmbSexIsMustInput = true;

        /// <summary>
        /// 科室是否必须输入 默认必须输入
        /// </summary>
        private bool cmbDeptIsMustInput = true;

        /// <summary>
        /// 科室是否必须输入 默认必须输入
        /// </summary>
        private bool cmbNurseCellIsMustInput = true;

        /// <summary>
        /// 出生日期是否必须输入 默认必须输入
        /// </summary>
        private bool dtpBirthDayMustInput = true;

        ///// <summary>
        ///// 工作单位是否必须输入 默认必须输入
        ///// </summary>
        //private bool cmbWorkAddressMustInput = true;

        /// <summary>
        /// 收住医师是否必须输入 默认必须输入
        /// </summary>
        private bool cmbDoctorMustInput = true;

        /// <summary>
        /// 预交金额是否必须输入 默认必须输入
        /// </summary>
        private bool mTxtPrepayMustInput = true;

        /// <summary>
        /// 预交金打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint prepayPrint = null;
        /// <summary>
        /// 是否包含接诊流程
        /// </summary>
        private bool IsContainsInstate=false;

        /// <summary>
        /// ADT接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        ////{0374EA05-782E-4609-9CDC-03236AB97906}
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety iPrintSureType = null;

        /// <summary>
        /// 是否可以自动生成住院号
        /// </summary>
        private bool isCanAutoInpatientNO = true;
        #endregion

        #region 业务层变量

        /// <summary>
        /// 住院费用业务层
        /// </summary>
        private InPatient inpatientManager = new InPatient();

        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 费用公用接口业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        private PactUnitInfo pactManager = new PactUnitInfo();

        /// <summary>
        /// 参数控制类
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
        /// <summary>
        /// 费用代理类
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

        Neusoft.HISFC.BizProcess.Interface.IQueryGFPatient queryGFPatient = null;
        #endregion

        /// <summary>
        /// 是否打印病案
        /// </summary>
        //{F862D2BC-57DB-4868-9A4D-32A47A8B4588}
        private bool isHealthPrint = true;


        /// <summary>
        /// 是否校验身份证号
        /// {EF38942A-1959-4edd-AF6A-3E3854E6AC88}
        /// </summary>
        private bool isCheckIdCardNo = true;

        /// <summary>
        /// 默认合同单位{205C0764-F871-440e-8E77-79A9298E5A0D}
        /// </summary>
        private string pactName = string.Empty;

        #region {07EE4783-D3B3-48d4-B712-7847CF13FBB7} 读院内卡

        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();

        HISFC.Models.RADT.InPatientProof inPatientProof = new InPatientProof();

        HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();
        #endregion

        #endregion

        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[5];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint);
                type[1] = typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT);
                //{0374EA05-782E-4609-9CDC-03236AB97906}
                type[2] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety);

                //{1336CBD1-EF5A-430c-9965-B9BC72823593}
                type[3] = typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface);
                type[4] = typeof(Neusoft.HISFC.BizProcess.Interface.IQueryGFPatient);
                return type;
            }
        }

          #endregion

        private int regDay = 1;      
        [Category("控件设置"), Description("显示登记天数内信息")]
        public int RegDay
        {
            get { return regDay; }
            set { regDay = value; }
        }
        #region 住院号错误性检查，这里为住院号的长度 xizf@neusoft.com 20101028{98AD0BF2-F13E-4323-99B3-861A2F7AD081}
        private int noLength = 7;
        [Category("控件设置"), Description("检查住院号的长度")]
        public int NoLength
        {
            get { return noLength; }
            set { noLength = value; }
        }
        #endregion
        #region 控件必须输入

        /// <summary>
        /// 患者姓名是否必须输入
        /// </summary>
        [Category("控件设置"), Description("患者姓名是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 患者姓名必须输入
        {
            set
            {
                this.txtNameIsMustInput = value;

                if (this.txtNameIsMustInput)
                {
                    this.lblName.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblName, this.txtName, this.txtNameIsMustInput);
            }
            //get
            //{
            //    return this.txtNameIsMustInput;
            //}
        }

        /// <summary>
        /// 患者姓名是否必须输入
        /// </summary>
        [Category("控件设置"), Description("患者性别是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 患者性别必须输入
        {
            set
            {
                this.cmbSexIsMustInput = value;

                if (this.cmbSexIsMustInput)
                {
                    this.lblSex.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblSex, this.cmbSex, this.cmbSexIsMustInput);
            }
           
        }

        /// <summary>
        /// 患者科室是否必须输入
        /// </summary>
        [Category("控件设置"), Description("患者科室是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 登记科室必须输入
        {
            set
            {
                this.cmbDeptIsMustInput = value;

                if (this.cmbDeptIsMustInput)
                {
                    this.lblDept.ForeColor = mustInputColor;
                }
                
                this.AddOrRemoveUnitAtMustInputLists(this.lblDept, this.cmbDept, this.cmbDeptIsMustInput);
            }
        }

        /// <summary>
        /// 患者病区是否必须输入//{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
        /// </summary>
        [Category("控件设置"), Description("患者病区是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 登记病区必须输入
        {
            set
            {
                this.cmbNurseCellIsMustInput = value;

                if (this.cmbNurseCellIsMustInput)
                {
                    this.lblDept.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblNurseCell, this.cmbNurseCell, this.cmbNurseCellIsMustInput);
            }
        }
        /// <summary>
        /// 结算方式是否必须输入
        /// </summary>
        [Category("控件设置"), Description("结算方式是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 结算方式必须输入
        {
            set
            {
                this.cmbPactIsMustInput = value;

                if (this.cmbPactIsMustInput)
                {
                    this.lblPact.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblPact, this.cmbPact, this.cmbPactIsMustInput);
            }
            get
            {
                return this.cmbPactIsMustInput;
            }
        }

        /// <summary>
        /// 入院日期是否必须输入
        /// </summary>
        [Category("控件设置"), Description("入院日期是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 住院日期必须输入
        {
            set
            {
                this.dtpInDateMustInput = value;

                if (this.dtpInDateMustInput)
                {
                    this.lblInTime.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblInTime, this.dtpInTime, this.dtpInDateMustInput);
            }
            get
            {
                return this.dtpInDateMustInput;
            }
        }

        /// <summary>
        /// 输入的医疗证号是否必须输入
        /// </summary>
        [Category("控件设置"), Description("医疗证号输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 医疗证号必须输入
        {
            set
            {
                this.txtMCardIsMustInput = value;

                if (this.txtMCardIsMustInput)
                {
                    this.lblMCardNO.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.lblMCardNO, this.txtMCardNO, this.txtMCardIsMustInput);
            }
            get
            {
                return this.txtMCardIsMustInput;
            }
        }
        
        /// <summary>
        /// 输入的住院号是否必须输入
        /// </summary>
        [Category("控件设置"), Description("住院号输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 住院号必须输入
        {
            set
            {
                this.rdoInpatientNOIsMustInput = value;

                if (this.rdoInpatientNOIsMustInput)
                {
                    this.rdoInpatientNO.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.rdoInpatientNO, this.txtInpatientNO, this.rdoInpatientNOIsMustInput);
            }
            get
            {
                return this.rdoInpatientNOIsMustInput;
            }
        }

        /// <summary>
        /// 出生日期是否必须输入
        /// </summary>
        [Category("控件设置"), Description("出生日期输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 出生日期必须输入
        {
            set
            {
                this.dtpBirthDayMustInput = value;
                if (this.dtpBirthDayMustInput)
                {
                    this.lblBirthday.ForeColor = mustInputColor;
                }
                this.AddOrRemoveUnitAtMustInputLists(this.lblBirthday, this.dtpBirthDay, this.dtpBirthDayMustInput);
            }
            get
            {
                return this.dtpBirthDayMustInput;
            }
        }

        ///// <summary>
        ///// 工作单位是否必须输入
        ///// </summary>
        //[Category("控件设置"), Description("工作单位输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        //public bool 工作单位必须输入
        //{
        //    set
        //    {
        //        this.cmbWorkAddressMustInput = value;
        //        if (this.cmbWorkAddressMustInput)
        //        {
        //            this.lblWorkAddress.ForeColor = mustInputColor;
        //        }
        //        this.AddOrRemoveUnitAtMustInputLists(this.lblWorkAddress, this.cmbWorkAddress, this.cmbWorkAddressMustInput);
        //    }
        //    get
        //    {
        //        return this.cmbWorkAddressMustInput;
        //    }
        //}

        /// <summary>
        /// 收住医师是否必须输入
        /// </summary>
        [Category("控件设置"), Description("收住医师输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 收住医师必须输入
        {
            set
            {
                this.cmbDoctorMustInput = value;
                if (this.cmbDoctorMustInput)
                {
                    this.lblDoctor.ForeColor = mustInputColor;
                }
                this.AddOrRemoveUnitAtMustInputLists(this.lblDoctor, this.cmbDoctor, this.cmbDoctorMustInput);
            }
            get
            {
                return this.cmbDoctorMustInput;
            }
        }

        /// <summary>
        /// 收住医师是否必须输入
        /// </summary>
        [Category("控件设置"), Description("收住医师输入控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool 预交金额必须输入
        {
            set
            {
                this.mTxtPrepayMustInput = value;
                if (this.mTxtPrepayMustInput)
                {
                    this.lblPrepay.ForeColor = mustInputColor;
                }
                this.AddOrRemoveUnitAtMustInputLists(this.lblPrepay, this.mTxtPrepay, this.mTxtPrepayMustInput);
            }
            get
            {
                return this.mTxtPrepayMustInput;
            }
        }

        /// <summary>
        /// 是否校验身份证号
        /// {EF38942A-1959-4edd-AF6A-3E3854E6AC88}
        /// </summary>
        [Category("控件设置"), Description("是否校验身份证号")]
        public bool 是否校验身份证号
        {
            get
            {
                return isCheckIdCardNo;
            }
            set
            {
                isCheckIdCardNo = value;
            }
        }

        /// <summary>
        /// 合同单位默认
        /// {205C0764-F871-440e-8E77-79A9298E5A0D}
        /// </summary>
        [Category("控件设置"), Description("默认合同单位")]
        public string 默认合同单位
        {
            get
            {
                return pactName;
            }
            set
            {
                pactName = value;
            }
        }
        #endregion

        /// <summary>
        /// 预交金打印接口
        /// </summary>
        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint PrepayPrint 
        {
            set 
            {
                this.prepayPrint = value;
            }
            get 
            {
                return this.prepayPrint;
            }
        }

        /// <summary>
        /// 是否为修改状态
        /// </summary>
        public bool IsModify
        {
            get 
            {
                return this.isModify;
            }
        }
        
        /// <summary>
        /// 扩展信息接口
        /// </summary>
        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IRegisterExtend RegisterExtend 
        {
            set 
            {
                this.registerExtend = value;
            }
        }

        /// <summary>
        /// 当前错误信息
        /// </summary>
        public string ErrText 
        {
            get 
            {
                return this.errText;
            }
        }

        /// <summary>
        /// 当前控件的父窗口
        /// </summary>
        public Form FatherForm 
        {
            get 
            {
                try
                {
                    Form f = this.FindForm();

                    return f;
                }
                catch (Exception e) 
                {
                    this.errText = e.Message;

                    return null;
                }
            }
        }

        /// <summary>
        /// 必须输入的项文本显示颜色
        /// </summary>
        [Category("控件设置"), Description("必须输入控件的颜色")]
        public Color MustInputColor 
        {
            set 
            {
                this.mustInputColor = value;
            }
            get 
            {
                return this.mustInputColor;
            }
        }

        /// <summary>
        /// 住院患者基本信息实体
        /// </summary>
        public PatientInfo PatientInfomation 
        {
            get 
            {
                return this.patientInfomation;
            }
            set 
            {
                this.patientInfomation = value;
            }
        }

        /// <summary>
        /// 是否按照TabIndex,回车切换焦点
        /// </summary>
        [Category("控件设置"), Description("是否按照TabIndex回车切换焦点,如果选择False按照必须输入得控件切换焦点")]
        public bool IsTabIndexFocused
        {
            set 
            {
                this.isTabIndexFocused = value;
            }
            get 
            {
                return this.isTabIndexFocused;
            }
        }
        
        /// <summary>
        /// 输入的门诊号是否必须输入
        /// </summary>
        [Category("控件设置"), Description("门诊号控件是否必须输入,如果设置为True那么控件将显示系统定义的颜色")]
        public bool RdoClinicNOIsMustInput
        {
            set 
            {
                this.rdoClinicNOIsMustInput = value;

                if (this.rdoClinicNOIsMustInput) 
                {
                    this.rdoClinicNO.ForeColor = mustInputColor;
                }

                this.AddOrRemoveUnitAtMustInputLists(this.rdoClinicNO, this.txtClinicNO, this.rdoClinicNOIsMustInput);
            }
            get 
            {
                return this.rdoClinicNOIsMustInput;
            }
        }

        /// <summary>
        /// 是否可以修改住院日期
        /// </summary>
        [Category("控件设置"), Description("True可以修改住院日期 False不可以修改 默认为当前时间")]
        public bool IsCanModifyInTime 
        {
            get 
            {
                return this.isCanModifyInTime;
            }
            set 
            {
                this.isCanModifyInTime = value;

                this.dtpInTime.Enabled = this.isCanModifyInTime;
            }
        }

        /// <summary>
        /// 是否自动生成住院号
        /// </summary>
        [Category("控件设置"), Description("True自动生成住院号 False手工输入住院号 默认为手工输入住院号")]
        public bool IsAutoInpatientNO 
        {
            get 
            {
                return this.isAutoInpatientNO;
            }
            set 
            {
                this.isAutoInpatientNO = value;

                this.btnAutoInpatientNO.Enabled = this.isAutoInpatientNO;

                toolBarService.SetToolButtonEnabled("临时号", this.isAutoInpatientNO);
            }
        }
        
        /// <summary> 
        /// 是否直接选择病床
        /// </summary>
        [Category("控件设置"), Description("家庭地址是否自动切换输入法")]
        public bool HomeAddressChangeLanguage
        {
            get
            {
                return this.homeAddressChangeLanguage;
            }
            set
            {
                this.homeAddressChangeLanguage = value; 
            }
        }
        /// <summary> 
        /// 是否直接选择病床
        /// </summary>
        [Category("控件设置"), Description("家庭地址是否自动切换输入法")]
        public bool WorkAddressChangeLanguage
        {
            get
            {
                return this.workAddressChangeLanguage;
            }
            set
            {
                this.workAddressChangeLanguage = value;
            }
        }
        /// <summary>
        /// 是否直接选择病床
        /// </summary>
        [Category("控件设置"), Description("家庭地址是否自动切换输入法")]
        public bool LinkManAddressChangeLanguage
        {
            get
            {
                return this.linkManAddressChangeLanguage;
            }
            set
            {
                this.linkManAddressChangeLanguage = value; 
            }
        }
        /// <summary>
        /// 是否直接选择病床
        /// </summary>
        [Category("控件设置"), Description("True直接选择病床,既自动接诊 False护士站接诊,这里不分配床 默认护士站接诊,这里不分配床")]
        public bool IsSelectBed 
        {
            get 
            {
                return this.isSelectBed;
            }
            set 
            {
                this.isSelectBed = value;

                this.cmbBedNO.Enabled = this.isSelectBed;
            }
        }

        /// <summary>
        /// 是否直接选择病床
        /// </summary>
        [Category("控件设置"), Description("登记时是否按合同单位自动生成默认警戒线,True:默认的警戒线取常数维护中合同单位的备注，请将备注设置为数字！")]
        public bool IsCreateMoneyAlert
        {
            get
            {
                return this.isCreateMoneyAlert;
            }
            set
            {
                this.isCreateMoneyAlert = value; 
            }
        }
        
        [Category("控件设置"),Description("住院登记时是否打印病案,True:打印:False:不答应")]
        //{F862D2BC-57DB-4868-9A4D-32A47A8B4588}
        public bool IsHealthPrint
        {
            get
            {
                return this.isHealthPrint;
            }
            set
            {
                this.isHealthPrint = value;
            }
        }

        //{0374EA05-782E-4609-9CDC-03236AB97906}
        private void InitInterface()
        {
            this.iPrintSureType = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety;
   
        }

        /// <summary>
        /// 是否自动生成住院号
        /// </summary>
        [Category("控件设置"),Description("是否自动生成住院号")]
        public bool IsCanAutoInpatientNO
        {
            get
            {
                return isCanAutoInpatientNO;
            }
            set
            {
                isCanAutoInpatientNO = value;
                this.btnAutoInpatientNO.Visible = isCanAutoInpatientNO;
                this.txtClinicNO.Enabled = isCanAutoInpatientNO;
            }
        }
       // #endregion

        #region 枚举

        /// <summary>
        /// 已经登记患者列表,列顺序枚举
        /// </summary>
        protected enum PatientLists 
        {
            /// <summary>
            /// 住院号
            /// </summary>
            PatientNO = 0,

            /// <summary>
            /// 姓名
            /// </summary>
            Name,

            /// <summary>
            /// 性别
            /// </summary>
            Sex,

            /// <summary>
            /// 住院科室
            /// </summary>
            Dept,

            /// <summary>
            /// 身份证号
            /// </summary>
            IDNO,

            /// <summary>
            /// 家庭住址
            /// </summary>
            HomeAddress,

            /// <summary>
            /// 登记时间
            /// </summary>
            InDate,

            /// <summary>
            /// 状态
            /// </summary>
            InState
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 根据控件属性,判断是否在必须输入控件列表中加入或者删除该控件
        /// </summary>
        /// <param name="nameControl">名称控件</param>
        /// <param name="inputControl">输入控件</param>
        /// <param name="isMustInput">是否必须输入</param>
        private void AddOrRemoveUnitAtMustInputLists(Control nameControl, Control inputControl, bool isMustInput) 
        {
            if (isMustInput)
            {
                if (!mustInputHashTable.ContainsKey(nameControl))
                {
                    this.mustInputHashTable.Add(nameControl, inputControl);
                }
            }
            else 
            {
                if (mustInputHashTable.ContainsKey(nameControl))
                {
                    this.mustInputHashTable.Remove(nameControl);
                }
            }
        }

        /// <summary>
        /// 自动生成患者登记住院号
        /// </summary>
        /// <param name="patientNO">当前住院号</param>
        /// <returns>成功 : 1 失败 : -1</returns>
        private int GetAutoInpatientNO(string patientNO) 
        {
            PatientInfo patient = new PatientInfo();
            this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期
            //没有输入住院号,说明为第一次入院.
            if (patientNO == string.Empty)
            {
                if (this.radtIntegrate.CreateAutoInpatientNO(patient) == -1)
                {
                    MessageBox.Show(Language.Msg("获得自动生成住院号出错!") + this.radtIntegrate.Err);

                    return -1;
                }

                //默认第一次入院
                patient.InTimes = 1;
            }
            else 
            {
                if (this.radtIntegrate.CreateAutoInpatientNO(patientNO, ref patient) == -1) 
                {
                    MessageBox.Show(Language.Msg("获得住院号出错!") + this.radtIntegrate.Err);

                    return -1;
                }
                //以前住过院
                if (patient.User03 == "SECOND")
                {
                    //判断在院状态
                    if (patient.PVisit.InState.ID.ToString() == "R" || patient.PVisit.InState.ID.ToString() == "I" || patient.PVisit.InState.ID.ToString() == "P" || patient.PVisit.InState.ID.ToString() == "B")
                    {
                        MessageBox.Show(Language.Msg("此患者在院治疗!"));
                        this.patientInfomation = new PatientInfo();
                        this.txtInpatientNO.Text = string.Empty;
                        this.txtInpatientNO.Tag = string.Empty;
                        this.txtClinicNO.Text = string.Empty;

                        return -1;
                    }
                    else//以前住过院目前不在院	
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("此住院号有上次的住院信息！", 111);
                        //清空床号
                        patient.PVisit.PatientLocation.Bed.ID = string.Empty;
                        //姓名不允许修改
                        this.txtName.Enabled = false;
                        //给界面赋值
                        if (!isReadCard)
                        {
                            this.SetPatientInfomation(patient);
                        }
                        else
                        {
                            this.txtInpatientNO.Text = patient.PID.PatientNO;
                            this.txtInpatientNO.Tag = patient.ID;
                            this.txtClinicNO.Text = patient.PID.CardNO;
                            this.mTxtIntimes.Text = (patient.InTimes + 1).ToString();
                            this.patientInfomation.User03 = patient.User03;
                        }

                        this.mTxtIntimes.Text = (patient.InTimes + 1).ToString();
                        this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime();//住院日期
                        this.cmbDoctor.Text = string.Empty;//收住医师
                        this.cmbDept.Focus();

                        return -1;
                    }
                }
            }

            this.txtInpatientNO.Text = patient.PID.PatientNO;
            this.txtInpatientNO.Tag = patient.ID;
            #region {07EE4783-D3B3-48d4-B712-7847CF13FBB7} 将门诊卡号覆盖新产生的卡号
            //this.txtClinicNO.Text = patient.PID.CardNO;
            patient.PID.CardNO = this.txtClinicNO.Text;
            #endregion
            #region 屏蔽{4C9973E5-0153-4339-B3DB-142D8616A350}
            //string cardNO = this.txtClinicNO.Text.Trim();
            ////{61D727CB-A325-4bb4-AE74-1116440FC7C6}
            //if (string.IsNullOrEmpty(cardNO))
            //{
            //    this.txtClinicNO.Text = patient.PID.CardNO;
            //}
            //else
            //{
            //    PatientInfo tempP = radtIntegrate.QueryComPatientInfo(cardNO);
            //    if (tempP == null)
            //    {
            //        MessageBox.Show("查询患者信息出错！" + radtIntegrate.Err);
            //        return -1;
            //    }
            //    if (string.IsNullOrEmpty(tempP.PID.CardNO))
            //    {
            //        this.txtClinicNO.Text = patient.PID.CardNO;
            //    }
            //    else if (tempP.Name != this.txtName.Text || tempP.Sex.ID.ToString() != this.cmbSex.Tag.ToString())
            //    {
            //        txtClinicNO.Text = patient.PID.CardNO;
            //    }
            //}
            #endregion
            if (patient.InTimes == 0) patient.InTimes = 1;//如果第一次输入则赋值为1
            this.mTxtIntimes.Text = patient.InTimes.ToString();
            this.patientInfomation.User03 = patient.User03;

            return 1;
        }

        /// <summary>
        /// 初始化控件,等信息
        /// </summary>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int Init() 
        {

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在初始化窗口，请稍候^^"));
            Application.DoEvents();

            try
            {
                #region 担保 luzhp@neusoft.com
                this.cmbSuretyType.AddItems(Neusoft.HISFC.Models.Fee.SuretyTypeEnumService.List());
                this.cmbSuretyPerson.AddItems(managerIntegrate.QueryEmployeeAll());
                #endregion
                //初始化科室列表
                this.cmbDept.AddItems(managerIntegrate.QueryDeptmentsInHos(true));

                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
                this.cmbSex.Text = "男";

                //民族
                this.cmbNation.AddItems(managerIntegrate.GetConstantList(EnumConstant.NATION));
                this.cmbNation.Text = "汉族";

                //婚姻状态
                this.cmbMarry.AddItems(Neusoft.HISFC.Models.RADT.MaritalStatusEnumService.List());

                //国家
                this.cmbCountry.AddItems(managerIntegrate.GetConstantList(EnumConstant.COUNTRY));
                this.cmbCountry.Text = "中国";

                //职业信息
                this.cmbProfession.AddItems(managerIntegrate.GetConstantList(EnumConstant.PROFESSION));

                //联系人信息
                this.cmbRelation.AddItems(managerIntegrate.GetConstantList(EnumConstant.RELATIVE));

                //联系人地址信息
                this.cmbLinkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //家庭住址信息
                this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //工作单位
                this.cmbWorkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //出生地信息
                this.cmbBirthArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.DIST));

                //病人来源信息
                this.cmbInSource.AddItems(managerIntegrate.GetConstantList(EnumConstant.INSOURCE));
                this.cmbInSource.SelectedIndex = 0;

                //入院途径信息
                this.cmbApproach.AddItems(managerIntegrate.GetConstantList(EnumConstant.INAVENUE));
                this.cmbApproach.SelectedIndex = 0;

                //入院情况信息
                this.cmbCircs.AddItems(managerIntegrate.GetConstantList(EnumConstant.INCIRCS));
                this.cmbCircs.SelectedIndex = 0;

                //医生信息
                this.cmbDoctor.AddItems(managerIntegrate.QueryEmployee(EnumEmployeeType.D));

                //住院次数
                this.mTxtIntimes.Text = "1";

                //支付方式
                this.cmbPayMode.Tag = "CA";

                //{0374EA05-782E-4609-9CDC-03236AB97906}
                this.cmbTransType1.Tag = "CA";

                //床位间隔
                this.txtBedInterval.Text = "1";

                //入院日期
                this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期

                //生日
                this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();//出生日期

                //地区
                this.cmbArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //合同单位
                this.cmbPact.AddItems(this.pactManager.QueryPactUnitAll());
                //if (this.默认合同单位 != string.Empty)//{205C0764-F871-440e-8E77-79A9298E5A0D}
                //{
                //    this.cmbPact.Text = this.默认合同单位;
                //}
                //else
                //{
                //    this.cmbPact.Text = "现金";
                //}

                //{A2B27285-0646-4f2a-B5D6-99ACC5430902}
                this.cmbPact.Text =this.pactName;

                //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
                this.cmbNurseCell.AddItems(this.managerIntegrate.GetDeptmentIn(EnumDepartmentType.N));
                //验证扩展有效性判断接口
                if (this.registerExtend != null)
                {
                    if (this.registerExtend.InitExtendInfomation(ref this.errText) == -1)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show(Language.Msg(this.errText));

                        return -1;
                    }
                }
                //判断是否包含接诊流程
                //string instateStr = this.ctlMgr.QueryControlerInfo("100017");
                //if (instateStr != string.Empty)
                //{
                this.IsContainsInstate = this.isSelectBed;
                if (this.IsContainsInstate)
                {
                    this.lblBedInterval.ForeColor = this.MustInputColor;
                }
                //}

                foreach (Control c in this.plInfomation.Controls) 
                {
                    if (c is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
                    {
                        ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)c).Enter += new EventHandler(ucRegister_Enter);
                    }
                    else 
                    {
                        c.Enter += new EventHandler(c_Enter);
                    }
                }
            }
            catch (Exception e) 
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);
                
                return -1;
            }
            #region 病案打印 {1336CBD1-EF5A-430c-9965-B9BC72823593}改用接口配置
            //object[] o = new object[] { };

            //try
            //{

            //    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            //    System.Runtime.Remoting.ObjectHandle objHande = System.Activator.CreateInstance("HISFC.Components.HealthRecord", "Neusoft.HISFC.Components.HealthRecord.ucLCCasePrint", false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

            //    object oLabel = objHande.Unwrap();

            //    this.healthPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface;
            //}
            //catch (System.TypeLoadException ex)
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //    MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));
            //    return -1;
            //}

            this.healthPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface)) as Neusoft.HISFC.BizProcess.Interface.HealthRecord.HealthRecordInterface;
            #endregion

            this.RefreshPatientLists();

            this.cmbUnit.IsFlat = true;
            this.cmbUnit.Text = "岁";
            //{0374EA05-782E-4609-9CDC-03236AB97906}
            this.InitInterface();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //{7C19D381-3836-4a3f-B719-799877EB42B7} 当窗体获取焦点时，将焦点转移到住院号20101101 席宗飞
            Form f = this.FindForm();
            f.Activated += new EventHandler(f_Activated);
            return 1;
        }

        void f_Activated(object sender, EventArgs e)
        {
            this.cmbPact.Text = "自费";
            this.ActiveControl = this.txtInpatientNO;
            this.txtInpatientNO.Focus();
            //throw new NotImplementedException();
        }

        void c_Enter(object sender, EventArgs e)
        {
            if (sender == this.txtInpatientNO)
            {
                return;
            }
            this.spPatientInfo.Visible = true;
            this.spConst.Visible = false;
            this.spPatientInfo.BringToFront();
            //患者姓名、联系人需要切换到中文输入法
            if (sender == this.txtName || sender == txtLinkMan || sender == txtDiagnose || sender == cmbWorkAddress 
                || sender == cmbHomeAddress || sender == cmbLinkAddress)
            {
                InputLanguage.CurrentInputLanguage = this.CHInput;
            }
            else
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            }
            if (sender == this.mTxtPrepay)
            {
                this.mTxtPrepay.SelectAll();
            }
            
        }

        void ucRegister_Enter(object sender, EventArgs e)
        {
            if (sender == null) 
            {
                return;
            }

            this.spPatientInfo.Visible = false;
            this.spConst.Visible = true;
            this.spConst.BringToFront();

            ArrayList constantList = ((Neusoft.FrameWork.WinForms.Controls.NeuComboBox)sender).alItems;

            this.DealConstantList(constantList);
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;

            if (sender == this.cmbHomeAddress&&this.homeAddressChangeLanguage)
            {
                InputLanguage.CurrentInputLanguage = this.CHInput;
            }
         
            if (sender == cmbLinkAddress&&this.linkManAddressChangeLanguage)
            {
                InputLanguage.CurrentInputLanguage = this.CHInput;
            }
    
            if (workAddressChangeLanguage && sender == this.cmbWorkAddress)
            {
                InputLanguage.CurrentInputLanguage = this.CHInput;
            } 
 
        }

        private void DealConstantList(ArrayList consList) 
        {
            if (consList == null || consList.Count <= 0) 
            {
                return;
            }

            this.spConst_Sheet1.RowCount = 0;
            this.spConst_Sheet1.RowCount = (consList.Count / 3) + (consList.Count % 3 == 0 ? 0 : 1);

            int row = 0;
            int col = 0;

            foreach (Neusoft.FrameWork.Models.NeuObject obj in consList)
            {
                if (col >= 5)
                {
                    col = 0;
                    row++;
                }

                this.spConst_Sheet1.SetValue(row, col, obj.ID);
                this.spConst_Sheet1.SetValue(row, col + 1, obj.Name);

                col = col + 2;
            }
            
            this.spPatientInfo.Visible = false;
            this.spConst.Visible = true;


        }

        /// <summary>
        /// 通过合同单位编码,获得结算类别实体
        /// </summary>
        /// <param name="pactID">合同单位编码</param>
        /// <returns>成功: 结算类别实体 失败: null</returns>
        private PayKind GetPayKindFromPactID(string pactID) 
        {
            Neusoft.HISFC.Models.Base.PactInfo pact = this.pactManager.GetPactUnitInfoByPactCode(pactID);
            if (pact == null) 
            {
                MessageBox.Show(Language.Msg("获得合同单位详细出错!"));

                return null;
            }

            return pact.PayKind;
        }

        /// <summary>
        /// 验证输入的信息是否合法
        /// </summary>
        /// <returns>成功: true 失败: null</returns>
        private bool IsInputValid() 
        {
            //判断必须输入的控件是否都已经输入信息
            foreach (DictionaryEntry d in this.mustInputHashTable) 
            {
                if (d.Value is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
                {
                    if (((Control)d.Value).Tag == null || ((Control)d.Value).Tag.ToString() == string.Empty || ((Control)d.Value).Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(((Control)d.Key).Text.Replace(':', ' ') + Language.Msg("必须输入信息!"));
                        ((Control)d.Value).Focus();

                        return false;
                    }
                }
                else
                {
                    if (((Control)d.Value).Text == string.Empty)
                    {
                        MessageBox.Show(((Control)d.Key).Text.Replace(':', ' ') + Language.Msg("必须输入信息!"));
                        ((Control)d.Value).Focus();

                        return false;
                    }
                }
            }

            if (this.txtInpatientNO.Tag == null || this.txtInpatientNO.Tag.ToString().Trim() == "" || this.txtInpatientNO.Text.Length != 10)//{689A09A7-3A14-40a3-895D-04F668D69283}
            {
                MessageBox.Show(Language.Msg("请回车确认住院号"));
                this.txtInpatientNO.Focus();

                return false;
            }

            //门诊号长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtClinicNO.Text, 10))
            {
                MessageBox.Show(Language.Msg("门诊号过长,请重新输入!"));
                this.txtClinicNO.Focus();

                return false;
            }
            //电脑号
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtComputerNO.Text, 20))
            {
                MessageBox.Show(Language.Msg("电脑号过长,请重新输入!"));
                this.txtComputerNO.Focus();

                return false;
            }

            

            //医疗证号长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtMCardNO.Text, 18))
            {
                MessageBox.Show(Language.Msg("医疗证号过长,请重新输入!"));
                this.txtClinicNO.Focus();

                return false;
            }

            try
            {
                Int64 inpatientNO = Convert.ToInt64(this.txtInpatientNO.Text);

                if (inpatientNO > 9000000000)
                {
                    MessageBox.Show(Language.Msg("您输入的住院号过大"));
                    this.txtInpatientNO.Focus();

                    return false;
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(Language.Msg("您输入的住院号中含有非数字字符，请更改") + e.Message);
                this.txtInpatientNO.Focus();

                return false;
            }

            if (this.txtClinicNO.Text.Substring(0, 1) == "T" && this.txtClinicNO.Text != "T" + this.txtInpatientNO.Text.Substring(1, 9))
            {
                MessageBox.Show(Language.Msg("自动生成的卡号不允许修改,请重新输入!"));
                this.txtClinicNO.Focus();

                return false;
            }

            //科室
            if (this.cmbDept.Tag == null || this.cmbDept.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("科室不能为空，请重新输入！"));
                return false;
            }

            //科室长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbDept.Text, 25))
            {
                MessageBox.Show(Language.Msg("科室输入过长,请重新输入!"));
                this.cmbDept.Focus();

                return false;
            }

            if(this.IsContainsInstate)
            {
                if (this.cmbBedNO.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show(Language.Msg("病床不能为空，请选择病床！"));
                    this.cmbBedNO.Focus();
                    return false;
                }
            }

            //入院来源
            if (this.cmbInSource.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("入院来源不能为空，请重新输入");
                return false;
            }

            //结算方式
            if (this.cmbPact.Tag.ToString() == null||this.cmbPact.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("结算方式不能为空，请重新输入");
                return false;
            }

            if (this.dtpInTime.Value > this.inpatientManager.GetDateTimeFromSysDateTime()) 
            {
                MessageBox.Show(Language.Msg("入院日期大于当前日期,请重新输入!"));
                this.dtpInTime.Focus();

                return false;
            }

            if (this.dtpBirthDay.Value > this.inpatientManager.GetDateTimeFromSysDateTime())
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();

                return false;
            }

            //判断字符超长姓名
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text, 20))
            {
                MessageBox.Show(Language.Msg("姓名录入超长！"));
                this.txtName.Focus();
                return false;
            }

            //判断字符超长籍贯
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbBirthArea.Text, 50))
            {
                MessageBox.Show(Language.Msg("籍贯录入超长！"));
                this.cmbBirthArea.Focus();
                return false;
            }

            //判断字符超长联系人
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkMan.Text, 12))
            {
                MessageBox.Show(Language.Msg("联系人录入超长！"));
                this.txtLinkMan.Focus();
                return false;
            }

            //判断字符超长工作单位
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.cmbWorkAddress.Text, 50))
            {
                MessageBox.Show(Language.Msg("工作单位录入超长！"));
                this.cmbWorkAddress.Focus();
                return false;
            }

            //判断字符超长联系人电话
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtLinkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("联系人电话录入超长！"));
                this.txtLinkPhone.Focus();

                return false;
            }
            //家庭电话
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("家庭电话录入超长！"));
                this.txtHomePhone.Focus();

                return false;
            }
            //单位电话
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtWorkPhone.Text, 30))
            {
                MessageBox.Show(Language.Msg("单位电话录入超长！"));
                this.txtWorkPhone.Focus();

                return false;
            }

            //诊断
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtDiagnose.Text, 50))
            {
                MessageBox.Show(Language.Msg("门诊诊断录入超长！"));
                this.txtDiagnose.Focus();

                return false;
            }

            //身份证
            //{EF38942A-1959-4edd-AF6A-3E3854E6AC88} 住院登记是否校验身份证
            if (this.isCheckIdCardNo)
            {
                if (this.txtIDNO.Text.Trim() != string.Empty)
                {
                    string errText = string.Empty;
                    if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(this.txtIDNO.Text, ref errText) == -1)
                    {
                        MessageBox.Show(errText);
                        return false;
                    }
                }
            }
            if (Convert.ToInt32(this.txtBedInterval.Text) == 0)
            {
                MessageBox.Show(Language.Msg("床费间隔必须是大于零的数,请重新输入"));
                txtBedInterval.Focus();
                txtBedInterval.SelectAll();
                return false;
            }
            if (this.cmbSex.Text.Trim() == string.Empty) 
            {
                MessageBox.Show("请输入患者性别!");
                this.cmbSex.Focus();

                return false;
            }
           

            //if (Convert.ToInt32(this.mTxtIntimes.Text) == 0)
            //{
            //    MessageBox.Show(Language.Msg("住院次数必须是大于零的数，请重新输入！"));
            //    this.mTxtIntimes.Focus();
            //    this.mTxtIntimes.SelectAll();
            //    return false;
            //}
            //if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtIDNO.Text, 18))
            //{
            //    MessageBox.Show(Language.Msg("身份证号码录入超过18位！"));
            //    this.txtIDNO.Focus();

            //    return false;
            //}

            //验证扩展有效性判断接口
            if (this.registerExtend != null) 
            {
                Control errControl = new Control();

                if (!this.registerExtend.IsInputValid(errControl, ref this.errText)) 
                {
                    MessageBox.Show(Language.Msg(this.errText));
                    errControl.Focus();

                    return false;
                }
            }

            //校验身份证号和生日 {9B24289B-D017-4356-8A25-B0F76EB79D15}
           
            int returnValue = this.ProcessIDENNO(this.txtIDNO.Text.Trim(), EnumCheckIDNOType.Saveing);
            
            if (returnValue < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获得控件输入的信息,合成患者基本信息实体
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns> 成功: 1 失败 : -1</returns>
        private int GetPatientInfomation(PatientInfo patient) 
        {
            if (patient == null) 
            {
                MessageBox.Show(Language.Msg("患者信息实体为空!"));

                return -1;
            }

            patient.PID.PatientNO = this.txtInpatientNO.Text; //住院号
            patient.PID.CardNO = this.txtClinicNO.Text;//门诊卡号
            patient.ID = this.txtInpatientNO.Tag.ToString();//住院流水号
            patient.SSN = this.txtMCardNO.Text;//医保号
            patient.ProCreateNO = this.txtComputerNO.Text;//生育保险电脑号
            if (this.isCanModifyInTime == true)
            {
                patient.PVisit.InTime = this.dtpInTime.Value;//入院日期
            }
            else
            {
                patient.PVisit.InTime = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期
            }
            patient.Pact.ID = this.cmbPact.Tag.ToString();//合同单位编码
            patient.Pact.Name = this.cmbPact.Text;//合同单位名称
            patient.Pact.PayKind = this.GetPayKindFromPactID(patient.Pact.ID);//结算类别
            //暂时屏蔽掉 接诊时候给床位
            //patient.PVisit.PatientLocation.Bed.ID = this.txtBedNo.Text;//病床
            patient.Name = this.txtName.Text;//名字
            patient.Sex.ID = this.cmbSex.Tag.ToString();//性别
            patient.Nationality.ID = this.cmbNation.Tag.ToString();//民族
            patient.Birthday = this.dtpBirthDay.Value;//生日
            patient.PVisit.PatientLocation.Dept.ID = this.cmbDept.Tag.ToString();//科室编码
            try
            {
                patient.PVisit.PatientLocation.Dept.Name = ((Department)this.cmbDept.SelectedItem).Memo;//科室名称
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("住院科室输入不正确，请重新输入！")+ex.Message);
                return -1;
            }
            patient.CompanyName = this.cmbWorkAddress.Text;//工作单位
            patient.MaritalStatus.ID = this.cmbMarry.Tag.ToString();//婚姻状况
            patient.DIST = this.cmbBirthArea.Text;//籍贯
            patient.Country.ID = this.cmbCountry.Tag.ToString();//国籍ID
            patient.Country.Name = this.cmbCountry.Text;//国籍
            patient.Profession.ID = this.cmbProfession.Tag.ToString();//职位ID
            patient.Profession.Name = this.cmbProfession.Text;//职位名称
            patient.Kin.Name = this.txtLinkMan.Text;//联系人姓名
            patient.Kin.RelationPhone = this.txtLinkPhone.Text;//联系人备注-电话
            patient.Kin.Relation.ID = this.cmbRelation.Tag.ToString();//与患者关系编码
            patient.Kin.Relation.Name = this.cmbRelation.Text;//与患者关系
            patient.Kin.RelationAddress = this.cmbLinkAddress.Text;//联系人地址
            patient.AddressHome = this.cmbHomeAddress.Text;//家庭地址
            patient.PhoneHome = this.txtHomePhone.Text;//患者电话
            #region {9FF4736C-5D48-48a3-95A0-0E864346DB9D}
            patient.PhoneBusiness = this.txtWorkPhone.Text;//单位电话 
            #endregion
            patient.IDCard = this.txtIDNO.Text;//身份证
            patient.PVisit.AdmitSource.ID = this.cmbApproach.Tag.ToString();//入院途径
            patient.PVisit.AdmitSource.Name = this.cmbApproach.Text;//入院途径
            patient.PVisit.InSource.ID = this.cmbInSource.Tag.ToString();//入院来源
            patient.PVisit.InSource.Name = this.cmbInSource.Text;//入院来源
            patient.PVisit.Circs.ID = this.cmbCircs.Tag.ToString();//入院情况
            patient.PVisit.Circs.Name = this.cmbCircs.Text;//入院情况
            patient.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString();//收住医师

            #region addby xuewj 2010-3-15 {010BAFC3-96E2-4acc-AAD4-55320B9C2229}
            //addby zl 2010-8-27{28D36E56-E893-4482-B71C-BAB884E3591C} 此处屏蔽了，接诊时就读不出来了，先打开。
            //hl7用 暂时屏蔽 待改
            patient.PVisit.AdmittingDoctor.ID = this.cmbDoctor.Tag.ToString();
            patient.PVisit.AdmittingDoctor.Name = this.cmbDoctor.Text;
            patient.PVisit.AttendingDoctor.ID = this.cmbDoctor.Tag.ToString();
            patient.PVisit.AttendingDoctor.Name = this.cmbDoctor.Text;
            patient.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString();//收住医师

            #endregion

            try
            {
                patient.FT.FixFeeInterval = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtBedInterval.Text);//床费间隔
            }
            catch
            {
                MessageBox.Show("床费间隔数字输入不正确，请重新输入");
                return -1;
            }
            patient.ClinicDiagnose = this.txtDiagnose.Text;//门诊诊断
            patient.AreaCode = this.cmbArea.Tag.ToString();//地区
            
            patient.FT.BloodLateFeeCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.mtxtBloodFee.Text);//血滞纳金
            //路志鹏 修改住院次数 目的：本次住院登记的住院次数应该是上一次住院次数加1
            patient.InTimes = NConvert.ToInt32(this.mTxtIntimes.Text);//住院次数？初次就增加啦
            patient.FT.LeftCost = NConvert.ToDecimal(this.mTxtPrepay.Text);//预交金
            patient.FT.PrepayCost = NConvert.ToDecimal(this.mTxtPrepay.Text);//预交金

            #region 担保
            patient.Surety.Mark = this.txtMark.Text;//担保备注
            //担保人
            patient.Surety.SuretyPerson.ID = this.cmbSuretyPerson.Tag.ToString();
            patient.Surety.SuretyPerson.Name = this.cmbSuretyPerson.Text.ToString();
            //担保金额
            patient.Surety.SuretyCost = NConvert.ToDecimal(this.txtSuretyCost.Text);
            //担保类型
            patient.Surety.SuretyType.ID = this.cmbSuretyType.Tag.ToString();
            patient.Surety.SuretyType.Name = this.cmbSuretyType.Text.ToString();
            //{0374EA05-782E-4609-9CDC-03236AB97906}
            patient.Surety.Bank = this.cmbTransType1.bank.Clone();
            patient.Surety.InvoiceNO = this.inpatientManager.GetSequence("Fee.Inpatient.GetSeq.InvoiceNO");
            patient.Surety.State = "1";

            //操作员
            patient.Surety.Oper.ID = inpatientManager.Operator.ID;
            #endregion

            //采集扩展录入的信息
            if (this.registerExtend != null) 
            {
                if (this.registerExtend.GetExtentPatientInfomation(patient, ref this.errText) == -1) 
                {
                    MessageBox.Show(Language.Msg(this.errText));

                    return -1;
                }
            }
            //加密
            patient.IsEncrypt = this.chbencrypt.Checked;

            if (patient.IsEncrypt)
            {
            
                patient.NormalName = Neusoft.FrameWork.WinForms.Classes.Function.Encrypt3DES(patient.Name);
                patient.Name = "******";
            }

            patient.PVisit.PatientLocation.NurseCell.ID = this.cmbNurseCell.Tag.ToString();//科室编码
            try
            {
                patient.PVisit.PatientLocation.NurseCell.Name = ((Department)this.cmbNurseCell.SelectedItem).Memo;//科室名称
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("住院病区输入不正确，请重新输入！") + ex.Message);
                return -1;
            }
            #region 包含接诊流程
            if (this.IsContainsInstate)
            {
                Neusoft.HISFC.Models.Base.Bed bedObj = this.cmbBedNO.SelectedItem as Neusoft.HISFC.Models.Base.Bed;
                patient.PVisit.PatientLocation.NurseCell = bedObj.NurseStation;
                //Neusoft.HISFC.Models.Base.Department deptObj= managerIntegrate.GetDepartment(bedObj.NurseStation.ID);
                //if (deptObj != null)
                //{
                //    patient.PVisit.PatientLocation.NurseCell.Name = deptObj.Name;
                //}
                patient.PVisit.PatientLocation.Bed = bedObj;
                patient.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.I;
            }
            else
            {
                patient.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.R;
            }
            #endregion
            return 1;
        }

        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
         /// <param name="patient">患者基本信息实体</param>
        private void SetPatientInfomation(PatientInfo patient)
        {
            this.txtInpatientNO.Text = patient.PID.PatientNO;//住院号　
            this.txtClinicNO.Text = patient.PID.CardNO;//门诊卡号
            this.txtInpatientNO.Tag = patient.ID;//住院流水号
            this.txtMCardNO.Text = patient.SSN;//医保号
            this.cmbBedNO.Text = patient.PVisit.PatientLocation.Bed.ID;//病床
            this.chbencrypt.Checked = patient.IsEncrypt;
            if (patient.IsEncrypt)
            {
                patient.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patient.NormalName);
            }
            this.txtName.Text = patient.Name;//患者姓名
            
            this.cmbWorkAddress.Text = patient.CompanyName;//公司名称
            this.txtHomePhone.Text = patient.PhoneHome;//患者电话
            this.txtWorkPhone.Text = patient.PhoneBusiness;//单位电话
            //入院途径
            if (patient.PVisit.AdmitSource.ID == string.Empty)
            {
                if (this.cmbApproach.Items.Count > 0)
                {
                    this.cmbApproach.SelectedIndex = 0;
                }
            }
            else
            {
                this.cmbApproach.Tag = patient.PVisit.AdmitSource.ID;
            }
            //入院来源
            if (patient.PVisit.InSource.ID == string.Empty)
            {
                this.cmbInSource.Tag = "1";
            }
            else
            {
                this.cmbInSource.Tag = patient.PVisit.InSource.ID;
            }
            //入院情况
            if (patient.PVisit.Circs.ID == "")
            {
                if (this.cmbCircs.Items.Count > 0)
                {
                    this.cmbCircs.SelectedIndex = 0;
                }
            }
            else
            {
                this.cmbCircs.Tag = patient.PVisit.Circs.ID;
            }
            this.cmbCountry.Tag = patient.Country.ID;//国籍
            this.cmbCountry.Focus();
            this.cmbHomeAddress.Text = patient.AddressHome;//家庭地址
            this.cmbPact.Tag = patient.Pact.ID;//合同单位
            this.cmbBirthArea.Tag = patient.DIST;//出生地／籍贯
            this.cmbMarry.Tag = patient.MaritalStatus.ID;//婚姻状况
            this.cmbSex.Tag = patient.Sex.ID;//性别  
            if (patient.Nationality.ID != string.Empty && patient.Nationality.ID != null)
            {
                this.cmbNation.Tag = patient.Nationality.ID;
            }
            this.cmbProfession.Text = patient.Profession.Name;//职位
            this.cmbProfession.Tag = patient.Profession.ID;//职位
            #region {9FF4736C-5D48-48a3-95A0-0E864346DB9D}
            this.mtxtBloodFee.Text = patient.FT.BloodLateFeeCost.ToString(); 
            #endregion
            if (patient.Birthday == DateTime.MinValue)
            {
                this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime().Date;
            }
            else
            {
                this.dtpBirthDay.Value = patient.Birthday;//Edit By Maokb
            }
            //this.txtAge.Text =this.inpatientManager.GetAge(this.dtpBirthDay.Value);//年龄  Edit By maokb
            //{87EB6328-0634-44dc-A597-DEC7B08F9AA5}更改取年龄的函数，防止年龄里出现汉字
            this.setAge(this.dtpBirthDay.Value);
            if (patient.PVisit.InTime == DateTime.MinValue)
            {
                this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime().Date;
            }
            else
            {
                this.dtpInTime.Value = patient.PVisit.InTime;//this.inpatientManager.GetDateTimeFromSysDateTime();//住院日期
            }
            this.txtLinkMan.Text = patient.Kin.ID;//联系人姓名
            this.txtLinkPhone.Text = patient.Kin.RelationPhone;//联系人备注-电话／地址
            this.cmbRelation.Text = patient.Kin.Relation.Name; //与患者关系
            this.cmbRelation.Tag = patient.Kin.Relation.ID;//与患者关系
            this.cmbDept.Tag = patient.PVisit.PatientLocation.Dept.ID;//科室
            this.mTxtPrepay.Text = patient.FT.PrepayCost.ToString();//预交金
            this.txtIDNO.Text = patient.IDCard;//身份证号码

            if (patient.InTimes == 0) 
            {
                patient.InTimes = 1;
            }

            this.mTxtIntimes.Text = patient.InTimes.ToString();// 住院次数
            this.cmbLinkAddress.Text = patient.Kin.RelationAddress; //联系人地址
            this.txtDiagnose.Text = patient.ClinicDiagnose; //门诊诊断
            this.cmbArea.Tag = patient.AreaCode; //地区
            
            this.cmbDoctor.Tag = patient.PVisit.AdmittingDoctor.ID;
            try
            {
                Neusoft.HISFC.Models.Base.Employee myEmpInfo = this.managerIntegrate.GetEmployeeInfo(patient.PVisit.AdmittingDoctor.ID);
                this.cmbDoctor.Text = myEmpInfo.Name; //收住医师
            }
            catch { }
            //this.cmbMarry.Text = patient.MaritalStatus.ID.ToString(); //婚姻状况
            this.txtComputerNO.Text = patient.ProCreateNO;//生育保险电脑号
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            this.cmbNurseCell.Tag = patient.PVisit.PatientLocation.NurseCell.ID;
        }

        /// <summary>
        /// 处理预交金
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功 1 失败: -1</returns>
        private int DealPreapy(Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            string invoiceNO = null;//发票号

            //如果没有输入预交金,那么直接返回
            if (this.patientInfomation.FT.PrepayCost <= 0)
            {
                return 1;
            }
            //xizf 限额判断20110111
            if (this.patientInfomation.FT.PrepayCost >=100000m) {
                MessageBox.Show("预交金不能大于100000,请重新输入");
                return -1;
            }

            prepay.FT.PrepayCost = this.patientInfomation.FT.PrepayCost;
            prepay.PayType.ID = this.cmbPayMode.Tag.ToString();
            prepay.PayType.Name = this.cmbPayMode.Text;
            prepay.PrepayState = "0";
            prepay.BalanceState = "0";
            prepay.BalanceNO = 0;
            prepay.TransferPrepayState = "0";
            prepay.PrepayOper.OperTime = this.inpatientManager.GetDateTimeFromSysDateTime();
            prepay.PrepayOper.ID = this.inpatientManager.Operator.ID;
            //{021A7D2F-2C91-4144-B7A9-E26AE53FA985}
            //invoiceNO = this.feeIntegrate.GetNewInvoiceNO(EnumInvoiceType.P);
            invoiceNO = this.feeIntegrate.GetNewInvoiceNO("P");

            if (invoiceNO == null || invoiceNO == string.Empty)
            {
                MessageBox.Show("获得预交金票据号失败!" + this.feeIntegrate.Err);

                return -1;
            }

            prepay.RecipeNO = invoiceNO;

            if (this.inpatientManager.PrepayManager(this.patientInfomation, prepay) == -1)
            {
                MessageBox.Show("插入预交金失败" + this.inpatientManager.Err);

                return -1;
            }

            return 1;
        }

        //打印预交金
        protected virtual void PrintPrepayInvoice(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay, bool isReturn)
        {
            if (patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.prepayPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint;
            //regprint.SetPrintValue(regObj,regmr);
            //this.prepayPrint = new ucPrepayPrint();
            if (this.prepayPrint == null)
            {
                //this.prepayPrint = new ucPrepayPrint();
            }


            this.prepayPrint.SetValue(patientInfo, prepay);
            this.prepayPrint.Print();


        }

        /// <summary>
        /// 插入住院主表信息
        /// </summary>
        /// <param name="t">数据库事务</param>
        /// <returns>成功 1 失败: -1</returns>
        private int InsertMainInfo()
        {
            #region addby xuewj {010BAFC3-96E2-4acc-AAD4-55320B9C2229} adt-Patient Registration

            if (this.adt == null)
            {
                this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
            }
            if (this.adt != null)
            {
                if (this.hl7 == "A01")
                    adt.RegInpatient(this.patientInfomation.Clone());
                else
                    adt.OutpatientToInpatient(this.patientInfomation.Clone());
            }
            #endregion

            int returnValue = 0;//插入函数的返回值

            returnValue = this.radtIntegrate.RegisterPatient(this.patientInfomation);

            if (returnValue == -1)
            {
                //主键重复
                //判断并发--防止住院号重复引起主键重复
                if (this.radtIntegrate.DBErrCode == 1)
                {
                    if (this.isAutoInpatientNO)
                    {

                        int tryCount = 0;//尝试获得住院号的次数
                    SetNewNo:

                        tryCount++;

                        //尝试次数大于10次,那么放弃这次登记
                        if (tryCount >= 10)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg("获取住院号出错！请联系信息科！") + this.patientInfomation.PID.PatientNO);

                            return -1;
                        }

                        if (this.patientInfomation.PatientNOType == EnumPatientNOType.Temp)
                        {
                            //this.AutoTempPatientNo();
                        }
                        else
                        {
                            this.GetAutoInpatientNO(string.Empty);
                            //{74CD8A32-2A99-4b5f-BD6D-4FFAC604284C} 提示住院号变化
                            MessageBox.Show("选定的住院号: " + this.patientInfomation.PID.PatientNO + "已经占用,新分配的住院号为: " + this.txtInpatientNO.Text.Trim());
                            //{74CD8A32-2A99-4b5f-BD6D-4FFAC604284C} 结束
                        }

                        //重新赋值住院号
                        ResetPatientNO();

                        if (this.radtIntegrate.RegisterPatient(this.patientInfomation) <= 0)
                        {
                            if (this.radtIntegrate.DBErrCode == 1)
                            {
                                goto SetNewNo;
                            }
                            else
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(this.radtIntegrate.Err);

                                return -1;
                            }
                        }

                    }
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.radtIntegrate.Err);

                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 重新给住院号赋值
        /// </summary>
        private void ResetPatientNO()
        {
            this.patientInfomation.PID.PatientNO = this.txtInpatientNO.Text.Trim();
            this.patientInfomation.ID = this.txtInpatientNO.Tag.ToString();
            this.patientInfomation.PID.CardNO = this.txtClinicNO.Text;
        }

        /// <summary>
        /// 重新获得住院号
        /// </summary>
        private int ReGetPatientNO()
        {
            if (this.patientInfomation.PatientNOType == EnumPatientNOType.Temp)
            {
                //this.AutoTempPatientNo();
                //this.Patient.Patient.PID.PatientNo = this.txtPatientNo.Text.Trim();
                //this.Patient.ID = this.txtPatientNo.Tag.ToString();
                //this.Patient.Patient.PID.CardNo = this.txtCard.Text;
            }
            if (this.patientInfomation.PatientNOType == EnumPatientNOType.First)
            {
                if (this.GetAutoInpatientNO(string.Empty) == 1)
                {
                    return -1;
                }

                this.ResetPatientNO();
            }

            return 1;
        }

        /// <summary>
        /// 刷新显示患者列表
        /// </summary>
        private void RefreshPatientLists()
        {
            DateTime beginTime = inpatientManager.GetDateTimeFromSysDateTime();
            
            //取当天时间的0点
            beginTime = new DateTime(beginTime.Year, beginTime.Month, beginTime.Day);

            Neusoft.HISFC.BizLogic.RADT.InPatient inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();

            ArrayList patients = inpatient.QueryPatient(beginTime.AddDays( -regDay), beginTime.AddDays(1), EnumInState.R);
            //ArrayList patients = radtIntegrate.QueryPatientsByDateTime(beginTime, beginTime.AddDays(1));

            if (patients == null) 
            {
                MessageBox.Show(Language.Msg("刷新已登记患者信息出错!") + radtIntegrate.Err);

                return;
            }

            this.spPatientInfo_Sheet1.RowCount = 0;
            this.spPatientInfo_Sheet1.RowCount = patients.Count;

            PatientInfo patient = null;//当前患者信息

            for (int i = 0; i < patients.Count; i++)
            {
                patient = patients[i] as PatientInfo;

                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.PatientNO, patient.PID.PatientNO);//住院号
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.Name, patient.Name);//姓名
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.Sex, patient.Sex.Name);//性别
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.Dept, patient.PVisit.PatientLocation.Dept.Name);
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.IDNO, patient.IDCard);//身份证号
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.HomeAddress, patient.AddressHome);//家庭住址
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.InDate, patient.PVisit.InTime);//入院时间
                this.spPatientInfo_Sheet1.SetValue(i, (int)PatientLists.InState, patient.PVisit.InState.Name);//状态

                this.spPatientInfo_Sheet1.Rows[i].Tag = patient;
            }
        }

        /// <summary>
        /// 获得当前焦点控件
        /// </summary>
        /// <returns>成功: 获得当前焦点得控件, 失败: null</returns>
        private Control GetFocusedControl() 
        {
            Control focusedControl = null;
            
            foreach (Control c in this.plInfomation.Controls) 
            {
                if (c.Focused) 
                {
                    focusedControl = c;
                    break;
                }
            }

            return focusedControl;
        }

        /// <summary>
        /// 下一个必须输入得控件获得焦点
        /// </summary>
        /// <param name="nowControl">当前获得焦点得控件</param>
        private void SetNextControlFocus(Control nowControl) 
        {
            if (nowControl == null) 
            {
                return;
            }

            Control focusedControl = this.GetNextControl(nowControl, false);

            if (focusedControl == null) 
            {
                return;
            }

            if (!this.mustInputHashTable.ContainsValue(nowControl)) 
            {
                this.SetNextControlFocus(focusedControl);
            }
            else
            {
                focusedControl.Focus();
            }
        }

        /// <summary>
        /// 下一个必须输入得控件获得焦点
        /// </summary>
        private void SetNextControlFocus() 
        {
            this.SetNextControlFocus(GetFocusedControl());
        }

        /// <summary>
        /// 处理输入住院号
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int DealInputInpatientNO() 
        {
            this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期
            //如果没有录入信息,那么停止
            if (this.txtInpatientNO.Text.Trim() == string.Empty)
            {
                return -1;
            }
            if (this.txtInpatientNO.Text.Trim().Length != NoLength) {
                return -1;
            }
            this.txtInpatientNO.Text = Neusoft.FrameWork.Public.String.FillString(this.txtInpatientNO.Text);

            if (this.GetAutoInpatientNO(this.txtInpatientNO.Text) == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 处理控件回车事件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int DealControlEnterEvents() 
        {
            if (this.txtInpatientNO.Focused) 
            {
                return this.DealInputInpatientNO();
            }

            if (this.txtClinicNO.Focused) 
            {
                string cardNO = Neusoft.FrameWork.Public.String.FillString(txtClinicNO.Text.Trim());
                if (cardNO == string.Empty) 
                {
                    return -1;
                }

                return this.GetPatientFromClinic(cardNO);
            }
            //{538F0253-AB89-4ce3-8C2A-7E8F5C6EDBF5}增加年龄生日互算
            if (this.dtpBirthDay.Focused) 
            {
                DateTime current = this.inpatientManager.GetDateTimeFromSysDateTime().Date;

                if (this.dtpBirthDay.Value.Date > current)
                {
                    MessageBox.Show("出生日期不能大于当前时间!", "提示");
                    this.dtpBirthDay.Focus();
                    return -1;
                }

                //计算年龄
                if (this.dtpBirthDay.Value.Date != current)
                {
                    this.setAge(this.dtpBirthDay.Value);
                }

                this.cmbWorkAddress.Focus();

                return -1;
            }
            if (this.txtAge.Focused)
            {
                //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
                 if(this.getBirthday()>0)

                 this.cmbUnit.Focus();
               
                return -1;
            }
            if (this.cmbUnit.Focused) 
            {
                this.cmbWorkAddress.Focus();

                return -1;
            }

            if (this.cmbDept.Focused)
            {
                //{1BFFE533-C177-46bf-93C6-093DD7344DAF} wbo 2010-08-19
                //this.cmbNurseCell.Focus();
                this.cmbBedNO.Focus();
                return -1;
            }

            if (this.cmbNurseCell.Focused)
            {
                this.cmbBedNO.Focus();
                return -1;
            }
            //{4B86EBA7-5616-4787-A9F2-CF7EEAA85D92}
            if (this.txtMCardNO.Focused)
            {
                if (this.GetGFPatientInfo() > 0)
                {
                    if (txtInpatientNO.Text.Trim().Length > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        this.txtInpatientNO.Focus();
                        this.txtMCardNO.Enabled = false;
                    }
                    return -1;
                }
            }


            //{538F0253-AB89-4ce3-8C2A-7E8F5C6EDBF5}增加年龄生日互算 结束

            return 1;
        }

        /// <summary>
        /// 获得临时住院流水号
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int AutoTempPatientNO()
		{
            //this.txtInpatientNO.Enabled = false;
            //this.btnAutoInpatientNO.Enabled = false;
			string pNO = string.Empty;

            PatientInfo patient = new PatientInfo();
            if (this.radtIntegrate.CreateAutoInpatientNO(patient) == -1)
            {
                MessageBox.Show(Language.Msg("获得自动生成住院号出错!") + this.radtIntegrate.Err);

                return -1;
            }
            //pNO = this.inpatientManager.GetTempPatientNO(this.autoPatientParms);
            //if(pNO == "000000") 
            //{
            //    pNO = this.autoPatientParms + "000000";				
            //}

            //pNO = (NConvert.ToInt32(pNO) + 1).ToString().PadLeft(10, '0');

            this.txtInpatientNO.Text = patient.PID.PatientNO;
            this.txtInpatientNO.Tag = patient.ID;//"ZY01" + pNO;
            this.txtClinicNO.Text = Neusoft.FrameWork.Public.String.FillString(txtClinicNO.Text.Trim()); 
			this.mTxtIntimes.Text = "1";
			this.patientInfomation.User03 = "TEMP";
			
			return 0; 
		}

        /// <summary>
        /// 通过门诊卡号获得住院号等信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns>成功 1 失败 -1</returns>
        private int GetPatientFromClinic(string cardNO) 
        {
            //获取最大住院号---就是最后一次住院的住院流水号
	            string inpatientNO = string.Empty;

            inpatientNO = this.radtIntegrate.GetMaxPatientNOByCardNO(cardNO);

            //数据库出错!
            if (inpatientNO == null)
            {
                return -2;
            }

            if (inpatientNO.Trim() == string.Empty)
            {
                //没有住院信息，查患者基本信息表
                Neusoft.HISFC.Models.RADT.PatientInfo pInfo = this.radtIntegrate.QueryComPatientInfo(cardNO);
                if (pInfo == null)
                {
                    MessageBox.Show(Language.Msg("获得患者基本信息出错!") + this.radtIntegrate.Err);

                    return -1;
                }

                if (this.isAutoInpatientNO)
                {
                    this.SetPatientInfomation(pInfo);
                    this.AutoTempPatientNO();
                    
                }
                else
                {
                    this.SetPatientInfomation(pInfo);
                }
            }
            else//找到了上次住院信息 
            {
                Neusoft.HISFC.Models.RADT.PatientInfo pInfo = this.radtIntegrate.GetPatientInfomation(inpatientNO);
                //if (pInfo.PVisit.InState.ID.ToString() == "R" || pInfo.PVisit.InState.ID.ToString() == "B" || pInfo.PVisit.InState.ID.ToString() == "P") 
                if (pInfo.PVisit.InState.ID.ToString() == "R" || pInfo.PVisit.InState.ID.ToString() == "B" || pInfo.PVisit.InState.ID.ToString() == "P" || pInfo.PVisit.InState.ID.ToString() == "I") //{EFD5F36A-4179-4413-A4AA-DBB199B2AC49}
                {
                    MessageBox.Show(Language.Msg("此患者在院治疗"));
                    this.txtClinicNO.SelectAll();
                    this.txtClinicNO.Focus();

                    return -1;
                }

                pInfo.InTimes++;
                pInfo.ID = "ZY" + pInfo.InTimes.ToString().PadLeft(2, '0') + pInfo.PID.PatientNO;
                this.txtInpatientNO.Text = pInfo.PID.PatientNO;
                this.txtInpatientNO.Tag = pInfo.ID;
                this.txtClinicNO.Text = pInfo.PID.CardNO;
                pInfo.PVisit.PatientLocation.Bed.ID = string.Empty;
                this.SetPatientInfomation(pInfo);
                this.cmbPact.Focus();
            }

            return 1;
        }

        /// <summary>
        /// {9B24289B-D017-4356-8A25-B0F76EB79D15}
        /// </summary>
        /// <param name="idNO"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private int ProcessIDENNO(string idNO, EnumCheckIDNOType enumType)
        {
            //{EF38942A-1959-4edd-AF6A-3E3854E6AC88} 住院登记是否校验身份证
            if (!this.isCheckIdCardNo)
            {
                return 1;
            }
            string errText = string.Empty;

            if (string.IsNullOrEmpty(idNO)) //为空的不处理
            {
                return 1;
            }

            //校验身份证号


            //{99BDECD8-A6FC-44fc-9AAA-7F0B166BB752}

            //string idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            string idNOTmp = string.Empty;
            if (idNO.Length == 15)
            {
                idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            }
            else
            {
                idNOTmp = idNO;
            }

            //校验身份证号
            int returnValue = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNOTmp, ref errText);



            if (returnValue < 0)
            {
                MessageBox.Show(errText);
                this.txtIDNO.Focus();
                return -1;
            }
            string[] reurnString = errText.Split(',');
            if (enumType == EnumCheckIDNOType.BeforeSave)
            {
                this.dtpBirthDay.Text = reurnString[1];
                this.cmbSex.Text = reurnString[2];
                this.setAge(this.dtpBirthDay.Value);
                //this.cmbPayKind.Focus();
            }
            else
            {
                if (this.dtpBirthDay.Text != reurnString[1])
                {
                    MessageBox.Show("输入的生日日期与身份证中号的生日不符");
                    this.dtpBirthDay.Focus();
                    return -1;
                }

                if (this.cmbSex.Text != reurnString[2])
                {
                    MessageBox.Show("输入的性别与身份证中号的性别不符");
                    this.cmbSex.Focus();
                    return -1;
                }
            }
            return 1;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 接收扩展录入信息接口
        /// </summary>
        /// <param name="inputObject">扩展录入信息对象</param>
        public void SetRegisterExtendInterface(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IRegisterExtend inputObject) 
        {
            this.registerExtend = inputObject;
        }

        /// <summary>
        /// 更新患者信息(目前只能更新科室)
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int UpdatePatientInfomation() 
        {
            //验证数据合法性
            if (!this.IsInputValid())
            {
                return -1;
            }
            
            //重新获得数据库存储得患者基本信息
            //this.patientInfomation.ID = this.txtInpatientNO.Tag.ToString();
            //更新患者住院科室时候如果改变了住院号text控件会报错的哟
            this.patientInfomation.ID = this.tempUpdatePatientID;
            this.patientInfomation = this.radtIntegrate.GetPatientInfomation(this.patientInfomation.ID);

            if (this.patientInfomation == null)
            {
                MessageBox.Show(Language.Msg("获得患者基本信息失败!") + this.radtIntegrate.Err);

                return -1;
            }

            //如果患者不是登记状态,不允许更改任何信息
            if (this.patientInfomation.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.R.ToString())
            {
                MessageBox.Show(Language.Msg("该患者在院状态已经改变, 不能进行修改!"));

                return -1;
            }

            //保存当前得患者科室信息,后面要插入变更记录
            Neusoft.FrameWork.Models.NeuObject oldDept = new Neusoft.FrameWork.Models.NeuObject();
            oldDept.ID = this.patientInfomation.PVisit.PatientLocation.Dept.ID;
            oldDept.Name = this.patientInfomation.PVisit.PatientLocation.Dept.Name;

            //获得修改后得患者基本信息
            if (this.GetPatientInfomation(this.patientInfomation) == -1)
            {
                return -1;
            }

            //重新在界面上取得了住院号啦，用原来的住院号更新他
            this.patientInfomation.ID = this.tempUpdatePatientID;

            //开始数据库事务
            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //更新科室
            if (this.radtIntegrate.UpdatePatientDept(this.patientInfomation) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("更新患者在院科室失败!") + this.radtIntegrate.Err);

                return -1;
            }


            //添加变更记录表	
            if (this.radtIntegrate.InsertShiftData(this.patientInfomation.ID, Neusoft.HISFC.Models.Base.EnumShiftType.CD, "修改科室", oldDept,
                this.patientInfomation.PVisit.PatientLocation.Dept) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("添加变更记录失败!") + this.radtIntegrate.Err);

                return -1;
            }

            //保存当前得患者科室信息,后面要插入变更记录
            Neusoft.FrameWork.Models.NeuObject oldNurseCell = new Neusoft.FrameWork.Models.NeuObject();
            oldNurseCell.ID = this.patientInfomation.PVisit.PatientLocation.NurseCell.ID;
            oldNurseCell.Name = this.patientInfomation.PVisit.PatientLocation.NurseCell.Name;

            //更新患者护士站{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (this.radtIntegrate.UpdatePatientNurse(this.patientInfomation) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("更新患者在院病区失败!") + this.radtIntegrate.Err);

                return -1;
            }

            //添加变转病区更记录表	F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            if (this.radtIntegrate.InsertShiftData(this.patientInfomation.ID, Neusoft.HISFC.Models.Base.EnumShiftType.CN, "修改科室", oldNurseCell,
                this.patientInfomation.PVisit.PatientLocation.NurseCell) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("添加变更记录失败!") + this.radtIntegrate.Err);

                return -1;
            }


            //提交数据库
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("更新成功!"));

            //刷新显示患者列表
            this.RefreshPatientLists();

            //清屏
            this.Clear();
            this.isModify = false;
            return 1;
        }
        
        /// <summary>
        /// 插入患者登记信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InsertPatientInfomation() 
        {
            //如果还没有输入住院号,那么自动生成住院号
            if (this.txtInpatientNO.Text == string.Empty)// || this.patientInfomation.PID.PatientNO == null || this.patientInfomation.PID.PatientNO == string.Empty)
            {
                if (this.isAutoInpatientNO)
                {
                    //如果自动生成住院号失败,那么中止方法
                    if (this.GetAutoInpatientNO(string.Empty) == -1)
                    {
                        return -1;
                    }
                }
                else 
                {
                    MessageBox.Show(Language.Msg("没有输入住院号!"));
                    
                    return -1;
                }
            }

            //验证有效性,如果有不符合录入,那么中止方法
                if (!this.IsInputValid()) 
            {
                return -1;
            }

            if (this.GetPatientInfomation(this.patientInfomation) == -1)
            {
                return -1;
            }

            Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrade = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            //创建数据库连接
            //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.inpatientManager.Connection);
            //开始数据库连接
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            radtIntegrade.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            managerMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

           
            if (this.isAutoInpatientNO)
            {
                //重新分配住院号
                if (this.ReGetPatientNO() == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    return -1;
                }
            } 
            //插入住院主表
            if (this.InsertMainInfo() == -1) 
            {
                return -1;
            }
            if (isCreateMoneyAlert)
            {
                Neusoft.FrameWork.Models.NeuObject conObj = managerIntegrate.GetConstant("PACTUNIT", cmbPact.Tag.ToString());
                if (conObj == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("获取合同单位失败" + cmbPact.Text);
                    return -1;
                }
                if (Neusoft.FrameWork.Public.String.IsNumeric(conObj.Memo))
                {
                    patientInfomation.PVisit.MoneyAlert = Neusoft.FrameWork.Function.NConvert.ToDecimal(conObj.Memo);
                }
                else
                {
                    patientInfomation.PVisit.MoneyAlert = 0m;
                }
                if (radtIntegrade.UpdatePatientAlert(this.patientInfomation.ID, patientInfomation.PVisit.MoneyAlert,Neusoft.HISFC.Models.Base.EnumAlertType.M.ToString(),DateTime.MinValue,DateTime.MinValue) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新警戒线失败" + radtIntegrade.Err);
                    return -1;
                }
            }
            # region 如果包含接诊流程，更新床的使用状态
            //如果包含接诊流程，更新床的使用状态
            if (this.IsContainsInstate)
            {

                //{4A0E8D9F-2FF5-4fc5-A050-8AA719E4D302}
                Neusoft.HISFC.Models.Base.Bed bedObjTemp = this.cmbBedNO.SelectedItem as Neusoft.HISFC.Models.Base.Bed;
                Neusoft.HISFC.Models.Base.Bed bedObj = bedObjTemp.Clone();
                bedObj.Status.User03 = bedObjTemp.Status.ID.ToString();

                bedObj.Status.ID = Neusoft.HISFC.Models.Base.EnumBedStatus.O;
                bedObj.InpatientNO = this.patientInfomation.ID;
                if (managerIntegrate.SetBed(bedObj) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新床位状态失败！"));
                    return -1;
                }
            }
            #endregion

            //如果取的是废号更新住院号标志
            if (this.radtIntegrate.UpdatePatientNOState(this.patientInfomation.PID.PatientNO) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("更新住院号状态出错！") + this.radtIntegrate.Err);

                return -1;
            }

            //更新扩展信息
            if (this.registerExtend != null) 
            {
                if (this.registerExtend.UpdateOtherInfomation(this.patientInfomation, ref this.errText) == -1) 
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(this.errText));

                    return -1;
                }
            }

            

            //插入患者基本信息
            if (this.radtIntegrate.RegisterComPatient(this.patientInfomation) == -1) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("插入患者基本信息出错!") + this.radtIntegrate.Err);

                return -1;
            }
            
            //插入变更信息
            if (this.radtIntegrate.InsertShiftData(this.patientInfomation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("插入变更信息出错!") + this.radtIntegrate.Err);

                    return -1;
                }
            #region 插入接诊的变更信息{FA3B8CE6-0414-423a-A92D-33678E5FF193}
            if (this.IsContainsInstate)
            {
                if (this.radtIntegrate.InsertRecievePatientShiftData(this.patientInfomation) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("插入接诊变更信息出错!") + this.radtIntegrate.Err);

                    return -1;
                }
            }
            #endregion
            //插入担保信息
            if (this.radtIntegrate.InsertSurty(this.patientInfomation) == -1) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("插入担保信息出错!") + this.radtIntegrate.Err);

                return -1;
            }

            //预交金实体
            Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();

            //处理预交金,包括获得预交金发票,这里不包括打印
            if (this.DealPreapy(prepay) == -1) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            //更新预约登记状态
            //User02是预约登记状态 0预约 1作废 2预约转住院

            if (this.PatientInfomation.User02 == "0" && this.PatientInfomation.User02!="")
            {
                string CardNo = this.patientInfomation.PID.CardNO;
                string HappenNo = this.patientInfomation.User01;
                managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                if (this.managerIntegrate.UpdatePreInPatientState(CardNo,"2",HappenNo) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
                if (this.adt != null)
                {
                    if (this.hl7 == "A01")
                        adt.PreRegInpatient(this.patientInfomation.Clone());

                }
            }

            long  returnValue = 0;
            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            returnValue = this.medcareInterfaceProxy.SetPactCode(this.patientInfomation.Pact.ID);
            this.medcareInterfaceProxy.Trans = Neusoft.FrameWork.Management.PublicTrans.Trans;
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获得合同单位失败") + this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.UploadRegInfoInpatient(this.patientInfomation);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口住院登记失败") + this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }
         
            this.medcareInterfaceProxy.Commit();
            

          
            returnValue = this.medcareInterfaceProxy.Disconnect();

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            # region 打印病案
            //{F862D2BC-57DB-4868-9A4D-32A47A8B4588}
            if (this.isHealthPrint)
            {
                if (this.healthPrint != null)
                {
                    DialogResult rs = MessageBox.Show(Language.Msg("是否打印病案?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        Neusoft.HISFC.Models.HealthRecord.Base parmPatientinfo = new Neusoft.HISFC.Models.HealthRecord.Base();
                        parmPatientinfo.PatientInfo = this.patientInfomation;

                        this.healthPrint.ControlValue(parmPatientinfo);
                        //this.healthPrint.PrintPreview();
                        this.healthPrint.Print();
                    }
                }
                else
                {
                    MessageBox.Show("请配置打印病案接口！");
                }
            }
            # endregion

            #region 预交金打印
            if (this.patientInfomation.FT.PrepayCost > 0)
            {
                this.prepayPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint;

                if (this.prepayPrint == null)
                {

                }
                else
                {
                    if (this.patientInfomation.IsEncrypt)
                    {
                        this.patientInfomation.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(this.patientInfomation.NormalName);
                    }
                    this.prepayPrint.Clear();
                    this.prepayPrint.SetValue(this.patientInfomation, prepay);
                    this.prepayPrint.Print();
                }
            }
            #endregion

            #region 打印担保金
            if (this.iPrintSureType != null && patientInfomation.Surety.SuretyCost > 0)
            {
                this.iPrintSureType.SetValue(patientInfomation);
                this.iPrintSureType.Print();
            }
            #endregion

            this.RefreshPatientLists();

            //this.Clear();

            MessageBox.Show(Language.Msg("登记成功!"));
            #region added by xizf20101128 按比例更新警戒线 {813120D4-B6CA-4d4b-A71D-85429CC70DC2}
             fun.UpdateInmainMoneyAlert(patientInfomation.ID, patientInfomation.Pact.ID);
           #endregion
            //{FB6200C2-1953-4c24-B888-953E4F2DF111} 20101107 席宗飞 待点击按钮之后，再清空界面，方便收款员核对患者所缴费用
            this.Clear();
          
            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear() 
        {
            this.txtClinicNO.SelectAll();
            this.txtInpatientNO.SelectAll();
            this.txtName.Text = string.Empty;
            this.cmbDept.Text = string.Empty;
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            this.cmbNurseCell.Text = string.Empty;
            this.cmbBedNO.Text = string.Empty;
            this.dtpInTime.Value = DateTime.Today;
            this.txtIDNO.Text = string.Empty;
            this.cmbMarry.Text = string.Empty;
            //{06926BA0-96F6-4a0a-9C19-69BF9AF9F312}
            //this.cmbPact.Text = string.Empty;

            //--------
            //{06926BA0-96F6-4a0a-9C19-69BF9AF9F312}
            //this.cmbPact.Tag = "1";
            //this.cmbPact.Text = "现金";

            //if (this.默认合同单位 != string.Empty)//{E4D64AAC-FB21-4cf3-AA98-D804D04506A7}
            //{
            //    this.cmbPact.Text = this.默认合同单位;
            //}
            //else
            //{
            //    this.cmbPact.Text = "现金";
            //}
            //{A2B27285-0646-4f2a-B5D6-99ACC5430902}
            //this.cmbPact.Text = this.pactName;
            this.cmbUnit.Text = "岁";
            this.cmbInSource.Tag = "1";
            this.cmbInSource.Text = "门诊";
            //--------
            txtHomePhone.Text = "";
            this.cmbBirthArea.Text = string.Empty;
            this.cmbCountry.Text = string.Empty;
            this.cmbProfession.Text = string.Empty;
            this.txtLinkMan.Text = string.Empty;
            this.cmbRelation.Text = string.Empty;
            this.cmbLinkAddress.Text = string.Empty;
            this.txtHomePhone.Text = string.Empty;
            //this.cmbInSource.Text = string.Empty;
            this.cmbDoctor.Text = string.Empty;
            this.mTxtPrepay.Text = "0.00";
            //this.cmbInSource.SelectedIndex = 0;
            this.cmbApproach.SelectedIndex = 0;
            this.cmbCircs.SelectedIndex = 0;
            this.mTxtIntimes.Text = "1";
            this.cmbPayMode.Tag = "CA";
            this.cmbPayMode.Text = "现金";
            //{0374EA05-782E-4609-9CDC-03236AB97906}
            this.cmbTransType1.Tag = "CA";
            this.cmbTransType1.Text = "现金";

            this.cmbUnit.SelectedIndex = 0;

            this.txtBedInterval.Text = "1";
            //this.Text = "有";
            //this.cmbCase.Tag = "1";
            //特殊---
            this.txtMCardNO.Text = string.Empty;
            this.txtComputerNO.Text = string.Empty;
            this.txtDiagnose.Text = string.Empty;
            this.mtxtBloodFee.Text = "0.00";
            this.cmbArea.Text = string.Empty;
            this.txtMCardNO.Enabled = true;
            this.txtName.Enabled = true;
            this.txtIDNO.Enabled = true;
            this.cmbHomeAddress.Text = string.Empty;
            this.cmbWorkAddress.Text = string.Empty;
            this.txtInpatientNO.Text = string.Empty;
            this.txtClinicNO.Text = string.Empty;
           
            this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.txtAge.Text = string.Empty;
            this.txtHomePhone.Text = string.Empty;
            this.txtLinkPhone.Text = string.Empty;
            this.isModify = false;
            //清空扩展信息
            if (this.registerExtend != null) 
            {
                this.registerExtend.ClearOtherInfomation();
            }
            this.chbencrypt.Checked = false;
            if(this.cmbBedNO.Items.Count>0)
                this.cmbBedNO.Items.Clear();
            this.isReadCard = false;
            //{FF419F26-D52C-404b-84BF-47A509BF5782}
            this.patientInfomation = new PatientInfo();
            this.RefreshPatientLists();

            //新增清屏信息
            this.cmbNation.Text = "汉族";
            this.txtWorkPhone.Text = string.Empty;
            this.cmbSuretyType.Tag = string.Empty;
            this.cmbSuretyPerson.Tag = string.Empty;
            this.txtSuretyCost.Text = "0.00";
            this.txtMark.Text = string.Empty;
            //{8D5C8D10-0E22-4229-A7C5-C133E666F567}
            this.SetEnableConrol(true);
            //if (this.rdoClinicNO.Checked)
            //{
            //    this.txtClinicNO.Focus();
            //}
            //else
            //{
            //    this.txtInpatientNO.Focus();
            //}

            this.cmbTransType1.bank = new Neusoft.HISFC.Models.Base.Bank();
            this.txtClinicNO.Enabled = isCanAutoInpatientNO;
            txtMCardNO.Enabled = true;
            //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
            this.txtInpatientNO.Focus();

        }
        /// <summary>
        /// 预约患者
        /// </summary>
        protected virtual void PrepayPatient()
        {
            try
            {
                //判断住院号
                if (this.txtInpatientNO.Text == null || this.txtInpatientNO.Text.Trim() == "")
                {
                    MessageBox.Show("请输入住院号!", "提示");
                    this.txtInpatientNO.Focus();
                    return;
                }
                //判断住院流水号
                if (this.txtInpatientNO.Tag == null)
                {
                    MessageBox.Show("请回车确认住院号", "提示");
                    this.txtInpatientNO.Focus();
                    return;
                }
                ucPrepayInQuery control = new ucPrepayInQuery();
                control.PrepayinState = "0";
                DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(control);
                if (result == DialogResult.OK)
                {
                    if (control.PatientInfo != null)
                    {
                        this.PatientInfomation = control.PatientInfo;
                        this.PatientInfomation.PID.PatientNO = this.txtInpatientNO.Text;
                        this.PatientInfomation.ID = this.txtInpatientNO.Tag.ToString() ;
                        this.SetPatientInfomation(PatientInfomation);
                        this.txtName.Focus();
                    }
                }
            }
            catch { }
            
        }

        /// <summary>
        /// 查询患者
        /// </summary>
        protected virtual void SearchPatient()
        {
            Neusoft.HISFC.Components.Common.Forms.frmSearchPatient frm = new Neusoft.HISFC.Components.Common.Forms.frmSearchPatient();
            frm.SaveInfo+=new Neusoft.HISFC.Components.Common.Forms.frmSearchPatient.SaveHandel(frm_SaveInfo);
            frm.Show();
        }
        private void frm_SaveInfo(PatientInfo patient)
        {
            this.SetPatientInfomation(patient);
        }
        #endregion

        #region 控件操作

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("确认保存", "保存录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("临时号", "生成临时住院号", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.L临时号, true, false, null);
            toolBarService.AddToolButton("预约患者", "打开预约患者界面", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预约, true, false, null);
            toolBarService.AddToolButton("患者查询", "打开患者查询界面", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            //{07EE4783-D3B3-48d4-B712-7847CF13FBB7} 读院内卡
            toolBarService.AddToolButton("读院内卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 自定义按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //string tempText = string.Empty;
            
            //try
            //{
            //    tempText = this.hsToolBar[e.ClickedItem.Text].ToString();
            //}
            //catch (Exception ex) 
            //{
            //    return;
            //}

            ButtonClicked(e.ClickedItem.Text);
            
            base.ToolStrip_ItemClicked(sender, e);
        }
        /// <summary>
        /// 响应键盘、鼠标事件
        /// </summary>
        /// <param name="tempText">工具栏按钮名称</param>
        private void ButtonClicked(string tempText)
        {
            switch (tempText)
            {
                case "确认保存":
                    this.hl7 = "A01";
                    if (this.isModify == true)
                    {
                        this.UpdatePatientInfomation();
                    }
                    else
                    {
                        this.InsertPatientInfomation();
                    }
                    this.cmbPact.Text = "自费";
                    this.txtInpatientNO.Text = "";
                    this.txtInpatientNO.Focus();
                    //this.InsertPatientInfomation();
                    break;
                case "清屏":
                    this.Clear();
                    break;
                case "临时号":
                    if (this.isAutoInpatientNO)
                    {
                        this.txtInpatientNO.Text = string.Empty;

                        this.GetAutoInpatientNO(string.Empty);

                        this.txtMCardNO.Focus();
                    }
                    break;
                case "预约患者":
                    {
                        PrepayPatient();
                        break;
                    }
                case "患者查询":
                    {
                        SearchPatient();
                        break;
                    }
                case "退出":
                    {
                        this.FindForm().Close();
                        break;
                    }
                case "帮助":
                    {
                        break;
                    }
                //{07EE4783-D3B3-48d4-B712-7847CF13FBB7} 读院内卡
                case "读院内卡":
                    {
                        this.txtClinicNO.Focus();
                        if (icreader.GetConnect())
                        {
                            cardno = icreader.ReaderICCard();
                            if (cardno == "0000000000")
                            {
                                isNewCard = true;
                                MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                            }
                            else
                            {
                                this.txtClinicNO.Text = cardno;
                                this.ProcessDialogKey(Keys.Enter);
                            }
                            icreader.CloseConnection();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("读卡失败！");
                            break;
                        }
                    }
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            //this.hl7 = "A01";

            if (this.isModify == true)
            {
                return this.UpdatePatientInfomation();
            }
            else
            {
                return this.InsertPatientInfomation();
            }
        }

        #endregion 

        #region 事件
        /// <summary>
        /// 初始化登记信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRegister_Load(object sender, EventArgs e)
        {
            //if (!this.DesignMode)
            //{E4002949-0D84-4eac-BE03-B2196A1AEC0D}
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.neuTabControl1.Focus();
                this.tabPage1.Focus();
                this.plInfomation.Focus();
                this.txtInpatientNO.Focus();
                this.rdoInpatientNO.Checked = true;

                this.登记科室必须输入 = true;
                this.患者性别必须输入 = true;
                this.患者姓名必须输入 = true;
                this.出生日期必须输入 = true;
                this.结算方式必须输入 = true;
                this.收住医师必须输入 = mTxtPrepayMustInput;
                this.预交金额必须输入 = true;
                this.住院号必须输入 = true;
                this.住院日期必须输入 = true;
                //this.cmbPact.Tag = "1";//{205C0764-F871-440e-8E77-79A9298E5A0D}
                //this.cmbPact.Text = "现金";//{205C0764-F871-440e-8E77-79A9298E5A0D}
                
                this.lblInSource.ForeColor = this.mustInputColor;
                this.lblPact.ForeColor = this.mustInputColor;


                //重新初始化工具栏
                //try
                //{
                //    Function.RefreshToolBar(this.hsToolBar, ((Neusoft.FrameWork.WinForms.Forms.frmBaseForm)this.ParentForm).toolBar1, "住院登记");
                //}
                //catch (Exception ex)
                //{ }


                //设置输入法
                try
                {
                    this.SetInputMenu( );
                    //设置窗体控件的输入法状态为半角
                    Neusoft.HISFC.Components.Common.Classes.Function.SetIme(this);
              
                }
                catch 
                {
                }

                this.Init();
            }

            //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD} 当窗体加载时，获取焦点20101101 席宗飞
            this.ActiveControl = this.txtInpatientNO;
            this.txtInpatientNO.Focus();
        }
        /// <summary>
        /// 自动生成住院号事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoInpatientNO_Click(object sender, EventArgs e)
        {
            this.txtInpatientNO.Text = string.Empty;

            this.GetAutoInpatientNO(string.Empty);

            this.txtMCardNO.Focus();

        }

        /// <summary>
        /// 已经登记患者显示信息列表的双击事件
        /// 主要判断是否可以修改患者信息,
        /// 如果患者是刚入院状态,则可以修改,其他状态不可以修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void spPatientInfo_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.spPatientInfo_Sheet1.RowCount <= 0)
            {
                return;
            }

            if (this.spPatientInfo_Sheet1.Rows[e.Row].Tag == null)
            {
                return;
            }
            Neusoft.HISFC.Models.RADT.PatientInfo pInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            pInfo = (Neusoft.HISFC.Models.RADT.PatientInfo)this.spPatientInfo.Sheets[0].Rows[e.Row].Tag;
            if (pInfo.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.R.ToString())
            {
                MessageBox.Show(Language.Msg("该患者不是住院登记状态, 不能进行修改!"));
                this.Clear();
                return;
            }
            this.SetPatientInfomation(pInfo);
            this.tempUpdatePatientID = pInfo.ID;
            this.isModify = true;
            //{8D5C8D10-0E22-4229-A7C5-C133E666F567}
            this.cmbDept.Focus();
            this.SetEnableConrol(false);
        }

        /// <summary>
        /// 当输入患者的年龄发生变化时，自动计算年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();



            if (this.dtpBirthDay.Value > nowTime)
            {

                //MessageBox.Show(Language.Msg("患者的生日不能大于当前系统时间!"));

                this.dtpBirthDay.Value = nowTime;

                return;
            }
            //{87EB6328-0634-44dc-A597-DEC7B08F9AA5}更改取年龄的函数，防止年龄里出现汉字
            this.setAge(this.dtpBirthDay.Value);
            //this.txtAge.Text = this.inpatientManager.GetAge(this.dtpBirthDay.Value);
        }


        /// <summary>
        /// 身份证 {9B24289B-D017-4356-8A25-B0F76EB79D15}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIDNO_Leave(object sender, System.EventArgs e)
        {
            if (this.txtIDNO.Text != "")
            {
                //string errMessage = string.Empty;
                //if (Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(this.txtIDNO.Text, ref errMessage) != 0)
                //{
                //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(errMessage));
                //}

               int returnValue = this.ProcessIDENNO(this.txtIDNO.Text.Trim(), EnumCheckIDNOType.BeforeSave);

               if (returnValue < 0)
               {
                   return;
               }
            }

            

            //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^\d{15,18}$");
            //System.Text.RegularExpressions.Match match = regex.Match(this.txtIDNO.Text);
            //if ( !match.Success )
            //{
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("身份证号为 15 至 18 位数字"));
            //    this.txtIDNO.Focus();
            //}
        }

        #endregion

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //{1BFFE533-C177-46bf-93C6-093DD7344DAF} wbo 2010-08-19
            this.cmbNurseCell.Tag = null;
            
            Neusoft.FrameWork.Models.NeuObject deptObj = this.cmbDept.SelectedItem;

            int returnValue = GetNurseCellByDept(deptObj);


            //ArrayList alBed = new ArrayList();

            //if (deptObj == null) return;
            
            //alBed = this.GetBedByDeptCode(deptObj);
            //if (alBed == null)
            //{
            //    MessageBox.Show("查找床位失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (alBed.Count == 0)
            //{
            //    MessageBox.Show("科室："+deptObj.Name + "目前没有床位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            
            ////包含接诊断流程
            //if (IsContainsInstate)
            //{
            //    cmbBedNO.Items.Clear();
            //    this.cmbBedNO.AddItems(alBed);
            //    if (this.cmbBedNO.Items.Count > 0)
            //    {
            //        this.cmbBedNO.SelectedIndex = 0;
            //    }
            //}

            

        }

        protected ArrayList GetBedByDeptCode(Neusoft.FrameWork.Models.NeuObject deptObj)
        {
            ArrayList alNurseCell = managerIntegrate.QueryNurseStationByDept(deptObj);
            ArrayList alBed = new ArrayList();
            try
            {
                foreach (Neusoft.FrameWork.Models.NeuObject obj in alNurseCell)
                {
                    ArrayList temp = managerIntegrate.QueryUnoccupiedBed(obj.ID);
                    if (temp != null && temp.Count > 0)
                        alBed.AddRange(temp);
                }
                return alBed;
            }
            catch { return null;}
        }

        /// <summary>
        /// 根据科室查询病区{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
        /// </summary>
        /// <param name="deptObj"></param>
        /// <returns></returns>
        protected int GetNurseCellByDept(Neusoft.FrameWork.Models.NeuObject deptObj)
        {
            ArrayList alNurseCell = managerIntegrate.QueryNurseStationByDept(deptObj);
            if (alNurseCell == null)
            {
                MessageBox.Show("根据科室查询病区出错" + managerIntegrate.Err);
                return -1;
            }

            Neusoft.FrameWork.Models.NeuObject nurseObj = new Neusoft.FrameWork.Models.NeuObject();
            if (alNurseCell.Count == 0)
            {
                //this.cmbNurseCell.SelectedIndexChanged -=new EventHandler(cmbNurseCell_SelectedIndexChanged);
                this.cmbNurseCell.Tag = nurseObj.ID;
                //this.cmbNurseCell.SelectedItem = null;
                //this.cmbNurseCell.SelectedIndexChanged += new EventHandler(cmbNurseCell_SelectedIndexChanged);
            }
            else
            {
                nurseObj = alNurseCell[0] as Neusoft.FrameWork.Models.NeuObject;
            }

            this.cmbNurseCell.Tag = nurseObj.ID;
            return 1;
        }


        #region ISIReadCard 成员

        public int ReadCard(string pactCode)
        {
            //{FF419F26-D52C-404b-84BF-47A509BF5782} 读卡前先清空一下
            this.Clear();

            #region 增加一个按钮读取所有医保的功能 {06926BA0-96F6-4a0a-9C19-69BF9AF9F312} wbo 2010-08-26
            //操作流程：选择合同单位，点读卡按钮
            if (string.IsNullOrEmpty(pactCode) || string.IsNullOrEmpty(pactCode.Trim()))
            {
                //如果没有选择合同单位点击读卡
                if (this.cmbPact.Tag == null || string.IsNullOrEmpty(this.cmbPact.Tag.ToString()))
                {
                    MessageBox.Show("请先选择合同单位，然后点击读卡按钮！");
                    return -1;
                }
                pactCode = this.cmbPact.Tag.ToString();
                this.patientInfomation.Pact.ID = pactCode;
            }
            #endregion

            //新农合登记时需要录入身份证号、医疗证号、所属地区来查询患者信息 {E0E5C4D7-AF3B-440c-82DB-E5A1A0676E4D} wbo 2010-08-28
            //新农合修改了，批量获取，xizf@neusoft.com 20110108
            if (pactCode == "13")
            {
                #region 输入身份证号、医疗证号和所属地区
                Neusoft.HISFC.Models.RADT.PatientInfo patient = new PatientInfo();
                NCMSSI.Control.frmGetPatientList frmpob = new NCMSSI.Control.frmGetPatientList();
                frmpob.Text = "新农合—住院登记";
                frmpob.ShowDialog();
                DialogResult result = frmpob.DialogResult;
                if (result == DialogResult.OK)
                {
                    this.patientInfomation = frmpob.patient;
                }
                else
                {
                    return -1;
                }
                #endregion
            }

            long returnValue = 0;
            returnValue =  this.medcareInterfaceProxy.SetPactCode(pactCode);
            if (returnValue != 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获得合同单位失败")+this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(this.patientInfomation);
            if (returnValue != 1)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口获得患者信息失败") + this.medcareInterfaceProxy.ErrMsg);
                return -1;
            }

            //returnValue = this.medcareInterfaceProxy.UploadRegInfoInpatient(this.patientInfomation);
            //this.medcareInterfaceProxy.Commit();

            //this.patientInfomation.SIMainInfo.TransType = 0;
            //this.patientInfomation.SIMainInfo.ReimbFlag = "";
            this.medcareInterfaceProxy.Disconnect();
            this.isReadCard = true;


            this.SetSIPatientInfo();
            //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
            this.txtInpatientNO.Focus();
            return 1;

        }

        public int SetSIPatientInfo()
        {
            ArrayList alPatientInfo = new ArrayList();
            this.txtMCardNO.Text = this.patientInfomation.SSN;
            this.cmbPact.Tag = this.patientInfomation.Pact.ID;
            this.cmbSex.Tag = this.patientInfomation.Sex.ID;
            this.cmbNation.Tag = this.patientInfomation.Nationality.ID;
          
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.Models.RADT.PatientInfo p = null;

            alPatientInfo = radt.PatientQueryByMcardNO(this.patientInfomation.SSN);
            if (alPatientInfo.Count != 0 && alPatientInfo!= null)
            {
                p = (Neusoft.HISFC.Models.RADT.PatientInfo)alPatientInfo[0];
                this.patientInfomation.PID.CardNO = p.PID.CardNO;
                this.patientInfomation.PhoneHome = p.PhoneHome;
                this.patientInfomation.AddressHome = p.AddressHome;
                this.patientInfomation.PID.PatientNO = p.PID.PatientNO;
                Neusoft.HISFC.Models.RADT.PatientInfo tempPatientInfo = new PatientInfo();
                //this.radtIntegrate.CreateAutoInpatientNO(tempPatientInfo);
                this.patientInfomation.ID = tempPatientInfo.ID;
                this.patientInfomation.Birthday = p.Birthday;
            }

            this.SetPatientInfomation(this.patientInfomation);


            return 1 ;
        }

        #endregion

        #region 快捷键

        /// <summary>
        /// toolBar映射
        /// </summary>
        //protected Hashtable hsToolBar = new Hashtable();

        /// <summary>
        /// 按键设置
        /// </summary>
        /// <param name="keyData">当前按键</param>
        /// <returns>继续执行True False 当前处理结束</returns>

        #region 作废
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        if (DealControlEnterEvents() == -1)
        //        {
        //            return true;
        //        }

        //        SendKeys.Send("{TAB}");
        //        return true;
        //    }
        //    ////判断执行快捷键
        //    //this.ExecuteShotCut(keyData);

        //    return base.ProcessDialogKey(keyData);
        //}

        #endregion

        //{bf62179b-f8a7-4a15-a1a1-bcf55a6b53b3} 调整回车焦点变更依次经过住院号、结算方式、姓名、性别、科室、预交金额、支付方式
        protected override bool ProcessDialogKey(Keys keyData)
        {
            #region  作废  {07EE4783-D3B3-48d4-B712-7847CF13FBB7} 
            if (this.cmbPact.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.txtInpatientNO.Focus();
                    return true;
                }
            }
            if (this.txtInpatientNO.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    //{483A614E-2765-41a9-891E-94B4841A619C} xizf@neusoft.com 住院号位数判断，目前为7位
                    if (this.DealInputInpatientNO() == -1)
                    {
                        MessageBox.Show("请检查住院号的位数及正确性");
                        this.txtInpatientNO.Focus();
                        return false;
                    }
                    this.txtName.Focus();
                    return true;
                }
            }
            if (this.txtName.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.cmbSex.Focus();
                    return true;
                }
            }
            if (this.cmbSex.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    //增加性别的数字输入方式{B4F285A2-A2E7-4076-80BC-9E425FFA4732} 席宗飞20101020
                    if (string.IsNullOrEmpty(this.cmbSex.Text.Trim()))
                    {
                        MessageBox.Show("性别不能为空,请重新输入!");
                        this.cmbSex.Focus();
                    }
                    else
                    {
                        if (this.cmbSex.Text.Trim() == "1")
                        {
                            this.cmbSex.Tag = "M";
                        }
                        else if (this.cmbSex.Text.Trim() == "2")
                        {
                            this.cmbSex.Tag = "F";
                        }
                        else if (this.cmbSex.Text.Trim() == "3")
                        {
                            this.cmbSex.Tag = "U";
                        }
                        else if (this.cmbSex.Text.Trim() == "男" || this.cmbSex.Text.Trim() == "女" || this.cmbSex.Text.Trim() == "未知")
                        {

                        }
                        else
                        {
                            MessageBox.Show("性别输入错误,请重新输入!");
                            this.cmbSex.Focus();
                            return true;
                        }
                    }
                    this.txtAge.Focus();
                    return true;
                }
            }
            if (this.txtAge.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.cmbUnit.Focus();
                    return true;
                }
            }
            if (this.cmbUnit.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
                    if (this.getBirthday() > 0)
                        this.cmbDept.Focus();
                    return true;
                }
            }
            if (this.cmbDept.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.cmbPayMode.Focus();
                    return true;
                }
            }

            //if (this.cmbPayMode.Focused)
            //{
            //    if (keyData == Keys.Enter)
            //    {
            //        ///{17383B2D-3110-4a9b-B0B7-99D95CB693C5} 增加支付方式的数字输入方式 席宗飞20101020
            //        if (string.IsNullOrEmpty(this.cmbPayMode.Text.Trim()))
            //        {
            //            MessageBox.Show("支付方式不能为空,请重新输入!");
            //            this.cmbPayMode.Focus();
            //        }
            //        else
            //        {
            //            if (this.cmbPayMode.Text.Trim() == "1")
            //            {
            //                this.cmbPayMode.Tag = "CA";
            //            }
            //            else if (this.cmbPayMode.Text.Trim() == "2")
            //            {
            //                this.cmbPayMode.Tag = "DB";
            //            }
            //            else if (this.cmbPayMode.Text.Trim() == "3")
            //            {
            //                this.cmbPayMode.Tag = "CH";
            //            }
            //            else if (this.cmbPayMode.Text.Trim() == "现金" || this.cmbPayMode.Text.Trim() == "银联卡" || this.cmbPayMode.Text.Trim() == "支票")
            //            {

            //            }
            //            else
            //            {
            //                MessageBox.Show("支付方式输入错误,请重新输入!");
            //                this.cmbPayMode.Focus();
            //                return true;
            //            }
            //        }
            //        this.mTxtPrepay.Focus();
            //        return true;
            //    }
            //}
            //if (this.mTxtPrepay.Focused)
            //{
            //    if (keyData == Keys.Enter)
            //    {
            //        if (MessageBox.Show("确认保存？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            this.ButtonClicked("确认保存");
            //        }
            //        else
            //        {
            //            this.mTxtPrepay.Focus();
            //        }

            //        return true;
            //    }
            //}
            #endregion

            // {07EE4783-D3B3-48d4-B712-7847CF13FBB7} 
            if (this.txtClinicNO.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    string cardNO = this.txtClinicNO.Text.ToString();
                    if (cardNO.Length < 10)
                    {
                        cardNO = cardNO.PadLeft(10, '0');
                    }

                    DateTime dtLimit = new DateTime(2010, 12, 10);
                    ArrayList patientInfoList = this.registerManager.Query(cardNO, dtLimit);
                    Neusoft.HISFC.Models.Registration.Register patientInfo = new Neusoft.HISFC.Models.Registration.Register();
                    if (patientInfoList.Count > 0)
                    {
                        patientInfo = patientInfoList[patientInfoList.Count - 1] as Neusoft.HISFC.Models.Registration.Register;
                    }
                    else
                    {
                        MessageBox.Show("该患者未挂号！");
                    }

                    this.inPatientProof = this.radtIntegrate.QueryInPatientProofinfo(patientInfo.ID);

                    this.SetOutpatientInfo(patientInfo);
                    patientInfo = null;
                    inPatientProof = null;
                    return true;
                }
            }
            if (this.cmbDept.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    this.cmbPayMode.Focus();
                    return true;
                }
            }
            if (this.cmbPayMode.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(this.cmbPayMode.Text.Trim()))
                    {
                        MessageBox.Show("支付方式不能为空,请重新输入!");
                        this.cmbPayMode.Focus();
                    }
                    else
                    {
                        if (this.cmbPayMode.Text.Trim() == "1")
                        {
                            this.cmbPayMode.Tag = "CA";
                        }
                        else if (this.cmbPayMode.Text.Trim() == "2")
                        {
                            this.cmbPayMode.Tag = "DB";
                        }
                        else if (this.cmbPayMode.Text.Trim() == "3")
                        {
                            this.cmbPayMode.Tag = "CH";
                        }
                        else if (this.cmbPayMode.Text.Trim() == "现金" || this.cmbPayMode.Text.Trim() == "银联卡" || this.cmbPayMode.Text.Trim() == "支票")
                        {

                        }
                        else
                        {
                            MessageBox.Show("支付方式输入错误,请重新输入!");
                            this.cmbPayMode.Focus();
                            return true;
                        }
                    }
                    this.mTxtPrepay.Focus();
                    return true;
                }
            }
            if (this.mTxtPrepay.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    if (MessageBox.Show("确认保存？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.ButtonClicked("确认保存");
                    }
                    else
                    {
                        this.mTxtPrepay.Focus();
                    }

                    return true;
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        private void SetOutpatientInfo(Neusoft.HISFC.Models.Registration.Register patientInfo)
        {
            this.cmbPact.Text = "";
            if (string.IsNullOrEmpty(this.inPatientProof.Memo1))
            {
                this.cmbPact.Text = "自费";
            }
            else
            {
                this.cmbPact.Text = this.inPatientProof.Memo1;
            }
            this.txtName.Text = "";
            this.txtName.Text = patientInfo.Name;
            this.btnAutoInpatientNO_Click(this.btnAutoInpatientNO, null);
            this.cmbSex.Text = "";
            this.cmbSex.Text = patientInfo.Sex.Name;
            this.dtpBirthDay.Value = patientInfo.Birthday;
            this.dtpBirthDay_ValueChanged(this.dtpBirthDay, null);
            this.cmbDoctor.Text = "";
            this.cmbDoctor.Text = this.inPatientProof.Doct_code.Name;
            this.cmbDept.Text = "";
            this.cmbDept.Text = this.inPatientProof.Dept_code.Name;
            this.cmbDept_SelectedIndexChanged(this.cmbDept, null);
            this.cmbNation.Text = "";
            this.cmbNation.Text = patientInfo.Nationality.Name;
            this.txtIDNO.Text = "";
            this.txtIDNO.Text = this.inPatientProof.Idenno;
            this.cmbHomeAddress.Text = "";
            this.cmbHomeAddress.Text = this.inPatientProof.Address;
            this.txtDiagnose.Text = "";
            this.txtDiagnose.Text = this.inPatientProof.Diagnose;
            this.cmbPayMode.Focus();
        }

        ///// <summary>
        ///// 执行快捷键
        ///// </summary>
        ///// <param name="key">当前按键</param>
        //private bool ExecuteShotCut(Keys key)
        //{
        //    string opName = Function.GetOperationName("住院登记",key.GetHashCode().ToString());

        //    if (opName == "") return false;

        //    ButtonClicked(opName);

        //    return true;

        //}

        #endregion

        #region 输入法设置

        /// <summary>
        /// 默认的中文输入法
        /// </summary>
        private InputLanguage CHInput = null;

        /// <summary>
        /// 初始化输入法菜单
        /// </summary>
        private void SetInputMenu(  )
        {
   
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage t = InputLanguage.InstalledInputLanguages[i];
                System.Windows.Forms.ToolStripMenuItem m = new ToolStripMenuItem( );
                m.Text = t.LayoutName;
                m.Click += new EventHandler(m_Click);
                neuContextMenuStrip1.Items.Add(m);
            }

            this.ReadInputLanguage( );
        }

        /// <summary>
        /// 读取当前默认输入法
        /// </summary>
        private  void ReadInputLanguage( )
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting( );

            }
            try
            {
                XmlDocument doc = new XmlDocument( );
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                CHInput = GetInputLanguage(node.Attributes["currentmodel"].Value);

                if (CHInput != null)
                {
                    foreach (ToolStripMenuItem m in neuContextMenuStrip1.Items)
                    {
                        if (m.Text == CHInput.LayoutName)
                        {
                            m.Checked = true;
                        }
                    }
                }

                //添加到工具栏

            }
            catch (Exception e)
            {
                MessageBox.Show("获取默认中文输入法出错!" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 根据输入法名称获取输入法
        /// </summary>
        /// <param name="LanName"></param>
        /// <returns></returns>
        private InputLanguage GetInputLanguage( string LanName )
        {
            foreach (InputLanguage input in InputLanguage.InstalledInputLanguages)
            {
                if (input.LayoutName == LanName)
                {
                    return input;
                }
            }
            return null;
        }

        /// <summary>
        /// 保存当前输入法
        /// </summary>
        private void SaveInputLanguage( )
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting( );
            }
            if (CHInput == null)
                return;

            try
            {
                XmlDocument doc = new XmlDocument( );
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                node.Attributes["currentmodel"].Value = CHInput.LayoutName;

                doc.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show("保存默认中文输入法出错!" + e.Message);
                return;
            }
        }

        private void m_Click( object sender, EventArgs e )
        {
            foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
            {
                if (sender == m)
                {
                    m.Checked = true;
                    this.CHInput = this.GetInputLanguage(m.Text);
                    //保存输入法
                    this.SaveInputLanguage( );
                }
                else
                {
                    m.Checked = false;
                }
            }
        }

        #endregion

        #region ////{538F0253-AB89-4ce3-8C2A-7E8F5C6EDBF5}增加年龄生日互算
        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime current = this.inpatientManager.GetDateTimeFromSysDateTime().Date;

                if (this.dtpBirthDay.Value.Date > current)
                {
                    MessageBox.Show("出生日期不能大于当前时间!", "提示");
                    this.dtpBirthDay.Focus();

                    return;
                }

                //计算年龄
                if (this.dtpBirthDay.Value.Date != current)
                {
                    this.setAge(this.dtpBirthDay.Value);
                }

                this.cmbWorkAddress.Focus();
            }
        }

        /// <summary>
        /// Set Age
        /// </summary>
        /// <param name="birthday"></param>
        private void setAge(DateTime birthday)
        {
            this.txtAge.Text = "";

            if (birthday == DateTime.MinValue)
            {
                return;
            }

            DateTime current;
            int year, month, day;

            current = this.inpatientManager.GetDateTimeFromSysDateTime();
            year = current.Year - birthday.Year;
            month = current.Month - birthday.Month;
            day = current.Day - birthday.Day;

            if (year > 1)
            {
                this.txtAge.Text = year.ToString();
                this.cmbUnit.SelectedIndex = 0;
            }
            else if (year == 1)
            {
                if (month >= 0)//一岁
                {
                    this.txtAge.Text = year.ToString();
                    this.cmbUnit.SelectedIndex = 0;
                }
                else
                {
                    this.txtAge.Text = Convert.ToString(12 + month);
                    this.cmbUnit.SelectedIndex = 1;
                }
            }
            else if (month > 0)
            {
                this.txtAge.Text = month.ToString();
                this.cmbUnit.SelectedIndex = 1;
            }
            else if (day > 0)
            {
                this.txtAge.Text = day.ToString();
                this.cmbUnit.SelectedIndex = 2;
            }

        }

        /// <summary>
        /// 获取出生日期
        /// {37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
        /// </summary>
        private int getBirthday()
        {
            string age = this.txtAge.Text.Trim();
            int i = 0;

            if (age == "") age = "0";

            try
            {
                i = int.Parse(age);
            }
            catch (Exception e)
            {
                string error = e.Message;
                MessageBox.Show("输入年龄不正确,请重新输入!", "提示");
                this.txtAge.Focus();
                return -1;
            }

            ///
            ///

            DateTime birthday = DateTime.MinValue;

            this.getBirthday(i, this.cmbUnit.Text, ref birthday);

            if (birthday < this.dtpBirthDay.MinDate)
            {
                MessageBox.Show("年龄不能过大!", "提示");
                this.txtAge.SelectAll();
                return -1;
            }

            //this.dtBirthday.Value = birthday ;

            if (this.cmbUnit.Text == "岁")
            {

                //数据库中存的是出生日期,如果年龄单位是岁,并且算出的出生日期和数据库中出生日期年份相同
                //就不进行重新赋值,因为算出的出生日期生日为当天,所以以数据库中为准

                if (this.dtpBirthDay.Value.Year != birthday.Year)
                {
                    this.dtpBirthDay.Value = birthday;
                }
            }
            else
            {
                this.dtpBirthDay.Value = birthday;
            }

            return 1;
        }

        /// <summary>
        /// 根据年龄得到出生日期
        /// </summary>
        /// <param name="age"></param>
        /// <param name="ageUnit"></param>
        /// <param name="birthday"></param>
        private void getBirthday(int age, string ageUnit, ref DateTime birthday)
        {
            DateTime current = this.inpatientManager.GetDateTimeFromSysDateTime();

            if (ageUnit == "岁")
            {
                birthday = current.AddYears(-age);
            }
            else if (ageUnit == "月")
            {
                birthday = current.AddMonths(-age);
            }
            else if (ageUnit == "天")
            {
                birthday = current.AddDays(-age);
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //{37B07DD6-D1A2-4f09-8DF1-E5290FC79CAD}
            if (this.getBirthday() <= 0)
            {
                this.cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbWorkAddress.Focus();
            }
          
        }

        private void dtpBirthDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime current = this.inpatientManager.GetDateTimeFromSysDateTime().Date;

                if (this.dtpBirthDay.Value.Date > current)
                {
                    MessageBox.Show("出生日期不能大于当前时间!", "提示");
                    this.dtpBirthDay.Focus();
                    return;
                }

                //计算年龄
                if (this.dtpBirthDay.Value.Date != current)
                {
                    this.setAge(this.dtpBirthDay.Value);
                }

                this.cmbWorkAddress.Focus();
            }
        }
        ////{538F0253-AB89-4ce3-8C2A-7E8F5C6EDBF5}增加年龄生日互算 结束
        #endregion

        #region 身份证校验枚举
        /// <summary>
        /// 判断身份证{9B24289B-D017-4356-8A25-B0F76EB79D15}
        /// </summary>
        private enum EnumCheckIDNOType
        {
            /// <summary>
            /// 保存之前校验
            /// </summary>
            BeforeSave = 0,

            /// <summary>
            /// 保存时校验
            /// </summary>
            Saveing
        }
        #endregion

        /// <summary>//{8D5C8D10-0E22-4229-A7C5-C133E666F567}
        /// 设置空间不可用
        /// </summary>
        /// <param name="isEnable"></param>
        private void SetEnableConrol(bool isEnable)
        {
            foreach (Control var in this.plInfomation.Controls)
            {
                if (var.GetType().ToString() != "Neusoft.FrameWork.WinForms.Controls.NeuLabel" && var.Name != "cmbDept"&&var.Name != "cmbNurseCell")
                {
                    var.Enabled = isEnable;
                }
            }
        }
        //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}

        private void cmbNurseCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject nurseObj = this.cmbNurseCell.SelectedItem;
            //ArrayList alBed = new ArrayList();

            if (nurseObj == null) return;

            ArrayList alBed = managerIntegrate.QueryUnoccupiedBed(nurseObj.ID);

            // alBed = this.GetBedByDeptCode(deptObj);
            if (alBed == null)
            {
                MessageBox.Show("查找床位失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (alBed.Count == 0)
            {
                MessageBox.Show("病区：" + nurseObj.Name + "目前没有床位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //包含接诊断流程
            if (IsContainsInstate)
            {
                cmbBedNO.Items.Clear();
                this.cmbBedNO.AddItems(alBed);
                if (this.cmbBedNO.Items.Count > 0)
                {
                    this.cmbBedNO.SelectedIndex = 0;
                }
            }


        }

        //{4B86EBA7-5616-4787-A9F2-CF7EEAA85D92}
        /// <summary>
        /// 获取公费患者信息
        /// </summary>
        /// <returns></returns>
        private int GetGFPatientInfo()
        {
            string mCardNO = this.txtMCardNO.Text.Trim();
            if (string.IsNullOrEmpty(mCardNO))
            {
                return -1;
            }
            string pactCode = this.cmbPact.Tag.ToString();
            if (queryGFPatient == null)
            {
                queryGFPatient = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IQueryGFPatient)) as Neusoft.HISFC.BizProcess.Interface.IQueryGFPatient;
            }
            if (queryGFPatient == null)
            {
                return -1;
            }
            PatientInfo p = new PatientInfo();
            string errText = string.Empty;
            int resultValue = queryGFPatient.QueryGFPatient(p, ref errText, pactCode, mCardNO);
            if (resultValue <= 0)
            {
                MessageBox.Show(errText);
                return -1;
            }
            this.txtName.Text = p.Name;
            this.cmbSex.Text = p.Sex.Name;
            this.txtIDNO.Text = p.IDCard;
            this.cmbWorkAddress.Text = p.CompanyName;
            this.txtHomePhone.Text = p.PhoneHome;
            this.txtInpatientNO.Focus();
            return 1;
        }

    } 
}