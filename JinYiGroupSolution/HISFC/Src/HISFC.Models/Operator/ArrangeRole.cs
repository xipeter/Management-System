using System;
using System.Collections;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// 手术麻醉人员安排人员类
	/// </summary>
	public class ArrangeRole:neusoft.neuFC.Object.neuObject
	{
		//角色类型
		private neusoft.HISFC.Object.Operator.ArrangeRoleType roleType; 
		//角色人员
		private neusoft.HISFC.Object.RADT.Person person;
		/// <summary>
		/// 角色状态(目前只针对麻醉安排有用)
		/// </summary>
		private neusoft.HISFC.Object.Operator.RoleOperKind roleOperKind;
		public ArrangeRole()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			roleType = new ArrangeRoleType();
			person = new neusoft.HISFC.Object.RADT.Person();
			roleOperKind = new RoleOperKind();
		}	
		//手术申请单序号
		public string OperationNo = "";
		/// <summary>
		/// 0术前安排1术后记录 标志
		/// </summary>
		public string ForeFlag = "0";			

		public ArrangeRoleType RoleType
		{
			get{ return roleType; }
			set{ roleType = value; }
		}

		public neusoft.HISFC.Object.RADT.Person Person
		{
			get{return person;}
			set{person = value;}
		}
		
		public RoleOperKind RoleOperKind
		{
			get{return roleOperKind;}
			set{roleOperKind = value;}
		}
	}
}
