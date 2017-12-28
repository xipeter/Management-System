using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /*
     * 历史采购信息 需要取采购表内状态为"2" "3"的  原来的有问题
    */
    /// <summary>
    /// [功能描述: 药品采购计划]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1.核心BUG，药品打印接口调用出错Bug处理，如果同时开了入库计划和采购计划并进行过打印的情况下，
    ///      切换界面点打印就会调用上一个打印接口实现 by Sunjh 2010-8-26 {D78A574D-59BE-491b-808C-38DCD26BA5EA}
    /// </修改记录>
    /// </summary>
    public partial class ucStockPlan : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                        Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucStockPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实体转换 由入库计划实体转换为采购计划实体
        /// </summary>
        /// <param name="inPlanObj">入库计划实体</param>
        /// <returns>成功返回采购计划实体 失败返回null</returns>
        public static Neusoft.HISFC.Models.Pharmacy.StockPlan ConvertPlanType(Neusoft.HISFC.Models.Pharmacy.InPlan inPlanObj)
        {
            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanObj = new Neusoft.HISFC.Models.Pharmacy.StockPlan();

            stockPlanObj.BillNO = inPlanObj.BillNO;             //单据号
            stockPlanObj.Dept = inPlanObj.Dept;                 //科室
            stockPlanObj.Item = inPlanObj.Item;                 //药品信息
            stockPlanObj.StoreQty = inPlanObj.StoreQty;         //本科库存
            stockPlanObj.StoreTotQty = inPlanObj.StoreTotQty;   //全院库存
            stockPlanObj.OutputQty = inPlanObj.OutputQty;       //出库总量
            stockPlanObj.PlanQty = inPlanObj.PlanQty;           //计划量
            stockPlanObj.PlanOper = inPlanObj.PlanOper;         //计划人
            stockPlanObj.Oper = inPlanObj.Oper;                 //操作人
            stockPlanObj.Extend = inPlanObj.Extend;             //备注 

            return stockPlanObj;
        }


        #region 变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 供货单位信息
        /// </summary>
        private ArrayList alCompany = null;

        /// <summary>
        /// 生产厂家信息
        /// </summary>
        private ArrayList alProduce = null;

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = null;

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper produceHelper = null;

        /// <summary>
        /// 采购是否需要审核
        /// </summary>
        private bool isNeedApprove = true;

        /// <summary>
        /// 是否使用字典信息内默认的供货公司/购入价
        /// </summary>
        private bool isUseDefaultStockData = true;

        /// <summary>
        /// 窗口功能
        /// </summary>
        private EnumWindowFun winFun = EnumWindowFun.采购计划;

        /// <summary>
        /// 历史采购记录
        /// </summary>
        private ArrayList alPlanHistory = new ArrayList();

        /// <summary>
        /// 当前操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作采购单号
        /// </summary>
        private string nowOperBillNO = "";

        /// <summary>
        /// 当前操作供货单位
        /// </summary>
        private string nowCompanyNO = "";

        /// <summary>
        /// 采购计划集合
        /// </summary>
        private System.Collections.Hashtable hsStockPlan = new Hashtable();

        /// <summary>
        /// 采购审核时 是否允许修改相应的采购信息
        /// </summary>
        private bool isCanEditWhenApprove = false;

        /// <summary>
        /// 是否允许修改计划购入价
        /// </summary>
        private bool isCanEditPrice = true;

        #endregion

        #region 属性

        /// <summary>
        /// 报表标题
        /// </summary>
        [Description("报表标题 根据不同医院名称设置"), Category("设置"), DefaultValue("入库计划单")]
        public string Title
        {
            get
            {
                return this.lbTitle.Text;
            }
            set
            {
                this.lbTitle.Text = value;
            }
        }

        /// <summary>
        /// 采购是否需要审核 
        /// </summary>
        [Description("采购计划指定后是否需要采购审核"), Category("设置"), DefaultValue(true),Browsable(false)]
        public bool IsNeedApprove
        {
            get
            {
                return this.isNeedApprove;
            }
            set
            {
                this.isNeedApprove = value;
            }
        }

        /// <summary>
        /// 窗口功能
        /// </summary>
        [Description("窗口功能"), Category("设置")]
        public EnumWindowFun WindowFun
        {
            get
            {
                return winFun;
            }
            set
            {
                this.winFun = value;

                if (value == EnumWindowFun.采购计划)            //此时可以修改审核数量 / 购入价 / 供货公司
                {
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].Locked = false;
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = false;
                    
                    //this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColCompany].Locked = false;
                    //{E0ED3F4F-F895-4cc6-B6A6-B1EFFABBC5DA}
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColCompany].Locked = true;
                }
                else
                {
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].Locked = true;
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = true;
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColCompany].Locked = true;
                }
            }
        }

        /// <summary>
        /// 是否使用字典信息内默认的供货公司/购入价
        /// </summary>
        [Description("采购指定时是否使用字典信息内默认的供货公司/购入价"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool UseDefaultStockData
        {
            get
            {
                return this.isUseDefaultStockData;
            }
            set
            {
                this.isUseDefaultStockData = value;
            }
        }

        /// <summary>
        /// 采购审核时 是否允许修改相应的采购信息
        /// </summary>
        [Description("采购审核时 是否允许修改相应的采购信息"), Category("设置"), DefaultValue(false), Browsable(false)]
        public bool IsCanEditWhenApprove
        {
            get
            {
                return this.isCanEditWhenApprove;
            }
            set
            {
                this.isCanEditWhenApprove = value;
            }
        }

        /// <summary>
        /// 是否允许修改计划购入价
        /// </summary>
        [Description("是否允许修改计划购入价"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool IsCanEditPrice
        {
            get
            {
                return this.isCanEditPrice;
            }
            set
            {
                this.isCanEditPrice = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("计 划 单", "调用计划单列表 可进行并单操作", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);
            toolBarService.AddToolButton("日 消 耗", "查看药品日消耗信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("采购拆分", "对某条药品拆分为多条采购信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "计 划 单")
            {
                this.ShowInPlanList();
            }
            if (e.ClickedItem.Text == "日 消 耗")
            {
                this.PopExpandData();
            }
            if (e.ClickedItem.Text == "采购拆分")
            {
                this.SplitPlan();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.SaveStockPlan() == 1)
            {
                this.ShowList();
            }
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();
            ArrayList alSavePlanList = new ArrayList();

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.StockPlan;
                if (stockPlan == null)
                {
                    MessageBox.Show(Language.Msg("处理采购计划保存时 发生类型转换错误"));
                    return -1;
                }

                stockPlan.Oper.ID = this.itemManager.Operator.ID;
                stockPlan.Oper.OperTime = sysTime;                      //操作人员信息

                stockPlan.StockPrice = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text);     //药品购入价
                stockPlan.StockApproveQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveNum].Text) * stockPlan.Item.PackQty;   //采购数量

                stockPlan.Item.PriceCollection.PurchasePrice = stockPlan.StockPrice;        //药品购入价 赋值为 药品计划购入价
                stockPlan.StockOper = stockPlan.Oper;                                       //采购人

                stockPlan.ApproveOper = stockPlan.Oper;

                alSavePlanList.Add(stockPlan);
            }

            return this.Print(alSavePlanList, false);
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export()
        {
            try
            {
                if (this.neuSpread1.Export() == 1)
                {
                    MessageBox.Show(Language.Msg("导出成功"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsNeedApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Stock_Need_Approve, true, true);
            this.IsCanEditWhenApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Stock_Edit_InPlan, true, false);
            this.IsCanEditPrice = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Stock_Edit_Price, true, true);
            this.UseDefaultStockData = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Stock_Use_DefaultData, true, true);
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        private int InitData()
        {
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            this.fpSpread2_Sheet1.DefaultStyle.Locked = true;           

            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            #region 获取生产厂家/供货公司帮助类

            //获得供货公司列表
            if (this.alCompany == null)
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                this.alCompany = phaConstant.QueryCompany("1");
                if (this.alCompany == null)
                {
                    MessageBox.Show(Language.Msg("获取供货单位列表出错"));
                    return -1;
                }

                this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alCompany);
            }
            if (this.alProduce == null)
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                this.alProduce = phaConstant.QueryCompany("0");
                if (this.alProduce == null)
                {
                    MessageBox.Show(Language.Msg("获取生产厂家列表出错"));
                    return -1;
                }
                this.produceHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alProduce);
            }

            #endregion

            this.InitControlParam();

            //采购计划 允许修改审核数量/供货公司
            //采购审核且属性设置为允许修改
            if (this.winFun == EnumWindowFun.采购计划 || (this.winFun == EnumWindowFun.采购审核 && this.isCanEditWhenApprove))      
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].Locked = false;
                this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].BackColor = System.Drawing.Color.SeaShell;

                if (this.isCanEditPrice)
                {
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = false;
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].BackColor = System.Drawing.Color.SeaShell;
                }
                else
                {
                    this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = true;
                }
            }

            return 1;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加入实体信息到Fp内
        /// </summary>
        /// <param name="stockPlan">采购实体信息</param>
        /// <param name="rowIndex">需添加的行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan,int rowIndex)
        {
            if (stockPlan.State == "2")
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].Locked = true;
                this.neuSpread1_Sheet1.Columns[(int)ColumnStockSet.ColApproveNum].BackColor = System.Drawing.Color.White;
            }

            #region 获取历史采购信息

            ArrayList alHistory = this.itemManager.QueryHistoryStockPlan(stockPlan.Dept.ID, stockPlan.Item.ID);
            if (alHistory == null)
            {
                Function.ShowMsg("获取历史采购信息出错" + this.itemManager.Err);
                return -1;
            }

            this.alPlanHistory.Add(alHistory);

            if (!this.isUseDefaultStockData)        //显示上一次的购入信息
            {
                if (alHistory.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.StockPlan stockTemp = alHistory[0] as Neusoft.HISFC.Models.Pharmacy.StockPlan;
                    //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                    //如果是已经选择了供货公司的话，则不用默认的
                    if (stockPlan.Company == null || stockPlan.Company.ID == "")
                    {
                        stockPlan.Company = stockTemp.Company;
                    }
                    if (stockPlan.Item.Product.Producer == null || stockPlan.Item.Product.Producer.ID == "")
                    {
                        stockPlan.Item.Product.Producer = stockTemp.Item.Product.Producer;
                    }
                    if (stockPlan.StockPrice == 0)
                    {
                        stockPlan.StockPrice = stockTemp.StockPrice;
                    }
                }
            }

            #endregion

            if (stockPlan.Item.PackQty == 0)
            {
                stockPlan.Item.PackQty = 1;
            }

            #region 药品信息

            Neusoft.HISFC.Models.Pharmacy.Item tempItem = new Neusoft.HISFC.Models.Pharmacy.Item();
            tempItem = this.itemManager.GetItem(stockPlan.Item.ID);
            if (tempItem == null)
            {
                Function.ShowMsg("未正确获取药品信息" + this.itemManager.Err);
                return -1;
            }

            #endregion

            this.neuSpread1_Sheet1.Rows.Add(rowIndex, 1);

            #region Fp赋值

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColTenderFlag].Value = tempItem.TenderOffer.IsTenderOffer;     //招标药标志
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColTradeName].Value = stockPlan.Item.Name;		                    //药品名称
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColSpecs].Value = stockPlan.Item.Specs;		                        //规格
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Value = stockPlan.StockPrice;	                        //药品购入价				
            //计划采购数量(按包装单位显示)
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColPlanNum].Value = stockPlan.PlanQty / stockPlan.Item.PackQty;
            //审核数量(按包装单位显示)
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColApproveNum].Value = stockPlan.StockApproveQty / stockPlan.Item.PackQty;
            //包装单位
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColUnit].Value = stockPlan.Item.PackUnit;
            //审核金额
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColApproveCost].Value = stockPlan.StockApproveQty / stockPlan.Item.PackQty * stockPlan.Item.PriceCollection.PurchasePrice;

            if (this.companyHelper.GetObjectFromID(stockPlan.Company.ID) != null)
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColCompany].Value = stockPlan.Company.Name;                      //供货公司名称
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColProduceName].Value = stockPlan.Item.Product.Producer.Name;	//生产厂家
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColCompany].Value = this.companyHelper.GetName(tempItem.Product.Company.ID);         //供货公司名称
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColProduceName].Value = this.produceHelper.GetName(tempItem.Product.Producer.ID);	//生产厂家               

                stockPlan.Company.ID = tempItem.Product.Company.ID;
                stockPlan.Company.Name = this.companyHelper.GetName(tempItem.Product.Company.ID);

                stockPlan.Item.Product.Producer.ID = tempItem.Product.Producer.ID;
                stockPlan.Item.Product.Producer.Name = this.produceHelper.GetName(tempItem.Product.Producer.ID);
            }

            if (stockPlan.StockPrice == 0)
            {
                if (tempItem.PriceCollection.PurchasePrice == 0)
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Text = tempItem.PriceCollection.RetailPrice.ToString("N");
                else
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Text = tempItem.PriceCollection.PurchasePrice.ToString();//{1EC17564-2FAD-4a77-97AC-4C57076888B2}
            }

            //全院库存/本科库存 保存制定入库计划时的值
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColOwnStockNum].Value = stockPlan.StoreQty / stockPlan.Item.PackQty;
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColAllStockNum].Value = stockPlan.StoreTotQty / stockPlan.Item.PackQty;

            this.neuSpread1_Sheet1.Rows[rowIndex].Tag = stockPlan;

            #endregion

            //显示入库计划单信息
            if (rowIndex == 0)
            {
                #region 显示入库计划单信息

                //获得科室名称
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(stockPlan.Dept.ID);
                //获得操作员姓名
                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.Models.Base.Employee person = personManager.GetPersonByID(stockPlan.Oper.ID);
                this.lbPlanBill.Text = "单据号:" + stockPlan.BillNO;                            //入库计划单号
                this.lbPlanInfo.Text = string.Format("计划科室 {0} 计划人 {1}",dept.Name,person.Name);     //操作科室

                #endregion
            }

            return 1;
        }

        /// <summary>
        /// 加入实体信息到Fp内
        /// </summary>
        /// <param name="stockPlan">采购实体信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            return this.AddDataToFp(stockPlan, this.neuSpread1_Sheet1.Rows.Count);
        }

        /// <summary>
        /// 加入实体信息
        /// </summary>
        /// <param name="inPlan">入库计划实体信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan = new Neusoft.HISFC.Models.Pharmacy.StockPlan();

            stockPlan.BillNO = inPlan.BillNO;               //单据号
            stockPlan.Dept = inPlan.Dept;                   //计划科室
            stockPlan.Item = inPlan.Item;                   //药品信息
            stockPlan.StoreQty = inPlan.StoreQty;           //本科库存
            stockPlan.StoreTotQty = inPlan.StoreTotQty;     //全院库存
            stockPlan.OutputQty = inPlan.OutputQty;         //日均出库
            stockPlan.PlanQty = inPlan.PlanQty;             //计划数量
            stockPlan.PlanOper = inPlan.PlanOper;           //计划人
            stockPlan.Extend = inPlan.Extend;               //扩展字段信息

            stockPlan.PlanNO = inPlan.ID;                   //计划流水号  保存采购计划对应的入库计划的流水号

            stockPlan.StockApproveQty = inPlan.PlanQty;     //审核数量

            return this.AddDataToFp(stockPlan);
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        public void Clear()
        {
            //情况Fp显示
            this.fpSpread2_Sheet1.Rows.Count = 0;
            this.neuSpread1_Sheet1.Rows.Count = 0;

            //采购信息集合清空
            this.hsStockPlan.Clear();
            this.alPlanHistory.Clear();

            this.lbPlanBill.Text = "单据号:";
            this.lbPlanInfo.Text = "计划科室 计划人";
            this.lbCost.Text = "计划总金额";

            this.ClearHistoryData();
        }

        /// <summary>
        /// 数据明细检索
        /// </summary>
        public void ShowStockData()
        {
            //清空数据
            this.Clear();
            if (this.nowOperBillNO == null || this.nowOperBillNO.Trim() == "")
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在检索入库计划单信息..."));
            Application.DoEvents();

            ArrayList alDetail = this.itemManager.QueryStockPlanByCompany(this.privDept.ID, this.nowOperBillNO, this.nowCompanyNO);
            if (alDetail == null)
            {
                Function.ShowMsg("获取采购计划信息出错" + this.itemManager.Err);
                return;
            }

            int iCount = 1;

            foreach (Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan in alDetail)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(iCount, alDetail.Count);
                Application.DoEvents();

                if (this.AddDataToFp(stockPlan) == 1)
                {
                    this.hsStockPlan.Add(stockPlan.ID, stockPlan);
                }                
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //增加合计
            this.SetSum();

            this.neuSpread1_Sheet1.ActiveRowIndex = 0;
            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColStockPrice;
        }

        /// <summary>
        /// 计算合计
        /// </summary>
        /// <returns></returns>
        private void SetSum()
        {
            try
            {
                if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                    return;
               
                decimal costSum = 0;
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    costSum = costSum + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text);
                }

                this.lbCost.Text = "计划总金额: " + costSum.ToString("N");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 判断是否已正确输入数据
        /// </summary>
        /// <returns></returns>
        public bool IsValidate()
        {
            int num = this.neuSpread1_Sheet1.RowCount;

            if (num <= 0)
            {
                return false;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                string trandeName = this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColTradeName].Text;

                if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() == "")
                {
                    MessageBox.Show(Language.Msg("请输入" + trandeName + " 供货公司"));
                    this.neuSpread1_Sheet1.ActiveRowIndex = i;
                    return false;
                }
                //如供货公司为"不详"，则可以不输入购入价
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() != "不详" && NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text) <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入" + trandeName + " 购入价!！"));
                    this.neuSpread1_Sheet1.ActiveRowIndex = i;
                    return false;
                }
                if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text) <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入" + trandeName + " 购入数量"));
                    this.neuSpread1_Sheet1.ActiveRowIndex = i;
                    return false;
                }
                if (this.neuSpread1_Sheet1.Columns.Get((int)ColumnStockSet.ColApproveNum).Visible && NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveNum].Text) <= 0)
                {
                    MessageBox.Show(Language.Msg("请输入" + trandeName + " 审核购入数量"));
                    this.neuSpread1_Sheet1.ActiveRowIndex = i;
                    return false ;
                }
                //审核数量 大于 计划数量 提示是否确认
                if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text) < NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveNum].Text))
                {
                    DialogResult rs = MessageBox.Show(Language.Msg(trandeName + " 的审核数量大于计划数量 是否确认审核通过"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 计划单打印
        /// </summary>
        /// <param name="alPrintData">待打印数据</param>
        /// <param name="isCue">是否进行提示</param>
        /// <returns></returns>
        public virtual int Print(ArrayList alPrintData,bool isCue)
        {
            //药品打印接口调用出错Bug处理，如果同时开了入库计划和采购计划并进行过打印的情况下，切换界面点打印就会调用上一个打印接口实现 by Sunjh 2010-8-26 {D78A574D-59BE-491b-808C-38DCD26BA5EA}
            Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            //if (Function.IPrint == null)
            //{
            //    Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            //}

            if (Function.IPrint != null)
            {
                if (isCue)
                {
                    DialogResult rs = MessageBox.Show(Language.Msg("是否打印计划单？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.No)
                    {
                        return 1;
                    }
                }

                Function.IPrint.SetData(alPrintData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.StockPlan);

                Function.IPrint.Print();
            }

            return 1;
        }

        /// <summary>
        /// 获取供货公司/生产厂家信息 并将对供货公司的更改反馈给行Tag实体
        /// </summary>
        private void PopStockCompany()
        {
            //当前记录的行、列
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;
            int j = this.neuSpread1_Sheet1.ActiveColumnIndex;
            //如无数据则返回
            if (this.neuSpread1_Sheet1.RowCount == 0)
                return;

            if (i < 0) return;

            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanTemp = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.StockPlan;

            if (j == (int)ColumnStockSet.ColCompany)
            {
                //获得供货公司列表
                if (this.alCompany == null)
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                    this.alCompany = phaConstant.QueryCompany("1");
                    if (this.alCompany == null)
                    {
                        MessageBox.Show(Language.Msg("获取供货单位列表出错"));
                        return;
                    }
                }
                //操作员对窗口选择返回的信息
                Neusoft.FrameWork.Models.NeuObject companyTemp = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref companyTemp) == 0)
                {
                    return;
                }
                else
                {                    
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Value = companyTemp.Name;       //供货公司
                    stockPlanTemp.Company = companyTemp;
                }
            }
            if (j == (int)ColumnStockSet.ColProduceName)
            {
                //获得供货公司列表
                if (this.alProduce == null)
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                    this.alProduce = phaConstant.QueryCompany("0");
                    if (this.alProduce == null)
                    {
                        MessageBox.Show(Language.Msg("获取生产厂家列表出错"));
                        return;
                    }
                }
                //操作员对窗口选择返回的信息
                Neusoft.FrameWork.Models.NeuObject producTemp = new Neusoft.FrameWork.Models.NeuObject();
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alProduce, ref producTemp) == 0)
                {
                    return;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColProduceName].Value = producTemp.Name;     //供货公司                    
                    stockPlanTemp.Item.Product.Producer = producTemp;
                }
            }

            //{C03DD304-AE71-4b6a-BC63-F385DB162EB7}
            //重新将修改的信息返回给Tag
            this.neuSpread1_Sheet1.Rows[i].Tag = stockPlanTemp;
        }

        /// <summary>
        /// 弹出日消耗计算控件
        /// </summary>
        public void PopExpandData()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                return;

            ucPhaExpand uc = new ucPhaExpand();

            uc.IsOnlyPatientInOut = true;

            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.StockPlan;
            Neusoft.FrameWork.Models.NeuObject tempDrug = stockPlan.Item;

            Neusoft.FrameWork.Models.NeuObject tempDept = new Neusoft.FrameWork.Models.NeuObject();
            tempDept.ID = "AAAA";
            tempDept.Name = "全院";

            uc.SetData(tempDept, tempDrug, 10);

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int SaveStockPlan()
        {
            if (!this.IsValidate())
            {
                return -1;
            }
            //系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            //定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            List<Neusoft.HISFC.Models.Pharmacy.StockPlan> alSavePlanList = new List<Neusoft.HISFC.Models.Pharmacy.StockPlan>();

            bool isStock = false;

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.StockPlan;
                if (stockPlan == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("处理采购计划保存时 发生类型转换错误"));
                    return -1;
                }
                if (stockPlan.State == "2")
                {
                    isStock = true;
                }

                #region 并发判断  根据业务层的函数 无法将并发判断放入Sql语句Update内

                if (stockPlan.ID != "")
                {
                    ArrayList alTemp = this.itemManager.QueryStockPlanDetail(stockPlan.ID);
                    if (alTemp == null || alTemp.Count <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("该采购计划信息已不存在 数据已发生变化 请退出界面重试"));
                        return -1;
                    }
                    Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanTemp = alTemp[0] as Neusoft.HISFC.Models.Pharmacy.StockPlan;
                    if (stockPlanTemp.State != stockPlan.State)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("该计划信息状态已发生变化 请退出界面重试"));
                        return -1;
                    }
                }

                #endregion

                #region 采购计划赋值

                stockPlan.Oper.ID = this.itemManager.Operator.ID;
                stockPlan.Oper.OperTime = sysTime;                      //操作人员信息

                stockPlan.StockPrice = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text);     //药品购入价
                stockPlan.StockApproveQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveNum].Text) * stockPlan.Item.PackQty;   //采购数量

                if (this.winFun == EnumWindowFun.采购计划)
                {
                    #region 采购计划制定

                    stockPlan.Item.PriceCollection.PurchasePrice = stockPlan.StockPrice;        //药品购入价 赋值为 药品计划购入价
                    stockPlan.StockOper = stockPlan.Oper;                                       //采购人
                    //如供货公司为不详 则不改变计划单状态
                    if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() == "不详")
                        stockPlan.State = "0";
                    else
                        stockPlan.State = "1";
                    //如采购不需要审核 则直接设置状态为2 审核
                    if (!this.isNeedApprove)
                    {
                        stockPlan.ApproveOper = stockPlan.Oper;
                        stockPlan.State = "2";
                    }

                    #endregion
                }
                else           //采购审核功能
                {
                    stockPlan.ApproveOper = stockPlan.Oper;
                    stockPlan.State = "2";
                }

                #endregion

                alSavePlanList.Add(stockPlan);
            }

            #region 采购计划保存

            int param = this.itemManager.SaveStockPlan(alSavePlanList);
            if (param == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("采购计划信息更新失败" + this.itemManager.Err));
                return -1;
            }
            if (param == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("入库计划数据已删除或已做完采购计划 请与入库计划人员联系"));
                return -1;
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isStock)
            {
                MessageBox.Show("采购单内存在已审核完成数据 不需要重复审核");
            }

            MessageBox.Show(Language.Msg("保存成功"));

            this.Print(new ArrayList(alSavePlanList.ToArray()),true);

            this.Clear();

            return 1;
        }

        #endregion

        #region 入库计划单检索 合/拆单操作

        /// <summary>
        /// 计划单据选择/合并
        /// </summary>
        private ucPlanList ucMergeList = null;

        /// <summary>
        /// 采购单拆分
        /// </summary>
        private ucSplitPlan ucSplitPlan = null;

        /// <summary>
        /// 入库计划单显示
        /// </summary>
        /// <returns></returns>
        public int ShowInPlanList()
        {
            if (this.ucMergeList == null)
            {
                this.ucMergeList = new ucPlanList();
            }

            this.ucMergeList.OperPrivDept = this.privDept;      //权限科室
            this.ucMergeList.State = "0";                       //单据状态 0

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucMergeList);
            if (this.ucMergeList.Result == DialogResult.OK)     //显示单据合并
            {
                List<Neusoft.HISFC.Models.Pharmacy.InPlan> alterPlan = this.ucMergeList.AlterInPlan;

                this.Clear();

                foreach (Neusoft.HISFC.Models.Pharmacy.InPlan inPlanObj in alterPlan)
                {
                    this.AddDataToFp(inPlanObj);
                }
            }
            return 1;
        }

        /// <summary>
        /// 入库计划单拆分多张采购单
        /// </summary>
        /// <returns></returns>
        public int SplitPlan()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return -1;
            }

            if (!this.neuSpread1.ContainsFocus || this.neuSpread1_Sheet1.ActiveRowIndex < 0)
            {
                MessageBox.Show(Language.Msg("请选择需拆分项目"));
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.StockPlan;
            if (stockPlan == null)
            {
                MessageBox.Show(Language.Msg("由Fp内获取实体发生错误"));
                return -1;
            }

            if (this.ucSplitPlan == null)
            {
                this.ucSplitPlan = new ucSplitPlan();

                this.ucSplitPlan.Init();
            }

            this.ucSplitPlan.OriginalStockPlan = stockPlan;

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucSplitPlan);
            if (this.ucSplitPlan.Result == DialogResult.OK)     //显示单据拆分
            {
                List<Neusoft.HISFC.Models.Pharmacy.StockPlan> splitPlan = this.ucSplitPlan.SplitPlan;

                int iRemoveIndex = this.neuSpread1_Sheet1.ActiveRowIndex;

                this.neuSpread1_Sheet1.Rows.Remove(iRemoveIndex, 1);

                foreach (Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlanObj in splitPlan)
                {
                    this.AddDataToFp(stockPlanObj,iRemoveIndex);

                    iRemoveIndex++;
                }
            }

            return 1;
        }

        #endregion

        #region 显示历史采购记录

        /// <summary>
        /// 清除原显示的历史采购信息
        /// </summary>
        private void ClearHistoryData()
        {
            this.tbStockHistory.Text = " 历史采购信息";
            this.fpSpread2_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 增加历史采购信息
        /// </summary>
        /// <param name="stockPlan">历史采购信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddHistoryDataToFp(Neusoft.HISFC.Models.Pharmacy.StockPlan stockPlan)
        {
            int iRowIndx = this.fpSpread2_Sheet1.Rows.Count;

            this.fpSpread2_Sheet1.Rows.Add(iRowIndx, 1);           

            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColTenderFlag].Value = stockPlan.Item.TenderOffer.IsTenderOffer;		//招标药
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColStockTime].Value = stockPlan.StockOper.OperTime;		                //采购日期
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColStockQty].Text = (stockPlan.StockApproveQty / stockPlan.Item.PackQty).ToString();		//采购数量
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColUnit].Text = stockPlan.Item.PackUnit;				                //单位
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColStockPrice].Text = stockPlan.StockPrice.ToString();		            //购入价
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColRetailPrice].Text = stockPlan.Item.PriceCollection.RetailPrice.ToString();		    //零售价
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColCompany].Text = stockPlan.Company.Name;				                //供货公司
            this.fpSpread2_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColProduce].Text = stockPlan.Item.Product.Producer.Name;		                //生产厂家

            return 1;
        }

        /// <summary>
        /// 增加历史采购信息
        /// </summary>
        /// <param name="alHistory"></param>
        private void AddHistoryDataToFp(ArrayList alHistory)
        {
            foreach (Neusoft.HISFC.Models.Pharmacy.StockPlan info in alHistory)
            {
                this.AddHistoryDataToFp(info);
            }
        }

        /// <summary>
        /// 显示历史采购记录
        /// </summary>
        protected void ShowHistoryData()
        {
            if (this.neuSpread1_Sheet1.RowCount <= 0)
                return;

            if (this.alPlanHistory.Count > this.neuSpread1_Sheet1.ActiveRowIndex)
            {
                this.ClearHistoryData();

                //显示Tab页上提示信息
                this.tbStockHistory.Text = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnStockSet.ColTradeName].Text + "[" + this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnStockSet.ColSpecs].Text + "]" + " 历史采购信息";

                this.AddHistoryDataToFp(this.alPlanHistory[this.neuSpread1_Sheet1.ActiveRowIndex] as ArrayList);
            }
        }

        #endregion

        #region 树操作

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            Neusoft.FrameWork.Models.NeuObject temp = neuObject as Neusoft.FrameWork.Models.NeuObject;

            if (temp != null)
            {
                this.nowOperBillNO = temp.ID;       //采购单号
                this.nowCompanyNO = temp.User01;    //供货单位号

                this.ShowStockData();
            }

            return base.OnSetValue(neuObject, e);
        }

        /// <summary>
        /// 列表刷新显示
        /// </summary>
        protected void ShowList()
        {
            //{368C3BA2-C27A-4ed2-8062-A52A40468F93}
            if ((this.winFun == EnumWindowFun.采购计划 && this.IsNeedApprove) || (this.winFun == EnumWindowFun.采购审核))
            {
                (this.tv as tvPlanList).ShowStockPlanList(this.privDept, "1");
            }
            else
            {
                (this.tv as tvPlanList).ShowStockPlanList(this.privDept, "2");
            }
        }

        #endregion

        #region 事件

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.privOper = this.itemManager.Operator;

                //string class2Priv = "0312";
                //if (this.winFun == EnumWindowFun.采购计划)
                //{
                //    class2Priv = "0312";
                //}
                //else
                //{
                //    class2Priv = "0313";

                //    this.toolBarService.SetToolButtonEnabled("计 划 单", false);
                //    this.toolBarService.SetToolButtonEnabled("采购拆分", false);
                //}

                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept(class2Priv, ref testPrivDept);

                //if (parma == -1)            //无权限
                //{
                //    MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                //    return;
                //}
                //else if (parma == 0)       //用户选择取消
                //{
                //    return;
                //}

                //this.privDept = testPrivDept;

                //base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name); 

                //{52402239-DB82-41c8-A8A7-2411B9EF64F1}  初始化打印接口
                Function.IPrint = null;

                this.InitData();

                if (this.tv as tvPlanList == null)
                {
                    MessageBox.Show(Language.Msg("树控件类型设置错误"));
                    return;
                }

                this.ShowList();
            }

            base.OnLoad(e);
        }

        private void fpStockApprove_EditModeOff(object sender, EventArgs e)
        {
            if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColStockPrice || this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColApproveNum)
            {
                int i = this.neuSpread1_Sheet1.ActiveRowIndex;
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColTradeName].Text == "合计")
                    return;
                //计算计划金额
                try
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text = (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text) * NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveNum].Text)).ToString();

                    this.SetSum();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg(ex.Message));
                }
                return;
            }
        }

        /// <summary>
        /// 处理回车跳转、上下箭头移动时改变 历史采购显示
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    #region 设置跳转
                    int iRow = this.neuSpread1_Sheet1.ActiveRowIndex;
                    int iColumn = this.neuSpread1_Sheet1.ActiveColumnIndex;

                    switch (iColumn)
                    {
                        case (int)ColumnStockSet.ColStockPrice:
                            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColApproveNum;
                            break;
                        case (int)ColumnStockSet.ColApproveNum:
                            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColCompany;
                            break;
                        case (int)ColumnStockSet.ColCompany:
                            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColProduceName;
                            break;
                        case (int)ColumnStockSet.ColProduceName:
                            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColMemo;
                            break;
                        case (int)ColumnStockSet.ColMemo:
                            this.neuSpread1_Sheet1.ActiveColumnIndex = 0;		//使焦点先跳转到第一列 否则直接跳转到价格看不到第一列
                            this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColStockPrice;
                            this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.ActiveRowIndex + 1;
                            this.ShowHistoryData();
                            break;
                    }
                    return true;
                    #endregion
                }
                if (keyData == Keys.Up)
                {
                    if (this.neuSpread1_Sheet1.ActiveRowIndex != 0)
                        this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.ActiveRowIndex - 1;
                    this.ShowHistoryData();
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    if (this.neuSpread1_Sheet1.ActiveRowIndex != this.neuSpread1_Sheet1.Rows.Count - 1)
                    {
                        this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.ActiveRowIndex + 1;
                    }
                    this.ShowHistoryData();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 处理对历史药品采购记录的弹出功能
        /// </summary>
        private void fpStockApprove_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //当前记录的行、列
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;
            int j = this.neuSpread1_Sheet1.ActiveColumnIndex;

            //回车键键码 13 空格键键码 32
            if (e.KeyChar == 32)
            {
                this.PopStockCompany();
            }
            else
            {      //按下的为Backspace键
                if (e.KeyChar == (char)8 && j == (int)ColumnStockSet.ColCompany)
                {
                    //{CF118F6D-8144-439c-B7E9-A30A24AB7EF1}按下Backspace键之后，供货公司置空
                    //this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Value = "不详";  //供货公司
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Value = "";
                }
            }
        }

        /// <summary>
        /// 处理对历史药品采购记录的弹出功能
        /// </summary>
        private void fpStockApprove_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //如果点击的为行或列标题则直接返回
            if (e.ColumnHeader || e.RowHeader)
                return;
            //功能窗口为采购审核 且不允许修改采购单信息
            if (this.winFun == EnumWindowFun.采购审核 && !this.isCanEditWhenApprove)
                return;

            this.PopStockCompany();
        }

        /// <summary>
        /// 选择不同行时显示不同历史采购信息
        /// </summary>
        private void fpStockApprove_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            this.ShowHistoryData();
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 窗口功能
        /// </summary>
        public enum EnumWindowFun
        {
            采购计划,
            采购审核
        }

        #endregion

        #region 列设置

        /// <summary>
        /// 采购计划列设置
        /// </summary>
        private enum ColumnStockSet
        {
            /// <summary>
            /// 0 是否招标药
            /// </summary>
            ColTenderFlag,
            /// <summary>
            /// 1 药品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 2 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 3 计划购入价
            /// </summary>
            ColStockPrice,
            /// <summary>
            /// 4 计划数量
            /// </summary>
            ColPlanNum,
            /// <summary>
            /// 5 审核数量
            /// </summary>
            ColApproveNum,
            /// <summary>
            /// 6 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 7 审核金额
            /// </summary>
            ColApproveCost,
            /// <summary>
            /// 8 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 9 生产厂家
            /// </summary>
            ColProduceName,
            /// <summary>
            /// 10 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 11 科室库存
            /// </summary>
            ColOwnStockNum,
            /// <summary>
            /// 12 全院库存
            /// </summary>
            ColAllStockNum
        }

        /// <summary>
        /// 采购计划列设置
        /// </summary>
        private enum ColumnHistorySet
        {
            /// <summary>
            /// 0 是否招标药
            /// </summary>
            ColTenderFlag,
            /// <summary>
            /// 0 采购日期
            /// </summary>
            ColStockTime,
            /// <summary>
            /// 1 采购数量
            /// </summary>
            ColStockQty,
            /// <summary>
            /// 2 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 3 购入价
            /// </summary>
            ColStockPrice,
            /// <summary>
            /// 4 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 5 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 6 生产厂家
            /// </summary>
            ColProduce,
            /// <summary>
            /// 7 备注
            /// </summary>
            ColMemo
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                printType[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint);

                return printType;
            }
        }

        #endregion

        #region IPreArrange 成员

        public int PreArrange()
        {
            string class2Priv = "0312";
            if (this.winFun == EnumWindowFun.采购计划)
            {
                class2Priv = "0312";
            }
            else
            {
                class2Priv = "0313";

                this.toolBarService.SetToolButtonEnabled("计 划 单", false);
                this.toolBarService.SetToolButtonEnabled("采购拆分", false);
            }

            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept(class2Priv, ref testPrivDept);

            if (parma == -1)            //无权限
            {
                MessageBox.Show(Language.Msg("您无此窗口操作权限"));
                return -1;
            }
            else if (parma == 0)       //用户选择取消
            {
                return -1;
            }

            this.privDept = testPrivDept;

            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            return 1;
        }

        #endregion
    }
}
