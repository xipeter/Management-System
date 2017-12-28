using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// OpsApparatus 的摘要说明。
	/// 手术仪器设备实体类
	/// </summary>
    [Serializable]
    public class OpsApparatus : Neusoft.HISFC.Models.Base.Spell 
	{

		public OpsApparatus()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		private string tradeMark = string.Empty;
		/// <summary>
		/// 品牌
		/// </summary>
		public string TradeMark
		{
			get
			{
				return this.tradeMark;
			}
			set
			{
				this.tradeMark = value;
			}
		}

		/// <summary>
		/// 产地
		/// </summary>
		public string AppaSource = "";

		/// <summary>
		/// 型号
		/// </summary>
		public string AppaModel = "";
		private string model = string.Empty;
		public string Model
		{
			get
			{
				return this.model;
			}
			set
			{
				this.model = value;
			}
		}


		/// <summary>
		/// 购入日期
		/// </summary>
		public DateTime BuyDate = DateTime.MinValue;

		[Obsolete("Price",true)]
		public decimal AppaPrice = 0;
		private decimal price = 0;
		/// <summary>
		/// 价格
		/// </summary>
		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				this.price = value;
			}
		}
		

		[Obsolete("Unit",true)]
		public string AppaUnit = "";
		private string unit = string.Empty;
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit
		{
			get
			{
				return this.unit;
			}
			set
			{
				this.unit = value;
			}
		}


		/// <summary>
		/// 1在用/0未用
		/// </summary>
		private bool isValid = true;
		[Obsolete("IsValid",true)]
		public bool bStatus
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}


		private string saler = string.Empty;
		/// <summary>
		/// 经销商
		/// </summary>
		public string Saler
		{
			get
			{
				return this.saler;
			}
			set
			{
				this.saler = value;
			}
		}


		/// <summary>
		/// 生产厂家
		/// </summary>
		public string Producer = "";

		[Obsolete("Level",true)]
		public string AppaKind = "";
		private string level;
		/// <summary>
		/// 级别 1贵重,2普通
		/// </summary>
		public string Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}


		private string remark = string.Empty;
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			get
			{
				return this.remark;
			}
			set
			{
				this.remark = value;
			}
		}


		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.HISFC.Models.Base.Employee User = new Employee();
		


		public new OpsApparatus Clone()
		{
			OpsApparatus myApparatus = base.Clone() as OpsApparatus;
			myApparatus.User = this.User.Clone();
			return myApparatus;
		}
	}
}
