using System;
using Neusoft.HISFC;
namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.Combo<br></br>
	/// [功能描述: 医嘱组合信息实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Combo:Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// ID 组合号 Name 暂无
		/// </summary>
		public Combo()
		{
			// TODO: 在此处添加构造函数逻辑
		}
		
		#region 变量

		/// <summary>
		/// 是否主药
		/// </summary>
		private bool isMainDrug = false;

		#endregion

		#region 属性

		/// <summary>
		/// 是否主药
		/// </summary>
		public bool IsMainDrug 
		{
			get
			{
				return this.isMainDrug;
			}
			set
			{
				this.isMainDrug = value;
			}
		}

		#endregion

		#region 作废的

		/// <summary>
		/// 是否主药
		/// </summary>
		[Obsolete("用IsMainDrug代替",false)]
		public bool MainDrug 
		{
			get
			{
				return this.isMainDrug;
			}
			set
			{
				this.isMainDrug = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new  Combo Clone()
		{
			return base.Clone() as Combo;
		}

		#endregion

		#endregion

	}
}
