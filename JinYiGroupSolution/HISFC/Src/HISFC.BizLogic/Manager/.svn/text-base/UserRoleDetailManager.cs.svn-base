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
	public class UserRoleDetailManager : Neusoft.FrameWork.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public UserRoleDetailManager()
		{
		}
		

		/// <summary>
		/// 
		/// </summary>	
		public ArrayList LoadAll()
		{
			string sqlstring = PrepareSQL("Manager.UserRoleDetailManager.LoadAll",null);

			
			ArrayList UserRoleDetails = new ArrayList();
			if(sqlstring == string.Empty)
				return UserRoleDetails ;
			try
			{
				this.ExecQuery(sqlstring);
				while(this.Reader.Read())
				{
				
					UserRoleDetail info = PrepareData();					 
					if(info  != null)
						UserRoleDetails.Add(info );
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				UserRoleDetails.Clear();
			}

			return UserRoleDetails;
		}	


		/// <summary>
		/// 
		/// </summary>	
		public ArrayList LoadByUserCode(string userCode)
		{
			string sqlstring = PrepareSQL("Manager.UserRoleDetailManager.LoadByUserCode",new string[]{userCode});

			
			ArrayList UserRoleDetails = new ArrayList();
			if(sqlstring == string.Empty)
				return UserRoleDetails ;
			PowerRoleManager roleMgr = new PowerRoleManager();

			try
			{
				this.ExecQuery(sqlstring);
				while(this.Reader.Read())
				{
				
					UserRoleDetail info = PrepareData();					 
					if(info  != null)
					{
						info.Role = roleMgr.Load(info.RoleCode);
						UserRoleDetails.Add(info );
					}
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				UserRoleDetails.Clear();
			}

			return UserRoleDetails;
		}	

			
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public UserRoleDetail LoadByPrimaryKey(string id)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.UserRoleDetailManager.LoadByPrimaryKey",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,id);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null; 
			}
			try
			{
				this.ExecQuery(strSql);
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
		
		private UserRoleDetail PrepareData()
		{
			UserRoleDetail info = new UserRoleDetail();
			info.PkID = this.Reader[0].ToString();
			info.DeptCode = this.Reader[1].ToString();
			info.UserCode = this.Reader[2].ToString();
			info.RoleCode = this.Reader[3].ToString();
			info.GrantDept = this.Reader[4].ToString();
			info.GrantEmpl = this.Reader[5].ToString();
			info.GrantFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
			info.Mark = this.Reader[7].ToString();
			
			

			return info;
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
		public int InsertUserRoleDetail(UserRoleDetail info)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.UserRoleDetailManager.InsertUserRoleDetail",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql, info.DeptCode, info.UserCode, info.RoleCode, info.GrantDept, info.GrantEmpl, FrameWork.Function.NConvert.ToInt32(info.GrantFlag), this.Operator.ID,  info.Mark);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
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
		
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateUserRoleDetail(UserRoleDetail info)
		{			
			string strSql = "";
			if (this.Sql.GetSql("Manager.UserRoleDetailManager.UpdateUserRoleDetail",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.PkID, info.DeptCode, info.UserCode, info.RoleCode, info.GrantDept, info.GrantEmpl, FrameWork.Function.NConvert.ToInt32(info.GrantFlag),this.Operator.ID, info.Mark);

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
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pkId"></param>
		/// <returns></returns>
		public int Delete(string pkId)
		{
			string strSql = "";
			if (this.Sql.GetSql("Manager.UserRoleDetailManager.DeleteUserRoleDetail",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql,pkId);

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


		public int DeleteUserRoleDetail(string roleCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("Manager.UserRoleDetailManager.DeleteByRoleCode",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql,roleCode);

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