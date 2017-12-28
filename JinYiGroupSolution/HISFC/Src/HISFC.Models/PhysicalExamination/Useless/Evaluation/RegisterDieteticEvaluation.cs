namespace Neusoft.HISFC.Models.PhysicalExamination.Evaluation 
{
	/// <summary>
	/// 每次体检的饮食评估
	/// </summary>
    [System.Serializable]
    public class RegisterDieteticEvaluation : Neusoft.HISFC.Models.PhysicalExamination.Base.PE 
	{

		/// <summary>
		/// 体检登记信息
		/// </summary>
        private Neusoft.HISFC.Models.PhysicalExamination.Useless.Register.Register register;

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
        public Neusoft.HISFC.Models.PhysicalExamination.Useless.Register.Register Register 
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
