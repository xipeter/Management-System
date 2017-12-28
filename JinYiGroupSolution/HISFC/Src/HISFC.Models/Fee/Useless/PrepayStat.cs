using System;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// PrepayStat 的摘要说明。
	/// TODO:
	/// 需要进一步讨论
	/// </summary>
    /// 
    [System.Serializable]
	public class PrepayStat:Neusoft.FrameWork.Models.NeuObject
	{
		public PrepayStat()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public string BeginDate;
		/// <summary>
		/// 结束时间
		/// </summary>
		public string EndDate;
		/// <summary>
		///  预交现金
		/// </summary>
		public decimal Pre_Cost;
		/// <summary>
		/// 预交支票
		/// </summary>
		public decimal Pre_Check;
		/// <summary>
		/// 预交其他
		/// </summary>
		public decimal Pre_Other;
		/// <summary>
		/// 预交汇票
		/// </summary>
		public decimal Pre_Draft;
		/// <summary>
		/// 转押金
		/// </summary>
		public decimal Foregift_Cost;
		/// <summary>
		/// 票据区间
		/// </summary>
		public string Receipt;
		/// <summary>
		/// 预交张数
		/// </summary>
		public int PrepayNum;
		/// <summary>
		/// 预交作废票子号
		/// </summary>
		public string ReturnNo;
		
	}
}
