namespace Neusoft.HISFC.Object.PhysicalExamination.Collective
{
	/// <summary>
	/// Employee <br></br>
	/// [功能描述: 集体人员实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Employee : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		#region 私有变量

		/// <summary>
		/// 人员类别
		/// </summary>
		private EmployeeType employeeType;

		/// <summary>
		/// 所属集体
		/// </summary>
		private Collective collective;

		#endregion

		#region 属性

		/// <summary>
		/// 人员类别
		/// </summary>
		public EmployeeType EmployeeType 
		{
			get 
			{
				return this.employeeType;
			}
			set 
			{
				this.employeeType = value;
			}
		}

		/// <summary>
		/// 所属集体
		/// </summary>
		public Collective Collective
		{
			get
			{
				return this.collective;
			}
			set
			{
				this.collective = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Employee Clone()
		{
			Employee employee = base.Clone() as Employee;

			employee.EmployeeType = this.EmployeeType.Clone();
			employee.Collective = this.Collective.Clone();

			return employee;
		}

		#endregion
	}
}
