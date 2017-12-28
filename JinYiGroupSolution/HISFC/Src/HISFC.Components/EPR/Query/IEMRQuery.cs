using System;
using System.Data;
namespace Neusoft.HISFC.Components.EPR.Query
{
	/// <summary>
	/// IEMRQuery 的摘要说明。
	/// </summary>
	public interface IEMRQuery
	{
		/// <summary>
		/// 当前患者
		/// </summary>
		string  InpatientNo{get;set;}
		/// <summary>
		/// 查询结果
		/// </summary>
		/// <returns></returns>
		DataSet Query();
	}
}
