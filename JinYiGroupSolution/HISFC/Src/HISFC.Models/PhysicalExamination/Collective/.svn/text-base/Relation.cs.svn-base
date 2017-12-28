using Neusoft.HISFC.Object.PhysicalExamination.Base;

namespace Neusoft.HISFC.Object.PhysicalExamination.Collective
{
	/// <summary>
	/// Relation <br></br>
	/// [功能描述: 联系方式]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Relation : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 私有变量

		/// <summary>
		/// 联系方式类别
		/// </summary>
		private PE relationType = new PE();

		#endregion

		#region 属性

		/// <summary>
		/// 联系方式类别
		/// </summary>
		public PE RelationType 
		{
			get 
			{
				return this.relationType;
			}
			set 
			{
				this.relationType = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>联系方式</returns>
		public new Relation Clone()
		{
			Relation relation = base.Clone() as Relation;

			relation.RelationType = this.RelationType.Clone();

			return relation;
		}

		#endregion
	}
}
