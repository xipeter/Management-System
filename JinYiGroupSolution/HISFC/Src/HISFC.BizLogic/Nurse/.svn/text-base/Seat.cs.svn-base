using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Nurse
{
    public class Seat : Neusoft.FrameWork.Management.Database
    {
        public Seat()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 表字段
		//	CONSOLE_CODE,                           --诊台代码
		//	CONSOLE_NAME,                           --诊台名称
		//	INPUT_CODE,                             --输入码
		//	ROOM_CODE,                              --诊室代码
		//	ROOM_NAME,                              --诊室名称
		//	VALID_FLAG,                             --1有效/0无效
		//	REMARK,                                 --备注
		//	OPER_CODE,                              --操作员
		//	OPER_DATE                               --操作时间
		#endregion

		#region 方法
		/// <summary>
		/// 根据诊室号码获取诊台
		/// </summary>
		/// <param name="roomNo"></param>
		/// <returns></returns>
		public ArrayList Query(string roomNo)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Seat.Query.1",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,roomNo);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 根据诊室号码获取有效诊台
		/// </summary>
		/// <param name="roomNo"></param>
		/// <returns></returns>
		public ArrayList QueryValid(string roomNo)
		{
			ArrayList al = new ArrayList();
			string strSQL;
			string strWhere = "";
			strSQL = this.GetSqlInjectInfo();
			if(this.Sql.GetSql("Nurse.Seat.Query.2",ref strWhere) == -1) return null;
			strSQL = strSQL + strWhere;
			strSQL = string.Format(strSQL,roomNo);
			al = this.myGetInfo(strSQL);
			return al;
		}
		/// <summary>
		/// 插入一条新的诊台信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Nurse.Seat info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Seat.Insert",ref sql) == -1)return -1;

			try
			{
                sql = string.Format(sql, info.ID, info.Name, info.PRoom.InputCode, info.PRoom.ID, info.PRoom.Name,
                    info.PRoom.IsValid, info.Memo, info.Oper.ID, info.Oper.OperTime);
			}
			catch(Exception e)
			{
				this.Err = "转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}
			return this.ExecNoQuery(sql);
		}
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Update(Neusoft.HISFC.Models.Nurse.Seat info)
		{
			string sql = "";

			if(this.Sql.GetSql("Nurse.Seat.Update",ref sql) == -1) return -1;

			try
			{
                sql = string.Format(sql, info.ID, info.Name, info.PRoom.InputCode, info.PRoom.ID, info.PRoom.Name,
                    info.PRoom.IsValid, info.Memo, info.Oper.ID, info.Oper.OperTime);
			}
			catch(Exception e)
			{
				this.Err ="转换出错!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		/// <summary>
		/// 根据诊台号码删除
		/// </summary>
		/// <param name="strId"></param> 
		/// <returns></returns>
		public int DeleteByConsole(string strId)
		{
			string strSql = "";
			if (this.Sql.GetSql("Nurse.Seat.Delete.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,strId);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 根据诊室号码删除若干信息
		/// </summary>
		/// <param name="roomCode"></param>
		/// <returns></returns>
		public int DeleteByRoom(string roomCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("Nurse.Seat.Delete.2",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,roomCode);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}			
			return this.ExecNoQuery(strSql);
		}

        /// <summary>
        /// 查询要删除的诊台是否被队列维护
        /// </summary>
        /// <param name="roomID">诊台</param>
        /// <param name="strDate">系统时间</param>
        /// <returns></returns>
        public int QueryConsole(string consoleID, string strDate)
        {
            string strsql = "";
            if (this.Sql.GetSql("Nurse.Seat.GetConsoleUsed", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Seat.GetConsoleUsed失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql, consoleID, strDate);

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
        }

        /// <summary>
        /// 查询met_nuo_assignrecord中是否有符合条件的诊台是否在用
        /// </summary>
        /// <param name="roomID">诊台代码</param>
        /// <returns></returns>
        public int QuerySeatByConsoleID(string consoleID)
        {
            string strsql = string.Empty;
            if (this.Sql.GetSql("Nurse.Seat.GetRoomByConsoleID", ref strsql) == -1)
            {
                this.Err = "得到Nurse.Seat.GetRoomByConsoleID失败";
                return -1;
            }

            try
            {
                strsql = string.Format(strsql, consoleID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            } return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strsql));
        }
		#endregion

		#region 公用信息
		/// <summary>
		/// 获取基本SQL语句
		/// </summary>
		/// <returns></returns>
		public string GetSqlInjectInfo() 
		{
			string strSql = "";
			if (this.Sql.GetSql("Nurse.Seat.Query",ref strSql)==-1) return null;
			return strSql;
		}
		/// <summary>
		/// 根据SQL,获取实体数组
		/// </summary>
		/// <param name="SQLString"></param>
		/// <returns></returns>
		public ArrayList myGetInfo(string SQLString) 
		{
			ArrayList al=new ArrayList();         
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) 
			{
				this.Err="获得注射信息时，执行SQL语句出错！"+this.Err; 
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read())  
				{
					#region 将结果转化为实体
					Neusoft.HISFC.Models.Nurse.Seat info = new Neusoft.HISFC.Models.Nurse.Seat();
					
					info.ID = this.Reader[0].ToString();//诊台代码
					info.Name = this.Reader[1].ToString();//诊台名称
                    info.PRoom.InputCode = this.Reader[2].ToString();//输入码
                    info.PRoom.ID = this.Reader[3].ToString();//诊室代码
                    info.PRoom.Name = this.Reader[4].ToString();//诊室名称
                    info.PRoom.IsValid = this.Reader[5].ToString();//1有效/0无效
                    info.PRoom.Memo = this.Reader[6].ToString();//备注
					info.Oper.ID = this.Reader[7].ToString();//操作员
					info.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8]);//操作时间
					info.CurrentCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
					#endregion
					al.Add(info);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得诊台信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();
			this.ProgressBarValue=-1;
			return al;
		}
		#endregion
	}
}