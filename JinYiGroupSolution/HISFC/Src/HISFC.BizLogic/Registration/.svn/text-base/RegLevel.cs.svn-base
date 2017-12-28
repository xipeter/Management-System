using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Registration
{
	/// <summary>
	/// 挂号级别管理类
	/// </summary>
	public class RegLevel:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 挂号级别管理类
		/// </summary>
		public RegLevel()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 定义
		/// <summary>
		/// 挂号级别实体
		/// </summary>
		protected Neusoft.HISFC.Models.Registration.RegLevel regLvl = null;

		/// <summary>
		///ArrayList
		/// </summary>
		protected ArrayList al = null;
		#endregion

		#region 增加
		/// <summary>
		/// 插入一条挂号级别
		/// </summary>
		/// <param name="regLevel"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Registration.RegLevel regLevel)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.RegLevel.Insert",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,regLevel.ID,regLevel.Name,regLevel.UserCode,regLevel.SortID.ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(regLevel.IsValid).ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(regLevel.IsExpert).ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(regLevel.IsFaculty).ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(regLevel.IsDefault).ToString(),regLevel.Oper.ID,
					regLevel.Oper.OperTime.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(regLevel.IsSpecial));
			}
			catch(Exception e)
			{
				this.Err = "[Registration.RegLevel.Insert]格式不匹配!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		#endregion

		#region 删除
		/// <summary>
		/// 根据挂号级别代码删除一条挂号级别
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int Delete(string ID)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.RegLevel.Delete",ref sql) == -1) return -1;

			try
			{
				sql=string.Format(sql,ID);
			}
			catch(Exception e)
			{
				this.Err = "[Registration.RegLevel.Delete]格式不匹配!" + e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		#endregion

		#region 查询
		/// <summary>
		/// 查询全部挂号级别
		/// </summary>
		/// <returns></returns>
		public ArrayList Query()
		{
			string sql="";

			if(this.Sql.GetSql("Registration.RegLevel.Query.1",ref sql)==-1) return null;
			
			return this.queryBase(sql);
		}
		/// <summary>
		/// 按是否有效查询挂号级别
		/// </summary>
		/// <param name="isValid"></param>
		/// <returns></returns>
		public ArrayList Query(bool isValid)
		{
			string sql = "",where = "";

			if(this.Sql.GetSql("Registration.RegLevel.Query.1",ref sql) == -1)return null;
			if(this.Sql.GetSql("Registration.RegLevel.Query.3",ref where) == -1)return null;

			sql = sql + " " +where;
			try
			{
				sql = string.Format(sql,Neusoft.FrameWork.Function.NConvert.ToInt32(isValid).ToString());
			}
			catch(Exception e)
			{
				this.Err = "[Registration.RegLevel.Query3]格式不匹配!" + e.Message;
				this.ErrCode = e.Message;
				return null;
			}

			return this.queryBase(sql);
		}
		/// <summary>
		/// 根据代码检索一条挂号级别
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.RegLevel Query(string ID)
		{
			string sql = "",where = "";

			if(this.Sql.GetSql("Registration.RegLevel.Query.1",ref sql) == -1)return null;
			if(this.Sql.GetSql("Registration.RegLevel.Query.4",ref where) == -1)return null;

			sql = sql + " " +where;
			try
			{
				sql = string.Format(sql,ID);
			}
			catch(Exception e)
			{
				this.Err = "[Registration.RegLevel.Query4]格式不匹配!" + e.Message;
				this.ErrCode = e.Message;
				return null;
			}

			if(this.queryBase(sql) == null)return null ;

			if(al == null)
			{
				return null;
			}
			else if(al.Count == 0)
			{
				return new Neusoft.HISFC.Models.Registration.RegLevel () ;
			}
			else
			{
				return (Neusoft.HISFC.Models.Registration.RegLevel)al[0];
			}
		}
		/// <summary>
		/// 根据sql查询挂号级别信息
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList queryBase(string sql)
		{
			if(this.ExecQuery(sql) == -1) return null;
			try
			{
				this.al = new ArrayList();

				while(this.Reader.Read())
				{
					this.regLvl = new Neusoft.HISFC.Models.Registration.RegLevel();
					//序号
					this.regLvl.ID = this.Reader[2].ToString();
					//名称
					this.regLvl.Name = this.Reader[3].ToString();
					//助记码
					this.regLvl.UserCode = this.Reader[4].ToString();
					//显示顺序
					this.regLvl.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString());
					//是否有效
					this.regLvl.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
					//是否专家号
					this.regLvl.IsExpert = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());
					//是否专科号
					this.regLvl.IsFaculty = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[8].ToString());
					//是否特诊号
					this.regLvl.IsSpecial = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());
					//是否默认
					this.regLvl.IsDefault = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[10].ToString());
					//操作员
					this.regLvl.Oper.ID = this.Reader[11].ToString();
					//操作时间
					this.regLvl.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12].ToString());

					this.al.Add(this.regLvl);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err = "查询挂号级别出错!" + e.Message;
				this.ErrCode = e.Message;
				return null;
			}

			return al;
		}
		#endregion
	}
}
