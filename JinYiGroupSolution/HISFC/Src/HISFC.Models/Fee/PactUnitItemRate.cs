using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// PactUnitItemRate 的摘要说明。
	/// id 合同代码 
	/// name 合同名称 
	/// </summary>
	public class PactUnitItemRate :Neusoft.NFC.Object.NeuObject 
	{
		
		public Neusoft.NFC.Object.NeuObject Item = new Neusoft.NFC.Object.NeuObject(); //项目代码 项目名称 或最小费用代码 最小费用名称
		
		/// <summary>
		/// 项目比例类别 0最小费用，1 药品，2 非药品
		/// </summary>
		public int ItemType = 0 ;

		public FTRate FTRate = new FTRate();//费用比例

		public string OperID ;
		public DateTime OperDateTime;

		public PactUnitItemRate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
