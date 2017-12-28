namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// Item <br></br>
	/// [功能描述: 体检项目实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Item : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Item()
		{

		}

		#region 私有变量
		
		/// <summary>
		/// 体检结果类型
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumResultType resultType;

		/// <summary>
		/// 是否需要预约
		/// </summary>
		private bool isNeedPrecontract;

		/// <summary>
		/// 是否是药品
		/// </summary>
		private bool isPharmacy;

		#endregion

		#region 属性

		/// <summary>
		/// 体检结果类型
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumResultType ResultType 
		{
			get 
			{
				return this.resultType;
			}
			set 
			{
				this.resultType = value;
			}
		}

		/// <summary>
		/// 是否需要预约
		/// </summary>
		public bool IsNeedPrecontract
		{
			get
			{
				return this.isNeedPrecontract;
			}
			set
			{
				this.isNeedPrecontract = value;
			}
		}

		/// <summary>
		/// 是否是药品
		/// </summary>
		public bool IsPharmacy
		{
			get
			{
				return this.isPharmacy;
			}
			set
			{
				this.isPharmacy = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检项目类</returns>
		public new Item Clone()
		{
			return base.Clone() as Item;
		}
		#endregion
	}
}
