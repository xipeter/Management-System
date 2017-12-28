using System;

namespace Neusoft.HISFC.Models.File
{
	/// <summary>
	/// 数据文件参数类 的摘要说明。
	/// ID = param名
	/// Name = 数据表名
	/// </summary>
    [System.Serializable]
    public class DataFileParam : Neusoft.FrameWork.Models.NeuObject, IFTP
	{
		public DataFileParam()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Type;
		/// <summary>
		/// 是否存数据库
		/// </summary>
		public bool IsInDB=false;
		/// <summary>
		/// 模板文件夹
		/// </summary>
		public string ModualFolders;
		/// <summary>
		/// 头
		/// </summary>
		public string Http;
		#region IFTP 成员
		protected string ip;
		/// <summary>
		/// ip
		/// </summary>
		public string IP
		{
			get
			{
				// TODO:  添加 DataFileParam.IP getter 实现
				return this.ip;
			}
			set
			{
				// TODO:  添加 DataFileParam.IP setter 实现
				this.ip=value;
			}
		}
		protected string username;
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			get
			{
				// TODO:  添加 DataFileParam.UserName getter 实现
				return this.username ;
			}
			set
			{
				// TODO:  添加 DataFileParam.UserName setter 实现
				this.username=value;
			}
		}
		protected string password;
		/// <summary>
		/// 密码
		/// </summary>
		public string PassWord
		{
			get
			{
				// TODO:  添加 DataFileParam.PassWord getter 实现
				return this.password;
			}
			set
			{
				// TODO:  添加 DataFileParam.PassWord setter 实现
				this.password=value;
			}
		}
		protected string folders;
		/// <summary>
		/// 远程文件夹
		/// </summary>
		public string Folders
		{
			get
			{
				// TODO:  添加 DataFileParam.Folders getter 实现
				return this.folders;
			}
			set
			{
				// TODO:  添加 DataFileParam.Folders setter 实现
				this.folders=value;
			}
		}
		protected string filename;
		/// <summary>
		/// 文件名
		/// </summary>
		public string FileName
		{
			get
			{
				// TODO:  添加 DataFileParam.FileName getter 实现
				return this.filename;
			}
			set
			{
				// TODO:  添加 DataFileParam.FileName setter 实现
				this.filename=value;
			}
		}
		protected string root;
		/// <summary>
		/// 根
		/// </summary>
		public string Root
		{
			get
			{
				// TODO:  添加 DataFileParam.FileName getter 实现
				return this.root;
			}
			set
			{
				// TODO:  添加 DataFileParam.FileName setter 实现
				this.root = value;
			}
		}
		#endregion
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new DataFileParam Clone()
		{
			DataFileParam obj = new DataFileParam();
			obj = base.Clone() as DataFileParam;
			return obj;
		}
	}
}
