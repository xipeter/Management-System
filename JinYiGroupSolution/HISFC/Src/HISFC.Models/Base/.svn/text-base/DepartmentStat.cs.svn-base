namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// DepartmentStat<br></br>
	/// [功能描述: 科室组织结构实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class DepartmentStat :Spell,IValidState 
	{

		public DepartmentStat()
        {
        }


		#region 变量

	

		
		/// <summary>
		/// 统计分类 0000 组织机构 0001 科室核算 0002 病案统计 0003 科室病区关系
		/// </summary>
		private string statCode = ""; 

		/// <summary>
		/// 父级科室
		/// </summary>		
		private Neusoft.FrameWork.Models.NeuObject superDept = new Neusoft.FrameWork.Models.NeuObject(); 

		/// <summary>
		/// 科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject(); 

		/// <summary>
		/// 节点类型
		/// </summary>
		private int nodeType ;

		/// <summary>
		/// 级别编码
		/// </summary>
		private int gradeCode ;

		/// <summary>
		/// 排序码 
		/// </summary>
		private int sortID ;

		/// <summary>
		/// 有效性状态
		/// </summary>
        private HISFC.Models.Base.EnumValidState validState;

		/// <summary>
		/// 扩展标志
		/// </summary>
		private bool extFlag ;

		/// <summary>
		/// 扩展标志1
		/// </summary>
		private bool extFlag1 ;

		/// <summary>
		/// 科室类型
		/// </summary>
		private EnumDepartmentType deptType = new EnumDepartmentType();

		private string pkID;

		private string pardepCode;

		private string pardepName;
		#endregion

		#region 属性

		/// <summary>
		/// 重写ID ＝科室编码
		/// </summary>
		public new string ID 
        {
			get 
            { 
                return this.dept.ID;
            }
			set 
            { 
				this.dept.ID = value;
				base.ID = value;
			}
		}

		/// <summary>
		/// 重写Name ＝科室名称
		/// </summary>
		public new string Name 
        {
			get 
            { 
                return this.dept.Name;
            }
			set 
            { 
				this.dept.Name = value;
				base.Name = value;
			}
		}

		/// <summary>
		/// 主键列
		/// </summary>
		public string PkID 
		{
			get
			{
				return this.pkID;
			}
			set
			{
				this.pkID = value;
			}
		}

		/// <summary>
		/// 统计分类 0000 组织机构 0001 科室核算 0002 病案统计 0003 科室病区关系
		/// </summary>
		public string StatCode
		{
			get
			{
				return this.statCode;
			}
			set
			{
				this.statCode = value;
			}
		}

		/// <summary>
		/// 部门编码（或分类编码）
		/// </summary>
		public string PardepCode
		{
			get
			{
				return this.pardepCode;
			}
			set
			{
				this.pardepCode = value;
			}
		}

		/// <summary>
		/// 部门名称（或分类名称）
		/// </summary>
		public string PardepName
		{
			get
			{
				return this.pardepName;
			}
			set
			{
				this.pardepName = value;
			}
		}

		/// <summary>
		/// 科室编码
		/// </summary>
		public string DeptCode
		{
			get
			{
				return this.dept.ID;
			}
			set
			{
				this.dept.ID = value;
				base.ID = value;
			}
		}

		/// <summary>
		/// 科室名称
		/// </summary>
		public string DeptName
		{
			get
			{
				return this.dept.Name;
			}
			set
			{
				this.dept.Name = value;
				base.Name = value;
			}
		}
		/// <summary>
		/// 节点类型：1终极科室，0科室分类
		/// </summary>
		public int NodeKind
		{
			get
			{
				return this.nodeType;
			}
			set
			{
				this.nodeType = value;
			}
		}

		/// <summary>
		/// 当前级别，指节点的层数
		/// </summary>
		public int GradeCode
		{
			get
			{
				return this.gradeCode;
			}
			set
			{
				this.gradeCode = value;
			}
		}

		/// <summary>
		/// 顺序号
		/// </summary>
		public int SortId
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
		/// 有效性标志 0 在用 1 停用 2 废弃
		/// </summary>
        public HISFC.Models.Base.EnumValidState ValidState
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
		/// 扩展标志
		/// </summary>
		public bool ExtFlag
		{
			get
			{
				return this.extFlag;
			}
			set
			{
				this.extFlag = value;
			}
		}

		/// <summary>
		/// 扩展标志1
		/// </summary>
		public bool Ext1Flag
		{
			get
			{
				return this.extFlag1;
			}
			set
			{
				this.extFlag1 = value;
			}
		}

        /// <summary>
        /// 承载对象
        /// </summary>
		private System.Collections.IList childs = null;
		public System.Collections.IList Childs
		{
			get
			{
				if(childs == null)
				{
					childs = new System.Collections.ArrayList();
				}

				return this.childs;
			}
			set
			{
				this.childs = value;
			}
		}	
	
		/// <summary>
		/// 科室类型
		/// </summary>
		public Neusoft.HISFC.Models.Base.EnumDepartmentType DeptType 
        {
			get
            { 
                return deptType;
            }
			set
            { 
                deptType = value; 
            }
		}
        #endregion

		#region 方法

	

		#region 克隆
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>DepartmentStat类实例</returns>
		public new DepartmentStat Clone()
		{
			DepartmentStat obj = base.Clone() as DepartmentStat;

			//obj.DeptType = this.DeptType.Clone();

			return obj;            
		}
		#endregion
		#endregion

		
	}
}