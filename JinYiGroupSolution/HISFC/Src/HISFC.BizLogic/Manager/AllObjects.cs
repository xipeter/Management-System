using System;
using System.Data;
namespace Neusoft.HISFC.BizLogic.Manager 
{
	/// <summary>
	/// AllObjects 的摘要说明。
	/// </summary>
	public class AllObjects:Neusoft.FrameWork.Management.Database
	{
		public AllObjects()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 得到所有需要检查修复(刷新、编译)的对象
		/// </summary>
		/// <returns></returns>
		public DataSet GetAllObject(string owner)
		{
			System.Data.DataSet  ds = new DataSet();
			try
			{
				string strSql = "";
				//获取SQL
				if(this.Sql.GetSql("HISFC.Management.GetAllObject",ref strSql) ==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
                strSql = string.Format(strSql, owner);
				//查询 
				this.ExecQuery(strSql,ref ds);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return ds;
		}

		/// <summary>
		/// 修复对象
		/// </summary>
		/// <param name="Ownobject"></param>
		/// <returns></returns>
		public int AlterSql(string Ownobject)
		{
			string strSql = "";
			int  Return = 0;
			try
			{
				if(this.Sql.GetSql("HISFC.Management.AlterSql",ref strSql)==-1 )
				{
					this.Err = this.Sql.Err;
					return -1;
				}
				else
				{
					//格式化SQL
					strSql = string.Format(strSql,Ownobject);
				}
				// 执行SQL
				Return = this.ExecNoQuery(strSql);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return Return;
		}

        /// <summary>
        /// 查询所有锁进程
        /// </summary>
        /// <returns>锁进程集合</returns>
        public DataSet QueryLockSession()
        {
            DataSet ds = new DataSet();

            string strsql = "";
            try
            {
                if (this.Sql.GetSql("Manager.QueryLockSession", ref strsql) == -1)
                {
                    this.Err = this.Sql.Err;
                    return null;
                }
                this.ExecQuery(strsql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="serial"></param>
        /// <returns>1,成功；-1失败</returns>
        public int AlterSessionState(string sid, string serial)
        {
            string strsql = "";
            try
            {
                if (this.Sql.GetSql("Manager.KillLockSession", ref strsql) == -1)
                {
                    this.Err = this.Sql.Err;
                    return -1;
                }
                strsql = string.Format(strsql, sid, serial);
                if (this.ExecNoQuery(strsql) == -1)
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;
        }

	}
}
