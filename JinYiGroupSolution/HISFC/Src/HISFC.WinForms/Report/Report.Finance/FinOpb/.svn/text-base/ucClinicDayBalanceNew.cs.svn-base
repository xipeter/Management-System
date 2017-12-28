using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucClinicDayBalanceNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucClinicDayBalanceNew()
        {
            InitializeComponent();
        }

        #region 变量定义
        /// <summary>
        /// 当前操作员
        /// </summary>
        NeuObject currentOperator = new NeuObject();

        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Neusoft.Report.Finance.FinOpb.Function.ClinicDayBalance();

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 上次日结时间
        /// </summary>
        public string lastDate = "";

        /// <summary>
        /// 本次日结时间
        /// </summary>
        string dayBalanceDate = "";
        /// <summary>
        /// 是否可以日结
        /// </summary>
        bool enableBalance = true;
        /// <summary>
        /// 日结操作时间
        /// </summary>
        string operateDate = "";
        /// <summary>
        /// 要日结的数据
        /// </summary>
        public List<Class.ClinicDayBalanceNew> alData = new List<Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew>();
        private Class.ClinicDayBalanceNew dayBalance = null;
        
        #region 不信不平之变量定义
        //{0EA3CF1A-2F03-46c3-83AE-1543B00BBDDB}
        decimal d合计, d市保账户, d市保统筹, d市保大额, d省保账户, d省保统筹, d省保大额, d省保公务员, d上缴现金, d公费医疗,d公费账户, d四舍五入,d减免金额;

        #endregion


        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void InitUC()
        {
            try
            {
                // 返回值
                int intReturn = 0;

                // 获取当前操作员
                currentOperator = this.clinicDayBalance.Operator;

                // 获取最近一次日结时间
                intReturn = this.GetLastBalanceDate();
                if (intReturn == -1)
                {
                    MessageBox.Show("获取上次日结时间失败！不能进行日结操作！");
                    return;
                }
                else if (intReturn == 0)
                {
                    // 没有作过日结，设置上次日结时间为最小时间
                    this.lastDate = System.DateTime.MinValue.ToString();
                    this.ucClinicDayBalanceDateControl1.tbLastDate.Text = System.DateTime.MinValue.ToString();
                }
                else
                {
                    // 作过日结
                    this.ucClinicDayBalanceDateControl1.tbLastDate.Text = this.lastDate.ToString();
                    this.ucClinicDayBalanceDateControl1.dtpBalanceDate.Value = this.clinicDayBalance.GetDateTimeFromSysDateTime();
                }

                // 初始化子控件的变量
                this.ucClinicDayBalanceDateControl1.dtLastBalance = NConvert.ToDateTime(this.lastDate);
                this.ucClinicDayBalanceReportNew1.InitUC("门诊收费员缴款日报表");
                this.ucClinicDayBalanceReportNew2.InitUC("门诊收费员缴款日报表");
            }
            catch { }
        }

        #endregion

        #region 获取收款员上次日结时间
        /// <summary>
        /// 获取收款员上次日结时间
        /// </summary>
        /// <returns></returns>
        public int GetLastBalanceDate()
        {

            try
            {
                // 变量定义
                int intReturn = 0;

                // 获取收款员上次日结时间
                intReturn = clinicDayBalance.GetLastBalanceDate(this.currentOperator, ref lastDate);

                // 判断获取结果
                if (intReturn == -1)
                {
                    MessageBox.Show("获取收款员最近一次日结时间失败！");
                    return -1;
                }
                return intReturn;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 查询要日结的数据
        /// <summary>
        /// 查询要日结的数据
        /// </summary>
        private void QueryDayBalanceData()
        {
            this.alData.Clear();
            DataSet ds;
            int intReturn = 0;
            //
            // 获取日结截止时间
            //
            intReturn = this.ucClinicDayBalanceDateControl1.GetBalanceDate(ref dayBalanceDate);
            if (intReturn == -1)
            {
                this.enableBalance = false;
                return;
            }
            //显示报表信息
            this.SetInfo(lastDate, dayBalanceDate, 0);
            //清除数据
            FarPoint.Win.Spread.SheetView sheet = ucClinicDayBalanceReportNew1.neuSpread1_Sheet1;
            if (sheet.Rows.Count > 0)
                sheet.Rows.Remove(0, sheet.Rows.Count);

            //获取日结算数据
            ds = new DataSet();
            //clinicDayBalance.GetDayBalanceDataNew(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            clinicDayBalance.GetDayBalanceDataMZRJ(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            if (ds != null && ds.Tables.Count >= 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.SetDetial(ds.Tables[0]);
            }
            else
            {
                MessageBox.Show("该段时间内没有要日结的数据！");
                return;
            }
            //设置farpoint格式
            this.ucClinicDayBalanceReportNew1.SetFarPoint();
            //显示发票数据
            SetInvoice(sheet);
            //显示金额数据
            this.SetMoneyValue(sheet);

            this.enableBalance = true;
        }
        #endregion

        #region 设置要日结Farpoint数据

        /// <summary>
        /// 设置显示项目数据
        /// </summary>
        /// <param name="table"></param>
        protected virtual void SetDetial(DataTable table)
        {
            if (table.Rows.Count == 0) return;
            //清除数据
            if (ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count > 0)
                ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Remove(0, ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count - 1);
            //设置Farpoint的行数
            int count = table.Rows.Count;
            decimal countMoney = 0;
            if (count % 2 == 0)
            {
                ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count = Convert.ToInt32(count / 2);
            }
            else
            {
                ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count = Convert.ToInt32(count / 2) + 1;
            }

            //显示项目数据
            for (int i = 0; i < count; i++)
            {
                int index = Convert.ToInt32(i / 2);
                int intMod = (i + 1) % 2;
                if (intMod > 0)
                {
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Models.Span.Add(index, 0, 1, 2);
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[index, 0].Text = table.Rows[i][1].ToString();
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[index, 2].Text = table.Rows[i][2].ToString();
                }
                else
                {
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Models.Span.Add(index, 3, 1, 2);
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[index, 3].Text = table.Rows[i][1].ToString();
                    ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[index, 5].Text = table.Rows[i][2].ToString();
                }
                #region 设置实体
                dayBalance = new Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew();
                dayBalance.InvoiceNO.ID = table.Rows[i][0].ToString();
                dayBalance.InvoiceNO.Name = table.Rows[i][1].ToString();
                dayBalance.TotCost = NConvert.ToDecimal(table.Rows[i][2]);
                dayBalance.TypeStr = "4";
                dayBalance.SortID = "TOT_COST";
                this.SetDayBalance();
                #endregion
                countMoney += Convert.ToDecimal(table.Rows[i][2]);

            }
            if (count % 2 > 0)
            {
                ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Models.Span.Add(ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count - 1, 3, 1, 2);
            }
            //显示合计
            ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count += 1;
            count = ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Rows.Count;
            ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Models.Span.Add(count - 1, 0, 1, 2);
            ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[count - 1, 0].Text = "合计：";
            ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Models.Span.Add(count - 1, 2, 1, 4);
            ucClinicDayBalanceReportNew1.neuSpread1_Sheet1.Cells[count - 1, 2].Text = countMoney.ToString();
            this.d合计 = countMoney;

        }

        /// <summary>
        /// 设置显示发票数据
        /// </summary>
        /// <param name="table"></param>
        protected virtual void SetInvoice(FarPoint.Win.Spread.SheetView sheet)
        {
            //获取发票数据
            DataSet ds = new DataSet();
            int resultValue = clinicDayBalance.GetDayInvoiceDataNew(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            if (resultValue == -1) return;
            DataTable table = ds.Tables[0];
            if (table.Rows.Count == 0) return;
            //起止票据号
            this.SetOneCellText(sheet, "A00101", GetInvoiceStartAndEnd(ds.Tables[0]));//luoff
           // this.SetOneCellText(sheet, "A00102", table.Rows[table.Rows.Count - 1][0].ToString());//luoff
            DataView dv = table.DefaultView;
            //总票据数
            dv.RowFilter = "trans_type='1'";
            this.SetOneCellText(sheet, "A002", dv.Count.ToString());

            //有效票据
            dv.RowFilter = "cancel_flag='1'";
            this.SetOneCellText(sheet, "A003", dv.Count.ToString());

            //退费票据
            dv.RowFilter = "cancel_flag='0' and trans_type='2'";
            this.SetOneCellText(sheet, "A00401", dv.Count.ToString());
            //退费票据号 
            string InvoiceStr = GetInvoiceStr(dv);
            this.SetOneCellText(sheet, "A00402", InvoiceStr);

            //作废票据
            dv.RowFilter = "cancel_flag in ('2','3') and trans_type='2'";
            this.SetOneCellText(sheet, "A00501", dv.Count.ToString());
            //作废票据号
            InvoiceStr = GetInvoiceStr(dv);
            this.SetOneCellText(sheet, "A00502", InvoiceStr);


        }

        /// <summary>
        /// 获得作废、退费票据号
        /// </summary>
        /// <param name="dv">DataView</param>
        /// <param name="aMod">作废还是退费1是作废 0是退费</param>
        /// <returns></returns>
        private string GetInvoiceStr(DataView dv)
        {
            StringBuilder sb = new StringBuilder();
            if (dv.Count == 0)
            {
                sb.Append("无");
            }
            else
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    sb.Append(dv[i][0].ToString() + "|");

                }
            }
            return sb.ToString();
        }

        #region 获得起始、终止票据号  luoff

        private string GetInvoiceStartAndEnd(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            int count = dt.Rows.Count-1;
            string minStr = dt.Rows[0][0].ToString();
            string maxStr = dt.Rows[0][0].ToString();
            for (int i = 0; i < count - 1; i++)
                for (int j = i + 1; j < count; j++)
                {
                    long froInt = Convert.ToInt32(dt.Rows[i][0].ToString());
                    long nxtInt = Convert.ToInt32(dt.Rows[j][0].ToString());
                    long chaInt = nxtInt - froInt;
                    if (chaInt > 1 )
                    {
                        maxStr = dt.Rows[i][0].ToString();
                        if (maxStr.Equals(minStr))
                        {
                            sb.Append(minStr + ",");
                        }
                        else
                        {
                            sb.Append(minStr + "～" + maxStr + ",");
                        }
                        minStr = dt.Rows[j][0].ToString();
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
            maxStr = dt.Rows[count][0].ToString();
            sb.Append(minStr + "～" + maxStr);
            return sb.ToString();
                        
        }

        #endregion

        /// <summary>
        /// 设置显示金额数据
        /// </summary>
        protected virtual void SetMoneyValue(FarPoint.Win.Spread.SheetView sheet)
        {
            decimal money = 0;
            int resultValue;
            //退费金额
            resultValue = clinicDayBalance.GetDayBalanceCancelMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref money);
            if (resultValue != -1)
            {
                SetOneCellText(sheet, "A006", money.ToString());
            }
            //作废金额
            resultValue = clinicDayBalance.GetDayBalanceFalseMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref money);
            if (resultValue != -1)
            {
                SetOneCellText(sheet, "A007", money.ToString());
            }
            //四舍五入
            resultValue = clinicDayBalance.GetDayBalanceModeMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref money);
            if (resultValue != -1)
            {
                SetOneCellText(sheet, "A011", money.ToString());
            }
            DataSet ds = new DataSet();
            //公费、省、市医保金额
            resultValue = clinicDayBalance.GetDayBalanceProtectMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            if (resultValue != -1)
            {
                SetProtectValue(sheet, ds);
            }

            ds = new DataSet();//{0EA3CF1A-2F03-46c3-83AE-1543B00BBDDB}
            //查询公费
            resultValue = clinicDayBalance.GetDayBalancePublicMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, "03", ref ds);
            if (resultValue != -1)
            {
                SetPublicValue(sheet, ds);
                
            }
            //{0EA3CF1A-2F03-46c3-83AE-1543B00BBDDB}
            ds = new DataSet();
            //查询减免
            resultValue = clinicDayBalance.GetDayBalanceRebateMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            if (resultValue != -1)
            {
                SetRebateValue(sheet, ds);

            }

            ds = new DataSet();
            //支付方式金额
            resultValue = clinicDayBalance.GetDayBalancePayTypeMoney(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref ds);
            if (resultValue != -1)
            {
                SetPayTypeValue(sheet, ds);
            }
        }
        /// <summary>
        /// 显示医保金额数据
        /// </summary>
        /// <param name="sheet">SheetView</param>
        /// <param name="ds">DataSet</param>
        protected virtual void SetProtectValue(FarPoint.Win.Spread.SheetView sheet, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["pact_code"].ToString())
                {
                    case "4"://公费
                        {
                            SetOneCellText(sheet, "A012", dr["pub_cost"].ToString()); //公费医疗
                            this.d公费医疗 = NConvert.ToDecimal(dr["pub_cost"]);
                            SetOneCellText(sheet, "A013", dr["pay_cost"].ToString());//公费自付
                            break;
                        }
                    case "2"://市护
                        {
                            SetOneCellText(sheet, "A014", dr["own_cost"].ToString());//市保自付

                            SetOneCellText(sheet, "A015", dr["pay_cost"].ToString());//市保账户

                            SetOneCellText(sheet, "A016", dr["pub_cost"].ToString());//市保统筹   

                            SetOneCellText(sheet, "A017", dr["over_cost"].ToString());//市保大额
                            this.d市保账户 = NConvert.ToDecimal(dr["pay_cost"]);
                            this.d市保统筹 = NConvert.ToDecimal(dr["pub_cost"]);
                            this.d市保大额 = NConvert.ToDecimal(dr["over_cost"]);

                            break;
                        }
                    case "3"://省保
                        {
                            SetOneCellText(sheet, "A018", dr["own_cost"].ToString());//省保自付

                            SetOneCellText(sheet, "A019", dr["pay_cost"].ToString());//省保账户

                            SetOneCellText(sheet, "A020", dr["pub_cost"].ToString());//省保统筹

                            SetOneCellText(sheet, "A021", dr["over_cost"].ToString());//省保大额

                            SetOneCellText(sheet, "A022", dr["official_cost"].ToString());//省公务员
                            this.d省保账户 = NConvert.ToDecimal(dr["pay_cost"]);
                            this.d省保统筹 = NConvert.ToDecimal(dr["pub_cost"]);
                            this.d省保大额 = NConvert.ToDecimal(dr["over_cost"]);
                            this.d省保公务员 = NConvert.ToDecimal(dr["official_cost"]);

                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 显示公费金额数据
        /// </summary>
        /// <param name="sheet">SheetView</param>
        /// <param name="ds">DataSet</param>
        protected virtual void SetPublicValue(FarPoint.Win.Spread.SheetView sheet, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {   
                SetOneCellText(sheet, "A012", dr["pub_cost"].ToString()); //公费医疗
                this.d公费医疗 = NConvert.ToDecimal(dr["pub_cost"]);
                SetOneCellText(sheet, "A013", dr["own_cost"].ToString());//公费自付  
                SetOneCellText(sheet,"A026",dr["pay_cost"].ToString());//公费账户
                this.d公费账户 = NConvert.ToDecimal(dr["pay_cost"]);
                //SetOneCellText(sheet, "A010", dr["rebate_cost"].ToString());
                //this.d减免金额 = NConvert.ToDecimal(dr["rebate_cost"]);
            }
        }
        //{0EA3CF1A-2F03-46c3-83AE-1543B00BBDDB}
        /// <summary>
        /// 显示减免金额数据
        /// </summary>
        /// <param name="sheet">SheetView</param>
        /// <param name="ds">DataSet</param>
        protected virtual void SetRebateValue(FarPoint.Win.Spread.SheetView sheet, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                SetOneCellText(sheet, "A010", dr["rebate_cost"].ToString());
                this.d减免金额 = NConvert.ToDecimal(dr["rebate_cost"]);
            }
        }


        
        /// <summary>
        /// 按支付类型显示金额
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="ds"></param>
        protected virtual void SetPayTypeValue(FarPoint.Win.Spread.SheetView sheet, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            string payType = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                payType = dr[0].ToString();
                //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                //Neusoft.HISFC.Models.Fee.EnumPayType ePayType = (Neusoft.HISFC.Models.Fee.EnumPayType)
                //    Enum.Parse(typeof(Neusoft.HISFC.Models.Fee.EnumPayType), payType);
                string ePayType = payType;
                switch (ePayType)
                {
                    case "CA": //现金
                        {
                            //this.SetOneCellText(sheet, "A023", Report.ReportClass.DealCent(Neusoft.FrameWork.Function.NConvert.ToDecimal(dr[1].ToString())).ToString());
                            this.SetOneCellText(sheet, "A023", (this.d合计 - this.d省保大额 - this.d省保公务员 - this.d省保统筹 - this.d省保账户 - this.d市保大额 - this.d市保统筹 - this.d市保账户 - this.d公费医疗 - this.d公费账户 - this.d减免金额).ToString());//{0EA3CF1A-2F03-46c3-83AE-1543B00BBDDB}
                            string strValue = GetOneCellText(sheet, "A011");
                            decimal tempTotCost = this.d合计 - this.d省保大额 - this.d省保公务员 - this.d省保统筹 - this.d省保账户 - this.d市保大额 - this.d市保统筹 - this.d市保账户 - this.d公费医疗 - this.d公费账户 - this.d减免金额;
                            this.SetOneCellText(sheet, "A1000", Neusoft.FrameWork.Public.String.LowerMoneyToUpper(tempTotCost));
                            //decimal tempTotCost = NConvert.ToDecimal(dr[1]) - NConvert.ToDecimal(strValue);
                            //this.SetOneCellText(sheet, "A1000", Neusoft.FrameWork.Public.String.LowerMoneyToUpper(tempTotCost));
                            break;
                        }
                    case "CH": //支票
                        {
                            this.SetOneCellText(sheet, "A024", dr[1].ToString());
                            break;
                        }
                    case "CD"://银联
                        {
                            this.SetOneCellText(sheet, "A025", dr[1].ToString());
                            break;
                        }
                }
            }
        }
        #endregion

        #region 查询已日结数据
        private void QueryDayBalanceRecord()
        {
            // 返回值
            int intReturn = 0;
            // 查询的起始时间
            DateTime dtFrom = DateTime.MinValue;
            // 查询的截止时间
            DateTime dtTo = DateTime.MinValue;
            // 返回的日志记录
            ArrayList balanceRecord = new ArrayList();
            // 查询的日记流水号
            string sequence = "";

            //清除数据
            int count = this.ucClinicDayBalanceReportNew2.neuSpread1_Sheet1.Rows.Count;
            if (count > 0)
            {
                this.ucClinicDayBalanceReportNew2.neuSpread1_Sheet1.Rows.Remove(0, count);
            }

            // 获取查询时间
            intReturn = this.ucReprintDateControl1.GetInputDateTime(ref dtFrom, ref dtTo);
            if (intReturn == -1)
            {
                return;
            }

            // 获取查询结果
            intReturn = this.clinicDayBalance.GetBalanceRecord(this.currentOperator, dtFrom, dtTo, ref balanceRecord);
            if (intReturn == -1)
            {
                MessageBox.Show("获取日志记录失败");
                return;
            }

            string begin = string.Empty, end = string.Empty;

            // 判断结果记录数，如果多条，那么弹出窗口让用户选择
            if (balanceRecord.Count > 1)
            {
                frmConfirmBalanceRecord confirmBalanceRecord = new frmConfirmBalanceRecord();
                confirmBalanceRecord.BalanceRecord = balanceRecord;
                if (confirmBalanceRecord.ShowDialog() == DialogResult.OK)
                {
                    sequence = confirmBalanceRecord.fpSpread1.Sheets[0].Cells[confirmBalanceRecord.fpSpread1.Sheets[0].ActiveRowIndex, 0].Text;
                    begin = confirmBalanceRecord.fpSpread1.Sheets[0].Cells[confirmBalanceRecord.fpSpread1.Sheets[0].ActiveRowIndex, 1].Text;
                    end = confirmBalanceRecord.fpSpread1.Sheets[0].Cells[confirmBalanceRecord.fpSpread1.Sheets[0].ActiveRowIndex, 2].Text;
                }
                else
                {
                    return;
                }
            }
            else
            {
                foreach (NeuObject obj in balanceRecord)
                {
                    sequence = obj.ID;
                    begin = obj.Name;
                    end = obj.Memo;
                }
            }
            //设置报表信息
            this.SetInfo(begin, end, 1);
            //查找日结数据
            DataSet ds = new DataSet();
            intReturn = clinicDayBalance.GetDayBalanceRecord(sequence, ref ds);
            if (intReturn == -1)
            {
                MessageBox.Show(clinicDayBalance.Err);
                return;
            }
            if (ds.Tables.Count == 0 || ds == null || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("该时间段内没有要查找的数据！");
                return;
            }
            SetOldFarPointData(ds.Tables[0]);
            ds.Dispose();
        }
        #endregion

        #region 设置已日结Farpoint数据
        private void SetOldFarPointData(DataTable table)
        {
            FarPoint.Win.Spread.SheetView sheet = this.ucClinicDayBalanceReportNew2.neuSpread1_Sheet1;
            int rowCount = sheet.Rows.Count;
            if (sheet.Rows.Count > 0)
            {
                sheet.Rows.Remove(0, rowCount - 1);
            }
            DataView dv = table.DefaultView;
            //设置项目明细
            SetDetialed(sheet, dv);
            this.ucClinicDayBalanceReportNew2.SetFarPoint();
            this.SetInvoiced(sheet, dv);
            this.SetMoneyed(sheet, dv);
        }

        /// <summary>
        /// 设置已日结发票信息
        /// </summary>
        /// <param name="sheet">FarPoint.Win.Spread.SheetView</param>
        /// <param name="dv">DataView</param>
        protected virtual void SetInvoiced(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            dv.RowFilter = "BALANCE_ITEM='5'";
            this.SetFarpointValue(sheet, dv);
        }

        protected virtual void SetMoneyed(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            dv.RowFilter = "BALANCE_ITEM='6'";
            this.SetFarpointValue(sheet, dv);
        }

        protected virtual void SetFarpointValue(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            if (dv.Count > 0)
            {
                string fieldStr = string.Empty;
                string tagStr = string.Empty;
                string field = string.Empty;
                int Index = 0;
                for (int k = 0; k < dv.Count; k++)
                {
                    fieldStr = dv[k]["sort_id"].ToString();
                    int index = fieldStr.IndexOf('、');
                    if (index == -1)
                    {
                        Index = fieldStr.IndexOf("|");
                        tagStr = fieldStr.Substring(0, Index);
                        field = fieldStr.Substring(Index + 1);
                        SetOneCellText(sheet, tagStr, dv[k][field].ToString());
                        if (dv[k][1].ToString() == "A023")
                        {
                            SetOneCellText(sheet, "A1000", Neusoft.FrameWork.Public.String.LowerMoneyToUpper(NConvert.ToDecimal(dv[k][field])));
                        }
                    }
                    else
                    {
                        string[] aField = fieldStr.Split('、');
                        if (aField.Length == 0) continue;
                        foreach (string s in aField)
                        {
                            Index = s.IndexOf("|");
                            tagStr = s.Substring(0, Index);
                            field = s.Substring(Index + 1);
                            SetOneCellText(sheet, tagStr, dv[k][field].ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置已日结项目明细
        /// </summary>
        /// <param name="sheet">FarPoint.Win.Spread.SheetView</param>
        /// <param name="dv">DataView</param>
        private void SetDetialed(FarPoint.Win.Spread.SheetView sheet, DataView dv)
        {
            #region 显示项目数据
            //项目数据
            dv.RowFilter = "BALANCE_ITEM='4'";
            int count = dv.Count;
            decimal countMoney = 0;
            if (count > 0)
            {
                if (count % 2 == 0)
                {
                    sheet.Rows.Count = Convert.ToInt32(count / 2);
                }
                else
                {
                    sheet.Rows.Count = Convert.ToInt32(count / 2) + 1;
                }

                //显示项目数据
                for (int i = 0; i < count; i++)
                {
                    int index = Convert.ToInt32(i / 2);
                    int intMod = (i + 1) % 2;
                    if (intMod > 0)
                    {
                        sheet.Models.Span.Add(index, 0, 1, 2);
                        sheet.Cells[index, 0].Text = dv[i]["extent_field1"].ToString();
                        sheet.Cells[index, 2].Text = dv[i]["tot_cost"].ToString();
                    }
                    else
                    {
                        sheet.Models.Span.Add(index, 3, 1, 2);
                        sheet.Cells[index, 3].Text = dv[i]["extent_field1"].ToString();
                        sheet.Cells[index, 5].Text = dv[i]["tot_cost"].ToString();
                    }
                    countMoney += Convert.ToDecimal(dv[i][0]);

                }
                if (count % 2 > 0)
                {
                    sheet.Models.Span.Add(sheet.Rows.Count - 1, 3, 1, 2);
                }
                //显示合计
                sheet.Rows.Count += 1;
                count = sheet.Rows.Count;
                sheet.Models.Span.Add(count - 1, 0, 1, 2);
                sheet.Cells[count - 1, 0].Text = "合计：";
                sheet.Models.Span.Add(count - 1, 2, 1, 4);
                sheet.Cells[count - 1, 2].Text = countMoney.ToString();
            }
            #endregion
        }
        #endregion

        #region 按tag读取FarPoint的cell数据
        /// <summary>
        /// 设置单个Cell的Text
        /// </summary>
        /// <param name="sheet">SheetView</param>
        /// <param name="tagStr">Cell的tag</param>
        /// <param name="strText">要显示的Text</param>
        private void SetOneCellText(FarPoint.Win.Spread.SheetView sheet, string tagStr, string strText)
        {
            FarPoint.Win.Spread.Cell cell = sheet.GetCellFromTag(null, tagStr);
            if (cell != null)
            {
                FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
                t.Multiline = true;
                t.WordWrap = true;
                cell.CellType = t;
                //把字符串转换成数字进行相加，成功后转回字符串
                try
                {
                    if (cell.Text == string.Empty || cell.Text == null)
                    {
                        cell.Text = "0";
                    }
                    if (strText == string.Empty || strText == null)
                    {
                        strText = "0";
                    }
                    decimal intText = (Convert.ToDecimal(cell.Text) + Convert.ToDecimal(strText));
                    cell.Text = intText.ToString();
                }
                //如果转换失败则把字符串相加
                catch
                {
                    if (cell.Text == "0")
                    {
                        cell.Text = "";
                    }
                    if (strText == "0")
                    {
                        strText = "";
                    }
                    cell.Text += strText;
                }
                //相加结果为零，变成空字符串
                if (cell.Text == "0")
                {
                    cell.Text = "";
                }
                //      cell.Text += strText;
            }
        }

        private string GetOneCellText(FarPoint.Win.Spread.SheetView sheet, string tagStr)
        {
            FarPoint.Win.Spread.Cell cell = sheet.GetCellFromTag(null, tagStr);
            if (cell != null)
                return cell.Text;
            return string.Empty;
        }
        #endregion

        #region 设置报表信息（起止时间、操作员)
        /// <summary>
        /// 设置报表信息（起止时间、操作员)
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <param name="aMode">0：本次日结　1：查询历史日结　</param>
        protected virtual void SetInfo(string beginDate, string endDate, int aMode)
        {
            //显示报表日结时间和收款员
            string strSpace = "               ";
            string strInfo = "收费员：" + currentOperator.Name + strSpace +
                "起始时间：" + beginDate + strSpace + "截止时间：" + endDate;
            if (aMode == 0)
                this.ucClinicDayBalanceReportNew1.lblReportInfo.Text = strInfo;
            else
                this.ucClinicDayBalanceReportNew2.lblReportInfo.Text = strInfo;
        }
        #endregion

        #region 设置日结实体

        /// <summary>
        /// 获得日结实体
        /// </summary>
        private void SetDayBalanceData()
        {
            FarPoint.Win.Spread.SheetView sheet = this.ucClinicDayBalanceReportNew1.neuSpread1_Sheet1;
            string strValue = string.Empty;

            #region 起止发票号
            dayBalance = new Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew();
            dayBalance.InvoiceNO.ID = "A001";
            dayBalance.InvoiceNO.Name = "起始结束票据号";
            strValue = GetOneCellText(sheet, "A00101");
            dayBalance.BegionInvoiceNO = strValue;
            strValue = GetOneCellText(sheet, "A00102");
            dayBalance.EndInvoiceNo = strValue;
            //设置Cell显示数据的Tag和字段名称
            dayBalance.SortID = "A00101|EXTENT_FIELD2、A00102|EXTENT_FIELD3";
            dayBalance.TypeStr = "5";
            this.SetDayBalance();
            #endregion

            #region 票据总数
            strValue = GetOneCellText(sheet, "A002");
            this.SetOneCellDayBalance("A002", "票据总数", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 有效票据
            strValue = GetOneCellText(sheet, "A003");
            this.SetOneCellDayBalance("A003", "有效票据", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 退费票据
            dayBalance = new Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew();
            dayBalance.InvoiceNO.ID = "A004";
            dayBalance.InvoiceNO.Name = "退费票据";
            //票据数
            strValue = this.GetOneCellText(sheet, "A00401");
            dayBalance.TotCost = NConvert.ToDecimal(strValue);
            //票据号
            strValue = this.GetOneCellText(sheet, "A00402");
            dayBalance.CancelInvoiceNo = strValue;
            dayBalance.TypeStr = "5";
            dayBalance.SortID = "A00401|TOT_COST、A00402|EXTENT_FIELD5";
            this.SetDayBalance();
            #endregion

            #region 作废票据
            dayBalance = new Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew();
            dayBalance.InvoiceNO.ID = "A005";
            dayBalance.InvoiceNO.Name = "作废票据";
            strValue = this.GetOneCellText(sheet, "A00501");
            dayBalance.TotCost = NConvert.ToDecimal(strValue);
            strValue = this.GetOneCellText(sheet, "A00502");
            dayBalance.FalseInvoiceNo = strValue;
            dayBalance.TypeStr = "5";
            dayBalance.SortID = "A00501|TOT_COST、A00502|EXTENT_FIELD4";
            this.SetDayBalance();
            #endregion

            #region 退费金额
            strValue = GetOneCellText(sheet, "A006");
            this.SetOneCellDayBalance("A006", "退费金额", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 作废金额
            strValue = GetOneCellText(sheet, "A007");
            this.SetOneCellDayBalance("A007", "作废金额", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 暂时无数据
            #region 押金金额
            strValue = GetOneCellText(sheet, "A008");
            this.SetOneCellDayBalance("A008", "押金金额", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 退押金额
            strValue = GetOneCellText(sheet, "A009");
            this.SetOneCellDayBalance("A009", "退押金额", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region  减免金额
            strValue = GetOneCellText(sheet, "A010");
            this.SetOneCellDayBalance("A010", "减免金额", NConvert.ToDecimal(strValue), "5");
            #endregion
            #endregion

            #region  四舍五入
            strValue = GetOneCellText(sheet, "A011");
            this.SetOneCellDayBalance("A011", "四舍五入", NConvert.ToDecimal(strValue), "5");
            #endregion

            #region 公费医疗
            strValue = this.GetOneCellText(sheet, "A012");
            SetOneCellDayBalance("A012", "公费医疗", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 公费自付
            strValue = this.GetOneCellText(sheet, "A013");
            SetOneCellDayBalance("A013", "公费自费", NConvert.ToDecimal(strValue), "6");
            #endregion
            #region 公费账户
            strValue = this.GetOneCellText(sheet, "A026");
            SetOneCellDayBalance("A026", "公费账户", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 市保自付
            strValue = this.GetOneCellText(sheet, "A014");
            SetOneCellDayBalance("A014", "市保自费", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 市保账户
            strValue = this.GetOneCellText(sheet, "A015");
            SetOneCellDayBalance("A015", "市保账户", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 市保统筹
            strValue = this.GetOneCellText(sheet, "A016");
            SetOneCellDayBalance("A016", "市保统筹", NConvert.ToDecimal(strValue), "6");

            #endregion

            #region 市保大额
            strValue = this.GetOneCellText(sheet, "A017");
            SetOneCellDayBalance("A017", "市保大额", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 省保自付
            strValue = this.GetOneCellText(sheet, "A018");
            SetOneCellDayBalance("A018", "省保自费", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 省保账户
            strValue = this.GetOneCellText(sheet, "A019");
            SetOneCellDayBalance("A019", "省保账户", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 省保统筹
            strValue = this.GetOneCellText(sheet, "A020");
            SetOneCellDayBalance("A020", "省保统筹", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 省保大额
            strValue = this.GetOneCellText(sheet, "A021");
            SetOneCellDayBalance("A021", "省保大额", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 省公务员
            strValue = this.GetOneCellText(sheet, "A022");
            SetOneCellDayBalance("A022", "省公务员", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 上缴现金额
            strValue = this.GetOneCellText(sheet, "A023");
            SetOneCellDayBalance("A023", "上缴现金额", NConvert.ToDecimal(strValue), "6");

            #endregion

            #region 上缴支票额
            strValue = this.GetOneCellText(sheet, "A024");
            SetOneCellDayBalance("A024", "上缴支票额", NConvert.ToDecimal(strValue), "6");
            #endregion

            #region 上缴银联额
            strValue = this.GetOneCellText(sheet, "A025");
            SetOneCellDayBalance("A025", "上缴银联额", NConvert.ToDecimal(strValue), "6");
            #endregion
        }
        /// <summary>
        /// 查找要日结的数据
        /// </summary>
        protected virtual void SetDayBalance()
        {
            dayBalance.BeginTime = NConvert.ToDateTime(this.lastDate);
            dayBalance.EndTime = NConvert.ToDateTime(this.dayBalanceDate);
            dayBalance.Oper.ID = currentOperator.ID;
            dayBalance.Oper.Name = currentOperator.Name;
            this.alData.Add(dayBalance);
        }
        /// <summary>
        /// 设置单个金额实体（只存一个金额或数量）
        /// </summary>
        /// <param name="InvoiceID">统计大类编码</param>
        /// <param name="InvoiceName">统计大类名称</param>
        /// <param name="Money">金额</param>
        /// <param name="typeStr">类别</param>
        private void SetOneCellDayBalance(string InvoiceID, string InvoiceName, decimal Money, string typeStr)
        {
            dayBalance = new Neusoft.Report.Finance.FinOpb.Class.ClinicDayBalanceNew();
            dayBalance.InvoiceNO.ID = InvoiceID;
            dayBalance.InvoiceNO.Name = InvoiceName;
            dayBalance.TotCost = Money;
            dayBalance.TypeStr = typeStr;
            dayBalance.SortID = InvoiceID + "|" + "TOT_COST";
            this.SetDayBalance();
        }
        #endregion

        #region 保存日结数据
        /// <summary>
        /// 保存日结数据
        /// </summary>
        public void DayBalance()
        {
            if (this.alData == null || this.alData.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("是否进行日结,日结后数据将不能恢复?", "门诊收款员缴款日报", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //
                // 变量定义
                //
                // 返回值
                int intReturn = 0;
                // 事务对象

                //Neusoft.FrameWork.Management.Transaction transaction = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                // 等待窗口
                Neusoft.FrameWork.WinForms.Forms.frmWait waitForm = new Neusoft.FrameWork.WinForms.Forms.frmWait();
                // 门诊收费业务层
                Neusoft.HISFC.BizLogic.Fee.Outpatient outpatient = new Neusoft.HISFC.BizLogic.Fee.Outpatient();
                // 日结序号
                string sequence = "";

                //
                // 判断合法性
                //
                if (!this.enableBalance)
                {
                    MessageBox.Show("不能进行日结");
                    return;
                }
                if (this.alData == null)
                {
                    return;
                }

                // 启动等待窗口
                waitForm.Tip = "正在进行日结";
                waitForm.Show();

                //
                // 设置事务
                //
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //transaction.BeginTransaction();
                this.clinicDayBalance.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                outpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //
                // 保存日结数据
                //
                this.operateDate = this.clinicDayBalance.GetDateTimeFromSysDateTime().ToString();
                // 获取日结序号
                intReturn = this.clinicDayBalance.GetBalanceSequence(ref sequence);
                if (intReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    waitForm.Hide();
                    MessageBox.Show("获取日结序列号失败");
                    return;
                }
                //获得日结实体
                this.SetDayBalanceData();
                foreach (Class.ClinicDayBalanceNew tempBalance in this.alData)
                {
                    tempBalance.BlanceNO = sequence;
                    tempBalance.Oper.OperTime = DateTime.Parse(this.operateDate);
                    intReturn = clinicDayBalance.InsertClinicDayBalance(tempBalance);
                    if (intReturn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        waitForm.Hide();
                        MessageBox.Show("日结失败" + outpatient.Err);
                        return;
                    }
                }

                //
                // 更新其他表
                //
                // 更新发票主表表FIN_OPB_INVOICEINFO
                intReturn = outpatient.UpdateInvoiceForDayBalance(DateTime.Parse(this.lastDate),
                    DateTime.Parse(this.dayBalanceDate),
                    "1",
                    sequence,
                    DateTime.Parse(this.operateDate));
                if (intReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    waitForm.Hide();
                    MessageBox.Show("更新发票主表失败" + outpatient.Err);
                    return;
                }
                // 更新发票明细表FIN_OPB_INVOICEDETAIL
                intReturn = outpatient.UpdateInvoiceDetailForDayBalance(DateTime.Parse(this.lastDate),
                    DateTime.Parse(this.dayBalanceDate),
                    "1",
                    sequence,
                    DateTime.Parse(this.operateDate));
                if (intReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    waitForm.Hide();
                    MessageBox.Show("更新发票明细表失败");
                    return;
                }
                // 更新支付情况表FIN_OPB_PAYMODE
                intReturn = outpatient.UpdatePayModeForDayBalance(DateTime.Parse(this.lastDate),
                    DateTime.Parse(this.dayBalanceDate),
                    "1",
                    sequence,
                    DateTime.Parse(this.operateDate));
                if (intReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    waitForm.Hide();
                    MessageBox.Show("更新支付情况表失败" + outpatient.Err);
                    return;
                }

                //
                // 保存成功
                //
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                waitForm.Hide();
                MessageBox.Show("日结成功完成");
                PrintInfo(this.neuPanel1);
                alData.Clear();
                // 设置上次日结时间显示
                //this.ucClinicDayBalanceDateControl1.tbLastDate.Text = this.dayBalanceDate;
                //this.ucClinicDayBalanceDateControl1.dtpBalanceDate.Value = this.clinicDayBalance.GetDateTimeFromSysDateTime();
            }
        }
        #endregion

        #region 事件
        private void ucClinicDayBalanceNew_Load(object sender, EventArgs e)
        {
            this.InitUC();
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.neuTabControl1.SelectedIndex == 0)
                QueryDayBalanceData();
            else
                this.QueryDayBalanceRecord();

            return base.OnQuery(sender, neuObject);
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitUC();

            toolBarService.AddToolButton("日结", "保存日结信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);

            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "日结")
            {
                // 日结
                if (this.enableBalance)
                {
                    this.DayBalance();
                }
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            switch (neuTabControl1.SelectedIndex)
            {
                case 0:
                    {
                        this.PrintInfo(this.neuPanel1);
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show(this.panelPrint.Controls.Count.ToString());
                        this.PrintInfo(this.panelPrint);

                        break;
                    }
            }

            return base.OnPrint(sender, neuObject);
        }

        protected virtual void PrintInfo(Neusoft.FrameWork.WinForms.Controls.NeuPanel panelPrint)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, panelPrint);
        }
        #endregion

    }
}
