using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Integrate;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material
{
    public partial class ucStoreManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucStoreManager()
        {
            InitializeComponent();
        }

        #region 管理类

        /// <summary>
        /// 帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 库存物品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资字典管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        #endregion

        #region 域变量

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// XML配置文件路径
        /// </summary>
        private string xmlFilePath = @".\\" + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "\\MaterialStoreManager.xml";

        /// <summary>
        /// 数据集
        /// </summary>
        private DataTable dtData = null;

        /// <summary>
        /// 数据视图
        /// </summary>
        private DataView dvData = null;

        /// <summary>
        /// 当前编辑的列
        /// </summary>
        private string nowEditColumn = "货位号";

        /// <summary>
        /// 物资科目
        /// </summary>
        private string nodeTag = "0";

        /// <summary>
        /// 货位号允许的长度
        /// </summary>
        private int placeNoLength = 12;

        /// <summary>
        /// 物品明细信息显示控件
        /// </summary>
        private Material.Base.ucMaterialManager DetailUC = null;

        /// <summary>
        /// 有效期警示信息
        /// </summary>
        private Color validDateCautionColor = System.Drawing.Color.Moccasin;

        /// <summary>
        /// 有效期警示天数 
        /// </summary>
        private int validDateCautionDays = 90;

        /// <summary>
        /// 当天日期 
        /// </summary>
        private DateTime sysDate = System.DateTime.MinValue;

        /// <summary>
        /// 列设置
        /// </summary>
        private Neusoft.HISFC.Components.Common.Controls.ucSetColumn ucColumn = null;

        /// <summary>
        /// 可编辑的列
        /// </summary>
        private System.Collections.Hashtable hsEditColumn = new Hashtable();

        /// <summary>
        /// 跳转列设置
        /// </summary>
        private System.Collections.Hashtable hsJumpColumn = new Hashtable();

        /// <summary>
        /// 库存上下限报警时 字体警示色
        /// </summary>
        private Color warnStoreColor = System.Drawing.Color.Blue;

        /// <summary>
        /// 是否进行列顺序设置
        /// </summary>
        private bool isSetJump = false;

        /// <summary>
        /// 物品库存明细有效期获取方式 True 实时获取 每次点击查询时重新获取 False 列表显示时 直接获取有效的库存记录的最小有效期
        /// </summary>
        private bool validDateQueryRealTime = true;

        /// <summary>
        /// 是否进行库存上下限报警
        /// </summary>
        private bool isWarnStore = false;

        /// <summary>
        /// 库存上下限报警时 是否弹出MessageBox提示
        /// </summary>
        private bool isWarnMessge = false;

        /// <summary>
        /// 是否允许弹出显示明细信息
        /// </summary>
        private bool isShowDrugDetail = true;

        /// <summary>
        /// 是否使用有效期警示
        /// </summary>
        private bool isValidDateFlag = false;

        #endregion

        #region 属性

        /// <summary>
        /// 当前操作科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperDept
        {
            set
            {
                this.operDept = value;
            }
            get
            {
                return this.operDept;
            }
        }


        /// <summary>
        /// 是否允许弹出显示明细信息
        /// </summary>
        [Description("是否允许弹出显示明细信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowDrugDetail
        {
            get
            {
                return this.isShowDrugDetail;
            }
            set
            {
                this.isShowDrugDetail = value;
            }
        }


        /// <summary>
        /// 货位号允许的长度
        /// </summary>
        [Description("货位号允许的长度"), Category("设置"), DefaultValue(12)]
        public int PlaceNoLength
        {
            get
            {
                return this.placeNoLength;
            }
            set
            {
                this.placeNoLength = value;
            }
        }


        /// <summary>
        /// 是否使用有效期警示
        /// </summary>
        [Description("是否使用有效期警示"), Category("设置"), DefaultValue(false)]
        public bool IsValidDateFlag
        {
            get
            {
                return isValidDateFlag;
            }
            set
            {
                isValidDateFlag = value;
            }
        }


        /// <summary>
        /// 有效期警示信息颜色
        /// </summary>
        [Description("有效期警示颜色"), Category("设置")]
        public Color ValidDateCautionColor
        {
            get
            {
                return this.validDateCautionColor;
            }
            set
            {
                this.validDateCautionColor = value;
            }
        }


        /// <summary>
        /// 有效期警示天数 
        /// </summary>
        [Description("有效期警示天数"), Category("设置"), DefaultValue(90)]
        public int ValidDateCautionDays
        {
            get
            {
                return validDateCautionDays;
            }
            set
            {
                validDateCautionDays = value;
            }
        }


        /// <summary>
        /// 物品库存明细有效期获取方式 
        /// True 实时获取 每次点击查询时重新获取 False 列表显示时 直接获取有效的库存记录的最小有效期
        /// </summary>
        [Description("物品库存明细有效期获取方式"), Category("设置"), DefaultValue(true)]
        public bool ValidDateQueryRealTime
        {
            get
            {
                return this.validDateQueryRealTime;
            }
            set
            {
                this.validDateQueryRealTime = value;
            }
        }


        /// <summary>
        /// 是否进行库存上下限报警
        /// </summary>
        [Description("是否进行库存上下限报警"), Category("设置"), DefaultValue(false)]
        public bool IsWarnStore
        {
            get
            {
                return this.isWarnStore;
            }
            set
            {
                this.isWarnStore = value;
            }
        }


        /// <summary>
        /// 库存上下限报警时 是否弹出MessageBox提示
        /// </summary>
        [Description("库存上下限报警时 是否弹出MessageBox提示"), Category("设置"), DefaultValue(false)]
        public bool IsWarnStoreMessage
        {
            get
            {
                return this.isWarnMessge;
            }
            set
            {
                this.isWarnMessge = value;
            }
        }


        /// <summary>
        /// 库存上下限报警时 字体警示色
        /// </summary>
        [Description("库存上下限报警时 字体警示色"), Category("设置")]
        public Color WarnStoreColor
        {
            get
            {
                return this.warnStoreColor;
            }
            set
            {
                this.warnStoreColor = value;
            }
        }


        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("刷新", "刷新库存信息药品显示", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            toolBarService.AddToolButton("高级过滤", "是否显示高级过滤", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预览, true, false, null);
            toolBarService.AddToolButton("跳转设置", "设置回车跳转的列顺序", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            toolBarService.AddToolButton("查看明细", "查询当前药品的库存明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "刷新")
            {
                this.Refresh(false);
            }
            if (e.ClickedItem.Text == "高级过滤")
            {
                this.panelFilter.Visible = !this.panelFilter.Visible;
            }
            if (e.ClickedItem.Text == "跳转设置")
            {
                this.SetColumnJumpOrder();
            }
            if (e.ClickedItem.Text == "查看明细")
            {
                this.GetData();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            return 1;
        }

        public override int SetPrint(object sender, object neuObject)
        {
            this.SetColumnDisplayOrder();

            return 1;
        }

        #endregion

        #region 数据初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected virtual void InitData()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

            ArrayList alDept = deptManager.GetDeptment("L");
            if (alDept == null)
            {
                MessageBox.Show("获取科室列表失败！", "提示");
                return;
            }
            this.cmbDept.Items.Add(new ArrayList(alDept.ToArray()));

            this.ucMaterialKindTree1.InitTreeView();

            #region Fp屏蔽回车键

            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            #endregion
        }

        /// <summary>
        /// 根据所拥有的权限 设置 操作科室
        /// </summary>
        private void InitDeptList()
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerDetailManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            string operCode = powerDetailManager.Operator.ID;
            List<Neusoft.FrameWork.Models.NeuObject> alDept = powerDetailManager.QueryUserPriv(operCode, "0502");
            if (alDept == null)
            {
                MessageBox.Show(Language.Msg("根据库存操作权限获取权限科室发生错误!") + powerDetailManager.Err);
                return;
            }
            this.cmbDept.AddItems(new ArrayList(alDept.ToArray()));

            if (alDept.Count > 0)
                this.cmbDept.SelectedIndex = 0;
        }

        #endregion

        #region DataTable操作设置

        /// <summary>
        /// 设置DataTable默认格式
        /// </summary>
        protected virtual void InitDefaultDataTable()
        {
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");
            System.Type dtDtime = System.Type.GetType("System.DateTime");            

            //装载DataTable列
            this.dtData.Columns.AddRange(new DataColumn[]{
														 new DataColumn("仓库编码",		dtStr),		//0
														 new DataColumn("物品编码",		dtStr),		//1
														 new DataColumn("科目编码",		dtStr),		//2
														 new DataColumn("科目名称",		dtStr),		//3
														 new DataColumn("物品名称",		dtStr),		//4
														 new DataColumn("规格",			dtStr),		//5
														 new DataColumn("库存数量",		dtDec),		//6
														 new DataColumn("计量单位",		dtStr),		//7
														 new DataColumn("单价",			dtDec),		//8
														 new DataColumn("库存金额",		dtDec),		//9
														 new DataColumn("零售单价",		dtDec),		//10
														 new DataColumn("零售金额",		dtDec),		//11
														 new DataColumn("库位编号",		dtStr),		//12
														 new DataColumn("医疗项目名称",	dtStr),		//13
														 new DataColumn("有效期",		dtDtime),	//14
														 new DataColumn("供货公司",		dtStr),		//15
														 new DataColumn("生产厂商",		dtStr),		//16
														 new DataColumn("上限数量",		dtDec),		//17
														 new DataColumn("下限数量",		dtDec),		//18
														 new DataColumn("库存类型",		dtStr),		//19
														 new DataColumn("是否病区",		dtBool),	//20
														 new DataColumn("缺货标志",		dtBool),	//21
														 new DataColumn("有效标志",		dtBool),	//22
														 new DataColumn("备注",			dtStr),		//23
														 new DataColumn("操作员",		dtStr),		//24
														 new DataColumn("操作日期",		dtDtime),	//25
														 new DataColumn("扩展字段",		dtStr),		//26
														 new DataColumn("拼音码",		dtStr),		//27
														 new DataColumn("五笔码",		dtStr),		//28
														 new DataColumn("自定义码",		dtStr),		//29
														 new DataColumn("医疗项目编码",	dtStr),		//30
														 new DataColumn("公司编码",		dtStr),		//31
														 new DataColumn("厂商编码",		dtStr)		//32
														 });

            this.neuSpread1_Sheet1.DataSource = this.dtData;

            //隐藏部分列
            try
            {
                this.neuSpread1_Sheet1.Columns[0].Visible = false;
                this.neuSpread1_Sheet1.Columns[1].Visible = false;
                this.neuSpread1_Sheet1.Columns[3].Visible = false;
                //this.neuSpread1_Sheet1.Columns[10].Visible = false;
                //this.neuSpread1_Sheet1.Columns[11].Visible = false;
                this.neuSpread1_Sheet1.Columns[26].Visible = false;
                this.neuSpread1_Sheet1.Columns[27].Visible = false;
                this.neuSpread1_Sheet1.Columns[28].Visible = false;
                this.neuSpread1_Sheet1.Columns[29].Visible = false;
                this.neuSpread1_Sheet1.Columns[30].Visible = false;
                this.neuSpread1_Sheet1.Columns[31].Visible = false;
                this.neuSpread1_Sheet1.Columns[32].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //保存格式
            //Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(neuSpread1_Sheet1, xmlFilePath);

        }

        /// <summary>
        /// 设置DataTable
        /// </summary>
        protected virtual void SetDataTable()
        {
            this.dtData = new DataTable();

            this.InitDefaultDataTable();

            #region 可编辑列
            this.hsEditColumn.Clear();

            if (this.GetColumnIndex("有效标志") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("有效标志"), "有效标志");
            if (this.GetColumnIndex("下限数量") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("下限数量"), "下限数量");
            if (this.GetColumnIndex("上限数量") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("上限数量"), "上限数量");
            if (this.GetColumnIndex("有效期") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("有效期"), "有效期");
            if (this.GetColumnIndex("备注") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("备注"), "备注");
            if (this.GetColumnIndex("缺货标志") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("缺货标志"), "缺货标志");
            if (this.GetColumnIndex("货位号") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("货位号"), "货位号");
            #endregion

            try
            {
                if (System.IO.File.Exists(this.xmlFilePath))
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnFormatProperty(this.neuSpread1_Sheet1, this.xmlFilePath);
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(this.neuSpread1_Sheet1, this.xmlFilePath);
                }
            }
            catch
            {
                MessageBox.Show(Language.Msg("读取列配置文件信息发生错误"));
            }
        }

        /// <summary>
        /// 设置DataRow
        /// </summary>
        /// <param name="store">库存实体</param>
        /// <returns>DataRow信息</returns>
        private DataRow SetStorage(Neusoft.HISFC.Models.Material.StoreHead store)
        {
            DataRow row = this.dtData.NewRow();

            try
            {
                row["仓库编码"] = store.StoreBase.StockDept.ID;							//仓库编码
                row["物品编码"] = store.StoreBase.Item.ID;								//物品编码	
                row["科目编码"] = store.StoreBase.Item.MaterialKind.ID;					//科目编码
                row["科目名称"] = store.StoreBase.Item.MaterialKind.Name;				//科目名称
                row["物品名称"] = store.StoreBase.Item.Name;							//物品名称
                row["规格"] = store.StoreBase.Item.Specs;								//规格
                row["库存数量"] = store.StoreBase.StoreQty.ToString();					//库存数量
                row["计量单位"] = store.StoreBase.Item.MinUnit;							//计量单位
                row["单价"] = store.StoreBase.AvgPrice.ToString();						//单价
                //{A9700EF7-BAED-477a-AB2E-5B4818B904A8}库存管理中的库存金额计算有错误
                //row["库存金额"] = store.StoreBase.StoreCost.ToString();					//库存金额
                row["库存金额"] = (store.StoreBase.StoreQty * store.StoreBase.AvgPrice).ToString();

                row["零售单价"] = store.StoreBase.AvgSalePrice.ToString();				//零售单价
                //{A9700EF7-BAED-477a-AB2E-5B4818B904A8}库存管理中的库存金额计算有错误
                //row["零售金额"] = store.StoreBase.RetailCost.ToString();				//零售金额
                row["零售金额"] = (store.StoreBase.StoreQty * store.StoreBase.AvgSalePrice).ToString();

                row["库位编号"] = store.StoreBase.PlaceNO;								//库位编号
                row["医疗项目名称"] = store.StoreBase.Item.UndrugInfo.Name;				//医疗项目名称
                row["医疗项目编码"] = store.StoreBase.Item.UndrugInfo.ID;				//医疗项目编码
                row["有效期"] = store.StoreBase.ValidTime.ToString();					//有效期
                row["供货公司"] = store.StoreBase.Item.Company.Name;					//供货公司名称
                row["生产厂商"] = store.StoreBase.Item.Factory.Name;					//生产厂商名称
                row["上限数量"] = store.TopQty.ToString();								//上限数量
                row["下限数量"] = store.LowQty.ToString();								//下限数量
                row["库存类型"] = store.StoreBase.StockType.ToString();					//库存类型
                row["是否病区"] = store.StoreBase.IsNurse;								//是否病区
                row["缺货标志"] = store.IsLack;											//缺货标志
                row["有效标志"] = NConvert.ToBoolean(store.StoreBase.State);			//有效标志
                row["备注"] = store.Memo;												//备注
                row["操作员"] = store.StoreBase.Operation.Oper.ID.ToString();			//操作员
                row["操作日期"] = store.StoreBase.Operation.Oper.OperTime.ToString();	//操作日期
                row["扩展字段"] = store.StoreBase.Extend;								//扩展字段
                row["拼音码"] = store.StoreBase.Item.SpellCode;						//拼音码
                row["五笔码"] = store.StoreBase.Item.WbCode;							//五笔码
                row["自定义码"] = store.StoreBase.Item.UserCode;						//自定义码
                row["公司编码"] = store.StoreBase.Item.Company.ID;						//公司编码
                row["厂商编码"] = store.StoreBase.Item.Factory.ID;						//厂商编码
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return row;
        }

        /// <summary>
        /// 根据行信息 返回库存信息
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns>库存实体</returns>
        private Neusoft.HISFC.Models.Material.StoreHead GetStorageModifyInfo(DataRow row)
        {
            Neusoft.HISFC.Models.Material.StoreHead storeInfo = new Neusoft.HISFC.Models.Material.StoreHead();

            try
            {
                storeInfo.StoreBase.StockDept.ID = row["仓库编码"].ToString();
                storeInfo.StoreBase.Item.ID = row["物品编码"].ToString();
                storeInfo.StoreBase.PlaceNO = row["库位编号"].ToString();
                storeInfo.StoreBase.ValidTime = NConvert.ToDateTime(row["有效期"]);
                storeInfo.TopQty = NConvert.ToDecimal(row["上限数量"]);
                storeInfo.LowQty = NConvert.ToDecimal(row["下限数量"]);
                storeInfo.IsLack = NConvert.ToBoolean(row["缺货标志"]);
                storeInfo.StoreBase.State = (NConvert.ToInt32(row["有效标志"])).ToString();
                storeInfo.Memo = row["备注"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return storeInfo;
        }

        #endregion

        #region 库存处理

        /// <summary>
        /// 刷新当前库存显示
        /// </summary>
        /// <param name="isResetDataTable">是否重置DataTable</param>
        public void Refresh(bool isResetDataTable)
        {
            if (this.cmbDept.SelectedItem != null)
                this.ShowStorageData(this.cmbDept.SelectedItem.ID, isResetDataTable);
            else
                this.ClearData();
            this.SetFlag(false);
            base.Refresh();
        }


        /// <summary>
        /// 根据科室编码检索库存信息并向DataTable内设置数据 
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        private void ShowStorageData(string deptCode)
        {
            this.ShowStorageData(deptCode, false);
        }


        /// <summary>
        /// 加载库存数据
        /// </summary>
        /// <param name="deptCode">库存科室编码</param>
        /// <param name="isReSetDataTable">是否重置DataTable</param>
        private void ShowStorageData(string deptCode, bool isReSetDataTable)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索库存信息...请稍候");
            Application.DoEvents();

            List<Neusoft.HISFC.Models.Material.StoreHead> alStore = this.storeManager.QueryStockHeadAll(deptCode);
            if (alStore == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(this.storeManager.Err);
                return;
            }

            if (isReSetDataTable)
            {
                this.SetDataTable();
            }
            else
            {
                this.ClearData();
            }

            foreach (Neusoft.HISFC.Models.Material.StoreHead storeInfo in alStore)
            {
                #region 通过参数来判断是否实时检索物品信息
                /*
				if (!this.ValidDateQueryRealTime)
				{
                    storeInfo.StoreBase.ValidTime = 
				}
				*/
                #endregion

                storeInfo.StoreBase.Item = this.itemManager.GetMetItemByMetID(storeInfo.StoreBase.Item.ID);
                this.dtData.Rows.Add(this.SetStorage(storeInfo));
            }

            this.dtData.AcceptChanges();

            this.dvData = this.dtData.DefaultView;
            this.dvData.AllowNew = true;
            this.neuSpread1_Sheet1.DataSource = dvData;

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnFormatProperty(this.neuSpread1_Sheet1, xmlFilePath);

            this.SetFp();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }


        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void Save()
        {
            this.neuSpread1.StopCellEditing();

            this.dvData.RowFilter = "1=1";
            for (int i = 0; i < this.dvData.Count; i++)
            {
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                
               // this.dvData.EndInit();
                this.dvData[i].EndEdit();
            }

            DataTable dtModify = this.dtData.GetChanges(DataRowState.Modified);
            if (dtModify == null || dtModify.Rows.Count <= 0)
            {
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (DataRow dr in dtModify.Rows)
            {
                Neusoft.HISFC.Models.Material.StoreHead storeInfo = this.GetStorageModifyInfo(dr);

                if (storeInfo.LowQty > storeInfo.TopQty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存不能进行。【" + storeInfo.StoreBase.Item.Name + "】最低库存量不能大于库存最高量！", "提示");
                    return;
                }

                if (this.storeManager.UpdateStockHeadStoreParam(storeInfo) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存操作 更新库存失败" + this.storeManager.Err);
                    return;
                }

            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            //{F085BC3C-1D84-4771-A2C6-942713785DD7}
            this.dtData.AcceptChanges();
            MessageBox.Show("保存成功！");

        }


        public void SaveAs()
        {
            this.Save();
        }


        #endregion

        #region 方法

        /// <summary>
        /// 数据导出
        /// </summary>
        protected virtual void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        protected virtual void ClearData()
        {
            if (this.dtData == null)
            {
                this.dtData = new DataTable();
            }
            this.dtData.Clear();
            this.neuSpread1_Sheet1.RowCount = 0;
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        public new void Focus()
        {
            this.txtQueryCode.Select();
            this.txtQueryCode.Focus();
            this.txtQueryCode.SelectAll();
        }

        /// <summary>
        /// 物品明细信息弹出
        /// </summary>
        protected virtual void PopDetail(Neusoft.HISFC.Models.Material.MaterialItem item)
        {
            if (this.DetailUC == null)
            {
                this.DetailUC = new Material.Base.ucMaterialManager();
                this.DetailUC.ReadOnly = true;
            }
            this.DetailUC.InputType = "U";
            this.DetailUC.Item = item;

            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "物资基本信息";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.DetailUC);
        }

        /// <summary>
        /// 根据列名称获取列索引
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <returns>成功返回列索引 失败返回-1</returns>
        private int GetColumnIndex(string colName)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Label == colName)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 显示停用标记 并根据设置 配置有效期显示
        /// </summary>
        ///<param name="isShowMsg">是否弹出提示信息 （特指库存上下限报警）</param>
        protected virtual void SetFlag(bool isShowMsg)
        {
            if (this.neuSpread1_Sheet1.Rows.Count >= 1)
            {
                string warnMsg = "";

                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.SetRowLabel(i, 0, "");
                    this.neuSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = System.Drawing.SystemColors.Control;
                    if (this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("有效标志")].Text.ToUpper() == "FALSE")
                    {
                        this.neuSpread1_Sheet1.SetRowLabel(i, 0, "停");
                        this.neuSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.SetRowLabel(i, 0, i.ToString());
                        this.neuSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = System.Drawing.Color.LightGray;
                    }

                    #region 有效期警示

                    if (this.isValidDateFlag && !this.validDateQueryRealTime)
                    {
                        DateTime tempDate = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("有效期")].Text);
                        if (tempDate > this.sysDate.AddDays(this.validDateCautionDays))
                            this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.White;
                        else
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                    }

                    #endregion

                    #region 库存上下限警示

                    if (this.isWarnStore)
                    {
                        decimal lowQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("库存下限")].Text);
                        decimal topQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("库存上限")].Text);
                        decimal storeQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("库存数量")].Text);

                        if (lowQty == 0 && topQty == 0)
                        {
                            continue;
                        }

                        if (storeQty < lowQty)
                        {
                            if (this.isWarnMessge)
                            {
                                warnMsg = warnMsg + " " + this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("物品名称")].Text;
                            }
                            else
                            {
                                this.neuSpread1_Sheet1.Rows[i].ForeColor = this.warnStoreColor;
                            }
                        }
                    }

                    #endregion
                }

                if (this.isWarnStore && this.isWarnMessge)
                {
                    if (warnMsg != "" && isShowMsg)
                    {
                        MessageBox.Show("以下物品库存量不足下限：\n" + warnMsg);
                    }
                }

                //				this.SetFp();
            }
        }

        #endregion

        #region 组合过滤处理

        /// <summary>
        /// 过滤 只处理通过编码检索过滤
        /// </summary>
        protected virtual void CodeFilter()
        {
            if (this.dtData.Rows.Count <= 0)
                return;

            try
            {
                string queryCode = "";

                if (this.chbMisty.Checked)
                {
                    queryCode = "%" + this.txtQueryCode.Text.Trim() + "%";
                }
                else
                {
                    queryCode = this.txtQueryCode.Text.Trim() + "%";
                }

                //设置过滤条件
                queryCode = "((拼音码 LIKE '" + queryCode + "') OR " +
                    "(五笔码 LIKE '" + queryCode + "') OR " +
                    "(自定义码 LIKE '" + queryCode + "') OR " +
                    "(物品名称 LIKE '" + queryCode + "'))";

                string filter = "";

                filter = Function.GetFilterStr(this.dvData, queryCode);


                //				this.dvData.RowFilter = filter;
                this.dvData.RowFilter = queryCode;

                this.SetFlag(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 组合过滤
        /// </summary>
        protected virtual void CombinedFilter()
        {
            string filterStr = "";
            if (this.chbStock.Checked)
            {
                if (this.cmbStock.Text != "")
                {
                    decimal stockNum = NConvert.ToDecimal(this.txtStockNum.Text);
                    filterStr = Function.ConnectFilterStr(filterStr, string.Format("库存数量 {0} {1}", this.cmbStock.Text, stockNum.ToString()), "and");
                }
            }
            if (this.chbState.Checked == true)
            {
                if (this.cmbState.Text != "")
                {
                    if (this.cmbState.Text == "停用")
                        filterStr = Function.ConnectFilterStr(filterStr, string.Format("有效标志 = {0}", false), "and");
                    else
                        filterStr = Function.ConnectFilterStr(filterStr, string.Format("有效标志 = {0}", true), "and");
                }
            }

            if (this.chbValidDate.Checked)
            {
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("有效期 {0} '{1}'", this.cmbValidDate.Text, this.dptValidDate.Value), "and");

            }

            filterStr = Function.ConnectFilterStr(filterStr, string.Format("科目编码 like '{0}%'", this.nodeTag.ToString()), "and");


            if (this.dvData != null)
            {
                this.dvData.RowFilter = filterStr;

                this.SetFlag(false);
            }
        }

        #endregion

        #region Fp列顺序设置 Fp列跳转处理

        /// <summary>
        /// 列设置
        /// </summary>
        private void SetColumnDisplayOrder()
        {
            this.ucColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            this.ucColumn.FilePath = xmlFilePath;
            this.ucColumn.DisplayEvent += new EventHandler(ucColumn_DisplayEvent);
            this.ucColumn.DisplayEvent -= new EventHandler(ucColumn_DisplayEvent);

            this.isSetJump = false;
            this.ucColumn.SetDataTable(this.xmlFilePath, this.neuSpread1_Sheet1);
            this.ucColumn.SetColVisible(true, true, true, false);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucColumn);
        }


        /// <summary>
        /// 设置列跳转顺序
        /// </summary>
        private void SetColumnJumpOrder()
        {
            #region 跳转设置(暂时屏掉)

            if (this.ucColumn == null)
            {
                this.ucColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
                this.ucColumn.DisplayEvent -= new EventHandler(ucColumn_DisplayEvent);
                this.ucColumn.DisplayEvent += new EventHandler(ucColumn_DisplayEvent);
            }

            this.isSetJump = true;

            this.ucColumn.SetDataTable(this.xmlFilePath, this.neuSpread1_Sheet1);
            this.ucColumn.SetColVisible(false, false, false, true);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "列跳转顺序设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucColumn);

            #endregion
        }


        public void SetColumn()
        {
            this.SetColumnDisplayOrder();
        }


        #endregion

        #region Fp列类型设置

        FarPoint.Win.Spread.CellType.TextCellType readonlyTextCell = new FarPoint.Win.Spread.CellType.TextCellType();

        /// <summary>
        /// 设置Fp只读属性
        /// </summary>
        private void SetFp()
        {
            this.readonlyTextCell.ReadOnly = true;

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Locked = false;
                if (this.hsEditColumn.Contains(i))
                {
                    continue;
                }
                this.neuSpread1_Sheet1.Columns[i].CellType = this.readonlyTextCell;
            }
        }


        #endregion

        #region 库存明细

        /// <summary>
        /// 查询当前选定物品的库存明细信息
        /// </summary>
        protected virtual void GetData()
        {
            this.neuSpread2_Sheet1.Rows.Count = 0;

            if (this.cmbDept.SelectedItem == null)
                return;

            string itemCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.GetColumnIndex("物品编码")].Text;
            string deptCode = this.cmbDept.SelectedItem.ID;

            List<Neusoft.HISFC.Models.Material.StoreDetail> alStorage = this.storeManager.QueryStoreListAll(deptCode, itemCode, true);
            if (alStorage == null)
            {
                MessageBox.Show("获取物品库存明细失败", this.storeManager.Err);
            }
            foreach (Neusoft.HISFC.Models.Material.StoreDetail info in alStorage)
            {
                if (info.StoreBase.StoreQty <= 0)
                    continue;

                this.neuSpread2_Sheet1.Rows.Add(0, 1);
                this.neuSpread2_Sheet1.Cells[0, 0].Text = info.StoreBase.StockNO;
                this.neuSpread2_Sheet1.Cells[0, 1].Text = info.StoreBase.Item.Name;
                this.neuSpread2_Sheet1.Cells[0, 2].Text = info.StoreBase.Item.Specs;
                this.neuSpread2_Sheet1.Cells[0, 3].Text = info.StoreBase.PriceCollection.PurchasePrice.ToString("N");
                this.neuSpread2_Sheet1.Cells[0, 4].Text = info.StoreBase.StoreQty.ToString();
                this.neuSpread2_Sheet1.Cells[0, 5].Text = info.StoreBase.Item.MinUnit;
                this.neuSpread2_Sheet1.Cells[0, 6].Text = info.StoreBase.ValidTime.ToString();

                this.txtDetail.Text = "库存明细 - " + info.StoreBase.Item.Name + "[" + info.StoreBase.Item.Specs + "]";
            }
        }

        public void GetDet()
        {
            this.GetData();
        }

        #endregion

        #region 有效期检索

        /// <summary>
        /// 有效期检索过滤
        /// </summary>
        private void ValidDateFilter()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在按照有效期进行查找\n\n满足条件的物品按颜色显示");

            Application.DoEvents();

            string itemCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.GetColumnIndex("物品编码")].Text;
            string deptCode = this.cmbDept.SelectedItem.ID;
            DateTime minValidDate = System.DateTime.MaxValue;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.validDateQueryRealTime)
                    minValidDate = this.GetMinValidDate(deptCode, itemCode);
                else
                    minValidDate = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("有效期")].Text);
                this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.White;

                switch (this.cmbValidDate.Text)
                {
                    case "<=":
                        if (minValidDate <= this.dptValidDate.Value)
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                        break;
                    case ">=":
                        if (minValidDate >= this.dptValidDate.Value)
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                        break;
                    case "=":
                        if (minValidDate == this.dptValidDate.Value)
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                        break;
                    default:
                        if (minValidDate <= this.dptValidDate.Value)
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                        break;
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }


        /// <summary>
        /// 获取物品有效库存记录的最小有效期
        /// </summary>
        private DateTime GetMinValidDate(string deptCode, string itemCode)
        {
            List<Neusoft.HISFC.Models.Material.StoreDetail> alStorage = this.storeManager.QueryStoreListAll(deptCode, itemCode, true);
            if (alStorage == null)
            {
                MessageBox.Show("获取物品库存明细失败", this.storeManager.Err);
            }
            DateTime validDate = System.DateTime.MaxValue;
            foreach (Neusoft.HISFC.Models.Material.StoreDetail info in alStorage)
            {
                if (info.StoreBase.StoreQty <= 0)
                    continue;
                if (info.StoreBase.ValidTime < validDate)
                    validDate = info.StoreBase.ValidTime;
            }

            return validDate;
        }


        #endregion

        #region 事件

        private void ucColumn_DisplayEvent(object sender, EventArgs e)
        {
            if (this.isSetJump)
            {
                #region 设置列跳转顺序

                List<string> checkCol = this.ucColumn.GetCheckCol(Neusoft.HISFC.Components.Common.Controls.CheckCol.Set);
                this.hsJumpColumn = new Hashtable();
                bool firstColumn = true;
                foreach (string str in checkCol)
                {
                    int iIndex = this.GetColumnIndex(str);
                    this.hsJumpColumn.Add(iIndex, str);
                    if (firstColumn)
                    {
                        this.nowEditColumn = str;
                        firstColumn = false;
                    }
                }

                #endregion
            }
            else
            {
                #region 设置列显示

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在应用列设置...请稍候"));
                Application.DoEvents();

                try
                {
                    this.Refresh(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("应用列设置失败" + ex.Message);
                }
                finally
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                }

                #endregion
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.CombinedFilter();
        }

        private void ucStoreManager_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.DesignMode)
                {
                    this.xmlFilePath = Application.StartupPath + this.xmlFilePath;

                    this.InitData();

                    this.SetDataTable();

                    this.Focus();

                    this.sysDate = this.storeManager.GetDateTimeFromSysDateTime().Date;

                    this.InitDeptList();

                    this.SetFlag(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucMaterialKindTree1_GetLak(object sender, TreeViewEventArgs e)
        {
            this.nodeTag = e.Node.Tag.ToString();

            string filter = "科目编码 like '" + this.nodeTag.ToString() + "%'";

            if (cmbDept.Text == "")
            {
                MessageBox.Show("请选择库存科室！", "提示");
                return;
            }

            dvData.RowFilter = filter;
            this.SetFlag(false);
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.CodeFilter();
        }

        private void txtQueryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex > 0)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex--;
                    return;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex < this.neuSpread1_Sheet1.RowCount)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex++;
                    return;
                }
            }
        }

        private void txtQueryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车时焦点转移到编辑中
            if (e.KeyChar == (char)13)
            {
                this.neuSpread1_Sheet1.ActiveColumnIndex = this.GetColumnIndex(this.nowEditColumn);
                this.neuSpread1.Focus();
            }
        }

        private void neuSpread11_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.neuSpread1.ActiveSheet.RowCount <= 0)
            {
                return;
            }
            int activeRowindex = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            string sHwh = this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("库位编号")].Text;
            if (sHwh.Length >= this.placeNoLength)
            {
                MessageBox.Show("库位编号长度不能大于" + this.placeNoLength.ToString() + "位\n 请查看您刚才输入的库位编号");
                this.neuSpread1.ActiveSheet.SetActiveCell(e.Row, e.Column);
                return;
            }
        }

        private void neuSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.isShowDrugDetail)
            {
                //				if (this.neuSpread2_Sheet1.Rows.Count <= 0)
                //					return;
                //				Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.ActiveRowIndex, this.GetColumnIndex("物品编码")].Text);
                //				if (item != null)
                //				{
                //					this.PopDetail(item);
                //				}
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh(false);
        }

        private void chbState_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbState.Enabled = this.chbState.Checked;
        }

        private void chbValidDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void neuSpread2_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(neuSpread1_Sheet1, xmlFilePath);
        }

        private void txtDetail_Click(object sender, EventArgs e)
        {
            if (this.neuPanel2.Visible)
                this.lnkShowDetail.Text = "显示";
            else
                this.lnkShowDetail.Text = "隐藏";

            this.neuPanel2.Visible = !this.neuPanel2.Visible;
        }

        public void FilterShow()
        {
            this.panelFilter.Visible = !this.panelFilter.Visible;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus && keyData == Keys.Enter)
            {
                int i = this.neuSpread1_Sheet1.ActiveColumnIndex;
                if (this.hsJumpColumn.Contains(i))
                {
                    while (i < this.neuSpread1_Sheet1.Columns.Count - 1)
                    {
                        i++;
                        if (this.hsJumpColumn.Contains(i))
                        {
                            this.neuSpread1_Sheet1.ActiveColumnIndex = i;
                            return true;
                        }
                    }
                    this.neuSpread1_Sheet1.ActiveColumnIndex = 0;
                    this.Focus();
                }
                this.neuSpread1_Sheet1.ActiveColumnIndex++;
            }

            return base.ProcessDialogKey(keyData);
        }

        #endregion
    }
}
