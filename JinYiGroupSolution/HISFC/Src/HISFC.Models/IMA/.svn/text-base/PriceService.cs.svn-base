using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品物资管理价格信息]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-11]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PriceService:Neusoft.FrameWork.Models.NeuObject
	{
		public PriceService()
		{

		}


		#region 变量

		/// <summary>
		/// 零售价
		/// </summary>
		private decimal retailPrice;

		/// <summary>
		/// 批发价
		/// </summary>
		private decimal wholeSalePrice;

		/// <summary>
		/// 购入价
		/// </summary>
		private decimal purchasePrice;

		/// <summary>
		/// 最高零售价
		/// </summary>
		private decimal topRetailPrice;

		/// <summary>
		/// 价格比率
		/// </summary>
		private decimal priceRate;

		/// <summary>
		/// 定价形式
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject priceForm = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

		/// <summary>
		/// 零售价
		/// </summary>
		public decimal RetailPrice
		{
			get
			{
				return this.retailPrice;
			}
			set
			{
				this.retailPrice = value;
			}
		}


		/// <summary>
		/// 批发价
		/// </summary>
		public decimal WholeSalePrice
		{
			get
			{
				return this.wholeSalePrice;
			}
			set
			{
				this.wholeSalePrice = value;
			}
		}


		/// <summary>
		/// 购入价
		/// </summary>
		public decimal PurchasePrice
		{
			get
			{
				return this.purchasePrice;
			}
			set
			{
				this.purchasePrice = value;
			}
		}


		/// <summary>
		/// 最高零售价
		/// </summary>
		public decimal TopRetailPrice
		{
			get
			{
				return this.topRetailPrice;
			}
			set
			{
				this.topRetailPrice = value;
			}
		}


		/// <summary>
		/// 价格比率
		/// </summary>
		public decimal PriceRate
		{
			get
			{
				return this.priceRate;
			}
			set
			{
				this.priceRate = value;
			}
		}


		/// <summary>
		/// 价格形式 国家定价、招标定价
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PriceForm
		{
			get
			{
				return this.priceForm;
			}
			set
			{
				this.priceForm = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数 
		/// </summary>
		/// <returns>成功返回克隆后实体</returns>
		public new PriceService Clone()
		{
			PriceService ps = base.Clone() as PriceService;

			ps.PriceForm = this.PriceForm.Clone();

			return ps;
		}


		#endregion
	}
}
