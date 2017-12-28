using System;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.SIInterface {


	/// <summary>
	/// SIMainInfo 的摘要说明。
	/// Id inpatientNo, name 患者姓名
	/// </summary>
    [Serializable]
    public class SIMainInfo : Neusoft.FrameWork.Models.NeuObject
    {
        public SIMainInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 扩展属性
        private System.Collections.Generic.Dictionary<string, NeuObject> extendProperty = new System.Collections.Generic.Dictionary<string, NeuObject>();
        /// <summary>
        /// 扩展属性
        /// </summary>
        public System.Collections.Generic.Dictionary<string, NeuObject> ExtendProperty
        {
            get { return extendProperty; }
            set { extendProperty = value; }
        } 
        #endregion

        private int feeTimes;
        /// <summary>
        /// 费用批次
        /// </summary>
        public int FeeTimes
        {
            set
            {
                feeTimes = value;
            }
            get
            {
                return feeTimes;
            }
        }
        private int readFlag;
        /// <summary>
        /// 读入标志
        /// </summary>
        public int ReadFlag
        {
            get
            {
                return readFlag;
            }
            set
            {
                readFlag = value;
            }
        }

        private string regNo;
        /// <summary>
        /// 就诊登记号、铁路医保个人编号
        /// </summary>
        public string RegNo
        {
            set
            {
                regNo = value;
            }
            get
            {
                return regNo;
            }
        }

        private string hosNo;
        /// <summary>
        /// 医院编号
        /// </summary>
        public string HosNo
        {
            set { hosNo = value; }
            get { return hosNo; }
        }

        private string balNo;
        /// <summary>
        ///  结算序号
        /// </summary>
        public string BalNo
        {
            get
            {
                if (balNo == null || balNo == "")
                {
                    balNo = "0";
                }
                return balNo;
            }
            set { balNo = value; }
        }
        private string invoiceNo;
        /// <summary>
        /// 主发票号
        /// </summary>
        public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }
        private Neusoft.FrameWork.Models.NeuObject medicalType = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 医疗类别 1-住院 2 -门诊特定项目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject MedicalType
        {
            get { return medicalType; }
            set { medicalType = value; }
        }
        //		private string patientNo;
        //		/// <summary>
        //		/// 住院号
        //		/// </summary>
        //		public string PatientNo
        //		{
        //			get{return patientNo;}
        //			set{patientNo = value;}
        //		}
        //		private string cardNo;
        //		/// <summary>
        //		/// 就诊卡号
        //		/// </summary>
        //		public string CardNo
        //		{
        //			get{return cardNo;}
        //			set{cardNo = value;}
        //		}
        //		private string mCardNo;
        //		/// <summary>
        //		/// 医疗证号
        //		/// </summary>
        //		public string MCardNo
        //		{
        //			get{return mCardNo;}
        //			set{mCardNo = value;}
        //		}
        private string proceatePcNo;
        /// <summary>
        /// 生育保险患者电脑号
        /// </summary>
        public string ProceatePcNo
        {
            get { return proceatePcNo; }
            set { proceatePcNo = value; }
        }
        private DateTime siBeginDate;
        /// <summary>
        /// 参保日期
        /// </summary>
        public DateTime SiBegionDate
        {
            get { return siBeginDate; }
            set { siBeginDate = value; }
        }
        private string siState;
        /// <summary>
        /// 参保状态 3-参保缴费、4-暂停缴费、7-终止参保
        /// </summary>
        public string SiState
        {
            get { return siState; }
            set { siState = value; }
        }
        private string emplType;
        /// <summary>
        /// 人员类别 1-在职、2-退休
        /// </summary>
        public string EmplType
        {
            get { return emplType; }
            set { emplType = value; }
        }
        private string clinicDiagNose;
        /// <summary>
        /// 门诊诊断
        /// </summary>
        public string ClinicDiagNose
        {
            get { return clinicDiagNose; }
            set { clinicDiagNose = value; }
        }
        private DateTime inDiagnoseDate;
        /// <summary>
        /// 入院诊断日期
        /// </summary>
        public DateTime InDiagnoseDate
        {
            get { return inDiagnoseDate; }
            set { inDiagnoseDate = value; }
        }

        private Neusoft.FrameWork.Models.NeuObject inDiagnose = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 入院诊断信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InDiagnose
        {
            get { return inDiagnose; }
            set { inDiagnose = value; }
        }

        private decimal totCost;
        /// <summary>
        /// 住院总金额
        /// </summary>
        public decimal TotCost
        {
            get { return totCost; }
            set { totCost = value; }
        }
        private decimal addTotCost = 0;
        /// <summary>
        /// 费用累计
        /// </summary>
        public decimal AddTotCost
        {
            get { return addTotCost; }
            set { addTotCost = value; }
        }
        private decimal payCost;
        /// <summary>
        /// 帐户支付金额
        /// </summary>
        public decimal PayCost
        {
            get { return payCost; }
            set { payCost = value; }
        }

        /// <summary>
        /// 社保支付金额(除自费和账户支付的所有金额的合计)
        /// </summary>
        private decimal pubCost;
        /// <summary>
        /// 社保支付金额(除自费和账户支付的所有金额的合计)
        /// </summary>
        public decimal PubCost
        {
            get { return pubCost; }
            set { pubCost = value; }
        }
        //{06A3389F-B19E-4482-A55C-89269995B142}
        /// <summary>
        /// 医保返回的统筹金额
        /// </summary>
        private decimal siPubCost;

        /// <summary>
        /// 医保返回的统筹金额
        /// </summary>
        public decimal SiPubCost
        {
            get { return this.siPubCost; }
            set { this.siPubCost = value; }

        }

        private decimal itemPayCost;
        /// <summary>
        /// 部分项目自付金额 
        /// </summary>
        public decimal ItemPayCost
        {
            get { return itemPayCost; }
            set { itemPayCost = value; }
        }
        private decimal baseCost;
        /// <summary>
        /// 个人起付金额
        /// </summary>
        public decimal BaseCost
        {
            get { return baseCost; }
            set { baseCost = value; }
        }
        private decimal ownCost;
        /// <summary>
        /// 个人自费项目金额
        /// </summary>
        public decimal OwnCost
        {
            get { return ownCost; }
            set { ownCost = value; }
        }
        private decimal itemYLCost;
        /// <summary>
        /// 个人自付金额（乙类自付部分）
        /// </summary>
        public decimal ItemYLCost
        {
            get { return itemYLCost; }
            set { itemYLCost = value; }
        }

        private decimal pubOwnCost;
        /// <summary>
        /// 个人自负金额
        /// </summary>
        public decimal PubOwnCost
        {
            set { pubOwnCost = value; }
            get { return pubOwnCost; }
        }

        private decimal overTakeOwnCost;
        /// <summary>
        /// 超统筹支付限额个人自付金额
        /// </summary>
        public decimal OverTakeOwnCost
        {
            get { return overTakeOwnCost; }
            set { overTakeOwnCost = value; }
        }

        private decimal hosCost;
        /// <summary>
        /// 医药机构分担金额
        /// </summary>
        public decimal HosCost
        {
            set
            {
                hosCost = value;
            }
            get
            {
                return hosCost;
            }
        }

        private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 操作员信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }
        private DateTime operDate;
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get { return operDate; }
            set { operDate = value; }
        }
        private int appNo;
        /// <summary>
        /// 审批号
        /// </summary>
        public int AppNo
        {
            get { return appNo; }
            set { appNo = value; }
        }
        private DateTime balanceDate;
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime BalanceDate
        {
            get { return balanceDate; }
            set { balanceDate = value; }
        }
        private decimal yearCost;
        /// <summary>
        /// 本年度可用定额
        /// </summary>
        public decimal YearCost
        {
            get
            {
                return yearCost;
            }
            set
            {
                yearCost = value;
            }
        }
        private Neusoft.FrameWork.Models.NeuObject outDiagnose = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 出院诊断
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OutDiagnose
        {
            set { outDiagnose = value; }
            get { return outDiagnose; }
        }

        private bool isValid;
        /// <summary>
        /// 是否有效 True有效 False 无效
        /// </summary>
        public bool IsValid
        {
            set
            {
                isValid = value;
            }
            get
            {
                return isValid;
            }
        }

        private bool isBalanced;
        /// <summary>
        /// 是否结算 True 结算 False 未结算
        /// </summary>
        public bool IsBalanced
        {
            get
            {
                return isBalanced;
            }
            set
            {
                isBalanced = value;
            }
        }


        #region 铁路医保附加属性
        #region 变量
        string icCardCode = "";
        Neusoft.FrameWork.Models.NeuObject personType = new NeuObject();
        Neusoft.FrameWork.Models.NeuObject civilianGrade = new NeuObject();
        Neusoft.FrameWork.Models.NeuObject specialCare = new NeuObject();
        string duty = "";
        Neusoft.FrameWork.Models.NeuObject anotherCity = new NeuObject();
        Neusoft.FrameWork.Models.NeuObject corporation = new NeuObject();
        decimal individualBalance = 0;
        string freezeMessage = "";
        string applySequence = "";
        Neusoft.FrameWork.Models.NeuObject disease = new NeuObject();
        Neusoft.FrameWork.Models.NeuObject applyType = new NeuObject();
        Neusoft.FrameWork.Models.NeuObject fund = new NeuObject();
        string businessSequence = "";
        Neusoft.FrameWork.Models.NeuObject specialWorkKind = new NeuObject();
        string hospitalBusinessSequence = "";
        string opositeBusinessSequence = "";
        #endregion
        /// <summary>
        /// IC卡号码
        /// </summary>
        public string ICCardCode
        {
            get
            {
                return this.icCardCode;
            }
            set
            {
                this.icCardCode = value;
            }
        }

        /// <summary>
        /// 人员类别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PersonType
        {
            get
            {
                return this.personType;
            }
            set
            {
                this.personType = value;
            }
        }
        /// <summary>
        /// 公务员级别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CivilianGrade
        {
            get
            {
                return this.civilianGrade;
            }
            set
            {
                this.civilianGrade = value;
            }
        }
        /// <summary>
        /// 特殊照顾人群
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SpecialCare
        {
            get
            {
                return this.specialCare;
            }
            set
            {
                this.specialCare = value;
            }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string Duty
        {
            get
            {
                return this.duty;
            }
            set
            {
                this.duty = value;
            }
        }
        /// <summary>
        /// 异地安置城市
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject AnotherCity
        {
            get
            {
                return this.anotherCity;
            }
            set
            {
                this.anotherCity = value;
            }
        }
        /// <summary>
        /// 参保人单位
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Corporation
        {
            get
            {
                return this.corporation;
            }
            set
            {
                this.corporation = value;
            }
        }
        /// <summary>
        /// 个人帐户余额
        /// </summary>
        public decimal IndividualBalance
        {
            get
            {
                return this.individualBalance;
            }
            set
            {
                this.individualBalance = value;
            }
        }
        /// <summary>
        /// 已冻结基金信息
        /// </summary>
        public string FreezeMessage
        {
            get
            {
                return this.freezeMessage;
            }
            set
            {
                this.freezeMessage = value;
            }
        }
        /// <summary>
        /// 申请序号
        /// </summary>
        public string ApplySequence
        {
            get
            {
                return this.applySequence;
            }
            set
            {
                this.applySequence = value;
            }
        }
        /// <summary>
        /// 疾病
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Disease
        {
            get
            {
                return this.disease;
            }
            set
            {
                this.disease = value;
            }
        }
        /// <summary>
        /// 申请类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ApplyType
        {
            get
            {
                return this.applyType;
            }
            set
            {
                this.applyType = value;
            }
        }
        /// <summary>
        /// 基金
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Fund
        {
            get
            {
                return this.fund;
            }
            set
            {
                this.fund = value;
            }
        }
        /// <summary>
        /// 业务序号
        /// </summary>
        public string BusinessSequence
        {
            get
            {
                return this.businessSequence;
            }
            set
            {
                this.businessSequence = value;
            }
        }
        /// <summary>
        /// 特殊工种
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SpecialWorkKind
        {
            get
            {
                return this.specialWorkKind;
            }
            set
            {
                this.specialWorkKind = value;
            }
        }
        /// <summary>
        /// 医院费用序列号
        /// </summary>
        public string HospitalBusinessSequence
        {
            get
            {
                return this.hospitalBusinessSequence;
            }
            set
            {
                this.hospitalBusinessSequence = value;
            }
        }
        /// <summary>
        /// 对应费用序列号
        /// </summary>
        public string OpositeBusinessSequence
        {
            get
            {
                return this.opositeBusinessSequence;
            }
            set
            {
                this.opositeBusinessSequence = value;
            }
        }

        public new SIMainInfo Clone()
        {
            SIMainInfo obj = base.Clone() as SIMainInfo;
            obj.medicalType = this.medicalType.Clone();
            obj.inDiagnose = this.inDiagnose.Clone();
            obj.operInfo = this.operInfo.Clone();
            obj.PersonType = this.PersonType.Clone();
            obj.CivilianGrade = this.CivilianGrade.Clone();
            obj.SpecialCare = this.SpecialCare.Clone();
            obj.AnotherCity = this.AnotherCity.Clone();
            obj.Corporation = this.Corporation.Clone();
            obj.Disease = this.Disease.Clone();
            obj.ApplyType = this.ApplyType.Clone();
            obj.Fund = this.Fund.Clone();
            obj.SpecialWorkKind = this.SpecialWorkKind.Clone();
            System.Collections.Generic.Dictionary<string, NeuObject> ep = new System.Collections.Generic.Dictionary<string, NeuObject>();
            foreach (string s in this.ExtendProperty.Keys)
            {
                ep.Add(s, this.ExtendProperty[s].Clone());
            }
            obj.ExtendProperty = ep;
            return obj;
        }
        #endregion

        #region 沈阳医保增加属性

        #region 变量

        /// <summary>
        /// 发卡机构编码
        /// </summary>
        private string cardOrgID = string.Empty;

        /// <summary>
        /// 卡有效期
        /// </summary>
        private DateTime cardValidTime = DateTime.MinValue;

        /// <summary>
        /// 变更日期
        /// </summary>
        private DateTime shiftTime = DateTime.MinValue;

        /// <summary>
        /// 是否卡已经锁定
        /// </summary>
        private bool isCardLocked = false;

        /// <summary>
        /// 本年统筹支出累计
        /// </summary>
        private decimal yearPubCost = 0;

        /// <summary>
        /// 本年救助金支出累计
        /// </summary>
        private decimal yearHelpCost = 0;

        /// <summary>
        /// 转出医院起伏标准
        /// </summary>
        private decimal turnOutHosStandardCost = 0;

        /// <summary>
        /// 转出医院起伏标准自付
        /// </summary>
        private decimal turnOutHosOnwCost = 0;

        /// <summary>
        /// 住院次数
        /// </summary>
        private int inHosTimes = 0;

        /// <summary>
        /// 账户支付累计
        /// </summary>
        private decimal payAddCost = 0;

        /// <summary>
        /// 账户支付年度
        /// </summary>
        private string payYear = string.Empty;

        /// <summary>
        /// 现金支付金额累计
        /// </summary>
        private decimal ownCashAddCost = 0;

        /// <summary>
        /// 个人自负(乙类项目)金额累计
        /// </summary>
        private decimal ownAddCost = 0;
        /// <summary>
        /// 年度个人自付累计
        /// </summary>
        private decimal yearOwnAddCost = 0;

        /// <summary>
        /// 公务员支付金额累计
        /// </summary>
        private decimal gwyPayAddCost = 0;

        /// <summary>
        /// 特殊门诊支付累计
        /// </summary>
        private decimal spOutpatientPayAddCost = 0;

        /// <summary>
        /// 门诊慢性病支付累计
        /// </summary>
        private decimal slowOutpatientPayAddCost = 0;
        /// <summary>
        /// 帐户注入累计
        /// </summary>
        private decimal yearAddPayCost = 0;
        /// <summary>
        ///  帐户注入刷新日期
        /// </summary>
        private DateTime freshAddPayDate = DateTime.MinValue;
        /// <summary>
        /// 结转帐户支出累计
        /// </summary>
        private decimal yearAddPayTurnCost = 0;

        #endregion

        #region 属性

        /// <summary>
        /// 发卡机构编码
        /// </summary>
        public string CardOrgID
        {
            get
            {
                return this.cardOrgID;
            }
            set
            {
                this.cardOrgID = value;
            }
        }

        /// <summary>
        /// 卡有效期
        /// </summary>
        public DateTime CardValidTime
        {
            get
            {
                return this.cardValidTime;
            }
            set
            {
                this.cardValidTime = value;
            }
        }

        /// <summary>
        /// 变更日期
        /// </summary>
        public DateTime ShiftTime
        {
            get
            {
                return this.shiftTime;
            }
            set
            {
                this.shiftTime = value;
            }
        }

        /// <summary>
        /// 是否卡已经锁定
        /// </summary>
        public bool IsCardLocked
        {
            get
            {
                return this.isCardLocked;
            }
            set
            {
                this.isCardLocked = value;
            }
        }

        /// <summary>
        /// 本年统筹支出累计
        /// </summary>
        public decimal YearPubCost
        {
            get
            {
                return this.yearPubCost;
            }
            set
            {
                this.yearPubCost = value;
            }
        }

        /// <summary>
        /// 本年救助金支出累计
        /// </summary>
        public decimal YearHelpCost
        {
            get
            {
                return this.yearHelpCost;
            }
            set
            {
                this.yearHelpCost = value;
            }
        }

        /// <summary>
        /// 转出医院起伏标准
        /// </summary>
        public decimal TurnOutHosStandardCost
        {
            get
            {
                return this.turnOutHosStandardCost;
            }
            set
            {
                this.turnOutHosStandardCost = value;
            }
        }

        /// <summary>
        /// 转出医院起伏标准自付
        /// </summary>
        public decimal TurnOutHosOnwCost
        {
            get
            {
                return this.turnOutHosOnwCost;
            }
            set
            {
                this.turnOutHosOnwCost = value;
            }
        }

        /// <summary>
        /// 住院次数
        /// </summary>
        public int InHosTimes
        {
            get
            {
                return this.inHosTimes;
            }
            set
            {
                this.inHosTimes = value;
            }
        }

        /// <summary>
        /// 账户支付累计
        /// </summary>
        public decimal PayAddCost
        {
            get
            {
                return this.payAddCost;
            }
            set
            {
                this.payAddCost = value;
            }
        }

        /// <summary>
        /// 账户支付年度
        /// </summary>
        public string PayYear
        {
            get
            {
                return this.payYear;
            }
            set
            {
                this.payYear = value;
            }
        }

        /// <summary>
        /// 现金支付金额累计
        /// </summary>
        public decimal OwnCashAddCost
        {
            get
            {
                return this.ownCashAddCost;
            }
            set
            {
                this.ownCashAddCost = value;
            }
        }

        /// <summary>
        /// 个人自负(乙类项目)金额累计
        /// </summary>
        public decimal OwnAddCost
        {
            get
            {
                return this.ownAddCost;
            }
            set
            {
                this.ownAddCost = value;
            }
        }
        /// <summary>
        /// 年度个人自付累计
        /// </summary>
        public decimal YearOwnAddCost
        {
            get
            {
                return this.yearAddPayCost;
            }
            set
            {
                this.yearAddPayCost = value;
            }
        }
        /// <summary>
        /// 公务员支付金额累计
        /// </summary>
        public decimal GwyPayAddCost
        {
            get
            {
                return this.gwyPayAddCost;
            }
            set
            {
                this.gwyPayAddCost = value;
            }
        }



        /// <summary>
        /// 特殊门诊支付累计
        /// </summary>
        public decimal SpOutpatientPayAddCost
        {
            get
            {
                return this.spOutpatientPayAddCost;
            }
            set
            {
                this.spOutpatientPayAddCost = value;
            }
        }

        /// <summary>
        /// 门诊慢性病支付累计
        /// </summary>
        public decimal SlowOutpatientPayAddCost
        {
            get
            {
                return this.slowOutpatientPayAddCost;
            }
            set
            {
                this.slowOutpatientPayAddCost = value;
            }
        }
        /// <summary>
        /// 帐户注入累计
        /// </summary>
        public decimal YearAddPayCost
        {
            set
            {
                this.yearAddPayCost = value;
            }
            get
            {
                return this.yearAddPayCost;
            }
        }
        /// <summary>
        /// 帐户注入刷新日期
        /// </summary>
        public DateTime FreshAddPayDate
        {
            set
            {
                this.freshAddPayDate = value;
            }
            get
            {
                return this.freshAddPayDate;
            }
        }
        /// <summary>
        /// 结转帐户支出累计
        /// </summary>
        public decimal YearAddPayTurnCost
        {
            set
            {
                this.yearAddPayCost = value;
            }
            get
            {
                return this.yearAddPayCost;
            }

        }
        /// <summary>
        /// 是否公务员
        /// </summary>
        private bool isOffice = false;
        /// <summary>
        /// 是否公务员
        /// </summary>
        public bool IsOffice
        {
            set
            {
                this.isOffice = value;
            }
            get
            {
                return this.isOffice;
            }

        }

        /// <summary>
        /// 医保住院状态
        /// </summary>
        private string inStateForYB = string.Empty;
        /// <summary>
        /// 医保住院状态
        /// </summary>
        public String InStateForYB
        {
            set
            {
                this.inStateForYB = value;
            }
            get
            {
                return this.inStateForYB;
            }
        }
        /// <summary>
        /// 出生地
        /// </summary>
        private string birthPlace = string.Empty;
        /// <summary>
        /// 出生地
        /// </summary>
        public string BirthPlace
        {
            set
            {
                this.birthPlace = value;
            }
            get
            {
                return this.birthPlace;
            }
        }
        /// <summary>
        /// 离院日期
        /// </summary>
        private DateTime leaveHosDate = DateTime.MinValue;
        /// <summary>
        /// 离院日期
        /// </summary>
        public DateTime LeaveHosDate
        {
            set
            {
                this.leaveHosDate = value;
            }
            get
            {
                return this.leaveHosDate;
            }
        }
        /// <summary>
        /// 家庭病床支出累计
        /// </summary>
        private decimal homeBedFeeAddCost = 0;
        /// <summary>
        /// 家庭病床支出累计
        /// </summary>
        public decimal HomeBedFeeAddCost
        {
            set
            {
                this.homeBedFeeAddCost = value;
            }
            get
            {
                return this.homeBedFeeAddCost;
            }
        }
        /// <summary>
        /// 超过最高限额公务员补助支出累计(26) 
        /// </summary>
        private decimal gwyBeyondPayAddCost = 0;
        /// <summary>
        /// 超过最高限额公务员补助支出累计(26) 
        /// </summary>
        public decimal GwyBeyondPayAddCost
        {
            get
            {
                return this.gwyBeyondPayAddCost;
            }
            set
            {
                this.gwyBeyondPayAddCost = value;
            }
        }
        /// <summary>
        /// 离休统筹支出累计
        /// </summary>
        private decimal lxAddPubCost = 0;
        /// <summary>
        /// 离休统筹支出累计
        /// </summary>
        public decimal LxAddPubCost
        {
            set
            {
                this.lxAddPubCost = value;
            }
            get
            {
                return this.lxAddPubCost;
            }
        }
        /// <summary>
        /// 门诊现金支出累计
        /// </summary>
        private decimal cashAddCostForMZ = 0;
        /// <summary>
        /// 门诊现金支出累计
        /// </summary>
        public decimal CashAddCostForMZ
        {
            set
            {
                this.cashAddCostForMZ = value;
            }
            get
            {
                return this.cashAddCostForMZ;
            }
        }
        /// <summary>
        /// 门诊公务员补助支出累计
        /// </summary>

        private decimal officalSupplyCostForMZ = 0;
        /// <summary>
        /// 门诊公务员补助支出累计
        /// </summary>
        public decimal OfficalSupplyCostForMZ
        {
            set
            {
                this.officalSupplyCostForMZ = value;
            }
            get
            {
                return this.officalSupplyCostForMZ;
            }
        }
        /// <summary>
        /// 生育保险是否最后结算标志
        /// </summary>
        private bool proceateLastFlag = false;
        /// <summary>
        /// 生育保险是否最后结算标志
        /// </summary>
        public bool ProceateLastFlag
        {
            get
            {
                return proceateLastFlag;
            }
            set
            {
                proceateLastFlag = value;
            }
        }
        /// <summary>
        /// 大额补助
        /// </summary>
        private decimal overCost = 0;
        /// <summary>
        /// 大额补助
        /// </summary>
        public decimal OverCost
        {
            set
            {
                this.overCost = value;
            }
            get
            {
                return this.overCost;
            }
        }

        /// <summary>
        /// 公务员补助支付
        /// </summary>
        private decimal officalCost = 0;
        /// <summary>
        /// 公务员补助支付
        /// </summary>
        public decimal OfficalCost
        {
            set
            {
                this.officalCost = value;
            }
            get
            {
                return this.officalCost;
            }
        }


        //private string reimbFlag = string.Empty;
        //public string ReimbFlag
        //{
        //    set
        //    {
        //        this.reimbFlag = value;
        //    }
        //    get
        //    {
        //        return this.reimbFlag;
        //    }
        //}

        //private int transType = 0;
        //public int TransType
        //{
        //    set
        //    {
        //        this.transType = value;
        //    }
        //    get
        //    {
        //        return this.transType;
        //    }
        //}

        #endregion

        #endregion
    }
}
