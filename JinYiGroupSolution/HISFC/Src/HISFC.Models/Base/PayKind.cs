namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PayKind<br></br>
	/// [功能描述: 结算类别<br></br>
	/// 01-自费,<br></br>
	/// 02-保险,<br></br>
	/// 03-公费在职,<br></br>
	/// 04-公费退休,<br></br>
	/// 05-公费高干]<br></br>
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
    public class PayKind : Neusoft.FrameWork.Models.NeuObject
	{
		public PayKind()
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
		/// 药品追加比率
		/// </summary>
		private float drugAdditionalRate = 1;

		/// <summary>
		/// 非药品追加比率
		/// </summary>
		private float undrugAdditionalRate = 1;

		#endregion

		#region 属性
		/// <summary>
		/// 药品追加比率
		/// </summary>
		public float DrugAdditionalRate
		{
			get
			{
				return this.drugAdditionalRate;
			}
			set
			{
				this.drugAdditionalRate = value;
			}
		}

		/// <summary>
		/// 非药品追加比率
		/// </summary>
		public float UndrugAdditionalRate
		{
			get
			{
				return this.undrugAdditionalRate;
			}
			set
			{
				this.undrugAdditionalRate = value;
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

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>PayKind</returns>
		public new PayKind  Clone()
		{
			return base.Clone() as PayKind;
		}

		#endregion

	}
}
