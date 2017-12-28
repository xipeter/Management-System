//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using System.Collections;

//namespace ReceiptPrint
//{
//    public partial class ucMZPrint : UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint
//    {
//        public ucMZPrint()
//        {
//            InitializeComponent();
//        }

//        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
//        #region 变量
//        /// <summary>
//        /// 分发票后的支付方式
//        /// </summary>
//        private string setPayModeType;
//        /// <summary>
//        /// 分发票后的支付方式
//        /// </summary>
//        private string splitinvoicepaymode;
//        /// <summary>
//        /// 设置是否为预览模式
//        /// </summary>
//        private bool isPreView = false;
//        /// <summary>
//        /// 数据库连接
//        /// </summary>
//        private System.Data.IDbTransaction trans;
//        #endregion

//        #region 函数
//        #region IInvoicePrint 成员

//        /// <summary>
//        /// 控件描述，最好填写。
//        /// </summary>
//        public string Description
//        {
//            get {
//                //{AF642C5F-85B8-46ea-9292-7929E54D8150}
//                string hospitalName = this.managerIntegrate.GetHospitalName();

//                return hospitalName;
//            }
//        }

//        /// <summary>
//        /// 设置是否为预览模式
//        /// </summary>
//        public bool IsPreView
//        {
//            set { this.isPreView = value; }
//        }
//        /// <summary>
//        /// 打印自身
//        /// </summary>
//        /// <returns>-1 失败 1 成功</returns>
//        public int Print()
//        {
//            try
//            {
//                Neusoft.FrameWork.WinForms.Classes.Print print = null;
//                try
//                {
//                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("初始化打印机失败!" + ex.Message);

//                    return -1;
//                }
//                string paperName=string.Empty ;
//                if (this.InvoiceType == "MZ05")
//                {
//                    paperName = "MZTK";

//                }
//                else if (this.InvoiceType == "MZ01")
//                {
//                    paperName = "MZXJ";
//                }

//                Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize(paperName, 0, 0);
//                ////纸张宽度
//                //ps.Width = this.Width;
//                ////纸张高度
//                //ps.Height = this.Height;
//                //上边距
//                ps.Top = 0;
//                //左边距
//                ps.Left = 0;               
//                print.SetPageSize(ps);
//                print.PrintPage(0, 0, this);
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return -1;
//            }

//            return 1;
//        }

//        /// <summary>
//        /// 打印其他内容
//        /// </summary>
//        /// <returns>-1 失败 1 成功</returns>
//        public int PrintOtherInfomation()
//        {
//            return 1;
//        }
//        /// <summary>
//        /// 分发票后的支付方式
//        /// </summary>
//        public string SetPayModeType
//        {
//            set { this.setPayModeType = value; }
//        }
//        /// <summary>
//        /// 设置是否为预览模式
//        /// </summary>
//        public void SetPreView(bool isPreView)
//        {
//            this.isPreView = isPreView;
//        }
//        /// <summary>
//        /// 设置打印其他内容
//        /// </summary>
//        /// <param name="regInfo">挂号信息</param>
//        /// <param name="Invoices">所有主发票信息</param>
//        /// <param name="invoiceDetails">所有发票明细信息</param>
//        /// <param name="feeDetails">所有费用信息</param>
//        /// <returns></returns>
//        public int SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, System.Collections.ArrayList Invoices, System.Collections.ArrayList invoiceDetails, System.Collections.ArrayList feeDetails)
//        {
//            return 1;
//        }

       

//        Control c;

//        /// <summary>
//        /// 设置发票打印内容
//        /// </summary>
//        /// <param name="regInfo">挂号信息</param>
//        /// <param name="invoice">发票主表信息</param>
//        /// <param name="alInvoiceDetail">发票明细信息</param>
//        /// <param name="alFeeItemList">费用明细信息</param>
//        /// <param name="isPreview">是否预览模式</param>
//        /// <returns></returns>
//        public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo,
//            Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice,
//            ArrayList alInvoiceDetail,
//            ArrayList alFeeItemList,
//            bool isPreview)
//        {
//           //this.isPreView = false  ;
//            try
//            {
//                this.Register = regInfo;
//                this.Controls.Clear();
//                //如果费用明细为空，则返回
//                if (alFeeItemList.Count <= 0)
//                {
//                    return -1;
//                }
//                #region 克隆一个费用明细信息列表，因为后面操作需要对列表元素有删除操作．
//                ArrayList alInvoiceDetailClone = new ArrayList();
//                foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList det in alInvoiceDetail)
//                {
//                    alInvoiceDetailClone.Add(det.Clone());
//                }
//                #endregion
//                if (this.InvoiceType == "MZ01")
//                {
//                    c = new ucMZXJ();
//                    while (c.Controls.Count > 0)
//                    {
//                        this.Controls.Add(c.Controls[0]);
//                    }
//                    this.Size = c.Size;
//                    this.InitReceipt();
//                    SetMZXJPrintValue (regInfo,
//                           invoice,
//                           alInvoiceDetailClone,
//                           alFeeItemList,
//                           isPreview);
//                }
//                if (this.InvoiceType == "MZ05")
//                {
//                    c = new ucMZTK();
//                    while (c.Controls.Count > 0)
//                    {
//                        this.Controls.Add(c.Controls[0]);
//                    }
//                    this.Size = c.Size;
//                    this.InitReceipt();
//                    SetMZTKPrintValue(regInfo,
//                           invoice,
//                           alInvoiceDetailClone,
//                           alFeeItemList,
//                           isPreview);
//                }
//                //控制根据打印和预览显示选项
//                if (isPreview)
//                {
//                    SetToPreviewMode();
//                }
//                else
//                {
//                    SetToPrintMode();
//                }
//            }
//            catch (Exception ex)
//            {
//                return -1;
//            }
//            return 0;
//        }

//        /// <summary>
//        /// 设置现金发票打印内容
//        /// </summary>
//        /// <param name="regInfo">挂号信息</param>
//        /// <param name="invoice">发票主表信息</param>
//        /// <param name="alInvoiceDetail">发票明细信息</param>
//        /// <param name="alFeeItemList">费用明细信息</param>
//        /// <param name="isPreview">是否预览模式</param>
//        /// <returns></returns>
//        private int SetMZXJPrintValue(
//            Neusoft.HISFC.Models.Registration.Register regInfo,
//            Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice,
//            ArrayList alInvoiceDetail,
//            ArrayList alFeeItemList,
//            bool isPreview)
//        {
//            try
//            {
//                string hospitalName = this.managerIntegrate.GetHospitalName();

               
//                #region 设置发票打印内容
//                ucMZXJ   ucReceipt = (ucMZXJ)c;
//                ucReceipt.neuLabel20.Text = hospitalName;
//                #region 医疗机构
//                //ucReceipt.lblYiLiaoJiGou.Text = "阜新市新邱区第二人民医院";
//                #endregion

//                #region 门诊号
//                ucReceipt.lblBingli.Text = regInfo.PID.CardNO; 
//                #endregion

//                #region 打印时间
//                ucReceipt.lblDate.Text = invoice.PrintTime.ToShortDateString();
//                #endregion

//                #region 流水号
//                ucReceipt.lblInvoiceNO.Text = invoice.Invoice.ID; 
//                #endregion

//                #region 收费员
//                Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
//                string operUserCode = string.Empty;
//                operUserCode = invoice.BalanceOper.ID;
//                ucReceipt.lblOper.Text = operUserCode;
//                #endregion

//                #region 合同单位
//                //if (invoice.Patient.Pact.PayKind.ID == "01" || invoice.Patient.Pact.PayKind.ID == "02")
//                //{
//                ucReceipt.lblPactName.Text = regInfo.Pact.Name;
//                //} 
//                #endregion

//                #region 现金支付
//                if (invoice.Patient.Pact.PayKind.ID == "01" )
//                {
//                    ucReceipt.lblOwnCost.Text = ""; 
//                }
//                #endregion

//                #region 姓名
//                ucReceipt.lblName.Text = regInfo.Name;
//                #endregion

//                #region 科别
//                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList detFeeItemList = alFeeItemList[0] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
//                ucReceipt.lblExeDept.Text =  detFeeItemList.ExecOper.Dept.Name;
//                #endregion
//                #region 处方医师
//                ucReceipt.lblRecipeOperName.Text = regInfo.DoctorInfo.Templet.Doct.Name; 
//                #endregion
//                #region 费用大类
//                //票面信息
//                decimal[] FeeInfo =
//                    //---------------------1-----------2------------3------------4-------------5-----------------
//                    new decimal[48] { decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                      decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                        decimal.Zero,decimal.Zero,decimal.Zero,
//                                      decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};
//                //票面信息
//                string[] FeeInfoName =
//                    //---------------------1-----------2------------3------------4-------------5-----------------
//                    new string[48] { string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                                string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
//                        string.Empty,string.Empty,string.Empty,
//                                string.Empty,string.Empty,string.Empty,string.Empty,string.Empty};

//                //统计大类项目可以直接取
//                for (int i = 0; i < alInvoiceDetail.Count; i++)
//                {
//                    Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = null;
//                    detail = (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList)alInvoiceDetail[i];
//                    if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
//                    {
//                        FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
//                        FeeInfoName[detail.FeeCodeStat.SortID - 1] += detail.FeeCodeStat.Name; ;
//                    }
//                }
//                int feeInfoNameIdx = 0;
//                int FeeInfoIndex = 0;
//                foreach (decimal d in FeeInfo)
//                {                    
//                    //名称
//                    Label lName = GetFeeNameLable("lblFeeName" + feeInfoNameIdx.ToString(), lblPrint);
//                    //值
//                    Label lValue = GetFeeNameLable("lblFeeValue" + feeInfoNameIdx.ToString(), lblPrint);
//                    if (lName != null)
//                    {
//                        if (FeeInfo[FeeInfoIndex] > 0)
//                        {
//                            //lName.Text = FeeInfoName[FeeInfoIndex] + ":";
//                            lName.Text = FeeInfoName[FeeInfoIndex] + "";

//                            lValue.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2).PadLeft(9,' ');
//                            //操作下一组控件
//                            feeInfoNameIdx++;
//                        }
//                    }
//                    FeeInfoIndex++;
//                }


//                #endregion

//                #region 医保信息
//                decimal GeRenCost = decimal.Zero;
//                decimal TongChouCost = decimal.Zero;
//                decimal XianJinCost = decimal.Zero;
//                decimal GongWuYuanCost = decimal.Zero;
//                decimal DaECost = decimal.Zero;
//                ucReceipt.label5.Text = "";
//                ucReceipt.label63.Text = "";
//                //个人账户支付
//                GeRenCost = regInfo.SIMainInfo.PayCost+regInfo.SIMainInfo.PubCost ;
//                if (GeRenCost != 0)
//                {
//                    ucReceipt.label63.Text = "医保承担：";
//                    ucReceipt.lblPubCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GeRenCost , 2).PadLeft(9, ' ');
//                }
//                ////统筹基金支付
//                //TongChouCost = regInfo.SIMainInfo.PubCost;
//                //if (TongChouCost != 0)
//                //{
//                //    ucReceipt.lblTongChouCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(TongChouCost , 2).PadLeft(9, ' ');
//                //}
//                //现金支付
//                XianJinCost = regInfo.SIMainInfo.OwnCost;
//                if (XianJinCost != 0)
//                {
                   
//                    ucReceipt.lblXianJinCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(XianJinCost , 2).PadLeft(9, ' ');
//                }
//                ////公务员补助
//                //GongWuYuanCost = regInfo.SIMainInfo.OfficalCost;
//                //if (GongWuYuanCost != 0)
//                //{
//                //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GongWuYuanCost  , 2).PadLeft(9, ' ');
//                //}
//                ////大额补助
//                //DaECost = regInfo.SIMainInfo.OverCost ;
//                //if (DaECost != 0)
//                //{
//                //    ucReceipt.lblDaECost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DaECost , 2).PadLeft(9, ' ');
//                //}
//                #endregion

//                #region 小写总金额
//                //ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2);
//                #endregion

//                #region 大写总金额
//                ucReceipt.lblUpOwnCost.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(invoice.FT.OwnCost);
//                #endregion
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                return -1;
//            }
//            return 0;
//        }

//        /// <summary>
//        /// 设置现金发票打印内容
//        /// </summary>
//        /// <param name="regInfo">挂号信息</param>
//        /// <param name="invoice">发票主表信息</param>
//        /// <param name="alInvoiceDetail">发票明细信息</param>
//        /// <param name="alFeeItemList">费用明细信息</param>
//        /// <param name="isPreview">是否预览模式</param>
//        /// <returns></returns>
//        private int SetMZTKPrintValue(
//            Neusoft.HISFC.Models.Registration.Register regInfo,
//            Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice,
//            ArrayList alInvoiceDetail,
//            ArrayList alFeeItemList,
//            bool isPreview)
//        {
//            try
//            {
//                string hospitalName = this.managerIntegrate.GetHospitalName();

//                #region 设置发票打印内容
//                ucMZTK ucReceipt = (ucMZTK)c; 
//                //姓名
//                ucReceipt.lblName.Text = regInfo.Name;
//                //发票号
//                ucReceipt.lblInvoiceID.Text = invoice.Invoice.ID;
//                //病历号
//                ucReceipt.lblCardNO.Text = regInfo.PID.CardNO;
//                //日期
//                ucReceipt.lblPrintTime.Text = invoice.PrintTime.ToShortDateString();
//                //收款员号
//                ucReceipt.lblOperID.Text = invoice.BalanceOper.ID;
//                //现金合计
//                ucReceipt.lblOwnCostA.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(invoice.FT.TotCost, 2);
//                //大写
//                ucReceipt.lblUpOwnCost.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(invoice.FT.TotCost);
//                //患者
//                ucReceipt.lblXianJinCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(regInfo.SIMainInfo.OwnCost, 2);
//                //减免的金额，也就是公费中的pubcost
//                ucReceipt.lblPubCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(regInfo.SIMainInfo.PubCost+regInfo.SIMainInfo.PayCost, 2);
//                //低保证号
//                ucReceipt.lblTKNO.Text = regInfo.SIMainInfo.ICCardCode.ToString();

//                //票面信息
//                decimal[] FeeInfo =
//                    //---------------------1-----------2------------3------------4-------------5-----------------
//                    new decimal[13] {decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                     decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
//                                     decimal.Zero,decimal.Zero,decimal.Zero};


//                for (int i = 0; i < alInvoiceDetail.Count; i++)
//                {
//                    Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Outpatient.BalanceList();
//                    detail = (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList)alInvoiceDetail[i];
//                    if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
//                    {
//                        FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
//                    }
//                }
//                int FeeInfoIndex = 0;
//                foreach (decimal d in FeeInfo)
//                {
//                    Label l = GetFeeNameLable("lblFeeInfo" + FeeInfoIndex.ToString(), lblPrint);
//                    if (l != null)
//                    {
//                        if (FeeInfo[FeeInfoIndex] > 0)
//                        {
//                            l.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2);
//                        }
//                    }
//                    FeeInfoIndex++;
//                }
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                return -1;
//            }
//            return 0;
//        }

//        /// <summary>
//        /// 设置数据库连接
//        /// </summary>
//        /// <param name="trans"></param>
//        public void SetTrans(IDbTransaction trans)
//        {
//            this.trans = trans;
//        }
//        /// <summary>
//        /// 分发票后的支付方式
//        /// </summary>
//        public string SplitInvoicePayMode
//        {
//            set { this.splitinvoicepaymode = value; }
//        }
//        /// <summary>
//        /// 数据库连接
//        /// </summary>
//        public IDbTransaction Trans
//        {
//            set { this.trans = value; }
//        }

//        #endregion

//        /// <summary>
//        /// 设置为打印模式
//        /// </summary>
//        public void SetToPrintMode()
//        {
//            //将预览项设为不可见
//            SetLableVisible(false, lblPreview);
//            foreach (Label lbl in lblPrint)
//            {
//                lbl.BorderStyle = BorderStyle.None;
//                lbl.BackColor = SystemColors.ControlLightLight;
//            }
//        }
//        /// <summary>
//        /// 设置为预览模式
//        /// </summary>
//        public void SetToPreviewMode()
//        {
//            //将预览项设为可见
//            SetLableVisible(true, lblPreview);
//            foreach (Label lbl in lblPrint)
//            {
//                lbl.BorderStyle = BorderStyle.None;
//                lbl.BackColor = SystemColors.ControlLightLight;
//            }
//        }

//        /// <summary>
//        /// 打印用的标签集合
//        /// </summary>
//        public Collection<Label> lblPrint;
//        /// <summary>
//        /// 预览用的标签集合
//        /// </summary>
//        public Collection<Label> lblPreview;

//        /// <summary>
//        /// 初始化收据
//        /// </summary>
//        /// <remarks>
//        /// 把打印项和预览项根据ｔａｇ标签的值区分开，用于需要追加新票据时
//        /// </remarks>
//        private void InitReceipt(Control control)
//        {
//            foreach (Control c in control.Controls)
//            {
//                if (c.GetType().FullName == "System.Windows.Forms.Label" ||
//                    c.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuLabel")
//                {
//                    Label l = (Label)c;
//                    if (l.Tag != null)
//                    {
//                        if (l.Tag.ToString() == "print")
//                        {
//                            #region 将代印字的打印项值清空
//                            if (!string.IsNullOrEmpty(l.Text) || l.Text == "印")
//                            {
//                                l.Text = "";
//                            }
//                            #endregion
//                            lblPrint.Add(l);
//                        }
//                        else
//                        {
//                            lblPreview.Add(l);
//                        }
//                    }
//                    else
//                    {
//                        lblPreview.Add(l);
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// 发票只打印大写数字 打印到十万
//        /// </summary>
//        /// <param name="Cash"></param>
//        /// <returns></returns>
//        public static string GetUpperCashByNumber(decimal Cash)
//        {
//            #region 大写总金额
//            string returnValue = string.Empty;
//            string[] strMoney = new string[8];
//            //---------------------------|\*/|-----这个＂点＂字没有用，纯属凑数！
//            string[] unit = { "分", "角", "点", "元", "拾", "佰", "仟", "万", "十万" };
//            strMoney = GetUpperCashNumberByNumber(Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2));
//            bool isStart = false;
//            string tempDaXie = string.Empty;
//            for (int i = 0; i < strMoney.Length; i++)
//            {
//                #region 从非零位开始打印
//                if (!isStart)
//                {
//                    if (strMoney[i] != "零")
//                    {
//                        isStart = true;
//                    }
//                    else
//                    {
//                        continue;
//                    }
//                }
//                #endregion
//                if (strMoney[i] != null)
//                {
//                    if (strMoney[i] != "零")
//                    {
//                        tempDaXie = strMoney[i] + unit[i] + tempDaXie;
//                        returnValue = tempDaXie + returnValue;
//                        tempDaXie = string.Empty;
//                    }
//                    else
//                    {
//                        tempDaXie = "零";
//                    }
//                }
//            }
//            return returnValue;
//            #endregion
//        }

//        /// <summary>
//        /// 初始化收据
//        /// </summary>
//        /// <remarks>
//        /// 把打印项和预览项根据ｔａｇ标签的值区分开
//        /// </remarks>
//        private void InitReceipt()
//        {
//            lblPreview = new Collection<Label>();
//            lblPrint = new Collection<Label>();
//            //foreach (Control c in this.Controls[0].Controls)
//            foreach (Control c in this.Controls)
//            {
//                if (c.GetType().FullName == "System.Windows.Forms.Label" ||
//                    c.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuLabel")
//                {
//                    Label l = (Label)c;
//                    if (l.Tag != null)
//                    {
//                        if (l.Tag.ToString() == "print")
//                        {
//                            #region 将代印字的打印项值清空
//                            if (!string.IsNullOrEmpty(l.Text) && l.Text == "印")
//                            {
//                                l.Text = "";
//                            }
//                            #endregion
//                            lblPrint.Add(l);
//                        }
//                        else
//                        {
//                            lblPreview.Add(l);
//                        }
//                    }
//                    else
//                    {
//                        lblPreview.Add(l);
//                    }
//                }
//            }
//        }
//        /// <summary>
//        /// 设置标签集合的可见性
//        /// </summary>
//        /// <param name="v">是否可见</param>
//        /// <param name="l">标签集合</param>
//        private void SetLableVisible(bool v, Collection<Label> l)
//        {
//            foreach (Label lbl in l)
//            {
//                lbl.Visible = v;                
//            }
//        }


//        /// <summary>
//        /// 设置打印集合的值
//        /// </summary>
//        /// <param name="t">值数组</param>
//        /// <param name="l">标签集合</param>
//        private void SetLableText(string[] t, Collection<Label> l)
//        {
//            foreach (Label lbl in l)
//            {
//                lbl.Text = "";
//            }
//            if (t != null)
//            {
//                if (t.Length <= l.Count)
//                {
//                    int i = 0;
//                    foreach (string s in t)
//                    {
//                        l[i].Text = s;
//                        i++;
//                    }
//                }
//                else
//                {
//                    if (t.Length > l.Count)
//                    {
//                        int i = 0;
//                        foreach (Label lbl in l)
//                        {
//                            lbl.Text = t[i];
//                            i++;
//                        }
//                    }
//                }
//            }
//        }
//        /// <summary>
//        /// 获得指定名称输入框
//        /// </summary>
//        /// <param name="n">名称</param>
//        /// <returns>费用名称输入框控件</returns>
//        public System.Windows.Forms.Label GetFeeNameLable(string n, Collection<Label> l)
//        {
//            foreach (Label lbl in l)
//            {
//                if (lbl.Name == n)
//                {
//                    return lbl;
//                }
//            }
//            return null;
//        }
//        /// <summary>
//        /// 获得指定名称输入框
//        /// </summary>
//        /// <param name="n">名称</param>
//        /// <returns>费用名称输入框控件</returns>
//        public System.Windows.Forms.Label GetFeeNameLable(string n, System.Windows.Forms.Control control)
//        {
//            foreach (System.Windows.Forms.Control c in control.Controls)
//            {
//                if (c.Name == n)
//                {
//                    return (System.Windows.Forms.Label)c;
//                }
//            }
//            return null;
//        }
//        /// <summary>
//        /// 发票只打印大写数字 打印到十万
//        /// </summary>
//        /// <param name="Cash"></param>
//        /// <returns></returns>
//        public static string[] GetUpperCashNumberByNumber(decimal Cash)
//        {
//            string[] sNumber = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
//            string[] sReturn = new string[9];
//            string strCash = null;
//            //填充位数
//            int iLen = 0;
//            strCash = Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2).ToString("############.00");
//            if (strCash.Length > 9)
//            {
//                strCash = strCash.Substring(strCash.Length - 9);
//            }

//            //填充位数
//            iLen = 9 - strCash.Length;
//            for (int j = 0; j < iLen; j++)
//            {
//                int k = 0;
//                k = 8 - j;
//                sReturn[k] = "零";
//            }
//            for (int i = 0; i < strCash.Length; i++)
//            {
//                string Temp = null;

//                Temp = strCash.Substring(strCash.Length - 1 - i, 1);

//                if (Temp == ".")
//                {
//                    continue;
//                }
//                sReturn[i] = sNumber[int.Parse(Temp)];
//            }
//            return sReturn;
//        }
//        #endregion
//        private string invoiceType;

//        public string InvoiceType
//        {
//            get { return invoiceType; }
//        }

//        private Neusoft.HISFC.Models.Registration.Register register;
//        public Neusoft.HISFC.Models.Registration.Register Register
//        {
//            set
//            {
//                //register = value;
//                //if (register.Pact.ID == "7")
//                //{
//                //    invoiceType = "MZ05";
//                //}
//                //else
//                //{
//                invoiceType = "MZ01";
//                //}
//            }
//        }
//    }
//}
