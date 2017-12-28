using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Fee 
{
	/// <summary>
	/// BalanceBase<br></br>
	/// [功能描述: 费用结算抽象类 ID:患者流水号 Name:患者姓名]<br></br>
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
	public abstract class BalanceBase : NeuObject
	{
		#region 变量
		
		/// <summary>
		/// 交易类型 Positive 正交易 Negative 负交易
		/// </summary>
		private TransTypes transType;
		
		/// <summary>
		/// 结算类型
		/// </summary>
		private BalanceTypeEnumService balanceType = new BalanceTypeEnumService();
		
		/// <summary>
		/// 患者基本信息
		/// </summary>
		private Patient patient = new Patient();
		
		/// <summary>
		/// 发票信息
		/// </summary>
		private Invoice invoice = new Invoice();
		
		/// <summary>
		/// 财务组
		/// </summary>
		private FinanceGroup financeGroup = new FinanceGroup();
		
		/// <summary>
		/// 操作环境(具体操作员,操作时间)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();
		
		/// <summary>
		/// 结算操作环境(具体结算操作员,结算时间)
		/// </summary>
		private OperEnvironment balanceOper = new OperEnvironment();
		
		/// <summary>
		/// 审核操作环境(审核操作员,审核时间)
		/// </summary>
		private OperEnvironment auditingOper = new OperEnvironment();
		
		/// <summary>
		/// 作废操作环境(作废操作员,操作时间)
		/// </summary>
		private OperEnvironment cancelOper = new OperEnvironment();
		
		/// <summary>
		/// 发票状态
		/// </summary>
		private CancelTypes cancelType;
		
		/// <summary>
		/// 作废票据号
		/// </summary>
		private string canceledInvoiceNO;
		
		/// <summary>
		/// 是否审核
		/// </summary>
		private bool isAuditing;
		
		/// <summary>
		/// 是否日结
		/// </summary>
		private bool isDayBalanced;
		
		/// <summary>
		/// 日结操作环境(日结人,日结时间)
		/// </summary>
		private OperEnvironment dayBalanceOper = new OperEnvironment();
		
		/// <summary>
		/// 发票打印日期
		/// </summary>
		private DateTime printTime;
		
		/// <summary>
		/// 费用信息
		/// </summary>
		private FT ft = new FT();
		
		/// <summary>
		/// 发票的费用类别 1 自费 2 记帐 3 特殊
		/// </summary>
		private NeuObject invoiceType = new NeuObject();

		#endregion
		
		#region 属性

		/// <summary>
		/// 交易类型 Positive 正交易 Negative 负交易
		/// </summary>
		public TransTypes TransType
		{
			get
			{
				return this.transType;
			}
			set
			{
				this.transType = value;
			}
		}

		/// <summary>
		/// 结算类型
		/// </summary>
		public BalanceTypeEnumService BalanceType 
        {
			get
			{
				return this.balanceType;
			}
			set
			{
				this.balanceType = value;
			}
		}

		/// <summary>
		/// 发票信息
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
		/// 患者基本信息
		/// </summary>
		public Patient Patient
		{
			get
			{
				return this.patient;
			}
			set
			{
				this.patient = value;
				
				if (this.patient != null)
				{
					this.Name = this.patient.Name;
				}
			}
		}
		
		/// <summary>
		/// 财务组
		/// </summary>
		public FinanceGroup FinanceGroup
		{
			get
			{
				return this.financeGroup;
			}
			set
			{
				this.financeGroup = value;
			}
		}
		
		/// <summary>
		/// 操作环境(具体操作员,操作时间)
		/// </summary>
		public OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}
		
		/// <summary>
		/// 结算操作环境(具体结算操作员,结算时间)
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
		/// 审核操作环境(审核操作员,审核时间)
		/// </summary>
		public OperEnvironment AuditingOper
		{
			get
			{
				return this.auditingOper;
			}
			set
			{
				this.auditingOper = value;
			}
		}
		
		/// <summary>
		/// 作废操作环境(作废操作员,操作时间)
		/// </summary>
		public OperEnvironment CancelOper
		{
			get
			{
				return this.cancelOper;
			}
			set
			{
				this.cancelOper = value;
			}
		}

		/// <summary>
		/// 发票状态
		/// </summary>
		public CancelTypes CancelType
		{
			get
			{
				return this.cancelType;
			}
			set
			{
				this.cancelType = value;
			}
		}
		
		/// <summary>
		/// 作废票据号
		/// </summary>
		public string CanceledInvoiceNO
		{
			get
			{
				return this.canceledInvoiceNO;
			}
			set
			{
				this.canceledInvoiceNO = value;
			}
		}

		/// <summary>
		/// 是否审核
		/// </summary>
		public bool IsAuditing
		{
			get
			{
				return this.isAuditing;
			}
			set
			{
				this.isAuditing = value;
			}
		}

		/// <summary>
		/// 是否日结
		/// </summary>
		public bool IsDayBalanced
		{
			get
			{
				return this.isDayBalanced;
			}
			set
			{
				this.isDayBalanced = value;
			}
		}
		
		/// <summary>
		/// 日结操作环境(日结人,日结时间)
		/// </summary>
		public OperEnvironment DayBalanceOper
		{
			get
			{
				return this.dayBalanceOper;
			}
			set
			{
				this.dayBalanceOper = value;
			}
		}

		/// <summary>
		/// 发票打印日期
		/// </summary>
		public DateTime PrintTime
		{
			get
			{
				return this.printTime;
			}
			set
			{
				this.printTime = value;
			}
		}

		/// <summary>
		/// 费用信息
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
		/// 发票的费用类别 1 自费 2 记帐 3 特殊
		/// </summary>
		public NeuObject InvoiceType
		{
			get
			{
				return this.invoiceType;
			}
			set
			{
				this.invoiceType = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例副本</returns>
		public new BalanceBase Clone()
		{
			BalanceBase balanceBase = base.Clone() as BalanceBase;
			
			balanceBase.AuditingOper = this.AuditingOper.Clone();
			balanceBase.BalanceOper = this.BalanceOper.Clone();
			balanceBase.CancelOper = this.CancelOper.Clone();
			balanceBase.DayBalanceOper = this.DayBalanceOper.Clone();
			balanceBase.FinanceGroup = this.FinanceGroup.Clone();
			balanceBase.FT = this.FT.Clone();
			balanceBase.Invoice = this.Invoice.Clone();
			balanceBase.Oper = this.Oper.Clone();
			balanceBase.Patient = this.Patient.Clone();
			balanceBase.InvoiceType = this.InvoiceType.Clone();
            balanceBase.BalanceType = this.BalanceType.Clone() as BalanceTypeEnumService;

			return balanceBase;
		}

		#endregion

		#endregion

	}
}
