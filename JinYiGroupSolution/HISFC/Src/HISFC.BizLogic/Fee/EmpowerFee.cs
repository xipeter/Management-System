using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// 收费授权(日结后通过财务授权后才可以继续收费)
    /// </summary>
    public class EmpowerFee : Neusoft.FrameWork.Management.Database
    {
        #region 查询
        /// <summary>
        /// 查询收费员是否被收费
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public bool QueryIsEmpower(string operCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.IsEmpowerFee", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.IsEmpowerFee的SQL语句失败！";
                return false;
            }
            sql = string.Format(sql, operCode);
            int returnValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
            if (returnValue <= 0)
            {
                return false;
            }
            return true;
            
        }

        /// <summary>
        /// 查询收费员是否日结
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public bool QueryIsDayBalance(string operCode,string beginDate,string endDate)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.IsDayBalance", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.IsEmpowerFee的SQL语句失败！";
                return false;
            }
            
            sql = string.Format(sql, operCode,beginDate,endDate);
            int returnValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
            if (returnValue <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据时间段来查询所有日结记录
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public System.Data.DataTable QueryAllDayBalance(string beginDate, string endDate) 
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.QueryAllDayBalance", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.QueryAllDayBalance的SQL语句失败！";
                return null;
            }

            sql = string.Format(sql, beginDate, endDate);
            System.Data.DataSet ds = new System.Data.DataSet();
            this.ExecQuery(sql,ref ds);
            return ds.Tables[0];
        }
        
        /// <summary>
        /// 查询已经授权的记录
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public System.Data.DataTable QueryAllEmpowered(string start, string end) 
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.QueryAllEmpowered", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.QueryAllEmpowered的SQL语句失败！";
                return null;
            }

            sql = string.Format(sql,start, end);
            System.Data.DataSet ds = new System.Data.DataSet();
            this.ExecQuery(sql,ref ds);
            return ds.Tables[0];
        }
        #endregion

        #region 删除

        public bool DeleteEmpowerByPk(string feeOperCode, string statNo) 
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.DeleteEmpowerByPk", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.DeleteEmpowerByPk的SQL语句失败！";
                return false;
            }

            sql = string.Format(sql, feeOperCode, statNo);
            int returnValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecNoQuery(sql));
            if (returnValue <= 0)
            {
                return false;
            }
            return true;
        }

        #endregion


        #region 插入

        public bool InsertEmpowerOper(Neusoft.HISFC.Models.Fee.EmpowerFeeOper empowerFeeOper)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.InsertEmpowerOper", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.InsertEmpowerOper的SQL语句失败！";
                return false;
            }

            string [] objs = 
                { 
                    empowerFeeOper.FeeOperCode, 
                    empowerFeeOper.StatNo,
                    empowerFeeOper.DayBalanceDate.ToString(),
                    empowerFeeOper.OperCode,
                    empowerFeeOper.OperDate.ToString(),
                    empowerFeeOper.Valid ? "1":"0"
                };

            sql = string.Format(sql,objs);

            int returnValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecNoQuery(sql));
            if (returnValue <= 0)
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}
