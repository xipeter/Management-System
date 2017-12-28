using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资字典]
	/// [创 建 者: 李超]
	/// [创建时间: 2007-03-10]
	/// ID 代表物品编码 Name 代表物品名称
	/// </summary>
	public class MaterialItem:Neusoft.HISFC.Object.Base.Item
	{		
		public MaterialItem()
		{
			
		}


		#region 域 

		/// <summary>
		/// 仓库编码
		/// </summary>
		private Neusoft.NFC.Object.NeuObject storageInfo = new Neusoft.NFC.Object.NeuObject();
	
		/// <summary>
		/// 规格
		/// </summary>
		private string specification;
		
		/// <summary>
		/// 物品科目信息
		/// </summary>		
		private Neusoft.NFC.Object.NeuObject materialKind = new Neusoft.NFC.Object.NeuObject();		
	
		/// <summary>
		/// 计量单位
		/// </summary>
		private string minUnit = string.Empty;

		/// <summary>
		/// 单价(最小单位)
		/// </summary>
		private decimal unitPrice;
		
		/// <summary>
		/// 批文信息
		/// </summary>
		private string approveInfo;

		/// <summary>
		/// 中心对照信息(医疗项目)
		/// </summary>
		private Neusoft.HISFC.Object.SIInterface.Compare compare = new Neusoft.HISFC.Object.SIInterface.Compare();

		/// <summary>
		/// 对应的非药品项目信息
		/// </summary>
		private Neusoft.HISFC.Object.Fee.Item.Undrug undrugInfo = new Neusoft.HISFC.Object.Fee.Item.Undrug();

		/// <summary>
		/// 停用标记(0－有效,1－停用 2 其他状态)
		/// </summary>
		private bool validState;

		/// <summary>
		/// 特殊标记
		/// </summary>
		private string specialFlag = string.Empty;

		/// <summary>
		/// 生产厂家
		/// </summary>
		private MaterialCompany factory = new MaterialCompany();

		/// <summary>
		/// 供货公司
		/// </summary>
		private MaterialCompany company = new MaterialCompany();

		/// <summary>
		/// 统计代码
		/// </summary>
		private Neusoft.NFC.Object.NeuObject statInfo = new Neusoft.NFC.Object.NeuObject();

		/// <summary>
		/// 加价规则
		/// </summary>
		private string addRule = string.Empty;

		/// <summary>
		/// 来源
		/// </summary>
		private string inSource = string.Empty;

		/// <summary>
		/// 用途
		/// </summary>
		private string usage = string.Empty;

		/// <summary>
		/// 大包装单位
		/// </summary>
		private string packUnit = string.Empty;

		/// <summary>
		/// 大包装价格
		/// </summary>
		private decimal packPrice; 

		/// <summary>
		/// 操作员
		/// </summary>
		private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();
		
		/// <summary>
		/// 操作日期
		/// </summary>
		private DateTime operTime;	

		/// <summary>
		/// 财务收费物品标志(0－否,1－是)
		/// </summary>
		private bool financeState;
		/// <summary>
		/// 生产者
		/// </summary>
		private string mader="";
		/// <summary>
		/// 注册号
		/// </summary>
		private string zch="";
		/// <summary>
		/// 特殊类别
		/// </summary>
		private string speType = "";
		/// <summary>
		/// 注册时间
		/// </summary>
		private DateTime zc_date;
		/// <summary>
		/// 到期时间
		/// </summary>
		private DateTime over_date;

		
				
		#endregion

		#region 属性
		/// <summary>
		/// 生产者
		/// </summary>
		public string Mader
		{
			get
			{
				return this.mader;
			}
			set
			{
				this.mader = value;
			}
		}
		/// <summary>
		/// 注册号
		/// </summary>
		public string ZCH
		{
			get
			{
				return this.zch;
			}
			set
			{
				this.zch = value;
			}
		}
		/// <summary>
		/// 特殊类别
		/// </summary>
		public string SpeType
		{
			get
			{
				return this.speType;
			}
			set
			{
				this.speType = value;
			}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime ZCDate
		{
			get
			{
				return this.zc_date;
			}
			set
			{
				this.zc_date = value;
			}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime OverDate
		{
			get
			{
				return this.over_date;
			}
			set
			{
				this.over_date = value;
			}
		}
		/// <summary>
		/// 仓库代码
		/// </summary>
		public Neusoft.NFC.Object.NeuObject StorageInfo
		{
			get
			{
				return this.storageInfo;
			}
			set
			{
				this.storageInfo = value;
			}
		}
		
		/// <summary>
		/// 物品编码
		/// </summary>
		public new string ID
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		/// <summary>
		/// 物品科目信息
		/// </summary>
		public Neusoft.NFC.Object.NeuObject MaterialKind
		{
			get
			{
				return this.materialKind;
			}
			set
			{
                this.materialKind = value;
			}
		}    
		
		/// <summary>
		/// 物品名称
		/// </summary>
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}
		
		/// <summary>
		/// 拼音编码
		/// </summary>
		public new string SpellCode
		{
			get
			{
				return base.SpellCode;
			}
			set
			{
                base.SpellCode = value;
			}
		}

		/// <summary>
		/// 五笔码
		/// </summary>
		public new string WbCode 
		{
			get
			{
				return base.WBCode;
			}
			set
			{
				base.WBCode = value;
			}
		}

		/// <summary>
		/// 自定义码
		/// </summary>
		public new string UserCode
		{
			get
			{
				return base.UserCode;
			}
			set
			{
				base.UserCode = value;
			}
		}

		/// <summary>
		/// 国家编码
		/// </summary>
		public new string GbCode
		{
			get
			{
				return base.GBCode;
			}
			set
			{
				base.GBCode = value;
			}
		}

		/// <summary>
		/// 规格
		/// </summary>
		public new string Specs
		{
			get
			{
				return this.specification;
			}
			set
			{
				this.specification = value;

			}
		}

		/// <summary>
		/// 最小单位
		/// </summary>
		public string MinUnit 
		{
			get
			{
				return this.minUnit;
			}
			set
			{
				this.minUnit = value;
			}
		}

		/// <summary>
		/// 单价(最小单位价格)
		/// </summary>
		public decimal UnitPrice 
		{
			get
			{
				return this.unitPrice;
			}
			set
			{
				this .unitPrice = value;
			}
		}

		/// <summary>
		/// 批文信息
		/// </summary>
		public string ApproveInfo
		{
			get
			{
				return this.approveInfo;
			}
			set
			{
				this.approveInfo = value;
			}
		}

		/// <summary>
		/// 中心对照信息(医疗项目)
		/// </summary>
		public Neusoft.HISFC.Object.SIInterface.Compare Compare
		{
			get
			{
				return this.compare;
			}
			set
			{
				this.compare = value;
			}
		}

		/// <summary>
		/// 非药品信息
		/// </summary>
		public Neusoft.HISFC.Object.Fee.Item.Undrug UndrugInfo  
		{
			get
			{
				return this.undrugInfo;
			}
			set
			{
				this.undrugInfo = value;
			}
		}

		/// <summary>
		/// 停用标记(1－有效,0－停用 2 其他状态)
		/// </summary>
		public bool ValidState 
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;
			}
		}

		/// <summary>
		/// 特殊标记
		/// </summary>
		public new string SpecialFlag
		{
			get
			{
				return base.SpecialFlag;
			}
			set
			{
				base.SpecialFlag = value;
			}
		}

		/// <summary>
		/// 生产厂家
		/// </summary>
		public MaterialCompany Factory 
		{
			get
			{
				return this.factory;
			}
			set
			{
				this.factory = value;
			}
		}

		/// <summary>
		/// 供货公司
		/// </summary>
		public MaterialCompany Company 
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
		/// 统计代码
		/// </summary>
		public Neusoft.NFC.Object.NeuObject StatInfo 
		{
			get
			{
				return this.statInfo;
			}
			set
			{
				this.statInfo = value;
			}
		}

		/// <summary>
		/// 加价规则
		/// </summary>
		public string AddRule
		{
			get
			{
				return this.addRule;
			}
			set
			{
				this.addRule = value;
			}
		}

		/// <summary>
		/// 大包装单位
		/// </summary>
		public string PackUnit
		{
			get
			{
				return this.packUnit;
			}
			set
			{
				this.packUnit = value;
			}
		}

		/// <summary>
		/// 大包装数量
		/// </summary>
		public new decimal PackQty
		{
			get
			{
				return base.PackQty;
			}
			set
			{
				base.PackQty = value;
			}
		}

		/// <summary>
		/// 大包装价格
		/// </summary>
		public decimal PackPrice
		{
			get
			{
				return this.packPrice;
			}
			set
			{
				this.packPrice = value;
			}
		}

		/// <summary>
		/// 来源
		/// </summary>
		public string InSource 
		{
			get
			{
				return this.inSource;
			}
			set
			{
				this.inSource = value;
			}
		}

		/// <summary>
		/// 用途
		/// </summary>
		public string Usage
		{
			get
			{
				return this.usage;
			}
			set
			{
				this.usage = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Oper 
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}

		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperTime 
		{
			get
			{
				return this.operTime;
			}
			set
			{
				this.operTime = value;
			}
		}

		/// <summary>
		/// 财务收费标志
		/// </summary>
		public bool FinanceState 
		{
			get
			{
				return this.financeState;
			}
			set
			{
				this.financeState = value;
			}
		}

		

    	#endregion

		#region 方法		
	
		/// <summary>
		/// 函数克隆
		/// </summary>
		/// <returns>成功返回克隆后的MaterialItem实体 失败返回null</returns>
		public new MaterialItem Clone()
		{
			MaterialItem materialItem = base.Clone() as MaterialItem;

			materialItem.StorageInfo = this.StorageInfo.Clone();

			materialItem.Compare = this.Compare.Clone();

			materialItem.Oper = this.Oper.Clone();

			materialItem.UndrugInfo = this.UndrugInfo.Clone();

			materialItem.Factory = this.Factory.Clone();

			materialItem.Company = this.Company.Clone();

			materialItem.MaterialKind = this.MaterialKind.Clone();

			materialItem.StatInfo = this.StatInfo.Clone();

			return materialItem;
		} 

		#endregion
	}
}
