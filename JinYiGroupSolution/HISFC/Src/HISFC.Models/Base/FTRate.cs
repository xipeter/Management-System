
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// FTRate<br></br>
	/// [功能描述: 各种费用比率实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-30]<br></br>
	/// <修改记录
	///		修改人='王宇'
	///		修改时间='2006-09-18'
	///		修改目的='增加ItemRate属性，修改代码格式不规范处'
	///		修改描述='ItemRate意义: 项目的收费比例'
	///  />
	/// </summary>
    [System.Serializable]
    public class FTRate : Neusoft.FrameWork.Models.NeuObject
	{
		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
		
		/// <summary>
		/// 急诊加成比例
		/// </summary>
		private decimal emcRate;
		
		/// <summary>
		/// 项目收费比例
		/// </summary>
		private decimal itemRate;
		
		/// <summary>
		/// 自费比例
		/// </summary>
		private decimal ownRate;

		/// <summary>
		/// 自付比例
		/// </summary>
		private decimal payRate;

		/// <summary>
		/// 公费比例
		/// </summary>
		private decimal pubRate;

		/// <summary>
		/// 减免比例
		/// </summary>
		private decimal derateRate;

		/// <summary>
		/// 欠费比例
		/// </summary>
		private decimal arrearageRate;

		/// <summary>
		/// 优惠比例
		/// </summary>
		private decimal rebateRate;

		/// <summary>
		/// 婴儿享用
		/// </summary>
		private bool isBabyShared;

		#endregion

		#region 属性

		/// <summary>
		/// 急诊加成比例
		/// </summary>
		public decimal EMCRate
		{
			get
			{
				return this.emcRate;
			}
			set
			{
				this.emcRate = value;
			}
		}
		
		/// <summary>
		/// 项目收费比例
		/// </summary>
		public decimal ItemRate
		{
			get
			{
				return this.itemRate;
			}
			set
			{
				this.itemRate = value;
			}
		}

		/// <summary>
		/// 自费比例
		/// </summary>
		public decimal OwnRate
		{
			get
			{
				return this.ownRate;
			}
			set
			{
				this.ownRate = value;
			}
		}

		/// <summary>
		/// 自付比例
		/// </summary>
		public decimal PayRate
		{
			get
			{
				return this.payRate;
			}
			set
			{
				this.payRate = value;
			}
		}
		
		/// <summary>
		/// 公费比例
		/// </summary>
		public decimal PubRate
		{
			get
			{
				return this.pubRate;
			}
			set
			{
				this.pubRate = value;
			}
		}
		
		/// <summary>
		/// 减免比例
		/// </summary>
		public decimal DerateRate
		{
			get
			{
				return this.derateRate;
			}
			set
			{
				this.derateRate = value;
			}
		}
		
		/// <summary>
		/// 欠费比例
		/// </summary>
		public decimal ArrearageRate
		{
			get
			{
				return this.arrearageRate;
			}
			set
			{
				this.arrearageRate = value;
			}
		}
		
		/// <summary>
		/// 优惠比例
		/// </summary>
		public decimal RebateRate
		{
			get
			{
				return this.rebateRate;
			}
			set
			{
				this.rebateRate = value;
			}
		}
		
		/// <summary>
		/// 是否婴儿享用
		/// </summary>
		public bool IsBabyShared
		{
			get
			{
				return this.isBabyShared;
			}
			set
			{
				this.isBabyShared = value;
			}
		}

		#endregion

		#region 方法
		
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
			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例</returns>
		public new FTRate Clone()
		{
			FTRate ftRate = base.Clone() as FTRate;

			return ftRate;
		}

		#endregion
	}
}
