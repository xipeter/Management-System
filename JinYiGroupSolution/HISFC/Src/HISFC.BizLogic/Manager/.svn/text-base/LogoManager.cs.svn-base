using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// LogoManager 的摘要说明。
	/// 日志管理类
	/// </summary>
	public class LogoManager:Neusoft.FrameWork.Management.Database
	{
		public LogoManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获得错误日志
		/// </summary>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public ArrayList GetLogoError(DateTime dtBegin,DateTime dtEnd)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.LogoManager.GetLogoError",ref sql)==-1) return null;
			
			try
			{
				sql = string.Format(sql,dtBegin.ToString(),dtEnd.ToString());
			}
			catch{
				this.Err = "Manager.LogoManager.GetLogoError赋值出错！";
				this.WriteErr();
			}
			
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
//			if(this.Reader.HasRows==false) return al;
			while(this.Reader.Read())
			{

				Neusoft.HISFC.Models.Base.Logo obj =new Neusoft.HISFC.Models.Base.Logo();
				try
				{
					if(!Reader.IsDBNull(0))obj.ID = this.Reader[0].ToString();
					if(!Reader.IsDBNull(1))obj.DBCode = this.Reader[1].ToString();
					if(!Reader.IsDBNull(2))obj.SqlCode = this.Reader[2].ToString();
					if(!Reader.IsDBNull(3))obj.SqlError = this.Reader[3].ToString();
					if(!Reader.IsDBNull(4))obj.User01 = this.Reader[4].ToString();
					if(!Reader.IsDBNull(5))obj.User02 = this.Reader[5].ToString();
					if(!Reader.IsDBNull(6))obj.CodeDescription = this.Reader[6].ToString();
					if(!Reader.IsDBNull(7))obj.Modual = this.Reader[7].ToString();
					obj.DebugType = 1; //error
				}
				catch{}
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 获得日志
		/// </summary>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public ArrayList GetLogoDebug(DateTime dtBegin,DateTime dtEnd)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.LogoManager.GetLogoDebug",ref sql)==-1) return null;
			
			try
			{
				sql = string.Format(sql,dtBegin.ToString(),dtEnd.ToString());
			}
			catch
			{
				this.Err = "Manager.LogoManager.GetLogoDebug赋值出错！";
				this.WriteErr();
			}
			
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
//			if(this.Reader.HasRows==false) return al;
			while(this.Reader.Read())
			{

				Neusoft.FrameWork.Models.NeuObject  obj =new Neusoft.FrameWork.Models.NeuObject();
				try
				{              
					if(!Reader.IsDBNull(0))obj.ID = this.Reader[0].ToString();
					if(!Reader.IsDBNull(1))obj.Name = this.Reader[1].ToString();
					if(!Reader.IsDBNull(2))obj.Memo = this.Reader[2].ToString();
					if(!Reader.IsDBNull(3))obj.User01 = this.Reader[3].ToString();
					if(!Reader.IsDBNull(4))obj.User02 = this.Reader[4].ToString();
					if(!Reader.IsDBNull(5))obj.User03 = this.Reader[5].ToString();
				}
				catch{}
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 删除调试日志
		/// </summary>
		/// <returns></returns>
		public int DeleteLogoDebug()
		{
			string sql = "";
			if(this.Sql.GetSql("Manager.LogoManager.DeleteLogoDebug",ref sql)== -1) return -1;
			return this.ExecQuery(sql);

		}
		/// <summary>
		/// 删除错误日志
		/// </summary>
		/// <returns></returns>
		public int DeleteLogoError()
		{
			string sql = "";
			if(this.Sql.GetSql("Manager.LogoManager.DeleteLogoError",ref sql)== -1) return -1;
			return this.ExecQuery(sql);
		}
	}
}
