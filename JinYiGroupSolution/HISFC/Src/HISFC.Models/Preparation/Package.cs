using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Package<br></br>
	/// [功能描述: 包装实体]<br></br>
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
    public class Package:PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Package()
		{
		}


		#region  变量
		/// <summary>
		/// 分装产品数量
		/// </summary>
		private decimal divisionQty;
		/// <summary>
		/// 外包装数量(移交入库量)
		/// </summary>
		private decimal packingQty;
		/// <summary>
		/// 废品量
		/// </summary>
		private decimal wasterQty;
		/// <summary>
		/// 审核员
		/// </summary>
		private string checkOper;
		/// <summary>
		/// 入库移交接收人
		/// </summary>
		private string inceptOper;

		private string packingOper;
		private DateTime packingDate;

		/// <summary>
		/// 物料平衡
		/// </summary>
		private decimal pacParam;
		/// <summary>
		/// 成品率
		/// </summary>
		private decimal finParam;
		/// <summary>
		/// 外包装--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment packingEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();
		#endregion

		#region  属性
		/// <summary>
		/// 外包装--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment PackingEnv
		{
			get
			{
				return this.packingEnv;
			}
			set
			{
				this.packingEnv = value;
			}
		}
		/// <summary>
		/// 分装产品数量
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
		/// 外包装数量(移交入库量)
		/// </summary>
		public decimal PackingQty
		{
			get
			{
				return this.packingQty;
			}
			set
			{
				this.packingQty = value;
			}
		}

		/// <summary>
		/// 废品量
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
		/// 物料平衡
		/// </summary>
		public decimal PacParam
		{
			get
			{
				return this.pacParam;
			}
			set
			{
				this.pacParam = value;
			}
		}
		/// <summary>
		/// 成品率
		/// </summary>
		public decimal FinParam
		{
			get
			{
				return this.finParam;
			}
			set
			{
				this.finParam = value;
			}
		}

		/// <summary>
		/// 审核员
		/// </summary>
		public string CheckOper
		{
			get
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}
		/// <summary>
		/// 入库移交接收人
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
		/// <returns>Package</returns>
		public new Package Clone()
		{
			Package package = base.Clone() as Package;
			package.packingEnv = this.packingEnv.Clone();
			return package;
		}
		#endregion
		
		#region  过期属性
		/// <summary>
		/// 分装产品数量
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
		/// 外包装数量(移交入库量)
		/// </summary>
		[System.Obsolete("已经过期，使用PackingQty", true)]
		public decimal PackingNum
		{
			get
			{
				return this.packingQty;
			}
			set
			{
				this.packingQty = value;
			}
		}

		/// <summary>
		/// 废品量
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

		/// <summary>
		/// 外包装操作员
		/// </summary>
		[System.Obsolete("已经过期，使用PackingEnv", true)]
		public string PackingOper
		{
			get
			{
				return this.packingOper;
			}
			set
			{
				this.packingOper = value;
			}
		}
		/// <summary>
		/// 外包装操作时间
		/// </summary>
		[System.Obsolete("已经过期，使用PackingEnv", true)]
		public DateTime PackingDate
		{
			get
			{
				return this.packingDate;
			}
			set
			{
				this.packingDate = value;
			}
		}
		#endregion
	}
}