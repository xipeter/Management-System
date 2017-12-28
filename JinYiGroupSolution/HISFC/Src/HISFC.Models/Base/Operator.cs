namespace Neusoft.HISFC.Models.Base
{

	/// <summary>
	/// Operator<br></br>
	/// [功能描述: 操作员]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-31]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Operator : Neusoft.FrameWork.Models.NeuObject 
	{
		public Operator ()
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

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

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Operator Clone()
		{
			return base.Clone() as Operator;
		}

		#endregion
	}
}
