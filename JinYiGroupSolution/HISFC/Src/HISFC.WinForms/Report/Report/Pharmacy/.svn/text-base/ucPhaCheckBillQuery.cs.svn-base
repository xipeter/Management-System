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

namespace Neusoft.WinForms.Report.Pharmacy
{
    /**
     *  CheckFlag 0 无盈亏 1 盘盈 2 盘亏
     * 
     **/
    /// <summary>
    /// [功能描述: 药品盘点单查询]<br>分盈亏盘点单</br>
    /// [创 建 者: sel]<br></br>
    /// [创建时间: 2009-07]<br></br> 
    /// </summary>
    public partial class ucPhaCheckBillQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer,
                                            Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucPhaCheckBillQuery()
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
        /// 药品信息
        /// </summary>
        private System.Collections.Hashtable hsItem = new Hashtable();

        /// <summary>
        /// 盘点实体信息
        /// </summary>
        private System.Collections.Hashtable hsCheck = new Hashtable();

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        private bool isAllowEdit = true;

        /// <summary>
        /// 新盘点单号
        /// </summary>
        private string newCheckNO = "";

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
        /// 历史盘点单获取状态 0 封帐 1 结存 2 解封
        /// </summary>
        private string historyListState = "1";

        /// <summary>
        /// 是否按货位号排序盘点单
        /// </summary>
        private bool isSortByPlaceCode = true;
        #region {CFF57829-C650-458d-A7D9-C60EC5DD6A82}
        private Neusoft.FrameWork.Public.ObjectHelper ohItemType = new Neusoft.FrameWork.Public.ObjectHelper();
        #endregion

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

                //this.SetToolButton(value);
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
            toolBarService.AddToolButton("封帐盘点单", "查询状态为封帐的盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
            toolBarService.AddToolButton("结存盘点单", "查询状态为结存的盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            toolBarService.AddToolButton("取消盘点单", "查询状态为取消的盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            //toolBarService.AddToolButton("历史盘点", "调用历史盘点记录 ", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D查询历史, true, false, null);
            //toolBarService.AddToolButton("盘点附加", "添加盘点附加药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C借入, true, false, null);
            //toolBarService.AddToolButton("盘 点 单", "显示盘点单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            //toolBarService.AddToolButton("增量保存", "增量保存盘点信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.O安排, true, false, null);
            //toolBarService.AddToolButton("删    除", "删除当前选择药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A删除, true, false, null);
            //toolBarService.AddToolButton("全    盘", "根据当前封帐库存更新盘点库存", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C借出, true, false, null);

            //toolBarService.AddToolButton("结存", "按照盘点库存更新当前库存 处理盈亏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            //toolBarService.AddToolButton("解封", "作废当前盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A注销, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "封帐盘点单")
            {
                //this.CheckCStore(this.privDept.ID, this.nowOperCheckNO);

                this.ShowCheckList("0");
            }
            if (e.ClickedItem.Text == "结存盘点单")
            {
                //this.CancelCheck(this.privDept.ID, this.nowOperCheckNO);

                this.ShowCheckList("1");
            }
            if (e.ClickedItem.Text == "取消盘点单")
            {
                //this.CancelCheck(this.privDept.ID, this.nowOperCheckNO);

                this.ShowCheckList("2");
            }
            base.ToolStrip_ItemClicked(sender, e);
        }



        public override int Export(object sender, object neuObject)
        {
            this.neuSpread1.Export();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (Neusoft.HISFC.Components.Pharmacy.Function.IPrint == null)
            {
                Neusoft.HISFC.Components.Pharmacy.Function.IPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;
            }

            if (Neusoft.HISFC.Components.Pharmacy.Function.IPrint != null)
            {
                Neusoft.HISFC.Components.Pharmacy.Function.IPrint.SetData(this.GetAllData(), Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.Check);

                Neusoft.HISFC.Components.Pharmacy.Function.IPrint.Print();
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
            this.toolBarService.SetToolButtonEnabled("封帐盘点单", !isShowList);
            this.toolBarService.SetToolButtonEnabled("结存盘点单", isShowList);
            this.toolBarService.SetToolButtonEnabled("取消盘点单", isShowList);

        }

        #endregion

        #region 盘点列表初始化

        /// <summary>
        /// 盘点单列表树组件
        /// </summary>
        private Neusoft.HISFC.Components.Pharmacy.Check.tvCheckList tvList = null;

        /// <summary>
        /// 盘点单列表初始化
        /// </summary>
        protected void InitCheckList()
        {
            this.tvList = new Neusoft.HISFC.Components.Pharmacy.Check.tvCheckList();
            this.ucDrugList1.TreeView = this.tvList;

            this.tvList.AfterSelect -= new TreeViewEventHandler(tvList_AfterSelect);
            this.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            this.ucDrugList1.Caption = "盘点单列表";

            this.ShowCheckList("0");

            this.ucDrugList1.ShowTreeView = true;
        }

        /// <summary>
        /// 盘点单列表显示
        /// </summary>
        private void ShowCheckList(string checkState)
        {
            Neusoft.FrameWork.Models.NeuObject operObj = new Neusoft.FrameWork.Models.NeuObject();
            operObj.ID = "ALL";
            operObj.Name = "所有人员";

            this.tvList.ShowCheckList(this.privDept, checkState, operObj);
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
                                                                                    new DataColumn("药品类别",dtStr),
   
                                                                    });
            this.dt.DefaultView.AllowNew = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowDelete = true;

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
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PlaceNO].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.UserCode].Width = 60F;                //自定义码
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.TradeName].Width = 130F;              //商品名称
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Specs].Width = 70F;                   //规格
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.RetailPrice].Width = 60F;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].Width = numWidth;            //盘点数量1
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackNum].Visible = false;             //盘点数量1
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackUnit].Width = unitWidth;          //包装单位
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PackUnit].Visible = false;            //包装单位
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].Width = numWidth;             //盘点数量2
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinNum].Visible = false;              //盘点数量2
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinUnit].Width = unitWidth;           //最小单位
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.MinUnit].Visible = false;             //最小单位

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

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.DrugPackQty].Visible = false;         //包装数量
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Memo].Visible = false;			    //备注
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
            Neusoft.HISFC.BizLogic.Manager.Constant managerConstant = new Neusoft.HISFC.BizLogic.Manager.Constant();

            ohItemType.ArrayObject.Clear();
            ohItemType.ArrayObject = managerConstant.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            ohItemType.ArrayObject.Insert(0, new FrameWork.Models.NeuObject("ALL", "全部", ""));
            this.cmbDrugType.AddItems(ohItemType.ArrayObject);
            this.cmbDrugType.SelectedIndex = 0;
       
            //历史盘点单获取时是否只取结存状态
            this.IsHistoryCStoreState = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Check_History_State, true, true);

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.BatchNO].Visible = this.isBatch;             //批号

            this.ucDrugList1.ShowDeptStorage(this.privDept.ID, this.isBatch, 0);
        }

        /// <summary>
        /// 设置Fp标记
        /// </summary>
        protected void SetFlag()
        {
            try
            {
                //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示吕山勇添加一共三个
                //if (NConvert.ToDecimal(this.neuLbTotalCost.Text) < 0)
                //{
                //    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Red;
                //}
                //else if (NConvert.ToDecimal(this.neuLbTotalCost.Text) > 0)
                //{
                //    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Blue;
                //}
                //else
                //{
                //    this.neuLbTotalCostSign.ForeColor = System.Drawing.Color.Black;
                //}                

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
                                                check.Item.NameCollection.RegularSpell.WBCode,
                       check.Item.Type.ID
              
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
            //this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) + count).ToString();
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

        #endregion

        #region 批量封帐 / 盘点附加

        /// <summary>
        /// 判断是否可以继续进行批量封帐
        /// </summary>
        /// <returns>允许进行</returns>
        //public bool JudgeContinue()
        //{
        //    if (this.neuSpread1_Sheet1.Rows.Count != 0)
        //    {
        //        DialogResult result;
        //        //提示用户选择是否继续生成，如继续生成则将清空原数据
        //        result = MessageBox.Show(Language.Msg("批量封帐将清除当前数据，是否继续"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
        //            MessageBoxOptions.RightAlign);
        //        if (result == DialogResult.No)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// 批量封帐
        /// </summary>
        //protected virtual void GroupCheckCloseType()
        //{
        //    //判断是否允许进行批量封帐
        //    if (!this.JudgeContinue())
        //        return;

        //    this.Clear();

        //    ////弹出选择药品类别、药品性质窗口
        //    HISFC.Components.Pharmacy.Check.ucTypeOrQualityChoose uc = new Neusoft.HISFC.Components.Pharmacy.Check.ucTypeOrQualityChoose(true);
        //    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

        //    switch (uc.ResultFlag)
        //    {
        //        case "0":           //取消
        //            break;
        //        case "1":           //药品类别/药品性质
        //            this.CheckCloseByType(this.privDept.ID, uc.DrugType, uc.DrugQuality, this.isBatch,uc.IsCheckZeroStock,uc.IsCheckStopDrug);
        //            break;
        //        case "2":           //全部药品封帐
        //            this.CheckCloseByTotal(this.privDept.ID, this.isBatch,uc.IsCheckZeroStock,uc.IsCheckStopDrug);
        //            break;
        //    }
        //}

        /// <summary>
        /// 盘点模版批量封帐
        /// </summary>
        //protected virtual void GroupCheckCloseStencil()
        //{
        //    DialogResult rs = MessageBox.Show(Language.Msg("使用模版将清除当前的数据 是否继续?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //    if (rs == DialogResult.No)
        //        return;

        //    this.Clear();

        //    ArrayList alStencilDetail = Neusoft.HISFC.Components.Pharmacy.Function.c(this.privDept.ID, Neusoft.HISFC.Models.Pharmacy.EnumDrugStencil.Check);
        //    if (alStencilDetail != null && alStencilDetail.Count > 0)
        //    {
        //        System.Collections.Hashtable hsDrugStencil = new Hashtable();
        //        foreach (Neusoft.HISFC.Models.Pharmacy.DrugStencil info in alStencilDetail)
        //        {
        //            hsDrugStencil.Add(info.Item.ID, null);
        //        }

        //        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在根据所选盘点模版进行封帐处理...");
        //        Application.DoEvents();

        //        ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
                
        //        //此处取出的货位号有问题
        //        ArrayList alItem = this.itemManager.QueryStorageList(this.privDept.ID, this.isBatch);

        //        foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alItem)
        //        {
        //            if (hsDrugStencil.ContainsKey(item.ID))
        //            {
        //                this.AddCheckData(this.privDept.ID, item.ID, item.User01, item.User02, this.isBatch);
        //            }
        //        }

        //        ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();

        //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //    }
        //}
        
         ///<summary>
         ///根据历史盘点表封帐 只取结存后的盘点单
         ///</summary>
        protected virtual void GroupCheckCloseHistory()
        {
            //if (!this.JudgeContinue())
            //    return;

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

        ///// <summary>
        ///// 盘点附加
        ///// </summary>
        //protected virtual void GroupCheckAdd()
        //{
        //    //当前列表内点击有效的盘点单
        //    if (this.tvList.SelectedNode == null || this.tvList.SelectedNode.Parent == null)
        //        return;

        //    if (this.dt.Rows.Count <= 0)
        //    {
        //        MessageBox.Show(Language.Msg("请先对相应药品进行封帐处理，\n无法直接将盘点附加药品加入盘点单"));
        //        return;
        //    }

        //    HISFC.Components.Pharmacy.Check.ucCheckAdd uc = new ucCheckAdd();

        //    uc.IsShowAddCheckBox = true;
        //    uc.IsShowButton = false;            

        //    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

        //    if (uc.Result == DialogResult.OK)
        //    {
        //        this.AddCheckAdd(uc.ChooseData);
        //    }
        //    else
        //    {
        //        return;
        //    }

        //}

        #endregion

        #region 封帐方法

        /// <summary>
        /// 封帐
        /// </summary>
        //protected void CheckClose()
        //{
        //    this.Clear();

        //    this.IsShowCheckList = false;

        //    this.ucDrugList1.SetFocusSelect();
        //}

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
        //protected int CheckCloseByType(string deptNO, string drugType, string drugQuality, bool isBatch,bool isCheckZeroStock,bool isCheckStopDrug)
        //{
        //    //清除原数据
        //    this.Clear();

        //    try
        //    {	//按照药品类别、药品性质进行封帐
        //        ArrayList alDetail = this.itemManager.CheckCloseByTypeQuality(deptNO, drugType, drugQuality, isBatch,isCheckZeroStock,isCheckStopDrug);
        //        if (alDetail == null)
        //        {
        //            MessageBox.Show(Language.Msg("按照药品类别/性质进行批量封帐失败" + this.itemManager.Err));
        //            return -1;
        //        }

        //        if (alDetail.Count == 0)
        //        {
        //            MessageBox.Show(Language.Msg("该选择类型无库存药品" + this.itemManager.Err));
        //            return -1;
        //        }

        //        this.ShowCheckDetail(alDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(Language.Msg(ex.Message));
        //        return -1;
        //    }
        //    return 1;
        //}

        /// <summary>
        /// 对本库房所有药品进行封帐处理
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <returns>成功返回1 失败返回－1</returns>
        //public int CheckCloseByTotal(string deptNO, bool isBatch,bool isCheckZeroStock,bool isCheckStopDrug)
        //{
        //    //清除原数据
        //    this.Clear();

        //    try
        //    {		
        //        //对所有药品进行封帐处理
        //        ArrayList alDetail = this.itemManager.CheckCloseByTotal(deptNO, isBatch,isCheckZeroStock,isCheckStopDrug);
        //        if (alDetail == null)
        //        {
        //            MessageBox.Show(Language.Msg("对本科室所有库存药品进行批量封帐处理失败" + this.itemManager.Err));
        //            return -1;
        //        }
        //        if (alDetail.Count == 0)
        //        {
        //            MessageBox.Show(Language.Msg("该选择类型无库存药品" + this.itemManager.Err));
        //            return -1;
        //        }

        //        //在FarPoint内显示明细
        //        this.ShowCheckDetail(alDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(Language.Msg("封帐失败！" + ex.Message));
        //        return -1;
        //    }
        //    return 1;
        //}

        /// <summary>
        /// 增加盘点附加信息
        /// </summary>
        /// <param name="alAddDetail"></param>
        /// <returns></returns>
        //protected int AddCheckAdd(List<Neusoft.HISFC.Models.Pharmacy.Check> alAddDetail)
        //{
        //    string errStr = "";
        //    foreach (Neusoft.HISFC.Models.Pharmacy.Check check in alAddDetail)
        //    {
        //        if (this.hsCheck.ContainsKey(check.Item.ID + check.BatchNO + check.PlaceNO))
        //        {
        //            if (errStr == "")
        //                errStr = "存在重复值 已自动屏蔽";
        //            errStr = errStr + check.Item.Name;
        //            continue;
        //        }

        //        bool isHave = false;
        //        foreach (DataRow dr in this.dt.Rows)
        //        {
        //            if (dr["药品编码"].ToString() == check.Item.ID)
        //            {
        //                isHave = true;
        //                break;
        //            }
        //        }
        //        check.Item = this.itemManager.GetItem(check.Item.ID);
        //        if (check.Item == null)
        //        {
        //            MessageBox.Show(Language.Msg("加载药品基本信息时出错" + this.itemManager.Err));
        //            return -1;
        //        }

        //        if (!isHave)
        //        {
        //            MessageBox.Show(Language.Msg("请先对 " + check.Item.Name + " 进行盘点封帐\n无法直接将药品加入盘点单"));
        //            return 0;
        //        }
               
        //        if (this.AddDataToTable(check) == 1)
        //        {
        //            this.hsCheck.Add(check.Item.ID + check.BatchNO + check.PlaceNO, check);
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }

        //    if (errStr != "")
        //    {
        //        MessageBox.Show(Language.Msg(errStr));
        //    }

        //    return 1;
        //}

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
                            Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("加载药品基本信息时出错" + this.itemManager.Err);
                            return -1;
                        }
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
                Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg(ex.Message);
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
        }

        /// <summary>
        /// 删除一条封帐记录
        /// </summary>
        //public void DeleteData()
        //{
        //    if (this.neuSpread1_Sheet1.Rows.Count == 0) 
        //        return;

        //    DialogResult result;
        //    //提示用户是否确认删除
        //    result = MessageBox.Show(Language.Msg("确认删除当前记录?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
        //        MessageBoxOptions.RightAlign);

        //    if (result == DialogResult.No)
        //    {
        //        return;
        //    }

        //    this.neuSpread1.StopCellEditing();

        //    int iRemove = this.neuSpread1_Sheet1.ActiveRowIndex;

        //    string key = this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.DrugNO].Text +
        //        this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.BatchNO].Text +
        //        this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.PlaceNO].Text;

        //    //{B465E3E5-A81C-46f3-B893-13CE12EA7390}  增加盈亏金额的显示
        //    //吕山勇当删除一行时，把盈亏金额中的数值给减去
        //    if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text) > 0)
        //    {
        //        this.neuLbWinCost.Text = (NConvert.ToDecimal(this.neuLbWinCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();
        //    }
        //    else
        //    {
        //        this.neuLbLoseCost.Text = (NConvert.ToDecimal(this.neuLbLoseCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();
        //    }
        //    this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[iRemove, (int)ColumnSet.CheckCost1].Text)).ToString();

        //    if (this.hsCheck.ContainsKey(key))
        //        this.hsCheck.Remove(key);
            
        //    this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);

        //    this.neuSpread1.StartCellEditing(null, false);
        //}

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

            try
            {
                this.dt.DefaultView.RowFilter = Neusoft.HISFC.Components.Pharmacy.Function.GetFilterStr(this.dt.DefaultView, queryCode);
                #region {CFF57829-C650-458d-A7D9-C60EC5DD6A82}
                if (this.cmbDrugType.Text != "全部")
                {
                    if (this.dt.DefaultView.RowFilter.Trim().Length > 0)
                    {
                        this.dt.DefaultView.RowFilter = "药品类别 = '" + this.cmbDrugType.Tag.ToString() + "' and (" + this.dt.DefaultView.RowFilter + " )";
                    }
                    else
                    {
                        this.dt.DefaultView.RowFilter = "药品类别 = '" + this.cmbDrugType.Tag.ToString() + "'";
                    }
                } 
                #endregion
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

            //this.neuLbTotalCost.Text = (NConvert.ToDecimal(this.neuLbTotalCost.Text) - NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text)).ToString();
            //实现回车时可以更新盈亏总额、盈亏数量、盈亏金额的更改
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCount].Text = (iPackNum * kPackQty + jMinNum - lFSoreQty).ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text = Math.Round((iPackNum * kPackQty + jMinNum - lFSoreQty) / kPackQty * price, 2).ToString();
            //用减过的金额再加上更改后的金额得到最后的金额

            //this.neuLbTotalCost.Text = Math.Round(Convert.ToDecimal(neuLbTotalCost.Text) + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.CheckCost1].Text), 2).ToString();

            this.SetFlag();
        }

    
        #endregion

        #region 结存/解封

        /// <summary>
        /// 对封帐盘点单进行解封处理
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        //public int CancelCheck(string deptNO, string checkNO)
        //{
        //    //如当前点击无数据则返回
        //    if (this.dt.Rows.Count == 0)
        //    {
        //        return -1;
        //    }

        //    DialogResult result;
        //    //提示用户选择是否继续
        //    result = MessageBox.Show(Language.Msg("确认进行解封操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
        //        MessageBoxOptions.RightAlign);
        //    if (result == DialogResult.No)
        //    {
        //        return -1;
        //    }

        //    //定义事务
        //    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

        //    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
        //    //t.BeginTransaction();

        //    this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

        //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行解封处理.请稍候...");
        //    Application.DoEvents();
        //    try
        //    {
        //        int i = this.itemManager.CancelCheck(deptNO, checkNO);
        //        //解封未成功返回
        //        if (i == -1)
        //        {
        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //            Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("解封操作失败" + this.itemManager.Err);
        //            return -1;
        //        }
        //        if (i == 0)
        //        {
        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //            Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("数据发生变化请刷新！" + this.itemManager.Err);
        //            return -1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //        Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("解封操作失败" + ex.Message);
        //        return -1;
        //    }

        //    Neusoft.FrameWork.Management.PublicTrans.Commit();

        //    Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("解封操作成功");

        //    return 1;
        //}

        /// <summary>
        /// 对盘点进行结存操作
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1、失败返回－1</returns>
        //public int CheckCStore(string deptNO, string checkNO)
        //{
        //    //如当前点击无数据则返回
        //    if (this.dt.Rows.Count == 0)
        //    {
        //        return -1;
        //    }

        //    //获取是否按批号盘点;获取当前显示的盘点单是否按批号盘点，当前通过明细表内批号字段判断，以后可在统计表内加字段
        //    bool isBatch;
        //    DataRow row = this.dt.Rows[0];
        //    if (row["批号"].ToString() == "ALL")
        //        isBatch = false;
        //    else
        //        isBatch = true;

        //    DialogResult result;
        //    //提示用户选择是否继续
        //    result = MessageBox.Show(Language.Msg("确认进行结存操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
        //        MessageBoxOptions.RightAlign);
        //    if (result == DialogResult.No)
        //    {
        //        return -1;
        //    }

        //    //定义事务
        //    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

        //    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
        //    //t.BeginTransaction();

        //    this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

        //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行结存处理.请稍候...");
        //    Application.DoEvents();
        //    try
        //    {
        //        if (this.itemManager.ExecProcedurgCheckCStore(deptNO, checkNO, isBatch) == -1)
        //        {
        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //            Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("结存操作失败" + this.itemManager.Err);
        //            return -1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //        Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("结存操作失败" + ex.Message);
        //        return -1;
        //    }

        //    Neusoft.FrameWork.Management.PublicTrans.Commit();

        //    Neusoft.HISFC.Components.Pharmacy.Function.ShowMsg("结存操作成功");

        //    return 1;
        //}

        #endregion

        #region 事件

        private void ucCheckManager_Load(object sender, EventArgs e)
        {
            this.InitDataTable();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //string class2Priv = "0305";
                ////根据结存按钮所处位置判断窗口类型 显示结存时 盘点结存 否则 盘点管理 
                //if (this.toolBarService.GetToolButton("结存").Owner != null && this.toolBarService.GetToolButton("结存").Owner.Visible)      //结存
                //{
                //    class2Priv = "0306";            //盘点结存
                //}
                //else
                //{
                //    class2Priv = "0305";            //盘点管理
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

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                this.InitData();

                this.InitCheckList();

                //this.SetToolButton(true);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                //该变量为静态量，避免别的地方曾经有赋值。保险
                Neusoft.HISFC.Components.Pharmacy.Function.IPrint = null;
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
        //private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        //{
        //    if (e.Column == (int)ColumnSet.PackNum || e.Column == (int)ColumnSet.MinNum)
        //    {
        //        this.SumCheckNumAndCost(e.Row);
        //    }
        //}

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
            if (this.toolBarService.GetToolButton("结存盘点单").Owner != null && this.toolBarService.GetToolButton("结存盘点单").Owner.Visible)      //结存
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

        /// <summary>
        /// 设置过滤条件
        /// </summary>
        /// <param name="strCheckFlag">状态为盈亏标记"0"无盈亏，"1"盘盈，"2"盘亏，"all"全部</param>
        /// <returns></returns>
        public void SetFilter(string strCheckFlag)
        {
            string strFilter="";
            switch (strCheckFlag)
            {
                case "0": 
                case "1":
                case "2": strFilter = string.Format("盈亏标记 = '{0}'", strCheckFlag); break;
                case "all":
                default: strFilter = "1=1"; break;
            }

            try
            {
                this.dt.DefaultView.RowFilter = strFilter;

                this.SetFlag();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            this.SetFilter("all");            
        }

        private void btWin_Click(object sender, EventArgs e)
        {
            this.SetFilter("1");
        }

        private void btLose_Click(object sender, EventArgs e)
        {
             this.SetFilter("2");
        }

        #region {CFF57829-C650-458d-A7D9-C60EC5DD6A82}
        private void cmbDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
        } 
        #endregion
    }
}
