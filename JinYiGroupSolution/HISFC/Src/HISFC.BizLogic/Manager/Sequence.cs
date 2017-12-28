using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Sequence 的摘要说明。
	/// </summary>
	public class Sequence:Neusoft.FrameWork.Management.Database
	{
		public Sequence()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public ArrayList GetList()
		{
			string sqlSelect ="";
			if(this.Sql.GetSql("Manager.Sequence.Get",ref sqlSelect)==-1) return null;
			return this.myGetSequence(sqlSelect);
		}
		/// <summary>
		/// 获得当前序列号
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int GetCurrentSequenceNo(Neusoft.HISFC.Models.Base.Sequence info)
		{
			#region 接口
			#endregion
			string sqlSelect="",sqlWhere="",sql="";
			if(this.Sql.GetSql("Manager.Sequence.Get",ref sqlSelect)==-1) return -1;
			if(this.Sql.GetSql("Manager.Sequence.Where.1",ref sqlWhere)==-1) return -1;
			sql = sqlSelect +" "+sqlWhere;
			try
			{
				sql=string.Format(sql,info.ID,info.Name,System.Convert.ToInt16(info.Type).ToString(),info.MinValue,info.CurrentValue,
					info.Rule,info.SortID,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecQuery(sql)==-1) return -1;
			
			if(this.Reader.Read())
			{
				info.ID = this.Reader[0].ToString();
				info.Name = this.Reader[1].ToString();
				try
				{
					info.Type = (Neusoft.HISFC.Models.Base.Sequence.enuType)this.Reader[2];
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.WriteErr();
				}
				info.MinValue  = this.Reader[3].ToString();
				info.CurrentValue = this.Reader[4].ToString();
				info.Rule  = this.Reader[5].ToString();
				return 0;
			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// 更新序列号
		/// </summary>
		/// <returns></returns>
		public int UpdateSequenceNo(Neusoft.HISFC.Models.Base.Sequence info)
		{
			string sql = "";
			if(this.Sql.GetSql("Manager.Sequence.Update.1",ref sql)==-1) return -1;
			try
			{
				sql=string.Format(sql,info.ID,info.Name,System.Convert.ToInt16(info.Type).ToString(),info.MinValue,info.CurrentValue,
					info.Rule,info.SortID,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			int i =this.ExecNoQuery(sql);
			if(i==0)
			{
				this.Err="未找到行！";
				return -1;
			}
			else if(i<=-1)
			{
				this.Err = "错误!";
			}
			else
			{
				return 0;
			}
			return -1;
		}
		private ArrayList myGetSequence(string sql)
		{
			ArrayList al = new ArrayList();
			if(this.ExecQuery(sql)==-1) return null;
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.Sequence info = new Neusoft.HISFC.Models.Base.Sequence();
				info.ID = this.Reader[0].ToString();
				info.Name = this.Reader[1].ToString();
				try
				{
					info.Type = (Neusoft.HISFC.Models.Base.Sequence.enuType)this.Reader[2];
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.WriteErr();
				}
				info.MinValue  = this.Reader[3].ToString();
				info.CurrentValue = this.Reader[4].ToString();
				info.Rule  = this.Reader[5].ToString();
				al.Add(info);
			}
			return al;
		}
	}
}
