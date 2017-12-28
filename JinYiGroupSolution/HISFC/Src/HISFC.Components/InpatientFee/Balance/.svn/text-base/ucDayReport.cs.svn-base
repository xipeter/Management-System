using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.InpatientFee.Balance
{
    public partial class ucDayReport : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        /// <summary>
        /// ucDayReport<br></br>
        /// [功能描述: 住院日结控件]<br></br>
        /// [创 建 者: 王儒超]<br></br>
        /// [创建时间: 2006-12-28]<br></br>
        /// <修改记录 
        ///		修改人='' 
        ///		修改时间='yyyy-mm-dd' 
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucDayReport()
        {

            InitializeComponent();
        }



        #region "变量"
        /// <summary>
        /// 日结业务层

        /// </summary>
        Neusoft.HISFC.Management.Fee.InpatientDayReport feeDayreport = new Neusoft.HISFC.Management.Fee.InpatientDayReport();
        Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();

        //toolbar
        Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();
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

        private DateTime dtDefaultBeginDate = Neusoft.NFC.Function.NConvert.ToDateTime("2006-01-01");

        #endregion

        #region "属性"
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

        #endregion

        #region"函数"
        /// <summary>
        /// 初始化函数
        /// </summary>
        protected virtual void Init()
        {

            //初始化时间和操作员

            this.lblOperator.Text = this.feeDayreport.Operator.Name;
            this.DtEnd = this.feeDayreport.GetDateTimeFromSysDateTime();
            this.lblStatDate.Text = this.feeDayreport.GetDateTimeFromSysDateTime().ToString();

            //获取上次日结信息实体
            Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();
            dayReport = this.feeDayreport.GetOperLastDayReport(this.feeDayreport.Operator.ID);
            if (dayReport == null)
            {
                dayReport = new Neusoft.HISFC.Object.Fee.DayReport();
                dayReport.EndDate = this.DefaultBeginDate;
            }
            this.DtBegin = dayReport.EndDate;

        }
        /// <summary>
        /// 利用实体赋值控件

        /// </summary>
        protected virtual void SetDayReportValue(Neusoft.HISFC.Object.Fee.DayReport dayReport)
        {

            //开始时间

            this.lblBeginDate.Text = dayReport.BeginDate.ToString();

            //结束日期
            this.lblEndDate.Text = dayReport.EndDate.ToString();

            //操作员代码

            this.lblOperator.Text = this.feeDayreport.Operator.Name;

            //统计时间
            this.lblStatDate.Text = dayReport.Oper.OperTime.ToString();

            //收取预交金金额

            this.lblLPrepayCost.Text = dayReport.PrepayCost.ToString();
            //医疗结算医药费

            this.lblLBalanceCost.Text = dayReport.BalanceCost.ToString();

            //贷方支票金额
            this.lblLCheckCost.Text = dayReport.LenderCheckCost.ToString();

            //借方支票金额
            this.lblDCheckCost.Text = dayReport.DebitCheckCost.ToString();

            //借方银行卡金额

            this.lblDBankCost.Text = dayReport.DebitBankCost.ToString();

            //贷方银行卡金额

            this.lblLBankCost.Text = dayReport.LenderBankCost.ToString();

            //公费记帐金额
            this.lblDBursaryCost.Text = dayReport.BursaryPubCost.ToString();

            //市医保帐户支付金额

            this.lblDCityAccountCost.Text = dayReport.CityMedicarePayCost.ToString();

            //市医保统筹金额

            this.lblDCityPubCost.Text = dayReport.CityMedicarePubCost.ToString();

            //省医保帐户支付金额

            this.lblDProvinceAccountCost.Text = dayReport.ProvinceMedicarePayCost.ToString();

            //省医保统筹金额

            this.lblDProvincePubCost.Text = dayReport.ProvinceMedicarePubCost.ToString();

            //库存金额（上缴金额）
            this.lblLCashCost.Text = dayReport.TurnInCash.ToString();

            //预交金发票张数

            this.lblPrepayNum.Text = dayReport.PrepayInvCount.ToString();

            //结算发票张数
            this.lblBalanceNum.Text = dayReport.BalanceInvCount.ToString();

            //作废预交金发票号码

            this.lblWastePrepayNO.Text = dayReport.PrepayWasteInvNO;

            //作废结算发票号码
            this.lblWasteBalanceNO.Text = dayReport.BalanceWasteInvNO;

            //作废预交金发票张数

            this.lblWastePrepayNum.Text = dayReport.PrepayWasteInvCount.ToString();

            //作废结算发票张数
            this.lblWasteBalanceNum.Text = dayReport.BalanceWasteInvCount.ToString();

            //预交金发票区间

            this.lblPreInvZone.Text = dayReport.PrepayInvZone;

            //结算发票区间
            this.lblBalanceInvZone.Text = dayReport.BalanceInvZone;


        }
        /// <summary>
        /// 从控件取日结信息
        /// </summary>
        /// <returns>日结实体</returns>
        protected virtual Neusoft.HISFC.Object.Fee.DayReport GetDayReportValue()
        {
            Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();
            //统计序号
                dayReport.StatNO = this.feeDayreport.GetNewDayReportID();

               //开始时间
                dayReport.BeginDate = Neusoft.NFC.Function.NConvert.ToDateTime(this.lblBeginDate.Text);
               //结束日期
                dayReport.EndDate = Neusoft.NFC.Function.NConvert.ToDateTime(this.lblEndDate.Text);

               //操作员代码
               dayReport.Oper.ID = this.feeDayreport.Operator.ID;
               //统计时间
               dayReport.Oper.OperTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.lblStatDate.Text);

               //收取预交金金额

               dayReport.PrepayCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblLPrepayCost.Text);
               //借方支票金额

               dayReport.DebitCheckCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDCheckCost.Text) ;
                //借方银行卡金额

               dayReport.DebitBankCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDBankCost.Text);
               //结算预交金金额

               dayReport.BalancePrepayCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDPrepayCost.Text);
                //贷方支票金额

               dayReport.LenderCheckCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblLCheckCost.Text);
                //贷方银行卡金额

               dayReport.LenderBankCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblLBankCost.Text);
               //公费记帐金额
               dayReport.BursaryPubCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDBursaryCost.Text);
               //市医保帐户支付金额

               dayReport.CityMedicarePayCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDCityAccountCost.Text);
               //市医保统筹金额

               dayReport.CityMedicarePubCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDCityPubCost.Text);
               //省医保帐户支付金额

               dayReport.ProvinceMedicarePayCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDProvinceAccountCost.Text);
               //省医保统筹金额

               dayReport.ProvinceMedicarePubCost = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDProvinceAccountCost.Text);
               //库存金额（上缴金额）
               dayReport.TurnInCash = Neusoft.NFC.Function.NConvert.ToDecimal(this.lblDCashCost.Text);
               //预交金发票张数

               dayReport.PrepayInvCount = Neusoft.NFC.Function.NConvert.ToInt32(this.lblPrepayNum.Text);
               //结算发票张数
               dayReport.BalanceInvCount = Neusoft.NFC.Function.NConvert.ToInt32(this.lblBalanceNum.Text);
               //作废预交金发票号码

               dayReport.PrepayWasteInvNO = this.lblWastePrepayNO.Text ;
               //作废结算发票号码
               dayReport.BalanceWasteInvNO = this.lblWasteBalanceNO.Text ;
               //作废预交金发票张数
                dayReport.PrepayWasteInvCount = Neusoft.NFC.Function.NConvert.ToInt32(lblWastePrepayNum.Text);
               //作废结算发票张数
                dayReport.BalanceWasteInvCount = Neusoft.NFC.Function.NConvert.ToInt32(this.lblWasteBalanceNum.Text);
               //预交金发票区间
                dayReport.PrepayInvZone = this.lblPreInvZone.Text;
               //结算发票区间
                dayReport.BalanceInvZone = this.lblBalanceInvZone.Text;
               //收费员科室

                dayReport.Oper.Dept.ID = ((Neusoft.HISFC.Object.Base.Employee)this.feeDayreport.Operator).Dept.ID;
                //结算总金额

                dayReport.BalanceCost = Neusoft.NFC.Function.NConvert.ToDecimal(lblLBalanceCost.Text);

            return dayReport;
        }

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("日结", "开始进行日结费用统计",(int)Neusoft.NFC.Interface.Classes.EnumImageList.F手动录入, true, false, null);

            //toolBarService.AddToolButton("查询", "查询以往日结信息", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A查询, true, false, null);

            //toolBarService.AddToolButton("打印", "打印日结报表", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A打印, true, false, null);

            toolBarService.AddToolButton("时间", "选择日结时间范围", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A设置, true, false, null);

            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A帮助, true, false, null);

            //toolBarService.AddToolButton("保存", "保存日结信息", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A保存, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "日结":

                    this.ExecDayReport();
                    break;
                //case "查询":

                //    this.QueryDayReport();
                //    break;
                case "时间":

                    ChooseDateTime();
                    break;
                //case "打印":

                //    this.PrintDayReport();
                //    break;
                case "帮助":

                    break;
                //case "保存":
                //    Save();
                //    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }



        /// <summary>
        /// 选择时间
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int ChooseDateTime()
        {


            Neusoft.NFC.Interface.Forms.BaseForm f;
            f = new Neusoft.NFC.Interface.Forms.BaseForm();

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


        /// <summary>
        /// 执行日结过程
        /// </summary>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int ExecDayReport()
        {
            try
            {
                //统计时间
                this.lblStatDate.Text = this.feeDayreport.GetDateTimeFromSysDateTime().ToString();

                Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();

                //日结收取预交金金额

                this.lblLPrepayCost.Text = this.feeDayreport.GetPrepayCostByOperIDAndTime(this.DtBegin, this.dtEnd, this.feeDayreport.Operator.ID);

                //日结结算预交金金额

                this.lblDPrepayCost.Text = this.feeDayreport.GetBalancedPrepayCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);

                //日结结算总金额

                this.lblLBalanceCost.Text = this.feeDayreport.GetBalancedCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);

                //借方支票
                decimal prepayCheckCost = 0m;
                prepayCheckCost = decimal.Parse(this.feeDayreport.GetPrepayCheckCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));
                decimal supplyCheckCost = 0m;
                supplyCheckCost = decimal.Parse(this.feeDayreport.GetSupplyCheckCostByOperIDAndTime(this.DtEnd, this.DtEnd, this.feeDayreport.Operator.ID));
                this.lblDCheckCost.Text = (prepayCheckCost + supplyCheckCost).ToString();

                //贷方支票
                this.lblLCheckCost.Text = this.feeDayreport.GetReturnCheckCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID);

                //借方现金
                decimal prepayCashCost = 0m;
                prepayCashCost = decimal.Parse(feeDayreport.GetPrepayCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));

                decimal supplyCashCost = 0m;
                supplyCashCost = decimal.Parse(feeDayreport.GetSupplyCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));

                decimal returnCashCost = 0m;
                returnCashCost = decimal.Parse(feeDayreport.GetReturnCashCostByOperIDAndTime(this.DtBegin, this.DtEnd, this.feeDayreport.Operator.ID));

                this.lblDCashCost.Text = (prepayCashCost - returnCashCost + supplyCashCost).ToString();

                //借方银行
                decimal prepayBankCost = 0m;
                prepayBankCost = decimal.Parse(feeDayreport.GetPrepayBankCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID));

                decimal supplyBankCost = 0m;
                supplyBankCost = decimal.Parse(feeDayreport.GetSupplyBankCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID));

                this.lblDBankCost.Text = (prepayBankCost + supplyBankCost).ToString();


                //贷方银行
                this.lblLBankCost.Text = this.feeDayreport.GetReturnBankCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);

                //公费记帐金额
                this.lblDBursaryCost.Text = this.feeDayreport.GetBursaryCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);

                //市医保帐户支付

                this.lblDCityAccountCost.Text = this.feeDayreport.GetCPayCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);


                //市医保统筹支付

                this.lblDCityPubCost.Text = this.feeDayreport.GetCPubCostByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);

                //省医保帐户

                this.lblDProvinceAccountCost.Text = "0.00";

                //省医保统筹支付

                this.lblDProvincePubCost.Text = "0.00";

                //借方合计
                this.lblDTotCost.Text = Neusoft.NFC.Public.String.ExpressionVal(this.lblDPrepayCost.Text + "+" + this.lblDCashCost.Text
                    + "+" + lblDCheckCost.Text + "+" + lblDBankCost.Text + "+" + lblDBursaryCost.Text + "+" + lblDCityAccountCost.Text
                    + "+" + lblDCityPubCost.Text + "+" + lblDProvinceAccountCost.Text + "+" + lblDProvincePubCost.Text).ToString();
                //贷方合计
                this.lblLTotCost.Text = Neusoft.NFC.Public.String.ExpressionVal(this.lblLPrepayCost.Text + "+" + this.lblLCheckCost.Text
                    + this.lblLBalanceCost.Text + "+" + this.lblLBankCost.Text).ToString();

                //预交金有效张数


                this.lblPrepayNum.Text = this.feeDayreport.GetValidPrepayInvoiceQtyByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);
                //预交金作废张数

                this.lblWastePrepayNum.Text = this.feeDayreport.GetWastePrepayInvoiceQtyByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);

                //预交金票据区间

                Neusoft.NFC.Object.NeuObject invoiceZone = new Neusoft.NFC.Object.NeuObject();

                invoiceZone = this.feeDayreport.GetPrepayInvoiceZoneByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);

                if (invoiceZone != null)
                {
                    this.lblPreInvZone.Text = invoiceZone.ID.ToString() + "----" + invoiceZone.Name;
                }

                //预交金作废票号

                ArrayList alWasteNO = new ArrayList();
                alWasteNO = this.feeDayreport.QueryWastePrepayInvNOByOperIDAndTime(DtBegin, dtEnd, feeDayreport.Operator.ID);
                string wasteInvNO = "";
                Neusoft.HISFC.Object.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Object.Fee.Inpatient.Prepay();
                if (alWasteNO.Count == 0)
                {
                    this.lblWastePrepayNO.Text = "";
                }
                else
                {
                    for (int i = 0; i < alWasteNO.Count; i++)
                    {
                        prepay = (Neusoft.HISFC.Object.Fee.Inpatient.Prepay)alWasteNO[i];
                        wasteInvNO = wasteInvNO + prepay.RecipeNO + ",";
                    }
                    this.lblWastePrepayNO.Text = wasteInvNO.Substring(0, wasteInvNO.Length - 1);
                }
                

                //结算有效张数
                this.lblBalanceNum.Text = this.feeDayreport.GetValidBalanceInvoiceQtyByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);

                //结算作废张数
                this.lblWasteBalanceNum.Text = this.feeDayreport.GetWasteBalanceInvoiceQtyByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);

                //结算票据区间
                Neusoft.NFC.Object.NeuObject balanceInvoiceZone = new Neusoft.NFC.Object.NeuObject();
                balanceInvoiceZone = this.feeDayreport.GetBalanceInvoiceZoneByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                if (balanceInvoiceZone != null)
                {
                    this.lblBalanceInvZone.Text = balanceInvoiceZone.ID.ToString() + "----" + balanceInvoiceZone.Name;
                }

                //结算作废票号
                ArrayList alWasteBalanceInvNO = new ArrayList();
                alWasteBalanceInvNO = this.feeDayreport.QueryWasteBalanceInvNOByOperIDAndTime(DtBegin, DtEnd, feeDayreport.Operator.ID);
                string balanceWasteNO = "";
                Neusoft.HISFC.Object.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Object.Fee.Inpatient.Balance();

                if (alWasteBalanceInvNO.Count == 0)
                {
                    lblWasteBalanceNO.Text = "";
                }
                else
                {
                    for (int j = 0; j < alWasteBalanceInvNO.Count; j++)
                    {
                        balance = (Neusoft.HISFC.Object.Fee.Inpatient.Balance)alWasteBalanceInvNO[j];
                        balanceWasteNO = balanceWasteNO + balance.Invoice.ID + ",";
                    }
                    this.lblWasteBalanceNO.Text = balanceWasteNO.Substring(0, balanceWasteNO.Length - 1);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("获取日结信息出错！"+this.feeDayreport.Err);
                return -1;
            }

            this.OperMode = "1";

            return 1;
        }




        /// <summary>
        /// 保存日结信息
        /// </summary>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (this.OperMode != "1") return -1;

            Neusoft.HISFC.Object.Fee.DayReport dayReport = new Neusoft.HISFC.Object.Fee.DayReport();

            dayReport = this.GetDayReportValue();

            if (dayReport.BalanceCost == 0 && dayReport.PrepayCost == 0)
            {
                Neusoft.NFC.Interface.Classes.Function.Msg("时间范围内没有发生费用！", 111);
                return -1;

            }



            if (this.feeDayreport.InsertDayReport(dayReport) < 1)
            {
                Neusoft.NFC.Interface.Classes.Function.Msg("保存日结出错！" + this.feeDayreport.Err, 211);
                return -1;
            }
            else
            {
                MessageBox.Show("保存成功！");
                this.OperMode = "2";
            }
            return 1;
        }

        /// <summary>
        /// 打印日报表

        /// </summary>
        protected override int OnPrint(object sender, object neuObject)
        {

            //if (Neusoft.NFC.Function.NConvert.ToDecimal(this.lblLBalanceCost.Text) == 0 && Neusoft.NFC.Function.NConvert.ToDecimal(this.lblPrepayCost.Text) == 0)
            //{
            //    Neusoft.NFC.Interface.Classes.Function.Msg("时间范围内没有发生预交金和结算费用！", 111);

            //}
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();

            print.PrintPage(0, 0, this);
            return 1;
        }
        /// <summary>
        /// 查询以往日结信息
        /// </summary>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            ucPopDayReportQuery ucQuery = new ucPopDayReportQuery();
            ucQuery.OnEndChoose += new ucPopDayReportQuery.mydelegateEndChoose(ucQuery_OnEndChoose);
            Neusoft.NFC.Interface.Classes.Function.PopShowControl(ucQuery);

            return 1;

        }



        #endregion

        #region "事件"

        private void ucDayReport_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        void ucQuery_OnEndChoose(Neusoft.HISFC.Object.Fee.DayReport dayReport)
        {
            this.SetDayReportValue(dayReport);
            this.OperMode = "2";
        }

        void ucTime_OnEndChooseDateTime(DateTime beginTime, DateTime endTime)
        {
            this.DtBegin = beginTime;
            this.DtEnd = endTime;
            //执行日结
            this.ExecDayReport();
        }

        #endregion
    }
}
