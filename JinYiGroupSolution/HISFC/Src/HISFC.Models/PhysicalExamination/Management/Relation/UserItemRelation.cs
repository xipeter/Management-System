namespace Neusoft.HISFC.Object.PhysicalExamination.Management.Relation 
{
	/// <summary>
	/// 用户与项目的关系，用于体检结果录入时的验证
	/// </summary>
	public class UserItemRelation : PEUser 
	{

		/// <summary>
		/// 项目
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.Item item;

		/// <summary>
		/// 项目
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.Item Item 
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
	}
}
