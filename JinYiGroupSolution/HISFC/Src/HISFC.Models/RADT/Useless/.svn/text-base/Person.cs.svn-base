using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// Person <br></br>
	/// [功能描述: 人员实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2004-05]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-09-11'
	///		修改目的='版本整合'
	///		修改描述=''
	///  />
	/// </summary>
	[Obsolete("已经过期，更改为Neusoft.HISFC.Models.Base.Employee",true)]
	public class Person : Neusoft.HISFC.Models.Base.Spell 
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Person()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept
		{
			get
			{
				if(myDept==null)myDept=new Neusoft.FrameWork.Models.NeuObject();
				return myDept;
			}
			set
			{
				if(value==null)value=new Neusoft.FrameWork.Models.NeuObject();
				this.myDept=value;
				this.Memo=this.myDept.ID;
				this.User01=this.myDept.Name;
			}
		}
		/// <summary>
		/// 病区
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Nurse
		{
			get
			{
				if(myNurse==null)myNurse=new Neusoft.FrameWork.Models.NeuObject();
				return myNurse;
			}
			set
			{
				if(value==null)value=new Neusoft.FrameWork.Models.NeuObject();
				this.myNurse=value;
				this.User02=this.myNurse.ID;
				this.User03=this.myNurse.Name;
			}
		}	
	
		#region 变量

		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord;

		#endregion

		/// <summary>
		/// 职务
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Duty=new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 是否专家
		/// </summary>
		public bool IsExpert=false;
		/// <summary>
		/// 专家
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Expert=new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 职级
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Level=new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 是否可以开麻药
		/// </summary>
		public bool drugPermission=false;
		/// <summary>
		/// 权限属于组
		/// </summary>
		public ArrayList PermissionGroup=new ArrayList();
		/// <summary>
		/// 权限
		/// </summary>
		public ArrayList Permission=new ArrayList();
		/// <summary>
		/// 当前选择的组
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject curGroup=new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 当前选择的权限
		/// </summary>
		public string curPermission;
		/// <summary>
		/// 菜单
		/// </summary>
		public string Menu;
		/// <summary>
		/// 是否管理员
		/// </summary>
		public bool isManager=false;
		protected Neusoft.FrameWork.Models.NeuObject myDept;
		protected Neusoft.FrameWork.Models.NeuObject myNurse;


		
		
		public EnumSex Sex = new EnumSex();
		
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime BirthDay;  		
//		public string LevelCode;
		public string EducationCode;

		/// <summary>
		/// 身份证号
		/// </summary>
		public string IdenCode; 	

		public PersonType PersonType = new PersonType();
		public bool CanModify;
		public bool CanNoRegFee;
		public int ValidState;
		public int  SortID;

		public new Person Clone()
		{
			Person obj=base.Clone() as Person;
			obj.Dept=this.Dept.Clone();
			obj.Nurse=this.Nurse.Clone();
			return obj;
		}
		

	}
}
