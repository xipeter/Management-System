namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PactInfo<br></br>
	/// [功能描述: 合同单位信息，用于业务实现]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class PactInfo :  Pact,  ISort
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PactInfo( ) 
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 结算类别
		/// </summary>
		private PayKind payKind = new PayKind();
		
		/// <summary>
		/// 价格形式
		/// </summary>
		private string priceForm;
		
		/// <summary>
		/// 各种比率
		/// </summary>
		private Neusoft.HISFC.Models.Base.FTRate rate = new FTRate();
		
		/// <summary>
		/// 是否要求必须有医疗证号
		/// </summary>
		private bool isNeedMCard;
		
		/// <summary>
		/// 是否受监控
		/// </summary>
		private bool isInControl;
		
		/// <summary>
		/// 项目类别标记 0 全部, 1 药品, 2 非药品
		/// </summary>
		private string itemType = "";
		
		/// <summary>
		/// 日限额
		/// </summary>
		private decimal dayQuota;
		
		/// <summary>
		/// 月限额
		/// </summary>
		private decimal monthQuota;
		
		/// <summary>
		/// 年限额
		/// </summary>
		private decimal yearQuota;
		
		/// <summary>
		/// 一次限额
		/// </summary>
		private decimal onceQuota;
		
		/// <summary>
		/// 床位标准
		/// </summary>
		private decimal bedQuota;
		
		/// <summary>
		/// 空调标准
		/// </summary>
		private decimal airConditionQuota;
		
		/// <summary>
		/// 合同单位简称
		/// </summary>
		private string shortName;
		
		/// <summary>
		/// 排列序号
		/// </summary>
		private int sortID;

        /// <summary>
        /// 合同单位对照医保待遇dll名称
        /// </summary>
        private string pactDllName = string.Empty;
        /// <summary>
        /// 合同单位对照医保待遇dll描述
        /// </summary>
        private string pactDllDescription = string.Empty;

		#endregion

		#region 属性
		
		/// <summary>
		/// 结算类别
		/// </summary>
		public PayKind PayKind
		{
			get
			{
				return this.payKind;
			}
			set
			{
				this.payKind = value;
			}
		}

		/// <summary>
		/// 价格形式
		/// </summary>
		public string PriceForm
		{
			get
			{
				return this.priceForm;
			}
			set
			{
				this.priceForm = value;
			}
		}

		/// <summary>
		/// 各种比率
		/// </summary>
		public Neusoft.HISFC.Models.Base.FTRate Rate
		{
			get
			{
				return this.rate;
			}
			set
			{
				this.rate = value;
			}
		}

		/// <summary>
		/// 是否要求必须有医疗证号
		/// </summary>
		public bool IsNeedMCard
		{
			get
			{
				return this.isNeedMCard;
			}
			set
			{
				this.isNeedMCard = value;
			}
		}

		/// <summary>
		/// 是否受监控
		/// </summary>
		public bool IsInControl
		{
			get
			{
				return this.isInControl;
			}
			set
			{
				this.isInControl = value;
			}
		}

		/// <summary>
		/// 项目类别标记 0 全部, 1 药品, 2 非药品
		/// </summary>
		public string ItemType
		{
			get
			{
				return this.itemType;
			}
			set
			{
				this.itemType = value;
			}
		}

		/// <summary>
		/// 日限额
		/// </summary>
		public decimal DayQuota
		{
			get
			{
				return this.dayQuota;
			}
			set
			{
				this.dayQuota = value;
			}
		}

		/// <summary>
		/// 月限额
		/// </summary>
		public decimal MonthQuota
		{
			get
			{
				return this.monthQuota;
			}
			set
			{
				this.monthQuota = value;
			}
		}

		/// <summary>
		/// 年限额
		/// </summary>
		public decimal YearQuota
		{
			get
			{
				return this.yearQuota;
			}
			set
			{
				this.yearQuota = value;
			}
		}

		/// <summary>
		/// 一次限额
		/// </summary>
		public decimal OnceQuota
		{
			get
			{
				return this.onceQuota;
			}
			set
			{
				this.onceQuota = value;
			}
		}

		/// <summary>
		/// 床位标准
		/// </summary>
		public decimal BedQuota
		{
			get
			{
				return this.bedQuota;
			}
			set
			{
				this.bedQuota = value;
			}
		}

		/// <summary>
		/// 空调标准
		/// </summary>
		public decimal AirConditionQuota
		{
			get
			{
				return this.airConditionQuota;
			}
			set
			{
				this.airConditionQuota = value;
			}
		}

		/// <summary>
		/// 合同单位简称
		/// </summary>
		public string ShortName
		{
			get
			{
				return this.shortName;
			}
			set
			{
				this.shortName = value;
			}
		}

        /// <summary>
        /// 合同单位对照医保待遇dll名称
        /// </summary>
        public string PactDllName
        {
            get
            {
                return pactDllName;
            }
            set
            {
                pactDllName = value;
            }
        }
        /// <summary>
        /// 合同单位对照医保待遇dll描述
        /// </summary>
        public string PactDllDescription
        {
            get
            {
                return pactDllDescription;
            }
            set
            {
                pactDllDescription = value;
            }
        }
		#endregion

		#region 方法
		
		#region 释放资源
		
		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			if (this.payKind != null)
			{
				this.payKind.Dispose();
				this.payKind = null;
			}
			if (this.rate != null)
			{
				this.rate.Dispose();
				this.rate = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象实例的副本</returns>
		public new PactInfo Clone()
		{
			PactInfo pactInfo = base.Clone() as PactInfo;

			pactInfo.PayKind = this.PayKind.Clone();
			pactInfo.Rate = this.Rate.Clone();

			return pactInfo;
		}

		#endregion

		#endregion

		#region 接口实现

		#region ISort 成员
		/// <summary>
		/// 排列序号
		/// </summary>
		public new int SortID
		{
			get
			{
				return this.sortID ;
			}
			set
			{
				this.sortID = value;
			}
		}
		#endregion

		#endregion
		
	}
}
