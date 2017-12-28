using System;

namespace neusoft.HISFC.Object.Power
{
	/// <summary>
	/// SysModel 的摘要说明。
	/// </summary>
	public class SysModel: neusoft.neuFC.Object.neuObject
	{
		private System.String sysCode ;
		private System.String sysName ;
		private System.Int32 sortId ;

		/// <summary>
		/// 模块编码
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
				this.ID = value;
			}
		}

		/// <summary>
		/// 模块名称
		/// </summary>
		public System.String SysName
		{
			get
			{
				return this.sysName;
			}
			set
			{
				this.sysName = value;
				this.Name = value;
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

	}


 
	



}
