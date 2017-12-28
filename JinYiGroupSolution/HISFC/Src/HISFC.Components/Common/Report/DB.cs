using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Common.Report
{
    public class DB:Neusoft.FrameWork.Management.Database
    {
      
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryDataBySql(string sql,ref System.Data.DataTable  dt,params string[] p )
        {
            string strsql = sql;
            //if (this.Sql.GetSql("Manager.Bed.QueryBedInfo", ref strsql) == -1)
            //{
            //    return -1;
            //}
            try
            {
                strsql = string.Format(strsql,p);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            dt = ds.Tables[0];
            return 1;
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryDataBySqlId(string sqlId, ref System.Data.DataTable dt, params string[] p)
        {
            string strsql = string.Empty;
            if (this.Sql.GetSql(sqlId, ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql, p);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            System.Data.DataSet ds = new System.Data.DataSet();
            if (this.ExecQuery(strsql, ref ds) == -1)
            {
                return -1;
            }
            dt = ds.Tables[0];
            return 1;
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryDataBySql(string sql, ref System.Data.DataTable dt, System.Collections.Generic.List<Neusoft.FrameWork.Models.NeuObject> p)
        {
            string pStr = string.Empty;

            foreach (Neusoft.FrameWork.Models.NeuObject  no in p)
            {
                pStr = pStr + no.Name.ToString() + ",";
            }
            return this.QueryDataBySql(sql,ref dt, pStr.Split(','));
          
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="dv">返回的数据视图</param>
        /// <returns>1,成功; -1,失败</returns>
        public int QueryDataBySqlId(string sqlId, ref System.Data.DataTable dt, System.Collections.Generic.List<Neusoft.FrameWork.Models .NeuObject> p)
        {
            string pStr = string.Empty;

            foreach (Neusoft.FrameWork.Models.NeuObject no in p)
            {
                pStr = pStr + no.Name.ToString() + "$";
            }
            return this.QueryDataBySqlId(sqlId, ref dt, pStr.Split('$'));
        }
    }
}
