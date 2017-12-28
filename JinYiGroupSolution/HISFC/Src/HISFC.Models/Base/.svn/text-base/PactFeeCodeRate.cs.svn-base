using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PactFeeCodeRate<br></br>
	/// [功能描述: 合同单位最小费用比率实体]<br></br>
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
    public class PactFeeCodeRate :NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PactFeeCodeRate( ) 
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 合同单位
		/// </summary>
		private Neusoft.HISFC.Models.Base.Pact pact = new Pact();

		/// <summary>
		/// 最小费用
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject minFee = new NeuObject();

		/// <summary>
		/// 各种比率
		/// </summary>
		private Neusoft.HISFC.Models.Base.FTRate rate = new FTRate();

		#endregion

		#region 属性

		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.HISFC.Models.Base.Pact Pact
		{
			get
			{
				return this.pact;
			}
			set
			{
				this.pact = value;
			}
		}

		/// <summary>
		/// 最小费用
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject MinFee 
		{
			get
			{
				return this.minFee;
			}
			set
			{
				this.minFee = value;
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

			if (this.pact != null)
			{
				this.pact.Dispose();
				this.pact = null;
			}
			if (this.minFee != null)
			{
				this.minFee.Dispose();
				this.minFee = null;
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
		/// <returns>当前对象的实例的副本</returns>
		public new PactFeeCodeRate Clone()
		{
			PactFeeCodeRate pactFeeCodeRate = base.Clone() as PactFeeCodeRate;

			pactFeeCodeRate.MinFee = this.MinFee.Clone();
			pactFeeCodeRate.Pact = this.Pact.Clone();
			pactFeeCodeRate.Rate = this.Rate.Clone();

			return pactFeeCodeRate;
		}

		#endregion

		#endregion
	}
}
