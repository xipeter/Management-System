using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Notice 的摘要说明。
	/// </summary>
	public class Notice:Neusoft.FrameWork.Management.Database
	{
		public Notice()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 执行Sql语句 获得Notice实体数组
		/// </summary>
		/// <param name="sql">所执行Sql语句</param>
		/// <returns>成功返回ArrayList 失败返回null</returns>
		protected ArrayList myNoticeQuery(string sql)
		{
			ArrayList al = new ArrayList();
			
			if (this.ExecQuery(sql) == -1)
				return null;

			try
			{
				Neusoft.HISFC.Models.Base.Notice notice;
				while (this.Reader.Read())
				{
					notice = new Neusoft.HISFC.Models.Base.Notice();

					notice.ID = this.Reader[0].ToString();						//0 流水号
					notice.Dept.ID = this.Reader[1].ToString();				//1 科室编码
					notice.Group.ID = this.Reader[2].ToString();				//2 功能组编码
					notice.NoticeInfo = this.Reader[3].ToString();				//3 发布信息
					notice.NoticeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());	//4 发布日期
					notice.NoticeDept.ID = this.Reader[5].ToString();			//5 发布科室
					notice.ExtFlag = this.Reader[6].ToString();					//6 扩展标志
					notice.OperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());	//7 操作日期
					notice.OperEnvironment.ID = this.Reader[8].ToString();				//8 操作人
					notice.NoticeTitle = this.Reader[9].ToString();				//9 发布信息标题

					al.Add(notice);
				}
			}
			catch (Exception ex)
			{
				this.Err = "获取已发布信息发生错误" + ex.Message;
				this.WriteErr();
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
			return al;
		}
		/// <summary>
		/// 返回insert 或 update 参数数组
		/// </summary>
		/// <param name="notice">notice实体</param>
		/// <returns>成功返回string数组</returns>
		protected string[] myNoticeParm(Neusoft.HISFC.Models.Base.Notice notice)
		{
			if (notice == null)
				return null;
			string[] strParm = {
								   notice.ID,						//0 流水号
									notice.Dept.ID,				//1 科室编码
									notice.Group.ID,				//2 功能组编码
									notice.NoticeInfo,				//3 发布信息
									notice.NoticeDate.ToString(),	//4 发布日期
									notice.NoticeDept.ID,			//5 发布科室
									notice.ExtFlag,					//6 扩展标志
									notice.OperEnvironment.OperTime.ToString(),		//7 操作日期
									notice.OperEnvironment.ID,				//8 操作员
								    notice.NoticeTitle				//9 发布信息标题
							   };
			return strParm;
		}


		/// <summary>
		/// 插入发布信息
		/// </summary>
		/// <param name="notice">发布信息实体</param>
		/// <returns>成功返回 1 失败返回-1</returns>
		protected int InsertNotice(Neusoft.HISFC.Models.Base.Notice notice)
		{
			string sql = "";
			if (this.Sql.GetSql("Manager.Notice.Insert",ref sql) == -1)		
				return -1;

			try
			{
				string[] strParm = this.myNoticeParm(notice);
				sql = string.Format(sql,strParm);
			}
			catch(Exception ex)
			{
				this.Err = "格式化Insert Sql语句出错" + ex.Message;
				this.WriteErr();
				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		/// <summary>
		/// 更新发布信息
		/// </summary>
		/// <param name="notice">发布信息实体</param>
		/// <returns>成功更新返回1 失败返回-1</returns>
		protected int UpdateNotice(Neusoft.HISFC.Models.Base.Notice notice)
		{
			string sql = "";
			if (this.Sql.GetSql("Manager.Notice.Update",ref sql) == -1)
				return -1;
			try
			{
				string[] strParm = this.myNoticeParm(notice);
				sql = string.Format(sql,strParm);
			}
			catch(Exception ex)
			{
				this.Err = "格式化Update Sql语句出错" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql);
		}

		
		/// <summary>
		/// 删除发布信息 
		/// </summary>
		/// <param name="noticeID">发布信息流水号</param>
		/// <returns>成功返回1 失败返回-1</returns>
		public int DeleteNotice(string noticeID)
		{
			string sql = "";
			if (this.Sql.GetSql("Manager.Notice.Delete",ref sql) == -1)		
				return -1;

			try
			{
				sql = string.Format(sql,noticeID);
			}
			catch(Exception ex)
			{
				this.Err = "格式化Delete Sql语句出错" + ex.Message;
				this.WriteErr();
				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 设置发布信息 先执行更新操作 再执行插入操作
		/// </summary>
		/// <param name="notice">发布信息实体</param>
		/// <returns>成功返回1 失败返回-1</returns>
		public int SetNotice(Neusoft.HISFC.Models.Base.Notice notice)
		{
			int parm = this.UpdateNotice(notice);
			if(parm == -1)
				return parm;
			if (parm == 0)
				return this.InsertNotice(notice);
			return parm;
		}

		/// <summary>
		/// 根据科室编码、功能组编码 获取 相应的发布信息
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="groupCode">功能组编码</param>
		/// <param name="beginNoticeDate">发布起始日期</param>
		/// <param name="endNoticeDate">发布终止日期</param>
		/// <returns>成功返回notice数组 失败返回null</returns>
		public ArrayList GetNotice(string deptCode,string groupCode,DateTime beginNoticeDate,DateTime endNoticeDate)
		{
			string sqlSelect = "",strWhere = "";
			if (this.Sql.GetSql("Manager.Notice.GetNotice.Select",ref sqlSelect) == -1)		
				return null;
			if (this.Sql.GetSql("Manager.Notice.GetNotice.Where.ByDept",ref strWhere) == -1)
				return null;

			try
			{
				sqlSelect = sqlSelect + strWhere;
				sqlSelect = string.Format(sqlSelect,deptCode,groupCode,beginNoticeDate.ToString(),endNoticeDate.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "格式化" + sqlSelect +"Sql语句出错" + ex.Message;
				this.WriteErr();
				return null;
			}

			return this.myNoticeQuery(sqlSelect);
		}
		/// <summary>
		/// 根据发布科室 发布日期 获取 相应的 发布信息
		/// </summary>
		/// <param name="noticeDept">发布科室</param>
		/// <param name="beginNoticeDate">发布起始日期</param>
		/// <param name="endNoticeDate">发布终止日期</param>
		/// <returns>成功返回notice数组 失败返回null</returns>
		public ArrayList GetNotice(string noticeDept,DateTime beginNoticeDate,DateTime endNoticeDate)
		{
			string sqlSelect = "",strWhere = "";
			if (this.Sql.GetSql("Manager.Notice.GetNotice.Select",ref sqlSelect) == -1)		
				return null;
			if (this.Sql.GetSql("Manager.Notice.GetNotice.Where.ByNoticeDept",ref strWhere) == -1)
				return null;

			try
			{
				sqlSelect = sqlSelect + strWhere;
				sqlSelect = string.Format(sqlSelect,noticeDept,beginNoticeDate.ToString(),endNoticeDate.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "格式化" + sqlSelect + "Sql语句出错" + ex.Message;
				this.WriteErr();
				return null;
			}

			return this.myNoticeQuery(sqlSelect);
		}
	}
}
