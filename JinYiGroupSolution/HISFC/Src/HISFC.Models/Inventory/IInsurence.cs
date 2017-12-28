using System;

namespace Neusoft.HISFC.Models.Insurance
{
	/// <summary>
	/// IInsurence 的摘要说明。
	/// </summary>
    //[Serializable]
    public interface IInsurence
	{
		/// <summary>
		/// 医保中心编码
		/// </summary>
		string CenterCode{get;set;}
		/// <summary>
		/// 医保中心名称
		/// </summary>
		string CenterName{get;set;}
		/// <summary>
		/// 医保审批号
		/// </summary>
		string ApprNo{get;set;}
		/// <summary>
		/// 医保项目代码
		/// </summary>
		string ItemCode{get;set;}
		/// <summary>
		/// 医保项目名称
		/// </summary>
		string ItemName{get;set;}
		/// <summary>
		/// 是否急救
		/// </summary>
		bool IsEmergency{get;set;}
		/// <summary>
		/// 项目类别，甲，乙...
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject Type{get;set;}
	}
}
