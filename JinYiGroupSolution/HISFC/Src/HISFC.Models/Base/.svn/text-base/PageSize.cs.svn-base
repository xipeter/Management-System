namespace Neusoft.HISFC.Models.Base
{  
	/// <summary>
	/// PageSize<br></br>
	/// [功能描述: 打印纸张大小类 ID 编码(流水号) Name 纸张名称(可自定义),默认A4的大小]<br></br>
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
    public class PageSize : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PageSize()
		{

		}

		/// <summary>
		/// 文件功能描述：打印纸张大小类 ID 编码(流水号) Name 纸张名称(可自定义)
		/// </summary>
		/// <param name="pageName">纸张名称</param>
		/// <param name="width">宽</param>
		/// <param name="height">高</param>
		public PageSize(string pageName, int width, int height)
		{
			this.Name = pageName;
			this.Width = width;
			this.Height = height;
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
	
		/// <summary>
		/// 象素高度
		/// </summary>
		protected int height = 1145;

		/// <summary>
		/// 象素宽度
		/// </summary>
		protected int width = 901;

		/// <summary>
		/// 毫米宽度
		/// </summary>
		protected float widthMM = 0f;

		/// <summary>
		/// 毫米高度
		/// </summary>
		protected float heightMM = 0f;

		/// <summary>
		/// 上边距
		/// </summary>
		private int top = 0;

		/// <summary>
		/// 左边距
		/// </summary>
		private int left = 0;

		/// <summary>
		/// 打印机名称
		/// </summary>
		private string printer = "";

		/// <summary>
		/// 操作环境
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();

		/// <summary>
		/// 是否自动转换
		/// </summary>
		private bool isAutoConvert = true;
 
		/// <summary>
		/// 科室-全部All
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

		#region 属性

		/// <summary>
		/// 纸张高度
		/// </summary>
		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				if (value <= 0)
				{
					return;
				}
				
				if (this.isAutoConvert)
				{
					this.heightMM = this.ConvertPixelToMM(value);
				}
				
				this.height = value;
			}
		}

		/// <summary>
		/// 纸张宽度
		/// </summary>
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				if (value <= 0)
				{
					return;
				}
				
				if (isAutoConvert)
				{
					this.widthMM = this.ConvertPixelToMM(value);
				}
				
				this.width = value;
			}

		}

		/// <summary>
		/// 纸张毫米宽度
		/// </summary>
		public float WidthMM 
		{
			get
			{
				return this.widthMM;
			}
			set
			{
				if (value <= 0f)
				{
					return;
				}
				
				if (isAutoConvert)
				{
					this.width = this.ConvertMMToPixel(value);
				}
				
				this.widthMM = value;
			}
		}

		/// <summary>
		/// 纸张毫米高度
		/// </summary>
		public float HeightMM
		{
			get
			{
				return this.heightMM;
			}
			set
			{
				if (value <= 0f)
				{
					return;
				}
				
				if (isAutoConvert)
				{
					this.height = this.ConvertMMToPixel(value);
				}
				
				this.heightMM = value;
			}
		}

		/// <summary>
		/// 科室-全部All
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept 
		{
			get
			{
				return this.dept;
			}
			set
			{
				this.dept = value;
				
				if (value.ID == "ALL" && this.dept.Name == "")
				{
					this.dept.Name = "全部";
				}
			}
		}

		/// <summary>
		/// 打印机
		/// </summary>
		public string Printer 
		{
			get
			{
				return this.printer;
			}
			set
			{
				this.printer = value;
			}
		}

		/// <summary>
		/// 上边距
		/// </summary>
		public int Top
		{
			get
			{
				return this.top;
			}
			set
			{
				this.top = value;
			}
		}

		/// <summary>
		/// 左边距
		/// </summary>
		public int Left 
		{
			get
			{
				return this.left;
			}
			set
			{
				this.left = value;
			}
		}

		/// <summary>
		/// 操作环境
		/// </summary>
		public OperEnvironment OperEnvironment
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

		/// <summary>
		/// 是否自动转换
		/// </summary>
		public bool IsAutoConvert
		{
			get
			{
				return this.isAutoConvert;
			}
			set
			{
				this.isAutoConvert = value;
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

			if (this.operEnvironment != null)
			{
				this.operEnvironment.Dispose();
				this.operEnvironment = null;
			}
			if (this.dept != null)
			{
				this.dept.Dispose();
				this.dept = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前类的实例的副本</returns>
		public new PageSize Clone()
		{
			PageSize pageSize = base.Clone() as PageSize;

			pageSize.Dept = this.Dept.Clone();
			pageSize.OperEnvironment = this.OperEnvironment.Clone();

			return pageSize;
		}

		#endregion

        #region 公有方法

		/// <summary>
		/// 转化像素到毫米
		/// </summary>
		/// <param name="pixel">象素值</param>
		/// <returns>毫米长度</returns>
		public float ConvertPixelToMM(int pixel)
		{
			if (pixel > 0)
			{
				return (float)(pixel / 3.78);	
			}
			else
			{
				return 0f;
			}
		}

		/// <summary>
		/// 转化毫米到像素
		/// </summary>
		/// <param name="mm">毫米长度</param>
		/// <returns>象素值</returns>
		public int ConvertMMToPixel(float mm)
		{
			if (mm > 0)
			{
				return (int)(mm * 3.78);	
			}
			else
			{
				return 0;
			}
		}

		#endregion

		#endregion
	}
}
