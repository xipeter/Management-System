using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Registration
{
    /// <summary>
    /// Register<br></br>
    /// [功能描述: 挂号信息实体]<br></br>
    /// [创 建 者: 黄小卫]<br></br>
    /// [创建时间: 2007-2-1]<br></br>
    /// <修改记录
    ///		修改人='王宇'
    ///		修改时间='2007-03-8'
    ///		修改目的='聚合增加患者优惠情况实体'
    ///		修改描述=''
    ///  />
    /// </summary>
    /// </summary>
    /// <修改记录
    ///		修改人='周雪松'
    ///		修改时间='2007-10-22'
    ///		修改目的='聚合患者访问类'
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Register : Patient
	{
        /// <summary>
        /// 
        /// </summary>
		public Register()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			// 
        }

        #region 变量

        /// <summary>
        /// 证件类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject cardType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 患者来源
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inSource = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 交易类型
        /// </summary>
        private TransTypes tranType = TransTypes.Positive;

        /// <summary>
        /// 看诊信息
        /// </summary>
        private Schema doctor = new Schema();

        /// <summary>
        /// 每日流水号
        /// </summary>
        private int orderNO = 0;        

        /// <summary>
        /// 挂号费
        /// </summary>
		private RegLvlFee regLvlFee = new RegLvlFee();

        /// <summary>
        /// 自费
        /// </summary>
        private decimal ownCost = 0m;
        /// <summary>
        /// 自负
        /// </summary>
        private decimal payCost = 0m;
        /// <summary>
        /// 记帐
        /// </summary>
        private decimal pubCost = 0m;

        /// <summary>
        /// 是否急诊
        /// </summary>
        private bool isEmergency = false;

        /// <summary>
        /// 是否收费
        /// </summary>
        private bool isFee = false;

        /// <summary>
        /// 挂号类别
        /// </summary>
        private EnumRegType regType = EnumRegType.Reg;

        /// <summary>
        /// 是否初诊
        /// </summary>
        private bool isFirst = true;

        /// <summary>
        /// 是否看诊
        /// </summary>
        private bool isSee = false;

        /// <summary>
        /// 挂号状态
        /// </summary>
        private EnumRegisterStatus status = EnumRegisterStatus.Valid;

        /// <summary>
        /// 发票号/处方号
        /// </summary>
        private string invoiceNO = "";
        /// <summary>
        /// 处方号 by niuxinyuan  2007-05-15
        /// </summary>
        private string recipeNO = "";

        /// <summary>
        /// 已打印发票数量
        /// </summary>
        private int printInvoiceCnt = 0;

        /// <summary>
        /// 录入人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment inputOper = new OperEnvironment();

        /// <summary>
        /// 作废人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment cancelOper = new OperEnvironment();

        /// <summary>
        /// 日结算操作信息
        /// </summary>
        private OperStat balanceOperStat = new OperStat();

        /// <summary>
        /// 核查日结操作信息
        /// </summary>
        private OperStat checkOperStat = new OperStat();        

        /// <summary>
        /// 是否分诊
        /// </summary>
        private bool isTriage = false;
                
        /// <summary>
        /// 分诊操作员环境变量
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment triageOper = new OperEnvironment();

        /// <summary>
        /// 门诊患者优惠情况
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Outpatient.EcoRate ecoRate = new Neusoft.HISFC.Models.Fee.Outpatient.EcoRate();
        ///// <summary>
        /////是向病案室去传递病案标记
        ///// </summary>
        //private bool isSendInhosCase;
        /// <summary>
        /// 看诊科室
        /// </summary>
        private string seeDPCD;
        /// <summary>
        /// 看诊医生
        /// </summary>
        private string seeDOCD;
        /// <summary>
        /// 患者访问类
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PVisit pVisit = new Neusoft.HISFC.Models.RADT.PVisit();

        /// <summary>
        /// 优惠金额{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
        /// </summary>
        private decimal ecoCost = 0m;

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 是否是账户流程挂号
        /// </summary>
        private bool isAccount = false;

        /// <summary>
        /// 收款员每日顺序号{543BD236-C9BD-4c92-A4EA-DC2EEBDF1317}
        /// </summary>
        private string operSeq;

        /// <summary>
        /// 账户账号
        /// </summary>
        private string accountNO = string.Empty;


        #endregion
             
        #region 属性

        /// <summary>
        /// 门诊患者优惠情况
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Outpatient.EcoRate EcoRate 
        {
            get 
            {
                return this.ecoRate;
            }
            set 
            {
                this.ecoRate = value;
            }
        }

        /// <summary>
        /// 证件类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CardType
        {
            get { return this.cardType; }
            set { this.cardType = value; }
        }

        /// <summary>
        /// 患者来源
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InSource
        {
            get { return this.inSource; }
            set { this.inSource = value; }
        }

        ///<summary>
        ///交易类型
        ///</summary>
        public TransTypes TranType
        {
            get { return tranType; }
            set { tranType = value; }
        }

        /// <summary>
        /// 看诊信息
        /// </summary>
        public Schema DoctorInfo
        {
            get { return this.doctor; }
            set { this.doctor = value; }
        }

        /// <summary>
        /// 每日流水号
        /// </summary>
        public int OrderNO
        {
            get { return orderNO; }
            set { orderNO = value; }
        }       

        /// <summary>
        /// 挂号费
        /// </summary>
        public RegLvlFee RegLvlFee
        {
            get { return regLvlFee; }
            set { regLvlFee = value; }
        }

        /// <summary>
        /// 自费
        /// </summary>
        public decimal OwnCost
        {
            get { return this.ownCost; }
            set { this.ownCost = value; }
        }

        /// <summary>
        /// 自负
        /// </summary>
        public decimal PayCost
        {
            get { return this.payCost; }
            set { this.payCost = value; }
        }

        /// <summary>
        /// 记帐
        /// </summary>
        public decimal PubCost
        {
            get { return this.pubCost; }
            set { this.pubCost = value; }
        }

        /// <summary>
        /// 是否急诊
        /// </summary>
        public bool IsEmergency
        {
            get { return isEmergency; }
            set { isEmergency = value; }
        }

        /// <summary>
        /// 是否收费
        /// </summary>
        public bool IsFee
        {
            get { return isFee; }
            set { isFee = value; }
        }

        /// <summary>
        /// 挂号类别
        /// </summary>
        public EnumRegType RegType
        {
            get { return this.regType; }
            set { this.regType = value; }
        }

        /// <summary>
        /// 是否初诊
        /// </summary>
        public bool IsFirst
        {
            get { return isFirst; }
            set { isFirst = value; }
        }   

        /// <summary>
        /// 是否看诊
        /// </summary>
        public bool IsSee
        {
            get { return isSee; }
            set { isSee = value; }
        }

        /// <summary>
        /// 挂号状态
        /// </summary>
        public EnumRegisterStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        /// <summary>
        /// 发票号/处方号
        /// </summary>
        public string InvoiceNO
        {
            get { return this.invoiceNO; }
            set { this.invoiceNO = value; }
        }

        /// <summary>
        /// 发票号/处方号
        /// </summary>
        public string RecipeNO
        {
            get { return this.recipeNO; }
            set { this.recipeNO = value; }
        }

        /// <summary>
        /// 已打印发票次数
        /// </summary>
        public int PrintInvoiceCnt
        {
            get { return this.printInvoiceCnt; }
            set { this.printInvoiceCnt = value; }
        }

        /// <summary>
        /// 挂号操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InputOper
        {
            get { return inputOper; }
            set { inputOper = value; }
        }

        /// <summary>
        /// 作废操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CancelOper
        {
            get { return cancelOper; }
            set { cancelOper = value; }
        }

        /// <summary>
        /// 日结核查操作信息
        /// </summary>
        public OperStat CheckOperStat
        {
            get { return checkOperStat; }
            set { checkOperStat = value; }
        }

        /// <summary>
        /// 日结算操作信息
        /// </summary>
        public OperStat BalanceOperStat
        {
            get { return balanceOperStat; }
            set { balanceOperStat = value; }
        }

        /// <summary>
        /// 是否分诊
        /// </summary>
        public bool IsTriage
        {
            get { return this.isTriage; }
            set { this.isTriage = value; }
        }

        /// <summary>
        /// 分诊人
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment TriageOper
        {
            get { return this.triageOper; }
            set { this.triageOper = value; }
        }

        //----------------------------------------------------------可自行在下面添加

        /// <summary>
        /// 医疗类别
        /// </summary>        
        public string MedicalType = "";

        /// <summary>
        /// 体检类型, 团体、个人
        /// </summary>        
        public string ChkKind = "";

        /// <summary>
        /// 医保登记信息
        /// </summary>
        private Neusoft.HISFC.Models.SIInterface.SIMainInfo siInfo = new Neusoft.HISFC.Models.SIInterface.SIMainInfo();

        /// <summary>
        /// 医保登记信息
        /// </summary>
        public Neusoft.HISFC.Models.SIInterface.SIMainInfo SIMainInfo
        {
            get
            {
                return siInfo;
            }
            set
            {
                siInfo = value;
            }
        }
        ///// <summary>
        ///// 是向病案室去传递病案标记
        ///// by niuxinyuan
        ///// </summary>
        //public bool IsSentInhosCase
        //{
        //    get 
        //    {
        //        return this.isSendInhosCase;
        //    }
        //    set
        //    {
        //        this.isSendInhosCase = value;
        //    }
        //}
        /// <summary>
        /// 看诊科室代码
        /// </summary>
        public string SeeDPCD
        {
            set 
            {
                this.seeDPCD = value;
            }
            get
            {
                return this.seeDPCD;
            }
        }
        /// <summary>
        /// 看诊医生代码
        /// </summary>
        public string SeeDOCD
        {
            set 
            {
                this.seeDOCD = value;
            }
            get
            {
                return this.seeDOCD;
            }
        }
        /// <summary>
        /// 患者访问类
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PVisit PVisit
        {
            get { return pVisit; }
            set { pVisit = value; }
        }

       

        /// <summary>
        /// 优惠金额{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
        /// </summary>
        public decimal EcoCost
        {
            get { return ecoCost; }
            set { ecoCost = value; }
        }

        ////{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 是否是账户流程挂号
        /// </summary>
        public bool IsAccount
        {
            get
            {
                return this.isAccount;
            }
            set
            {
                isAccount = value;

            }
        }

        /// <summary>
        /// 收款员每日顺序号{543BD236-C9BD-4c92-A4EA-DC2EEBDF1317}
        /// </summary>
        public string OperSeq
        {
            get
            {
                return operSeq;
            }
            set
            {
                operSeq = value;
            }
        }

        /// <summary>
        /// 账户账号
        /// </summary>
        public string AccountNO
        {
            get { return accountNO; }
            set { accountNO = value; }
        }
        #endregion

        #region 方法
        ///// <summary>
        /////  挂号的副本
        ///// </summary>
        ///// <returns></returns>
        public new Register Clone()
        {
            Register reg = base.Clone() as Register;

            reg.CardType = this.cardType.Clone();
            reg.InSource = this.inSource.Clone();
            reg.DoctorInfo = this.doctor.Clone();
            reg.regLvlFee = this.regLvlFee.Clone();
                        
            reg.InputOper = this.inputOper.Clone();
            reg.CancelOper = this.cancelOper.Clone();
            reg.BalanceOperStat = this.balanceOperStat.Clone();
            reg.CheckOperStat = this.checkOperStat.Clone();
            reg.TriageOper = this.triageOper.Clone();
            reg.PVisit = this.pVisit.Clone();

            return reg;
        }
        #endregion

        #region  作废
		
        /// <summary>
		/// 病历号
		/// </summary>
		[Obsolete("更改为：PID.CardNO",true)]
        public string CardNo;
		
        /// <summary>
		/// 身份证号
		/// </summary>
        [Obsolete("更改为:IDCard",true)]
		public string IdenNo;
		        
		/// <summary>
		/// 性别代码
		/// </summary>
		[Obsolete("更改为：Sex.ID",true)]
        public string SexID;
		
		/// <summary>
		/// 联系电话
		/// </summary>
        [Obsolete("更改为：PhoneHome",true)]
		public string Phone;
		
        /// <summary>
		/// 地址
		/// </summary>
        [Obsolete("更改为：AddressHome", true)]
        public string Address;	        

        /// <summary>
        /// 挂号日期
        /// </summary>
        [Obsolete("更改为:DoctorInfo.SeeDate",true)]
        public DateTime RegDate = DateTime.MaxValue;

        /// <summary>
        /// 午别
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.Noon.ID",true)]
        public string Noon = "";

        /// <summary>
        /// 开始时间
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.Begin",true)]
        public DateTime BeginTime = DateTime.MinValue;

        /// <summary>
        /// 结束时间
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.End",true)]
        public DateTime EndTime = DateTime.MinValue;

        /// <summary>
        /// 结算类别
        /// </summary>
        [Obsolete("更改为：Pact.PayKind",true)]
        public Neusoft.FrameWork.Models.NeuObject PayKind;

        /// <summary>
        /// 挂号级别
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.RegLevel",true)]
        public Neusoft.FrameWork.Models.NeuObject RegLevel;

        /// <summary>
        /// 挂号科室
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.Dept",true)]
        public Neusoft.FrameWork.Models.NeuObject RegDept;

        /// <summary>
        /// 看诊医生
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.Doct", true)]
        public Neusoft.FrameWork.Models.NeuObject RegDoct;

        /// <summary>
        /// 看诊序号
        /// </summary>
        [Obsolete("更改为：DoctorInfo.SeeNO",true)]
        public int SeeID;

        /// <summary>
        /// 排班序号
        /// </summary>
        [Obsolete("更改为：DoctorInfo.ID",true)]
        public string SchemaNo;

        /// <summary>
        /// 是否加号
        /// </summary>
        [Obsolete("更改为：DoctorInfo.Templet.IsAppend",true)]
        public bool IsAppend;

        /// <summary>
		/// 挂号费
		/// </summary>
		[Obsolete("更改为：RegLvlFee.RegFee",true)]
        public decimal RegFee;

		/// <summary>
		/// 检查费
		/// </summary>
        [Obsolete("更改为：RegLvlFee.ChkFee",true)]
		public decimal ChkFee;

		/// <summary>
		/// 诊察费
		/// </summary>
		[Obsolete("更改为：RegLvlFee.OwnDigFee",true)]
        public decimal DigFee;

		/// <summary>
		/// 其他费
		/// </summary>
		[Obsolete("更改为：RegLvlFee.OthFee",true)]
        public decimal OthFee;

        /// <summary>
        /// 是否急诊
        /// </summary>
        [Obsolete("更改为：IsEmergency", true)]
        public bool IsUrg;

        /// <summary>
        /// 是否有效
        /// </summary>
        [Obsolete("更改为：Status",true)]
        public bool IsValid;

        /// <summary>
        /// 挂号类别
        /// </summary>
        [Obsolete("更改为：RegType", true)]
        public bool IsPre;
        
        /// <summary>
        /// 医疗证号
        /// </summary>
        [Obsolete("更改为：SSN", true)]
        public string McardID; 
        #endregion      
    }
}
