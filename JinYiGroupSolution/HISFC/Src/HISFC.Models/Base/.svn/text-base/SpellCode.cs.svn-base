using System;

using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Base
{
    /*----------------------------------------------------------------
    // Copyright (C) 2004 东软股份有限公司
    // 版权所有。 
    //
    // 文件名：SpellCode.cs
    // 文件功能描述：拼音码实体
    //
    // 
    // 创建标识:李云凡 20050614
    //
    // 修改标识：周雪松 20060420
    // 修改描述：整理一下代码,终于逮到你了的下画线了，可是不敢改
    //
    // 修改标识：
    // 修改描述：
    //----------------------------------------------------------------*/
	public class SpellCode:Neusoft.NFC.Object.NeuObject,ISpellCode
	{	
		/// <summary>
		/// 输入编码类
		/// </summary>
		public SpellCode()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 拼音码
		/// </summary>
		protected string sSpell_Code;
		/// <summary>
		/// 五笔码
		/// </summary>
		protected string sWB_Code;
		/// <summary>
		/// 自定义码
		/// </summary>
		protected string sUser_Code;

		public new SpellCode Clone()
		{
			return this.MemberwiseClone() as SpellCode;
		}
		#region ISpellCode 成员

		public string Spell_Code
		{
			get
			{
				// TODO:  添加 SpellCode.Spell_Code getter 实现
				return this.sSpell_Code ;
			}
			set
			{
				// TODO:  添加 SpellCode.Spell_Code setter 实现
				this.sSpell_Code=value;
			}
		}

		public string WB_Code
		{
			get
			{
				// TODO:  添加 SpellCode.WB_Code getter 实现
				return this.sWB_Code ;
			}
			set
			{
				// TODO:  添加 SpellCode.WB_Code setter 实现
				this.sWB_Code=value;
			}
		}

		public string User_Code
		{
			get
			{
				// TODO:  添加 SpellCode.User_Code getter 实现
				return this.sUser_Code ;
			}
			set
			{
				// TODO:  添加 SpellCode.User_Code setter 实现
				this.sUser_Code =value;
			}
		}

		#endregion
	}
}
