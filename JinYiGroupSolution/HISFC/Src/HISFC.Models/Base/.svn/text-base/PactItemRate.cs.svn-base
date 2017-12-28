using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PactItemRate<br></br>
	/// [功能描述: 合同单位项目比率]<br></br>
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
    public class PactItemRate : Pact
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PactItemRate( ) 
		{
	
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 合同单位对应的项目或最小费用
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject pactItem = new NeuObject();

		/// <summary>
		/// 项目类别: 0-最小费用,1-药品,2-非药品
		/// </summary>
		private string itemType;

		/// <summary>
		/// 合同单位对应的项目的各种比率
		/// </summary>
		private Neusoft.HISFC.Models.Base.FTRate rate = new FTRate();

		/// <summary>
		/// 操作环境
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();

		#endregion

		#region 属性
		/// <summary>
		/// 合同单位对应的项目或最小费用
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PactItem
		{
			get
			{
				return this.pactItem;
			}
			set
			{
				this.pactItem = value;
			}
		}

		/// <summary>
		/// 项目类别: 0-最小费用,1-药品,2-非药品
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
		/// 合同单位对应的项目的各种比率
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
		/// 操作环境
		/// </summary>
		public new OperEnvironment OperEnvironment
		{
			get
			{
				return this.operEnvironment;
			}
			set
			{
				this.operEnvironment = value;
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

			if (this.pactItem != null)
			{
				this.pactItem.Dispose();
				this.pactItem = null;
			}
			if (this.rate != null)
			{
				this.rate.Dispose();
				this.rate = null;
			}
			if (this.operEnvironment != null)
			{
				this.operEnvironment.Dispose();
				this.operEnvironment = null;
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
		public new PactItemRate  Clone()
		{
			PactItemRate pactItemRate = base.Clone() as PactItemRate;

			pactItemRate.OperEnvironment = this.OperEnvironment.Clone();
			pactItemRate.PactItem = this.PactItem.Clone();
			pactItemRate.Rate = this.Rate.Clone();

			return pactItemRate;
		}

		#endregion

		#endregion
	}
}
