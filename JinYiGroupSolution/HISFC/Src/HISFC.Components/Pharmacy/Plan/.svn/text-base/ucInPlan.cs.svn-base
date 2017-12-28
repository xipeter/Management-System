using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /// <summary>
    /// [功能描述: 药品入库计划]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1.药品打印接口调用出错Bug处理，如果同时开了入库计划和采购计划并进行过打印的情况下，
    ///      切换界面点打印就会调用上一个打印接口实现by Sunjh 2010-8-26 {D78A574D-59BE-491b-808C-38DCD26BA5EA}
    ///    2.修改提示内容 by Sunjh 2010-9-6 {1C29C7AC-D178-4caf-915C-B1E824014B78}
    /// </修改记录>
    /// </summary>
    public partial class ucInPlan : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                        Neusoft.FrameWork.WinForms.Classes.IPreArrange
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
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 存储计划数据
        /// </summary>
        private System.Collections.Hashtable hsPlanData = new Hashtable();

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
        /// 是否显示自定义码
        /// </summary>
        private bool isShowCustomCode = false;

        /// <summary>
        /// 是否显示本科库存
        /// </summary>
        private bool isShowOwnStock = false;

        /// <summary>
        /// 是否显示全院库存
        /// </summary>
        private bool isShowAllStock = false;

        /// <summary>
        /// 是否使用字典信息内默认的供货公司/购入价
        /// </summary>
        private bool isUseDefaultStockData = false;

        /// <summary>
        /// 人员姓名字典信息
        /// </summary>
        private Dictionary<string, string> personNameDictionary = new Dictionary<string, string>();

        #endregion

        #region 属性

        /// <summary>
        /// 用于计算日均出库量，日消耗 统计天数
        /// </summary>
        [Description("用于计算日均出库量，日消耗 统计天数"), Category("设置"),Browsable(false)]
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
        [Description("是否进行有效性判断"), Category("设置"), DefaultValue(true)]
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
        [Description("列表选择控件是否显示行标题"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool IsShowRowHeader
        {
            get
            {
                return this.ucDrugList1.ShowFpRowHeader;
            }
            set
            {
                this.ucDrugList1.ShowFpRowHeader = value;
            }
        }

        /// <summary>
        /// 是否允许通过行索引确认选择数据
        /// </summary>
        [Description("列表选择控件是否允许通过行索引确认选择数据"), Category("设置"), DefaultValue(false), Browsable(false)]
        public bool IsSelectByNumber
        {
            get
            {
                return this.ucDrugList1.IsUseNumChooseData;
            }
            set
            {
                this.ucDrugList1.IsUseNumChooseData = value;
            }
        }

        /// <summary>
        /// 是否对计划量是否为零进行判断
        /// </summary>
        [Description("是否对计划量是否为零进行判断"), Category("设置"), DefaultValue(false), Browsable(false)]
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
        /// 是否使用字典信息内默认的供货公司/购入价
        /// </summary>
        [Browsable(false)]
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
        /// 是否显示计划单列表
        /// </summary>
        [Browsable(false)]
        public bool IsShowList
        {
            get
            {
                return this.ucDrugList1.ShowTreeView;
            }
            set
            {
                this.ucDrugList1.ShowTreeView = value;

                this.SetToolButton(value);
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("新    建", "新建计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("计划模版", "调用模版生成计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);
            toolBarService.AddToolButton("警 戒 线", "调用模版生成计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B报警, true, false, null);
            toolBarService.AddToolButton("日 消 耗", "调用模版生成计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R日消耗, true, false, null);
            toolBarService.AddToolButton("整单删除", "删除整单计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolBarService.AddToolButton("计 划 单", "计划单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            
            //toolBarService.AddToolButton("日    期", "设置计划单检索日期", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D查询历史, true, false, null);
            
            toolBarService.AddToolButton("删    除", "删除当前选择的计划药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("排    序", "对计划单内药品信息进行排序", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预约, true, false, null);
            toolBarService.AddToolButton("申 请 单", "调用汇总科室申请单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删    除")
            {
                this.DeleteData();
            }
            if (e.ClickedItem.Text == "整单删除")
            {
                this.DeleteDataByBill(this.privDept.ID, this.nowBillNO);
            }
            if (e.ClickedItem.Text == "计 划 单")
            {
                this.tvList.ShowInPlanList(this.privDept, "0");

                this.IsShowList = true;
            }
            if (e.ClickedItem.Text == "新    建")
            {
                this.New();
            }
            if (e.ClickedItem.Text == "计划模版")
            {
                this.planType = "5";
                this.AddStencilData();
            }
            if (e.ClickedItem.Text == "警 戒 线")
            {
                this.planType = "1";
                this.AddAlterData("0");
            }
            if (e.ClickedItem.Text == "日 消 耗")
            {
                this.planType = "2";
                this.AddAlterData("1");
            }
            if (e.ClickedItem.Text == "排    序")
            {
                this.Sort();
            }
            if (e.ClickedItem.Text == "申 请 单")
            {
                this.AddTotalApplyData();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Save() == 1)
            {
                this.IsShowList = true;
            }
            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            ArrayList alPlan = new ArrayList();

            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.HISFC.Models.Pharmacy.InPlan inPlan = this.GetDataFromRow(dr);

                alPlan.Add(inPlan);
            }

            this.Print(alPlan,false);

            return 1;
        }

        public override int SetPrint(object sender, object neuObject)
        {
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
            this.toolBarService.SetToolButtonEnabled("计划模版", !isShowList);
            this.toolBarService.SetToolButtonEnabled("警 戒 线", !isShowList);
            this.toolBarService.SetToolButtonEnabled("日 消 耗", !isShowList);
        }

        #endregion

        #region 数据表初始化

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.Outday = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Plan_Expand_Days, true, 30);
            this.IsShowRowHeader = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Plan_Show_RowHeader, true, true);
            this.IsSelectByNumber = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Plan_Num_SelectRow, true, false);
            this.IsCheckNumZero = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Plan_NumZero_Valid, true, true);
            this.UseDefaultStockData = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Stock_Use_DefaultData, true, true);
            //minihis取消config配置文件的设置
            //this.InitConfig();
        }

        /// <summary>
        /// 配置参数获取
        /// </summary>
        private void InitConfig()
        {
            HISFC.Components.Pharmacy.Function fun = new Function();
            System.Xml.XmlDocument doc = fun.GetConfig();

            if (doc != null)
            {
                System.Xml.XmlNode valueNode = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='InPlan']");
                if (valueNode != null)
                {
                    this.isShowCustomCode = NConvert.ToBoolean(valueNode.Attributes["IsShowCustomCode"].Value);
                    this.isShowOwnStock = NConvert.ToBoolean(valueNode.Attributes["IsShowOwnStock"].Value);
                    this.isShowAllStock = NConvert.ToBoolean(valueNode.Attributes["IsShowAllStock"].Value);
                }

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = this.isShowCustomCode;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOwnStockNum].Visible = this.isShowOwnStock;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColAllStockNum].Visible = this.isShowAllStock;
            }
        }

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
                MessageBox.Show(Language.Msg("获得再用科室列表出错！" + deptManager.Err));
                return;
            }
            this.deptHelper.ArrayObject = deptAll;
            //获得操作员姓名
            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList personAl = personManager.GetEmployeeAll();
            if (personAl == null)
            {
                MessageBox.Show(Language.Msg("获取全部人员列表出错!" + personManager.Err));
                return;
            }
            this.personHelper.ArrayObject = personAl;
            //获取生产厂家
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            ArrayList produceAl = phaConsManager.QueryCompany("0");
            if (produceAl == null)
            {
                MessageBox.Show(Language.Msg("获取生产厂家列表出错!" + phaConsManager.Err));
                return;
            }
            this.produceHelpter.ArrayObject = produceAl;

            #endregion
            //{E215BCFB-9D4B-418c-9C12-AC6E0242FB7F}
            this.ucDrugList1.DeptCode = this.privDept.ID;

            this.ucDrugList1.ShowPharmacyList();
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
                                                                        new DataColumn("自定义码",    dtStr),
                                                                        new DataColumn("商品名称",	  dtStr),
                                                                        new DataColumn("规格",        dtStr),
                                                                        new DataColumn("包装数量",    dtDec),
                                                                        new DataColumn("计划购入价",  dtDec),
                                                                        new DataColumn("计划数量",	  dtDec),
                                                                        new DataColumn("单位",        dtStr),
                                                                        new DataColumn("计划金额",	  dtDec),
                                                                        new DataColumn("本科库存",	  dtDec),
                                                                        new DataColumn("全院库存",	  dtDec),
                                                                        new DataColumn("出库总量",	  dtDec),
                                                                        new DataColumn("日均出库",	  dtDec),
                                                                        new DataColumn("供货公司",    dtStr),
                                                                        new DataColumn("生产厂家",    dtStr),
                                                                        new DataColumn("备注",        dtStr),
                                                                        new DataColumn("药品编码",	  dtStr),
                                                                        new DataColumn("拼音码",      dtStr),
                                                                        new DataColumn("五笔码",      dtStr)                                                                        
                                                                    });

            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[1];
            keys[0] = this.dt.Columns["药品编码"];
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

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDrugNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOutDay].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColAllStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOutTotal].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOwnStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPackQty].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Locked = false;
        }

        #endregion   

        #region 列表初始化

        /// <summary>
        /// 盘点单列表树组件
        /// </summary>
        private tvPlanList tvList = null;

        /// <summary>
        /// 盘点单列表初始化
        /// </summary>
        protected void InitPlanList()
        {
            this.tvList = new tvPlanList();
            this.ucDrugList1.TreeView = this.tvList;

            this.tvList.AfterSelect -= new TreeViewEventHandler(tvList_AfterSelect);
            this.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            this.tvList.DoubleClick -= new EventHandler(tvList_DoubleClick);
            this.tvList.DoubleClick += new EventHandler(tvList_DoubleClick);

            this.ucDrugList1.Caption = "计划单列表";

            this.ShowPlanList();

            this.ucDrugList1.ShowTreeView = true;
        }      

        /// <summary>
        /// 盘点单列表显示
        /// </summary>
        private void ShowPlanList()
        {
            this.tvList.ShowInPlanList(this.privDept, "0");
        }

        #endregion

        #region 方法

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="inPlan"></param>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            try
            {
                if (inPlan.Item.PriceCollection.PurchasePrice == 0)
                    inPlan.Item.PriceCollection.PurchasePrice = inPlan.Item.PriceCollection.RetailPrice;

                decimal planCost = inPlan.PlanQty / inPlan.Item.PackQty * inPlan.Item.PriceCollection.PurchasePrice;
                if (this.produceHelpter != null)
                    inPlan.Item.Product.Producer.Name = this.produceHelpter.GetName(inPlan.Item.Product.Producer.ID);               

                this.dt.Rows.Add(new object[] { 
                                                inPlan.Item.NameCollection.UserCode,        //自定义码
                                                inPlan.Item.Name,                           //商品名称
                                                inPlan.Item.Specs,                          //规格
                                                inPlan.Item.PackQty,                        //包装数量
                                                inPlan.Item.PriceCollection.PurchasePrice,  //计划购入价
                                                inPlan.PlanQty / inPlan.Item.PackQty,       //计划数量
                                                inPlan.Item.PackUnit,                       //单位
                                                planCost,                                   //计划进额  
                                                inPlan.StoreQty / inPlan.Item.PackQty,      //本科库存
                                                inPlan.StoreTotQty / inPlan.Item.PackQty,   //全院库存
                                                inPlan.OutputQty / inPlan.Item.PackQty,     //出库总量
                                                0,                                          //日均出库
                                                inPlan.Item.Product.Company.Name,           //供货公司
                                                inPlan.Item.Product.Producer.Name,          //生产厂家
                                                inPlan.Memo,                                //备注
                                                inPlan.Item.ID,                             //药品编码
                                                inPlan.Item.NameCollection.SpellCode,       //拼音码
                                                inPlan.Item.NameCollection.WBCode          //五笔码                                                
                                           });
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].CellType = this.numCellType;//{1EC17564-2FAD-4a77-97AC-4C57076888B2}
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + e.Message));

                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("DataTable内赋值发生错误" + ex.Message));

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 由数据行内获取入库计划数据
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>成功返回1 失败返回－1</returns>
        private Neusoft.HISFC.Models.Pharmacy.InPlan GetDataFromRow(DataRow dr)
        {
            Neusoft.HISFC.Models.Pharmacy.InPlan inPlan = this.hsPlanData[dr["药品编码"].ToString()] as Neusoft.HISFC.Models.Pharmacy.InPlan;

            inPlan.BillNO = this.nowBillNO;                     //计划单号
            inPlan.State = "0";                                 //单据状态
            inPlan.PlanType = this.planType;                    //采购类型

            inPlan.PlanQty = NConvert.ToDecimal(dr["计划数量"]) * inPlan.Item.PackQty;//计划数量

            inPlan.PlanOper.ID = this.itemManager.Operator.ID;

            inPlan.Oper = inPlan.PlanOper;
            inPlan.Memo = dr["备注"].ToString();                //备注

            return inPlan;
        }

        /// <summary>
        /// 清空入库计划药品信息
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
                this.dt.AcceptChanges();
                foreach(DataRow dr in this.dt.Rows)
                {
                    if (NConvert.ToDecimal(dr["计划数量"]) < 0)
                    {
                        MessageBox.Show("请输入 " + dr["商品名称"].ToString() + " 计划数量");
                        return false;
                    }
                    if (this.isCheckNumZero && (NConvert.ToDecimal(dr["计划数量"]) == 0))
                    {
                        MessageBox.Show("请输入 " + dr["商品名称"].ToString() + " 计划数量 计划量不能为零");
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
                this.ucDrugList1.Select();
                this.ucDrugList1.SetFocusSelect();
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
            node.Tag = new Neusoft.HISFC.Models.Pharmacy.InPlan();

            this.tvList.Nodes[0].Nodes.Insert(0, node);

            //选中此新节点
            this.tvList.SelectedNode = node;//this.ucChooseList.tvList.Nodes[0].Nodes[0];

            //切换到药品数据列表
            this.IsShowList = false;

            this.ucDrugList1.SetFocusSelect();
        }

        /// <summary>
        /// 将药品实体添加
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <param name="totOutQty">出库总量</param>
        /// <param name="averageOutQty">日均出库</param>
        /// <param name="planQty">根据警戒线自动生成的计划出库量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Pharmacy.Item item,decimal totOutQty,decimal averageOutQty,decimal planQty)
        {
            if (this.hsPlanData.ContainsKey(item.ID))
            {
                MessageBox.Show(Language.Msg("该药品已添加到计划单内 同一品种药不能重复添加"));
                return 0;
            }

            //获取全院库存量
            decimal itemSum = 0, itemTotSum = 0;

            if (this.itemManager.FindSum(this.privDept.ID, item.ID, ref itemSum, ref itemTotSum) == -1)
            {
                MessageBox.Show(Language.Msg("读取【" + item.Name + "】库存总量时发生错误" + this.itemManager.Err));
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.InPlan inPlan = new Neusoft.HISFC.Models.Pharmacy.InPlan();

            inPlan.Item = item;
            inPlan.StoreTotQty = itemTotSum;
            inPlan.StoreQty = itemSum;
            inPlan.PlanQty = planQty;

            inPlan.Dept = this.privDept;

            #region 获取历史采购信息

            if (!this.isUseDefaultStockData)        //显示上一次的购入信息
            {
                ArrayList alHistory = this.itemManager.QueryHistoryStockPlan(this.privDept.ID, item.ID);
                if (alHistory == null)
                {
                    Function.ShowMsg("获取历史采购信息出错" + this.itemManager.Err);
                    return -1;
                }

                if (alHistory.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.StockPlan stockTemp = alHistory[0] as Neusoft.HISFC.Models.Pharmacy.StockPlan;

                    inPlan.Item.Product.Company = stockTemp.Company;
                    inPlan.Item.Product.Producer = stockTemp.Item.Product.Producer;
                    inPlan.Item.PriceCollection.PurchasePrice = stockTemp.StockPrice;
                }
            }

            #endregion

            if (this.AddDataToTable(inPlan) == 1)
            {
                this.hsPlanData.Add(inPlan.Item.ID, inPlan);
            }

            this.SetSum();

            return 1;
        }

        /// <summary>
        /// 将药品实体添加
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <param name="planQty">按警戒线自动生成的计划出库量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Pharmacy.Item item,decimal planQty)
        {
            return this.AddDrugData(item, 0, 0, planQty);
        }

        /// <summary>
        /// 将药品实体添加
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            return this.AddDrugData(item, 0, 0, 0);
        }

        #region 按照警戒线/日消耗 数据增加

        ///<summary>
        ///根据药品警戒线加入数据
        ///</summary>
        ///<param name="alterFlag">生成方式 0 警戒线 1 日消耗</param>
        ///<returns>成功返回0，失败返回－1</returns>
        public void AddAlterData(string alterFlag)
        {
            DialogResult result = DialogResult.Yes;
            if (this.dt.Rows.Count > 0)
            {
                //修改提示内容 by Sunjh 2010-9-6 {1C29C7AC-D178-4caf-915C-B1E824014B78}
                result = MessageBox.Show(Language.Msg("是否清除当前入库计划单内容？"), "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (result == DialogResult.Yes)
            {
                //数据清空
                this.Clear();
            }

            try
            {
                ArrayList alDetail = new ArrayList();

                if (alterFlag == "1")
                {
                    #region 弹出窗口 设置日消耗参数 计算需申请信息
                    using (ucPhaAlter uc = new ucPhaAlter())
                    {
                        uc.DeptCode = this.privDept.ID;
                        uc.SetData();
                        uc.Focus();
                       Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                       if (uc.rs == DialogResult.Cancel)
                       {
                           return;
                       }
                        if (uc.ApplyInfo != null)
                        {
                            alDetail = uc.ApplyInfo;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 警戒线计算

                    ////{F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 更改调用函数
                    alDetail = this.itemManager.QueryDrugListByNumAlter(this.privDept.ID);
                    if (alDetail == null)
                    {
                        MessageBox.Show(Language.Msg("按照数量警戒线执行信息计算未正确执行\n" + this.itemManager.Err));
                        return;
                    }

                    #endregion
                }

                if (alDetail.Count == 0)
                {
                    MessageBox.Show(Language.Msg("无满足条件的药品计划信息"));
                    return;
                }

                if (result == DialogResult.Yes)
                {
                    #region 清除原数据，使用警戒线/日消耗数据

                    Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();

                    foreach (Neusoft.FrameWork.Models.NeuObject temp in alDetail)
                    {
                        item = this.itemManager.GetItem(temp.ID);
                        if (item == null)
                        {
                            MessageBox.Show(Language.Msg("读取药品基本信息失败！[" + temp.Name + "]药品不存在! \n 请与药学部联系"));
                            continue;
                        }

                        if (alterFlag == "1")
                            this.AddDrugData(item, NConvert.ToDecimal(temp.User01), NConvert.ToDecimal(temp.User02), NConvert.ToDecimal(temp.User03));
                        else
                            this.AddDrugData(item, NConvert.ToDecimal(temp.User03));
                    }

                    #endregion
                }

                if (result == DialogResult.No)
                {
                    #region 在原数据基础上，使用警戒线数据

                    System.Collections.Hashtable hsAlterList = new Hashtable();

                    foreach (Neusoft.FrameWork.Models.NeuObject temp in alDetail)
                    {
                        hsAlterList.Add(temp.ID, temp);
                    }

                    this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Locked = true;

                    foreach (DataRow dr in this.dt.Rows)
                    {
                        if (hsAlterList.ContainsKey(dr["药品编码"].ToString()))
                        {
                            Neusoft.FrameWork.Models.NeuObject info = hsAlterList[dr["药品编码"].ToString()] as Neusoft.FrameWork.Models.NeuObject;

                            dr["计划数量"] = System.Math.Ceiling(NConvert.ToDecimal(info.User03) / NConvert.ToDecimal(dr["包装数量"]));                           
                        }
                    }

                    this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Locked = false;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 汇总科室申请数据

        /// <summary>
        /// 科室申请选择控件
        /// </summary>
        ucPhaApplyList ucApply = null;

        /// <summary>
        /// 汇总科室申请数据
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddTotalApplyData()
        {
            if (this.ucApply == null)
            {
                this.ucApply = new ucPhaApplyList();
                this.ucApply.Init();
            }

            string class3MeaningCode = Neusoft.HISFC.Models.Base.EnumIMAInTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAInType.InnerApply);

            this.ucApply.QueryApplyListByTarget(this.privDept, class3MeaningCode, "0");
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "科室申请信息汇总";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucApply);

            if (this.ucApply.Result == DialogResult.OK)
            {
                System.Collections.Generic.Dictionary<string, Neusoft.HISFC.Models.Pharmacy.Item> hsApplyData = new Dictionary<string, Neusoft.HISFC.Models.Pharmacy.Item>();

                foreach (Neusoft.FrameWork.Models.NeuObject info in this.ucApply.ApplyListCollection)
                {
                    ArrayList alTempData = this.itemManager.QueryApplyOutInfoByListCode(info.Memo, info.ID, "0");
                    if (alTempData == null)
                    {
                        MessageBox.Show("加载科室申请信息发生错误" + this.itemManager.Err);
                        return -1;
                    }
                    //减去已发核准量   {78801D5B-DE2D-4e59-9181-EB09AE5F0118}
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyData in alTempData)
                    {
                        if (hsApplyData.ContainsKey(applyData.Item.ID))
                        {
                            decimal totApplyQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(hsApplyData[applyData.Item.ID].User01);

                            hsApplyData[applyData.Item.ID].User01 = (totApplyQty + (applyData.Operation.ApplyQty - applyData.Operation.ApproveQty)).ToString();
                        }
                        else
                        {
                            applyData.Item.User01 = (applyData.Operation.ApplyQty - applyData.Operation.ApproveQty).ToString();
                            hsApplyData.Add(applyData.Item.ID, applyData.Item.Clone());
                        }
                    }

                    this.Clear();

                    foreach (string key in hsApplyData.Keys)
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item tempItem = hsApplyData[key];

                        this.AddDrugData(tempItem, Neusoft.FrameWork.Function.NConvert.ToDecimal(tempItem.User01));
                    }
                }
            }

            return 1;
        }

        #endregion

        /// <summary>
        /// 模版数据显示
        /// </summary>
        public void AddStencilData()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("根据模版生成计划信息将清除当前显示的数据 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
                return;

            this.Clear();

            ArrayList alOpenDetail = Function.ChooseDrugStencil(this.privDept.ID,Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil.Plan);

            if (alOpenDetail != null && alOpenDetail.Count > 0)
            {             
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在根据所选模版生成计划信息..."));
                Application.DoEvents();
                //先加载库存信息的Hs 保证模版调用顺序
                System.Collections.Hashtable hsStoreDrug = new Hashtable();

                List<Neusoft.HISFC.Models.Pharmacy.Item> alItem = this.itemManager.QueryItemAvailableList(false);
                foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alItem)
                {
                    hsStoreDrug.Add(item.ID, item);
                }

                int i = 0;
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in alOpenDetail)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, alOpenDetail.Count);
                    Application.DoEvents();

                    if (hsStoreDrug.Contains(info.Item.ID))
                    {
                        this.AddDrugData(hsStoreDrug[info.Item.ID] as Neusoft.HISFC.Models.Pharmacy.Item);
                    }

                    i++;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                this.SetFocus(true);
            }
        }

        /// <summary>
        /// 根据入库计划单号 获取入库计划数据
        /// </summary>
        /// <param name="privDept">权限科室</param>
        /// <param name="billNO">单据号</param>
        public int ShowPlanData(string privDept,string billNO)
        {
            //清空数据。
            this.Clear();

            //取入库计划中的数据
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> alDetail = this.itemManager.QueryInPlanDetail(privDept, billNO);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在显示计划明细 请稍候..."));
            Application.DoEvents();

            foreach (Neusoft.HISFC.Models.Pharmacy.InPlan info in alDetail)
            {
                //对已做完采购计划的数据不显示 
                if (info.State != "0")
                    continue;

                info.Item = this.itemManager.GetItem(info.Item.ID);
                if (info.Item == null)
                {
                    Function.ShowMsg("获取新药品信息发生错误 "); //+ info.Item.ID);
                    return -1;
                }

                this.SetPlanInfo(info);

                if (this.AddDataToTable(info) == 1)
                {
                    this.hsPlanData.Add(info.Item.ID,info);
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

        /// <summary>
        /// 设置计划信息显示
        /// </summary>
        /// <param name="inPlan"></param>
        private void SetPlanInfo(Neusoft.HISFC.Models.Pharmacy.InPlan inPlan)
        {
            this.lbPlanBill.Text = "单据号:" + inPlan.BillNO;

            //{B5B12199-4F8C-4a70-B55F-795E13261EAF}  设置显示人员名称
            if (this.personNameDictionary.ContainsKey(inPlan.PlanOper.ID) == false) //不包含计划人信息
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                Neusoft.HISFC.Models.Base.Employee planOper = managerIntegrate.GetEmployeeInfo(inPlan.PlanOper.ID);
                if (planOper != null)
                {
                    this.personNameDictionary.Add(planOper.ID, planOper.Name);
                }
            }

            if (this.personNameDictionary.ContainsKey(inPlan.PlanOper.ID))
            {
                this.lbPlanInfo.Text = "计划科室: " + this.privDept.Name + " 计划人: " + this.personNameDictionary[inPlan.PlanOper.ID];
            }
            else
            {               
                this.lbPlanInfo.Text = "计划科室: " + this.privDept.Name + " 计划人: " + inPlan.PlanOper.ID;
            }            
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
                MessageBox.Show(Language.Msg("计划单内只有一条药品记录 请选择整单删除方式进行操作"));
                return;
            }
            if (this.neuSpread1_Sheet1.Rows.Count == 0) 
                return;

            if (MessageBox.Show("确定删除选择的数据吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            this.neuSpread1.StopCellEditing();

            string drugNO = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text;
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
            result = MessageBox.Show(Language.Msg("确认删除【" + this.nowBillNO + "】计划单吗？\n 此操作无法撤销"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                int parm = this.itemManager.DeleteInPlan(deptCode, billCode,"0");
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.itemManager.Err);
                    return -1;
                }
                else
                    if (parm != this.dt.Rows.Count)
                    { //处理并发
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("数据发生变动，请刷新窗口"));
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
        /// 保存入库计划单
        /// </summary>
        /// <param name="billCode">入库计划单号</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="state">计划单状态</param>
        /// <param name="plantype">计划类型</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Save()
        {
            if (this.dt.Rows.Count <= 0)
                return -1;
            if (!this.IsValid())
                return -1;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存 请稍候...");
            Application.DoEvents();

            //系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            //定义数据库处理事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 如果是修改的入库计划单，则先删除原入库计划单数据

            if (this.nowBillNO != null && this.nowBillNO != "")
            {
                List<Neusoft.HISFC.Models.Pharmacy.InPlan> alCount = this.itemManager.QueryInPlanDetail(this.privDept.ID, this.nowBillNO);
                    
                //删除未采购审核的计划信息
                int parm = this.itemManager.DeleteInPlan(this.privDept.ID, this.nowBillNO,"0");
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
                this.nowBillNO = this.itemManager.GetPlanBillNO(this.privDept.ID);
                //入库计划单号的操作
                if (this.nowBillNO == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(Language.Msg("获取新计划单号出错" + this.itemManager.Err));
                    return -1;
                }
            }

            #endregion

            int iCount = 1;

            ArrayList printData = new ArrayList();

            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(iCount, this.dt.Rows.Count);
                Application.DoEvents();
             
                #region 入库计划赋值 保存

                //对计划数量为0的不进行处理
                if (NConvert.ToDecimal(dr["计划数量"]) == 0)
                    continue;

                Neusoft.HISFC.Models.Pharmacy.InPlan inPlan = this.hsPlanData[dr["药品编码"].ToString()] as Neusoft.HISFC.Models.Pharmacy.InPlan;

                inPlan.BillNO = this.nowBillNO;                     //计划单号
                inPlan.State = "0";                                 //单据状态
                inPlan.PlanType = this.planType;                    //采购类型

                inPlan.PlanQty = NConvert.ToDecimal(dr["计划数量"]) * inPlan.Item.PackQty;//计划数量

                inPlan.PlanOper.ID = this.itemManager.Operator.ID;
                inPlan.PlanOper.OperTime = sysTime;                 //操作信息

                inPlan.Oper = inPlan.PlanOper;
                inPlan.Memo = dr["备注"].ToString();                //备注

                if (this.itemManager.InsertInPlan(inPlan) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.Item.Name + "保存失败 " + this.itemManager.Err);
                    return -1;
                }

                #endregion

                printData.Add(inPlan);

                iCount++;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");

            this.Print(printData,true);

            //清空数据
            this.Clear();

            this.tvList.ShowInPlanList(this.privDept, "0");

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
        /// 将当前查询内容按Excel格式导出
        /// </summary>
        public void Export()
        {
            try
            {
                if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                    return;

                if (this.neuSpread1.Export() == 1)
                {
                    MessageBox.Show(Language.Msg("导出成功"));
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="alData">待打印数据</param>
        /// <param name="isCue">是否进行提示</param>
        public void Print(ArrayList alData,bool isCue)
        {
            foreach (Neusoft.HISFC.Models.Pharmacy.InPlan info in alData)
            {
                //{B5B12199-4F8C-4a70-B55F-795E13261EAF}  设置显示人员名称
                if (this.personNameDictionary.ContainsKey(info.PlanOper.ID) == false) //不包含计划人信息
                {
                    Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                    Neusoft.HISFC.Models.Base.Employee planOper = managerIntegrate.GetEmployeeInfo(info.PlanOper.ID);
                    if (planOper != null)
                    {
                        this.personNameDictionary.Add(planOper.ID, planOper.Name);
                    }
                }

                if (this.personNameDictionary.ContainsKey(info.PlanOper.ID))
                {
                    info.PlanOper.Name = this.personNameDictionary[info.PlanOper.ID];
                }   
            }

            //药品打印接口调用出错Bug处理，如果同时开了入库计划和采购计划并进行过打印的情况下，切换界面点打印就会调用上一个打印接口实现by Sunjh 2010-8-26 {D78A574D-59BE-491b-808C-38DCD26BA5EA}
            Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            //if (Function.IPrint == null)
            //{
            //    Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            //}

            if (Function.IPrint != null)
            {
                if (isCue)
                {
                    DialogResult rs = MessageBox.Show(Language.Msg("是否打印计划单"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.No)
                    {
                        return;
                    }
                }
                Function.IPrint.SetData(alData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.InPlan);

                Function.IPrint.Print();
            }
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

        /// <summary>
        /// 排序
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Sort()
        {
            if (this.nowBillNO == null || this.nowBillNO == "")
            {
                MessageBox.Show(Language.Msg("请先进行保存操作后再进行排序操作"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }
            //获取当前待排序数据
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> inPlanList = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();
            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.HISFC.Models.Pharmacy.InPlan inPlan = this.GetDataFromRow(dr);
                inPlanList.Add(inPlan);
            }
            if (inPlanList.Count == 0)
            {
                return 1;
            }

            using (ucSortManager uc = new ucSortManager())
            {
                uc.SetFarPoint("自定义码", "商品名称", "规格","供货公司","生产厂家");
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                //排序管理类设置
                List<Neusoft.HISFC.Models.Pharmacy.InPlan> sortList = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();

                MultiSortBase<Neusoft.HISFC.Models.Pharmacy.InPlan> sortManager = new MultiSortBase<Neusoft.HISFC.Models.Pharmacy.InPlan>();
                InPlanSortDelegateInstance delegateInstance = new InPlanSortDelegateInstance();
                sortManager.GetCompareInstance = delegateInstance.GetCompare;

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在进行数据排序 请稍候..."));
                Application.DoEvents();
                //数据排序
                sortManager.MultiStort(inPlanList, ref sortList,uc.SortLevel,uc.Direction);
                //对排序后的数据重新显示            
                if (sortList != null && sortList.Count > 0)
                {
                    this.Clear();

                    foreach (Neusoft.HISFC.Models.Pharmacy.InPlan info in sortList)
                    {
                        this.SetPlanInfo(info);

                        if (this.AddDataToTable(info) == 1)
                        {
                            this.hsPlanData.Add(info.Item.ID, info);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            return 1;

        }

        #region 事件

        private void ucInPlan_Load(object sender, EventArgs e)
        {
            this.InitDataTable();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0311", ref testPrivDept);

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

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                this.InitData();

                this.InitPlanList();

                this.SetToolButton(true);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                if (this.ParentForm != null)
                {
                    this.ParentForm.FormClosing -= new FormClosingEventHandler(ParentForm_FormClosing);
                    this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
                }

                this.InitControlParam();
            }
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsShowList)
            {
                DialogResult rs = MessageBox.Show(Language.Msg("计划单尚未保存 确认退出吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.FrameWork.Models.NeuObject inPlanObj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.nowBillNO = inPlanObj.ID;

                this.ShowPlanData(this.privDept.ID, inPlanObj.ID);
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

        private void fpStockPlan_EditModeOff(object sender, EventArgs e)
        {
            //此事件处理内对dr进行操作 会造成计划量遗留在界面上
            //if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColPlanNum)
            //{
            //    string[] keys = new string[] { this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text};
            //    DataRow dr = this.dt.Rows.Find(keys);
            //    if (dr != null)
            //    {
            //        dr["计划金额"] = NConvert.ToDecimal(dr["计划数量"]) * NConvert.ToDecimal(dr["计划购入价"]);

            //        dr.EndEdit();

            //        this.SetSum();
            //    }
            //}            
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void neuTextBox1_KeyDown(object sender, KeyEventArgs e)
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

                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex,(int)ColumnSet.ColPlanCost].Value = planQty * planPrice;

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

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (activeRow < 0)
                return;

            string drugCode = sv.Cells[activeRow, 0].Text;

            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(drugCode);
            if (item == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
            }

            if (this.AddDrugData(item) == 1)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.SetFocus(true);
            }
        }      

        #endregion

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {          
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode,
            /// <summary>
            /// 药品商品名  
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格  
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 包装数量
            /// </summary>
            ColPackQty,
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
            /// 日均出库
            /// </summary>
            ColOutDay,
            /// <summary>
            /// 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProduce,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 药品编码 
            /// </summary>
            ColDrugNO,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode
        }

        #region IPreArrange 成员

        public int PreArrange()
        {
            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept("0311", ref testPrivDept);

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

    internal class InPlanSortDelegateInstance
    {
        public IComparer<Neusoft.HISFC.Models.Pharmacy.InPlan> GetCompare(List<string> sortColumnLevel, SortDirection direction)
        {
            CompareInPlan c = new CompareInPlan();

            c.sortColumnLevel = sortColumnLevel;
            c.sortDirection = direction;

            return c;
        }

        public class CompareInPlan : IComparer<Neusoft.HISFC.Models.Pharmacy.InPlan>
        {
            /// <summary>
            /// 排序列
            /// </summary>
            public List<string> sortColumnLevel = new List<string>();

            /// <summary>
            /// 排序方式
            /// </summary>
            public SortDirection sortDirection = SortDirection.Ascend;

            #region IComparer<Neusoft.HISFC.Models.Pharmacy.InPlan> 成员

            public int Compare(Neusoft.HISFC.Models.Pharmacy.InPlan x, Neusoft.HISFC.Models.Pharmacy.InPlan y)
            {
                string oX = null;
                string oY = null;
                int nComp;

                foreach (string sortColumn in sortColumnLevel)
                {
                    switch (sortColumn)
                    {
                        case "自定义码":
                            oX += x.Item.NameCollection.UserCode;
                            oY += y.Item.NameCollection.UserCode;
                            break;
                        case "商品名称":
                            oX += x.Item.Name;
                            oY += y.Item.Name;
                            break;
                        case "规格":
                            oX += "S" + x.Item.Specs;
                            oY += "S" + y.Item.Specs;
                            break;
                        case "供货公司":
                            oX += "C" + x.Item.Product.Company.ID;
                            oY += "C" + y.Item.Product.Company.ID;
                            break;
                        case "生产厂家":
                            oX += "P" + x.Item.Product.Producer.ID;
                            oY += "P" + y.Item.Product.Producer.ID;
                            break;
                    }

                }

                if (oX == null) 
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null) 
                {
                    nComp = 1; 
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return this.sortDirection == SortDirection.Ascend ? nComp : -nComp;
            }

            #endregion
        }
    }
}
