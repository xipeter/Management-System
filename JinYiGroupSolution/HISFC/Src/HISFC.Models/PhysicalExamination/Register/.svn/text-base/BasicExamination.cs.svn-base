namespace Neusoft.HISFC.Object.PhysicalExamination.Register 
{
	/// <summary>
	/// BasicExamination <br></br>
	/// [功能描述: 身体基本状况]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class BasicExamination : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 私有变量
		
		/// <summary>
		/// 项目的定性结果
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.ItemQualitativeResult itemQualitativeResult;

		/// <summary>
		/// 值类型结果
		/// </summary>
		private decimal valueResult;

		#endregion

		#region 属性

		/// <summary>
		/// 项目的定性结果
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.ItemQualitativeResult ItemQualitativeResult 
		{
			get 
			{
				return this.itemQualitativeResult;
			}
			set 
			{
				this.itemQualitativeResult = value;
			}
		}

		/// <summary>
		/// 值类型结果
		/// </summary>
		public decimal ValueResult
		{
			get
			{
				return this.valueResult;
			}
			set
			{
				this.valueResult = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>身体基本状况</returns>
		public new BasicExamination Clone()
		{
			BasicExamination basicExamination = base.Clone() as BasicExamination;

			basicExamination.ItemQualitativeResult = this.ItemQualitativeResult.Clone();

			return basicExamination;
		}

		#endregion
	}
}
