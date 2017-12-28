using System;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// QueryCondition 的摘要说明。
	/// 查询条件 保存类 对应表COM_QUERY_CONDITION
	/// </summary>
	public class QueryCondition:Neusoft.FrameWork.Management.Database
	{
		public QueryCondition()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 获得查询条件
		/// </summary>
		/// <returns></returns>
		public string GetQueryCondtion(string formName,bool isDefault)
		{
			string sql1 ="Manager.QueryCondition.Get.1";
			string sql2 ="Manager.QueryCondition.Get.2";
			string sql = "";
			
			if(isDefault)//默认的配置
			{
				if(this.Sql.GetSql(sql2,ref sql)==-1) return "-1";
				if(this.ExecQuery(sql,formName,"")==-1) return  "-1";
			}
			else //个人配置
			{
				if(this.Sql.GetSql(sql1,ref sql)==-1) return "-1";
				if(this.ExecQuery(sql,formName,this.Operator.ID)==-1) return  "-1";
			}
			if(this.Reader.Read())
			{
				return this.Reader[0].ToString();
			}
			else
			{
				return "";
			}
			
		}

		/// <summary>
		/// 获得查询条件
		/// </summary>
		/// <param name="formName"></param>
		/// <returns></returns>
		public string GetQueryCondtion(string formName)
		{
			return GetQueryCondtion(formName,false);
		}
		/// <summary>
		/// 设置查询条件
		/// </summary>
		/// <param name="formName"></param>
		/// <param name="xml"></param>
		/// <param name="isDefault"></param>
		/// <returns></returns>
		public int SetQueryCondition(string formName,string xml,bool isDefault)
		{
			string s = this.GetQueryCondtion(formName,isDefault);
			if(s == "-1") return -1;
			if(s =="") //insert
			{
				return this._InsertQueryCondtion(formName,xml,isDefault);
			}
			else //update
			{
				return this._UpdateQueryCondition(formName,xml,isDefault);
			}
		}
		/// <summary>
		/// 设置查询条件
		/// </summary>
		/// <param name="formName"></param>
		/// <returns></returns>
		public int SetQueryCondition(string formName,string xml)
		{
			return SetQueryCondition(formName,xml,false);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="formName"></param>
		/// <param name="xml"></param>
		/// <param name="isDefault"></param>
		/// <returns></returns>
		protected int _InsertQueryCondtion(string formName,string xml,bool isDefault)
		{
			string sql = "Manager.QueryCondition.Insert";
			if(this.Sql.GetSql(sql,ref sql) == -1) return -1;
			if(isDefault)
			{
				return this.ExecNoQuery(sql,formName,"",xml);
			}
			else
			{
				return this.ExecNoQuery(sql,formName,this.Operator.ID,xml);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="formName"></param>
		/// <param name="xml"></param>
		/// <param name="isDefault"></param>
		/// <returns></returns>
		protected int _UpdateQueryCondition(string formName,string xml,bool isDefault)
		{
			string sql = "Manager.QueryCondition.Update";
			if(this.Sql.GetSql(sql,ref sql) == -1) return -1;
			if(isDefault)
			{
				return this.ExecNoQuery(sql,formName,"",xml);
			}
			else
			{
				return this.ExecNoQuery(sql,formName,this.Operator.ID,xml);
			}
		}
	}
}
