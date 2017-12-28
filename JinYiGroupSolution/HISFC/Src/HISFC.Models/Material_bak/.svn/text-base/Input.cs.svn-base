using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资入库信息]
	/// [创 建 者: 梁俊泽]
	/// [创建时间: 2007-03]
	/// 
	/// ID 入库记录流水号
	/// </summary>
	public class Input : Neusoft.NFC.Object.NeuObject
	{
		public Input()
		{
			this.storeBase.Class2Type = "0510";
		}


		#region 变量

		/// <summary>
		/// 入库单据号 默认年月日+流水号
		/// </summary>
		private string inListNO;

		/// <summary>
		/// 入库金额
		/// </summary>
		private decimal inCost;

		/// <summary>
		/// 正式入库日期
		/// </summary>
		private DateTime inFormalTime;

		/// <summary>
		/// 大包装入库数量
		/// </summary>
		private decimal packInQty;

		/// <summary>
		/// 发票号
		/// </summary>
		private string invoiceNO;

		/// <summary>
		/// 发票日期
		/// </summary>
		private DateTime invoiceTime;

		/// <summary>
		/// 贷方科目
		/// </summary>
		private string credit;

		/// <summary>
		/// 生产日期
		/// </summary>
		private DateTime produceTime;

		/// <summary>
		/// 是否生产入库
		/// </summary>
		private bool isProduce;

		/// <summary>
		/// 采购员
		/// </summary>
		private Neusoft.NFC.Object.NeuObject buyer = new Neusoft.NFC.Object.NeuObject();

		/// <summary>
		/// 计划单号
		/// </summary>
		private string planListNO;

		/// <summary>
		/// 计划单内序号
		/// </summary>
		private int planSerialNO;

		/// <summary>
		/// 出库流水号
		/// </summary>
		private string outNO;

		/// <summary>
		/// 库存基本信息
		/// </summary>
		private Neusoft.HISFC.Object.Material.StoreBase storeBase = new StoreBase();

		#endregion

		#region 属性

		/// <summary>
		/// 入库单据号
		/// </summary>
		public string InListNO
		{
			get
			{
				return this.inListNO;
			}
			set
			{
				this.inListNO = value;
			}
		}


		/// <summary>
		/// 入库金额
		/// </summary>
		public decimal InCost
		{
			get
			{
				return this.inCost;
			}
			set
			{
				this.inCost = value;
			}
		}


		/// <summary>
		/// 正式入库日期
		/// </summary>
		public DateTime InFormalTime
		{
			get
			{
				return this.inFormalTime;
			}
			set			
			{
				this.inFormalTime = value;
			}
		}


		/// <summary>
		/// 大包装入库数量
		/// </summary>
		public decimal PackInQty
		{
			get
			{
				return this.packInQty;
			}
			set
			{
				this.packInQty = value;
			}
		}


		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNO
		{
			get
			{
				return this.invoiceNO;
			}
			set			
			{
				this.invoiceNO = value;
			}
		}


		/// <summary>
		/// 发票日期
		/// </summary>
		public DateTime InvoiceTime
		{
			get
			{
				return this.invoiceTime;
			}
			set
			{
				this.invoiceTime = value;
			}
		}


		/// <summary>
		/// 贷方科目
		/// </summary>
		public string Credit
		{
			get
			{
				return this.credit;
			}
			set
			{
				this.credit = value;
			}
		}


		/// <summary>
		/// 生产日期
		/// </summary>
		public DateTime ProduceTime
		{
			get
			{
				return this.produceTime;
			}
			set
			{
				this.produceTime = value;
			}
		}


		/// <summary>
		/// 是否生产入库
		/// </summary>
		public bool IsProduce
		{
			get
			{
				return this.isProduce;
			}
			set
			{
				this.isProduce = value;
			}
		}


		/// <summary>
		/// 采购员
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Buyer
		{
			get
			{
				return this.buyer;
			}
			set
			{
				this.buyer = value;
			}
		}


		/// <summary>
		/// 计划单号
		/// </summary>
		public string PlanListNO
		{
			get
			{
				return this.planListNO;
			}
			set
			{
				this.planListNO = value;
			}
		}


		/// <summary>
		/// 计划单内序号
		/// </summary>
		public int PlanSerialNO
		{
			get
			{
				return this.planSerialNO;
			}
			set
			{
				this.planSerialNO = value;
			}
		}


		/// <summary>
		/// 出库流水号
		/// </summary>
		public string OutNO
		{
			get
			{
				return this.outNO;
			}
			set
			{
				this.outNO = value;
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

		public new Input Clone()
		{
			Input input = base.Clone() as Input;

			input.buyer = this.buyer.Clone();

			input.storeBase = this.storeBase.Clone();

			return input;
		}

		#endregion
	}
}
