using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.InvoicePrint
{
    public partial class ucSplitInvoice : UserControl
    {
        public ucSplitInvoice()
        {
            InitializeComponent();
        }

        #region 变量

        ucSplitUnit splitUnit = new ucSplitUnit();
        private Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice = new Neusoft.HISFC.Models.Fee.Outpatient.Balance();

        /// <summary>
        /// 费用业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParam = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        private ArrayList invoiceDetails = new ArrayList();
        private string beginInvoiceNo = "";//开始发票号
        private string beginRealInvoiceNo = "";//开始实际发票号
        private string endInvoiceNo = "";//结束发票号
        private string endRealInvoiceNo = "";//结束实际发票号
        private string invoiceType = "";//发票类别
        private bool isAuto = false;//是否自动分票
        private int count = 0;//分票张数
        private ArrayList splitInvoices = new ArrayList();//分发票后的主发票集合
        private ArrayList splitInvoiceDetails = new ArrayList();//分发票后的发票明细
        private int days = 1;//间隔天数
        private bool isConfirm = false; //是否确认分票
        private string invoiceNoType;//发票号方式
        private string STATCODEJC = string.Empty;
        private string STATCODEZL = string.Empty;

        #endregion

        #region 属性

        /// <summary>
        /// 发票号方式
        /// </summary>
        public string InvoiceNoType
        {
            set
            {
                invoiceNoType = value;
            }
        }

        /// <summary>
        /// 是否确认分票
        /// </summary>
        public bool IsConfirm
        {
            get
            {
                return this.isConfirm;
            }
        }

        /// <summary>
        /// 确认天数
        /// </summary>
        public int Days
        {
            set
            {
                days = value;
            }
        }

        /// <summary>
        /// 分发票后的主发票集合
        /// </summary>
        public ArrayList SplitInvoices
        {
            get
            {
                splitInvoices = GetSplitInvoices("1");
                return splitInvoices;
            }
        }

        /// <summary>
        /// 分发票后的发票明细
        /// </summary>
        public ArrayList SplitInvoiceDetails
        {
            get
            {
                splitInvoiceDetails = GetSplitInvoices("2");
                return splitInvoiceDetails;
            }
        }

        /// <summary>
        /// 分票数量
        /// </summary>
        public int Count
        {
            set
            {
                count = value;
                this.tbCount.Text = count.ToString();
            }
        }

        /// <summary>
        /// 是否自动分票
        /// </summary>
        public bool IsAuto
        {
            set
            {
                isAuto = value;

                this.cbAuto.Checked = isAuto;
            }
        }

        /// <summary>
        /// 发票类别
        /// </summary>
        public string InvoiceType
        {
            set
            {
                invoiceType = value;
            }
        }

        /// <summary>
        /// 开始发票号
        /// </summary>
        public string BeginInvoiceNo
        {
            set
            {
                beginInvoiceNo = value;
                if (beginInvoiceNo == null || beginInvoiceNo == "")
                {
                    MessageBox.Show("请输入发票号!");
                    return;
                }
            }
        }

        /// <summary>
        /// 开始实际发票号
        /// </summary>
        public string BeginRealInvoiceNo
        {
            set
            {
                beginRealInvoiceNo = value;
            }
        }

        /// <summary>
        /// 结束发票号
        /// </summary>
        public string EndInvoiceNo
        {
            get
            {
                return endInvoiceNo;
            }
        }

        /// <summary>
        /// 结束实际发票号
        /// </summary>
        public string EndRealInvoiceNo
        {
            get
            {
                return endRealInvoiceNo;
            }
        }

        /// <summary>
        /// 发票明细实体
        /// </summary>
        ///
        public ArrayList InvoiceDetails
        {
            get
            {
                return invoiceDetails;
            }
            set
            {
                invoiceDetails = value;
            }
        }

        /// <summary>
        /// 发票实体
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Outpatient.Balance Invoice
        {
            get
            {
                return invoice;
            }
            set
            {
                invoice = value;
            }
        }

        #endregion

        #region 函数
        /// <summary>
        /// 获得调整后的发票信息
        /// </summary>
        /// <param name="flag">1主发票集合 2 发票明细信息</param>
        /// <returns></returns>
        public ArrayList GetSplitInvoices(string flag)
        {
            ArrayList alTempAll = new ArrayList();
            ArrayList alTempInvoice = new ArrayList();
            ArrayList alTempInvoiceDetails = new ArrayList();
            for (int i = 0; i < this.plSplitUnits.Controls.Count; i++)
            {
                try
                {
                    ((ucSplitUnit)plSplitUnits.Controls[i]).Invoice.PrintTime = ((ucSplitUnit)plSplitUnits.Controls[i]).Invoice.PrintTime;
                    
                    alTempInvoice.Add(((ucSplitUnit)plSplitUnits.Controls[i]).Invoice);

                    alTempInvoiceDetails.Add(((ucSplitUnit)plSplitUnits.Controls[i]).InvoiceDetails);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (flag == "1")//主发票信息
            {
                return alTempInvoice;
            }
            else
            {
                return alTempInvoiceDetails;
            }
        }
        /// <summary>
        /// 默认分发票
        /// </summary>
        /// <param name="count">分票的张数</param>
        /// <param name="splitFlag">类型 1自动 0 自定义</param>
        public void AddInvoiceUnits(int count, string splitFlag)
        {
            //清空控件
            ClearInvoicUnits();

            int xPoint = 0, yPoint = 0;
            DateTime dtTempPrint = this.invoice.PrintTime;
            for (int i = 0; i < count; i++)
            {
                splitUnit = new ucSplitUnit();

                if (Math.IEEERemainder(i, 2) == 0)
                {
                    xPoint = 28;
                }
                else
                {
                    xPoint = 16 * 2 + splitUnit.Width + 25;
                }

                yPoint = 14 + (i / 2) * (16 + splitUnit.Height);
                if (i > 0)
                {
                    dtTempPrint = dtTempPrint.AddDays(this.days);
                }
                splitUnit.Location = new System.Drawing.Point(xPoint, yPoint);
                splitUnit.Name = "splitUnit" + i.ToString();
                splitUnit.InvoiceDate = dtTempPrint;
                splitUnit.TabIndex = i + 1;
                splitUnit.CostChanged += new ucSplitUnit.ChangeCost(splitUnit_CostChanged);
                splitUnit.ModifyFinished += new ucSplitUnit.ChangeFocus(splitUnit_ModifyFinished);
                if (splitFlag == "1")//自动分发票
                {
                    splitUnit.IsLast = true;
                }
                else
                {
                    if (i == count - 1)
                    {
                        splitUnit.IsLast = true;
                    }
                    else
                    {
                        splitUnit.IsLast = false;
                    }
                }

                this.plSplitUnits.Controls.Add(splitUnit);
            }

            this.ucInvoicePreviewGF1.InvoiceType = invoiceType;
            ArrayList alTempInvoice = new ArrayList();
            alTempInvoice.Add(invoice);
            ArrayList alTempInvoiceAndDetails = new ArrayList();
            alTempInvoiceAndDetails.Add(alTempInvoice);
            ArrayList tempInvoiceDetails = new ArrayList();
            ArrayList tempInvoiceDetailsTow = new ArrayList();
            tempInvoiceDetailsTow.Add(invoiceDetails);
            tempInvoiceDetails.Add(tempInvoiceDetailsTow);

            alTempInvoiceAndDetails.Add(tempInvoiceDetails);
            this.ucInvoicePreviewGF1.InvoiceAndDetails = alTempInvoiceAndDetails;

            ArrayList tempSplit = new ArrayList();
            decimal errorOwnCost = 0, errorPubCost = 0, errorTotCost = 0, errorPayCost = 0;//各项金额分票时得误差
            decimal errCTFee = 0, errMRIFee = 0, errSXFee = 0, errSYFee = 0;//CT费等误差
            decimal sumOwnCost = 0, sumPubCost = 0, sumTotCost = 0, sumPayCost = 0;//根据发票明细汇总得发票金额
            Neusoft.HISFC.Models.Fee.Outpatient.Balance tempInvoice = null;

            Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detailTemp = null;
            ArrayList invoiceDetailsSplit = new ArrayList();
            ArrayList invoicesSplit = new ArrayList();
            int iReturn = 0;
            for (int i = 0; i < count; i++)
            {
                ArrayList invoiceDetailsToInvoice = new ArrayList();
                string beginTempInvoiceNo = "";
                string beginTempRealInvoiceNo = "";
                string errText = "";

                if (invoiceNoType == "2")//普通模式需要Trans支持
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    iReturn = this.feeIntegrate.GetNextInvoiceNO(invoiceNoType, beginInvoiceNo, beginRealInvoiceNo, ref beginTempInvoiceNo, ref beginTempRealInvoiceNo, i + 1, ref errText);
                    if (iReturn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                        
                        this.plSplitUnits.Controls.Clear();

                        return;
                    }

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();//因为此时不一定插入数据库,所以回滚,保持发票不跳号
                }
                else
                {
                    iReturn = this.feeIntegrate.GetNextInvoiceNO(this.invoiceNoType, beginInvoiceNo, this.beginRealInvoiceNo, ref beginTempInvoiceNo, ref beginTempRealInvoiceNo, i, ref errText);
                    if (iReturn < 0)
                    {
                        MessageBox.Show(errText);
                        return;
                    }
                }
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail in invoiceDetails)
                {
                    detailTemp = detail.Clone();

                    detailTemp.BalanceBase.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((detail.BalanceBase.FT.TotCost / (decimal)count), 2);
                    detailTemp.BalanceBase.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber((detail.BalanceBase.FT.PayCost / (decimal)count), 2);
                    detailTemp.BalanceBase.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber((detail.BalanceBase.FT.OwnCost / (decimal)count), 2);
                    detailTemp.BalanceBase.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber((detail.BalanceBase.FT.PubCost / (decimal)count), 2);
                    detailTemp.CTFee = Neusoft.FrameWork.Public.String.FormatNumber((detail.CTFee / (decimal)count), 2);
                    detailTemp.MRIFee = Neusoft.FrameWork.Public.String.FormatNumber((detail.MRIFee / (decimal)count), 2);
                    detailTemp.SXFee = Neusoft.FrameWork.Public.String.FormatNumber((detail.SXFee / (decimal)count), 2);
                    detailTemp.SYFee = Neusoft.FrameWork.Public.String.FormatNumber((detail.SYFee / (decimal)count), 2);
                    detailTemp.BalanceBase.Invoice.ID = beginTempInvoiceNo;

                    errorOwnCost = detail.BalanceBase.FT.OwnCost - detailTemp.BalanceBase.FT.OwnCost * count;
                    errorPubCost = detail.BalanceBase.FT.PubCost - detailTemp.BalanceBase.FT.PubCost * count;
                    errorPayCost = detail.BalanceBase.FT.PayCost - detailTemp.BalanceBase.FT.PayCost * count;
                    errorTotCost = detail.BalanceBase.FT.TotCost - detailTemp.BalanceBase.FT.TotCost * count;
                    errCTFee = detail.CTFee - detailTemp.CTFee * count;
                    errMRIFee = detail.MRIFee - detailTemp.MRIFee * count;
                    errSXFee = detail.SXFee - detailTemp.SXFee * count;
                    errSYFee = detail.SYFee - detailTemp.SYFee * count;

                    if (i == 0)
                    {
                        detailTemp.BalanceBase.FT.TotCost = detailTemp.BalanceBase.FT.TotCost + errorTotCost;
                        detailTemp.BalanceBase.FT.PayCost = detailTemp.BalanceBase.FT.PayCost + errorPayCost;
                        detailTemp.BalanceBase.FT.OwnCost = detailTemp.BalanceBase.FT.OwnCost + errorOwnCost;
                        detailTemp.BalanceBase.FT.PubCost = detailTemp.BalanceBase.FT.PubCost + errorPubCost;

                        detailTemp.CTFee += errCTFee;
                        detailTemp.MRIFee += errMRIFee;
                        detailTemp.SXFee += errSXFee;
                        detailTemp.SYFee += errSYFee;
                    }

                    invoiceDetailsToInvoice.Add(detailTemp);
                }

                invoiceDetailsSplit.Add(invoiceDetailsToInvoice);
            }
            for (int i = 0; i < count; i++)
            {
                tempInvoice = invoice.Clone();

                string beginTempInvoiceNo = "";
                string beginTempRealInvoiceNo = "";
                string errText = "";

                if (invoiceNoType == "2")//普通模式需要Trans支持
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    iReturn = this.feeIntegrate.GetNextInvoiceNO(invoiceNoType, beginInvoiceNo, this.beginRealInvoiceNo, ref beginTempInvoiceNo, ref beginTempRealInvoiceNo, i + 1, ref errText);
                    if (iReturn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        this.plSplitUnits.Controls.Clear();

                        return;
                    }

                    beginTempRealInvoiceNo = (Neusoft.FrameWork.Function.NConvert.ToInt32(beginTempRealInvoiceNo) - 1).ToString();

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();//因为此时不一定插入数据库,所以回滚,保持发票不跳号
                }
                else
                {
                    iReturn = this.feeIntegrate.GetNextInvoiceNO(this.invoiceNoType, beginInvoiceNo, this.beginRealInvoiceNo, ref beginTempInvoiceNo, ref beginTempRealInvoiceNo, i, ref errText);
                    if (iReturn < 0)
                    {
                        MessageBox.Show(errText);
                        return;
                    }
                }
                //重新计算金额
                ArrayList invoiceDetailsTemp = invoiceDetailsSplit[i] as ArrayList;
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail in invoiceDetailsTemp)
                {
                    sumOwnCost += detail.BalanceBase.FT.OwnCost;
                    sumPubCost += detail.BalanceBase.FT.PubCost;
                    sumPayCost += detail.BalanceBase.FT.PayCost;
                    sumTotCost += detail.BalanceBase.FT.TotCost;
                }

                tempInvoice.FT.TotCost = sumTotCost;
                tempInvoice.FT.PayCost = sumPayCost;
                tempInvoice.FT.OwnCost = sumOwnCost;
                tempInvoice.FT.PubCost = sumPubCost;
                tempInvoice.Invoice.ID = beginTempInvoiceNo;
                tempInvoice.PrintedInvoiceNO = beginTempRealInvoiceNo;

                sumTotCost = 0;
                sumPayCost = 0;
                sumOwnCost = 0;
                sumPubCost = 0;

                invoicesSplit.Add(tempInvoice);
            }
            //添加信息到控件.
            for (int i = 0; i < count; i++)
            {
                try
                {
                    ((ucSplitUnit)plSplitUnits.Controls[i]).Invoice = invoicesSplit[i] as Neusoft.HISFC.Models.Fee.Outpatient.Balance;
                    ((ucSplitUnit)plSplitUnits.Controls[i]).InvoiceDetails = invoiceDetailsSplit[i] as ArrayList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void splitUnit_ModifyFinished(int seq)
        {
            if (seq == count)
            {
                seq = 1;
            }
            foreach (Control ctrl in this.plSplitUnits.Controls)
            {
                if (((ucSplitUnit)ctrl).SeqNO == seq)
                {
                    ((ucSplitUnit)ctrl).IsFocus = true;
                }
            }
        }

        bool splitUnit_CostChanged(string feeStat, decimal orgCost, decimal newCost, ref Neusoft.HISFC.Models.Base.FT ft, ref decimal CTFee, ref decimal MRIFee, ref decimal SXFee, ref decimal SYFee)
        {
             ucSplitUnit tempLastSpitUnit = new ucSplitUnit();
            foreach (Control crtl in this.plSplitUnits.Controls)
            {
                if (((ucSplitUnit)crtl).IsLast)
                {
                    tempLastSpitUnit = (ucSplitUnit)crtl;
                    ArrayList detailsTemp = ((ucSplitUnit)crtl).InvoiceDetails;
                    Neusoft.HISFC.Models.Fee.Outpatient.Balance invoiceTemp = ((ucSplitUnit)crtl).Invoice;
                    foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail in detailsTemp)
                    {
                        if (detail.FeeCodeStat.ID == feeStat)
                        {
                            if (detail.BalanceBase.FT.TotCost + orgCost < newCost)
                            {
                                MessageBox.Show("分票的金额大于可分金额!");

                                return false;
                            }
                            else
                            {
                                decimal errCost = newCost - orgCost;

                                if (feeStat == this.STATCODEJC)//检查项目
                                {
                                    detail.CTFee += CTFee;
                                    detail.MRIFee += MRIFee;
                                    MRIFee = 0;
                                    CTFee = 0;

                                }
                                if (feeStat == this.STATCODEZL)//检查项目
                                {
                                    detail.SXFee += SXFee;
                                    detail.SYFee += SYFee;
                                    SXFee = 0;
                                    SYFee = 0;
                                }

                                detail.BalanceBase.FT.TotCost = detail.BalanceBase.FT.TotCost - errCost;
                                detail.BalanceBase.FT.OwnCost = detail.BalanceBase.FT.OwnCost - errCost;

                                invoiceTemp.FT.TotCost = invoiceTemp.FT.TotCost - errCost;
                                invoiceTemp.FT.OwnCost = invoiceTemp.FT.OwnCost - errCost;

                                if (feeStat == this.STATCODEJC)//检查
                                {
                                    if ((detail.BalanceBase.FT.TotCost) < detail.CTFee + detail.MRIFee)
                                    {
                                        decimal tempCost = 0;
                                        decimal errCostOut = detail.CTFee + detail.MRIFee - detail.BalanceBase.FT.TotCost;
                                        tempCost = errCost - detail.CTFee;
                                        if (tempCost <= 0)
                                        {
                                            CTFee = tempCost;
                                            detail.CTFee = detail.CTFee - tempCost;
                                            MRIFee = 0;
                                        }
                                        else
                                        {
                                            CTFee = detail.CTFee;
                                            detail.CTFee = 0;
                                            MRIFee = tempCost - detail.CTFee;
                                            detail.MRIFee = detail.MRIFee - MRIFee;
                                        }
                                    }
                                }
                                if (feeStat == this.STATCODEZL)//检查
                                {
                                    if ((detail.BalanceBase.FT.TotCost) < detail.SYFee + detail.SXFee)
                                    {
                                        decimal tempCost = 0;
                                        decimal errCostOut = detail.SYFee + detail.SXFee - detail.BalanceBase.FT.TotCost;
                                        tempCost = errCost - detail.SYFee;
                                        if (tempCost <= 0)
                                        {
                                            SYFee = tempCost;
                                            SXFee = 0;
                                        }
                                        else
                                        {
                                            SYFee = detail.SYFee;
                                            SXFee = tempCost - detail.SYFee;
                                        }
                                    }
                                }
                            }

                            tempLastSpitUnit.Invoice = invoiceTemp;
                            tempLastSpitUnit.InvoiceDetails = detailsTemp;
                        }
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 清空显示的控见
        /// </summary>
        private void ClearInvoicUnits()
        {
            plSplitUnits.Controls.Clear();
            plSplitUnits.Refresh();
        }

        #endregion

        #region 事件
        private void cbAuto_CheckedChanged(object sender, System.EventArgs e)
        {
            isAuto = this.cbAuto.Checked;
            string temp = this.tbCount.Text.Trim();
            int tempCount = 0;
            try
            {
                tempCount = Neusoft.FrameWork.Function.NConvert.ToInt32(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("分票的数量输入不合法!" + ex.Message);
                return;
            }
            if (tempCount == 0)
            {
                MessageBox.Show("分票张数不能等于0");
                return;
            }
            if (tempCount > 9)
            {
                MessageBox.Show("分票张数不能大于9");
                return;
            }
            string tempFlag = null;
            if (isAuto)
            {
                tempFlag = "1";
            }
            else
            {
                tempFlag = "0";
            }
            this.AddInvoiceUnits(tempCount, tempFlag);
        }

        private void btnSplit_Click(object sender, System.EventArgs e)
        {
            string temp = this.tbCount.Text.Trim();
            int tempCount = 0;
            try
            {
                tempCount = Convert.ToInt32(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("分票的数量输入不合法!" + ex.Message);
                return;
            }
            if (tempCount <= 0)
            {
                MessageBox.Show("分票张数不能小于或者等于0");
                return;
            }

            int splitCounts = this.controlParam.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLITCOUNTS, false, 9);

            if (tempCount > splitCounts)
            {
                MessageBox.Show("分票张数不能大于9");
                return;
            }
            string tempFlag = null;
            if (isAuto)
            {
                tempFlag = "1";
            }
            else
            {
                tempFlag = "0";
            }
            this.AddInvoiceUnits(tempCount, tempFlag);
        }

        private void tbOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.isConfirm = true;
                this.FindForm().Close();
            }
            catch { }
        }

        private bool splitUnit_CostChanged(string feeStat, decimal orgCost, decimal newCost, ref decimal ownCost, ref decimal payCost, ref decimal pubCost, ref decimal CTFee, ref decimal MRIFee, ref decimal SXFee, ref decimal SYFee)
        {
           

                            #region 暂时屏蔽
                            //								decimal tempTotCost = detail.BalanceBase.FT.TotCost;
                            //								decimal orgPayCost =0, orgOwnCost = 0, orgPubCost = 0;
                            //
                            //								if(detail.BalanceBase.FT.TotCost + orgCost == newCost)
                            //								{
                            //									detail.BalanceBase.FT.TotCost = 0;
                            //									detail.BalanceBase.FT.OwnCost = 0;
                            //									detail.FT.Pub_Cost = 0;
                            //									detail.FT.Pay_Cost = 0;
                            //
                            //									ownCost = ownCost + detail.BalanceBase.FT.OwnCost;
                            //									payCost = payCost + detail.FT.Pay_Cost;
                            //									pubCost = pubCost + detail.FT.Pub_Cost;
                            //
                            //									invoiceTemp.FT.TotCost = invoiceTemp.FT.TotCost - detail.BalanceBase.FT.TotCost;
                            //									invoiceTemp.FT.Pay_Cost = invoiceTemp.FT.Pay_Cost - detail.FT.Pay_Cost;
                            //									invoiceTemp.FT.Pub_Cost = invoiceTemp.FT.Pub_Cost - detail.FT.Pub_Cost;
                            //									invoiceTemp.FT.OwnCost = invoiceTemp.FT.OwnCost - detail.BalanceBase.FT.OwnCost;
                            //								}
                            //								else
                            //								{
                            //									orgPayCost = detail.FT.Pay_Cost;
                            //									orgOwnCost = detail.BalanceBase.FT.OwnCost;
                            //									orgPubCost = detail.FT.Pub_Cost;
                            //
                            //									if(orgOwnCost > 0)//自费
                            //									{
                            //										detail.BalanceBase.FT.OwnCost = orgOwnCost - (newCost - orgCost);
                            //										detail.BalanceBase.FT.TotCost = detail.BalanceBase.FT.TotCost - (newCost - orgCost);
                            //										invoiceTemp.FT.TotCost = invoiceTemp.FT.TotCost - (newCost - orgCost);
                            //										invoiceTemp.FT.Pay_Cost = 0;
                            //										invoiceTemp.FT.Pub_Cost = 0;
                            //										invoiceTemp.FT.OwnCost = invoiceTemp.FT.TotCost;
                            //									}
                            //									else //公费
                            //									{
                            //										detail.BalanceBase.FT.TotCost = detail.BalanceBase.FT.TotCost - (newCost - orgCost);
                            //										detail.FT.Pay_Cost = orgPayCost - neusoft.neNeusoft.HISFC.Components.Public.String.FormatNumber(orgPayCost/tempTotCost * orgPayCost, 2);
                            //										detail.FT.Pub_Cost = orgPubCost - (newCost - orgCost) - detail.FT.Pay_Cost;
                            //
                            //										invoiceTemp.FT.TotCost = invoiceTemp.FT.TotCost - (newCost - orgCost);
                            //										invoiceTemp.FT.Pay_Cost = invoiceTemp.FT.Pay_Cost - neusoft.neNeusoft.HISFC.Components.Public.String.FormatNumber(orgPayCost/tempTotCost * orgPayCost, 2);
                            //										invoiceTemp.FT.Pub_Cost = invoiceTemp.FT.Pub_Cost - (newCost - orgCost) + detail.FT.Pay_Cost;
                            //										invoiceTemp.FT.OwnCost = 0;
                            //									}
                            //								}
                            #endregion

                       
            return true;
        }

        private void tbCancel_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.isConfirm = false;
                this.FindForm().Close();
            }
            catch { }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                try
                {
                    this.isConfirm = false;
                    this.FindForm().Close();
                }
                catch { };
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion
    }
}
