using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Fee.Item;

namespace Neusoft.HISFC.Models.Terminal
{
	/// <summary>
	/// MedTechItem <br></br>
	/// [功能描述: 医技预约项目信息]<br></br>
	/// [创 建 者: sunxh]<br></br>
	/// [创建时间: 2005-3-3]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class MedTechItem : Neusoft.FrameWork.Models.NeuObject
	{
		public MedTechItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量
		
		/// <summary>
		/// 项目
		/// </summary>
		private Neusoft.HISFC.Models.Fee.Item.Undrug item = new Undrug();
		
		/// <summary>
		/// 项目扩展信息
		/// </summary>
		private ItemExtend itemExtend = new ItemExtend();
		
		#endregion

		#region 属性

		/// <summary>
		/// 项目信息
		/// </summary>
		public Neusoft.HISFC.Models.Fee.Item.Undrug Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}
		
		/// <summary>
		/// 项目扩展信息
		/// </summary>
		public ItemExtend ItemExtend
		{
			get
			{
				return this.itemExtend;
			}
			set
			{
				this.itemExtend = value;
			}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>医技预约项目信息</returns>
		public new MedTechItem Clone()
		{
			MedTechItem medTechItem = base.Clone() as MedTechItem;
			
			medTechItem.Item = this.Item.Clone();
			medTechItem.itemExtend = this.itemExtend.Clone();
			
			return medTechItem;
		}

		#endregion
	}
}
