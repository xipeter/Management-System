using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资库存管理信息基类]
	/// [创 建 者: 梁俊泽]
	/// [创建时间: 2007-03]
	/// </summary>
	public class StoreBase : Neusoft.HISFC.Object.IMA.IMAStoreBase
	{
		public StoreBase()
		{

		}


		#region 变量

		/// <summary>
		/// 物资项目信息
		/// </summary>
		private MaterialItem item = new MaterialItem();

		/// <summary>
		/// 批号
		/// </summary>
		private string batchNO;

		/// <summary>
		/// 库存序号(批次号)
		/// </summary>
		private string stockNO;

		/// <summary>
		/// 库存类型 默认仓库存 1 仓库 0 病区
		/// </summary>
		private string stockType = "1";

		/// <summary>
		/// stockType为"0"时 科室是否为病区
		/// </summary>
		private bool isNurse = false;

		/// <summary>
		/// 平均单价
		/// </summary>
		private decimal avgPrice;		

		/// <summary>
		/// 平均零售价
		/// </summary>
		private decimal avgSalePrice;

		/// <summary>
		/// 有效期
		/// </summary>
		private DateTime validTime;

		/// <summary>
		/// 条形码
		/// </summary>
		private string barNO;

		/// <summary>
		/// 扩展字段
		/// </summary>
		private string extend;

        /// <summary>
        /// 已退数量
        /// </summary>
        private decimal returns;

		#endregion

		#region 属性

		/// <summary>
		/// 物资项目信息
		/// </summary>
		public MaterialItem Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;

				base.IMAItem = value;				
			}
		}


		/// <summary>
		/// 批号
		/// </summary>
		public string BatchNO
		{
			get
			{
				return this.batchNO;
			}
			set
			{
				this.batchNO = value;
			}
		}


		/// <summary>
		/// 库存序号(批次号)
		/// </summary>
		public string StockNO
		{
			get
			{
				return this.stockNO;
			}
			set
			{
				this.stockNO = value;
			}
		}


		/// <summary>
		/// 库存类型 默认仓库存
		/// </summary>
		public string StockType
		{
			get
			{
				return this.stockType;
			}
			set
			{
				this.stockType = value;
			}
		}


		/// <summary>
		/// stockType为"0"时 科室是否为病区
		/// </summary>
		public bool IsNurse
		{
			get
			{
				return this.isNurse;
			}
			set
			{
				this.isNurse = value;
			}
		}


		/// <summary>
		/// 平均单价
		/// </summary>
		public decimal AvgPrice
		{
			get
			{
				return this.avgPrice;
			}
			set
			{
				this.avgPrice = value;
			}
		}


		/// <summary>
		/// 平均零售价
		/// </summary>
		public decimal AvgSalePrice
		{
			get
			{
				return this.avgSalePrice;
			}
			set
			{
				this.avgSalePrice = value;
			}
		}


		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidTime
		{
			get
			{
				return this.validTime;
			}
			set
			{
				this.validTime = value;
			}
		}


		/// <summary>
		/// 条形码
		/// </summary>
		public string BarNO
		{
			get
			{
				return this.barNO;
			}
			set
			{
				this.barNO = value;
			}
		}


		/// <summary>
		/// 扩展字段
		/// </summary>
		public string Extend
		{
			get
			{
				return this.extend;
			}
			set
			{
				this.extend = value;
			}
		}


        public decimal Returns
        {
            get
            {
                return this.returns;
            }
            set
            {
                this.returns = value;
            }
        }


		#endregion

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new StoreBase Clone()
		{
			StoreBase storeBase = base.Clone() as StoreBase;

			storeBase.item = this.item.Clone();

			return storeBase;
		}


		#endregion
	}
}
