using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.OutpatientFee.InvoicePrint
{
    public partial class ucSplitUnit : UserControl
    {
        public ucSplitUnit()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private DateTime dtInvoiceDate = DateTime.MinValue;//发票时间
        private Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice = new Neusoft.HISFC.Models.Fee.Outpatient.Balance();//发票实体
        private ArrayList invoiceDetails = new ArrayList();//发票明细实体
        private int seqNO = 0;//第几张发票
        private bool isFocus = false; //是否获得焦点
        private bool isLast = false;//是否最后一张发票，如果是不可修改金额
        public delegate bool ChangeCost(string feeStat, decimal orgCost, decimal newCost, ref Neusoft.HISFC.Models.Base.FT ft, 
            ref decimal CTFee, ref decimal MRIFee, ref decimal SXFee, ref decimal SYFee);
        public event ChangeCost CostChanged;
        public delegate void ChangeFocus(int seq);
        public event ChangeFocus ModifyFinished;

        private string STATCODEJC = "";//检查费
        private string STATCODEZL = "";//治疗费

        #endregion

        #region 属性
        
        /// <summary>
        /// 是否最后一张发票，如果是不可修改金额
        /// </summary>
        public bool IsLast
        {
            set
            {
                isLast = value;
                if (isLast)
                {
                    this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
                }
                else
                {
                    this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
                }
            }
            get
            {
                return isLast;
            }
        }

        /// <summary>
        /// 发票号
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
                this.lbInvoiceNo.Text = invoice.Invoice.ID;
                if (this.invoice != null) 
                {
                    this.invoice.PrintTime = this.dtpInvoiceTime.Value;
                }
                this.lbCost.Text = invoice.FT.TotCost.ToString() + " 大写: " + Neusoft.FrameWork.Public.String.LowerMoneyToUpper(invoice.FT.TotCost);

            }
        }

        /// <summary>
        /// 发票时间
        /// </summary>
        public DateTime InvoiceDate
        {
            get
            {
                dtInvoiceDate = this.dtpInvoiceTime.Value.Date;
                return dtInvoiceDate;
            }
            set
            {
                dtInvoiceDate = value;
                this.dtpInvoiceTime.Value = dtInvoiceDate;
                //this.invoice.PrintTime = this.dtpInvoiceTime.Value;
            }
        }

        /// <summary>
        /// 发票明细实体
        /// </summary>
        public ArrayList InvoiceDetails
        {
            get
            {
                invoiceDetails = new ArrayList();
                Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = null;
                for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                {
                    detail = this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.Outpatient.BalanceList;
                    if (detail.BalanceBase.FT.TotCost >= 0)
                    {
                        invoiceDetails.Add(detail);
                    }
                }
                return invoiceDetails;
            }
            set
            {
                invoiceDetails = value;
                this.fpSpread1_Sheet1.RowCount = invoiceDetails.Count;
                Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = null;
                for (int i = 0; i < invoiceDetails.Count; i++)
                {
                    detail = invoiceDetails[i] as Neusoft.HISFC.Models.Fee.Outpatient.BalanceList;
                    this.fpSpread1_Sheet1.Cells[i, 0].Text = detail.FeeCodeStat.Name;
                    this.fpSpread1_Sheet1.Cells[i, 1].Text = detail.BalanceBase.FT.TotCost.ToString();
                    this.fpSpread1_Sheet1.Rows[i].Tag = detail;
                }
            }
        }

        /// <summary>
        /// 第几张发票
        /// </summary>
        public int SeqNO
        {
            get
            {
                return seqNO;
            }
            set
            {
                seqNO = value;
            }
        }
        /// <summary>
        /// 控件是否获得焦点
        /// </summary>
        public bool IsFocus
        {
            set
            {
                isFocus = value;
                if (isFocus)
                {
                    if (this.fpSpread1_Sheet1.RowCount <= 0)
                    {
                        return;
                    }
                    this.fpSpread1_Sheet1.SetActiveCell(0, 1, false);
                }
            }
        }

        #endregion

        #region 函数

        /// <summary>
        /// 初始化farpoint,屏蔽一些热键
        /// </summary>
        private void InitFp()
        {
            InputMap im;
            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        #endregion

        #region 事件

        private void ucSplitUnit_Load(object sender, System.EventArgs e)
        {
            try
            {
                InitFp();

                bool isCanModifyInvoiceDate = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_MODIFY_INVOICE_DATE, true, false);
                
                this.dtpInvoiceTime.Enabled = isCanModifyInvoiceDate;
            }
            catch { }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (this.fpSpread1.ContainsFocus)
            {
                int currRow = this.fpSpread1_Sheet1.ActiveRowIndex;
                int rowCount = this.fpSpread1_Sheet1.RowCount;

                if (keyData == Keys.Enter)
                {
                    if (currRow < rowCount - 1)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(currRow + 1, 1, false);
                    }
                    if (currRow == rowCount - 1)
                    {
                        ModifyFinished(seqNO);
                    }
                    Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detailTemp =
                        this.fpSpread1_Sheet1.Rows[currRow].Tag as Neusoft.HISFC.Models.Fee.Outpatient.BalanceList;
                    decimal orgCost = detailTemp.BalanceBase.FT.TotCost;
                    decimal newCost = 0;
                    try
                    {
                        newCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[currRow, 1].Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("金额输入不合法!" + ex.Message);
                        this.fpSpread1_Sheet1.SetActiveCell(currRow, 1, false);
                        return false;
                    }
                    if (newCost < 0)
                    {
                        MessageBox.Show("金额不能修改成负数!");
                        this.fpSpread1_Sheet1.SetActiveCell(currRow, 1, false);
                        return false;
                    }
                    decimal CTFee = 0, MRIFee = 0, SXFee = 0, SYFee = 0;
                    if (detailTemp.FeeCodeStat.ID == this.STATCODEJC)//检查
                    {
                        if ((newCost) < detailTemp.CTFee + detailTemp.MRIFee)
                        {
                            decimal tempCost = 0;
                            decimal errCost = detailTemp.CTFee + detailTemp.MRIFee - newCost;
                            tempCost = errCost - detailTemp.CTFee;
                            if (tempCost <= 0)
                            {
                                CTFee = tempCost;
                                detailTemp.CTFee = detailTemp.CTFee - CTFee;
                                MRIFee = 0;
                            }
                            else
                            {
                                CTFee = detailTemp.CTFee;
                                detailTemp.CTFee = 0;
                                MRIFee = tempCost - detailTemp.CTFee;
                                detailTemp.MRIFee = detailTemp.MRIFee - MRIFee;
                            }
                        }
                    }
                    if (detailTemp.FeeCodeStat.ID == this.STATCODEZL)//治疗
                    {
                        if ((newCost) < detailTemp.SYFee + detailTemp.SXFee)
                        {
                            decimal tempCost = 0;
                            decimal errCost = detailTemp.SXFee + detailTemp.SYFee - newCost;
                            tempCost = errCost - detailTemp.SXFee;
                            if (tempCost <= 0)
                            {
                                SXFee = tempCost;
                                detailTemp.SXFee = detailTemp.SXFee - SXFee;
                                SYFee = 0;
                            }
                            else
                            {
                                SXFee = detailTemp.SYFee;
                                detailTemp.SXFee = 0;
                                SYFee = tempCost - detailTemp.SYFee;
                                detailTemp.SYFee = detailTemp.SYFee - SYFee;
                            }
                        }
                    }

                    Neusoft.HISFC.Models.Base.FT ft = new Neusoft.HISFC.Models.Base.FT();

                    ft.OwnCost = detailTemp.BalanceBase.FT.OwnCost;
                    ft.PayCost = detailTemp.BalanceBase.FT.PayCost;
                    ft.PubCost = detailTemp.BalanceBase.FT.PubCost;

                    bool returnValue = this.CostChanged(detailTemp.FeeCodeStat.ID, orgCost, newCost, ref ft, ref CTFee, ref MRIFee, ref SXFee, ref SYFee);
                    if (!returnValue)
                    {
                        this.fpSpread1_Sheet1.Cells[currRow, 1].Text = orgCost.ToString();
                        this.fpSpread1_Sheet1.SetActiveCell(currRow, 1, false);

                        return false;
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[currRow, 1].Text = newCost.ToString();
                        detailTemp.BalanceBase.FT.TotCost = newCost;
                        detailTemp.BalanceBase.FT.OwnCost = newCost;
                        this.invoice.FT.TotCost = this.invoice.FT.TotCost + (newCost - orgCost);
                        this.invoice.FT.OwnCost = this.invoice.FT.OwnCost + (newCost - orgCost);
                        this.lbCost.Text = invoice.FT.TotCost.ToString() + " 大写: " + Neusoft.FrameWork.Public.String.LowerMoneyToUpper(invoice.FT.TotCost);
                        if (detailTemp.FeeCodeStat.ID == this.STATCODEJC)//检查
                        {
                            detailTemp.CTFee += CTFee;
                            detailTemp.MRIFee += MRIFee;
                        }
                        if (detailTemp.FeeCodeStat.ID == this.STATCODEZL)//检查
                        {
                            detailTemp.SXFee += SXFee;
                            detailTemp.SYFee += SYFee;
                        }

                    }
                }
                if (keyData == Keys.Down)
                {

                    this.fpSpread1_Sheet1.ActiveRowIndex = currRow + 1;
                    this.fpSpread1_Sheet1.SetActiveCell(currRow + 1, 1);

                }
                if (keyData == Keys.Up)
                {
                    if (currRow > 0)
                    {
                        this.fpSpread1_Sheet1.ActiveRowIndex = currRow - 1;
                        this.fpSpread1_Sheet1.SetActiveCell(currRow - 1, 1);
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void dtpInvoiceTime_ValueChanged(object sender, System.EventArgs e)
        {
            this.invoice.PrintTime = this.dtpInvoiceTime.Value;
        }

        #endregion

    }
}
