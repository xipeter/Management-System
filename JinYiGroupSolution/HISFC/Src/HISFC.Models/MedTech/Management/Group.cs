namespace Neusoft.HISFC.Models.MedTech.Management 
{
    /// <summary>
    /// [功能描述: 医技预约组]<br></br>
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
	public class Group : Neusoft.HISFC.Models.Base.Spell
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Group( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 负责人
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment master;

		#endregion

		#region 属性

		/// <summary>
		/// 负责人
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Master 
		{
			get 
			{
				return this.master;
			}
			set 
			{
				this.master = value;
			}
		}
		#endregion
		
	}
}
