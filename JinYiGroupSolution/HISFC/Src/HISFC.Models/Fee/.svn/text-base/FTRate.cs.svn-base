using System;

namespace Neusoft.HISFC.Object.Base
{
	/// <summary>
	/// FTRate<br></br>
	/// [功能描述: 各种费用比率实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-30]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class FTRate : Neusoft.NFC.Object.NeuObject
	{
		public FTRate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量
		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
		/// <summary>
		/// 自费比例
		/// </summary>
		private decimal ownRate=1.0M;
		/// <summary>
		/// 自付比例
		/// </summary>
		private decimal payRate=1.0M;
		/// <summary>
		/// 公费比例
		/// </summary>
		private decimal pubRate=0.0M;
		/// <summary>
		/// 减免比例
		/// </summary>
		private decimal derateRate =0.0M;
		/// <summary>
		/// 欠费比例
		/// </summary>
		private decimal arrearageRate =0.0M;
		/// <summary>
		/// 优惠比例
		/// </summary>
		private decimal rebateRate = 0.0M;
		/// <summary>
		/// 婴儿享用
		/// </summary>
		private bool  isBabyShared ;
		#endregion

		#region 属性
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
			base.Dispose (isDisposing);
			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new FTRate Clone()
		{
			FTRate ftRate = base.Clone() as FTRate;
			return ftRate;
		}
		#endregion
	}
}
