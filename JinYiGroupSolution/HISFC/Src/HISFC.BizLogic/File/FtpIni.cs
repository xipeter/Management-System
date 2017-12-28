using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.File
{
	/// <summary>
	/// FtpIni 的摘要说明。
	/// </summary>
	public class FtpIni :Neusoft.FrameWork.Management.Database
	{
		public FtpIni()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public ArrayList GetAllFtpIni()
		{
			Neusoft.HISFC.Models.File.Ftpini info ;
			System.Collections.ArrayList list = new ArrayList();
			string strSql = "";
			//select FTP_ADDRESS  ,FTP_USERNAME,FTP_PASSWORD,FTP_REMOTEDIRECTORY,CLIENT_IPBEGIN,CLIENT_IPEND ,OPER_CODE from com_ftpini 
			if (this.Sql.GetSql("Management.File.GetAllFtpFileIni",ref strSql)==-1)return null;
			try
			{
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.File.Ftpini();
					try
					{
						info.FtpAddress = Reader[0].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message; 
					}
					try
					{
						info.FtpUserName = Reader[1].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						info.FtpPassWord = Reader[2].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						info.FtpRemoteDirectory  = Reader[3].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						info.FtpClientBegin = Reader[4].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					try
					{
						info.FtpClientEnd = Reader[5].ToString();
					}
					catch(Exception ee)
					{
						string Error = ee.Message;
					}
					if(Reader[6]!=DBNull.Value)
					{
						info.OperDate =Convert.ToDateTime(Reader[6]);
					}
					list.Add(info);
					info = null;
       			}
			}
			catch(Exception ee)
			{
				string Error  = ee.Message;
			    list=null;
			}
			this.Reader.Close();
			return list;

		}
		public int UpdateFtpIni(Neusoft.HISFC.Models.File.Ftpini info)
		{
			string strSql = "";
			//update com_ftpini set FTP_ADDRESS ='{0}',FTP_USERNAME='{1}',FTP_PASSWORD ='{2}',FTP_REMOTEDIRECTORY='{3}',CLIENT_IPBEGIN='{4}',CLIENT_IPEND='{5}'
			if (this.Sql.GetSql("Management.File.UpdateFtpIni",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.FtpAddress,info.FtpUserName,info.FtpPassWord,info.FtpRemoteDirectory,info.FtpClientBegin,info.FtpClientEnd);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		public int DeleteFtpIni(Neusoft.HISFC.Models.File.Ftpini info)
		{
			string strSql = "";
			//delete com_ftpini where FTP_ADDRESS ='{0}',FTP_REMOTEDIRECTORY='{1}',CLIENT_IPBEGIN='{2}'
			if (this.Sql.GetSql("Management.File.DeleteFtpIni",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.FtpAddress,info.FtpClientBegin,info.FtpClientEnd);
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
		public int InsertFtpIni(Neusoft.HISFC.Models.File.Ftpini info)
		{
			string strSql = "";
			//insert com_ftpini (FTP_ADDRESS,FTP_USERNAME ,FTP_PASSWORD ,FTP_REMOTEDIRECTORY,CLIENT_IPBEGIN ,CLIENT_IPEND,OPER_CODE,OPER_DATE) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',sysdate)
			if (this.Sql.GetSql("Management.File.InsertFtpIni",ref strSql)==-1)return -1;
			try
			{
				string Opercode = this.Operator.ID;
				strSql = string.Format(strSql,info.FtpAddress,info.FtpUserName,info.FtpPassWord,info.FtpRemoteDirectory,info.FtpClientBegin,info.FtpClientEnd,Opercode );
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}
	}
}
