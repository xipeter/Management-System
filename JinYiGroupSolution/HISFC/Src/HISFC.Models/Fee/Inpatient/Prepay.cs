using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// Prepay<br></br>
	/// [功能描述: 住院预交金类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Prepay : NeuObject
	{
		
		#region 变量
		
		/// <summary>
		/// 人员基本信息
		/// </summary>
		private PatientInfo patient = new PatientInfo();

		/// <summary>
		/// 预交金票据号
		/// </summary>
		private string recipeNO = string.Empty;

		/// <summary>
		/// 费用信息 包含预交金费用等
		/// </summary>
		private FT ft = new FT();
		
		/// <summary>
        /// 付费方式{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
		/// </summary>
        //private EnumPayTypeService payType = new EnumPayTypeService();
        private NeuObject payType = new NeuObject();
	
		/// <summary>
		///结算发票号 
		/// </summary>
		private Invoice invoice = new Invoice();
		
		/// <summary>
		/// 统计日期
		/// </summary>
		private DateTime staticTime;
		
		/// <summary>
		/// 结算日期
		/// </summary>
		private DateTime balanceTime;
		
		/// <summary>
		/// 结算员代码
		/// </summary>
		private OperEnvironment balanceOper = new OperEnvironment ();
		
		/// <summary>
		/// 结算状态
		/// </summary>
		private string balanceState = string.Empty;
		
		/// <summary>
		/// 结算序号
		/// </summary>
		private int balanceNO;
		
		/// <summary>
		/// 预交金状态
		/// </summary>
		private string prepayState = string.Empty;
		
		/// <summary>
		/// 开户银行
		/// </summary>
		private Bank bank = new Bank();
		
		/// <summary>
		/// 是否上缴
		/// </summary>
		private bool isTurnIn;

		/// <summary>
		/// 财务组代码
		/// </summary>
		private FinanceGroup finGroup = new FinanceGroup();
		
		/// <summary>
		/// 转押金状态 0非转押金，1转押金，2转押金已打印
		/// </summary>
		private string transferPrepayState = string.Empty;

		/// <summary>
		/// 转押金时间
		/// </summary>
		private DateTime transferPrepayTime;
		
		/// <summary>
		/// 原发票信息
		/// </summary>
		private Invoice orgInvoice = new Invoice();
		
		/// <summary>
		/// 财务审核序号
		/// </summary>
		private string auditingNO = string.Empty;
		
		/// <summary>
		/// 转押金操作信息
		/// </summary>
		private OperEnvironment transferPrepayOper = new OperEnvironment();
		
		/// <summary>
		/// 预交金操作信息
		/// </summary>
		private OperEnvironment prepayOper =  new OperEnvironment();
		
		/// <summary>
		/// 转押金时结算序号 
		/// </summary>
		private int transferPrepayBalanceNO;

        /// <summary>
        /// 区分正常收取和结算召回生成数据 正常收取 1 结算召回 2
        /// </summary>
        private string prepaySourceState ="1";

		#endregion
		
		#region 属性
		
		/// <summary>
		/// 人员基本信息
		/// </summary>
		public PatientInfo Patient
		{
			get
			{
				return this.patient;
			}
			set
			{
				this.patient = value;
			}
		}

		/// <summary>
		/// 预交金票据号
		/// </summary>
		public string RecipeNO
		{
			get
			{
				return this.recipeNO;
			}
			set
			{
				this.recipeNO = value;
			}
		}
		
		/// <summary>
		/// 费用信息 包含预交金费用等
		/// </summary>
		public FT FT
		{
			get
			{
				return this.ft;
			}
			set
			{
				this.ft = value;
			}
		}
		
		/// <summary>
        /// 付费方式{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
		/// </summary>
		//public EnumPayTypeService PayType
        public NeuObject PayType
		{
			get
			{
				return this.payType;
			}
			set
			{
				this.payType = value;
			}
		}
	
		/// <summary>
		/// 结算发票号
		/// </summary>
		public Invoice Invoice
		{
			get
			{
				return this.invoice;
			}
			set
			{
				this.invoice = value;
			}
		}

		/// <summary>
		/// 统计日期
		/// </summary>
		public DateTime StaticTime
		{
			get
			{
				return this.staticTime;
			}
			set
			{
				this.staticTime = value;
			}
		}
		
		/// <summary>
		/// 结算日期
		/// </summary>
        [Obsolete("无用,用BalanceOper.OperTime代替", true)]
		public DateTime BalanceTime
		{
			get
			{
				return this.balanceTime;
			}
			set
			{
				this.balanceTime = value;
			}
		}
		
		/// <summary>
		/// 结算员代码
		/// </summary>
		public OperEnvironment BalanceOper
		{
			get
			{
				return this.balanceOper;
			}
			set
			{
				this.balanceOper = value;
			}
		}
		
		/// <summary>
		/// 结算状态
		/// </summary>
		public string BalanceState
		{
			get
			{
				return this.balanceState;
			}
			set
			{
				this.balanceState = value;
			}
		}
		
		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceNO
		{
			get
			{
				return this.balanceNO;
			}
			set
			{
				this.balanceNO = value;
			}
		}
		
		/// <summary>
		/// 预交金状态
		/// </summary>
		public string PrepayState
		{
			get
			{
				return this.prepayState;
			}
			set
			{
				this.prepayState = value;
			}
		}
		
		/// <summary>
		/// 开户银行
		/// </summary>
		public Bank Bank
		{
			get
			{
				return this.bank;
			}
			set
			{
				this.bank = value;
			}
		}
		
		/// <summary>
		/// 是否上缴
		/// </summary>
		public bool IsTurnIn
		{
			get
			{
				return this.isTurnIn;
			}
			set
			{
				this.isTurnIn = value;
			}
		}
		
		/// <summary>
		/// 财务组代码
		/// </summary>
		public FinanceGroup FinGroup
		{
			get
			{
				return this.finGroup;
			}
			set
			{
				this.finGroup = value;
			}
		}
		
		/// <summary>
		/// 转押金状态 0非转押金，1转押金，2转押金已打印
		/// </summary>
		public string TransferPrepayState
		{
			get
			{
				return this.transferPrepayState;
			}
			set
			{
				this.transferPrepayState = value;
			}
		}
		
		/// <summary>
		/// 转押金时间
		/// </summary>
		public DateTime TransferPrepayTime
		{
			get
			{
				return this.transferPrepayTime;
			}
			set
			{
				this.transferPrepayTime = value;
			}
		}
		
		/// <summary>
		/// 原发票信息
		/// </summary>
		public Invoice OrgInvoice
		{
			get
			{
				return this.orgInvoice;
			}
			set
			{
				this.orgInvoice = value;
			}
		}
		
		/// <summary>
		/// 财务审核序号
		/// </summary>
		public string AuditingNO
		{
		
			get
			{
				return this.auditingNO;
			}
			set
			{
				this.auditingNO = value;
			}
		}
		
		/// <summary>
		/// 转押金操作信息
		/// </summary>
		public OperEnvironment TransferPrepayOper
		{
			get
			{
				return this.transferPrepayOper;
			}
			set
			{
				this.transferPrepayOper = value;
			}
		}
		
		/// <summary>
		/// 预交金操作信息
		/// </summary>
		public OperEnvironment PrepayOper
		{
			get
			{
				return this.prepayOper;
			}
			set
			{
				this.prepayOper = value;
			}
			
		}
		
		/// <summary>
		/// 转押金时结算序号 
		/// </summary>
		public int TransferPrepayBalanceNO
		{
			get
			{
				return this.transferPrepayBalanceNO;
			}
			set
			{
				this.transferPrepayBalanceNO = value;
			}
		}

        /// <summary>
        /// 区分正常收取和结算召回生成数据 正常收取 1 结算召回 2
        /// </summary>
        public string PrepaySourceState 
        {
            get 
            {
                return this.prepaySourceState;
            }
            set
            {
                this.prepaySourceState = value;
            }
        }

		#endregion 

		#region 无用
		
		/// <summary>
		/// 患者科室
		/// </summary>
		[Obsolete("无用,用Patient中的科室属性代替", true)]
		public Department PatientDept
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		
		/// <summary>
		///  预交金额
		/// </summary>
		[Obsolete("无用,用FT属性费用代替", true)]
		public decimal Pre_Cost;
		/// <summary>
		/// 患者科室
		/// </summary>
		//Neusoft.HISFC.Models.Base.Department
		public NeuObject Dept=new NeuObject();
		
		/// <summary>
		/// 结算发票号
		/// </summary>
		[Obsolete("无用,用Invoice类属性的ID代替", true)]
		public string InvoiceNo;

		/// <summary>
		/// 统计日期
		/// </summary>
		[Obsolete("无用,用StaticTime属性代替", true)]
		public DateTime StatisticDate;
		/// <summary>
		/// 结算日期
		/// </summary>
		[Obsolete("无用,用BalanceTime属性代替", true)]
		public DateTime DtBalanceDate;
		/// <summary>
		/// 结算状态
		/// </summary>
		[Obsolete("无用,用BalanceState属性代替", true)]
		public string BalanceStatus;
		/// <summary>
		/// 结算序号
		/// </summary>\
		[Obsolete("无用,用BalanceNO属性代替", true)]
		public int BalanceSequece;
		/// <summary>
		/// 开户银行
		/// </summary>
		[Obsolete("无用,用Bank属性代替", true)]
		public Neusoft.HISFC.Models.Base.Bank AccountBank=new Neusoft.HISFC.Models.Base.Bank();
		/// <summary>
		/// 是否上缴
		/// </summary>
		[Obsolete("无用,用IsTurnIn属性代替", true)]
		public bool IsReport;
		/// <summary>
		/// 财务组代码
		/// </summary>
		//Fee.FinanceGroup
		[Obsolete("无用,用FinGroup属性代替", true)]
		public NeuObject FinGrpCode = new NeuObject();
		/// <summary>
		/// 转押金状态 0非转押金，1转押金，2转押金已打印
		/// </summary>
		[Obsolete("无用,用TransferPrepayState属性代替", true)]
		public string  TransPrepayState;
		/// <summary>
		/// 转押金时间
		/// </summary>
		[Obsolete("无用,用TransferPrepayTime属性代替", true)]
		public DateTime DtTransPrepay;
		/// <summary>
		/// 预交金发票号
		/// </summary>
		[Obsolete("无用,用Invoice.ID代替", true)]
		public string ReceiptNo;
		/// <summary>
		/// 原发票号
		/// </summary>
		[Obsolete("无用,用OrgInvoice.ID代替", true)]
		public string OldReceiptNo;
        /// <summary>
		/// 财务审核序号
		/// </summary>
		[Obsolete("无用,用AuditingNO代替", true)]
		public string CheckNo;
		/// <summary>
		/// 转押金操作员
		/// </summary>
		//OperEnvironment
		public NeuObject TransPrepayOper = new NeuObject();
		/// <summary>
		/// 操作员科室
		/// </summary>
		[Obsolete("无用",true)]
		public NeuObject OperDept = new NeuObject();
		/// <summary>
		/// 预交金操作时间
		/// </summary>
		[Obsolete("无用,用PrepayOper.OperTime代替", true)]
		public DateTime DtOperate;
		/// <summary>
		/// 转押金时结算序号 
		/// </summary>
		[Obsolete("无用,用TransferPrepayBalanceNO代替", true)]
		public int ChangeBalanceNo;
		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Prepay Clone()
		{
			Prepay prepay = base.Clone() as Prepay;

			prepay.FT = this.FT.Clone();
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //prepay.payType = this.PayType.Clone()as EnumPayTypeService;
            prepay.PayType = this.PayType.Clone();
			prepay.Invoice = this.Invoice.Clone();
			prepay.BalanceOper = this.BalanceOper.Clone();
			prepay.Bank = this.Bank.Clone();
			prepay.FinGroup = this.FinGroup.Clone();
			prepay.OrgInvoice = this.OrgInvoice.Clone();
			prepay.TransferPrepayOper = this.TransferPrepayOper.Clone();
			prepay.PrepayOper = this.PrepayOper.Clone();

			return prepay;
		}

		#endregion

		#endregion
		
	}
}