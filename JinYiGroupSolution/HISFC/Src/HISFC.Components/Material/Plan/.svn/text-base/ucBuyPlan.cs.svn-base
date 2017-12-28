using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Function;

namespace Neusoft.UFC.Material.Plan
{
    public partial class ucBuyPlan : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucBuyPlan()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.NFC.Object.NeuObject privDept = new Neusoft.NFC.Object.NeuObject();

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
        private Neusoft.NFC.Public.ObjectHelper deptHelper = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.NFC.Public.ObjectHelper personHelper = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.NFC.Public.ObjectHelper produceHelpter = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 入库计划管理类
        /// </summary>
        private Neusoft.HISFC.Management.Material.Plan planManager = new Neusoft.HISFC.Management.Material.Plan();

        /// <summary>
        /// 物品基本信息管理类
        /// </summary>
        private Neusoft.HISFC.Management.Material.MetItem itemManager = new Neusoft.HISFC.Management.Material.MetItem();

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

        private string comId = "";

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
        /// 是否按供货公司显示列表
        /// </summary>
        private bool isVisibleCom = true;

        bool isApprove = false;

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
            }
        }


        /// <summary>
        /// 判断当前打开窗口是否是审核窗口
        /// </summary>
        public bool IsCheck
        {
            get
            {
                return this.isCheck;
            }
            set
            {
                this.isCheck = value;
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
        /// 是否按供货公司显示列表
        /// </summary>
        public bool IsVisibleCom
        {
            get
            {
                return this.isVisibleCom;
            }
            set
            {
                this.isVisibleCom = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();

        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("显 示 栏", "显示栏", Neusoft.NFC.Interface.Classes.EnumImageList.A组套, true, false, null);
            
            toolBarService.AddToolButton("计 划 单", "计划单列表", Neusoft.NFC.Interface.Classes.EnumImageList.A信息, true, false, null);
            toolBarService.AddToolButton("删    除", "删除当前选择的计划药品", Neusoft.NFC.Interface.Classes.EnumImageList.A删除, true, false, null);
            toolBarService.AddToolButton("整单删除", "删除整单计划单", Neusoft.NFC.Interface.Classes.EnumImageList.A取消, true, false, null);
            toolBarService.AddToolButton("采 购 单", "采购单列表", Neusoft.NFC.Interface.Classes.EnumImageList.F换单, true, false, null);            
            
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "删    除":
                    this.DeleteData();
                    break;
                case "删除整单":
                    this.DeleteDataByBill(this.privDept.ID, this.nowBillNO);
                    break;
                case "计 划 单":
                    this.tvList.ShowInPlanList(this.privDept, "2");
                    this.IsShowList = true;
                    break;
                case "采 购 单":
                    this.tvList.ShowStockPlanList(this.privDept, "3");
                    this.IsShowList = true;
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
                case "打    印":
                    break;
                case "导    出":
                    this.Export();
                    break;
                case "未 审 核":
                    this.tvList.ShowStockPlanList(this.privDept, "3");
                    this.IsShowList = true;
                    break;
                case "已 审 核":
                    this.tvList.ShowStockPlanList(this.privDept, "5");
                    this.IsShowList = true;
                    break;
                case "显 示 栏":
                    this.ucMaterialItemList1.Visible = !this.ucMaterialItemList1.Visible;
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
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel1);
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
            this.toolBarService.SetToolButtonEnabled("显 示 栏", !isShowList);

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
            Neusoft.HISFC.Management.Manager.Department deptManager = new Neusoft.HISFC.Management.Manager.Department();
            ArrayList deptAll = deptManager.GetDeptmentAll();
            if (deptAll == null)
            {
                MessageBox.Show("获得再用科室列表出错！" + deptManager.Err);
                return;
            }
            this.deptHelper.ArrayObject = deptAll;
            //获得操作员姓名
            Neusoft.HISFC.Management.Manager.Person personManager = new Neusoft.HISFC.Management.Manager.Person();
            ArrayList personAl = personManager.GetEmployeeAll();
            if (personAl == null)
            {
                MessageBox.Show("获取全部人员列表出错!" + personManager.Err);
                return;
            }
            this.personHelper.ArrayObject = personAl;
            //获取生产厂家
            Neusoft.HISFC.Management.Material.ComCompany company = new Neusoft.HISFC.Management.Material.ComCompany();
            ArrayList produceAl = company.QueryCompany("0", "A");
            if (produceAl == null)
            {
                MessageBox.Show("获取生产厂家列表出错!" + company.Err);
                return;
            }
            this.produceHelpter.ArrayObject = produceAl;

            #endregion

            this.ucMaterialItemList1.ShowMaterialList();
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
														  new DataColumn("选择",dtBol),
														  new DataColumn("物品类别",      dtStr),//--liuxq
														  new DataColumn("物品名称",	  dtStr),
														  new DataColumn("规格",        dtStr),
														  new DataColumn("计划购入价",  dtDec),
														  new DataColumn("计划数量",	  dtDec),
														  new DataColumn("单位",        dtStr),
														  new DataColumn("计划金额",	  dtDec),
														  new DataColumn("采购数量",	  dtDec),
														  new DataColumn("采购金额",	  dtDec),
														  new DataColumn("本科库存",	  dtDec),
														  new DataColumn("全院库存",	  dtDec),
														  new DataColumn("出库总量",	  dtDec),														  
														  new DataColumn("生产厂家",    dtStr),
														  new DataColumn("供货公司",    dtStr),
														  new DataColumn("发票号",      dtStr),//liuxq add
														  new DataColumn("公司编码",    dtStr),
														  new DataColumn("备注",        dtStr),
														  new DataColumn("物品编码",	  dtStr),
														  new DataColumn("拼音码",      dtStr),
														  new DataColumn("五笔码",      dtStr),
														  new DataColumn("自定义码",    dtStr)
													  });

            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

            this.neuSpread1_Sheet1.Columns.Get(13).Visible = false;

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

            FarPoint.Win.Spread.CellType.CheckBoxCellType chkCell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.isCheck].Width = 5F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColKind].Width = 10F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradeName].Width = 80F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpecs].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanNum].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPlanCost].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockNum].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockCost].Width = 50F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUnit].Width = 10F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColCompany].Width = 20F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColInvoiceNo].Width = 10F;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.isCheck].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColKind].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColItemNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColAllStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOutTotal].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOwnStockNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColCompanyID].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColCompany].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColInvoiceNo].Visible = true;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.isCheck].CellType = chkCell;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.isCheck].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockNum].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColCompany].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColInvoiceNo].Locked = false;


            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStockNum].BackColor = System.Drawing.Color.SeaShell;
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
            if (this.IsCheck == false)
            {
                this.tvList.ShowInPlanList(this.privDept, "2");
            }
            else
            {
                if (this.IsVisibleCom == false)
                {
                    this.tvList.ShowBuyPlanList(this.privDept, "3");
                }
                else
                {
                    this.tvList.ShowStockPlanList(this.privDept, "3");
                }

            }

        }


        #endregion

        #region 方法

        /// <summary>
        /// 向数据表内加入数据
        /// </summary>
        /// <param name="inPlan"></param>
        private int AddDataToTable(Neusoft.HISFC.Object.Material.InputPlan inPlan)
        {
            try
            {
                if (inPlan.PlanPrice == 0)
                    inPlan.PlanPrice = inPlan.StoreBase.PriceCollection.RetailPrice;

                decimal planCost = inPlan.PlanNum / inPlan.StoreBase.Item.PackQty * inPlan.PlanPrice;
                if (this.produceHelpter != null)
                    inPlan.Producer.Name = this.produceHelpter.GetName(inPlan.Producer.ID);

                this.dt.Rows.Add(new object[] { 
												  this.isApprove,
												  inPlan.StoreBase.Item.MaterialKind.Name,//---liuxq
												  inPlan.StoreBase.Item.Name,                           //物品名称
												  inPlan.StoreBase.Item.Specs,                          //规格
												  inPlan.PlanPrice,										//计划购入价
												  inPlan.PlanNum / inPlan.StoreBase.Item.PackQty,       //计划数量
												  inPlan.StoreBase.Item.PackUnit,                       //单位
												  planCost,												//计划金额 
												  inPlan.PlanNum / inPlan.StoreBase.Item.PackQty,       //采购数量												
												  planCost,												//采购金额 
												  inPlan.StoreSum / inPlan.StoreBase.Item.PackQty,      //本科库存
												  inPlan.StoreTotsum / inPlan.StoreBase.Item.PackQty,   //全院库存
												  inPlan.OutputSum / inPlan.StoreBase.Item.PackQty,     //出库总量												  
												  inPlan.Producer.Name,									//生产厂家
												  inPlan.Company.Name,
												  inPlan.InvoiceNo,//发票号liuxq add
												  inPlan.Company.ID,
												  inPlan.Memo,											//备注
												  inPlan.StoreBase.Item.ID,                             //物品编码
												  inPlan.StoreBase.Item.SpellCode,						//拼音码
												  inPlan.StoreBase.Item.WbCode,						//五笔码
												  inPlan.StoreBase.Item.UserCode						//自定义码
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
                    if (NConvert.ToDecimal(dr["采购数量"]) < 0)
                    {
                        MessageBox.Show("请输入" + dr["物品名称"].ToString() + " 采购数量！");
                        return false;
                    }
                    //					if (this.isCheckNumZero && (NConvert.ToDecimal(dr["计划数量"]) == 0))
                    //					{
                    //						MessageBox.Show("请输入 " + dr["物品名称"].ToString() + " 采购数量 采购量不能为零");
                    //						return false;
                    //					}
                    //					if ((dr["供货公司"].ToString()) == "")
                    //					{
                    //						MessageBox.Show("请输入" + dr["物品名称"].ToString() + " 的供货公司！");
                    //						return false;
                    //					}
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
            node.Tag = new Neusoft.HISFC.Object.Material.InputPlan();

            this.tvList.Nodes[0].Nodes.Insert(0, node);

            //选中此新节点
            this.tvList.SelectedNode = node;

            //切换到物品数据列表
            this.IsShowList = false;

            this.ucMaterialItemList1.SetFocusSelect();
        }


        /// <summary>
        /// 将物品实体添加
        /// </summary>
        /// <param name="item">物品实体</param>
        /// <param name="totOutQty">出库总量</param>
        /// <param name="averageOutQty">日均出库</param>
        /// <param name="planQty">根据警戒线自动生成的计划出库量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Object.Material.MaterialItem item, decimal totOutQty, decimal averageOutQty, decimal planQty)
        {
            if (this.hsPlanData.ContainsKey(item.ID))
            {
                MessageBox.Show("该物品已添加到计划单内 同一品种物品不能重复添加");
                return 0;
            }

            //获取全院库存量
            //			decimal itemSum = 0, itemTotSum = 0;
            //
            //			if (this.planManager.FindSum(this.privDept.ID, item.ID, ref itemSum, ref itemTotSum) == -1)
            //			{
            //				MessageBox.Show("读取【" + item.Name + "】库存总量时发生错误" + this.planManager.Err);
            //				return -1;
            //			}

            Neusoft.HISFC.Object.Material.InputPlan inPlan = new Neusoft.HISFC.Object.Material.InputPlan();

            inPlan.StoreBase.Item = item;
            //			inPlan.StoreTotsum = itemTotSum;
            //			inPlan.StoreSum = itemSum;
            inPlan.PlanNum = planQty;
            inPlan.PlanPrice = inPlan.StoreBase.Item.UnitPrice;
            inPlan.StockNum = planQty;

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
        public int AddDrugData(Neusoft.HISFC.Object.Material.MaterialItem item, decimal planQty)
        {
            return this.AddDrugData(item, 0, 0, planQty);
        }


        /// <summary>
        /// 将物品实体添加
        /// </summary>
        /// <param name="item">物品实体</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AddDrugData(Neusoft.HISFC.Object.Material.MaterialItem item)
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
            #region 暂时屏掉根据警戒线生成计划单代码，日后根据实际需求在增加。lichao
            /*if (this.dt.Rows.Count > 0)
			{
				DialogResult result;
				result = MessageBox.Show("按警戒线生成将清除当前入库计划单内容，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);

				if (result == DialogResult.No)
					return;
			}

			//数据清空
			this.Clear();

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
						Neusoft.NFC.Interface.Classes.Function.PopShowControl(uc);

						if (uc.ApplyInfo != null)
						{
							alDetail = uc.ApplyInfo;
						}
					}
					#endregion
				}
				else
				{
					alDetail = this.itemManager.FindByAlter("0", this.privDept.ID, System.DateTime.MinValue, System.DateTime.MaxValue);
					if (alDetail == null)
					{
						MessageBox.Show("按照数量警戒线执行信息计算未正确执行\n" + this.itemManager.Err);
						return;
					}
				}

				if (alDetail.Count == 0)
				{
					MessageBox.Show("无满足条件的物品计划信息");
					return;
				}

				Neusoft.HISFC.Object.Material.MaterialItem item = new Neusoft.HISFC.Object.Material.MaterialItem();

				foreach (Neusoft.NFC.Object.NeuObject temp in alDetail)
				{
					item = this.itemManager.QueryMetItemAllByID(temp.ID);
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
			}*/
            #endregion
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

			ArrayList alOpenDetail = Function.ChooseDrugStencil(this.privDept.ID,Neusoft.HISFC.Object.Pharmacy.EnumDrugStencil.Plan);

			if (alOpenDetail != null && alOpenDetail.Count > 0)
			{             
				Neusoft.NFC.Interface.Classes.Function .ShowWaitForm("正在根据所选模生成计划信息...");
				Application.DoEvents();
				//先加载库存信息的Hs 保证模版调用顺序
				System.Collections.Hashtable hsStoreDrug = new Hashtable();

				ArrayList alItem = this.itemManager.QueryItemAvailableList(false);
				foreach (Neusoft.HISFC.Object.Material.MaterialItem item in alItem)
				{
					hsStoreDrug.Add(item.ID, item);
				}

				int i = 0;
				foreach (Neusoft.HISFC.Object.Material.MaterialItem info in alOpenDetail)
				{
					Neusoft.NFC.Interface.Classes.Function .ShowWaitForm(i, alOpenDetail.Count);
					Application.DoEvents();

					if (hsStoreDrug.Contains(info.Item.ID))
					{
						this.AddDrugData(hsStoreDrug[info.Item.ID] as Neusoft.HISFC.Object.Pharmacy.Item);
					}

					i++;
				}

				Neusoft.NFC.Interface.Classes.Function .HideWaitForm();

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

            ArrayList alDetail = new ArrayList();

            //取入库计划中的数据
            if (this.IsCheck == false)
            {
                alDetail = this.planManager.QueryInPlanDetail(privDept, billNO);
            }
            else
            {
                alDetail = this.planManager.QueryInPlanDetailCom(privDept, billNO, this.comId);
            }

            if (alDetail == null)
            {
                MessageBox.Show(this.itemManager.Err);
                return -1;
            }

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在显示计划明细 请稍候...");
            Application.DoEvents();

            foreach (Neusoft.HISFC.Object.Material.InputPlan info in alDetail)
            {
                //对已做完采购计划的数据不显示 
                if (info.State != "2" && info.State != "3" && info.State != "5")
                    continue;

                info.StoreBase.Item = this.itemManager.QueryMetItemAllByID(info.StoreBase.Item.ID);
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
                    Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();

            this.SetSum();

            return 1;
        }


        /// <summary>
        /// 设置计划信息显示
        /// </summary>
        /// <param name="inPlan"></param>
        private void SetPlanInfo(Neusoft.HISFC.Object.Material.InputPlan inPlan)
        {
            this.lbPlanBill.Text = "单据号:" + inPlan.PlanListCode;

            this.lbPlanInfo.Text = "计划科室: " + this.privDept.Name + " 计划人: " + inPlan.StoreBase.Operation.ApplyOper.ID;
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

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);

            try
            {
                int parm = this.planManager.DeleteInputPlan(deptCode, billCode);
                if (parm == -1)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.planManager.Err);
                    return -1;
                }
                else
                    if (parm != this.dt.Rows.Count)
                    { //处理并发
                        Neusoft.NFC.Management.PublicTrans.RollBack();
                        MessageBox.Show("数据发生变动，请刷新窗口");
                        return -1;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Neusoft.NFC.Management.PublicTrans.Commit();

            this.tvList.ShowStockPlanList(this.privDept, "2");

            return 1;
        }


        /// <summary>
        /// 保存采购计划单
        /// </summary>
        public int Save()
        {
            if (this.dt.Rows.Count <= 0)
                return -1;
            if (!this.IsValid())
                return -1;

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在进行保存 请稍候...");
            Application.DoEvents();

            //系统时间
            DateTime sysTime = this.planManager.GetDateTimeFromSysDateTime();

            //定义数据库处理事务
            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);

            int iCount = 1;

            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(iCount, this.dt.Rows.Count);
                Application.DoEvents();

                #region 入库计划赋值 保存

                //对计划数量为0的不进行处理
                if (NConvert.ToDecimal(dr["计划数量"]) == 0)
                    continue;
                if (!NConvert.ToBoolean(dr["选择"]))
                    continue;
                else
                {
                    if ((dr["供货公司"].ToString()) == "")
                    {
                        MessageBox.Show("请输入" + dr["物品名称"].ToString() + " 的供货公司！");
                        return -1;
                    }
                }

                Neusoft.HISFC.Object.Material.InputPlan inPlan = this.hsPlanData[dr["物品编码"].ToString()] as Neusoft.HISFC.Object.Material.InputPlan;

                inPlan.PlanListCode = this.nowBillNO;												 //计划单号
                inPlan.PlanType = this.planType;
                inPlan.StockNum = NConvert.ToDecimal(dr["采购数量"]) * inPlan.StoreBase.Item.PackQty;//采购数量
                inPlan.StockOper.ID = this.planManager.Operator.ID;									 //采购员
                inPlan.StockTime = sysTime;															 //操作信息
                inPlan.StoreBase.Operation.Oper.ID = inPlan.StockOper.ID;							 //操作员
                inPlan.Memo = dr["备注"].ToString();												 //备注
                inPlan.Company.ID = dr["公司编码"].ToString();										 //公司编码
                inPlan.Company.Name = dr["供货公司"].ToString();								     //供货公司
                inPlan.InvoiceNo = dr["发票号"].ToString();//发票号liuxq add

                if (this.planManager.UpdatePlanForStock(inPlan.StorageCode, inPlan.PlanListCode, inPlan.PlanNo, inPlan.StockNum, inPlan.StoreBase.Operation.ApplyOper.ID, sysTime, "3", inPlan.Company.ID, inPlan.Company.Name, inPlan.InvoiceNo) == -1)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.StoreBase.Item.Name + "保存失败 " + this.planManager.Err);
                    return -1;
                }

                #endregion

                iCount++;
            }

            Neusoft.NFC.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");
            //清空数据
            this.Clear();

            this.tvList.ShowInPlanList(this.privDept, "2");

            return 1;
        }


        /// <summary>
        /// 审核采购计划单
        /// </summary>
        public int SaveCheck()
        {
            if (this.dt.Rows.Count <= 0)
                return -1;
            if (!this.IsValid())
                return -1;

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在进行保存 请稍候...");
            Application.DoEvents();

            //系统时间
            DateTime sysTime = this.planManager.GetDateTimeFromSysDateTime();

            //定义数据库处理事务
            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction(Neusoft.NFC.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);

            int iCount = 1;
            string saveState = "5";
            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(iCount, this.dt.Rows.Count);
                Application.DoEvents();

                #region 入库计划赋值 保存

                //对计划数量为0的不进行处理
                if (NConvert.ToDecimal(dr["计划数量"]) == 0)
                    continue;

                Neusoft.HISFC.Object.Material.InputPlan inPlan = this.hsPlanData[dr["物品编码"].ToString()] as Neusoft.HISFC.Object.Material.InputPlan;

                inPlan.PlanListCode = this.nowBillNO;												 //计划单号
                if (this.IsFinance == false)//计划单状态判断 4:需要经过财务审核 5:不需要经过财务审核 
                {
                    saveState = "5";
                    inPlan.State = "5";
                }
                else
                {
                    saveState = "4";
                    inPlan.State = "4";
                }
                inPlan.PlanType = this.planType;													 //采购类型				
                inPlan.StockNum = NConvert.ToDecimal(dr["采购数量"]) * inPlan.StoreBase.Item.PackQty;//采购数量
                inPlan.StockOper.ID = this.planManager.Operator.ID;									 //采购员
                inPlan.StockTime = sysTime;															 //操作信息
                inPlan.StoreBase.Operation.Oper.ID = inPlan.StockOper.ID;							 //操作员
                inPlan.Memo = dr["备注"].ToString();												 //备注

                if (this.planManager.UpdateBuyPlanState(inPlan.StorageCode, inPlan.PlanListCode, inPlan.PlanNo, saveState, inPlan.StoreBase.Operation.ApplyOper.ID, sysTime) == -1)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    Function.ShowMsg(inPlan.StoreBase.Item.Name + "保存失败 " + this.planManager.Err);
                    return -1;
                }

                #endregion

                iCount++;
            }

            Neusoft.NFC.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");
            //清空数据
            this.Clear();

            this.tvList.ShowBuyPlanList(this.privDept, "3");

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


        #endregion

        #region 事件

        public void ToolBarClicked(string parm)
        {/*
            switch (parm)
            {
                case "删除":
                    this.DeleteData();
                    break;
                case "删除整单":
                    this.DeleteDataByBill(this.privDept.ID, this.nowBillNO);
                    break;
                case "计划单":
                    this.tvList.ShowInPlanList(this.privDept, "2");
                    this.IsShowList = true;
                    break;
                case "采购单":
                    this.tvList.ShowStockPlanList(this.privDept, "3");
                    this.IsShowList = true;
                    break;
                case "保存":
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
                case "打印":
                    break;
                case "导出":
                    this.Export();
                    break;
                case "退出":
                    frmInPlan tempFrm = new frmInPlan();
                    tempFrm.Close();
                    break;

                case "未审核":
                    this.tvList.ShowStockPlanList(this.privDept, "3");
                    this.IsShowList = true;
                    break;
                case "已审核":
                    this.tvList.ShowStockPlanList(this.privDept, "5");
                    this.IsShowList = true;
                    break;
                case "显示栏":
                    this.ucMaterialItemList1.Visible = !this.ucMaterialItemList1.Visible;
                    break;
            }
            */
        }

        private void ucInPlan_Load(object sender, System.EventArgs e)
        {
            this.InitDataTable();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                Neusoft.NFC.Object.NeuObject testPrivDept = new Neusoft.NFC.Object.NeuObject();
                int parma = Neusoft.UFC.Common.Classes.Function.ChoosePivDept("0511", ref testPrivDept);

                if (parma == -1)            //无权限
                {
                    MessageBox.Show("您无此窗口操作权限");
                    return;
                }
                else if (parma == 0)       //用户选择取消
                {
                    return;
                }

                this.privDept = testPrivDept;

                Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                this.InitData();

                this.InitPlanList();

                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();

            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.NFC.Object.NeuObject inPlanObj = e.Node.Tag as Neusoft.NFC.Object.NeuObject;

                this.nowBillNO = inPlanObj.ID;
                this.comId = inPlanObj.Name;

                this.ShowPlanData(this.privDept.ID, inPlanObj.ID);
            }
        }

        private void tvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.tvList.SelectedNode != null && this.tvList.SelectedNode.Parent != null)
            {
                Neusoft.NFC.Object.NeuObject inPlanObj = this.tvList.SelectedNode.Tag as Neusoft.NFC.Object.NeuObject;

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
                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColStockNum)
                {
                    decimal stockQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColStockNum].Text);
                    decimal planPrice = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColPurchasePrice].Text);

                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColStockCost].Value = stockQty * planPrice;

                    this.SetSum();
                }

                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColStockNum)
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

                if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColCompany)
                {
                    Neusoft.HISFC.Management.Material.ComCompany company = new Neusoft.HISFC.Management.Material.ComCompany();
                    ArrayList alCompany = company.QueryCompany("1", "A");
                    Neusoft.NFC.Object.NeuObject infoCompany = new Neusoft.NFC.Object.NeuObject();
                    Neusoft.NFC.Interface.Classes.Function.ChooseItem(alCompany, ref infoCompany);
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColCompany].Value = infoCompany.Name;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColCompanyID].Value = infoCompany.ID;
                    this.neuSpread1_Sheet1.ActiveColumnIndex++;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ucMaterialItemList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (activeRow < 0)
                return;

            string itemCode = sv.Cells[activeRow, 0].Text;

            Neusoft.HISFC.Object.Material.MaterialItem item = this.itemManager.QueryMetItemAllByID(itemCode);
            if (item == null)
            {
                MessageBox.Show(this.itemManager.Err);
            }

            if (this.AddDrugData(item) == 1)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.SetFocus(true);
            }
        }

        #endregion

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == (int)ColumnSet.ColCompany)
            {
                bool ifCheck;
                Neusoft.HISFC.Management.Material.ComCompany company = new Neusoft.HISFC.Management.Material.ComCompany();
                ArrayList alCompany = company.QueryCompany("1", "A");
                Neusoft.NFC.Object.NeuObject infoCompany = new Neusoft.NFC.Object.NeuObject();
                Neusoft.NFC.Interface.Classes.Function.ChooseItem(alCompany, ref infoCompany);
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColCompany].Value = infoCompany.Name;
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColCompanyID].Value = infoCompany.ID;
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    ifCheck = Neusoft.NFC.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value.ToString());
                    if (ifCheck)
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCompany].Value = infoCompany.Name;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCompanyID].Value = infoCompany.ID;
                    }

                }
            }
            if (e.Column == (int)ColumnSet.ColProduce)
            {
                Neusoft.HISFC.Management.Material.ComCompany company = new Neusoft.HISFC.Management.Material.ComCompany();
                ArrayList alCompany = company.QueryCompany("0", "A");
                Neusoft.NFC.Object.NeuObject infoCompany = new Neusoft.NFC.Object.NeuObject();
                Neusoft.NFC.Interface.Classes.Function.ChooseItem(alCompany, ref infoCompany);
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColProduce].Value = infoCompany.Name;
                //this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex,(int)ColumnSet.ColProduceID].Value = infoCompany.ID;	
            }
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 是否选择
            /// </summary>
            isCheck,
            /// <summary>
            /// 物品类别
            /// </summary>
            ColKind,
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
            /// 采购数量
            /// </summary>
            ColStockNum,
            /// <summary>
            /// 采购金额
            /// </summary>
            ColStockCost,
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
            /// 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 发票号liuxq add
            /// </summary> 
            ColInvoiceNo,
            /// <summary>
            /// 供或公司编码
            /// </summary>
            ColCompanyID,
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
            ColUserCode

        }
    }
}
