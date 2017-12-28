using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucDayReportNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDayReportNew()
        {
            InitializeComponent();
        }

        #region 变量
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 1统计 2查询补打
        /// </summary>
        protected string OperMode = "0";

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime dtBegin = DateTime.MinValue;
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime dtEnd = DateTime.MinValue;

        /// <summary>
        /// 日结业务层
        /// </summary>
        Functions.DayReport feeDayreport = new Report.InpatientFee.Functions.DayReport();
        private DateTime dtDefaultBeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime("2006-01-01");
        DataSet ds = null;
        private Class.DayReport dayReport = new Report.InpatientFee.Class.DayReport();
        private Class.Item item = null;
        private OperType operType=OperType.DayReport;
        private List<Class.DayReport> listEnviroment = null;
        #endregion

        #region 属性
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DtBegin
        {
            get
            {
                return this.dtBegin;
            }
            set
            {
                this.dtBegin = value;
                this.lblBeginDate.Text = this.dtBegin.ToString();
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DtEnd
        {
            get
            {
                return this.dtEnd;
            }
            set
            {
                this.dtEnd = value;
                this.lblEndDate.Text = this.dtEnd.ToString();
            }
        }
        /// <summary>
        /// 默认开始时间
        /// </summary>
        public DateTime DefaultBeginDate
        {
            get
            {
                return this.dtDefaultBeginDate;
            }
            set
            {
                this.dtDefaultBeginDate = value;
            }
        }
        
        [Description("DayReport：日结　CollectDayReport：汇总"),Browsable(true)]
        public OperType OperationType
        {
            get
            {
                return operType;
            }
            set
            {
                operType = value;
            }
        }
        #endregion

        #region 枚举
        /// <summary>
        /// Farpoint中Cell的tag
        /// </summary>
        private enum EnumColumn
        {
            /// <summary>
            /// 医疗预收款(借方金额)
            /// </summary>
            DebitPrePay,
            /// <summary>
            /// 医疗预收款(贷方金额)
            /// </summary>
            LenderPrePay,
            /// <summary>
            /// 医疗应收款(贷方金额)
            /// </summary>
            LenderPay,
            /// <summary>
            /// 银行存款(借方金额)
            /// </summary>
            DebitBank,
            /// <summary>
            /// 银行存款(贷方金额)
            /// </summary>
            LenderBank,
            /// <summary>
            /// 现金(借方金额)
            /// </summary>
            DebitCACost,
            /// <summary>
            /// 现金(贷方金额)
            /// </summary>
            LenderCACost,

            /// <summary>
            /// 银行卡(借方金额)
            /// </summary>
            DebitBankCard,
            /// <summary>
            /// 银行卡(贷方金额)
            /// </summary>
            LenderBankCard,
            /// <summary>
            /// 院内帐户(借方金额)
            /// </summary>
            DebitYSCost,
            /// <summary>
            /// 院内帐户(贷方金额)
            /// </summary>
            LenderYSCost,
            /// <summary>
            /// 其它预收(借方金额)
            /// </summary>
            DebitOtherPrePay,
            /// <summary>
            /// 其它预收(贷方金额)
            /// </summary>
            LenderOtherPrePay,
            /// <summary>
            /// 血押金(贷方金额)
            /// </summary>
            Blood,
            /// <summary>
            /// 减免医疗(借方金额)
            /// </summary>
            Derate,
            /// <summary>
            /// 公费医疗记账(借方金额)
            /// </summary>
            BusaryPubCost,
            /// <summary>
            /// 市医保帐户(借方金额)
            /// </summary>
            CmedicarePayCost,
            /// <summary>
            /// 市保统筹(借方金额)
            /// </summary>
            CmedicarePubCost,
            /// <summary>
            /// 市保大额(借方金额)
            /// </summary>
            CmedicareOverCost,
            /// <summary>
            /// 省保帐户(借方金额)
            /// </summary>
            PmedicarePayCost,
            /// <summary>
            /// 省医保统筹
            /// </summary>
            PmedicarePubCost,
            /// <summary>
            /// 省保大额
            /// </summary>
            PmedicareOverCost,
            /// <summary>
            /// 省保公务员
            /// </summary>
            PmedicareOfficialCost,
            /// <summary>
            /// 借方合计
            /// </summary>
            DebitSummer,
            /// <summary>
            /// 贷方合计
            /// </summary>
            LenderSummer,
            /// <summary>
            /// 预交金票据号范围
            /// </summary>
            PrePayInvoiceBound,
            /// <summary>
            /// 预交金张数
            /// </summary>
            PrePayInvoiceCount,
            /// <summary>
            /// 预交金有效张数
            /// </summary>
            PrePayUseInvoiceCount,//luoff
            /// <summary>
            /// 预交金作废张数
            /// </summary>
            PrePayWasteInvoiceCount,
            /// <summary>
            /// 预交金作废票据号
            /// </summary>
            PrePayWasteInvoiceNo ,
            /// <summary>
            /// 结算票据号范围
            /// </summary>
            BalanceInvoiceBound,
            /// <summary>
            /// 结算票据张数
            /// </summary>
            BalanceInvoiceCount,
            /// <summary>
            /// 结算票据有效张数
            /// </summary>
            BalanceUseInvoiceCount,//luoff
            /// <summary>
            /// 结算票据作废张数
            /// </summary>
            BalanceWasteInvoiceCount,
            /// <summary>
            /// 结算作废票据号
            /// </summary>
            BalanceWasteInvoiceNo,
            /// <summary>
            /// 上缴现金
            /// </summary>
            PayTotCost,
            /// <summary>
            /// 大写
            /// </summary>
            PayTotCostCapital,
            /// <summary>
            /// 上缴银联
            /// </summary>
            PayBankCardTotCost,
            /// <summary>
            /// 上缴支票额
            /// </summary>
            PayBankTotCost,
        }
        #endregion

        #region 方法

        #region 初始化
        /// <summary>
        /// 初始化函数
        /// </summary>
        protected virtual void Init()
        {

            if (OperationType == OperType.DayReport)
            {
                //初始化时间和操作员
                this.lblOperator.Text = this.feeDayreport.Operator.Name;
                this.DtEnd = this.feeDayreport.GetDateTimeFromSysDateTime();
                //获取上次日结信息实体
                Class.DayReport dayReport = new Report.InpatientFee.Class.DayReport();
                dayReport = this.feeDayreport.GetOperLastDayReport(this.feeDayreport.Operator.ID);
                if (dayReport == null)
                {
                    dayReport = new Report.InpatientFee.Class.DayReport();
                    dayReport.EndDate = this.DefaultBeginDate;
                }
                this.DtBegin = dayReport.EndDate;
            }
            else
            {
                this.panelDayReport.Visible = false;
            }
            this.SetFarPoint(this.neuSpread1_Sheet1);
        }
        #endregion

        #region 设置日结时间
        private void SetDayReprotDate()
        {
            this.DtEnd = this.feeDayreport.GetDateTimeFromSysDateTime();
            //获取上次日结信息实体
            //这里就用全局变量，不然全局变量没有清空 {D1C44D8F-2BFB-4ff3-A689-4E8F42E79251} wbo 2010-08-20
            //Class.DayReport dayReport = new Report.InpatientFee.Class.DayReport();
            dayReport = null;
            dayReport = this.feeDayreport.GetOperLastDayReport(this.feeDayreport.Operator.ID);
            if (dayReport == null)
            {
                dayReport = new Report.InpatientFee.Class.DayReport();
                dayReport.EndDate = this.DefaultBeginDate;
            }
            this.DtBegin = dayReport.EndDate;
        }
        #endregion

        #region 设置FarPoint
        /// <summary>
        /// 设置Farpoint
        /// </summary>
        /// <param name="sheet">SheetView</param>
        private void SetFarPoint(FarPoint.Win.Spread.SheetView sheet)
        {
            if (sheet.Rows.Count > 0)
            {
                sheet.Rows.Remove(0, sheet.Rows.Count);
            }
            int index = 0;
            //合并起止行
            int beginSpan = 0;
            int endSpan = 0;
            //项目合计
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "合计：";
            sheet.Models.Span.Add(index, 1, 1, 3);
            sheet.Cells[index, 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "借方金额";
            sheet.Cells[index, 1].Text = "会计科目";
            sheet.Cells[index, 2].Text = "贷方金额";
            //合并起始行
            beginSpan = index;

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "医疗预收款";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitPrePay.ToString();
            sheet.Cells[index, 0].Note = "双击该单元格可以察看和打印明细";
            sheet.Cells[index, 0].NoteStyle = FarPoint.Win.Spread.NoteStyle.PopupNote;
            sheet.Cells[index, 2].Tag = EnumColumn.LenderPrePay.ToString();
            sheet.Cells[index, 2].Note = "双击该单元格可以察看和打印明细";
            sheet.Cells[index, 2].NoteStyle = FarPoint.Win.Spread.NoteStyle.PopupNote;
           
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "医疗应收款";
            sheet.Cells[index, 2].Tag = EnumColumn.LenderPay.ToString();
            sheet.Cells[index, 2].Note = "双击该单元格可以察看和打印明细";
            sheet.Cells[index, 2].NoteStyle = FarPoint.Win.Spread.NoteStyle.PopupNote;

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "银行存款";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitBank.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderBank.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "现金";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitCACost.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderCACost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "银行卡";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitBankCard.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderBankCard.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "院内帐户";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitYSCost.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderYSCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "其它预收";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitOtherPrePay.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderOtherPrePay.ToString();


            //血押金暂时先去掉
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "血押金";
            sheet.Cells[index, 2].Tag = EnumColumn.Blood.ToString();
            sheet.Rows[index].Visible = false;

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "医疗减免";
            sheet.Cells[index, 0].Tag = EnumColumn.Derate.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "公费医疗记账";
            sheet.Cells[index, 0].Tag = EnumColumn.BusaryPubCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "市保账户";
            sheet.Cells[index, 0].Tag = EnumColumn.CmedicarePayCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "市保统筹";
            sheet.Cells[index, 0].Tag = EnumColumn.CmedicarePubCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "市保大额";
            sheet.Cells[index, 0].Tag = EnumColumn.CmedicareOverCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "省保账户";
            sheet.Cells[index, 0].Tag = EnumColumn.PmedicarePayCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "省保统筹";
            sheet.Cells[index, 0].Tag = EnumColumn.PmedicarePubCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "省保大额";
            sheet.Cells[index, 0].Tag = EnumColumn.PmedicareOverCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "省保公务员";
            sheet.Cells[index, 0].Tag = EnumColumn.PmedicareOfficialCost.ToString();

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 1].Text = "合计";
            sheet.Cells[index, 0].Tag = EnumColumn.DebitSummer.ToString();
            sheet.Cells[index, 2].Tag = EnumColumn.LenderSummer.ToString();
            endSpan = index;

            for (int i = beginSpan; i < endSpan; i++)
            {
                sheet.Models.Span.Add(i, 2, 1, 2);
            }

            if (OperationType == OperType.DayReport)
            {
                index = AddFarpointRow(sheet);
                sheet.Cells[index, 0].Text = "预交金票据号范围";
                sheet.Models.Span.Add(index, 1, 1, 3);
                sheet.Cells[index, 1].Tag = EnumColumn.PrePayInvoiceBound.ToString();
                sheet.Rows[index].Height = 50;
                sheet.Cells[index, 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "预交金张数";
            sheet.Cells[index, 1].Tag = EnumColumn.PrePayInvoiceCount.ToString();//luoff
            sheet.Models.Span.Add(index, 1, 1, 3);//luoff
            sheet.Cells[index, 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            
            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "预交金有效张数";
            sheet.Cells[index, 1].Tag = EnumColumn.PrePayUseInvoiceCount.ToString();
            sheet.Cells[index, 2].Text = "预交金作废张数";
            sheet.Cells[index, 3].Tag = EnumColumn.PrePayWasteInvoiceCount.ToString();
            if (OperationType == OperType.DayReport)
            {
                index = AddFarpointRow(sheet);
                sheet.Cells[index, 0].Text = "预交金作废票据号";
                sheet.Cells[index, 1].Tag = EnumColumn.PrePayWasteInvoiceNo.ToString();
                sheet.Rows[index].Height = 80;
                sheet.Models.Span.Add(index, 1, 1, 3);
                sheet.Cells[index, 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            if (OperationType == OperType.DayReport)
            {
                index = AddFarpointRow(sheet);
                sheet.Cells[index, 0].Text = "结算票据号范围";
                sheet.Models.Span.Add(index, 1, 1, 3);
                sheet.Cells[index, 1].Tag = EnumColumn.BalanceInvoiceBound.ToString();
                sheet.Rows[index].Height = 50;
                sheet.Cells[index, 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "结算票据张数";
            sheet.Cells[index, 1].Tag = EnumColumn.BalanceInvoiceCount.ToString();
            sheet.Models.Span.Add(index, 1, 1, 3);

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "结算票据有效张数";
            sheet.Cells[index, 1].Tag = EnumColumn.BalanceUseInvoiceCount.ToString();

            sheet.Cells[index, 2].Text = "结算票据作废张数";
            sheet.Cells[index, 3].Tag = EnumColumn.BalanceWasteInvoiceCount.ToString();

            if (OperationType == OperType.DayReport)
            {
                index = AddFarpointRow(sheet);
                sheet.Cells[index, 0].Text = "结算作废票据号";
                sheet.Cells[index, 1].Tag = EnumColumn.BalanceWasteInvoiceNo.ToString();
                sheet.Rows[index].Height = 80;
                sheet.Models.Span.Add(index, 1, 1, 3);
                sheet.Cells[index, 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "上缴现金";
            sheet.Cells[index, 1].Tag = EnumColumn.PayTotCost.ToString();
            sheet.Cells[index, 2].Text = "（大写）：";
            sheet.Cells[index, 2].Tag = EnumColumn.PayTotCostCapital.ToString();
            sheet.Models.Span.Add(index, 2, 1, 2);

            index = AddFarpointRow(sheet);
            sheet.Cells[index, 0].Text = "上缴银联额";
            sheet.Cells[index, 1].Tag = EnumColumn.PayBankCardTotCost.ToString();
            sheet.Cells[index, 2].Text = "上缴支票额";
            sheet.Cells[index, 3].Tag = EnumColumn.PayBankTotCost.ToString();

        }
        /// <summary>
        /// 增加SheetView行
        /// </summary>
        /// <param name="sheet">sheetView</param>
        /// <returns>SheetView最后一行的Index</returns>
        private int AddFarpointRow(FarPoint.Win.Spread.SheetView sheet)
        {
            int count = sheet.Rows.Count;
            sheet.Rows.Add(count, 1);
            int index = sheet.Rows.Count-1;
            return index;
        }

        #endregion

        #region 增加ToolBar控件按钮
        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("日结", "开始进行日结费用统计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S手动录入, true, false, null);

            toolBarService.AddToolButton("时间", "选择日结时间范围", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);

            toolBarService.AddToolButton("汇总", "汇总日结费用统计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);
            #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打

            toolBarService.AddToolButton("补打", "补打已汇总的日结费用统计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);

            #endregion
            toolBarService.AddToolButton("确认", "保存汇总记录", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            return this.toolBarService;
        }
        #endregion

        #region 选择时间
        /// <summary>
        /// 选择时间
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int ChooseDateTime()
        {
            Neusoft.FrameWork.WinForms.Forms.BaseForm f;
            f = new Neusoft.FrameWork.WinForms.Forms.BaseForm();

            ucChooseTime ucTime = new ucChooseTime();
            ucTime.OnEndChooseDateTime += new ucChooseTime.myDelegateGetDateTime(ucTime_OnEndChooseDateTime);

            ucTime.BeginDate = this.DtBegin;
            ucTime.EndDate = this.DtEnd;
            ucTime.IsBeginDateEdit = false;
            ucTime.Dock = System.Windows.Forms.DockStyle.Fill;
            f.Controls.Add(ucTime);

            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            f.Size = new Size(295, 200);

            f.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            f.BackColor = this.Parent.BackColor;
            f.Text = "选择日结时间";
            f.ShowDialog();
            return 1;
        }
        #endregion

        #region 根据Tag查找Cell,给Text赋值
        /// <summary>
        /// 根据Tag查找Cell,给Text赋值
        /// </summary>
        /// <param name="tagValue">Cell的标识</param>
        /// <param name="textValue">Cell要显示的Text</param>
        private void SetCellValue(string tagValue, string textValue)
        {
            FarPoint.Win.Spread.Cell cell = this.neuSpread1_Sheet1.GetCellFromTag(null, tagValue);
            if (cell == null) return;
            cell.Text = textValue;
        }
        /// <summary>
        /// 得到Cell的Text
        /// </summary>
        /// <param name="tagValue">cell的tag</param>
        /// <returns></returns>
        private string GetCellValue(string tagValue)
        {
            FarPoint.Win.Spread.Cell cell = this.neuSpread1_Sheet1.GetCellFromTag(null, tagValue);
            if (cell == null) return string.Empty;
            return cell.Text;
        }
        #endregion

        #region 执行日结过程
        /// <summary>
        /// 执行日结过程
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int ExecDayReport()
        {
            try
            {
                this.SetFarPoint(this.neuSpread1_Sheet1);
                SetDayReprotDate();
                string ResultValue = string.Empty;
                string resultAll = string.Empty;//luoff
                string resultWaste = string.Empty;//luoff
                //借方合计
                decimal debitSummer = 0m;
                //贷方合计
                decimal lenderSummer = 0m;
                //显示项目明细
                SetDayReportItem();

                #region 医疗预收款
                //医疗预收款借方
                ResultValue = this.feeDayreport.GetBalancedPrepayCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.DebitPrePay.ToString(), ResultValue);
                debitSummer += NConvert.ToDecimal(ResultValue);
                //医疗预收款贷方
                ResultValue = this.feeDayreport.GetPrepayCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.LenderPrePay.ToString(), ResultValue);
                lenderSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                #region 医疗应收款
                ResultValue = this.feeDayreport.GetLenderPay(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.LenderPay.ToString(), ResultValue);
                lenderSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                #region 银行存款
                //借方银行存款
                decimal prepayCheckCost = 0m;
                prepayCheckCost = NConvert.ToDecimal(this.feeDayreport.GetPrepayCheckCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                decimal supplyCheckCost = 0m;
                supplyCheckCost = NConvert.ToDecimal(this.feeDayreport.GetSupplyCheckCostByOperIDAndTime(this.DtEnd, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.DebitBank.ToString(), (prepayCheckCost + supplyCheckCost).ToString());
                debitSummer += prepayCheckCost + supplyCheckCost;

                //贷方银行存款
                ResultValue = this.feeDayreport.GetReturnCheckCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.LenderBank.ToString(), ResultValue);
                lenderSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                #region 现金
                //预交现金
                decimal prepayCashCost = 0m;
                prepayCashCost = NConvert.ToDecimal(feeDayreport.GetPrepayCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                //补收现金
                decimal supplyCashCost = 0m;
                supplyCashCost = NConvert.ToDecimal(feeDayreport.GetSupplyCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                //借方现金
                this.SetCellValue(EnumColumn.DebitCACost.ToString(), (prepayCashCost + supplyCashCost).ToString());
                debitSummer += prepayCashCost + supplyCashCost;

                //反还现金
                decimal returnCashCost = 0m;
                returnCashCost = NConvert.ToDecimal(feeDayreport.GetReturnCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.LenderCACost.ToString(), returnCashCost.ToString());
                lenderSummer += returnCashCost;
                #endregion

                #region 银行卡
                //借方
                decimal prepayBankCost = 0m;
                prepayBankCost = NConvert.ToDecimal(feeDayreport.GetPrepayBankCardCost(DtBegin, DtEnd, feeDayreport.Operator.ID));

                decimal supplyBankCost = 0m;
                supplyBankCost = NConvert.ToDecimal(feeDayreport.GetSupplyBankCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID));

                this.SetCellValue(EnumColumn.DebitBankCard.ToString(), (prepayBankCost + supplyBankCost).ToString());
                debitSummer += prepayBankCost + supplyBankCost;

                //贷方
                ResultValue = this.feeDayreport.GetReturnBankCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.LenderBankCard.ToString(), ResultValue);
                lenderSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                #region 院内帐户
                decimal YsCost = 0m, SupplyYsCost = 0m, ReturnYsCost = 0m;
                //借方
                YsCost = NConvert.ToDecimal(this.feeDayreport.GetYSCost(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                SupplyYsCost = NConvert.ToDecimal(this.feeDayreport.GetSupplyYSCost(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.DebitYSCost.ToString(), (YsCost + SupplyYsCost).ToString());
                debitSummer += YsCost + SupplyYsCost;

                //贷方
                ReturnYsCost = NConvert.ToDecimal(this.feeDayreport.GetReturnYSCost(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.LenderYSCost.ToString(),ReturnYsCost.ToString());
                lenderSummer += ReturnYsCost;
                #endregion

                #region 其它预收
                //借
                decimal OtherPrePay = 0m, SupplyOtherPrePay = 0m, ReturnOtherPrePay = 0m;
                OtherPrePay = NConvert.ToDecimal(this.feeDayreport.GetOtherPrepayCost(
                                                this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                SupplyOtherPrePay = NConvert.ToDecimal(this.feeDayreport.GetSupplyOtherPrePayCost(
                                                this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.DebitOtherPrePay.ToString(), (OtherPrePay + SupplyOtherPrePay).ToString());
                debitSummer += OtherPrePay + SupplyOtherPrePay;

                //贷款
                ReturnOtherPrePay = NConvert.ToDecimal(this.feeDayreport.GetReturnOtherPrePayCost(
                                                 this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                this.SetCellValue(EnumColumn.LenderOtherPrePay.ToString(), ReturnOtherPrePay.ToString());
                lenderSummer += ReturnOtherPrePay;
                #endregion

                #region 医疗减免
                //医疗减免
                ResultValue = this.feeDayreport.GetDayReportDerCost(DtBegin, DtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.Derate.ToString(), ResultValue);
                debitSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                #region 公费记帐金额
                //公费记帐金额
                ResultValue = this.feeDayreport.GetBursaryCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.BusaryPubCost.ToString(), ResultValue);
                debitSummer += NConvert.ToDecimal(ResultValue);
                #endregion

                this.SetProtectPay(ref debitSummer);

                //借方合计
                this.SetCellValue(EnumColumn.DebitSummer.ToString(), debitSummer.ToString());
                //贷方合计
                this.SetCellValue(EnumColumn.LenderSummer.ToString(), lenderSummer.ToString());

                //预交金张数
                ResultValue = this.feeDayreport.GetValidPrepayInvoiceQtyByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.PrePayInvoiceCount.ToString(), ResultValue);
                resultAll = ResultValue;
                
                //预交金作废张数
                ResultValue = this.feeDayreport.GetWastePrepayInvoiceQtyByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.PrePayWasteInvoiceCount.ToString(), ResultValue);
                resultWaste = ResultValue;

                //预交金有效张数
                int result = Convert.ToInt32(resultAll) - Convert.ToInt32(resultWaste);
                ResultValue = Convert.ToString(result);
                this.SetCellValue(EnumColumn.PrePayUseInvoiceCount.ToString(), ResultValue);//luoff

                ////预交金票据区间
                //Neusoft.FrameWork.Models.NeuObject invoiceZone = new Neusoft.FrameWork.Models.NeuObject();

                //invoiceZone = this.feeDayreport.GetPrepayInvoiceZoneByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);

                //if (invoiceZone != null)
                //{
                //    ResultValue = invoiceZone.ID.ToString() + "----" + invoiceZone.Name;
                //    this.SetCellValue(EnumColumn.PrePayInvoiceBound.ToString(), ResultValue);
                //}

                //预交金票据区间  luoff
                DataSet ds = new DataSet();
                int resultValue = feeDayreport.GetPrepayInvoiceZoneNew(this.dtBegin, this.dtEnd, this.feeDayreport.Operator.ID, ref ds);
                if (resultValue == -1) return -1;
                DataTable table = ds.Tables[0];

                //if (table.Rows.Count == 0) return -1;{89969B93-7B2A-427b-9363-78C1E16D87F3}
                if (table.Rows.Count != 0)
                {

                    this.SetCellValue(EnumColumn.PrePayInvoiceBound.ToString(), GetPrepayOrBalanceInvoiceZone(table));
                }
               

                //预交金作废票号
                ArrayList alWasteNO = new ArrayList();
                alWasteNO = this.feeDayreport.QueryWastePrepayInvNOByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);
                string wasteInvNO = "";
                Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                if (alWasteNO.Count == 0)
                {
                    this.SetCellValue(EnumColumn.PrePayWasteInvoiceNo.ToString(), string.Empty);
                }
                else
                {
                    for (int i = 0; i < alWasteNO.Count; i++)
                    {
                        prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)alWasteNO[i];
                        wasteInvNO = wasteInvNO + prepay.RecipeNO + "|";
                    }
                    this.SetCellValue(EnumColumn.PrePayWasteInvoiceNo.ToString(), wasteInvNO.Substring(0, wasteInvNO.Length - 1));
                }


                //结算票据张数
                ResultValue = this.feeDayreport.GetValidBalanceInvoiceQtyByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.BalanceInvoiceCount.ToString(), ResultValue);
                resultAll = ResultValue;

                //结算作废张数
                ResultValue = this.feeDayreport.GetWasteBalanceInvoiceQtyByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                this.SetCellValue(EnumColumn.BalanceWasteInvoiceCount.ToString(), ResultValue);
                resultWaste = ResultValue;

                //结算票据有效张数
                result = Convert.ToInt32(resultAll) - Convert.ToInt32(resultWaste);
                ResultValue = Convert.ToString(result);
                this.SetCellValue(EnumColumn.BalanceUseInvoiceCount.ToString(), ResultValue);

                ////结算票据区间
                //Neusoft.FrameWork.Models.NeuObject balanceInvoiceZone = new Neusoft.FrameWork.Models.NeuObject();
                //balanceInvoiceZone = this.feeDayreport.GetBalanceInvoiceZoneByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                //if (balanceInvoiceZone != null)
                //{
                //    this.SetCellValue(EnumColumn.BalanceInvoiceBound.ToString(), balanceInvoiceZone.ID.ToString() + "----" + balanceInvoiceZone.Name);
                //}

                #region 结算票据区间 luoff
                DataSet balanceDS = new DataSet();
                int balanceValue = feeDayreport.GetBalanceInvoiceZoneNew(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID, ref balanceDS);
                if (balanceValue == -1)
                {
                    return -1;
                }
                DataTable balanceTable = balanceDS.Tables[0];
                //if (balanceTable.Rows.Count == 0){89969B93-7B2A-427b-9363-78C1E16D87F3}
                //{
                //    return -1;
                //}
                if (balanceTable.Rows.Count != 0)
                {
                    this.SetCellValue(EnumColumn.BalanceInvoiceBound.ToString(), GetPrepayOrBalanceInvoiceZone(balanceTable));
                }
                #endregion

                //结算作废票号
                ArrayList alWasteBalanceInvNO = new ArrayList();
                alWasteBalanceInvNO = this.feeDayreport.QueryWasteBalanceInvNOByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                string balanceWasteNO = "";
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();

                if (alWasteBalanceInvNO.Count == 0)
                {
                    this.SetCellValue(EnumColumn.BalanceWasteInvoiceNo.ToString(), string.Empty);
                }
                else
                {
                    for (int j = 0; j < alWasteBalanceInvNO.Count; j++)
                    {
                        balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alWasteBalanceInvNO[j];
                        balanceWasteNO = balanceWasteNO + balance.Invoice.ID + "|";
                    }
                    this.SetCellValue(EnumColumn.BalanceWasteInvoiceNo.ToString(), balanceWasteNO.Substring(0, balanceWasteNO.Length - 1));
                }
                SetPayTotCostInfo();
                this.OperMode = "1";
                return 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        #region 获得预交金\结算票据区间  luoff

        private string GetPrepayOrBalanceInvoiceZone(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            int count = dt.Rows.Count - 1;
            string minStr = dt.Rows[0][0].ToString();
            string maxStr = dt.Rows[0][0].ToString();
            for (int i = 0; i < count - 1; i++)
                for (int j = i + 1; j < count; j++)
                {
                    long froInt = Convert.ToInt32(dt.Rows[i][0].ToString());
                    long nxtInt = Convert.ToInt32(dt.Rows[j][0].ToString());
                    long chaInt = nxtInt - froInt;
                    if (chaInt > 1)
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
        /// 显示项目明细
        /// </summary>
        private void SetDayReportItem()
        {
           // ds = this.feeDayreport.GetDayReportItem(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);//原来取统计大类项目明细
            ds = this.feeDayreport.GetDayReportItemZYRJ(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
            if (ds == null)
            {
                return;
            }
            
            try
            {
                DataTable dt = ds.Tables[0];
                int Index = 0;
                int iMod = 0;
                decimal TotCost = 0m;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Index = Convert.ToInt32(i / 2);
                    iMod = i % 2;
                    if (iMod == 0)
                    {
                        this.neuSpread1_Sheet1.Rows.Add(Index, 1);
                        this.neuSpread1_Sheet1.Cells[Index, 0].Tag = dt.Rows[i][0].ToString();
                        this.neuSpread1_Sheet1.Cells[Index, 0].Text = dt.Rows[i][1].ToString();
                        this.neuSpread1_Sheet1.Cells[Index, 1].Text = dt.Rows[i][2].ToString();
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[Index, 2].Tag = dt.Rows[i][0].ToString();
                        this.neuSpread1_Sheet1.Cells[Index, 2].Text = dt.Rows[i][1].ToString();
                        this.neuSpread1_Sheet1.Cells[Index, 3].Text = dt.Rows[i][2].ToString();
                    }
                    TotCost += NConvert.ToDecimal(dt.Rows[i][2]);
                    #region 设置项目实体
                    item = new Report.InpatientFee.Class.Item();
                    item.StateCode = dt.Rows[i][0].ToString();
                    item.TotCost = NConvert.ToDecimal(dt.Rows[i][2]);
                    item.Mark = dt.Rows[i][1].ToString();
                    dayReport.ItemList.Add(item);
                    #endregion
                }
                //合计
                this.neuSpread1_Sheet1.Cells[Index + 1, 1].Text = TotCost.ToString();
            }
            catch { }
            finally
            {
                ds.Dispose();
            }
        }
        /// <summary>
        /// 显示省、市医保支付数据
        /// </summary>
        /// <param name="DebitSummer">合计数据</param>
        private void SetProtectPay(ref decimal DebitSummer)
        {
            ds = this.feeDayreport.GetDayReportProtectPay(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);
            if (ds == null) return;
            DataTable dt = ds.Tables[0];
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["pact_code"].ToString())
                    {
                        case "2":
                            {
                                this.SetCellValue(EnumColumn.CmedicarePayCost.ToString(), dr["pay_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["pay_cost"]);

                                this.SetCellValue(EnumColumn.CmedicarePubCost.ToString(), dr["pub_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["pub_cost"]);

                                this.SetCellValue(EnumColumn.CmedicareOverCost.ToString(), dr["over_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["over_cost"]);
                                break;
                            }
                        case "3":
                            {
                                this.SetCellValue(EnumColumn.PmedicarePayCost.ToString(), dr["pay_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["pay_cost"]);

                                this.SetCellValue(EnumColumn.PmedicarePubCost.ToString(), dr["pub_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["pub_cost"]);

                                this.SetCellValue(EnumColumn.PmedicareOverCost.ToString(), dr["over_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["over_cost"]);

                                this.SetCellValue(EnumColumn.PmedicareOfficialCost.ToString(), dr["official_cost"].ToString());
                                DebitSummer += NConvert.ToDecimal(dr["official_cost"]);
                                break;
                            }
                    }
                }
            }
            catch { }
            finally
            {
                ds.Dispose();
            }

        }
        /// <summary>
        /// 显示上缴数据
        /// </summary>
        private void SetPayTotCostInfo()
        {
            decimal resultValue = 0m;
            //上缴现金=现金借方－贷方
            resultValue = NConvert.ToDecimal(this.GetCellValue(EnumColumn.DebitCACost.ToString()))
                        -NConvert.ToDecimal(this.GetCellValue(EnumColumn.LenderCACost.ToString()));
            this.SetCellValue(EnumColumn.PayTotCost.ToString(), resultValue.ToString());
            //大写
            this.SetCellValue(EnumColumn.PayTotCostCapital.ToString(),"大写："+ NConvert.ToCapital(resultValue));
            //上缴银联额=银行卡借方－贷方
            resultValue = NConvert.ToDecimal(this.GetCellValue(EnumColumn.DebitBankCard.ToString()))
                        - NConvert.ToDecimal(this.GetCellValue(EnumColumn.LenderBankCard.ToString()));
            this.SetCellValue(EnumColumn.PayBankCardTotCost.ToString(),resultValue.ToString());
            //上缴支票额＝银行存款借方－贷方
            resultValue = NConvert.ToDecimal(this.GetCellValue(EnumColumn.DebitBank.ToString()))
                        - NConvert.ToDecimal(this.GetCellValue(EnumColumn.LenderBank.ToString()));
            this.SetCellValue(EnumColumn.PayBankTotCost.ToString(),resultValue.ToString());
        }
        /// <summary>
        /// 获得日结实体
        /// </summary>
        private void GetDayReprot()
        {
            string resultValue=string.Empty;
            //统计序号
            dayReport.StatNO = this.feeDayreport.GetNewDayReportID();

            //开始时间

            dayReport.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.DtBegin);
            //结束日期
            dayReport.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.DtEnd);

            //操作员代码

            dayReport.Oper.ID = this.feeDayreport.Operator.ID;
            //统计时间
            dayReport.Oper.OperTime = this.feeDayreport.GetDateTimeFromSysDateTime();

            #region 医疗预收款
            //借
            resultValue=this.GetCellValue(EnumColumn.DebitPrePay.ToString());
            dayReport.BalancePrepayCost = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderPrePay.ToString());
            dayReport.PrepayCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 医疗应收款
            resultValue = this.GetCellValue(EnumColumn.LenderPay.ToString());
            dayReport.BalanceCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 银行存款
            //借
            resultValue = this.GetCellValue(EnumColumn.DebitBank.ToString());
            dayReport.DebitCheckCost = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderBank.ToString());
            dayReport.LenderCheckCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 现金
            //借
            resultValue = this.GetCellValue(EnumColumn.DebitCACost.ToString());
            dayReport.DebitCash = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderCACost.ToString());
            dayReport.LenderCash = NConvert.ToDecimal(resultValue);
            #endregion

            #region 银行卡
            //借
            resultValue = this.GetCellValue(EnumColumn.DebitBankCard.ToString());
            dayReport.DebitBankCost = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderBankCard.ToString());
            dayReport.LenderBankCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 院内帐户
            //借
            resultValue = this.GetCellValue(EnumColumn.DebitYSCost.ToString());
            dayReport.DebitHos = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderYSCost.ToString());
            dayReport.LenderHos = NConvert.ToDecimal(resultValue);
            #endregion

            #region 其它预收
            //借
            resultValue = this.GetCellValue(EnumColumn.DebitOtherPrePay.ToString());
            dayReport.DebitOther = NConvert.ToDecimal(resultValue);
            //贷
            resultValue = this.GetCellValue(EnumColumn.LenderOtherPrePay.ToString());
            dayReport.LenderOther = NConvert.ToDecimal(resultValue);
            #endregion

            #region 医疗减免
            resultValue = this.GetCellValue(EnumColumn.Derate.ToString());
            dayReport.DerateCost = NConvert.ToDecimal(resultValue);
            #endregion 

            #region 公费医疗记账
            resultValue = this.GetCellValue(EnumColumn.BusaryPubCost.ToString());
            dayReport.BursaryPubCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 市保账户
            resultValue = this.GetCellValue(EnumColumn.CmedicarePayCost.ToString());
            dayReport.CityMedicarePayCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 市保统筹
            resultValue = this.GetCellValue(EnumColumn.CmedicarePubCost.ToString());
            dayReport.CityMedicarePubCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 市保大额
            resultValue = this.GetCellValue(EnumColumn.CmedicareOverCost.ToString());
            dayReport.CityMedicareOverCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 省保账户
            resultValue = this.GetCellValue(EnumColumn.PmedicarePayCost.ToString());
            dayReport.ProvinceMedicarePayCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 省保统筹
            resultValue = this.GetCellValue(EnumColumn.PmedicarePubCost.ToString());
            dayReport.ProvinceMedicarePubCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 省保大额
            resultValue = this.GetCellValue(EnumColumn.PmedicareOverCost.ToString());
            dayReport.ProvinceMedicarePayCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 省保公务员
            resultValue = this.GetCellValue(EnumColumn.PmedicareOfficialCost.ToString());
            dayReport.ProvinceMedicareOfficeCost = NConvert.ToDecimal(resultValue);
            #endregion

            #region 预交金票据号范围
            resultValue = this.GetCellValue(EnumColumn.PrePayInvoiceBound.ToString());
            dayReport.PrepayInvZone = resultValue;
            #endregion

            #region 预交金张数
            resultValue = this.GetCellValue(EnumColumn.PrePayInvoiceCount.ToString());
            dayReport.PrepayInvCount = NConvert.ToInt32(resultValue);
            #endregion

            #region 预交金作废张数
            resultValue = this.GetCellValue(EnumColumn.PrePayWasteInvoiceCount.ToString());
            dayReport.PrepayWasteInvCount = NConvert.ToInt32(resultValue);
            #endregion

            #region 预交金作废票据号
            resultValue = this.GetCellValue(EnumColumn.PrePayWasteInvoiceNo.ToString());
            dayReport.PrepayWasteInvNO = resultValue;
            #endregion

            #region 结算票据号范围
            resultValue = this.GetCellValue(EnumColumn.BalanceInvoiceBound.ToString());
            dayReport.BalanceInvZone = resultValue;
            #endregion

            #region 结算票据张数
            resultValue = this.GetCellValue(EnumColumn.BalanceInvoiceCount.ToString());
            dayReport.BalanceInvCount = NConvert.ToInt32(resultValue);
            #endregion

            #region 结算票据作废张数
            resultValue = this.GetCellValue(EnumColumn.BalanceWasteInvoiceCount.ToString());
            dayReport.BalanceWasteInvCount = NConvert.ToInt32(resultValue);
            #endregion

            #region 结算作废票据号
            resultValue = this.GetCellValue(EnumColumn.BalanceWasteInvoiceNo.ToString());
            dayReport.BalanceWasteInvNO = resultValue;
            #endregion
        }
        #endregion

        #region 显示查询日结数据
        /// <summary>
        /// 
        /// </summary>
        private void SetDayReport()
        {
            this.DtBegin = this.dayReport.BeginDate;
            this.DtEnd = this.dayReport.EndDate;
            ShowDayReportDetail(dayReport.ItemList);
            ShwoDayReport();
            SetPayTotCostInfo();
            
        }
        private void ShowDayReportDetail(List<Class.Item> list)
        {
            int Index = 0;
            int iMod = 0;
            decimal TotCost = 0m;
            for (int i = 0; i < list.Count; i++)
            {
                Index = Convert.ToInt32(i / 2);
                iMod = i % 2;
                if (iMod == 0)
                {
                    this.neuSpread1_Sheet1.Rows.Add(Index, 1);
                    this.neuSpread1_Sheet1.Cells[Index, 0].Tag = list[i].StateCode;
                    this.neuSpread1_Sheet1.Cells[Index, 0].Text = list[i].Mark;
                    this.neuSpread1_Sheet1.Cells[Index, 1].Text = list[i].TotCost.ToString();
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[Index, 2].Tag = list[i].StateCode;
                    this.neuSpread1_Sheet1.Cells[Index, 2].Text = list[i].Mark;
                    this.neuSpread1_Sheet1.Cells[Index, 3].Text = list[i].TotCost.ToString();
                }
                TotCost += list[i].TotCost;
            }
            //合计
            this.neuSpread1_Sheet1.Cells[Index + 1, 1].Text = TotCost.ToString();
        }

        private void ShwoDayReport()
        {
            decimal debitSummer = 0m, lenderSummer = 0m;
            #region 医疗预收款
            //借
            this.SetCellValue(EnumColumn.DebitPrePay.ToString(), dayReport.BalancePrepayCost.ToString());
            debitSummer += dayReport.BalancePrepayCost;
            //贷
            this.SetCellValue(EnumColumn.LenderPrePay.ToString(), dayReport.PrepayCost.ToString());
            lenderSummer += dayReport.PrepayCost;
            #endregion

            #region 医疗应收款
            this.SetCellValue(EnumColumn.LenderPay.ToString(), dayReport.BalanceCost.ToString());
            lenderSummer += dayReport.BalanceCost;
            #endregion

            #region 银行存款
            //借
            this.SetCellValue(EnumColumn.DebitBank.ToString(), dayReport.DebitCheckCost.ToString());
            debitSummer += dayReport.DebitCheckCost;
            //贷
            this.SetCellValue(EnumColumn.LenderBank.ToString(), dayReport.LenderCheckCost.ToString());
            lenderSummer += dayReport.LenderCheckCost;
            #endregion

            #region 现金
            //借
            this.SetCellValue(EnumColumn.DebitCACost.ToString(), dayReport.DebitCash.ToString());
            debitSummer += dayReport.DebitCash;
            //贷
            this.SetCellValue(EnumColumn.LenderCACost.ToString(), dayReport.LenderCash.ToString());
            lenderSummer += dayReport.LenderCash;
            #endregion

            #region 银行卡
            //借
            this.SetCellValue(EnumColumn.DebitBankCard.ToString(), dayReport.DebitBankCost.ToString());
            debitSummer += dayReport.DebitBankCost;
            //贷
            this.SetCellValue(EnumColumn.LenderBankCard.ToString(), dayReport.LenderBankCost.ToString());
            lenderSummer += dayReport.LenderBankCost;
            #endregion

            #region 院内帐户
            //借
            this.SetCellValue(EnumColumn.DebitYSCost.ToString(), dayReport.DebitHos.ToString());
            debitSummer += dayReport.DebitHos;
            //贷
            this.SetCellValue(EnumColumn.LenderYSCost.ToString(), dayReport.LenderHos.ToString());
            lenderSummer += dayReport.LenderHos;
            #endregion

            #region 其它预收
            //借
            this.SetCellValue(EnumColumn.DebitOtherPrePay.ToString(), dayReport.DebitOther.ToString());
            debitSummer += dayReport.DebitOther;
            //贷
            this.SetCellValue(EnumColumn.LenderOtherPrePay.ToString(), dayReport.LenderOther.ToString());
            lenderSummer += dayReport.LenderOther;
            #endregion

            // 医疗减免
            this.SetCellValue(EnumColumn.Derate.ToString(), dayReport.DerateCost.ToString());
            debitSummer += dayReport.DerateCost;

            // 公费医疗记账
            this.SetCellValue(EnumColumn.BusaryPubCost.ToString(), dayReport.BursaryPubCost.ToString());
            debitSummer += dayReport.BursaryPubCost;

            // 市保账户
            this.SetCellValue(EnumColumn.CmedicarePayCost.ToString(), dayReport.CityMedicarePayCost.ToString());
            debitSummer += dayReport.CityMedicarePayCost;

            // 市保统筹
            this.SetCellValue(EnumColumn.CmedicarePubCost.ToString(), dayReport.CityMedicarePubCost.ToString());
            debitSummer += dayReport.CityMedicarePubCost;

            // 市保大额
            this.SetCellValue(EnumColumn.CmedicareOverCost.ToString(), dayReport.CityMedicareOverCost.ToString());
            debitSummer += dayReport.CityMedicareOverCost;

            // 省保账户
            this.SetCellValue(EnumColumn.PmedicarePayCost.ToString(), dayReport.ProvinceMedicarePayCost.ToString());
            debitSummer += dayReport.ProvinceMedicarePayCost;
            // 省保统筹
            this.SetCellValue(EnumColumn.PmedicarePubCost.ToString(), dayReport.ProvinceMedicarePubCost.ToString());
            debitSummer += dayReport.ProvinceMedicarePubCost;

            // 省保大额
            this.SetCellValue(EnumColumn.PmedicareOverCost.ToString(), dayReport.ProvinceMedicarePayCost.ToString());
            debitSummer += dayReport.ProvinceMedicarePayCost;
            
            // 省保公务员
            this.SetCellValue(EnumColumn.PmedicareOfficialCost.ToString(), dayReport.ProvinceMedicareOfficeCost.ToString());
            debitSummer += dayReport.ProvinceMedicareOfficeCost;

            //合计
            //借方合计
            this.SetCellValue(EnumColumn.DebitSummer.ToString(), debitSummer.ToString());
            //贷方合计
            this.SetCellValue(EnumColumn.LenderSummer.ToString(), lenderSummer.ToString());

            // 预交金票据号范围
            this.SetCellValue(EnumColumn.PrePayInvoiceBound.ToString(), dayReport.PrepayInvZone);

            #region 预交金张数
            this.SetCellValue(EnumColumn.PrePayInvoiceCount.ToString(), dayReport.PrepayInvCount.ToString());
            #endregion

            // 预交金作废张数
            this.SetCellValue(EnumColumn.PrePayWasteInvoiceCount.ToString(), dayReport.PrepayWasteInvCount.ToString());

           // 预交金作废票据号
            this.SetCellValue(EnumColumn.PrePayWasteInvoiceNo.ToString(), dayReport.PrepayWasteInvNO);

            // 结算票据号范围
            this.SetCellValue(EnumColumn.BalanceInvoiceBound.ToString(), dayReport.BalanceInvZone);

            // 结算票据张数
            this.SetCellValue(EnumColumn.BalanceInvoiceCount.ToString(), dayReport.BalanceInvCount.ToString());

            // 结算票据作废张数
            this.SetCellValue(EnumColumn.BalanceWasteInvoiceCount.ToString(), dayReport.BalanceWasteInvCount.ToString());
           
            // 结算作废票据号
            this.SetCellValue(EnumColumn.BalanceWasteInvoiceNo.ToString(), dayReport.BalanceWasteInvNO);
           
        }
        
        #endregion

        #region 保存日结数据
        protected virtual void Save()
        {
            if (this.OperMode != "1") return;
            //if (this.dayReport.ItemList.Count == 0)
            //{
            //    MessageBox.Show("该时间段没有发生费用，不能日结！");
            //    return;
            //}
            DialogResult diaResult = MessageBox.Show("是否进行日结,日结后数据将不能恢复?", "住院收款员缴款日报", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diaResult == DialogResult.No) return;
            //设置日结实体
            this.GetDayReprot();
            if (string.IsNullOrEmpty(dayReport.PrepayInvZone) && string.IsNullOrEmpty(dayReport.PrepayWasteInvNO) && string.IsNullOrEmpty(dayReport.BalanceInvZone) && string.IsNullOrEmpty(dayReport.BalanceWasteInvNO))
            {
                MessageBox.Show("不存在日结数据！");
                return;
            }
            //事物
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            feeDayreport.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int result = 0;
            //插入明细
            result = feeDayreport.InsetDayReportDetail(dayReport);
            if (result == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(feeDayreport.Err);
                return;
            }
            //插入日结报表
            result = feeDayreport.InsertDayReport(dayReport);
            if (result == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(feeDayreport.Err);
                return;
            }
            //{9B8D83F8-CB0F-48fb-8ECD-0BA4462A952A}
            //更新结算信息
            result = feeDayreport.UpdateDayReport(dayReport.StatNO, dayReport.Oper.ID, dayReport.Oper.OperTime, dtBegin, dtEnd);
            if(result <0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(feeDayreport.Err);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            dayReport.ItemList.Clear();
            MessageBox.Show("保存成功！");
            this.OperMode = "2";
        }
        #endregion

        #region 查询汇总
        private void QueryOrCollectData()
        {
            ucPopDayReportQueryNew ucQuery = new ucPopDayReportQueryNew(OperationType);
            DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucQuery);
            if (result != DialogResult.OK) return ;
            this.dayReport = ucQuery.DayReprot;
            SetDayReport();
            if (this.OperationType == OperType.CollectDayReport)
            {
                listEnviroment = ucQuery.CollectEnvironment;
            }
        }
        #endregion

        #region  {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
        private void QueryOrCollectDataCheck()
        {
            ucPopDayReportQueryNew ucQuery = new ucPopDayReportQueryNew(OperationType);
            ucQuery.ckRePrint.Checked = true;
            DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucQuery);
            if (result != DialogResult.OK) return;
            this.dayReport = ucQuery.DayReprot;
            SetDayReport();
            if (this.OperationType == OperType.CollectDayReport)
            {
                listEnviroment = ucQuery.CollectEnvironment;
            }
        } 
        #endregion
        #region 保存日结汇总数据
        /// <summary>
        /// 保存日结汇总数据
        /// </summary>
        public void SaveCollectData()
        {
            if (listEnviroment == null || listEnviroment.Count == 0)
            {
                MessageBox.Show("请先汇总数据然后再保存数据！");
                return;
            }
            DialogResult result = MessageBox.Show("确认要保存汇总数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            //操作员编码
            string operID = this.feeDayreport.Operator.ID;
            //操作时间
            DateTime OperDate = this.feeDayreport.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();

            this.feeDayreport.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            foreach (Class.DayReport obj in listEnviroment)
            {
                if (feeDayreport.SaveCollectData(operID, OperDate, obj.StatNO) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存汇总数据失败！");
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存汇总数据成功！");
        }
        #endregion
        #endregion

        #region 事件
        private void ucDayReportNew_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        void ucTime_OnEndChooseDateTime(DateTime beginTime, DateTime endTime)
        {
            this.DtBegin = beginTime;
            this.DtEnd = endTime;
            //执行日结
            this.ExecDayReport();
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "日结":
                    {
                        this.ExecDayReport();
                        break;
                    }
                case "时间":
                    {
                        ChooseDateTime();
                        break;
                    }
                case "汇总":
                    {
                        QueryOrCollectData();
                        break;
                    }
                #region {05FE6DC0-EE61-4aba-A00D-E57B853B3793}日结汇总补打
                case "补打":
                    {
                        QueryOrCollectDataCheck();
                        break;
                    }
                #endregion
                case "确认":
                    {
                        this.SaveCollectData();
                        break;
                    }
                case "帮助":
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.OperationType != OperType.DayReport) return -1;
            this.Save();
            return base.OnSave(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            QueryOrCollectData();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
            return base.OnPrint(sender, neuObject);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            object tag = neuSpread1_Sheet1.ActiveCell.Tag;
            if (tag == null) return;
            if (neuSpread1_Sheet1.ActiveCell.Text.Trim() == string.Empty) return;
            if (operType == OperType.DayReport)
            {
                if (tag.ToString() == EnumColumn.LenderPrePay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(this.DtBegin, this.DtEnd, operType);
                    c.FrmTitle = "贷方医疗预收款明细";
                    c.aMod = 1;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }
                if (tag.ToString() == EnumColumn.DebitPrePay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(this.DtBegin, this.DtEnd, operType);
                    c.FrmTitle = "借方医疗预收款明细";
                    c.aMod = 0;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }
                if (tag.ToString() == EnumColumn.LenderPay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(this.DtBegin, this.DtEnd, operType);
                    c.FrmTitle = "医疗应收款明细";
                    c.aMod = 2;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }
            }
            //汇总
            else
            {
                if (tag.ToString() == EnumColumn.LenderPrePay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(listEnviroment, operType);
                    c.FrmTitle = "贷方医疗预收款明细";
                    c.aMod = 1;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }
                if (tag.ToString() == EnumColumn.DebitPrePay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(listEnviroment, operType);
                    c.FrmTitle = "借方医疗预收款明细";
                    c.aMod = 0;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }
                if (tag.ToString() == EnumColumn.LenderPay.ToString())
                {
                    ucDayReportDetail c = new ucDayReportDetail(listEnviroment, operType);
                    c.FrmTitle = "医疗应收款明细";
                    c.aMod = 2;
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
                }

            }
        }
        #endregion
        
    }
    /// <summary>
    /// 用来设置是日结、查询还是汇总
    /// </summary>
    public enum OperType
    {
        /// <summary>
        /// 日结和查询
        /// </summary>
        DayReport = 0,
        /// <summary>
        /// 汇总
        /// </summary>
        CollectDayReport = 1,
    }
}
