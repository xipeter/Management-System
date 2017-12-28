namespace Neusoft.HISFC.Object.PhysicalExamination.Evaluation
{
	/// <summary>
	/// 饮食结构项目
	/// </summary>
	public class DieteticItem : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 参考内容
		/// </summary>
		private string referenceContent;

		/// <summary>
		/// 参考内容
		/// </summary>
		public string ReferenceContent
		{
			get
			{
				return this.referenceContent;
			}
			set
			{
				this.referenceContent = value;
			}
		}
	}
}
