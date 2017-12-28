using System;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// PowerLevelClass1 的摘要说明。
	/// </summary>
	public class PowerLevelClass1: neusoft.neuFC.Object.neuObject
	{
		private System.String class1Code ;
		private System.String class1Name ;
		private System.Boolean uniteFlag ;
		private System.Int32 typeProperty ;
		private System.String uniteCode ;
		private System.String vocationType ;
		private System.String vocationName ;
		private System.String validState = "0" ;

		//重写ID＝一级权限编码
		public new string ID {
			get {return this.class1Code;}
			set {this.class1Code = value;}
		}

		//重写Name＝一级权限名称
		public new string Name {
			get {return this.class1Name;}
			set {this.class1Name = value;}
		}

		/// <summary>
		/// 一级权限分类码，权限类型，对应于表COM_DEPTSTAT.STAT_CODE
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
		/// 一级权限分类名称
		/// </summary>
		public System.String Class1Name
		{
			get
			{
				return this.class1Name;
			}
			set
			{
				this.class1Name = value;
			}
		}

		/// <summary>
		/// 是否允许统一维护0－不允许1－允许
		/// </summary>
		public System.Boolean UniteFlag
		{
			get
			{
				return this.uniteFlag;
			}
			set
			{
				this.uniteFlag = value;
			}
		}

		/// <summary>
		/// 类型属性：0不能增加分类，只能在下级增加自定义科室，1按科室分类管理（人员只能属于终极科室），2允许在科室分类下面增加人员，3只能维护科室关系，不允许增加人员，4不能添加科室和人员
		/// </summary>
		public System.Int32 TypeProperty
		{
			get
			{
				return this.typeProperty;
			}
			set
			{
				this.typeProperty = value;
			}
		}

		/// <summary>
		/// 统一维护码：相同的编码统一维护成一个
		/// </summary>
		public System.String UniteCode
		{
			get
			{
				return this.uniteCode;
			}
			set
			{
				this.uniteCode = value;
			}
		}

		/// <summary>
		/// 所属业务线
		/// </summary>
		public System.String VocationType
		{
			get
			{
				return this.vocationType;
			}
			set
			{
				this.vocationType = value;
			}
		}

		/// <summary>
		/// 所属业务线名称
		/// </summary>
		public System.String VocationName
		{
			get
			{
				return this.vocationName;
			}
			set
			{
				this.vocationName = value;
			}
		}

		/// <summary>
		/// 有效状态(0有效，1无效)
		/// </summary>
		public System.String ValidState {
			get{ return this.validState;}
			set{ this.validState = value;}
		}
	}
}
