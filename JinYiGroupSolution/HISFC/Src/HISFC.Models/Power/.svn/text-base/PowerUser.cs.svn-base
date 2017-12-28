using System;
using System.Collections;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// User 的摘要说明。
	/// </summary>
	public class PowerUser : neusoft.neuFC.Object.neuObject       
	{
		public PowerUser()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			
			//

			Department = new neusoft.neuFC.Object.neuObject();
			GrantDepartment = new neusoft.neuFC.Object.neuObject();

			Department.ID = "";
			Department.Name = "";
		}

		//ID;
		//Name;

		/// <summary>
		/// 权限部门
		/// </summary>
		public neuFC.Object.neuObject Department;

		public neuFC.Object.neuObject GrantDepartment;


		private IList powerDetails ;
		private IList roleDetails;


		public string PowerClass1 ;
		public string PowerClass2 ;
		public string PowerClass3 ;


		/// <summary>
		/// 人员的扩展权限
		/// </summary>
		public IList PowerDetails
		{
			get
			{
				return this.powerDetails;
			}
			set
			{
				this.powerDetails = value;
			}
		}


		public IList RoleDetails
		{
			get
			{
				return this.roleDetails;
			}
			set
			{
				this.roleDetails = value;
			}
		}
	}
}
