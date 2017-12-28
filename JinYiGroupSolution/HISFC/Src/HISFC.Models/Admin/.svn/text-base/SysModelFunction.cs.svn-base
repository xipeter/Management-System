using System;


namespace Neusoft.HISFC.Models.Admin {

    
	/// <summary>
	/// SysModelFunction 的摘要说明。
	/// </summary>
    /// 

    [System.Serializable]
	public class SysModelFunction: Neusoft.FrameWork.Models.NeuObject
	{
		private System.String sysCode ;
		private System.String winName ;
		private System.String funName ;
		private System.String mark ;
		private System.Int32 sortId ;

        private SysModelFunction treeControl = null;

        /// <summary>
        /// 树控件
        /// </summary>
        public SysModelFunction TreeControl
        {
            get
            {
                if (treeControl == null)
                    treeControl = new SysModelFunction();
                return this.treeControl;
            }
            set
            {
                this.treeControl = value;
            }
        }
        
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
        ///  唯一索引 
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
        [Obsolete("用Memo代替")]
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
        /// 序号
		/// </summary>
		public System.Int32 SortID
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
		public string FormShowType
        {
            get
            {
                if (frmShowType == "") frmShowType = "MDI";
                return frmShowType;
            }
            set
            {
                frmShowType = value;
            }
        }
        protected string frmShowType= "MDI";
       
		/// <summary>
		/// 窗口类型
        /// Form ,Control,Report and so on
		/// </summary>
		public string FormType 
        {
            get
            {
                if (frmType == "") frmType = "Form";
                return frmType;
            }
            set
            {
                
                frmType = value;
            }
        }

        protected string frmType = "";
        
		/// <summary>
		/// 参数 tag
		/// </summary>
        public string Param
        {
            get
            {
                return this.param;
            }
            set
            {
                this.param = value;
            }
        }
        protected string param = "";
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
