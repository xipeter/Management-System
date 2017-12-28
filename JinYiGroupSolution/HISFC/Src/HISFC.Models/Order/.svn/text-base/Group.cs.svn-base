using System;
namespace Neusoft.HISFC.Object.Base
{


	/// <summary>
	/// 组套
	/// </summary>
	public class Group: Neusoft.NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.ISpell {

		private System.String mySpell_Code ;
		private System.String myUser_Code ;
		private Neusoft.HISFC.Object.Base.enuType myUserType =Neusoft.HISFC.Object.Base.enuType.I;
		private enuGroupKind myKind =enuGroupKind.Doctor ;
		//private enuGroupType myType =enuGroupType.Doctor;
		private Neusoft.NFC.Object.NeuObject myDept = new Neusoft.NFC.Object.NeuObject();
		private Neusoft.NFC.Object.NeuObject myDoctor = new Neusoft.NFC.Object.NeuObject();
		private System.Boolean myIsShared ;
	
		public Group() 
		{
			// TODO: 在此处添加构造函数逻辑
		}
	
		/// <summary>
		/// 1门诊/2住院
		/// </summary>
		public Neusoft.HISFC.Object.Base.enuType UserType
		{
			get{ return this.myUserType; }
			set{ this.myUserType = value; }
		}


		/// <summary>
		/// 组套类型,1.医师组套；2.科室组套
		/// </summary>
		public enuGroupKind Kind
		{
			get{ return this.myKind; }
			set{ this.myKind = value; }
		}
//		/// <summary>
//		/// 组套类型,1.医师组套；2.费用
//		/// </summary>
//		public enuGroupType Type
//		{
//			get{ return this.myType; }
//			set{ this.myType = value; }
//		}

		/// <summary>
		/// 科室代码
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Dept
		{
			get{ return this.myDept; }
			set{ this.myDept = value; }
		}


		/// <summary>
		/// 组套医师
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Doctor
		{
			get{ return this.myDoctor; }
			set{ this.myDoctor = value; }
		}


		/// <summary>
		/// 是否共享，1是，0否
		/// </summary>
		public System.Boolean IsShared
		{
			get{ return this.myIsShared; }
			set{ this.myIsShared = value; }
		}
		#region ISpellCode 成员

		public string Spell_Code
		{
			get
			{
				// TODO:  添加 Group.Neusoft.HISFC.Object.Base.ISpellCode.Spell_Code getter 实现
				return this.mySpell_Code;
			}
			set
			{
				// TODO:  添加 Group.Neusoft.HISFC.Object.Base.ISpellCode.Spell_Code setter 实现
				this.mySpell_Code = value;
			}
		}

		public string WB_Code
		{
			get
			{
				// TODO:  添加 Group.WB_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 Group.WB_Code setter 实现
			}
		}

		public string User_Code
		{
			get
			{
				// TODO:  添加 Group.Neusoft.HISFC.Object.Base.ISpellCode.User_Code getter 实现
				return this.myUser_Code;
			}
			set
			{
				// TODO:  添加 Group.Neusoft.HISFC.Object.Base.ISpellCode.User_Code setter 实现
				this.myUser_Code = value;
			}
		}

		#endregion	

	}
	/// <summary>
	/// 组套类型
	/// </summary>
	public enum enuGroupKind
	{
		/// <summary>
		/// 医生
		/// </summary>
		Doctor = 1,
		/// <summary>
		/// 科室
		/// </summary>
		Dept = 2,
		/// <summary>
		/// 全院
		/// </summary>
		All = 3
	}
	/// <summary>
	/// 组套类型
	/// </summary>
	public enum enuGroupType
	{
		/// <summary>
		/// 医生组套
		/// </summary>
		Doctor = 1,
		/// <summary>
		/// 费用组套
		/// </summary>
		Fee = 2
	}
}