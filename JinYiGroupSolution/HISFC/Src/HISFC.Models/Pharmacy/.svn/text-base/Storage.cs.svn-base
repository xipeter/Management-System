using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品库存管理类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自IMAStoreBase基类'
	///  />
	/// </summary>
    [Serializable]
    public class Storage : StorageBase
	{
		public Storage () 
		{
			
		}

		#region 变量

		private decimal preOutQty;

		private decimal myPreOutCost;

		private decimal lastMonthQty;

		private decimal lowQty;

		private decimal topQty;

		private bool myIsCheck;

		private bool myIsStop;

        private bool myIsLack;

        /// <summary>
        /// 药品库存性质
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject manageQuality = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 负库存量
        /// </summary>
        private decimal negativeQty;

		#endregion

		/// <summary>
		/// 预出库数量
		/// </summary>
		public decimal PreOutQty
		{
			get 
			{
				return this.preOutQty;
			}
			set 
			{
				this.preOutQty = value;
			}
		}

		/// <summary>
		/// 预出库金额
		/// </summary>
		public decimal PreOutCost 
		{
			get 
			{
				return myPreOutCost;
			}
			set 
			{
				myPreOutCost = value;
			}
		}
		
		/// <summary>
		/// 最低库存量
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
		/// 最高库存量
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
		/// 上月结存数量
		/// </summary>
		public decimal LastMonthQty
		{
			get 
			{
				return this.lastMonthQty;
			}
			set 
			{
				lastMonthQty = value;
			}
		}

		/// <summary>
		/// 是否停用 该属性不由数据库内获取，通过ValidState赋值
		/// </summary>
        [Obsolete("该属性不由数据库内获取",false)]
		public bool IsStop 
		{
			get 
			{
				return myIsStop;
			}
			set 
			{
				myIsStop = value;

                if (value)
                {
                    base.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                }
                else
                {
                    base.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                }
			}
		}

		/// <summary>
		/// 是否每日盘点
		/// </summary>
		public bool IsCheck 
		{
			get 
			{
				return myIsCheck;
			}
			set 
			{
				myIsCheck = value;
			}
		}

        /// <summary>
        /// 是否缺药
        /// </summary>
        public bool IsLack
        {
            get
            {
                return this.myIsLack;
            }
            set
            {
                this.myIsLack = value;
            }
        }

        /// <summary>
        /// 药品库存性质
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ManageQuality
        {
            get
            {
                return this.manageQuality;
            }
            set
            {
                this.manageQuality = value;
            }
        }

        /// <summary>
        /// 有效性状态
        /// </summary>
        public new Neusoft.HISFC.Models.Base.EnumValidState ValidState
        {
            get
            {
                return base.ValidState;
            }
            set
            {
                if (value == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    this.myIsStop = false;
                }
                else
                {
                    this.myIsStop = true;
                }

                base.ValidState = value;
            }
        }

        /// <summary>
        /// 负库存量
        /// </summary>
        public decimal NegativeQty
        {
            get
            {
                return this.negativeQty;
            }
            set
            {
                this.negativeQty = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new Storage Clone()
		{
            Storage cloneStorage = base.Clone() as Storage;

            cloneStorage.manageQuality = this.manageQuality.Clone();

            return cloneStorage;
		}

		#endregion  
	}
}
