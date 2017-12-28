using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资采购计划类]
	/// [创 建 者: 李超]
	/// [创建时间: 2007-04]
	/// </summary>
	public class InputPlan: Neusoft.NFC.Object.NeuObject
	{
		public InputPlan() 
		{
			this.storeBase.Class2Type = "0510";
		}

		
		#region  变量
		/// <summary>
		/// 计划部门
		/// </summary>
		private System.String storageCode = string.Empty ;
		/// <summary>
		/// 计划编码
		/// </summary>
		private System.String planListCode = string.Empty;
		/// <summary>
		/// 计划单内序号
		/// </summary>
		private System.Int32 planNo ;
		/// <summary>
		/// 状态
		/// </summary>
		private System.String state = string.Empty ;
		/// <summary>
		/// 计划类型
		/// </summary>
		private System.String planType = string.Empty ;		
		/// <summary>
		/// 财务审核标志
		/// </summary>
		private System.String financeFlag = string.Empty ;
		/// <summary>
		/// 计划数量
		/// </summary>
		private decimal planNum ;
		/// <summary>
		/// 计划价格
		/// </summary>
		private decimal planPrice ;
		/// <summary>
		/// 计划金额
		/// </summary>
		private decimal planCost ;		
		/// <summary>
		/// 采购数量
		/// </summary>
		private decimal stockNum ;		
		/// <summary>
		/// 采购员
		/// </summary>
		private Neusoft.NFC.Object.NeuObject stockOper = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 采购时间
		/// </summary>
		private System.DateTime stockTime;		
		/// <summary>
		/// 供货公司
		/// </summary>
		private Neusoft.NFC.Object.NeuObject company = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 发票号liuxq add
		/// </summary>
		private System.String invoiceNo;
		/// <summary>
		/// 生产厂商
		/// </summary>
		private Neusoft.NFC.Object.NeuObject producer = new Neusoft.NFC.Object.NeuObject();			
		/// <summary>
		/// 科室类型
		/// </summary>
		private System.Int32 deptType ;
		/// <summary>
		/// 本科室库存
		/// </summary>
		private decimal storeSum ;
		/// <summary>
		/// 全院库存
		/// </summary>
		private decimal storeTotsum ;
		/// <summary>
		/// 全院出库总量
		/// </summary>
		private decimal outputSum ;		
		/// <summary>
		/// 库存基本信息
		/// </summary>
		private Neusoft.HISFC.Object.Material.StoreBase storeBase = new StoreBase();
		#endregion

		#region 属性
		/// <summary>
		/// 计划部门
		/// </summary>
		public System.String StorageCode
		{
			get
			{ 
				return this.storageCode; 
			}
			set
			{ 
				this.storageCode = value; 
			}
		}


		/// <summary>
		/// 计划单号
		/// </summary>
		public System.String PlanListCode
		{
			get
			{ 
				return this.planListCode;
			}
			set
			{ 
				this.planListCode = value;
			}
		}


		/// <summary>
		/// 计划单内序号
		/// </summary>
		public System.Int32 PlanNo
		{
			get
			{ 
				return this.planNo;
			}
			set
			{ 
				this.planNo = value;
			}
		}


		/// <summary>
		/// 计划单状态(0计划单，1采购单，2审核，3已入库) 4 作废计划单
		/// </summary>
		public System.String State
		{
			get
			{
				return this.state; 
			}
			set
			{ 
				this.state = value;
			}
		}


		/// <summary>
		/// 计划类型0手工计划，1警戒线，2消耗，3时间，4日消耗
		/// </summary>
		public System.String PlanType
		{
			get
			{
				return this.planType;
			}
			set
			{ 
				this.planType = value;
			}
		}


		/// <summary>
		/// 财务收费物品标志(0－否,1－是)
		/// </summary>
		public System.String FinanceFlag
		{
			get
			{ 
				return this.financeFlag; 
			}
			set
			{ 
				this.financeFlag = value; 
			}
		}


		/// <summary>
		/// 计划数量
		/// </summary>
		public decimal PlanNum
		{
			get
			{ 
				return this.planNum;
			}
			set
			{ 
				this.planNum = value;
			}
		}


		/// <summary>
		/// 计划价格
		/// </summary>
		public decimal PlanPrice
		{
			get
			{ 
				return this.planPrice;
			}
			set
			{ 
				this.planPrice = value;
			}
		}


		/// <summary>
		/// 计划金额
		/// </summary>
		public decimal PlanCost
		{
			get
			{ 
				return this.planCost; 
			}
			set
			{ 
				this.planCost = value;
			}
		}

		
		/// <summary>
		/// 采购数量
		/// </summary>
		public decimal StockNum
		{
			get
			{ 
				return this.stockNum; 
			}
			set
			{ 
				this.stockNum = value;
			}
		}


		/// <summary>
		/// 采购信息
		/// </summary>
		public Neusoft.NFC.Object.NeuObject  StockOper
		{
			get
			{
				return this.stockOper;
			}
			set
			{ 
				this.stockOper = value; 
			}
		}


		public System.DateTime StockTime 
		{
			get
			{
				return this.stockTime;
			}
			set
			{
				this.stockTime = value;
			}
		}

		
		/// <summary>
		/// 供货公司信息
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Company
		{
			get
			{ 
				return this.company; 
			}
			set
			{ 
				this.company = value;
			}
		}
		/// <summary>
		/// 发票号liuxq add 
		/// </summary>
		public System.String InvoiceNo
		{
			get
			{
				return this.invoiceNo;
			}
			set
			{
				this.invoiceNo = value;
			}
		}

		/// <summary>
		/// 生产厂家编码
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Producer
		{
			get
			{ 
				return this.producer;
			}
			set
			{ 
				this.producer = value; 
			}
		}


		/// <summary>
		/// 1仓库部门   0 科室
		/// </summary>
		public System.Int32 DeptType
		{
			get
			{ 
				return this.deptType;
			}
			set
			{
				this.deptType = value; 
			}
		}


		/// <summary>
		/// 本科室库存
		/// </summary>
		public decimal StoreSum
		{
			get
			{ 
				return this.storeSum;
			}
			set
			{ 
				this.storeSum = value;
			}
		}


		/// <summary>
		/// 全院库存总和
		/// </summary>
		public decimal StoreTotsum
		{
			get
			{ 
				return this.storeTotsum; 
			}
			set
			{ 
				this.storeTotsum = value; 
			}
		}


		/// <summary>
		/// 全院出库总量
		/// </summary>
		public decimal OutputSum
		{
			get
			{ 
				return this.outputSum; 
			}
			set
			{ 
				this.outputSum = value; 
			}
		}


		/// <summary>
		/// 库存基本信息
		/// </summary>
		public Neusoft.HISFC.Object.Material.StoreBase StoreBase
		{
			get
			{
				return this.storeBase;
			}
			set
			{
				this.storeBase = value;
			}
		}
	
		#endregion 

		#region 方法

		public new InputPlan Clone()
		{
			InputPlan inputPlan = base.Clone() as InputPlan;

			inputPlan.company = this.company.Clone();

			inputPlan.producer = this.producer.Clone();			

			inputPlan.stockOper = this.stockOper.Clone();
			
			inputPlan.storeBase = this.storeBase.Clone();

			return inputPlan;
		}

		#endregion


	}
}
