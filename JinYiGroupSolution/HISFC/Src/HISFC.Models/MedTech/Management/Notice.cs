namespace Neusoft.HISFC.Object.MedTech.Management 
{

    /// <summary>
    /// [功能描述: 温馨提示及注意事项]<br></br>
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
    public class Notice : MedTech.Base.MTObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Notice( ) 
		{
		}

		/// <summary>
		/// 对应项目主键
		/// </summary>
		private Item item;

		/// <summary>
		/// 对应项目主键
		/// </summary>
		public Item Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}
	}
}
