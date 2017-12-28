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

namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    /**
     *  CheckFlag 0 无盈亏 1 盘盈 2 盘亏
     * 
     **/
    /// <summary>
    /// [功能描述: 药品盘点管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改>
    ///     <时间>2007-07-16</时间>
    ///     <修改人>Liangjz</修改人>
    ///     <修改内容>
    ///             1 增加全盘功能
    ///             2 批量封帐时,增加对停用药品/库存为零药品的处理.
    ///     </修改内容>
    ///     <时间>2007-11-29</时间>
    ///     <修改人>Liangjz</修改人>
    ///     <修改内容>
    ///             1 是否按批号盘点更改为根据部门库存常数获取 不根据控制参数进行判断
    ///     </修改内容>
    /// </修改>
    /// </summary>
    public partial class ucCheckManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                            Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucCheckManager()
        {
            InitializeComponent();
        }

        #region 域变量

        private DataTable dt = new DataTable();

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 盘点日志业务层{0A34566D-E154-47a4-BCB1-2437CC877F63}
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.CheckLog checkLogManager = new Neusoft.HISFC.BizLogic.Pharmacy.CheckLog();

        /// <summary>
        /// 药品信息
        /// </summary>
        private System.Collections.Hashtable hsItem = new Hashtable();

        /// <summary>
        /// 盘点实体信息
        /// </summary>
        private System.Collections.Hashtable hsCheck = new Hashtable();

        /// <summary>
        /// 特殊盘点信息
        /// {98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
        /// </summary>
        private Hashtable htSpecialCheck = new Hashtable();

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        private bool isAllowEdit = true;

        /// <summary>
        /// 新盘点单号
        /// </summary>
        private string newCheckNO = "";

        /// <summary>
        /// 当前盘点单开始盘点时间
        /// 
        /// //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 增加开始盘点时间记录
        /// </summary>
        private DateTime currentBillBeginCheckDate;

        /// <summary>
        /// 是否在录入时更新系统封帐库存
        /// 
        /// {F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 
        /// </summary>
        private bool isUpdateFStoreRealTime = false;

        /// <summary>
        /// 是否窗口盘点
        /// </summary>
        private bool isWindowCheck = false;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作单号
        /// </summary>
        private string nowOperCheckNO = "";

        /// <summary>
        /// 是否按批号盘点
        /// </summary>
        private bool isBatch = false;

        /// <summary>
        /// 最初的批号盘点标识位
        /// {98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
        /// </summary>
        private bool isBatchInitial = false;

        /// <summary>
        /// 历史盘点单获取状态 0 封帐 1 结存 2 解封
        /// </summary>
        private string historyListState = "1";

        /// <summary>
        /// 是否按货位号排序盘点单
        /// </summary>
        private bool isSortByPlaceCode = true;
        #endregion

        #region 属性

        /// <summary>
        /// 报表标题
        /// </summary>
        [Description("报表标题 根据不同医院名称设置"), Category("设置"), DefaultValue("盘点单")]
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
        /// 是否允许编辑
        /// </summary>
        [Description("是否允许对盘点数据进行修改编辑"), Category("设置"), DefaultValue(true)]
        public bool IsAllowEdit
        {
            get
            {
                return this.isAllowEdit;
            }
            set
            {
                this.isAllowEdit = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].Locked = !value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].Locked = !value;
            }
        }

        /// <summary>
        /// 是否窗口盘点 窗口盘点使用增量保存功能
        /// </summary>
        [Description("是否窗口盘点 窗口盘点使用增量保存功能"), Category("设置"), DefaultValue(false)]
        public bool IsWindowCheck
        {
            get
            {
                return this.isWindowCheck;
            }
            set
            {
                this.isWindowCheck = value;
            }
        }

        /// <summary>
        /// 是否盘点主窗口功能 主窗口功能显示列表
        /// </summary>
        [Description("是否盘点主窗口功能 主窗口功能显示列表"), Category("设置"), DefaultValue(true)]
        public bool IsCheckManager
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

        /// <summary>
        /// 是否显示盘点单列表
        /// </summary>
        [Description("是否显示盘点单列表"), Category("设置"), DefaultValue(false)]
        public bool IsShowCheckList
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

        /// <summary>
        /// 历史盘点单获取时是否只取结存状态 
        /// </summary>
        [Description("历史盘点单获取时是否只取结存状态 True 取结存状态 False 取解封状态"), Category("设置"), DefaultValue(true)]
        public bool IsHistoryCStoreState
        {
            get
            {
                if (this.historyListState == "1")
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    this.historyListState = "1";
                else
                    this.historyListState = "2";
            }
        }

        /// <summary>
        /// 是否按货位号排序盘点单
        /// </summary>
        [Description("是否按货位号排序盘点单，设置为True则按照货位号排序，设置为False则按照封帐先后顺序排序"), Category("设置"), DefaultValue(true)]
        public bool IsSortByPlaceCode
        {
            get
            {
                return this.isSortByPlaceCode;
            }
            set
            {
                this.isSortByPlaceCode = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("封    帐", "记录当前库存形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
            toolBarService.AddToolButton("批量封帐", "批量封存形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);
            toolBarService.AddToolButton("盘点模版", "调用模版形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);
            toolBarService.AddToolButton("历史盘点", "调用历史盘点记录 ", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            toolBarService.AddToolButton("盘点附加", "添加盘点附加药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借入, true, false, null);
            toolBarService.AddToolButton("盘 点 单", "显示盘点单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("增量保存", "增量保存盘点信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A安排, true, false, null);
            toolBarService.AddToolButton("删    除", "删除当前选择药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("全    盘", "根据当前封帐库存更新盘点库存", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 增加开始盘点时间记录
            toolBarService.AddToolButton( "开始盘点", "记录开始手工盘点药品时间点", Neusoft.FrameWork.WinForms.Classes.EnumImageList.K开帐, true, false, null );

            toolBarService.AddToolButton("结存", "按照盘点库存更新当前库存 处理盈亏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            toolBarService.AddToolButton("解封", "作废当前盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 增加开始盘点时间记录
            if (e.ClickedItem.Text == "开始盘点")
            {
                this.RecordCheckTime();
            }
            if (e.ClickedItem.Text == "结存")
            {
                this.CheckCStore(this.privDept.ID,this.nowOperCheckNO);

                this.ShowCheckList();
            }
            if (e.ClickedItem.Text == "解封")
            {
                this.CancelCheck(this.privDept.ID, this.nowOperCheckNO);

                this.ShowCheckList();
            }
            if (e.ClickedItem.Text == "删    除")
            {
                this.DeleteData();
            }
            if (e.ClickedItem.Text == "全    盘")
            {
                this.FstoreSetAStore();
            }
            if (e.ClickedItem.Text == "增量保存")
            {
                this.AddSave(this.privDept.ID, this.nowOperCheckNO);

                if (this.tvList.Nodes.Count > 0)
                    this.tvList.SelectedNode = this.tvList.Nodes[0];
            }
            if (e.ClickedItem.Text == "盘 点 单")
            {
                this.Clear();

                if (!this.IsShowCheckList)
                {
                    this.IsShowCheckList = true;
                }
            }
            if (e.ClickedItem.Text == "封    帐")
            {
                this.CheckClose();
            }
            if (e.ClickedItem.Text == "盘点附加")
            {
                this.GroupCheckAdd();
            }
            if (e.ClickedItem.Text == "历史盘点")
            {
                this.GroupCheckCloseHistory();
            }
            if (e.ClickedItem.Text == "批量封帐")
            {
                this.GroupCheckCloseType();
            }
            if (e.ClickedItem.Text == "盘点模版")
            {
                this.GroupCheckCloseStencil();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Save(this.privDept.ID, this.nowOperCheckNO) != 1)
                return -1;

            if (!this.IsShowCheckList)
            {
                this.ShowCheckList();

                this.IsShowCheckList = true;
            }

            if (this.tvList.Nodes.Count > 0)
            {
                this.tvList.SelectedNode = this.tvList.Nodes[0];
            }

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.neuSpread1.Export();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (Function.IPrint == null)
            {
                Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            }

            if (Function.IPrint != null)
            {
                Function.IPrint.SetData(this.GetAllData(), Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.Check);

                Function.IPrint.Print();
            }
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
            this.toolBarService.SetToolButtonEnabled("盘 点 单", !isShowList);
            this.toolBarService.SetToolButtonEnabled("盘点附加", isShowList);
            this.toolBarService.SetToolButtonEnabled("封    帐", isShowList);
            this.toolBarService.SetToolButtonEnabled("增量保存", isShowList);
            this.toolBarService.SetToolButtonEnabled("删    除", !isShowList);
            this.toolBarService.SetToolButtonEnabled("批量封帐", !isShowList);
            this.toolBarService.SetToolButtonEnabled("盘点模版", !isShowList);
            this.toolBarService.SetToolButtonEnabled("剂型分类", !isShowList);
            this.toolBarService.SetToolButtonEnabled("历史盘点", !isShowList);

        }

        #endregion

        #region 盘点列表初始化

        /// <summary>
        /// 盘点单列表树组件
        /// </summary>
        private tvCheckList tvList = null;

        /// <summary>
        /// 盘点单列表初始化
        /// </summary>
        protected void InitCheckList()
        {
            this.tvList = new tvCheckList();
            this.ucDrugList1.TreeView = this.tvList;

            this.tvList.AfterSelect -= new TreeViewEventHandler(tvList_AfterSelect);
            this.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            this.ucDrugList1.Caption = "盘点单列表";

            this.ShowCheckList();

            this.ucDrugList1.ShowTreeView = true;
        }

        /// <summary>
        /// 盘点单列表显示
        /// </summary>
        private void ShowCheckList()
        {
            Neusoft.FrameWork.Models.NeuObject operObj = new Neusoft.FrameWork.Models.NeuObject();
            operObj.ID = "ALL";
            operObj.Name = "所有人员";

            this.tvList.ShowCheckList(this.privDept, "0", operObj);
        }

        #endregion

        #region 初始化DataTable及Fp设置

        /// <summary>
        /// DataTable初始化
        /// </summary>
        private void InitDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列     //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            this.dt.Columns.AddRange(new DataColumn[] {
                                                                        new DataColumn("货位号",      dtStr),
                                                                        new DataColumn("自定义码",	  dtStr),
                                                                        new DataColumn("商品名称",	  dtStr),
                                                                        new DataColumn("规格",        dtStr),
                                                                        new DataColumn("包装数量",    dtDec),
                                                                        new DataColumn("批号",		  dtStr),
                                                                        new DataColumn("有效期",	  dtStr),
                                                                        new DataColumn("零售价",      dtDec),
                                                                        new DataColumn("盘点数量1",	  dtDec),
                                                                        new DataColumn("包装单位",    dtStr),
                                                                        new DataColumn("盘点数量2",	  dtDec),
                                                                        new DataColumn("最小单位",	  dtStr),
                                                                        new DataColumn("盘点库存",    dtDec),
                                                                        new DataColumn("封帐库存",    dtDec),
                                                                        new DataColumn("单位",		  dtStr),
                                                                        new DataColumn("盘点金额",	  dtDec),
                                                                        new DataColumn("盈亏数量",	  dtDec),
                                                                        new DataColumn("盈亏金额",	  dtDec),
                                                                        new DataColumn("备注",        dtStr),
                                                                        new DataColumn("盈亏标记",    dtDec),
                                                                        new DataColumn("是否附加",	  dtBol),
                                                                        new DataColumn("流水号",      dtStr),
                                                                        new DataColumn("药品编码",	  dtStr),
                                                                        new DataColumn("拼音码",      dtStr),
                                                                        new DataColumn("五笔码",      dtStr),
                                                                        new DataColumn("通用名拼音码",dtStr),
                                                                        new DataColumn("通用名五笔码",dtStr),
                                                                    });
            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;
            this.dt.CaseSensitive = true;

            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[3];
            keys[0] = this.dt.Columns["药品编码"];
            keys[1] = this.dt.Columns["货位号"];
            keys[2] = this.dt.Columns["批号"];
            this.dt.PrimaryKey = keys;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.SetFormat();
        }

        /// <summary>
        /// 格式化FarPoint
        /// </summary>
        public void SetFormat()
        {
            float unitWidth = 36F;
            float numWidth = 70F;

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numberCellType1 = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            numberCellType1.MinimumValue = 0;

            //屏蔽回车键
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //使直接选中就可以编辑
            FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
            t.ReadOnly = true;

            this.neuSpread1_Sheet1.DefaultStyle.CellType = t;

            this.neuSpread1_Sheet1.ColumnHeader.Rows[0].Height = 40F;

            if (this.isAllowEdit)
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].CellType = numberCellType1;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].CellType = numberCellType1;
            }
            else
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].CellType = numberCellType1;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].CellType = numberCellType1;
            }

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PlaceNO].Width = 50F;                 //货位号
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.UserCode].Width = 60F;                //自定义码
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.TradeName].Width = 130F;              //商品名称
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Specs].Width = 70F;                   //规格
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.RetailPrice].Width = 60F;          
            
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].Width = numWidth;            //盘点数量1
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackUnit].Width = unitWidth;          //包装单位
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].Width = numWidth;             //盘点数量2
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinUnit].Width = unitWidth;           //最小单位

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckQty].Width = numWidth;           //盘点库存
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.FStoreQty].Width = numWidth;          //封帐库存
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckUnit].Width = unitWidth;         //盘点库存单位
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCost].Width = numWidth;          //盘点金额
            //   //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCount].Width = numWidth;          //盈亏数量   
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCost1].Width = numWidth;          //盈亏金额

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.BatchNO].Visible = this.isBatch;             //批号
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ValidDate].Visible = false;           //有效期

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.IsAdd].Visible = false;               //是否附加

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckNO].Visible = false;			    //流水号
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.DrugNO].Visible = false;			    //药品编码            
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.RegularSpell].Visible = false;        //通用名拼音码
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.RegularWB].Visible = false;           //通用名五笔码
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.WBCode].Visible = false;              //五笔码
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SpellCode].Visible = false;           //拼音码

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].BackColor = System.Drawing.Color.SeaShell;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].BackColor = System.Drawing.Color.SeaShell;

            //设置可以排序
            this.neuSpread1_Sheet1.SetColumnAllowAutoSort((int)ColumnSet.CheckFlag, true);
            //{EA9E3C43-2708-405f-9C19-4F7513573A61}按货位号排序
            this.neuSpread1_Sheet1.SetColumnAllowAutoSort((int)ColumnSet.PlaceNO, true);

            this.SetFlag();
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> alItem = this.itemManager.QueryItemList();
            if (alItem == null)
            {
                MessageBox.Show(Language.Msg("加载药品基本信息发生错误"));
                return;
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in alItem)
            {
                this.hsItem.Add(info.ID, info);
            }            

            
			Neusoft.HISFC.BizLogic.Manager.Controler ctrlMagager = new Neusoft.HISFC.BizLogic.Manager.Controler();
			string ctrlStr = ctrlMagager.QueryControlerInfo("510001");
			if (ctrlStr == "1")
                this.isBatch = true;
			else
				this.isBatch = false;

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //获得库房控制参数，判断对该库房是否按批号管理
            this.isBatch = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Check_With_Batch, true, false);
            
            //是否盘点更改为根据部门库存参数设置获取
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptConst = consManager.QueryDeptConstant(this.privDept.ID);
            this.isBatch = deptConst.IsBatch;
            //{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}增加可以按药品性质维护药品是否按批次盘点,保留原始标识位
            this.isBatchInitial = this.isBatch;
            //历史盘点单获取时是否只取结存状态
            this.IsHistoryCStoreState = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Check_History_State, true, true);

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.BatchNO].Visible = this.isBatch;             //批号

            //可以按药品性质维护药品是否按批次盘点{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
            //this.ucDrugList1.ShowDeptStorage(this.privDept.ID, this.isBatch, 0);
            this.ucDrugList1.ShowDeptStorageWithSpecialCheck(this.privDept.ID, this.isBatch, 0);
        }

        /// <summary>
        /// 设置Fp标记
        /// </summary>
        protected void SetFlag()
        {
            try
            {
                //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示吕山勇添加一共三个
                if (NConvert.ToDecimal(this.neuLbTotalCost.Text) < 0)
                {
                    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Red;
                }
                else if (NConvert.ToDecimal(this.neuLbTotalCost.Text) > 0)
                {
                    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Black;
                }

                if (NConvert.ToDecimal(this.neuLbWinCost.Text) < 0)
                {
                    this.neuLbWinCostSign.ForeColor = System.Drawing.Color.Red;
                }
                else if (NConvert.ToDecimal(this.neuLbWinCost.Text) > 0)
                {
                    this.neuLbWinCostSign.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    this.neuLbWinCostSign.ForeColor = System.Drawing.Color.Black;
                }

                if (NConvert.ToDecimal(this.neuLbLoseCost.Text) < 0)
                {
                    this.neuLbLoseCostSign.ForeColor = System.Drawing.Color.Red;
                }
                else if (NConvert.ToDecimal(this.neuLbLoseCost.Text) > 0)
                {
                    this.neuLbLoseCostSign.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    this.neuLbLoseCostSign.ForeColor = System.Drawing.Color.Black;
                }

                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.CheckQty].Text) > NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.FStoreQty].Text))
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Blue;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.CheckFlag].Text = "1";
                    }
                    else if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.CheckQty].Text) < NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.FStoreQty].Text))
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Red;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.CheckFlag].Text = "2";
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Black;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.CheckFlag].Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("格式化Fp盈亏颜色显示时发生错误" + ex.Message));
                return;
            }
        }

        /// <summary>
        /// 向数据表内增加数据
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        protected int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.Check check)
        {
            string judgeCheckID = "-1";
            if (check.ID != null && check.ID != "")
            {
                judgeCheckID = check.ID;
            }
            else   //对有效盘点单不用进行判断
            {
                if (!check.IsAdd)
                {
                    if (this.itemManager.JudgeCheckState(check.Item.ID, this.privDept.ID, "0", judgeCheckID))
                    {
                        MessageBox.Show(check.Item.Name + Language.Msg("  仍存在未结存或解封的盘点单 不能继续进行封帐盘点"));
                        return -1;
                    }
                }
            }

            try
            {
                decimal checkFlag = 0;
                if (check.AdjustQty > check.FStoreQty)      //盘盈
                {
                    checkFlag = 1;
                }
                else if (check.AdjustQty < check.FStoreQty) //盘亏
                {
                    checkFlag = 2;
                }
                if (check.PlaceNO == "" || check.PlaceNO == null)
                {
                    check.PlaceNO = "0";
                }
                //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
                decimal winLosCost = System.Math.Round((check.AdjustQty - check.FStoreQty) / check.Item.PackQty * check.Item.PriceCollection.RetailPrice, 2);

                this.dt.Rows.Add(new object[] { 
                                                check.PlaceNO,                              //货位号
                                                check.Item.NameCollection.UserCode,         //自定义码
                                                check.Item.NameCollection.Name,             //商品名称
                                                check.Item.Specs,                           //规格
                                                check.Item.PackQty,                         //包装数量
                                                check.BatchNO,                              //批号
                                                check.ValidTime,                            //有效期
                                                check.Item.PriceCollection.RetailPrice,     //零售价
                                                check.PackQty,                              //盘点数量1
                                                check.Item.PackUnit,                        //包装单位
                                                check.MinQty,                               //盘点数量2
                                                check.Item.MinUnit,                         //最小单位
                                                check.AdjustQty,                            //盘点库存
                                                check.FStoreQty,                            //封帐库存
                                                check.Item.MinUnit,                         //单位
                                                System.Math.Round(check.AdjustQty / check.Item.PackQty * check.Item.PriceCollection.RetailPrice,2),      //盘点金额                                           
                                                 check.AdjustQty-check.FStoreQty,//盈亏数量
                                                winLosCost,

                                                check.Memo,
                                                checkFlag,
                                                check.IsAdd,
                                                check.ID,
                                                check.Item.ID,
                                                check.Item.NameCollection.SpellCode,
                                                check.Item.NameCollection.WBCode,
                                                check.Item.NameCollection.RegularSpell.SpellCode,
                                                check.Item.NameCollection.RegularSpell.WBCode
                                           });
                //  {B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
                //  吕山勇添加WinLoseCost()
                this.WinLoseCost(winLosCost);
            }
            catch (System.Data.ConstraintException eCons)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("该药品已存在 不能重复添加"));
                return -1;
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
        /// {B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示吕山勇
        /// 用此函数实现盈亏总额、盘盈金额、盘亏总额
        /// </summary>
        private void WinLoseCost(decimal count)
        {
            this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) + count).ToString();
            if (count > 0)
            {
                this.neuLbWinCost.Text = (NConvert.ToDecimal(this.neuLbWinCost.Text) + count).ToString();
            }
            else
            {
                this.neuLbLoseCost.Text = (NConvert.ToDecimal(this.neuLbLoseCost.Text) + count).ToString();
            }
        }

        /// <summary>
        /// 由DataTable内获取项目信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Pharmacy.Check GetDataFromTable(DataRow dr)
        {
            string key = dr["药品编码"].ToString() + dr["批号"].ToString() + dr["货位号"].ToString();
            if (this.hsCheck.Contains(key))
            {
                Neusoft.HISFC.Models.Pharmacy.Check check = this.hsCheck[key] as Neusoft.HISFC.Models.Pharmacy.Check;

                check.PackQty = NConvert.ToDecimal(dr["盘点数量1"]);
                check.MinQty = NConvert.ToDecimal(dr["盘点数量2"]);

                check.AdjustQty = check.PackQty * check.Item.PackQty + check.MinQty;
                check.Memo = dr["备注"].ToString();

                return check;
            }

            return null;
        }

        /// <summary>
        /// {98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
        /// 初始化特殊盘点哈希表
        /// </summary>
        private void InitSpecialCheck()
        {
            List<Neusoft.HISFC.Models.Pharmacy.CheckSpecial> spList = this.itemManager.QueryCheckSpecial(this.privDept.ID);
            if (spList == null)
            {
                MessageBox.Show("查找特殊盘点记录失败：" + this.itemManager.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.CheckSpecial special in spList)
            {
                this.htSpecialCheck.Add(special.DrugQuality.ID, special);
            }
        }

        #endregion

        #region 批量封帐 / 盘点附加

        /// <summary>
        /// 判断是否可以继续进行批量封帐
        /// </summary>
        /// <returns>允许进行</returns>
        public bool JudgeContinue(string msg)
        {
            if (this.neuSpread1_Sheet1.Rows.Count != 0)
            {
                DialogResult result;
                //提示用户选择是否继续生成，如继续生成则将清空原数据
                result = MessageBox.Show(Language.Msg(msg + " 将清除当前数据，是否继续"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 批量封帐
        /// </summary>
        protected virtual void GroupCheckCloseType()
        {
            //判断是否允许进行批量封帐
            if (!this.JudgeContinue("批量封帐"))
            {
                return;
            }

            this.Clear();

            ////弹出选择药品类别、药品性质窗口
            HISFC.Components.Pharmacy.Check.ucTypeOrQualityChoose uc = new ucTypeOrQualityChoose( true );
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

            switch (uc.ResultFlag)
            {
                case "0":           //取消
                    break;
                case "1":           //药品类别/药品性质
                    this.CheckCloseByType(this.privDept.ID, uc.DrugType, uc.DrugQuality, this.isBatch,uc.IsCheckZeroStock,uc.IsCheckStopDrug);
                    break;
                case "2":           //全部药品封帐
                    this.CheckCloseByTotal(this.privDept.ID, this.isBatch,uc.IsCheckZeroStock,uc.IsCheckStopDrug);
                    break;
            }
        }

        /// <summary>
        /// 盘点模版批量封帐
        /// </summary>
        protected virtual void GroupCheckCloseStencil()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("使用模版将清除当前的数据 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.No)
            {
                return;
            }

            this.Clear();

            ArrayList alStencilDetail = Function.ChooseDrugStencil(this.privDept.ID, Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil.Check);
            if (alStencilDetail != null && alStencilDetail.Count > 0)
            {
                System.Collections.Hashtable hsDrugStencil = new Hashtable();
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in alStencilDetail)
                {
                    hsDrugStencil.Add(info.Item.ID, null);
                }

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据所选盘点模版进行封帐处理...");
                Application.DoEvents();

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
                
                //此处取出的货位号有问题
                ArrayList alItem = this.itemManager.QueryStorageList(this.privDept.ID, this.isBatch);

                foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alItem)
                {
                    if (hsDrugStencil.ContainsKey(item.ID))
                    {
                        this.AddCheckData(this.privDept.ID, item.ID, item.User01, item.User02, this.isBatch);
                    }
                }

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
        
        /// <summary>
        /// 根据历史盘点表封帐 只取结存后的盘点单
        /// </summary>
        protected virtual void GroupCheckCloseHistory()
        {
            if (!this.JudgeContinue("复制历史盘点单"))
            {
                return;
            }

            this.Clear();

            List<Neusoft.HISFC.Models.Pharmacy.Check> alList = this.itemManager.QueryCheckList(this.privDept.ID,this.historyListState, "ALL");
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取盘点单列表发生错误" + this.itemManager.Err));
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Check check in alList)
            {
                //获得封帐人员姓名
                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.Models.Base.Employee employee = personManager.GetPersonByID(check.FOper.ID);
                if (employee == null)
                {
                    System.Windows.Forms.MessageBox.Show(Language.Msg("获得封帐人员信息时出错！人员编码为" + check.FOper.ID + "的人员不存在"));
                    return;
                }
                check.FOper.Name = employee.Name;

                check.User01 = check.CheckNO;

                if (check.CheckName == "")          //盘点单号/盘点单名称
                    check.ID = check.CheckNO;
                else
                    check.ID = check.CheckName;
                check.Name = employee.Name;         //封帐人
                
            }

            Neusoft.FrameWork.Models.NeuObject selectObj = new Neusoft.FrameWork.Models.NeuObject();
            string[] label = { "单据号", "封帐人" };
            float[] width = { 120F, 100F };
            bool[] visible = { true, true, false, false, false, false };
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(new ArrayList(alList.ToArray()), ref selectObj) == 0)
            {
                return;
            }
            else
            {
                ArrayList alDetail = this.itemManager.QueryCheckDetailByCheckCode(this.privDept.ID, selectObj.User01);
                if (alDetail == null)
                {
                    MessageBox.Show(Language.Msg("根据盘点单获取盘点明细列表发生错误"));
                    return;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在根据所选盘点单进行封帐处理..."));
                Application.DoEvents();

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

                int i = 1;
                foreach (Neusoft.HISFC.Models.Pharmacy.Check checkInfo in alDetail)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, alDetail.Count);
                    Application.DoEvents();

                    this.AddCheckData(this.privDept.ID, checkInfo.Item.ID, checkInfo.BatchNO, checkInfo.PlaceNO,this.isBatch);
                }

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

        }

        /// <summary>
        /// 盘点附加
        /// </summary>
        protected virtual void GroupCheckAdd()
        {
            //当前列表内点击有效的盘点单
            if (this.tvList.SelectedNode == null || this.tvList.SelectedNode.Parent == null)
                return;

            if (this.dt.Rows.Count <= 0)
            {
                MessageBox.Show(Language.Msg("请先对相应药品进行封帐处理，\n无法直接将盘点附加药品加入盘点单"));
                return;
            }

            HISFC.Components.Pharmacy.Check.ucCheckAdd uc = new ucCheckAdd();

            uc.IsShowAddCheckBox = true;
            uc.IsShowButton = false;            

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

            if (uc.Result == DialogResult.OK)
            {
                this.AddCheckAdd(uc.ChooseData);
            }
            else
            {
                return;
            }

        }

        #endregion

        #region 封帐方法

        /// <summary>
        /// 封帐
        /// </summary>
        protected void CheckClose()
        {
            this.Clear();

            this.IsShowCheckList = false;

            this.ucDrugList1.SetFocusSelect();
        }

        /// <summary>
        /// 手工添加药品封帐记录
        /// </summary>
        /// <param name="deptNO"></param>
        /// <param name="drugNO"></param>
        /// <param name="batchNO"></param>
        /// <param name="placeNO"></param>
        /// <param name="isBatch"></param>
        protected int AddCheckData(string deptNO, string drugNO, string batchNO, string placeNO, bool isBatch)
        {
            string key = drugNO + batchNO + placeNO;
            if (this.hsCheck.ContainsKey(key))
            {
                MessageBox.Show(Language.Msg("添加药品已存在,不能重复添加"));
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.Check check = this.itemManager.CheckCloseByDrug(deptNO, drugNO, batchNO, isBatch);
            if (check == null)
            {
                MessageBox.Show(Language.Msg("添加药品封帐失败 " + this.itemManager.Err));
                return -1;
            }

            if (this.AddDataToTable(check) == 1)
            {
                //货位号以封帐获取的为准
                this.hsCheck.Add(drugNO + batchNO + check.PlaceNO, check);
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// 根据药品类别、性质直接进行盘点封帐
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugType">药品类别</param>
        /// <param name="drugQuality">药品性质</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <returns>成功返回1 失败返回－1，不操作返回0</returns>
        protected int CheckCloseByType(string deptNO, string drugType, string drugQuality, bool isBatch,bool isCheckZeroStock,bool isCheckStopDrug)
        {
            //清除原数据
            this.Clear();

            try
            {
                // 批量盘点检索速度和全盘速度慢甚至死机的问题 {17261296-ABFC-45d5-AD3A-D772B905C8CA} wbo 2010-09-28
                //按照药品类别、药品性质进行封帐
                //ArrayList alDetail = this.itemManager.CheckCloseByTypeQuality(deptNO, drugType, drugQuality, isBatch, isCheckZeroStock, isCheckStopDrug);
                ArrayList alDetail = this.itemManager.LocalCheckCloseByTypeQuality(deptNO, drugType, drugQuality, isBatch, isCheckZeroStock, isCheckStopDrug);
                if (alDetail == null)
                {
                    MessageBox.Show(Language.Msg("按照药品类别/性质进行批量封帐失败" + this.itemManager.Err));
                    return -1;
                }

                if (alDetail.Count == 0)
                {
                    MessageBox.Show(Language.Msg("该选择类型无库存药品" + this.itemManager.Err));
                    return -1;
                }

                this.ShowCheckDetail(alDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 对本库房所有药品进行封帐处理
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CheckCloseByTotal(string deptNO, bool isBatch,bool isCheckZeroStock,bool isCheckStopDrug)
        {
            //清除原数据
            this.Clear();

            try
            {
                // 批量盘点检索速度和全盘速度慢甚至死机的问题 {17261296-ABFC-45d5-AD3A-D772B905C8CA} wbo 2010-09-28
                //对所有药品进行封帐处理
                //ArrayList alDetail = this.itemManager.CheckCloseByTotal(deptNO, isBatch, isCheckZeroStock, isCheckStopDrug);
                ArrayList alDetail = this.itemManager.LocalCheckCloseByTotal(deptNO, isBatch, isCheckZeroStock, isCheckStopDrug);
                if (alDetail == null)
                {
                    MessageBox.Show(Language.Msg("对本科室所有库存药品进行批量封帐处理失败" + this.itemManager.Err));
                    return -1;
                }
                if (alDetail.Count == 0)
                {
                    MessageBox.Show(Language.Msg("该选择类型无库存药品" + this.itemManager.Err));
                    return -1;
                }

                //在FarPoint内显示明细
                this.ShowCheckDetail(alDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("封帐失败！" + ex.Message));
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 增加盘点附加信息
        /// </summary>
        /// <param name="alAddDetail"></param>
        /// <returns></returns>
        protected int AddCheckAdd(List<Neusoft.HISFC.Models.Pharmacy.Check> alAddDetail)
        {
            string errStr = "";
            foreach (Neusoft.HISFC.Models.Pharmacy.Check check in alAddDetail)
            {
                if (this.hsCheck.ContainsKey(check.Item.ID + check.BatchNO + check.PlaceNO))
                {
                    if (errStr == "")
                        errStr = "存在重复值 已自动屏蔽";
                    errStr = errStr + check.Item.Name;
                    continue;
                }

                bool isHave = false;
                foreach (DataRow dr in this.dt.Rows)
                {
                    if (dr["药品编码"].ToString() == check.Item.ID)
                    {
                        isHave = true;
                        break;
                    }
                }
                check.Item = this.itemManager.GetItem(check.Item.ID);
                if (check.Item == null)
                {
                    MessageBox.Show(Language.Msg("加载药品基本信息时出错" + this.itemManager.Err));
                    return -1;
                }

                if (!isHave)
                {
                    MessageBox.Show(Language.Msg("请先对 " + check.Item.Name + " 进行盘点封帐\n无法直接将药品加入盘点单"));
                    return 0;
                }
               
                if (this.AddDataToTable(check) == 1)
                {
                    this.hsCheck.Add(check.Item.ID + check.BatchNO + check.PlaceNO, check);
                }
                else
                {
                    return -1;
                }
            }

            if (errStr != "")
            {
                MessageBox.Show(Language.Msg(errStr));
            }

            return 1;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示盘点明细信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        public void ShowCheckDetail(string deptNO, string checkNO)
        {
            ArrayList alDetail = new ArrayList();

            alDetail = this.itemManager.QueryCheckDetailByCheckCode(deptNO, checkNO);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }

            if (!this.isSortByPlaceCode)
            {
                NoSort noSort = new NoSort();

                alDetail.Sort(noSort);
            }

            this.ShowCheckDetail(alDetail);

            //提交变化 根据单号检索时 所有数据都是已保存过得 尚未做过修改
            this.dt.AcceptChanges();
        }

        /// <summary>
        /// 填充FarPoint
        /// </summary>
        /// <param name="alDetail">check动态数组</param>
        public int ShowCheckDetail(ArrayList alDetail)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在检索盘点详细信息..."));
            Application.DoEvents();

            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

                int i = 1;
                foreach (Neusoft.HISFC.Models.Pharmacy.Check check in alDetail)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, alDetail.Count);
                    Application.DoEvents();

                    #region 获取药品基本信息

                    if (this.hsItem.ContainsKey(check.Item.ID))
                    {
                        check.Item = this.hsItem[check.Item.ID] as Neusoft.HISFC.Models.Pharmacy.Item;
                    }
                    else
                    {
                        MessageBox.Show(check.Item.ID);
                        check.Item = this.itemManager.GetItem(check.Item.ID);
                        if (check.Item == null)
                        {
                            Function.ShowMsg("加载药品基本信息时出错" + this.itemManager.Err);
                            return -1;
                        }
                    }

                    //批量盘点检索速度和全盘速度慢甚至死机的问题 {17261296-ABFC-45d5-AD3A-D772B905C8CA} wbo 2010-09-28
                    if (check.Item.ValidState != Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                    {
                        continue;
                    }

                    #endregion

                    if (this.isWindowCheck)
                    {
                        check.MinQty = 0;               //[盘点最小数量
                        check.PackQty = 0;              //[盘点包装数量
                    }

                    if (this.AddDataToTable(check) == -1)
                    {
                        return -1;
                    }

                    this.hsCheck.Add(check.Item.ID + check.BatchNO + check.PlaceNO, check);
                }
            }
            catch (Exception ex)
            {
                Function.ShowMsg(ex.Message);
                return -1;
            }
            finally
            {
                this.SetFlag();

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            return 1;
        }

        /// <summary>
        /// 清空列表  
        /// </summary>
        public void Clear()
        {
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();

            this.hsCheck.Clear();

            this.nowOperCheckNO = "";
            this.newCheckNO = "";

            this.txtFilter.Text = "";

            this.neuLbTotalCost.Text = "0";
            this.neuLbWinCost.Text = "0";
            this.neuLbLoseCost.Text = "0";
        }

        /// <summary>
        /// 删除一条封帐记录
        /// </summary>
        public void DeleteData()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0) 
                return;

            DialogResult result;
            //提示用户是否确认删除
            result = MessageBox.Show(Language.Msg("确认删除当前记录?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

            if (result == DialogResult.No)
            {
                return;
            }

            this.neuSpread1.StopCellEditing();

            int iRemove = this.neuSpread1_Sheet1.ActiveRowIndex;

            string key = this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.DrugNO].Text +
                this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.BatchNO].Text +
                this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.PlaceNO].Text;

            //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            //吕山勇当删除一行时，把盈亏金额中的数值给减去
            if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text) > 0)
            {
                this.neuLbWinCost.Text = (NConvert.ToDecimal(this.neuLbWinCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            else
            {
                this.neuLbLoseCost.Text = (NConvert.ToDecimal(this.neuLbLoseCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();

            if (this.hsCheck.ContainsKey(key))
                this.hsCheck.Remove(key);
            
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);

            this.neuSpread1.StartCellEditing(null, false);
        }

        /// <summary>
        /// 获取所有盘点数据打印
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAllData()
        {
            ArrayList alDetail = new ArrayList();

            this.dt.DefaultView.RowFilter = "1=1";
            foreach (DataRow dr in this.dt.Rows)
            {
                Neusoft.HISFC.Models.Pharmacy.Check check = this.GetDataFromTable(dr);
                if (check == null)
                {
                    MessageBox.Show(Language.Msg("由数据表内获取Check实体失败"));
                    return null;
                }

                check.StockDept = this.privDept;        //科室

                alDetail.Add(check);
            }

            return alDetail;
        }

        /// <summary>
        /// 获取当前发生变化的数据，返回Check动态数组
        /// </summary>
        /// <param name="flag">检索标志Modify(增加、更新)、Del(删除)</param>
        /// <returns>成功返回发生变动的数组、失败返回null</returns>
        private ArrayList GetModify(string flag)
        {
            this.dt.DefaultView.RowFilter = "1=1";
            for (int i = 0; i < this.dt.DefaultView.Count; i++)
            {
                this.dt.DefaultView[i].EndEdit();
            }

            DataTable dtChange = new DataTable();
            switch (flag)
            {
                case "Modify":		//获取变动(增加、修改)数据
                    dtChange = this.dt.GetChanges(DataRowState.Added | DataRowState.Modified);
                    break;
                case "Del":			//获取删除数据
                    dtChange = this.dt.GetChanges(DataRowState.Deleted);
                    break;
                default:
                    return null;
            }
            //无变动数据
            if (dtChange == null)
                return null;

            ArrayList alDetail = new ArrayList();

            //对于删除数据，回滚变化
            if (flag == "Del")
            {
                dtChange.RejectChanges();
            }

            string errDrug = "";
            try
            {
                //获得数据加入Check盘点实体
                foreach (DataRow dr in dtChange.Rows)
                {
                    errDrug = dr["药品编码"].ToString() + dr["商品名称"].ToString();

                    if (flag == "Del" && dr["流水号"].ToString() == "")
                        return null;

                    Neusoft.HISFC.Models.Pharmacy.Check check = this.GetDataFromTable(dr);

                    if (check == null)
                    {
                        MessageBox.Show(Language.Msg("由数据表内获取Check实体失败"));
                        return null;
                    }

                    check.StockDept = this.privDept;        //科室

                    alDetail.Add(check);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message + "\n " + errDrug));
                return null;
            }

            return alDetail;
        }

        /// <summary>
        ///对封帐、盘点过程进行保存，更新盘点明细表
        /// </summary>
        /// <param name="deptNO">库房编码</param>
        /// <param name="checkNO">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Save(string deptNO, string checkNO)
        {
            if (this.dt.Rows.Count <= 0)
            {
                return 0;
            }

            if (this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.SumCheckNumAndCost( this.neuSpread1_Sheet1.ActiveRowIndex );
            }

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            string errDrug = "";

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存.请稍候...");
            Application.DoEvents();

            try
            {
                //盘点单号
                if (checkNO != "" && checkNO != null)
                {
                    Neusoft.HISFC.Models.Pharmacy.Check check = this.itemManager.GetCheckStat(deptNO, checkNO);
                    if (check == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(Language.Msg("根据盘点单号获取盘点单统计信息发生错误"));
                        return -1;
                    }
                    if (check.State != "0")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg(Language.Msg("盘点单已结存或解封 请退出重试"));
                        return -1;
                    }
                }

                //对新建盘点单向盘点统计表插入数据
                if (checkNO == "" || checkNO == null)
                {
                    #region 对新建盘点单向盘点统计表插入数据

                    if (this.newCheckNO != "")
                    {	//当封帐后两次点击保存时，不重新取盘点单号及插入盘点统计表
                        checkNO = this.newCheckNO;
                    }
                    else
                    {
                        //获取新盘点单号
                        checkNO = this.itemManager.GetCheckCode(deptNO);
                        if (checkNO == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("获取新盘点单号失败" + this.itemManager.Err);
                            return -1;
                        }

                        //保存新生成的盘点单号
                        this.newCheckNO = checkNO;
                       
                        Neusoft.HISFC.Models.Pharmacy.Check info = new Neusoft.HISFC.Models.Pharmacy.Check();

                        info.CheckNO = checkNO;				            //盘点单号
                        info.StockDept = this.privDept;			        //库房编码
                        info.State = "0";					            //封帐状态
                        info.User01 = "0";						        //盘亏金额
                        info.User02 = "0";						        //盘盈金额

                        info.FOper.ID = this.itemManager.Operator.ID;   //封帐人
                        info.FOper.OperTime = sysTime;				    //封帐时间
                        info.Operation.Oper = info.FOper;               //操作人

                        if (this.itemManager.InsertCheckStatic(info) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("添加盘点统计表失败" + this.itemManager.Err);
                            return -1;
                        }
                    }

                    #endregion
                }

                //DataSet内获得发生变动的数据
                ArrayList modifyList = this.GetModify("Modify");
                ArrayList delList = this.GetModify("Del");

                if (modifyList != null)
                {
                    #region 对发生变动的记录进行更新

                    foreach (Neusoft.HISFC.Models.Pharmacy.Check info in modifyList)
                    {
                        errDrug = info.Item.Name;

                        info.CheckNO = checkNO;			                        //盘点单号
                        info.State = "0";				                        //盘点状态 封帐

                        info.Operation.Oper.ID = this.itemManager.Operator.ID;   //操作信息
                        info.Operation.Oper.OperTime = sysTime;			        //操作时间

                        //对新增数据该字段（流水号）由FarPoint取到的为空，设为－1
                        if (info.ID == "")
                        {
                            info.ID = "-1";
                        }

                        //先进行更新操作，如更新失败则插入
                        int parm = this.itemManager.UpdateCheckDetail(info);
                        //对盘点明细表更新数据
                        if (parm == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("更新盘点明细时出错" + this.itemManager.Err);
                            return -1;
                        }
                        else
                        {
                            if (parm == 0)
                            {
                                //对盘点明细表插入数据
                                if (this.itemManager.InsertCheckDetail(info) != 1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    Function.ShowMsg("添加盘点明细时出错" + this.itemManager.Err);
                                    return -1;
                                }
                            }
                        }

                        //插入盘点日志{0A34566D-E154-47a4-BCB1-2437CC877F63}
                        parm = this.checkLogManager.InsertCheckLogs(info);
                        if (parm < 0) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("插入盘点日志出错!" + this.checkLogManager.Err);

                            return -1;
                        }//{0A34566D-E154-47a4-BCB1-2437CC877F63}本段添加完毕
                    }
                    #endregion
                }
                if (delList != null)
                {		
                    #region 对删除的记录进行删除

                    foreach (Neusoft.HISFC.Models.Pharmacy.Check info in delList)
                    {
                        //对盘点明细记录删除
                        if (this.itemManager.DeleteCheckDetail(info.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("删除盘点明细时出错" + this.itemManager.Err);
                            return -1;
                        }
                    }
                    #endregion
                }

                //计算盘点盈亏更新盈亏数量、盈亏标记
                if (this.itemManager.SaveCheck(deptNO, checkNO) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("更新实际盘存数量时出错" + this.itemManager.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg(ex.Message + "  \n" + errDrug);
                return -1;
            }

            //提交事务
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("保存成功");

            return 1;
        }

        /// <summary>
        ///对封帐、盘点过程进行增量保存，更新盘点明细表
        /// </summary> 
        /// <returns>成功返回1 失败返回－1</returns>
        public int AddSave(string deptNO, string chekNO)
        {
            if (this.dt.Rows.Count <= 0)
                return 0;

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            string errDrug = "";

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存.请稍候...");
            Application.DoEvents();

            try
            {
                ArrayList modifyList = this.GetModify("Modify");

                if (modifyList != null)
                {
                    #region 对发生变动的记录进行更新

                    foreach (Neusoft.HISFC.Models.Pharmacy.Check info in modifyList)
                    {
                        errDrug = info.Item.Name;
				
                        info.CheckNO = chekNO;			        //盘点单号		
                        info.State = "0";				        //盘点状态 封帐

                        info.Operation.Oper.ID = this.itemManager.Operator.ID;	//操作人
                        info.Operation.Oper.OperTime = sysTime;			        //操作时间
                        info.CStoreQty = info.AdjustQty;

                        //对盘点明细表更新数据						
                        int parm = this.itemManager.UpdateCheckDetailAddSave(info);
                        if (parm == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Function.ShowMsg("更新盘点明细时出错" + this.itemManager.Err);
                            return -1;
                        }
                    }

                    //计算盘点盈亏更新盈亏数量、盈亏标记
                    if (this.itemManager.SaveCheck(deptNO, chekNO) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Function.ShowMsg("更新实际盘存数量时出错" + this.itemManager.Err);
                        return -1;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg(ex.Message + "  \n" + errDrug);
                return -1;
            }

            //提交事务
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在导出数据...请稍候");
            Application.DoEvents();

            this.AutoExport();

            this.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            MessageBox.Show(Language.Msg("保存成功"), "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return 1;
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

                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel 工作薄 (*.xls)|*.*";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在导出 请稍候...");
                    Application.DoEvents();

                    fileName = dlg.FileName;
                    this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
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
        /// 将当前查询内容按Excel格式自动导出
        /// </summary>
        public void AutoExport()
        {
            try
            {
                this.dt.DefaultView.RowFilter = "1=1";

                DateTime dt = this.itemManager.GetDateTimeFromSysDateTime();

                string fileDir = @"c:\Check";
                if (!System.IO.Directory.Exists(fileDir))
                    System.IO.Directory.CreateDirectory(fileDir);
                string fileName = @"c:\Check\" + dt.ToString("MMdd-HHmm-ss") + ".xls";

                this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private void Filter()
        {
            if (this.dt.DefaultView == null)
                return;

            //获得过滤条件
            string queryCode = "";
            if (this.ckFlur.Checked)		//模糊查询
                queryCode = "%" + this.txtFilter.Text.Trim() + "%";
            else
                queryCode = this.txtFilter.Text.Trim() + "%";
            //支持大小写检索 {64F88CE9-5A49-442a-8264-EDBECCFE4CA9} wbo 20100929
            try
            {
                queryCode = queryCode.ToUpper();
            }
            catch (Exception e)
            { }

            try
            {               
                this.dt.DefaultView.RowFilter = Function.GetFilterStr(this.dt.DefaultView, queryCode);

                this.SetFlag();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 盘点库存与盘点金额计算
        /// </summary>
        private void SumCheckNumAndCost(int rowIndex)
        {
            //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D}  记录原始封帐库存量
            decimal originalCheckQty = NConvert.ToDecimal( this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckQty].Text );

            //盘点包装数量
            decimal iPackNum = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.PackNum].Text);
            //盘点最小数量
            decimal jMinNum = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.MinNum].Text);
            //包装数量
            decimal kPackQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.DrugPackQty].Text);
            //零售价
            decimal price = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.RetailPrice].Text);

            //封账库存吕山勇添加临时变量的lFStoreQty
            //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            decimal lFSoreQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.FStoreQty].Text);

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckQty].Text = (iPackNum * kPackQty + jMinNum).ToString();	//盘点库存
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost].Text = Math.Round((iPackNum + jMinNum / kPackQty) * price, 2).ToString();

            // {B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示吕山勇添加一下四行
            //用原来的总金额减去更改项的金额
            if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text) > 0)
            {
                this.neuLbWinCost.Text = (NConvert.ToDecimal(this.neuLbWinCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            else
            {
                this.neuLbLoseCost.Text = (NConvert.ToDecimal(this.neuLbLoseCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            //实现回车时可以更新盈亏总额、盈亏数量、盈亏金额的更改
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCount].Text = (iPackNum * kPackQty + jMinNum - lFSoreQty).ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text = Math.Round((iPackNum * kPackQty + jMinNum - lFSoreQty) / kPackQty * price, 2).ToString();
            //用减过的金额再加上更改后的金额得到最后的金额
            if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text) > 0)
            {
                this.neuLbWinCost.Text = (NConvert.ToDecimal(neuLbWinCost.Text) + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            else
            {
                this.neuLbLoseCost.Text = (NConvert.ToDecimal(neuLbLoseCost.Text) + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            }
            this.neuLbTotalCost.Text = Math.Round(Convert.ToDecimal(neuLbTotalCost.Text) + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text), 2).ToString();

            #region 批量盘点检索速度和全盘速度慢甚至死机的问题 {17261296-ABFC-45d5-AD3A-D772B905C8CA} wbo 2010-09-28
            //this.SetFlag();
            if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckQty].Text) > NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.FStoreQty].Text))
            {
                this.neuSpread1_Sheet1.Rows[rowIndex].ForeColor = System.Drawing.Color.Blue;
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckFlag].Text = "1";
            }
            else if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckQty].Text) < NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.FStoreQty].Text))
            {
                this.neuSpread1_Sheet1.Rows[rowIndex].ForeColor = System.Drawing.Color.Red;
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckFlag].Text = "2";
            }
            else
            {
                this.neuSpread1_Sheet1.Rows[rowIndex].ForeColor = System.Drawing.Color.Black;
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckFlag].Text = "0";
            }
            #endregion

            #region {F2DA66B0-0AB4-4656-BB21-97CB731ABA4D}  更新封帐数量、统计盘点期间的入出库盈亏

            decimal newCheckQty = NConvert.ToDecimal( this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckQty].Text );

            if (originalCheckQty != newCheckQty)            //盘点数量发生变化时
            {
                string drugNO = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.DrugNO].Text;
                string batchNO = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.BatchNO].Text;
                string placeNO = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.PlaceNO].Text;

                string key = drugNO + batchNO + placeNO;

                if (this.hsCheck.ContainsKey( key ))
                {
                    Neusoft.HISFC.Models.Pharmacy.Check info = this.hsCheck[key] as Neusoft.HISFC.Models.Pharmacy.Check;
                    if (info != null)
                    {
                        if (info.IsAdd == true)       //附加药品 更新封帐数量时需要找到主项目
                        {
                            #region 附加药品的处理

                            for (int i = rowIndex + 1; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                            {
                                drugNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.DrugNO].Text;
                                batchNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.BatchNO].Text;
                                placeNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.PlaceNO].Text;
                                key = drugNO + batchNO + placeNO;

                                Neusoft.HISFC.Models.Pharmacy.Check temp = this.hsCheck[key] as Neusoft.HISFC.Models.Pharmacy.Check;
                                if (temp.Item.ID == info.Item.ID && temp.BatchNO == info.BatchNO)
                                {
                                    if (temp.IsAdd == false)            //非附加药品
                                    {
                                        rowIndex = i;
                                        info = temp;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            for (int i = rowIndex - 1; i >= 0; i--)
                            {
                                drugNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.DrugNO].Text;
                                batchNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.BatchNO].Text;
                                placeNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.PlaceNO].Text;
                                key = drugNO + batchNO + placeNO;

                                Neusoft.HISFC.Models.Pharmacy.Check temp = this.hsCheck[key] as Neusoft.HISFC.Models.Pharmacy.Check;
                                if (temp.Item.ID == info.Item.ID && temp.BatchNO == info.BatchNO)
                                {
                                    if (temp.IsAdd == false)
                                    {
                                        rowIndex = i;
                                        info = temp;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                        #endregion
                        }

                        if (this.isUpdateFStoreRealTime == false)
                        {
                            //获取当前库存
                            decimal storageNum = 0;
                            batchNO = info.BatchNO == "ALL" ? null : info.BatchNO;

                            if (this.itemManager.GetStorageNum( this.privDept.ID, info.Item.ID, batchNO, out storageNum ) == -1)
                            {
                                MessageBox.Show( "计算封帐库存发生错误" + this.itemManager.Err );
                                return;
                            }

                            info.FStoreQty = storageNum;
                            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.FStoreQty].Text = storageNum.ToString();
                        }

                        //入出库总量计算
                        decimal inoutQty = 0;
                        if (this.itemManager.ComputeInOutQty( this.privDept.ID, info.Item.ID, this.currentBillBeginCheckDate, out inoutQty ) == -1)
                        {
                            MessageBox.Show( "计算盘点期间入出库总量发生错误" + this.itemManager.Err );
                            return;
                        }
                        if (inoutQty != 0)
                        {
                            this.neuSpread1_Sheet1.RowHeader.Rows[rowIndex].BackColor = System.Drawing.Color.RosyBrown;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.RowHeader.Rows[rowIndex].BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 开始盘点时间记录
        /// 
        /// {F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 
        /// </summary>
        private void RecordCheckTime()
        {
            DateTime sysDate = this.itemManager.GetDateTimeFromSysDateTime();

            Neusoft.HISFC.Models.Base.ExtendInfo info = new Neusoft.HISFC.Models.Base.ExtendInfo();
            info.ExtendClass = Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT;
            info.Item.ID = this.privDept.ID + "-" + this.nowOperCheckNO;
            info.PropertyCode = "BeginCheck";
            info.PropertyName = "开始盘点时间";

            info.DateProperty = sysDate;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.FrameWork.Management.ExtendParam extendParamManager = new ExtendParam();                    

            if (extendParamManager.DeleteComExtInfo( Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, info.Item.ID, info.PropertyCode ) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( "删除开始盘点时间记录信息发生错误" + extendParamManager.Err );
                return;
            }

            if (extendParamManager.InsertComExtInfo( info ) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( "生成开始盘点时间记录信息发生错误" + extendParamManager.Err );
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show( "时间记录成功" );
        }

        /// <summary>
        /// 根据封帐库存更新盘点库存
        /// </summary>
        protected void FstoreSetAStore()
        {
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            foreach (DataRow dr in this.dt.Rows)
            {
                int fsQty = Neusoft.FrameWork.Function.NConvert.ToInt32(dr["封帐库存"]);
                int packQty = Neusoft.FrameWork.Function.NConvert.ToInt32(dr["包装数量"]);
                int checkMinQty = 0;
                int checkPackQty = System.Math.DivRem(fsQty, packQty, out checkMinQty);

                dr["盘点数量1"] = checkPackQty.ToString();
                dr["盘点数量2"] = checkMinQty.ToString();

                dr["盘点库存"] = dr["封帐库存"];
            }

            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.SumCheckNumAndCost(i);
            }
        }

        /// <summary>
        /// 可以按药品性质维护药品是否按批次盘点
        /// {98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
        /// </summary>
        /// <param name="drugCode"></param>
        private int SetBatchCheckFlag(string drugCode)
        {
            if (this.isBatchInitial && this.isBatch)
            {
                return 1;
            }
            Neusoft.HISFC.Models.Pharmacy.Item drugItem = this.hsItem[drugCode] as Neusoft.HISFC.Models.Pharmacy.Item;
            string quality = drugItem.Quality.ID;
            if (this.dt.Rows.Count > 0 && this.isBatch != this.htSpecialCheck.ContainsKey(quality))
            {
                MessageBox.Show("已填加的药品" + (this.isBatch ? "按批号盘点" : "不按批号盘点") + "，不能加入不同盘点方式的药品");
                return -1;
            }
            this.isBatch = this.htSpecialCheck.ContainsKey(quality);
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.BatchNO].Visible = this.isBatch;
            return 1;
        }

        #endregion

        #region 结存/解封

        /// <summary>
        /// 对封帐盘点单进行解封处理
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CancelCheck(string deptNO, string checkNO)
        {
            //如当前点击无数据则返回
            if (this.dt.Rows.Count == 0)
            {
                return -1;
            }

            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show(Language.Msg("确认进行解封操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行解封处理.请稍候...");
            Application.DoEvents();
            try
            {
                int i = this.itemManager.CancelCheck(deptNO, checkNO);
                //解封未成功返回
                if (i == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("解封操作失败" + this.itemManager.Err);
                    return -1;
                }
                if (i == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("数据发生变化请刷新！" + this.itemManager.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg("解封操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("解封操作成功");

            return 1;
        }

        /// <summary>
        /// 对盘点进行结存操作
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1、失败返回－1</returns>
        public int CheckCStore(string deptNO, string checkNO)
        {
            //如当前点击无数据则返回
            if (this.dt.Rows.Count == 0)
            {
                return -1;
            }

            //获取是否按批号盘点;获取当前显示的盘点单是否按批号盘点，当前通过明细表内批号字段判断，以后可在统计表内加字段
            bool isBatch;
            DataRow row = this.dt.Rows[0];
            if (row["批号"].ToString() == "ALL")
                isBatch = false;
            else
                isBatch = true;

            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show(Language.Msg("确认进行结存操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行结存处理.请稍候...");
            Application.DoEvents();
            try
            {
                if (this.itemManager.ExecProcedurgCheckCStore(deptNO, checkNO, isBatch) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("结存操作失败" + this.itemManager.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg("结存操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Function.ShowMsg("结存操作成功");

            return 1;
        }

        #endregion

        #region 事件

        private void ucCheckManager_Load(object sender, EventArgs e)
        {
            this.InitDataTable();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                this.InitData();

                this.InitCheckList();

                //{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}根据不同药品性质按批次盘点
                this.InitSpecialCheck();

                this.SetToolButton(true);

                //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 盘点期间入出库明细信息显示
                this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler( neuSpread1_CellDoubleClick );
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                this.isUpdateFStoreRealTime = ctrlIntegrate.GetControlParam<bool>( Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Check_UpdateFStore_RealTime, true, false );
                //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 
                
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                //该变量为静态量，避免别的地方曾经有赋值。保险
                Function.IPrint = null;
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D}  增加明细数据显示
            if (e.RowHeader)
            {
                if (this.neuSpread1_Sheet1.RowHeader.Rows[e.Row].BackColor == System.Drawing.Color.RosyBrown)
                {
                    string drugCode = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.DrugNO].Text;

                    DataSet ds = this.itemManager.ComputeInOutDetailForCheck( this.privDept.ID, drugCode, this.currentBillBeginCheckDate );
                    if (ds != null)
                    {
                        using (Neusoft.FrameWork.WinForms.Controls.ucBaseControl uc = new Neusoft.FrameWork.WinForms.Controls.ucBaseControl())
                        {
                            uc.Width = 500;
                            uc.Height = 300;
                            
                            FarPoint.Win.Spread.SheetView sv = new FarPoint.Win.Spread.SheetView();
                            sv.DataSource = ds;
                            sv.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
                            sv.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;

                            Neusoft.FrameWork.WinForms.Controls.NeuSpread fs = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
                            fs.Sheets.Add( sv );

                            fs.BackColor = System.Drawing.Color.White;
                            

                            fs.Dock = DockStyle.Fill;

                            uc.Controls.Add( fs );

                            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( uc );
                        }
                    }
                }
            }
        }     

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                return;
            }

            if (e.KeyData == Keys.Up)
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.neuSpread1.Focus();
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.PackNum;
            }
        }

        // 在输入盘点数量1、盘点数量2后计算盘点库存
        private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Column == (int)ColumnSet.PackNum || e.Column == (int)ColumnSet.MinNum)
            {
                this.SumCheckNumAndCost(e.Row);                
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:

                    #region 回车跳转

                    if (this.neuSpread1.ContainsFocus)
                    {
                        int i = this.neuSpread1_Sheet1.ActiveRowIndex;
                        int j = this.neuSpread1_Sheet1.ActiveColumnIndex;
                        if (j == (int)ColumnSet.MinNum || j == (int)ColumnSet.PackNum)
                        {
                            if (j == (int)ColumnSet.PackNum)
                            {
                                this.neuSpread1_Sheet1.SetActiveCell(i, (int)ColumnSet.MinNum, false);
                            }
                            else
                            {
                                if (j == (int)ColumnSet.MinNum)
                                {
                                    if (i < this.neuSpread1_Sheet1.Rows.Count - 1)
                                    {
                                        this.neuSpread1_Sheet1.ActiveRowIndex++;
                                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.PackNum, false);
                                    }
                                    else
                                    {
                                        this.txtFilter.Focus();
                                        this.txtFilter.SelectAll();
                                    }
                                }
                            }

                            this.SumCheckNumAndCost(i);
                        }
                    }

                    #endregion

                    break;
                case Keys.F5:

                    this.txtFilter.Focus();
                    this.txtFilter.SelectAll();

                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.HISFC.Models.Pharmacy.Check check = e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.Check;
                
                //{F2DA66B0-0AB4-4656-BB21-97CB731ABA4D} 增加开始盘点时间记录
                Neusoft.FrameWork.Management.ExtendParam extendParamManager = new ExtendParam();
                this.currentBillBeginCheckDate = extendParamManager.GetComExtInfoDateTime( Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, "BeginCheck", this.privDept.ID + "-" + check.CheckNO );
                if (this.currentBillBeginCheckDate == System.DateTime.MinValue)
                {
                    this.currentBillBeginCheckDate = check.FOper.OperTime;
                }

                this.nowOperCheckNO = check.CheckNO;

                this.ShowCheckDetail(this.privDept.ID, check.CheckNO);
            }
        }

        #endregion

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.Clear();
            
            if (e != null && e.Parent != null)
            {
                Neusoft.HISFC.Models.Pharmacy.Check check = e.Tag as Neusoft.HISFC.Models.Pharmacy.Check;

                this.nowOperCheckNO = check.CheckNO;

                this.ShowCheckDetail(this.privDept.ID, check.CheckNO);
            }
            return base.OnSetValue(neuObject, e);
        }

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (activeRow < 0)
                return;

            string drugCode = sv.Cells[activeRow, 0].Text;
            string batchNo = sv.Cells[activeRow, 3].Text;
            string placeCode = sv.Cells[activeRow, 4].Text;

            //可以按药品性质维护药品是否按批次盘点{98F0BF7A-5F41-4de3-884F-B38E71B41A8C}
            if (this.SetBatchCheckFlag(drugCode) < 0)
            {
                return;
            }

            this.AddCheckData(this.privDept.ID,drugCode, batchNo, placeCode, this.isBatch);
            //吕山勇调用了SetFlag()
            //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            this.SetFlag();
        }

        #region 数组排序

        public class NoSort : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                Neusoft.HISFC.Models.Pharmacy.Check c1 = x as Neusoft.HISFC.Models.Pharmacy.Check;
                Neusoft.HISFC.Models.Pharmacy.Check c2 = y as Neusoft.HISFC.Models.Pharmacy.Check;

                return NConvert.ToInt32(c1.ID) - NConvert.ToInt32(c2.ID);
            }

            #endregion
        }

        #endregion

        #region 列设置

        private enum ColumnSet
        {
            /// <summary>
            /// 货位号		
            /// </summary>
            PlaceNO,        
            /// <summary>
            /// 自定义码	
            /// </summary>
            UserCode,
            /// <summary>
            /// 商品名称	
            /// </summary>
            TradeName,
            /// <summary>
            /// 规格		
            /// </summary>
            Specs,
            /// <summary>
            /// 包装数量
            /// </summary>
            DrugPackQty,
            /// <summary>
            /// 批号		
            /// </summary>
            BatchNO,
            /// <summary>
            /// 有效期		
            /// </summary>
            ValidDate,
            /// <summary>
            /// 零售价		
            /// </summary>
            RetailPrice,          
            /// <summary>
            /// 盘点数量1 包装数量	
            /// </summary>
            PackNum,
            /// <summary>
            /// 包装单位	
            /// </summary>
            PackUnit,
            /// <summary>
            /// 盘点数量2 最小单位	
            /// </summary>
            MinNum,
            /// <summary>
            /// 最小单位	
            /// </summary>
            MinUnit,
            /// <summary>
            /// 盘点库存
            /// </summary>
            CheckQty,
            /// <summary>
            /// 封帐库存	
            /// </summary>
            FStoreQty,
            /// <summary>
            /// 单位 最小单位
            /// </summary>
            CheckUnit,
            /// <summary>
            /// 盘点金额
            /// </summary>
            CheckCost,
            /// <summary>
            /// 盈亏数量     //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            /// </summary>
            CheckCount,//lvshy
            /// <summary>
            /// 盈亏金额     //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
            /// </summary>
            CheckCost1,//lvshy
            /// <summary>
            /// 备注
            /// </summary>
            Memo,
            /// <summary>
            /// 盈亏标记 0 无盈亏 1 盘赢 2 盘亏
            /// </summary>
            CheckFlag,
            /// <summary>
            /// 是否附加	
            /// </summary>
            IsAdd,
            /// <summary>
            /// 流水号	
            /// </summary>
            CheckNO,
            /// <summary>
            /// 药品编码	
            /// </summary>
            DrugNO,
            /// <summary>
            /// 拼音码		
            /// </summary>
            SpellCode,
            /// <summary>
            /// 五笔码		
            /// </summary>
            WBCode,
            /// <summary>
            /// 通用名拼音码
            /// </summary>
            RegularSpell,
            /// <summary>
            /// 通用名五笔码
            /// </summary>
            RegularWB
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

        bool isPreArrange = false;

        public int PreArrange()
        {
            this.isPreArrange = true;

            string class2Priv = "0305";
            //根据结存按钮所处位置判断窗口类型 显示结存时 盘点结存 否则 盘点管理 
            if (this.toolBarService.GetToolButton("结存").Owner != null && this.toolBarService.GetToolButton("结存").Owner.Visible)      //结存
            {
                class2Priv = "0306";            //盘点结存
            }
            else
            {
                class2Priv = "0305";            //盘点管理
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

            //if (this.isCheckPartition)
            //{
            //    base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name + "－ 盘点分区录入");
            //}
            //else
            //{
            //    base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);
            //}

            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            return 1;
        }

        #endregion
    }
}
