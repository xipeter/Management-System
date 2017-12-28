using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;//Neusoft.FrameWork.Models.NeuObject;

using Neusoft.FrameWork.Function;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucClinicDayBalance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucClinicDayBalance()
        {
            InitializeComponent();
        }

        #region 变量定义
        /// <summary>
        /// 当前操作员
        /// </summary>
        NeuObject currentOperator = new NeuObject();
        /// <summary>
        /// 当前科室
        /// </summary>
        NeuObject currentDepartment = new NeuObject();

       // Neusoft.NFC.Object
       

        /// <summary>
        /// 日结方法类
        /// </summary>
        Function.ClinicDayBalance clinicDayBalance = new Neusoft.Report.Finance.FinOpb.Function.ClinicDayBalance();

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 上次日结时间
        /// </summary>
        string lastDate = "";

        /// <summary>
        /// 本次日结时间
        /// </summary>
        string dayBalanceDate = "";

        /// <summary>
        /// 日结操作时间
        /// </summary>
        string operateDate = "";

        /// <summary>
        /// 是否可以进行日结（true-可以/false-不可以）
        /// </summary>
        public bool enableBalance = false;

        /// <summary>
        /// 要日结的数据
        /// </summary>
        ArrayList alBalanceData = new ArrayList();
        #endregion

        #region 函数

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

                // 获取当前科室
                currentDepartment = ((Neusoft.HISFC.Models.Base.Employee)(this.clinicDayBalance.Operator)).Dept;

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
                this.ucClinicDayBalanceReport.labelReportDate.Text = this.clinicDayBalance.GetDateTimeFromSysDateTime().ToLongDateString();
                this.ucClinicDayBalanceReport.InitUC();
                this.ucReportReprint.InitUC();
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

        #region 查询本次日结的数据
        /// <summary>
        /// 查询本次日结的数据
        /// </summary>
        public void QueryDayBalanceData()
        {
            //
            // 变量定义
            //
            // 返回的日结数据
            System.Data.DataSet dsBalanceDate = new DataSet();
            // 返回调用的结果
            int intReturn = 0;
            // 查询返回的结果
            ArrayList alDayBalance = new ArrayList();
            // 等待窗口
            Neusoft.FrameWork.WinForms.Forms.frmWait waitForm = new Neusoft.FrameWork.WinForms.Forms.frmWait();

            //
            // 清空现有保存的日结数据
            //
            this.alBalanceData = null;

            //
            // 获取日结截止时间
            //
            intReturn = this.ucClinicDayBalanceDateControl1.GetBalanceDate(ref dayBalanceDate);
            if (intReturn == -1)
            {
                this.enableBalance = false;
                return;
            }

            // 显示等待窗口
            waitForm.Tip = "正在获取并汇总日结数据";
            waitForm.Show();

            //
            // 获取日结数据
            //
            intReturn = this.clinicDayBalance.GetDayBalanceData(this.currentOperator.ID, this.lastDate, dayBalanceDate, ref dsBalanceDate);
            if (intReturn == -1)
            {
                waitForm.Hide();
                MessageBox.Show("获取门诊收款员的日结数据失败" + this.clinicDayBalance.Err);
                this.enableBalance = false;
                return;
            }
            if (dsBalanceDate.Tables[0].Rows.Count == 0)
            {
                waitForm.Hide();
                MessageBox.Show("该时间段没有可用的日结数据");
                this.enableBalance = false;
                return;
            }

            //
            // 计算日结数据
            //
            this.Calculate(dsBalanceDate, ref alDayBalance);

            //
            // 设置FarPoint
            //
            this.SetFarPoint(alDayBalance, this.ucClinicDayBalanceReport.fpSpread1_Sheet1);

            //
            // 保存此次查询的日结数据
            //
            this.alBalanceData = alDayBalance;

            this.enableBalance = true;
            waitForm.Hide();
        }
        #endregion

        #region 计算日结数据
        /// <summary>
        /// 计算日结数据
        /// </summary>
        /// <param name="dsBalanceData">获取的日结数据</param>
        /// <param name="argArrayList">返回的实体数组</param>
        public void Calculate(DataSet dsBalanceData, ref ArrayList argArrayList)
        {
            #region 变量定义

            // 实体数组
            ArrayList alDayBalance = new ArrayList();
            // 前一个发票号
            string priviousInvoice = "";
            // 第一个发票号
            string firstInvoice = "";
            // 是否出现与上一张发票号不同的现象
            bool boolDifferent = false;
            // 发生前后不同的次数
            long intDifferent = 0;
            // 实收金额
            decimal ownCost = 0;
            // 记帐金额
            decimal accountCost = 0;
            // 总金额
            decimal totalCost = 0;
            // 记帐单数
            int accountCount = 0;
            // 前一个日结项目
            string priviousBalanceItem = "";
            // 是否出现与前一张发票不同的日结项目
            bool boolItem = false;
            #endregion

            #region 循环计算
            // 保存第一个发票号
            firstInvoice = dsBalanceData.Tables[0].Rows[0][0].ToString();
            // 初始化前一个发票号
            priviousInvoice = dsBalanceData.Tables[0].Rows[0][0].ToString();
            // 保存第一个日结项目
            priviousBalanceItem = dsBalanceData.Tables[0].Rows[0][4].ToString();

            // 循环计算
            foreach (DataRow drData in dsBalanceData.Tables[0].Rows)
            {
                // 日结实体类
                Class.ClinicDayBalance dayBalance = new Class.ClinicDayBalance();
                // 当前发票号
                string currentInvoice = "";
                // 实收金额
                decimal decOwnCost = 0;
                // 记帐金额
                decimal decAccountCost = 0;
                // 总金额
                decimal decTotalCost = 0;
                // 记帐单数
                //int intAccountCount = 0;
                // 日结项目
                string stringItem = "";

                // 获取当前发票号
                currentInvoice = drData[0].ToString();

                // 获取当前日结项目
                stringItem = drData[4].ToString();

                // 获取各种金额
                decOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(drData[1].ToString());
                decAccountCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(drData[2].ToString());
                decTotalCost =  Neusoft.FrameWork.Function.NConvert.ToDecimal(drData[5].ToString());

                // 如果前一次循环发生发票号不连续，那么重新获取第一张发票号
                if (boolDifferent)
                {
                    firstInvoice = priviousInvoice;
                    boolDifferent = false;
                }

                // 如果前一次循环发生项目不同，那么重新获取前一次项目
                if (boolItem)
                {
                    firstInvoice = priviousInvoice;
                    boolItem = false;
                }

                //
                // 如果当前日结项目与前一个日结项目不同，需要作为一个实体，并且设置第一张发票号为当前发票号
                //
                if (stringItem != priviousBalanceItem)
                {
                    //
                    // 设置实体
                    //
                    this.SetEntity(firstInvoice, priviousInvoice, priviousBalanceItem, ownCost, accountCost, totalCost, accountCount, ref dayBalance);

                    // 存储到实体数组
                    alDayBalance.Add(dayBalance);

                    // 设置辅助变量
                    priviousInvoice = currentInvoice;
                    firstInvoice = currentInvoice;
                    boolItem = true;
                    intDifferent++;
                    ownCost = 0;
                    accountCost = 0;
                    totalCost = 0;
                    accountCount = 0;
                }
                else if ((currentInvoice != priviousInvoice) && (long.Parse(priviousInvoice) != (long.Parse(currentInvoice) - 1)))
                {
                    //
                    // 如果发生发票号不连续，则计算发票数据，同时计数
                    //
                    // 设置实体
                    //
                    this.SetEntity(firstInvoice, priviousInvoice, priviousBalanceItem, ownCost, accountCost, totalCost, accountCount, ref dayBalance);

                    // 存储到实体数组
                    alDayBalance.Add(dayBalance);

                    // 设置辅助变量
                    boolDifferent = true;
                    firstInvoice = currentInvoice;
                    intDifferent++;
                    ownCost = 0;
                    accountCost = 0;
                    totalCost = 0;
                    accountCount = 0;
                }
                //else
                {
                    // 汇总各种金额
                    ownCost += decOwnCost;
                    accountCost += decAccountCost;
                    totalCost += decTotalCost;

                    // 合计记帐单数
                    if (drData[5].ToString() == "2")
                    {
                        accountCount++;
                    }
                }

                // 存储当前发票号作为下次循环的上一次发票号
                priviousInvoice = drData[0].ToString();

                // 存储当前项目类别作为下次循环的上一次日结项目
                priviousBalanceItem = drData[4].ToString();
            }

            // 如果计数器为0，说明一个不同项目、断号都没有
            if (intDifferent == 0)
            {
                // 日结实体类
                Class.ClinicDayBalance dayBalance = new Class.ClinicDayBalance();
                // 当前发票号
                string currentInvoice = "";
                firstInvoice = dsBalanceData.Tables[0].Rows[0][0].ToString();

                ownCost = 0;
                totalCost = 0;
                accountCost = 0;
                accountCount = 0;
                foreach (DataRow drData in dsBalanceData.Tables[0].Rows)
                {
                    // 当前发票号
                    currentInvoice = drData[0].ToString();
                    // 实收金额
                    ownCost += decimal.Parse(drData[1].ToString());
                    // 记帐金额
                    accountCost += decimal.Parse(drData[2].ToString());
                    // 总金额
                    totalCost += decimal.Parse(drData[5].ToString());
                    // 记帐单数量
                    if (drData[5].ToString() == "2")
                    {
                        accountCount++;
                    }
                    // 日结项目
                    priviousBalanceItem = drData[3].ToString();
                }

                // 设置实体
                this.SetEntity(firstInvoice, currentInvoice, priviousBalanceItem, ownCost, accountCost, totalCost, accountCount, ref dayBalance);
                alDayBalance.Add(dayBalance);
            }
            else
            {
                Class.ClinicDayBalance dayBalance = new Class.ClinicDayBalance();
                this.SetEntity(firstInvoice, priviousInvoice, priviousBalanceItem, ownCost, accountCost, totalCost, accountCount, ref dayBalance);
                alDayBalance.Add(dayBalance);
            }
            argArrayList = alDayBalance;
            #endregion
        }
        #endregion

        #region 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="argPriInvoice">前一个发票号</param>
        /// <param name="argCurrInvoice">当前发票号</param>
        /// <param name="argOwnCost">实收金额</param>
        /// <param name="argLeftCost">记帐金额</param>
        /// <param name="argTotalCost">总金额</param>
        /// <param name="argAccount">记帐单数</param>
        /// <param name="argDayBalance">返回的实体</param>
        public void SetEntity(string argPriInvoice, string argCurrInvoice, string argItem,
            decimal argOwnCost, decimal argLeftCost, decimal argTotalCost,
            int argAccount, ref Class.ClinicDayBalance argDayBalance)
        {
            // 发票号
            if (argPriInvoice != argCurrInvoice)
            {
                argDayBalance.InvoiceNo = argPriInvoice + "～" + argCurrInvoice;
            }
            else
            {
                argDayBalance.InvoiceNo = argCurrInvoice;
            }
            // 发票张数
            argDayBalance.Memo = (long.Parse(argCurrInvoice) - long.Parse(argPriInvoice) + 1).ToString();
            // 实收金额
            argDayBalance.Cost.OwnCost = argOwnCost;
            // 记帐金额
            argDayBalance.Cost.LeftCost = argLeftCost;
            // 总金额
            argDayBalance.Cost.TotCost = argTotalCost;
            // 日结项目
            if (argItem == "1")
            {
                argDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
            }
            else if (argItem == "0")
            {
                argDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
            }
            else if (argItem == "2")
            {
                argDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.Reprint;
            }
            else
            {
                argDayBalance.BalanceItem = Neusoft.HISFC.Models.Base.CancelTypes.LogOut;
            }
            // 记帐单数目
            argDayBalance.AccountNumber = argAccount;
            // 起始时间
            if (DateTime.MinValue == DateTime.Parse(this.lastDate))
            {
                // 如果没有作过日结，那么将上次日结时间设置成去年今天的零点
                DateTime dtToday = new DateTime();
                dtToday = this.clinicDayBalance.GetDateTimeFromSysDateTime();
                this.lastDate = (new System.DateTime(dtToday.Year - 1, dtToday.Month, dtToday.Day, 0, 1, 1)).ToString();
                argDayBalance.BeginDate = DateTime.Parse(this.lastDate);
            }
            else
            {
                argDayBalance.BeginDate = NConvert.ToDateTime(this.lastDate);
            }
            // 截止时间
            argDayBalance.EndDate = NConvert.ToDateTime(this.dayBalanceDate);
            // 操作员编码
            argDayBalance.BalanceOperator = this.currentOperator;
            // 财务审核
            argDayBalance.CheckFlag = "1";
            // 审核人
            argDayBalance.CheckOperator = new NeuObject();
            // 审核时间
            argDayBalance.CheckDate = DateTime.MinValue;
        }
        #endregion

        #region 设置FarPoint
        /// <summary>
        /// 设置FarPoint
        /// </summary>
        /// <param name="alDayBalance">实体数组</param>
        /// <param name="sheet">要显示的FarPoint</param>
        public void SetFarPoint(ArrayList alDayBalance, FarPoint.Win.Spread.SheetView sheet)
        {
            // 发票张数
            long invoiceCount = 0;
            // 实收金额
            decimal ownCost = 0;
            // 记帐金额
            decimal leftCost = 0;
            // 总金额
            decimal totalCost = 0;
            // 记帐单数量
            long accountCount = 0;
            // 行号
            int intRow = 0;

            // 清空FarPoint
            sheet.RowCount = 0;

            // 循环插值
            foreach (Class.ClinicDayBalance dayBalance in alDayBalance)
            {
                if (dayBalance.Memo != string.Empty)
                {
                    invoiceCount += long.Parse(dayBalance.Memo);
                }
                ownCost += dayBalance.Cost.OwnCost;
                leftCost += dayBalance.Cost.LeftCost;
                totalCost += dayBalance.Cost.TotCost;
                accountCount += dayBalance.AccountNumber;

                // 插入新行
                sheet.AddRows(sheet.RowCount, 1);

                // 获取插入的行号
                intRow = sheet.RowCount - 1;

                // 发票号
                sheet.Cells[intRow, 0].Text = dayBalance.InvoiceNo;
                // 发票张数
                sheet.Cells[intRow, 1].Text = dayBalance.Memo;
                // 实收金额
                sheet.Cells[intRow, 2].Text = dayBalance.Cost.OwnCost.ToString();
                // 记帐金额
                sheet.Cells[intRow, 3].Text = dayBalance.Cost.LeftCost.ToString();
                // 总金额
                sheet.Cells[intRow, 4].Text = dayBalance.Cost.TotCost.ToString();
                // 记帐单数量
                sheet.Cells[intRow, 5].Text = dayBalance.AccountNumber.ToString();
                // 日结项目
                //if (dayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Valid)
                //{
                //    sheet.Cells[intRow, 6].Text = "正常";
                //}
                //else if (dayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Canceled)
                //{
                //    sheet.Cells[intRow, 6].Text = "退费";
                //}
                //else if (dayBalance.BalanceItem == Neusoft.HISFC.Models.Base.CancelTypes.Reprint)
                //{
                //    sheet.Cells[intRow, 6].Text = "重打";
                //}
                //else
                //{
                //    sheet.Cells[intRow, 6].Text = "注销";
                //}
            }

            //
            // 合计项目
            //
            // 插入新行
            sheet.AddRows(sheet.RowCount, 1);
            // 获取插入的行号
            intRow = sheet.RowCount - 1;
            // 赋值
            sheet.Cells[intRow, 0].Text = "合计";
            sheet.Cells[intRow, 1].Text = invoiceCount.ToString();
            sheet.Cells[intRow, 2].Text = ownCost.ToString();
            sheet.Cells[intRow, 3].Text = leftCost.ToString();
            sheet.Cells[intRow, 4].Text = totalCost.ToString();
            sheet.Cells[intRow, 5].Text = accountCount.ToString();
            sheet.Cells[intRow, 6].Text = "";

            //
            // 合并表格
            //
            //大写实收金额
            sheet.AddRows(sheet.RowCount, 1);
            intRow = sheet.RowCount - 1;
            sheet.Models.Span.Add(intRow, 0, 1, 7);
            sheet.Cells[intRow, 0].Text = "实收金额(大写): " + NConvert.ToCapital(decimal.Parse(sheet.Cells[intRow - 1, 4].Text));
            if (sheet.Cells[intRow - 1, 4].Text == "0")
            {
                sheet.Cells[intRow, 0].Text = "实收金额(大写): 零元零角零分";
            }
            // 操作员信息
            sheet.AddRows(sheet.RowCount, 1);
            intRow = sheet.RowCount - 1;
            sheet.Models.Span.Add(intRow, 0, 1, 3);
            sheet.Models.Span.Add(intRow, 3, 1, 4);
            sheet.Cells[intRow, 0].Text = "缴款人: " + this.currentOperator.Name;
            sheet.Cells[intRow, 3].Text = "收款员: " + this.currentOperator.Name;
            sheet.Cells[intRow, 3].HorizontalAlignment =  FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            // 填表人和出纳员
            sheet.AddRows(sheet.RowCount, 1);
            intRow = sheet.RowCount - 1;
            sheet.Models.Span.Add(intRow, 0, 1, 3);
            sheet.Models.Span.Add(intRow, 3, 1, 4);
            sheet.Cells[intRow, 0].Text = "填表人: " + "".PadLeft(this.currentOperator.Name.Length * 2, ' ');
            sheet.Cells[intRow, 3].Text = "出纳员: " + "".PadLeft(this.currentOperator.Name.Length * 2, ' ');
            sheet.Cells[intRow, 3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            // 统计时间
            sheet.AddRows(sheet.RowCount, 1);
            intRow = sheet.RowCount - 1;
            sheet.Models.Span.Add(intRow, 0, 1, 7);
            if (this.tabControl1.SelectedIndex == 0)
            {
                sheet.Cells[intRow, 0].Text = "统计时间: " + this.lastDate + " 至 " + this.dayBalanceDate;
            }
            else
            {
                foreach (Class.ClinicDayBalance dayBalance in alDayBalance)
                {
                    sheet.Cells[intRow, 0].Text = "统计时间: " + dayBalance.BeginDate + " 至 " + dayBalance.EndDate;
                    return;
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="argPanel">要打印的Panel</param>
        public void PrintPanel(System.Windows.Forms.Panel argPanel)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, argPanel);
        }
        #endregion

        #region 保存日结数据
        /// <summary>
        /// 保存日结数据
        /// </summary>
        public void DayBalance()
        {
            if (this.alBalanceData == null)
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
                if (this.alBalanceData == null)
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
                foreach (Class.ClinicDayBalance tempBalance in this.alBalanceData)
                {
                    tempBalance.BalanceSequence = sequence;
                    tempBalance.BalanceDate = DateTime.Parse(this.operateDate);
                    intReturn = clinicDayBalance.CreateClinicDayBalance(tempBalance);
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
                this.PrintPanel(this.panelPrint);

                alBalanceData = null;

                // 设置上次日结时间显示
                this.ucClinicDayBalanceDateControl1.tbLastDate.Text = this.dayBalanceDate;
                this.ucClinicDayBalanceDateControl1.dtpBalanceDate.Value = this.clinicDayBalance.GetDateTimeFromSysDateTime();
            }
        }
        #endregion

        #region 查询日结记录
        /// <summary>
        /// 查询日结记录
        /// </summary>
        public void QueryBalanceRecorde()
        {
            // 返回值
            int intReturn = 0;
            // 查询的起始时间
            DateTime dtFrom = DateTime.MinValue;
            // 查询的截止时间
            DateTime dtTo = DateTime.MinValue;
            // 返回的日志记录
            ArrayList balanceRecord = new ArrayList();
            // 返回的日志明细
            ArrayList balanceDetail = new ArrayList();
            // 查询的日记流水号
            string sequence = "";

            // 获取查询时间
            intReturn = this.ucReprintDateTime.GetInputDateTime(ref dtFrom, ref dtTo);
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

            // 判断结果记录数，如果多条，那么弹出窗口让用户选择
            if (balanceRecord.Count > 1)
            {
                frmConfirmBalanceRecord confirmBalanceRecord = new frmConfirmBalanceRecord();
                confirmBalanceRecord.BalanceRecord = balanceRecord;
                if (confirmBalanceRecord.ShowDialog() == DialogResult.OK)
                {
                    sequence = confirmBalanceRecord.fpSpread1.Sheets[0].Cells[confirmBalanceRecord.fpSpread1.Sheets[0].ActiveRowIndex, 0].Text;
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
                }
            }

            // 根据日结序号获取日结明细
            intReturn = this.clinicDayBalance.GetDayBalanceDetail(sequence, ref balanceDetail);
            if (intReturn == -1)
            {
                MessageBox.Show("获取日结明细失败！" + this.clinicDayBalance.Err);
            }

            // 设置FarPoint
            this.SetFarPoint(balanceDetail, this.ucReportReprint.fpSpread1_Sheet1);
        }
        #endregion

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.InitUC();

            toolBarService.AddToolButton("日结", "保存日结信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
 	        if(e.ClickedItem.Text == "日结")
            {
                // 日结
                if (this.enableBalance)
                {
                    this.DayBalance();
                }
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            // 查询
            if (this.tabControl1.SelectedIndex == 0)
            {
                // 查询日结数据
                this.QueryDayBalanceData();
            }
            else
            {
                // 查询日结记录
                this.QueryBalanceRecorde();
            }
            
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            // 打印
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (MessageBox.Show("是否打印？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.PrintPanel(this.panelPrint);
                }
            }
            else
            {
                if (MessageBox.Show("是否打印？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.PrintPanel(this.panelReprint);
                }
            }
            
            return base.OnPrint(sender, neuObject);
        }


        #endregion

        #region 按键事件
        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                // 日结
                if (this.enableBalance)
                {
                    this.QueryDayBalanceData();
                }
                else
                {
                    MessageBox.Show("不能进行日结操作!");
                }
                return true;
            }
            else if (keyData == Keys.F5)
            {
                // 查询
                if (this.tabControl1.SelectedIndex == 0)
                {
                    this.QueryDayBalanceData();
                }
                else
                {
                    this.QueryBalanceRecorde();
                }
                return true;
            }
            else if (keyData == Keys.F8)
            {
                // 打印
                if (this.tabControl1.SelectedIndex == 0)
                {
                    if (MessageBox.Show("是否打印？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.PrintPanel(this.panelPrint);
                    }
                }
                else
                {
                    if (MessageBox.Show("是否打印？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.PrintPanel(this.panelReprint);
                    }
                }
                return true;
            }
            else if (keyData == Keys.F12)
            {
                // 退出
                this.ParentForm.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        #endregion
    }
}
