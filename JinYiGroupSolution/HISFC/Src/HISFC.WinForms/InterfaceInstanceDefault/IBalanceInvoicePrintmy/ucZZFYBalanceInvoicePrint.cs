using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace InterfaceInstanceDefault.IBalanceInvoicePrintmy
{
    /// <summary>
    /// ucZZFYBalanceInvoicePrint<br></br>
    /// [功能描述: 郑州住院发票<br></br>//{5D2A0629-A594-468d-9F6F-42119405A080}
    /// [创 建 者: 董国强]<br></br>
    /// [创建时间: 2010-08-05]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  /> 
    /// </summary>
    public partial class ucZZFYBalanceInvoicePrint : UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy
    {
        /// <summary>
        /// 字段：是否是现场发票打印，默认false
        /// </summary>
        private bool isZZFYPrint = false;

        /// <summary>
        /// 字段：是否是现场发票打印，默认false
        /// </summary>
        public bool IsZZFYPrint
        {
            get { return isZZFYPrint; }
            set
            {
                isZZFYPrint = value;
                if (isZZFYPrint)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl.GetType().FullName == "System.Windows.Forms.Label")
                        {
                            if (ctrl.Name.StartsWith("neu"))
                            {
                                ctrl.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        

        public ucZZFYBalanceInvoicePrint()
        {
            IsZZFYPrint = false ;
            InitializeComponent();
        }


        #region IBalanceInvoicePrintmy 成员

        /// <summary>
        /// 字段：中途结算标记
        /// </summary>
        protected Neusoft.HISFC.Models.Base.EBlanceType MidBalanceFlag;
        /// <summary>
        /// 属性：中途结算标记
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

        #region IBalanceInvoicePrint 成员

        public int Clear()
        {
            return 1;
        }

        private string invoiceType;

        /// <summary>
        /// 发票类别
        /// </summary>
        public string InvoiceType
        {
            get { return invoiceType; }
        }

        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo;

        /// <summary>
        /// 患者实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set
            {
                patientInfo = value;
                //if (patientInfo.Pact.PayKind.ID == "01")
                //{
                    //自费
                    invoiceType = "ZY01";
                //}
                //else if (patientInfo.Pact.PayKind.ID == "02")
                //{
                //    //市医保
                //    invoiceType = "ZY02";
                //}
            }
        }

        public int Print()
        {

            #region {E11D456D-F6F8-44e7-AFD8-49879BB825AC}
            
            

            //设置为非现场打印
            IsZZFYPrint = true;
            //
            //this.printDocument1.Print();
            //return 1;
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                Neusoft.HISFC.Models.Base.PageSize ps = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                ps = new Neusoft.HISFC.Models.Base.PageSize();
                Neusoft.HISFC.BizLogic.Manager.PageSize pss = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                ps = pss.GetPageSize("ZYJSFP");
                
                print.SetPageSize(ps);

                InitReceipt();

                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;

            #endregion
        }

        public int PrintPreview()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                Neusoft.HISFC.Models.Base.PageSize ps = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }
                string paperName = string.Empty;
                if (this.InvoiceType == "ZY02")
                {
                    paperName = "ZYZF";

                }
                else if (this.InvoiceType == "ZY01")
                {
                    paperName = "ZYYB";
                }
                ps = new Neusoft.HISFC.Models.Base.PageSize(paperName, 0, 0);
                ps.Top = 0;
                ps.Left = 0;
                print.SetPageSize(ps);

                InitReceipt();

                print.PrintPreview(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;
        }


        #region {E11D456D-F6F8-44e7-AFD8-49879BB825AC}
        /// </summary>
        /// <remarks>
        /// 把打印项和预览项根据ｔａｇ标签的值区分开
        /// </remarks>
        private void InitReceipt()
        {
            foreach (Control c in this.Controls)
            {
                if (c is System.Windows.Forms.Label )
                {
                    #region 将代印字的打印项值清空

                    if (!string.IsNullOrEmpty(c.Text) && c.Text == "印")
                    {
                        c.Text = "";
                    }

                    #endregion
                }
            }
        }

        #endregion


        public void SetTrans(System.Data.IDbTransaction trans)
        {
            return;
        }

        public int SetValueForPreview(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, System.Collections.ArrayList alBalanceList, System.Collections.ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, true);
        }

        public int SetValueForPrint(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, System.Collections.ArrayList alBalanceList, System.Collections.ArrayList alPayList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, true);
        }

        private int SetPrintValue(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead, System.Collections.ArrayList alBalanceList, bool IsPreview)
        { 

            #region 设置自费发票打印内容
            /*
             * {E7AF00A9-C588-464b-8C3B-2E312694A5B1} 席宗飞 modified on 20100923
             * 05 郑州市医疗保险
             * 08郑州市铁路医疗保险
             
             */
            Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Hashtable ZZCityKind = new Hashtable();
            ZZCityKind["302"] = "郑州市医疗保险(中原区)";
            ZZCityKind["303"] = "郑州市医疗保险(二七区)";
            ZZCityKind["304"] = "郑州市医疗保险(管城区)";
            ZZCityKind["305"] = "郑州市医疗保险(金水区)";
            ZZCityKind["306"] = "郑州市医疗保险(上街区)";
            ZZCityKind["308"] = "郑州市医疗保险(惠济区)";
            if (patientInfo.Pact.ID == "05")
            {
                if (patientInfo.SIMainInfo.PersonType.ID == "41")
                {
                    this.label2.Text = "郑州市医疗保险(居民)";
                }
                else if ((patientInfo.SIMainInfo.PersonType.ID == "21" || patientInfo.SIMainInfo.PersonType.ID == "11") && !ZZCityKind.ContainsKey(patientInfo.SIMainInfo.Fund.Name))
                {
                    this.label2.Text = "郑州市医疗保险(职工)";
                }
                else {
                    this.label2.Text = ZZCityKind[patientInfo.SIMainInfo.Fund.Name].ToString();
                
                }
            }
            else if (patientInfo.Pact.ID == "08")
            {
                if (patientInfo.SIMainInfo.PersonType.ID == "11" || patientInfo.SIMainInfo.PersonType.ID == "21")
                {
                    this.label2.Text = "郑州市铁路医疗保险(职工)";
                }
                else if (patientInfo.SIMainInfo.PersonType.ID == "31")
                {
                    this.label2.Text = "郑州市铁路医疗保险(家庭)";
                }
                else {
                    this.label2.Text = "郑州市铁路医疗保险(离休)";
                }
            }
            else
            {
                this.label2.Text = patientInfo.Pact.Name;
            }
            ///{C00F610C-D314-4783-B4D9-548ACD884312} 席宗飞 添加结算状态20101110
            if (balanceHead.BalanceType.ID.ToString() == "Q") {
                this.label2.Text += "  逃帐结算";
            }
            else if (balanceHead.BalanceType.ID.ToString() == "I")
            {
                this.label2.Text += "  中途结算";
            }
            else {
                this.label2.Text += "  正常结算";
            }
            //打票单位
            this.lblHospitalName.Text = mgr.GetHospitalName();
            //打印时间
            this.label2.Text += " " + Neusoft.FrameWork.Management.Connection.Sql.GetSysDateTime();
            //姓名
            #region 对于新农合患者，打印患者所在县 modified by xizf 20101224
            if (patientInfo.Pact.ID == "13")
            {
                this.lblPatientName.Text = patientInfo.Name+"("+patientInfo.CompanyName+")";
                this.lblCountryID.Text = "新农合:"+patientInfo.User03;//打印新农合地区编码
            }
            else {
                this.lblPatientName.Text = patientInfo.Name;
                this.lblCountryID.Text = "";
            }
            #endregion
           
            

            //住院科室
            this.lblDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            //医保号 {9252CFAC-171B-451d-A517-23D363BEED44} 席宗飞20101112
            if (balanceHead.Patient.Pact.PayKind.ID == "02")
            {
                if (patientInfo.Pact.ID == "05")
                {
                    this.label42.Text = patientInfo.IDCard;
                }
                else if (patientInfo.Pact.ID == "03" || patientInfo.Pact.ID == "02" || patientInfo.Pact.ID == "07")
                {
                    this.label42.Text = patientInfo.SSN;
                }
                else {
                    this.label42.Text = patientInfo.IDCard;
                }
            }
            else 
            {
                this.label42.Text = string.Empty;
            }

            //住院号码
            this.lblInNo.Text = patientInfo.PID.PatientNO;

            //住院日期
            this.lblInTime.Text = balanceHead.BeginTime.ToString("yyyy.MM.dd");

            //出院日期
            if (MidBalanceFlag == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            {
                this.lblOutTime.Text = balanceHead.EndTime.ToString("yyyy.MM.dd");
                //this.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            }
            else
            {
                this.lblOutTime.Text = patientInfo.PVisit.OutTime.ToString("yyyy.MM.dd");
                //this.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            }

            //结算形式
            this.lblPayKind.Text = patientInfo.PayKind.Name;

            #region 具体的项目

            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];

                

                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblItem" + i.ToString(),true))
                {
                    ctrl.Visible = true;
                    ctrl.Text = detail.FeeCodeStat.StatCate.Name;
                }

                foreach (System.Windows.Forms.Control ctrl in this.Controls.Find("lblItemFee" + i.ToString(), true))
                {
                    ctrl.Visible = true;
                    ctrl.Text = detail.BalanceBase.FT.TotCost.ToString();
                }
            }

            #endregion

            #region 医保相关信息

            this.label46.Visible = false;
            this.label47.Visible = false;
            this.label48.Visible = false;
            this.label49.Visible = false;
            this.label50.Visible = false;
            this.label51.Visible = false;
            this.label52.Visible = false;
            this.label53.Visible = false;
            this.label54.Visible = false;
            this.label55.Visible = false;

            //医保记账
            this.label56.Visible = false;
            //大额比例自负
            this.label1.Visible = false;


            if (balanceHead.Patient.Pact.PayKind.ID == "02")
            {
                this.label46.Visible = true;
                this.label47.Visible = true;
                this.label48.Visible = true;
                this.label49.Visible = true;
                this.label50.Visible = true;
                this.label51.Visible = true;
                this.label52.Visible = true;
                this.label53.Visible = true;
                this.label54.Visible = true;
                this.label55.Visible = true;

                //
                this.label56.Visible = true;
                //
                this.label1.Visible = true;
                //
                decimal ziFeiFeiYong = decimal.Zero;
                decimal daEJiZhang = decimal.Zero;
                
                decimal geRenZiFu = decimal.Zero;
                decimal caoDaEJiZhang = decimal.Zero;

                decimal biaoZhunQiFu = decimal.Zero;
                decimal gongWuYuanJiZhang = decimal.Zero;

                decimal anBiLiZiFu = decimal.Zero;
                decimal geRenZhangHu = decimal.Zero;

                decimal tongChouJiZhang = decimal.Zero;
                decimal xianJinZhiFu = decimal.Zero;

                decimal daEBiLiZiFu = decimal.Zero;

                //46自费费用
                ziFeiFeiYong = patientInfo.SIMainInfo.ItemYLCost;
                if (ziFeiFeiYong != 0)
                {
                    this.label46.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(ziFeiFeiYong, 2);
                }

                //47大额记账
                daEJiZhang = patientInfo.SIMainInfo.OverCost;
                if (daEJiZhang != 0)
                {
                    this.label47.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(daEJiZhang, 2);
                }

                //48个人自付
                geRenZiFu = patientInfo.SIMainInfo.PubOwnCost;
                if (geRenZiFu != 0)
                {
                    this.label48.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZiFu, 2);
                }

                //49超大额记账
                caoDaEJiZhang = patientInfo.SIMainInfo.OverTakeOwnCost;
                if (caoDaEJiZhang != 0)
                {
                    this.label49.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(caoDaEJiZhang, 2);
                }

                //50起付标准
                biaoZhunQiFu = patientInfo.SIMainInfo.BaseCost;
                if (biaoZhunQiFu != 0)
                {
                    this.label50.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(biaoZhunQiFu, 2);
                }

                //51公务员记账
                gongWuYuanJiZhang = patientInfo.SIMainInfo.OfficalCost;
                if (gongWuYuanJiZhang > 0)
                {
                    //{8DA5C28A-11C3-4891-A727-E72A19C36AE2} 席宗飞2010118 对于省农合公务员记帐不显示
                    if (patientInfo.Pact.ID == "13")
                    {
                        this.label51.Text = "";
                    }
                    else {
                        this.label51.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(gongWuYuanJiZhang, 2);
                    }
                    
                }

                //52按比例自付
                anBiLiZiFu = patientInfo.SIMainInfo.ItemPayCost;
                if (anBiLiZiFu != 0) 
                {
                    this.label52.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(anBiLiZiFu, 2);
                }

                //53个人账户
                geRenZhangHu = patientInfo.SIMainInfo.PayCost;
                if (geRenZhangHu != 0)
                {
                    //20101108 席宗飞 省农合的个人账户存储超限额费用{B8DCCA59-92A9-483d-8531-D1177F0D79E3}
                    if (patientInfo.Pact.ID == "13")
                    {
                        this.label51.Text = "超限额:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                    }
                    else {
                        this.label53.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(geRenZhangHu, 2);
                    }
                    
                }

                //54统筹记账
                tongChouJiZhang = patientInfo.SIMainInfo.SiPubCost;
                if (tongChouJiZhang != 0)
                {
                    this.label54.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(tongChouJiZhang, 2);
                }

                //55现金支付
                xianJinZhiFu = patientInfo.SIMainInfo.OwnCost;
                if (xianJinZhiFu != 0)
                {
                    this.label55.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(xianJinZhiFu, 2);
                }

                //大额比例自付
                daEBiLiZiFu = patientInfo.SIMainInfo.YearHelpCost;
                //if (daEBiLiZiFu != 0) 
                //{
                    this.label1.Text = string.Format("大额比例自付：{0}",Neusoft.FrameWork.Public.String.FormatNumberReturnString(daEBiLiZiFu,2));
                //}

                //医保记账
                if (patientInfo.SIMainInfo.PayAddCost != 0) 
                {
                    this.label56.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.PayAddCost, 2);
                }


            }


            #endregion           

            //费用合计
            if (balanceHead.FT.TotCost != 0)
            {
                this.lblTotAll.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }


            //预收押金
            if (balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost != 0)
            {
                this.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost, 2);
            }
            //退押金
            if (balanceHead.FT.ReturnCost != 0)
            {
                this.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2);
            }
            else 
            {
                this.lblPriReturn.Text = "0.00";
            }


            //退还款{D70E9BBD-E2BF-41c6-9804-EFD6C447C8C1}
            if (balanceHead.FT.SupplyCost != 0)
            {
                //{C5DD6E04-F68D-483d-B0FB-22F0B41A3472} 席宗飞 逃帐结算的特殊显示20101110
                if (balanceHead.BalanceType.ID.ToString() == "Q")
                {
                    this.lblPriAdd.Text = "欠费 "+Neusoft.FrameWork.Public.String.FormatNumberReturnString(decimal.Negate(balanceHead.FT.SupplyCost), 2);
                }
                else {
                    this.lblPriAdd.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(decimal.Negate(balanceHead.FT.SupplyCost), 2);
                }
                
            }
            else 
            {
                this.lblPriAdd.Text = "0.00";
            }


            //实收金额(大写)
            if (balanceHead.FT.TotCost != 0)
            {
                this.lblUpTotCost.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));
            }
            //实收金额
            if (balanceHead.FT.TotCost != 0)
            {
                this.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }


            //流水号
            this.lblInvoiceNo.Text = balanceHead.Invoice.ID;

            //制单
            this.label57.Text = new Neusoft.HISFC.BizLogic.Manager.Person().GetPersonByID(balanceHead.BalanceOper.ID).ID;

            //结算员工号
            this.lblOperater.Text = new Neusoft.HISFC.BizLogic.Manager.Person().GetPersonByID(balanceHead.BalanceOper.ID).ID;

            //发票号
            //this.lblInvoiceNO.Text = balanceHead.Invoice.ID;
            
            
            #endregion
            

            return 0;
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion





        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    System.Drawing.Graphics g = e.Graphics;
        //    foreach (Control c in this.Controls)
        //    {
        //        if (c is System.Windows.Forms.Label)
        //        {
        //            Font f = c.Font;
        //            PointF loc = new PointF((float)c.Location.X, (float)c.Location.Y);
        //            g.DrawString(c.Text, f, Brushes.Black, loc);
        //        }
        //    }
        //}

        //private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        //{
        //    e.PageSettings.PrinterSettings.PrinterName = "Epson LQ-1600K";
        //}

    }
}
