using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Material.Plan
{
    /// <summary>
    /// 通过设置ListState与SaveState属性 在正常流程处理内增加多种审核流程
    /// </summary>
    public partial class ucInPlan : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucInPlan()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 数值单据类型
        /// </summary>
        private FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

        /// <summary>
        /// 用于计算日均出库量，日消耗
        /// </summary>
        private int outday = 30;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper produceHelpter = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 入库计划管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Plan planManager = new Neusoft.HISFC.BizLogic.Material.Plan();

        /// <summary>
        /// 物品基本信息管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 库存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 存储计划数据
        /// </summary>
        private System.Collections.Hashtable hsPlanData = new Hashtable();

        ///// <summary>
        ///// 入库计划单需要审核的次数 最多2次
        ///// </summary>
        //private int inplanExamTimes = 0;

        /// <summary>
        /// 是否对计划数量为0进行有效性判断 
        /// </summary>
        private bool isJudgeValid = true;

        /// <summary>
        /// 当前操作单号
        /// </summary>
        private string nowBillNO = "";

        /// <summary>
        /// 计划类型 入库计划单类型 0 手工计划 1 警戒线 2 消耗 3 时间 4 日消耗 5 模版
        /// </summary>
        private string planType = "0";

        /// <summary>
        /// 是否对计划量为零进行判断
        /// </summary>
        private bool isCheckNumZero = true;

        /// <summary>
        /// 判断当前打开窗口是否是审核窗口
        /// </summary>
        private bool isCheck = false;

        /// <summary>
        /// 是否需要财务审核
        /// </summary>
        private bool isFinance = false;

        /// <summary>
        /// 是否使用最小单位进行处理
        /// </summary>
        private bool isMinUnit = false;

        /// <summary>
        /// 计划单类型
        /// </summary>
        private BillTypeEnum billType = BillTypeEnum.PlanList;

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime BeginTime;

        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime EndTime;

        /// <summary>
        /// 当前窗口类型：入库计划、入库计划审核
        /// </summary>
        private EnumWindowFunInPlan winFun = EnumWindowFunInPlan.入库计划;

        #endregion

        #region 属性

        /// <summary>
        /// 用于计算日均出库量，日消耗 统计天数
        /// </summary>
        [Description("用于计算日均出库量，日消耗 统计天数"), Category("设置")]
        public int Outday
        {
            get
            {
                return this.outday;
            }
            set
            {
                this.outday = value;
            }
        }

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
        /// 是否对计划数量为0进行有效性判断
        /// </summary>
        [Description("是否对计划数量为0进行有效性判断"), Category("设置"), DefaultValue(true)]
        public bool IsJudgeValid
        {
            get
            {
                return this.isJudgeValid;
            }
            set
            {
                this.isJudgeValid = value;
            }
        }

        /// <summary>
        /// 是否显示行标题
        /// </summary>
        [Description("列表选择控件是否显示行标题"), Category("设置"), DefaultValue(true)]
        public bool IsShowRowHeader
        {
            get
            {
                return this.ucMaterialItemList1.ShowFpRowHeader;
            }
            set
            {
                this.ucMaterialItemList1.ShowFpRowHeader = value;
            }
        }

        /// <summary>
        /// 是否允许通过行索引确认选择数据
        /// </summary>
        [Description("列表选择控件是否允许通过行索引确认选择数据"), Category("设置"), DefaultValue(false)]
        public bool IsSelectByNumber
        {
            get
            {
                return this.ucMaterialItemList1.IsUseNumChooseData;
            }
            set
            {
                this.ucMaterialItemList1.IsUseNumChooseData = value;
            }
        }

        /// <summary>
        /// 是否对计划量是否为零进行判断
        /// </summary>
        [Description("是否对计划量是否为零进行判断"), Category("设置"), DefaultValue(false)]
        public bool IsCheckNumZero
        {
            get
            {
                return this.isCheckNumZero;
            }
            set
            {
                this.isCheckNumZero = value;
            }
        }

        /// <summary>
        /// 是否显示计划单列表
        /// </summary>
        [Browsable(false)]
        public bool IsShowList
        {
            get
            {
                return this.ucMaterialItemList1.ShowTreeView;
            }
            set
            {
                this.ucMaterialItemList1.ShowTreeView = value;

                this.IsShowLeftPanel = true;
            }
        }

        /// <summary>
        /// 判断当前打开窗口是否是审核窗口
        /// </summary>
        [Browsable(false)]
        public bool IsCheck
        {
            get
            {
                return this.isCheck;
            }
            set
            {
                this.isCheck = value;

                this.toolBarService.SetToolButtonEnabled("申请汇总", !value);
                this.toolBarService.SetToolButtonEnabled("申 请 单", !value);
            }
        }

        /// <summary>
        /// 当前窗口类型：入库计划、入库计划审核
        /// </summary>
        [Description("窗口功能"), Category("设置"), DefaultValue(false)]
        public EnumWindowFunInPlan WinFun
        {
            get
            {
                return this.winFun;
            }
            set
            {
                this.winFun = value;
                if (this.winFun == EnumWindowFunInPlan.入库计划)
                {
                    this.IsCheck = false;
                }
                else
                {
                    this.IsCheck = true;
                }
            }
        }

        /// <summary>
        /// 是否需要财务审核
        /// </summary>
        public bool IsFinance
        {
            get
            {
                return this.isFinance;
            }
            set
            {
                this.isFinance = value;
            }
        }

        /// <summary>
        /// 是否显示左侧Panel
        /// </summary>
        public bool IsShowLeftPanel
        {
            get
            {
                return !this.splitContainer1.Panel1Collapsed;
            }
            set
            {
                this.splitContainer1.Panel1Collapsed = !value;
            }
        }

        #endregion

        #region 状态相关属性

        /// <summary>
        /// 单据列表检索状态
        /// </summary>
        private string listState = "0";

        /// <summary>
        /// 单据保存状态
        /// </summary>
        private string saveState = "1";

        /// <summary>
        /// 单据列表检索状态
        /// </summary>
        [Description("单据列表检索状态"), Category("设置"), DefaultValue("0")]
        public string ListState
        {
            get
            {
                return this.listState;
            }
            set
            {
                this.listState = value;
            }
        }

        ///// <summary>
        ///// 物资入库计划单需要审核的次数，最多2次
        ///// </summary>
        //[Description("物资入库计划单需要审核的次数，最多2次"), Category("设置"), DefaultValue("0")]
        //public int InplanExamTimes
        //{
        //    get
        //    {
        //        return this.inplanExamTimes;
        //    }
        //    set
        //    {
        //        this.inplanExamTimes = value;
        //    }
        //}

        /// <summary>
        /// 单据保存状态
        /// </summary>
        [Description("单据检索状态"), Category("设置"), DefaultValue("1")]
        public string SaveState
        {
            get
            {
                return this.saveState;
            }
            set
            {
                this.saveState = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("显 示 栏", "显示栏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);
            toolBarService.AddToolButton("新    建", "新建计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("计 划 单", "计划单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("删    除", "删除当前选择的计划药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("整单删除", "删除整单计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolBarService.AddToolButton("申 请 单", "申请单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换单, true, false, null);
            toolBarService.AddToolButton("申请汇总", "申请汇总", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印输液卡, true, false, null);
            toolBarService.AddToolButton("警 戒 线", "库存警戒线", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B报警, true, false, null);
            toolBarService.AddToolButton("日 消 耗", "调用模版生成计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R日消耗, true, false, null);
            toolBarService.AddToolButton("日    期", "设置计划单检索日期", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);


            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "新    建":
                    this.New();
                    break;
                case "删    除":
                    this.DeleteData();
                    break;
                case "整单删除":
                    this.DeleteDataByBill(this.privDept.ID, this.nowBillNO);
                    break;
                case "计 划 单":
                    this.tvList.ShowInPlanList(this.privDept, this.listState);
                    this.IsShowList = true;
                    this.billType = BillTypeEnum.PlanList;
                    break;
                case "申 请 单":
                    this.ShowApplyInfo(false);
                    break;
                case "申请汇总":
                    this.ShowApplyInfo(true);
                    break;
                case "警 戒 线":
                    AddAlterData("0");
                    break;
                case "日 消 耗":
                    AddAlterData("1");
                    break;
                case "保    存":
                    if (this.IsCheck == false)
                    {
                        if (this.Save() == 1)
                        {
                            this.IsShowList = true;
                        }
                    }
                    else
                    {
                        if (this.SaveCheck() == 1)
                        {
                            this.IsShowList = true;
                        }
                    }

                    break;
                case "日    期":
                    if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.BeginTime, ref this.EndTime) == 0)
                        return;
                    break;
                case "未 审 核":
                    this.tvList.ShowInPlanList(this.privDept, "0");
                    this.IsShowList = true;
                    break;
                case "已 审 核":
                    this.tvList.ShowInPlanList(this.privDept, "2");
                    this.IsShowList = true;
                    break;
                case "显 示 栏":
                    this.IsShowLeftPanel = !this.IsShowLeftPanel;
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.IsCheck == false)
            {
                if (this.Save() == 1)
                {
                    this.IsShowList = true;
                }
            }
            else
            {
                if (this.SaveCheck() == 1)
                {
                    this.IsShowList = true;
                }
            }
            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel1);
            return 1;
        }

        /// <summary>
        /// 设置工具栏按钮状态
        /// </summary>
        /// <param name="isShowList">是否显示盘点单列表</param>
        protected void SetToolButton(bool isShowList)
        {
            this.toolBarService.SetToolButtonEnabled("计 划 单", !isShowList);
            this.toolBarService.SetToolButtonEnabled("新    建", isShowList);
            this.toolBarService.SetToolButtonEnabled("整单删除", isShowList);
            this.toolBarService.SetToolButtonEnabled("显 示 栏", !isShowList);
            this.toolBarService.SetToolButtonEnabled("警 戒 线", !isShowList);
            this.toolBarService.SetToolButtonEnabled("日 消 耗", !isShowList);
        }

        #endregion

        #region 数据表初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            #region 基本数据获取

            //获得科室名称
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList deptAll = deptManager.GetDeptmentAll();
            if (deptAll == null)
            {
                MessageBox.Show("获得在用科室列表出错！" + deptManager.Err);
                return;
            }
            this.deptHelper.ArrayObject = deptAll;
            //获得操作员姓名
            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList personAl = personManager.GetEmployeeAll();
            if (personAl == null)
            {
                MessageBox.Show("获取全部人员列表出错!" + personManager.Err);
                return;
            }
            this.personHelper.ArrayObject = personAl;
            //获取生产厂家
            Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
            ArrayList produceAl = company.QueryCompany("0", "A");
            if (produceAl == null)
            {
                MessageBox.Show("获取生产厂家列表出错!" + company.Err);
                return;
            }
            this.produceHelpter.ArrayObject = produceAl;

            #endregion
            //{AFE629CC-8493-4344-9792-8611C0BFA1BD}
            this.ucMaterialItemList1.ShowMaterialList(this.privDept.ID);
        }

        /// <summary>
        /// 数据表初始化
        /// </summary>
        private void InitDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dt.Columns.AddRange(new DataColumn[] {
														  new DataColumn("物品名称",	  dtStr),
														  new DataColumn("规格",        dtStr),
														  new DataColumn("计划购入价",  dtDec),
														  new DataColumn("计划数量",	  dtDec),
														  new DataColumn("单位",        dtStr),
														  new DataColumn("计划金额",	  dtDec),
														  new DataColumn("本科库存",	  dtDec),
														  new DataColumn("全院库存",	  dtDec),
														  new DataColumn("出库总量",	  dtDec),														  
														  new DataColumn("生产厂家",    dtStr),
														  new DataColumn("备注",        dtStr),
														  new DataColumn("物品编码",	  dtStr),
														  new DataColumn("拼音码",      dtStr),
														  new DataColumn("五笔码",      dtStr),
														  new DataColumn("自定义码",    dtStr),
														  new DataColumn("库存数量",dtStr),
                                                         //{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
                                                          new DataColumn("已购/未购",dtStr)
													  });

            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["物品编码"];
            this.dt.PrimaryKey = keys;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.SetFormat();
        }

        /// <summary>
        /// Fp格式化
        /// </summary>
        private void SetFormat()
        {
            this.numCellType.DecimalPlaces = 4;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].CellType = this.numCellType;

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradeName].Width = 120F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpecs].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanCost].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockNum].Width = 80F;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColItemNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColAllStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOutTotal].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOwnStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockNum].Visible = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].BackColor = System.Drawing.Color.SeaShell;
            // 已购/未购{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsBought].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsBought].Visible = true;
            this.SetColIsBoughtValue();
        }
        //设置已购/未购列的值 {4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
        private void SetColIsBoughtValue()
        {            
            ArrayList al = new ArrayList();
            al.Add(new Neusoft.FrameWork.Models.NeuObject("0", "未购", ""));
            al.Add(new Neusoft.FrameWork.Models.NeuObject("1", "已购", ""));

            this.neuSpread1.SetColumnList(this.neuSpread1_Sheet1, (int)ColumnSet.ColIsBought, al);
            this.neuSpread1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(neuSpread1_SetItem);
        }

        #endregion

        #region 列表初始化

        /// <summary>
        /// 入库单列表树组件
        /// </summary>
        private tvPlanList tvList = null;

        /// <summary>
        /// 入库单列表初始化
        /// </summary>
        protected void InitPlanList()
        {
            this.tvList = new tvPlanList();
            this.ucMaterialItemList1.TreeView = this.tvList;

            this.tvList.AfterSelect -= new TreeViewEventHandler(tvList_AfterSelect);
            this.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            this.tvList.DoubleClick -= new EventHandler(tvList_DoubleClick);
            this.tvList.DoubleClick += new EventHandler(tvList_DoubleClick);

            this.ucMaterialItemList1.Caption = "计划单列表";

            this.ShowPlanList();

            this.ucMaterialItemList1.ShowTreeView = true;
        }

        /// <summary>
        /// 入库单列表显示
        /// </summary>
        private void ShowPlanList()
        {
            this.Clear();

            this.tvList.ShowInPlanList(this.privDept, this.listState);
        }

        /// <summary>
        /// 申请信息显示
        /// </summary>
        /// <param name="flag">申请信息显示类型 1 显示申请明细信息 0 显示</param>
        public void ShowApplyInfo(bool isShowApplySum)
        {
            this.Clear();

            this.billType = BillTypeEnum.ApplyList;

            if (isShowApplySum)
            {
                this.tvList.Nodes.Clear();
                this.IsShowLeftPanel = false;
                ShowApplySumData(this.privDept.ID, this.BeginTime, this.EndTime);
            }
            else
            {
                this.tvList.ShowApplyList(this.privDept, this.BeginTime, this.EndTime);
                this.IsShowList = true;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="inPlan"></param>
        private int AddDataToTable(Neusoft.HISFC.Models.Material.InputPlan inPlan)
        {
            try
            {
                if (inPlan.PlanPrice == 0)
                {
                    inPlan.PlanPrice = inPlan.StoreBase.PriceCollection.RetailPrice;
                }

                decimal planCost = inPlan.PlanNum * inPlan.PlanPrice;
                if (this.produceHelpter != null)
                {
                    inPlan.Producer.Name = this.produceHelpter.GetName(inPlan.Producer.ID);
                }

                #region 取本科库存 X（大包装）X（小包装）eg:1包4支
                string strStoreSum = (Math.Floor(inPlan.StoreSum / inPlan.StoreBase.Item.PackQty)).ToString() + inPlan.StoreBase.Item.PackUnit;
                decimal reQty = Math.Ceiling(inPlan.StoreSum % inPlan.StoreBase.Item.PackQty);
                if (reQty > 0)
                {
                    strStoreSum = strStoreSum + reQty.ToString() + inPlan.StoreBase.Item.MinUnit;
                }
                #endregion

                this.dt.Rows.Add(new object[] { 
												  inPlan.StoreBase.Item.Name,                           //物品名称
												  inPlan.StoreBase.Item.Specs,                          //规格
												  inPlan.PlanPrice,										//计划购入价
												  inPlan.PlanNum,                                       //计划数量
												  inPlan.StoreBase.Item.PackUnit,                       //单位
												  planCost,												//计划金额  
												  inPlan.StoreSum / inPlan.StoreBase.Item.PackQty,      //本科库存
												  inPlan.StoreTotsum / inPlan.StoreBase.Item.PackQty,   //全院库存
												  inPlan.OutputSum / inPlan.StoreBase.Item.PackQty,     //出库总量												  
												  inPlan.Producer.Name,									//生产厂家
												  inPlan.Memo,											//备注
												  inPlan.StoreBase.Item.ID,                             //物品编码
												  inPlan.StoreBase.Item.SpellCode,						//拼音码
												  inPlan.StoreBase.Item.WbCode,			            	//五笔码
												  inPlan.StoreBase.Item.UserCode,						//自定义码
												  strStoreSum ,                                         //取本科库存 X（大包装）X（小包装）eg:1包4支
                                                  inPlan.Extend1                                        //已购未购//{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
											  });
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + e.Message);

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + ex.Message);

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 清空入库计划物品信息
        /// </summary>
        /// <returns>成功添加返回1 失败返回－1</returns>
        public void Clear()
        {
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();

            this.hsPlanData.Clear();

            this.lbPlanBill.Text = "单据号:";
            this.lbPlanInfo.Text = "计划科室 计划人";

            this.txtFilter.Text = "";
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns> </returns>
        private bool IsValid()
        {
            if (this.isJudgeValid)
            {
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["计划数量"]) < 0)
                    {
                        MessageBox.Show("请正确输入 " + dr["物品名称"].ToString() + " 计划数量");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        /// <param name="isFpFocus"></param>
        public void SetFocus(bool isFpFocus)
        {
            if (isFpFocus)
            {
                this.neuSpread1.Select();
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColPlanNum;
            }
            else
            {
                this.ucMaterialItemList1.Select();
                this.ucMaterialItemList1.SetFocusSelect();
            }
        }

        /// <summary>
        /// 新增加一张入库计划单
        /// </summary>
        public void New()
        {
            //在树型列表中插入新节点
            TreeNode node = new TreeNode();
            node.Text = "新建入库计划单";
            node.ImageIndex = 4;
            node.SelectedImageIndex = 4;
            node.Tag = new Neusoft.HISFC.Models.Material.InputPlan();

            this.tvList.Nodes[0].Nodes.Insert(0, node);

            //选中此新节点
            this.tvList.SelectedNode = node;

            //切换到物品数据列表
            this.IsShowList = false;

            this.ucMaterialItemList1.SetFocusSelect();
            this.SetPlanInfo();
        }

        /// <summary>
        /// 将物品实体添加
        /// </summary>
        /// <param name="item">物品实体</param>
        /// <param name="totOutQty">出库总量</param>
        /// <param name="averageOutQty">日均出库</param>
        /// <param name="planQty">根据警戒线自动生成的计划出库量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Material.MaterialItem item, decimal totOutQty, decimal averageOutQty, decimal planQty)
        {
            if (this.hsPlanData.ContainsKey(item.ID))
            {
                MessageBox.Show("该物品已添加到计划单内 同一品种物品不能重复添加");
                return 0;
            }

            Neusoft.HISFC.Models.Material.InputPlan inPlan = new Neusoft.HISFC.Models.Material.InputPlan();

            #region 获取本科室库存

            decimal itemQty;
            if (this.storeManager.GetStoreQty(this.privDept.ID, item.ID, out itemQty) == -1)
            {
                MessageBox.Show("获取" + this.privDept.Name + "科室物品库存失败");
                return -1;
            }
            inPlan.StoreSum = itemQty;

            #endregion

            #region 获取全院库存

            decimal itemTotQty;
            if (this.storeManager.GetStoreTotQty(item.ID, out itemTotQty) == -1)
            {
                MessageBox.Show("获取全院物品库存失败");
                return -1;
            }
            inPlan.StoreTotsum = itemTotQty;

            #endregion

            inPlan.StoreBase.Item = item;
            //inPlan.StoreTotsum = totOutQty;

            inPlan.PlanNum = planQty;
            inPlan.PlanPrice = inPlan.StoreBase.Item.PackPrice;

            inPlan.StorageCode = this.privDept.ID;
            inPlan.Company = inPlan.StoreBase.Item.Company;
            inPlan.Producer = inPlan.StoreBase.Item.Factory;

            if (this.AddDataToTable(inPlan) == 1)
            {
                this.hsPlanData.Add(inPlan.StoreBase.Item.ID, inPlan);
            }

            this.SetSum();

            return 1;
        }

        /// <summary>
        /// 将物品实体添加
        /// </summary>
        /// <param name="item">物品实体</param>
        /// <param name="planQty">按警戒线自动生成的计划出库量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Material.MaterialItem item, decimal planQty)
        {
            return this.AddDrugData(item, 0, 0, planQty);
        }

        /// <summary>
        /// 将物品实体添加
        /// </summary>
        /// <param name="item">物品实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Material.MaterialItem item)
        {

            return this.AddDrugData(item, 0, 0, 0);
        }

        ///<summary>
        ///根据物品警戒线加入数据
        ///</summary>
        ///<param name="alterFlag">生成方式 0 警戒线 1 日消耗</param>
        ///<returns>成功返回0，失败返回－1</returns>
        public void AddAlterData(string alterFlag)
        {
            this.IsShowLeftPanel = false;//liuxq add不显示左边列表

            #region 暂时屏掉根据警戒线生成计划单代码，日后根据实际需求在增加。lichao；已增加 gengxl
            if (this.dt.Rows.Count > 0)
            {
                DialogResult result;
                result = MessageBox.Show("按警戒线生成将清除当前入库计划单内容，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                if (result == DialogResult.No)
                    return;
            }

            //数据清空
            this.Clear();

            try
            {
                ArrayList alDetail = new ArrayList();

                if (alterFlag == "1")//日消耗
                {
                    #region 弹出窗口 设置日消耗参数 计算需申请信息
                    using (ucPhaAlter uc = new ucPhaAlter())
                    {
                        uc.DeptCode = this.privDept.ID;
                        uc.SetData();
                        uc.Focus();
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                        if (uc.ApplyInfo != null)
                        {
                            alDetail = uc.ApplyInfo;
                        }
                    }
                    #endregion
                }
                else//警戒线
                {
                    ///---liuxq----暂时屏蔽，找到后在放开////
                    //					alDetail = this.itemManager.FindByAlter("0", this.privDept.ID, System.DateTime.MinValue, System.DateTime.MaxValue);
                    //					if (alDetail == null)
                    //					{
                    //						MessageBox.Show("按照数量警戒线执行信息计算未正确执行\n" + this.itemManager.Err);
                    //						return;
                    //					}
                    ArrayList al = this.storeManager.FindByAlter("0", this.privDept.ID, DateTime.Now, DateTime.Now, 0, 0);
                    if (al != null)
                    {
                        alDetail = al;
                    }
                }

                if (alDetail.Count == 0)
                {
                    MessageBox.Show("无满足条件的物品计划信息");
                    return;
                }

                Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();

                foreach (Neusoft.FrameWork.Models.NeuObject temp in alDetail)
                {
                    item = this.itemManager.GetMetItemByMetID(temp.ID);
                    if (item == null)
                    {
                        MessageBox.Show("读取物品基本信息失败！[" + temp.Name + "]物品不存在!");
                        continue;
                    }

                    if (alterFlag == "1")
                        this.AddDrugData(item, NConvert.ToDecimal(temp.User01), NConvert.ToDecimal(temp.User02), NConvert.ToDecimal(temp.User03));
                    else
                        this.AddDrugData(item, NConvert.ToDecimal(temp.User03));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            this.SetPlanInfo();
        }

        /// <summary>
        /// 模版数据显示
        /// </summary>
        public void AddStencilData()
        {
            #region 暂时屏掉此功能，待时间充裕时完善。lichao
            /*DialogResult rs = MessageBox.Show("根据模版生成计划信息将清除当前显示的数据 是否继续?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (rs == DialogResult.No)
				return;

			this.Clear();

			ArrayList alOpenDetail = Function.ChooseDrugStencil(this.privDept.ID,Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil.Plan);

			if (alOpenDetail != null && alOpenDetail.Count > 0)
			{             
				Neusoft.FrameWork.WinForms.Classes.Function .ShowWaitForm("正在根据所选模生成计划信息...");
				Application.DoEvents();
				//先加载库存信息的Hs 保证模版调用顺序
				System.Collections.Hashtable hsStoreDrug = new Hashtable();

				ArrayList alItem = this.itemManager.QueryItemAvailableList(false);
				foreach (Neusoft.HISFC.Models.Material.MaterialItem item in alItem)
				{
					hsStoreDrug.Add(item.ID, item);
				}

				int i = 0;
				foreach (Neusoft.HISFC.Models.Material.MaterialItem info in alOpenDetail)
				{
					Neusoft.FrameWork.WinForms.Classes.Function .ShowWaitForm(i, alOpenDetail.Count);
					Application.DoEvents();

					if (hsStoreDrug.Contains(info.Item.ID))
					{
						this.AddDrugData(hsStoreDrug[info.Item.ID] as Neusoft.HISFC.Models.Pharmacy.Item);
					}

					i++;
				}

				Neusoft.FrameWork.WinForms.Classes.Function .HideWaitForm();

				this.SetFocus(true);
			}*/
            #endregion
        }

        /// <summary>
        /// 根据入库计划单号 获取入库计划数据
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="billNO">单据号</param>
        public int ShowPlanData(string privDept, string billNO)
        {
            //清空数据。
            this.Clear();

            //取入库计划中的数据
            ArrayList alDetail = this.planManager.QueryInPlanDetail(privDept, billNO);
            if (alDetail == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示计划明细 请稍候...");
            Application.DoEvents();

            foreach (Neusoft.HISFC.Models.Material.InputPlan info in alDetail)
            {
                //对已做完采购计划的数据不显示 
                //if (info.State != "0" && info.State != "2")
                //    continue;
                if (info.State != this.listState)
                {
                    continue;
                }

                info.StoreBase.Item = this.itemManager.GetMetItemByMetID(info.StoreBase.Item.ID);
                if (info.StoreBase.Item == null)
                {
                    Function.ShowMsg("获取新物品信息发生错误 \n" + info.StoreBase.Item.Name);
                    return -1;
                }

                this.SetPlanInfo(info);

                if (this.AddDataToTable(info) == 1)
                {
                    this.hsPlanData.Add(info.StoreBase.Item.ID, info);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetSum();

            return 1;
        }

        #region 根据科室申请情况生成入库计划

        /// <summary>
        /// 根据各科室申请汇总生成入库计划
        /// </summary>
        /// <param name="privDept">库存科室</param>
        /// <returns></returns>
        public int ShowApplySumData(string privDept, DateTime dateBegin, DateTime dateEnd)
        {
            //清空数据。
            this.Clear();

            //取入库计划中的数据{CDAF22EE-1D2F-44a1-BA62-169E28A421A4}
            //----------------------------------------------------targetdept-currentdept-priv-extend1-inclass-
            //extend1："0"申请状态 "1"入库计划 "2" 部分审批 "3" 全部审批
            ArrayList alList = this.storeManager.QueryApplyListByDept("A", privDept, "0510", "0", "13");
                //this.storeManager.QueryApplySumForPlan(privDept, dateBegin, dateEnd);
            if (alList == null)
            {
                MessageBox.Show(this.storeManager.Err);
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示计划明细 请稍候...");
            Application.DoEvents();
            //重新写了申请单选择的控件 by yuyun 08-7-28 {285D96FA-06E5-4123-87F3-996674851B87}
            Neusoft.HISFC.Components.Material.Base.ucApplyLists ucLists = new Neusoft.HISFC.Components.Material.Base.ucApplyLists();
            ucLists.Init(alList);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            Control c = ucLists as Control;
            c.Text = "申请单列表";
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(c);
            
            string listNO = string.Empty;
            string storageDept = string.Empty;

            if (ucLists.ListApply.Count>0)
            {
                foreach (ArrayList al in ucLists.ListApply)
                {
                    listNO += "'" + al[1].ToString() + "',";
                    storageDept += "'" + al[3].ToString() + "',";
                }
            }
            if (listNO.Length <= 0 && storageDept.Length <= 0)
            {                
                return -1;
            }
            listNO = listNO.Substring(0, listNO.Length - 1);
            storageDept = storageDept.Substring(0, storageDept.Length - 1);

            ArrayList alDetail = new ArrayList();
            alDetail = this.storeManager.QueryApplySumForPlan(privDept, storageDept, listNO);

            if (alDetail == null)
            {
                MessageBox.Show(this.storeManager.Err);

                return -1;
            }
            //-------------
            foreach (Neusoft.HISFC.Models.Material.Apply info in alDetail)
            {
                Neusoft.HISFC.Models.Material.InputPlan inPlan = new Neusoft.HISFC.Models.Material.InputPlan();
                Neusoft.HISFC.Models.Material.MaterialItem item = new Neusoft.HISFC.Models.Material.MaterialItem();
                Neusoft.HISFC.BizLogic.Material.Store myStore = new Neusoft.HISFC.BizLogic.Material.Store();

                item = this.itemManager.GetMetItemByMetID(info.Item.ID);
                int i = 0;
                decimal itemSum = 0;
                i = myStore.GetStoreQty(this.privDept.ID, info.Item.ID, out itemSum);
                inPlan.StoreBase.Item = item;

                inPlan.StoreSum = itemSum;

                #region 获取全院库存

                decimal itemTotQty;
                if (this.storeManager.GetStoreTotQty(item.ID, out itemTotQty) == -1)
                {
                    MessageBox.Show("获取全院物品库存失败");
                    return -1;
                }
                inPlan.StoreTotsum = itemTotQty;

                #endregion
                //计划数量 = 申请数量 / 包装数量{5499029C-B6EF-4015-A855-15DC67BD9E14}
                inPlan.PlanNum = info.Operation.ApplyQty / inPlan.StoreBase.Item.PackQty;

                //inPlan.PlanPrice = inPlan.StoreBase.Item.UnitPrice;
                inPlan.PlanPrice = inPlan.StoreBase.Item.PackPrice;
                inPlan.StorageCode = this.privDept.ID;
                inPlan.Company = inPlan.StoreBase.Item.Company;
                inPlan.Producer = inPlan.StoreBase.Item.Factory;

                if (this.AddDataToTable(inPlan) == 1)
                {
                    this.hsPlanData.Add(inPlan.StoreBase.Item.ID, inPlan);
                }
            }
            this.neuSpread1_Sheet1.Tag = alDetail;
            //将申请单号和申请科室存起来以便以后更新申请状态{CDAF22EE-1D2F-44a1-BA62-169E28A421A4}
            this.neuSpread1_Sheet1.Columns[0].Tag = listNO;
            this.neuSpread1_Sheet1.Columns[1].Tag = storageDept;            

            this.SetSum();

            return 1;
        }

        /// <summary>
        /// 根据申请单号形成计划信息
        /// </summary>
        /// <param name="privDept"></param>
        /// <param name="billNO"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public int ShowApplySingleData(string privDept, string billNO, DateTime dateBegin, DateTime dateEnd)
        {
            //清空数据。
            this.Clear();

            //取入库计划中的数据
            ArrayList alDetail = this.storeManager.QueryApplyDetailForPlan(privDept, billNO, "0", dateBegin, dateEnd);
            if (alDetail == null)
            {
                MessageBox.Show(this.storeManager.Err);
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示计划明细 请稍候...");
            Application.DoEvents();

            Neusoft.HISFC.Models.Material.InputPlan inPlan = new Neusoft.HISFC.Models.Material.InputPlan();

            foreach (Neusoft.HISFC.Models.Material.Apply info in alDetail)
            {
                inPlan.StoreBase.Item = this.itemManager.GetMetItemByMetID(info.Item.ID);
                Neusoft.HISFC.BizLogic.Material.Store myStore = new Neusoft.HISFC.BizLogic.Material.Store();

                int i = 0;
                decimal itemSum = 0;
                i = myStore.GetStoreQty(this.privDept.ID, info.Item.ID, out itemSum);

                inPlan.StoreSum = itemSum;

                inPlan.PlanNum = info.Operation.ApplyQty;
                //inPlan.PlanPrice = inPlan.StoreBase.Item.UnitPrice;
                inPlan.PlanPrice = inPlan.StoreBase.Item.PackPrice;
                inPlan.StorageCode = this.privDept.ID;
                inPlan.Company = inPlan.StoreBase.Item.Company;
                inPlan.Producer = inPlan.StoreBase.Item.Factory;

                #region 获取全院库存
                decimal itemTotQty;
                if (this.storeManager.GetStoreTotQty(info.Item.ID, out itemTotQty) == -1)
                {
                    MessageBox.Show("获取全院物品库存失败");
                    return -1;
                }
                inPlan.StoreTotsum = itemTotQty;
                #endregion

                if (this.AddDataToTable(inPlan) == 1)
                {
                    this.hsPlanData.Add(inPlan.StoreBase.Item.ID, inPlan);
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetSum();

            return 1;
        }

        /// <summary>
        /// 装载申请数据
        /// </summary>
        /// <returns>返回DataTable</returns>
        public void InitApplyData()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            this.dt = new DataTable();

            this.dt.Columns.AddRange(
                new System.Data.DataColumn[] {
												 new DataColumn("物品名称",  dtStr),
												 new DataColumn("规格",      dtStr),
												 new DataColumn("单价",    dtDec),
												 new DataColumn("单位",  dtStr),
												 new DataColumn("申请数量",  dtDec),
												 new DataColumn("申请金额",  dtDec),
												 new DataColumn("备注",      dtStr),
												 new DataColumn("物品编码",  dtStr),
												 new DataColumn("序号",    dtStr),												
												 new DataColumn("拼音码",    dtStr),
												 new DataColumn("五笔码",    dtStr),
												 new DataColumn("自定义码",  dtStr),
												 new DataColumn("库存数量",  dtDec)
												 
											 }
                );

            DataColumn[] keys = new DataColumn[1];

            keys[0] = this.dt.Columns["物品编码"];

            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.SetApplyFormat();
        }


        /// <summary>
        /// 根据申请单信息向DataTable内增加数据
        /// </summary>
        /// <param name="apply">申请信息</param>
        /// <returns></returns>
        protected virtual int AddApplyToTable(Neusoft.HISFC.Models.Material.Apply apply)
        {
            if (this.dt == null)
            {
                this.InitApplyData();
            }

            try
            {
                Neusoft.HISFC.BizLogic.Material.MetItem managerItem = new Neusoft.HISFC.BizLogic.Material.MetItem();
                apply.Item = managerItem.GetMetItemByMetID(apply.Item.ID);

                decimal price = 0;
                decimal qty = 0;
                decimal cost = 0;
                string unit = "";

                if (this.isMinUnit)
                {
                    qty = apply.Operation.ApplyQty;
                    cost = apply.Operation.ApplyQty * apply.Item.UnitPrice;
                    unit = apply.Item.MinUnit;
                    price = apply.Item.UnitPrice;
                }
                else
                {
                    qty = apply.Operation.ApplyQty / apply.Item.PackQty;
                    cost = apply.Operation.ApplyQty / apply.Item.PackQty * apply.Item.PackPrice;
                    unit = apply.Item.PackUnit;
                    price = apply.Item.PackPrice;
                }
                this.dt.Rows.Add(new object[] { 
												  apply.Item.Name,                                //商品名称
												  apply.Item.Specs,                               //规格
												  price,					                      //零售价
												  unit,											  //包装单位
												  qty,											  //申请数量
												  cost,                                           //申请金额
												  apply.Memo,                                     //备注
												  apply.Item.ID,                                  //物品编码
												  apply.SerialNO,                                 //序号												 
												  apply.Item.SpellCode,                          //拼音码
												  apply.Item.WbCode,                             //五笔码
												  apply.Item.UserCode                            //自定义码                            
											  }
                    );

                this.dt.DefaultView.AllowDelete = true;
                this.dt.DefaultView.AllowEdit = true;
                this.dt.DefaultView.AllowNew = true;
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + e.Message);

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("DataTable内赋值发生错误" + ex.Message);

                return -1;
            }

            return 1;
        }


        /// <summary>
        /// 根据申请单号 获取申请数据
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="billNO">单据号</param>
        public int ShowApplyData(string privDept, string billNO, DateTime dateBegin, DateTime dateEnd)
        {
            //清空数据。
            this.Clear();

            //取入库计划中的数据
            ArrayList alDetail = this.storeManager.QueryApplyDetailForPlan(privDept, billNO, "0", dateBegin, dateEnd);
            if (alDetail == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示计划明细 请稍候...");
            Application.DoEvents();

            foreach (Neusoft.HISFC.Models.Material.Apply info in alDetail)
            {
                if (this.AddApplyToTable(info) == -1)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.SetSum();

            return 1;
        }


        /// <summary>
        /// 格式化Fp显示
        /// </summary>
        public virtual void SetApplyFormat()
        {
            if (this.neuSpread1_Sheet1 == null)
                return;

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColItemName].Width = 150F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColSpecs].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColRetailPrice].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColPackUnit].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColApplyQty].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColApplyCost].Width = 100F;

            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColItemID].Visible = false;           //物品编码
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColNO].Visible = false;               //序号
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColDataSource].Visible = false;       //数据来源
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColSpellCode].Visible = false;        //拼音码
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColWBCode].Visible = false;           //五笔码
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColUserCode].Visible = false;         //自定义码

            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColMemo].Width = 200F;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColMemo].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColApplyQty].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ApplyColumnSet.ColApplyQty].BackColor = System.Drawing.Color.SeaShell;
        }


        /// <summary>
        /// 列设置
        /// </summary>
        private enum ApplyColumnSet
        {
            /// <summary>
            /// 物品名称
            /// </summary>
            ColItemName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 单价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 单位
            /// </summary>
            ColPackUnit,
            /// <summary>
            /// 申请数量
            /// </summary>
            ColApplyQty,
            /// <summary>
            /// 申请金额
            /// </summary>
            ColApplyCost,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 项目编码
            /// </summary>
            ColItemID,
            /// <summary>
            /// 序号
            /// </summary>
            ColNO,
            /// <summary>
            /// 数据来源
            /// </summary>
            ColDataSource,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode
        }

        #endregion

        /// <summary>
        /// 设置计划信息显示
        /// </summary>
        /// <param name="inPlan"></param>
        private void SetPlanInfo(Neusoft.HISFC.Models.Material.InputPlan inPlan)
        {
            this.lbPlanBill.Text = "单据号:" + inPlan.PlanListCode;

            this.lbPlanInfo.Text = "计划科室: " + this.privDept.Name + " 计划人: " + inPlan.StoreBase.Operation.ApplyOper.ID;
        }
        private void SetPlanInfo()
        {
            this.lbPlanInfo.Text = "计划科室: " + this.privDept.Name + " 计划人: " + FrameWork.Management.Connection.Operator.Name;
        }

        /// <summary>
        /// 计划总金额计算
        /// </summary>
        private void SetSum()
        {
            decimal totCost = 0;

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                totCost += NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColPlanCost].Text);
            }

            this.lbCost.Text = "计划总金额:" + totCost.ToString("N");
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteData()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 1)
            {
                MessageBox.Show("计划单内只有一条物品记录 请选择整单删除方式进行操作");
                return;
            }
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
                return;

            this.neuSpread1.StopCellEditing();

            string drugNO = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColItemNO].Text;
            if (this.hsPlanData.ContainsKey(drugNO))
            {
                this.hsPlanData.Remove(drugNO);
            }

            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);

            this.neuSpread1.StartCellEditing(null, false);
        }

        /// <summary>
        /// 对入库计划单进行整单删除
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="billCode">入库计划单号</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int DeleteDataByBill(string deptCode, string billCode)
        {
            if (this.nowBillNO == "")
                return 0;

            DialogResult result;
            //提示用户是否确认删除
            result = MessageBox.Show("确认删除【" + this.nowBillNO + "】计划单吗？\n 此操作无法撤销", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                int parm = this.planManager.DeleteInputPlan(deptCode, billCode);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.planManager.Err);
                    return -1;
                }
                else
                    if (parm != this.dt.Rows.Count)
                    { //处理并发
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("数据发生变动，请刷新窗口");
                        return -1;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.tvList.ShowInPlanList(this.privDept, "0");

            return 1;
        }

        /// <summary>
        /// 保存入库计划单- 新建
        /// </summary>
        public int Save()
        {
            if (this.dt.Rows.Count <= 0)
                return -1;
            if (!this.IsValid())
                return -1;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存 请稍候...");
            Application.DoEvents();

            //系统时间
            DateTime sysTime = this.planManager.GetDateTimeFromSysDateTime();

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 如果是修改的入库计划单，则先删除原入库计划单数据

            if (this.nowBillNO != null && this.nowBillNO != "")
            {
                ArrayList alCount = this.planManager.QueryInPlanDetail(this.privDept.ID, this.nowBillNO);

                //删除未采购审核的计划信息
                int parm = this.planManager.DeleteInputPlan(this.privDept.ID, this.nowBillNO);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(this.itemManager.Err);
                    return -1;
                }
                else if (parm < alCount.Count)
                { //处理并发
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("计划单可能已通过采购审核，请刷新窗口");
                    return -1;
                }
            }
            else
            {
                //如果是新增加的入库计划单，则取入库计划单号
                this.nowBillNO = this.planManager.GetPlanNO(this.privDept.ID);
                //入库计划单号的操作
                if (this.nowBillNO == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("获取新计划单号出错" + this.itemManager.Err);
                    return -1;
                }
            }

            #endregion

            int iCount = 1;

            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(iCount, this.dt.Rows.Count);
                Application.DoEvents();

                #region 入库计划赋值 保存

                //对计划数量为0的不进行处理
                if (NConvert.ToDecimal(dr["计划数量"]) == 0)
                    continue;

                Neusoft.HISFC.Models.Material.InputPlan inPlan = this.hsPlanData[dr["物品编码"].ToString()] as Neusoft.HISFC.Models.Material.InputPlan;

                inPlan.PlanListCode = this.nowBillNO;               //计划单号
                inPlan.PlanNo = iCount;
                //窗口参数控制入库计划单是否需要审核  
                //switch (inplanExamTimes)
                //{
                //    case 0:
                //        inPlan.State = "M";
                //        break;
                //    case 1:
                //        inPlan.State = "F";
                //        break;
                //    case 2:
                //        inPlan.State = "0";
                //        break;
                //    default:
                //        inPlan.State = "0";
                //        break;
                //}                                
                //单据状态
                inPlan.State = this.saveState;
                inPlan.PlanType = this.planType;                    //采购类型

                inPlan.PlanNum = NConvert.ToDecimal(dr["计划数量"]); //* inPlan.StoreBase.Item.PackQty;//计划数量 - 存储手填的数，即大包装数量，为了方便计算计划金额
                inPlan.PlanCost = NConvert.ToDecimal(dr["计划数量"]) * inPlan.PlanPrice;
                inPlan.StoreBase.Operation.ApplyOper.ID = this.planManager.Operator.ID;
                inPlan.StoreBase.Operation.ApplyOper.OperTime = sysTime;                 //操作信息

                inPlan.StoreBase.Operation.Oper = inPlan.StoreBase.Operation.ApplyOper;
                inPlan.Memo = dr["备注"].ToString();                //备注
                inPlan.Producer = inPlan.StoreBase.Item.Factory;
                ////{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
                inPlan.Extend1 = dr["已购/未购"].ToString();
                if (this.planManager.InsertInputPlan(inPlan) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.StoreBase.Item.Name + "保存失败 " + this.planManager.Err);

                    return -1;
                }


                #endregion

                iCount++;
            }
            //{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
            #region 对应申请单的extend1更新成"1" 将已做入库计划的申请单和普通申请单区分开
            string listNO = string.Empty;
            string storageDept = string.Empty;

            if (this.neuSpread1_Sheet1.Columns[0].Tag != null && this.neuSpread1_Sheet1.Columns[1].Tag != null)
            {
                listNO = this.neuSpread1_Sheet1.Columns[0].Tag.ToString();
                storageDept = this.neuSpread1_Sheet1.Columns[1].Tag.ToString();

                if (!string.IsNullOrEmpty(listNO) && !string.IsNullOrEmpty(storageDept))
                {
                    if (this.storeManager.UpdateApplyListState(listNO, storageDept, privDept.ID, "1") == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("更新申请单状态失败 " + this.storeManager.Err);

                        return -1;
                    }
                } 
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");
            //清空数据
            this.Clear();

            this.tvList.ShowInPlanList(this.privDept, "0");            

            return 1;
        }

        /// <summary>
        /// 保存入库计划单-审核
        /// </summary>
        public int SaveCheck()
        {
            if (this.dt.Rows.Count <= 0)
                return -1;
            if (!this.IsValid())
                return -1;

            dt.AcceptChanges();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存 请稍候...");
            Application.DoEvents();

            //系统时间
            DateTime sysTime = this.planManager.GetDateTimeFromSysDateTime();

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int iCount = 1;
            string saveState = "2";//单据状态

            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(iCount, this.dt.Rows.Count);
                Application.DoEvents();

                #region 入库计划赋值 保存

                //对计划数量为0的不进行处理
                if (NConvert.ToDecimal(dr["计划数量"]) == 0)
                    continue;

                Neusoft.HISFC.Models.Material.InputPlan inPlan = this.hsPlanData[dr["物品编码"].ToString()] as Neusoft.HISFC.Models.Material.InputPlan;

                inPlan.PlanListCode = this.nowBillNO;               //计划单号

                if (this.IsFinance == false)						//计划单状态判断 1:需要经过财务审核 2:不需要经过财务审核 
                {
                    saveState = "2";
                    inPlan.State = "2";
                }
                else
                {
                    saveState = "1";
                    inPlan.State = "1";
                }

                saveState = this.saveState;
                inPlan.State = this.saveState;

                inPlan.PlanType = this.planType;                    //采购类型

                inPlan.PlanNum = NConvert.ToDecimal(dr["计划数量"]);// * inPlan.StoreBase.Item.PackQty;//计划数量- 存储手填的数，即大包装数量，为了方便计算计划金额
                inPlan.PlanCost = NConvert.ToDecimal(dr["计划数量"]) * inPlan.PlanPrice;

                inPlan.StoreBase.Operation.ApplyOper.ID = this.planManager.Operator.ID;
                inPlan.StoreBase.Operation.ApplyOper.OperTime = sysTime;                 //操作信息

                inPlan.StoreBase.Operation.Oper = inPlan.StoreBase.Operation.ApplyOper;
                inPlan.Memo = dr["备注"].ToString();                //备注

                if (this.planManager.UpdateInputPlan(inPlan) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.StoreBase.Item.Name + "更新入库计划失败 " + this.planManager.Err);
                    return -1;
                }

                if (this.planManager.UpdateInPlanState(inPlan.StorageCode, inPlan.PlanListCode, inPlan.PlanNo, saveState, inPlan.StoreBase.Operation.ApplyOper.ID, sysTime) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.StoreBase.Item.Name + "保存失败 " + this.planManager.Err);
                    return -1;
                }

                #endregion

                iCount++;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");
            //清空数据
            this.Clear();
            //{5A17420D-209C-4862-80BE-97CE0D539C50}
            //this.tvList.ShowInPlanList(this.privDept, "0");
            this.tvList.ShowInPlanList(this.privDept, this.listState);
            return 1;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <returns></returns>
        public void Filter()
        {
            if (this.dt.DefaultView == null)
                return;

            //获得过滤条件
            string queryCode = "%" + this.txtFilter.Text.Trim() + "%";

            try
            {
                this.dt.DefaultView.RowFilter = Function.GetFilterStr(this.dt.DefaultView, queryCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 导出数据为Excel格式
        /// </summary>
        private void ExportInfo()
        {
            try
            {
                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel (*.xls)|*.*";
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 将当前查询内容按Excel格式导出
        /// </summary>
        public void Export()
        {
            this.ExportInfo();
        }

        private void GetDetail(string deptcode, DateTime dtbegin, DateTime dtend, string itemcode)
        {
            DataSet myDataSet = new DataSet();

            try
            {
                Neusoft.HISFC.BizLogic.Manager.Report reportMgr = new Neusoft.HISFC.BizLogic.Manager.Report();
                int parm = reportMgr.ExecQuery("Material.Store.GetApplySumForPlanDetail", ref myDataSet,
                    deptcode, dtbegin.ToString("yyyy-MM-dd HH:mm:ss"), dtend.ToString("yyyy-MM-dd HH:mm:ss"),
                    itemcode);
                if (parm == -1)
                {
                    MessageBox.Show("查询明细失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //格式配置文件地址

            //对farpoint绑定数据源
            DataView myDataView = new DataView(myDataSet.Tables[0]);
            this.neuSpread1_Sheet2.DataSource = myDataView;
            this.neuSpread1_Sheet2.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.GrayAreaBackColor = System.Drawing.Color.White;
        }

        #endregion

        #region 事件

        private void ucInPlan_Load(object sender, System.EventArgs e)
        {
            this.InitDataTable();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0511", ref testPrivDept);

                //if (parma == -1)            //无权限
                //{
                //    MessageBox.Show("您无此窗口操作权限");
                //    return;
                //}
                //else if (parma == 0)       //用户选择取消
                //{
                //    return;
                //}

                //this.privDept = testPrivDept;

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                this.InitData();

                this.InitPlanList();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.FrameWork.Models.NeuObject inPlanObj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.nowBillNO = inPlanObj.ID;

                if (this.billType == BillTypeEnum.PlanList)
                {
                    this.ShowPlanData(this.privDept.ID, inPlanObj.ID);
                }
                else
                {
                    this.ShowApplySingleData(this.privDept.ID, inPlanObj.ID, this.BeginTime, this.EndTime);
                    if (inPlanObj.ID == null)
                    {
                        this.ShowApplySumData(this.privDept.ID, this.BeginTime, this.EndTime);
                    }
                }
            }
        }

        private void tvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.tvList.SelectedNode != null && this.tvList.SelectedNode.Parent != null)
            {
                Neusoft.FrameWork.Models.NeuObject inPlanObj = this.tvList.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.nowBillNO = inPlanObj.ID;

                if (inPlanObj.Memo == "0")
                {
                    this.IsShowList = false;
                }
            }
        }

        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            this.Filter();
        }

        private void txtFilter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.SetFocus(true);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus && keyData == Keys.Enter)
            {
                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColPlanNum)
                {
                    decimal planQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPlanNum].Text);
                    decimal planPrice = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPurchasePrice].Text);

                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPlanCost].Value = planQty * planPrice;

                    this.SetSum();
                }

                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColPlanNum)
                {
                    if (this.neuSpread1_Sheet1.ActiveRowIndex < this.neuSpread1_Sheet1.Rows.Count - 1)
                    {
                        this.neuSpread1_Sheet1.ActiveRowIndex++;
                    }
                    else
                    {
                        if (this.IsShowList)
                        {
                            this.txtFilter.Select();
                            this.txtFilter.SelectAll();
                        }
                        else
                        {
                            this.SetFocus(false);
                        }
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ucMaterialItemList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            //-----by yuyun 08-7-26{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            //string itemCode = sv.Cells[activeRow, 0].Text;
            string itemCode = sv.Cells[activeRow, 10].Text;

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(itemCode);
            if (item == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return;
            }

            if (this.AddDrugData(item) == 1)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.SetFocus(true);
            }
        }

        private void neuSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == (int)ColumnSet.ColPlanNum)
            {
                decimal planQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPlanNum].Text);
                decimal planPrice = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPurchasePrice].Text);

                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPlanCost].Value = planQty * planPrice;

                this.SetSum();
            }
        }
        //{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
        private int neuSpread1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.neuSpread1_Sheet1.ActiveColumnIndex].Text = obj.Name;
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.neuSpread1_Sheet1.ActiveColumnIndex].Tag = obj.ID;
            return 0;
        }
        #endregion

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //if (this.neuSpread1.ActiveSheet.SheetName == "汇总")
            //{
            //    this.GetDetail(this.privDept.ID, this.BeginTime, this.EndTime, this.neuSpread1_Sheet1.Cells[e.Row, 11].Text);
            //}
            //this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
        }

        #region 枚举

        /// <summary>
        /// 窗口功能
        /// </summary>
        public enum EnumWindowFunInPlan
        {
            入库计划,
            入库计划审核
        }

        #endregion

        #region IPreArrange 成员

        public int PreArrange()
        {
            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0511", ref testPrivDept);

            if (parma == -1)            //无权限
            {
                MessageBox.Show("您无此窗口操作权限");
                return -1;
            }
            else if (parma == 0)       //用户选择取消
            {
                return -1;
            }

            this.privDept = testPrivDept;
            return 1;
        }

        #endregion

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 物品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格  
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 计划购入价  
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 计划数量  
            /// </summary>
            ColPlanNum,
            /// <summary>
            /// 单位  
            /// </summary>
            ColUnit,
            /// <summary>
            /// 计划金额  
            /// </summary>
            ColPlanCost,
            /// <summary>
            /// 本科库存  
            /// </summary>
            ColOwnStockNum,
            /// <summary>
            /// 全院库存  
            /// </summary>
            ColAllStockNum,
            /// <summary>
            /// 出库总量
            /// </summary>
            ColOutTotal,
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProduce,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 物品编码 
            /// </summary>
            ColItemNO,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode,
            /// <summary>
            /// 库存数量
            /// </summary>
            ColStockNum,
            /// <summary>
            /// 已购/未购//{4D18D170-A7D7-40d0-BA09-D9DB2E20DD79}
            /// </summary>
            ColIsBought
        }

        /// <summary>
        /// 申请单据类型
        /// </summary>
        private enum BillTypeEnum
        {
            /// <summary>
            /// 申请单列表
            /// </summary>
            ApplyList,
            /// <summary>
            /// 计划单列表
            /// </summary>
            PlanList
        }


    }
}
