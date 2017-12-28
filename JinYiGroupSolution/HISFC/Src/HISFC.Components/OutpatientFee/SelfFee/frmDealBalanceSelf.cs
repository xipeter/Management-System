using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.OutpatientFee.SelfFee
{
    public partial class frmDealBalanceSelf : Form, Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientPopupFee
    {
        public frmDealBalanceSelf()
        {
            InitializeComponent(); 
        }

        #region 变量
        
        /// <summary>
        /// 自费药金额
        /// </summary>
        protected decimal selfDrugCost;

        /// <summary>
        /// 超标药金额
        /// </summary>
        protected decimal overDrugCost;

        /// <summary>
        /// 自费金额
        /// </summary>
        protected decimal ownCost;     

        /// <summary>
        /// 自付金额
        /// </summary>
        protected decimal payCost; 

        /// <summary>
        /// 记帐金额
        /// </summary>
        protected decimal pubCost;    

        /// <summary>
        /// 自费总额 = 自费金额 + 自付金额
        /// </summary>
        protected decimal totOwnCost;   

        /// <summary>
        /// 总金额
        /// </summary>
        protected decimal totCost;   

        /// <summary>
        /// 实付金额
        /// </summary>
        protected decimal realCost;  

        /// <summary>
        /// 找零金额
        /// </summary>
        protected decimal leastCost;

        /// <summary>
        /// 最多分发票张数
        /// </summary>
        protected int splitCounts;

        /// <summary>
        /// 是否可以分发票
        /// </summary>
        protected bool isCanSplit;

        /// <summary>
        /// 是否现金冲账
        /// </summary>
        protected bool isCashPay = false;

        /// <summary>
        /// 收费时应缴只显示现金金额
        /// </summary>
        protected bool isDisplayCashOnly = false;

        /// <summary>
        /// 是否可以修改发票打印日期
        /// </summary>
        protected bool isModifyDate = false;

        /// <summary>
        /// 主发票和发票明细集合
        /// </summary>
        protected ArrayList alInvoiceAndDetails = new ArrayList();

        /// <summary>
        /// 主发票集合
        /// </summary>
        protected ArrayList alInvoices = new ArrayList();

        /// <summary>
        /// 发票明细集合
        /// </summary>
        protected ArrayList alInvoiceDetails = new ArrayList();

        /// <summary>
        /// 费用明细集合
        /// </summary>
        protected ArrayList alFeeDetails = new ArrayList();

        //{E6CD2A14-1DCB-4361-834C-9CF9B9DC669A}添加一个属性，保存按发票分组的费用明细 liuq
        /// <summary>
        /// 发票费用明细集合
        /// </summary>
        private ArrayList alInvoiceFeeDetails = new ArrayList();

        /// <summary>
        /// 最小费用组合
        /// </summary>
        protected ArrayList alMinFee = new ArrayList();

        /// <summary>
        /// 合同单位信息
        /// </summary>
        protected Neusoft.HISFC.Models.Base.PactInfo pactInfo = new Neusoft.HISFC.Models.Base.PactInfo();

        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register rInfo = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParam = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.FrameWork.Management.ControlParam myCtrl = new ControlParam();

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 门诊账户业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 支付方式信息
        /// </summary>
        protected ArrayList alPatientPayModeInfo = new ArrayList();

        /// <summary>
        /// 支付方式列表
        /// </summary>
        protected ArrayList alPayModes = new ArrayList();

        /// <summary>
        /// 分发票列表
        /// </summary>
        protected ArrayList alSplitInvoices = new ArrayList();

        /// <summary>
        /// 银行表
        /// </summary>
        protected ArrayList alBanks = new ArrayList();

        /// <summary>
        /// payMode列表查询
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper helpPayMode = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 银行列表查询
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper helpBank = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        ///最小费用列表查询
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper helpMinFee = null;

        /// <summary>
        /// 最小费用列表查询
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper helpMinFeeList = new Neusoft.FrameWork.Public.ObjectHelper();


        /// <summary>
        /// 收费按钮触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateFee FeeButtonClicked;

        /// <summary>
        /// 划价按钮触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething ChargeButtonClicked;

        /// <summary>
        /// 支付方式选择列表
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbPayMode = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();

        /// <summary>
        /// 银行选择列表
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbBank = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        
        /// <summary>
        /// 退费的时候判断是否点的取消
        /// </summary>
        protected bool isPushCancelButton = false;

        /// <summary>
        /// 是否退费调用
        /// </summary>
        protected bool isQuitFee = false;

        /// <summary>
        /// 医保可以用
        /// </summary>
        protected bool isSICanUserCardPayAll = false;

        Neusoft.HISFC.Models.Base.FT ftFeeInfo = new Neusoft.HISFC.Models.Base.FT();
        
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected Neusoft.FrameWork.Management.Transaction trans = null;

        #endregion

        #region 属性

        //{E6CD2A14-1DCB-4361-834C-9CF9B9DC669A}添加一个属性，保存按发票分组的费用明细 liuq
        /// <summary>
        /// 发票费用明细集合
        /// </summary>
        public ArrayList InvoiceFeeDetails
        {
            get { return alInvoiceFeeDetails; }
            set { alInvoiceFeeDetails = value; }
        }


        /// <summary>
        /// 退费的时候判断是否点的取消
        /// </summary>
        public bool IsPushCancelButton 
        {
            get 
            {
                return this.isPushCancelButton;
            }
            set 
            {
                this.isPushCancelButton = value;
            }
        }

        /// <summary>
        /// 是否现金冲账
        /// </summary>
        public bool IsCashPay
        {
            get
            {
                return this.isCashPay;
            }
            set
            {
                this.isCashPay = value;
            }
        }

        /// <summary>
        /// 是否退费
        /// </summary>
        public bool IsQuitFee
        {
            set
            {
                isQuitFee = value;
                if (isQuitFee)
                {
                    this.tbCharge.Enabled = false;

                }
            }
        }

        /// <summary>
        /// 数据库事务
        /// </summary>
        public Neusoft.FrameWork.Management.Transaction Trans
        {
            set
            {
                trans = value;
            }
        }

        /// <summary>
        /// 收费信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.FT FTFeeInfo
        {
            get
            {
                return this.ftFeeInfo;
            }
        }

        /// <summary>
        /// 挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            set
            {
                this.rInfo = value;
            }
        }

        /// <summary>
        /// 主发票和发票明细集合
        /// </summary>
        public ArrayList InvoiceAndDetails
        {
            set
            {
                alInvoiceAndDetails = value;
            }
            get
            {
                return alInvoiceAndDetails;
            }
        }
        
        /// <summary>
        /// 主发票集合
        /// </summary>
        public ArrayList Invoices
        {
            set
            {
                alInvoices = value;
                if (alInvoices != null)
                {
                    this.fpSplit_Sheet1.RowCount = alInvoices.Count;
                    for (int i = 0; i < alInvoices.Count; i++)
                    {
                        Balance balance = alInvoices[i] as Balance;
                        this.fpSplit_Sheet1.Cells[i, 0].Text = balance.Invoice.ID;
                        this.fpSplit_Sheet1.Cells[i, 1].Text = balance.FT.TotCost.ToString();
                        string tmp = null;
                        switch (balance.Memo)
                        {
                            case "5":
                                tmp = "总发票";
                                break;
                            case "1":
                                tmp = "自费";
                                break;
                            case "2":
                                tmp = "记帐";
                                break;
                            case "3":
                                tmp = "特殊";
                                break;
                            case "4":
                                tmp = "医保";
                                break;
                        }
                        this.fpSplit_Sheet1.Cells[i, 2].Text = tmp;
                        this.fpSplit_Sheet1.Cells[i, 2].Tag = balance.Memo;
                        this.fpSplit_Sheet1.Cells[i, 3].Text = balance.FT.OwnCost.ToString();
                        this.fpSplit_Sheet1.Cells[i, 4].Text = balance.FT.PayCost.ToString();
                        this.fpSplit_Sheet1.Cells[i, 5].Text = balance.FT.PubCost.ToString();
                        //发票主表
                        this.fpSplit_Sheet1.Rows[i].Tag = balance;
                        //发票明细
                        this.fpSplit_Sheet1.Cells[i, 0].Tag = ((ArrayList)alInvoiceDetails[i])[0] as ArrayList;
                        //{E6CD2A14-1DCB-4361-834C-9CF9B9DC669A}添加一个属性，保存按发票分组的费用明细 liuq
                        //费用明细
                        this.fpSplit_Sheet1.Cells[i, 3].Tag = ((ArrayList)InvoiceFeeDetails[i]) as ArrayList;
                    }
                }
            }
            get
            {
                return alInvoices;
            }
        }

        /// <summary>
        /// 发票明细集合
        /// </summary>
        public ArrayList InvoiceDetails
        {
            set
            {
                alInvoiceDetails = value;
            }
            get
            {
                return alInvoiceDetails;
            }
        }

        /// <summary>
        /// 费用明细集合
        /// </summary>
        public ArrayList FeeDetails
        {
            set
            {
                alFeeDetails = value;
                this.SpliteMinFee();
            }
            get
            {
                return alFeeDetails;
            }
        }

        /// <summary>
        /// 患者合同单位信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.PactInfo PactInfo
        {
            set
            {
                this.pactInfo = value;
                if (this.pactInfo.PayKind.ID == "01")//自费患者可以分票
                {
                    this.tpSplitInvoice.Show();
                }
                else
                {
                    this.tpSplitInvoice.Hide();
                }
            }
        }

        /// <summary>
        /// 自费药金额
        /// </summary>
        public decimal SelfDrugCost
        {
            set
            {
                selfDrugCost = value;
                this.tbSelfDrug.Text = selfDrugCost.ToString();
            }
        }

        /// <summary>
        /// 超标药金额
        /// </summary>
        public decimal OverDrugCost
        {
            set
            {
                overDrugCost = value;
                this.tbOverDrug.Text = overDrugCost.ToString();
            }
        }

        /// <summary>
        /// 应付金额
        /// </summary>
        public decimal OwnCost
        {
            set
            {
                ownCost = value;
                this.tbOwnCost.Text = ownCost.ToString();
            }
            get
            {
                return this.ownCost;
            }
        }

        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal PubCost
        {
            set
            {
                pubCost = value;
                this.tbTotCost.Text = pubCost.ToString();
                //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438}支付方式金额自动分配、结算判断金额相等
                //注册事件
                //this.fpPayMode_Sheet1.CellChanged -= new FarPoint.Win.Spread.SheetViewEventHandler(this.fpPayMode_Sheet1_CellChanged);
                this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Text = "统筹(医院垫付)";
                this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.Cost].Text = value.ToString();
                this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Locked = true;
            }
            get
            {
                return this.pubCost;
            }
        }

        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal PayCost
        {
            set
            {
                payCost = value;
                this.tbPayCost.Text = payCost.ToString();
                //if (this.rInfo.Pact.PayKind.ID == "02" && !this.isCashPay)
                    if ((this.rInfo.Pact.PayKind.ID == "02" || rInfo.Pact.PayKind.ID == "03") && !this.isCashPay)
             
                {
                    //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438}支付方式金额自动分配、结算判断金额相等
                    //注册事件
                    //this.fpPayMode_Sheet1.CellChanged -= new FarPoint.Win.Spread.SheetViewEventHandler(this.fpPayMode_Sheet1_CellChanged);
                    this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.PayMode].Text = "保险帐户";
                    this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.Cost].Text = value.ToString();
                    this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.PayMode].Locked = true;// modify  by jlj
                    //this.fpPayMode_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.fpPayMode_Sheet1_CellChanged);
                }
            }
            get
            {
                return this.payCost;
            }
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotCost
        {
            set
            {
                totCost = value;
                this.tbTotCost.Text = totCost.ToString();
            }
            get
            {
                return totCost;
            }
        }

        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal RealCost
        {
            set
            {
                realCost = value;

                //this.tbRealCost.Text = realCost.ToString();
            }
        }

        /// <summary>
        /// 应缴金额
        /// </summary>
        public decimal TotOwnCost
        {
            set
            {
                totOwnCost = value;
                //totOwnCost = Class.Function.DealCent(totOwnCost);
                this.tbTotOwnCost.Text = totOwnCost.ToString();
                this.tbRealCost.Text = Class.Function.DealCent(totOwnCost).ToString();
                this.tbRealCost.SelectAll();
                this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Text = "现金";

                if (this.trans != null)
                {
                    this.accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                }

                //判断是否存在门诊账户
                decimal vacancy = 0;

                int returnValue = this.accountManager.GetVacancy(this.rInfo.PID.CardNO, ref vacancy);
                if (returnValue == -1)
                {
                    MessageBox.Show(this.accountManager.Err);

                    return;
                }
                //如果存在门诊账户,并且账户余额大于0, 需要的自费金额 大于0, 那么显示院内账户支付方式
                if (returnValue > 0 && vacancy > 0 && this.TotOwnCost > 0)
                {
                    this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Text = "院内账户";
                    decimal leftOwnCost = vacancy > this.totOwnCost ? this.totOwnCost : this.totOwnCost - vacancy;
                    //自费支付金额
                    this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = (this.totOwnCost - leftOwnCost).ToString();
                    this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Locked = true;
                    //院内账户支付金额
                    this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.Cost].Text = leftOwnCost.ToString();
                }
                else
                {
                    //this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = totOwnCost.ToString();
                    this.fpPayMode_Sheet1.SetValue(0, (int)PayModeCols.Cost, totOwnCost);
                    this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Locked = true;
                }
            }

            get
            {
                return totOwnCost;
            }
        }

        /// <summary>
        /// 找零金额
        /// </summary>
        public decimal LeastCost
        {
            set
            {
                leastCost = value;
            }
        }

        #endregion

        #region 列枚举
        /// <summary>
        /// 支付方式列枚举
        /// </summary>
        protected enum PayModeCols
        {
            /// <summary>
            /// 支付方式
            /// </summary>
            PayMode = 0,
            /// <summary>
            /// 金额
            /// </summary>
            Cost = 1,
            /// <summary>
            /// 开户银行
            /// </summary>
            Bank = 2,
            /// <summary>
            /// 帐号
            /// </summary>
            Account = 3,
            /// <summary>
            /// 开据单位
            /// </summary>
            Company = 4,
            /// <summary>
            /// 支票，汇票，交易号
            /// </summary>
            PosNo = 5
        }

        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 发票预览
        /// </summary>
        private void PreViewInvoice()
        {
            int row = this.fpSplit_Sheet1.ActiveRowIndex;
            if (this.fpSplit_Sheet1.RowCount <= 0)
            {
                return;
            }

            Balance invoicePreView = this.fpSplit_Sheet1.Rows[row].Tag as Balance;
            ArrayList invoiceDetailsPreview = this.fpSplit_Sheet1.Cells[row, 0].Tag as ArrayList;
            ArrayList InvoiceFeeDetailsPreview = this.fpSplit_Sheet1.Cells[row, 3].Tag as ArrayList;
         
            string returnValue = this.managerIntegrate.QueryControlerInfo("MZ0002");
            if (returnValue == null || returnValue == string.Empty)
            {
                MessageBox.Show("没有设置发票打印参数，不能预览!");

                return;
            }

            object tempObj = null;
            returnValue = Application.StartupPath + returnValue;
            try
            {
                Assembly a = Assembly.LoadFrom(returnValue);
                Type[] types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IInvoicePrint") != null)
                    {
                        tempObj = System.Activator.CreateInstance(type);

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("初始化发票失败!" + e.Message);

                return;
            }
            if (tempObj == null)
            {
                MessageBox.Show("没有找到符合条件的发票信息!请设置!");

                return;
            }
            try
            {
                if (this.trans != null)
                {
                    ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint)tempObj).Trans = Neusoft.FrameWork.Management.PublicTrans.Trans;
                }

                ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint)tempObj).SetPrintValue(
                    this.rInfo, invoicePreView, invoiceDetailsPreview, alFeeDetails, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }

            if (tempObj.GetType().GetInterface("IPreview") != null)
            {
                System.Windows.Forms.Control temp = ((Neusoft.HISFC.BizProcess.Interface.Common.IPreview)tempObj).PreviewControl;

                if (temp != null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(temp);
                }
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl((Control)tempObj);
            }
        }

        /// <summary>
        /// 归类最小费用
        /// </summary>
        private void SpliteMinFee()
        {
            this.alMinFee = new ArrayList();

            helpMinFee.ArrayObject = this.alMinFee;

            if (this.alFeeDetails == null || this.alFeeDetails.Count <= 0)
            {
                return;
            }

            if (this.trans != null)
            {
                this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }

            foreach (FeeItemList feeItemList in alFeeDetails)
            {
                #region 2007-8-24 liuq 赋最小费用名称
                string minFeeName = string.Empty;
                #endregion
                if (this.helpMinFee.GetObjectFromID(feeItemList.Item.MinFee.ID) == null)
                {
                    NeuObject obj = new NeuObject();

                    obj.ID = feeItemList.Item.MinFee.ID;

                    if (this.helpMinFeeList.GetObjectFromID(feeItemList.Item.MinFee.ID) == null)
                    {
                        obj.Name = this.managerIntegrate.GetConstansObj("MINFEE", feeItemList.Item.MinFee.ID).Name;
                    }
                    else
                    {
                        obj.Name = this.helpMinFeeList.GetObjectFromID(feeItemList.Item.MinFee.ID).Name;
                    }

                    obj.Memo = feeItemList.FT.TotCost.ToString();
                    #region 2007-8-24 liuq 赋最小费用名称
                    minFeeName = obj.Name;
                    #endregion
                    alMinFee.Add(obj);
                }
                else
                {
                    NeuObject obj = helpMinFee.GetObjectFromID(feeItemList.Item.MinFee.ID);
                    #region 2007-8-24 liuq 赋最小费用名称
                    minFeeName = obj.Name;
                    #endregion
                    obj.Memo = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(obj.Memo) + feeItemList.FT.TotCost, 2).ToString();

                }
                #region 2007-8-24 liuq 赋最小费用名称
                feeItemList.Item.MinFee.Name = minFeeName;
                #endregion
            }

            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            }

            if (alMinFee.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Add(0, alMinFee.Count / 5 + 1);
            }

            for (int i = 0; i < alMinFee.Count; i++)
            {
                this.fpSpread1_Sheet1.Cells[(i + 1) / 5, 2 * (i % 5)].Text = (alMinFee[i] as NeuObject).Name;
                this.fpSpread1_Sheet1.Cells[(i + 1) / 5, 2 * (i % 5) + 1].Text = (alMinFee[i] as NeuObject).Memo;
            }
        }

        /// <summary>
        /// 初始化分发票信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitSplitInvoice()
        {
            string tmpCtrlValue = null;

            tmpCtrlValue = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.CANSPLIT, "0");
           
            if (tmpCtrlValue == null || tmpCtrlValue == "-1" || tmpCtrlValue == string.Empty)
            {
                MessageBox.Show("是否分发票参数没有维护，现在采用默认值: 不可分发票!");

                tmpCtrlValue = "0";
            }

            this.isCanSplit = NConvert.ToBoolean(tmpCtrlValue);

            this.rbAuto.Enabled = isCanSplit;
            this.rbMun.Enabled = isCanSplit;
            this.tbCount.Enabled = isCanSplit;
            this.btnSplit.Enabled = isCanSplit;
            this.tbDefault.Enabled = isCanSplit;

            this.splitCounts = this.controlParam.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLITCOUNTS, false, 9);

            bool isCanModifyInvoiceDate = this.controlParam.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_MODIFY_INVOICE_DATE, false, false);
            
            if (!isCanModifyInvoiceDate)//不可以修改发票日期
            {
                this.tbSplitDay.Text = "0";
                this.tbSplitDay.Enabled = false;
            }
            else
            {
                this.tbSplitDay.Text = "1";
                this.tbSplitDay.Enabled = true;
            }

            return 1;
        }

        /// <summary>
        /// 初始化farpoint,屏蔽一些热键
        /// </summary>
        private void InitFp()
        {
            InputMap im;
            im = this.fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Back, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            for (int i = 0; i < this.fpSpread1_Sheet1.ColumnCount; i++)
            {
                this.fpSpread1_Sheet1.Columns[i].Locked = true;
            }
        }

        /// <summary>
        /// 验证支付方式输入是否合法
        /// </summary>
        /// <param name="errText">错误信息</param>
        /// <param name="errRow">错误行</param>
        /// <param name="errCol">错误列</param>
        /// <returns>成功 true 错误false</returns>
        private bool IsPayModesValid(ref string errText, ref int errRow, ref int errCol)
        {
            string tempPayMode = string.Empty;
            //验证金额;
            decimal tempCost = 0;
            decimal cardPayCost = 0;//医保卡支付金额
            string tmpPayCost = string.Empty;

            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                tempPayMode = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text;
                tmpPayCost = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Text;
                if (tempPayMode == string.Empty || tmpPayCost == string.Empty)
                {
                    continue;
                }
                string tempId = helpPayMode.GetID(tempPayMode);
                if (tempId == null || tempId == string.Empty)
                {
                    errText = "支付方式输入错误!";
                    errRow = i;
                    errCol = (int)PayModeCols.PayMode;

                    return false;
                }
                if (tempPayMode == "支票" || tempPayMode == "汇票")
                {
                    if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Bank].Text == string.Empty)
                    {
                        errText = "支付方式" + tempPayMode + "没有输入银行信息";
                        errRow = i;
                        errCol = (int)PayModeCols.Bank;

                        return false;
                    }
                    if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Account].Text == string.Empty)
                    {
                        errText = "支付方式" + tempPayMode + "没有输入帐号信息";
                        errRow = i;
                        errCol = (int)PayModeCols.Account;

                        return false;
                    }
                }
                if (tempPayMode == "保险帐户" || tempPayMode == "社保卡")
                {
                    cardPayCost += NConvert.ToDecimal(
                        this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value.ToString());
                }
                try
                {
                    tempCost += NConvert.ToDecimal(
                        this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("金额输入不合法" + ex.Message);
                    errRow = i;
                    errCol = (int)PayModeCols.Account;

                    return false;
                }
            }

            //if (tempCost - this.payCost  - this.pubCost != NConvert.ToDecimal(this.tbTotOwnCost.Text))
            //{
            //    errText = "支付方式中输入的金额不等于应付金额!请验证后输入";

            //    return false;
            //}

            if (!isSICanUserCardPayAll)
            {
                if (cardPayCost > this.payCost)
                {
                    errText = "医保卡不允许支付自费部分!请验证再输入";

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 获得支付方式的集合
        /// </summary>
        /// <returns>成功 支付方式的集合 失败 null</returns>
        private ArrayList QueryBalancePays()
        {
            ArrayList balancePays = new ArrayList();
            BalancePay balancePay = null;

            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text == string.Empty)
                {
                    continue;
                }
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Text == string.Empty)
                {
                    continue;
                }
                if (NConvert.ToDecimal
                    (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) == 0)
                {
                    continue;
                }
                balancePay = new BalancePay();

                balancePay.PayType.Name = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text;
                balancePay.PayType.ID = helpPayMode.GetID(balancePay.PayType.Name);
                if (balancePay.PayType.ID == null || balancePay.PayType.ID.ToString() == string.Empty)
                {
                    return null;
                }
                //balancePay.FT.TotCost = totOwnCost; // NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value.ToString());
                balancePay.FT.TotCost = NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value.ToString());
                if (balancePay.PayType.Name == "现金")
                {
                    balancePay.FT.RealCost = Class.Function.DealCent(balancePay.FT.TotCost);
                }
                else
                {
                    balancePay.FT.RealCost = balancePay.FT.TotCost;
                }
                balancePay.Bank.Name = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Bank].Text;
                balancePay.Bank.ID = helpBank.GetID(balancePay.Bank.Name);
                balancePay.Bank.Account = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Account].Text;
                if (balancePay.PayType.Name == "支票" || balancePay.PayType.Name == "汇票")
                {
                    balancePay.Bank.InvoiceNO = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PosNo].Text;
                }
                else
                {
                    balancePay.POSNO = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PosNo].Text;
                }
                if (balancePay.PayType.ID.ToString() == "CA")
                {
                    balancePay.FT.RealCost = Neusoft.HISFC.Components.OutpatientFee.Class.Function.DealCent(balancePay.FT.RealCost);
                }
                else
                {
                    balancePay.FT.RealCost = balancePay.FT.RealCost;
                }
                balancePays.Add(balancePay);
            }

            return balancePays;
        }

        /// <summary>
        /// 验证分发票数据是否合法
        /// </summary>
        /// <returns>成功 true 失败 false</returns>
        private bool IsSplitInvoicesValid()
        {
            decimal tempTotCost = 0;

            for (int i = 0; i < this.fpSplit_Sheet1.RowCount; i++)
            {
                if (this.fpSplit_Sheet1.Cells[i, 2].Text == "总发票")
                {
                    continue;
                }
                try
                {
                    //tempTotCost += NConvert.ToDecimal(this.fpSplit_Sheet1.Cells[i, 1].Text);
                    //张俊义修改
                    tempTotCost += NConvert.ToDecimal(this.fpSplit_Sheet1.Cells[i, 3].Text) + NConvert.ToDecimal(this.fpSplit_Sheet1.Cells[i, 4].Text) + NConvert.ToDecimal(this.fpSplit_Sheet1.Cells[i, 5].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("金额输入不合法!" + ex.Message);

                    return false;
                }
            }

            if (Neusoft.FrameWork.Public.String.FormatNumber(tempTotCost, 2) != this.totCost)
            {
                MessageBox.Show("分发票金额与总金额不符!请重新分配!");

                return false;
            }

            return true;
        }

        /// <summary>
        /// 获得分发票信息
        /// </summary>
        /// <returns>成功 分发票信息 失败 null</returns>
        protected ArrayList QuerySplitInvoices()
        {
            NeuObject obj = null;
            ArrayList objs = new ArrayList();

            if (this.pactInfo.ID == "01")//自费分票
            {
                for (int i = 0; i < this.fpSplit_Sheet1.RowCount; i++)
                {
                    obj = new NeuObject();
                    obj.ID = i.ToString();
                    obj.User01 = this.fpSplit_Sheet1.Cells[i, 1].Text;
                    objs.Add(obj);
                }
            }
            else //公费和医保
            {
                obj = new NeuObject();
                obj.User01 = ownCost.ToString();
                obj.User02 = payCost.ToString();
                obj.User03 = pubCost.ToString();
                objs.Add(obj);
            }

            return objs;
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <returns>成功 ture 失败 false</returns>
        private bool ComputCost()
        {
            decimal tmpCost = 0;
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                tmpCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                if (tmpCost > NConvert.ToDecimal(this.tbTotOwnCost.Text))
                {
                    MessageBox.Show("单项金额不能大于可拆分自费金额!");
                    this.fpPayMode.Focus();
                    this.fpPayMode_Sheet1.SetActiveCell(i, (int)PayModeCols.Cost, false);

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 初始化银行信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitBanks()
        {
            lbBank.AddItems(alBanks);
            Controls.Add(lbBank);
            lbBank.Hide();
            lbBank.BorderStyle = BorderStyle.FixedSingle;
            lbBank.BringToFront();
            lbBank.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbBank_SelectItem);
           
            return 1;
        }

        /// <summary>
        /// 初始化支付方式信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitPayMode()
        {
            ArrayList alPayModesClone = (ArrayList)alPayModes.Clone();
            NeuObject objCA = null;

            foreach (NeuObject obj in alPayModesClone)
            {
                if (obj.Name == "现金")
                {
                    objCA = obj;
                }
            }

            alPayModesClone.Remove(objCA);

            if (this.trans != null) 
            {
                this.accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }

            //判断是否存在门诊账户
            decimal vacancy = 0;

            int returnValue = this.accountManager.GetVacancy(this.rInfo.PID.CardNO, ref vacancy);
            if (returnValue == -1) 
            {
                MessageBox.Show(this.accountManager.Err);

                return -1;
            }
            //如果存在门诊账户,并且账户余额大于0, 需要的自费金额 大于0, 那么显示院内账户支付方式
            if (returnValue > 0 && vacancy > 0 && this.TotOwnCost > 0)
            {
                this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Text = "院内账户";
            }
            else//否则去掉门诊账户支付方式的选择内容
            {
                foreach (NeuObject obj in alPayModesClone)
                {
                    if (obj.Name == "院内账户")
                    {
                        objCA = obj;
                    }
                }
            }
            alPayModesClone.Remove(objCA);

            lbPayMode.AddItems(alPayModesClone);
            Controls.Add(lbPayMode);
            lbPayMode.Hide();
            lbPayMode.BorderStyle = BorderStyle.FixedSingle;
            lbPayMode.BringToFront();
            lbPayMode.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbPayMode_SelectItem);
            //this.fpPayMode_Sheet1.CellChanged -=new SheetViewEventHandler(fpPayMode_Sheet1_CellChanged);
            this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Text = "现金";
            this.fpPayMode_Sheet1.Cells[1, (int)PayModeCols.PayMode].Text = "借记卡";
            this.fpPayMode_Sheet1.Cells[2, (int)PayModeCols.PayMode].Text = "信用卡";
            this.fpPayMode_Sheet1.Cells[3, (int)PayModeCols.PayMode].Text = "支票";
            //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438} //调整下显示顺序
            this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.PayMode].Text = "保险帐户";
            this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Text = "统筹(医院垫付)";
            this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.PayMode].ForeColor = Color.Blue;
            this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].ForeColor = Color.Blue;
            this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Locked = true;
            this.fpPayMode_Sheet1.Cells[1, (int)PayModeCols.PayMode].Locked = true;
            this.fpPayMode_Sheet1.Cells[2, (int)PayModeCols.PayMode].Locked = true;
            this.fpPayMode_Sheet1.Cells[3, (int)PayModeCols.PayMode].Locked = true;
            this.fpPayMode_Sheet1.Cells[4, (int)PayModeCols.PayMode].Locked = true;
            this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Locked = true;
            //this.fpPayMode_Sheet1.CellChanged += new SheetViewEventHandler(fpPayMode_Sheet1_CellChanged);

            //bool isSocialCard = this.controlParam.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.SOCIAL_CARD_DISPLAY, false, false);

            //if (isSocialCard)
            //{
            //    this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Text = "社保卡";
            //    this.fpPayMode_Sheet1.Cells[5, (int)PayModeCols.PayMode].Locked = true;
            //}

            return 1;
        }

        /// <summary>
        /// 设置位置
        /// </summary>
        private void SetLocation()
        {
            if (this.fpPayMode_Sheet1.ActiveColumnIndex == (int)PayModeCols.PayMode)
            {
                Control cell = this.fpPayMode.EditingControl;
                lbPayMode.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4,
                    this.panel1.Location.Y + this.tabControl1.Location.Y + this.fpPayMode.Location.Y + cell.Location.Y + cell.Height * 2 + SystemInformation.Border3DSize.Height * 2);
                lbPayMode.Size = new Size(cell.Width + 50 + SystemInformation.Border3DSize.Width * 2, 150);
                if (lbPayMode.Location.Y + lbPayMode.Height > this.fpPayMode.Location.Y + this.fpPayMode.Height)
                {
                    lbPayMode.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4,
                        this.panel1.Location.Y + this.tabControl1.Location.Y + this.fpPayMode.Location.Y + cell.Location.Y + cell.Height * 2 + SystemInformation.Border3DSize.Height * 2
                        - lbPayMode.Size.Height - cell.Height);
                }
            }
            if (this.fpPayMode_Sheet1.ActiveColumnIndex == (int)PayModeCols.Bank)
            {
                Control cell = this.fpPayMode.EditingControl;
                lbBank.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4,
                    this.panel1.Location.Y + this.tabControl1.Location.Y + this.fpPayMode.Location.Y + cell.Location.Y + cell.Height * 2 + SystemInformation.Border3DSize.Height * 2);
                lbBank.Size = new Size(cell.Width + 200 + SystemInformation.Border3DSize.Width * 2, 150);
                if (lbBank.Location.Y + lbBank.Height > this.fpPayMode.Location.Y + this.fpPayMode.Height)
                {
                    lbBank.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4,
                        this.panel1.Location.Y + this.tabControl1.Location.Y + this.fpPayMode.Location.Y + cell.Location.Y + cell.Height * 2 + SystemInformation.Border3DSize.Height * 2
                        - lbBank.Size.Height - cell.Height);
                }
            }
        }

        /// <summary>
        /// 支付方式的回车
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessPayMode()
        {
            int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
            if (currRow < 0)
            {
                return 0;
            }
            NeuObject item = null;

            int returnValue = lbPayMode.GetSelectedItem(out item);
            if (returnValue == -1)
            {
                return -1;
            }
            if (item == null)
            {
                return -1;
            }

            fpPayMode_Sheet1.SetValue(currRow, (int)PayModeCols.PayMode, item.Name);
            fpPayMode.StopCellEditing();
            decimal nowCost = 0;
            decimal currCost = 0;
            bool isOnlyCash = true;
            
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                }
            }

            currCost = NConvert.ToDecimal(this.tbTotOwnCost.Text) - nowCost;
            this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = currCost.ToString();

            nowCost = 0;
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "现金")
                    {
                        isOnlyCash = false;
                    }
                    if (i == currRow)
                    {
                        continue;
                    }

                    nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                }
            }

            if (isOnlyCash)
            {
                currCost = this.TotOwnCost - nowCost;
                this.tbTotOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(TotOwnCost, 2).ToString();
            }
            else
            {
                currCost = this.realCost - nowCost;
                this.tbTotOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(realCost, 2).ToString();
            }

            this.fpPayMode_Sheet1.Cells[currRow, (int)PayModeCols.Cost].Value = currCost;

            this.lbPayMode.Visible = false;
            
            return 1;
        }

        /// <summary>
        /// 处理银行信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessPayBank()
        {
            if (lbBank.Visible == false)
            {
                return -1;
            }
            int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
            if (currRow < 0)
            {
                return 0;
            }
            NeuObject item = null;
            int returnValue = lbBank.GetSelectedItem(out item);
            if (returnValue == -1)
            {
                return -1;
            }
            if (item == null)
            {
                return -1;
            }

            fpPayMode.StopCellEditing();
            fpPayMode_Sheet1.SetValue(currRow, (int)PayModeCols.Bank, item.Name);
            this.lbBank.Visible = false;

            return 1;
        }

        #endregion

        /// <summary>
        /// 控制焦点
        /// </summary>
        public void SetControlFocus()
        {
            this.panel1.Focus();
            this.groupBox2.Focus();
            this.tbRealCost.Focus();
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            //初始化FarPoint信息
            this.InitFp();

            //初始化支付方式信息{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //alPayModes = Neusoft.HISFC.Models.Fee.EnumPayTypeService.List();
            alPayModes = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
            if (alPayModes == null || alPayModes.Count <= 0)
            {
                MessageBox.Show("获取支付方式错误");

                return -1;
            }
            this.InitPayMode();
            
            //初始化银行信息
            if (trans != null)
            {
                this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }
            alBanks = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            if (alBanks == null || alBanks.Count <= 0)
            {
                MessageBox.Show("获取银行列表失败!");

                return -1;
            }
            InitBanks();

            helpPayMode.ArrayObject = alPayModes;
            helpBank.ArrayObject = alBanks;

            //初始化分发票信息
            this.InitSplitInvoice();

            //初始化最小费用列表
            ArrayList alMinFeeList = this.managerIntegrate.GetConstantList("MINFEE");
            if (alMinFeeList != null)
            {
                this.helpMinFeeList.ArrayObject = alMinFeeList;
            }

            string tempControlValue = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.CANUSEMCARND, "0");

            this.isSICanUserCardPayAll = NConvert.ToBoolean(tempControlValue);

            string fpVisible = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.MINFEE_DISPLAY_WHENFEE, "0");        

            this.fpSpread1.Visible = NConvert.ToBoolean(fpVisible);

            string modifyDate = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.MODIFY_INVOICE_PRINTDATE, "0");

            this.isModifyDate = NConvert.ToBoolean(modifyDate);

            if (this.isModifyDate == true)
            {
                this.dateTimePicker1.Enabled = true;
            }
            else
            {
                this.dateTimePicker1.Enabled = false;
            }

            this.isDisplayCashOnly = NConvert.ToBoolean(this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.CASH_ONLY_WHENFEE, "0"));

            this.helpMinFee = new Neusoft.FrameWork.Public.ObjectHelper();

            return 1;
        }

        /// <summary>
        /// 收费保存
        /// </summary>
        /// <returns>成功 ture 失败 false</returns>
        public bool SaveFee()
        {
            string errText = string.Empty;
            int errRow = 0, errCol = 0;

            if (!this.IsPayModesValid(ref errText, ref errRow, ref errCol))
            {
                MessageBox.Show(errText, "提示");
                this.fpPayMode.Focus();
                this.fpPayMode_Sheet1.SetActiveCell(errRow, errCol, false);

                return false;
            }

            alPatientPayModeInfo = QueryBalancePays();
            if (alPatientPayModeInfo == null)
            {
                MessageBox.Show("获得支付方式信息出错!", "提示");

                return false;
            }
            if (!this.IsSplitInvoicesValid())
            {
                this.fpSplit.Focus();
                
                return false;
            }

            //ArrayList alTempInvoices = new ArrayList();
            //ArrayList alTempInvoiceDetals = new ArrayList();
            //ArrayList alTempInvoiceDetailsSec = new ArrayList();
            //Balance invoiceTemp = new Balance();

            //for (int i = 0; i < this.fpSplit_Sheet1.RowCount; i++)
            //{
            //    invoiceTemp = this.fpSplit_Sheet1.Rows[i].Tag as Balance;
            //    alTempInvoices.Add(invoiceTemp);
            //    ArrayList tempArrayList = this.fpSplit_Sheet1.Cells[i, 0].Tag as ArrayList;
            //    alTempInvoiceDetailsSec.Add(tempArrayList);
            //}

            //alTempInvoiceDetals.Add(alTempInvoiceDetailsSec);

            //this.FeeButtonClicked(alPatientPayModeInfo, alTempInvoices, alTempInvoiceDetals);

            ArrayList alTempInvoices = new ArrayList();
            ArrayList alTempInvoiceDetals = new ArrayList();
            ArrayList alTempInvoiceDetailsSec = new ArrayList();
            ArrayList alTempInvoiceFeeItemDetals = new ArrayList();
            ArrayList alTempInvoiceFeeItemDetalsSec = new ArrayList();
            Balance invoiceTemp = new Balance();

            for (int i = 0; i < this.fpSplit_Sheet1.RowCount; i++)
            {
                invoiceTemp = this.fpSplit_Sheet1.Rows[i].Tag as Balance;
                alTempInvoices.Add(invoiceTemp);
                ArrayList tempArrayListTempInvoiceDetails = this.fpSplit_Sheet1.Cells[i, 0].Tag as ArrayList;
                alTempInvoiceDetailsSec.Add(tempArrayListTempInvoiceDetails);
                #region liuq 2007-8-27 追加对应费用明细
                ArrayList tempArrayListTempInvoiceFeeItemDetals = this.fpSplit_Sheet1.Cells[i, 3].Tag as ArrayList;
                alTempInvoiceFeeItemDetalsSec.Add(tempArrayListTempInvoiceFeeItemDetals);
                #endregion
            }

            alTempInvoiceDetals.Add(alTempInvoiceDetailsSec);
            #region liuq 2007-8-27 追加对应费用明细
            alTempInvoiceFeeItemDetals.Add(alTempInvoiceFeeItemDetalsSec);
            #endregion
            this.FeeButtonClicked(alPatientPayModeInfo, alTempInvoices, alTempInvoiceDetals, alTempInvoiceFeeItemDetals);

            return true;
        }

        /// <summary>
        /// 划价保存
        /// </summary>
        /// <returns>成功 true 失败 false</returns>
        public bool SaveCharge()
        {
            this.ChargeButtonClicked();

            return true;
        }

        #endregion

        #region 事件

        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void frmDealBalance_Load(object sender, EventArgs e)
        {
            this.tbRealCost.Select();
            this.tbRealCost.Focus();
            this.tbRealCost.SelectAll();
            this.tbLeast.Text = "0";
            leastCost = 0;
        }

        /// <summary>
        /// 点击收费按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbFee_Click(object sender, EventArgs e)
        {  
            this.tbFee.Enabled = false;
            if (!this.SaveFee())
            {
                this.tbFee.Enabled = true;

                return;
            }
            this.tbFee.Enabled = true;
            this.tbRealCost.Focus();
            
            this.Close();
        }

        /// <summary>
        /// 划价保存按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbCharge_Click(object sender, EventArgs e)
        {
            this.tbCharge.Enabled = false;
            this.SaveCharge();
            this.tbCharge.Enabled = true;
            this.tbRealCost.Focus();
            this.Close();
        }

        /// <summary>
        /// 点击取消按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbCancel_Click(object sender, EventArgs e)
        {
            isPushCancelButton = true;
            this.tbRealCost.Focus();
            this.Close();
        }

        /// <summary>
        /// 点击分发票默认按钮触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbDefault_Click(object sender, EventArgs e)
        {
            Invoices = this.alInvoices;
        }

        /// <summary>
        /// 按键触发
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                this.panel1.Focus();
                this.groupBox2.Focus();
                this.tbRealCost.Focus();
                this.tbRealCost.SelectAll();
            }
            if (keyData == Keys.Add)
            {
                this.tbFee.Enabled = false;
                if (!this.SaveFee())
                {
                    this.tbFee.Enabled = true;
                    return false;
                }
                this.tbFee.Enabled = true;
                this.tbRealCost.Focus();
                this.Close();
            }
            if (keyData == Keys.F5)
            {
                this.tabControl1.SelectedTab = this.tpSplitInvoice;

                this.tpSplitInvoice.Focus();
                this.tbCount.Focus();
            }
            if (keyData == Keys.F6)
            {
                this.panel1.Focus();
                this.tabControl1.Focus();
                this.tabControl1.SelectedTab = this.tpPayMode;
                this.tpPayMode.Focus();
                this.fpPayMode.Focus();
                this.fpPayMode_Sheet1.ActiveRowIndex = 1;
                this.fpPayMode_Sheet1.SetActiveCell(1, (int)PayModeCols.Cost, false);
            }
            if (keyData == Keys.Escape)
            {

                if (lbPayMode.Visible)
                {
                    lbPayMode.Visible = false;
                    this.fpPayMode.StopCellEditing();
                }
                else if (lbBank.Visible)
                {
                    lbBank.Visible = false;
                    this.fpPayMode.StopCellEditing();
                }
                else
                {
                    this.tbRealCost.Focus();
                    this.isPushCancelButton = true;
                    this.Close();
                }
            }
            if (this.fpPayMode.ContainsFocus)
            {
                if (keyData == Keys.Up)
                {
                    if (lbPayMode.Visible)
                    {
                        lbPayMode.PriorRow();
                    }
                    else if (lbBank.Visible)
                    {
                        lbBank.PriorRow();
                    }
                    else
                    {
                        int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                        if (currRow > 0)
                        {
                            this.fpPayMode_Sheet1.ActiveRowIndex = currRow - 1;
                            if (this.fpPayMode_Sheet1.Cells[currRow - 1, (int)PayModeCols.PayMode].Locked == true)
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow - 1, (int)PayModeCols.Cost);
                            }
                            else
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow - 1, (int)PayModeCols.PayMode);
                            }
                        }
                    }
                }
                if (keyData == Keys.Back)
                {
                    int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                    int currCol = this.fpPayMode_Sheet1.ActiveColumnIndex;
                    if (this.fpPayMode_Sheet1.Cells[currRow, currCol].Text == string.Empty)
                    {
                        if (currCol == 0)
                        {

                            this.fpPayMode_Sheet1.SetActiveCell(currRow - 1, 0, false);
                        }
                        else
                        {
                            this.fpPayMode_Sheet1.SetActiveCell(currRow, currCol - 1, false);
                        }
                    }
                }
                if (keyData == Keys.Down)
                {
                    if (lbPayMode.Visible)
                    {
                        lbPayMode.NextRow();
                    }
                    else if (lbBank.Visible)
                    {
                        lbBank.NextRow();
                    }
                    else
                    {
                        int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;

                        if (currRow <= 8)
                        {
                            this.fpPayMode_Sheet1.ActiveRowIndex = currRow + 1;
                            if (this.fpPayMode_Sheet1.Cells[currRow + 1, (int)PayModeCols.PayMode].Locked == true)
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.Cost);
                            }
                            else
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.PayMode);
                            }
                        }
                    }

                }
                if (keyData == Keys.Enter)
                {
                    int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                    int currCol = this.fpPayMode_Sheet1.ActiveColumnIndex;
                    this.fpPayMode.StopCellEditing();
                    if (currCol == (int)PayModeCols.PayMode)
                    {
                        ProcessPayMode();
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Cost, false);

                    }
                    if (currCol == (int)PayModeCols.Cost)
                    {
                        decimal cost = NConvert.ToDecimal(
                            this.fpPayMode_Sheet1.Cells[currRow, (int)PayModeCols.Cost].Value);
                        if (cost < 0)
                        {
                            MessageBox.Show("金额不能小于零");
                            this.fpPayMode.Focus();
                            this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Cost, false);

                            return false;
                        }
                        else
                        {
                            decimal tempOwnCost = NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Value);

                            if (!ComputCost())
                            {
                                return false;
                            }
                            if (currRow == 0)//现金
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.Cost, false);
                            }
                            else
                            {
                                if (this.fpPayMode_Sheet1.Cells[currRow, (int)PayModeCols.PayMode].Text != "支票")
                                {
                                    this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.Cost, false);
                                }
                                else
                                {
                                    this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Bank, false);
                                }
                            }
                        }
                    }
                    if (currCol == (int)PayModeCols.Bank)
                    {
                        ProcessPayBank();
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Account, false);
                    }
                    if (currCol == (int)PayModeCols.Account)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Company, false);
                    }
                    if (currCol == (int)PayModeCols.Company)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.PosNo, false);
                    }
                    if (currCol == (int)PayModeCols.PosNo)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.Cost, false);
                    }

                }
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbRealCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal tempCost = 0;
                decimal cashCost = 0;
                for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
                {
                    string tmpPayMode = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text;
                    decimal tmpCashCost = 0;
                    if (tmpPayMode == "现金")
                    {
                        tmpCashCost = Neusoft.FrameWork.Public.String.FormatNumber(
                            NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value), 2);
                    }
                    cashCost += tmpCashCost;
                }
                try
                {
                    tempCost = NConvert.ToDecimal(this.tbRealCost.Text) - cashCost;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的数字不合法！请验证输入" + ex.Message);
                    this.tbRealCost.Text = string.Empty;
                    this.tbRealCost.Focus();

                    return;
                }

                if (tempCost < 0)
                {
                    DialogResult result = MessageBox.Show("您输入的实付金额小于应收现金,是否重新输入?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        this.tbRealCost.SelectAll();
                        this.tbRealCost.Focus();
                        return;
                    }

                }

                this.tbLeast.Text = tempCost.ToString();

                //this.frmDisplay.RInfo = this.rInfo;
                Neusoft.HISFC.Models.Base.FT feeInfo = new Neusoft.HISFC.Models.Base.FT();
                feeInfo.TotCost = totCost;
                feeInfo.OwnCost = ownCost;
                feeInfo.PayCost = payCost;
                feeInfo.PubCost = pubCost;
                feeInfo.BalancedCost = NConvert.ToDecimal(tbTotOwnCost.Text);
                feeInfo.SupplyCost = totOwnCost;
                feeInfo.RealCost = NConvert.ToDecimal(this.tbRealCost.Text);
                feeInfo.ReturnCost = tempCost;
                this.ftFeeInfo = feeInfo;
                //this.frmDisplay.FeeInfo = feeInfo;
                //this.frmDisplay.FpPayMode = this.fpPayMode;
                //frmDisplay.SetValue();

                string tmpContrlValue = "0";

                tmpContrlValue = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.ENTER_TO_FEE, "0");

                if (tmpContrlValue == "1")
                {
                    this.tbFee.Enabled = false;
                    if (!this.SaveFee())
                    {
                        this.tbFee.Enabled = true;
                        return;
                    }
                    this.tbFee.Enabled = true;
                    this.tbRealCost.Focus();
                    this.Close();
                }
                else
                {
                    tbFee.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpSplit_CellDoubleClick(object sender, CellClickEventArgs e)
        {
           // this.PreViewInvoice();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int count = 0;
                try
                {
                    count = Convert.ToInt32(this.tbCount.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入分票得数量不合法" + ex.Message);
                    this.tbCount.Focus();
                    this.tbCount.SelectAll();

                    return;
                }
                if (count > this.splitCounts)
                {
                    MessageBox.Show("当前可分发票数不能大于: " + splitCounts.ToString());
                    this.tbCount.Focus();
                    this.tbCount.SelectAll();

                    return;
                }

                this.tbSplitDay.Focus();
                this.tbSplitDay.SelectAll();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbSplitDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int count = 0;
                try
                {
                    count = Convert.ToInt32(this.tbSplitDay.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入间隔天数不合法" + ex.Message);
                    this.tbSplitDay.Focus();
                    this.tbSplitDay.SelectAll();
                    return;
                }
                if (count > 999)
                {
                    MessageBox.Show("间隔天数不能大于999天!");
                    this.tbSplitDay.Focus();
                    this.tbSplitDay.SelectAll();
                    return;
                }

                btnSplit.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpPayMode_EditModeOn(object sender, EventArgs e)
        {
            fpPayMode.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            SetLocation();
            if (fpPayMode_Sheet1.ActiveColumnIndex != (int)PayModeCols.PayMode)
            {
                lbPayMode.Visible = false;
            }
            if (fpPayMode_Sheet1.ActiveColumnIndex != (int)PayModeCols.Bank)
            {
                lbBank.Visible = false;
            }
        }

        void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpPayMode_EditChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)PayModeCols.PayMode)
            {
                string text = fpPayMode_Sheet1.ActiveCell.Text;
                lbPayMode.Filter(text);
                if (!lbPayMode.Visible)
                {
                    lbPayMode.Visible = true;
                }
            }
            if (e.Column == (int)PayModeCols.Bank)
            {
                string text = fpPayMode_Sheet1.ActiveCell.Text;
                lbBank.Filter(text);
                if (!lbBank.Visible)
                {
                    lbBank.Visible = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fpPayMode_Sheet1_CellChanged(object sender, SheetViewEventArgs e)
        {
            string tempString = this.fpPayMode_Sheet1.Cells[e.Row, (int)PayModeCols.PayMode].Text;
            if (tempString == string.Empty)
            {
                for (int i = 0; i < this.fpPayMode_Sheet1.Columns.Count; i++)
                {
                    this.fpPayMode_Sheet1.Cells[e.Row, i].Text = string.Empty;
                }
            }
            bool isOnlyCash = true;
            decimal nowCost = 0;
            //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438}支付方式金额自动分配、结算判断金额相等
            //不存在支付方式金额不等再进行结算问题
            bool isReturnZero = false;

            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "现金"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value)>0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "保险帐户"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value)>0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "社保卡"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value)>0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "统筹(医院垫付)"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value)
                        > 0)
                    {
                        isOnlyCash = false;
                        nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                    }
                }
            }
            if (isOnlyCash)
            {
                this.tbTotOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(totOwnCost, 2).ToString();
                //this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = totOwnCost.ToString();
                this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = Class.Function.DealCent(totOwnCost).ToString();
            }
            else
            {
                if (realCost - nowCost < 0)
                {
                    this.fpPayMode_Sheet1.Cells[e.Row, (int)PayModeCols.Cost].Value = 0;
                    this.fpPayMode_Sheet1.SetActiveCell(e.Row, (int)PayModeCols.Cost, false);
                    nowCost = 0;
                    //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438}支付方式金额自动分配、结算判断金额相等
                    //是否进行过归零操作
                    isReturnZero = true;
                }
                this.tbTotOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumber(realCost,2).ToString();
                this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Value = Class.Function.DealCent(realCost - nowCost);

                if (this.isDisplayCashOnly)
                {
                    //{0F169460-7FF9-4b76-A22E-C2D0A1DCD438}支付方式金额自动分配、结算判断金额相等
                    //归零操作重新计算nowCost
                    if (isReturnZero)
                    {
                        for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
                        {
                            if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                            {
                                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "现金"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) > 0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "保险帐户"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) > 0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "社保卡"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) > 0
                        && this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != "统筹(医院垫付)"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value)
                        > 0)
                                {
                                    isOnlyCash = false;
                                    nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                                }
                            }
                        }
                    }
                    this.tbRealCost.Text = Class.Function.DealCent(realCost - nowCost).ToString();
                }
            }
            
            if (this.isDisplayCashOnly)
            {
                this.tbRealCost.Text = Class.Function.DealCent(realCost - nowCost).ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.fpSplit_Sheet1.RowCount; i++)
            {
                if (this.fpSplit_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSplit_Sheet1.Rows[i].Tag is Balance)
                    {
                        Balance invoice = this.fpSplit_Sheet1.Rows[i].Tag as Balance;
                        invoice.PrintTime = this.dateTimePicker1.Value;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int lbBank_SelectItem(Keys key)
        {
            ProcessPayBank();
            fpPayMode.Focus();
            fpPayMode_Sheet1.SetActiveCell(fpPayMode_Sheet1.ActiveRowIndex, (int)PayModeCols.Account, true);

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int lbPayMode_SelectItem(Keys key)
        {
            ProcessPayMode();
            fpPayMode.Focus();
            fpPayMode_Sheet1.SetActiveCell(fpPayMode_Sheet1.ActiveRowIndex, (int)PayModeCols.Cost, true);

            return 1;
        }

        /// <summary>
        /// 分发票按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSplit_Click(object sender, EventArgs e)
        {
            int row = this.fpSplit_Sheet1.ActiveRowIndex;
            if (this.fpSplit_Sheet1.RowCount <= 0)
            {
                return;
            }

            string tempType = this.fpSplit_Sheet1.Cells[row, 2].Tag.ToString();

            if (tempType != "1")//只有自费发票可以分票
            {
                return;
            }
            string beginInvoiceNo = this.fpSplit_Sheet1.Cells[row, 0].Text;
            string beginRealInvoiceNo = "";
            Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice = null;
            ArrayList invoiceDetails = null;
            try
            {
                invoice = this.fpSplit_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Fee.Outpatient.Balance;
                beginRealInvoiceNo = invoice.PrintedInvoiceNO;
                invoiceDetails = this.fpSplit_Sheet1.Cells[row, 0].Tag as ArrayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            InvoicePrint.ucSplitInvoice split = new Neusoft.HISFC.Components.OutpatientFee.InvoicePrint.ucSplitInvoice();

            int count = 0;
            try
            {
                count = Convert.ToInt32(this.tbCount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入分票得数量不合法" + ex.Message);
                this.tbCount.Focus();
                this.tbCount.SelectAll();
                return;
            }
            if (count > this.splitCounts)
            {
                MessageBox.Show("当前可分发票数不能大于: " + splitCounts.ToString());
                this.tbCount.Focus();
                this.tbCount.SelectAll();
                return;
            }
            if (count <= 0)
            {
                MessageBox.Show("当前可分发票数不能小于或等于0");
                this.tbCount.Focus();
                this.tbCount.SelectAll();
                return;
            }
            int days = 0;
            try
            {
                days = Convert.ToInt32(this.tbSplitDay.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入间隔天数不合法" + ex.Message);
                this.tbSplitDay.Focus();
                this.tbSplitDay.SelectAll();
                return;
            }
            if (days > 999)
            {
                MessageBox.Show("间隔天数不能大于999天!");
                this.tbSplitDay.Focus();
                this.tbSplitDay.SelectAll();
                return;
            }
            string invoiceNoType = this.controlParam.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, true, "0");

            if (invoiceNoType == "2" && this.fpSplit_Sheet1.RowCount > 1)
            {
                MessageBox.Show("已经存在分票记录,如果要继续分票,请点击默认按钮,重新分配!");
                this.tbSplitDay.Focus();
                this.tbSplitDay.SelectAll();

                return;
            }

            this.btnSplit.Focus();
            split.Count = count;
            split.Days = days;
            split.InvoiceType = tempType;
            split.InvoiceNoType = invoiceNoType;
            split.BeginInvoiceNo = beginInvoiceNo;
            split.BeginRealInvoiceNo = beginRealInvoiceNo;
            split.Invoice = invoice;
            split.InvoiceDetails = invoiceDetails;
            split.AddInvoiceUnits(count, this.rbAuto.Checked ? "1" : "0");
            split.IsAuto = this.rbAuto.Checked;
            Form frmTemp = new Form();
            split.Dock = DockStyle.Fill;
            frmTemp.Controls.Add(split);
            frmTemp.Text = "分发票";
            frmTemp.WindowState = FormWindowState.Maximized;
            frmTemp.ShowDialog(this);

            if (!split.IsConfirm)
            {
                return;
            }

            this.dateTimePicker1.Enabled = false;//分过发票之后不允许再通过收费界面修改发票日期

            ArrayList splitInvoices = split.SplitInvoices;
            ArrayList splitInvoiceDetails = split.SplitInvoiceDetails;


            this.fpSplit_Sheet1.Rows.Add(row + 1, splitInvoices.Count);
            for (int i = 0; i < splitInvoices.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.Balance invoiceTemp = splitInvoices[i] as Neusoft.HISFC.Models.Fee.Outpatient.Balance;
                this.fpSplit_Sheet1.Cells[row + 1 + i, 0].Text = invoiceTemp.Invoice.ID;
                this.fpSplit_Sheet1.Cells[row + 1 + i, 1].Text = invoiceTemp.FT.TotCost.ToString();
                string tmp = null;
                switch (invoiceTemp.Memo)
                {
                    case "5":
                        tmp = "总发票";
                        break;
                    case "1":
                        tmp = "自费";
                        break;
                    case "2":
                        tmp = "记帐";
                        break;
                    case "3":
                        tmp = "特殊";
                        break;
                }
                this.fpSplit_Sheet1.Cells[row + 1 + i, 2].Text = tmp;
                this.fpSplit_Sheet1.Cells[row + 1 + i, 2].Tag = invoiceTemp.Memo;
                this.fpSplit_Sheet1.Cells[row + 1 + i, 3].Text = invoiceTemp.FT.OwnCost.ToString();
                this.fpSplit_Sheet1.Cells[row + 1 + i, 4].Text = invoiceTemp.FT.PayCost.ToString();
                this.fpSplit_Sheet1.Cells[row + 1 + i, 5].Text = invoiceTemp.FT.PubCost.ToString();
                this.fpSplit_Sheet1.Rows[row + 1 + i].Tag = invoiceTemp;
                this.fpSplit_Sheet1.Cells[row + 1 + i, 0].Tag = ((ArrayList)splitInvoiceDetails[i]) as ArrayList;
            }
            this.fpSplit_Sheet1.Rows.Remove(row, 1);
            for (int i = row + splitInvoices.Count; i < this.fpSplit_Sheet1.RowCount; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.Balance tempInvoice =
                    this.fpSplit_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.Outpatient.Balance;

                string nextInvoiceNo = ""; string nextRealInvoiceNo = ""; string errText = "";

                if (invoiceNoType == "2")//普通模式需要Trans支持
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    int iReturn = this.feeIntegrate.GetNextInvoiceNO(invoiceNoType, tempInvoice.Invoice.ID, tempInvoice.PrintedInvoiceNO, ref nextInvoiceNo, ref nextRealInvoiceNo, splitInvoices.Count - 1, ref errText);
                    if (iReturn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return;
                    }

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();//因为此时不一定插入数据库,所以回滚,保持发票不跳号
                }
                else
                {

                    int iReturn = this.feeIntegrate.GetNextInvoiceNO(invoiceNoType, tempInvoice.Invoice.ID, tempInvoice.PrintedInvoiceNO, ref nextInvoiceNo, ref nextRealInvoiceNo, splitInvoices.Count - 1, ref errText);
                    if (iReturn < 0)
                    {
                        MessageBox.Show(errText);
                        return;
                    }
                }
                tempInvoice.Invoice.ID = nextInvoiceNo;
                tempInvoice.PrintedInvoiceNO = nextRealInvoiceNo;

                this.fpSplit_Sheet1.Cells[i, 0].Text = tempInvoice.Invoice.ID;
                this.fpSplit_Sheet1.Rows[i].Tag = tempInvoice;
                ArrayList alTemp = this.fpSplit_Sheet1.Cells[i, 0].Tag as ArrayList;
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail in alTemp)
                {
                    detail.BalanceBase.Invoice.ID = tempInvoice.Invoice.ID;
                }
                this.fpSplit_Sheet1.Cells[i, 0].Tag = alTemp;
            }
        }

        private void tbLeast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            //this.frmDisplay.RInfo = this.rInfo;
            Neusoft.HISFC.Models.Base.FT feeInfo = new Neusoft.HISFC.Models.Base.FT();
            feeInfo.TotCost = totCost;
            feeInfo.OwnCost = ownCost;
            feeInfo.PayCost = payCost;
            feeInfo.PubCost = pubCost;
            feeInfo.BalancedCost = NConvert.ToDecimal(tbTotOwnCost.Text);
            feeInfo.SupplyCost = totOwnCost;
            feeInfo.RealCost = NConvert.ToDecimal(this.tbRealCost.Text);
            feeInfo.ReturnCost = NConvert.ToDecimal(tbLeast.Text);
            this.ftFeeInfo = feeInfo;
            //this.frmDisplay.FeeInfo = feeInfo;
            //this.frmDisplay.FpPayMode = this.fpPayMode;
            //frmDisplay.SetValue();

            //string tmpContrlValue = "0";

            //tmpContrlValue = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.ENTER_TO_FEE, "0");

            //if (tmpContrlValue == "1")
            //{
            this.tbFee.Enabled = false;
            if (!this.SaveFee())
            {
                this.tbFee.Enabled = true;
                return;
            }
            this.tbFee.Enabled = true;
            this.tbRealCost.Focus();
            this.Close();
            //}
            //else
            //{
            //    tbFee.Focus();
            //}
        }

        private void tbRealCost_TextChanged(object sender, EventArgs e)
        {
            #region 找零显示

            decimal tempCost = 0;
            decimal cashCost = 0;
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                string tmpPayMode = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text;
                decimal tmpCashCost = 0;
                if (tmpPayMode == "现金")
                {
                    tmpCashCost = Neusoft.FrameWork.Public.String.FormatNumber(
                        NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value), 2);
                }
                cashCost += tmpCashCost;
            }
            try
            {
                tempCost = NConvert.ToDecimal(this.tbRealCost.Text) - cashCost;
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入的数字不合法！请验证输入" + ex.Message);
                this.tbRealCost.Text = string.Empty;
                this.tbRealCost.Focus();

                return;
            }

            this.tbLeast.Text = tempCost.ToString();
            #endregion

            #region {221FCC64-7D41-471a-9EED-C30BA1CE330A} 防止无法输入小数点
            string dealCent = Neusoft.HISFC.Components.OutpatientFee.Class.Function.DealCent(NConvert.ToDecimal(tbRealCost.Text)).ToString();
            if (NConvert.ToDecimal(dealCent) != NConvert.ToDecimal(tbRealCost.Text))
            {
                this.tbRealCost.Text = dealCent;
            }
            //this.tbRealCost.Text = Neusoft.HISFC.Components.OutpatientFee.Class.Function.DealCent(Convert.ToDecimal(tbRealCost.Text)).ToString(); 
            #endregion
        }
        #endregion

        #region IOutpatientPopupFee 成员


        public bool IsAccountPay
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
    }
}