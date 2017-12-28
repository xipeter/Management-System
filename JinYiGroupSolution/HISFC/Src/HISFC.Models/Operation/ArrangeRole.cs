using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// [功能描述: 手术麻醉人员安排人员类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-10-02]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class ArrangeRole : Neusoft.HISFC.Models.Base.Employee
	{
		//角色类型
		private OperationRoleEnumService roleType = new OperationRoleEnumService(); 
		/// <summary>
		/// 角色状态(目前只针对麻醉安排有用)
		/// </summary>
        private RoleOperKindEnumService roleOperKind = new RoleOperKindEnumService();

		public ArrangeRole()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public ArrangeRole(Neusoft.FrameWork.Models.NeuObject neuObject)
        {
            this.ID = neuObject.ID;
            this.Name = neuObject.Name;
            this.Memo = neuObject.Memo;
        }

		//手术申请单序号
		public string OperationNo = string.Empty;

		/// <summary>
		/// 0术前安排1术后记录 标志
		/// </summary>
		public string ForeFlag = "0";

        /// <summary>
        /// 角色类型
        /// </summary>
		public OperationRoleEnumService RoleType 
		{
			get
			{ 
				return roleType; 
			}
			set
			{ 
				roleType = value; 
			}
		}

        /// <summary>
        /// 角色状态(目前只针对麻醉安排有用)
        /// </summary>
		public RoleOperKindEnumService RoleOperKind 
		{
			get
			{
				return this.roleOperKind;
			}
			set
			{
				this.roleOperKind = value;
			}
		}
	}
}
