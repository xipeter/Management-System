namespace Neusoft.HISFC.Models.MedTech.Management 
{
    /// <summary>
    /// [功能描述: 权限]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Serializable]
    public class Role 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Role( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 窗口
		/// </summary>
		private Window window;

		#endregion

		#region 属性

		/// <summary>
		/// 窗口
		/// </summary>
		public Window Window 
		{
			get 
			{
				return this.window;
			}
			set 
			{
				this.window = value;
			}
		}

		#endregion

		#region 方法
		#endregion
	}
}
