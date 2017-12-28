using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资库存明细信息]
	/// [创 建 者: 梁俊泽]
	/// [创建时间: 2007-03]
	/// 
	/// ID 库存序号
	/// </summary>
	public class StoreDetail : Neusoft.NFC.Object.NeuObject
	{
		public StoreDetail()
		{
			
		}


		#region 变量
		
		/// <summary>
		/// 零售金额
		/// </summary>
		private decimal saleCost;
		
		/// <summary>
		/// 出库日期
		/// </summary>
		private DateTime outTime;

		/// <summary>
		/// 入库日期
		/// </summary>
		private DateTime inTime;

		/// <summary>
		/// 生产日期
		/// </summary>
		private DateTime produceTime;

		/// <summary>
		/// 是否加价
		/// </summary>
		private bool isModifyPrice = false;

		/// <summary>
		/// 加价人
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment modifyOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 卫生材料流水号
		/// </summary>
		private string outSequence;

		/// <summary>
		/// 库存管理基本信息
		/// </summary>
		private Neusoft.HISFC.Object.Material.StoreBase storeBase = new StoreBase();

		#endregion

		#region 属性

		/// <summary>
		/// 零售金额
		/// </summary>
		public decimal SaleCost
		{
			get
			{
				return this.saleCost;
			}
			set
			{
				this.saleCost = value;
			}
		}


		/// <summary>
		/// 最近一次出库日期
		/// </summary>
		public DateTime OutTime
		{
			get
			{
				return this.outTime;
			}
			set
			{
				this.outTime = value;
			}
		}


		/// <summary>
		/// 最近一次入库日期
		/// </summary>
		public DateTime InTime
		{
			get
			{
				return this.inTime;
			}
			set
			{
				this.inTime = value;
			}
		}


		/// <summary>
		/// 最近一次生产日期
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
		/// 是否加价
		/// </summary>
		public bool IsModifyPrice
		{
			get
			{
				return this.isModifyPrice;
			}
			set
			{
				this.isModifyPrice = value;
			}
		}


		/// <summary>
		/// 加价人
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ModifyOper
		{
			get
			{
				return this.modifyOper;
			}
			set
			{
				this.modifyOper = value;
			}
		}


		/// <summary>
		/// 卫生材料流水号
		/// </summary>
		public string OutSequence
		{
			get
			{
				return this.outSequence;
			}
			set
			{
				this.outSequence = value;
			}
		}


		/// <summary>
		/// 库存管理基本信息
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

		public new StoreDetail Clone()
		{
			StoreDetail storeDetail = base.Clone() as StoreDetail;

			storeDetail.modifyOper = this.modifyOper.Clone();

			storeDetail.storeBase = this.storeBase.Clone();

			return storeDetail;
		}


		#endregion
	}
}
