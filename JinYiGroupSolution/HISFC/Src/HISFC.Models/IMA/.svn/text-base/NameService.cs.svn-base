using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 项目名称基类信息]<br></br>
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
    public class NameService : Neusoft.HISFC.Models.Base.Spell
	{

		public NameService()
		{
		}


		#region 变量
		/// <summary>
		/// 通用名
		/// </summary>
		private string regularName;

		/// <summary>
		/// 通用名拼音码
		/// </summary>
		private Neusoft.HISFC.Models.Base.Spell regularSpell = new Neusoft.HISFC.Models.Base.Spell();

		/// <summary>
		/// 学名
		/// </summary>
		private string formalName;

		/// <summary>
		/// 学名拼音码
		/// </summary>
		private Neusoft.HISFC.Models.Base.Spell formalSpell = new Neusoft.HISFC.Models.Base.Spell();

		/// <summary>
		/// 别名
		/// </summary>
		private string otherName;

		/// <summary>
		/// 学名拼音码
		/// </summary>
		private Neusoft.HISFC.Models.Base.Spell otherSpell = new Neusoft.HISFC.Models.Base.Spell();

		/// <summary>
		/// 英文名
		/// </summary>
		private string englishName;

		/// <summary>
		/// 英文通用名
		/// </summary>
		private string englishRegularName;

		/// <summary>
		/// 英文别名
		/// </summary>
		private string englishOtherName;

		/// <summary>
		/// 国际编码
		/// </summary>
		private string internationalCode;

		/// <summary>
		/// 国家编码
		/// </summary>
		private string gbCode;

		#endregion

		/// <summary>
		/// 通用名
		/// </summary>		
		public string RegularName
		{
			get
			{
				return this.regularName;
			}
			set
			{
				this.regularName = value;
			}
		}


		/// <summary>
		/// 通用名输入码
		/// </summary>
		public Neusoft.HISFC.Models.Base.Spell RegularSpell
		{
			get
			{
				return this.regularSpell;
			}
			set
			{
				this.regularSpell = value;
			}
		}
		

		/// <summary>
		/// 学名
		/// </summary>
		public string FormalName
		{
			get
			{
				return this.formalName;
			}
			set
			{
				this.formalName = value;
			}
		}


		/// <summary>
		/// 学名输入码
		/// </summary>
		public Neusoft.HISFC.Models.Base.Spell FormalSpell
		{
			get
			{
				return this.formalSpell;
			}
			set
			{
				this.formalSpell = value;
			}
		}
		

		/// <summary>
		/// 别名
		/// </summary>
		public string OtherName
		{
			get
			{
				return this.otherName;
			}
			set
			{
				this.otherName = value;
			}
		}
		

		/// <summary>
		/// 别名输入码
		/// </summary>
		public Neusoft.HISFC.Models.Base.Spell OtherSpell
		{
			get
			{
				return this.otherSpell;
			}
			set
			{
				this.otherSpell = value;
			}
		}
		

		/// <summary>
		/// 英文名
		/// </summary>
		public string EnglishName
		{
			get
			{
				return this.englishName;
			}
			set
			{
				this.englishName = value;
			}
		}
		

		/// <summary>
		/// 英文通用名
		/// </summary>
		public string EnglishRegularName
		{
			get
			{
				return this.englishRegularName;
			}
			set
			{
				this.englishRegularName = value;
			}
		}


		/// <summary>
		/// 英文别名
		/// </summary>
		public string EnglishOtherName
		{
			get
			{
				return this.englishOtherName;
			}
			set
			{
				this.englishOtherName = value;
			}
		}
		

		/// <summary>
		/// 国际编码
		/// </summary>
		public string InternationalCode
		{
			get
			{
				return this.internationalCode;
			}
			set
			{
				this.internationalCode = value;
			}
		}
		

		/// <summary>
		/// 国家编码
		/// </summary>
		public string GbCode
		{
			get
			{
				return this.gbCode;
			}
			set
			{
				this.gbCode = value;
			}
		}


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new NameService Clone()
		{
			NameService nameS = base.Clone() as NameService;

			nameS.RegularSpell = this.RegularSpell.Clone();
			nameS.FormalSpell = this.FormalSpell.Clone();
			nameS.OtherSpell = this.OtherSpell.Clone();

			return nameS;
		}
	}
}
