namespace Neusoft.HISFC.Models.PhysicalExamination.Evaluation 
{
	/// <summary>
	/// 饮食评估
	/// </summary>
    [System.Serializable]
    public class DieteticEvaluation : Neusoft.HISFC.Models.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 体检登记信息
		/// </summary>
        private Neusoft.HISFC.Models.PhysicalExamination.Useless.Register.Register register;

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
