namespace Neusoft.HISFC.Object.PhysicalExamination.Register 
{
	/// <summary>
	/// SumCost <br></br>
	/// [功能描述: 总金额]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class SumCost : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 私有变量

		/// <summary>
		/// 体检登记的总金额
		/// </summary>
		private decimal registerCost;

		/// <summary>
		/// 体检收费的实际总金额
		/// </summary>
		private decimal chargeCost;

		#endregion

		#region 属性

		/// <summary>
		/// 体检登记的总金额
		/// </summary>
		public decimal RegisterCost 
		{
			get 
			{
				return this.registerCost;
			}
			set 
			{
				this.registerCost = value;
			}
		}

		/// <summary>
		/// 体检收费的实际总金额
		/// </summary>
		public decimal ChargeCost
		{
			get
			{
				return this.chargeCost;
			}
			set
			{
				this.chargeCost = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>总金额</returns>
		public new SumCost Clone()
		{
			return base.Clone() as SumCost;
		}
		#endregion
	}
}
