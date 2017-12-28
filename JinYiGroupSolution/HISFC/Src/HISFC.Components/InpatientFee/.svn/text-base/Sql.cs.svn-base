using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace Neusoft.HISFC.Components.InpatientFee
{
    /// <summary>
    /// 警戒线相关
    /// </summary>
   public class Sql:Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取指定合同单位按比例欠费的分子和分母
        /// </summary>
        public static string GetMoneyAlertSql = @"select a.once_limit, --按比例的分子
                                                        a.air_limit,--按比例的分母
                                                        a.arr_ratio --居民、新农合医保备用
                                                      from fin_com_pactunitinfo a  
                                                     where a.pact_code = '{0}'";
        /// <summary>
        /// 居民医保标识
        /// </summary>
        public static string GetJMSql = @"select count(*)
                                                                   from fin_ipr_siinmaininfo a
                                                                  where a.pact_code = '05'
                                                                    and a.person_type = '41'
                                                                    and a.inpatient_no = '{0}'";
        /// <summary>
        /// 大病医保标识
        /// </summary>
        public static string GetDBSql = @"select count(*)
                                                                  from fin_ipr_siinmaininfo t
                                                                 where t.pact_code = '13'
                                                                   and t.applysequence not in ('0', '1')
                                                                   and t.inpatient_no = '{0}'";
       /// <summary>
       /// 警戒线类别
       /// </summary>
        public static string GetType = @"select a.alter_type from fin_ipr_inmaininfo a where a.inpatient_no = '{0}'";
        #region 判断是否大病 added by xizf@neusoft.com 20110411
        /// <summary>
        /// 是否大病{2F7096E9-7DF9-484a-B31D-EADBF6379810} 
        /// </summary>
        ///{BB1F54A1-4804-4bba-86B7-FE3EED26726C} 修正判断是否大病的sql
        public static string GetIsNcum = @"SELECT AA. APPLYSEQUENCE
  FROM (SELECT B.APPLYSEQUENCE
          FROM FIN_IPR_SIINMAININFO B
         WHERE B.INPATIENT_NO = '{0}'
           AND B.VALID_FLAG = 1
           AND B.TOT_COST != 0
         ORDER BY B.BALANCE_NO DESC) AA
 WHERE  ROWNUM <= 1";
        #endregion

        #region 获取定额总费用{1C0082F2-84D6-4770-9BB2-76BF772FA615}
        public static string GetDeCost = @"select b.tot_cost
  from fin_ipr_siinmaininfo b
 where b.inpatient_no = '{0}'
   and b.valid_flag = 1
   and b.tot_cost != 0
   and b.balance_state = 1
   and rownum<=1";
        #endregion
        /// <summary>
        /// 获取结算前总费用
        /// </summary>
        public static string GetDeUnBalCost = @"select b.tot_cost
  from fin_ipr_siinmaininfo b
 where b.inpatient_no = '{0}'
   and b.valid_flag = 1
   and b.tot_cost != 0
   and b.balance_state = 0
   and rownum<=1";
        /// <summary>
        /// 更新警戒线
        /// </summary>
        public static string UpdateMoneyAlertSQL = @"update fin_ipr_inmaininfo b
   set b.money_alert = -round(b.prepay_cost * {1}/{2}) where  b.inpatient_no = '{0}'";
        /// <summary>
        ///根据合同单位获取欠费比例
        /// </summary>
        /// <param name="pactId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        
        public int GetMoneyAlertLimit(string pactId,ref Neusoft.FrameWork.Models.NeuObject obj) {
            string sql = string.Empty;
            try
            {
                sql = string.Format(Components.InpatientFee.Sql.GetMoneyAlertSql, pactId);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL失败";
                return -1;
            }
            DataSet ds = new DataSet();
            this.ExecQuery(sql, ref ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    obj.ID = row.ItemArray.GetValue(0).ToString();//欠费分子
                    obj.Name = row.ItemArray.GetValue(1).ToString();//欠费分母
                    obj.User01 = row.ItemArray.GetValue(2).ToString();//备用
                    
                }
            }
            else {
                this.Err = "没有找到该合同单位的相关欠费比例信息";
                return -1;
            }
            return 1;
        }
        /// <summary>
        ///获取定额总费用{1C0082F2-84D6-4770-9BB2-76BF772FA615}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public string GetDeTot(string inpatientNO) {
            string sql = Components.InpatientFee.Sql.GetDeCost;
            try
            {
                sql = string.Format(sql, inpatientNO);
            }
            catch (Exception)
            {

                this.Err = "格式化SQL出错";
            }
            return this.ExecSqlReturnOne(sql);
        }
        /// <summary>
        /// 获取结算前总费用
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public string GetDeUnbalTot(string inpatientNO)
        {
            string sql = Components.InpatientFee.Sql.GetDeUnBalCost;
            try
            {
                sql = string.Format(sql, inpatientNO);
            }
            catch (Exception)
            {

                this.Err = "格式化SQL出错";
            }
            return this.ExecSqlReturnOne(sql);
        }
        /// <summary>
        /// 是否大病 {2F7096E9-7DF9-484a-B31D-EADBF6379810} 
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public bool isNcum(string inpatientNO) {
            string sql = string.Empty;
            bool isNcum = false;
            sql = Components.InpatientFee.Sql.GetIsNcum;
            try
            {
                sql = string.Format(sql, inpatientNO);
            }
            catch (Exception e) 
            {
                
                this.Err = "格式化SQL出错";
            }
            string temp = this.ExecSqlReturnOne(sql);
            ArrayList al = new ArrayList();
            //特殊补偿标识:11~17的为先天性心脏病
            for (int i = 11; i <= 16; i++)
            {
                al.Add(i);
            }
            foreach (int i in al) {
                if (i.ToString() == temp) {
                    isNcum = true;
                }
            }
            return isNcum;
        }
        /// <summary>
        /// 是否六种儿童大病
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public bool isNcumExt(string inpatientNO)
        {
            string sql = string.Empty;
            bool isNcum = false;
            sql = Components.InpatientFee.Sql.GetIsNcum;
            try
            {
                sql = string.Format(sql, inpatientNO);
            }
            catch (Exception e)
            {

                this.Err = "格式化SQL出错";
            }
            string temp = this.ExecSqlReturnOne(sql);
            if (temp != "0" && temp != "1") {
                isNcum = true;
            }
            return isNcum;
        }
        /// <summary>
        /// 是否居民或大病,false 不是该两种类型
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public bool isJM(string inpatientNo,string kind) {
            string sql = string.Empty;
            try
            {
                if ("05" == kind)//市医保判断居民
                {
                    sql = string.Format(Components.InpatientFee.Sql.GetJMSql, inpatientNo);
                }
                else {//新农合判断大病
                    sql = string.Format(Components.InpatientFee.Sql.GetDBSql, inpatientNo);
                }
                

            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL出错";
            }
            if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql)) == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }
        /// <summary>
        /// 更新警戒线
        /// </summary>
        /// <param name="NO"></param>
        /// <param name="fz"></param>
        /// <param name="fm"></param>
        /// <returns></returns>
        public int UpdateMoneyAlertByPatientNO(string NO,int fz,int fm) {
            string sql = string.Empty;
            try
            {
                sql = string.Format(Components.InpatientFee.Sql.UpdateMoneyAlertSQL, NO, fz, fm);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL出错";
            }
            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 获取警戒线类别
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public string isMtype(string inpatientNo)
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format(Components.InpatientFee.Sql.GetType, inpatientNo);

            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL出错";
            }
            return this.ExecSqlReturnOne(sql)+" ";
        }

    }
}
