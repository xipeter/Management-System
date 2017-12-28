using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资库存主信息]
	/// [创 建 者: 梁俊泽]
	/// [创建时间: 2007-03]
	/// </summary>
	public class StoreHead : Neusoft.NFC.Object.NeuObject
	{
		public StoreHead()
		{
			
		}


		#region 变量

		/// <summary>
		/// 零售金额
		/// </summary>
		private decimal saleCost;

		/// <summary>
		/// 库存上限数量
		/// </summary>
		private decimal topQty;

		/// <summary>
		/// 库存下限数量
		/// </summary>
		private decimal lowQty;

		/// <summary>
		/// 是否缺货
		/// </summary>
		private bool isLack = false;

		/// <summary>
		/// 库存基本信息
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
		/// 库存上限数量
		/// </summary>
		public decimal TopQty
		{
			get			
			{
				return this.topQty;
			}
			set
			{
				this.topQty = value;
			}
		}


		/// <summary>
		/// 库存下限数量
		/// </summary>
		public decimal LowQty
		{
			get
			{
				return this.lowQty;
			}
			set
			{
				this.lowQty = value;
			}
		}


		/// <summary>
		/// 是否缺货
		/// </summary>
		public bool IsLack
		{
			get
			{
				return this.isLack;
			}
			set
			{
				this.isLack = value;
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

		public new StoreHead Clone()
		{
			StoreHead storeHead = base.Clone() as StoreHead;

			storeHead.storeBase = this.storeBase.Clone();

			return storeHead;
		}


		#endregion
	}
}
