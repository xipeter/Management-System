using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.HISFC.Models.Base;
using System.Collections.Generic;
using Neusoft.HISFC.Models.Fee;


namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucQuitFee<br></br>
    /// [功能描述: 门诊退费主界面UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-2-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQuitFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQuitFee()
        {
            try
            {
                InitializeComponent();
                Filter();
            }
            catch { }
        }

        #region 变量

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 常数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 退费申请业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.ReturnApply returnApplyManager = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

        /// <summary>
        /// 非药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 组合项目业务层
        /// </summary>
        //protected Neusoft.HISFC.BizProcess.Fee.UndrugComb undrugCombManager = new Neusoft.HISFC.BizProcess.Fee.UndrugComb();

        /// <summary>
        /// 组合项目业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.UndrugPackAge undrugPackAgeManager = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        protected Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();

        /// <summary>
        /// 复合项目
        /// </summary>
        protected Neusoft.HISFC.Models.Fee.Item.Undrug undrugComb = new Neusoft.HISFC.Models.Fee.Item.Undrug();

        /// <summary>
        /// 当前退费的复合项目
        /// </summary>
        protected Neusoft.HISFC.Models.Fee.Item.Undrug currentUndrugComb = new Neusoft.HISFC.Models.Fee.Item.Undrug();

        /// <summary>
        /// 要退费的发票集合
        /// </summary>
        protected ArrayList quitInvoices = new ArrayList();

        /// <summary>
        /// 发票费用信息
        /// </summary>
        protected ArrayList invoiceFeeItemLists = new ArrayList();

        /// <summary>
        /// 当前复合项目明细
        /// </summary>
        protected ArrayList currentUndrugCombs = new ArrayList();

        /// <summary>
        /// 再收费信息
        /// </summary>
        protected ArrayList againFeeItemLists = new ArrayList();

        ///// <summary>
        ///// 全局数据库事务
        ///// </summary>
        //protected Neusoft.FrameWork.Management.Transaction t = null;

        /// <summary>
        /// 退费的类别
        /// </summary>
        protected string backType = string.Empty;

        /// <summary>
        /// 当前退费设置
        /// </summary>
        protected bool isNeedAllQuit = false;//默认全退

        /// <summary>
        /// 挂号信息实体
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 划价过的发票
        /// </summary>
        protected Hashtable hsInvoice = new Hashtable();

        /// <summary>
        /// 修改后的支付方式
        /// </summary>
        protected ArrayList modifiedBalancePays = new ArrayList();

        /// <summary>
        /// 工具条
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 是否有优惠金额
        /// </summary>
        protected bool isHaveRebateCost = false;

        protected string InvoiceNoStr = string.Empty;
        private Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
        /// <summary>
        /// 物资收费
        /// </summary>
        //{143CA424-7AF9-493a-8601-2F7B1D635027}
        protected Neusoft.HISFC.BizProcess.Integrate.Material.Material mateIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();

        protected bool isQuitFee = true;

        /// <summary>
        /// 是否账户退费
        /// </summary>
        protected bool isAccount = false;

        /// <summary>
        /// 是否作废
        /// </summary>
        private bool isCanacelFee = false;

        /// <summary>
        /// 手工方项目编号
        /// </summary>
        private List<string> listManualIte = new List<string>();

        #region {B5979EE5-CC71-4700-BCFF-AB627F6F17CA} 门诊退费读卡操作 by guanyx
        /// <summary>
        /// 读卡事件
        /// </summary>
        private event System.EventHandler ReadCardEvent;
        #endregion
        #region 插件变量

        /// <summary>
        /// 挂号信息插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientInfomation registerControl = null;

        /// <summary>
        /// 项目录入插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientItemInputAndDisplay itemInputControl = null;

        /// <summary>
        /// 左侧信息插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationLeft leftControl = null;

        /// <summary>
        /// 收费弹出控件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientPopupFee popFeeControl = null;

        /// <summary>
        /// 右侧信息显示控件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationRight rightControl = null;

        #endregion

        #endregion

        #region 属性



        /// <summary>
        /// 操作类别
        /// </summary>
        [Category("控件设置"), Description("是否允许半退 false:不允许 true:允许")]
        private bool isAllowQuitFeeHalf = false;
        public bool IsAllowQuitFeeHalf
        {
            set
            {
                this.isAllowQuitFeeHalf = value;

            }
            get
            {
                return this.isAllowQuitFeeHalf;
            }
        }

        /// <summary>
        /// 是否打印负票 {E47AD522-2ACA-4482-8DC5-6F2D7C04F082}
        /// </summary>
        [Category("控件设置"), Description("是否打印负票")]
        private bool isPrintBill = false;
        public bool IsPrintQuitBill
        {
            set
            {
                this.isPrintBill = value;

            }
            get
            {
                return this.isPrintBill;
            }
        }

        /// <summary>
        /// 是否收费 {C6F1CFDA-7848-47c4-905E-E161B9F5C4C8}
        /// </summary>
        [Category("控件设置"), Description("是否收费"),DefaultValue(true)]
        public bool IsQuitFee
        {
            set
            {
                this.isQuitFee = false;

            }
            get
            {
                return this.isQuitFee;
            }
        }

        [Category("控件设置"), Description("是否作废"), DefaultValue(true)]
        public bool IsCanacelFee
        {
            get { return isCanacelFee; }
            set { isCanacelFee = value; }
        }


        [Category("控件设置"), Description("【单条全退】按钮默认是否选中"), DefaultValue(true)]
        public bool IsCheckForckbAllQuit
        {
            get { return this.ckbAllQuit.Checked; }
            set { this.ckbAllQuit.Checked = value; }
        }


        #endregion

        #region  枚举
        /// <summary>
        /// 待退药显示列
        /// </summary>
        protected enum DrugList
        {
            /// <summary>
            /// 名称
            /// </summary>
            ItemName = 0,

            /// <summary>
            /// 组
            /// </summary>
            Comb = 1,

            /// <summary>
            /// 组号
            /// </summary>
            CombNo = 2,

            /// <summary>
            /// 规格
            /// </summary>
            Specs = 3,

            /// <summary>
            /// 数量
            /// </summary>
            Amount = 4,

            /// <summary>
            /// 单位
            /// </summary>
            PriceUnit = 5,

            /// <summary>
            /// 可退数量
            /// </summary>
            NoBackQty = 6,

            /// <summary>
            /// 金额
            /// </summary>
            Cost = 7,

            /// <summary>
            /// 每次量和付数
            /// </summary>
            DoseAndDays = 8
        }
        /// <summary>
        /// 待退非药显示列
        /// </summary>
        protected enum UndrugList
        {
            /// <summary>
            /// 名称
            /// </summary>
            ItemName = 0,

            /// <summary>
            /// 组
            /// </summary>
            Comb = 1,

            /// <summary>
            /// 组号
            /// </summary>
            CombNo = 2,

            /// <summary>
            /// 数量
            /// </summary>
            Amount = 3,

            /// <summary>
            /// 单位
            /// </summary>
            PriceUnit = 4,

            /// <summary>
            /// 可退数量
            /// </summary>
            NoBackQty = 5,

            /// <summary>
            /// 金额
            /// </summary>
            Cost = 6,

            /// <summary>
            /// 组合项目名称
            /// </summary>
            PackageName = 7
        }
        /// <summary>
        /// 已退药显示列
        /// </summary>
        protected enum DrugListQuit
        {
            /// <summary>
            /// 名称
            /// </summary>
            ItemName = 0,

            /// <summary>
            /// 规格
            /// </summary>
            Specs = 1,

            /// <summary>
            /// 数量
            /// </summary>
            Amount = 2,

            /// <summary>
            /// 单位
            /// </summary>
            PriceUnit = 3,

            /// <summary>
            /// 标志
            /// </summary>
            Flag = 4,

            Price = 5,

            Cost = 6
        }
        /// <summary>
        /// 已退非药显示列
        /// </summary>
        protected enum UndrugListQuit
        {
            /// <summary>
            /// 名称
            /// </summary>
            ItemName = 0,

            /// <summary>
            /// 数量
            /// </summary>
            Amount = 1,

            /// <summary>
            /// 单位
            /// </summary>
            PriceUnit = 2,

            /// <summary>
            /// 标志
            /// </summary>
            Flag = 3
        }

        #endregion

        

        #region 函数

        #region 私有方法



        /// <summary>
        /// 载入插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int LoadPlugins()
        {
            //this.itemInputControl = this.feeIntegrate.GetPlugIns<Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientItemInputAndDisplay>
            //       (Neusoft.HISFC.BizProcess.Integrate.Const.INTERFACE_ITEM_INPUT, new ucDisplay());

            this.itemInputControl = this.ucDisplay1;
            this.ucDisplay1.IsQuitFee = true;

            this.itemInputControl.ItemKind = ItemKind.All;

            //this.leftControl = this.feeIntegrate.GetPlugIns<Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationLeft>
            //        (Neusoft.HISFC.BizProcess.Integrate.Const.INTERFACE_LEFT, new ucInvoicePreview());

            this.leftControl = this.ucInvoicePreview1;

            //{1B220814-0243-4725-882C-012E831C0DA1}
            this.leftControl.InvoiceUpdated += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(leftControl_InvoiceUpdated);



            //用于判断收费还是划价
            this.leftControl.IsValidFee = true;
            this.leftControl.IsPreFee = false;
            this.itemInputControl.LeftControl = this.leftControl;

            //this.rightControl = this.feeIntegrate.GetPlugIns<Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationRight>
            //    (Neusoft.HISFC.BizProcess.Integrate.Const.INTERFACE_RIGHT, new ucCostDisplay());

            this.rightControl = this.ucCostDisplay1;
            this.rightControl.IsPreFee = false;

            this.itemInputControl.RightControl = this.rightControl;

            if (this.isQuitFee)
            {

                this.leftControl.Init();

                if (this.neuTabControl1.TabPages.Count > 1)
                {
                    this.leftControl.InitInvoice();
                }

                this.rightControl.Init();
            }
            else//{C6F1CFDA-7848-47c4-905E-E161B9F5C4C8}
            {
                this.neuTabControl1.Controls.Remove(this.tpFee);
            }

            return 1;
        }

        //{1B220814-0243-4725-882C-012E831C0DA1}
        void leftControl_InvoiceUpdated()
        {
            this.cmbRegDept.Focus();
        }
        /// <summary>
        /// 将上面Fp隐藏掉{E24AFB64-593E-4001-AB56-3560DEB89A37}
        /// </summary>
        private void Filter()
        {
            //this.panel2.Visible = false;
            //this.panel1.Location = new System.Drawing.Point(0, 0);
            //this.fpSpread2.Dock = DockStyle.Fill;
            this.fpSpread1_Sheet2.Visible = false;
            this.fpSpread2_Sheet1.SheetName = "未退药品(F7)";
            this.fpSpread2_Sheet2.SheetName = "未退非药品(F8)";
            this.fpSpread2_Sheet1.Columns[0].Label = "未退药品名称";
            this.fpSpread2_Sheet1.Columns[2].Label = "未退数量";
            this.fpSpread2_Sheet2.Columns[0].Label = "未退非药品名称";
            this.panel3.Visible = false;
        }
        /// <summary>
        /// 初始化项目录入插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitItemInputControl()
        {
            if (this.itemInputControl == null)
            {
                return -1;
            }

            if (this.isQuitFee)
            {
                this.itemInputControl.Init();
            }

            return 1;
        }

        /// <summary>
        /// 通过发票号获得发票信息集合
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功 发票信息集合 失败 null</returns>
        protected virtual ArrayList QueryBalancesByInvoiceNO(string invoiceNO)
        {
            //通过输入发票号，获得发票的序列，再通过序列获得所有发票集合。
            ArrayList balances = this.outpatientManager.QueryBalancesSameInvoiceCombNOByInvoiceNO(invoiceNO);
            //查询业务层出错
            if (balances == null)
            {
                tbInvoiceNO.SelectAll();
                MessageBox.Show("查询发票出错!" + this.outpatientManager.Err);
                tbInvoiceNO.Focus();

                return null;
            }
            //没有找到纪录
            if (balances.Count == 0)
            {
                tbInvoiceNO.SelectAll();
                MessageBox.Show("发票号不存在,请重新录入");
                tbInvoiceNO.Focus();

                return null;
            }

            return balances;
        }

        /// <summary>
        /// 处理产生多发票时候的退费情况,发票获得
        /// </summary>
        /// <param name="balances">当前发票集合</param>
        /// <returns>成功 1 失败 -1 </returns>
        protected virtual int DealMulityBalancesCount(ref ArrayList balances)
        {
            bool isSelect = false;//默认不需要弹出选择发票窗口.
            string SeqNo = string.Empty;//发票序列号
            //循环检索当前获得的所有发票信息.
            foreach (Balance balance in balances)
            {
                if (SeqNo == string.Empty)
                {
                    SeqNo = balance.CombNO;

                    continue;
                }
                else
                {
                    //如果发现有发票序列不同的情况,说明存在重复发票号情况,需要弹出发票选择窗口.
                    if (SeqNo != balance.CombNO)
                    {
                        isSelect = true;
                    }
                }
            }
            if (isSelect) //判断是否需要选择发票
            {
                //声明选择发票窗口实例
                ucInvoiceSelect uc = new ucInvoiceSelect();
                //装载本次检索的所有发票信息
                uc.Add(balances);
                //弹出发票选择窗口
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.TopMost = true;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                //如果操作员没有进行选择给予提示
                if (uc.SelectedBalance == null || uc.SelectedBalance.CombNO == string.Empty)
                {
                    MessageBox.Show("请选择要退的发票");

                    return -1;
                }
                //通过操作员选择的发票信息,选择了唯一发票序列,再根据发票序列获取本次应参与退费的所有发票信息.
                balances = outpatientManager.QueryBalancesByInvoiceSequence(uc.SelectedBalance.CombNO);
                if (balances == null)
                {
                    MessageBox.Show("查询发票失败" + outpatientManager.Err);

                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 是否操作员可以退当前发票
        /// </summary>
        /// <param name="balances">当前发票集合</param>
        /// <returns>成功 true 失败 false</returns>
        protected virtual bool IsOperCanQuitTheseBalances(ArrayList balances)
        {
            //读取控制参数
            //读取是否允许退其他操作员的费用。
            bool isCanQuitOterhOper = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_OTHER_OPER_INVOICE, true, false);
           
            //不允许退其他操作员费用,判断当前发票的收费操作员是否为当前操作员
            //如果不是，那么不允许继续退费;
            if (!isCanQuitOterhOper)
            {
                Balance tempBalance = balances[0] as Balance;

                if (tempBalance == null)
                {
                    MessageBox.Show("发票格式转换出错!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }

                if (tempBalance.BalanceOper.ID != this.outpatientManager.Operator.ID)
                {
                    MessageBox.Show("该发票的收费员为: " + tempBalance.BalanceOper.ID + "您没有权限进行退费!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }

                tempBalance = null;
            }
            //获得是否可以退日结过费用控制参数
            bool isCanQuitDayBlanced = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_DAYBALANCED_INVOICE, true, false);

            if (!isCanQuitDayBlanced)//不允许退日结过费用
            {
                Balance tmpInvoice = balances[0] as Balance;
             
                if (tmpInvoice == null)
                {
                    MessageBox.Show("发票格式转换出错!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();
                    
                    return false;
                }
                if (tmpInvoice.IsDayBalanced)
                {
                    MessageBox.Show("该发票已经日结,您没有权限进行退费!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();
                    
                    return false;
                }
            }

            int canQuitDays = this.controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.VALID_QUIT_DAYS, true, 10000);

            DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();

            Balance tmpInvoiceValid = balances[0] as Balance;
             
            if (tmpInvoiceValid == null)
            {
                MessageBox.Show("发票格式转换出错!");
                tbInvoiceNO.SelectAll();
                tbInvoiceNO.Focus();
                
                return false;
            }

            int tempDays =  (nowTime - tmpInvoiceValid.BalanceOper.OperTime).Days;

            if (tempDays >= canQuitDays) 
            {
                MessageBox.Show("该发票已经超出可退费天数,不允许退费!");

                tbInvoiceNO.SelectAll();
                tbInvoiceNO.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 查询发票信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>null错误 要处理的发票集合</returns>
        protected virtual ArrayList QueryInvoices(string invoiceNO)
        {
            //发票补位
            invoiceNO = invoiceNO.PadLeft(12, '0');
            InvoiceNoStr = invoiceNO;
            //通过发票号获得发票信息集合
            ArrayList balances = this.QueryBalancesByInvoiceNO(invoiceNO);
            if (balances == null)
            {
                return null;
            }

            //是否操作员可以退当前发票
            if (!this.IsOperCanQuitTheseBalances(balances))
            {
                return null;
            }

            //如果获得的发票多余一张(因为分发票的情况存在),那么判断是否要弹出发票选择界面
            //这里的多张发票产生有两个可能 1 分发票产生的,发票号不同,但是发票序列相同,所以无需弹出选择发票界面.
            // 2 是由于设置的发票号重复(系统允许发票号重复),但是发票序列不同,这个时候要弹出选择发票界面,让操作员
            //进行选择.总之就是发票序列决定此次退费的发票信息.
            if (balances.Count > 1)
            {
                if (this.DealMulityBalancesCount(ref balances) == -1)
                {
                    return null;
                }
            }

            return balances;
        }

        /// <summary>
        /// 初始化 
        /// </summary>
        /// <returns>成功1 失败 -1</returns>
        protected virtual int Init()
        {
            if (this.LoadPlugins() < 0)
            {
                return -1;
            }

            if (this.InitItemInputControl() < 0)
            {
                return 1;
            }

            //初始化 挂号科室
            ArrayList regDeptList = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);
            if (regDeptList == null)
            {
                MessageBox.Show("初始化挂号科室出错!" + this.managerIntegrate.Err);

                return -1;
            }
            this.cmbRegDept.AddItems(regDeptList);

            //初始化医生列表，加入一个无归属医生。编号999
            ArrayList doctList = new ArrayList();
            doctList = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (doctList == null)
            {
                MessageBox.Show("初始化医生列表出错!" + this.managerIntegrate.Err);

                return -1;
            }
            Neusoft.HISFC.Models.Base.Employee pNone = new Neusoft.HISFC.Models.Base.Employee();
            pNone.ID = "999";
            pNone.Name = "无归属";
            pNone.SpellCode = "WGS";
            pNone.UserCode = "999";
            doctList.Add(pNone);

            this.cmbDoct.AddItems(doctList);

            ArrayList quitReason = this.managerIntegrate.GetConstantList("QUITFEEREASON");
            this.cmbQuitReason.DropDownStyle = ComboBoxStyle.DropDown;
            if (quitReason == null)
            {
                MessageBox.Show("初始化退费原因出错!" + this.managerIntegrate.Err);

                return -1;
            }
            this.cmbQuitReason.AddItems(quitReason);            
            if (IsCanacelFee)
            {
                this.neuLabel11.Text = "作废原因";
                this.cmbQuitReason.SelectedIndex = 0;
                this.neuLabel16.Visible = true;
                this.cmbUnPayMode.Visible = true;
                ArrayList alPayModes = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
                this.cmbUnPayMode.AddItems(alPayModes);
                this.cmbUnPayMode.SelectedIndex = 1;
                this.cmbUnPayMode.Enabled = false;
            }
            else
            {
                this.neuLabel11.Text = "退费原因";
                this.neuLabel16.Visible = false;
                this.cmbUnPayMode.Visible = false;
            }
            //手工方项目编号
            DataSet ds = new DataSet();
            if (this.outpatientManager.QueryItemListOld(ref ds) < 0)
            {
                MessageBox.Show("查询项目失败！" + outpatientManager.Err);
                return -1;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listManualIte.Add(dr[4].ToString());
            }

            return 1;
        }

        #endregion
        #region {5A4211C4-F4EC-448e-A7D2-280711613F1C}判断是否已经做过退费申请，否则不允许退费 modied by  xizf 20110227
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int ValidIsApply()
        {
            int length = this.fpSpread2.Sheets.Count;
            //没有做退费申请的药品列表
            ArrayList alDrug = new ArrayList();
            //没有做退费申请的非药品列表
            ArrayList alUndrug = new ArrayList();
            //没有审核的药品
            ArrayList alUnConfirmDrug = new ArrayList();
            bool isDrug = true;
            for (int i = 0; i < length; i++)
            {
                //先判断是药品还是非药品
                if (this.fpSpread2.Sheets[i].SheetName.Contains("未退非药品"))
                {
                    isDrug = false;
                }
                //药品
                if (isDrug)
                {
                    for (int j = 0; j < this.fpSpread2.Sheets[i].Rows.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(this.fpSpread2.Sheets[i].Cells[j, (int)DrugListQuit.Flag].Text))
                        {
                            if (this.fpSpread2.Sheets[i].Cells[j, (int)DrugListQuit.Flag].Text.Trim() != "确认")
                            {
                                if (this.fpSpread2.Sheets[i].Cells[j, (int)DrugListQuit.Flag].Text.Trim() == "未审核")
                                {
                                    alUnConfirmDrug.Add(this.fpSpread2.Sheets[i].Cells[j, (int)DrugListQuit.ItemName].Text);
                                    continue;
                                }
                                alDrug.Add(this.fpSpread2.Sheets[i].Cells[j, (int)DrugListQuit.ItemName].Text);
                            }
                        }
                    }
                }
                else
                {
                    //非药品
                    for (int j = 0; j < this.fpSpread2.Sheets[i].Rows.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(this.fpSpread2.Sheets[i].Cells[j, (int)UndrugListQuit.Flag].Text))
                        {
                            if (this.fpSpread2.Sheets[i].Cells[j, (int)UndrugListQuit.Flag].Text.Trim() != "确认")
                            {
                                alUndrug.Add(this.fpSpread2.Sheets[i].Cells[j, (int)UndrugListQuit.ItemName].Text);
                            }
                        }
                    }
                }

            }
            if (alDrug.Count > 0 || alUndrug.Count > 0 || alUnConfirmDrug.Count > 0)
            {
                string drugStr = string.Empty;
                string undrugStr = string.Empty;
                string unconfirmStr = string.Empty;
                if (alDrug.Count > 0)
                {
                    foreach (object item in alDrug)
                    {
                        drugStr += item.ToString() + ",";
                    }

                }
                if (alUndrug.Count > 0)
                {
                    foreach (object obj in alUndrug)
                    {
                        undrugStr += obj.ToString() + ",";
                    }
                }
                if (alUnConfirmDrug.Count > 0)
                {
                    foreach (object obj in alUnConfirmDrug)
                    {
                        unconfirmStr += obj.ToString() + ",";
                    }
                }
                if (alDrug.Count > 0 && alUndrug.Count > 0)
                {
                    drugStr = drugStr.TrimEnd(new char[] { ',' });
                    undrugStr = undrugStr.TrimEnd(new char[] { ',' });
                    MessageBox.Show("药品：" + drugStr + ",非药品：" + undrugStr + ",未作退费申请，请先做退费申请！");
                }
                if (alDrug.Count > 0 && alUndrug.Count == 0)
                {
                    drugStr = drugStr.TrimEnd(new char[] { ',' });
                    MessageBox.Show("药品：" + drugStr + ",未作退费申请，请先做退费申请！");
                }
                if (alUndrug.Count > 0 && alDrug.Count == 0)
                {
                    undrugStr = undrugStr.TrimEnd(new char[] { ',' });
                    MessageBox.Show("非药品：" + undrugStr + ",未作退费申请，请先做退费申请！");
                }
                if (alUnConfirmDrug.Count > 0)
                {
                    unconfirmStr = unconfirmStr.TrimEnd(new char[] { ',' });
                    MessageBox.Show("药品：" + unconfirmStr + ",未做退药审核，请先到药房审核");
                }
                return -1;
            }
            return 1;
        }
        #endregion

        #region 判断是否已经退药 {5C26D40F-456B-48a0-9428-EFA0DA78C2D6}
        private int ValidIsDurged()
        {
            int length = this.fpSpread2.Sheets.Count;
            //没有做退费申请的药品列表
            ArrayList alDrug = new ArrayList();
            //没有做退费申请的非药品列表
            ArrayList alUndrug = new ArrayList();
            bool isDrug = true;
            for (int i = 0; i < length; i++)
            {
                //先判断是药品还是非药品
                if (this.fpSpread2.Sheets[i].SheetName.Contains("未退非药品"))
                {
                    isDrug = false;
                }
                //药品
                if (isDrug)
                {
                    for (int j = 0; j < this.fpSpread2.Sheets[i].Rows.Count; j++)
                    {

                        ReturnApply tempInsert = new ReturnApply();

                        if (this.fpSpread2.Sheets[i].Rows[j].Tag == null)
                        {
                            continue;
                        }

                        if (this.fpSpread2.Sheets[i].Rows[j].Tag is ReturnApply)
                        {
                            tempInsert = this.fpSpread2.Sheets[i].Rows[j].Tag as ReturnApply;

                        }
                        Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList = this.outpatientManager.GetFeeItemListBalanced(tempInsert.RecipeNO, tempInsert.SequenceNO);
                        if (feeItemList == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempInsert.Item.Name + "获得项目失败!" + this.outpatientManager.Err);

                            return -1;
                        }
                        if (feeItemList.ConfirmedQty > 0)
                        {
                            MessageBox.Show("该患者没有做退药审核，请先到药房进行退药审核！");
                            return -1;
                        }
                    }
                }
            }

            return 1;
        }
        #endregion

        /// <summary>
        /// 获得费用明细
        /// </summary>
        /// <returns>-1 失败 1 成功</returns>
        protected virtual int GetItemList()
        {
            try
            {
                //获得本次退费所有发票的第一张作为临时发票信息
                Balance tempBalance = quitInvoices[0] as Balance;

                isHaveRebateCost = false;

                //通过发票序列号,获得所有应参与退费的药品信息
                ArrayList drugItemLists = this.outpatientManager.QueryDrugFeeItemListByInvoiceSequence(tempBalance.CombNO);
                if (drugItemLists == null)
                {
                    MessageBox.Show("获得药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
                //通过发票序列号,获得所有应参与退费的非药品信息
                ArrayList undrugItemLists = outpatientManager.QueryUndrugFeeItemListByInvoiceSequence(tempBalance.CombNO);
                if (undrugItemLists == null)
                {
                    MessageBox.Show("获得非药品信息出错!" + outpatientManager.Err);

                    return -1;
                }

                foreach (FeeItemList tempDrugItem in drugItemLists)
                {
                    if (listManualIte.Contains(tempDrugItem.Item.ID))
                    {
                        MessageBox.Show("该发票是手工方请在手工方退费中进行退费！");
                        return -1;
                    }
                }

                foreach (FeeItemList tempUndrugItem in undrugItemLists)
                {
                    if (listManualIte.Contains(tempUndrugItem.Item.ID))
                    {
                        MessageBox.Show("该发票是手工方请在手工方退费中进行退费！");
                        return -1;
                    }
                }

                #region 物资
                //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                ArrayList mateItemLists = outpatientManager.QueryMateFeeItemListByInvoiceSequence(tempBalance.CombNO);
                if (mateItemLists == null)
                {
                    MessageBox.Show("获得物资信息出错！" + outpatientManager.Err);
                    return -1;
                }
                //暂时将物资放在非药品中处理
                undrugItemLists.AddRange(mateItemLists.ToArray());
                #endregion

                if (drugItemLists.Count + undrugItemLists.Count == 0)
                {
                    MessageBox.Show("没有费用信息!");

                    return -1;
                }

                this.invoiceFeeItemLists = outpatientManager.QueryFeeItemListsByInvoiceNO(tempBalance.Invoice.ID);

                ArrayList drugConfirmList = new ArrayList();//已经核准的退药信息
                ArrayList undrugConfirmList = new ArrayList();//已经核准退费的非药品信息
                //循环所有参与退费的发票,查询已经核准的药品和非药品信息
                //由于多张发票的存在,而明细只对应一个发票号,所以遍所有的参与退费的发票,其中只有一个发票号符合查询条件.
                foreach (Balance balance in this.quitInvoices)
                {
                    //如果已经获得了已经核准退费的药品信息,就不再获取
                    if (drugConfirmList == null || drugConfirmList.Count == 0)
                    {
                        //获得已经核准的退药信息{E2EF8607-E06C-42d4-BE5A-B31F7CA42DF4}
                        drugConfirmList = returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "1");
                        if (drugConfirmList == null)
                        {
                            MessageBox.Show("获得确认药品项目列表出错!" + returnApplyManager.Err);

                            return -1;
                        }
                    }
                    //如果已经获得了已经核准退费的非药品信息,就不再获取
                    if (undrugConfirmList == null || undrugConfirmList.Count == 0)
                    {
                        //获得已经核准退费的非药品信息{E2EF8607-E06C-42d4-BE5A-B31F7CA42DF4}
                        undrugConfirmList = returnApplyManager.GetList(balance.Patient.ID, balance.Invoice.ID, false, false, "0");
                        if (undrugConfirmList == null)
                        {
                            MessageBox.Show("获得确认非药品项目列表出错!" + returnApplyManager.Err);

                            return -1;
                        }
                    }
                }

               

                //显示待退药品信息
                this.fpSpread1_Sheet1.RowCount = drugItemLists.Count;

                FeeItemList drugItem = null;//药品临时实体
                for (int i = 0; i < drugItemLists.Count; i++)
                {
                    drugItem = drugItemLists[i] as FeeItemList;

                    if (drugItem.FT.RebateCost > 0)
                    {
                        isHaveRebateCost = true;
                    }
                   

                    //重新计算本条药品的总金额,方便以后参与计算费用
                    drugItem.FT.TotCost = drugItem.FT.OwnCost + drugItem.FT.PayCost + drugItem.FT.PubCost;

                    this.fpSpread1_Sheet1.Rows[i].Tag = drugItem;
                    //因为可能存在同一发票有不同看诊科室的情况,而且挂号信息中的看诊信息不一定与实际收费的看诊
                    //科室相同,所以这里把挂号实体的看诊可是赋值为收费明细时的看诊科室信息.
                    this.patient.DoctorInfo.Templet.Dept = drugItem.RecipeOper.Dept;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.ItemName].Text = drugItem.Item.Name;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.CombNo].Text = drugItem.Order.Combo.ID;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Specs].Text = drugItem.Item.Specs;
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text = drugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty / drugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.PriceUnit].Text = drugItem.Item.PriceUnit;
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.NoBackQty].Text = drugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty / drugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Cost].Text = (drugItem.FT.OwnCost + drugItem.FT.PayCost + drugItem.FT.PubCost).ToString();

                    if (drugItem.Item.SysClass.ID.ToString() == "PCC")
                    {
                        this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit + " " + "付数:" + drugItem.Days.ToString();
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit;
                    }

                    Class.Function.DrawCombo(this.fpSpread1_Sheet1, (int)DrugList.CombNo, (int)DrugList.Comb, 0);
                }

                //显示非药品信息
                this.fpSpread1_Sheet2.RowCount = undrugItemLists.Count;
                
                FeeItemList undrugItem = null;
                for (int i = 0; i < undrugItemLists.Count; i++)
                {
                    undrugItem = undrugItemLists[i] as FeeItemList;

                    #region 加载物资信息
                    //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    if (undrugItem.Item.ItemType == EnumItemType.UnDrug)
                    {
                        //{143CA424-7AF9-493a-8601-2F7B1D635027}
                        string outNo = undrugItem.UpdateSequence.ToString();
                        List<HISFC.Models.FeeStuff.Output> list = mateIntegrate.QueryOutput(outNo);
                        undrugItem.MateList = list;
                    }
                    #endregion

                    if (undrugItem.FT.RebateCost > 0)
                    {
                        isHaveRebateCost = true;
                    }

                    undrugItem.FT.TotCost = undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost;
                    this.fpSpread1_Sheet2.Rows[i].Tag = undrugItem;
                    this.patient.DoctorInfo.Templet.Dept = undrugItem.RecipeOper.Dept;

                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.ItemName].Text = undrugItem.Item.Name;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.CombNo].Text = undrugItem.Order.Combo.ID;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text = undrugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty / undrugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PriceUnit].Text = undrugItem.Item.PriceUnit;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.NoBackQty].Text = undrugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty / undrugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Cost].Text = (undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost).ToString();
                    if (undrugItem.UndrugComb.ID != null && undrugItem.UndrugComb.ID.Length > 0)
                    {
                        this.undrugComb = this.undrugManager.GetValidItemByUndrugCode(undrugItem.UndrugComb.ID);
                        if (this.undrugComb == null)
                        {
                            MessageBox.Show("获得组套信息出错，无法显示组套自定义码，但是不影响退费操作！");
                        }
                        else
                        {
                            undrugItem.UndrugComb.UserCode = this.undrugComb.UserCode;
                        }

                        Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                        if (item == null)
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name;
                        }
                        else
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name + "[" + item.UserCode + "]";
                        }

                    }
                    else
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                        if (item != null)
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = item.UserCode;
                        }
                    }

                    Class.Function.DrawCombo(this.fpSpread1_Sheet2, (int)UndrugList.CombNo, (int)UndrugList.Comb, 0);
                    //显示物资信息
                    SetMateData(undrugItem, i);
                }
                //显示确认退药信息
                this.fpSpread2_Sheet1.RowCount = drugItemLists.Count + drugConfirmList.Count;
                Neusoft.HISFC.Models.Fee.ReturnApply drugReturn = null;
                for (int i = 0; i < drugConfirmList.Count; i++)
                {
                    drugReturn = drugConfirmList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                    this.fpSpread2_Sheet1.Rows[i].Tag = drugReturn;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.ItemName].Text = drugReturn.Item.Name;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Amount].Text = drugReturn.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugReturn.Item.Qty / drugReturn.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugReturn.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.PriceUnit].Text = drugReturn.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Specs].Text = drugReturn.Item.Specs;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Flag].Text = "确认";
                    //判断是否发药 modified by xizf 20110301 {D81B766E-C049-4cb6-B457-7B7387712458}
                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList = this.outpatientManager.GetFeeItemListBalanced(drugReturn.RecipeNO, drugReturn.SequenceNO);
                    if (feeItemList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(drugReturn.Item.Name + "获得项目失败!" + this.outpatientManager.Err);

                        return -1;
                    }
                    if (feeItemList.ConfirmedQty > 0)
                    {
                        this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Flag].Text = "未审核";
                    }

                    int findRow = FindItem(drugReturn.RecipeNO, drugReturn.SequenceNO, this.fpSpread1_Sheet1);
                    if (findRow == -1)
                    {
                        MessageBox.Show("查找未退药项目出错!");

                        return -1;
                    }
                    FeeItemList modifyDrug = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;

                    modifyDrug.NoBackQty = modifyDrug.NoBackQty - drugReturn.Item.Qty;
                    modifyDrug.Item.Qty = modifyDrug.Item.Qty - drugReturn.Item.Qty;
                    modifyDrug.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Price * modifyDrug.Item.Qty / modifyDrug.Item.PackQty, 2);
                    modifyDrug.FT.OwnCost = modifyDrug.FT.TotCost;

                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Cost].Text = modifyDrug.FT.TotCost.ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Amount].Text = modifyDrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Qty / modifyDrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = modifyDrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.NoBackQty / modifyDrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.NoBackQty, 2).ToString();
                }
                this.fpSpread2_Sheet2.RowCount = undrugItemLists.Count + undrugConfirmList.Count;
                Neusoft.HISFC.Models.Fee.ReturnApply undrugReturn = null;
                for (int i = 0; i < undrugConfirmList.Count; i++)
                {
                    undrugReturn = undrugConfirmList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                    this.fpSpread2_Sheet2.Rows[i].Tag = undrugReturn;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.ItemName].Text = undrugReturn.Item.Name;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Amount].Text = undrugReturn.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugReturn.Item.Qty / undrugReturn.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugReturn.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.PriceUnit].Text = undrugReturn.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Flag].Text = "确认";

                    int findRow = FindItem(undrugReturn.RecipeNO, undrugReturn.SequenceNO, this.fpSpread1_Sheet2);
                    if (findRow == -1)
                    {
                        MessageBox.Show("查找未退非药项目出错!");

                        return -1;
                    }
                    FeeItemList modifyUndrug = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;

                    modifyUndrug.NoBackQty = modifyUndrug.NoBackQty - undrugReturn.Item.Qty;
                    modifyUndrug.Item.Qty = modifyUndrug.Item.Qty - undrugReturn.Item.Qty;
                    modifyUndrug.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Price * modifyUndrug.Item.Qty / modifyUndrug.Item.PackQty, 2);
                    modifyUndrug.FT.OwnCost = modifyUndrug.FT.TotCost;

                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Cost].Text = modifyUndrug.FT.TotCost.ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Amount].Text = modifyUndrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Qty / modifyUndrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = modifyUndrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.NoBackQty / modifyUndrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.NoBackQty, 2).ToString();

                }

                if (isHaveRebateCost)
                {
                    this.ckbAllQuit.Checked = true;
                    this.ckbAllQuit.Enabled = false;
                }
                else 
                {
                    this.ckbAllQuit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 显示物资数据
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="rowIndex"></param>
        //{143CA424-7AF9-493a-8601-2F7B1D635026}
        protected virtual void SetMateData(FeeItemList feeItemList , int rowIndex)
        {

            int index = 0;
            //{4D6501CB-D2A4-4204-8CBA-F34F28D5300A} 非药品-物资对照方式退费修改
            if (feeItemList.MateList.Count < 1) return;

            fpSpread1_Sheet2.RowHeader.Cells[rowIndex, 0].Text = "+";
            fpSpread1_Sheet2.RowHeader.Cells[rowIndex, 0].BackColor = Color.YellowGreen;

            foreach (HISFC.Models.FeeStuff.Output outItem in feeItemList.MateList)
            {
                fpSpread1_Sheet2.Rows.Add(fpSpread1_Sheet2.Rows.Count, 1);
                index = fpSpread1_Sheet2.Rows.Count - 1;
                this.fpSpread1_Sheet2.Cells[index, 0].Text = outItem.StoreBase.Item.Name;
                this.fpSpread1_Sheet2.Cells[index, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                outItem.StoreBase.Item.Qty = outItem.StoreBase.Quantity - outItem.ReturnApplyNum - outItem.StoreBase.Returns;
                this.fpSpread1_Sheet2.Cells[index, 3].Text = outItem.StoreBase.Item.Qty.ToString();
                this.fpSpread1_Sheet2.Cells[index, 4].Text = outItem.StoreBase.Item.PriceUnit;
                this.fpSpread1_Sheet2.Cells[index, 5].Text = outItem.StoreBase.Item.Qty.ToString();
                this.fpSpread1_Sheet2.Cells[index, 6].Text = (outItem.StoreBase.Item.Qty * outItem.StoreBase.Item.Price).ToString();
                this.fpSpread1_Sheet2.Cells[index, 7].Text = outItem.StoreBase.Item.UserCode;
                this.fpSpread1_Sheet2.RowHeader.Cells[index, 0].Text = ".";
                this.fpSpread1_Sheet2.RowHeader.Cells[index, 0].BackColor = System.Drawing.Color.SkyBlue;
                this.fpSpread1_Sheet2.Rows[index].Tag = outItem;
                this.fpSpread1_Sheet2.Rows[index].Visible = false;

            }
        }

        /// <summary>
        /// 查找项目
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequence">处方流水号</param>
        /// <param name="sv">当前SheetView</param>
        /// <returns></returns>
        protected virtual int FindItem(string recipeNO, int sequence, FarPoint.Win.Spread.SheetView sv)
        {
            for (int i = 0; i < sv.RowCount; i++)
            {
                if (sv.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList f = sv.Rows[i].Tag as FeeItemList;
                    if (f.RecipeNO == recipeNO && f.SequenceNO == sequence)
                    {
                        return i;
                    }
                }
            }
           
            return -1;
        }

        /// <summary>
        /// 查找允许新增的行
        /// </summary>
        /// <param name="sv">当前SheetView页</param>
        /// <returns>成功 当前可以增加的行 失败 -1</returns>
        protected virtual int FindNullRow(FarPoint.Win.Spread.SheetView sv)
        {
            for (int i = 0; i < sv.RowCount; i++)
            {
                if (sv.Rows[i].Tag == null || !(sv.Rows[i].Tag is Neusoft.FrameWork.Models.NeuObject))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 全退操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int AllQuit()
        {
            this.ckbAllQuit.Checked = true;

            int temp = 0;
            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)
            {
                temp = 1;
            }
            else
            {
                temp = 2;
            }

            this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                this.fpSpread1_Sheet1.ActiveRowIndex = i;
                if (this.QuitOperation() == -1)
                {
                    return -1;
                }
            }
            //this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
            //for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            //{
            //    this.fpSpread1_Sheet2.ActiveRowIndex = i;
            //    if (this.QuitOperation() == -1)
            //    {
            //        return -1;
            //    }
            //}

            //if (temp == 1)
            //{
            //    this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
            //}
            //else
            //{
            //    this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
            //}

            return 1;
        }

        /// <summary>
        /// 处理双击,回车选择项目退费
        /// </summary>
        protected virtual void DealQuitOperation()
        {
            //bool isNeedGroupAllQuit = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.GROUP_ITEM_ALLQUIT, false, false);

            ////tmpValue = bValue;

            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)//非药品
            {
                int currRow = this.fpSpread1_Sheet2.ActiveRowIndex;

                if (this.fpSpread1_Sheet2.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread1_Sheet2.Rows[currRow].Tag as FeeItemList;
                    if (f.UndrugComb.ID != string.Empty && this.isNeedAllQuit && this.ckbAllQuit.Checked)
                    {
                        for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
                        {
                            if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                            {
                                FeeItemList fTemp = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;
                                if (fTemp.UndrugComb.ID == f.UndrugComb.ID && fTemp.Order.ID == f.Order.ID)
                                {
                                    this.QuitUndrugOperation(i);
                                }
                            }
                        }

                        return;
                    }
                    else
                    {
                        QuitOperation();
                    }
                }
                //{143CA424-7AF9-493a-8601-2F7B1D635026}
                //物资项目
                if (this.fpSpread1_Sheet2.Rows[currRow].Tag is HISFC.Models.FeeStuff.Output)
                {
                    QuitOperationMate(currRow);
                }
            }
            else
            {
                QuitOperation();
            }
        }

        /// <summary>
        ///退去药品操作 
        /// </summary>
        /// <param name="currRow">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QuitDrugOperation(int currRow)
        {
            if (this.fpSpread1_Sheet1.Rows[currRow].Tag is FeeItemList)
            {
                FeeItemList f = this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList;

                if (f.NoBackQty <= 0)
                {
                    return -2;
                }
                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                //没有找到，那么新增一条;
                if (findRow == -1)
                {
                    findRow = FindNullRow(this.fpSpread2_Sheet1);
                    FeeItemList fClone = f.Clone();
                    this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";                    
                }
                else //找到了累加数量
                {

                    FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
                    fFind.Item.Qty = fFind.Item.Qty + f.Item.Qty;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
                }
                f.Item.Qty = f.Item.Qty - f.NoBackQty;
                f.NoBackQty = 0;
                f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
                this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = "0";
            }

            ComputCost();
            
            return 1;
        }

        /// <summary>
        /// 处理非药品当前行退费
        /// </summary>
        /// <param name="currRow">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QuitUndrugOperation(int currRow)
        {
            if (this.fpSpread1_Sheet2.Rows[currRow].Tag is FeeItemList)
            {
                FeeItemList f = this.fpSpread1_Sheet2.Rows[currRow].Tag as FeeItemList;

                if (f.NoBackQty <= 0)
                {
                    return -2;
                }
                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                //没有找到，那么新增一条;
                if (findRow == -1)
                {
                    findRow = FindNullRow(this.fpSpread2_Sheet2);
                    FeeItemList fClone = f.Clone();
                    this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                }
                else //找到了累加数量
                {

                    FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
                    fFind.Item.Qty = fFind.Item.Qty + f.Item.Qty;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                }
                f.Item.Qty = f.Item.Qty - f.NoBackQty;
                f.NoBackQty = 0;
                f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
                this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = "0";


            }

            ComputCost();
            
            return 1;
        }

        /// <summary>
        /// 处理退费操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QuitOperation()
        {
            #region 药品

            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)//退药品
            {
                int currRow = this.fpSpread1_Sheet1.ActiveRowIndex;

                if (this.fpSpread1_Sheet1.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList;

                    if (this.ckbAllQuit.Checked)
                    {
                        if (!this.isNeedAllQuit || f.Item.SysClass.ID.ToString() != "PCC")
                        {
                            if (f.NoBackQty <= 0)
                            {
                                MessageBox.Show(f.Item.Name + "已经没有可退数量，不能再退费!");

                                return -1;
                            }
                            int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                            //没有找到，那么新增一条;
                            if (findRow == -1)
                            {
                                findRow = FindNullRow(this.fpSpread2_Sheet1);
                                FeeItemList fClone = f.Clone();
                                this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fClone.Item.Specs;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty / fClone.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty, 2).ToString();
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";                               
                            }
                            else //找到了累加数量
                            {

                                FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
                                fFind.Item.Qty = fFind.Item.Qty + f.NoBackQty;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fFind.Item.Specs;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";                                                      
                            }
                            f.Item.Qty = f.Item.Qty - f.NoBackQty;
                            f.NoBackQty = 0;
                            f.FT.OwnCost = f.FT.OwnCost - f.FT.OwnCost;
                            f.FT.PubCost = f.FT.PubCost - f.FT.PubCost;
                            f.FT.PayCost = f.FT.PayCost - f.FT.PayCost;
                            f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = "0";
                        }
                        else
                        {
                            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                                    if (fTemp.Item.SysClass.ID.ToString() == "PCC" && fTemp.Order.Combo.ID == f.Order.Combo.ID)
                                    {
                                        this.QuitDrugOperation(i);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (f.Item.SysClass.ID.ToString() == "PCC" && f.Order.Combo.ID.Length > 0 && this.isNeedAllQuit)
                        {
                            ArrayList alFeeItem = new ArrayList();

                            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                                    if (fTemp.Item.SysClass.ID.ToString() == "PCC" && fTemp.Order.Combo.ID == f.Order.Combo.ID)
                                    {
                                        alFeeItem.Add(fTemp);
                                    }
                                }
                            }

                            txtReturnItemName.Text = "中药组合";
                            txtReturnNum.Tag = alFeeItem;
                            txtRetSpecs.Text = string.Empty;
                            this.backType = "PCC";
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                        else
                        {
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                            txtReturnItemName.Text = f.Item.Name;
                            txtReturnNum.Tag = f;
                            txtRetSpecs.Text = f.Item.Specs;
                        }
                    }
                }
            }

            #endregion

            #region 非药品

            if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)//退药品
            {
                int currRow = this.fpSpread1_Sheet2.ActiveRowIndex;

               // bool isNeedGroupAllQuit = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.GROUP_ITEM_ALLQUIT, false, false);

                //tmpValue = bValue;

                #region 物资
                //{143CA424-7AF9-493a-8601-2F7B1D635026}
                //是否是多条对照
                List<HISFC.Models.FeeStuff.Output> outitemList = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
                string headerText = this.fpSpread1.ActiveSheet.RowHeader.Cells[currRow, 0].Text;
                if (headerText == "+" || headerText == "-")
                {
                    if (!this.ckbAllQuit.Checked)
                    {
                        if (!this.ckbAllQuit.Checked && headerText != ".")
                        {
                            MessageBox.Show("请选择要退费的物资信息！");
                            if (this.fpSpread1_Sheet2.RowHeader.Cells[currRow, 0].Text == "+")
                            {
                                this.ExpandOrCloseRow(false, currRow + 1);
                            }
                            return -1;
                        }
                    }
                }
                #endregion
                #region 非药品
                if (this.fpSpread1_Sheet2.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread1_Sheet2.Rows[currRow].Tag as FeeItemList;

                    if (this.ckbAllQuit.Checked)
                    {
                        if (f.NoBackQty <= 0)
                        {
                            MessageBox.Show(f.Item.Name + "已经没有可退数量，不能再退费!");
                            return -2;
                        }
                        int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                        //没有找到，那么新增一条;
                        if (findRow == -1)
                        {
                            findRow = FindNullRow(this.fpSpread2_Sheet2);
                            FeeItemList fClone = f.Clone();
                            this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty / fClone.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty, 2).ToString();
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        }
                        else //找到了累加数量
                        {
                            FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
                            fFind.Item.Qty = fFind.Item.Qty + f.NoBackQty;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                            this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        }
                        f.Item.Qty = f.Item.Qty - f.NoBackQty;
                        f.NoBackQty = 0;

                        f.FT.OwnCost = f.FT.OwnCost - f.FT.OwnCost;
                        f.FT.PubCost = f.FT.PubCost - f.FT.PubCost;
                        f.FT.PayCost = f.FT.PayCost - f.FT.PayCost;

                        f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                        this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                        this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
                        this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = "0";
                        #region 物资
                        //{143CA424-7AF9-493a-8601-2F7B1D635026}
                        int mateIndex = 0;
                        if (f.MateList.Count > 0)
                        {
                            foreach (HISFC.Models.FeeStuff.Output tempOut in f.MateList)
                            {
                                mateIndex = GetMateRowIndex(tempOut);
                                if (mateIndex == -1)
                                {
                                    MessageBox.Show("查找物资信息失败！");
                                    return -1;
                                }
                                tempOut.StoreBase.Item.Qty = 0;
                                this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.NoBackQty].Text = "0";
                                this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.Amount].Text = "0";
                                this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.Cost].Text = "0";
                                this.fpSpread1_Sheet2.Rows[mateIndex].Tag = tempOut;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //复合项目
                        if (f.UndrugComb.ID != null && f.UndrugComb.ID.Length > 0 && this.isNeedAllQuit)
                        {
                            ArrayList alFeeItem = new ArrayList();

                            this.currentUndrugComb = this.undrugManager.GetValidItemByUndrugCode(f.UndrugComb.ID);
                            if (this.currentUndrugComb == null)
                            {
                                MessageBox.Show("获得复合项目出错！" + this.undrugManager.Err);

                                return -1;
                            }

                            this.currentUndrugCombs = this.undrugPackAgeManager.QueryUndrugPackagesBypackageCode(this.currentUndrugComb.ID);

                            if (currentUndrugCombs == null)
                            {
                                MessageBox.Show("获得复合项目明细出错！" + this.undrugPackAgeManager.Err);

                                return -1;
                            }

                            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
                            {
                                if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                                {
                                    FeeItemList fTemp = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;
                                    if (fTemp.UndrugComb.ID == f.UndrugComb.ID && fTemp.Order.ID == f.Order.ID)
                                    {
                                        alFeeItem.Add(fTemp);
                                    }
                                }
                            }


                            txtReturnItemName.Text = f.UndrugComb.Name;
                            txtReturnNum.Tag = alFeeItem;
                            txtRetSpecs.Text = string.Empty;
                            this.backType = "PACKAGE";
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                        else
                        {
                            txtReturnItemName.Text = f.Item.Name;
                            txtReturnNum.Tag = f;
                            txtRetSpecs.Text = f.Item.Specs;
                            this.backType = string.Empty;
                            txtReturnNum.Select();
                            txtReturnNum.Focus();
                        }
                    }
                }
                #endregion
            }

            #endregion

            ComputCost();

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex">当前选种的行</param>
        /// <returns></returns>
        //{143CA424-7AF9-493a-8601-2F7B1D635026}
        private int QuitOperationMate(int rowIndex)
        {
            int undrugIndex = this.FinItemRowIndex(rowIndex);
            FeeItemList feeItem = this.fpSpread1_Sheet2.Rows[undrugIndex].Tag as FeeItemList;
            FeeItemList f = feeItem.Clone();
            HISFC.Models.FeeStuff.Output outItem = this.fpSpread1_Sheet2.Rows[rowIndex].Tag as HISFC.Models.FeeStuff.Output;
            List<HISFC.Models.FeeStuff.Output> list = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            list.Add(outItem);
            f.MateList = list;
            int mateListIndex = 0;
            if (this.ckbAllQuit.Checked)
            {
                if (f.NoBackQty <= 0)
                {
                    MessageBox.Show(f.Item.Name + "已经没有可退数量，不能再退费!");

                    return -2;
                }
                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                //{4D6501CB-D2A4-4204-8CBA-F34F28D5300A}
                FeeItemList fClone = f.Clone();
                f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? outItem.StoreBase.Item.Qty * f.Item.PackQty : outItem.StoreBase.Item.Qty);
                f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? outItem.StoreBase.Item.Qty * f.Item.PackQty : outItem.StoreBase.Item.Qty);
                f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                f.FT.OwnCost = f.FT.TotCost;
                if (findRow == -1)
                {
                    findRow = FindNullRow(this.fpSpread2_Sheet2);
                    //{4D6501CB-D2A4-4204-8CBA-F34F28D5300A}
                    //FeeItemList fClone = f.Clone();
                    fClone.Item.Qty = (f.FeePack == "1" ? outItem.StoreBase.Item.Qty * f.Item.PackQty : outItem.StoreBase.Item.Qty);
                    this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty / fClone.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fClone.NoBackQty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                }
                else //找到了累加数量
                {
                    FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
                    fFind.Item.Qty = fFind.Item.Qty + (f.FeePack == "1" ? outItem.StoreBase.Item.Qty * f.Item.PackQty : outItem.StoreBase.Item.Qty);
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                    //设置退费费用的物资信息
                    this.SetFeeItemList(fFind, outItem.Clone(), true);
                }
               
                f.FT.OwnCost = f.FT.OwnCost - f.FT.OwnCost;
                f.FT.PubCost = f.FT.PubCost - f.FT.PubCost;
                f.FT.PayCost = f.FT.PayCost - f.FT.PayCost;

                f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                
                this.fpSpread1_Sheet2.Cells[undrugIndex, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[undrugIndex, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
                this.fpSpread1_Sheet2.Cells[undrugIndex, (int)UndrugList.NoBackQty].Text = f.NoBackQty.ToString();
                this.fpSpread1_Sheet2.Cells[rowIndex, (int)UndrugList.NoBackQty].Text = "0";
                this.fpSpread1_Sheet2.Cells[rowIndex, (int)UndrugList.Amount].Text = "0";
                this.fpSpread1_Sheet2.Cells[rowIndex, (int)UndrugList.Cost].Text = "0";
                //设置为退费费用的物资信息
                feeItem.Item.Qty = f.Item.Qty;
                feeItem.FT.OwnCost = f.FT.OwnCost;
                feeItem.FT.PubCost=  f.FT.PubCost;
                feeItem.FT.PayCost = f.FT.PayCost;
                feeItem.FT.TotCost = f.FT.TotCost;
                feeItem.NoBackQty = f.NoBackQty;
                this.SetFeeItemList(feeItem, outItem, false, ref mateListIndex);
                this.fpSpread1_Sheet2.Rows[rowIndex].Tag = feeItem.MateList[mateListIndex];
                
            }
            else
            {
                txtReturnItemName.Text = outItem.StoreBase.Item.Name;
                txtReturnNum.Tag = f;
                txtRetSpecs.Text = outItem.StoreBase.Item.Specs;
                this.backType = string.Empty;
                txtReturnNum.Select();
                txtReturnNum.Focus();
            }
            ComputCost();
            return 1;

        }

        /// <summary>
        /// 设置FeeItemList中的物资信息
        /// </summary>
        /// <param name="f">费用信息</param>
        /// <param name="outItem">物资出库</param>
        /// <param name="isQuiteOperation">是否是退费操作</param>
        //{143CA424-7AF9-493a-8601-2F7B1D635026}
        protected virtual void SetFeeItemList(FeeItemList f, HISFC.Models.FeeStuff.Output outItem, bool isQuiteOperation)
        {
            if (f.MateList.Count == 0)
            {
                f.MateList.Add(outItem);
                return;
            }
            bool isFind = false;
            foreach (HISFC.Models.FeeStuff.Output item in f.MateList)
            {
                if (item.ID == outItem.ID && item.StoreBase.StockNO == outItem.StoreBase.StockNO)
                {
                    isFind = true;
                    if (isQuiteOperation)
                    {
                        item.StoreBase.Item.Qty += outItem.StoreBase.Item.Qty;
                        
                    }
                    else
                    {
                        item.StoreBase.Item.Qty -= outItem.StoreBase.Item.Qty;
                    }
                    return;
                }
            }
            if (!isFind)
            {
                f.MateList.Add(outItem);
                return;
            }
        }

        /// <summary>
        /// 设置FeeItemList中的物资信息
        /// </summary>
        /// <param name="f">费用信息</param>
        /// <param name="outItem">物资出库</param>
        /// <param name="isQuiteOperation">是否是退费操作</param>
        //{143CA424-7AF9-493a-8601-2F7B1D635026}
        protected virtual void SetFeeItemList(FeeItemList f, HISFC.Models.FeeStuff.Output outItem, bool isQuiteOperation, ref int mateListindex)
        {
            mateListindex = 0;
            if (f.MateList.Count == 0)
            {
                f.MateList.Add(outItem);
                return;
            }
            bool isFind = false;
            HISFC.Models.FeeStuff.Output item = null;
            for (int i = 0; i < f.MateList.Count; i++)
            {
                item = f.MateList[i];
                if (item.ID == outItem.ID && item.StoreBase.StockNO == outItem.StoreBase.StockNO)
                {
                    isFind = true;
                    if (isQuiteOperation)
                    {
                        item.StoreBase.Item.Qty += outItem.StoreBase.Item.Qty;
                    }
                    else
                    {
                        item.StoreBase.Item.Qty -= outItem.StoreBase.Item.Qty;
                    }
                    mateListindex = i;
                    return;
                }
            }
            if (!isFind)
            {
                f.MateList.Add(outItem);
                mateListindex = f.MateList.Count - 1;
                return;
            }
        }

        /// <summary>
        /// 输入数量退费
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int QuitItemByNum()
        {
            if (this.txtReturnNum.Tag == null)
            {
                MessageBox.Show("请选择项目!");

                return -1;
            }
            decimal quitQty = 0;
            try
            {
                quitQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtReturnNum.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数量输入不合法!" + ex.Message);
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }
            if (quitQty == 0)
            {
                MessageBox.Show("数量不能为零");
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }
            if (quitQty < 0)
            {
                MessageBox.Show("数量不能为小于零");
                this.txtReturnNum.SelectAll();
                this.txtReturnNum.Focus();

                return -1;
            }

            object objQuit = this.txtReturnNum.Tag;

            #region Tag为单个项目时

            if (objQuit is FeeItemList)
            {
                FeeItemList f = objQuit as FeeItemList;
                //{143CA424-7AF9-493a-8601-2F7B1D635027}
                if (f.MateList.Count > 0)
                {
                    if (quitQty > f.MateList[0].StoreBase.Item.Qty)
                    {
                        MessageBox.Show("输入的数量大于可退数量!");
                        this.txtReturnNum.SelectAll();
                        this.txtReturnNum.Focus();
                        return -1;
                    }
                }
                if (f.FeePack == "1")//包装单位
                {
                    if (quitQty > f.NoBackQty / f.Item.PackQty)
                    {
                        MessageBox.Show("输入的数量大于可退数量!");
                        this.txtReturnNum.SelectAll();
                        this.txtReturnNum.Focus();

                        return -1;
                    }
                }
                else
                {
                    if (quitQty > f.NoBackQty)
                    {
                        MessageBox.Show("输入的数量大于可退数量!");
                        this.txtReturnNum.SelectAll();
                        this.txtReturnNum.Focus();

                        return -1;
                    }
                }
                int currRow = 0;
                //if (f.Item.IsPharmacy)
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);
                    if (currRow == -1)
                    {
                        MessageBox.Show("查找药品失败！");

                        return -1;
                    }
                    if (f.Item.SysClass.ID.ToString() == "PCC")
                    {
                        decimal doseOnce = (f.NoBackQty - quitQty) / f.Days;

                        (this.fpSpread1_Sheet1.Rows[currRow].Tag as FeeItemList).Order.DoseOnce = doseOnce;

                        this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.DoseAndDays].Text = "每次量:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(doseOnce, 3) + f.Order.DoseUnit + " " + "付数:" + f.Days.ToString();
                    }
                }
                else
                {
                    currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);
                    if (currRow == -1)
                    {
                        MessageBox.Show("查找非药品失败！");

                        return -1;
                    }
                }

                f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty);
                f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty);
                f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
                f.FT.OwnCost = f.FT.TotCost;

                //if (f.Item.IsPharmacy)//药品
                if (f.Item.ItemType == EnumItemType.Drug)//药品
                {
                    int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                    //没有找到，那么新增一条;
                    if (findRow == -1)
                    {
                        findRow = FindNullRow(this.fpSpread2_Sheet1);

                        FeeItemList fClone = f.Clone();
                        fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty : quitQty;

                        this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fClone.Item.Specs;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
                    }
                    else //找到了累加数量
                    {
                        FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
                        fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty : quitQty);
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Specs].Text = fFind.Item.Specs;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                        this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
                    }

                    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
                    this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
                }
                else //非药品
                {
                    HISFC.Models.FeeStuff.Output outItem = null;
                    
                    int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                    //没有找到，那么新增一条;
                    if (findRow == -1)
                    {
                        findRow = FindNullRow(this.fpSpread2_Sheet2);

                        FeeItemList fClone = f.Clone();
                        fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty : quitQty;

                        //fClone.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty : quitQty);
                        fClone.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Price * fClone.Item.Qty / fClone.Item.PackQty, 2);
                        fClone.FT.OwnCost = fClone.FT.TotCost;

                        this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        //{143CA424-7AF9-493a-8601-2F7B1D635026}
                        //物资收费
                        if (fClone.MateList.Count > 0)
                        {
                            outItem = fClone.MateList[0];
                            outItem.StoreBase.Item.Qty = quitQty;
                        }
                       
                    }
                    else //找到了累加数量
                    {
                        FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
                        fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty : quitQty);
                        fFind.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Price * fFind.Item.Qty / fFind.Item.PackQty, 2);
                        fFind.FT.OwnCost = fFind.FT.TotCost;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                            Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                        this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                        //{143CA424-7AF9-493a-8601-2F7B1D635026}
                        //物资收费
                        if (f.MateList.Count > 0)
                        {
                            HISFC.Models.FeeStuff.Output tempoutItem = f.MateList[0].Clone();
                            tempoutItem.StoreBase.Item.Qty = quitQty;
                            this.SetFeeItemList(fFind, tempoutItem, true);
                        }
                    }
                  
                    
                    this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
                    this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
                    //处理物资
                    //{143CA424-7AF9-493a-8601-2F7B1D635026}
                    FeeItemList tempItemList = this.fpSpread1_Sheet2.Rows[currRow].Tag as FeeItemList;
                    tempItemList.Item.Qty = f.Item.Qty;
                    tempItemList.NoBackQty = f.NoBackQty ;
                    tempItemList.FT.TotCost = f.FT.TotCost;
                    tempItemList.FT.OwnCost = f.FT.OwnCost;
                    
                    if (f.MateList.Count > 0)
                    {
                        outItem = f.MateList[0].Clone();

                        outItem.StoreBase.Item.Qty = quitQty;
                        
                        int matelistIndex = 0;
                        this.SetFeeItemList(tempItemList, outItem,false,ref matelistIndex);

                        int mateRow = GetMateRowIndex(outItem);
                        outItem = tempItemList.MateList[matelistIndex];

                        this.fpSpread1_Sheet2.Cells[mateRow, (int)UndrugList.Amount].Text = outItem.StoreBase.Item.Qty.ToString();
                        this.fpSpread1_Sheet2.Cells[mateRow, (int)UndrugList.Cost].Text = (outItem.StoreBase.Item.Qty * outItem.StoreBase.Item.Price).ToString();
                        this.fpSpread1_Sheet2.Cells[mateRow, (int)UndrugList.NoBackQty].Text = outItem.StoreBase.Item.Qty.ToString();

                        this.fpSpread1_Sheet2.Rows[mateRow].Tag = outItem;
                    }
                }

            }

            #endregion

            else if (objQuit is ArrayList)
            {
                ArrayList alTemp = objQuit as ArrayList;

                if (this.backType == "PACKAGE")
                {
                    foreach (FeeItemList item in alTemp)
                    {
                        Neusoft.HISFC.Models.Fee.Item.UndrugComb info = null;

                        foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb in this.currentUndrugCombs)
                        {
                            if (undrugComb.ID == item.ID)
                            {
                                info = undrugComb;

                                break;
                            }
                        }

                        if (info == null)
                        {
                            MessageBox.Show("新维护的组套中没有" + item.Item.Name + "请执行全退");

                            return -1;
                        }

                        #region 处理明细

                        FeeItemList f = item;
                        if (f.FeePack == "1")//包装单位
                        {
                            if (quitQty * info.Qty > f.NoBackQty / f.Item.PackQty)
                            {
                                MessageBox.Show("输入的数量大于可退数量!");
                                this.txtReturnNum.SelectAll();
                                this.txtReturnNum.Focus();

                                return -1;
                            }
                        }
                        else
                        {
                            if (quitQty * info.Qty > f.NoBackQty)
                            {
                                MessageBox.Show("输入的数量大于可退数量!");
                                this.txtReturnNum.SelectAll();
                                this.txtReturnNum.Focus();

                                return -1;
                            }
                        }
                        int currRow = 0;
                        //if (!f.Item.IsPharmacy)
                        if(f.Item.ItemType != EnumItemType.Drug)
                        {
                            currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);
                            if (currRow == -1)
                            {
                                MessageBox.Show("查找非药品失败！");

                                return -1;
                            }
                        }

                        f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * info.Qty : quitQty * info.Qty);
                        f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * info.Qty : quitQty * info.Qty);
                        f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);

                        //if (!f.Item.IsPharmacy) //非药品
                        if(f.Item.ItemType != EnumItemType.Drug)
                        {
                            int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                            //没有找到，那么新增一条;
                            if (findRow == -1)
                            {
                                findRow = FindNullRow(this.fpSpread2_Sheet2);

                                FeeItemList fClone = f.Clone();
                                fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty * info.Qty : quitQty * info.Qty;

                                this.fpSpread2_Sheet2.Rows[findRow].Tag = fClone;
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fClone.Item.Name;
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                            }
                            else //找到了累加数量
                            {
                                FeeItemList fFind = this.fpSpread2_Sheet2.Rows[findRow].Tag as FeeItemList;
                                fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty * info.Qty : quitQty * info.Qty);
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.ItemName].Text = fFind.Item.Name;
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                                this.fpSpread2_Sheet2.Cells[findRow, (int)UndrugListQuit.Flag].Text = "未核准";
                            }

                            this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Amount].Text = f.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                            this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.Cost].Text = f.FT.TotCost.ToString();
                            this.fpSpread1_Sheet2.Cells[currRow, (int)UndrugList.NoBackQty].Text = f.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
                        }

                        #endregion
                    }
                }
                if (this.backType == "PCC")
                {
                    foreach (FeeItemList item in alTemp)
                    {
                        #region 处理明细

                        FeeItemList f = item;
                        if (f.FeePack == "1")//包装单位
                        {
                            if (quitQty * f.Order.DoseOnce > f.NoBackQty / f.Item.PackQty)
                            {
                                MessageBox.Show("输入的数量大于可退数量!");
                                this.txtReturnNum.SelectAll();
                                this.txtReturnNum.Focus();

                                return -1;
                            }
                        }
                        else
                        {
                            if (quitQty * f.Order.DoseOnce > f.NoBackQty)
                            {
                                MessageBox.Show("输入的数量大于可退数量!");
                                this.txtReturnNum.SelectAll();
                                this.txtReturnNum.Focus();

                                return -1;
                            }
                        }
                        int currRow = 0;
                        //if (f.Item.IsPharmacy)
                        if (f.Item.ItemType == EnumItemType.Drug)
                        {
                            currRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);
                            if (currRow == -1)
                            {
                                MessageBox.Show("查找药品失败！");

                                return -1;
                            }
                        }

                        f.Item.Qty = f.Item.Qty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce);
                        f.NoBackQty = f.NoBackQty - (f.FeePack == "1" ? quitQty * f.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce);
                        f.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);

                        //if (f.Item.IsPharmacy) //非药品
                        if (f.Item.ItemType == EnumItemType.Drug) //非药品
                        {
                            int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet1);
                            //没有找到，那么新增一条;
                            if (findRow == -1)
                            {
                                findRow = FindNullRow(this.fpSpread2_Sheet1);

                                FeeItemList fClone = f.Clone();
                                fClone.Item.Qty = fClone.FeePack == "1" ? quitQty * fClone.Item.PackQty * f.Order.DoseOnce : quitQty * f.Order.DoseOnce;

                                this.fpSpread2_Sheet1.Rows[findRow].Tag = fClone;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fClone.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fClone.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty / fClone.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fClone.Item.Qty, 2).ToString();
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fClone.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
                            }
                            else //找到了累加数量
                            {
                                FeeItemList fFind = this.fpSpread2_Sheet1.Rows[findRow].Tag as FeeItemList;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.ItemName].Text = fFind.Item.Name;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.PriceUnit].Text = fFind.Item.PriceUnit;
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Flag].Text = "未核准";
                                fFind.Item.Qty = fFind.Item.Qty + (fFind.FeePack == "1" ? quitQty * fFind.Item.PackQty * fFind.Order.DoseOnce : quitQty * fFind.Order.DoseOnce);
                                this.fpSpread2_Sheet1.Cells[findRow, (int)DrugListQuit.Amount].Text = fFind.FeePack == "1" ?
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                            }

                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Amount].Text = f.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.Cost].Text = f.FT.TotCost.ToString();
                            this.fpSpread1_Sheet1.Cells[currRow, (int)DrugList.NoBackQty].Text = f.FeePack == "1" ?
                                Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty / f.Item.PackQty, 2).ToString() :
                                Neusoft.FrameWork.Public.String.FormatNumber(f.NoBackQty, 2).ToString();
                        }

                        #endregion
                    }
                }
            }

            this.fpSpread1.Select();
            this.fpSpread1.Focus();
            if (this.fpSpread1.ActiveSheet.RowCount > 0)
            {
                this.fpSpread1.ActiveSheet.ActiveRowIndex = 0;
            }

            ComputCost();
            
            return 1;
        }

        /// <summary>
        /// 查找物资所在fp中的行
        /// </summary>
        /// <param name="outItem">物资出库信息</param>
        /// <returns>-1  失败</returns>
        protected virtual int GetMateRowIndex(HISFC.Models.FeeStuff.Output outItem)
        {
            string headText = string.Empty;
            HISFC.Models.FeeStuff.Output tempOut = null;
            for (int i = 0; i < this.fpSpread1_Sheet2.Rows.Count; i++)
            {
                headText = this.fpSpread1_Sheet2.RowHeader.Cells[i, 0].Text;
                if (headText != ".") continue;
                tempOut = this.fpSpread1_Sheet2.Rows[i].Tag as HISFC.Models.FeeStuff.Output;
                if (tempOut.StoreBase.StockNO == outItem.StoreBase.StockNO &&
                    tempOut.ID == outItem.ID)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 处理取消退费操作
        /// </summary>
        protected virtual void DealCancelQuitOperation()
        {

            if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet2)//非药品
            {
                int currRow = this.fpSpread2_Sheet2.ActiveRowIndex;

                if (this.fpSpread2_Sheet2.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread2_Sheet2.Rows[currRow].Tag as FeeItemList;
                    if (f.UndrugComb.ID != string.Empty && isNeedAllQuit)
                    {
                        for (int i = 0; i < this.fpSpread2_Sheet2.RowCount; i++)
                        {
                            if (this.fpSpread2_Sheet2.Rows[currRow].Tag is FeeItemList)
                            {
                                FeeItemList fTemp = this.fpSpread2_Sheet2.Rows[i].Tag as FeeItemList;
                                if (fTemp != null && fTemp.UndrugComb.ID == f.UndrugComb.ID && f.Order.ID == fTemp.Order.ID)
                                {
                                    CancelUndrugQuitOperation(i);
                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        CancelQuitOperation();
                    }
                }
            }
            else
            {
                int currRow = this.fpSpread2_Sheet1.ActiveRowIndex;

                if (this.fpSpread2_Sheet1.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread2_Sheet1.Rows[currRow].Tag as FeeItemList;

                    if (f.Item.SysClass.ID.ToString() == "PCC" && f.Order.Combo.ID.Length > 0 && this.isNeedAllQuit)
                    {
                        for (int i = 0; i < this.fpSpread2_Sheet1.RowCount; i++)
                        {
                            if (this.fpSpread2_Sheet1.Rows[i].Tag is FeeItemList)
                            {
                                FeeItemList fTemp = this.fpSpread2_Sheet1.Rows[i].Tag as FeeItemList;
                                if (fTemp.Item.SysClass.ID.ToString() == "PCC" && fTemp.Order.Combo.ID == f.Order.Combo.ID)
                                {
                                    CancelQuitDrugOperation(i);
                                }
                            }
                        }
                    }
                    else
                    {
                        CancelQuitOperation();
                    }
                }
            }
        }
        
        /// <summary>
        /// 处理取消已退非药品操作
        /// </summary>
        /// <param name="currRow">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelUndrugQuitOperation(int currRow)
        {
            if (this.fpSpread2_Sheet2.Rows[currRow].Tag == null)
            {
                return -1;
            }
            if (this.fpSpread2_Sheet2.Rows[currRow].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
            {
                MessageBox.Show("已经核准非药品不能取消!");

                return -1;
            }
            if (this.fpSpread2_Sheet2.Rows[currRow].Tag is FeeItemList)
            {
                FeeItemList f = this.fpSpread2_Sheet2.Rows[currRow].Tag as FeeItemList;

                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);

                if (findRow == -1)
                {
                    MessageBox.Show("查找未退非药品失败!");

                    return -1;
                }
                FeeItemList fFind = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;
                fFind.Item.Qty += f.Item.Qty;
                fFind.NoBackQty += f.Item.Qty;
                fFind.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Price * fFind.Item.Qty / fFind.Item.PackQty, 2);
                this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Amount].Text = fFind.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Cost].Text = fFind.FT.TotCost.ToString();
                this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = fFind.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty / fFind.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty, 2).ToString();
                f.Item.Qty = 0;
                this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.Amount].Text = string.Empty;
                this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.Flag].Text = string.Empty;
                this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.ItemName].Text = string.Empty;
                this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.PriceUnit].Text = string.Empty;
            }

            ComputCost();

            return 1;
        }

        /// <summary>
        /// 处理药品取消退费
        /// </summary>
        /// <param name="currRow">当前行</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelQuitDrugOperation(int currRow)
        {
            if (this.fpSpread2_Sheet1.Rows[currRow].Tag == null)
            {
                return -1;
            }
            if (this.fpSpread2_Sheet1.Rows[currRow].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
            {
                MessageBox.Show("已经核准药品不能取消!");

                return -1;
            }
            if (this.fpSpread2_Sheet1.Rows[currRow].Tag is FeeItemList)
            {
                FeeItemList f = this.fpSpread2_Sheet1.Rows[currRow].Tag as FeeItemList;

                int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);

                if (findRow == -1)
                {
                    MessageBox.Show("查找未退药品失败!");

                    return -1;
                }
                FeeItemList fFind = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;
                fFind.Item.Qty += f.Item.Qty;
                fFind.NoBackQty += f.Item.Qty;
                fFind.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Price * fFind.Item.Qty / fFind.Item.PackQty, 2);
                fFind.FT.OwnCost = fFind.FT.TotCost;
                this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Amount].Text = fFind.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Cost].Text = fFind.FT.TotCost.ToString();
                this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = fFind.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty / fFind.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty, 2).ToString();
                f.Item.Qty = 0;

                this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Amount].Text = string.Empty;
                this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Flag].Text = string.Empty;
                this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.ItemName].Text = string.Empty;
                this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.PriceUnit].Text = string.Empty;
                this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Specs].Text = string.Empty;
            }

            ComputCost();

            return 0;
        }

        /// <summary>
        /// 取消退费操作
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelQuitOperation()
        {
            if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet1)//药品
            {
                int currRow = this.fpSpread2_Sheet1.ActiveRowIndex;

                if (this.fpSpread2_Sheet1.Rows[currRow].Tag == null)
                {
                    return -1;
                }
                if (this.fpSpread2_Sheet1.Rows[currRow].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                {
                    MessageBox.Show("已经核准药品不能取消!");

                    return -1;
                }
                if (this.fpSpread2_Sheet1.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread2_Sheet1.Rows[currRow].Tag as FeeItemList;

                    int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet1);

                    if (findRow == -1)
                    {
                        MessageBox.Show("查找未退药品失败!");

                        return -1;
                    }
                    FeeItemList fFind = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;
                    fFind.Item.Qty += f.Item.Qty;
                    fFind.NoBackQty += f.Item.Qty;
                    fFind.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Price * fFind.Item.Qty / fFind.Item.PackQty, 2) - fFind.FT.RebateCost;
                    fFind.FT.OwnCost = fFind.FT.TotCost;
                    //fFind.FT.TotCost += f.FT.TotCost;
                    //fFind.FT.PubCost += f.FT.PubCost;
                    //fFind.FT.PayCost += f.FT.PayCost;
                    //fFind.FT.OwnCost += f.FT.OwnCost;

                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Cost].Text = fFind.FT.TotCost.ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty, 2).ToString();
                    f.Item.Qty = 0;
                    if (f.Item.SysClass.ID.ToString() == "PCC")
                    {
                        decimal doseOnce = (fFind.NoBackQty) / fFind.Days;

                        (this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList).Order.DoseOnce = doseOnce;

                        this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.DoseAndDays].Text = "每次量:" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(doseOnce, 3) + f.Order.DoseUnit + " " + "付数:" + f.Days.ToString();
                    }
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Amount].Text = "0";
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Amount].Text = string.Empty;
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Flag].Text = string.Empty;
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.ItemName].Text = string.Empty;
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.PriceUnit].Text = string.Empty;
                    this.fpSpread2_Sheet1.Cells[currRow, (int)DrugListQuit.Specs].Text = string.Empty;
                    //{433AA56A-264F-4c8c-BC7E-52DAEAFDC605}
                    this.fpSpread2_Sheet1.Rows[currRow].Tag = null;
                }
            }
            if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet2)//非药品
            {
                int currRow = this.fpSpread2_Sheet2.ActiveRowIndex;

                if (this.fpSpread2_Sheet2.Rows[currRow].Tag == null)
                {
                    return -1;
                }
                if (this.fpSpread2_Sheet2.Rows[currRow].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                {
                    MessageBox.Show("已经核准非药品不能取消!");

                    return -1;
                }
                if (this.fpSpread2_Sheet2.Rows[currRow].Tag is FeeItemList)
                {
                    FeeItemList f = this.fpSpread2_Sheet2.Rows[currRow].Tag as FeeItemList;

                    int findRow = FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread1_Sheet2);

                    if (findRow == -1)
                    {
                        MessageBox.Show("查找未退非药品失败!");

                        return -1;
                    }
                    FeeItemList fFind = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;
                    fFind.Item.Qty += f.Item.Qty;
                    fFind.NoBackQty += f.Item.Qty;
                    fFind.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Price * fFind.Item.Qty / fFind.Item.PackQty, 2) - fFind.FT.RebateCost;
                    fFind.FT.OwnCost = fFind.FT.TotCost;
                    //fFind.FT.TotCost += f.FT.TotCost;
                    //fFind.FT.PubCost += f.FT.PubCost;
                    //fFind.FT.PayCost += f.FT.PayCost;
                    //fFind.FT.OwnCost += f.FT.OwnCost; 
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Amount].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Cost].Text = fFind.FT.TotCost.ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = fFind.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty / fFind.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(fFind.NoBackQty, 2).ToString();
                    f.Item.Qty = 0;
                    //this.fpSpread2_Sheet2.Cells[currRow,(int)UndrugListQuit.Item.Qty].Text = "0";
                    this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.Amount].Text = string.Empty;
                    this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.Flag].Text = string.Empty;
                    this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.ItemName].Text = string.Empty;
                    this.fpSpread2_Sheet2.Cells[currRow, (int)UndrugListQuit.PriceUnit].Text = string.Empty;
                    this.fpSpread2_Sheet2.Rows[currRow].Tag = null;
                    #region 物资
                    //{143CA424-7AF9-493a-8601-2F7B1D635026}
                    int mateListIndex = 0;
                    if (f.MateList.Count > 0)
                    {
                        int mateIndex = 0;
                        foreach (HISFC.Models.FeeStuff.Output outItem in f.MateList)
                        {
                            mateIndex = this.GetMateRowIndex(outItem);
                            if (mateIndex == -1)
                            {
                                MessageBox.Show("查找物资信息失败！");
                                return -1;
                            }
                            this.SetFeeItemList(fFind, outItem, true, ref mateListIndex);

                            this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.Amount].Text = fFind.MateList[mateListIndex].StoreBase.Item.Qty.ToString();
                            this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.Cost].Text = (fFind.MateList[mateListIndex].StoreBase.Item.Qty * fFind.MateList[mateListIndex].StoreBase.Item.Price).ToString();
                            this.fpSpread1_Sheet2.Cells[mateIndex, (int)UndrugList.NoBackQty].Text = fFind.MateList[mateListIndex].StoreBase.Item.Qty.ToString();
                            this.fpSpread1_Sheet2.Rows[mateIndex].Tag = fFind.MateList[mateListIndex];
                        }
                    }
                    #endregion
                }
            }

            ComputCost();
            
            return 1;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual bool IsValid()
        {
            if (this.quitInvoices == null || this.quitInvoices.Count == 0)
            {
                MessageBox.Show("请输入发票信息");

                return false;
            }

            if (!IsQuitItem())
            {
                MessageBox.Show("请选择退费项目!");

                return false;
            }

            bool isCanQuitOtherOper = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_OTHER_OPER_INVOICE, true, false);
            if (!isCanQuitOtherOper)//不予许交叉退费
            {
                Balance tmpInvoice = quitInvoices[0] as Balance;
                if (tmpInvoice == null)
                {
                    MessageBox.Show("发票格式转换出错!");
                    this.tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }

                if (tmpInvoice.BalanceOper.ID != this.outpatientManager.Operator.ID)
                {
                    MessageBox.Show("该发票为操作员" + tmpInvoice.BalanceOper.ID + "收取,您没有权限进重打!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }
            }

            bool isCanQuitDayBalanced = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_DAYBALANCED_INVOICE, true, false);
            if (!isCanQuitDayBalanced)//不予许退费日结后费用
            {
                Balance tmpInvoice = quitInvoices[0] as Balance;
                if (tmpInvoice == null)
                {
                    MessageBox.Show("发票格式转换出错!");
                    this.tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }

                //if (tmpInvoice.BalanceOper.ID != this.outpatientManager.Operator.ID)
                //{
                //    MessageBox.Show("该发票已经日结,您没有权限进重打!");
                //    tbInvoiceNO.SelectAll();
                //    tbInvoiceNO.Focus();

                //    return false;
                //}
                if (tmpInvoice.IsDayBalanced)
                {
                    MessageBox.Show("该发票已经日结,您没有权限进重打!");
                    tbInvoiceNO.SelectAll();
                    tbInvoiceNO.Focus();

                    return false;
                }
            }
            
            Balance invoice = quitInvoices[0] as Balance;
            //if (invoice != null && invoice.IsAccount)
            //{
            //    if (!IsAllQuit())
            //    {
            //        MessageBox.Show("账户集中打印的发票必须全退！");

            //        return false;
            //    }
            //}

            if (this.patient.Pact.PayKind.ID == "02")//医保患者需要全退!
            {
                bool isSICanHalfQuit = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.SI_CAN_HALF_QUIT, false, false);
                if (!isSICanHalfQuit)
                {
                    if (!IsAllQuit())
                    {
                        MessageBox.Show("公费或者医保患者要求全退!还有未退光的费用!");

                        return false;
                    }
                }
            }
            if (this.patient.Pact.PayKind.ID == "03")//公费患者需要全退!
            {
                string tmpControl = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.PUB_CAN_HALF_QUIT, "0");
                if (tmpControl == "0")
                {
                    if (!IsAllQuit())
                    {
                        MessageBox.Show("公费或者医保患者要求全退!还有未退光的费用!");

                        return false;
                    }
                }
            }
            if (IsCanacelFee)
            {
                if (!IsAllQuit())
                {
                    MessageBox.Show("作废必须全退!");

                    return false;
                }
                if (string.IsNullOrEmpty(this.cmbQuitReason.Text))
                {
                    MessageBox.Show("请输入退费原因!");

                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否项目全退
        /// </summary>
        /// <returns>成功 true 失败 false</returns>
        protected virtual bool IsQuitItem()
        {
            decimal qty = 0;

            for (int i = 0; i < this.fpSpread2_Sheet1.RowCount; i++)
            {
                if (this.fpSpread2_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpread2_Sheet1.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList fTemp = this.fpSpread2_Sheet1.Rows[i].Tag as FeeItemList;

                        qty += fTemp.Item.Qty;
                    }
                }
                if (this.fpSpread2_Sheet1.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                {
                    Neusoft.HISFC.Models.Fee.ReturnApply fTemp = this.fpSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;

                    qty += fTemp.Item.Qty;
                }
            }
            for (int i = 0; i < this.fpSpread2_Sheet2.RowCount; i++)
            {
                if (this.fpSpread2_Sheet2.Rows[i].Tag != null)
                {
                    if (this.fpSpread2_Sheet2.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList fTemp = this.fpSpread2_Sheet2.Rows[i].Tag as FeeItemList;

                        qty += fTemp.Item.Qty;
                    }
                }
                if (this.fpSpread2_Sheet2.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                {
                    Neusoft.HISFC.Models.Fee.ReturnApply fTemp = this.fpSpread2_Sheet2.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;

                    qty += fTemp.Item.Qty;
                }
            }
            if (qty > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否全退
        /// </summary>
        /// <returns>成功true 失败 false</returns>
        protected virtual bool IsAllQuit()
        {
            decimal qty = 0;

            FeeItemList fTemp = null;

            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                {
                    fTemp = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;

                    qty += fTemp.Item.Qty;
                }
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    fTemp = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;

                    qty += fTemp.Item.Qty;
                }
            }
            if (qty > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 保存退费
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Save()
        {
            DialogResult result = MessageBox.Show("是否要退费?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return -1;
            }

            //判断有效性
            if (!IsValid())
            {
                return -1;
            }
            //判断是否做过退费申请 {5A4211C4-F4EC-448e-A7D2-280711613F1C}
            //if (ValidIsApply() < 0)
            //{
            //    return -1;
            //}
            //判断是否已经退药{5C26D40F-456B-48a0-9428-EFA0DA78C2D6}
            //if (ValidIsDurged() < 0)
            //{
            //    return -1;
            //}
            //发票组合号,根据发票组合号查询支付方式 {F0114A43-2079-40dc-BE1E-04611B59B7D9}
            string invoiceUnion = (quitInvoices[0] as Balance).InvoiceCombo;
            bool isAccountPay = false;
            
            //ArrayList alBalancePay = outpatientManager.QueryBalancePaysByInvoiceUnion(invoiceUnion);
            //foreach (BalancePay tempB in alBalancePay)
            //{
            //    if (tempB.PayType.ID == "YS")
            //    {
            decimal vacancy = 0m;
            string accountNO = string.Empty;
            if (feeIntegrate.GetAccountVacancy(this.patient.PID.CardNO, ref vacancy,ref accountNO) > 0)
            {

                DialogResult digResult = MessageBox.Show("该发票存在账户支付，是否退费入户？", "提示", MessageBoxButtons.YesNo);
                if (digResult == DialogResult.Yes)
                {
                    isAccountPay = true;
                }
            }
                    //break;
            //    }
            //}
            //{F0114A43-2079-40dc-BE1E-04611B59B7D9}


            long returnValue = 0;//返回值,主要给医保用

            this.medcareInterfaceProxy.SetPactCode(this.patient.Pact.ID);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            DateTime nowTime = outpatientManager.GetDateTimeFromSysDateTime();
            int iReturn = 0;

            //获得负发票流水号
            string invoiceSeqNegative = outpatientManager.GetInvoiceCombNO();
            if (invoiceSeqNegative == null || invoiceSeqNegative == string.Empty)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();                
                MessageBox.Show("获得发票流水号失败!" + outpatientManager.Err);

                return -1;
            }
            #region 记录作废发票的金额
            decimal CancelTotCost = 0; //作废发票的总金额
            decimal CancelOwnCost = 0;//作废发票的自费金额
            decimal CancelPayCost = 0;//作废发票的自付金额
            decimal CancelPubCost = 0;//作废发票的公费金额
            string InvoiceNO = "";
            #endregion 
            //为了打退票，将发票明细存起来 {BB77678F-A3E1-4f62-9D8D-8D52C1C17F8B}
            ArrayList alInvoiceDetails = new ArrayList();
            //集中打印发票标识
            bool isaccount = (quitInvoices[0] as Balance).IsAccount;

            //作废发票表
            foreach (Balance invoice in this.quitInvoices)
            {
                InvoiceNO = invoice.Invoice.ID;
                invoice.User03 = this.cmbQuitReason.Tag.ToString();//退费原因
                //iReturn = outpatientManager.UpdateBalanceCancelType(invoice.Invoice.ID, invoice.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled, invoice.User03);
                iReturn = outpatientManager.UpdateBalanceCancelFeeType(invoice.Invoice.ID, invoice.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled, invoice.User03);

                if (iReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废原始发票信息出错!" + outpatientManager.Err);

                    return -1;
                }
                if (iReturn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该发票已经作废!");

                    return -1;
                }
                //插入负纪录冲账
                Balance invoClone = invoice.Clone();

                CancelTotCost += invoClone.FT.TotCost;
                CancelOwnCost += invoClone.FT.OwnCost;
                CancelPayCost += invoClone.FT.PayCost;
                CancelPubCost += invoClone.FT.PubCost;

                invoClone.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                invoClone.FT.TotCost = -invoClone.FT.TotCost;
                invoClone.FT.OwnCost = -invoClone.FT.OwnCost;
                invoClone.FT.PayCost = -invoClone.FT.PayCost;
                invoClone.FT.PubCost = -invoClone.FT.PubCost;
                invoClone.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                invoClone.CanceledInvoiceNO = invoice.ID;
                invoClone.CancelOper.ID = outpatientManager.Operator.ID;
                invoClone.BalanceOper.ID = outpatientManager.Operator.ID;//日结需要 改为当前退费人
                invoClone.BalanceOper.OperTime = nowTime;
                invoClone.CancelOper.OperTime = nowTime;
                invoClone.IsAuditing = false;
                invoClone.AuditingOper.ID = string.Empty;
                invoClone.AuditingOper.OperTime = DateTime.MinValue;
                invoClone.IsDayBalanced = false;
                invoClone.DayBalanceOper.OperTime = DateTime.MinValue;

                invoClone.CombNO = invoiceSeqNegative;                

                iReturn = outpatientManager.InsertBalance(invoClone);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入发票冲账信息出错!!" + outpatientManager.Err);

                    return -1;
                }

                //作废发票明细信息
                //处理发票明细表信息
                ArrayList alInvoiceDetail = outpatientManager.QueryBalanceListsByInvoiceNOAndInvoiceSequence(invoice.Invoice.ID, invoice.CombNO);
                if (alInvoiceDetail == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("获得发票明细出错!" + outpatientManager.Err);

                    return -1;
                }

                //作废发票明细表信息
                iReturn = outpatientManager.UpdateBalanceListCancelType(invoice.Invoice.ID, invoice.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废发票明细出错!" + outpatientManager.Err);

                    return -1;
                }
                foreach (BalanceList d in alInvoiceDetail)
                {
                    d.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                    d.BalanceBase.FT.OwnCost = -d.BalanceBase.FT.OwnCost;
                    d.BalanceBase.FT.PubCost = -d.BalanceBase.FT.PubCost;
                    d.BalanceBase.FT.PayCost = -d.BalanceBase.FT.PayCost;
                    d.BalanceBase.BalanceOper.OperTime = nowTime;
                    d.BalanceBase.BalanceOper.ID = outpatientManager.Operator.ID;
                    d.BalanceBase.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                    d.BalanceBase.IsDayBalanced = false;
                    d.BalanceBase.DayBalanceOper.ID = string.Empty;
                    d.BalanceBase.DayBalanceOper.OperTime = DateTime.MinValue;
                    //d.CombNO = invoiceSeqNegative;
                    ((Balance)d.BalanceBase).CombNO = invoiceSeqNegative;

                    iReturn = outpatientManager.InsertBalanceList(d);
                    if (iReturn <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入发票明细冲账信息出错!" + outpatientManager.Err);

                        return -1;
                    }
                }
                //为了打退票，将发票明细存起来 {D5FA97FA-8DBB-48e7-BF5B-8DF4049EEE2B}
                alInvoiceDetails.Add(alInvoiceDetail);
            }
            Balance invoiceInfo = ((Balance)quitInvoices[0]);
            //作废支付表

            #region //处理支付信息

            ArrayList payList = new ArrayList();
            BalancePay objPay = new BalancePay();
            objPay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
            //objPay.FT.TotCost = -(CancelPayCost + CancelOwnCost);
            objPay.FT.TotCost = -CancelOwnCost;
            objPay.FT.RealCost = Neusoft.HISFC.Components.OutpatientFee.Class.Function.DealCent(-CancelOwnCost);
            objPay.FT.OwnCost = -CancelOwnCost;
            objPay.InputOper.OperTime = nowTime;
            objPay.Invoice.ID = InvoiceNO;
            objPay.Squence = "99";
            if (isAccountPay)
            {
                objPay.PayType.ID = "YS";
                objPay.Bank.Account = accountNO;
            }
            else
            {
                objPay.PayType.ID = "CA";
             
            }
            objPay.InputOper.ID = outpatientManager.Operator.ID;
            objPay.InvoiceCombNO = invoiceSeqNegative;
            objPay.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
            objPay.IsChecked = false;
            objPay.CheckOper.ID = string.Empty;
            objPay.CheckOper.OperTime = DateTime.MinValue;
            objPay.BalanceOper.ID = string.Empty;
            //p.BalanceNo = 0;
            objPay.IsDayBalanced = false;
            objPay.IsAuditing = false;
            objPay.AuditingOper.OperTime = DateTime.MinValue;
            objPay.AuditingOper.ID = string.Empty;
            objPay.InvoiceUnion = invoiceUnion;
            if (patient.Pact.PayKind.ID == "02")
            {
                objPay.FT.OwnCost = -CancelOwnCost;
            }

            string choosePayMode = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.QUIT_PAY_MODE_SELECT, "1");
            //支付方式修改
            if (!invoiceInfo.IsAccount && choosePayMode == "0") //选择支付方式
            {
                //{9BB85825-7424-4c8c-9938-3FDDFEEC5B3D}
                //ArrayList payLists = new ArrayList();

                //payLists.Add(objPay);

                //Froms.frmChooseBalancePay frmTemp = new Neusoft.HISFC.Components.OutpatientFee.Froms.frmChooseBalancePay();
                //frmTemp.Init();
                //frmTemp.QuitPayModes = payLists;
                //frmTemp.InitQuitPayModes();
                //frmTemp.StartPosition = FormStartPosition.CenterScreen;
                //frmTemp.ShowDialog();

                //if (frmTemp.IsSelect == false) 
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("没有选择退费的支付方式，请重新退费!");

                //    return -1;
                //}

                //payLists = new ArrayList();
                //payLists = frmTemp.ModifiedPayModes;

                //objPay = payLists[0] as Neusoft.HISFC.Models.Fee.Outpatient.BalancePay;
                //{9BB85825-7424-4c8c-9938-3FDDFEEC5B3D}
            }

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 账户新增(账户冲掉扣费金额)
            if (objPay.PayType.ID =="YS")
            {
                if (feeIntegrate.AccountCancelPay(patient, objPay.FT.OwnCost, InvoiceNO, (outpatientManager.Operator as Employee).Dept.ID, "C") < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("账户退费入户失败！" + feeIntegrate.Err);
                    return -1;
                }
            }
            #endregion

            iReturn = outpatientManager.InsertBalancePay(objPay);
            if (iReturn <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                return -1;
            }
            payList.Add(objPay);
            #endregion

            #region 支付信息屏蔽liu.xq
            //ArrayList payModes = outpatientManager.QueryBalancePaysByInvoiceSequence(invoiceInfo.CombNO);
            //if (payModes == null)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show("获得患者支付信息出错！" + outpatientManager.Err);

            //    return -1;
            //}
            //iReturn = outpatientManager.UpdateCancelTyeByInvoiceSequence("4", invoiceInfo.CombNO, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
            //if (iReturn < 0)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show("更新支付方式出错!" + outpatientManager.Err);

            //    return -1;
            //}
            #endregion
            //string choosePayMode = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.QUIT_PAY_MODE_SELECT, "1");
            bool isCashPay = false;//是否现金冲账
            #region 支付信息屏蔽liu.xq
            if (choosePayMode == "0")//选择支付方式
            {
                //Froms.frmChooseBalancePay frmTemp = new Neusoft.HISFC.Components.OutpatientFee.Froms.frmChooseBalancePay();
                //frmTemp.Init();
                //frmTemp.QuitPayModes = payModes;
                //frmTemp.InitQuitPayModes();
                //bool isNeedShowPop = false;
                //foreach (BalancePay p in payModes)
                //{
                //    //如果支付方式都是现金,那么说明不需要选择冲帐支付方式了.
                //    if (p.PayType.ID.ToString() != "CA")
                //    {
                //        isNeedShowPop = true;
                //        break;
                //    }
                //}
                //if (isNeedShowPop)//需要弹出选择支付方式的窗口
                //{
                //    #region 冲账提示
                //    DialogResult diagResult = MessageBox.Show("是否转为现金冲账？", "谨慎选择！！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                //    if (diagResult == DialogResult.Yes)//现金冲
                //    {
                //        isCashPay = true;
                //        foreach (BalancePay p in payModes)
                //        {
                //            p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //            p.PayType.ID = "CA";
                //            p.FT.TotCost= -p.FT.TotCost;
                //            p.FT.RealCost = -p.FT.RealCost;
                //            p.InputOper.OperTime = nowTime;
                //            p.InputOper.ID = outpatientManager.Operator.ID;
                //            p.InvoiceCombNO = invoiceSeqNegative;
                //            p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //            p.IsChecked = false;
                //            p.CheckOper.ID = string.Empty;
                //            p.CheckOper.OperTime = DateTime.MinValue;
                //            p.BalanceOper.ID = string.Empty;
                //            //p.BalanceNo = 0;
                //            p.IsDayBalanced = false;
                //            p.IsAuditing = false;
                //            p.AuditingOper.OperTime = DateTime.MinValue;
                //            p.AuditingOper.ID = string.Empty;

                //            iReturn = outpatientManager.InsertBalancePay(p);
                //            if (iReturn <= 0)
                //            {
                //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //                return -1;
                //            }
                //        }
                //    }
                //    else //原始方式冲
                //    {
                //        foreach (BalancePay p in payModes)
                //        {
                //            p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //            p.FT.TotCost = -p.FT.TotCost;
                //            p.FT.RealCost = -p.FT.RealCost;
                //            p.InputOper.OperTime = nowTime;
                //            p.InputOper.ID = outpatientManager.Operator.ID;
                //            p.InvoiceCombNO = invoiceSeqNegative;
                //            p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //            p.IsChecked = false;
                //            p.CheckOper.ID = string.Empty;
                //            p.CheckOper.OperTime = DateTime.MinValue;
                //            p.BalanceOper.ID = string.Empty;
                //            //p.BalanceNo = 0;
                //            p.IsDayBalanced = false;
                //            p.IsAuditing = false;
                //            p.AuditingOper.OperTime = DateTime.MinValue;
                //            p.AuditingOper.ID = string.Empty;

                //            iReturn = outpatientManager.InsertBalancePay(p);
                //            if (iReturn <= 0)
                //            {
                //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //                return -1;
                //            }
                //        }
                //    }

                //    #endregion
                //}
                //else//不需要弹出选择支付方式窗口,说明单纯的现金支付方式,所以采用现金冲帐
                //{
                //    #region 纯现金
                //    foreach (BalancePay p in payModes)
                //    {
                //        p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //        p.FT.TotCost = -p.FT.TotCost;
                //        p.FT.RealCost = -p.FT.RealCost;
                //        p.InputOper.OperTime = nowTime;
                //        p.InputOper.ID = outpatientManager.Operator.ID;
                //        p.InvoiceCombNO = invoiceSeqNegative;
                //        p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //        p.IsChecked = false;
                //        p.CheckOper.ID = string.Empty;
                //        p.CheckOper.OperTime = DateTime.MinValue;
                //        p.BalanceOper.ID = string.Empty;
                //        //p.BalanceNo = 0;
                //        p.IsDayBalanced = false;
                //        p.IsAuditing = false;
                //        p.AuditingOper.OperTime = DateTime.MinValue;
                //        p.AuditingOper.ID = string.Empty;

                //        iReturn = outpatientManager.InsertBalancePay(p);
                //        if (iReturn <= 0)
                //        {
                //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //            MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //            return -1;
                //        }
                //    }
                //    #endregion
                //}
            }
           
            else//现金冲帐
            {
                //foreach (BalancePay p in payModes)
                //{
                //    p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //    p.FT.TotCost = -p.FT.TotCost;
                //    p.FT.RealCost = -p.FT.RealCost;
                //    p.InputOper.OperTime = nowTime;
                //    p.InputOper.ID = outpatientManager.Operator.ID;
                //    p.InvoiceCombNO = invoiceSeqNegative;
                //    p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //    p.IsChecked = false;
                //    p.CheckOper.ID = string.Empty;
                //    p.CheckOper.OperTime = DateTime.MinValue;
                //    p.BalanceOper.ID = string.Empty;
                    
                //    p.IsDayBalanced = false;
                //    p.IsAuditing = false;
                //    p.AuditingOper.OperTime = DateTime.MinValue;
                //    p.AuditingOper.ID = string.Empty;

                //    iReturn = outpatientManager.InsertBalancePay(p);
                //    if (iReturn <= 0)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //        return -1;
                //    }
                //}
            } 
            #endregion
            //处理费用明细
            ArrayList alFeeDetail = outpatientManager.QueryFeeItemListsByInvoiceSequence(invoiceInfo.CombNO);
            if (alFeeDetail == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获得患者费用明细出错!" + outpatientManager.Err);

                return -1;
            }
            iReturn = outpatientManager.UpdateFeeItemListCancelType(invoiceInfo.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
            if (iReturn <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("作废患者明细出错!" + outpatientManager.Err);

                return -1;
            }

            foreach (FeeItemList f in alFeeDetail)
            {
                f.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                f.FT.OwnCost = -f.FT.OwnCost;
                f.FT.PayCost = -f.FT.PayCost;
                f.FT.PubCost = -f.FT.PubCost;
                f.FT.TotCost = f.FT.OwnCost+f.FT.PubCost+f.FT.PayCost;
                f.Item.Qty = -f.Item.Qty;
                f.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                f.FeeOper.ID = outpatientManager.Operator.ID;
                f.FeeOper.OperTime = nowTime;
                f.ChargeOper.OperTime = nowTime;
                f.InvoiceCombNO = invoiceSeqNegative;

                iReturn = outpatientManager.InsertFeeItemList(f);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入费用明细冲帐信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            //this.t.BeginTransaction();



            this.medcareInterfaceProxy.BeginTranscation();
            //long returnValue = medcareInterfaceProxy.SetPactCode(this.patient.Pact.ID);

           
            returnValue = medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + medcareInterfaceProxy.ErrMsg);
                return -1;
            }

            returnValue = medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口或得患者信息失败") + medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = medcareInterfaceProxy.DeleteUploadedFeeDetailsOutpatient(this.patient, ref alFeeDetail);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口上传退费明细失败") + medcareInterfaceProxy.ErrMsg);

                return -1;
            }
            this.patient.SIMainInfo.InvoiceNo = ((Balance)quitInvoices[0]).Invoice.ID;
            returnValue = medcareInterfaceProxy.CancelBalanceOutpatient(this.patient, ref alFeeDetail);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口结算失败") + medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            
            
            //针对未核准退药信息
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList fQuit = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                        //有未确认的退药，作废退药申请!
                        if (fQuit.IsConfirmed == false)
                        {
                            iReturn = pharmacyIntegrate.CancelApplyOutClinic(fQuit.RecipeNO, fQuit.SequenceNO);
                            if (iReturn < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                medcareInterfaceProxy.Rollback();
                                MessageBox.Show("作废发药申请出错!药品可能已经发药，请刷新窗口重试");

                                return -1;
                            }
                        }
                    }
                }
            }
            //作废终端申请
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++) 
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag != null && this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList) 
                {
                    FeeItemList fQuit = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;

                    //有未确认的退药，作废退药申请!
                    if (fQuit.IsConfirmed == false)
                    {
                        iReturn = confirmIntegrate.CancelConfirmTerminal(fQuit.Order.ID, fQuit.Item.ID);
                        if (iReturn < 0)
                        {
                            medcareInterfaceProxy.Rollback();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("作废终端申请出错!" + confirmIntegrate.Err);

                            return -1;
                        }
                    }
                }
            }

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 更新退费申请退费标记
            Neusoft.HISFC.Models.Fee.ReturnApply returnApply = null;
            //DateTime operDate = outpatientManager.GetDateTimeFromSysDateTime();
            string operCode = outpatientManager.Operator.ID;
            foreach (FarPoint.Win.Spread.SheetView sv in fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.Rows.Count; i++)
                {
                    if (sv.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        returnApply = sv.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
                        returnApply.CancelType = CancelTypes.Valid;
                        returnApply.CancelOper.ID = operCode;
                        returnApply.CancelOper.OperTime = nowTime;
                        if (returnApplyManager.UpdateApplyCharge(returnApply) <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新申请表退费标记失败！" + returnApplyManager.Err);
                            return -1;
                        }
                    }
                }
            }

            #endregion

            #region 对物资退费部分进行退库
            //{143CA424-7AF9-493a-8601-2F7B1D635027}
            ArrayList alMate = new ArrayList();
            for (int i = 0; i < this.fpSpread2_Sheet2.RowCount; i++)
            {
                if (this.fpSpread2_Sheet2.Rows[i].Tag != null && this.fpSpread2_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList fQuit = this.fpSpread2_Sheet2.Rows[i].Tag as FeeItemList;

                    //非对照的物资 {40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    if (fQuit.Item.ItemType == EnumItemType.MatItem)
                    {
                        alMate.Add(fQuit);
                    }
                    else
                    {
                        if (fQuit.MateList.Count > 0)
                        {
                            alMate.Add(fQuit);
                        }
                    }
                }
            }
            if (alMate.Count > 0)
            {
                //退库
                if (mateIntegrate.MaterialFeeOutputBack(alMate) < 0)
                {
                    //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    MessageBox.Show("物资退库失败,\n" + mateIntegrate.Err);
                    
                    return -1;
                }
            }
            #endregion

            //对剩余项目收费!
            ArrayList feeDetails = new ArrayList();
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList f = (this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList).Clone();
                    f.FT.OwnCost = f.FT.PubCost = f.FT.PayCost = 0;
                    f.FT.OwnCost = f.FT.TotCost;
                    //f.ConfirmedQty = 0;
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text) > 0)//by yuyun 解决门诊已发药之后做半退，退费时全退的情况
                       
                    //if (f.Item.Qty > 0)
                    {
                        f.User03 = "HalfQuit";
                        feeDetails.Add(f);
                    }
                }
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList f = (this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList).Clone();
                    f.FT.OwnCost = f.FT.PubCost = f.FT.PayCost = 0;
                    f.FT.OwnCost = f.FT.TotCost;
                    //f.IsConfirmed = false;
                    //f.ConfirmedQty = 0;
                   // if (f.Item.Qty > 0)

                    //{06212A22-5FD4-4db3-838C-1790F75FF286}
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text) > 0)
                  
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug unDrugTemp = this.undrugManager.GetUndrugByCode(f.Item.ID);
                        if (unDrugTemp != null)
                        {
                            f.Item.IsNeedConfirm = unDrugTemp.IsNeedConfirm;
                            f.Item.IsNeedBespeak = unDrugTemp.IsNeedBespeak;
                        }

                        //{06212A22-5FD4-4db3-838C-1790F75FF286}
                        if (f.IsConfirmed == true)
                        {
                            int row = this.FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                            if (row != -1)
                            {
                                FeeItemList quitItem = this.fpSpread2_Sheet2.Rows[row].Tag as FeeItemList;
                                if(confirmIntegrate.UpdateOrDeleteTerminalConfirmApply(f.Order.ID,(int)(f.Item.Qty+quitItem.Item.Qty),(int)quitItem.Item.Qty,Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty,2)) == -1)
                                {
                                    medcareInterfaceProxy.Rollback();
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("更新终端确认信息出错!"+confirmIntegrate.Err);                                    
                                    return -1;
                                }
                            }
                        }


                        f.User03 = "HalfQuit";
                        feeDetails.Add(f);
                    }
                }
            }
            string returnCostString = string.Empty;

            //补收费用明细!;
            //{BBE9766A-A539-485e-A03B-9972DC675538} 退费补收
            ArrayList addFeeItemList = this.ucDisplay1.GetFeeItemList();
            if (addFeeItemList != null && addFeeItemList.Count > 0)
            {
                if (this.cmbRegDept.Tag == null || this.cmbRegDept.Tag.ToString() == string.Empty || this.cmbRegDept.Text.Trim() == string.Empty)
                {
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请选择补收费用的看诊科室!" + confirmIntegrate.Err);

                    return -1;
                }

                if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty || this.cmbDoct.Text.Trim() == string.Empty)
                {
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请选择补收费用的开立医生!" + confirmIntegrate.Err);

                    return -1;
                }

                foreach (FeeItemList f in addFeeItemList)
                {
                    string doctCode = string.Empty;
                    doctCode = this.cmbDoct.Tag.ToString();
                    Neusoft.HISFC.Models.Base.Employee empl = this.managerIntegrate.GetEmployeeInfo(doctCode);
                    if (empl != null)
                    {
                        f.RecipeOper.Dept.ID = empl.Dept.ID;
                    }
                    //看诊医生 {83283AE6-6D16-4b69-9B42-F2E0754FC8B2}
                    ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.Templet.Doct.ID = this.cmbDoct.Tag.ToString();

                    f.RecipeOper.ID = doctCode;
                    (f.Patient as Neusoft.HISFC.Models.Registration.Register).DoctorInfo.Templet.Dept.ID = this.cmbRegDept.Tag.ToString();
                    f.NoBackQty = f.Item.Qty;
                }

                feeDetails.AddRange(addFeeItemList);
            }
            //{BBE9766A-A539-485e-A03B-9972DC675538} 结束

            #region 半退
            if (feeDetails.Count > 0)
            {
                if (isHaveRebateCost) 
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该张发票存在优惠金额,请全退!");
                    medcareInterfaceProxy.Rollback();
                    return -1;
                }

                string errText = string.Empty, invoiceNo = string.Empty, realInvoiceNo = string.Empty;


                Neusoft.HISFC.Models.Registration.Register tmpReg = null;

                //如果不是体检患者,那么重新获得患者挂号信息
                if (!(this.patient.ChkKind == "1" || this.patient.ChkKind == "2"))
                {

                    tmpReg = registerIntegrate.GetByClinic(this.patient.ID);
                    if (tmpReg == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        medcareInterfaceProxy.Disconnect();
                        MessageBox.Show("获得挂号信息失败!" + this.registerIntegrate.Err);

                        return -1;
                    }
                    tmpReg.Pact = this.patient.Pact;

                    this.patient = tmpReg.Clone();
                }
                returnValue = medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
                if (returnValue == -1)
                {
                    medcareInterfaceProxy.Rollback();
                    medcareInterfaceProxy.Disconnect();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    MessageBox.Show("待遇接口获得接口患者基本信息失败!" + medcareInterfaceProxy.ErrMsg);

                    return -1;
                }
                if (tmpReg != null && tmpReg.IDCard != this.patient.IDCard)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    medcareInterfaceProxy.Rollback();
                    medcareInterfaceProxy.Disconnect();
                    MessageBox.Show("身份证与上次收费信息不符,可能选择错误!不能退费!");

                    return -1;
                }
                foreach (FeeItemList f in feeDetails)
                {
                    f.FeeOper.OperTime = nowTime;
                    f.FTSource = "0";
                }
                
              if (choosePayMode == "0")//选择支付方式
                {
                    decimal ownCost = 0, payCost = 0, pubCost = 0, totCostPayMode = 0; decimal overDrugFee = 0; decimal selfDrugFee = 0;

                    if (this.patient.Pact.PayKind.ID == "01" || this.patient.Pact.PayKind.ID == "03") //自费，直接累加各项目金额
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            ownCost += f.FT.OwnCost;
                            //payCost += f.FT.PayCost;
                            //pubCost += f.FT.PubCost;
                            totCostPayMode += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                            //if (f.Item.IsPharmacy)
                            if (f.Item.ItemType == EnumItemType.Drug)
                            {
                                overDrugFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(f.FT.ExcessCost);
                                selfDrugFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(f.FT.DrugOwnCost);
                            }

                            //f.NoBackQty = f.Item.Qty;
                        }
                    }
                    if (this.patient.Pact.PayKind.ID == "02")//医保
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            totCostPayMode += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                        ownCost = totCostPayMode - this.patient.SIMainInfo.PubCost - this.patient.SIMainInfo.PayCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                    }

                    ownCost = Neusoft.FrameWork.Public.String.FormatNumber(ownCost, 2);
                    payCost = Neusoft.FrameWork.Public.String.FormatNumber(payCost, 2);
                    pubCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost, 2);
                    totCostPayMode = Neusoft.FrameWork.Public.String.FormatNumber(totCostPayMode, 2);

                    Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientPopupFee frmBalance = new Froms.frmDealBalance();
                    //frmBalance.Trans = t;
                    //this.frmBalance.ucDealBalance1.FrmDisplay = frmDisplay;
                    frmBalance.Init();
                    frmBalance.IsCashPay = isCashPay;

                    //是否账户支付(退费时使用如果账户收费退费时返回现金为false，退到账户为true)
                    frmBalance.IsAccountPay = isAccountPay;

                    frmBalance.FeeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateFee(frmBalance_FeeButtonClicked);
                    this.patient.Memo = "门诊退费标记";
                    frmBalance.PatientInfo = this.patient;
                    frmBalance.SelfDrugCost = selfDrugFee;
                    frmBalance.OverDrugCost = overDrugFee;
                    frmBalance.RealCost = ownCost + payCost;
                    frmBalance.OwnCost = ownCost;
                    frmBalance.PayCost = payCost;
                    frmBalance.PubCost = pubCost;
                    frmBalance.TotCost = totCostPayMode;
                    frmBalance.TotOwnCost = ownCost + payCost;
                    frmBalance.FeeDetails = feeDetails;
                    frmBalance.IsQuitFee = true;
                    //frmBalance.Trans = this.t;

                    Neusoft.HISFC.Models.Base.Employee employee = this.outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;

                    int iReturnValue = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNo, ref realInvoiceNo, ref errText,null);
                    if (iReturnValue == -1)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }

                    //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
                    Class.Function.IsQuitFee = true;

                    ArrayList alInvoiceAndDetails = Class.Function.MakeInvoice(this.feeIntegrate, this.patient, feeDetails, invoiceNo, realInvoiceNo, ref errText);
                    if (alInvoiceAndDetails == null)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    foreach (Neusoft.HISFC.Models.Fee.Outpatient.Balance tempBalance in (ArrayList)alInvoiceAndDetails[0])
                    {
                        tempBalance.IsAccount = isaccount;
                    }

                    #region liuq 2007-8-27 发票费用明细
                    frmBalance.InvoiceFeeDetails = (ArrayList)alInvoiceAndDetails[2];
                    #endregion
                    frmBalance.InvoiceDetails = (ArrayList)alInvoiceAndDetails[1];

                    if (this.patient.Pact.PayKind.ID == "02"
                  || this.patient.Pact.PayKind.ID == "03")
                    {
                        ownCost = decimal.Zero;
                        payCost = decimal.Zero;
                        pubCost = decimal.Zero;
                        totCostPayMode = decimal.Zero;
                        //删除本次因为错误或者其他原因上传的明细
                        returnValue = this.medcareInterfaceProxy.DeleteUploadedFeeDetailsAllOutpatient(this.patient);

                        //重新上传所有明细
                        returnValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.patient, ref feeDetails);
                        if (returnValue == -1)
                        {
                            this.medcareInterfaceProxy.Rollback();
                            MessageBox.Show("上传费用明细失败!" + this.medcareInterfaceProxy.ErrMsg);

                            return -1;
                        }
                        returnValue = this.medcareInterfaceProxy.PreBalanceOutpatient(this.patient, ref feeDetails);
                        if (returnValue == -1)
                        {
                            MessageBox.Show("获得医保预结算信息失败!" + this.medcareInterfaceProxy.ErrMsg);
                            this.medcareInterfaceProxy.Rollback();
                            this.medcareInterfaceProxy.Disconnect();

                            return -1;
                        }

                        ownCost += this.patient.SIMainInfo.OwnCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                        //{21EEC08E-53DA-458b-BEA3-0036EF6E3D37}
                        //    + this.patient.SIMainInfo.OfficalCost
                        //    + this.patient.SIMainInfo.OverCost;
                        totCostPayMode += this.patient.SIMainInfo.PayCost;
                        totCostPayMode += this.patient.SIMainInfo.OwnCost;
                        totCostPayMode += this.patient.SIMainInfo.PubCost;
                            //+ this.patient.SIMainInfo.OfficalCost
                            //+ this.patient.SIMainInfo.OverCost;
                        frmBalance.RealCost = ownCost;
                        frmBalance.OwnCost = ownCost;
                        frmBalance.PayCost = payCost;
                        frmBalance.PubCost = pubCost;
                        frmBalance.TotCost = totCostPayMode;
                        frmBalance.TotOwnCost = ownCost;
                        ////断开待遇接口连接
                        //this.medcareInterfaceProxy.Rollback();
                        //this.medcareInterfaceProxy.Disconnect();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();

                        ////重新赋值
                        //invoice.FT.OwnCost = this.patient.SIMainInfo.OwnCost;
                        //invoice.FT.PubCost = this.patient.SIMainInfo.PubCost;
                        //invoice.FT.PayCost = this.patient.SIMainInfo.PayCost;
                        //        }
                        //    }

                        //}
                    }
                    againFeeItemLists = new ArrayList();

                    againFeeItemLists = feeDetails;
                    
                    frmBalance.Invoices = (ArrayList)alInvoiceAndDetails[0];

                    modifiedBalancePays = payList;

                    if (!((Form)frmBalance).Visible)
                    {
                        this.Focus();
                        frmBalance.SetControlFocus();
                        frmBalance.IsPushCancelButton = true;
                        ((Form)frmBalance).Location = new Point(this.Location.X + 150, this.Location.Y + 200);
                        ((Form)frmBalance).ShowDialog();
                    }
                    if (frmBalance.IsPushCancelButton)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        return -1;
                    }
                }
                else
                {

                    #region 按支付方式退
                    decimal ownCost = 0, payCost = 0, pubCost = 0; decimal totCost = 0;
                    if (this.patient.Pact.PayKind.ID == "01" || this.patient.Pact.PayKind.ID == "03") //自费，直接累加各项目金额
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            ownCost += f.FT.OwnCost;
                            payCost += f.FT.PayCost;
                            pubCost += f.FT.PubCost;
                            totCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                    }
                    if (this.patient.Pact.PayKind.ID == "02")//医保
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            totCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                        ownCost = totCost - this.patient.SIMainInfo.PubCost - this.patient.PayCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                    }

                    Neusoft.HISFC.Models.Base.Employee employee = this.outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;

                    iReturn = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNo, ref realInvoiceNo, ref errText, null);
                    if (iReturn < 0)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    //生成新发票
                  
                    //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
                    Class.Function.IsQuitFee = true;

                    ArrayList invoicesAndDetails = Class.Function.MakeInvoice(this.feeIntegrate, this.patient, feeDetails, invoiceNo, realInvoiceNo, ref errText, Neusoft.FrameWork.Management.PublicTrans.Trans);
                    if (invoicesAndDetails == null || invoicesAndDetails.Count == 0)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    if (this.patient.Pact.PayKind.ID == "02")
                    {
                        foreach (Balance invoice in (ArrayList)invoicesAndDetails[0])
                        {
                            if (invoice.Memo == "4")//记账发票!
                            {
                                invoice.FT.PubCost = pubCost;
                                invoice.FT.PayCost = payCost;
                                invoice.FT.OwnCost = invoice.FT.TotCost - pubCost - payCost;
                            }
                        }
                    }
                    ArrayList alTempInvoiceDetails = new ArrayList();
                    ArrayList alFinalInvoiceDetails = new ArrayList();
                    foreach (ArrayList alTemp in ((ArrayList)invoicesAndDetails[1]))
                    {
                        alTempInvoiceDetails.Add(alTemp[0]);
                    }
                    alFinalInvoiceDetails.Add(alTempInvoiceDetails);



                    BalancePay pFinal = new BalancePay();

                    //					foreach(FeeItemList f in feeDetails)
                    //					{
                    //						totCost += f.FT.OwnCost + f.FT.PayCost;
                    //					}
                    decimal orgCost = 0;
                    foreach (BalancePay p in payList)
                    {
                        //因为此时的支付方式为负
                        orgCost += -p.FT.RealCost;
                    }
                    decimal returnCost = orgCost - totCost;
                    decimal returnCostCent = Class.Function.DealCent(returnCost);
                    decimal centCost = returnCost - returnCostCent;
                    pFinal.FT.TotCost = totCost;
                    pFinal.FT.RealCost = totCost + centCost;
                    pFinal.PayType.Name = "现金";
                    pFinal.PayType.ID = "CA";

                    ArrayList alPay = new ArrayList();
                    alPay.Add(pFinal);

                    //退费,并且是默认发票号方式时,不需要再次更新发票号
                    this.feeIntegrate.IsNeedUpdateInvoiceNO = false;

                    //收费
                    bool bReturn = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.patient,
                        (ArrayList)invoicesAndDetails[0], alFinalInvoiceDetails, feeDetails, feeDetails, alPay, ref errText);

                    if (!bReturn)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        if (errText != string.Empty)
                        {
                            MessageBox.Show(errText);
                        }

                        return -1;
                    }
                    returnCostString = "应退金额: " + Class.Function.DealCent(returnCost).ToString();
                    tbQuitCash.Text = Class.Function.DealCent(returnCost).ToString(); 
                    #endregion
                }
         

             
                //Neusoft.FrameWork.Management.PublicTrans.Commit();
                //this.medcareInterfaceProxy.Commit();
                //MessageBox.Show("退费成功!" + "\n" + returnCostString);
            }
            #endregion
            else
            {
                decimal orgCost = 0;
                decimal otherCost = 0m;
                bool isHaveCard = false;
                #region liu.xq1008
                //foreach (BalancePay p in payModes)
                //{
                //    //因为此时的支付方式为负
                //    if (p.PayType.ID.ToString() == "CA")
                //    {
                //        orgCost += -p.FT.RealCost;
                //    }
                //    if (p.PayType.ID.ToString() != "CA")
                //    {
                //        isHaveCard = true;
                //        otherCost += -p.FT.RealCost;
                //    }
                //}
                #endregion
                if (isHaveCard)
                {
                    if (otherCost > 0)
                    {
                        returnCostString = "应退金额:现金 " + CancelOwnCost.ToString() + "  其他支付方式:" + CancelPubCost.ToString();
                    }
                }
                else
                {
                    if (isAccountPay)
                    {
                        returnCostString = "账户退费: " + CancelOwnCost.ToString();
                    }
                    else
                    {
                        returnCostString = "应退金额: " + CancelOwnCost.ToString();
                    }
                } 
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.medcareInterfaceProxy.Commit();

                this.ucCostDisplay1.Clear();
                this.ucDisplay1.Clear();
                this.ucInvoicePreview1.Clear();

                tbQuitCash.Text = CancelOwnCost.ToString();

                MessageBox.Show("退费成功!" + "\n" + returnCostString);
            }

            //打印负票 {EC3C448A-2E7C-4eff-9348-0AC37B40F438}
            if (this.isPrintBill)
            {
                string invoicePrintDll = null;

                invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

                if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                {
                    MessageBox.Show("没有设置发票打印参数，收费请维护!");

                }
                //发票
                ArrayList alInvoices = new ArrayList();
                Balance tmpInvoice = quitInvoices[0] as Balance;
                tmpInvoice.Invoice.ID += "(退费)";
                tmpInvoice.FT.TotCost = -tmpInvoice.FT.TotCost;
                tmpInvoice.FT.OwnCost = -tmpInvoice.FT.OwnCost;
                tmpInvoice.FT.PayCost = -tmpInvoice.FT.PayCost;
                tmpInvoice.FT.PubCost = -tmpInvoice.FT.PubCost;
                tmpInvoice.PrintTime = outpatientManager.GetDateTimeFromSysDateTime();
                alInvoices.Add(tmpInvoice);

                //发票明细
                ArrayList alIDetails = new ArrayList();
                foreach (ArrayList alInvoiceDetail in alInvoiceDetails)
                {
                    int sort = 0;
                    foreach (BalanceList balList in alInvoiceDetail)
                    {
                        sort++;
                        balList.BalanceBase.FT.TotCost = balList.BalanceBase.FT.OwnCost + balList.BalanceBase.FT.PayCost + balList.BalanceBase.FT.PubCost;
                        balList.FeeCodeStat.SortID = sort;
                        //balList.BalanceBase.FT.TotCost = -balList.BalanceBase.FT.TotCost;
                        //balList.BalanceBase.FT.OwnCost = -balList.BalanceBase.FT.OwnCost;
                        //balList.BalanceBase.FT.PayCost = -balList.BalanceBase.FT.PayCost;
                        //balList.BalanceBase.FT.PubCost = -balList.BalanceBase.FT.PubCost;
                    }
                }
                alIDetails.Add(alInvoiceDetails);

                //患者信息
                this.patient.SIMainInfo.TotCost = -this.patient.SIMainInfo.TotCost;
                this.patient.SIMainInfo.OwnCost = -this.patient.SIMainInfo.OwnCost;
                this.patient.SIMainInfo.PayCost = -this.patient.SIMainInfo.PayCost;
                this.patient.SIMainInfo.PubCost = -this.patient.SIMainInfo.PubCost;
                this.patient.SIMainInfo.OfficalCost = -this.patient.SIMainInfo.OfficalCost;
                this.patient.SIMainInfo.OverCost = -this.patient.SIMainInfo.OverCost;

                string errText = "";

                this.feeIntegrate.PrintInvoice(invoicePrintDll, this.patient, alInvoices, alIDetails, alFeeDetail, payList, false, ref errText);

            }

            return 1;
        }

        /// <summary>
        /// 保存退费
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int CancelFee()
        {
            DialogResult result = MessageBox.Show("是否要作废?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return -1;
            }

            //判断有效性
            if (!IsValid())
            {
                return -1;
            }

            long returnValue = 0;//返回值,主要给医保用

            this.medcareInterfaceProxy.SetPactCode(this.patient.Pact.ID);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            DateTime nowTime = outpatientManager.GetDateTimeFromSysDateTime();
            int iReturn = 0;

            //获得负发票流水号
            string invoiceSeqNegative = outpatientManager.GetInvoiceCombNO();
            if (invoiceSeqNegative == null || invoiceSeqNegative == string.Empty)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获得发票流水号失败!" + outpatientManager.Err);

                return -1;
            }
            #region 记录作废发票的金额
            decimal CancelTotCost = 0; //作废发票的总金额
            decimal CancelOwnCost = 0;//作废发票的自费金额
            decimal CancelPayCost = 0;//作废发票的自付金额
            decimal CancelPubCost = 0;//作废发票的公费金额
            string InvoiceNO = "";
            #endregion
            //为了打退票，将发票明细存起来 {BB77678F-A3E1-4f62-9D8D-8D52C1C17F8B}
            ArrayList alInvoiceDetails = new ArrayList();
            //作废发票表
            foreach (Balance invoice in this.quitInvoices)
            {
                InvoiceNO = invoice.Invoice.ID;
                invoice.User02 = this.cmbQuitReason.Tag.ToString();//作废原因
                iReturn = outpatientManager.UpdateCancelFeeType(invoice.Invoice.ID, invoice.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled, invoice.User02);
                if (iReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废原始发票信息出错!" + outpatientManager.Err);

                    return -1;
                }
                if (iReturn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该发票已经作废!");

                    return -1;
                }
                //插入负纪录冲账
                Balance invoClone = invoice.Clone();

                CancelTotCost += invoClone.FT.TotCost;
                CancelOwnCost += invoClone.FT.OwnCost;
                CancelPayCost += invoClone.FT.PayCost;
                CancelPubCost += invoClone.FT.PubCost;

                invoClone.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                invoClone.FT.TotCost = -invoClone.FT.TotCost;
                invoClone.FT.OwnCost = -invoClone.FT.OwnCost;
                invoClone.FT.PayCost = -invoClone.FT.PayCost;
                invoClone.FT.PubCost = -invoClone.FT.PubCost;
                invoClone.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                invoClone.CanceledInvoiceNO = invoice.ID;
                invoClone.CancelOper.ID = outpatientManager.Operator.ID;
                invoClone.BalanceOper.ID = outpatientManager.Operator.ID;//日结需要 改为当前退费人
                invoClone.BalanceOper.OperTime = nowTime;
                invoClone.CancelOper.OperTime = nowTime;
                invoClone.IsAuditing = false;
                invoClone.AuditingOper.ID = string.Empty;
                invoClone.AuditingOper.OperTime = DateTime.MinValue;
                invoClone.IsDayBalanced = false;
                invoClone.DayBalanceOper.OperTime = DateTime.MinValue;

                invoClone.CombNO = invoiceSeqNegative;                

                iReturn = outpatientManager.InsertBalance(invoClone);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入发票冲账信息出错!!" + outpatientManager.Err);

                    return -1;
                }

                //作废发票明细信息
                //处理发票明细表信息
                ArrayList alInvoiceDetail = outpatientManager.QueryBalanceListsByInvoiceNOAndInvoiceSequence(invoice.Invoice.ID, invoice.CombNO);
                if (alInvoiceDetail == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("获得发票明细出错!" + outpatientManager.Err);

                    return -1;
                }

                //作废发票明细表信息
                iReturn = outpatientManager.UpdateBalanceListCancelType(invoice.Invoice.ID, invoice.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废发票明细出错!" + outpatientManager.Err);

                    return -1;
                }
                foreach (BalanceList d in alInvoiceDetail)
                {
                    d.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                    d.BalanceBase.FT.OwnCost = -d.BalanceBase.FT.OwnCost;
                    d.BalanceBase.FT.PubCost = -d.BalanceBase.FT.PubCost;
                    d.BalanceBase.FT.PayCost = -d.BalanceBase.FT.PayCost;
                    d.BalanceBase.BalanceOper.OperTime = nowTime;
                    d.BalanceBase.BalanceOper.ID = outpatientManager.Operator.ID;
                    d.BalanceBase.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                    d.BalanceBase.IsDayBalanced = false;
                    d.BalanceBase.DayBalanceOper.ID = string.Empty;
                    d.BalanceBase.DayBalanceOper.OperTime = DateTime.MinValue;
                    //d.CombNO = invoiceSeqNegative;
                    ((Balance)d.BalanceBase).CombNO = invoiceSeqNegative;

                    iReturn = outpatientManager.InsertBalanceList(d);
                    if (iReturn <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入发票明细冲账信息出错!" + outpatientManager.Err);

                        return -1;
                    }
                }
                //为了打退票，将发票明细存起来 {D5FA97FA-8DBB-48e7-BF5B-8DF4049EEE2B}
                alInvoiceDetails.Add(alInvoiceDetail);
            }
            Balance invoiceInfo = ((Balance)quitInvoices[0]);
            //作废支付表

            #region //处理支付信息

            ArrayList payList = new ArrayList();
            BalancePay objPay = new BalancePay();
            objPay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
            objPay.FT.TotCost = -(CancelPayCost + CancelOwnCost);
            objPay.FT.RealCost = Neusoft.HISFC.Components.OutpatientFee.Class.Function.DealCent(-(CancelPayCost + CancelOwnCost));
            objPay.FT.OwnCost = -CancelOwnCost;
            objPay.InputOper.OperTime = nowTime;
            objPay.Invoice.ID = InvoiceNO;
            objPay.Squence = "99";
            if (invoiceInfo.IsAccount)
            {
                objPay.PayType.ID = "YS";
            }
            else
            {
                if (isCanacelFee)//{CFF9083A-007C-4a10-B3DC-1192B29A5C1C}
                {
                    objPay.PayType.ID = this.cmbUnPayMode.Tag.ToString();
                }
                else
                {
                    objPay.PayType.ID = "CA";
                }
            }
            objPay.InputOper.ID = outpatientManager.Operator.ID;
            objPay.InvoiceCombNO = invoiceSeqNegative;
            objPay.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
            objPay.IsChecked = false;
            objPay.CheckOper.ID = string.Empty;
            objPay.CheckOper.OperTime = DateTime.MinValue;
            objPay.BalanceOper.ID = string.Empty;
            //p.BalanceNo = 0;
            objPay.IsDayBalanced = false;
            objPay.IsAuditing = false;
            objPay.AuditingOper.OperTime = DateTime.MinValue;
            objPay.AuditingOper.ID = string.Empty;
            if (patient.Pact.PayKind.ID == "02")
            {
                objPay.FT.OwnCost = -CancelOwnCost;
            }

            string choosePayMode = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.QUIT_PAY_MODE_SELECT, "1");
            //支付方式修改
            if (!invoiceInfo.IsAccount && choosePayMode == "0") //选择支付方式
            {
                //{9BB85825-7424-4c8c-9938-3FDDFEEC5B3D}
                //ArrayList payLists = new ArrayList();

                //payLists.Add(objPay);

                //Froms.frmChooseBalancePay frmTemp = new Neusoft.HISFC.Components.OutpatientFee.Froms.frmChooseBalancePay();
                //frmTemp.Init();
                //frmTemp.QuitPayModes = payLists;
                //frmTemp.InitQuitPayModes();
                //frmTemp.StartPosition = FormStartPosition.CenterScreen;
                //frmTemp.ShowDialog();

                //if (frmTemp.IsSelect == false) 
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("没有选择退费的支付方式，请重新退费!");

                //    return -1;
                //}

                //payLists = new ArrayList();
                //payLists = frmTemp.ModifiedPayModes;

                //objPay = payLists[0] as Neusoft.HISFC.Models.Fee.Outpatient.BalancePay;
                //{9BB85825-7424-4c8c-9938-3FDDFEEC5B3D}
            }

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 账户新增(账户冲掉扣费金额)
            if (objPay.PayType.ID == "YS")
            {
                if (feeIntegrate.AccountCancelPay(patient, objPay.FT.OwnCost, InvoiceNO, (outpatientManager.Operator as Employee).Dept.ID, "C") < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("账户退费入户失败！" + feeIntegrate.Err);
                    return -1;
                }
            }
            #endregion

            iReturn = outpatientManager.InsertBalancePay(objPay);
            if (iReturn <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                return -1;
            }
            payList.Add(objPay);
            #endregion

            #region 支付信息屏蔽liu.xq
            //ArrayList payModes = outpatientManager.QueryBalancePaysByInvoiceSequence(invoiceInfo.CombNO);
            //if (payModes == null)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show("获得患者支付信息出错！" + outpatientManager.Err);

            //    return -1;
            //}
            //iReturn = outpatientManager.UpdateCancelTyeByInvoiceSequence("4", invoiceInfo.CombNO, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
            //if (iReturn < 0)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show("更新支付方式出错!" + outpatientManager.Err);

            //    return -1;
            //}
            #endregion
            //string choosePayMode = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.QUIT_PAY_MODE_SELECT, "1");
            bool isCashPay = false;//是否现金冲账
            #region 支付信息屏蔽liu.xq
            if (choosePayMode == "0")//选择支付方式
            {
                //Froms.frmChooseBalancePay frmTemp = new Neusoft.HISFC.Components.OutpatientFee.Froms.frmChooseBalancePay();
                //frmTemp.Init();
                //frmTemp.QuitPayModes = payModes;
                //frmTemp.InitQuitPayModes();
                //bool isNeedShowPop = false;
                //foreach (BalancePay p in payModes)
                //{
                //    //如果支付方式都是现金,那么说明不需要选择冲帐支付方式了.
                //    if (p.PayType.ID.ToString() != "CA")
                //    {
                //        isNeedShowPop = true;
                //        break;
                //    }
                //}
                //if (isNeedShowPop)//需要弹出选择支付方式的窗口
                //{
                //    #region 冲账提示
                //    DialogResult diagResult = MessageBox.Show("是否转为现金冲账？", "谨慎选择！！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                //    if (diagResult == DialogResult.Yes)//现金冲
                //    {
                //        isCashPay = true;
                //        foreach (BalancePay p in payModes)
                //        {
                //            p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //            p.PayType.ID = "CA";
                //            p.FT.TotCost= -p.FT.TotCost;
                //            p.FT.RealCost = -p.FT.RealCost;
                //            p.InputOper.OperTime = nowTime;
                //            p.InputOper.ID = outpatientManager.Operator.ID;
                //            p.InvoiceCombNO = invoiceSeqNegative;
                //            p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //            p.IsChecked = false;
                //            p.CheckOper.ID = string.Empty;
                //            p.CheckOper.OperTime = DateTime.MinValue;
                //            p.BalanceOper.ID = string.Empty;
                //            //p.BalanceNo = 0;
                //            p.IsDayBalanced = false;
                //            p.IsAuditing = false;
                //            p.AuditingOper.OperTime = DateTime.MinValue;
                //            p.AuditingOper.ID = string.Empty;

                //            iReturn = outpatientManager.InsertBalancePay(p);
                //            if (iReturn <= 0)
                //            {
                //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //                return -1;
                //            }
                //        }
                //    }
                //    else //原始方式冲
                //    {
                //        foreach (BalancePay p in payModes)
                //        {
                //            p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //            p.FT.TotCost = -p.FT.TotCost;
                //            p.FT.RealCost = -p.FT.RealCost;
                //            p.InputOper.OperTime = nowTime;
                //            p.InputOper.ID = outpatientManager.Operator.ID;
                //            p.InvoiceCombNO = invoiceSeqNegative;
                //            p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //            p.IsChecked = false;
                //            p.CheckOper.ID = string.Empty;
                //            p.CheckOper.OperTime = DateTime.MinValue;
                //            p.BalanceOper.ID = string.Empty;
                //            //p.BalanceNo = 0;
                //            p.IsDayBalanced = false;
                //            p.IsAuditing = false;
                //            p.AuditingOper.OperTime = DateTime.MinValue;
                //            p.AuditingOper.ID = string.Empty;

                //            iReturn = outpatientManager.InsertBalancePay(p);
                //            if (iReturn <= 0)
                //            {
                //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //                MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //                return -1;
                //            }
                //        }
                //    }

                //    #endregion
                //}
                //else//不需要弹出选择支付方式窗口,说明单纯的现金支付方式,所以采用现金冲帐
                //{
                //    #region 纯现金
                //    foreach (BalancePay p in payModes)
                //    {
                //        p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //        p.FT.TotCost = -p.FT.TotCost;
                //        p.FT.RealCost = -p.FT.RealCost;
                //        p.InputOper.OperTime = nowTime;
                //        p.InputOper.ID = outpatientManager.Operator.ID;
                //        p.InvoiceCombNO = invoiceSeqNegative;
                //        p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //        p.IsChecked = false;
                //        p.CheckOper.ID = string.Empty;
                //        p.CheckOper.OperTime = DateTime.MinValue;
                //        p.BalanceOper.ID = string.Empty;
                //        //p.BalanceNo = 0;
                //        p.IsDayBalanced = false;
                //        p.IsAuditing = false;
                //        p.AuditingOper.OperTime = DateTime.MinValue;
                //        p.AuditingOper.ID = string.Empty;

                //        iReturn = outpatientManager.InsertBalancePay(p);
                //        if (iReturn <= 0)
                //        {
                //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //            MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //            return -1;
                //        }
                //    }
                //    #endregion
                //}
            }

            else//现金冲帐
            {
                //foreach (BalancePay p in payModes)
                //{
                //    p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //    p.FT.TotCost = -p.FT.TotCost;
                //    p.FT.RealCost = -p.FT.RealCost;
                //    p.InputOper.OperTime = nowTime;
                //    p.InputOper.ID = outpatientManager.Operator.ID;
                //    p.InvoiceCombNO = invoiceSeqNegative;
                //    p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                //    p.IsChecked = false;
                //    p.CheckOper.ID = string.Empty;
                //    p.CheckOper.OperTime = DateTime.MinValue;
                //    p.BalanceOper.ID = string.Empty;

                //    p.IsDayBalanced = false;
                //    p.IsAuditing = false;
                //    p.AuditingOper.OperTime = DateTime.MinValue;
                //    p.AuditingOper.ID = string.Empty;

                //    iReturn = outpatientManager.InsertBalancePay(p);
                //    if (iReturn <= 0)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        MessageBox.Show("插入支付负信息出错!" + outpatientManager.Err);

                //        return -1;
                //    }
                //}
            }
            #endregion
            //处理费用明细
            ArrayList alFeeDetail = outpatientManager.QueryFeeItemListsByInvoiceSequence(invoiceInfo.CombNO);
            if (alFeeDetail == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获得患者费用明细出错!" + outpatientManager.Err);

                return -1;
            }
            iReturn = outpatientManager.UpdateFeeItemListCancelType(invoiceInfo.CombNO, nowTime, Neusoft.HISFC.Models.Base.CancelTypes.Canceled);
            if (iReturn <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("作废患者明细出错!" + outpatientManager.Err);

                return -1;
            }

            foreach (FeeItemList f in alFeeDetail)
            {
                f.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                f.FT.OwnCost = -f.FT.OwnCost;
                f.FT.PayCost = -f.FT.PayCost;
                f.FT.PubCost = -f.FT.PubCost;
                f.FT.TotCost = f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                f.Item.Qty = -f.Item.Qty;
                f.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                f.FeeOper.ID = outpatientManager.Operator.ID;
                f.FeeOper.OperTime = nowTime;
                f.ChargeOper.OperTime = nowTime;
                f.InvoiceCombNO = invoiceSeqNegative;

                iReturn = outpatientManager.InsertFeeItemList(f);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入费用明细冲帐信息出错!" + outpatientManager.Err);

                    return -1;
                }
            }

            //this.t.BeginTransaction();



            this.medcareInterfaceProxy.BeginTranscation();
            //long returnValue = medcareInterfaceProxy.SetPactCode(this.patient.Pact.ID);


            returnValue = medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + medcareInterfaceProxy.ErrMsg);
                return -1;
            }

            returnValue = medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口或得患者信息失败") + medcareInterfaceProxy.ErrMsg);
                return -1;
            }
            returnValue = medcareInterfaceProxy.DeleteUploadedFeeDetailsOutpatient(this.patient, ref alFeeDetail);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口上传退费明细失败") + medcareInterfaceProxy.ErrMsg);

                return -1;
            }
            this.patient.SIMainInfo.InvoiceNo = ((Balance)quitInvoices[0]).Invoice.ID;
            returnValue = medcareInterfaceProxy.CancelBalanceOutpatient(this.patient, ref alFeeDetail);
            if (returnValue != 1)
            {
                medcareInterfaceProxy.Rollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口结算失败") + medcareInterfaceProxy.ErrMsg);

                return -1;
            }



            //针对未核准退药信息
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList fQuit = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;
                        //有未确认的退药，作废退药申请!
                        if (fQuit.IsConfirmed == false)
                        {
                            iReturn = pharmacyIntegrate.CancelApplyOutClinic(fQuit.RecipeNO, fQuit.SequenceNO);
                            if (iReturn < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                medcareInterfaceProxy.Rollback();
                                MessageBox.Show("作废发药申请出错!药品可能已经发药，请刷新窗口重试");

                                return -1;
                            }
                        }
                    }
                }
            }
            //作废终端申请
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag != null && this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList fQuit = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;

                    //有未确认的退药，作废退药申请!
                    if (fQuit.IsConfirmed == false)
                    {
                        iReturn = confirmIntegrate.CancelConfirmTerminal(fQuit.Order.ID, fQuit.Item.ID);
                        if (iReturn < 0)
                        {
                            medcareInterfaceProxy.Rollback();
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("作废终端申请出错!" + confirmIntegrate.Err);

                            return -1;
                        }
                    }
                }
            }

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 更新退费申请退费标记
            Neusoft.HISFC.Models.Fee.ReturnApply returnApply = null;
            //DateTime operDate = outpatientManager.GetDateTimeFromSysDateTime();
            string operCode = outpatientManager.Operator.ID;
            foreach (FarPoint.Win.Spread.SheetView sv in fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.Rows.Count; i++)
                {
                    if (sv.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        returnApply = sv.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
                        returnApply.CancelType = CancelTypes.Valid;
                        returnApply.CancelOper.ID = operCode;
                        returnApply.CancelOper.OperTime = nowTime;
                        if (returnApplyManager.UpdateApplyCharge(returnApply) <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新申请表退费标记失败！" + returnApplyManager.Err);
                            return -1;
                        }
                    }
                }
            }

            #endregion

            #region 对物资退费部分进行退库
            //{143CA424-7AF9-493a-8601-2F7B1D635027}
            ArrayList alMate = new ArrayList();
            for (int i = 0; i < this.fpSpread2_Sheet2.RowCount; i++)
            {
                if (this.fpSpread2_Sheet2.Rows[i].Tag != null && this.fpSpread2_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList fQuit = this.fpSpread2_Sheet2.Rows[i].Tag as FeeItemList;

                    //非对照的物资 {40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    if (fQuit.Item.ItemType == EnumItemType.MatItem)
                    {
                        alMate.Add(fQuit);
                    }
                    else
                    {
                        if (fQuit.MateList.Count > 0)
                        {
                            alMate.Add(fQuit);
                        }
                    }
                }
            }
            if (alMate.Count > 0)
            {
                //退库
                if (mateIntegrate.MaterialFeeOutputBack(alMate) < 0)
                {
                    //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    MessageBox.Show("物资退库失败,\n" + mateIntegrate.Err);

                    return -1;
                }
            }
            #endregion

            //对剩余项目收费!
            ArrayList feeDetails = new ArrayList();
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList f = (this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList).Clone();
                    f.FT.OwnCost = f.FT.PubCost = f.FT.PayCost = 0;
                    f.FT.OwnCost = f.FT.TotCost;
                    //f.ConfirmedQty = 0;
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text) > 0)//by yuyun 解决门诊已发药之后做半退，退费时全退的情况

                    //if (f.Item.Qty > 0)
                    {
                        f.User03 = "HalfQuit";
                        feeDetails.Add(f);
                    }
                }
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList f = (this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList).Clone();
                    f.FT.OwnCost = f.FT.PubCost = f.FT.PayCost = 0;
                    f.FT.OwnCost = f.FT.TotCost;
                    //f.IsConfirmed = false;
                    //f.ConfirmedQty = 0;
                    // if (f.Item.Qty > 0)

                    //{06212A22-5FD4-4db3-838C-1790F75FF286}
                    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text) > 0)
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug unDrugTemp = this.undrugManager.GetUndrugByCode(f.Item.ID);
                        if (unDrugTemp != null)
                        {
                            f.Item.IsNeedConfirm = unDrugTemp.IsNeedConfirm;
                            f.Item.IsNeedBespeak = unDrugTemp.IsNeedBespeak;
                        }

                        //{06212A22-5FD4-4db3-838C-1790F75FF286}
                        if (f.IsConfirmed == true)
                        {
                            int row = this.FindItem(f.RecipeNO, f.SequenceNO, this.fpSpread2_Sheet2);
                            if (row != -1)
                            {
                                FeeItemList quitItem = this.fpSpread2_Sheet2.Rows[row].Tag as FeeItemList;
                                if (confirmIntegrate.UpdateOrDeleteTerminalConfirmApply(f.Order.ID, (int)(f.Item.Qty + quitItem.Item.Qty), (int)quitItem.Item.Qty, Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty, 2)) == -1)
                                {
                                    medcareInterfaceProxy.Rollback();
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("更新终端确认信息出错!" + confirmIntegrate.Err);
                                    return -1;
                                }
                            }
                        }


                        f.User03 = "HalfQuit";
                        feeDetails.Add(f);
                    }
                }
            }
            string returnCostString = string.Empty;

            //补收费用明细!;
            //{BBE9766A-A539-485e-A03B-9972DC675538} 退费补收
            ArrayList addFeeItemList = this.ucDisplay1.GetFeeItemList();
            if (addFeeItemList != null && addFeeItemList.Count > 0)
            {
                if (this.cmbRegDept.Tag == null || this.cmbRegDept.Tag.ToString() == string.Empty || this.cmbRegDept.Text.Trim() == string.Empty)
                {
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请选择补收费用的看诊科室!" + confirmIntegrate.Err);

                    return -1;
                }

                if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty || this.cmbDoct.Text.Trim() == string.Empty)
                {
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请选择补收费用的开立医生!" + confirmIntegrate.Err);

                    return -1;
                }

                foreach (FeeItemList f in addFeeItemList)
                {
                    string doctCode = string.Empty;
                    doctCode = this.cmbDoct.Tag.ToString();
                    Neusoft.HISFC.Models.Base.Employee empl = this.managerIntegrate.GetEmployeeInfo(doctCode);
                    if (empl != null)
                    {
                        f.RecipeOper.Dept.ID = empl.Dept.ID;
                    }
                    //看诊医生 {83283AE6-6D16-4b69-9B42-F2E0754FC8B2}
                    ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.Templet.Doct.ID = this.cmbDoct.Tag.ToString();

                    f.RecipeOper.ID = doctCode;
                    (f.Patient as Neusoft.HISFC.Models.Registration.Register).DoctorInfo.Templet.Dept.ID = this.cmbRegDept.Tag.ToString();
                    f.NoBackQty = f.Item.Qty;
                }

                feeDetails.AddRange(addFeeItemList);
            }
            //{BBE9766A-A539-485e-A03B-9972DC675538} 结束

            #region 半退
            if (feeDetails.Count > 0)
            {
                if (isHaveRebateCost)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该张发票存在优惠金额,请全退!");
                    medcareInterfaceProxy.Rollback();
                    return -1;
                }

                string errText = string.Empty, invoiceNo = string.Empty, realInvoiceNo = string.Empty;


                Neusoft.HISFC.Models.Registration.Register tmpReg = null;

                //如果不是体检患者,那么重新获得患者挂号信息
                if (!(this.patient.ChkKind == "1" || this.patient.ChkKind == "2"))
                {

                    tmpReg = registerIntegrate.GetByClinic(this.patient.ID);
                    if (tmpReg == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        medcareInterfaceProxy.Disconnect();
                        MessageBox.Show("获得挂号信息失败!" + this.registerIntegrate.Err);

                        return -1;
                    }
                    tmpReg.Pact = this.patient.Pact;

                    this.patient = tmpReg.Clone();
                }
                returnValue = medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
                if (returnValue == -1)
                {
                    medcareInterfaceProxy.Rollback();
                    medcareInterfaceProxy.Disconnect();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    MessageBox.Show("待遇接口获得接口患者基本信息失败!" + medcareInterfaceProxy.ErrMsg);

                    return -1;
                }
                if (tmpReg != null && tmpReg.IDCard != this.patient.IDCard)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    medcareInterfaceProxy.Rollback();
                    medcareInterfaceProxy.Disconnect();
                    MessageBox.Show("身份证与上次收费信息不符,可能选择错误!不能退费!");

                    return -1;
                }
                foreach (FeeItemList f in feeDetails)
                {
                    f.FeeOper.OperTime = nowTime;
                    f.FTSource = "0";
                }

                if (choosePayMode == "0")//选择支付方式
                {
                    decimal ownCost = 0, payCost = 0, pubCost = 0, totCostPayMode = 0; decimal overDrugFee = 0; decimal selfDrugFee = 0;

                    if (this.patient.Pact.PayKind.ID == "01" || this.patient.Pact.PayKind.ID == "03") //自费，直接累加各项目金额
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            ownCost += f.FT.OwnCost;
                            //payCost += f.FT.PayCost;
                            //pubCost += f.FT.PubCost;
                            totCostPayMode += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                            //if (f.Item.IsPharmacy)
                            if (f.Item.ItemType == EnumItemType.Drug)
                            {
                                overDrugFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(f.FT.ExcessCost);
                                selfDrugFee += Neusoft.FrameWork.Function.NConvert.ToDecimal(f.FT.DrugOwnCost);
                            }

                            //f.NoBackQty = f.Item.Qty;
                        }
                    }
                    if (this.patient.Pact.PayKind.ID == "02")//医保
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            totCostPayMode += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                        ownCost = totCostPayMode - this.patient.SIMainInfo.PubCost - this.patient.SIMainInfo.PayCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                    }

                    ownCost = Neusoft.FrameWork.Public.String.FormatNumber(ownCost, 2);
                    payCost = Neusoft.FrameWork.Public.String.FormatNumber(payCost, 2);
                    pubCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost, 2);
                    totCostPayMode = Neusoft.FrameWork.Public.String.FormatNumber(totCostPayMode, 2);

                    Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientPopupFee frmBalance = new Froms.frmDealBalance();
                    //frmBalance.Trans = t;
                    //this.frmBalance.ucDealBalance1.FrmDisplay = frmDisplay;
                    frmBalance.Init();
                    frmBalance.IsCashPay = isCashPay;
                    frmBalance.FeeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateFee(frmBalance_FeeButtonClicked);
                    frmBalance.PatientInfo = this.patient;
                    frmBalance.SelfDrugCost = selfDrugFee;
                    frmBalance.OverDrugCost = overDrugFee;
                    frmBalance.RealCost = ownCost + payCost;
                    frmBalance.OwnCost = ownCost;
                    frmBalance.PayCost = payCost;
                    frmBalance.PubCost = pubCost;
                    frmBalance.TotCost = totCostPayMode;
                    frmBalance.TotOwnCost = ownCost + payCost;
                    frmBalance.FeeDetails = feeDetails;
                    frmBalance.IsQuitFee = true;
                    //frmBalance.Trans = this.t;

                    Neusoft.HISFC.Models.Base.Employee employee = this.outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;

                    int iReturnValue = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNo, ref realInvoiceNo, ref errText, null);
                    if (iReturnValue == -1)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }

                    //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
                    Class.Function.IsQuitFee = true;

                    ArrayList alInvoiceAndDetails = Class.Function.MakeInvoice(this.feeIntegrate, this.patient, feeDetails, invoiceNo, realInvoiceNo, ref errText);
                    if (alInvoiceAndDetails == null)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    #region liuq 2007-8-27 发票费用明细
                    frmBalance.InvoiceFeeDetails = (ArrayList)alInvoiceAndDetails[2];
                    #endregion
                    frmBalance.InvoiceDetails = (ArrayList)alInvoiceAndDetails[1];

                    if (this.patient.Pact.PayKind.ID == "02"
                  || this.patient.Pact.PayKind.ID == "03")
                    {
                        ownCost = decimal.Zero;
                        payCost = decimal.Zero;
                        pubCost = decimal.Zero;
                        totCostPayMode = decimal.Zero;
                        //foreach (Balance invoice in (ArrayList)alInvoiceAndDetails[0])
                        //{
                        //    if (invoice.Memo == "4")//记账发票!
                        //    {
                        //        invoice.FT.PubCost = pubCost;
                        //        invoice.FT.PayCost = payCost;
                        //        invoice.FT.OwnCost = invoice.FT.TotCost - pubCost - payCost;
                        //    }
                        //      ArrayList tempFeeItemListArray = (ArrayList)alInvoiceAndDetails[2];
                        //    for (int i = 0; i < tempFeeItemListArray.Count; i++)
                        //    {

                        //        FeeItemList tempFeeItemList = ((ArrayList)tempFeeItemListArray[i])[0] as FeeItemList;

                        //        if (invoice.Invoice.ID == tempFeeItemList.Invoice.ID)
                        //        {
                        //            ArrayList myFeeItemlist = new ArrayList();
                        //            myFeeItemlist = (ArrayList)tempFeeItemListArray[i];
                        //删除本次因为错误或者其他原因上传的明细
                        returnValue = this.medcareInterfaceProxy.DeleteUploadedFeeDetailsAllOutpatient(this.patient);

                        //重新上传所有明细
                        returnValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.patient, ref feeDetails);
                        if (returnValue == -1)
                        {
                            this.medcareInterfaceProxy.Rollback();
                            MessageBox.Show("上传费用明细失败!" + this.medcareInterfaceProxy.ErrMsg);

                            return -1;
                        }
                        returnValue = this.medcareInterfaceProxy.PreBalanceOutpatient(this.patient, ref feeDetails);
                        if (returnValue == -1)
                        {
                            MessageBox.Show("获得医保预结算信息失败!" + this.medcareInterfaceProxy.ErrMsg);
                            this.medcareInterfaceProxy.Rollback();
                            this.medcareInterfaceProxy.Disconnect();

                            return -1;
                        }

                        ownCost += this.patient.SIMainInfo.OwnCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                        //{21EEC08E-53DA-458b-BEA3-0036EF6E3D37}
                        //    + this.patient.SIMainInfo.OfficalCost
                        //    + this.patient.SIMainInfo.OverCost;
                        totCostPayMode += this.patient.SIMainInfo.PayCost;
                        totCostPayMode += this.patient.SIMainInfo.OwnCost;
                        totCostPayMode += this.patient.SIMainInfo.PubCost;
                        //+ this.patient.SIMainInfo.OfficalCost
                        //+ this.patient.SIMainInfo.OverCost;
                        frmBalance.RealCost = ownCost;
                        frmBalance.OwnCost = ownCost;
                        frmBalance.PayCost = payCost;
                        frmBalance.PubCost = pubCost;
                        frmBalance.TotCost = totCostPayMode;
                        frmBalance.TotOwnCost = ownCost;
                        ////断开待遇接口连接
                        //this.medcareInterfaceProxy.Rollback();
                        //this.medcareInterfaceProxy.Disconnect();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();

                        ////重新赋值
                        //invoice.FT.OwnCost = this.patient.SIMainInfo.OwnCost;
                        //invoice.FT.PubCost = this.patient.SIMainInfo.PubCost;
                        //invoice.FT.PayCost = this.patient.SIMainInfo.PayCost;
                        //        }
                        //    }

                        //}
                    }
                    againFeeItemLists = new ArrayList();

                    againFeeItemLists = feeDetails;

                    frmBalance.Invoices = (ArrayList)alInvoiceAndDetails[0];

                    modifiedBalancePays = payList;

                    if (!((Form)frmBalance).Visible)
                    {
                        this.Focus();
                        frmBalance.SetControlFocus();
                        frmBalance.IsPushCancelButton = true;
                        ((Form)frmBalance).Location = new Point(this.Location.X + 150, this.Location.Y + 200);
                        ((Form)frmBalance).ShowDialog();
                    }
                    if (frmBalance.IsPushCancelButton)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        return -1;
                    }
                }
                else
                {

                    #region 按支付方式退
                    decimal ownCost = 0, payCost = 0, pubCost = 0; decimal totCost = 0;
                    if (this.patient.Pact.PayKind.ID == "01" || this.patient.Pact.PayKind.ID == "03") //自费，直接累加各项目金额
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            ownCost += f.FT.OwnCost;
                            payCost += f.FT.PayCost;
                            pubCost += f.FT.PubCost;
                            totCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                    }
                    if (this.patient.Pact.PayKind.ID == "02")//医保
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            totCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                        }
                        ownCost = totCost - this.patient.SIMainInfo.PubCost - this.patient.PayCost;
                        payCost += this.patient.SIMainInfo.PayCost;
                        pubCost += this.patient.SIMainInfo.PubCost;
                    }

                    Neusoft.HISFC.Models.Base.Employee employee = this.outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;

                    iReturn = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNo, ref realInvoiceNo, ref errText, null);
                    if (iReturn < 0)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    //生成新发票

                    //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
                    Class.Function.IsQuitFee = true;

                    ArrayList invoicesAndDetails = Class.Function.MakeInvoice(this.feeIntegrate, this.patient, feeDetails, invoiceNo, realInvoiceNo, ref errText, Neusoft.FrameWork.Management.PublicTrans.Trans);
                    if (invoicesAndDetails == null || invoicesAndDetails.Count == 0)
                    {
                        medcareInterfaceProxy.Rollback();
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);

                        return -1;
                    }
                    if (this.patient.Pact.PayKind.ID == "02")
                    {
                        foreach (Balance invoice in (ArrayList)invoicesAndDetails[0])
                        {
                            if (invoice.Memo == "4")//记账发票!
                            {
                                invoice.FT.PubCost = pubCost;
                                invoice.FT.PayCost = payCost;
                                invoice.FT.OwnCost = invoice.FT.TotCost - pubCost - payCost;
                            }
                        }
                    }
                    ArrayList alTempInvoiceDetails = new ArrayList();
                    ArrayList alFinalInvoiceDetails = new ArrayList();
                    foreach (ArrayList alTemp in ((ArrayList)invoicesAndDetails[1]))
                    {
                        alTempInvoiceDetails.Add(alTemp[0]);
                    }
                    alFinalInvoiceDetails.Add(alTempInvoiceDetails);



                    BalancePay pFinal = new BalancePay();

                    //					foreach(FeeItemList f in feeDetails)
                    //					{
                    //						totCost += f.FT.OwnCost + f.FT.PayCost;
                    //					}
                    decimal orgCost = 0;
                    foreach (BalancePay p in payList)
                    {
                        //因为此时的支付方式为负
                        orgCost += -p.FT.RealCost;
                    }
                    decimal returnCost = orgCost - totCost;
                    decimal returnCostCent = Class.Function.DealCent(returnCost);
                    decimal centCost = returnCost - returnCostCent;
                    pFinal.FT.TotCost = totCost;
                    pFinal.FT.RealCost = totCost + centCost;
                    pFinal.PayType.Name = "现金";
                    pFinal.PayType.ID = "CA";

                    ArrayList alPay = new ArrayList();
                    alPay.Add(pFinal);

                    //退费,并且是默认发票号方式时,不需要再次更新发票号
                    this.feeIntegrate.IsNeedUpdateInvoiceNO = false;

                    //收费
                    bool bReturn = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.patient,
                        (ArrayList)invoicesAndDetails[0], alFinalInvoiceDetails, feeDetails, feeDetails, alPay, ref errText);

                    if (!bReturn)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        medcareInterfaceProxy.Rollback();
                        if (errText != string.Empty)
                        {
                            MessageBox.Show(errText);
                        }

                        return -1;
                    }
                    returnCostString = "应退金额: " + Class.Function.DealCent(returnCost).ToString();
                    tbQuitCash.Text = Class.Function.DealCent(returnCost).ToString();
                    #endregion
                }



                //Neusoft.FrameWork.Management.PublicTrans.Commit();
                //this.medcareInterfaceProxy.Commit();
                //MessageBox.Show("退费成功!" + "\n" + returnCostString);
            }
            #endregion
            else
            {
                decimal orgCost = 0;
                decimal otherCost = 0m;
                bool isHaveCard = false;
                #region liu.xq1008
                //foreach (BalancePay p in payModes)
                //{
                //    //因为此时的支付方式为负
                //    if (p.PayType.ID.ToString() == "CA")
                //    {
                //        orgCost += -p.FT.RealCost;
                //    }
                //    if (p.PayType.ID.ToString() != "CA")
                //    {
                //        isHaveCard = true;
                //        otherCost += -p.FT.RealCost;
                //    }
                //}
                #endregion
                if (isHaveCard)
                {
                    if (otherCost > 0)
                    {
                        returnCostString = "应退金额:现金 " + CancelOwnCost.ToString() + "  其他支付方式:" + CancelPubCost.ToString();
                    }
                    else
                    {
                        returnCostString = "应退金额: " + CancelOwnCost.ToString();
                    }
                }
                else
                {
                    returnCostString = "应退金额: " + Class.Function.DealCent(CancelOwnCost).ToString();
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.medcareInterfaceProxy.Commit();

                this.ucCostDisplay1.Clear();
                this.ucDisplay1.Clear();
                this.ucInvoicePreview1.Clear();

                tbQuitCash.Text = CancelOwnCost.ToString();

                MessageBox.Show("作废成功!" + "\n" + returnCostString);
            }

            //打印负票 {EC3C448A-2E7C-4eff-9348-0AC37B40F438}
            if (this.isPrintBill)
            {
                string invoicePrintDll = null;

                invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

                if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                {
                    MessageBox.Show("没有设置发票打印参数，收费请维护!");

                }
                //发票
                ArrayList alInvoices = new ArrayList();
                Balance tmpInvoice = quitInvoices[0] as Balance;
                tmpInvoice.Invoice.ID += "(退费)";
                tmpInvoice.FT.TotCost = -tmpInvoice.FT.TotCost;
                tmpInvoice.FT.OwnCost = -tmpInvoice.FT.OwnCost;
                tmpInvoice.FT.PayCost = -tmpInvoice.FT.PayCost;
                tmpInvoice.FT.PubCost = -tmpInvoice.FT.PubCost;
                tmpInvoice.PrintTime = outpatientManager.GetDateTimeFromSysDateTime();
                alInvoices.Add(tmpInvoice);

                //发票明细
                ArrayList alIDetails = new ArrayList();
                foreach (ArrayList alInvoiceDetail in alInvoiceDetails)
                {
                    int sort = 0;
                    foreach (BalanceList balList in alInvoiceDetail)
                    {
                        sort++;
                        balList.BalanceBase.FT.TotCost = balList.BalanceBase.FT.OwnCost + balList.BalanceBase.FT.PayCost + balList.BalanceBase.FT.PubCost;
                        balList.FeeCodeStat.SortID = sort;
                        //balList.BalanceBase.FT.TotCost = -balList.BalanceBase.FT.TotCost;
                        //balList.BalanceBase.FT.OwnCost = -balList.BalanceBase.FT.OwnCost;
                        //balList.BalanceBase.FT.PayCost = -balList.BalanceBase.FT.PayCost;
                        //balList.BalanceBase.FT.PubCost = -balList.BalanceBase.FT.PubCost;
                    }
                }
                alIDetails.Add(alInvoiceDetails);

                //患者信息
                this.patient.SIMainInfo.TotCost = -this.patient.SIMainInfo.TotCost;
                this.patient.SIMainInfo.OwnCost = -this.patient.SIMainInfo.OwnCost;
                this.patient.SIMainInfo.PayCost = -this.patient.SIMainInfo.PayCost;
                this.patient.SIMainInfo.PubCost = -this.patient.SIMainInfo.PubCost;
                this.patient.SIMainInfo.OfficalCost = -this.patient.SIMainInfo.OfficalCost;
                this.patient.SIMainInfo.OverCost = -this.patient.SIMainInfo.OverCost;

                string errText = "";

                this.feeIntegrate.PrintInvoice(invoicePrintDll, this.patient, alInvoices, alIDetails, alFeeDetail, payList, false, ref errText);

            }

            return 1;
        }

        /// <summary>
        /// 显示计算器
        /// </summary>
        /// <returns></returns>
        protected virtual int DisplayCalc()
        {
            string tempValue = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.CALCTYPE, "0");

            if (tempValue == "0")
            {
                System.Diagnostics.Process.Start("CALC.EXE");
            }
            else if (tempValue == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(
                    new Neusoft.HISFC.Components.Common.Controls.ucCalc());
            }
            else
            {
                System.Diagnostics.Process.Start("CALC.EXE");
            }

            return 1;
        }
        /// <summary>
        /// 收费按钮触发
        /// </summary>
        /// <param name="alPayModes">支付方式信息</param>
        /// <param name="invoices">发票信息（基本对应发票主表的信息，每个对象对应一个发票）</param>
        /// <param name="invoiceDetails">发票明细信息（对应本次结算的全部费用明细）</param>
        /// <param name="invoiceFeeItemDetails">发票费用明细信息（按发票分组后的费用明细，每个对象对应该发票下的费用明细）</param>
        void frmBalance_FeeButtonClicked(ArrayList balancePays, ArrayList invoices, ArrayList invoiceDetails, ArrayList invoiceFeeDetails)
        {
            string errText = string.Empty;
            
            this.feeIntegrate.IsNeedUpdateInvoiceNO = false;
            //============暂时先这样加吧 luzhp@nuesoft.com
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice in invoices)
            {
                invoice.CanceledInvoiceNO = InvoiceNoStr;
            }
            if (this.patient.Pact.PayKind.ID == "02"
                 || this.patient.Pact.PayKind.ID == "03"
                )
            {
                foreach (Balance myBalance in invoices)
                {
                    ArrayList myFeeItemListArray = new ArrayList();
                    for (int i = 0; i < invoiceFeeDetails.Count; i++)
                    {
                        ArrayList tempAarry = new ArrayList();
                        tempAarry = (ArrayList)invoiceFeeDetails[i];
                        for (int j = 0; j < tempAarry.Count; j++)
                        {

                            ArrayList tempAarry2 = new ArrayList();
                            tempAarry2 = (ArrayList)tempAarry[j];
                            for (int k = 0; k < tempAarry2.Count; k++)
                            {
                                FeeItemList myFeeItemList = new FeeItemList();
                                myFeeItemList = (FeeItemList)tempAarry2[k];
                                if (myBalance.Invoice.ID == myFeeItemList.Invoice.ID)
                                {
                                    myFeeItemListArray.Add(myFeeItemList);

                                }
                            }
                        }
                    }
                    #region 上传医保信息

                    this.patient.SIMainInfo.InvoiceNo = myBalance.Invoice.ID;
                    //设置合同单位

                    long returnMedcareValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.patient, ref myFeeItemListArray);
                    if (returnMedcareValue != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口上传明细失败") + this.medcareInterfaceProxy.ErrMsg);
                        return;
                    }
                    returnMedcareValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
                    returnMedcareValue = this.medcareInterfaceProxy.BalanceOutpatient(this.patient, ref myFeeItemListArray);
                    if (returnMedcareValue != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口门诊结算失败") + this.medcareInterfaceProxy.ErrMsg);
                        return;
                    }

                    #endregion

                }
            }
            //==========
            bool bReturn = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.patient, invoices, invoiceDetails, againFeeItemLists,invoiceFeeDetails, balancePays, ref errText);

            if (!bReturn)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (errText != string.Empty)
                {
                    MessageBox.Show(errText);
                }
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.medcareInterfaceProxy.Commit();
            #region//发票打印

            string invoicePrintDll = null;

            invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NEWINVOICEPRINT, false, string.Empty);

            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                MessageBox.Show("没有设置发票打印参数，收费请维护!");

                //return false;
            }

            //iReturn = PrintInvoice(invoicePrintDll, r, invoices, invoiceDetails, feeDetails, invoiceFeeDetails, payModes, false, ref errText);
            // this.feeIntegrate.PrintInvoice(invoicePrintDll, this.registerControl.PatientInfo, invoicesClinicFee, invoiceDetailsClinicFee, myFeeItemListArray, invoiceFeeDetailsClinicFee, null, false, ref errText);
            this.feeIntegrate.PrintInvoice(invoicePrintDll, this.patient, invoices, invoiceDetails, againFeeItemLists, invoiceFeeDetails, balancePays, false, ref errText);
            //if (iReturn == -1)
            //{
            //    return false;
            //}

            #endregion
            decimal orgCost = 0;
            decimal newCost = 0;
            bool isHaveCard = false;
            decimal returnCost = 0;
            decimal accountOrgCost = 0m;
            decimal accountNewCost = 0m;
            decimal returnAccountCost = 0m;
            foreach (BalancePay p in modifiedBalancePays)
            {
                //因为此时的支付方式为负
                if (p.PayType.ID.ToString() == "CA")
                {
                    orgCost += -p.FT.RealCost;
                }
                if (p.PayType.ID.ToString() != "CA")
                {
                    isHaveCard = true;
                }
                if (p.PayType.ID.ToString() == "YS")
                {
                    accountOrgCost += -p.FT.RealCost;
                }
            }
            foreach (BalancePay p in balancePays)
            {
                //因为此时的支付方式为负
                if (p.PayType.ID.ToString() == "CA")
                {
                    newCost += p.FT.RealCost;
                }
                //门诊退费提示金额修改
                else if (p.PayType.ID.ToString() == "YS")
                {
                    accountNewCost += p.FT.RealCost;
                }
                else
                {
                    newCost += p.FT.RealCost;
                }
            }
            returnCost = orgCost - newCost;
            returnAccountCost = accountOrgCost - accountNewCost;
            returnCost = Class.Function.DealCent(returnCost);
            string messageText = string.Empty;

            if (returnCost == 0)
            {
                if (returnAccountCost >= 0)
                {
                    messageText = "账户退费" + returnAccountCost.ToString();
                }
                else
                {
                    messageText = "账户收取" + (-returnAccountCost).ToString();
                }
            }
            else if (returnCost > 0)
            {
                messageText = "应退金额: " + returnCost.ToString();
            }
            else
            {
                messageText = "应收现金: " + (-returnCost).ToString();
            }
            MessageBox.Show(messageText);
            tbQuitCash.Text = returnCost.ToString();

            this.Clear();
        }

        /// <summary>
        /// 收费按钮触发
        /// </summary>
        /// <param name="alPayModes">支付方式信息</param>
        /// <param name="invoices">发票信息（基本对应发票主表的信息，每个对象对应一个发票）</param>
        /// <param name="invoiceDetails">发票明细信息（对应本次结算的全部费用明细）</param>
        /// <param name="invoiceFeeItemDetails">发票费用明细信息（按发票分组后的费用明细，每个对象对应该发票下的费用明细）</param>
        void frmBalance_FeeButtonClicked1(ArrayList balancePays, ArrayList invoices, ArrayList invoiceDetails, ArrayList invoiceFeeDetails)
        {
            string errText = string.Empty;

            this.feeIntegrate.IsNeedUpdateInvoiceNO = false;
            //============暂时先这样加吧 luzhp@nuesoft.com
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice in invoices)
            {
                invoice.CanceledInvoiceNO = InvoiceNoStr;
            }
            if (this.patient.Pact.PayKind.ID == "02"
                 || this.patient.Pact.PayKind.ID == "03"
                )
            {
                foreach (Balance myBalance in invoices)
                {
                    ArrayList myFeeItemListArray = new ArrayList();
                    for (int i = 0; i < invoiceFeeDetails.Count; i++)
                    {
                        ArrayList tempAarry = new ArrayList();
                        tempAarry = (ArrayList)invoiceFeeDetails[i];
                        for (int j = 0; j < tempAarry.Count; j++)
                        {

                            ArrayList tempAarry2 = new ArrayList();
                            tempAarry2 = (ArrayList)tempAarry[j];
                            for (int k = 0; k < tempAarry2.Count; k++)
                            {
                                FeeItemList myFeeItemList = new FeeItemList();
                                myFeeItemList = (FeeItemList)tempAarry2[k];
                                if (myBalance.Invoice.ID == myFeeItemList.Invoice.ID)
                                {
                                    myFeeItemListArray.Add(myFeeItemList);

                                }
                            }
                        }
                    }
                    #region 上传医保信息

                    this.patient.SIMainInfo.InvoiceNo = myBalance.Invoice.ID;
                    //设置合同单位

                    long returnMedcareValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.patient, ref myFeeItemListArray);
                    if (returnMedcareValue != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口上传明细失败") + this.medcareInterfaceProxy.ErrMsg);
                        return;
                    }
                    returnMedcareValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(this.patient);
                    returnMedcareValue = this.medcareInterfaceProxy.BalanceOutpatient(this.patient, ref myFeeItemListArray);
                    if (returnMedcareValue != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口门诊结算失败") + this.medcareInterfaceProxy.ErrMsg);
                        return;
                    }

                    #endregion

                }
            }
            //==========
            bool bReturn = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.patient, invoices, invoiceDetails, againFeeItemLists, invoiceFeeDetails, balancePays, ref errText);

            if (!bReturn)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (errText != string.Empty)
                {
                    MessageBox.Show(errText);
                }
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.medcareInterfaceProxy.Commit();
            #region//发票打印

            string invoicePrintDll = null;

            invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                MessageBox.Show("没有设置发票打印参数，收费请维护!");

                //return false;
            }

            //iReturn = PrintInvoice(invoicePrintDll, r, invoices, invoiceDetails, feeDetails, invoiceFeeDetails, payModes, false, ref errText);
            // this.feeIntegrate.PrintInvoice(invoicePrintDll, this.registerControl.PatientInfo, invoicesClinicFee, invoiceDetailsClinicFee, myFeeItemListArray, invoiceFeeDetailsClinicFee, null, false, ref errText);
            this.feeIntegrate.PrintInvoice(invoicePrintDll, this.patient, invoices, invoiceDetails, againFeeItemLists, invoiceFeeDetails, balancePays, false, ref errText);
            //if (iReturn == -1)
            //{
            //    return false;
            //}

            #endregion
            decimal orgCost = 0;
            decimal newCost = 0;
            bool isHaveCard = false;
            decimal returnCost = 0;
            foreach (BalancePay p in modifiedBalancePays)
            {
                //因为此时的支付方式为负
                if (p.PayType.ID.ToString() == "CA")
                {
                    orgCost += -p.FT.RealCost;
                }
                if (p.PayType.ID.ToString() != "CA")
                {
                    isHaveCard = true;
                }
            }
            foreach (BalancePay p in balancePays)
            {
                //因为此时的支付方式为负
                if (p.PayType.ID.ToString() == "CA")
                {
                    newCost += p.FT.RealCost;
                }
            }
            returnCost = orgCost - newCost;
            returnCost = Class.Function.DealCent(returnCost);

            if (returnCost >= 0)
            {
                MessageBox.Show("应退金额: " + returnCost.ToString());
            }
            else
            {
                MessageBox.Show("应收现金: " + (-returnCost).ToString());
            }
            tbQuitCash.Text = returnCost.ToString();

            this.Clear();
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        protected virtual void ComputCost() 
        {
            decimal realQuitCost = 0;

            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpread1_Sheet1.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList f = this.fpSpread1_Sheet1.Rows[i].Tag as FeeItemList;

                        realQuitCost += f.FT.TotCost;
                        
                    //    realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2) - 
                    //        (Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2) / f.FT.TotCost) * f.FT.RebateCost;
                    }
                }
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.RowCount; i++)
            {
                if (this.fpSpread1_Sheet2.Rows[i].Tag != null)
                {
                    if (this.fpSpread1_Sheet2.Rows[i].Tag is FeeItemList)
                    {
                        FeeItemList f = this.fpSpread1_Sheet2.Rows[i].Tag as FeeItemList;

                        realQuitCost += f.FT.TotCost;

                        //realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2) - 
                        //    (Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2) / f.FT.TotCost) * f.FT.RebateCost;
                    }
                }
            }



            //			for(int i = 0; i < this.fpSpread2_Sheet1.RowCount; i ++)
            //			{
            //				if(this.fpSpread2_Sheet1.Rows[i].Tag != null)
            //				{
            //					if(this.fpSpread2_Sheet1.Rows[i].Tag is FeeItemList)
            //					{
            //						FeeItemList f = this.fpSpread2_Sheet1.Rows[i].Tag as FeeItemList;
            //
            //						realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
            //					}
            //					if(this.fpSpread2_Sheet1.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
            //					{
            //						Neusoft.HISFC.Models.Fee.ReturnApply f = this.fpSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
            //						
            //						realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
            //					}
            //				}
            //				
            //			}
            //			for(int i = 0; i < this.fpSpread2_Sheet2.RowCount; i ++)
            //			{
            //				if(this.fpSpread2_Sheet2.Rows[i].Tag != null)
            //				{
            //					if(this.fpSpread2_Sheet2.Rows[i].Tag is FeeItemList)
            //					{
            //						FeeItemList f = this.fpSpread2_Sheet2.Rows[i].Tag as FeeItemList;
            //
            //						realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
            //					}
            //					if(this.fpSpread2_Sheet2.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
            //					{
            //						Neusoft.HISFC.Models.Fee.ReturnApply f = this.fpSpread2_Sheet2.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
            //						
            //						realQuitCost += Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2);
            //					}
            //				}
            //			}
            decimal totCost = 0;
            totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(tbTotCost.Text);
            this.tbQuitCost.Text = (totCost - realQuitCost).ToString();
            this.tbReturnCost.Text = realQuitCost.ToString();
        }
        
        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear()
        {
            this.quitInvoices = null;
            this.ucDisplay1.Clear();
            this.ucCostDisplay1.Clear();
            this.ucInvoicePreview1.Clear();
            this.tbInvoiceNO.Text = string.Empty;
            this.tbCardNo.Text = string.Empty;
            this.tbName.Text = string.Empty;
            this.tbPactName.Text = string.Empty;
            this.tbQuitCost.Text = string.Empty;
            tbTotCost.Text = string.Empty;
            tbOwnCost.Text = string.Empty;
            tbPayCost.Text = string.Empty;
            tbPubCost.Text = string.Empty;
            tbReturnCost.Text = string.Empty;
            this.txtReturnItemName.Text = string.Empty;
            this.txtRetSpecs.Text = string.Empty;
            this.txtReturnNum.Text = string.Empty;
            this.txtUnit.Text = string.Empty;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.RowCount = 5;
            this.fpSpread1_Sheet2.RowCount = 0;
            this.fpSpread1_Sheet2.RowCount = 5;
            this.fpSpread2_Sheet1.RowCount = 0;
            this.fpSpread2_Sheet1.RowCount = 5;
            this.fpSpread2_Sheet2.RowCount = 0;
            this.fpSpread2_Sheet2.RowCount = 5;
            this.Focus();
            this.tbInvoiceNO.Focus();
            this.cmbDoct.Tag = string.Empty;
            this.cmbRegDept.Tag = string.Empty;
            this.isAccount = false;
        }
        
        /// <summary>
        /// 保存划价信息
        /// </summary>
        protected virtual void SaveCharge()
        {
            DialogResult result;

            result = MessageBox.Show("是否确定要划价？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }
            if (this.quitInvoices != null && this.quitInvoices.Count > 0)
            {
                if (hsInvoice.Contains(quitInvoices[0]))
                {
                    DialogResult r = MessageBox.Show("该发票费用信息已经划价保存过,是否重新划价?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (r == DialogResult.Cancel)
                    {
                        return;
                    }
                    hsInvoice.Remove(quitInvoices[0]);
                }
            }

            if (this.invoiceFeeItemLists == null || this.invoiceFeeItemLists.Count <= 0)
            {
                MessageBox.Show("没有划价信息！");
                return;
            }
            ArrayList alTemp = new ArrayList();

            foreach (FeeItemList f in invoiceFeeItemLists)
            {
                alTemp.Add(f.Clone());
            }

            System.Collections.Hashtable hsCombNos = new Hashtable();
            int combNo = 100;

            foreach (FeeItemList item in alTemp)
            {
                if (item.UndrugComb.ID != null && item.UndrugComb.ID.Length > 0)
                {
                    if (hsCombNos.ContainsKey(item.UndrugComb.ID))
                    {
                        item.Order.Combo.ID = hsCombNos[item.UndrugComb.ID].ToString();
                    }
                    else
                    {
                        hsCombNos.Add(item.UndrugComb.ID, combNo.ToString());
                        combNo++;
                    }
                }
                item.FT.TotCost = item.FT.PayCost + item.FT.OwnCost + item.FT.PubCost;

                item.FT.PayCost = 0m;
                item.FT.PubCost = 0m;
                item.FT.OwnCost = item.FT.TotCost;
                item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
                item.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                item.RecipeSequence = string.Empty;
                item.RecipeNO = string.Empty;
                item.SequenceNO = -1;
                item.Invoice.ID = string.Empty;
                item.InvoiceCombNO = null;
                item.Order.ID = string.Empty;
                item.ConfirmedQty = 0;
                item.IsConfirmed = false;
                item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
                item.NoBackQty = item.Item.Qty;
                item.ConfirmedInjectCount = 0;
                item.ConfirmOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
                
                item.ChargeOper.ID = this.outpatientManager.Operator.ID;

                item.FeeOper.OperTime = System.DateTime.MinValue;

            }

            bool iReturn = false;
            DateTime dtNow = outpatientManager.GetDateTimeFromSysDateTime();
            string errText = string.Empty;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            iReturn = this.feeIntegrate.SetChargeInfo(this.patient, alTemp, dtNow, ref errText);

            if (iReturn == false)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("划价出错" + errText);
                return;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("划价成功！");
                if (this.quitInvoices != null && this.quitInvoices.Count > 0)
                {
                    Balance invo = this.quitInvoices[0] as Balance;

                    hsInvoice.Add(invo, null);
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 设置toolBar按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("退费", "确认退费信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("取消", "取消已经选择的退费信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolBarService.AddToolButton("全退", "全部退除所有费用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);
            toolBarService.AddToolButton("计算器", "打开计算器", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B病历, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            //{F28E9BBB-D37E-4d8b-B25A-24F834290FBC}增加划价保存功能
            toolBarService.AddToolButton("划价保存", "把当前退费项目划价", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H划价保存, true, false, null);
            //{F28E9BBB-D37E-4d8b-B25A-24F834290FBC}完毕
            toolBarService.AddToolButton("发票作废", "把当前发票作废", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            #region {B5979EE5-CC71-4700-BCFF-AB627F6F17CA} 门诊退费读卡操作 by guanyx
            ReadCardEvent += new EventHandler(ucQuitFee_ReadCardEvent);
            toolBarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            #endregion
            return this.toolBarService;
        }

        #region {B5979EE5-CC71-4700-BCFF-AB627F6F17CA} 门诊退费读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucQuitFee_ReadCardEvent(object sender, EventArgs e)
        {
            this.Clear();
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.tbCardNo.Text = cardno;
                    this.tbCardNo_KeyDown(this.tbCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text) 
            {
                case "退费":
                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    if (patient != null && isAccount)
                    {
                        if (SaveAccountQuiteFee() == 1)
                        {
                            this.Clear();
                        }
                    }
                    else
                    {
                        if (this.Save() == 1)
                        {
                            this.Clear();
                        }
                    }
                    break;
                case "发票作废":
                    {
                        IsCanacelFee = true;
                        if (this.CancelFee() == -1)
                        {                            
                            this.Clear();
                        }
                        IsCanacelFee = false;
                        break;
                    }
                case "清屏":
                    this.Clear();
                    break;
                case "取消":
                    this.CancelQuitOperation();
                    break;

                case "计算器":
                    this.DisplayCalc();
                    break;

                case"全退":
                    this.AllQuit();
                    break;
                //{F28E9BBB-D37E-4d8b-B25A-24F834290FBC}增加划价保存按钮
                case "划价保存":
                    this.SaveCharge();
                    break;
                //{F28E9BBB-D37E-4d8b-B25A-24F834290FBC}结束
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                //				this.panel1.Focus();
                //				this.panel2.Focus();
                //				this.fpSpread1.Focus();
                //				this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
                //				if(this.fpSpread1_Sheet1.RowCount > 0)
                //				{
                //					this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                //				}
                this.SaveCharge();
            }
            if (keyData == Keys.F6)
            {
                //				this.panel1.Focus();
                //				this.panel2.Focus();
                //				this.fpSpread1.Focus();
                //				this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
                //				if(this.fpSpread1_Sheet2.RowCount > 0)
                //				{
                //					this.fpSpread1_Sheet2.ActiveRowIndex = 0;
                //				}
                if (this.fpSpread1.Focused)
                {
                    if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)
                    {
                        this.fpSpread2.Focus();
                        if (this.fpSpread2_Sheet1.RowCount > 0)
                        {
                            this.fpSpread2_Sheet1.ActiveRowIndex = 0;
                        }
                    }
                    if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)
                    {
                        this.fpSpread2.Focus();
                        if (this.fpSpread2_Sheet2.RowCount > 0)
                        {
                            this.fpSpread2_Sheet2.ActiveRowIndex = 0;
                        }
                    }
                }
                else
                {
                    if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet1)
                    {
                        this.fpSpread1.Focus();
                        if (this.fpSpread1_Sheet1.RowCount > 0)
                        {
                            this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                        }
                    }
                    if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet2)
                    {
                        this.fpSpread1.Focus();
                        if (this.fpSpread1_Sheet2.RowCount > 0)
                        {
                            this.fpSpread1_Sheet2.ActiveRowIndex = 0;
                        }
                    }
                }
            }
            if (keyData == Keys.F7)
            {
                this.panel1.Focus();
                this.fpSpread2.Focus();
                this.fpSpread2.ActiveSheet = this.fpSpread2_Sheet1;
                if (this.fpSpread2_Sheet1.RowCount > 0)
                {
                    this.fpSpread2_Sheet1.ActiveRowIndex = 0;
                }
            }
            if (keyData == Keys.F8)
            {
                this.panel1.Focus();
                this.fpSpread2.Focus();
                this.fpSpread2.ActiveSheet = this.fpSpread2_Sheet2;
                if (this.fpSpread2_Sheet2.RowCount > 0)
                {
                    this.fpSpread2_Sheet2.ActiveRowIndex = 0;
                }
            }
            if (keyData == Keys.F11)
            {
                this.ckbAllQuit.Checked = !this.ckbAllQuit.Checked;
                if (this.ckbAllQuit.Checked)
                {
                    this.txtReturnNum.Enabled = false;
                }
                else
                {
                    this.txtReturnNum.Enabled = true;
                }
            }
            if (keyData == Keys.F2)
            {
                this.neuTabControl1.SelectedTab = this.tpQuit;
                this.tpQuit.Focus();
                this.tbInvoiceNO.Select();
                this.tbInvoiceNO.Focus();
            }
            if (keyData == Keys.F3)
            {
                this.neuTabControl1.SelectedTab = this.tpFee;
                this.tpFee.Focus();
                this.ucDisplay1.Select();
                this.ucDisplay1.Focus();
            }
            if (keyData == Keys.F4)
            {
                this.AllQuit();
            }
            if (keyData == Keys.F9)
            {
                this.Clear();
            }
            if (keyData == Keys.F12)
            {
                this.FindForm().Close();
            }
            if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }
            if (keyData == Keys.F1)
            {
                //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(new Neusoft.Common.Controls.ucCalc());
            }

            return base.ProcessDialogKey(keyData);
        }

        protected virtual void tbInvoiceNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string invoiceNO = this.tbInvoiceNO.Text;

                this.Clear();
                this.tbQuitCash.Text = string.Empty;

                if (invoiceNO == string.Empty)
                {
                    MessageBox.Show("请输入发票号!");
                    this.tbInvoiceNO.Focus();
                    return;
                }
                this.tbInvoiceNO.Text = invoiceNO;
                this.quitInvoices = QueryInvoices(invoiceNO);
                if (quitInvoices == null)
                {
                    return;
                }
                if (quitInvoices.Count == 0)
                {
                    return;
                }
                if (quitInvoices.Count > 1)
                {
                    string invoiceNoTemp = string.Empty;
                    foreach (Balance invoice in quitInvoices)
                    {
                        invoiceNoTemp += invoice.Invoice.ID + "\n";
                    }
                    MessageBox.Show("此次退费有:" + invoiceNoTemp + "请全部收回!");
                }

               
                Balance invoiceTemp = quitInvoices[0] as Balance;

                Neusoft.HISFC.Models.Registration.Register tmpReg = registerIntegrate.GetByClinic(invoiceTemp.Patient.ID);
                if (tmpReg == null)
                {
                    MessageBox.Show("获得挂号信息出错!" + this.registerIntegrate.Err);

                    this.tbInvoiceNO.Focus();

                    return;
                }

                this.ucDisplay1.PatientInfo = tmpReg.Clone();
                this.ucDisplay1.PatientInfo.Pact = this.managerIntegrate.GetPactUnitInfoByPactCode(tmpReg.Pact.ID);

                this.tbCardNo.Text = invoiceTemp.Patient.PID.CardNO;
                this.tbName.Text = invoiceTemp.Patient.Name;
                this.tbPactName.Text = invoiceTemp.Patient.Pact.Name;

                this.patient.PID.CardNO = invoiceTemp.Patient.PID.CardNO;
                this.patient.Name = invoiceTemp.Patient.Name;
                this.patient.Pact.PayKind.ID = invoiceTemp.Patient.Pact.PayKind.ID;
                this.patient.Pact.ID = invoiceTemp.Patient.Pact.ID;
                this.patient.Pact.Name = invoiceTemp.Patient.Pact.Name;
                this.patient.ID = invoiceTemp.Patient.ID;
                this.patient.DoctorInfo.SeeDate = ((Neusoft.HISFC.Models.Registration.Register)invoiceTemp.Patient).DoctorInfo.SeeDate;
                this.patient.SSN = invoiceTemp.Patient.SSN;
                this.patient.ChkKind = invoiceTemp.ExamineFlag;
                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                isAccount = false;
                //this.patient.IsAccount = false;
                decimal totCost = 0;
                decimal ownCost = 0;
                decimal payCost = 0;
                decimal pubCost = 0;
                foreach (Balance invoice in quitInvoices)
                {
                    totCost += invoice.FT.TotCost;
                    ownCost += invoice.FT.OwnCost;
                    payCost += invoice.FT.PayCost;
                    pubCost += invoice.FT.PubCost;
                }
                this.tbTotCost.Text = totCost.ToString();
                this.tbOwnCost.Text = ownCost.ToString();
                this.tbPayCost.Text = payCost.ToString();
                this.tbPubCost.Text = pubCost.ToString();

                if (this.GetItemList() == -1)
                {
                    return;
                }

                if (this.fpSpread1_Sheet1.RowCount > 0)
                {
                    this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
                    this.fpSpread1.Focus();
                    this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                }
                else
                {
                    this.fpSpread1.Focus();
                    this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
                    this.fpSpread1_Sheet2.ActiveRowIndex = 0;
                }
            }
        }

        protected virtual void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //是否允许半退
            if (IsAllowQuitFeeHalf == false)
            {
                MessageBox.Show("没有半退权限");
                return;
            }
            if (this.fpSpread1.ActiveSheet.RowCount > 0)
            {
                //if (this.patient.Pact.PayKind.ID == "02")
                //{
                //    MessageBox.Show("医保患者必须点全退");
                //    //this.Clear();
                //    return;
                //}
                this.DealQuitOperation();
            }
        }

        protected virtual void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //是否允许半退
            if (IsAllowQuitFeeHalf == false)
            {
                MessageBox.Show("没有半退权限");
                return;
            }
            if (this.fpSpread2.ActiveSheet.RowCount > 0)
            {
                this.DealCancelQuitOperation();
            }
        }

        protected virtual void ckbAllQuit_Click(object sender, System.EventArgs e)
        {
            if (this.ckbAllQuit.Checked)
            {
                this.txtReturnNum.Enabled = false;
            }
            else
            {
                this.txtReturnNum.Enabled = true;
            }
        }

        protected virtual void txtReturnNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QuitItemByNum();
            }
        }

        protected virtual void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            //if (e.Button == this.tbCalc)
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(new Neusoft.Common.Controls.ucCalc());
            //}
            //if (e.Button == this.tbCancel)
            //{
            //    this.CancelQuitOperation();
            //}
            //if (e.Button == this.tbQuitAll)
            //{
            //    this.AllQuit();
            //}
            //if (e.Button == this.tbSave)
            //{
            //    if (this.Save() == 0)
            //    {
            //        this.Clear();
            //    }
            //}
            //if (e.Button == this.tbClear)
            //{
            //    this.Clear();
            //}
            //if (e.Button == this.tbExit)
            //{
            //    this.Close();
            //}
            //else if (e.Button == this.tbCharge)
            //{
            //    this.SaveCharge();
            //}
        }

        protected virtual void fpSpread1_ActiveSheetChanged(object sender, System.EventArgs e)
        {
            //if (this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet1)
            //{
            //    this.fpSpread2.ActiveSheet = this.fpSpread2_Sheet1;
            //}
            //else
            //{
            //    if (this.fpSpread2.ActiveSheet != null)
            //    {
            //        this.fpSpread2.ActiveSheet = this.fpSpread2_Sheet2;
            //    }
            //}
            if(this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)
            {
                this.fpSpread2.ActiveSheet = this.fpSpread2_Sheet2;
            }
        }

        protected virtual void fpSpread2_ActiveSheetChanged(object sender, System.EventArgs e)
        {
            if (this.fpSpread2.ActiveSheet == this.fpSpread2_Sheet1)
            {
                this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
            }
            else
            {
                this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet2;
            }
        }

        protected virtual void frmQuitFee_Load(object sender, System.EventArgs e)
        {
            this.fpSpread1.ActiveSheet = this.fpSpread1_Sheet1;
            try
            {
                this.isNeedAllQuit = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.GROUP_ITEM_ALLQUIT, false, false);
                this.chkGoupAllQuit.Checked = isNeedAllQuit;
                if (this.Init() < 0)
                {
                    return;
                }

                this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
            }
            catch
            {
            }
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //{E027D856-6334-4410-8209-5E9E36E31B53} 项目列表多线程载入
                //关闭窗口之前,如果载入项目列表线程没有结束,强行结束,避免线程例外
                this.ucDisplay1.threadItemInit.Abort();
            }
            catch { }
        }

        protected virtual void fpSpread1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpSpread1.ActiveSheet.RowCount > 0)
                {
                    if (this.patient.Pact.PayKind.ID == "02")
                    {
                        MessageBox.Show("医保患者必须点全退");
                        this.Clear();
                        return;
                    }
                    this.DealQuitOperation();
                }
            }
        }

        protected virtual void fpSpread2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpSpread2.ActiveSheet.RowCount > 0)
                {
                    this.DealCancelQuitOperation();
                }
            }
        }

        protected virtual void chkGoupAllQuit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.chkGoupAllQuit.Checked)
            {
                this.isNeedAllQuit = true;
            }
            else
            {
                this.isNeedAllQuit = false;
            }
        }

        protected virtual void ckbAllQuit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbAllQuit.Checked)
            {
                this.txtReturnNum.Enabled = false;
                this.txtReturnNum.Text = string.Empty;
                this.txtReturnNum.Tag = null;
            }
            else
            {
                this.txtReturnNum.Enabled = true;
            }
        }

        #endregion	          
        

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader && this.fpSpread1_Sheet2.RowHeader.Cells[e.Row, 0].Text == "+" &&
                this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)
            {
                ExpandOrCloseRow(false, e.Row + 1);
                return;
            }
            if (e.RowHeader && fpSpread1_Sheet2.RowHeader.Cells[e.Row, 0].Text == "-" &&
                this.fpSpread1.ActiveSheet == this.fpSpread1_Sheet2)
            {
                ExpandOrCloseRow(true, e.Row + 1);
                return;
            }
        }
        /// <summary>
        /// 折叠显示物资数据
        /// </summary>
        /// <param name="isExpand"></param>
        /// <param name="index"></param>
        private void ExpandOrCloseRow(bool isExpand, int index)
        {

            for (int i = index; i < fpSpread1_Sheet2.Rows.Count; i++)
            {
                if (this.fpSpread1_Sheet2.RowHeader.Cells[i, 0].Text == "." && this.fpSpread1_Sheet2.Rows[i].Visible == isExpand)
                {
                    this.fpSpread1_Sheet2.Rows[i].Visible = !isExpand;
                }
                else
                {
                    break;
                }
            }
            if (isExpand)
            {
                fpSpread1_Sheet2.RowHeader.Cells[index - 1, 0].Text = "+";
            }
            else
            {
                fpSpread1_Sheet2.RowHeader.Cells[index - 1, 0].Text = "-";
            }
        }

        /// <summary>
        /// 查找物资所对照的非药品所对应的行
        /// </summary>
        /// <param name="rowIndex">物资所在的行</param>
        /// <returns></returns>
        private int FinItemRowIndex(int rowIndex)
        {
            for (int i = rowIndex; i >= 0; i--)
            {
                if (this.fpSpread1_Sheet2.RowHeader.Cells[i, 0].Text != ".")
                    return i;
            }
            return -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.ucDisplay1.DeleteRow();
        }

        private void neuTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            ArrayList addItemList = this.ucDisplay1.GetFeeItemList();
            if (addItemList == null)
            {
                return;
            }

            if (addItemList.Count > 0)
            {

                if (this.cmbRegDept.Tag == null || this.cmbRegDept.Tag.ToString() == string.Empty || this.cmbRegDept.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请选择补收费用的看诊科室!");

                    return;
                }

                if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == string.Empty || this.cmbDoct.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请选择补收费用的开立医生!");

                    return;
                }
            }

            ArrayList phList = new ArrayList(); //药品列表
            ArrayList itemList = new ArrayList();//非药品列表

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in addItemList)
            {
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    phList.Add(f);
                }
                else
                {
                    itemList.Add(f);
                }
            }

            for (int i = this.fpSpread1_Sheet1.RowCount - 1; i >= 0; i--)
            {
                if (this.fpSpread1_Sheet1.RowHeader.Cells[i, 0].Text == "补收")
                {
                    this.fpSpread1_Sheet1.Rows.Remove(i, 1);
                }
            }
            for (int i = this.fpSpread1_Sheet2.RowCount - 1; i >= 0; i--)
            {
                if (this.fpSpread1_Sheet2.RowHeader.Cells[i, 0].Text == "补收")
                {
                    this.fpSpread1_Sheet2.Rows.Remove(i, 1);
                }
            }

            int phOrgCount = this.fpSpread1_Sheet1.RowCount;

            this.fpSpread1_Sheet1.RowCount += phList.Count; //药品.

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList drugItem in phList)
            {
                //this.fpSpread1_Sheet1.Rows[phOrgCount].Tag = drugItem;


                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.ItemName].Text = drugItem.Item.Name;

                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.CombNo].Text = drugItem.Order.Combo.ID;

                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.Specs].Text = drugItem.Item.Specs;
                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.Amount].Text = drugItem.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty / drugItem.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.PriceUnit].Text = drugItem.Item.PriceUnit;
                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.NoBackQty].Text = drugItem.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty / drugItem.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty, 2).ToString();
                this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.Cost].Text = (drugItem.FT.OwnCost + drugItem.FT.PayCost + drugItem.FT.PubCost).ToString();

                if (drugItem.Item.SysClass.ID.ToString() == "PCC")
                {
                    this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit + " " + "付数:" + drugItem.Days.ToString();
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[phOrgCount, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit;
                }

                Class.Function.DrawCombo(this.fpSpread1_Sheet1, (int)DrugList.CombNo, (int)DrugList.Comb, 0);

                this.fpSpread1_Sheet1.RowHeader.Cells[phOrgCount, 0].Text = "补收";

                phOrgCount++;
            }

            int unDrugOrgCount = this.fpSpread1_Sheet2.RowCount;

            this.fpSpread1_Sheet2.RowCount += itemList.Count; //药品.

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList undrugItem in itemList)
            {

                #region 加载物资信息
                //{143CA424-7AF9-493a-8601-2F7B1D635027}
                string outNo = undrugItem.UpdateSequence.ToString();
                List<HISFC.Models.FeeStuff.Output> list = mateIntegrate.QueryOutput(outNo);
                undrugItem.MateList = list;
                #endregion

                if (undrugItem.FT.RebateCost > 0)
                {
                    isHaveRebateCost = true;
                }

                undrugItem.FT.TotCost = undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost;
                //this.fpSpread1_Sheet2.Rows[unDrugOrgCount].Tag = undrugItem;


                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.ItemName].Text = undrugItem.Item.Name;
                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.CombNo].Text = undrugItem.Order.Combo.ID;
                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.Amount].Text = undrugItem.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty / undrugItem.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.PriceUnit].Text = undrugItem.Item.PriceUnit;
                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.NoBackQty].Text = undrugItem.FeePack == "1" ?
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty / undrugItem.Item.PackQty, 2).ToString() :
                    Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty, 2).ToString();
                this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.Cost].Text = (undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost).ToString();
                if (undrugItem.UndrugComb.ID != null && undrugItem.UndrugComb.ID.Length > 0)
                {
                    this.undrugComb = this.undrugManager.GetValidItemByUndrugCode(undrugItem.UndrugComb.ID);
                    if (this.undrugComb == null)
                    {
                        MessageBox.Show("获得组套信息出错，无法显示组套自定义码，但是不影响退费操作！");
                    }
                    else
                    {
                        undrugItem.UndrugComb.UserCode = this.undrugComb.UserCode;
                    }

                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                    if (item == null)
                    {
                        this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name;
                    }
                    else
                    {
                        this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name + "[" + item.UserCode + "]";
                    }

                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                    if (item != null)
                    {
                        this.fpSpread1_Sheet2.Cells[unDrugOrgCount, (int)UndrugList.PackageName].Text = item.UserCode;
                    }
                }

                Class.Function.DrawCombo(this.fpSpread1_Sheet2, (int)UndrugList.CombNo, (int)UndrugList.Comb, 0);
                //显示物资信息
                SetMateData(undrugItem, unDrugOrgCount);

                this.fpSpread1_Sheet2.RowHeader.Cells[unDrugOrgCount, 0].Text = "补收";

                unDrugOrgCount++;
            }

        }
        //{E3C20659-CA54-457b-A907-650EEA30516C} 增加两个回车事件
        private void cmbRegDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.cmbDoct.Focus();
            }
        }

        private void cmbDoct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.ucDisplay1.SetFocus();
            }
        }
        //{E3C20659-CA54-457b-A907-650EEA30516C} 完毕

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增

        protected virtual void tbCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string markNO = this.tbCardNo.Text.Trim();
            if (string.IsNullOrEmpty(markNO))
            {
                MessageBox.Show("请输入就诊卡号！");
                this.tbCardNo.Focus();
                return;
            }
            Neusoft.HISFC.Models.Account.AccountCard accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
            if (feeIntegrate.ValidMarkNO(markNO, ref accountCard) <= 0)
            {
                MessageBox.Show(feeIntegrate.Err);
                return;
            }
            GetFeeList(accountCard.Patient);
            

        }

        protected virtual int GetFeeList(Neusoft.HISFC.Models.RADT.PatientInfo p)
        {
            DateTime beginTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;
            int returnValues = Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref beginTime, ref endTime);
            if (returnValues < 0)
            {
                return -1;
            }

            this.patient.PID = p.PID;
            this.patient.Name = p.Name;
            this.patient.Pact = p.Pact;
            this.patient.Birthday = p.Birthday;
            this.patient.Sex = p.Sex;

            FT ft = new FT();
            if (GetList(p.PID.CardNO, beginTime, endTime, ref ft) < 0)
            {
                return -1;
            }
            this.tbName.Text = p.Name;
            this.tbPactName.Text = p.Pact.Name;
            this.tbPayCost.Text = ft.PayCost.ToString();
            this.tbOwnCost.Text = ft.OwnCost.ToString();
            this.tbPubCost.Text = ft.PubCost.ToString();
            this.tbTotCost.Text = ft.TotCost.ToString();
            isAccount = true;
            return 1;
        }

        /// <summary>
        /// 显示患者费用信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        protected virtual int GetList(string cardNO, DateTime beginDate, DateTime endDate, ref FT ft)
        {
            try
            {
                ArrayList drugItemLists = outpatientManager.GetDrugFeeByCardNODate(cardNO, beginDate, endDate, true);
                if (drugItemLists == null)
                {
                    MessageBox.Show("获得药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
                ArrayList undrugItemLists = outpatientManager.GetDrugFeeByCardNODate(cardNO, beginDate, endDate, false);
                if (undrugItemLists == null)
                {
                    MessageBox.Show("获得非药品信息出错!" + outpatientManager.Err);

                    return -1;
                }
                if (drugItemLists.Count + undrugItemLists.Count == 0)
                {
                    MessageBox.Show("没有费用信息!");

                    return -1;
                }

                ArrayList drugConfirmList = new ArrayList();//已经核准的退药信息
                ArrayList undrugConfirmList = new ArrayList();//已经核准退费的非药品信息
                //循环所有参与退费的发票,查询已经核准的药品和非药品信息
                //由于多张发票的存在,而明细只对应一个发票号,所以遍所有的参与退费的发票,其中只有一个发票号符合查询条件.
                //foreach (Balance balance in this.quitInvoices)
                //{
                //如果已经获得了已经核准退费的药品信息,就不再获取
                if (drugConfirmList == null || drugConfirmList.Count == 0)
                {
                    //获得已经核准的退药信息
                    drugConfirmList = returnApplyManager.GetApplyReturn(cardNO, false, false, true);
                    if (drugConfirmList == null)
                    {
                        MessageBox.Show("获得确认药品项目列表出错!" + returnApplyManager.Err);

                        return -1;
                    }
                }
                //如果已经获得了已经核准退费的非药品信息,就不再获取
                if (undrugConfirmList == null || undrugConfirmList.Count == 0)
                {
                    //获得已经核准退费的非药品信息
                    undrugConfirmList = returnApplyManager.GetApplyReturn(cardNO, false, false, false);
                    if (undrugConfirmList == null)
                    {
                        MessageBox.Show("获得确认非药品项目列表出错!" + returnApplyManager.Err);

                        return -1;
                    }
                }
                //}
                //显示待退药品信息
                this.fpSpread1_Sheet1.RowCount = drugItemLists.Count;

                FeeItemList drugItem = null;//药品临时实体
                for (int i = 0; i < drugItemLists.Count; i++)
                {
                    drugItem = drugItemLists[i] as FeeItemList;

                    if (drugItem.FT.RebateCost > 0)
                    {
                        isHaveRebateCost = true;
                    }


                    //重新计算本条药品的总金额,方便以后参与计算费用
                    drugItem.FT.TotCost = drugItem.FT.OwnCost + drugItem.FT.PayCost + drugItem.FT.PubCost;

                    this.fpSpread1_Sheet1.Rows[i].Tag = drugItem;
                    //因为可能存在同一发票有不同看诊科室的情况,而且挂号信息中的看诊信息不一定与实际收费的看诊
                    //科室相同,所以这里把挂号实体的看诊可是赋值为收费明细时的看诊科室信息.
                    this.patient.DoctorInfo.Templet.Dept = drugItem.RecipeOper.Dept;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.ItemName].Text = drugItem.Item.Name;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.CombNo].Text = drugItem.Order.Combo.ID;

                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Specs].Text = drugItem.Item.Specs;
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text = drugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty / drugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.PriceUnit].Text = drugItem.Item.PriceUnit;
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.NoBackQty].Text = drugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty / drugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugItem.NoBackQty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Cost].Text = (drugItem.FT.OwnCost + drugItem.FT.PayCost + drugItem.FT.PubCost).ToString();

                    if (drugItem.Item.SysClass.ID.ToString() == "PCC")
                    {
                        this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit + " " + "付数:" + drugItem.Days.ToString();
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[i, (int)DrugList.DoseAndDays].Text = "每次量:" + drugItem.Order.DoseOnce.ToString() + drugItem.Order.DoseUnit;
                    }
                    //cost += drugItem.FT.TotCost;
                    ft.TotCost += drugItem.FT.TotCost;
                    ft.OwnCost += drugItem.FT.OwnCost;
                    ft.PubCost += drugItem.FT.PubCost;
                    ft.PayCost += drugItem.FT.PayCost;
                    Class.Function.DrawCombo(this.fpSpread1_Sheet1, (int)DrugList.CombNo, (int)DrugList.Comb, 0);
                }

                //显示非药品信息
                this.fpSpread1_Sheet2.RowCount = undrugItemLists.Count;

                FeeItemList undrugItem = null;
                for (int i = 0; i < undrugItemLists.Count; i++)
                {
                    undrugItem = undrugItemLists[i] as FeeItemList;

                    #region 加载物资信息
                    //{143CA424-7AF9-493a-8601-2F7B1D635027}
                    //string outNo = undrugItem.UpdateSequence.ToString();
                    //List<HISFC.Object.Material.Output> list = mateIntegrate.QueryOutput(outNo);
                    //undrugItem.MateList = list;
                    #endregion

                    if (undrugItem.FT.RebateCost > 0)
                    {
                        isHaveRebateCost = true;
                    }

                    undrugItem.FT.TotCost = undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost;
                    this.fpSpread1_Sheet2.Rows[i].Tag = undrugItem;
                    this.patient.DoctorInfo.Templet.Dept = undrugItem.RecipeOper.Dept;

                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.ItemName].Text = undrugItem.Item.Name;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.CombNo].Text = undrugItem.Order.Combo.ID;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text = undrugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty / undrugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PriceUnit].Text = undrugItem.Item.PriceUnit;
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.NoBackQty].Text = undrugItem.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty / undrugItem.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugItem.NoBackQty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Cost].Text = (undrugItem.FT.OwnCost + undrugItem.FT.PayCost + undrugItem.FT.PubCost).ToString();
                    if (undrugItem.UndrugComb.ID != null && undrugItem.UndrugComb.ID.Length > 0)
                    {
                        this.undrugComb = this.undrugManager.GetValidItemByUndrugCode(undrugItem.UndrugComb.ID);
                        if (this.undrugComb == null)
                        {
                            MessageBox.Show("获得组套信息出错，无法显示组套自定义码，但是不影响退费操作！");
                        }
                        else
                        {
                            undrugItem.UndrugComb.UserCode = this.undrugComb.UserCode;
                        }

                        Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                        if (item == null)
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name;
                        }
                        else
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = "(" + undrugItem.UndrugComb.UserCode + ")" + undrugItem.UndrugComb.Name + "[" + item.UserCode + "]";
                        }

                    }
                    else
                    {
                        Neusoft.HISFC.Models.Fee.Item.Undrug item = this.undrugManager.GetValidItemByUndrugCode(undrugItem.ID);

                        if (item != null)
                        {
                            this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.PackageName].Text = item.UserCode;
                        }
                    }
                    //cost += undrugItem.FT.TotCost;
                    ft.TotCost += undrugItem.FT.TotCost;
                    ft.OwnCost += undrugItem.FT.OwnCost;
                    ft.PubCost += undrugItem.FT.PubCost;
                    ft.PayCost += undrugItem.FT.PayCost;
                    Class.Function.DrawCombo(this.fpSpread1_Sheet2, (int)UndrugList.CombNo, (int)UndrugList.Comb, 0);
                    //显示物资信息
                    //SetMateData(undrugItem, i);
                }
                //显示确认退药信息
                this.fpSpread2_Sheet1.RowCount = drugItemLists.Count + drugConfirmList.Count;
                Neusoft.HISFC.Models.Fee.ReturnApply drugReturn = null;
                for (int i = 0; i < drugConfirmList.Count; i++)
                {
                  
                    drugReturn = drugConfirmList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                    int findRow = FindItem(drugReturn.RecipeNO, drugReturn.SequenceNO, this.fpSpread1_Sheet1);
                    if (findRow == -1)
                    {
                        //MessageBox.Show("查找未退药项目出错!");
                        continue;
                    }
                    this.fpSpread2_Sheet1.Rows[i].Tag = drugReturn;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.ItemName].Text = drugReturn.Item.Name;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Amount].Text = drugReturn.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(drugReturn.Item.Qty / drugReturn.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(drugReturn.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.PriceUnit].Text = drugReturn.Item.PriceUnit;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Specs].Text = drugReturn.Item.Specs;
                    this.fpSpread2_Sheet1.Cells[i, (int)DrugListQuit.Flag].Text = "确认";

                    
                    FeeItemList modifyDrug = this.fpSpread1_Sheet1.Rows[findRow].Tag as FeeItemList;

                    modifyDrug.NoBackQty = modifyDrug.NoBackQty - drugReturn.Item.Qty;
                    modifyDrug.Item.Qty = modifyDrug.Item.Qty - drugReturn.Item.Qty;
                    modifyDrug.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Price * modifyDrug.Item.Qty / modifyDrug.Item.PackQty, 2);
                    modifyDrug.FT.OwnCost = modifyDrug.FT.TotCost;

                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Cost].Text = modifyDrug.FT.TotCost.ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.Amount].Text = modifyDrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Qty / modifyDrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet1.Cells[findRow, (int)DrugList.NoBackQty].Text = modifyDrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.NoBackQty / modifyDrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyDrug.NoBackQty, 2).ToString();
                }
                this.fpSpread2_Sheet2.RowCount = undrugItemLists.Count + undrugConfirmList.Count;
                Neusoft.HISFC.Models.Fee.ReturnApply undrugReturn = null;
                for (int i = 0; i < undrugConfirmList.Count; i++)
                {
                    undrugReturn = undrugConfirmList[i] as Neusoft.HISFC.Models.Fee.ReturnApply;
                    int findRow = FindItem(undrugReturn.RecipeNO, undrugReturn.SequenceNO, this.fpSpread1_Sheet2);
                    if (findRow == -1)
                    {
                        //MessageBox.Show("查找未退非药项目出错!");

                        //return -1;
                        continue;
                    }
                    this.fpSpread2_Sheet2.Rows[i].Tag = undrugReturn;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.ItemName].Text = undrugReturn.Item.Name;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Amount].Text = undrugReturn.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugReturn.Item.Qty / undrugReturn.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(undrugReturn.Item.Qty, 2).ToString();
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.PriceUnit].Text = undrugReturn.Item.PriceUnit;
                    this.fpSpread2_Sheet2.Cells[i, (int)UndrugListQuit.Flag].Text = "确认";

                    
                    FeeItemList modifyUndrug = this.fpSpread1_Sheet2.Rows[findRow].Tag as FeeItemList;

                    modifyUndrug.NoBackQty = modifyUndrug.NoBackQty - undrugReturn.Item.Qty;
                    modifyUndrug.Item.Qty = modifyUndrug.Item.Qty - undrugReturn.Item.Qty;
                    modifyUndrug.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Price * modifyUndrug.Item.Qty / modifyUndrug.Item.PackQty, 2);
                    modifyUndrug.FT.OwnCost = modifyUndrug.FT.TotCost;

                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Cost].Text = modifyUndrug.FT.TotCost.ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.Amount].Text = modifyUndrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Qty / modifyUndrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.Item.Qty, 2).ToString();
                    this.fpSpread1_Sheet2.Cells[findRow, (int)UndrugList.NoBackQty].Text = modifyUndrug.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.NoBackQty / modifyUndrug.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(modifyUndrug.NoBackQty, 2).ToString();

                }

                if (isHaveRebateCost)
                {
                    this.ckbAllQuit.Checked = true;
                    this.ckbAllQuit.Enabled = false;
                }
                else
                {
                    this.ckbAllQuit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }


            return 1;

        }

        /// <summary>
        /// 作废费用信息
        /// </summary>
        /// <param name="f"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private int SaveAccountQuiteFee()
        {

            DialogResult diaResult = MessageBox.Show("是否要退费?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (diaResult == DialogResult.No)
            {
                return -1;
            }

            decimal vacancy = 0m;
            if (feeIntegrate.GetAccountVacancy(this.patient.PID.CardNO, ref vacancy) < 0)
            {
                MessageBox.Show("该患者账户已停用，请打印发票后再退费！");
                return -1;
            }

            if (!feeIntegrate.CheckAccountPassWord(this.patient))
            {
                return -1;
            }
            if (!IsQuitItem())
            {
                return -1;
            }

            ArrayList alFee = new ArrayList();
            FeeItemList tempf = null;
            DateTime nowTime = outpatientManager.GetDateTimeFromSysDateTime();
            int iReturn;
            FeeItemList f = null;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            foreach (FarPoint.Win.Spread.SheetView sv in fpSpread1.Sheets)
            {
                for (int i = 0; i < sv.Rows.Count; i++)
                {
                    if (sv.Rows[i].Tag == null) continue;

                    f = (sv.Rows[i].Tag as FeeItemList).Clone();

                    #region 作废申请数据
                    if (f.Item.ItemType == EnumItemType.Drug)
                    {
                        if (f.IsConfirmed == false)
                        {
                            iReturn = pharmacyIntegrate.CancelApplyOutClinic(f.RecipeNO, f.SequenceNO);
                            if (iReturn < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("作废发药申请出错!" + pharmacyIntegrate.Err);
                                return -1;
                            }
                        }

                        tempf = f.Clone();
                        tempf.FT.OwnCost = tempf.FT.PubCost = tempf.FT.PayCost = 0;
                        tempf.FT.OwnCost = tempf.FT.TotCost;
                        //if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i, (int)DrugList.Amount].Text) > 0)//by yuyun 解决门诊已发药之后做半退，退费时全退的情况
                        if (f.Item.Qty > 0)
                        {
                            tempf.User03 = "HalfQuit";
                            alFee.Add(tempf);
                        }
                    }
                    else
                    {
                        //有未确认的退药，作废退药申请!
                        tempf = f.Clone();
                        if (f.IsConfirmed == false)
                        {
                            iReturn = confirmIntegrate.CancelConfirmTerminal(f.Order.ID, f.Item.ID);
                            if (iReturn < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("作废终端申请出错!" + confirmIntegrate.Err);

                                return -1;
                            }
                        }
                        else
                        {
                            #region 更新终端确认信息
                            
                            //{06212A22-5FD4-4db3-838C-1790F75FF286}

                            int row = this.FindItem(tempf.RecipeNO, tempf.SequenceNO, this.fpSpread2_Sheet2);
                            if (row != -1)
                            {
                                FeeItemList quitItem = this.fpSpread2_Sheet2.Rows[row].Tag as FeeItemList;
                                if (confirmIntegrate.UpdateOrDeleteTerminalConfirmApply(tempf.Order.ID, (int)(tempf.Item.Qty + quitItem.Item.Qty), (int)quitItem.Item.Qty, Neusoft.FrameWork.Public.String.FormatNumber(tempf.Item.Price * tempf.Item.Qty, 2)) == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("更新终端确认信息出错!" + confirmIntegrate.Err);
                                    return -1;
                                }
                            }
                            
                            #endregion
                        }
                        tempf.FT.OwnCost = tempf.FT.PubCost = tempf.FT.PayCost = 0;
                        tempf.FT.OwnCost = tempf.FT.TotCost;
                        //{06212A22-5FD4-4db3-838C-1790F75FF286}
                        //if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet2.Cells[i, (int)UndrugList.Amount].Text) > 0)
                        if (f.Item.Qty > 0)
                        {
                            Neusoft.HISFC.Models.Fee.Item.Undrug unDrugTemp = this.undrugManager.GetUndrugByCode(f.Item.ID);
                            if (unDrugTemp != null)
                            {
                                tempf.Item.IsNeedConfirm = unDrugTemp.IsNeedConfirm;
                                tempf.Item.IsNeedBespeak = unDrugTemp.IsNeedBespeak;
                            }
                            tempf.User03 = "HalfQuit";
                            alFee.Add(tempf);
                        }

                    }

                    #endregion

                   
                    #region 冲负记录

                    FeeItemList feeItem = outpatientManager.GetFeeItemListForFee(f.RecipeNO, f.SequenceNO);
                    if (feeItem == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("作废患者明细出错!" + outpatientManager.Err);
                        return -1;
                    }
                    feeItem.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                    feeItem.FT.OwnCost = -feeItem.FT.OwnCost;
                    feeItem.FT.PayCost = -feeItem.FT.PayCost;
                    feeItem.FT.PubCost = -feeItem.FT.PubCost;
                    feeItem.FT.TotCost = feeItem.FT.OwnCost + feeItem.FT.PubCost + feeItem.FT.PayCost;
                    feeItem.Item.Qty = -feeItem.Item.Qty;
                    feeItem.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                    feeItem.FeeOper.ID = outpatientManager.Operator.ID;
                    feeItem.FeeOper.OperTime = nowTime;
                    feeItem.InvoiceCombNO = this.outpatientManager.GetTempInvoiceComboNO();
                    iReturn = outpatientManager.InsertFeeItemList(feeItem);
                    if (iReturn <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入费用明细冲帐信息出错!" + outpatientManager.Err);
                        return -1;
                    }
                    #endregion

                    #region 更新费用退费标记
                    if (outpatientManager.UpdateFeeItemListCancelType(f.RecipeNO, f.SequenceNO, CancelTypes.Canceled) <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("作废患者明细出错!" + outpatientManager.Err);
                        return -1;
                    }
                    #endregion

                }
            }

            #region 半退
            ArrayList drugList = new ArrayList();
            if (alFee.Count > 0)
            {
                this.patient = registerIntegrate.GetByClinic((alFee[0] as FeeItemList).Patient.ID);
                foreach (FeeItemList item in alFee)
                {
                    item.FeeOper.OperTime = nowTime;
                    item.FeeOper.ID = outpatientManager.Operator.ID;
                    item.PayType = PayTypes.Balanced;
                    item.TransType = TransTypes.Positive;
                    item.InvoiceCombNO = outpatientManager.GetTempInvoiceComboNO();
                    if (outpatientManager.InsertFeeItemList(item) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入费用明细失败！" + outpatientManager.Err);
                        return -1;
                    }
                    //发药申请
                    if (item.Item.ItemType == EnumItemType.Drug)
                    {
                        if (!item.IsConfirmed)
                        {
                            if (!item.Item.IsNeedConfirm)
                            {
                                drugList.Add(item);
                            }
                        }
                    }
                    else
                    {
                        //终端申请
                        if (!item.IsConfirmed)
                        {
                            if (item.Item.IsNeedConfirm)
                            {
                                Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(item, this.patient);
                                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("处理终端申请确认表失败!" + confirmIntegrate.Err);

                                    return -1;
                                }
                            }
                        }
                    }

                }
                if (drugList.Count > 0)
                {
                    string drugSendInfo = string.Empty;
                    iReturn = this.pharmacyIntegrate.ApplyOut(patient, drugList, string.Empty, nowTime, false, out drugSendInfo);
                    if (iReturn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("处理药品明细失败!" + pharmacyIntegrate.Err);
                        return -1;
                    }
                }
            }
            #endregion

            #region 更新退费申请退费标记
            Neusoft.HISFC.Models.Fee.ReturnApply returnApply = null;
            DateTime operDate = outpatientManager.GetDateTimeFromSysDateTime();
            string operCode = outpatientManager.Operator.ID;
            foreach (FarPoint.Win.Spread.SheetView sv in fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.Rows.Count; i++)
                {
                    if (sv.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        returnApply = sv.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
                        returnApply.CancelType = CancelTypes.Valid;
                        returnApply.CancelOper.ID = operCode;
                        returnApply.CancelOper.OperTime = operDate;
                        if (returnApplyManager.UpdateApplyCharge(returnApply) <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新申请表退费标记失败！" + returnApplyManager.Err);
                            return -1;
                        }
                    }
                }
            }

            #endregion



            #region 返还账户
            decimal cost = 0m;
            Neusoft.HISFC.Models.Fee.ReturnApply applyItem = null;
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList fitem = null;
            foreach (FarPoint.Win.Spread.SheetView sv in fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.Rows.Count; i++)
                {
                    if (sv.Rows[i].Tag == null) continue;
                    if (sv.Rows[i].Tag is Neusoft.HISFC.Models.Fee.ReturnApply)
                    {
                        applyItem = sv.Rows[i].Tag as Neusoft.HISFC.Models.Fee.ReturnApply;
                        cost += Neusoft.FrameWork.Public.String.FormatNumber(applyItem.Item.Price * applyItem.Item.Qty / applyItem.Item.PackQty, 2);
                    }
                    if (sv.Rows[i].Tag is FeeItemList)
                    {
                        fitem = sv.Rows[i].Tag as FeeItemList;
                        cost += Neusoft.FrameWork.Public.String.FormatNumber(fitem.Item.Price * fitem.Item.Qty / fitem.Item.PackQty, 2);
                    }
                }
            }
            if (feeIntegrate.AccountCancelPay(patient, -cost, "门诊退费", (outpatientManager.Operator as Employee).Dept.ID, string.Empty) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("账户退费入户失败！" + feeIntegrate.Err);
                return -1;
            }

            #endregion

            #region 保存退费项目

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("返还账户金额" + cost.ToString() + "元");
            return 1;
        }

        #endregion


    }
}
         