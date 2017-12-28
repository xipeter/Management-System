namespace Neusoft.HISFC.Object.PhysicalExamination.Evaluation 
{
	/// <summary>
	/// 饮食评估
	/// </summary>
	public class DieteticEvaluation : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 体检登记信息
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Register.Register register;

		/// <summary>
		/// 体检登记信息
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Register.Register Register 
		{
			get 
			{
				return this.register;
			}
			set 
			{
				this.register = value;
			}
		}

		/// <summary>
		/// 饮食评估结果
		/// </summary>
		private DieteticItemResult itemResult;

		/// <summary>
		/// 饮食评估结果
		/// </summary>
		public DieteticItemResult ItemResult 
		{
			get 
			{
				return this.itemResult;
			}
			set 
			{
				this.itemResult = value;
			}
		}
	}
}
