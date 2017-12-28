namespace Neusoft.HISFC.Object.PhysicalExamination.Register 
{
	/// <summary>
	/// RegisterItem <br></br>
	/// [功能描述: 体检登记开立的体检收费项目，一般来自于体检套餐]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class RegisterItem : Neusoft.HISFC.Object.PhysicalExamination.Management.Item
	{
		#region 私有变量
		
		/// <summary>
		/// 体检登记信息
		/// </summary>
		private Register register;

		/// <summary>
		/// 开立数量
		/// </summary>
		private decimal count;

		/// <summary>
		/// 项目的定性结果
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.ItemQualitativeResult qualitativeResult;

		/// <summary>
		/// 项目的执行信息
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Confirm.Confirm confirm;

		#endregion

		#region 属性

		/// <summary>
		/// 体检登记信息
		/// </summary>
		public Register Register 
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
		/// 开立数量
		/// </summary>
		public decimal Count
		{
			get
			{
				return this.count;
			}
			set
			{
				this.count = value;
			}
		}

		/// <summary>
		/// 项目的定性结果
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.ItemQualitativeResult QualitativeResult
		{
			get
			{
				return this.qualitativeResult;
			}
			set
			{
				this.qualitativeResult = value;
			}
		}

		/// <summary>
		/// 项目的执行信息
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Confirm.Confirm Confirm
		{
			get
			{
				return this.confirm;
			}
			set
			{
				this.confirm = value;
			}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检登记开立的体检收费项目</returns>
		public new RegisterItem Clone()
		{
			RegisterItem registerItem = base.Clone() as RegisterItem;

			registerItem.Register = this.Register.Clone();
			registerItem.QualitativeResult = this.QualitativeResult.Clone();
			registerItem.Confirm = this.Confirm.Clone();
			
			return registerItem;
		}
		#endregion
	}
}
