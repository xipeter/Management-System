
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Logo<br></br>
	/// [功能描述: 错误日志实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Logo : Neusoft.FrameWork.Models.NeuObject
	{
		public Logo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 数据库错误
		/// </summary>
        private string dbCode = "";

		/// <summary>
		/// sqlcode
		/// </summary>
        private string sqlCode = "";

		/// <summary>
		/// 错误信息
		/// </summary>
        private string sqlError = "";

		/// <summary>
		/// 模块
		/// </summary>
		/// 
        private string modual = "";

		/// <summary>
		/// 描述
		/// </summary>
        private string codeDescription;
        
		/// <summary>
		/// 调试类型
		/// </summary>
        private int debugType = 0;

		#endregion

		#region 属性

		/// <summary>
		/// 数据库错误码
		/// </summary>
        public string DBCode
        {
            get
            {
                return this.dbCode;
            }
            set
            {
                this.dbCode = value;
            }
        }

		/// <summary>
		/// 执行的sql
		/// </summary>
        public string SqlCode
        {
            get
            {
                return this.sqlCode;
            }
            set
            {
                this.sqlCode = value;
            }
        }
        
		/// <summary>
		/// 执行的sql error
		/// </summary>
        public string SqlError
        {
            get
            {
                return this.sqlError;
            }
            set
            {
                this.sqlError = value;
            }

        }
        
		/// <summary>
		/// 运行的modual
		/// </summary>
        public string Modual
        {
            get
            {
                return this.modual;
            }
            set
            {
                this.modual = value;
            }
        }
        
        
		/// <summary>
		/// 0 debug 1 error
		/// </summary>
        public int DebugType
        {
            get
            {
                return this.debugType;
            }
            set
            {
                this.debugType = value;
            }
        }

		/// <summary>
		/// 错误描述
		/// </summary>
		public new string CodeDescription
		{
			get
			{
				return this.codeDescription;
			}
			set
			{
				this.codeDescription = value;
			}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>Logo</returns>
		public new Logo Clone()
		{
			Logo logo = base.Clone() as Logo;

			return logo;
		}

		#endregion

	}
}
