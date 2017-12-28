using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Division<br></br>
	/// [功能描述: 分装实体]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Division:PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Division()
		{
		}
		

		#region 变量
		/// <summary>
		/// 分装数量
		/// </summary>
		private decimal divisionQty;
		/// <summary>
		/// 分装废品数量
		/// </summary>
		private decimal wasterQty;
		/// <summary>
		/// 分装质控参数 物料平衡
		/// </summary>
		private decimal divisionParam;
//		/// <summary>
//		/// 分装人
//		/// </summary>
//		private string divisionOper;
//		/// <summary>
//		/// 分装时间
//		/// </summary>
//		private DateTime divisionDate;
		/// <summary>
		/// 分装--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment divisionEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 分装产品移交接收人
		/// </summary>
		private string inceptOper;
		#endregion

		#region 属性
		/// <summary>
		/// 分装数量
		/// </summary>
		public decimal DivisionQty
		{
			get
			{
				return this.divisionQty;
			}
			set
			{
				this.divisionQty = value;
			}
		}

		/// <summary>
		/// 分装废品数量
		/// </summary>
		public decimal WasterQty
		{
			get
			{
				return this.wasterQty;
			}
			set
			{
				this.wasterQty = value;
			}
		}
		/// <summary>
		/// 分装质控参数 物料平衡
		/// </summary>
		public decimal DivisionParam
		{
			get
			{
				return this.divisionParam;
			}
			set
			{
				this.divisionParam = value;
			}
		}

		/// <summary>
		/// 分装--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment DivisionEnv
		{
			get
			{
				return this.divisionEnv;
			}
			set
			{
				this.divisionEnv = value;
			}
		}
		
		/// <summary>
		/// 分装产品移交接收人
		/// </summary>
		public string InceptOper
		{
			get
			{
				return this.inceptOper;
			}
			set
			{
				this.inceptOper = value;
			}
		}
		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Division</returns>
		public new Division Clone()
		{
			Division division = base.Clone() as Division;
			division.divisionEnv = this.divisionEnv.Clone();
			return division;
		}
		#endregion

		#region 过期属性
		/// <summary>
		/// 分装人
		/// </summary>
		[System.Obsolete("已经过期，使用DivisionEnv", true)]
		public string DivisionOper
		{
			get
			{
				return null;
			}
			set
			{
				//this.divisionOper = value;
			}
		}
		/// <summary>
		/// 分装时间
		/// </summary>
		[System.Obsolete("已经过期，使用DivisionEnv", true)]
		public DateTime DivisionDate
		{
			get
			{
				return DateTime.Now;
			}
			set
			{
				//this.divisionDate = value;
			}
		}
		/// <summary>
		/// 分装数量
		/// </summary>
		[System.Obsolete("已经过期，使用DivisionQty", true)]
		public decimal DivisionNum
		{
			get
			{
				return this.divisionQty;
			}
			set
			{
				this.divisionQty = value;
			}
		}
		/// <summary>
		/// 分装废品数量
		/// </summary>
		[System.Obsolete("已经过期，使用WasterQty", true)]
		public decimal WasterNum
		{
			get
			{
				return this.wasterQty;
			}
			set
			{
				this.wasterQty = value;
			}
		}
		#endregion
	}
}