namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// PEMeal <br></br>
	/// [功能描述: 体检套餐]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class PEMeal : Neusoft.HISFC.Object.PhysicalExamination.Base.PE 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PEMeal()
		{

		}

		#region 私有变量
		
		/// <summary>
		/// 价格
		/// </summary>
		private Price price;

		#endregion

		#region 属性

		/// <summary>
		/// 价格
		/// </summary>
		public Price Price 
		{
			get 
			{
				return this.price;
			}
			set 
			{
				this.price = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PEMeal Clone()
		{
			PEMeal peMeal = base.Clone() as PEMeal;
			
			peMeal.Price = this.Price.Clone();

			return peMeal;
		}
		#endregion
	}
}
