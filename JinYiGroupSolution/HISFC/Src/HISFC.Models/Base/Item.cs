using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using System;
namespace Neusoft.HISFC.Models.Base
{   
    
	/// <summary>
	/// Item<br></br>
	/// [功能描述: 项目基类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Item : Spell, IValid
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Item()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 国际编码
		/// </summary>
		private string nationCode;

		/// <summary>
		/// 国家编码
		/// </summary>
		private string gbCode;

		/// <summary>
		/// 系统类别
		/// </summary>
		private SysClassEnumService sysClass = new SysClassEnumService();

		/// <summary>
		/// 最小费用
		/// </summary>
		private NeuObject minFee = new NeuObject();

		/// <summary>
		/// 三甲价,基本价格
		/// </summary>
		private decimal price;

		/// <summary>
		/// 儿童价
		/// </summary>
		private decimal childPrice;

		/// <summary>
		/// 特诊价
		/// </summary>
		private decimal specialPrice;

		/// <summary>
		/// 记价单位
		/// </summary>
		private string  priceUnit;

		/// <summary>
		/// 包装数量
		/// </summary>
		private decimal packQty;

		/// <summary>
		/// 规格
		/// </summary>
		private string specs;

		/// <summary>
		/// 记价数量
		/// </summary>
		private decimal qty;

		/// <summary>
		/// 是否药品 true:是药品 false:非药品或者组套,组合项目
		/// </summary>
		private bool isPharmacy;

        /// <summary>
        /// 项目类型 Drug:药品 Undrug:非药品或者组套,组合项目 MatItem:物资项目
        /// </summary>
        //{25934862-5C82-409c-A0D7-7BE5A24FFC75}
        private EnumItemType itemType = EnumItemType.UnDrug;

		/// <summary>
		/// 是否需要终端确认
		/// </summary>
		private bool isNeedConfirm;

		/// <summary>
		/// 是否有效 true有效[1] false无效[0]
		/// </summary>
		private bool isValid;

		/// <summary>
		/// 有效性状态 1 有效 其他状态自定义
		/// </summary>
		private string validState;

		/// <summary>
		/// 是否附材
		/// </summary>
		private bool isMaterial;
		
		/// <summary>
		/// 是否需要预约
		/// </summary>
		private bool isNeedBespeak;

		/// <summary>
		/// 特殊标志
		/// </summary>
		private string specialFlag;

		/// <summary>
		/// 特殊标志1
		/// </summary>
		private string specialFlag1;

		/// <summary>
		/// 特殊标志2
		/// </summary>
		private string specialFlag2;

		/// <summary>
		/// 特殊标志3
		/// </summary>
		private string specialFlag3;

		/// <summary>
		/// 特殊标志4
		/// </summary>
		private string specialFlag4;

	
		
		/// <summary>
		/// 甲乙丙类
		/// </summary>
		private string grade="" ;
		#endregion

		#region 属性

		/// <summary>
		/// 国际编码
		/// </summary>
		public string NationCode
		{
			get
			{
				return this.nationCode;
			}
			set
			{
				this.nationCode = value;
			}
		}

		/// <summary>
		/// 国家编码
		/// </summary>
		public string GBCode
		{
			get
			{
				return gbCode;
			}
			set
			{
				gbCode = value;
			}
		}

		/// <summary>
		/// 系统类别
		/// </summary>
		public SysClassEnumService SysClass
		{
			get
			{
				return this.sysClass;
			}
			set
			{
				this.sysClass = value;
			}
		}

		/// <summary>
		/// 最小费用
		/// </summary>
		public NeuObject MinFee
		{
			get
			{
				return this.minFee;
			}
			set
			{
				this.minFee = value;
			}
		}

		/// <summary>
		/// 三甲价,基本价格
		/// </summary>
		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				if (value < 0)
				{
					this.price = 0;
				}
				else
				{
					this.price = value;
				}
			}
		}

		/// <summary>
		/// 儿童价
		/// </summary>
		public decimal ChildPrice
		{
			get
			{
				return this.childPrice;
			}
			set
			{
				if (value < 0)
				{
					this.childPrice = 0;
				}
				else
				{
					this.childPrice = value;
				}
			}
		}

		/// <summary>
		/// 特诊价
		/// </summary>
		public decimal SpecialPrice
		{
			get
			{
				return this.specialPrice;
			}
			set
			{
				if (value < 0)
				{
					this.specialPrice = 0;
				}
				else
				{
					this.specialPrice = value;
				}
			}
		}

		/// <summary>
		/// 记价单位
		/// </summary>
		public string PriceUnit
		{
			get
			{
				return this.priceUnit;
			}
			set
			{
				this.priceUnit = value;
			}
		}

		/// <summary>
		/// 包装数量
		/// </summary>
		public decimal PackQty
		{
			get
			{
				return this.packQty;
			}
			set
			{
				//包装数不能小于1
				if(value < 1)
				{
					this.packQty = 1;
				}
				else
				{
					this.packQty = value;
				}
			}
		}

		/// <summary>
		/// 规格
		/// </summary>
        [System.ComponentModel.DisplayName("规格")]
        [System.ComponentModel.Description("药品规格")]
		public string Specs
		{
			get
			{
				return this.specs;
			}
			set
			{
				this.specs = value;
			}
		}

		/// <summary>
		/// 记价数量
		/// </summary>
		public decimal Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}

        
		/// <summary>
		/// 是否药品
		/// </summary>
        //{25934862-5C82-409c-A0D7-7BE5A24FFC75}
        [Obsolete("由枚举ItemType代替",true)]
		public bool IsPharmacy
		{
			get
			{
				return this.isPharmacy;
			}
			set
			{
				this.isPharmacy = value;
			}
		}

        /// <summary>
        /// 项目类型 Drug:药品 Undrug:非药品或者组套,组合项目 MatItem:物资项目
        /// </summary>
        //{25934862-5C82-409c-A0D7-7BE5A24FFC75}
        public EnumItemType ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
            }
        }

		/// <summary>
		/// 是否需要终端确认
		/// </summary>
		public bool IsNeedConfirm
		{
			get
			{
				return this.isNeedConfirm;
			}
			set
			{
				this.isNeedConfirm = value;
			}
		}

		/// <summary>
		/// 有效性状态 1 有效 其他状态自定义
		/// </summary>
		public string ValidState
		{
			get
			{
				
				return validState;
			}
			set
			{
				this.validState = value;
				//如果有效性状态不是"1"即有效,那么该项目的有效性判断为false;
				if (validState == "1")
				{
					this.isValid = true;
				}
				else
				{
					this.isValid = false;
				}
			}
		}

		/// <summary>
		/// 是否附材
		/// </summary>
		public bool IsMaterial
		{
			get
			{
				return this.isMaterial;
			}
			set
			{
				this.isMaterial = value;
			}
		}
		
		/// <summary>
		/// 是否需要预约
		/// </summary>
		public bool IsNeedBespeak
		{
			get
			{
				return this.isNeedBespeak;
			}
			set
			{
				this.isNeedBespeak = value;
			}
		}

		/// <summary>
		/// 特殊标志
		/// </summary>
		public string SpecialFlag
		{
			get
			{
				return this.specialFlag;
			}
			set
			{
				this.specialFlag = value;
			}
		}

		/// <summary>
		/// 特殊标志1
		/// </summary>
		public string SpecialFlag1
		{
			get
			{
				return this.specialFlag1;
			}
			set
			{
				this.specialFlag1 = value;
			}
		}

		/// <summary>
		/// 特殊标志2
		/// </summary>
		public string SpecialFlag2
		{
			get
			{
				return this.specialFlag2;
			}
			set
			{
				this.specialFlag2 = value;
			}
		}

		/// <summary>
		/// 特殊标志3
		/// </summary>
		public string SpecialFlag3
		{
			get
			{
				return this.specialFlag3;
			}
			set
			{
				this.specialFlag3 = value;
			}

		}

		/// <summary>
		/// 特殊标志4
		/// </summary>
		public string SpecialFlag4
		{
			get
			{
				return this.specialFlag4;
			}
			set
			{
				this.specialFlag4 = value;
			}
		}

		/// <summary>
		/// 甲乙丙类
		/// </summary>
		public string Grade
		{
			get
			{
				return this.grade;
			}
			set
			{
				this.grade = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>克隆后的当前对象的实例</returns>
		public new Item Clone()
		{
			Item item = base.Clone() as Item;

			item.MinFee = this.MinFee.Clone();
			
			return item;
		}

		#endregion

		#endregion
	
		#region 接口实现
		
		#region IValid 成员
		/// <summary>
		/// 是否有效 true有效[1] false无效[0]
		/// </summary>
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

		#endregion
		
		#endregion

		
	}
}