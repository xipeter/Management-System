namespace Neusoft.HISFC.Object.PhysicalExamination.Evaluation 
{
	/// <summary>
	/// 每次体检的饮食评估
	/// </summary>
	public class RegisterDieteticEvaluation : Neusoft.HISFC.Object.PhysicalExamination.Base.PE 
	{

		/// <summary>
		/// 体检登记信息
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Register.Register register;

		/// <summary>
		/// 评估
		/// </summary>
		private IntegratedEvaluation evaluation;

		/// <summary>
		/// 评估
		/// </summary>
		public IntegratedEvaluation Evaluation 
		{
			get 
			{
				return this.evaluation;
			}
			set 
			{
				this.evaluation = value;
			}
		}

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
	}
}
