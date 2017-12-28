using System;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// SysModelFunction 的摘要说明。
	/// </summary>
	public class SysModelFunction: neusoft.neuFC.Object.neuObject
	{
		private System.String sysCode ;
		private System.String winName ;
		private System.String funName ;
		private System.String mark ;
		private System.Int32 sortId ;

		/// <summary>
		/// 所属系统
		/// </summary>
		public System.String SysCode
		{
			get
			{
				return this.sysCode;
			}
			set
			{
				this.sysCode = value;
			}
		}

		/// <summary>
		/// 窗口名称
		/// </summary>
		public System.String WinName
		{
			get
			{
				return this.winName;
			}
			set
			{
				this.winName = value;
			}
		}

		/// <summary>
		/// 窗口描述
		/// </summary>
		public System.String FunName
		{
			get
			{
				return this.funName;
			}
			set
			{
				this.funName = value;
			}
		}

		/// <summary>
		/// 备注
		/// </summary>
		public System.String Mark
		{
			get
			{
				return this.mark;
			}
			set
			{
				this.mark = value;
			}
		}

		/// <summary>
		/// 顺序号
		/// </summary>
		public System.Int32 SortId
		{
			get
			{
				return this.sortId;
			}
			set
			{
				this.sortId = value;
			}
		}
		/// <summary>
		/// 窗口显示类型
		/// </summary>
		public string FormShowType = "MDI";
		/// <summary>
		/// 窗口类型
		/// </summary>
		public string FormType = "Form";
		/// <summary>
		/// 参数
		/// </summary>
		public string Param ="";
		protected string strDllName ="";
		/// <summary>
		/// 程序集名称
		/// </summary>
		public string DllName 
		{
			get
			{
				if(this.strDllName =="")
				{
					try
					{
						this.strDllName = this.WinName.Substring(0,this.WinName.IndexOf("."));
					}
					catch{}
				}
				return this.strDllName;
			}
			set
			{
				this.strDllName = value;
			}
		}
	}

}
