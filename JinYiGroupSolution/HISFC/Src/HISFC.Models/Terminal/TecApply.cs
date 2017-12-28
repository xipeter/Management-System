using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

/// <summary>
/// TecApply <br></br>
/// [功能描述: 不知道，原来没有注释]<br></br>
/// [创 建 者: 不知道]<br></br>
/// [创建时间: 不知道]<br></br>
/// <修改记录
///		修改人=''
///		修改时间=''
///		修改目的=''
///		修改描述=''
///  />
/// </summary>
[Serializable]
public class TecApply : Neusoft.FrameWork.Models.NeuObject
{
	public TecApply()
	{
		// TODO: 在此处添加构造函数逻辑
	}

	#region 变量

	/// <summary>
	/// 体检序号
	/// </summary>
	private System.String clinicCode;
	
	/// <summary>
	/// 交易类型
	/// </summary>
	private System.String transType;
	
	/// <summary>
	/// 就诊卡号
	/// </summary>
	private System.String cardNo;
	
	/// <summary>
	/// 姓名
	/// </summary>
	private System.String myName;
	
	/// <summary>
	/// 年龄
	/// </summary>
	private System.Int32 age;
	
	/// <summary>
	/// 项目
	/// </summary>
	private Neusoft.FrameWork.Models.NeuObject item = new NeuObject();
	
	/// <summary>
	/// 项目数量
	/// </summary>
	private System.Int32 myItemQty;
	
	/// <summary>
	/// 单位标识
	/// </summary>
	private System.String myUnitFlag;
	
	/// <summary>
	/// 处方号
	/// </summary>
	private System.String recipeNo;
	
	/// <summary>
	/// SequenceNo
	/// </summary>
	private System.Int32 sequenceNo;

	/// <summary>
	/// 开单科室
	/// </summary>
	private Neusoft.HISFC.Models.Base.Department recipeDept = new Department();
	
	/// <summary>
	/// 科室
	/// </summary>
	private Neusoft.HISFC.Models.Base.Department dept = new Department();
	
	/// <summary>
	/// 状态：0 预预约 1 生效 2 审核
	/// </summary>
	private System.String status;
	
	/// <summary>
	/// 预约单号
	/// </summary>
	private System.String bookId;
	
	/// <summary>
	/// 预约时间
	/// </summary>
	private System.DateTime bookTime;
	
	/// <summary>
	/// 午别编码
	/// </summary>
	private System.String noonCode;
	
	/// <summary>
	/// 知情同意书
	/// </summary>
	private System.String reasonableFlag;
	
	/// <summary>
	/// 健康状态
	/// </summary>
	private System.String healthStatus;
	
	/// <summary>
	/// 执行地点
	/// </summary>
	private System.String executeLocate;
	
	/// <summary>
	/// 取报告时间
	/// </summary>
	private System.String reportTime;
	
	/// <summary>
	/// 有创/无创
	/// </summary>
	private System.String hurtFlag;
	
	/// <summary>
	/// 标本或部位
	/// </summary>
	private System.String sampleKind;
	
	/// <summary>
	/// 采样方法
	/// </summary>
	private System.String sampleWay;
	
	/// <summary>
	/// 注意事项
	/// </summary>
	private System.String remark;
	
	/// <summary>
	/// 顺序号
	/// </summary>
	private System.Int32 sortID;
	
	/// <summary>
	/// 操作环境
	/// </summary>
	private Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();

	#endregion

	#region 属性

	/// <summary>
	/// 体检序号
	/// </summary>
	public System.String ClinicCode
	{
		get
		{
			return this.clinicCode;
		}
		set
		{
			this.clinicCode = value;
		}
	}

	/// <summary>
	/// 交易类型
	/// </summary>
	public System.String TransType
	{
		get
		{
			return this.transType;
		}
		set
		{
			this.transType = value;
		}
	}

	/// <summary>
	/// 就诊卡号
	/// </summary>
	public System.String CardNo
	{
		get
		{
			return this.cardNo;
		}
		set
		{
			this.cardNo = value;
		}
	}

	/// <summary>
	/// 姓名
	/// </summary>
	public System.String MyName
	{
		get
		{
			return this.myName;
		}
		set
		{
			this.myName = value;
		}
	}

	/// <summary>
	/// 年龄
	/// </summary>
	public System.Int32 Age
	{
		get
		{
			return this.age;
		}
		set
		{
			this.age = value;
		}
	}

	/// <summary>
	/// 项目
	/// </summary>
	public Neusoft.FrameWork.Models.NeuObject Item
	{
		get
		{
			return this.item;
		}
		set
		{
			this.item = value;
		}
	}

	/// <summary>
	/// 项目数量
	/// </summary>
	public System.Int32 ItemQty
	{
		get
		{
			return this.myItemQty;
		}
		set
		{
			this.myItemQty = value;
		}
	}

	/// <summary>
	/// 单位标识
	/// </summary>
	public System.String UnitFlag
	{
		get
		{
			return this.myUnitFlag;
		}
		set
		{
			this.myUnitFlag = value;
		}
	}

	/// <summary>
	/// 处方号
	/// </summary>
	public System.String RecipeNo
	{
		get
		{
			return this.recipeNo;
		}
		set
		{
			this.recipeNo = value;
		}
	}

	/// <summary>
	/// 处方内项目序号
	/// </summary>
	public System.Int32 SequenceNo
	{
		get
		{
			return this.sequenceNo;
		}
		set
		{
			this.sequenceNo = value;
		}
	}
	
	/// <summary>
	/// 开单科室
	/// </summary>
	public Neusoft.HISFC.Models.Base.Department RecipeDept
	{
		get
		{
			return this.recipeDept;
		}
		set
		{
			this.recipeDept = value;
		}
	}

	/// <summary>
	/// 科室
	/// </summary>
	public Neusoft.HISFC.Models.Base.Department Dept
	{
		get
		{
			return this.dept;
		}
		set
		{
			this.dept = value;
		}
	}

	/// <summary>
	/// 状态：0 预预约 1 生效 2 审核
	/// </summary>
	public System.String Status
	{
		get
		{
			return this.status;
		}
		set
		{
			this.status = value;
		}
	}

	/// <summary>
	/// 预约单号
	/// </summary>
	public System.String BookId
	{
		get
		{
			return this.bookId;
		}
		set
		{
			this.bookId = value;
		}
	}

	/// <summary>
	/// 预约时间
	/// </summary>
	public System.DateTime BookTime
	{
		get
		{
			return this.bookTime;
		}
		set
		{
			this.bookTime = value;
		}
	}

	/// <summary>
	/// 午别编码
	/// </summary>
	public System.String NoonCode
	{
		get
		{
			return this.noonCode;
		}
		set
		{
			this.noonCode = value;
		}
	}

	/// <summary>
	/// 知情同意书
	/// </summary>
	public System.String ReasonableFlag
	{
		get
		{
			return this.reasonableFlag;
		}
		set
		{
			this.reasonableFlag = value;
		}
	}

	/// <summary>
	/// 健康状态
	/// </summary>
	public System.String HealthStatus
	{
		get
		{
			return this.healthStatus;
		}
		set
		{
			this.healthStatus = value;
		}
	}

	/// <summary>
	/// 执行地点
	/// </summary>
	public System.String ExecuteLocate
	{
		get
		{
			return this.executeLocate;
		}
		set
		{
			this.executeLocate = value;
		}
	}

	/// <summary>
	/// 取报告时间
	/// </summary>
	public System.String ReportTime
	{
		get
		{
			return this.reportTime;
		}
		set
		{
			this.reportTime = value;
		}
	}

	/// <summary>
	/// 有创/无创
	/// </summary>
	public System.String HurtFlag
	{
		get
		{
			return this.hurtFlag;
		}
		set
		{
			this.hurtFlag = value;
		}
	}

	/// <summary>
	/// 标本或部位
	/// </summary>
	public System.String SampleKind
	{
		get
		{
			return this.sampleKind;
		}
		set
		{
			this.sampleKind = value;
		}
	}

	/// <summary>
	/// 采样方法
	/// </summary>
	public System.String SampleWay
	{
		get
		{
			return this.sampleWay;
		}
		set
		{
			this.sampleWay = value;
		}
	}

	/// <summary>
	/// 注意事项
	/// </summary>
	public System.String Remark
	{
		get
		{
			return this.remark;
		}
		set
		{
			this.remark = value;
		}
	}

	/// <summary>
	/// 顺序号
	/// </summary>
	public System.Int32 SortID
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
	
	/// <summary>
	/// 操作环境
	/// </summary>
	public Neusoft.HISFC.Models.Base.OperEnvironment OperEnvironment
	{
		get
		{
			return this.operEnvironment;
		}
		set
		{
			this.operEnvironment = value;
		}
	}

	#endregion

	#region 过时

	/// <summary>
	/// 项目编码
	/// </summary>
	[Obsolete("已经过时，更改为Item", true)]
	private System.String myItemCode;

	/// <summary>
	/// 项目名称
	/// </summary>
	[Obsolete("已经过时，更改为Item", true)]
	private System.String myItemName;

	/// <summary>
	/// 开单科室名称
	/// </summary>
	[Obsolete("已经过时，更改为RecipeDept", true)]
	private System.String recipeDeptname;

	/// <summary>
	/// 科室编号
	/// </summary>
	[Obsolete("已经过时，更改为Dept", true)]
	private System.String myDeptCode;

	/// <summary>
	/// 科室名称
	/// </summary>
	[Obsolete("已经过时，更改为Dept", true)]
	private System.String myDeptName;

	/// <summary>
	/// 操作员编码
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	private System.String myOperCode;

	/// <summary>
	/// 操作科室编码
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	private System.String myOperDeptcode;

	/// <summary>
	/// 操作时间
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	private System.DateTime myOperDate;

	/// <summary>
	/// 项目代码
	/// </summary>
	[Obsolete("已经过时，更改为Item", true)]
	public System.String ItemCode
	{
		get
		{
			return this.item.ID;
		}
		set
		{
			this.item.ID = value;
		}
	}

	/// <summary>
	/// 项目名称
	/// </summary>
	[Obsolete("已经过时，更改为Item", true)]
	public System.String ItemName
	{
		get
		{
			return this.item.Name;
		}
		set
		{
			this.item.Name = value;
		}
	}

	/// <summary>
	/// 开单科室名称
	/// </summary>
	[Obsolete("已经过时， 更改为RecipeDept", true)]
	public System.String RecipeDeptname
	{
		get
		{
			return this.recipeDept.Name;
		}
		set
		{
			this.recipeDept.Name = value;
		}
	}

	/// <summary>
	/// 科室号
	/// </summary>
	[Obsolete("已经过时，更改为Dept", true)]
	public System.String DeptCode
	{
		get
		{
			return this.dept.ID;
		}
		set
		{
			this.dept.ID = value;
		}
	}

	/// <summary>
	/// 科室名称
	/// </summary>
	[Obsolete("已经过时，更改为Dept", true)]
	public System.String DeptName
	{
		get
		{
			return this.dept.Name;
		}
		set
		{
			this.dept.Name = value;
		}
	}

	/// <summary>
	/// 操作员
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	public System.String OperCode
	{
		get
		{
			return this.operEnvironment.ID;
		}
		set
		{
			this.operEnvironment.ID = value;
		}
	}

	/// <summary>
	/// 操作科室
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	public System.String OperDeptcode
	{
		get
		{
			return this.dept.ID;
		}
		set
		{
			this.dept.ID = value;
		}
	}

	/// <summary>
	/// 操作日期
	/// </summary>
	[Obsolete("已经过时，更改为OperEnvironment")]
	public System.DateTime OperDate
	{
		get
		{
			return this.operEnvironment.OperTime;
		}
		set
		{
			this.operEnvironment.OperTime = value;
		}
	}
	
	#endregion

	#region 方法

	/// <summary>
	/// 克隆
	/// </summary>
	/// <returns>TecApply</returns>
	public new TecApply Clone()
	{
		TecApply tecApply = base.Clone() as TecApply;

		tecApply.Item = this.Item.Clone();
		tecApply.RecipeDept = this.RecipeDept.Clone();
		tecApply.Dept = this.Dept.Clone();
		tecApply.OperEnvironment = this.OperEnvironment.Clone();

		return tecApply;
	}
	
	#endregion

}