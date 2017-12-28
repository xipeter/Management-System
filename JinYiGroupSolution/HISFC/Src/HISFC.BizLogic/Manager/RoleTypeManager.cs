using System;
using System.Collections;


using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models;

using Neusoft.HISFC.Models.Admin;

namespace Neusoft.HISFC.BizLogic.Manager
{

	/// <summary>
	/// 
	/// </summary>
	public class RoleTypeManager : Neusoft.FrameWork.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public RoleTypeManager()
		{
		}
			
		 
			
		public ArrayList LoadAll()
		{
			string sqlstring = PrepareSQL("Manager.RoleTypeManager.LoadAll",null);

			if(sqlstring == string.Empty)
				return null;
			ArrayList roleTypes = new ArrayList();
			try
			{
				this.ExecQuery(sqlstring);
				while(this.Reader.Read())
				{
					RoleType roleType = PrepareData();
					 
 				   if(roleType != null)
					   roleTypes.Add(roleType);
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				roleTypes.Clear();
			}

			return roleTypes;
		}
			
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public RoleType LoadByPrimaryKey(string id0)
		{

			string sqlstring = PrepareSQL("Manager.RoleTypeManager.LoadByPrimaryKey",id0);

			if(sqlstring == string.Empty)
				return null;
			try
			{
				this.ExecQuery(sqlstring);
				if(this.Reader.Read())
					return PrepareData();		
				else
					return null;

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null; 
			}

			
		}
		
		 
		private RoleType PrepareData()
		{
			RoleType roleType = new RoleType();
			roleType.TypeCode = this.Reader[0].ToString();
			roleType.TypeName = this.Reader[1].ToString();
			roleType.TypeMeanint = this.Reader[2].ToString();
			roleType.Mark = this.Reader[3].ToString();
			roleType.ID = roleType.TypeCode;
			roleType.Name = roleType.TypeName;

			return roleType;
		}
		

		private string PrepareSQL(string sqlName,params string[] values)
		{
			string strSql = string.Empty;
			if (this.Sql.GetSql(sqlName,ref  strSql) == 0 )
			{
				try
				{
					if(values != null)
						strSql= string.Format(strSql,values);
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					strSql = string.Empty;
				}
			}
			return strSql;
		}

		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertRoleType(RoleType info)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.RoleTypeManager.InsertRoleType",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,info.TypeName, info.TypeMeanint, this.Operator.ID,this.Operator.Name, info.Mark);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateRoleType(RoleType info)
		{			
			string strSql = "";
			if (this.Sql.GetSql("Manager.RoleTypeManager.UpdateRoleType",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.TypeCode, info.TypeName, info.TypeMeanint,this.Operator.ID,this.Operator.Name, info.Mark);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}
		
		public int Delete(RoleType info)
		{
			return Delete(info.TypeCode);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="roleTypeCode"></param>
		/// <returns></returns>
		public int Delete(string roleTypeCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("Manager.RoleTypeManager.DeleteRoleType",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql,roleTypeCode);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}
		
	}
	
}