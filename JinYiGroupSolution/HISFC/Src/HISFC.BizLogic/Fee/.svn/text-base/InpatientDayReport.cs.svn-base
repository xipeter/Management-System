using System;
using System.Data;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// InpatientDayReport<br></br>
    /// [功能描述: 住院日结业务类]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-09-26]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
   public class InpatientDayReport : Neusoft.FrameWork.Management.Database
    {
        #region "私有方法"

        #region "单表更新操作"
        /// <summary>
        /// 更新单表操作
        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: >= 1 失败 -1 没有更新到数据 0</returns>
        private int UpdateSingleTable(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, args);
        }

        /// <summary>
        /// 获得日结属性字符串数组
        /// </summary>
        /// <param name="dayReport">日结信息实体</param>
        /// <returns>成功: 日结属性字符串数组 失败: null</returns>
        private string[] GetDayReportParams(Neusoft.HISFC.Models.Fee.DayReport dayReport)
        {
 
            string[] args ={

               //统计序号
                dayReport.StatNO,

               //开始时间

                dayReport.BeginDate.ToString(),
               //结束日期
                dayReport.EndDate.ToString(),

               //操作员代码

               dayReport.Oper.ID,
               //统计时间
               dayReport.Oper.OperTime.ToString(),

               //收取预交金金额

                dayReport.PrepayCost.ToString(),
               //贷方支票金额

                dayReport.DebitCheckCost.ToString(),
               //贷方银行卡金额

                dayReport.DebitBankCost.ToString(),
               //结算预交金金额

                dayReport.BalancePrepayCost.ToString(),
               //借方支票金额

                dayReport.LenderCheckCost.ToString(),
               //借方银行卡金额

                dayReport.LenderBankCost.ToString(),
               //公费记帐金额
                dayReport.BursaryPubCost.ToString(),
               //市医保帐户支付金额

                dayReport.CityMedicarePayCost.ToString(),
               //市医保统筹金额

                dayReport.CityMedicarePubCost.ToString(),
               //省医保帐户支付金额

                dayReport.ProvinceMedicarePayCost.ToString(),
               //省医保统筹金额

                dayReport.ProvinceMedicarePubCost.ToString(),
               //库存金额（上缴金额）
                dayReport.TurnInCash.ToString(),
               //预交金发票张数

                dayReport.PrepayInvCount.ToString(),
               //结算发票张数
                dayReport.BalanceInvCount.ToString(),
               //作废预交金发票号码

                dayReport.PrepayWasteInvNO,
               //作废结算发票号码
                dayReport.BalanceWasteInvNO,
               //作废预交金发票张数

                dayReport.PrepayWasteInvCount.ToString(),
               //作废结算发票张数
                dayReport.BalanceWasteInvCount.ToString(),
               //预交金发票区间

                dayReport.PrepayInvZone,
               //结算发票区间
                dayReport.BalanceInvZone,
               //收费员科室

                dayReport.Oper.Dept.ID,
                //结算总金额

                dayReport.BalanceCost.ToString()
						   };

            return args;
        }

        #endregion


        /// <summary>
        /// 获取检索fin_ipb_dayReport的全部数据的sql
        /// </summary>
        /// <returns>成功: 返回SQL语句 失败 null</returns>
        private string GetSqlForSelectAllDayReport()
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.InpatientDayReport.GetDayReportAllInfo", ref strSql) == -1)
            {
                this.Err = "找不到Sql语句Fee.FeeReport.GetDayReortInfo";
                return null;
            }
            return strSql;
        }

        /// <summary>
        /// 根据SQL查询日结信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回住院日结实体集合 失败 null</returns>
        private ArrayList QueryDayReportsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList alDayReport = new ArrayList();//日结集合
            DayReport dayReport = null;//日结实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    dayReport = new DayReport();

                    //统计序号
                    dayReport.StatNO = this.Reader[0].ToString();

                   //开始时间

                    dayReport.BeginDate =Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString());
                   //结束日期
                    dayReport.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());

                   //操作员代码

                   dayReport.Oper.ID = this.Reader[3].ToString();
                   //统计时间
                   dayReport.Oper.OperTime  =Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());

                   //收取预交金金额

                    dayReport.PrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                   //借方支票金额

                    dayReport.DebitCheckCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString());
                    //借方银行卡金额

                    dayReport.DebitBankCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
                   //结算预交金金额

                    dayReport.BalancePrepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString());
                   //贷方支票金额

                    dayReport.LenderCheckCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
                    //贷方银行卡金额

                    dayReport.LenderBankCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());
                   //公费记帐金额
                    dayReport.BursaryPubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString());
                   //市医保帐户支付金额

                    dayReport.CityMedicarePayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString());
                   //市医保统筹金额

                    dayReport.CityMedicarePubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString());
                   //省医保帐户支付金额

                    dayReport.ProvinceMedicarePayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14].ToString());
                   //省医保统筹金额

                    dayReport.ProvinceMedicarePubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15].ToString());
                   //库存金额（上缴金额）
                    dayReport.TurnInCash = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
                   //预交金发票张数

                    dayReport.PrepayInvCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[17].ToString());
                   //结算发票张数
                    dayReport.BalanceInvCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[18].ToString());
                   //作废预交金发票号码

                    dayReport.PrepayWasteInvNO = this.Reader[19].ToString();
                   //作废结算发票号码
                    dayReport.BalanceWasteInvNO = this.Reader[20].ToString();
                   //作废预交金发票张数

                    dayReport.PrepayWasteInvCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[21].ToString());
                   //作废结算发票张数
                    dayReport.BalanceWasteInvCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[22].ToString());
                   //预交金发票区间

                    dayReport.PrepayInvZone = this.Reader[23].ToString();
                   //结算发票区间
                    dayReport.BalanceInvZone = this.Reader[24].ToString();
                   //收费员科室

                    dayReport.Oper.Dept.ID = this.Reader[25].ToString();
                    dayReport.BalanceCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString());

                    alDayReport.Add(dayReport);
                }//循环结束

                this.Reader.Close();

                return alDayReport;
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 通过Where条件查询日结信息
        /// </summary>
        /// <param name="whereIndex">Where条件</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回日结实体集合 失败 null</returns>
        private ArrayList QueryDayReports(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectAllDayReport();

            return this.QueryDayReportsBySql(sql + " " + where, args);
        }


        #endregion

        #region "共有方法"

        /// <summary>
        /// 获日结统计序号

        /// </summary>
        /// <returns></returns>
        public string GetNewDayReportID()
        {
            string sql = "";
            if (this.Sql.GetSql("Fee.FeeReport.DayReport.GetID", ref sql) == -1) return null;
            string strReturn = this.ExecSqlReturnOne(sql);
            if (strReturn == "-1" || strReturn == "") return null;
            return strReturn;
        }

        /// <summary>
        /// 插入日结信息
        /// </summary>
        /// <param name="dayReport">日结信息实体</param>
        /// <returns>成功: 1 失败 -1 没有插入数据 0</returns>
         public int InsertDayReport(Neusoft.HISFC.Models.Fee.DayReport dayReport)
        {
            return this.UpdateSingleTable("Fee.InpatientDayReport.InsertDayReport", this.GetDayReportParams(dayReport));
        }

        /// <summary>
        /// 获取操作员时间段内实收日报实体

        /// </summary>
        /// <param name="operID">操作员编码</param>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public ArrayList GetDayReportInfosForOper(string operID,DateTime dtBegin,DateTime dtEnd)
        {
            string[] args = 
                {
                    operID,
                    dtBegin.ToString(),
                    dtEnd.ToString()
                };
            return this.QueryDayReports("Fee.InpatientDayReport.GetDayReportInfosForOper", args);
           
        }
       /// <summary>
       /// 获取操作员最后一次日结信息

       /// </summary>
       /// <param name="operID">操作员ID</param>
       /// <returns>成功 返回日结信息实体 失败 null</returns>
       public DayReport GetOperLastDayReport(string operID)
       {
           ArrayList alDayReport = new ArrayList();

           alDayReport = this.QueryDayReports("Fee.InpatientDayReport.GetOperLastDayReport", operID);

           if (alDayReport == null || alDayReport.Count == 0)
           {
               return null;
           }
           return (DayReport)alDayReport[0];
       }

       #region 获取日结各项金额
       /// <summary>
       /// 获取一段时间范围内操作员收取预交金总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetPrepayCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string prepayCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结收取预交金金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           prepayCost = this.ExecSqlReturnOne(sql);

           return prepayCost;
       }


       /// <summary>
       /// 获取一段时间范围内操作员结算预交金总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetBalancedPrepayCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string prepayCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetBalancedPrepayCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结结算预交金总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           prepayCost = this.ExecSqlReturnOne(sql);

           return prepayCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员预交金现金总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetPrepayCashCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string prepayCashCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayCashCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结预交金现金金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           prepayCashCost = this.ExecSqlReturnOne(sql);

           return prepayCashCost;
       }


       /// <summary>
       /// 获取一段时间范围内操作员预交金支票总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetPrepayCheckCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string prepayCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayCheckCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           prepayCost = this.ExecSqlReturnOne(sql);

           return prepayCost;
       }


       /// <summary>
       /// 获取一段时间范围内操作员预交金银行卡总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetPrepayBankCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string prepayBankCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayBankCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结银行卡金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           prepayBankCost = this.ExecSqlReturnOne(sql);

           return prepayBankCost;
       }


       /// <summary>
       /// 获取一段时间范围内操作员结算费用总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetBalancedCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string balanceCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetBalancedCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结结算总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           balanceCost = this.ExecSqlReturnOne(sql);

           return balanceCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员补收结算支票结算费用总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetSupplyCheckCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string supplyCheckCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetSupplyCheckCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结补收结算支票结算总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           supplyCheckCost = this.ExecSqlReturnOne(sql);

           return supplyCheckCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员返还结算支票结算费用总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetReturnCheckCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string returnCheckCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetReturnCheckCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结返还结算支票结算总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           returnCheckCost = this.ExecSqlReturnOne(sql);

           return returnCheckCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员补收现金总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetSupplyCashCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string supplyCashCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetSupplyCashCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结补收结算现金总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           supplyCashCost = this.ExecSqlReturnOne(sql);

           return supplyCashCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员返还现金总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetReturnCashCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string returnCashCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetReturnCashCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结返还现金总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           returnCashCost = this.ExecSqlReturnOne(sql);

           return returnCashCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员补收一卡通总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetSupplyBankCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string supplyBankCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetSupplyBankCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结补收结算一卡通结算总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           supplyBankCost = this.ExecSqlReturnOne(sql);

           return supplyBankCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员返还银行卡总额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetReturnBankCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string returnBankCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetReturnBankCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获得日结返还银行卡总金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           returnBankCost = this.ExecSqlReturnOne(sql);

           return returnBankCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算费用公费记帐金额

       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetBursaryCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string bursaryPubCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetBursaryCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算费用公费记帐金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           bursaryPubCost = this.ExecSqlReturnOne(sql);

           return bursaryPubCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算费用市医保帐户金额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetCPayCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string payCost = "";
           string sql = "";

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetCPayCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算费用市医保帐户金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           payCost = this.ExecSqlReturnOne(sql);

           return payCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算费用市医保统筹金额
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员</param>
       /// <returns></returns>
       public string GetCPubCostByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string pubCost = "";
           string sql = ""; 

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetCPubCostByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算费用市医保统筹金额出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           pubCost = this.ExecSqlReturnOne(sql);

           

           return pubCost;
       }

       /// <summary>
       /// 获取一段时间范围内操作员预交金有效张数
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns></returns>
       public string GetValidPrepayInvoiceQtyByOperIDAndTime(DateTime beginDate,DateTime endDate,string operID)
       {
           string qty = "";
           string sql = "";
           if (this.Sql.GetSql("Fee.InpatientDayReport.GetValidPrepayInvoiceQtyByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员预交金有效张数出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           qty = this.ExecSqlReturnOne(sql);


           return qty;
       }

       /// <summary>
       /// 获取一段时间范围内操作员预交金作废张数
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns></returns>
       public string GetWastePrepayInvoiceQtyByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string qty = "";
           string sql = "";
           if (this.Sql.GetSql("Fee.InpatientDayReport.GetWastePrepayInvoiceQtyByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员预交金有效张数出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           qty = this.ExecSqlReturnOne(sql);


           return qty;
       }
       /// <summary>
       /// 获取一段时间范围内操作员预交金票据区间 
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns>返回object ID最小号 name最大号</returns>
       public Neusoft.FrameWork.Models.NeuObject GetPrepayInvoiceZoneByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string sql = string.Empty;
           Neusoft.FrameWork.Models.NeuObject prepayInvoiceZone = new Neusoft.FrameWork.Models.NeuObject();

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayInvoiceZoneByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员预交金有效张数出错!";
               return null;
           }
           sql = string.Format(sql, beginDate, endDate, operID);

           if (this.ExecQuery(sql)== -1)
           {
               return null;
           }
           while (this.Reader.Read())
           {
               prepayInvoiceZone.ID = this.Reader[0].ToString();
               prepayInvoiceZone.Name = this.Reader[1].ToString();
           }
           this.Reader.Close();

           return prepayInvoiceZone;


       }
       /// <summary>
       /// 获取一段时间范围内操作员预交金票据作废票号
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns>作废票号数组，失败返回null</returns>
       public ArrayList QueryWastePrepayInvNOByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string sql = string.Empty;
           ArrayList alPrepayInv = new ArrayList();
           Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay;

           if (this.Sql.GetSql("Fee.InpatientDayReport.QueryWastePrepayInvNOByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员预交金票据作废票号出错!";
               return null;
           }
           sql = string.Format(sql, beginDate, endDate, operID);

           if (this.ExecQuery(sql) == -1)
           {
               return null;
           }
           while (this.Reader.Read())
           {
               prepay = new Prepay();
               prepay.RecipeNO = this.Reader[0].ToString();
               alPrepayInv.Add(prepay);
           }
           this.Reader.Close();

           return alPrepayInv;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算有效张数

       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns></returns>
       public string GetValidBalanceInvoiceQtyByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string qty = "";
           string sql = "";
           if (this.Sql.GetSql("Fee.InpatientDayReport.GetValidBalanceInvoiceQtyByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算有效张数出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           qty = this.ExecSqlReturnOne(sql);


           return qty;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算作废张数

       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns></returns>
       public string GetWasteBalanceInvoiceQtyByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string qty = "";
           string sql = "";
           if (this.Sql.GetSql("Fee.InpatientDayReport.GetWasteBalanceInvoiceQtyByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算作废张数出错!";
               return "";
           }
           sql = string.Format(sql, beginDate, endDate, operID);
           qty = this.ExecSqlReturnOne(sql);


           return qty;
       }

       /// <summary>
       /// 获取一段时间范围内操作员结算票据区间 
       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns>返回object ID最小号 name最大号</returns>
       public Neusoft.FrameWork.Models.NeuObject GetBalanceInvoiceZoneByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string sql = string.Empty;
           Neusoft.FrameWork.Models.NeuObject BalanceInvoiceZone = new Neusoft.FrameWork.Models.NeuObject() ;

           if (this.Sql.GetSql("Fee.InpatientDayReport.GetBalanceInvoiceZoneByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算票据区间出错!";
               return null;
           }
           sql = string.Format(sql, beginDate, endDate, operID);

           if (this.ExecQuery(sql) == -1)
           {
               return null;
           }
           while (this.Reader.Read())
           {
               
               BalanceInvoiceZone.ID = this.Reader[0].ToString();
               BalanceInvoiceZone.Name = this.Reader[1].ToString();
           }
           this.Reader.Close();

           return BalanceInvoiceZone;


       }

       /// <summary>
       /// 获取一段时间范围内操作员结算票据作废票号

       /// </summary>
       /// <param name="beginDate">开始时间</param>
       /// <param name="endDate">结束时间</param>
       /// <param name="operID">操作员代码</param>
       /// <returns>作废票号数组，失败返回null</returns>
       public ArrayList QueryWasteBalanceInvNOByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
       {
           string sql = string.Empty;
           ArrayList alWasteBalanceInv = new ArrayList();
           Neusoft.HISFC.Models.Fee.Inpatient.Balance balance;

           if (this.Sql.GetSql("Fee.InpatientDayReport.QueryWasteBalanceInvNOByOperIDAndTime", ref sql) == -1)
           {
               this.Err = "获取操作员结算票据作废票号出错!";
               return null;
           }
           sql = string.Format(sql, beginDate, endDate, operID);

           if (this.ExecQuery(sql) == -1)
           {
               return null;
           }
           while (this.Reader.Read())
           {
               balance = new Balance();
               balance.Invoice.ID = this.Reader[0].ToString();
               alWasteBalanceInv.Add(balance);
           }
           this.Reader.Close();

           return alWasteBalanceInv;
       }
       #endregion
      

        #endregion

     
    }
}
