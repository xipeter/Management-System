namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// Group <br></br>
	/// [功能描述: 组合项目实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Group : Neusoft.HISFC.Object.PhysicalExamination.Base.PE 
	{
		public Group()
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
		/// <returns>组合项目类</returns>
		public new Group Clone()
		{
			Group group = base.Clone() as Group;

			group.Price = this.Price.Clone();

			return group;
		}
		#endregion
	}
}
