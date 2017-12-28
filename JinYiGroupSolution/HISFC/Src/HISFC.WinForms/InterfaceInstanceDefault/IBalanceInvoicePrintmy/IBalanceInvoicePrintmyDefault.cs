using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Registration;

namespace InterfaceInstanceDefault.IBalanceInvoicePrintmy
{
    /// <summary>
    /// 住院发票打印
    /// </summary>
    public partial class IBalanceInvoicePrintmyDefault : UserControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBalanceInvoicePrintmy
    {
        /// <summary>
        ///  构造函数



        /// </summary>
        public IBalanceInvoicePrintmyDefault()
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
        protected Neusoft.HISFC.Models.Base.EBlanceType MidBalanceFlag;
        /// <summary>
        /// 中途结算标记
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
            if (this.InvoiceType == "ZY01")
            {
                c = new ucZYXJFP();
                while (c.Controls.Count > 0)
                {
                    this.Controls.Add(c.Controls[0]);
                }
                //this.Controls.Add(c);
                this.Size = c.Size;
                this.InitReceipt();
                SetZYXJFPPrintValue(patientInfo,
                       balanceHead,
                       alBalanceListClone,
                       IsPreview);
            }
            if (this.InvoiceType == "ZY02")
            {
                c = new ucZYYBFP ();
                while (c.Controls.Count > 0)
                {
                    this.Controls.Add(c.Controls[0]);
                }
                //this.Controls.Add(c);
                this.Size = c.Size;
                this.InitReceipt();
                SetZYYBFPPrintValue(patientInfo,
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
        /// <param name="patientInfo">患者实体</param>
        /// <param name="balanceHead">发票</param>
        /// <param name="alBalanceList">发票明细</param>
        /// <param name="IsPreview">是否预览</param>
        /// <returns></returns>
        protected int SetZYXJFPPrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            #region 设置自费发票打印内容
            ucZYXJFP ucReceipt = (ucZYXJFP)c;

            #region 医疗机构
            //医院名称从数据库获取 {8A045104-A387-48e7-91A5-6E362E44B765} wbo 2010-08-20
            Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ucReceipt.lblHospitalName.Text = mgr.GetHospitalName();
            //ucReceipt.lblHospitalName.Text = "中国北车集团长春客车厂职工医院";
            #endregion
            //电脑编号
            ucReceipt.lblSSN.Text = patientInfo.SSN;
            //病房
            ucReceipt.lblNurseCellName.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            //基本信息
            //病案号
            ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;
            //结算日期
            ucReceipt.lblDate.Text = balanceHead.BalanceOper.OperTime.ToShortDateString();
            //姓名
            ucReceipt.lblName.Text = patientInfo.Name;
            //住院日期
            ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToShortDateString();
            //住院日期
            ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToShortDateString();

            #region //出院日期如果没有，那么打现在的日期 {02F13455-1B64-48bb-9C69-1D2C9038E3B0} wbo 2010-08-20

            Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
            DateTime dt = consMgr.GetDateTimeFromSysDateTime();
            if (MidBalanceFlag == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            {
                if (balanceHead.EndTime < new DateTime(1900, 1, 1))
                {
                    ucReceipt.lblOutTime.Text = dt.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(dt.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
                else
                {
                    ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
            }
            else
            {
                if (patientInfo.PVisit.OutTime < new DateTime(1900, 1, 1))
                {
                    ucReceipt.lblOutTime.Text = dt.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(dt.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
                else
                {
                    ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
            }
            //if (MidBalanceFlag == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            //{
            //    ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            //else
            //{
            //    ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            #endregion

            ////科室
            //ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //结算员

            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            string operUserCode = string.Empty;
            operUserCode = person.GetPersonByID(balanceHead.BalanceOper.ID).Name;

            ucReceipt.lblOperName.Text = operUserCode;

            ////操作员



            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            #region 医保信息
            ucReceipt.lblSSNTitle.Visible = false;
            ucReceipt.lblPayCostTitle.Visible = false;
            ucReceipt.lblPubCostTitle.Visible = false;
            ucReceipt.lblOwnCost.Visible = false;
            ucReceipt.lblPubCost.Visible = false;
            ucReceipt.lblPayCost.Visible = false;
            ucReceipt.lblOverCost.Visible = false;
            ucReceipt.lblSSN.Visible = false;
            ucReceipt.lblOwnCostTitle.Visible = false;

            if (balanceHead.Patient.Pact.PayKind.ID == "02")
            {
                ucReceipt.lblSSNTitle.Visible = true;
                ucReceipt.lblPayCostTitle.Visible = true;
                ucReceipt.lblPubCostTitle.Visible = true;

                ucReceipt.lblOwnCost.Visible = true;
                ucReceipt.lblPubCost.Visible = true;
                ucReceipt.lblPayCost.Visible = true;
                ucReceipt.lblOverCost.Visible = true;
                ucReceipt.lblSSN.Visible = true;
                ucReceipt.lblOwnCostTitle.Visible = true;
                ucReceipt.lblSSN.Text = patientInfo.SSN;
                decimal GeRenCost = decimal.Zero;
                decimal TongChouCost = decimal.Zero;
                decimal XianJinCost = decimal.Zero;
                decimal GongWuYuanCost = decimal.Zero;
                decimal DaECost = decimal.Zero;
                //个人账户支付
                GeRenCost = patientInfo.SIMainInfo.PayCost;
                if (GeRenCost != 0)
                {
                    ucReceipt.lblPayCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GeRenCost, 2);
                }
                //统筹基金支付
                TongChouCost = patientInfo.SIMainInfo.PubCost;
                if (TongChouCost != 0)
                {
                    ucReceipt.lblPubCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(TongChouCost, 2);
                }
                //现金支付
                XianJinCost = patientInfo.SIMainInfo.OwnCost;
                if (XianJinCost != 0)
                {
                    ucReceipt.lblOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(XianJinCost, 2);
                }
                //公务员补助

                //GongWuYuanCost = patientInfo.SIMainInfo.OfficalCost;
                //if (GongWuYuanCost > 0)
                //{
                //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GongWuYuanCost, 2);
                //}
                //大额补助
                DaECost = patientInfo.SIMainInfo.OverTakeOwnCost;
                if (DaECost != 0)
                {
                    ucReceipt.lblOverCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DaECost, 2);
                }
            }
            #endregion
            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[18]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                //decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,//decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};
            //票面信息
            string[] FeeInfoName =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new string[18] { string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 //string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 string.Empty,string.Empty,string.Empty,//string.Empty,
                                 string.Empty,string.Empty,string.Empty,string.Empty,string.Empty};

            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                    if (detail.FeeCodeStat.StatCate.Name.Length > 5)
                    {
                        FeeInfoName[detail.FeeCodeStat.SortID - 1] += detail.FeeCodeStat.StatCate.Name.Substring(0, 5);
                    }
                    else
                    {
                        FeeInfoName[detail.FeeCodeStat.SortID - 1] += detail.FeeCodeStat.StatCate.Name;
                    }
                }
            }
            int feeInfoNameIdx = 0;
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                //测试用
                //FeeInfo[FeeInfoIndex] = 999999.99m;
                //名称
                Label lName = GetFeeNameLable("lblFeeName" + feeInfoNameIdx.ToString(), lblPrint);
                Label lValue = GetFeeNameLable("lblFeeInfo" + feeInfoNameIdx.ToString(), lblPrint);
                if (lName != null)
                {
                    if (FeeInfo[FeeInfoIndex] > 0)
                    {
                        //测试用
                        //lName.Text = FeeInfoName[feeInfoNameIdx] + "普通人工器官材料费";
                        //lName.Text = FeeInfoName[FeeInfoIndex] + "";
                        lValue.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2).PadLeft(9, ' ');
                        feeInfoNameIdx++;
                    }
                }
                feeInfoNameIdx++;
                FeeInfoIndex++;
            }
            //预收
            if (balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost != 0)
            {
                ucReceipt.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost, 2);
            }
            //补收
            if (balanceHead.FT.SupplyCost != 0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            }
            //退款
            if (balanceHead.FT.ReturnCost != 0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(0 - balanceHead.FT.ReturnCost, 2);
            }
            //发票号
            ucReceipt.lblInvoiceNO.Text = balanceHead.Invoice.ID;
            //总金额
            if (balanceHead.FT.TotCost != 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额
            if (balanceHead.FT.TotCost != 0)
            {
                //string  tempUpTotCost = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));

                string tempUpTotCost = string.Empty;
                string[] strMoney = new string[8];
                strMoney = GetUpperCashNumberByNumber(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));

                ucReceipt.lblUpTotCost.Text = "  " + strMoney[7] + "    " + strMoney[6] + "    " + strMoney[5]
                    + "    " + strMoney[4] + "    " + strMoney[3] + "    " + strMoney[1] + "    " + strMoney[0];
            }
            #endregion
            #endregion

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
        protected int SetZYYBFPPrintValue(
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceHead,
            ArrayList alBalanceList,
            bool IsPreview)
        {
            #region 设置自费发票打印内容
            ucZYYBFP ucReceipt = (ucZYYBFP)c;

            #region 医疗机构
            //医院名称从数据库获取 {8A045104-A387-48e7-91A5-6E362E44B765} wbo 2010-08-20
            Neusoft.HISFC.BizProcess.Integrate.Manager mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ucReceipt.lblHospitalName.Text = mgr.GetHospitalName();
            //ucReceipt.lblHospitalName.Text = "中国北车集团长春客车厂职工医院";
            #endregion
            //电脑编号
            ucReceipt.lblSSN.Text = patientInfo.SSN;
            //病房
            ucReceipt.lblNurseCellName.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            //基本信息
            //病案号
            ucReceipt.lblCaseNO.Text = patientInfo.PID.CaseNO;
            //结算日期
            ucReceipt.lblDate.Text = balanceHead.BalanceOper.OperTime.ToString("yyyy    MM    dd");
            //姓名
            ucReceipt.lblName.Text = patientInfo.Name;
            //住院日期
            ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToString ("yyyy    MM    dd     HH     mm");
            //住院日期
            ucReceipt.lblInTime.Text = balanceHead.BeginTime.ToString("yyyy    MM    dd     HH     mm");

            #region //出院日期如果没有，那么打现在的日期 {02F13455-1B64-48bb-9C69-1D2C9038E3B0} wbo 2010-08-20

            Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
            DateTime dt = consMgr.GetDateTimeFromSysDateTime();
            if (MidBalanceFlag == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            {
                if (balanceHead.EndTime < new DateTime(1900, 1, 1))
                {
                    ucReceipt.lblOutTime.Text = dt.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(dt.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
                else
                {
                    ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
            }
            else
            {
                if (patientInfo.PVisit.OutTime < new DateTime(1900, 1, 1))
                {
                    ucReceipt.lblOutTime.Text = dt.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(dt.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
                else
                {
                    ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
                    ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
                }
            }
            //if (MidBalanceFlag == Neusoft.HISFC.Models.Base.EBlanceType.Mid)
            //{
            //    ucReceipt.lblOutTime.Text = balanceHead.EndTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(balanceHead.EndTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            //else
            //{
            //    ucReceipt.lblOutTime.Text = patientInfo.PVisit.OutTime.ToShortDateString();
            //    ucReceipt.lblInDay.Text = new TimeSpan(patientInfo.PVisit.OutTime.Ticks - balanceHead.BeginTime.Ticks).Days.ToString();
            //}
            #endregion
            ////科室
            //ucReceipt.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;

            //结算员

            Neusoft.HISFC.BizLogic.Manager.Person person = new Neusoft.HISFC.BizLogic.Manager.Person();
            string operUserCode = string.Empty;
            operUserCode = person.GetPersonByID(balanceHead.BalanceOper.ID).Name;

            ucReceipt.lblOperName.Text = operUserCode;

            ////操作员



            //ucReceipt.lblBalanceName.Text = balanceHead.Oper.ID;

            #region 医保信息
            ucReceipt.lblSSNTitle.Visible = false;
            ucReceipt.lblPayCostTitle.Visible = false;
            ucReceipt.lblPubCostTitle.Visible = false;
            ucReceipt.lblOwnCost.Visible = false;
            ucReceipt.lblPubCost.Visible = false;
            ucReceipt.lblPayCost.Visible = false;
            ucReceipt.lblOverCost.Visible = false;
            ucReceipt.lblSSN.Visible = false;
            ucReceipt.lblOwnCostTitle.Visible = false;

            if (balanceHead.Patient.Pact.PayKind.ID == "02")
            {
                ucReceipt.lblSSNTitle.Visible = true;
                ucReceipt.lblPayCostTitle.Visible = true;
                ucReceipt.lblPubCostTitle.Visible = true;
                ucReceipt.lblOwnCost.Visible = true;
                ucReceipt.lblPubCost.Visible = true;
                ucReceipt.lblPayCost.Visible = true;
                ucReceipt.lblOverCost.Visible = true;
                ucReceipt.lblSSN.Visible = true;
                ucReceipt.lblOwnCostTitle.Visible = true;
                ucReceipt.lblSSN.Text = patientInfo.SSN;
                decimal GeRenCost = decimal.Zero;
                decimal TongChouCost = decimal.Zero;
                decimal XianJinCost = decimal.Zero;
                decimal GongWuYuanCost = decimal.Zero;
                decimal DaECost = decimal.Zero;
                //个人账户支付
                GeRenCost = patientInfo.SIMainInfo.PayCost;
                if (GeRenCost != 0)
                {
                    ucReceipt.lblPayCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GeRenCost, 2);
                }
                //统筹基金支付
                TongChouCost = patientInfo.SIMainInfo.PubCost;
                if (TongChouCost != 0)
                {
                    ucReceipt.lblPubCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(TongChouCost, 2);
                }
                //现金支付
                XianJinCost = patientInfo.SIMainInfo.OwnCost;
                if (XianJinCost != 0)
                {
                    ucReceipt.lblOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(XianJinCost, 2);
                    ucReceipt.lblUpOwnCost.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(Neusoft.FrameWork.Public.String.FormatNumber(XianJinCost, 2));         
                }
                //公务员补助

                //GongWuYuanCost = patientInfo.SIMainInfo.OfficalCost;
                //if (GongWuYuanCost > 0)
                //{
                //    ucReceipt.lblGongWuYuanCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(GongWuYuanCost, 2);
                //}
                //大额补助
                DaECost = patientInfo.SIMainInfo.OverCost;
                if (DaECost != 0)
                {
                    ucReceipt.lblOverCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(DaECost, 2);
                } //-----1---------------------------2----------------3-----------------------4-----------------------5-----------------6----------------
                //|医疗费总额TotCost|个人帐户支付金额PayCost|统筹支付金额PubCost|个人现金支付OwnCost|救助金支出金额OverCost|公务员补助支出金额OfficalCost
                //-----------------7------------------8-----------------------9-----------
                //|保健对象补贴支出BaseCost|离休人员统筹支出PubOwnCost|医院付担金额HosCost
                //-------------10-------------11----------------------12------------13------------------
                //|上次进入统筹医疗费用累计|本次进入统筹医疗费用金额|上次个人帐户余额|个人自费金额
                //----14---------------15-------------16--------------------------------17----------
                //|乙类药品个人自理|起付标准自付金额|分段自理金额|超过封顶线个人自付金额|住院封顶线以上公务员补助支出金额
                //----18---------------------------19------20--------------21--------------------
                //|住院自付部分公务员补助支出金额|住院人次|工伤基金支付金额|生育基金支付金额|
                string[] temp = patientInfo.SIMainInfo.Memo.Split('|');
                ucReceipt.lblTemp18 .Text = temp[18];
                ucReceipt.lblTemp6.Text = temp[6];
                ucReceipt.lblTemp7.Text = temp[7];
                ucReceipt.lblTemp8.Text = temp[8];
                ucReceipt.lblTemp20.Text = temp[20];
                ucReceipt.lblTemp21.Text = temp[21];
                ucReceipt.lblTemp15.Text = temp[15];
                ucReceipt.lblTemp13.Text = temp[13];
            }
            #endregion
            //票面信息
            decimal[] FeeInfo =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new decimal[18]{decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                //decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,//decimal.Zero,
                                decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero,decimal.Zero};
            //票面信息
            string[] FeeInfoName =
                //---------------------1-----------2------------3------------4-------------5-----------------
                new string[18] { string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 //string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,
                                 string.Empty,string.Empty,string.Empty,//string.Empty,
                                 string.Empty,string.Empty,string.Empty,string.Empty,string.Empty};

            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                detail = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                if (detail.FeeCodeStat.SortID <= FeeInfo.Length)
                {
                    FeeInfo[detail.FeeCodeStat.SortID - 1] += detail.BalanceBase.FT.TotCost;
                    if (detail.FeeCodeStat.StatCate.Name.Length > 5)
                    {
                        FeeInfoName[detail.FeeCodeStat.SortID - 1] += detail.FeeCodeStat.StatCate.Name.Substring(0, 5);
                    }
                    else
                    {
                        FeeInfoName[detail.FeeCodeStat.SortID - 1] += detail.FeeCodeStat.StatCate.Name;
                    }
                }
            }
            int feeInfoNameIdx = 0;
            int FeeInfoIndex = 0;
            foreach (decimal d in FeeInfo)
            {
                //测试用
                //FeeInfo[FeeInfoIndex] = 999999.99m;
                //名称
                Label lName = GetFeeNameLable("lblFeeName" + feeInfoNameIdx.ToString(), lblPrint);
                Label lValue = GetFeeNameLable("lblFeeInfo" + feeInfoNameIdx.ToString(), lblPrint);
                if (lName != null)
                {
                    if (FeeInfo[FeeInfoIndex] > 0)
                    {
                        //lName.Text = FeeInfoName[feeInfoNameIdx] + "普通人工器官材料费";
                        // lName.Text = FeeInfoName[FeeInfoIndex] + "";
                        lValue.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(FeeInfo[FeeInfoIndex], 2).PadLeft(9, ' ');
                        
                    }
                }
                FeeInfoIndex++;
                feeInfoNameIdx++;
            }
            //预收
            if (balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost != 0)
            {
                ucReceipt.lblPriPrepay.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost - balanceHead.FT.BalancedPrepayCost, 2);
            }
            //补收
            if (balanceHead.FT.SupplyCost != 0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            }
            //退款
            if (balanceHead.FT.ReturnCost != 0)
            {
                ucReceipt.lblPriReturn.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(0 - balanceHead.FT.ReturnCost, 2);
            }
            //发票号
            ucReceipt.lblInvoiceNO.Text = balanceHead.Invoice.ID;
            //总金额
            if (balanceHead.FT.TotCost != 0)
            {
                ucReceipt.lblTotCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(balanceHead.FT.TotCost, 2);
            }
            #region 大写总金额
            if (balanceHead.FT.TotCost != 0)
            {
                ucReceipt.lblUpTotCost.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(Neusoft.FrameWork.Public.String.FormatNumber(balanceHead.FT.TotCost, 2));
            }
            #endregion
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
                    paperName = "ZYYBFP";

                }
                else if (this.InvoiceType == "ZY01")
                {
                    paperName = "ZYXJFP";
                }
                ps = new Neusoft.HISFC.Models.Base.PageSize(paperName, 0, 0);
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
        public int SetValueForPreview(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList, ArrayList alPayList)
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
                    c.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuLabel")
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
        #endregion

        /// <summary>
        /// 获得指定名称输入框
        /// </summary>
        /// <param name="n">名称</param>
        /// <returns>费用名称输入框控件</returns>
        public System.Windows.Forms.Label GetFeeNameLable(string n, Collection<Label> l)
        {
            foreach (Label lbl in l)
            {
                if (lbl.Name == n)
                {
                    return lbl;
                }
            }
            return null;
        }
        /// <summary>
        /// 获得指定名称输入框
        /// </summary>
        /// <param name="n">名称</param>
        /// <returns>费用名称输入框控件</returns>
        public System.Windows.Forms.Label GetFeeNameLable(string n, System.Windows.Forms.Control control)
        {
            foreach (System.Windows.Forms.Control c in control.Controls)
            {
                if (c.Name == n)
                {
                    return (System.Windows.Forms.Label)c;
                }
            }
            return null;
        }
        /// <summary>
        /// 发票只打印大写数字 打印到十万
        /// </summary>
        /// <param name="Cash"></param>
        /// <returns></returns>
        public static string[] GetUpperCashNumberByNumber(decimal Cash)
        {
            string[] sNumber = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] sReturn = new string[9];
            string strCash = null;
            //填充位数
            int iLen = 0;
            strCash = Neusoft.FrameWork.Public.String.FormatNumber(Cash, 2).ToString("############.00");
            if (strCash.Length > 9)
            {
                strCash = strCash.Substring(strCash.Length - 9);
            }

            //填充位数
            iLen = 9 - strCash.Length;
            for (int j = 0; j < iLen; j++)
            {
                int k = 0;
                k = 8 - j;
                sReturn[k] = "零";
            }
            for (int i = 0; i < strCash.Length; i++)
            {
                string Temp = null;

                Temp = strCash.Substring(strCash.Length - 1 - i, 1);

                if (Temp == ".")
                {
                    continue;
                }
                sReturn[i] = sNumber[int.Parse(Temp)];
            }
            return sReturn;
        }
        //////////////////////////////



    }
}