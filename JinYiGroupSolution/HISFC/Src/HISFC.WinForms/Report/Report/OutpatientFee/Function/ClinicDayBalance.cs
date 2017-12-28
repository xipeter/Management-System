/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			ClinicDayBalance.cs
            // 文件功能描述：	门诊收款日结方法类
            //
            // 
            // 创建标识：		2006-3-22
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Data;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork.Function;
using System.Collections.Generic;

namespace Neusoft.WinForms.Report.OutpatientFee.Function
{
    /// <summary>
    /// 门诊收款员日结
    /// </summary>
    public class ClinicDayBalance : Neusoft.FrameWork.Management.Database
    {
        public ClinicDayBalance()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        //
        // 变量
        //
        #region 变量
        /// <summary>
        ///  返回值
        /// </summary>
        int intReturn = 0;

        /// <summary>
        /// 执行查询的SQL语句
        /// </summary>
        string SQL = "";

        /// <summary>
        /// 查询语句
        /// </summary>
        string stringSelect = "";

        /// <summary>
        /// 条件语句
        /// </summary>
        string stringWhere = "";

        /// <summary>
        /// 分组语句
        /// </summary>
        string stringGroup = "";

        /// <summary>
        /// 排序语句
        /// </summary>
        string stringOrder = "";

        /// <summary>
        /// 构造SQL语句的参数
        /// </summary>
        string[] parms = new string[26];
        #endregion

        //
        // 公共方法
        //
        #region 初始化变量
        /// <summary>
        /// 初始化变量
        /// </summary>
        private void InitVar()
        {
            this.intReturn = 0;
            this.SQL = "";
            this.stringSelect = "";
            this.stringWhere = "";
            this.stringGroup = "";
            this.stringOrder = "";
        }
        #endregion

        #region 构造SQL语句
        /// <summary>
        /// 构造SQL语句
        /// </summary>
        private void CreateSQL()
        {
            this.SQL = this.stringSelect + " " + this.stringWhere + " " + this.stringGroup + " " + this.stringOrder;
        }
        #endregion

        #region 清空参数数组
        /// <summary>
        /// 清空参数数组
        /// </summary>
        public void ClearParms()
        {
            for (int i = 0; i < parms.Length; i++)
            {
                parms[i] = "";
            }
        }
        #endregion

        #region 构造SQL语句匹配参数
        /// <summary>
        /// 构造SQL语句匹配参数
        /// </summary>
        /// <param name="clinicDayBalance">日结实体类</param>
        /// <param name="insert">是否插入</param>
        public void FillParms(Class.ClinicDayBalance clinicDayBalance, bool insert)
        {
            // 清空参数数组
            this.ClearParms();

            // 日结序号
            parms[0] = clinicDayBalance.BalanceSequence;
            // 日结数据开始时间
            parms[1] = clinicDayBalance.BeginDate.ToString();
            // 日结数据截止时间
            parms[2] = clinicDayBalance.EndDate.ToString();
            // 总收入
            parms[3] = clinicDayBalance.Cost.TotCost.ToString();
            // 收款员代码
            parms[4] = clinicDayBalance.BalanceOperator.ID;
            // 收款员姓名
            parms[5] = clinicDayBalance.BalanceOperator.Name;
            // 日结操作时间
            parms[6] = clinicDayBalance.BalanceDate.ToString();
            // 备注金额1
            parms[7] = clinicDayBalance.UnValidNumber.ToString();
            // 备注金额2
            parms[8] = clinicDayBalance.BKNumber.ToString();
            // 备注金额3
            parms[9] = clinicDayBalance.Memo;
            // 财务审核标志
            parms[10] = clinicDayBalance.CheckFlag;
            // 财务审核人
            parms[11] = clinicDayBalance.CheckOperator.ID;
            // 财务审核时间
            parms[12] = clinicDayBalance.CheckDate.ToString();
            // 日结项目
            if (clinicDayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Valid)
            {
                // 正常
                parms[13] = "0";
            }
            else if (clinicDayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Canceled)
            {
                // 退费
                parms[13] = "1";
            }
            else if (clinicDayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Reprint)
            {
                // 重打
                parms[13] = "2";
            }
            else if (clinicDayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.LogOut)
            {
                // 注销
                parms[13] = "3";
            }
            // 日结项目对应发票号
            parms[14] = clinicDayBalance.InvoiceNo;
            // 实收金额
            parms[15] = clinicDayBalance.Cost.OwnCost.ToString();
            // 记帐单数量
            parms[16] = clinicDayBalance.AccountNumber.ToString();
            // 扩展字段
            parms[17] = clinicDayBalance.ExtendField;
            // 记帐金额
            parms[18] = clinicDayBalance.Cost.LeftCost.ToString();
            //刷卡数量
            parms[19] = clinicDayBalance.CDNumber.ToString();
            //现金
            parms[20] = clinicDayBalance.BackCost1.ToString();
            //刷卡
            parms[21] = clinicDayBalance.BackCost2.ToString();
            //支票
            parms[22] = clinicDayBalance.BackCost3.ToString();
            //退费发票明细
            parms[23] = clinicDayBalance.BKInvoiceNo;
            //作废发票明细
            parms[24] = clinicDayBalance.UnValidInvoiceNo;
            //发票区间
            parms[25] = clinicDayBalance.InvoiceBand;


        }
        #endregion

        #region 转换返回的Reader到实体类
        /// <summary>
        /// 转换返回的Reader到实体类
        /// </summary>
        /// <param name="clinicDayBalance">返回的日结实体</param>
        public void ChangeReaderToClass(ref Class.ClinicDayBalance clinicDayBalance)
        {
            // 如果Reader为空，那么返回空
            if (this.Reader == null)
            {
                clinicDayBalance = null;
            }

            // 转换
            if (this.Reader.Read())
            {
                // 日结序号
                clinicDayBalance.BalanceSequence = this.Reader[2].ToString();
                // 日结数据开始时间
                try
                {
                    clinicDayBalance.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3]);
                }
                catch
                {
                    clinicDayBalance.BeginDate = DateTime.MinValue;
                }
                // 日结数据截止时间
                try
                {
                    clinicDayBalance.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4]);
                }
                catch
                {
                    clinicDayBalance.EndDate = DateTime.MinValue;
                }
                // 总收入
                clinicDayBalance.Cost.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5]);
                // 收款员代码
                clinicDayBalance.BalanceOperator.ID = this.Reader[6].ToString();
                // 收款员姓名
                clinicDayBalance.BalanceOperator.Name = this.Reader[7].ToString();
                // 日结操作时间
                try
                {
                    clinicDayBalance.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8]);
                }
                catch
                {
                    clinicDayBalance.BalanceDate = DateTime.MinValue;
                }
                // 备注金额1
                clinicDayBalance.UnValidNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
                // 备注金额2
                clinicDayBalance.BKNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10]);
                // 备注金额3
                clinicDayBalance.User03 = this.Reader[11].ToString();
                // 财务审核标志
                clinicDayBalance.CheckFlag = this.Reader[12].ToString();
                // 财务审核人
                clinicDayBalance.CheckOperator.ID = this.Reader[13].ToString();
                // 财务审核时间
                clinicDayBalance.CheckDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[14]);
                // 日结项目
                if (this.Reader[15].ToString() == "0")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                }
                else if (this.Reader[15].ToString() == "1")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                }
                else if (this.Reader[15].ToString() == "2")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Reprint;
                }
                else if (this.Reader[15].ToString() == "3")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.LogOut;
                }
                // 日结项目对应发票号
                clinicDayBalance.InvoiceNo = this.Reader[16].ToString();
                // 实收金额
                clinicDayBalance.Cost.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
                // 记帐单数量
                clinicDayBalance.AccountNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[18].ToString());
                // 扩展字段
                clinicDayBalance.ExtendField = this.Reader[19].ToString();
                // 记帐金额
                clinicDayBalance.Cost.LeftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
                //刷卡数量
                if (this.Reader[21] != null)
                {
                    clinicDayBalance.CDNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[21].ToString());
                }
                //刷卡
                if (this.Reader[22] != null)
                {
                    clinicDayBalance.BackCost2 = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[22].ToString());
                }
                //现金
                if (this.Reader[23] != null)
                {
                    clinicDayBalance.BackCost1 = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[23].ToString());
                }
                //支票
                if (this.Reader[24] != null)
                {
                    clinicDayBalance.BackCost3 = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[24].ToString());
                }
                //票据区间
                clinicDayBalance.RecipeBand = this.Reader[25].ToString();
                //发票区间
                clinicDayBalance.InvoiceBand = this.Reader[26].ToString();
                //作废发票明细
                clinicDayBalance.UnValidInvoiceNo = this.Reader[27].ToString();
                //退费发票明细
                clinicDayBalance.BKInvoiceNo = this.Reader[28].ToString();
            }
        }
        #endregion

        #region 转换返回的Reader到实体类数组
        /// <summary>
        /// 转换返回的Reader到实体类数组
        /// </summary>
        /// <param name="alClinicDayBalance">返回的日结实体数组</param>
        public void ChangeReaderToClass(ref ArrayList alClinicDayBalance)
        {


            // 如果Reader为空，那么返回空
            if (this.Reader == null)
            {
                return;
            }

            // 转换
            while (this.Reader.Read())
            {
                Class.ClinicDayBalance clinicDayBalance = new Class.ClinicDayBalance();
                // 日结序号
                clinicDayBalance.BalanceSequence = this.Reader[2].ToString();
                // 日结数据开始时间
                try
                {
                    clinicDayBalance.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3]);
                }
                catch
                {
                    clinicDayBalance.BeginDate = DateTime.MinValue;
                }
                // 日结数据截止时间
                try
                {
                    clinicDayBalance.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4]);
                }
                catch
                {
                    clinicDayBalance.EndDate = DateTime.MinValue;
                }
                // 总收入
                clinicDayBalance.Cost.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5]);
                // 收款员代码
                clinicDayBalance.BalanceOperator.ID = this.Reader[6].ToString();
                // 收款员姓名
                clinicDayBalance.BalanceOperator.Name = this.Reader[7].ToString();
                // 日结操作时间
                try
                {
                    clinicDayBalance.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8]);
                }
                catch
                {
                    clinicDayBalance.BalanceDate = DateTime.MinValue;
                }
                // 备注金额1
                clinicDayBalance.UnValidNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
                // 备注金额2
                clinicDayBalance.BKNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10]);
                // 备注金额3
                clinicDayBalance.User03 = this.Reader[11].ToString();
                // 财务审核标志
                clinicDayBalance.CheckFlag = this.Reader[12].ToString();
                // 财务审核人
                clinicDayBalance.CheckOperator.ID = this.Reader[13].ToString();
                // 财务审核时间
                clinicDayBalance.CheckDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[14]);
                // 日结项目
                if (this.Reader[15].ToString() == "0")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                }
                else if (this.Reader[15].ToString() == "1")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                }
                else if (this.Reader[15].ToString() == "2")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Reprint;
                }
                else if (this.Reader[15].ToString() == "3")
                {
                    clinicDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.LogOut;
                }
                // 日结项目对应发票号
                clinicDayBalance.InvoiceNo = this.Reader[16].ToString();
                // 实收金额
                clinicDayBalance.Cost.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
                // 记帐单数量
                clinicDayBalance.AccountNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[18].ToString());
                // 扩展字段
                clinicDayBalance.ExtendField = this.Reader[19].ToString();
                // 记帐金额
                clinicDayBalance.Cost.LeftCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[20].ToString());
                //刷卡数量
                if (this.Reader[21] != null)
                {
                    clinicDayBalance.CDNumber = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[21].ToString());
                }
                //刷卡
                if (this.Reader[22] != null)
                {
                    clinicDayBalance.BackCost2 = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[22].ToString());
                }
                //现金
                if (this.Reader[23] != null)
                {
                    clinicDayBalance.BackCost1 = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[23].ToString());
                }
                //支票
                if (this.Reader[24] != null)
                {
                    clinicDayBalance.BackCost3 = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[24].ToString());
                }
                //票据区间
                clinicDayBalance.RecipeBand = this.Reader[25].ToString();
                //发票区间
                clinicDayBalance.InvoiceBand = this.Reader[16].ToString();
                //作废发票明细
                clinicDayBalance.UnValidInvoiceNo = this.Reader[27].ToString();
                //退费发票明细
                clinicDayBalance.BKInvoiceNo = this.Reader[28].ToString();
                // 添加实体
                alClinicDayBalance.Add(clinicDayBalance);
            }
        }
        #endregion

        #region 计算发票张数
        /// <summary>
        /// 计算发票张数
        /// </summary>
        /// <param name="invoiceCode">发票号或发票区间</param>
        /// <returns>发票张数</returns>
        public int GetInvoiceCount(string invoiceCode)
        {
            // 变量定义
            int intCount = 0;
            int intLeft = 0;
            int intRight = 0;
            int intLength = 0;
            string stringSub = "";

            // 获取长度和分割符位置
            intLength = invoiceCode.Length;
            intCount = invoiceCode.IndexOf("～");

            // 如果没有分割符，那么发票张数为1
            if (intCount == -1)
            {
                intCount = 1;
            }
            else
            {
                intLeft = int.Parse(invoiceCode.Substring(0, intCount));
                stringSub = invoiceCode.Substring(intCount + 1, intLength - intCount - 1);
                intRight = int.Parse(stringSub);
                intCount = intRight - intLeft + 1;

            }

            return intCount;
        }
        #endregion

        //
        // 查询获取
        //
        #region 根据收款员工号获取上次日结时间(1：成功/0：没有作过日结/-1：失败)
        /// <summary>
        /// 根据收款员工号获取上次日结时间(1：成功/0：没有作过日结/-1：失败)
        /// </summary>
        /// <param name="employee">操作员</param>
        /// <param name="lastDate">返回上次日结截止时间</param>
        /// <returns>1：成功/0：没有作过日结/-1：失败</returns>
        public int GetLastBalanceDate(Neusoft.FrameWork.Models.NeuObject employee, ref string lastDate)
        {
            //
            // 初始化变量
            //
            this.InitVar();

            //
            // 获取SQL语句
            //

            // 获取查询语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.GetLastBalanceDate.Select", ref stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取条件语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.GetLastBalanceDate.Where", ref stringWhere);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            this.CreateSQL();

            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, employee.ID);
            }
            catch (Exception e)
            {
                this.InitVar();
                this.Err = "格式化SQL语句失败(" + this.Err + ")(" + e.Message + ")";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(this.SQL);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            //
            // 返回执行结果
            //
            if (this.Reader == null)
            {
                lastDate = DateTime.MinValue.ToString();
                return 0;
            }
            this.Reader.Read();
            lastDate = this.Reader[0].ToString();
            if (lastDate == "")
            {
                lastDate = System.DateTime.MinValue.ToString();
            }

            // 存在数据，返回1
            return 1;
        }
        /// <summary>
        /// 得到日结数据
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="dtBegin"></param>
        /// <param name="?"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetZSYDayBalanceData(string employeeID, string dtBegin, string dtEnd, ref DataSet ds)
        {
            string strSql = "";
            string strWhere = "";
            int intReturn = -1;
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Select", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Select";
                return -1;
            }
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Where1", ref strWhere) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Where1";
                return -1;
            }
            strSql = strSql + strWhere;
            strSql = System.String.Format(strSql, employeeID, dtBegin, dtEnd);
            intReturn = this.ExecQuery(strSql, ref ds);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 得到退费数据
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="dtBegin"></param>
        /// <param name="?"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetZSYDayBalanceReturnData(string employeeID, string dtBegin, string dtEnd, ref DataSet ds)
        {
            string strSql = "";
            string strWhere = "";
            int intReturn = -1;
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Select", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Select";
                return -1;
            }
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Where2", ref strWhere) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Where1";
                return -1;
            }
            strSql = strSql + strWhere;
            strSql = System.String.Format(strSql, employeeID, dtBegin, dtEnd);
            intReturn = this.ExecQuery(strSql, ref ds);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 得到无效数据
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="dtBegin"></param>
        /// <param name="?"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetZSYDayBalanceUnvalidData(string employeeID, string dtBegin, string dtEnd, ref DataSet ds)
        {
            string strSql = "";
            string strWhere = "";
            int intReturn = -1;
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Select", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Select";
                return -1;
            }
            if (this.Sql.GetSql("Local.Clinic.GetZSYDayBalanceData.Where3", ref strWhere) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetZSYDayBalanceData.Where1";
                return -1;
            }
            strSql = strSql + strWhere;
            strSql = System.String.Format(strSql, employeeID, dtBegin, dtEnd);
            intReturn = this.ExecQuery(strSql, ref ds);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 获得最大日结号
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public string GetMaxBalanceNoByOper(string operCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Local.Clinic.Function.GetMaxBalanceNo.Select", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.Function.GetLastBalanceDate.Select";
                return "";
            }
            strSql = System.String.Format(strSql, operCode);
            return this.ExecSqlReturnOne(strSql);
        }
        #endregion

        #region 获取门诊收款员的日结数据(1：成功/-1：失败)
        /// <summary>
        /// 获取门诊收款员的日结数据(1：成功/-1：失败)
        /// </summary>
        /// <param name="employeeID">门诊收款员编号</param>
        /// <param name="dateBegin">日结起始时间</param>
        /// <param name="dateEnd">日结截止时间</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetDayBalanceData(string employeeID, string dateBegin,
                                        string dateEnd, ref System.Data.DataSet dsResult)
        {
            //
            // 初始化变量
            //
            this.InitVar();

            //
            // 获取SQL语句
            //

            // 获取查询语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceData.Select", ref stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取条件语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceData.Where", ref stringWhere);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取分组语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceData.Group", ref stringGroup);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取排序语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceData.Order", ref stringOrder);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 构造SQL语句
            this.CreateSQL();

            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, employeeID, dateBegin, dateEnd);
            }
            catch (Exception e)
            {
                this.InitVar();
                this.Err = "格式化SQL语句失败(" + this.Err + ")(" + e.Message + ")";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(this.SQL, ref dsResult);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            return 1;
        }
        #endregion

        #region 根据时间范围获取相应的日结记录（非明细）
        /// <summary>
        /// 根据时间范围获取相应的日结记录（非明细）
        /// </summary>
        /// <param name="employee">操作员信息</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <param name="clinicDayBalance">返回的日结记录数组</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetBalanceRecord(Neusoft.FrameWork.Models.NeuObject employee, DateTime dtFrom, DateTime dtTo,
                                    ref ArrayList clinicDayBalance)
        {
            //
            // 初始化变量
            //
            this.InitVar();
            // 日结记录
            Neusoft.FrameWork.Models.NeuObject balanceRecord = new NeuObject();

            //
            // 获取SQL语句
            //

            // 获取查询语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetBalanceRecord.Select", ref stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取条件语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetBalanceRecord.Where", ref stringWhere);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 构造SQL语句
            this.CreateSQL();

            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, employee.ID, dtFrom, dtTo);
            }
            catch (Exception e)
            {
                this.InitVar();
                this.Err = "格式化SQL语句失败(" + this.Err + ")(" + e.Message + ")";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(this.SQL);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            //
            // 赋值
            //
            while (this.Reader.Read())
            {
                balanceRecord = new NeuObject();
                balanceRecord.ID = this.Reader[0].ToString();
                balanceRecord.Name = this.Reader[1].ToString();
                balanceRecord.Memo = this.Reader[2].ToString();
                balanceRecord.User01 = this.Reader[3].ToString();
                clinicDayBalance.Add(balanceRecord);
            }

            return 1;
        }
        /// <summary>
        /// 根据时间范围获取相应的日结记录（非明细）
        /// </summary>
        /// <param name="employee">操作员信息</param>
        /// <param name="empDept">操作员科室</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <param name="clinicDayBalance">返回的日结记录数组</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetBalanceRecord(Neusoft.FrameWork.Models.NeuObject employee, Neusoft.FrameWork.Models.NeuObject empDept, DateTime dtFrom, DateTime dtTo,
            ref ArrayList clinicDayBalance)
        {
            //
            // 初始化变量
            //
            this.InitVar();
            // 日结记录
            Neusoft.FrameWork.Models.NeuObject balanceRecord = new NeuObject();

            //
            // 获取SQL语句
            //

            // 获取查询语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetBalanceRecord.Select", ref stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取条件语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetBalanceRecord.ByOperDeptAndOperCode", ref stringWhere);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 构造SQL语句
            this.CreateSQL();

            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, employee.ID, dtFrom, dtTo, empDept.ID);
            }
            catch (Exception e)
            {
                this.InitVar();
                this.Err = "格式化SQL语句失败(" + this.Err + ")(" + e.Message + ")";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(this.SQL);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            //
            // 赋值
            //
            while (this.Reader.Read())
            {
                balanceRecord = new NeuObject();
                balanceRecord.ID = this.Reader[0].ToString();
                balanceRecord.Name = this.Reader[1].ToString();
                balanceRecord.Memo = this.Reader[2].ToString();
                balanceRecord.User01 = this.Reader[3].ToString();
                clinicDayBalance.Add(balanceRecord);
            }

            return 1;
        }
        #endregion

        #region 根据日结流水号获取日结明细(1：成功/-1：失败)
        /// <summary>
        /// 根据日结流水号获取日结明细(1：成功/-1：失败)
        /// </summary>
        /// <param name="stringSequece">日结流水号</param>
        /// <param name="balanceDetail">返回的日结明细</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetDayBalanceDetail(string stringSequece, ref ArrayList balanceDetail)
        {
            //
            // 初始化变量
            //
            this.InitVar();

            //
            // 获取SQL语句
            //

            // 获取查询语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceDetail.Select", ref stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 获取条件语句
            intReturn = this.Sql.GetSql("Local.Clinic.GetDayBalanceDetail.Where", ref stringWhere);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            // 构造SQL语句
            this.CreateSQL();

            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, stringSequece);
            }
            catch (Exception e)
            {
                this.InitVar();
                this.Err = "格式化SQL语句失败(" + this.Err + ")(" + e.Message + ")";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(this.SQL);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            //
            // 赋值
            //
            this.ChangeReaderToClass(ref balanceDetail);

            return 1;
        }
        #endregion

        #region 获取日结序号(1：成功/-1：失败)
        /// <summary>
        /// 获取日结序号(1：成功/-1：失败)
        /// </summary>
        /// <param name="sequence">返回日结序列号</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetBalanceSequence(ref string sequence)
        {
            // 获取日结序号
            sequence = this.GetSequence("Local.Clinic.Function.CreateClinicDayBalance.GetInsertSequence");
            if (sequence == null)
            {
                this.Err = "获取流水号失败！" + this.Err;
                return -1;
            }
            return 1;
        }
        #endregion

        #region 根据发票号获得对应的支付方式和金额
        /// <summary>
        /// 获得发票对应支付方式
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        public ArrayList GetPayModeByInvoiceNo(string invoiceNo, string invoice_seq, string transType)
        {
            string strSql = "";//sql 语句

            ArrayList al = new ArrayList();//返回数组
            //
            //找不到sql
            //
            if (this.Sql.GetSql("Local.Clinic.GetPayModeByInvoiceNo", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.GetPayModeByInvoiceNo";
                return null;
            }
            strSql = System.String.Format(strSql, invoiceNo, invoice_seq, transType);
            //
            //执行出错
            //
            if (this.ExecQuery(strSql) < 0)
            {
                this.Err = "Execute Sql Err";
                return null;
            }
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
                obj.ID = this.Reader[0].ToString();//发票号
                obj.Name = this.Reader[1].ToString();//支付方式
                obj.Memo = this.Reader[2].ToString();//金额
                al.Add(obj);
            }
            this.Reader.Close();
            return al;
        }
        #endregion

        #region  根据日结流水号更新日结表的票据范围等字段
        /// <summary>
        /// 根据日结流水号更新日结表的票据范围等字段
        /// </summary>
        /// <param name="balanceID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateOtherByBalanceID(string balanceID, Neusoft.FrameWork.Models.NeuObject obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("Local.Clinic.UpdateOtherByBalanceID", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Local.Clinic.UpdateOtherByBalanceID";
                return -1;
            }
            strSql = System.String.Format(strSql, obj.ID, obj.Name, obj.Memo, obj.User01, obj.User02, obj.User03, balanceID);
            if (this.ExecNoQuery(strSql) < 0)
            {
                this.Err = "Execute Err";
                return -1;
            }
            return 1;
        }
        #endregion

        //
        // 数据操作
        //
        #region 插入日结表(-1：失败/1：成功)
        /// <summary>
        /// 插入日结表(-1：失败/1：成功)
        /// </summary>
        /// <param name="clinicDayBalance">输入的日结实体</param>
        /// <returns>-1：失败/1</returns>
        public int CreateClinicDayBalance(Class.ClinicDayBalance clinicDayBalance)
        {
            // 初始化变量
            this.InitVar();


            // 获取SQL语句
            this.intReturn = this.Sql.GetSql("Local.Clinic.Function.CreateClinicDayBalance", ref this.stringSelect);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句失败" + this.Err;
                return -1;
            }
            this.CreateSQL();

            // 匹配参数
            this.FillParms(clinicDayBalance, true);

            // 格式化语句
            try
            {
                this.SQL = string.Format(this.SQL, this.parms);
            }
            catch (Exception e)
            {
                this.Err = "格式化SQL语句失败" + e.Message;
                return -1;
            }

            // 执行SQL语句
            intReturn = this.ExecNoQuery(this.SQL);
            if (intReturn <= 0)
            {
                this.Err = "执行SQL语句失败" + this.Err;
                return -1;
            }

            return 1;
        }
        #endregion

        #region 新日结
        /// <summary>
        /// 获取日结项目数据
        /// </summary>
        /// <param name="employeeID">收款员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="dsResult">返回数据集</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetDayBalanceDataNew(string employeeID, string dateBegin,
                                       string dateEnd, ref DataSet dsResult)
        {
            if (this.Sql.GetSql("Local.Clinic.GetDayBalanceDataNew.Select", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;

            }
            if (this.ExecQuery(SQL, ref dsResult) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }

        #region 门诊日结 luoff

        public int GetDayBalanceDataMZRJ(string employeeID, string dateBegin,
                                         string dateEnd, ref DataSet dsResult)
        {
            if (this.Sql.GetSql("Local.Clinic.GetDayBalanceDataMZRJ.Select", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref dsResult) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;

        }
        #endregion
        /// <summary>
        /// 获取日结发票数据
        /// </summary>
        /// <param name="employeeID">收款员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="dsResult">返回数据集</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetDayInvoiceDataNew(string employeeID, string dateBegin,
                                       string dateEnd, ref DataSet dsResult)
        {
            if (this.Sql.GetSql("Local.Clinic.GetDayInvoiceDataNew.Select", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;

            }
            if (this.ExecQuery(SQL, ref dsResult) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 生成结算数据
        /// </summary>
        /// <param name="clicicDayBlanceNew">结算数据实体</param>
        /// <returns>1成功-1失败</returns>
        public int InsertClinicDayBalance(Class.ClinicDayBalanceNew clicicDayBlanceNew)
        {
            if (this.Sql.GetSql("Local.Clinic.InsertDayBalanceDataNew", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL,
                                  clicicDayBlanceNew.BlanceNO,
                                  clicicDayBlanceNew.BeginTime.ToString(),
                                  clicicDayBlanceNew.EndTime.ToString(),
                                  clicicDayBlanceNew.TotCost,
                                  clicicDayBlanceNew.Oper.ID,
                                  clicicDayBlanceNew.Oper.Name,
                                  clicicDayBlanceNew.Oper.OperTime.ToString(),
                                  clicicDayBlanceNew.InvoiceNO.ID,
                                  clicicDayBlanceNew.InvoiceNO.Name,
                                  clicicDayBlanceNew.BegionInvoiceNO,
                                  clicicDayBlanceNew.EndInvoiceNo,
                                  clicicDayBlanceNew.FalseInvoiceNo,
                                  clicicDayBlanceNew.CancelInvoiceNo,
                                  clicicDayBlanceNew.TypeStr,
                                  clicicDayBlanceNew.SortID);

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(SQL);
        }

        /// <summary>
        /// 查找日结数据
        /// </summary>
        /// <param name="employeeID">收款员</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <returns></returns>
        public int GetDayBalanceRecord(string strSequence, ref DataSet dsResult)
        {
            if (this.Sql.GetSql("Local.Clinic.SelectDayBalanceRecord", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, strSequence);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref dsResult) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 获取日结退费金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="cancelMoney">返回的退费金额</param>
        /// <returns>1成功-1失败</returns>
        public int GetDayBalanceCancelMoney(string employeeID, string dateBegin, string dateEnd,ref decimal cancelMoney)
        {
            if (this.Sql.GetSql("Local.Clinic.GetDayInvoiceCancelMoney", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
                cancelMoney = NConvert.ToDecimal(this.ExecSqlReturnOne(SQL));
                return 1;
            }
            catch(Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获取日结作废金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="falseMoney">返回的作废金额</param>
        /// <returns>1成功-1失败</returns>
        public int GetDayBalanceFalseMoney(string employeeID, string dateBegin, string dateEnd, ref decimal falseMoney)
        { 
            if (this.Sql.GetSql("Local.Clinic.GetDayInvoiceFalseMoney.Select", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
                falseMoney = NConvert.ToDecimal(this.ExecSqlReturnOne(SQL));
                return 1;
            }
            catch(Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获取日结四舍五入金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="modeMoney">返回四舍五入金额</param>
        /// <returns>1成功-1失败</returns>
        public int GetDayBalanceModeMoney(string employeeID, string dateBegin, string dateEnd, ref decimal modeMoney)
        { 
            if (this.Sql.GetSql("Local.Clinic.GetDayModeMoney", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
                modeMoney = NConvert.ToDecimal(this.ExecSqlReturnOne(SQL));
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获取公费、省、市医护金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="ds">dataSet</param>
        /// <returns>1成功 -1失败</returns>
        public int GetDayBalanceProtectMoney(string employeeID, string dateBegin, string dateEnd, ref DataSet ds)
        {
            if (this.Sql.GetSql("Local.Clinic.GetProtectMoney", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                //1是门诊数据　2是住院数据
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd,"1");
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref ds) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获取公费医护金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">dataSet</param>
        /// <returns>1成功 -1失败</returns>
        public int GetDayBalancePublicMoney(string employeeID, string dateBegin, string dateEnd,string pactCode, ref DataSet ds)
        {
            if (this.Sql.GetSql("Local.Clinic.GetPublicMoney", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                //1是门诊数据　2是住院数据
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd,pactCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref ds) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }
        //{745DF4AC-4A2D-47e8-A4D1-8D8A80D6C2B8}
        /// <summary>
        /// 获取减免金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="pactCode">合同单位</param>
        /// <param name="ds">dataSet</param>
        /// <returns>1成功 -1失败</returns>
        public int GetDayBalanceRebateMoney(string employeeID, string dateBegin, string dateEnd, ref DataSet ds)
        {
            if (this.Sql.GetSql("Local.Clinic.GetRebateMoney", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                //1是门诊数据　2是住院数据
                this.SQL = string.Format(SQL, employeeID, dateBegin, dateEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref ds) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 按支付方式查找金额
        /// </summary>
        /// <param name="employeeID">操作员编码</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="ds">dataSet</param>
        /// <returns>1成功 -1失败</returns>
        public int GetDayBalancePayTypeMoney(string employeeID, string dateBegin, string dateEnd, ref DataSet ds)
        {
            if (this.Sql.GetSql("Local.Clinic.GetPayTypeMoney", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL,
                                  employeeID,
                                  dateBegin,
                                  dateEnd);
            }
            catch (Exception ex)
            {

                this.Err = ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref ds) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 查找汇总数据信息
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public int GetCollectDayBalanceInfo(string dateBegin, string dateEnd, ref List<Class.ClinicDayBalanceNew> list)
        {
            if (this.Sql.GetSql("Local.Clinic.GetCollectDayBalanceInfo", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, dateBegin, dateEnd);
                if (this.ExecQuery(SQL) == -1)
                {
                    this.Err = "查找数据失败！";
                    return -1;
                }
                Class.ClinicDayBalanceNew obj = null;
                while (this.Reader.Read())
                {
                    obj = new Report.OutpatientFee.Class.ClinicDayBalanceNew();
                    obj.BlanceNO = Reader[0].ToString();
                    obj.Oper.Name = Reader[1].ToString();
                    obj.BeginTime = NConvert.ToDateTime(Reader[2]);
                    obj.EndTime = NConvert.ToDateTime(Reader[3]);
                    obj.BegionInvoiceNO = Reader[4].ToString();
                    obj.EndInvoiceNo = Reader[5].ToString();
                    list.Add(obj);
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return -1;
            }

        }   /// <summary>
        #region {A233C411-4B52-4831-AF89-8D7C2CE8D09E} 日结汇总加补打功能
        /// 查找汇总数据信息
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public int GetCheckedCollectDayBalanceInfo(string dateBegin, string dateEnd, ref List<Class.ClinicDayBalanceNew> list)
        {
            if (this.Sql.GetSql("Local.Clinic.GetCheckCollectDayBalanceInfo", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, dateBegin, dateEnd);
                if (this.ExecQuery(SQL) == -1)
                {
                    this.Err = "查找数据失败！";
                    return -1;
                }
                Class.ClinicDayBalanceNew obj = null;
                while (this.Reader.Read())
                {
                    obj = new Report.OutpatientFee.Class.ClinicDayBalanceNew();
                    obj.BlanceNO = Reader[0].ToString();
                    obj.Oper.Name = Reader[1].ToString();
                    obj.BeginTime = NConvert.ToDateTime(Reader[2]);
                    obj.EndTime = NConvert.ToDateTime(Reader[3]);
                    obj.BegionInvoiceNO = Reader[4].ToString();
                    obj.EndInvoiceNo = Reader[5].ToString();
                    obj.Memo = Reader[6].ToString();
                    list.Add(obj);
                }
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return -1;
            }

        } 
        #endregion

        /// <summary>
        /// 查找日结汇总数据
        /// </summary>
        ///<param name="balanceNos">日结算序号</param>
        /// <param name="ds">DataSet</param>
        /// <returns>1：成功-1失败</returns>
        public int GetCollectDayBalanceData(string balanceNos, ref DataSet ds)
        {
            if (this.Sql.GetSql("Local.Clinic.SelecCollectDayBalanceData", ref SQL) == -1)
            {
                this.Err = "查找Sql语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, balanceNos);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句失败！" + ex.Message;
                return -1;
            }
            if (this.ExecQuery(SQL, ref ds) == -1)
            {
                this.Err = "执行SQL语句失败！";
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 保存汇总数据
        /// </summary>
        /// <param name="operID">审核人编码</param>
        /// <param name="operTime">审核时间</param>
        /// <param name="balanceNos">结算序号</param>
        /// <returns>1成功 -1失败</returns>
        public int SaveCollectData(string operID, DateTime operTime, string balanceNos)
        {
            if (this.Sql.GetSql("Local.Clinic.SaveDayBalanceCollectData", ref SQL) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                SQL = string.Format(SQL, operID, operTime.ToString(), balanceNos);
            }
            catch
            { 
                this.Err="格式化SQL语句失败！";
                return -1;
            }
            return this.ExecNoQuery(SQL);
        }
        #endregion

    }
}
