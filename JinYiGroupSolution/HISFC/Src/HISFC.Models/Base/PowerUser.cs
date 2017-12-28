public class PowerUser: neusoft.neuFC.Object.neuObject
{
	private System.String _pkId ;
	private System.String _deptCode ;
	private System.String _userCode ;
	private System.String _class1Code ;
	private System.String _class2Code ;
	private System.String _class3Code ;
	private System.String _grantDept ;
	private System.String _grantEmpl ;
	private System.Boolean _grantFlag ;
	private System.String _roleCode ;
	private System.String _mark ;

	/// <summary>
	/// 用户权限流水号
	/// </summary>
	public System.String PkId
	{
		get
		{
			return this._pkId;
		}
		set
		{
			this._pkId = value;
		}
	}

	/// <summary>
	/// 权限部门
	/// </summary>
	public System.String DeptCode
	{
		get
		{
			return this._deptCode;
		}
		set
		{
			this._deptCode = value;
		}
	}

	/// <summary>
	/// 用户编码
	/// </summary>
	public System.String UserCode
	{
		get
		{
			return this._userCode;
		}
		set
		{
			this._userCode = value;
		}
	}

	/// <summary>
	/// 一级权限分类码，权限类型
	/// </summary>
	public System.String Class1Code
	{
		get
		{
			return this._class1Code;
		}
		set
		{
			this._class1Code = value;
		}
	}

	/// <summary>
	/// 二级权限分类码
	/// </summary>
	public System.String Class2Code
	{
		get
		{
			return this._class2Code;
		}
		set
		{
			this._class2Code = value;
		}
	}

	/// <summary>
	/// 三级权限分类码
	/// </summary>
	public System.String Class3Code
	{
		get
		{
			return this._class3Code;
		}
		set
		{
			this._class3Code = value;
		}
	}

	/// <summary>
	/// 授权科室
	/// </summary>
	public System.String GrantDept
	{
		get
		{
			return this._grantDept;
		}
		set
		{
			this._grantDept = value;
		}
	}

	/// <summary>
	/// 授权人
	/// </summary>
	public System.String GrantEmpl
	{
		get
		{
			return this._grantEmpl;
		}
		set
		{
			this._grantEmpl = value;
		}
	}

	/// <summary>
	/// 是否可以再授权：0否1是
	/// </summary>
	public System.Boolean GrantFlag
	{
		get
		{
			return this._grantFlag;
		}
		set
		{
			this._grantFlag = value;
		}
	}

	/// <summary>
	/// 角色代码
	/// </summary>
	public System.String RoleCode
	{
		get
		{
			return this._roleCode;
		}
		set
		{
			this._roleCode = value;
		}
	}

	/// <summary>
	/// 备注
	/// </summary>
	public System.String Mark
	{
		get
		{
			return this._mark;
		}
		set
		{
			this._mark = value;
		}
	}

}