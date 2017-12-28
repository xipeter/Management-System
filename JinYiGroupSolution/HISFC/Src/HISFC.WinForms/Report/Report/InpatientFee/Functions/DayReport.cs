using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Base;
using System.Data;

namespace Neusoft.WinForms.Report.InpatientFee.Functions
{
     public class DayReport : Neusoft.FrameWork.Management.Database
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
            Class.DayReport dayReport = null;//日结实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();

                    //统计序号
                    dayReport.StatNO = this.Reader[0].ToString();

                    //开始时间

                    dayReport.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString());
                    //结束日期
                    dayReport.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());

                    //操作员代码

                    dayReport.Oper.ID = this.Reader[3].ToString();
                    //统计时间
                    dayReport.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());

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
        public ArrayList GetDayReportInfosForOper(string operID, DateTime dtBegin, DateTime dtEnd)
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
        public Class.DayReport GetOperLastDayReport(string operID)
        {
            ArrayList alDayReport = new ArrayList();

            alDayReport = this.QueryDayReports("Fee.InpatientDayReport.GetOperLastDayReport", operID);

            if (alDayReport == null || alDayReport.Count == 0)
            {
                return null;
            }
            return (Class.DayReport)alDayReport[0];
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
        public string GetValidPrepayInvoiceQtyByOperIDAndTime(DateTime beginDate, DateTime endDate, string operID)
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

            if (this.ExecQuery(sql) == -1)
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

        #region 预交金票据区间 luoff
         /// <summary>
         /// 获取预交金票据区间
         /// </summary>
         /// <param name="beginTime">开始时间</param>
         /// <param name="endTime">结束时间</param>
         /// <param name="operID">操作员代码</param>
         /// <param name="dsResult">返回数据集</param>
         /// <returns>1：成功，-1：失败</returns>
         public int GetPrepayInvoiceZoneNew(DateTime beginTime, DateTime endTime, string operID, ref DataSet dsResult)
         {
             string SQL = string.Empty;
             if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayInvoiceZoneNew", ref SQL) == -1)
             {
                 this.Err = "查找sql语句失败！";
                 return -1;
             }
             try
             {
                 SQL = string.Format(SQL, beginTime.ToString(), endTime.ToString(), operID);
             }
             catch (Exception ex)
             {
                 this.Err = ex.Message;
                 return -1;
             }
             if (this.ExecQuery(SQL, ref dsResult) == -1)
             {
                 this.Err = "执行查询语句出错！";
                 return -1;
             }
             return 1;
         }

        #endregion

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
            Neusoft.FrameWork.Models.NeuObject BalanceInvoiceZone = new Neusoft.FrameWork.Models.NeuObject();

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

        #region 获取结算票据区间 luoff
         /// <summary>
         /// 获取一段时间范围内操作员结算票据区间
         /// </summary>
         /// <param name="beginTime">开始时间</param>
         /// <param name="endTime">结束时间</param>
         /// <param name="operID">操作员代码</param>
         /// <param name="dsResult">返回数据集</param>
         /// <returns>1：成功/-1：失败</returns>
         public int GetBalanceInvoiceZoneNew(DateTime beginTime, DateTime endTime, string operID, ref DataSet dsResult)
         {
             string sql = string.Empty;
             if (this.Sql.GetSql("Fee.InpatientDayReport.GetBalanceInvoiceZoneNew", ref sql) == -1)
             {
                 this.Err = "获取操作员结算票据区间出错！";
                 return -1;
             }
             try
             {
                 sql = string.Format(sql, beginTime.ToString(), endTime.ToString(), operID);
             }
             catch (Exception ex)
             {
                 this.Err = ex.Message;
                 return -1;
             }
             if (this.ExecQuery(sql, ref dsResult) == -1)
             {
                 this.Err = "执行操作员票据区间查询语句出错！";
                 return -1;
             }
             return 1;
         }
        #endregion

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

        #region 日结新的项目金额

        /// <summary>
        /// 查找日结项目明细
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="OperID">操作员编码</param>
        /// <returns>null：失败 NOTNULL成功</returns>
        public DataSet GetDayReportItem(DateTime beginDate, DateTime endDate, string OperID)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Local.Report.InpatientDayREport.SelectDayReportItem", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                sqlStr = string.Format(sqlStr, OperID, beginDate.ToString(), endDate.ToString());
            }
            catch (Exception ex)
            {

                this.Err = "格式化SQL语句失败！" + ex.Message;
                return null;
            }
            DataSet ds = new DataSet();
            if (this.ExecQuery(sqlStr, ref ds) == -1)
            {
                this.Err = "查找数据失败！";
                return null;
            }
            return ds;
        }

        #region 统计大类项目明细 luoff
         /// <summary>
         /// 查找统计大类项目明细
         /// </summary>
         /// <param name="begionTime">开始时间</param>
         /// <param name="endTime">结束时间</param>
         /// <param name="operID">操作员代码</param>
         /// <returns>失败返回null,成功notnull</returns>
         public DataSet GetDayReportItemZYRJ(DateTime begionTime, DateTime endTime, string operID)
         {
             string sqlStr = string.Empty;
             if (this.Sql.GetSql("Local.Report.InpatientDayReport.SelectDayReportItemZYRJ", ref sqlStr) == -1)
             {
                 this.Err = "查找sql语句失败！";
                 return null;
             }
             try
             {
                 sqlStr = string.Format(sqlStr, operID, begionTime.ToString(), endTime.ToString());
             }
             catch (Exception ex)
             {
                 this.Err = "格式化sql语句失败！" + ex.Message;
                 return null;
             }
             DataSet ds = new DataSet();
             if (this.ExecQuery(sqlStr, ref ds) == -1)
             {
                 this.Err = "查找数据失败！";
                 return null;
             }
             return ds;
         }
        #endregion

        /// <summary>
        /// 获取医疗预收款明细
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="OperID">操作员编码</param>
        /// <param name="aMod">0:借方 1：贷方</param>
        /// <returns>DataTable</returns>
        public System.Data.DataSet GetLenderPrePayDetail(DateTime beginDate, DateTime endDate, string OperID, int aMod)
        {
            string sqlStr = string.Empty;
            string sqlIndex = string.Empty;
            if (aMod == 0)
            {
                sqlIndex = "Fee.InpatientDayReport.GetPrepayDetail";
            }
            else
            {
                sqlIndex = "Local.Report.InpatientDayReprot.SelectPrePayDetail";
            }
            if (this.Sql.GetSql(sqlIndex, ref sqlStr) == -1)
            {
                this.Err = "查找SELECT语句失败！";
                return null;
            }
      
            try
            {
                sqlStr = string.Format(sqlStr, OperID, beginDate, endDate);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return null;
            }
            DataSet ds = new DataSet();
            if (this.ExecQuery(sqlStr, ref ds) == -1)
            {
                this.Err = "查询数据失败！";
                return null;
            }
            return ds;
        }
        
        /// <summary>
        /// 获取汇总时医疗预收款明细
        /// </summary>
        /// <param name="list">日结实体集合</param>
        /// <param name="aMod">0：借1：贷</param>
        /// <returns></returns>
        public DataSet GetLenderPrePayDetail(List<Class.DayReport> list, int aMod)
        {
            string sqlStr = string.Empty;
            string sqlIndex = string.Empty;
            string execSql = string.Empty;
            if (aMod == 1)
            {
                sqlIndex = "Local.Report.InpatientDayReprot.SelectPrePayDetail";
            }
            else
            {
                sqlIndex = "Fee.InpatientDayReport.GetPrepayDetail";
            }
            if (this.Sql.GetSql(sqlIndex, ref sqlStr) == -1)
            {
                this.Err = "查找SELECT语句失败！";
                return null;
            }
           
            try
            {               
                string tempStr = sqlStr;
                foreach (Class.DayReport dayReport in list)
                {
                    sqlStr = string.Format(tempStr, dayReport.Oper.ID, dayReport.BeginDate.ToString(), dayReport.EndDate.ToString());
                    execSql +=" " + sqlStr + " " + "union all";
                }
                execSql = execSql.Substring(0, execSql.LastIndexOf("union all"));
            }
            catch (Exception ex)
            {
                this.Err = "查找数据失败！"+ex.Message;
                return null;
            }
            DataSet ds=new DataSet();
            if (this.ExecQuery(execSql, ref ds) == -1)
            {
                this.Err = "查找数据失败！";
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 查找医疗应收款明细
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="OperID">操作员</param>
        /// <returns></returns>
        public DataSet GetLenderPayDetail(DateTime beginDate, DateTime endDate, string OperID)
        {
            string sqlStr = string.Empty;
            string whereStr = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayDetail", ref sqlStr) == -1)
            {
                this.Err = "查找SELECT语句失败！";
                return null;
            }
            try
            {
                sqlStr = string.Format(sqlStr, OperID, beginDate, endDate);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return null;
            }
            DataSet ds = new DataSet();
            if (this.ExecQuery(sqlStr, ref ds) == -1)
            {
                this.Err = "查询数据失败！";
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 查找汇总时医疗应收款明细
        /// </summary>
        ///<param name="list">日结实体集合</param>
        /// <returns></returns>
        public DataSet GetLenderPayDetail(List<Class.DayReport> list)
        {
            string sqlStr = string.Empty;
            string execSql = string.Empty;
            
            if (this.Sql.GetSql("Fee.InpatientDayReport.GetPrepayDetail", ref sqlStr) == -1)
            {
                this.Err = "查找SELECT语句失败！";
                return null;
            }

            try
            {
                string tempStr = sqlStr;
                foreach (Class.DayReport dayReport in list)
                {
                    sqlStr = string.Format(tempStr, dayReport.Oper.ID, dayReport.BeginDate.ToString(), dayReport.EndDate.ToString());
                    execSql += " " + sqlStr + " " + "union all";
                }
                execSql = execSql.Substring(0, execSql.LastIndexOf("union all"));
            }
            catch (Exception ex)
            {
                this.Err = "查找数据失败！" + ex.Message;
                return null;
            }
            DataSet ds = new DataSet();
            if (this.ExecQuery(execSql, ref ds) == -1)
            {
                this.Err = "查找数据失败！";
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 查找省、市医保支付
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">操作员编码</param>
        /// <returns></returns>
        public DataSet GetDayReportProtectPay(DateTime beginDate, DateTime endDate, string OperID)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Local.Clinic.GetProtectMoney", ref sqlStr) == -1)
            {
                this.Err = "查找SQL失败！";
                return null;
            }
            try
            {
                //1、门诊数据　2、住院数据
                sqlStr = string.Format(sqlStr, OperID, beginDate.ToString(), endDate.ToString(),"2");
            }
            catch
            {
                this.Err = "格式化SQL语句失败！";
                return null;
            }
            DataSet ds = new DataSet();
            if (this.ExecQuery(sqlStr, ref ds) == -1)
            {
                this.Err = "查找数据失败！";
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 按照时间段和收费员编码查找单个金额
        /// </summary>
        /// <param name="stringIndex">SQL语句Index</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收费员编码</param>
        /// <returns></returns>
        private string GetSingleCost(string stringIndex, DateTime beginDate, DateTime endDate, string OperID)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql(stringIndex, ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return string.Empty;
            }
            try
            {
                sqlStr = string.Format(sqlStr, OperID, beginDate.ToString(), endDate.ToString());
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return string.Empty;
            }
            return this.ExecSqlReturnOne(sqlStr);
        }

        /// <summary>
        /// 查找医疗应收款
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetLenderPay(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetLenderPayCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 医疗减免金额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="OperID">操作员编码</param>
        /// <returns></returns>
        public string GetDayReportDerCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Local.Report.InpatientDayReport.SelectDerCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员预交金银行卡总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetPrepayBankCardCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetPrepayBankCardCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员院内帐户总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetYSCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetYSCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员结算补收院内帐户总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetSupplyYSCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetSupplyYSCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员退还院内帐户总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetReturnYSCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetReturnYSCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员其它预收总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetOtherPrepayCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetOtherPrePayCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员结算补收其它预收总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetSupplyOtherPrePayCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetSupplyOtherPrePayCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 获取一段时间范围内操作员退还其它预收总额
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">收款员编码</param>
        /// <returns></returns>
        public string GetReturnOtherPrePayCost(DateTime beginDate, DateTime endDate, string OperID)
        {
            return this.GetSingleCost("Fee.InpatientDayReport.GetReturnOtherPrePayCost", beginDate, endDate, OperID);
        }

        /// <summary>
        /// 插入住院日结报表
        /// </summary>
        /// <param name="dayReport">日结报表实体</param>
        /// <returns>1:成功 -1 失败</returns>
        public int InsertDayReport(Class.DayReport dayReport)
        { 
            return this.UpdateSingleTable("Fee.InpatientDayReport.InsertDayReport1",this.GetInsertDayReportargs(dayReport));
        }

        /// <summary>
        /// 获得日结属性字符串数组
        /// </summary>
        /// <param name="dayReport">日结实体</param>
        /// <returns></returns>
        private string[] GetInsertDayReportargs(Class.DayReport dayReport)
        {
            string[] arrayStr = {
                dayReport.StatNO.ToString(),//统计序号
                dayReport.BeginDate.ToString(),//开始时间
                dayReport.EndDate.ToString(),//结束日期
                dayReport.Oper.ID,//操作员代码
                dayReport.Oper.OperTime.ToString(),
                dayReport.PrepayCost.ToString(),//医疗预收款贷方
                dayReport.DebitCheckCost.ToString(),//借方支票(银行存款借方)
                dayReport.DebitBankCost.ToString(),//借方银行卡
                dayReport.BalancePrepayCost.ToString(),//医疗预收款借方
                dayReport.LenderCheckCost.ToString(),//贷方支票(银行存款贷方)
                dayReport.LenderBankCost.ToString(),//贷方银行卡
                dayReport.BursaryPubCost.ToString(),//公费记帐金额
                dayReport.CityMedicarePayCost.ToString(),//市医保帐户支付金额
                dayReport.CityMedicarePubCost.ToString(),//市医保统筹金额
                dayReport.ProvinceMedicarePayCost.ToString(),//省医保帐户支付金额
                dayReport.ProvinceMedicarePubCost.ToString(),//省医保统筹金额
                dayReport.PrepayInvCount.ToString(),//预交金发票张数
                dayReport.BalanceInvCount.ToString(),//结算发票张数
                dayReport.PrepayWasteInvNO,//作废预交金发票号码
                dayReport.BalanceWasteInvNO,//作废结算发票号码
                dayReport.PrepayWasteInvCount.ToString(),//作废预交金发票张数
                dayReport.BalanceWasteInvCount.ToString(),//作废结算发票张数
                dayReport.PrepayInvZone,//预交金发票区间,
                dayReport.BalanceInvZone,//结算发票区间
                dayReport.BalanceCost.ToString(),//医疗应收款(结算总金额)
                dayReport.DebitHos.ToString(),//院内账户借方
                dayReport.LenderHos.ToString(),//院内账户贷方
                dayReport.DebitOther.ToString(),//借方其它
                dayReport.LenderOther.ToString(),//贷方其它
                dayReport.DerateCost.ToString(),//减免金额
                dayReport.CityMedicareOverCost.ToString(),//市保大额
                dayReport.ProvinceMedicareOverCost.ToString(),//省保大额
                dayReport.ProvinceMedicareOfficeCost.ToString(),//省保公务员
                dayReport.DebitCash.ToString(),//库存现金借方
                dayReport.LenderCash.ToString()};//库存现金贷方
            return arrayStr;
        }

        /// <summary>
        /// 插入日结明细
        /// </summary>
        /// <param name="dayReport">日结实体</param>
        /// <returns>1:成功 -1：失败</returns>
        public int InsetDayReportDetail(Class.DayReport dayReport)
        {
            string Sqlstr = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.InsertDayReportDetail", ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                int resultValue = 0;
                string ExecSql = string.Empty;
                foreach (Class.Item item in dayReport.ItemList)
                {
                    ExecSql = string.Format(Sqlstr,
                                        dayReport.StatNO,//统计序号
                                        dayReport.BeginDate.ToString(),//开始时间
                                        dayReport.EndDate.ToString(),//结束时间
                                        dayReport.Oper.ID,
                                        item.StateCode,//统计大类
                                        item.TotCost,//费用金额
                                        item.OwnCost,//自费金额
                                        item.PayCost,//自付医疗
                                        item.PubCost,//公费医疗
                                        item.Mark);//备注
                    resultValue = this.ExecNoQuery(ExecSql);
                    if (resultValue == -1)
                        return -1;
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "插入日结明细失败" + ex.Message;
                return -1;
            }

        }

        /// <summary>
        /// 查找日结数据信息
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">操作员</param>
        /// <returns></returns>
        public List<Class.DayReport> SelectDayReprotInfo(DateTime beginDate, DateTime endDate, string OperID)
        {
            string Sqlstr = string.Empty;
            string SqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryDayReportInfo", ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryDayReportInfoWhere1", ref SqlWhere) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                SqlWhere = string.Format(SqlWhere, OperID, beginDate.ToString(), endDate.ToString());
                Sqlstr += " " + SqlWhere;
                if (this.ExecQuery(Sqlstr) == -1)
                {
                    return null;
                }
                Class.DayReport dayReport = null;
                List<Class.DayReport> list = new List<Report.InpatientFee.Class.DayReport>();
                while (this.Reader.Read())
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();
                    dayReport.StatNO = this.Reader[0].ToString();//统计序号
                    dayReport.BeginDate = NConvert.ToDateTime(this.Reader[1]);//开始时间
                    dayReport.EndDate = NConvert.ToDateTime(this.Reader[2]);//终止时间
                    dayReport.Oper.ID = this.Reader[3].ToString(); //操作员编码
                    dayReport.Oper.Name = this.Reader[4].ToString();//操作员姓名
                    dayReport.Oper.OperTime = NConvert.ToDateTime(this.Reader[5]);//统计时间
                    dayReport.BalanceInvZone = this.Reader[6].ToString();//结算发票区间
                    list.Add(dayReport);
                }
                return list;
            }
            catch
            {
                return null;
            }

        }
           /// <summary>
        /// 查找日结数据信息
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">操作员</param>
        /// <returns></returns>
        public List<Class.DayReport> CollectDayReprotInfo(DateTime beginDate, DateTime endDate)
        {
            string Sqlstr = string.Empty;
            string SqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryDayReportInfo", ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryDayReportInfoWhere2", ref SqlWhere) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                SqlWhere = string.Format(SqlWhere, beginDate.ToString(), endDate.ToString());
                Sqlstr += " " + SqlWhere;
                if (this.ExecQuery(Sqlstr) == -1)
                {
                    return null;
                }
                Class.DayReport dayReport = null;
                List<Class.DayReport> list = new List<Report.InpatientFee.Class.DayReport>();
                while (this.Reader.Read())
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();
                    dayReport.StatNO = this.Reader[0].ToString();//统计序号
                    dayReport.BeginDate = NConvert.ToDateTime(this.Reader[1]);//开始时间
                    dayReport.EndDate = NConvert.ToDateTime(this.Reader[2]);//终止时间
                    dayReport.Oper.ID = this.Reader[3].ToString();//操作员编码
                    dayReport.Oper.Name = this.Reader[4].ToString();//操作员名称
                    dayReport.Oper.OperTime = NConvert.ToDateTime(this.Reader[5]);//统计时间
                    dayReport.BalanceInvZone = this.Reader[6].ToString();//结算发票区间
                    list.Add(dayReport);
                }
                return list;
            }
            catch
            {
                return null;
            }

        }
        #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
        /// <summary>
        /// 查找日结数据信息
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="OperID">操作员</param>
        /// <returns></returns>
        public List<Class.DayReport> CollectCheckedDayReprotInfo(DateTime beginDate, DateTime endDate)
        {
            string Sqlstr = string.Empty;
            string SqlWhere = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryCheckedDayReportInfo", ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            if (this.Sql.GetSql("Fee.InpatientDayReport.QueryCheckedDayReportInfoWhere2", ref SqlWhere) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                SqlWhere = string.Format(SqlWhere, beginDate.ToString(), endDate.ToString());
                Sqlstr += " " + SqlWhere;
                if (this.ExecQuery(Sqlstr) == -1)
                {
                    return null;
                }
                Class.DayReport dayReport = null;
                List<Class.DayReport> list = new List<Report.InpatientFee.Class.DayReport>();
                while (this.Reader.Read())
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();
                    dayReport.StatNO = this.Reader[0].ToString();//统计序号
                    dayReport.BeginDate = NConvert.ToDateTime(this.Reader[1]);//开始时间
                    dayReport.EndDate = NConvert.ToDateTime(this.Reader[2]);//终止时间
                    dayReport.Oper.ID = this.Reader[3].ToString();//操作员编码
                    dayReport.Oper.Name = this.Reader[4].ToString();//操作员名称
                    dayReport.Oper.OperTime = NConvert.ToDateTime(this.Reader[5]);//统计时间
                    dayReport.BalanceInvZone = this.Reader[6].ToString();//结算发票区间
                    //审核时间
                    dayReport.Memo = this.Reader[7].ToString();
                    list.Add(dayReport);
                }
                return list;
            }
            catch
            {
                return null;
            }

        } 
        #endregion

        /// <summary>
        /// 查找日结数据
        /// </summary>
        ///<param name="statcodes">统计编码字符串</param>
        /// <param name="aMod">0查询，１统计</param>
        /// <returns></returns>
        public Class.DayReport SelectDayReport(string statcodes,int aMod)
        {
            Class.DayReport dayReprot = null;
            try
            {
                
                dayReprot = SetDayReport(statcodes,aMod);
                return dayReprot;
            }
            catch (Exception ex)
            {
                this.Err = "查找数据失败，" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 日结数据
        /// </summary>
        /// <param name="statcodes">统计编码字符串</param>
        /// <param name="aMod">0查询，１统计</param>
        /// <returns></returns>
        private Class.DayReport SetDayReport( string statcodes,int aMod)
        {
            string Sqlstr = string.Empty;
            string sqlIndex = string.Empty;
            if (aMod == 0)
            {
                sqlIndex = "Fee.InpatientDayReport.SelectDayReport";
            }
            else
            {
                sqlIndex = "Fee.InpatientDayReport.CollectDayReprot";
            }
            if (this.Sql.GetSql(sqlIndex, ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                Sqlstr = string.Format(Sqlstr, statcodes);
                Class.DayReport dayReport = null;
                if (this.ExecQuery(Sqlstr) == -1) return null;
                while (this.Reader.Read())
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();
                    dayReport.StatNO = this.Reader[0].ToString();//统计序号
                    dayReport.BeginDate = NConvert.ToDateTime(this.Reader[1]);//开始时间
                    dayReport.EndDate = NConvert.ToDateTime(this.Reader[2]);//终止时间
                    dayReport.Oper.Name = this.Reader[3].ToString();//操作员编码
                    dayReport.Oper.OperTime = NConvert.ToDateTime(this.Reader[4]);//统计时间
                    dayReport.PrepayCost = NConvert.ToDecimal(this.Reader[5]);//贷医疗预收款
                    dayReport.DebitCheckCost = NConvert.ToDecimal(this.Reader[6]);//借银行存款
                    dayReport.DebitBankCost = NConvert.ToDecimal(this.Reader[7]);//借银行卡
                    dayReport.BalancePrepayCost = NConvert.ToDecimal(this.Reader[8]);//借医疗预收款
                    dayReport.LenderCheckCost = NConvert.ToDecimal(this.Reader[9]);//贷银行存款
                    dayReport.LenderBankCost = NConvert.ToDecimal(this.Reader[10]);//贷银行卡
                    dayReport.BursaryPubCost = NConvert.ToDecimal(this.Reader[11]);//公费记帐金额
                    dayReport.CityMedicarePayCost = NConvert.ToDecimal(this.Reader[12]);//市医保帐户支付金额
                    dayReport.CityMedicarePubCost = NConvert.ToDecimal(this.Reader[13]);//市医保统筹金额
                    dayReport.ProvinceMedicarePayCost = NConvert.ToDecimal(this.Reader[14]);//省医保帐户支付金额
                    dayReport.ProvinceMedicarePubCost = NConvert.ToDecimal(this.Reader[15]);//省医保统筹金额
                    dayReport.PrepayInvCount = NConvert.ToInt32(this.Reader[16]);//预交金发票张数
                    dayReport.BalanceInvCount = NConvert.ToInt32(this.Reader[17]);//结算发票张数
                    dayReport.PrepayWasteInvNO = this.Reader[18].ToString();//作废预交金发票号码
                    dayReport.BalanceWasteInvNO = this.Reader[19].ToString();//作废结算发票号码
                    dayReport.PrepayWasteInvCount = NConvert.ToInt32(this.Reader[20]);//作废预交金发票张数
                    dayReport.BalanceWasteInvCount = NConvert.ToInt32(this.Reader[21]);//作废结算发票张数
                    dayReport.PrepayInvZone = this.Reader[22].ToString();//预交金发票区间
                    dayReport.BalanceInvZone = this.Reader[23].ToString();//结算发票区间
                    dayReport.BalanceCost = NConvert.ToDecimal(this.Reader[24]);//医疗应收款(结算总金额)
                    dayReport.DebitHos = NConvert.ToDecimal(this.Reader[25]);//院内账户借方
                    dayReport.LenderHos = NConvert.ToDecimal(this.Reader[26]);//院内账户贷方
                    dayReport.DebitOther = NConvert.ToDecimal(this.Reader[27]);//借方其它
                    dayReport.LenderOther = NConvert.ToDecimal(this.Reader[28]);//贷方其它
                    dayReport.DerateCost = NConvert.ToDecimal(this.Reader[29]);//减免金额
                    dayReport.CityMedicareOverCost = NConvert.ToDecimal(this.Reader[30]);//市保大额
                    dayReport.ProvinceMedicareOverCost = NConvert.ToDecimal(this.Reader[31]);//省保大额
                    dayReport.ProvinceMedicareOfficeCost = NConvert.ToDecimal(this.Reader[32]);//省保公务员
                    dayReport.DebitCash = NConvert.ToDecimal(this.Reader[33]);//库存现金借方
                    dayReport.LenderCash = NConvert.ToDecimal(this.Reader[34]);//库存现金贷方
                    #region 明细
                    if(aMod==0)
                        dayReport.ItemList = SelectDayReportDetail("Fee.InpatientDayReport.SelectDayReportDetail", statcodes);
                    else
                        dayReport.ItemList = SelectDayReportDetail("Fee.InpatientDayReport.CollectDayReprotDetail", statcodes);
                    #endregion
                }
                return dayReport;
            }
            catch
            {
                return null;
            }
        }

        private List<Class.Item> SelectDayReportDetail(string sqlIndex, string statcodes)
        {
            string Sqlstr = string.Empty;
            if (this.Sql.GetSql(sqlIndex, ref Sqlstr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return null;
            }
            try
            {
                Sqlstr = string.Format(Sqlstr, statcodes);
                if (this.ExecQueryByTempReader(Sqlstr) == -1)
                {
                    this.Err = "查找数据失败！";
                    return null;
                }
                Class.Item item = null;
                List<Class.Item> list = new List<Report.InpatientFee.Class.Item>();
                while (this.TempReader.Read())
                {
                    item = new Report.InpatientFee.Class.Item();
                    item.StateCode = TempReader[0].ToString();
                    item.Mark = TempReader[2].ToString();
                    item.TotCost = NConvert.ToDecimal(TempReader[1]);
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存日结汇总数据
        /// </summary>
        /// <param name="statNO">统计编码</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="operID">操作员编码</param>
        /// <returns></returns>
        public int SaveCollectData(string operID,DateTime operDate, string statNO)
        {
            string sqlStr = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.SaveCollectDayReprot", ref sqlStr) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                sqlStr = string.Format(sqlStr, "1", operID, operDate, statNO);
            }
            catch (Exception ex)
            {

                this.Err = "格式化SQL语句失败！";
                return -1;
            }
            return this.ExecNoQuery(sqlStr);
                    
        }
        #endregion

         //{9B8D83F8-CB0F-48fb-8ECD-0BA4462A952A}
        /// <summary>
        /// 更新日结标记(fin_ipb_inprepay fin_ipb_balancehead)
        /// </summary>
        /// <param name="dayReportID"></param>
        /// <param name="operID"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public int UpdateDayReport(string dayReportID, string operID, DateTime operDate, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientDayReport.UpdatePrePayFlag", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.InpatientDayReport.UpdatePrePayFlag的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, dtBegin.ToString(), dtEnd.ToString());
            if (this.ExecNoQuery(sql) < 0)
            {
                return -1;
            }
            if (this.Sql.GetSql("Fee.InpatientDayReport.UpdateBalanceHeadFlag", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.InpatientDayReport.UpdateBalanceHeadFlag的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, dayReportID, operID, operDate.ToString(), dtBegin.ToString(), dtEnd.ToString());
            if (this.ExecNoQuery(sql) == -1)
            {
                return -1;
            }
            return 1;
        }
        #endregion
    }
}
