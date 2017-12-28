using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// BedFeeInfo 的摘要说明。
	/// </summary>
	public class BedFeeInfo	: Neusoft.NFC.Object.NeuObject, Neusoft.HISFC.Object.Base.ISort
	{
		public BedFeeInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string ItemCode;
		public string ItemName;
		public int  Number;
		public DateTime StartTime;
		public DateTime EndTime;
		public bool HasRelationToBaby;
		public bool HasRelationToTime;
		public bool ValidState;

		private int sortId;
		#region ISort 成员

		public int SortID
		{
			get
			{
				// TODO:  添加 BedFeeInfo.SortID getter 实现
				return sortId;
			}
			set
			{
				// TODO:  添加 BedFeeInfo.SortID setter 实现
				sortId = value;
			}
		}

		#endregion
	}
}
