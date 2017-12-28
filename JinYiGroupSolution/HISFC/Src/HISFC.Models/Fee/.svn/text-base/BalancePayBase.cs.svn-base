using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee 
{

	/// <summary>
	/// BalancePayBase<br></br>
	/// [功能描述: 支付信息抽象类]<br></br>
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
	public abstract class BalancePayBase : NeuObject 
	{
		#region 变量
		
		/// <summary>
		/// 发票信息
		/// </summary>
		private Invoice invoice = new Invoice();
		
		/// <summary>
		/// 交易类型
		/// </summary>
		private TransTypes transType;
		
		/// <summary>
        /// 支付类型{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
		/// </summary>
		//private EnumPayTypeService payType = new EnumPayTypeService();
        private NeuObject payType = new NeuObject();
		
		/// <summary>
		/// 金额信息
		/// </summary>
		private FT ft = new FT();
		
		/// <summary>
		/// 张数
		/// </summary>
		private int qty;
		
		/// <summary>
		/// 银行信息
		/// </summary>
		private Bank bank = new Bank();
		
		/// <summary>
		/// 返还补收标记 1补收2返还
		/// </summary>
		private string returnOrSupplyFlag;

        /// <summary>
        /// 操作员信息(录入,收费,退费操作员)
        /// </summary>
        private OperEnvironment inputOper = new OperEnvironment();
		
		/// <summary>
		/// 日结信息(日结人,日结时间)
		/// </summary>
		private OperEnvironment balanceOper = new OperEnvironment();
		
		/// <summary>
		/// POS机器号
		/// </summary>
		private string posNO;

		/// <summary>
		/// 是否审核
		/// </summary>
		private bool isAuditing;

		/// <summary>
		/// 审核操作环境(审核操作员,审核时间)
		/// </summary>
		private OperEnvironment auditingOper = new OperEnvironment();
		
		/// <summary>
		/// 是否日结
		/// </summary>
		private bool isDayBalanced;
		
		/// <summary>
		/// 是否银行对帐
		/// </summary>
		private bool isChecked;
		
		/// <summary>
		/// 对帐操作环境(对帐人信息,对帐时间)
		/// </summary>
		private OperEnvironment checkOper = new OperEnvironment();
		
		/// <summary>
		/// 支付状态
		/// </summary>
		private CancelTypes cancelType;

		#endregion

		#region 属性

        /// <summary>
        /// 操作员信息(录入,收费,退费操作员)
        /// </summary>
        public OperEnvironment InputOper 
        {
            get 
            {
                return this.inputOper;
            }
            set 
            {
                this.inputOper = value;
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
		/// 交易类型
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
        /// 支付类型{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
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
		/// 金额信息
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
		/// 张数
		/// </summary>
		public int Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}
		
		/// <summary>
		/// 银行信息
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
		/// 返还补收标记 1补收2返还
		/// </summary>
		public string RetrunOrSupplyFlag
		{
			get
			{
				return this.returnOrSupplyFlag;
			}
			set
			{
				this.returnOrSupplyFlag = value;
			}
		}

		/// <summary>
		/// 结算环境信息(结算人,结算时间)
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
		/// POS机器号
		/// </summary>
		public string POSNO
		{
			get
			{
				return this.posNO;
			}
			set
			{
				this.posNO = value;
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
		/// 是否银行对帐
		/// </summary>
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				this.isChecked = value;
			}
		}

		/// <summary>
		/// 对帐操作环境(对帐人信息,对帐时间)
		/// </summary>
		public OperEnvironment CheckOper
		{
			get
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}
		
		/// <summary>
		/// 支付状态
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

		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象的实例副本</returns>
		public new BalancePayBase Clone()
		{
			BalancePayBase balancePayBase = base.Clone() as BalancePayBase;

			balancePayBase.AuditingOper = this.AuditingOper.Clone();
			balancePayBase.BalanceOper = this.BalanceOper.Clone();
			balancePayBase.Bank = this.Bank.Clone();
			balancePayBase.CheckOper = this.CheckOper.Clone();
			balancePayBase.FT = this.FT.Clone();
			balancePayBase.Invoice = this.Invoice.Clone();
			//{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            balancePayBase.PayType = this.PayType.Clone();
			return balancePayBase;
		}

		#endregion

		#endregion
	}
}
