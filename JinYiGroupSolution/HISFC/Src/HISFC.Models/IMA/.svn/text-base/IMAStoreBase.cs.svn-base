using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品、物资库存管理基类 包括库存管理 入出库皆由此继承]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// 
	/// </summary>
    [Serializable]
    public class IMAStoreBase : IMABase,Base.IValidState
	{
		public IMAStoreBase()
		{
			
		}


		#region 变量

		/// <summary>
		/// 单内序号
		/// </summary>
		private int serialNo;

		/// <summary>
		/// 库存操作目标科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject targetDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 生产厂家
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject producer = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 供货公司
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject company = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 数量
		/// </summary>
		private decimal quantity;

		/// <summary>
		/// 价格信息
		/// </summary>
		private Neusoft.HISFC.Models.IMA.PriceService priceCollection = new Neusoft.HISFC.Models.IMA.PriceService(); 

		/// <summary>
		/// 零售金额
		/// </summary>
		private decimal retailCost;

		/// <summary>
		/// 批发金额
		/// </summary>
		private decimal wholeSaleCost;

		/// <summary>
		/// 购入金额
		/// </summary>
		private decimal purchaseCost;

		/// <summary>
		/// 库存数量(汇总后)
		/// </summary>
		private decimal storeQty;

		/// <summary>
		/// 库存金额
		/// </summary>
		private decimal storeCost;

		/// <summary>
		/// 货位号
		/// </summary>
		private string placeNo;

        /// <summary>
        /// 有效性
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumValidState validState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;

		#endregion
		
		/// <summary>
		/// 单内序号
		/// </summary>
		public int SerialNO
		{
			get
			{
				return this.serialNo;
			}
			set
			{
				this.serialNo = value;
			}
		}

		/// <summary>
		/// 库存操作目标科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject TargetDept
		{
			get
			{
				return this.targetDept;
			}
			set
			{
				this.targetDept = value;
			}
		}

		/// <summary>
		/// 生产厂家
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Producer
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
		/// 供货公司
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Company
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
		/// 数量
		/// </summary>
		public decimal Quantity
		{
			get
			{
				return this.quantity;
			}
			set
			{
				this.quantity = value;
			}
		}

		/// <summary>
		/// 价格信息
		/// </summary>
		public Neusoft.HISFC.Models.IMA.PriceService PriceCollection
		{
			get
			{
				return this.priceCollection;
			}
			set
			{
				this.priceCollection = value;
			}
		}

		/// <summary>
		/// 零售金额
		/// </summary>
		public decimal RetailCost
		{
			get
			{
				return this.retailCost;
			}
			set
			{
				this.retailCost = value;
			}
		}

		/// <summary>
		/// 批发金额
		/// </summary>
		public decimal WholeSaleCost
		{
			get
			{
				return this.wholeSaleCost;
			}
			set
			{
				this.wholeSaleCost = value;
			}
		}

		/// <summary>
		/// 购入金额
		/// </summary>
		public decimal PurchaseCost
		{
			get
			{
				return this.purchaseCost;
			}
			set
			{
				this.purchaseCost = value;
			}
		}

		/// <summary>
		/// 库存数量 汇总数量
		/// </summary>
		public decimal StoreQty
		{
			get
			{
				return this.storeQty;
			}
			set
			{
				this.storeQty = value;
			}
		}

		/// <summary>
		/// 库存金额 汇总金额
		/// </summary>
		public decimal StoreCost
		{
			get
			{
				return this.storeCost;
			}
			set
			{
				this.storeCost = value;
			}
		}

		/// <summary>
		/// 货位号
		/// </summary>
		public string PlaceNO
		{
			get
			{
				return this.placeNo;
			}
			set
			{
				this.placeNo = value;
			}
		}

        #region IValidState 成员

        public Neusoft.HISFC.Models.Base.EnumValidState ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                this.validState = value;
            }
        }

        #endregion


		#region 方法

		public new IMAStoreBase Clone()
		{
			IMAStoreBase imaStoreBase = base.Clone() as IMAStoreBase;

			imaStoreBase.TargetDept = this.TargetDept.Clone();
			imaStoreBase.Producer = this.Producer.Clone();
			imaStoreBase.Company = this.Company.Clone();
			imaStoreBase.PriceCollection = this.PriceCollection.Clone();

			return imaStoreBase;
		}


		#endregion        
    }
}
