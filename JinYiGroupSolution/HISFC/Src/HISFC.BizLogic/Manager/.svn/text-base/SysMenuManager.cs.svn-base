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
	public class SysMenuManager : Neusoft.FrameWork.Management.Database
	{

		/// <summary>
		/// 
		/// </summary>
		public SysMenuManager()
		{
		}
		

		/// <summary>
		/// 
		/// </summary>	
		public ArrayList LoadAll(string curgrpCode)
		{
			string sqlstring = PrepareSQL("Manager.SysMenuManager.LoadAll",new string[]{curgrpCode});

			
			ArrayList SysMenus = new ArrayList();
			if(sqlstring == string.Empty)
				return SysMenus;
			try
			{
                if (this.ExecQuery(sqlstring) == -1)
                {
                    return null;
                }
				while(this.Reader.Read())
				{
				
					SysMenu info = PrepareData();					 
					if(info  != null)
						SysMenus.Add(info );
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysMenus.Clear();
			}

			return SysMenus;
		}	




		public ArrayList LoadAllParentMenu(string curgrpCode)
		{
			string sqlstring = PrepareSQL("Manager.SysMenuManager.LoadAllParentMenu",new string[]{curgrpCode});

			
			ArrayList SysMenus = new ArrayList();
			if(sqlstring == string.Empty)
				return SysMenus;
			try
			{
                if (this.ExecQuery(sqlstring) == -1)
                {
                    return null;
                }
				while(this.Reader.Read())
				{
				
					SysMenu info = PrepareData();					 
					if(info  != null)
						SysMenus.Add(info );
				}

			}   
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				
				SysMenus.Clear();
			}

			return SysMenus;
		}	
			
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public SysMenu LoadByPrimaryKey(string curgrpCode,int x,int y)
		{
			string strSql = PrepareSQL("Manager.SysMenuManager.LoadByPrimaryKey",new object[]{curgrpCode,x,y });
			
			 	
			if(strSql == string.Empty)
				return null;
			try
			{
                if (this.ExecQuery(strSql) == -1)
                    return null;
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
		


	 
		private SysMenu PrepareData()
		{
			SysMenu info = new SysMenu();
			info.PargrpCode = this.Reader[0].ToString();
			info.CurgrpCode = this.Reader[1].ToString();
			info.X = FrameWork.Function.NConvert.ToInt32(this.Reader[2]);
			info.Y = FrameWork.Function.NConvert.ToInt32(this.Reader[3]);
			info.MenuName = this.Reader[4].ToString();
			info.ShortCut = this.Reader[5].ToString();
			info.Icon = this.Reader[6].ToString();
			info.Enabled = FrameWork.Function.NConvert.ToBoolean(this.Reader[7]);
			info.SysCode = this.Reader[8].ToString();
			info.MenuWin = this.Reader[9].ToString();
			info.MenuParm = this.Reader[10].ToString();
			info.OwnerFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[11]);
			try
			{
				info.ModelFuntion.WinName = this.Reader[12].ToString() ; 
				info.ModelFuntion.DllName  = this.Reader[13].ToString() ;
				info.ModelFuntion.FormShowType   = this.Reader[14].ToString() ;
				info.ModelFuntion.Param  = this.Reader[15].ToString() ;
				info.ModelFuntion.Memo = this.Reader[16].ToString() ;
                info.ModelFuntion.TreeControl.WinName = this.Reader[18].ToString();
                info.ModelFuntion.TreeControl.DllName = this.Reader[17].ToString();
                info.ModelFuntion.TreeControl.Param = this.Reader[19].ToString();
			}
			catch{}

			info.Name = info.MenuName;
			info.ID = info.SysCode ;
            info.Memo = info.ModelFuntion.Memo;

			return info;
		}
		 
		private string PrepareSQL(string sqlName,params object[] values)
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
		public int InsertSysMenu(SysMenu info)
		{
			string strSql = PrepareSQL("Manager.SysMenuManager.InsertSysMenu",new object[]
			{info.PargrpCode, info.CurgrpCode, info.X, info.Y, info.MenuName, info.ShortCut, info.Icon,
			FrameWork.Function.NConvert.ToInt32(info.Enabled),
			info.SysCode, info.MenuWin, info.MenuParm,  FrameWork.Function.NConvert.ToInt32(info.OwnerFlag), this.Operator.ID }  );
			
			if(strSql == string.Empty)
				return -1;
			return this.ExecNoQuery(strSql);
		}
		
		
		

		
		public int Delete(string groupCode)
		{
			string strSql = PrepareSQL("Manager.SysMenuManager.DeleteByGroupCode",new object[]{groupCode});
			if(strSql == string.Empty)
				return -1;
				  		  			

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

		public int Delete(string groupCode, int x)
		{
			string strSql = PrepareSQL("Manager.SysMenuManager.DeleteByGroupCodeX",new object[]{groupCode,x});
			if(strSql == string.Empty)
				return -1;
				  		  			

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