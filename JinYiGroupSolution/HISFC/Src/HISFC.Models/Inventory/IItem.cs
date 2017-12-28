using System;

namespace Neusoft.HISFC.Models.Insurance
{
	/// <summary>
	/// IItem 的摘要说明。
	/// </summary>
    //[Serializable]
	public interface IItem
	{
		/// <summary>
		/// 医保项目代码
		/// </summary>
		string ItemCode{get;set;}
		/// <summary>
		/// 医保项目名称
		/// </summary>
		string ItemName{get;set;}
		bool IsEmergency{get;set;}
		//		/// <summary>
		//		/// 急诊加成比例
		//		/// </summary>
		//		public decimal EmcRate;
		//		/// <summary>
		//		/// 计划生育标记
		//		/// </summary>
		//		public bool Family;
		//		///<summary>
		//		///特定治疗项目
		//		///</summary>
		//		public string  Special;
		//		///<summary>
		//		///甲乙类
		//		///</summary>
		//		public string  ItemGrade;
		/// <summary>
		/// 项目类别，甲，乙...
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject Type{get;set;}
	}
}
