namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// DepartmentExt<br></br>
	/// [功能描述: 科室实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    [System.Obsolete("已经不用了，都用ExtendInfo来做这些东西了!",false)]
	public class DepartmentExt: ComExtInfo 
    {
		/// <summary>
		/// 构造函数
		/// </summary>
		public DepartmentExt() 
        {
		}


		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
		#endregion

		#region 属性

		/// <summary>
		/// 科室编码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept 
        {
			get
            { 
                return this.Item;
            }
			set
            { 
                this.Item = value;
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

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}
		#endregion

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>DepartmentExt类的实例</returns>
		public new DepartmentExt Clone()
		{
			return this.MemberwiseClone() as DepartmentExt;
		}
		#endregion

		#endregion

		


	}
}
