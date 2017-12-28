
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// ConstriantDictionary<br></br>
	/// [功能描述: 常数约束实体]<br></br>
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
    public class ConstriantDictionary: Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public ConstriantDictionary()
		{
		}


		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 字典类型
		/// </summary>
		private string dictType ;

		/// <summary>
		/// 字典ID
		/// </summary>
		private string dictID ;

		/// <summary>
		/// SQL状态 UPDATE DELETE
		/// </summary>
		private string sqlType ;

		/// <summary>
		/// 约束条件
		/// </summary>
		private string constraintSql ;

		/// <summary>
		/// 操作信息
		/// </summary>				
		private OperEnvironment operEnvironment = new OperEnvironment();	

		#endregion

		#region 属性

		/// <summary>
		/// 字典类型
		/// </summary>
		public string Type
		{
			get
			{
				return this.dictType;
			}
			set
			{
				this.dictType = value;
			}
		}


		/// <summary>
		/// 字典ID
		/// </summary>
		public string Id
		{
			get
			{
				return this.dictID;
			}
			set
			{
				this.dictID = value;
			}
		}


		/// <summary>
		/// SQL状态 UPDATE DELETE
		/// </summary>
		public string SqlType
		{
			get
			{
				return this.sqlType;
			}
			set
			{
				this.sqlType = value;
			}
		}


		/// <summary>
		/// 约束条件
		/// </summary>
		public string ConstraintSql
		{
			get
			{
				return this.constraintSql;
			}
			set
			{
				this.constraintSql = value;
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
				this.operEnvironment = value ;
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
		
			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>ConstriantDictionary类实例</returns>
		public new ConstriantDictionary Clone()
		{
			return this.MemberwiseClone() as ConstriantDictionary;
		}

		#endregion

		#endregion

		

	}
}
