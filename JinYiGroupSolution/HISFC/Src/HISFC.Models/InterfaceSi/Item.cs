using System;

namespace neusoft.HISFC.Object.InterfaceSi
{
	/// <summary>
	/// Item 的摘要说明。
	/// </summary>
	public class Item : neusoft.neuFC.Object.neuObject,neusoft.HISFC.Object.Base.ISpellCode
	{
		public Item()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//合同单位编码
		private string pactCode;
		//项目类别
		private string sysClass;
		//项目英文名称
		private string englishName;
		//规格
		private string specs;
		//剂型编码
		private string doseCode;
		//拼音码
		private Base.SpellCode spellCode = new neusoft.HISFC.Object.Base.SpellCode();
		//费用分类代码 1 床位费 2西药费3中药费4中成药5中草药6检查费7治疗费8放射费9手术费10化验费11输血费12输氧费13其他
		private string feeCode;
		//医保目录级别 1 基本医疗范围 2 广东省厅补充
		private string itemType;
		//医保目录等级 1 甲类(统筹全部支付) 2 乙类(准予部分支付) 3 自费
		private string itemGrade;
		//自负比例
		private Decimal rate;
		//基准价格
		private Decimal price;
		//操作员代码;
		private string operCode;
		//操作时间
		private DateTime operDate;
		/// <summary>
		/// 合同单位编码
		/// </summary>
		public string PactCode
		{
			get
			{
				return pactCode;
			}
			set
			{
				pactCode = value;
			}
		}
		/// <summary>
		/// 项目类别
		/// </summary>
		public string SysClass
		{
			get
			{
				return sysClass;
			}
			set
			{
				sysClass = value;
			}
		}
		/// <summary>
		/// 项目英文名称
		/// </summary>
		public string EnglishName
		{
			get
			{
				return englishName;
			}
			set
			{
				englishName = value;
			}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Specs
		{
			get
			{
				return specs;
			}
			set
			{
				specs = value;
			}
		}
		/// <summary>
		/// 剂型编码
		/// </summary>
		public string DoseCode
		{
			get
			{
				return doseCode;
			}
			set
			{
				doseCode = value;
			}
		}
		/// <summary>
		/// 检索信息
		/// </summary>
		public Base.SpellCode SpellCode
		{
			get
			{
				return spellCode;
			}
			set
			{
				spellCode = value;
			}
		}
		/// <summary>
		/// 费用分类代码 1 床位费 2西药费3中药费4中成药5中草药6检查费7治疗费8放射费9手术费
		/// 10化验费11输血费12输氧费13其他 
		/// </summary>
		public string FeeCode
		{
			get
			{
				return feeCode;
			}
			set
			{
				feeCode = value;
			}
		}
		/// <summary>
		/// 医保目录级别 1 基本医疗范围 2 广东省厅补充
		/// </summary>
		public string ItemType
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
		/// 医保目录等级 1 甲类(统筹全部支付) 2 乙类(准予部分支付) 3 自费
		/// </summary>
		public string ItemGrade
		{
			get
			{
				return itemGrade;
			}
			set
			{
				itemGrade = value;
			}
		}
		/// <summary>
		/// 自负比例
		/// </summary>
		public Decimal Rate
		{
			get
			{
				return rate;
			}
			set
			{
				rate = value;
			}
		}
		/// <summary>
		/// 自负比例
		/// </summary>
		public Decimal Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode
		{
			get
			{
				return operCode;
			}
			set
			{
				operCode = value;
			}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return operDate;
			}
			set
			{
				operDate = value;
			}
		}

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new Item Clone()
		{
			Item obj = base.Clone() as Item;
			obj.SpellCode = this.SpellCode.Clone();

			return obj;
		}
		#region ISpellCode 成员

		public string Spell_Code
		{
			get
			{
				// TODO:  添加 Item.Spell_Code getter 实现
				return spellCode.Spell_Code;
			}
			set
			{
				// TODO:  添加 Item.Spell_Code setter 实现
				spellCode.Spell_Code = value;
			}
		}

		public string WB_Code
		{
			get
			{
				// TODO:  添加 Item.WB_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 Item.WB_Code setter 实现
			}
		}

		public string User_Code
		{
			get
			{
				// TODO:  添加 Item.User_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 Item.User_Code setter 实现
			}
		}

		#endregion
	}

}
