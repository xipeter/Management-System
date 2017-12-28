using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Registration
{
    public class NetRegister : Neusoft.FrameWork.Management.Database
    {
        #region 私有方法
        /// <summary>
        /// 获取集成平台挂号信息SQL语句
        /// </summary>
        /// <returns></returns>
        private string GetNetRegisterSql()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Net_GetRegister.Sql", ref sql) ==-1)
            {
                this.Err = "查询索引为Net_GetRegister.Sql的SQL语句失败！";
                return null;
            }
            return sql;
        }


        #endregion

        #region 共有方法
        /// <summary>
        /// 获取集成平台挂号信息
        /// </summary>
        /// <returns></returns>
        public DataSet  GetNetRegister(DateTime dtBegin,DateTime dtEnd)
        {
            string sql = string.Empty;
            string sqlWhere = string.Empty;
            sql = GetNetRegisterSql();
            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }
            if (this.Sql.GetSql("Net_getRegister.Where1", ref sqlWhere) == -1)
            {
                this.Err = "查询索引为Net.GetRegister.OrderBy的SQL语句失败！";
                return null;
            }

            sqlWhere = string.Format(sqlWhere, dtBegin.ToString(), dtEnd.ToString());

            sql += sqlWhere;

            DataSet ds = new DataSet();
            if (this.ExecQuery(sql, ref ds) < 0)
            {
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 更新集成疲态挂号信息确认状态
        /// </summary>
        /// <param name="hospitalCode">医院编码</param>
        /// <param name="hosptialSeq">医院Seq</param>
        /// <returns></returns>
        public int UpdateConfirm(string hospitalCode, string hosptialSeq)
        {
            string sql = string.Empty ;
            if (this.Sql.GetSql("Net_UpdateRegisterConfirm", ref sql) == -1)
            {
                this.Err = "查询索引为Net_UpdateRegisterConfirm的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql,hospitalCode, hosptialSeq);
            return this.ExecNoQuery(sql);
        }
        #endregion
    }
}
