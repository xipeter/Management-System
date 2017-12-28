using System;
 
namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品基本信息]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-11]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.ComponentModel.DisplayName("药品字典信息")]
    [Serializable]
	public class Item : Neusoft.HISFC.Models.Base.Item,Neusoft.HISFC.Models.Base.IValidState
	{
		public Item()
		{
			//this.IsPharmacy = true;
            this.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
		}


		#region 变量

		/// <summary>
		/// 操作环境信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 项目名称信息
		/// </summary>
		private Neusoft.HISFC.Models.IMA.NameService nameCollection = new Neusoft.HISFC.Models.IMA.NameService();	

		/// <summary>
		/// 价格信息
		/// </summary>
		private Neusoft.HISFC.Models.IMA.PriceService priceCollection = new Neusoft.HISFC.Models.IMA.PriceService();
			
		/// <summary>
		/// 产品信息
		/// </summary>
		private Neusoft.HISFC.Models.Pharmacy.Base.ProductService product = new Neusoft.HISFC.Models.Pharmacy.Base.ProductService();

		/// <summary>
		/// 大屏幕显示
		/// </summary>
		private bool isShow;

		/// <summary>
		/// 显示属性 0 全院 1 住院  2 门诊
		/// </summary>
		private string showState;
		
		/// <summary>
		/// 是否停用
		/// </summary>
		private bool isStop;	
		
		/// <summary>
		/// 是否GMP
		/// </summary>
		private bool isGMP;

		/// <summary>
		/// 是否OTC
		/// </summary>
		private bool isOTC;

		/// <summary>
		/// 是否新药
		/// </summary>
		private bool isNew;

		/// <summary>
		/// 是否缺药
		/// </summary>
		private bool isLack;

		/// <summary>
		/// 是否需要试敏
		/// </summary>
		private bool isAllergy;

		/// <summary>
		/// 是否附材
		/// </summary>
		private bool isSubtbl;

		/// <summary>
		/// 有效成份
		/// </summary>
		private string ingredient;

		/// <summary>
		/// 中药执行标准
		/// </summary>
		private string executeStandard;

		/// <summary>
		/// 招标信息类
		/// </summary>
		private TenderOffer tenderOffer = new TenderOffer();

		/// <summary>
		/// 变动类型
		/// </summary>
		private ItemShiftType shiftType = new ItemShiftType();

		/// <summary>
		/// 变动时间
		/// </summary>
		private DateTime shiftTime;

		/// <summary>
		/// 变动原因
		/// </summary>
		private string shiftMark;

		/// <summary>
		/// 老系统药品编码
		/// </summary>
		private string oldDrugID;

		/// <summary>
		/// 拆分类型 0 可拆包装单位 1 不能拆包装单位
		/// </summary>
		private string splitType = "1";

        /// <summary>
        /// 有效性
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumValidState validState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;

        /// <summary>
        /// 是否协定处方药
        /// </summary>
        private bool isNostrum = false;

		#endregion

		#region 药品使用信息变量

		/// <summary>
		/// 包装单位
		/// </summary>
		private string packUnit;

		/// <summary>
		/// 最小单位
		/// </summary>
		private string minUnit;

		/// <summary>
		/// 基本剂量
		/// </summary>
		private decimal baseDose;

		/// <summary>
		/// 剂量单位
		/// </summary>
		private string doseUnit;

		/// <summary>
		/// 一次剂量
		/// </summary>
		private decimal onceDose;

		/// <summary>
		/// 剂型
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dosageForm = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 类别 西药、中药等
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject type = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 药品性质
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject quality = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 使用方法
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject usage = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 频次
		/// </summary>
		private Neusoft.HISFC.Models.Order.Frequency frequency = new Neusoft.HISFC.Models.Order.Frequency();

		/// <summary>
		/// 药理作用1
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject phyFunction1 = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 药理作用2
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject phyFunction2 = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 药理作用3
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject phyFunction3 = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

        #region 药品扩展信息变量

        /// <summary>
        /// 扩展数据1
        /// </summary>
        private string extendData1;

        /// <summary>
       /// 扩展数据2
       /// </summary>
        private string extendData2;

        /// <summary>
        /// 字典建立时间
        /// </summary>
        private DateTime createTime;

        #endregion

        /// <summary>
		/// 项目编码
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
				this.nameCollection.ID = value;
				this.priceCollection.ID = value;
				this.product.ID = value;
			}
		}


		/// <summary>
		/// 项目名称
		/// </summary>
        [System.ComponentModel.DisplayName("药品名称")]
        [System.ComponentModel.Description("药品商品名称")]
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				this.nameCollection.Name = value;
				this.priceCollection.Name = value;
				this.product.Name = value;
			}
		}
		

		/// <summary>
		/// 项目名称信息
		/// </summary>
		public Neusoft.HISFC.Models.IMA.NameService NameCollection
		{
			get
			{
				return this.nameCollection;
			}
			set
			{
				this.nameCollection = value;
			}
		}

        /// <summary>
        /// 价格 (零售价)
        /// </summary>
        public new decimal Price
        {
            get
            {
                if (this.priceCollection.RetailPrice != 0)
                {
                    base.Price = this.priceCollection.RetailPrice;
                    return this.priceCollection.RetailPrice;
                }
                else
                {
                    return base.Price;
                }
            }
            set
            {
                this.priceCollection.RetailPrice = value;
                base.Price = value;
            }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        [System.ComponentModel.DisplayName("拼音码")]
        [System.ComponentModel.Description("药品商品名称的拼音码")]
        public new string SpellCode
        {
            get
            {
                return this.nameCollection.SpellCode;
            }
            set
            {
                base.SpellCode = value;
                this.nameCollection.SpellCode = value;
            }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        [System.ComponentModel.DisplayName("五笔码")]
        [System.ComponentModel.Description("药品商品名称的五笔码")]
        public new string WBCode
        {
            get
            {
                return this.nameCollection.WBCode;
            }
            set
            {
                base.WBCode = value;
                this.nameCollection.WBCode = value;
            }
        }

        /// <summary>
        /// 自定义码
        /// </summary>
        [System.ComponentModel.DisplayName("自定义码")]
        [System.ComponentModel.Description("药品商品名称的自定义码")]
        public new string UserCode
        {
            get
            {
                return this.nameCollection.UserCode;
            }
            set
            {
                base.UserCode = value;
                this.nameCollection.UserCode = value;
            }
        }

        /// <summary>
        /// 国家编码
        /// </summary>
        [System.ComponentModel.DisplayName("国家编码")]
        [System.ComponentModel.Description("药品国家编码")]
        public new string GBCode
        {
            get
            {
                return this.nameCollection.GbCode;
            }
            set
            {
                base.GBCode = value;
                this.nameCollection.GbCode = value;
            }
        }

        /// <summary>
        /// 国际编码
        /// </summary>
        [System.ComponentModel.DisplayName("国际编码")]
        [System.ComponentModel.Description("药品国际编码")]
        public new string NationCode
        {
            get
            {
                return this.nameCollection.InternationalCode;
            }
            set
            {
                base.NationCode = value;
                this.nameCollection.InternationalCode = value;
            }
        }		

		/// <summary>
		/// 包装单位
		/// </summary>
        [System.ComponentModel.DisplayName("包装单位")]
        [System.ComponentModel.Description("药品包装单位")]
		public string PackUnit
		{
			get
			{
				return this.packUnit;
			}
			set
			{
				this.packUnit = value;
                base.PriceUnit = value;
			}
		}
		

		/// <summary>
		/// 最小单位
		/// </summary>
        [System.ComponentModel.DisplayName("最小单位")]
        [System.ComponentModel.Description("药品最小单位")]
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
		/// 基本剂量
		/// </summary>
        [System.ComponentModel.DisplayName("基本剂量")]
        [System.ComponentModel.Description("药品基本剂量")]
		public decimal BaseDose
		{
			get
			{
				return this.baseDose;
			}
			set
			{
				this.baseDose = value;
			}
		}
		

		/// <summary>
		/// 剂量单位
		/// </summary>
        [System.ComponentModel.DisplayName("剂量单位")]
        [System.ComponentModel.Description("药品剂量单位")]
		public string DoseUnit
		{
			get
			{
				return this.doseUnit;
			}
			set
			{
				this.doseUnit = value;
			}
		}
		

		/// <summary>
		/// 一次用量(剂量)
		/// </summary>
        [System.ComponentModel.DisplayName("每次剂量")]
        [System.ComponentModel.Description("药品每次剂量")]
		public decimal OnceDose
		{
			get
			{
				return this.onceDose;
			}
			set
			{
				this.onceDose = value;
			}
		}


		/// <summary>
		/// 剂型
		/// </summary>
        [System.ComponentModel.DisplayName("剂型")]
        [System.ComponentModel.Description("药品剂型")]
		public Neusoft.FrameWork.Models.NeuObject DosageForm
		{
			get
			{
				return this.dosageForm;
			}
			set
			{
				this.dosageForm = value;
			}
		}
		

		/// <summary>
		/// 类别 西药，中药等
		/// </summary>
        [System.ComponentModel.DisplayName("类别")]
        [System.ComponentModel.Description("药品类别")]
		public Neusoft.FrameWork.Models.NeuObject Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}
		

		/// <summary>
		/// 性质 普，麻 
		/// </summary>
        [System.ComponentModel.DisplayName("性质")]
        [System.ComponentModel.Description("药品性质")]
		public Neusoft.FrameWork.Models.NeuObject Quality
		{
			get
			{
				return this.quality;
			}
			set
			{
				this.quality = value;
			}
		}
		

		/// <summary>
		/// 使用方法
		/// </summary>
        [System.ComponentModel.DisplayName("使用方法")]
        [System.ComponentModel.Description("药品使用方法")]
		public Neusoft.FrameWork.Models.NeuObject Usage
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
		/// 频次
		/// </summary>
        [System.ComponentModel.DisplayName("频次")]
        [System.ComponentModel.Description("药品频次")]
		public Neusoft.HISFC.Models.Order.Frequency Frequency
		{
			get
			{
				return this.frequency;
			}
			set
			{
				this.frequency = value;
			}
		}
		

		/// <summary>
		/// 一级药理作用
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PhyFunction1
		{
			get
			{
				return this.phyFunction1;
			}
			set
			{
				this.phyFunction1 = value;
			}
		}
		

		/// <summary>
		/// 二级药理作用
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PhyFunction2
		{
			get
			{
				return this.phyFunction2;
			}
			set
			{
				this.phyFunction2 = value;
			}
		}
		

		/// <summary>
		/// 三级药理作用
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PhyFunction3
		{
			get
			{
				return this.phyFunction3;
			}
			set
			{
				this.phyFunction3 = value;
			}
		}
		

		/// <summary>
		/// 价格信息
		/// </summary>
		public Neusoft.HISFC.Models.IMA.PriceService PriceCollection
		{
			get
			{
				return this.priceCollection;
			}
			set
			{
				this.priceCollection = value;
                base.Price = value.RetailPrice;
			}
		}


		/// <summary>
		/// 产品信息
		/// </summary>
		public Neusoft.HISFC.Models.Pharmacy.Base.ProductService Product
		{
			get
			{
				return this.product;
			}
			set
			{
				this.product = value;
			}
		}
		

		/// <summary>
		/// 是否停用
		/// </summary>
        [System.ComponentModel.DisplayName("是否停用")]
        [System.ComponentModel.Description("药品是否停用")]
        [Obsolete("该属性不由数据库内获取",false)]
		public bool IsStop
		{
			get
			{
				return this.isStop;
			}
			set
			{
				this.isStop = value;

                if (value)
                {
                    this.validState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
                }
                else
                {
                    this.validState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;
                }               
			}
		}

        #region IValidState 成员

        public new Neusoft.HISFC.Models.Base.EnumValidState ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                if (value == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    this.isStop = false;
                }
                else
                {
                    this.isStop = true;
                }

                this.validState = value;
            }
        }

        #endregion
		

		/// <summary>
		/// 是否GMP
		/// </summary>
        [System.ComponentModel.DisplayName("是否GMP")]
        [System.ComponentModel.Description("药品是否GMP")]
		public bool IsGMP
		{
			get
			{
				return this.isGMP;
			}
			set
			{
				this.isGMP = value;
			}
		}
		

		/// <summary>
		/// 是否OTC
		/// </summary>
        [System.ComponentModel.DisplayName("是否OTC")]
        [System.ComponentModel.Description("药品是否OTC")]
		public bool IsOTC
		{
			get
			{
				return this.isOTC;
			}
			set
			{
				this.isOTC = value;
			}
		}
		

		/// <summary>
		/// 是否新药
		/// </summary>
		public bool IsNew
		{
			get
			{
				return this.isNew;
			}
			set
			{
				this.isNew = value;
			}
		}
		

		/// <summary>
		/// 是否缺药
		/// </summary>
		public bool IsLack
		{
			get
			{
				return this.isLack;
			}
			set
			{
				this.isLack = value;
			}
		}


		/// <summary>
		/// 大屏幕显示
		/// </summary>
		public bool IsShow
		{
			get
			{
				return this.isShow;
			}
			set
			{
				this.isShow = value;
			}
		}


		/// <summary>
		/// 显示属性 0 全院 1 住院  2 门诊
		/// </summary>
		public string ShowState
		{
			get
			{
				return this.showState;
			}
			set
			{
				this.showState = value;
			}
		}


		/// <summary>
		/// 是否需要试敏
		/// </summary>
        [System.ComponentModel.DisplayName("是否需要试敏")]
        [System.ComponentModel.Description("药品是否需要试敏 试敏提示医生")]
		public bool IsAllergy
		{
			get
			{
				return this.isAllergy;
			}
			set
			{
				this.isAllergy = value;
			}
		}
		

		/// <summary>
		/// 是否附材
		/// </summary>
		public bool IsSubtbl
		{
			get
			{
				return this.isSubtbl;
			}
			set
			{
				this.isSubtbl = value;
			}
		}
		
		
		/// <summary>
		/// 有效成份
		/// </summary>
		public string Ingredient
		{
			get
			{
				return this.ingredient;
			}
			set
			{
				this.ingredient = value;
			}
		}


		/// <summary>
		/// 中药执行标准
		/// </summary>
		public string ExecuteStandard
		{
			get
			{
				return this.executeStandard;
			}
			set
			{
				this.executeStandard = value;
			}
		}
		
		
		/// <summary>
		/// 招标信息类
		/// </summary>
		public TenderOffer TenderOffer
		{
			get
			{
				return this.tenderOffer;
			}
			set
			{
				this.tenderOffer = value;
			}
		}


		/// <summary>
		/// 变动类型
		/// </summary>
		public ItemShiftType ShiftType
		{
			get
			{
				return this.shiftType;
			}
			set
			{
				this.shiftType = value;
			}
		}


		/// <summary>
		/// 变动时间
		/// </summary>
		public DateTime ShiftTime
		{
			get
			{
				return this.shiftTime;
			}
			set
			{
				this.shiftTime = value;
			}
		}


		/// <summary>
		/// 变动原因
		/// </summary>
		public string ShiftMark
		{
			get
			{
				return this.shiftMark;
			}
			set
			{
				this.shiftMark = value;
			}
		}


		/// <summary>
		/// 老系统药品编码
		/// </summary>
		public string OldDrugID
		{
			get
			{
				return this.oldDrugID;
			}
			set
			{
				this.oldDrugID = value;
			}
		}


		/// <summary>
		/// 拆分类型 0 可拆包装单位 1 不能拆包装单位
		/// </summary>
        [System.ComponentModel.DisplayName("拆分类型")]
        [System.ComponentModel.Description("药品拆分类型 仅对门诊及出院带药有效")]
		public string SplitType 
		{
			get
			{
				return this.splitType;
			}
			set
			{
				this.splitType = value;
			}
		}

        /// <summary>
        /// 药品等级
        /// </summary>
        [System.ComponentModel.DisplayName("药品等级")]
        [System.ComponentModel.Description("药品等级 与医生职级相关")]
        public new string Grade
        {
            get
            {
                return base.Grade;
            }
            set
            {
                base.Grade = value;
            }
        }


		/// <summary>
		/// 操作环境信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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
        /// 是否协定处方药
        /// </summary>
        [System.ComponentModel.DisplayName("协定处方药标记")]
        [System.ComponentModel.Description("协定处方药标记")]
        public bool IsNostrum
        {
            get
            {
                return this.isNostrum;
            }
            set
            {
                this.isNostrum = value;
            }
        }

        /// <summary>
        /// 扩展数据1     {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
        /// </summary>
        public string ExtendData1
        {
            get
            {
                return this.extendData1;
            }
            set
            {
                this.extendData1 = value;
            }
        }

        /// <summary>
        /// 扩展数据2     {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
        /// </summary>
        public string ExtendData2
        {
            get
            {
                return this.extendData2;
            }
            set
            {
                this.extendData2 = value;
            }
        }

        /// <summary>
        /// 字典建立时间  {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                this.createTime = value;
            }
        }

		#region 方法

		/// <summary>
		/// 函数克隆
		/// </summary>
		/// <returns>成功返回克隆后的Item实体 失败返回null</returns>
		public new Item Clone()
		{
			Item item = base.Clone() as Item;

			item.NameCollection = this.NameCollection.Clone();
			item.DosageForm = this.DosageForm.Clone();
			item.Type = this.Type.Clone();
			item.Quality = this.Quality.Clone();
			item.Usage = this.Usage.Clone();
			item.Frequency = this.Frequency.Clone();
			item.PhyFunction1 = this.PhyFunction1.Clone();
			item.PhyFunction2 = this.PhyFunction2.Clone();
			item.PhyFunction3 = this.PhyFunction3.Clone();
			item.PriceCollection = this.PriceCollection.Clone();
			item.Product = this.Product.Clone();	
			item.TenderOffer = this.TenderOffer.Clone();
			item.ShiftType = this.ShiftType.Clone();

			return item;
		}

		#endregion
    }
}