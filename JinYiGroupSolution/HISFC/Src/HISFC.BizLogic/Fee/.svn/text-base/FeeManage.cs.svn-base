using System;
using System.Collections;
using System.Data;

namespace neusoft.HISFC.Management.Fee
{
	/// <summary>
	///与费用相关的，需要与数据库联接的一些函数，(Create By Maokb)
	///1.查询最小费用名称和代码；
	/// </summary>
	public class FeeManage:neusoft.neuFC.Management.Database 
	{
		/// <summary>
		/// 包括：1.查询最小费用名称和代码；
		/// </summary>
		public FeeManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 公有函数
		/// <summary>
		/// 查询最小费用代码，名称
		/// </summary>
		/// <returns>包含最小费用代码和名称的数组</returns>
		public ArrayList GetMinFee()
		{
			string sql = "";
			if(this.Sql.GetSql("Fee.FeeManage.GetMinFee",ref sql)==-1)
			{
				this.Err="没有找到Fee.FeeManage.GetMinFee字段!";
				return null;
			}
			//查询添加Item
			return this.addItem2(sql);
		}
		#endregion

		#region 私有函数
		/// <summary>
		/// 向数组中添加包含两项的Item
		/// </summary>
		/// <param name="excSql">执行的SQL语句</param>
		/// <returns></returns>
		private ArrayList addItem2(string excSql)
		{
			ArrayList al = new ArrayList();

			if(this.ExecQuery(excSql)==-1)
				return null;
			
			try
			{
				while(this.Reader.Read())
				{
					neusoft.neuFC.Object.neuObject obj = new neusoft.neuFC.Object.neuObject();
					obj.ID = this.Reader[0].ToString();//ID
					obj.Name = this.Reader[1].ToString();//Name
					al.Add(obj);
					obj=null;
				}
				this.Reader.Close();
				return al;
			}
			catch(Exception ex)
			{
				this.Err="添加项目出错"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				if(this.Reader.IsClosed==false)this.Reader.Close();
				al=null;
				return al;
			}
		}
		#endregion
	}
}
