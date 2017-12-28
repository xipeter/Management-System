
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// ISort<br></br>
	/// [功能描述: 实现代码检索]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    //[System.Serializable]
    public interface ISpell 
	{
		/// <summary>
		/// 拼音码
		/// </summary>
		string SpellCode
		{	
			get;
			set;
		}

		/// <summary>
		/// 五笔码
		/// </summary>
		string WBCode
		{
			get;
			set;
		}

		/// <summary>
		/// 自定义码
		/// </summary>
		string UserCode
		{	
			get;
			set;
		}
	}
}
