using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// PayKind 的摘要说明。
	/// 结算类别-付费类别
	///  01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干              
	/// ID 编码 Name 名称
	/// </summary>
	public class PayKind:Neusoft.NFC.Object.NeuObject
	{
		public PayKind()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 药品追加比率
		/// </summary>
		public float MedicalRate=1;
		/// <summary>
		/// 非药品追加比率
		/// </summary>
		public float OtherRate=1;
		public new string ID
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID=value;
			}
		}
		public new PayKind  Clone()
		{
			return base.Clone() as PayKind;
		}
	}
}
