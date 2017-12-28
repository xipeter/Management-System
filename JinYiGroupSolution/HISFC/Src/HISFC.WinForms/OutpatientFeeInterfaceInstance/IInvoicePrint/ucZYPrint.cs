using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Object.Registration;

namespace FuXin.XinQiu.ErYuan.ReceiptPrint
{
    /// <summary>
    /// 住院发票打印
    /// </summary>
    public partial class ucBalanceInvoice : UserControl, Neusoft.HISFC.Integrate.FeeInterface.IBalanceInvoicePrintmy
    {
        /// <summary>
        ///  构造函数


        /// </summary>
        public ucBalanceInvoice()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 数据库连接


        /// </summary>
        private System.Data.IDbTransaction trans;
        /// <summary>
        /// 打印用的标签集合
        /// </summary>
        public Collection<Label> lblPrint = null;
        /// <summary>
        /// 预览用的标签集合
        /// </summary>
        public Collection<Label> lblPreview = null;

        #endregion
        /// <summary>
        /// 中途结算标记


        /// </summary>
        protected bool MidBalanceFlag;
        /// <summary>
        /// 中途结算标记


        /// </summary>
        public bool IsMidwayBalance
        {
            get
            {
                return MidBalanceFlag;
            }
            set
            {
                MidBalanceFlag = value;
            }
        }



        Control c;

        /// <summary>
        /// 打印控件赋值


        /// </summary>
        /// <param name="patientInfo">患者实体</param>
        /// <param name="balanceHead">发票</param>
        /// <param name="alBalanceList">发票明细</param>
        /// <param name="IsPreview">是否预览</param>
        /// <returns></returns>
        protected int SetPrintValue(
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            this.Controls.Clear();
            //如果费用明细为空，则返回
            if (alBalanceList.Count <= 0)
            {
                return -1;
            }

            #region 克隆一个费用明细信息列表，因为后面操作需要对列表元素有删除操作．
            ArrayList alBalanceListClone = new ArrayList();
            foreach (Neusoft.HISFC.Object.Fee.Inpatient.BalanceList det in alBalanceList)
            {
                alBalanceListClone.Add(det.Clone());
            }
            #endregion
            //if (this.InvoiceType == "ZY02")
            //{
            //    c = new ucZYZF();
            //    while (c.Controls.Count > 0)
            //    {
            //        this.Controls.Add(c.Controls[0]);
            //    }
            //    //this.Controls.Add(c);
            //    this.Size = c.Size;
            //    this.InitReceipt();
            //    SetZYZFPrintValue(patientInfo,
            //           balanceHead,
            //           alBalanceListClone,
            //           IsPreview);
            //}
            //else if (this.InvoiceType == "ZY01")
            //{
            c = new ucZYFP();
            while (c.Controls.Count > 0)
            {
                this.Controls.Add(c.Controls[0]);
            }
            //this.Controls.Add(c);
            this.Size = c.Size;
            this.InitReceipt();
            SetZYFPPrintValue(patientInfo,
                   balanceHead,
                   alBalanceListClone,
                   IsPreview);
            //}

            //控制根据打印和预览显示选项
            if (IsPreview)
            {
                SetToPreviewMode();
            }
            else
            {
                SetToPrintMode();
            }
            return 0;
        }

        /// <summary>
        /// 打印控件赋值


        /// </summary>
        /// <param name="patientInfo">患者实体</param>
        /// <param name="balanceHead">发票</param>
        /// <param name="alBalanceList">发票明细</param>
        /// <param name="IsPreview">是否预览</param>
        /// <returns></returns>
        protected int SetZYFPPrintValue(
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            //#region 设置自费发票打印内容
            //ucZYYB ucReceipt = (ucZYYB)c;

            //#region 医疗机构
            //ucReceipt.lblYiLiaoJiGou.Text = "鞍山市第三医院";
            //#endregion
            ////电脑编号
            //ucReceipt.lblSSN.Text = patientInfo.SSN;
            ////病房
            //ucReceipt.lblNurseCellName.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            ////基本信息
            ////病案号


            //ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;
            ////结算日期
            //ucReceipt.lblOperDate.Text = balanceHead.BalanceOper.OperTime.ToShortDateString();
            ////姓名
            //ucReceipt.lblName.Text = patientInfo.Name;
            ////住院日期
            //ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToShortDateString();
            ////住院日期
            //ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToShortDateString();
            //if (MidBalanceFlag)
            //{
            //    ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            //else
            //{
            //    ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            //////科室
            ////ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            ////结算员


            //ucReceipt.lblOperName.Text = balanceHead.BalanceOper.ID;

            //////操作员


            ////ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            //#region 医保信息
            //decimal GeRenCost = decimal.Zero;
            //decimal TongChouCost = decimal.Zero;
            //decimal XianJinCost = decimal.Zero;
            //decimal GongWuYuanCost = decimal.Zero;
            //decimal DaECost = decimal.Zero;
            ////个人账户支付
            //GeRenCost = patientInfo.SIMainInfo.PayCost;
            //if (GeRenCost != 0)
            //{
            //    ucReceipt.lblGeRenCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(GeRenCost, 2);
            //}
            ////统筹基金支付
            //TongChouCost = patientInfo.SIMainInfo.PubCost;
            //if (TongChouCost != 0)
            //{
            //    ucReceipt.lblTongChouCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(TongChouCost, 2);
            //}
            ////现金支付
            //XianJinCost = patientInfo.SIMainInfo.OwnCost;
            //if (XianJinCost != 0)
            //{
            //    ucReceipt.lblXianJinCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(XianJinCost, 2);
            //}
            ////公务员补助
            //GongWuYuanCost = patientInfo.SIMainInfo.OfficalCost;
            //if (GongWuYuanCost > 0)
            //{
            //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(GongWuYuanCost, 2);
            //}
            ////大额补助
            //DaECost = patientInfo.SIMainInfo.OverTakeOwnCost;
            //if (DaECost != 0)
            //{
            //    ucReceipt.lblDaECost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(DaECost, 2);
            //}
            //#endregion
            ////票面信息
            //decimal[] FeeInfo =
            //    //---------------------1-----------2------------3------------4-------------5-----------------
            //    new decimal[23]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
            //                    decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
            //                    decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
            //                    decimal.Zero,decimal.Zero,decimal.Zero,
            //                    decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};


            //for (int i = 0; i < alBalanceList.Count; i++)
            //{
            //    Neusoft.HISFC.Object.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Object.Fee.Inpatient.BalanceList();
            //    detail = (Neusoft.HISFC.Object.Fee.Inpatient.BalanceList)alBalanceList[i];
            //    if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
            //    {
            //        FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
            //    }
            //}
            //int FeeInfoIndex = 0;
            //foreach (decimal d in FeeInfo)
            //{
            //    Label l = Function.GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), lblPrint);
            //    if (l != null)
            //    {
            //        if (FeeInfo[FeeInfoIndex] > 0)
            //        {
            //            l.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2);
            //        }
            //    }
            //    FeeInfoIndex++;
            //}
            ////预收
            //if (balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost != 0)
            //{
            //    ucReceipt.lblPriPrepay.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost, 2);
            //}
            ////补收
            //if (balanceHead.FT.SupplyCost != 0)
            //{
            //    ucReceipt.lblPriSupply.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            //}
            ////退款

            //if (balanceHead.FT.ReturnCost != 0)
            //{
            //    ucReceipt.lblPriReturn.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2);
            //}
            ////发票号

            //ucReceipt.lblReceiptNo.Text = balanceHead.Invoice.ID;
            ////总金额

            //if (balanceHead.FT.TotCost != 0)
            //{
            //    ucReceipt.lblTotCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            //}
            //#region 大写总金额

            //if (balanceHead.FT.TotCost != 0)
            //{
            //    ucReceipt.lblDaXie.Text = Function.GetUpperCashByNumber(Neusoft.NFC.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));
            //}
            //#endregion
            //#endregion

            //return 0;

            #region 设置发票打印内容
            ucZYFP ucReceipt = (ucZYFP)c;
            //#region 医疗机构
            ucReceipt.lblYiLiaoJiGou.Text = "阜新市新邱区第二人民医院";
            //#endregion
            //结算日期
            ucReceipt.lblOperDate.Text = balanceHead.BalanceOper.OperTime.ToShortDateString();
            //收据号

            ucReceipt.lblReceiptNo.Text = balanceHead.Invoice.ID;

            //患者基本信息

            ucReceipt.lblInPatientNO.Text = patientInfo.PID.PatientNO; //住院号

            ucReceipt.lblName.Text = patientInfo.Name;//姓名
            //科室
            ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //打印出来的字：发票号，元 ，￥：

            ucReceipt.lblInvoiceNo.Text = "发票号";
            ucReceipt.lblyuan.Text = "元";
            ucReceipt.lblY.Text = "￥";


            //费别
            //if ( patientInfo.Pact.PayKind.ID = "01" )
            //{
            //本来想写死，怕以后增加别的类别，直接写此类别
            ucReceipt.lblPayKind.Text = patientInfo.Pact.Name;
            //}
            //else 
            //{

            //}
            //住院日期
            ucReceipt.lblInTime.Text = patientInfo.PVisit.InTime.ToShortDateString();
            ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            //ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - patientInfo.PVisit.InTime.Ticks).Days.ToString();
            //家庭住址
            ucReceipt.lblHome.Text = patientInfo.AddressHome;
            //电脑编号
            ucReceipt.lblSSN.Text = patientInfo.SSN;
            //操作员


            ucReceipt.lblOperName.Text = balanceHead.BalanceOper.ID;
            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[14]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};


            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Object.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Object.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Object.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                }
            }
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                Label l = Function.GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), lblPrint);
                if (l != null)
                {
                    if (FeeInfo[FeeInfoIndex] > 0)
                    {
                        l.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2).PadLeft(8);
                    }
                }
                FeeInfoIndex++;
            }
            //预收
            if (balanceHead.FT.PrepayCost > 0)
            {
                ucReceipt.lblPriPrepay.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost, 2).PadLeft(8);
            }        
            //应交款

            if (balanceHead.FT.SupplyCost > 0)
            {
                ucReceipt.lblPriSupply.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2).PadLeft(8);
            }
            //退款


            if (balanceHead.FT.ReturnCost > 0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2).PadLeft(8);
            }

            //小写总金额


            if (balanceHead.FT.TotCost > 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
                //ucReceipt.lblSum.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额


            ucReceipt.lblDaXie.Text = Function.GetUpperCashByNumber(Neusoft.NFC.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));
            #endregion
            //医保里边的金额

            if (patientInfo.SIMainInfo.PayCost != 0)
            {
                ucReceipt.lblPayCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.PayCost, 2).PadLeft(8);
            }
            if (patientInfo.SIMainInfo.OwnCost != 0)
            {
                ucReceipt.lblOwnCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.OwnCost, 2).PadLeft(8);
            }
            if (patientInfo.SIMainInfo.PubCost != 0)
            {
                ucReceipt.lblPubCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.PubCost, 2).PadLeft(8);
            }
            if (patientInfo.SIMainInfo.OfficalCost != 0)
            {
                ucReceipt.lblGwyCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.OfficalCost, 2).PadLeft(8);
            }
            if (patientInfo.SIMainInfo.OverCost  != 0)
            {
                ucReceipt.lblDebzCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.OverCost, 2).PadLeft(8);
            }
            #endregion
            return 0;
        }

       
        #region IBalanceInvoicePrint 成员

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            SetLableText(null, lblPrint);
            return 1;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <returns></returns>
        public int PrintPreview()
        {
            try
            {
                Neusoft.NFC.Interface.Classes.Print print = null;
                Neusoft.HISFC.Object.Base.PageSize ps = null;
                try
                {
                    print = new Neusoft.NFC.Interface.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }
                string paperName = string.Empty;
                //if (this.InvoiceType == "ZY02")
                //{
                //    paperName = "ZYZF";

                //}
                //else if (this.InvoiceType == "ZY01")
                //{
                paperName = "ZYFP";
                //}
                ps = new Neusoft.HISFC.Object.Base.PageSize(paperName, 0, 0);
                ps.Top = 0;
                ps.Left = 0;
                print.SetPageSize(ps);
                print.PrintPreview(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            try
            {
                Neusoft.NFC.Interface.Classes.Print print = null;
                Neusoft.HISFC.Object.Base.PageSize ps = null;
                try
                {
                    print = new Neusoft.NFC.Interface.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }
                string paperName = string.Empty;
                //if (this.InvoiceType == "ZY02")
                //{
                paperName = "ZYFP";

                //}
                //else if (this.InvoiceType == "ZY01")
                //{
                //    paperName = "ZYYB";
                //}
                ps = new Neusoft.HISFC.Object.Base.PageSize(paperName, 0, 0);
                ps.Top = 0;
                ps.Left = 0;
                print.SetPageSize(ps);
                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;
        }

        /// <summary>
        /// 设置数据库连接


        /// </summary>
        /// <param name="trans"></param>
        public void SetTrans(IDbTransaction trans)
        {
            this.trans = trans;
        }
        /// <summary>
        /// 打印控件赋值


        /// </summary>
        /// <param name="patientInfo">患者实体</param>
        /// <param name="balanceHead">发票</param>
        /// <param name="alBalanceList">发票明细</param>
        /// <returns></returns>
        public int SetValueForPreview(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList,ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, true);
        }
        /// <summary>
        /// 打印控件赋值


        /// </summary>
        /// <param name="patientInfo">患者实体</param>
        /// <param name="balanceInfo">发票</param>
        /// <param name="alBalanceList">发票明细</param>
        /// <returns></returns>
        public int SetValueForPrint(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList, ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, false);
        }

        /// <summary>
        /// 数据库连接


        /// </summary>
        public IDbTransaction Trans
        {
            set { this.trans = value; }
            get { return this.trans; }
        }

        /// <summary>
        /// 设置为打印模式


        /// </summary>
        public void SetToPrintMode()
        {
            //将预览项设为不可见


            SetLableVisible(false, lblPreview);
            foreach (Label lbl in lblPrint)
            {
                lbl.BorderStyle = BorderStyle.None;
                lbl.BackColor = SystemColors.ControlLightLight;
            }
        }

        /// <summary>
        /// 设置为预览模式


        /// </summary>
        public void SetToPreviewMode()
        {
            //将预览项设为可见
            SetLableVisible(true, lblPreview);
            foreach (Label lbl in lblPrint)
            {
                lbl.BorderStyle = BorderStyle.None;
                lbl.BackColor = SystemColors.ControlLightLight;
            }
        }

        /// <summary>
        /// 设置标签集合的可见性


        /// </summary>
        /// <param name="v">是否可见</param>
        /// <param name="l">标签集合</param>
        private void SetLableVisible(bool v, Collection<Label> l)
        {
            foreach (Label lbl in l)
            {
                lbl.Visible = v;
            }
        }

        /// <summary>
        /// 初始化收据


        /// </summary>
        /// <remarks>
        /// 把打印项和预览项根据ｔａｇ标签的值区分开
        /// </remarks>
        private void InitReceipt()
        {
            lblPreview = new Collection<Label>();
            lblPrint = new Collection<Label>();

            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName == "System.Windows.Forms.Label" ||
                    c.GetType().FullName == "Neusoft.NFC.Interface.Controls.NeuLabel")
                {
                    Label l = (Label)c;
                    if (l.Tag != null)
                    {
                        if (l.Tag.ToString() == "print")
                        {
                            #region 将代印字的打印项值清空



                            if (!string.IsNullOrEmpty(l.Text) && l.Text == "印")
                            {
                                l.Text = "";
                            }
                            #endregion
                            lblPrint.Add(l);
                        }
                        else
                        {
                            lblPreview.Add(l);
                        }
                    }
                    else
                    {
                        lblPreview.Add(l);
                    }
                }
            }
        }

        /// <summary>
        /// 设置打印集合的值


        /// </summary>
        /// <param name="t">值数组</param>
        /// <param name="l">标签集合</param>
        private void SetLableText(string[] t, Collection<Label> l)
        {
            foreach (Label lbl in l)
            {
                lbl.Text = "";
            }
            if (t != null)
            {
                if (t.Length <= l.Count)
                {
                    int i = 0;
                    foreach (string s in t)
                    {
                        l[i].Text = s;
                        i++;
                    }
                }
                else
                {
                    if (t.Length > l.Count)
                    {
                        int i = 0;
                        foreach (Label lbl in l)
                        {
                            lbl.Text = t[i];
                            i++;
                        }
                    }
                }
            }
        }
        #endregion

        #region IBalanceInvoicePrint 成员

        private string invoiceType;

        /// <summary>
        /// 发票类别
        /// </summary>
        public string InvoiceType
        {
            get { return invoiceType; }
        }

        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo;

        /// <summary>
        /// 患者实体


        /// </summary>
        public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
        {
            set
            {
                patientInfo = value;
                //if (patientInfo.Pact.PayKind.ID == "01" || patientInfo.Pact.PayKind.ID == "03")
                //{
                //    //自费//公费
                //    invoiceType = "ZY02";
                //}
                //else if (patientInfo.Pact.PayKind.ID == "02")
                //{
                //    //市医保//省医保

                invoiceType = "ZY01";
                //}
            }
        }
        #endregion
    }
}