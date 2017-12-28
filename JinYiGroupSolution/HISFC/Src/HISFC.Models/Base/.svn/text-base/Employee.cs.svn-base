using System;
using System.Collections;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Employee <br></br>
	/// [功能描述: 人员实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Employee :  Spell,  ISort, IValidState
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Employee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 病区
		/// </summary>
        protected Neusoft.FrameWork.Models.NeuObject nurse = new NeuObject();

		/// <summary>
		/// 科室
		/// </summary>
        protected Neusoft.FrameWork.Models.NeuObject dept = new NeuObject();

		/// <summary>
		/// 密码
		/// </summary>
		private string password;

		/// <summary>
		/// 职务
		/// </summary>
		private NeuObject duty = new NeuObject();

		/// <summary>
		/// 是否专家
		/// </summary>
		private bool isExpert;

		/// <summary>
		/// 专家
		/// </summary>
		private NeuObject expert = new NeuObject();

		/// <summary>
		/// 职级
		/// </summary>
		private NeuObject level = new NeuObject();

		/// <summary>
		/// 是否可以开麻药
		/// </summary>
		private bool isPermissionAnesthetic;

		/// <summary>
		/// 权限属于组
		/// </summary>
		private ArrayList permissionGroup = new ArrayList();

		/// <summary>
		/// 权限
		/// </summary>
		private ArrayList permission = new ArrayList();

		/// <summary>
		/// 当前选择的组
		/// </summary>
		private NeuObject currentGroup = new NeuObject();

		/// <summary>
		/// 当前选择的权限
		/// </summary>
		private string currentPermission;

		/// <summary>
		/// 菜单
		/// </summary>
		private string menu;

		/// <summary>
		/// 是否管理员
		/// </summary>
		private bool isManager;

		/// <summary>
		/// 性别
		/// </summary>
		private SexEnumService sex = new SexEnumService();

		/// <summary>
		/// 出生日期
		/// </summary>
		private DateTime birthDay;  

		/// <summary>
		/// 身份证
		/// </summary>
		private string idCard;

		/// <summary>
		/// 人员类别
		/// </summary>
		private EmployeeTypeEnumService employeeType = new EmployeeTypeEnumService();

		/// <summary>
		/// 排序序号
		/// </summary>
		private int  sortID;

		/// <summary>
		/// 员工状态
		/// </summary>
		private Base.EnumValidState validState;

		/// <summary>
		/// 是否有修改票据权限 1允许 0不允许
		/// </summary>
		private bool isCanModify;

		/// <summary>
		/// 毕业院校
		/// </summary>
		private NeuObject graduateSchool = new NeuObject();

		/// <summary>
		/// 不挂号就收费权限 0 不允许 1允许
		/// </summary>
		private bool isNoRegCanCharge;

        #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名
        /// <summary>
        /// 人员基本信息扩展类
        /// </summary>
        private EmployeeExt employeeExt = new EmployeeExt();

        #endregion

        #endregion

        #region 属性

        #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

        /// <summary>
        /// 人员基本信息扩展类
        /// </summary>
        public EmployeeExt EmployeeExt
        {
            get { return employeeExt; }
            set { employeeExt = value; }
        }

        #endregion

        /// <summary>
		/// 毕业院校
		/// </summary>
		public NeuObject GraduateSchool
		{
			get
			{
				return this.graduateSchool;
			}
			set
			{
				this.graduateSchool = value;
			}
		}

		/// <summary>
		/// 不挂号就收费权限 0 不允许 1允许
		/// </summary>
		public bool IsNoRegCanCharge
		{
			get
			{
				return this.isNoRegCanCharge;
			}
			set
			{
				this.isNoRegCanCharge = value;
			}
		}

		/// <summary>
		/// 是否有修改票据权限 1允许 0不允许
		/// </summary>
		public bool IsCanModify
		{
			get
			{
				return this.isCanModify;
			}
			set
			{
				this.isCanModify = value;
			}
		}

		/// <summary>
		/// 员工状态
		/// </summary>
        public Base.EnumValidState ValidState
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;
			}
		}

		/// <summary>
		/// 人员类别
		/// </summary>
		public EmployeeTypeEnumService EmployeeType
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
		/// 身份证
		/// </summary>
		public string IDCard
		{
			get
			{
				return this.idCard;
			}
			set
			{
				this.idCard = value;
			}
		}

		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime Birthday
		{
			get
			{
				return this.birthDay;
			}
			set
			{
				this.birthDay = value;
			}
		}

		/// <summary>
		/// 性别
		/// </summary>
		public SexEnumService Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}

		/// <summary>
		/// 病区
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Nurse
		{
			get
			{
				
				return nurse;
			}
			set
			{
                this.nurse = value;
			}
		}

		/// <summary>
		/// 科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept
		{
			get
			{
				
				return dept;
			}
			set
			{
                this.dept = value;
			}
		}

		/// <summary>
		/// 是否管理员
		/// </summary>
		public bool IsManager
		{
			get
			{
				return this.isManager;
			}
			set
			{
				this.isManager = value;
			}
		}

		/// <summary>
		/// 菜单
		/// </summary>
		public string Menu
		{
			get
			{
				return this.menu;
			}
			set
			{
				this.menu = value;
			}
		}

		/// <summary>
		/// 当前选择的权限
		/// </summary>
		public string CurrentPermission
		{
			get
			{
				return this.currentPermission;
			}
			set
			{
				this.currentPermission = value;
			}
		}

		/// <summary>
		/// 当前选择的组
		/// </summary>
		public NeuObject CurrentGroup
		{
			get
			{
				return this.currentGroup;
			}
			set
			{
				this.currentGroup = value;
			}
		}

		/// <summary>
		/// 权限
		/// </summary>
		public ArrayList Permission
		{
			get
			{
				return this.permission;
			}
			set
			{
				this.permission = value;
			}
		}

		/// <summary>
		/// 权限属于组
		/// </summary>
		public ArrayList PermissionGroup
		{
			get
			{
				return this.permissionGroup;
			}
			set
			{
				this.permissionGroup = value;
			}
		}

		/// <summary>
		/// 是否允许开麻药
		/// </summary>
		public bool IsPermissionAnesthetic
		{
			get
			{
				return this.isPermissionAnesthetic;
			}
			set
			{
				this.isPermissionAnesthetic = value;
			}
		}

		/// <summary>
		/// 职级
		/// </summary>
		public NeuObject Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		/// <summary>
		/// 专家
		/// </summary>
		public NeuObject Expert
		{
			get
			{
				return this.expert;
			}
			set
			{
				this.expert = value;
			}
		}

		/// <summary>
		/// 是否专家
		/// </summary>
		public bool IsExpert
		{
			get
			{
				return this.isExpert;
			}
			set
			{
				this.isExpert = value;
			}
		}

		/// <summary>
		/// 职务
		/// </summary>
		public NeuObject Duty
		{
			get
			{
				return this.duty;
			}
			set
			{
				this.duty = value;
			}
		}

		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}
		#endregion

		#region 过期

		/// <summary>
		/// 当前选择的权限
		/// </summary>
		[Obsolete("已经过期，更改为CurrentPermission")]
		public string curPermission;

		/// <summary>
		/// 当前选择的组
		/// </summary>
		[Obsolete("已经过期，更改为CurrentGroup")]
		public Neusoft.FrameWork.Models.NeuObject curGroup=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 密码
		/// </summary>
		[Obsolete("已经过期，更改为Password")]
		public string PassWord;

		/// <summary>
		/// 是否可以开麻药
		/// </summary>
		[Obsolete("已经过期，更改为IsPermissionAnesthetic")]
		public bool drugPermission;

		/// <summary>
		/// 身份证号
		/// </summary>
		[Obsolete("已经过期，更改为IDCard")]
		public string IdenCode;

		/// <summary>
		/// 不挂号就收费权限 0 不允许 1允许
		/// </summary>
		[Obsolete("已经过期，更改为IsNoRegCanCharge")]
		public bool CanNoRegFee;

		/// <summary>
		/// 毕业院校
		/// </summary>
		[Obsolete("已经过期，更改为对象GraduateSchool")]
		public string EducationCode;
		
		/// <summary>
		/// 人员类别
		/// </summary>
		[Obsolete("已经过期，更改为对象EmployeeType")]
		public string PersonType;


		/// <summary>
		/// 是否可以更改
		/// </summary>
		[Obsolete("已经过期，更改为对象IsModify")]
		public string Modify;
		#endregion

		#region ISort 成员

		/// <summary>
		/// 排序序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
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

			employee.Dept = this.Dept.Clone();
			employee.Nurse = this.Nurse.Clone();
			employee.GraduateSchool = this.GraduateSchool.Clone();
			employee.CurrentGroup = this.CurrentGroup.Clone();
			employee.Level = this.Level.Clone();
			employee.Expert = this.Expert.Clone();
			employee.Duty = this.Duty.Clone();

			return employee;
		}

		#endregion
		
	}
}
