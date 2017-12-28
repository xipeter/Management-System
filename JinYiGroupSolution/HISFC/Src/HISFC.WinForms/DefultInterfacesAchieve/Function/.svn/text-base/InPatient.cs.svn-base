using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.DefultInterfacesAchieve.Function
{
    /// <summary>
    /// {6BFCAC25-CC22-48ac-ADDB-76E169375EAB}
    /// </summary>
    public class InPatient : Neusoft.FrameWork.Management.Database
    {

        /// <summary>
        /// 查询某一最小费用的费用明细收取的数量
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <param name="miniFee"></param>
        /// <returns></returns>
        public int QueryItemQtyByMiniFee(string inPatientNO, string miniFee)
        {
            string sql = string.Empty;

            //获得SQL语句
            if (this.Sql.GetSql("RADT.InPatient.QueryItemQtyByMiniFee.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return 0;
            }
            try
            {
                sql = string.Format(sql, inPatientNO, miniFee);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToInt32(myresult);

        }

        /// <summary>
        /// 查询某一SYSCLASS的费用明细收取的数量
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <param name="sysClass"></param>
        /// <returns></returns>
        public int QueryItemQtyBySysClass(string inPatientNO, string sysClass)
        {
            string sql = string.Empty;

            //获得SQL语句
            if (this.Sql.GetSql("RADT.InPatient.QueryItemQtyBySysClass.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return 0;
            }
            try
            {
                sql = string.Format(sql, inPatientNO, sysClass);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToInt32(myresult);

        }
    }
}
