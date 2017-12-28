using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 招标类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// ID    招标文号
	/// Name  （暂时不用）
	/// </summary>
    [Serializable]
    public class TenderOffer : Neusoft.FrameWork.Models.NeuObject
	{
		public TenderOffer()
		{

		}


		#region 变量

		/// <summary>
		/// 是否招标用药
		/// </summary>
		private bool isTenderOffer;

		/// <summary>
		/// 中标价
		/// </summary>
		private decimal price;

		/// <summary>
		/// 采购合同单位编号
		/// </summary>
		private string contractNo;

		/// <summary>
		/// 采购开始日前
		/// </summary>
		private DateTime beginDate;

		/// <summary>
		/// 采购结束日期
		/// </summary>
		private DateTime endDate;

		/// <summary>
		/// 采购单位
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject company = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

		/// <summary>
		/// 是否是招标用药
		/// </summary>
		public bool IsTenderOffer
		{
			get
			{
				return this.isTenderOffer;
			}
			set
			{
				this.isTenderOffer = value;
			}
		}


		/// <summary>
		/// 中标价
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


		/// <summary>
		/// 采购合同编号
		/// </summary>
		public string ContractNO
		{
			get
			{
				return this.contractNo;
			}
			set
			{
				this.contractNo = value;
			}
		}


		/// <summary>
		/// 采购开始周期
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginDate;
			}
			set
			{
				this.beginDate = value;
			}
		}


		/// <summary>
		/// 采购结束周期
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return this.endDate;
			}
			set
			{
				this.endDate = value;
			}
		}


		/// <summary>
		/// 采购单位
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Company
		{
			get
			{
				return this.company;
			}
			set
			{
				this.company = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本 </returns>
		public new TenderOffer Clone()
		{
			TenderOffer tenderOffer = base.Clone() as TenderOffer;

			tenderOffer.company = this.company.Clone();

			return tenderOffer;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 采购合同单位编号
		/// </summary>
		private string contractCode;

		/// <summary>
		/// 采购合同编号
		/// </summary>
		[System.Obsolete("程序重构 更改为ContractNO属性")]
		public string ContractCode
		{
			get
			{
				return this.contractCode;
			}
			set
			{
				this.contractCode = value;
			}
		}


		/// <summary>
		/// 采购开始周期
		/// </summary>
		[System.Obsolete("程序整合 更改为BeginTime属性",true)]
		public DateTime BeginDate
		{
			get
			{
				return this.beginDate;
			}
			set
			{
				this.beginDate = value;
			}
		}


		/// <summary>
		/// 采购结束周期
		/// </summary>
		[System.Obsolete("程序整合 更改为EndTime属性",true)]
		public DateTime EndDate
		{
			get
			{
				return this.endDate;
			}
			set
			{
				this.endDate = value;
			}
		}


		#endregion
	}
}
