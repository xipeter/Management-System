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
	public class SysModelManager : Neusoft.FrameWork.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public SysModelManager()
		{
		}
		

		/// <summary>
		/// 
		/// </summary>	
		public ArrayList LoadAll()
		{
			string sqlstring = PrepareSQL("Manager.SysModelManager.LoadAll",null);

			
			ArrayList SysModels = new ArrayList();
			if(sqlstring == string.Empty)
				return SysModels ;
			try
			{
				this.ExecQuery(sqlstring);
				while(this.Reader.Read())
				{
				
					SysModel info = PrepareData();					 
					if(info  != null)
						SysModels.Add(info );
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysModels.Clear();
			}

			return SysModels;
		}	
			
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public SysModel LoadByPrimaryKey(string id0)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.SysModelManager.LoadByPrimaryKey",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,id0);
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
		
		private SysModel PrepareData()
		{
			SysModel info = new SysModel();
			info.SysCode = this.Reader[0].ToString();
			info.SysName = this.Reader[1].ToString();
			info.SortId = FrameWork.Function.NConvert.ToInt32(this.Reader[2]);
		 

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
		public int InsertSysModel(SysModel info)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.SysModelManager.InsertSysModel",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,info.SysCode, info.SysName, info.SortId, this.Operator.ID);
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
		public int UpdateSysModel(SysModel info)
		{			
			string strSql = "";
			if (this.Sql.GetSql("Manager.SysModelManager.UpdateSysModel",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.SysCode, info.SysName, info.SortId,this.Operator.ID);

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
		
	 
		public int Delete(SysModel info)
		{
			return Delete(info.SysCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sysCode"></param>
		/// <returns></returns>
		public int Delete(string sysCode)
		{


			string deleteQuery = string.Empty;
			if (this.Sql.GetSql("Manager.SysModelManager.DeleteQuery",ref deleteQuery)==-1) return -1;
			try
			{
				deleteQuery = string.Format(deleteQuery,sysCode);
				this.ExecQuery(deleteQuery);

			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				return -1;
			}
			


			string strSql = "";
			if (this.Sql.GetSql("Manager.SysModelManager.DeleteSysModel",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql,sysCode);   
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