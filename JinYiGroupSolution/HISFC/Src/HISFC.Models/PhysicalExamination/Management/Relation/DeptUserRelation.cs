namespace Neusoft.HISFC.Object.PhysicalExamination.Management.Relation 
{


	/// <summary>
	/// 科室与用户的关系
	/// </summary>
	public class DeptUserRelation : Department {

		/// <summary>
		/// 用户
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.PEUser user;

		/// <summary>
		/// 用户
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.PEUser User 
		{
			get 
			{
				return this.user;
			}
			set 
			{
				this.user = value;
			}
		}
	}
}
