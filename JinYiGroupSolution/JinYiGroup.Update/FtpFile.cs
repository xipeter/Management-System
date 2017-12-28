using System;

namespace AutoUpdate
{
	/// <summary>
	/// FtpFile 的摘要说明。
	/// </summary>
	public class FtpFile
	{
		public FtpFile()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public string PrimaryID;// 主键列         
		public string FileName;	//文件名         
		public string LocalDirectory; //客户端相对目录 
		public byte []FileContent;	//文件内容       
		public string FileVersion;	// 版本号         
		public string OperCode;		//操作员         
		public System.DateTime OperDate;//操作日期    
	}
	public enum EditType
	{
		None,
		Modify,
		Add,
		Delete
	}
}
