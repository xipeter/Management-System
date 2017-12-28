namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Record<br></br>
	/// [功能描述: 报表实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Report : Neusoft.FrameWork.Models.NeuObject,  IValid,  ISort
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Report()
		{

		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
		
		/// <summary>
		/// 父级组别编码
		/// </summary>
		private string parentCode;
		
		/// <summary>
		/// 组别编码
		/// </summary>
		private string currentCode;
		
		/// <summary>
		/// 控件名称
		/// </summary>
		private string ctrlName;
		
		/// <summary>
		/// 调用参数
		/// </summary>
		private string parm;
		
		/// <summary>
		/// 是否有效
		/// </summary>
		private bool isValid;
		
		/// <summary>
		/// 序号
		/// </summary>
		private int sortID;
		
		/// <summary>
		/// 特殊标记
		/// </summary>
		private string specialFlag;

		#endregion

		#region 属性

		/// <summary>
		/// 父级组别编码
		/// </summary>
		public string ParentCode 
		{
			get
			{
				return this.parentCode;
			}
			set
			{
				this.parentCode = value;
			}
		}

		/// <summary>
		/// 组别编码
		/// </summary>
		public string CurrentCode
		{
			get
			{
				return this.currentCode;
			}
			set
			{
				this.currentCode = value;
			}
		}

		/// <summary>
		/// 控件名称
		/// </summary>
		public string CtrlName
		{
			get
			{
				return this.ctrlName;
			}
			set
			{
				this.ctrlName = value;
			}
		}

		/// <summary>
		/// 调用参数
		/// </summary>
		public string Parm
		{
			get
			{
				return this.parm;
			}
			set
			{
				this.parm = value;
			}
		}
 
		/// <summary>
		/// 特殊标记
		/// </summary>
		public string SpecialFlag
		{
			get
			{
				return this.specialFlag;
			}
			set
			{
				this.specialFlag = value;
			}
		}

		#endregion

		#region 方法

		#region 释放资源
		
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

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Report Clone()
		{
			return base.Clone() as Report;
		}

		#endregion

		#endregion

		#region 接口实现
		
		#region IValid 成员
		
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value ;
			}
		}

		#endregion
		
		#region ISort 成员
		
		/// <summary>
		/// 序号
		/// </summary>
		public int SortID
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

		#endregion

		#endregion

	}
}
