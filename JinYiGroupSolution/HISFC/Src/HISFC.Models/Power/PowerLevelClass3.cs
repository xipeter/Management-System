using System;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// PowerLevelClass3 的摘要说明。
	/// </summary>
	public class PowerLevelClass3: neusoft.neuFC.Object.neuObject
	{
		private System.String class2Code ;
		private System.String class3Code ;
		private System.String class3Name ;
		private System.String class3MeaningCode ;
		private System.String class3MeaningName ;
		private System.Boolean finFlag ;
		private System.Boolean delFlag ;
		private System.Boolean grantFlag ;
		private System.String class3JoinCode ;
		private System.String joinGroupCode ;
		private System.Int32 joinGroupOrder ;
		private System.Boolean checkFlag ;
		private PowerLevelClass2 powerLevelClass2 = new PowerLevelClass2();

		/// <summary>
		/// 重写ID ＝三级权限编码
		/// </summary>
		public new string ID {
			get { return class3Code;}
			set { class3Code = value;}
		}

		/// <summary>
		/// 重写Name ＝三级权限名称
		/// </summary>
		public new string Name {
			get { return class3Name;}
			set { class3Name = value;}
		}

		/// <summary>
		/// 二级权限
		/// </summary>
		public PowerLevelClass2 PowerLevelClass2
		{
			get
			{
				return this.powerLevelClass2;
			}
			set
			{
				this.powerLevelClass2 = value;
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
		/// 三级权限分类码
		/// </summary>
		public System.String Class3Code
		{
			get
			{
				return this.class3Code;
			}
			set
			{
				this.class3Code = value;
			}
		}

		/// <summary>
		/// 三级权限分类名称
		/// </summary>
		public System.String Class3Name
		{
			get
			{
				return this.class3Name;
			}
			set
			{
				this.class3Name = value;
			}
		}

		/// <summary>
		/// 三级权限涵义代码
		/// </summary>
		public System.String Class3MeaningCode
		{
			get
			{
				return this.class3MeaningCode;
			}
			set
			{
				this.class3MeaningCode = value;
			}
		}

		/// <summary>
		/// 三级权限涵义名称
		/// </summary>
		public System.String Class3MeaningName
		{
			get
			{
				return this.class3MeaningName;
			}
			set
			{
				this.class3MeaningName = value;
			}
		}

		/// <summary>
		/// 核算标记：1财务科室核算0不核算
		/// </summary>
		public System.Boolean FinFlag
		{
			get
			{
				return this.finFlag;
			}
			set
			{
				this.finFlag = value;
			}
		}

		/// <summary>
		/// 1-允许删改该记录，0-不允许删改该记录
		/// </summary>
		public System.Boolean DelFlag
		{
			get
			{
				return this.delFlag;
			}
			set
			{
				this.delFlag = value;
			}
		}

		/// <summary>
		/// 是否可以再授权1可以0不可以2系统权限（不能分配、删改）
		/// </summary>
		public System.Boolean GrantFlag
		{
			get
			{
				return this.grantFlag;
			}
			set
			{
				this.grantFlag = value;
			}
		}

		/// <summary>
		/// 三级权限关联分类码，如果与另一个三级权限关联，则保存另一个三级权限分类码
		/// </summary>
		public System.String Class3JoinCode
		{
			get
			{
				return this.class3JoinCode;
			}
			set
			{
				this.class3JoinCode = value;
			}
		}

		/// <summary>
		/// 关联分组组别号：如果与其它三级权限分类是一组操作，则维护为同一个组别号，例如：申请、审核、确认组别号可以设为一样的
		/// </summary>
		public System.String JoinGroupCode
		{
			get
			{
				return this.joinGroupCode;
			}
			set
			{
				this.joinGroupCode = value;
			}
		}

		/// <summary>
		/// 关联分组顺序号：同一个组别里的先后顺序号，例如：申请为1号，审核为2号，确认为3号
		/// </summary>
		public System.Int32 JoinGroupOrder
		{
			get
			{
				return this.joinGroupOrder;
			}
			set
			{
				this.joinGroupOrder = value;
			}
		}

		/// <summary>
		/// 是否需要审核（默认不需要）：0不需要1需要
		/// </summary>
		public System.Boolean CheckFlag
		{
			get
			{
				return this.checkFlag;
			}
			set
			{
				this.checkFlag = value;
			}
		}

	}
}
