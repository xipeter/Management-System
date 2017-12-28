using System;
using System.Data.OracleClient;
namespace AutoUpdate
{
	/// <summary>
	/// DataBase 的摘要说明。
	/// </summary>
	public class DataBase
	{
		public DataBase()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 连接 私有
		/// </summary>
		protected System.Data.OracleClient.OracleConnection con;
		/// <summary>
		/// 命令 私有
		/// </summary>
		protected System.Data.OracleClient.OracleCommand command;
	}
}
