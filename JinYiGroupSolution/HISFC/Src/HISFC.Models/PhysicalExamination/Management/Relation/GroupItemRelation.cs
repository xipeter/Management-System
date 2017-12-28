namespace Neusoft.HISFC.Object.PhysicalExamination.Management.Relation 
{
	/// <summary>
	/// 组套与项目的关系
	/// </summary>
	public class GroupItemRelation : Group 
	{

		/// <summary>
		/// 项目
		/// </summary>
		private Neusoft.HISFC.Object.Base.Item item;

		/// <summary>
		/// 项目
		/// </summary>
		public Neusoft.HISFC.Object.Base.Item Item 
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
