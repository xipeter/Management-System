namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// IInvalid<br></br>
	/// [功能描述: 实现有效性标识]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    //[System.Serializable]
    public interface IValid
	{
		/// <summary>
		/// 有效标记 0 false 有效，1 true 无效
		/// </summary>		
		bool IsValid
		{
			get;
			set;
		}
	}
}
