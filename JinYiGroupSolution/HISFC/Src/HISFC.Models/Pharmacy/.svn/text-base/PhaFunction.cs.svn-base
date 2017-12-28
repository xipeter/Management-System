using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 药理作用实体]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-11]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PhaFunction :  Neusoft.HISFC.Models.Base.Spell,Neusoft.HISFC.Models.Base.IValid
	{

		public PhaFunction() 
		{
			
		}


		#region 变量

		/// <summary>
		/// 父级节点编码
		/// </summary>
		private System.String myParentNode ;

		/// <summary>
		/// 节点名称
		/// </summary>
		private System.String myNodeName;

		/// <summary>
		/// 节点类型
		/// </summary>
		private System.Int32 myNodeKind ;

		/// <summary>
		/// 当前级别
		/// </summary>
		private System.Int32 myGradeLevel;
		
		/// <summary>
		/// 顺序号
		/// </summary>
		private System.Int32 mySortId ;

		/// <summary>
		/// 有效性
		/// </summary>
		private bool isValid;

		/// <summary>
		/// 操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();
		
		#endregion		

		/// <summary>
		/// 父级节点编码
		/// </summary>
		public System.String ParentNode
		{
			get
			{
				return this.myParentNode;
			}
			set
			{
				this.myParentNode = value; 
			}
		}


		/// <summary>
		/// 节点编码
		/// </summary>
		public System.String NodeID
		{
			get
			{
				return this.myNodeCode; 
			}
			set
			{
				this.myNodeCode = value; 
			}
		}

		
		/// <summary>
		/// 节点名称
		/// </summary>
		public System.String NodeName
		{
			get
			{
				return this.myNodeName; 
			}
			set
			{
				this.myNodeName = value; 
			}
		}


		/// <summary>
		/// 节点类型：0非叶子节点，1叶子节点
		/// </summary>
		public System.Int32 NodeKind
		{
			get
			{
				return this.myNodeKind;
			}
			set
			{
				this.myNodeKind = value;
			}
		}


		/// <summary>
		/// 当前级别，指节点的层数
		/// </summary>
		public System.Int32 GradeLevel
		{
			get
			{ 
				return this.myGradeLevel;
			}
			set
			{
				this.myGradeLevel = value; 
			}
		}


		/// <summary>
		/// 顺序号
		/// </summary>
		public System.Int32 SortID
		{
			get
			{
				return this.mySortId; 
			}
			set
			{
				this.mySortId = value; 
			}
		}


		/// <summary>
		/// 操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}

		
		#region IValid 成员

		/// <summary>
		/// 有效性 
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}


		#endregion

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new PhaFunction Clone()
		{
			return base.Clone() as PhaFunction;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 节点编码
		/// </summary>
		private System.String myNodeCode ;

		/// <summary>
		/// 当前级别
		/// </summary>
		private System.Int32 myGradeCode ;

		/// <summary>
		/// 操作员
		/// </summary>
		private System.String myOperCode ;

		/// <summary>
		/// 操作时间
		/// </summary>
		private System.DateTime myOperDate ;

		/// <summary>
		/// 有效性
		/// </summary>
		private System.String myValidState ;

		/// <summary>
		/// 节点编码
		/// </summary>
		[System.Obsolete("程序重构 更改为NodeID属性",true)]
		public System.String NodeCode
		{
			get{ return this.myNodeCode; }
			set{ this.myNodeCode = value; }
		}


		/// <summary>
		/// 当前级别，指节点的层数
		/// </summary>
		[System.Obsolete("程序重构 更改为GradeLevel属性",true)]
		public System.Int32 GradeCode
		{
			get{ return this.myGradeCode; }
			set{ this.myGradeCode = value; }
		}


		/// <summary>
		/// 顺序号
		/// </summary>
		[System.Obsolete("程序重构 更改为SortID属性",true)]
		public System.Int32 SortId
		{
			get{ return this.mySortId; }
			set{ this.mySortId = value; }
		}


		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public System.String OperCode
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public System.DateTime OperDate
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		/// <summary>
		/// 有效性标志 0有效 1无效
		/// </summary>
		[System.Obsolete("程序重构 更改为Bool类型的IsValid属性",true)]
		public System.String ValidState
		{
			get{ return this.myValidState; }
			set{ this.myValidState = value; }
		}


		#endregion
	}
}
