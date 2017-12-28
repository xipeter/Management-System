using System;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EnumNotFoundException<br></br>
	/// [功能描述: 枚举服务未找到异常]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-31]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class EnumNotFoundException : ApplicationException 
	{
		public EnumNotFoundException( Enum enumType ) : 
			base("未在枚举服务类中找到枚举: " + enumType.GetType().ToString() + "." + enumType.ToString()) 
		{
		}
	}
}
