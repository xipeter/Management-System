using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Neusoft.WinForms.Report.Finance.FinIpr
{
    class Sql:Neusoft.FrameWork.Management.Database
    {
       
        /// <summary>
        ///根据日期获取结账处退费明细（按照统计大类）
        /// </summary>
        public static string GetBackFeeByTj = @"select *
  from (select sum(e.tot_cost),
               e.fee_stat_name,
               (select f.dept_name
                  from fin_ipr_inmaininfo f
                 where f.inpatient_no = e.inpatient_no) dept_name,
               e.inpatient_no,
               (select g.name
                  from fin_ipr_inmaininfo g
                 where g.inpatient_no = e.inpatient_no) name,
               (select h.empl_name
                  from com_employee h
                 where h.empl_code = e.fee_opercode) oper_name,
               (select i.dept_code
                  from com_employee i
                 where i.empl_code = e.fee_opercode) oper_dept_code
          from (select  distinct a.tot_cost tot_cost,
                       fee_stat_name fee_stat_name,
                       a.inpatient_no inpatient_no,
                       a.fee_opercode fee_opercode
                  from fin_ipb_itemlist a, fin_com_feecodestat b
                 where a.trans_type = 2
                   and a.fee_code = b.fee_code
                   and a.fee_date >=
                       to_date('{0} 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                and a.fee_date<=to_date('{0} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
                ) e
         group by e.fee_stat_name, e.inpatient_no, e.fee_opercode) y
 where y.oper_dept_code = '6101' order by  y.oper_name,y.dept_name,y.name";
        /// <summary>
        /// 执行SQL,返回DS
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="begin_time"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int Exec(string sql, string begin_time,ref DataSet ds) {
            try
            {
                sql = string.Format(sql, begin_time);
            }
            catch (Exception ex)
            {
                this.Err = "格式化sql出错";
                return -1;
            }
            int rev = this.ExecQuery(sql, ref ds);
            if (rev == -1) {
                return -1;
            }
            return 1;
        }
    }
}
