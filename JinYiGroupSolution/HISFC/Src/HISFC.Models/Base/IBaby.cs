
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// IBaby<br></br>
	/// [功能描述: 实现婴儿属性]<br></br>
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
    public interface IBaby
	{
		/// <summary>
		/// 婴儿序号
		/// </summary>
		string BabyNO
		{
			get;
			set;
		}

		/// <summary>
		/// 是否婴儿
		/// </summary>
		bool IsBaby
		{
			get;
			set;
		}
	}
}
