namespace Neusoft.HISFC.Object.PhysicalExamination.Management.Relation
{
	/// <summary>
	/// 科室项目关系
	/// </summary>
	public class DeptItemRelation : Neusoft.HISFC.Object.PhysicalExamination.Management.Department
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