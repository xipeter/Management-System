using System;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// PowerLevelClass2 的摘要说明。
	/// </summary>
	public class PowerLevelClass2: neusoft.neuFC.Object.neuObject
	{
		private PowerLevelClass1 powerLevelClass1;
		private System.String class1Code = "";
		private System.String class2Code = "";
		private System.String class2Name = "";
		private System.String validState = "0" ;
		private System.String flag;

		//重写ID＝二级权限编码
		public new string ID {
			get {return this.class2Code;}
			set {this.class2Code = value;}
		}

		//重写Name＝二级权限名称
		public new string Name {
			get {return this.class2Name;}
			set {this.class2Name = value;}
		}


		/// <summary>
		/// 一级权限分类码
		/// </summary>
		public PowerLevelClass1 PowerLevelClass1
		{
			get
			{
				return this.powerLevelClass1;
			}
			set
			{
				this.powerLevelClass1 = value;
			}
		}

		/// <summary>
		/// 一级权限分类码，权限类型
		/// </summary>
		public System.String Class1Code
		{
			get
			{
				return this.class1Code;
			}
			set
			{
				this.class1Code = value;
			}
		}

		/// <summary>
		/// 二级权限分类码
		/// </summary>
		public System.String Class2Code
		{
			get
			{
				return this.class2Code;
			}
			set
			{
				this.class2Code = value;
			}
		}

		/// <summary>
		/// 二级权限分类名称
		/// </summary>
		public System.String Class2Name
		{
			get
			{
				return this.class2Name;
			}
			set
			{
				this.class2Name = value;
			}
		}

		/// <summary>
		/// 有效状态(0有效，1无效)
		/// </summary>
		public System.String ValidState {
			get{ return this.validState;}
			set{ this.validState = value;}
		}
		/// <summary>
		/// 特殊标记：1判断窗口权限时，只要存在权限就允许进入，不需要用户选择科室
		/// </summary>
		public System.String Flag {
			get{ return this.flag;}
			set{ this.flag = value;}
		}
	}
}
