using System;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// PageSize 的摘要说明。
	/// 打印纸张大小设置
	/// </summary>
	public class PageSize:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 设置打印纸张大小
		/// </summary>
		public PageSize()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		/// <summary>
		/// 获得纸张大小
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.PageSize GetPageSize(string ID,string DeptCode)
		{
			string sql ="Manager.PageSize.GetPageSize.1";
			if(this.Sql.GetSql(sql,ref sql)==-1)
			{
				this.Err = "无法找到Manager.PageSize.GetPageSize.1";
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql,ID,DeptCode)==-1)
			{
				return null;
			}
			Neusoft.HISFC.Models.Base.PageSize obj = new Neusoft.HISFC.Models.Base.PageSize();
			
			
			try
			{
				this.Reader.Read();
				obj.ID  = this.Reader[0].ToString();
				obj.Name  = this.Reader[1].ToString();
				obj.Memo  = this.Reader[2].ToString();
				obj.Dept.ID  = this.Reader[3].ToString();
				try
				{
					obj.Dept.Name = this.Reader[4].ToString();
				}
				catch{}

				obj.Width   = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5]);
				obj.Height  = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6]);

				obj.Printer = this.Reader[7].ToString();
				obj.Top = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8]);
				obj.Left = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
				obj.OperEnvironment.ID = this.Reader[10].ToString();
				obj.OperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11]);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			return obj;
		}
		
		/// <summary>
		/// 获得纸张大小
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.PageSize GetPageSize(string ID)
		{
			string sql ="Manager.PageSize.GetPageSize.2";
			if(this.Sql.GetSql(sql,ref sql)==-1)
			{
				this.Err = "无法找到Manager.PageSize.GetPageSize.2";
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql,ID)==-1)
			{
				return null;
			}
			Neusoft.HISFC.Models.Base.PageSize obj = new Neusoft.HISFC.Models.Base.PageSize();
			
//			if(this.Reader.HasRows==false) return obj;
			
			try
			{
				this.Reader.Read();
				obj.ID  = this.Reader[0].ToString();
				obj.Name  = this.Reader[1].ToString();
				obj.Memo  = this.Reader[2].ToString();
				obj.Dept.ID  = this.Reader[3].ToString();
				try
				{
					obj.Dept.Name = this.Reader[4].ToString();
				}
				catch{}
				obj.Width   = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5]);
				obj.Height  = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6]);
				obj.Printer = this.Reader[7].ToString();
				obj.Top = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8]);
				obj.Left = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
				obj.OperEnvironment.ID = this.Reader[10].ToString();
				obj.OperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11]);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			return obj;
		}
		
		/// <summary>
		///  获得列表
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetList()
		{
			string sql ="Manager.PageSize.GetPageSize.List.1";
			if(this.Sql.GetSql(sql,ref sql)==-1)
			{
				this.Err = "无法找到Manager.PageSize.GetPageSize.List.1";
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql)==-1)
			{
				return null;
			}
			
			System.Collections.ArrayList al  = new System.Collections.ArrayList();		
//			if(this.Reader.HasRows==false) return al;
			
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Base.PageSize obj = new Neusoft.HISFC.Models.Base.PageSize();
					obj.ID  = this.Reader[0].ToString();
					obj.Name  = this.Reader[1].ToString();
					obj.Memo  = this.Reader[2].ToString();
					obj.Dept.ID  = this.Reader[3].ToString();
					try
					{
						obj.Dept.Name = this.Reader[4].ToString();
					}
					catch{}

					obj.Width   = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5]);
					obj.Height  = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6]);

					obj.Printer = this.Reader[7].ToString();
					obj.Top = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8]);
					obj.Left = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
					obj.OperEnvironment.ID = this.Reader[10].ToString();
					obj.OperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11]);
					al.Add(obj);
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			return al;
		}
		
		/// <summary>
		/// 设置PageSize 根据ID,DeptCode为索引
		/// </summary>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public int SetPageSize(Neusoft.HISFC.Models.Base.PageSize pageSize)
		{
//			Neusoft.HISFC.Models.Base.PageSize obj =this.GetPageSize(pageSize.ID,pageSize.Dept.ID);
//			if(obj == null)
//				return -1;

			string sqlInsert = "Manager.PageSize.InsertPageSize";
			string sqlUpdate = "Manager.PageSize.UpdatePageSize";
			string sql ="";
			if(this.myGetSql(sqlUpdate,pageSize,ref sql)==-1)return -1;
			if(this.ExecNoQuery(sql)<=0)
			{
				if(this.myGetSql(sqlInsert,pageSize,ref sql)==-1)return -1;
				return this.ExecNoQuery(sql);
			}
			
			return 0;
		}
		/// <summary>
		/// 获得参数
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="Sql"></param>
		/// <returns></returns>
		protected int myGetSql(string sqlIndex,Neusoft.HISFC.Models.Base.PageSize pageSize,ref string Sql)
		{
			string sql1 = "";
			if(this.Sql.GetSql(sqlIndex,ref sql1)==-1)
			{
				this.Err = sqlIndex +"没有找到!";
				this.WriteErr();
				return -1;
			}
			try
			{
				Sql = string.Format(sql1,pageSize.ID,pageSize.Name,pageSize.Memo,pageSize.Height,pageSize.Width,pageSize.Dept.ID,pageSize.Printer,pageSize.Top,pageSize.Left,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return -1;
			}
			return 0;
		}
		/// <summary>
		/// 删除PageSize
		/// </summary>
		/// <param name="ID"></param>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public int DelPageSize(string ID,string DeptCode)
		{
			return 0;
		}
	}
}
