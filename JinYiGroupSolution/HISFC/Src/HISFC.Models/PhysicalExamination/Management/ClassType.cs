namespace Neusoft.HISFC.Object.PhysicalExamination.Management
{
	/// <summary>
	/// ClassType <br></br>
	/// [功能描述: 类的类别实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ClassType : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 变量
		
		/// <summary>
		/// 所属类别名称
		/// </summary>
		private string belongType = "";

		#endregion

		#region 属性

		/// <summary>
		/// 所属类别名称，一般是表名
		/// </summary>
		public string BelongType
		{
			get
			{
				return this.belongType;
			}
			set
			{
				this.belongType = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new ClassType Clone()
		{
			ClassType classType = base.Clone() as ClassType;

			return classType;
		}

		#endregion
	}
}
