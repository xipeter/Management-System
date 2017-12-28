using Neusoft.HISFC.Object.PhysicalExamination.Base;

namespace Neusoft.HISFC.Object.PhysicalExamination.Collective
{
	/// <summary>
	/// Collective <br></br>
	/// [功能描述: 集体实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Collective : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 变量
		
		/// <summary>
		/// 集体类别
		/// </summary>
		private PE collectiveTYpe = new PE();

		#endregion

		#region 属性

		/// <summary>
		/// 集体类别
		/// </summary>
		public PE CollectiveType 
		{
			get 
			{
				return this.collectiveTYpe;
			}
			set 
			{
				this.collectiveTYpe = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检集体</returns>
		public new Collective Clone()
		{
			Collective collective = base.Clone() as Collective;

			collective.CollectiveType = this.CollectiveType.Clone();

			return collective;
		}
		#endregion
	}
}
