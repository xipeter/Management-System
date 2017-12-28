using System;
using System.Collections;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// IEnumService<br></br>
	/// [功能描述: Enum服务类接口，用于实现Enum中文名称]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-31]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    //[Serializable]
    public interface IEnumService
	{
		/// <summary>
		/// 得到枚举中文名称
		/// </summary>
		/// <param name="enumType">枚举</param>
		/// <returns>中文名称</returns>
		string GetName(Enum enumType);
		
		/// <summary>
		/// 枚举数组
		/// </summary>
		FrameWork.Models.NeuObject[] ObjectItems
		{
			get;
		}
		
		/// <summary>
		/// 枚举中文数组
		/// </summary>
		string[] StringItems
		{
			get;			
		}

	}
}
