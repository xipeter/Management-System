using System;

namespace neusoft.HISFC.Object.InterfaceSi
{
	/// <summary>
	/// Compare 的摘要说明。
	/// </summary>
	public class Compare : neusoft.neuFC.Object.neuObject 
	{
		public Compare()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//医保中心信息
		private Item centerItem = new Item();
		//本地项目代码
		private string hisCode;
		//本地项目检索信息
		private Base.SpellCode spellCode  = new neusoft.HISFC.Object.Base.SpellCode(); 
		//本地项目规格
		private string specs;
		//本地项目价格
		private Decimal price;
		//本地项目剂型
		private string doseCode;

		private string regularName;

		public string RegularName
		{
			set
			{
				regularName = value;
			}
			get
			{
				return regularName;
			}
		}

		/// <summary>
		/// 医保中心信息
		/// </summary>
		public Item CenterItem
		{
			get
			{
				return centerItem;
			}
			set
			{
				centerItem = value;
			}
		}
		/// <summary>
		/// 本地项目代码
		/// </summary>
		public string HisCode
		{
			get
			{
				return hisCode;
			}
			set
			{
				hisCode = value;
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

		public new Compare Clone()
		{
			Compare obj = base.Clone() as Compare;
			obj.centerItem = this.CenterItem.Clone();
			obj.SpellCode = this.SpellCode.Clone();

			return obj;
		}
	}
}
