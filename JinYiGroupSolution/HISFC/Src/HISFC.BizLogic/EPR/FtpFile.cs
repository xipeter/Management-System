using System;
using System.Collections;
namespace Neusoft.HISFC.Management.File
{
	/// <summary>
	/// FtpFile 的摘要说明。
	/// </summary>
	public class FtpFile:Neusoft.FrameWork.Management.Database
	{
		public FtpFile()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public ArrayList  GetAllFtpFileInfo()
		{
			Neusoft.HISFC.Models.File.FtpFile  file; 
			ArrayList  list = new ArrayList();
			string strSql = "";
			//select FILE_NAME,UPDATE_FLAG,FILE_VERSION,LOCAL_DIRECTORY,OPER_DATE   from com_ftpfile
			if (this.Sql.GetSql("Management.File.GetAllFtpFileInfo",ref strSql)==-1)return null;
			try
			{
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					file  = new Neusoft.HISFC.Models.File.FtpFile();
					try
					{
						file.Name = this.Reader[0].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						file.UpdateFlag = Reader[1].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						file.FileVersion = Reader[2].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						file.LocalDirectory = Reader[3].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					if(Reader[4]!=DBNull.Value)
					{
						file.UpdateDate =Convert.ToDateTime(Reader[4]);
					}
					list.Add(file);
					file= null;
				}
			}
			catch(Exception ee)
			{
				this.Reader.Close();
				string Error = ee.Message;
				list = null;
			}
			this.Reader.Close();
			return list;
		}
		public int UpdateFtpFileInfo(Neusoft.HISFC.Models.File.FtpFile info )
		{
			string strSql = "";
			//update com_ftpfile set FILE_NAME = '{0}',UPDATE_FLAG='{1}',FILE_VERSION='{2}',LOCAL_DIRECTORY='{3}' 
			if (this.Sql.GetSql("Management.File.UpdateFtpFileInfo",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.Name,info.UpdateFlag,info.FileVersion,info.LocalDirectory,this.Operator.ID,info.UpdateDate);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		public int DeleteFtpFileInfo(Neusoft.HISFC.Models.File.FtpFile info)
		{
			//delete com_ftpfile where FILE_NAME='{0}',FILE_VERSION ='{1}'
			string strSql = "";
			if (this.Sql.GetSql("Management.File.DeleteFtpFileInfo",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.Name,info.FileVersion);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}

		public int InsertFtpFileInfo(Neusoft.HISFC.Models.File.FtpFile info)
		{
			string strSql = "";
			string  OPER_CODE = Operator.ID;
			//insert into com_ftpfile (FILE_NAME,UPDATE_FLAG ,FILE_VERSION,LOCAL_DIRECTORY,OPER_CODE,OPER_DATE)values('{0}','{1}','{2}','{3}','{4}',sysdate)
			if (this.Sql.GetSql("Management.File.InsertFtpFileInfo",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.Name,info.UpdateFlag,info.FileVersion,info.LocalDirectory,OPER_CODE);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 统一设定更新的时间
		/// </summary>
		/// <returns></returns>
		public int SetUpdateTime()
		{
			string strSql = "";
			//update com_ftpfile set OPER_DATE = sysdate  
			if (this.Sql.GetSql("Management.File.SetUpdateTime",ref strSql)==-1)return -1;
			return this.ExecNoQuery(strSql);
		}
	}
}
