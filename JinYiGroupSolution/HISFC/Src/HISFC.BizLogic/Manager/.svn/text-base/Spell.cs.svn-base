using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Spell 的摘要说明。
	/// 拼音管理类
	/// </summary>
	public class Spell:Neusoft.FrameWork.Management.Database
	{
		public Spell()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获得字符串
		/// </summary>
		/// <param name="Words"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.ISpell Get(string Words)
		{
			Neusoft.HISFC.Models.Base.Spell spell=new Neusoft.HISFC.Models.Base.Spell();
			string strSql = "",strExeSql="";
			if(this.Sql.GetSql("Manager.Spell.GetSpellCode",ref strSql)==-1) return null;
			strExeSql =  strSql;
			for(int i=0;i<Words.Length;i++)
			{
				string word=Words.Substring(i,1);
                //strExeSql = string.Format(strSql,word);
                if (this.ExecQuery(strExeSql, word) == -1) return null;
				
					try
					{
						this.Reader.Read();
						spell.SpellCode = spell.SpellCode +this.Reader[0].ToString();
						spell.WBCode = spell.WBCode + this.Reader[1].ToString();
					}
					catch{}
				
			}
			return spell;
		}
		/// <summary>
		/// 根据拼音码获取同音的字  返回 Neusoft.HISFC.Models.Base.SpellCode类型实体，Name存储汉字
		/// </summary>
		/// <param name="SpellCode">拼音码</param>
		/// <returns>出错返回null </returns>
		public ArrayList  GetWord(string SpellCode)
		{
			try
			{
				ArrayList list = new ArrayList(); 
				Neusoft.HISFC.Models.Base.Spell spell = null;
				string strSql = "";
				if(this.Sql.GetSql("Manager.Spell.GetWord",ref strSql)==-1) return null;
                //strSql = string.Format(strSql,SpellCode);
                if (this.ExecQuery(strSql, SpellCode) == -1) return null;
				while(this.Reader.Read())
				{
					spell=new Neusoft.HISFC.Models.Base.Spell();
					spell.Name = this.Reader[0].ToString();
					list.Add(spell); //
				}
				Reader.Close();
				return list;
			}
			catch(Exception ex)
			{
				if(!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}
				this.Err = ex.Message;
				return null;
			}
		}
		/// <summary>
		/// 取一个汉字的拼音码（全拼） 
		/// </summary>
		/// <param name="word">一个汉字</param>
		/// <returns>null 程序错误 </returns>
		public string GetSpellCode(string word)
		{
			try
			{
				string SpellCode = "";
				string strSql = "";
				if(this.Sql.GetSql("Manager.Spell.GetSpellCode.2",ref strSql)==-1) return null;
                //strSql = string.Format(strSql,word);
                if (this.ExecQuery(strSql, word) == -1) return null;
				while(this.Reader.Read())
				{
					SpellCode = this.Reader[0].ToString(); //拼音全码  
				}
				Reader.Close();
				if(SpellCode == "")
				{
					SpellCode = word;
				}
				return SpellCode; //返回
			}
			catch(Exception ex)
			{
				if(!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}
				this.Err = ex.Message;
				return null;
			}
		}
	}
}
