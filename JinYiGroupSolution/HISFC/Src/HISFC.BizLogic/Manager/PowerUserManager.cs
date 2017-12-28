using System;
using System.Collections;


using neusoft.neuFC.Object;
using neusoft.HISFC.Object;
 

namespace neusoft.HISFC.Management.Manager
{

	/// <summary>
	/// 
	/// </summary>
	public class PowerUserManager : neusoft.neuFC.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public PowerUserManager()
		{
		}
			
			
		public bool UserHasPower(string userCode , string level2Code, string level3Code)
		{

			return true;
		}
			


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ArrayList SelectByPrimaryKey(string id0)
		{
			ArrayList users = new ArrayList();
			 
			return users;
		}
		
		public ArrayList LoadAllUsers()
		{
			string strSql = string.Empty ;
			ArrayList users = new ArrayList();
			if (this.Sql.GetSql("Manager.PowerUserManager.LoadAllUsers",ref strSql)==-1) return users;
			try
			{
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					neusoft.HISFC.Object.Power.PowerUser user = new neusoft.HISFC.Object.Power.PowerUser();
					user.ID = this.Reader[0].ToString();

					users.Add(user);
				}
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				users.Clear(); 
			}

			return users;
			
		}
		

		
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="info"></param>
//		/// <returns></returns>
//		public int InsertPowerUser(UserPowerDetail info)
//		{
//			string strSql = "";
//			
//			if (this.Sql.GetSql("Manager.PowerUserManagerImpl.InsertPowerUser",ref strSql)==-1) return -1;
//			try
//			{
//				strSql = string.Format(strSql,info.PkId, info.DeptCode, info.UserCode, info.Class1Code, info.Class2Code, info.Class3Code, info.GrantDept, info.GrantEmpl, info.GrantFlag, info.RoleCode, info.Mark, this.Operator.ID,this.GetSysDateTime());
//			}
//			catch(Exception ex)
//			{
//				this.Err=ex.Message;
//				this.ErrCode=ex.Message;
//				return -1;
//			}
//			return this.ExecNoQuery(strSql);
//		}
//		
//		
//		
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="info"></param>
//		/// <returns></returns>
//		public int UpdatePowerUser(UserPowerDetail info)
//		{			
//			string strSql = "";
//			if (this.Sql.GetSql("Manager.PowerUserManagerImpl.UpdatePowerUser",ref strSql)==-1) return -1;
//			
//			try
//			{   				
//				strSql = string.Format(strSql,info.PkId, info.DeptCode, info.UserCode, info.Class1Code, info.Class2Code, info.Class3Code, info.GrantDept, info.GrantEmpl, info.GrantFlag, info.RoleCode, info.Mark,this.Operator.ID);
//
//			}
//			catch(Exception ex)
//			{
//				this.ErrCode=ex.Message;
//				this.Err=ex.Message;
//				return -1;
//			}      			
//
//			try
//			{
//				return this.ExecNoQuery(strSql);
//			}
//			catch(Exception ex)
//			{
//				this.ErrCode=ex.Message;
//				this.Err=ex.Message;
//				return -1;
//			}
//		}
//		
//		
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="info"></param>
//		/// <returns></returns>
//		public int Delete(string pkId)
//		{
//			string strSql = "";
//			if (this.Sql.GetSql("Manager.PowerUserManagerImpl.DeletePowerUser",ref strSql)==-1) return -1;
//				
//			try
//			{   				
//				strSql = string.Format(strSql,pkId);
//
//			}
//			catch(Exception ex)
//			{
//				this.ErrCode=ex.Message;
//				this.Err=ex.Message;
//				return -1;
//			}      			
//
//			try
//			{
//				return this.ExecNoQuery(strSql);
//			}
//			catch(Exception ex)
//			{
//				this.ErrCode=ex.Message;
//				this.Err=ex.Message;
//				return -1;
//			}
//		}
//		
	}
	
}