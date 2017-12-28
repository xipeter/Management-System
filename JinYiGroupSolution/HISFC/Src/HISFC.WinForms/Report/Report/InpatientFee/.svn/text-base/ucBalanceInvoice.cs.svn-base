using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Registration ;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucBalanceInvoice : UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy
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
        public Collection<Label> lblPrint;
        /// <summary>
        /// 预览用的标签集合
        /// </summary>
        public Collection<Label> lblPreview;

        #endregion

        protected Neusoft.HISFC.Models.Base.EBlanceType MidBalanceFlag;

        //中途结算标记

        //protected bool MidBalanceFlag;
        ///// <summary>
        ///// 中途结算标记

        ///// </summary>
        //public bool IsMidwayBalance
        //{
        //    get
        //    {
        //        return MidBalanceFlag;
        //    }
        //    set
        //    {
        //        MidBalanceFlag = value;
        //    }
        //}

       
        


        /// <summary>
        /// 打印控件赋值
        /// </summary>
        /// <param name="Pinfo"></param>
        /// <param name="Pinfo"></param>
        /// <param name="al">balancelist数据</param>
        /// <param name="IsPreview">是否打印其余可显示部分</param>
        /// <returns></returns>
        protected int SetPrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
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
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList det in alBalanceList)
            {
                alBalanceListClone.Add(det.Clone());
            }
            #endregion

            Control c;
            
            if (this.InvoiceType  == "ZY01")
            {
                c = new ucDianLiZY01();

                this.Controls.Add(c);
                this.Size = c.Size;
                this.InitReceipt();
                SetZY01PrintValue(patientInfo,
                       balanceHead,
                       alBalanceListClone,
                       IsPreview);
            }
            else if (this.InvoiceType == "ZY02")
            {
                c = new ucDianLiZY02();
                this.Controls.Add(c);
                this.Size = c.Size;
                this.InitReceipt();
                SetZY02PrintValue(patientInfo,
                       balanceHead,
                       alBalanceListClone,
                       IsPreview);
            }
            else if (this.InvoiceType == "ZY03")
            {
                c = new ucDianLiZY01();
                this.Controls.Add(c);
                this.Size = c.Size;
                this.InitReceipt();
                SetZY03PrintValue(patientInfo,
                       balanceHead,
                       alBalanceListClone,
                       IsPreview);
            }
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
        /// <param name="Pinfo"></param>
        /// <param name="Pinfo"></param>
        /// <param name="al">balancelist数据</param>
        /// <param name="IsPreview">是否打印其余可显示部分</param>
        /// <returns></returns>
        protected int SetZY02PrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            #region 设置自费发票打印内容
            ucDianLiZY02 ucReceipt = (ucDianLiZY02)this.Controls[0];

            #region 医疗机构
            ucReceipt.lblYiLiaoJiGou.Text = "辽宁电力中心医院";
            #endregion

            //基本信息
            //病案号
            ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;
            //结算日期
            ucReceipt.lblOperDate.Text = balanceHead.BalanceOper.OperTime.ToShortDateString();
            //姓名
            ucReceipt.lblName.Text = patientInfo.Name;

            //住院日期
            ucReceipt.lblInTime.Text = patientInfo.PVisit.InTime.ToShortDateString();
            ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - patientInfo.PVisit.InTime.Ticks).Days.ToString();
            ////科室
            //ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //结算员
            ucReceipt.lblOperName.Text = balanceHead.BalanceOper.ID;

            ////操作员
            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            #region 医保信息
            decimal GeRenCost = decimal.Zero;
            decimal TongChouCost = decimal.Zero;
            decimal XianJinCost = decimal.Zero;
            decimal GongWuYuanCost = decimal.Zero;
            decimal DaECost = decimal.Zero;
            //个人账户支付
            GeRenCost = patientInfo.SIMainInfo.PayCost;
            if (GeRenCost > 0)
            {
                ucReceipt.lblGeRenCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GeRenCost, 2);
            }
            //统筹基金支付
            TongChouCost = patientInfo.SIMainInfo.PubCost - patientInfo.SIMainInfo.OverCost - patientInfo.SIMainInfo.OfficalCost;
            if (TongChouCost > 0)
            {
                ucReceipt.lblTongChouCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(TongChouCost, 2);
            }
            //现金支付
            XianJinCost = patientInfo.SIMainInfo.OwnCost;
            if (XianJinCost > 0)
            {
                ucReceipt.lblXianJinCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(XianJinCost, 2);
            }
            //公务员补助
            //GongWuYuanCost = patientInfo.SIMainInfo.OfficalCost;
            //if (GongWuYuanCost > 0)
            //{
            //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GongWuYuanCost, 2);
            //}
            //大额补助
            DaECost = patientInfo.SIMainInfo.OverCost;
            if (DaECost > 0)
            {
                ucReceipt.lblDaECost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DaECost, 2);
            }
            #endregion
            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[23]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};


            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                }
            }
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                Label l = Function.GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), ucReceipt);
                if (l != null)
                {
                    if (FeeInfo[FeeInfoIndex] > 0)
                    {
                        l.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2);
                    }
                }
                FeeInfoIndex++;
            }
            //预收
            ucReceipt.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost, 2);
            //补收
            ucReceipt.lblPriSupply.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            //退款
            ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2);

            ucReceipt.lblReceiptNo.Text = balanceHead.Invoice.BeginNO;
            if (balanceHead.FT.TotCost > 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额

            ucReceipt.lblDaXie.Text = Function.GetUpperCashByNumber(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));

            #endregion
            #endregion

            return 0;
        } /// <summary>
        /// 打印控件赋值
        /// </summary>
        /// <param name="Pinfo"></param>
        /// <param name="Pinfo"></param>
        /// <param name="al">balancelist数据</param>
        /// <param name="IsPreview">是否打印其余可显示部分</param>
        /// <returns></returns>
        protected int SetZY03PrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            #region 设置自费发票打印内容
            ucDianLiZY03 ucReceipt = (ucDianLiZY03)this.Controls[0];

            #region 医疗机构
            ucReceipt.lblYiLiaoJiGou.Text =  "辽宁电力中心医院";
            #endregion

            //基本信息
            //病案号
            ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;
            //结算日期
            ucReceipt.lblOperDate.Text = balanceHead.BalanceOper.OperTime.ToShortDateString();
            //姓名
            ucReceipt.lblName.Text = patientInfo.Name;
            //住院日期
            ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToShortDateString();
            ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
            ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            ////科室
            //ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //结算员
            ucReceipt.lblOperName.Text = balanceHead.BalanceOper.ID;

            ////操作员
            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            #region 医保信息
            decimal GeRenCost = decimal.Zero;
            decimal TongChouCost = decimal.Zero;
            decimal XianJinCost = decimal.Zero;
            decimal GongWuYuanCost = decimal.Zero;
            decimal DaECost = decimal.Zero;
            ////个人账户支付
            //GeRenCost = patientInfo.SIMainInfo.PayCost;
            //if (GeRenCost > 0)
            //{
            //    ucReceipt.lblGeRenCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GeRenCost, 2);
            //}
            //统筹基金支付
            TongChouCost = patientInfo.SIMainInfo.PubCost - patientInfo.SIMainInfo.OverCost - patientInfo.SIMainInfo.OfficalCost;
            if (TongChouCost > 0)
            {
                ucReceipt.lblTongChouCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(TongChouCost, 2);
            }
            //现金支付
            XianJinCost = patientInfo.SIMainInfo.OwnCost;
            if (XianJinCost > 0)
            {
                ucReceipt.lblXianJinCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(XianJinCost, 2);
            }
            ////公务员补助
            //GongWuYuanCost = patientInfo.SIMainInfo.OfficalCost;
            //if (GongWuYuanCost > 0)
            //{
            //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GongWuYuanCost, 2);
            //}
            ////大额补助
            //DaECost = patientInfo.SIMainInfo.OverCost;
            //if (DaECost > 0)
            //{
            //    ucReceipt.lblDaECost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DaECost, 2);
            //}
            #endregion
            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[21]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};


            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                }
            }
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                Label l = Function.GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), ucReceipt);
                if (l != null)
                {
                    if (FeeInfo[FeeInfoIndex] > 0)
                    {
                        l.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2);
                    }
                }
                FeeInfoIndex++;
            }
            //预收
            ucReceipt.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost, 2);
            //补收
            ucReceipt.lblPriSupply.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            //退款
            ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2);

            ucReceipt.lblReceiptNo.Text = balanceHead.Invoice.BeginNO;
            if (balanceHead.FT.TotCost > 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额

            ucReceipt.lblDaXie.Text = Function.GetUpperCashByNumber(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));

            #endregion
            #endregion

            return 0;
        }
       

        /// <summary>
        /// 打印控件赋值
        /// </summary>
        /// <param name="Pinfo"></param>
        /// <param name="Pinfo"></param>
        /// <param name="al">balancelist数据</param>
        /// <param name="IsPreview">是否打印其余可显示部分</param>
        /// <returns></returns>
        protected int SetZY01PrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            #region 设置自费发票打印内容
            ucDianLiZY01 ucReceipt = (ucDianLiZY01)this.Controls[0];
            //#region 医疗机构
            //ucReceipt.lblYiLiaoJiGou.Text = "辽宁电力中心医院";
            //#endregion
            //基本信息
            ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;  //病案号
            ucReceipt.lblPrintYear.Text = balanceHead.BalanceOper.OperTime.Year.ToString(); //年
            ucReceipt.lblPrintMonth.Text = balanceHead.BalanceOper.OperTime.Month.ToString(); //月
            ucReceipt.lblPrintDay.Text = balanceHead.BalanceOper.OperTime.Day.ToString(); //日
            //ucReceipt.lblName.Text = patientInfo.Name;//姓名
            //住院日期
            ucReceipt.lblInTime.Text = patientInfo.PVisit.InTime.ToShortDateString();
            ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - patientInfo.PVisit.InTime.Ticks).Days.ToString();
            //科室
            //ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //操作员
            ucReceipt.lblOperName.Text = balanceHead.BalanceOper.ID;

            //结算员
            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[18]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};


            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                }
            }
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                Label l = Function.GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), ucReceipt);
                if (l != null)
                {
                    if (FeeInfo[FeeInfoIndex]>0)
                    {
                        l.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2); 
                    }
                }
                FeeInfoIndex++;
            }
            //预收
            if (balanceHead.FT.PrepayCost>0)
            {
                ucReceipt.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost, 2); 
            }
            //实收
            if (balanceHead.FT.SupplyCost>0)
            {
                ucReceipt.lblPriSupply.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.OwnCost, 2); 
            }
            //退款
            if (balanceHead.FT.ReturnCost>0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2); 
            }
            //小写总金额
            if (balanceHead.FT.TotCost > 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost , 2);
                ucReceipt.lblSum.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额
            ucReceipt.lblDaXie.Text = Function.GetUpperCashByNumber(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));
            #endregion
            #endregion
            return 0;
        }

        #region IBalanceInvoicePrint 成员

        public int Clear()
        {
            SetLableText(null, lblPrint);
            return 1;
        }
        public int PrintPreview()
        {

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(0, 0, this);
            return 1;
        }

        public int Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            //设置纸张大小
            //neusoft.Common.Class.Function.GetPageSize("bill", ref Print);

            print.PrintPage(0, 0, this);

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
        //{1FADBEC0-514A-46f0-9A4B-037F5B65892A}
        public int SetValueForPreview(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList,ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, true);
        }
        //{1FADBEC0-514A-46f0-9A4B-037F5B65892A}
        public int SetValueForPrint(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList, ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, false);
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbTransaction Trans
        {
            set { this.trans = value; }
            get { return this.trans ; }
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
            if (l == null || l.Count == 0) return;
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
            foreach (Control c in this.Controls[0].Controls)
            {
                if (c.GetType().FullName == "System.Windows.Forms.Label")
                {
                    Label l = (Label)c;
                    if (l.Tag != null)
                    {
                        if (l.Tag.ToString() == "print")
                        {
                            l.Text = "";
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
            if (l == null || l.Count == 0) return;
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

        private string _invoiceType;

        public string InvoiceType
        {
            get { return _invoiceType; }
        }

        private Neusoft.HISFC.Models.RADT.PatientInfo _patientInfo;
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set { _patientInfo = value;
            if (_patientInfo.Pact.PayKind.ID=="01")
            {
                _invoiceType = "ZY01";
            }
            else if (_patientInfo.Pact.PayKind.ID=="02")
            {
                _invoiceType = "ZY02";
                if (_patientInfo.PVisit.MedicalType.ID=="42" || 
                    _patientInfo.PVisit.MedicalType.ID=="44" ||
                    _patientInfo.PVisit.MedicalType.ID=="45" )
                {
                    _invoiceType = "ZY03";
                }
            }
            }
        }

        #endregion

        #region IBalanceInvoicePrintmy 成员
        /// <summary>
        /// 结算类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.EBlanceType IsMidwayBalance
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

        #endregion
    }
}