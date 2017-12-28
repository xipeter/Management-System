using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.DefultInterfacesAchieve.Inject
{
    /// <summary>
    /// GetInjectOrderNoAchieve<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射号码接口实现业务层{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class Function : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取该患者当天的最后一次的序号
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string GetPatientTodayOrderNo(string cardNo)
        {
            string sql = @" select distinct (order_no)
                             from met_nuo_inject
                            where card_no = '{0}'
                             and register_date > to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                             and register_date = (select max(register_date)
                                                  from met_nuo_inject
                                                  where card_no = '{0}'
                                                  and register_date > to_date('{1}', 'yyyy-mm-dd hh24:mi:ss'))";
            string today = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 00:00:01";
            sql = string.Format(sql, cardNo, today);
            return this.ExecSqlReturnOne(sql);
        }

        /// <summary>
        /// 生成新的序号
        /// </summary>
        /// <param name="startStr"></param>
        /// <returns></returns>
        public string CreateNewNo(string startStr)
        {
            string sql = @"select distinct(order_no) from met_nuo_inject 
                           where register_date > to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                            and Substr(order_no, 0, 1) = '{0}' 
                            and register_date = (select max(register_date)
                                                  from met_nuo_inject
                                                 where register_date > to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                                                  and Substr(order_no, 0, 1) = '{0}' )";
            string today = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 00:00:01";
            sql = string.Format(sql, startStr, today);
            string orderNo = this.ExecSqlReturnOne(sql);
            if (string.IsNullOrEmpty(orderNo) || orderNo == "-1")
            {
                return startStr + "001-1";
            }
            string[] noSplit = orderNo.Split('-');
            return (FrameWork.Function.NConvert.ToInt32(noSplit[0]) + 1).ToString("0000") + "-1";
        }

        /// <summary>
        /// 获取打印序号
        /// </summary>
        /// <returns></returns>
        public string GetPrintNo()
        {
            string sql = "";
            if (this.Sql.GetSql("Nurse.Inject.GetPrintNoSeq", ref sql) == -1)
            {
                this.Err = "未找到sql语句：Nurse.Inject.GetPrintNoSeq";
                return "";
            }
            return this.ExecSqlReturnOne(sql);
        }
    }
}
