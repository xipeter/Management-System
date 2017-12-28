namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// Role <br></br>
	/// [功能描述: 体检权限]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Role : Neusoft.HISFC.Object.PhysicalExamination.Base.PE 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Role()
		{

		}

		#region 私有变量
		
		/// <summary>
		/// 体检用户
		/// </summary>
		private PEUser user;

		#endregion

		#region 属性

		/// <summary>
		/// 体检用户
		/// </summary>
		public PEUser User 
		{
			get 
			{
				return this.user;
			}
			set 
			{
				this.user = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检权限</returns>
		public new Role Clone()
		{
			Role role = base.Clone() as Role;

			role.User = this.User.Clone();

			return role;
		}
		#endregion
	}
}
