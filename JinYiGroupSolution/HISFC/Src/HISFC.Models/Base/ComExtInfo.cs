using System;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// ComExtInfo<br></br>
	/// [功能描述: 扩展属性]<br></br>
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
    [System.Obsolete("已经不用了，都用ExtendInfo来做这些东西了!",false)]
	public class ComExtInfo : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public ComExtInfo()
		{
		}


		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 扩展属性编码
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 属性编码
		/// </summary>
		private string propertyCode;

		/// <summary>
		/// 属性名称
		/// </summary>
		private string propertyName ;

		/// <summary>
		/// 字符属性
		/// </summary>
		private string stringProperty = "" ;

		/// <summary>
		/// 数值属性
		/// </summary>
		private decimal numberProperty = 0;

		/// <summary>
		/// 日期属性
		/// </summary>
		private System.DateTime dateProperty = DateTime.MinValue;

		/// <summary>
		/// 操作信息
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();

		#endregion

		#region 属性

		/// <summary>
		/// 扩展属性编码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Item 
		{
			get
			{ 
				return this.item; 
			}
			set
			{
				this.item = value;
				this.ID = value.ID;
			}
		}

		/// <summary>
		/// 属性编码
		/// </summary>
		public string PropertyCode 
		{
			get
			{ 
				return this.propertyCode; 
			}
			set
			{ 
				this.propertyCode = value; 
			}
		}

		/// <summary>
		/// 属性名称
		/// </summary>
		public string PropertyName 
		{
			get
			{ 
				return this.propertyName; 
			}
			set
			{
				this.propertyName = value; 
			}
		}

		/// <summary>
		/// 字符属性
		/// </summary>
		public string StringProperty 
		{
			get
			{ 
				return this.stringProperty; 
			}
			set
			{
				this.stringProperty = value; 
				this.Name = value;
			}
		}

		/// <summary>
		/// 数值属性
		/// </summary>
		public System.Decimal NumberProperty 
		{
			get
			{ 
				return this.numberProperty; 
			}
			set
			{
				this.numberProperty = value; 
				this.Name = value.ToString();
			}
		}

		/// <summary>
		/// 日期属性
		/// </summary>
		public System.DateTime DateProperty 
		{
			get
			{ 
				return this.dateProperty; 
			}
			set
			{
				this.dateProperty = value; 
				this.Name = value.ToString();
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

		#endregion

		#region 方法

		#region 释放

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
		
			if (this.item != null)
			{
				this.item.Dispose();
				this.item = null;
			}

			if (this.operEnvironment != null)
			{
				this.operEnvironment.Dispose();
				this.operEnvironment = null;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}
		#endregion

		#region 克隆

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>ComExtInfo类实例</returns>
		public new ComExtInfo Clone()
		{
			ComExtInfo comExtInfo = base.Clone() as ComExtInfo;

			comExtInfo.Item = this.Item.Clone();
			comExtInfo.OperEnvironment = this.OperEnvironment.Clone();

			return comExtInfo;
		}

		#endregion

		#endregion

		

	}
}
