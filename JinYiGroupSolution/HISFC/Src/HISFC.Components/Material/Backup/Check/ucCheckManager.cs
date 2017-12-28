using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Material;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material.Check
{
    public partial class ucCheckManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucCheckManager()
        {
            InitializeComponent();
        }

        #region 域
        //定义DataSet
        //private DataSet myDataSet = new DataSet();
        private DataTable myDataTable = new DataTable();

        //private DataView myDataView;

        //Item管理类
        private Neusoft.HISFC.BizLogic.Material.MetItem myItem = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// store管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeMgr = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// ComCompany管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany companyMgr = new Neusoft.HISFC.BizLogic.Material.ComCompany();

        //存储新生成的盘点单号
        //private string newCheckCode = "";

        /// <summary>
        /// 是否允许双击删除
        /// </summary>
        private bool allowDel = false;

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        private bool allowEdit = true;

        /// <summary>
        /// 是否窗口盘点
        /// </summary>
        private bool isWindowCheck = false;

        /// <summary>
        /// 药品信息
        /// </summary>
        private System.Collections.Hashtable hsItem = new Hashtable();

        /// <summary>
        /// 当前操作的科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作单号
        /// </summary>
        private string nowOperCheckNO = "";

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper companyHelper = null;

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper producerHelper = null;

        /// <summary>
        /// 盈亏状态帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper profitHelper = null;

        #endregion

        #region 属性
        /// <summary>
        /// 是否新封帐的盘点单
        /// </summary>
        //public bool IsNewCheckCode
        //{
        //    set
        //    {
        //        if (value)
        //            newCheckCode = "";
        //    }
        //}

        /// <summary>
        /// 是否允许双击删除
        /// </summary>
        public bool AllowDel
        {
            get
            {
                return allowDel;
            }
            set
            {
                this.allowDel = value;
            }
        }
        /// <summary>
        /// 是否允许对盘点数量进行编辑
        /// </summary>
        public bool AllowEdit
        {
            get
            {
                return allowEdit;
            }
            set
            {
                allowEdit = value;
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string LebelTitle
        {
            set
            {
                this.lbTitle.Text = value;
            }
        }
        /// <summary>
        /// 是否窗口盘点
        /// </summary>
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
        /// 是否显示盘点单列表
        /// </summary>
        [Description("是否显示盘点单列表"), Category("设置"), DefaultValue(false)]
        public bool IsShowCheckList
        {
            get
            {
                return this.ucMaterialItemList1.ShowTreeView;
            }
            set
            {
                this.ucMaterialItemList1.ShowTreeView = value;

                this.SetToolButton(value);
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("封    帐", "记录当前库存形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
            toolBarService.AddToolButton("批量封帐", "批量封存形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并, true, false, null);
            //toolBarService.AddToolButton("盘点模版", "调用模版形成盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A组套, true, false, null);
            toolBarService.AddToolButton("历史盘点", "调用历史盘点记录 ", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            //toolBarService.AddToolButton("盘点附加", "添加盘点附加药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C借入, true, false, null);
            toolBarService.AddToolButton("盘 点 单", "显示盘点单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            /// {9ADAD904-B8B5-4f94-88A9-AF690A98D1BF}
            //toolBarService.AddToolButton("增量保存", "增量保存盘点信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.O安排, true, false, null);
            toolBarService.AddToolButton("删    除", "删除当前选择药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("全    盘", "根据当前封帐库存更新盘点库存", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            toolBarService.AddToolButton("结存", "按照盘点库存更新当前库存 处理盈亏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.P盘点结存解封, true, false, null);
            toolBarService.AddToolButton("解封", "作废当前盘点单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "结存")
            {
                this.CheckCStore(this.privDept.ID, this.nowOperCheckNO);

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
            ///{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
            if (e.ClickedItem.Text == "批量封帐")
            {
                this.GroupCheckCloseType();
            }

            //{9ADAD904-B8B5-4f94-88A9-AF690A98D1BF}
            //if (e.ClickedItem.Text == "增量保存")
            //{
            //    this.AddSave(this.privDept.ID, this.nowOperCheckNO);

            //    if (this.tvList.Nodes.Count > 0)
            //        this.tvList.SelectedNode = this.tvList.Nodes[0];
            //}
            ///{E10FCFDC-BE18-40c5-B357-5B4A347B78BE}
            if (e.ClickedItem.Text == "全    盘")
            {
                this.FstoreSetAStore();
            }

            if (e.ClickedItem.Text == "盘 点 单")
            {
                this.ClearData();

                if (!this.IsShowCheckList)
                {
                    this.IsShowCheckList = true;
                }
            }
            if (e.ClickedItem.Text == "封    帐")
            {
                this.CheckClose();
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
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel2);

            return base.OnPrint(sender, neuObject);
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
            //this.toolBarService.SetToolButtonEnabled("盘点附加", isShowList);
            this.toolBarService.SetToolButtonEnabled("封    帐", isShowList);
            ///{9ADAD904-B8B5-4f94-88A9-AF690A98D1BF}
            //this.toolBarService.SetToolButtonEnabled("增量保存", isShowList);
            this.toolBarService.SetToolButtonEnabled("删    除", !isShowList);
            this.toolBarService.SetToolButtonEnabled("批量封帐", !isShowList);
            //this.toolBarService.SetToolButtonEnabled("盘点模版", !isShowList);
            //this.toolBarService.SetToolButtonEnabled("剂型分类", !isShowList);
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
            this.ucMaterialItemList1.TreeView = this.tvList;

            this.tvList.AfterSelect -= new TreeViewEventHandler(tvList_AfterSelect);
            this.tvList.AfterSelect += new TreeViewEventHandler(tvList_AfterSelect);

            this.ucMaterialItemList1.Caption = "盘点单列表";

            this.ShowCheckList();

            this.ucMaterialItemList1.ShowTreeView = true;
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

        //{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
        #region 批量封账

        /// <summary>
        /// 批量封账
        /// </summary>
        protected virtual void GroupCheckCloseType()
        {
            //判断是否允许进行批量封账
            if (this.JudgeContinue() == -1)
            {
                return;
            }

            this.ClearData();

            //弹出选择物资科目窗口
            Neusoft.HISFC.Components.Material.Check.ucTypeOrQualityChoose uc = new ucTypeOrQualityChoose(true);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

            switch (uc.ResultFlag)
            {
                case "0":                    //取消
                    break;
                case "1":                   //物资科目
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在对库存物资进行封账 请稍候...");
                    Application.DoEvents();

                    this.CheckCloseByType(this.privDept.ID, uc.KindType, false, uc.IsCheckZeroStock, uc.IsCheckStopMaterial);

                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    break;
                case "2":                  //全部药品封账
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在对库存物资进行封账 请稍候...");
                    Application.DoEvents();

                    this.CheckCloseByTotal(this.privDept.ID, false, uc.IsCheckZeroStock, uc.IsCheckStopMaterial);

                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    break;
            }
        }

        #endregion

        # region 方法

        /// <summary>
        /// 初始化DataSet
        /// </summary>
        private void InitDataTable()
        {
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBol = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.myDataTable.Columns.AddRange(new DataColumn[] {
																	new DataColumn("盘点流水号",  dtStr),//0
																	new DataColumn("盘点单号",      dtStr),//1
																	new DataColumn("仓库编码",	  dtStr),//2
																	new DataColumn("物品编码",	  dtStr),//3
																	new DataColumn("物品名称",	  dtStr),//4
																	new DataColumn("零售金额",        dtDec),//5
																	new DataColumn("库存序号",	  dtStr),//6
																	new DataColumn("规格",		  dtStr),//7
																	new DataColumn("库位编号",	      dtStr),//8
																	new DataColumn("最近有效期",    dtStr),//9
																	new DataColumn("供货公司",	  dtStr),//10
																	new DataColumn("生产厂家",    dtStr),//11
																	new DataColumn("封帐库存数量",    dtDec),//12
																	new DataColumn("实际盘存数量",    dtDec),//13
																	new DataColumn("结存库存数量",    dtDec),//14
                                                                    new DataColumn("盈亏数量",    dtDec),//15
                                                                    new DataColumn("计量单位",        dtStr),//16
																	new DataColumn("盈亏标记",    dtStr),//17
																	new DataColumn("盘点状态",    dtStr),//18
																	new DataColumn("操作员",    dtStr),//19
																	new DataColumn("操作日期",      dtStr),//20
																	new DataColumn("拼音码",	  dtStr),//21
																	new DataColumn("五笔码",	  dtStr),//22
																	new DataColumn("自定义码",	  dtStr) //23

																	
			});
            this.myDataTable.DefaultView.AllowNew = true;
            this.myDataTable.DefaultView.AllowEdit = true;
            this.myDataTable.DefaultView.AllowDelete = true;

            //this.myDataSet.Tables.Add(this.myDataTable);
            //this.myDataView = new DataView(this.myDataTable);

            //设定用于对DataView进行重复行检索的主键
            DataColumn[] keys = new DataColumn[3];
            //keys[0] = this.myDataTable.Columns["盘点单号"];
            keys[0] = this.myDataTable.Columns["仓库编码"];
            keys[1] = this.myDataTable.Columns["物品编码"];
            keys[2] = this.myDataTable.Columns["零售金额"];
            this.myDataTable.PrimaryKey = keys;

            this.neuSpread1_Sheet1.DataSource = this.myDataTable.DefaultView;

            this.SetFormat();
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            List<Neusoft.HISFC.Models.Material.MaterialItem> alItem = this.myItem.GetMetItemList();
            if (alItem == null)
            {
                MessageBox.Show("加载物资基本信息发生错误");
                return;
            }
            foreach (Neusoft.HISFC.Models.Material.MaterialItem info in alItem)
            {
                this.hsItem.Add(info.ID, info);
            }
            this.ucMaterialItemList1.ShowDeptStorage(this.privDept.ID, false, false);
        }

        /// <summary>
        /// 格式化FarPoint
        /// </summary>
        public void SetFormat()
        {
            //FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            //屏蔽回车键
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            //不可编辑
            FarPoint.Win.Spread.CellType.TextCellType cReadOnlyType = new FarPoint.Win.Spread.CellType.TextCellType();
            cReadOnlyType.ReadOnly = true;
            //可编辑
            FarPoint.Win.Spread.CellType.TextCellType cWriteType = new FarPoint.Win.Spread.CellType.TextCellType();
            cWriteType.ReadOnly = false;
            //是否允许对盘点数量进行编辑
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //用基类的控件
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType cEditType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            cEditType.MinimumValue = 0;
            //FarPoint.Win.Spread.CellType.NumberCellType cEditType = new FarPoint.Win.Spread.CellType.NumberCellType();
            if (this.allowEdit)
            {
                cEditType.ReadOnly = false;
            }
            else
            {
                cEditType.ReadOnly = true;
            }

            /// <summary>
            /// 盘点流水号CheckNo	0
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckNo].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckNo].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckNo].Width = 70F;

            /// <summary>
            /// 盘点单号CheckCode	1
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckCode].Width = 70F;

            /// <summary>
            /// 仓库编码StorageCode	2
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StorageCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StorageCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StorageCode].Width = 70F;

            /// <summary>
            /// 物品编码ItemCode	3
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemCode].Width = 70F;

            /// <summary>
            /// 物品名称ItemName	4
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemName].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemName].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ItemName].Width = 70F;

            /// <summary>
            /// 零售金额SaleCost	5
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SaleCost].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SaleCost].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SaleCost].Width = 70F;

            /// <summary>
            /// 库存序号：按汇总盘点：ALL StockNo	6	
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StockNo].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StockNo].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StockNo].Width = 70F;

            /// <summary>
            /// 规格Specs		7
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Specs].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Specs].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Specs].Width = 70F;

            /// <summary>
            /// 库位编号PlaceCode	8
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PlaceCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PlaceCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.PlaceCode].Width = 70F;

            /// <summary>
            /// 最近有效期ValidDate	9
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ValidDate].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ValidDate].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ValidDate].Width = 70F;

            /// <summary>
            /// 供货公司Company	10
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Company].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Company].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Company].Width = 70F;

            /// <summary>
            /// 生产厂家Factory	11
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Factory].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Factory].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.Factory].Width = 70F;

            /// <summary>
            /// 封帐库存数量(最小单位)FstoreNum	12
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.FstoreNum].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.FstoreNum].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.FstoreNum].Width = 80F;

            /// <summary>
            /// 实际盘存数量(最小单位)AdjustNum	13
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.AdjustNum].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.AdjustNum].CellType = cEditType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.AdjustNum].Width = 80F;

            /// <summary>
            /// 结存库存数量(最小单位)CstoreNum	14
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CstoreNum].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CstoreNum].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CstoreNum].Width = 70F;

            /// <summary>
            /// 盈亏数量ProfitLossNum	15
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitLossNum].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitLossNum].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitLossNum].Width = 70F;

            /// <summary>
            /// 计量单位StatUnit	16
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StatUnit].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StatUnit].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.StatUnit].Width = 70F;

            /// <summary>
            /// 盈亏标记(0盘亏；1盘盈；2无盈亏)ProfitFlag	17
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitFlag].Visible = true;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitFlag].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ProfitFlag].Width = 70F;

            /// <summary>
            /// 盘点状态(0封帐；1结存；2取消)CheckState	18
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckState].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckState].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.CheckState].Width = 70F;

            /// <summary>
            /// 操作员OperCode      19
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperCode].Width = 70F;

            /// <summary>
            /// 操作日期OperDate	20
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperDate].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperDate].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.OperDate].Width = 70F;

            /// <summary>
            /// 拼音码SpellCode		21
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SpellCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.SpellCode].Width = 70F;

            /// <summary>
            /// 五笔码WBCode		22
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.WBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.WBCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.WBCode].Width = 70F;

            /// <summary>
            /// 自定义码UserCode    23
            /// </summary>
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.UserCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.UserCode].CellType = cReadOnlyType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.UserCode].Width = 70F;
        }

        ///{E10FCFDC-BE18-40c5-B357-5B4A347B78BE}
        /// <summary>
        /// 根据封帐库存更新盘点库存
        /// </summary>
        protected void FstoreSetAStore()
        {
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            foreach (DataRow dr in this.myDataTable.Rows)
            {
                dr["实际盘存数量"] = dr["封帐库存数量"];
            }

            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;
        }

        #region 封帐加入数据/数据操作


        /// <summary>
        /// 封帐
        /// </summary>
        protected void CheckClose()
        {
            this.ClearData();

            this.IsShowCheckList = false;

            this.ucMaterialItemList1.SetFocusSelect();
        }

        /// <summary>
        /// 初始化帮助类
        /// </summary>
        private void initHelper()
        {
            if (this.companyHelper == null)
            {
                ArrayList alCompany = this.companyMgr.QueryCompany("1", "1");
                this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alCompany);
            }
            if (this.producerHelper == null)
            {
                ArrayList alProducer = this.companyMgr.QueryCompany("0", "1");
                this.producerHelper = new Neusoft.FrameWork.Public.ObjectHelper(alProducer);
            }
            if (this.profitHelper == null)
            {
                ArrayList alPorfit = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "0";
                obj.Name = "盘亏";
                alPorfit.Add(obj);
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "1";
                obj.Name = "盘盈";
                alPorfit.Add(obj);
                obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "2";
                obj.Name = "无盈亏";
                alPorfit.Add(obj);
                this.profitHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPorfit);
            }
        }

        /// <summary>
        /// 手工添加一种物品进行盘点
        /// </summary>
        /// <param name="checkInfo"></param>
        private void AddData(Neusoft.HISFC.Models.Material.Check checkInfo)
        {
            try
            {
                if (checkInfo == null)
                {
                    MessageBox.Show("未找到有效盘点信息");
                    return;
                }
                this.myDataTable.Rows.Add(new object[]{
                                                        checkInfo.ID,                                                             //盘点流水号
                                                        checkInfo.CheckCode,                                                      //盘点单号 
                                                        checkInfo.StoreHead.StoreBase.StockDept.ID,                               //仓库编码	
                                                        checkInfo.StoreHead.StoreBase.Item.ID,                                    //物品编码	
                                                        checkInfo.StoreHead.StoreBase.Item.Name,                                  //物品名称	
                                                        checkInfo.StoreHead.StoreBase.AvgSalePrice,                               //零售金额 
                                                        checkInfo.StoreHead.StoreBase.StockNO,                                    //库存序号	
                                                        checkInfo.StoreHead.StoreBase.Item.Specs,                                 //规格	  
                                                        checkInfo.StoreHead.StoreBase.PlaceNO,                                    //库位编号
                                                        checkInfo.StoreHead.StoreBase.ValidTime,                                  //最近有效期
                                                        this.companyHelper.GetName(checkInfo.StoreHead.StoreBase.Company.ID),     //供货公司	
                                                        this.producerHelper.GetName(checkInfo.StoreHead.StoreBase.Producer.ID),   //生产厂家 
                                                        checkInfo.FStoreNum,                                                      //封帐库存数量
                                                        checkInfo.AdjustNum,                                                      //实际盘存数量
                                                        checkInfo.CStoreNum,                                                      //结存库存数量
                                                        checkInfo.ProfitLossNum,                                                  //盈亏数量                                                                   
                                                        checkInfo.StoreHead.StoreBase.Item.MinUnit,                               //计量单位                                                                   
                                                        this.profitHelper.GetName(checkInfo.ProfitFlag),                          //盈亏标记
                                                        checkInfo.CheckState,                                                     //盘点状态
                                                        checkInfo.Oper.ID,                                                        //操作员
                                                        checkInfo.Oper.OperTime,                                                  //操作日期
                                                        checkInfo.StoreHead.StoreBase.Item.SpellCode,                             //拼音码
                                                        checkInfo.StoreHead.StoreBase.Item.WbCode,                                //五笔码
                                                        checkInfo.StoreHead.StoreBase.Item.UserCode                               //自定义码
													  }
                                       );
                this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.RowCount - 1, 0);
            }
            catch (ConstraintException cex)
            {
                MessageBox.Show("添加物资已存在，不能重复添加");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加盘点信息失败：" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 手工添加一种物品进行盘点
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="batchNo">批号，如不按批号则为all</param>
        /// <param name="isBatch">是否按批号管理</param>
        public void AddData(string deptCode, string itemCode, string checkCode, DateTime dateBegin, DateTime dateEnd, string batchNo, string placeCode, bool isBatch)
        {

            Neusoft.HISFC.Models.Material.Check check;
            try
            {
                //查找是否已重复添加
                String[] tempFind = new string[3];
                tempFind[0] = itemCode;			//编码
                tempFind[1] = placeCode;	//库位号
                tempFind[2] = batchNo;			//批号
                DataRow findRow = this.myDataTable.Rows.Find(tempFind);
                if (findRow != null)
                {
                    MessageBox.Show("添加物资已存在，不能重复添加");
                    return;
                }

                check = this.myItem.CheckCloseByDrug(deptCode, itemCode, checkCode, dateBegin, dateEnd, batchNo, isBatch);
                if (check == null)
                {
                    MessageBox.Show("添加物资封帐失败" + this.myItem.Err);
                    return;
                }

                if (check.ID == null || check.ID == "")
                {
                    //check.PackNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(Math.Floor(Convert.ToDouble(check.FStoreNum / check.Item.PackQty)));
                    //check.MinNum = check.FStoreNum - check.PackNum * check.Item.PackQty;
                    //check.AdjustNum = check.FStoreNum;
                }

                //添加数据进入farpoint
                this.myDataTable.Rows.Add(new object[]{
                                                          //check.ID,									//0 盘点流水号
                                                          //check.PlaceCode,							//1 库位号
                                                          //check.Item.ID,							//2 药品编码
                                                          //check.Item.UserCode,						//3  自定义码
                                                          //check.Item.Name,							//4 药品名称
                                                          //check.Item.Specs,							//5 规格
                                                          //check.Item.PackQty,						//6 包装数量
                                                          //check.BatchNo,							//7 批号
                                                          //check.Item.UnitPrice,                     //8价格
                                                          //check.Item.MinUnit,						//9 单位
                                                          //check.Item.PackUnit,						//10 包装单位
                                                          //check.Item.MinUnit,						//11 最小单位
                                                          //check.LastNum,							//12 
                                                          //check.InNum,								//13
                                                          //check.OutNum,								//14 
                                                          //check.InMoney,							//15 
                                                          //check.OutMoney,							//16 
                                                          //check.FStoreNum,							//17 封帐库存
                                                          //check.FstoreMoney,						//18 
                                                          //check.AdjustNum,							//19 盘点数量
                                                          //check.ValidDate,							//20 有效期
                                                          //Math.Round(check.AdjustNum * check.Item.UnitPrice,4),//21盘点金额
                                                          //check.Item.Factory.Name,					//22 生产厂家
                                                          //check.Item.Factory.ID,					//23 部门编码
                                                          //check.Item.SpellCode,					//24 拼音码
                                                          //check.Item.WBCode						//25 五笔码
													  }
                    );
                this.SetFormat();
                this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.RowCount - 1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        ///{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
        /// <summary>
        /// 根据物资科目直接进行盘点封账
        /// </summary>
        /// <param name="deptNO">库房编码</param>
        /// <param name="kindType">物资科目</param>
        /// <param name="isCheckZeroStock"></param>
        /// <param name="isCheckStopDrug"></param>
        /// <returns></returns>
        protected int CheckCloseByType(string deptNO, string kindType, bool isBatch, bool isCheckZeroStock, bool isCheckStopMaterial)
        {
            //清除原数据
            this.ClearData();

            try
            {   //按照物资科目进行封账
                ArrayList alDetail = this.myItem.CheckCloseByKind(deptNO, kindType, isBatch, isCheckZeroStock, isCheckStopMaterial);
                if (alDetail == null)
                {
                    MessageBox.Show(Language.Msg("按照药品类别/性质进行批量封帐失败" + this.myItem.Err));
                    return -1;
                }

                if (alDetail.Count == 0)
                {
                    MessageBox.Show(Language.Msg("该选择类型无库存药品" + this.myItem.Err));
                    return -1;
                }
                //判断是否有未结存的盘点单中包含项目，对这些项目进行过滤{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
                ArrayList alCheck = new ArrayList();
                foreach (Neusoft.HISFC.Models.Material.Check checkTemp in alDetail)
                {
                    int iReturn = this.IsUnchecked(checkTemp.StoreHead.StoreBase.Item.ID, checkTemp.StoreHead.StoreBase.AvgSalePrice);
                    if (iReturn == 0)
                    {
                        alCheck.Add(checkTemp);
                        continue;
                    }
                }
                //------------------------
                this.ShowCheckDetail(alCheck);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 对本库房所有物资进行封帐处理{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="isBatch">是否按批号管理</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CheckCloseByTotal(string deptCode, bool isBatch, bool isCheckZeroStock, bool isCheckStopStock)
        {
            //清除原数据
            this.ClearData();
            ArrayList al = new ArrayList();
            try
            {		//对所有药品进行封帐处理
                al = this.myItem.CheckCloseByTotal(deptCode, isBatch, isCheckZeroStock, isCheckStopStock);
                if (al == null)
                {
                    MessageBox.Show(this.myItem.Err);
                    return -1;
                }
                if (al.Count == 0)
                {
                    MessageBox.Show("该选择类型无库存药品" + this.myItem.Err);
                    return -1;
                }
                //判断是否有未结存的盘点单中包含项目，对这些项目进行过滤{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
                ArrayList alCheck = new ArrayList();                
                foreach (Neusoft.HISFC.Models.Material.Check checkTemp in al)
                {
                    int iReturn = this.IsUnchecked(checkTemp.StoreHead.StoreBase.Item.ID, checkTemp.StoreHead.StoreBase.AvgSalePrice);
                    if (iReturn == 0)
                    {
                        alCheck.Add(checkTemp);
                        continue;
                    }
                }
                //------------------------
                //在FarPoint内显示明细
                this.ShowCheckDetail(alCheck);
            }
            catch (Exception ex)
            {
                MessageBox.Show("封帐失败！" + ex.Message);
                return -1;
            }
            return 1;
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
            result = MessageBox.Show("确认删除当前记录?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return;
            }
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
        }

        #endregion

        /// <summary>
        /// 获取当前发生变化的数据，返回Check动态数组
        /// </summary>
        /// <param name="flag">检索标志Modify(增加、更新)、Del(删除)、All(所有)</param>
        /// <returns>成功返回发生变动的数组、失败返回null</returns>
        private ArrayList GetUpdateInfo(string flag)
        {
            this.neuSpread1.StopCellEditing();
            foreach (DataRow dr in this.myDataTable.Rows)
            {
                dr.EndEdit();
            }

            ArrayList al = new ArrayList();
            DataTable dataChange = new DataTable();
            switch (flag)
            {
                case "Modify":		//获取变动(增加、修改)数据
                    dataChange = this.myDataTable.GetChanges(DataRowState.Modified | DataRowState.Added);
                    break;
                case "Del":			//获取删除数据
                    dataChange = this.myDataTable.GetChanges(DataRowState.Deleted);
                    break;
                case "All":         //获得所有数据
                    dataChange = this.myDataTable;
                    break;
                default:
                    return null;
            }
            //无变动数据
            if (dataChange == null)
                return null;
            //对于删除数据，回滚变化
            if (flag == "Del")
            {
                dataChange.RejectChanges();
            }

            try
            {
                //获得数据加入Check盘点实体
                foreach (DataRow row in dataChange.Rows)
                {
                    try
                    {

                        //由FarPoint内获得数据
                        Neusoft.HISFC.Models.Material.Check checkInfo = new Neusoft.HISFC.Models.Material.Check();

                        checkInfo.ID = row["盘点流水号"].ToString();	                                                    		//盘点流水号      
                        checkInfo.CheckCode = row["盘点单号"].ToString();                                                           //盘点单号 
                        checkInfo.StoreHead.StoreBase.StockDept.ID = row["仓库编码"].ToString();                                    //仓库编码	
                        checkInfo.StoreHead.StoreBase.Item.ID = row["物品编码"].ToString();                                         //物品编码	
                        checkInfo.StoreHead.StoreBase.Item.Name = row["物品名称"].ToString();                                       //物品名称	
                        checkInfo.StoreHead.StoreBase.AvgSalePrice = FrameWork.Function.NConvert.ToDecimal(row["零售金额"].ToString());   //零售金额 
                        checkInfo.StoreHead.StoreBase.StockNO = row["库存序号"].ToString();                                         //库存序号	
                        checkInfo.StoreHead.StoreBase.Item.Specs = row["规格"].ToString();                                          //规格	  
                        checkInfo.StoreHead.StoreBase.PlaceNO = row["库位编号"].ToString();                                         //库位编号
                        checkInfo.StoreHead.StoreBase.ValidTime = FrameWork.Function.NConvert.ToDateTime(row["最近有效期"].ToString());   //最近有效期
                        checkInfo.StoreHead.StoreBase.Company.ID = this.companyHelper.GetID(row["供货公司"].ToString());            //供货公司	
                        checkInfo.StoreHead.StoreBase.Producer.ID = this.producerHelper.GetID(row["生产厂家"].ToString());          //生产厂家 
                        checkInfo.FStoreNum = FrameWork.Function.NConvert.ToDecimal(row["封帐库存数量"].ToString());                      //封帐库存数量
                        checkInfo.AdjustNum = FrameWork.Function.NConvert.ToDecimal(row["实际盘存数量"].ToString());                      //实际盘存数量
                        checkInfo.CStoreNum = FrameWork.Function.NConvert.ToDecimal(row["结存库存数量"].ToString());                      //结存库存数量
                        //checkInfo.ProfitLossNum = FrameWork.Function.NConvert.ToDecimal(row["盈亏数量"].ToString());                      //盈亏数量        
                        checkInfo.ProfitLossNum = Math.Abs(checkInfo.FStoreNum - checkInfo.AdjustNum);                              //盈亏数量 
                        checkInfo.StoreHead.StoreBase.Item.MinUnit = row["计量单位"].ToString();                                    //计量单位
                        //checkInfo.ProfitFlag = this.profitHelper.GetID(row["盈亏标记"].ToString());                                 //盈亏标记
                        if (checkInfo.FStoreNum > checkInfo.AdjustNum)//盘亏
                        {
                            checkInfo.ProfitFlag = "0";
                        }
                        else if (checkInfo.FStoreNum < checkInfo.AdjustNum)//盘盈
                        {
                            checkInfo.ProfitFlag = "1";
                        }
                        else
                        {
                            checkInfo.ProfitFlag = "2";
                        }
                        checkInfo.CheckState = row["盘点状态"].ToString();                                                          //盘点状态
                        //checkInfo.Oper.ID = row["操作员"].ToString();                                                             
                        checkInfo.Oper.ID = this.myItem.Operator.ID;                                                                //操作员     
                        //checkInfo.Oper.OperTime = FrameWork.Function.NConvert.ToDateTime(row["操作日期"].ToString());                     
                        checkInfo.Oper.OperTime = this.myItem.GetDateTimeFromSysDateTime();                                         //操作日期  
                        checkInfo.StoreHead.StoreBase.Item.SpellCode = row["拼音码"].ToString();                                    //拼音码
                        checkInfo.StoreHead.StoreBase.Item.WbCode = row["五笔码"].ToString();                                       //五笔码
                        checkInfo.StoreHead.StoreBase.Item.UserCode = row["自定义码"].ToString();                                   //自定义码
                        if (checkInfo.ProfitFlag == "0")    //盈亏金额
                        {
                            checkInfo.CheckLossCost = checkInfo.ProfitLossNum * checkInfo.StoreHead.StoreBase.AvgSalePrice;
                        }
                        else if (checkInfo.ProfitFlag == "1")
                        {
                            checkInfo.CheckProfitCost = checkInfo.ProfitLossNum * checkInfo.StoreHead.StoreBase.AvgSalePrice;
                        }
                        //加入info进入动态数组
                        al.Add(checkInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(row["物品名称"].ToString() + row["规格"].ToString() + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n ");
            }
            return al;
        }

        /// <summary>
        /// 显示盘点明细信息
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        public void ShowCheckDetail(string deptCode, string checkCode)
        {
            ArrayList al = new ArrayList();

            al = this.myItem.GetCheckDetailByCheckCode(deptCode, checkCode);
            if (al == null)
            {
                MessageBox.Show(this.myItem.Err);
                return;
            }
            this.ShowCheckDetail(al);
            //提交变化
            this.myDataTable.AcceptChanges();
            //格式化FaoPoint
            this.SetFormat();
        }

        /// <summary>
        /// 填充FarPoint
        /// </summary>
        /// <param name="al">check动态数组</param>
        public void ShowCheckDetail(ArrayList al)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索盘点详细信息...");
            Application.DoEvents();
            try
            {
                Neusoft.HISFC.Models.Material.Check check;

                //如果不先取消绑定 那么速度会很慢
                //				this.neuSpread1_Sheet1.DataSource = null;

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, al.Count);
                    Application.DoEvents();

                    check = al[i] as Neusoft.HISFC.Models.Material.Check;

                    //获取药品信息
                    Neusoft.HISFC.Models.Material.MaterialItem item = new MaterialItem();
                    if (this.hsItem.ContainsKey(check.StoreHead.StoreBase.Item.ID))
                    {
                        item = this.hsItem[check.StoreHead.StoreBase.Item.ID] as Neusoft.HISFC.Models.Material.MaterialItem;
                    }
                    else
                    {
                        item = this.myItem.GetMetItemByMetID(check.StoreHead.StoreBase.Item.ID);
                        if (item == null)
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("加载基本信息时出错" + this.myItem.Err);
                            return;
                        }
                    }
                    check.StoreHead.StoreBase.Item = item;
                    this.AddData(check);
                    //if (this.isWindowCheck)
                    //{
                    //    //check.MinNum = 0;
                    //    //check.PackNum = 0;
                    //}

                    //if (check.ID == null || check.ID == "")
                    //{
                    //    //check.PackNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(Math.Floor(Convert.ToDouble(check.FStoreNum / check.Item.PackQty)));
                    //    //check.MinNum = check.FStoreNum - check.PackNum * check.Item.PackQty;
                    //    //check.AdjustNum = check.FStoreNum;
                    //}

                    //this.myDataTable.Rows.Add(new object[]{
                    //                                          //check.ID,									//0 盘点流水号
                    //                                          //check.PlaceCode,							//1 库位号
                    //                                          //check.Item.ID,							//2 药品编码
                    //                                          //check.Item.UserCode,						//3  自定义码
                    //                                          //check.Item.Name,							//4 药品名称
                    //                                          //check.Item.Specs,							//5 规格
                    //                                          //check.Item.PackQty,						//6 包装数量
                    //                                          //check.BatchNo,							//7 批号
                    //                                          //check.Item.Price,                         //8 价格
                    //                                          //check.Item.MinUnit,						//9 单位
                    //                                          //check.Item.PackUnit,						//10 包装单位
                    //                                          //check.Item.MinUnit,						//11 最小单位
                    //                                          //check.LastNum,							//12 
                    //                                          //check.InNum,								//13
                    //                                          //check.OutNum,								//14 
                    //                                          //check.InMoney,							//15 
                    //                                          //check.OutMoney,							//16 
                    //                                          //check.FStoreNum,							//17 封帐库存
                    //                                          //check.FstoreMoney,						//18 
                    //                                          //check.AdjustNum,							//19 盘点数量
                    //                                          //check.ValidDate,							//20 有效期
                    //                                          //Math.Round(check.AdjustNum * check.Item.UnitPrice,4),//21盘点金额
                    //                                          //check.Item.Factory.Name,					//22 生产厂家
                    //                                          //check.Item.Factory.ID,					//23 部门编码
                    //                                          //check.Item.SpellCode,					//24 拼音码
                    //                                          //check.Item.WBCode						//25 五笔码
                    //                                      }
                    //    );
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            }

            //			this.neuSpread1_Sheet1.DataSource = this.myDataView;

            //格式化
            this.SetFormat();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        ///对封帐、盘点过程进行保存，更新盘点明细表
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int Save(string deptCode, string checkCode)
        {

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            if (this.myDataTable.Rows.Count == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            //string nowOperDrug = "";

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存.请稍候...");
            Application.DoEvents();
            try
            {
                this.myItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                DateTime sysTime = this.myItem.GetDateTimeFromSysDateTime();
                Neusoft.HISFC.Models.Material.Check checkInfo = new Neusoft.HISFC.Models.Material.Check();
                //取所有的盘点记录
                ArrayList alAllCheck = this.GetUpdateInfo("All");
                //盘亏金额
                decimal lossCost = 0;
                //盘盈金额
                decimal profitCost = 0;
                foreach (Neusoft.HISFC.Models.Material.Check tmpCheck in alAllCheck)
                {
                    lossCost += tmpCheck.CheckLossCost;
                    profitCost += tmpCheck.CheckProfitCost;
                }
                #region 插入或更新盘点汇总表
                if (checkCode == "" || checkCode == null)
                {
                    #region 对新建盘点单向盘点统计表插入数据
                    //if (this.newCheckCode != "")
                    //{	//当封帐后两次点击保存时，不重新取盘点单号及插入盘点统计表
                    //    checkCode = this.newCheckCode;
                    //}
                    //else
                    //{
                    //获取新盘点单号
                    checkCode = this.myItem.GetCheckCode(deptCode);
                    //保存新生成的盘点单号
                    //this.newCheckCode = checkCode;
                    if (checkCode == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("获取新盘点单号失败" + this.myItem.Err);
                        return -1;
                    }
                    checkInfo.CheckCode = checkCode;        //盘点单号
                    checkInfo.StoreHead.StoreBase.StockDept.ID = deptCode;  //库房编码
                    checkInfo.CheckState = "0";      //封帐状态
                    checkInfo.FOper.ID = this.myItem.Operator.ID;//封帐人
                    checkInfo.FOper.OperTime = sysTime;				//操作时间
                    checkInfo.CheckLossCost = lossCost;           //盘亏金额
                    checkInfo.CheckProfitCost = profitCost;         //盘盈金额
                    checkInfo.Oper.ID = this.myItem.Operator.ID;   //操作员
                    checkInfo.Oper.OperTime = sysTime;                //操作时间
                    checkInfo.StoreHead.StoreBase.StockNO = "ALL";    //库存序号
                    if (this.myItem.InsertCheckStatic(checkInfo) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("添加盘点统计表失败" + this.myItem.Err);
                        return -1;
                    }
                    //}

                    #endregion
                }
                else
                {
                    #region 对已存在的盘点单向盘点统计表更新数据
                    checkInfo.CheckCode = checkCode;
                    checkInfo.StoreHead.StoreBase.StockDept.ID = deptCode;  //库房编码
                    checkInfo.CheckState = "0";      //封帐状态
                    checkInfo.FOper.ID = this.myItem.Operator.ID;//封帐人
                    checkInfo.FOper.OperTime = sysTime;				//操作时间
                    checkInfo.CheckLossCost = lossCost;           //盘亏金额
                    checkInfo.CheckProfitCost = profitCost;         //盘盈金额
                    checkInfo.Oper.ID = this.myItem.Operator.ID;  //操作员
                    checkInfo.Oper.OperTime = sysTime;             //操作时间
                    checkInfo.StoreHead.StoreBase.StockNO = "ALL";  //库存序号
                    if (this.myItem.UpdateCheckStatic(checkInfo) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("更新盘点统计表失败" + this.myItem.Err);
                        return -1;
                    }
                    #endregion
                }
                #endregion
                //DataSet内获得发生变动的数据
                ArrayList modifyList = this.GetUpdateInfo("Modify");
                ArrayList delList = this.GetUpdateInfo("Del");

                if (modifyList != null)
                {
                    #region 对发生变动的记录进行更新
                    foreach (Neusoft.HISFC.Models.Material.Check info in modifyList)
                    {
                        //获取最新药品信息
                        //Neusoft.HISFC.Models.Material.MaterialItem item = new MaterialItem();
                        //item = this.myItem.QueryMetItemAllByID(info.StoreHead.StoreBase.Item.ID);
                        //if (item == null)
                        //{
                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        //    MessageBox.Show("获取最新药品信息时出错" + this.myItem.Err);
                        //    return -1;
                        //}
                        //nowOperDrug = item.Name;
                        //info.StoreHead.StoreBase.Item = item;					//最新药品实体
                        //info.CheckCode = checkCode;			//盘点单号
                        //info.StoreHead.StoreBase.StockDept.ID = deptCode;			//库房编码
                        //info.CheckState = "0";				//盘点状态 封帐
                        info.FOper.ID = this.myItem.Operator.ID;	//操作人
                        info.FOper.OperTime = sysTime;			//操作时间
                        info.CheckCode = checkCode;
                        info.StoreHead.StoreBase.StockDept.ID = deptCode;
                        //对新增数据该字段（流水号）由FarPoint取到的为空，设为－1
                        if (info.ID == "")
                        {
                            info.ID = "-1";
                        }
                        //先进行更新操作，如更新失败则插入
                        int parm = this.myItem.UpdateCheckDetail(info);
                        //对盘点明细表更新数据
                        if (parm == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("更新盘点明细时出错" + this.myItem.Err);
                            return -1;
                        }
                        else
                        {
                            if (parm == 0)
                            {
                                //对盘点明细表插入数据
                                if (this.myItem.InsertCheckDetail(info) == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                    MessageBox.Show("添加盘点明细时出错" + this.myItem.Err);
                                    return -1;
                                }
                            }
                        }
                    }
                    #endregion
                }
                if (delList != null)
                {		//
                    #region 对删除的记录进行删除
                    foreach (Neusoft.HISFC.Models.Material.Check info in delList)
                    {
                        //对盘点明细记录删除
                        if (this.myItem.DeleteCheckDetail(info.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("删除盘点明细时出错" + this.myItem.Err);
                            return -1;
                        }
                    }
                    #endregion
                }

                //计算盘点盈亏更新盈亏数量、盈亏标记
                //if (this.myItem.SaveCheck(deptCode, checkCode) == -1)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    MessageBox.Show("更新实际盘存数量时出错" + this.myItem.Err);
                //    return -1;
                //}
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message + "  \n");
                return -1;
            }
            //提交事务、格式化farpoint
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.SetFormat();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            MessageBox.Show("保存成功");
            return 1;
        }

        ///{9ADAD904-B8B5-4f94-88A9-AF690A98D1BF}
        /// <summary>
        ///对封帐、盘点过程进行增量保存，更新盘点明细表
        /// </summary> 
        /// <returns>成功返回1 失败返回－1</returns>
        //public int AddSave(string deptCode, string checkCode)
        //{
        //    //定义事务
        //    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

        //    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
        //    //t.BeginTransaction();

        //    if (this.myDataTable.Rows.Count == 0)
        //    {
        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //        return -1;
        //    }

        //    string nowOperDrug = "";

        //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行保存.请稍候...");
        //    Application.DoEvents();
        //    try
        //    {
        //        this.myItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
        //        DateTime sysTime = this.myItem.GetDateTimeFromSysDateTime();//DataSet内获得发生变动的数据
        //        ArrayList modifyList = this.GetUpdateInfo("Modify");
        //        if (modifyList != null)
        //        {
        //            #region 对发生变动的记录进行更新
        //            foreach (Neusoft.HISFC.Models.Material.Check info in modifyList)
        //            {
        //                //获取最新药品信息
        //                Neusoft.HISFC.Models.Material.MaterialItem item = new MaterialItem();
        //                item = this.myItem.GetMetItemByMetID(info.StoreHead.StoreBase.Item.ID);
        //                if (item == null)
        //                {
        //                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //                    MessageBox.Show("获取最新药品信息时出错" + this.myItem.Err);
        //                    return -1;
        //                }

        //                nowOperDrug = item.Name;

        //                info.StoreHead.StoreBase.Item = item;					//最新药品实体						
        //                info.CheckCode = checkCode;			//盘点单号			
        //                info.StoreHead.StoreBase.StockDept.ID = deptCode;			//库房编码
        //                info.CheckState = "0";				//盘点状态 封帐
        //                info.FOper.ID = this.myItem.Operator.ID;	//操作人
        //                info.FOper.OperTime = sysTime;			//操作时间

        //                //对盘点明细表更新数据						
        //                int parm = this.myItem.UpdateCheckDetailAddSave(info);
        //                if (parm == -1)
        //                {
        //                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //                    MessageBox.Show("更新盘点明细时出错" + this.myItem.Err);
        //                    return -1;
        //                }
        //            }
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //        MessageBox.Show(ex.Message + "  \n" + nowOperDrug);
        //        return -1;
        //    }
        //    //提交事务、格式化farpoint
        //    Neusoft.FrameWork.Management.PublicTrans.Commit();

        //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在导出数据...请稍候");
        //    Application.DoEvents();

        //    this.AutoExport();

        //    this.myDataTable.Clear();
        //    this.SetFormat();

        //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        //    MessageBox.Show("保存成功", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        //    return 1;
        //}

        /// <summary>
        /// 清空列表  
        /// </summary>
        public void ClearData()
        {
            //清空DataSet
            //this.myDataSet.Tables[0].Clear();
            //this.myDataSet.AcceptChanges();
            this.myDataTable.Clear();
            this.myDataTable.AcceptChanges();
            //格式化FarPoint
            this.SetFormat();
            this.neuTextBox1.Text = "";
            this.nowOperCheckNO = "";
        }

        /// <summary>
        /// 判断是否可以继续进行批量封帐
        /// </summary>
        /// <returns>允许进行返回1 禁止返回－1</returns>
        public int JudgeContinue()
        {
            if (this.neuSpread1_Sheet1.Rows.Count != 0)
            {
                DialogResult result;
                //提示用户选择是否继续生成，如继续生成则将清空原数据
                result = MessageBox.Show("批量封帐将清除当前数据，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                if (result == DialogResult.No)
                {
                    return -1;
                }
            }
            return 1;
        }

        #region 结存/解封
        /// <summary>
        /// 对封帐盘点单进行解封处理
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CancelCheck(string deptCode, string checkCode)
        {
            //如当前点击无数据则返回
            if (this.myDataTable.Rows.Count == 0)
            {
                return -1;
            }
            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show("确认进行解封操作吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }
            //定义事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行解封处理.请稍候...");
            Application.DoEvents();
            try
            {
                this.myItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                int i = this.myItem.CancelCheck(deptCode, checkCode);
                //解封未成功返回
                if (i == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("解封操作失败" + this.myItem.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("解封操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.SetFormat();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            MessageBox.Show("解封操作成功");
            return 1;
        }


        /// <summary>
        /// 对盘点进行结存操作
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <param name="checkCode">盘点单号</param>
        /// <returns>成功返回1、失败返回－1</returns>
        public int CheckCStore(string deptCode, string checkCode)
        {
            //如当前点击无数据则返回
            if (this.myDataTable.Rows.Count == 0)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(checkCode))
            {
                MessageBox.Show("获取盘点单号失败");
                return -1;
            }
            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show("确认进行结存操作吗", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }
            //定义事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行结存处理.请稍候...");
            Application.DoEvents();
            try
            {
                this.myItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                if (this.myItem.CheckCStore(deptCode, checkCode) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("结存操作失败" + this.myItem.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("结存操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.SetFormat();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.ucMaterialItemList1.ShowDeptStorage(this.privDept.ID, false);
            this.ClearData();
            MessageBox.Show("结存操作成功");
            return 1;
        }

        #endregion

        public int Print()
        {
            //			Local.GyHis.Pharmacy.ucPhaCheck uc = new Local.GyHis.Pharmacy.ucPhaCheck();
            //
            //			uc.Decimals = 2;
            //			uc.MaxRowNo = 8;
            //
            //			uc.PrintCheck(this.myDataTable,this.myPrivDept.ID,
            //				"",System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),this.myItem.Operator.ID);
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
                    fileName = dlg.FileName;
                    this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 将当前查询内容按Excel格式自动导出
        /// </summary>
        public void AutoExport()
        {
            try
            {
                this.myDataTable.DefaultView.RowFilter = "1=1";

                DateTime dt = this.myItem.GetDateTimeFromSysDateTime();
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
        /// 盘点库存与盘点金额计算
        /// </summary>
        private void SumCheckNumAndCost(int rowIndex)
        {
            //盘点数量
            decimal adjustNum = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.AdjustNum].Text);
            //盘点最小数量
            decimal fStoreNum = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.FstoreNum].Text);

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ProfitLossNum].Text = Math.Abs(adjustNum - fStoreNum).ToString();	//盘点库存
            //this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.AdjustCost].Text = Math.Round((iPackNum + jMinNum / kPackQty) * price, 4).ToString();
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //重新设置颜色
            this.SetFlag();
        }

        /// <summary>
        /// 根据库存信息获取盘点实体
        /// </summary>
        /// <param name="storeHead"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Material.Check GetCheck(StoreHead storeHead)
        {
            Neusoft.HISFC.Models.Material.Check checkInfo = new Neusoft.HISFC.Models.Material.Check();
            checkInfo.StoreHead = storeHead;
            checkInfo.CheckCode = "";
            checkInfo.FStoreNum = storeHead.StoreBase.StoreQty;
            checkInfo.AdjustNum = 0;
            checkInfo.ProfitLossNum = storeHead.StoreBase.StoreQty;
            checkInfo.CheckState = "0";
            return checkInfo;
        }

        /// <summary>
        /// 设置Fp标记
        /// </summary>
        protected void SetFlag()
        {
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.AdjustNum].Text) > NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.FstoreNum].Text))
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Blue;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ProfitFlag].Text = "盘盈";
                    }
                    else if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.AdjustNum].Text) < NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.FstoreNum].Text))
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Red;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ProfitFlag].Text = "盘亏";
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Black;
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ProfitFlag].Text = "无盈亏";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("格式化盈亏颜色显示时发生错误" + ex.Message));
                return;
            }
        }

        #endregion

        #region 事件

        private void ucCheckManager_Load(object sender, EventArgs e)
        {
            //初始化数据表
            this.InitDataTable();
            //初始化
            if (!this.DesignMode)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Application.DoEvents();

                //初始化帮助类
                this.initHelper();
                //初始化物资帐目信息
                this.InitData();

                this.InitCheckList();

                this.SetToolButton(true);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.myDataTable.DefaultView == null)
                return;
            //获得过滤条件
            string queryCode = "";
            if (this.neuCheckBox1.Checked)		//模糊查询
                queryCode = "%" + this.neuTextBox1.Text.Trim() + "%";
            else
                queryCode = this.neuTextBox1.Text.Trim() + "%";

            //modify by zhaoyang 2009-06-20 注释掉不存在的两列 {38322DE1-5E53-4e37-B003-4CD638872EC0}
            string filter = "(拼音码 LIKE '" + queryCode + "') OR " +
                "(五笔码 LIKE '" + queryCode + "') OR " +
                //"(通用名拼音码 LIKE '" + queryCode + "') OR " +
                //"(通用名五笔码 LIKE '" + queryCode + "') OR " +
                "(自定义码 LIKE '" + queryCode + "') ";
            try
            {
                this.myDataTable.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.SetFormat();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                this.neuSpread1_Sheet1.ActiveColumnIndex = 10;
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //如不允许删除则返回
            if (!this.allowDel)
                return;
            //当前点击为列则返回
            if (e.ColumnHeader)
                return;
            //删除
            this.DeleteData();
        }

        // 在输入盘点数量1、盘点数量2后计算盘点库存
        private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (e.Column == (int)ColumnSet.AdjustNum)
            {
                this.SumCheckNumAndCost(e.Row);
            }
            this.SetFlag();
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.ClearData();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.HISFC.Models.Material.Check check = e.Node.Tag as Neusoft.HISFC.Models.Material.Check;

                this.nowOperCheckNO = check.CheckCode;

                this.ShowCheckDetail(this.privDept.ID, check.CheckCode);

                this.SetFlag();
            }
        }

        #region 处理回车调换焦点事件
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
                        //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                        //列数不对
                        if (j == 13)
                        {

                            if (i < this.neuSpread1_Sheet1.Rows.Count - 1)
                            {
                                this.neuSpread1_Sheet1.ActiveRowIndex++;
                                this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, 13, false);
                            }
                            else
                            {
                                this.neuTextBox1.Focus();
                                this.neuTextBox1.SelectAll();
                            }

                            this.SumCheckNumAndCost(i);
                            
                            //							//处理跳转焦点后盘点库存的计算
                            //							if (this.neuSpread1_Sheet1.Cells[i,10].Text == "")
                            //								this.neuSpread1_Sheet1.Cells[i,10].Text = "0";
                            //							if (this.neuSpread1_Sheet1.Cells[i,12].Text == "")
                            //								this.neuSpread1_Sheet1.Cells[i,12].Text = "0";
                            //							decimal iPackNum = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,10].Text);
                            //							decimal jMinNum = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,12].Text);
                            //							decimal kPackQty = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,6].Text);
                            //							this.neuSpread1_Sheet1.Cells[i,14].Text = (iPackNum * kPackQty + jMinNum).ToString();
                        }
                    }

                    #endregion

                    break;
                case Keys.F5:

                    this.neuTextBox1.Focus();
                    this.neuTextBox1.SelectAll();

                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        /// <summary>
        /// 左侧fp选中物品事件
        /// </summary>
        /// <param name="sv">SheetView</param>
        /// <param name="activeRow">选中的行</param>
        private void ucMaterialItemList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (activeRow < 0)
                return;
            //{7019A2A6-ADCA-4984-944B-C4F1A312449A}
            //string itemCode = sv.Cells[activeRow, 0].Text;
            string itemCode = sv.Cells[activeRow, 11].Text;
            decimal salePrice = FrameWork.Function.NConvert.ToDecimal(sv.Cells[activeRow, 3].Text);
            //{B954FF22-CCDB-4d58-B233-9FFD0EC95410}判断是否有未结存的盘点单中包含选中项目
            int iReturn = this.IsUnchecked(itemCode, salePrice);
            if (iReturn == -1)
            {
                MessageBox.Show("获取" + sv.Cells[activeRow, 1].Text + "的盘点信息失败:" + this.myItem.Err);

                return;
            }
            else if (iReturn > 0)
            {
                MessageBox.Show(sv.Cells[activeRow, 1].Text + "存在未结存的盘点单，不能再次添加");

                return;
            }
            //------------------------
            Neusoft.HISFC.Models.Material.StoreHead storeHead = this.storeMgr.GetStoreHead(this.privDept.ID, itemCode, salePrice);
            if (storeHead == null)
            {
                MessageBox.Show("获取" + sv.Cells[activeRow, 1].Text + "的库存汇总信息失败:" + this.storeMgr.Err);
                return;
            }
            Neusoft.HISFC.Models.Material.MaterialItem item = this.hsItem[itemCode] as Neusoft.HISFC.Models.Material.MaterialItem;
            if (item == null)
            {
                MessageBox.Show("查找物品信息失败，请重新打开该窗口");
                return;
            }
            storeHead.StoreBase.Item = item;
            Neusoft.HISFC.Models.Material.Check checkInfo = this.GetCheck(storeHead);
            this.AddData(checkInfo);
            this.SetFlag();
        }

        /// <summary>
        /// 判断是否有未结存的盘点单中包含选中项目{B954FF22-CCDB-4d58-B233-9FFD0EC95410}
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="salePrice"></param>
        /// <returns></returns>
        private int IsUnchecked(string itemCode, decimal salePrice)
        {
            ArrayList alCheck = this.myItem.GetCheckDetail(itemCode, salePrice, "0");
            if (alCheck == null)
            {
                return -1;
            }

            return alCheck.Count;
        }

        #endregion

        #region 列设置

        private enum ColumnSet
        {
            /// <summary>
            /// 盘点流水号	0
            /// </summary>
            CheckNo,
            /// <summary>
            /// 盘点单号	1
            /// </summary>
            CheckCode,
            /// <summary>
            /// 仓库编码	2
            /// </summary>
            StorageCode,
            /// <summary>
            /// 物品编码	3
            /// </summary>
            ItemCode,
            /// <summary>
            /// 物品名称	4
            /// </summary>
            ItemName,
            /// <summary>
            /// 零售金额	5
            /// </summary>
            SaleCost,
            /// <summary>
            /// 库存序号：按汇总盘点：ALL	6	
            /// </summary>
            StockNo,
            /// <summary>
            /// 规格		7
            /// </summary>
            Specs,
            /// <summary>
            /// 库位编号	8
            /// </summary>
            PlaceCode,
            /// <summary>
            /// 最近有效期	9
            /// </summary>
            ValidDate,
            /// <summary>
            /// 供货公司	10
            /// </summary>
            Company,
            /// <summary>
            /// 生产厂家	11
            /// </summary>
            Factory,
            /// <summary>
            /// 封帐库存数量(最小单位)	12
            /// </summary>
            FstoreNum,
            /// <summary>
            /// 实际盘存数量(最小单位)	13
            /// </summary>
            AdjustNum,
            /// <summary>
            /// 结存库存数量(最小单位)	14
            /// </summary>
            CstoreNum,
            /// <summary>
            /// 盈亏数量	15
            /// </summary>
            ProfitLossNum,
            /// <summary>
            /// 计量单位	16
            /// </summary>
            StatUnit,
            /// <summary>
            /// 盈亏标记(0盘亏；1盘盈；2无盈亏)	17
            /// </summary>
            ProfitFlag,
            /// <summary>
            /// 盘点状态(0封帐；1结存；2取消)	18
            /// </summary>
            CheckState,
            /// <summary>
            /// 操作员      19
            /// </summary>
            OperCode,
            /// <summary>
            /// 操作日期	20
            /// </summary>
            OperDate,
            /// <summary>
            /// 拼音码		21
            /// </summary>
            SpellCode,
            /// <summary>
            /// 五笔码		22
            /// </summary>
            WBCode,
            /// <summary>
            /// 自定义码    23
            /// </summary>
            UserCode
        }

        #endregion

        #region 接口成员

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                //printType[0] = typeof(Neusoft.HISFC.BizProcess.Integrate.PharmacyInterface.IBillPrint);

                return printType;
            }
        }

        #endregion

        #region IPreArrange 成员

        bool isPreArrange = false;

        public int PreArrange()
        {
            this.isPreArrange = true;

            string class2Priv = "0505";
            //根据结存按钮所处位置判断窗口类型 显示结存时 盘点结存 否则 盘点管理 
            if (this.toolBarService.GetToolButton("结存").Owner != null && this.toolBarService.GetToolButton("结存").Owner.Visible)      //结存
            {
                class2Priv = "0507";            //盘点结存
            }
            else
            {
                class2Priv = "0505";            //盘点管理
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

        #endregion
    }
}
