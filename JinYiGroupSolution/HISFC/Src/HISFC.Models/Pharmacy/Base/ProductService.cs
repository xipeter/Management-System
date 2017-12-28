using System;

namespace Neusoft.HISFC.Models.Pharmacy.Base
{
	/// <summary>
	/// [功能描述: 药品物资产品基本信息]<br></br>
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
    public class ProductService:Neusoft.FrameWork.Models.NeuObject
	{
		public ProductService()
		{
		}


		#region 变量

		/// <summary>
		/// 生产厂家
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject producer = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 最新供货公司
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject company = new Neusoft.FrameWork.Models.NeuObject();	
	
		/// <summary>
		/// 批文信息
		/// </summary>
		private string approvalInfo;

		/// <summary>
		/// 注册商标
		/// </summary>
		private string label;

		/// <summary>
		/// 注意事项
		/// </summary>
		private string caution;

		/// <summary>
		/// 条形码
		/// </summary>
		private string barCode;

		/// <summary>
		/// 产地
		/// </summary>
		private string producingArea;

		/// <summary>
		/// 简介
		/// </summary>
		private string briefIntroduction;

		/// <summary>
		/// 说明书内容
		/// </summary>
		private string manual;

		/// <summary>
		/// 外观图片
		/// </summary>
		private System.Drawing.Image appearanceImage;

		/// <summary>
		/// 储藏条件
		/// </summary>
		private string storeCondition;	

		/// <summary>
		/// 是否自制
		/// </summary>
		private bool isSelfMade;		

		#endregion

		/// <summary>
		/// 生产厂家
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Producer
		{
			get
			{
				return this.producer;
			}
			set
			{
				this.producer = value;
			}
		}


		/// <summary>
		/// 最新供货公司
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
		

		/// <summary>
		/// 批文信息
		/// </summary>
		public string ApprovalInfo
		{
			get
			{
				return this.approvalInfo;
			}
			set
			{
				this.approvalInfo = value;
			}
		}


		/// <summary>
		/// 注册商标
		/// </summary>
		public string Label
		{
			get
			{
				return this.label;
			}
			set
			{
				this.label = value;
			}
		}


		/// <summary>
		/// 注意事项
		/// </summary>
		public string Caution
		{
			get
			{
				return this.caution;
			}
			set
			{
				this.caution = value;
			}
		}


		/// <summary>
		/// 条形码
		/// </summary>
		public string BarCode
		{
			get
			{
				return this.barCode;
			}
			set
			{
				this.barCode = value;
			}
		}


		/// <summary>
		/// 产地
		/// </summary>
		public string ProducingArea
		{
			get
			{
				return this.producingArea;
			}
			set
			{
				this.producingArea = value;
			}
		}


		/// <summary>
		/// 药品简介
		/// </summary>
		public string BriefIntroduction
		{
			get
			{
				return this.briefIntroduction;
			}
			set
			{
				this.briefIntroduction = value;
			}
		}


		/// <summary>
		/// 药品说明书内容
		/// </summary>
		public string Manual
		{
			get
			{
				return this.manual;
			}
			set
			{
				this.manual = value;
			}
		}
		

		/// <summary>
		/// 药品外观图片
		/// </summary>
		public System.Drawing.Image Image
		{
			get
			{
				return this.appearanceImage;
			}
			set
			{
				this.appearanceImage = value;
			}
		}		


		/// <summary>
		/// 储藏条件
		/// </summary>
		public string StoreCondition
		{
			get
			{
				return this.storeCondition;
			}
			set
			{
				this.storeCondition = value;
			}
		}


		/// <summary>
		/// 是否自制
		/// </summary>
		public bool IsSelfMade
		{
			get
			{
				return this.isSelfMade;
			}
			set
			{
				this.isSelfMade = value;
			}
		}
		

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>成功返回ProductSerice克隆后实体</returns>
		public new ProductService Clone()
		{
			ProductService productS = base.Clone() as ProductService;

			productS.Producer = this.Producer.Clone();
			productS.Company = this.Company.Clone();

			return productS;
		}


		#endregion
	}
}
