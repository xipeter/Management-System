using System;
using System.Collections;

namespace Neusoft.HISFC.Object.RADT
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
	public class Person : Neusoft.HISFC.Object.Base.Spell 
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
		public Neusoft.NFC.Object.NeuObject Dept
		{
			get
			{
				if(myDept==null)myDept=new Neusoft.NFC.Object.NeuObject();
				return myDept;
			}
			set
			{
				if(value==null)value=new Neusoft.NFC.Object.NeuObject();
				this.myDept=value;
				this.Memo=this.myDept.ID;
				this.User01=this.myDept.Name;
			}
		}
		/// <summary>
		/// 病区
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Nurse
		{
			get
			{
				if(myNurse==null)myNurse=new Neusoft.NFC.Object.NeuObject();
				return myNurse;
			}
			set
			{
				if(value==null)value=new Neusoft.NFC.Object.NeuObject();
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
		public Neusoft.NFC.Object.NeuObject Duty=new Neusoft.NFC.Object.NeuObject();
		
		/// <summary>
		/// 是否专家
		/// </summary>
		public bool IsExpert=false;
		/// <summary>
		/// 专家
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Expert=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 职级
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Level=new Neusoft.NFC.Object.NeuObject();
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
		public Neusoft.NFC.Object.NeuObject curGroup=new Neusoft.NFC.Object.NeuObject();
		
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
		protected Neusoft.NFC.Object.NeuObject myDept;
		protected Neusoft.NFC.Object.NeuObject myNurse;


		
		
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
