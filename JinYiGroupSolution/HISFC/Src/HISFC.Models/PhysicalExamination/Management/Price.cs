namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// Price <br></br>
	/// [功能描述: 体检价格实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Price : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Price()
		{

		}

		#region 私有变量

		/// <summary>
		/// 个人收费价格，个人体检应该收取的价格
		/// </summary>
		private decimal individualPrice;

		/// <summary>
		/// 公司体检价格，公司或集体体检应该收取的价格
		/// </summary>
		private decimal companyPrice;
		
		#endregion

		#region 属性
		
		/// <summary>
		/// 个人收费价格，个人体检应该收取的价格
		/// </summary>
		public decimal IndividualPrice 
		{
			get 
			{
				return this.individualPrice;
			}
			set 
			{
				this.individualPrice = value;
			}
		}

		/// <summary>
		/// 公司体检价格，公司或集体体检应该收取的价格
		/// </summary>
		public decimal CompanyPrice 
		{
			get 
			{
				return this.companyPrice;
			}
			set 
			{
				this.companyPrice = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检价格函数</returns>
		public new Price Clone()
		{
			return base.Clone() as Price;
		}
		
		#endregion
	}
}
