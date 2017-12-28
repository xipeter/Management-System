namespace Neusoft.HISFC.Object.PhysicalExamination.Management
{
	/// <summary>
	/// Query <br></br>
	/// [功能描述: 查询码实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Query : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 变量

		/// <summary>
		/// 所属表
		/// </summary>
		private string table = "";
		
		/// <summary>
		/// 体检业务
		/// </summary>
		private Business business = new Business();
		
		#endregion

		#region 属性
		
		/// <summary>
		/// 所属表
		/// </summary>
		public string Table
		{
			get
			{
				return this.table;
			}
			set
			{
				this.table = value;
			}
		}
		
		/// <summary>
		/// 体检业务
		/// </summary>
		public Business Business
		{
			get
			{
				return this.business;
			}
			set
			{
				this.business = value;
			}
		}
		
		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Query Clone()
		{
			Query query = base.Clone() as Query;

			query.Business = this.Business.Clone();

			return query;
		}
		
		#endregion
	}
}
