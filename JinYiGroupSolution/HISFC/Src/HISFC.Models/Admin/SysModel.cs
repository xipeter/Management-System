using System;


namespace Neusoft.HISFC.Models.Admin {


	/// <summary>
	/// SysModel 的摘要说明。
	/// </summary>
    /// 
    [System.Serializable]
	public class SysModel: Neusoft.FrameWork.Models.NeuObject
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
