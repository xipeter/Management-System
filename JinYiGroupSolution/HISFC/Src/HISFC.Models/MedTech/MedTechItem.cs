using System;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// Deptitemdetail 的摘要说明。
	/// </summary>
	public class MedTechItem :neusoft.neuFC.Object.neuObject
	{
		public MedTechItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 项目信息
		/// </summary>
		public neusoft.HISFC.Object.Fee.Item Item = new neusoft.HISFC.Object.Fee.Item();
		/// <summary>
		/// 项目扩展信息
		/// </summary>
		public neusoft.HISFC.Object.MedTech.ItemExtend ItemExtend = new ItemExtend();
		public new MedTechItem Clone()
		{
			MedTechItem obj=base.Clone() as MedTechItem;
						obj.Item =this.Item.Clone();
//						obj.MedTechItemExtend = this.MedTechItemExtend.Clone();
			return obj;
		}
	}
}
