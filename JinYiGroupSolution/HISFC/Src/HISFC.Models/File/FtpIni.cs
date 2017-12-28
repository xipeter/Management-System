using System;

namespace Neusoft.HISFC.Models.File
{
	/// <summary>
	/// Ftpini 的摘要说明。
	/// </summary>
    [System.Serializable]
    public class Ftpini : Neusoft.FrameWork.Models.NeuObject, IFTP
	{
        public Ftpini()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//		FTP_ADDRESS         VARCHAR2(20)                   FTP地址          
		//		FTP_USERNAME        VARCHAR2(20)  Y                FTP用户名        
		//		FTP_PASSWORD        VARCHAR2(20)  Y                FTP口令          
		//		FTP_REMOTEDIRECTORY VARCHAR2(100) Y                FTP远程目录      
		//		CLIENT_IPBEGIN      VARCHAR2(20)           'ALL'   客户端开始IP地址 
		//		CLIENT_IPEND        VARCHAR2(20)           'ALL'   客户端结束IP地址 
		//		OPER_CODE           VARCHAR2(6)                    操作员           
		//		OPER_DATE           DATE                           操作时间  

		public string FtpAddress;
		public string FtpUserName;
		public string FtpPassWord;
		public string FtpRemoteDirectory;
		public string FtpClientBegin;
		public string FtpClientEnd;
		public System.DateTime OperDate;
		#region IFTP 成员

		public string IP
		{
			get
			{
				// TODO:  添加 Ftpini.IP getter 实现
				return this.FtpAddress;
			}
			set
			{
				// TODO:  添加 Ftpini.IP setter 实现
			}
		}

		public string UserName
		{
			get
			{
				// TODO:  添加 Ftpini.UserName getter 实现
				return this.FtpUserName;
			}
			set
			{
				// TODO:  添加 Ftpini.UserName setter 实现
			}
		}

		public string PassWord
		{
			get
			{
				// TODO:  添加 Ftpini.PassWord getter 实现
				return this.FtpPassWord;
			}
			set
			{
				// TODO:  添加 Ftpini.PassWord setter 实现
			}
		}

		protected string folders;
		protected string filename;
		public string Folders
		{
			get
			{
				// TODO:  添加 Ftpini.Folders getter 实现
				return this.folders;
			}
			set
			{
				// TODO:  添加 Ftpini.Folders setter 实现
				this.folders = value;
			}
		}

		public string FileName
		{
			get
			{
				// TODO:  添加 Ftpini.FileName getter 实现
				return this.filename;
			}
			set
			{
				// TODO:  添加 Ftpini.FileName setter 实现
				this.filename = value;
			}
		}

		public string Root
		{
			get
			{
				// TODO:  添加 Ftpini.Root getter 实现
				return this.FtpRemoteDirectory;
			}
			set
			{
				// TODO:  添加 Ftpini.Root setter 实现
			}
		}

		#endregion
	}
}
