using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.PhysicalExamination.Base
{
	/// <summary>
	/// Employee <br></br>
	/// <br>包括创建和使无效操作环境</br>
	/// <br>包括有效性和无效性</br>
	/// <br>包括医院信息</br>
	/// <br>包括体检类型（个人体检／集体公司体检）</br>
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
	public class PE : Neusoft.HISFC.Object.Base.Spell 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PE( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 手工编码
		/// </summary>
		private string code = "";

		/// <summary>
		/// 有效性
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumValidity validity = Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumValidity.Valid;

		/// <summary>
		/// 医院
		/// </summary>
		private Hospital hospital = new Hospital();

		/// <summary>
		/// 创建操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment createEnvironment = new OperEnvironment();

		/// <summary>
		/// 使无效操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment invalidEnvironment = new OperEnvironment();

		/// <summary>
		/// 类别：个人体检、公司／集体体检
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumPEType peType = Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumPEType.Personal;

		#endregion

		#region 属性
		
		/// <summary>
		/// 手工编码
		/// </summary>
		public string Code
		{
			get
			{
				return this.code;
			}
			set
			{
				this.code = value;
			}
		}

		/// <summary>
		/// 有效性
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumValidity Validity 
		{
			get 
			{
				return this.validity;
			}
			set 
			{
				this.validity = value;
			}
		}

		/// <summary>
		/// 医院
		/// </summary>
		public Hospital Hospital 
		{
			get 
			{
				return this.hospital;
			}
			set 
			{
				this.hospital = value;
			}
		}

		/// <summary>
		/// 创建操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment CreateEnvironment 
		{
			get 
			{
				return this.createEnvironment;
			}
			set 
			{
				this.createEnvironment = value;
			}
		}

		/// <summary>
		/// 使无效操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment InvalidEnvironment 
		{
			get 
			{
				return this.invalidEnvironment;
			}
			set 
			{
				this.invalidEnvironment = value;
			}
		}

		/// <summary>
		/// 类别：个人体检、公司／集体体检
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Enum.EnumPEType PEType 
		{
			get 
			{
				return this.peType;
			}
			set 
			{
				this.peType = value;
			}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检基类</returns>
		public new PE Clone()
		{
			PE pe = base.Clone() as PE;

			pe.Hospital = this.Hospital.Clone();
			pe.CreateEnvironment = this.CreateEnvironment.Clone();
			pe.InvalidEnvironment = this.InvalidEnvironment.Clone();

			return pe;
		}
		
		#endregion
	}
}
