using System;
using System.Collections;


using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models;

using Neusoft.HISFC.Models.Admin;

namespace Neusoft.HISFC.BizLogic.Manager
{

	/// <summary>
	/// 系统功能维护管理业务模块
	/// </summary>
	public class SysModelFunctionManager : Neusoft.FrameWork.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public SysModelFunctionManager()
		{
		}
		
		/// <summary>
		/// 查询所有
        /// 功能
		/// </summary>	
        public ArrayList QuerySysModelFunction()
		{
			string sqlstring = PrepareSQL("Manager.SysModelFunctionManager.Select",null);

			ArrayList SysModelFunctions = new ArrayList();
			if(sqlstring == string.Empty)
				return SysModelFunctions ;
			try
			{
				this.ExecQuery(sqlstring);
				while(this.Reader.Read())
				{
				
					SysModelFunction info = PrepareData();					 
					if(info  != null)
						SysModelFunctions.Add(info );
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysModelFunctions.Clear();
			}

			return SysModelFunctions;
		}	


		/// <summary>
		/// 查询系统模块-通过系统类别
		/// </summary>
		/// <returns></returns>
        public ArrayList QuerySysModelFunction(string sysCode)
		{
            string sqlSelect = "";
            if (this.Sql.GetSql("Manager.SysModelFunctionManager.Select", ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            string sqlstring = PrepareSQL("Manager.SysModelFunctionManager.Where.BySys", new string[] { sysCode });			
			ArrayList SysModelFunctions = new ArrayList();
			if(sqlstring == string.Empty)
				return SysModelFunctions ;
			try
			{
				this.ExecQuery(sqlSelect + " "+sqlstring);
				while(this.Reader.Read())
				{
				
					SysModelFunction info = PrepareData();					 
					if(info  != null)
						SysModelFunctions.Add(info );
				}
				this.Reader.Close();
			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysModelFunctions.Clear();
			}

			return SysModelFunctions;
		}	

		/// <summary>
		/// 查询系统模块-通过模块类别
		/// </summary>
		/// <returns></returns>
        public ArrayList QuerySysModelFunctionByType(string FormType)
		{
            string sqlSelect = "";
            if (this.Sql.GetSql("Manager.SysModelFunctionManager.Select", ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            string sqlstring = PrepareSQL("Manager.SysModelFunctionManager.Where.ByFormType", new string[] { FormType });

			ArrayList SysModelFunctions = new ArrayList();
			if(sqlstring == string.Empty)
				return SysModelFunctions ;
			try
			{
				this.ExecQuery(sqlSelect +" "+sqlstring);
				while(this.Reader.Read())
				{
				
					SysModelFunction info = PrepareData();					 
					if(info  != null)
						SysModelFunctions.Add(info );
				}
				this.Reader.Close();
			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysModelFunctions.Clear();
			}

			return SysModelFunctions;
		}	
			
		/// <summary>
		/// 查找信息
		/// </summary>
		/// <returns></returns>
        public SysModelFunction QuerySysModelFunctionByID(string id)
		{
			string strSql = "";
            string sqlSelect = "";
            if (this.Sql.GetSql("Manager.SysModelFunctionManager.Select", ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
			if (this.Sql.GetSql("Manager.SysModelFunctionManager.Where.ID",ref strSql)==-1) return null;
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
                this.ExecQuery(sqlSelect +" "+strSql);
                if (this.Reader.Read())
                    return PrepareData();
                else
                    return null;

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
		}
		
        /// <summary>
        /// 私有获得数据给实体
        /// </summary>
        /// <returns></returns>
		protected SysModelFunction PrepareData()
		{
       
			SysModelFunction info = new SysModelFunction();
			info.SysCode = this.Reader[0].ToString();
			info.WinName = this.Reader[1].ToString();
			info.FunName = this.Reader[2].ToString();
			info.Memo = this.Reader[3].ToString();
			info.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());
			info.DllName  = this.Reader[7].ToString();
			info.FormShowType   = this.Reader[8].ToString();
			info.FormType = this.Reader[9].ToString();
            info.TreeControl.DllName = this.Reader[10].ToString();
            info.TreeControl.WinName = this.Reader[11].ToString();
            info.Param = this.Reader[12].ToString();
            info.TreeControl.Param = this.Reader[13].ToString();
            info.ID = this.Reader[14].ToString();
			return info;
		}
		 
        /// <summary>
        /// 格式化Sql
        /// </summary>
        /// <param name="sqlName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
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
		public int InsertSysModelFunction(SysModelFunction info)
		{
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.SysModelFunctionManager.Insert",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,
                    	info.SysCode,//0
                        info.WinName,//1
                        info.FunName,//2
                        info.Memo,//3
                        info.SortID,//4
                        this.Operator.ID,
                        "",//操作时间
                        info.DllName,//7
                        info.FormShowType,//8
                        info.FormType,//9
                        info.TreeControl.DllName,//10
                        info.TreeControl.WinName,//11
                        info.Param,//12
                        info.TreeControl.Param ,//13
                        info.ID);//14
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
		public int UpdateSysModelFunction(SysModelFunction info)
		{			
			string strSql = "";
			if (this.Sql.GetSql("Manager.SysModelFunctionManager.Update",ref strSql)==-1) return -1;
			
			try
			{
                strSql = string.Format(strSql,
                        info.SysCode,//0
                        info.WinName,//1
                        info.FunName,//2
                        info.Memo,//3
                        info.SortID,//4
                        this.Operator.ID,
                        "",//操作时间
                        info.DllName,//7
                        info.FormShowType,//8
                        info.FormType,//9
                        info.TreeControl.DllName,//10
                        info.TreeControl.WinName,//11
                        info.Param,//12
                        info.TreeControl.Param,//13
                        info.ID);//14
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
		/// <param name="info"></param>
		/// <returns></returns>
        public int DeleteSysModelFunction(SysModelFunction info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Manager.SysModelFunctionManager.Delete",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql,info.ID);

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
        /// 获得新ID
        /// </summary>
        /// <returns></returns>
        public string GetNewID()
        {
            string sql = "";
            if (this.Sql.GetSql("Manager.SysModelFunctionManager.GetMaxID", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return "";
            }
            return this.ExecSqlReturnOne(sql);
        }
		
	}
	
}