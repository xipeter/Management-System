using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Cadjustundrugpricedetai 的摘要说明。
	/// </summary>
	public class Cadjustundrugpricedetai :Neusoft.NFC.Object.NeuObject
	{
		public Cadjustundrugpricedetai()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public string AdjustPriceNo;
		public string ItemCode;
		public string ItemName;
		public decimal PriceOld; //三甲价  旧
		public decimal PriceNew; // 三甲价 旧
		public decimal PriceOld1; //儿童价  旧
		public decimal PriceNew1; // 儿童价 旧
		public decimal PriceOld2; //特诊价  旧
		public decimal PriceNew2; // 特诊价 旧
		public string OperCode;
		public System.DateTime  operdate;
		public bool IsNow;

	}
}
