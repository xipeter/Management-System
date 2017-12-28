using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品科室库存管理]<br></br>
    /// [创 建 者: Liangjz]<br></br>
    /// [创建时间: 2007-03]<br></br>
    /// <说明>
    ///     1、有效期自动报警属性设置 IsValidDateFlag 设置为True ValidDateQueryRealTime 设置为False
    ///                 ValidDateCautionColor 设置有效期警示颜色 ValidDateCautionDays设置有效期警示天数
    ///     2、库存上下限报警属性设置 IsWarnStore 设置为True  如需弹出提示设置 IsWarnStoreMessage 为True
    ///                 如设置为False 则设置字体前景色显示 WarnStoreColor 设置警戒色
    /// </说明>
    /// <修改记录>
    ///     <时间>2007-07</时间>
    ///     <修改人>Liangjz</修改人>
    ///     <修改内容>增加默认查询条件设置功能。</修改内容>
    ///     <时间>2007-08-19</时间>
    ///     <修改人>liangjz</修改人>
    ///     <修改内容>增加库存性质的维护功能。</修改内容>
    ///     <时间>2008-01-01</时间>
    ///     <修改人>liangjz</修改人>
    ///     <修改内容>对跳转设置不向本地配置文件内存入。</修改内容>
    ///     <时间>2010-8-23</时间>
    ///     <修改人> sunjh</修改人>
    ///     <修改内容>同步更新快速查询控件指定行{A115CC11-A5B8-4835-9D2E-41733059C82A}</修改内容>
    ///     <修改内容>限制最低库存量不能大于最大库存量 by Sunjh 2010-8-24 {CCAE2615-E287-4629-A163-41675012998B}</修改内容>
    /// </修改记录>
    /// </summary>
    public partial class ucStorageManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucStorageManager()
        {
            InitializeComponent();
        }

        #region 帮助类

        /// <summary>
        /// 药品类别帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper itemTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 药品性质帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 剂型帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper dosageHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept;

        /// <summary>
        /// 是否允许弹出显示明细信息
        /// </summary>
        private bool isShowDrugDetail = true;

        /// <summary>
        /// Xml配置文件路径
        /// </summary>
        private string xmlFilePath = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "\\PharmacyStorageManager.xml";

        /// <summary>
        /// 药品数据集
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
        /// 货位号允许的长度
        /// </summary>
        private int placeNoLength = 12;

        /// <summary>
        /// 药品明细信息显示控件
        /// </summary>
        private Neusoft.HISFC.Components.Pharmacy.Base.ucPharmacyManager DetailDrugUC = null;

        /// <summary>
        /// 是否使用有效期警示
        /// </summary>
        private bool isValidDateFlag = false;

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
        /// 是否进行列顺序设置
        /// </summary>
        private bool isSetJump = false;

        /// <summary>
        /// 药品库存明细有效期获取方式 True 实时获取 每次点击查询时重新获取 False 列表显示时 直接获取有效的库存记录的最小有效期
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
        /// 库存上下限报警时 字体警示色
        /// </summary>
        private Color warnStoreColor = System.Drawing.Color.Blue;

        /// <summary>
        /// 快速查询设定
        /// </summary>
        private System.Collections.Hashtable hsQuickQuery = null;

        /// <summary>
        /// 库存性质名称集合
        /// </summary>
        private string[] qualityNameCollection = null;

        /// <summary>
        /// FY药品性质Combo
        /// </summary>
        private FarPoint.Win.Spread.CellType.ComboBoxCellType qualityComboCellType = null;
       
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
        [Description("货位号允许的长度"), Category("设置"), DefaultValue(12),Browsable(false)]
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
        [Description("是否使用有效期警示"), Category("设置"), DefaultValue(false), Browsable(false)]
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
        [Description("有效期警示颜色"), Category("设置"), Browsable(false)]
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
        [Description("有效期警示天数"), Category("设置"), DefaultValue(90), Browsable(false)]
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
        /// 药品库存明细有效期获取方式 
        /// True 实时获取 每次点击查询时重新获取 False 列表显示时 直接获取有效的库存记录的最小有效期
        /// </summary>
        [Description("药品库存明细有效期获取方式"), Category("设置"), DefaultValue(true), Browsable(false)]
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
        [Description("是否进行库存上下限报警"), Category("设置"), DefaultValue(false), Browsable(false)]
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
        [Description("库存上下限报警时 是否弹出MessageBox提示"), Category("设置"), DefaultValue(false), Browsable(false)]
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
        [Description("库存上下限报警时 字体警示色"), Category("设置"), Browsable(false)]
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

        /// <summary>
        /// 药品数据集
        /// </summary>
        public DataTable DtData
        {
            get 
            {
                return dtData; 
            }
            set 
            { 
                dtData = value; 
            }
        }

        /// <summary>
        /// 数据视图
        /// </summary>
        public DataView DvData
        {
            get 
            {
                return dvData; 
            }
            set 
            { 
                dvData = value; 
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

            toolBarService.AddToolButton("创建查询组合", "保存当前设置的查询组合信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);
            toolBarService.AddToolButton("删除查询组合", "删除当前显示的查询组合信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            toolBarService.AddToolButton("生成警戒线", "根据患者发药数据自动形成警戒线", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分票, true, false, null);

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
                this.SetColumnJumpOrder(true);
            }
            if (e.ClickedItem.Text == "查看明细")
            {
                this.GetData();
            }
            if (e.ClickedItem.Text == "创建查询组合")
            {
                this.SaveQuickQuery();
            }
            if (e.ClickedItem.Text == "删除查询组合")
            {
                this.DelQuickQuery();
            }
            if (e.ClickedItem.Text == "生成警戒线")
            {
                this.SetCaution();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            this.SetFp();

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

        #region 初始化

        /// <summary>
        /// 控制参数获取
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.PlaceNoLength = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_Place_Code, true, 12);
            this.IsValidDateFlag = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Valid_Warn_Enabled, true, true);
            this.ValidDateCautionDays = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Valid_Warn_Days, true, 90);

            string validWarnColor = ctrlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Valid_Warn_Color, true, System.Drawing.Color.Red.ToArgb().ToString());
            this.ValidDateCautionColor = System.Drawing.Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(validWarnColor));

            this.ValidDateQueryRealTime = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Valid_Warn_SourceRealTime, true, true);

            this.IsWarnStore = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Store_Warn_Enabled, true, true);
            this.IsWarnStoreMessage = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Store_Warn_Msg, true, true);
            string storeWarnColor = ctrlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Store_Warn_Color, true, System.Drawing.Color.Blue.ToArgb().ToString());
            this.warnStoreColor = System.Drawing.Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(storeWarnColor));
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected virtual void InitData()
        {
            #region 数据检索加载

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alItemType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alItemType == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品类型名称发生错误!") + consManager.Err);
                itemTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                return;
            }

            Neusoft.FrameWork.Models.NeuObject itemTypeObj = new Neusoft.FrameWork.Models.NeuObject();
            itemTypeObj.ID = "ALL";
            itemTypeObj.Name = "全部";

            alItemType.Insert(0, itemTypeObj);

            itemTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(alItemType);
          
            this.cmbType.AddItems(alItemType);

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            ArrayList alPerson = personManager.GetEmployeeAll();
            if (alPerson == null)
            {
                MessageBox.Show(Language.Msg("获取人员列表发生错误!") + consManager.Err);
                this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                return;
            }
            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPerson);

            ArrayList alQuality = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            if (alQuality == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品性质发生错误!") + consManager.Err);
                this.qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                return;
            }

            this.qualityNameCollection = new string[alQuality.Count];
            int iIndex = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject qualityInfo in alQuality)
            {
                qualityNameCollection[iIndex] = qualityInfo.Name;
                iIndex++;
            }

            Neusoft.FrameWork.Models.NeuObject qualityObj = new Neusoft.FrameWork.Models.NeuObject();
            qualityObj.ID = "ALL";
            qualityObj.Name = "全部";

            alQuality.Insert(0, qualityObj);
            this.qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper(alQuality);
         
            this.cmbQuality.AddItems(alQuality);

            ArrayList alDosage = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM);
            if (alDosage == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取药品剂型发生错误") + consManager.Err);
                return;
            }
            this.dosageHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDosage);


            #endregion

            #region Fp屏蔽回车键

            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            #endregion

            #region 快速查询设定加载

            ArrayList alQuickQuery = consManager.GetList("PhaQuickQuery");
            if (alQuickQuery == null)
            {
                MessageBox.Show(Language.Msg("根据常数类别获取快速查询设定发生错误") + consManager.Err);
                return;
            }

            this.hsQuickQuery = new Hashtable();

            foreach (Neusoft.FrameWork.Models.NeuObject info in alQuickQuery)            
            {              
                this.hsQuickQuery.Add(info.ID, info);
            }

            this.cmbQuickQuery.AddItems(alQuickQuery);

            #endregion
        }
     
        #endregion

        #region 权限相关设置

        private System.Collections.Hashtable hsStopManagerPriv = new Hashtable();

        /// <summary>
        /// 权限设置
        /// </summary>
        protected void PrivManager()
        {
            //{C6AF4B8E-B9D6-4c1e-A5FE-D05F1457E305}
            if (this.cmbDept.SelectedItem != null)
            {
                this.InitStopPriv(this.cmbDept.SelectedItem.ID);
            }
        }

        /// <summary>
        /// 根据所拥有的权限 设置 操作科室
        /// </summary>
        private void InitDeptList()
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerDetailManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            string operCode = powerDetailManager.Operator.ID;
            List<Neusoft.FrameWork.Models.NeuObject> alDept = powerDetailManager.QueryUserPriv(operCode, "0302");
            if (alDept == null)
            {
                MessageBox.Show(Language.Msg("根据库存操作权限获取权限科室发生错误!") + powerDetailManager.Err);
                return;
            }
            this.cmbDept.AddItems(new ArrayList(alDept.ToArray()));

            if (alDept.Count > 0)
                this.cmbDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 权限判断控制
        /// </summary>
        /// <param name="deptCode"></param>
        private void InitStopPriv(string deptCode)
        {
            bool isPriv = false;
            if (hsStopManagerPriv.ContainsKey(deptCode))
            {
                isPriv = (bool)hsStopManagerPriv[deptCode];
            }
            else
            {
                Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerDetailManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

                string operCode = powerDetailManager.Operator.ID;

                isPriv = powerDetailManager.JudgeUserPriv(operCode, deptCode, "0302", "02");

                hsStopManagerPriv.Add(deptCode, isPriv);
            }

            this.neuSpread1_Sheet1.Columns[this.GetColumnIndex("停用")].Locked = !isPriv;
        }

        #endregion

        #region DataTable操作 设置

        /// <summary>
        /// 按照默认设置单据格式
        /// </summary>
        protected virtual void InitDefaultDataTable()
        {
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDTime = System.Type.GetType("System.DateTime");
            System.Type dtBool = System.Type.GetType("System.Boolean");

            //在myDataTable中添加列
            this.dtData.Columns.AddRange(new DataColumn[] {
														new DataColumn("库房编码",    dtStr),//0
														new DataColumn("药品编码",    dtStr),//1
														new DataColumn("自定义码",    dtStr),//2
														new DataColumn("商品名称",    dtStr),//3
														new DataColumn("规格",        dtStr),//4
                                                        new DataColumn("剂型",        dtStr),
														new DataColumn("零售价",      dtDec),//5
                                                        new DataColumn("购入价",      dtDec),
                                                        new DataColumn("库存量",      dtStr),
														new DataColumn("库存数量",    dtDec),//6
														new DataColumn("最小单位",    dtStr),//7
														new DataColumn("包装数量",    dtDec),//8
														new DataColumn("包装单位",    dtStr),//9
														new DataColumn("通用名",      dtStr),//10																		
														new DataColumn("货位号",      dtStr),//11
														new DataColumn("停用",        dtBool),//12
														new DataColumn("最低库存量",  dtDec),//13
														new DataColumn("最高库存量",  dtDec),//14
														new DataColumn("日盘点",      dtBool),//15
                                                        new DataColumn("库存性质",    dtStr),
														new DataColumn("有效期",      dtDTime),//16
														new DataColumn("库存金额",    dtDec),//17
														new DataColumn("预扣数量",    dtDec),//18
														new DataColumn("预扣金额",    dtDec),//19
														new DataColumn("药品类别",    dtStr),//20
														new DataColumn("药品性质",    dtStr),//21
														new DataColumn("备注",        dtStr),//22
														new DataColumn("操作人",      dtStr),//23
														new DataColumn("操作日期",    dtDTime),//24
														new DataColumn("拼音码",      dtStr),//25
														new DataColumn("五笔码",      dtStr),//26																			
														new DataColumn("通用名拼音码",dtStr),//27
														new DataColumn("通用名五笔码",dtStr),//28
														new DataColumn("通用名自定义码",dtStr),//29
				                                        new DataColumn("药库停用",dtBool),//30
				                                        new DataColumn("缺药",dtBool),//31
                                                        new DataColumn("学名",dtStr),
                                                        new DataColumn("别名",dtStr),
                                                        new DataColumn("学名拼音码"),
                                                        new DataColumn("别名拼音码")
                    								});

            this.neuSpread1_Sheet1.DataSource = this.dtData;

            try
            {
                this.neuSpread1_Sheet1.Columns[0].Visible = false;          //库房编码
                this.neuSpread1_Sheet1.Columns[1].Visible = false;          //药品编码
                this.neuSpread1_Sheet1.Columns[27].Visible = false;
                this.neuSpread1_Sheet1.Columns[28].Visible = false;
                this.neuSpread1_Sheet1.Columns[29].Visible = false;
                this.neuSpread1_Sheet1.Columns[30].Visible = false;
                this.neuSpread1_Sheet1.Columns[31].Visible = false;

                this.neuSpread1_Sheet1.Columns[3].Width = 120F;
                this.neuSpread1_Sheet1.Columns[4].Width = 90F;
            }
            catch { }

          //  Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(this.neuSpread1_Sheet1, this.xmlFilePath);

        }

        /// <summary>
        /// 设置DataTable
        /// </summary>
        /// <param name="dt">需设置的DataTable</param>
        protected virtual void SetDataTable()
        {
            this.dtData = new DataTable();

            this.InitDefaultDataTable();

            //if (System.IO.File.Exists(this.xmlFilePath))
            //{
            //    this.dtData = Function.GetDataTableFromXml(this.xmlFilePath);

            //    if (this.dtData == null)
            //    {
            //        this.dtData = new DataTable();

            //        this.InitDefaultDataTable();
            //    }
            //    else
            //    {
            //        this.neuSpread1_Sheet1.DataSource = this.dtData;
            //    }

            //    //Xml存储列设置存在bug 不一定什么时候发生错误 将这几列存储为Text 导致过滤发生错误
            //    if (this.dtData.Columns["库存数量"].DataType != typeof(System.Decimal) || this.dtData.Columns["最低库存量"].DataType != typeof(System.Decimal) ||
            //        this.dtData.Columns["最高库存量"].DataType != typeof(System.Decimal))
            //    {
            //        this.dtData.Columns.Clear();

            //        this.InitDefaultDataTable();
            //    }
            //}
            //else
            //{
            //    #region 根据默认设置DataTable

            //    this.InitDefaultDataTable();
               
            //    #endregion
            //}           

            this.hsEditColumn.Clear();

            if (this.GetColumnIndex("停用") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("停用"), "停用");
            if (this.GetColumnIndex("最低库存量") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("最低库存量"), "最低库存量");
            if (this.GetColumnIndex("最高库存量") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("最高库存量"), "最高库存量");
            if (this.GetColumnIndex("日盘点") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("日盘点"), "日盘点");
            if (this.GetColumnIndex("有效期") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("有效期"), "有效期");
            if (this.GetColumnIndex("备注") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("备注"), "备注");
            if (this.GetColumnIndex("缺药") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("缺药"), "缺药");
            if (this.GetColumnIndex("货位号") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("货位号"), "货位号");
            if (this.GetColumnIndex("库存性质") != -1)
                this.hsEditColumn.Add(this.GetColumnIndex("库存性质"), "库存性质");
        }

        /// <summary>
        /// 根据库存信息 设置DataRow
        /// </summary>
        /// <param name="storage">库存信息</param>
        /// <returns>成功返回数据行信息</returns>
        protected virtual DataRow SetStorage(Neusoft.HISFC.Models.Pharmacy.Storage storage)
        {
            DataRow row = this.dtData.NewRow();
            try
            {
                row["库房编码"] = storage.StockDept.ID;
                row["药品编码"] = storage.Item.ID;
                row["自定义码"] = storage.Item.UserCode;
                row["商品名称"] = storage.Item.Name;
                row["规格"] = storage.Item.Specs;
                row["零售价"] = storage.Item.PriceCollection.RetailPrice;
                row["库存数量"] = storage.StoreQty;

                decimal packQty = Math.Floor(storage.StoreQty / storage.Item.PackQty);
                decimal minQty = storage.StoreQty - packQty * storage.Item.PackQty;
                if (packQty == 0)
                {
                    row["库存量"] = string.Format("{0}{1}", minQty, storage.Item.MinUnit);
                }
                else if (minQty == 0)
                {
                    row["库存量"] = string.Format("{0}{1}", packQty, storage.Item.PackUnit);
                }
                else
                {
                    row["库存量"] = string.Format("{0}{1} {2}{3}", packQty, storage.Item.PackUnit, minQty, storage.Item.MinUnit);
                }

                row["最小单位"] = storage.Item.MinUnit;
                row["包装数量"] = storage.Item.PackQty;
                row["包装单位"] = storage.Item.PackUnit;
                row["通用名"] = storage.Item.NameCollection.RegularName;
                row["货位号"] = storage.PlaceNO;
                row["停用"] = storage.IsStop;
                row["最低库存量"] = storage.LowQty;
                row["最高库存量"] = storage.TopQty;
                row["日盘点"] = storage.IsCheck;
                row["有效期"] = storage.ValidTime;
                row["库存金额"] = storage.StoreCost;
                row["预扣数量"] = storage.PreOutQty;
                row["预扣金额"] = Math.Round(storage.PreOutQty / storage.Item.PackQty * storage.Item.PriceCollection.RetailPrice, 2);
                row["药品类别"] = this.itemTypeHelper.GetName(storage.Item.Type.ID);
                row["药品性质"] = this.qualityHelper.GetName(storage.Item.Quality.ID);
                row["备注"] = storage.Memo;
                row["操作人"] = storage.Operation.Oper.ID;
                row["操作日期"] = storage.Operation.Oper.OperTime;
                row["拼音码"] = storage.Item.NameCollection.SpellCode;
                row["五笔码"] = storage.Item.NameCollection.WBCode;
                row["通用名拼音码"] = storage.Item.NameCollection.RegularSpell.SpellCode;
                row["通用名五笔码"] = storage.Item.NameCollection.RegularSpell.WBCode;
                row["通用名自定义码"] = storage.Item.NameCollection.RegularSpell.UserCode;
                row["药库停用"] = storage.Item.IsStop;
                row["缺药"] = storage.Item.IsLack;

                row["库存性质"] = this.qualityHelper.GetName(storage.ManageQuality.ID);

                row["学名"] = storage.Item.NameCollection.FormalName;
                row["学名拼音码"] = storage.Item.NameCollection.FormalSpell.SpellCode;
                row["别名"] = storage.Item.NameCollection.OtherName;
                row["别名拼音码"] = storage.Item.NameCollection.OtherSpell.SpellCode;

                row["剂型"] = this.dosageHelper.GetName(storage.Item.DosageForm.ID);

                row["购入价"] = storage.Item.PriceCollection.PurchasePrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("根据库存信息对数据行进行赋值时发生错误!") + ex.Message);
            }

            return row;
        }

        /// <summary>
        /// 根据行信息 返回库存信息
        /// </summary>
        /// <param name="row">DataRow信息</param>
        /// <returns>成功返回库存信息</returns>
        private Neusoft.HISFC.Models.Pharmacy.Storage GetStorageModifyInfo(DataRow row)
        {
            Neusoft.HISFC.Models.Pharmacy.Storage storage = new Neusoft.HISFC.Models.Pharmacy.Storage();
            try
            {
                storage.StockDept.ID = row["库房编码"].ToString();
                storage.Item.ID = row["药品编码"].ToString();
                storage.Item.UserCode = row["自定义码"].ToString();
                storage.Item.Name = row["商品名称"].ToString();
                storage.Item.Specs = row["规格"].ToString();
                storage.Item.PriceCollection.RetailPrice = NConvert.ToDecimal(row["零售价"]);
                storage.PlaceNO = row["货位号"].ToString();
                storage.IsStop = NConvert.ToBoolean(row["停用"]);
                storage.LowQty = NConvert.ToDecimal(row["最低库存量"]);
                storage.TopQty = NConvert.ToDecimal(row["最高库存量"]);
                storage.IsCheck = NConvert.ToBoolean(row["日盘点"]);
                storage.ValidTime = NConvert.ToDateTime(row["有效期"]);
                storage.Memo = row["备注"].ToString();
                storage.IsLack = NConvert.ToBoolean(row["缺药"]);
                storage.ManageQuality.ID = this.qualityHelper.GetID(row["库存性质"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("根据库存信息对数据行进行赋值时发生错误!") + ex.Message);
            }

            return storage;
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
        /// 根据科室编码检索库存信息并向DataTable内设置数据
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="isReSetDataTable">是否重置DataTable</param>
        protected virtual void ShowStorageData(string deptCode, bool isReSetDataTable)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在检索显示库存信息...请稍候"));
            Application.DoEvents();

            ArrayList alStorageData = this.itemManager.QueryStockinfoList(deptCode);
            if (alStorageData == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                MessageBox.Show(Language.Msg("获取科室库存信息发生错误!") + this.itemManager.Err);
                return;
            }

            if (isReSetDataTable)
                this.SetDataTable();
            else
                this.ClearData();

            foreach (Neusoft.HISFC.Models.Pharmacy.Storage storage in alStorageData)
            {
                if (!this.validDateQueryRealTime)
                    storage.ValidTime = this.GetMinValidDate(storage.StockDept.ID, storage.Item.ID);
                //不显示药库停用药品 {D6C79B69-0D73-482e-AD94-7B22FCA61E97} wbo 2010-09-23
                //this.dtData.Rows.Add(this.SetStorage(storage));
                if (storage.Item.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    this.dtData.Rows.Add(this.SetStorage(storage));
                }
            }

            this.dtData.AcceptChanges();

            this.dvData = this.dtData.DefaultView;
            this.dvData.AllowNew = true;
            this.neuSpread1_Sheet1.DataSource = this.dvData;

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

                this.SetDrugFlag(true);
            }
            catch
            {
                MessageBox.Show(Language.Msg("读取列配置文件信息发生错误"));
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 科室库存数据保存
        /// </summary>
        protected virtual void Save()
        {
            this.neuSpread1.StopCellEditing();

            this.dvData.RowFilter = "1=1";
            for (int i = 0; i < this.dvData.Count; i++)
            {
                this.dvData[i].EndEdit();
            }

            DataTable dtModify = this.dtData.GetChanges(DataRowState.Modified);
            if (dtModify == null || dtModify.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (DataRow dr in dtModify.Rows)
            {
                Neusoft.HISFC.Models.Pharmacy.Storage storage = this.GetStorageModifyInfo(dr);
                if (storage.LowQty > storage.TopQty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存不能进行。【" + storage.Item.Name + "】最低库存量不能大于库存最高量！"), "提示");
                    return;
                }

                if (this.itemManager.UpdateStockinfoModifyData(storage) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存操作 更新库存失败") + this.itemManager.Err);
                    return;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));
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
                this.dtData = new DataTable();

            this.dtData.Clear();

            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        public new void Focus()
        {
            this.txtQueryCode.Focus();
            this.txtQueryCode.SelectAll();
        }

        /// <summary>
        /// 药品明细信息弹出
        /// </summary>
        protected virtual void PopDrugDetail(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            if (this.DetailDrugUC == null)
            {
                this.DetailDrugUC = new HISFC.Components.Pharmacy.Base.ucPharmacyManager();
                this.DetailDrugUC.ReadOnly = true;
            }
            this.DetailDrugUC.InputType = "UPDATE";
            this.DetailDrugUC.Item = item;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(this.DetailDrugUC);
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
        /// 显示药库停用标记 并根据设置 配置有效期显示
        /// </summary>
        ///<param name="isShowMsg">是否弹出提示信息 （特指库存上下限报警）</param>
        protected virtual void SetDrugFlag(bool isShowMsg)
        {
            if (this.neuSpread1_Sheet1.Rows.Count >= 1)
            { 
                string warnMsg = "";

                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.SetRowLabel(i, 0, "");
                    this.neuSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = System.Drawing.SystemColors.Control;
                    if (this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("药库停用")].Text.ToUpper() == "TRUE")
                    {
                        this.neuSpread1_Sheet1.SetRowLabel(i, 0, "停");
                        this.neuSpread1_Sheet1.RowHeader.Cells[i, 0].BackColor = System.Drawing.Color.White;
                    }

                    #region 有效期警示

                    if (this.isValidDateFlag && !this.validDateQueryRealTime)
                    {
                        DateTime tempDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("有效期")].Text);
                        if (tempDate > this.sysDate.AddDays(this.validDateCautionDays))
                            this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.White;
                        else
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                    }

                    #endregion

                    #region 库存上下限警示

                    if (this.isWarnStore)
                    {
                        decimal lowQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("最低库存量")].Text);
                        decimal topQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("最高库存量")].Text);
                        decimal storeQty = NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("库存数量")].Text);

                        if (lowQty == 0 && topQty == 0)
                        {
                            continue;
                        }

                        if (storeQty < lowQty)
                        {
                            if (this.isWarnMessge)
                            {
                                warnMsg = warnMsg + " " + this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("商品名称")].Text;
                            }
                            else
                            {
                                this.neuSpread1_Sheet1.Rows[i].ForeColor = this.warnStoreColor;
                            }
                        }//设置为蓝色后，过滤后不设置回来是不行的 {51BDB8C0-760F-46c7-9788-DC6C9704079F} wbo 2011-1-12
                        else
                        {
                            this.neuSpread1_Sheet1.Rows[i].ForeColor = Color.Black;
                        }
                    }

                    #endregion
                }

                if (this.isWarnStore && this.isWarnMessge)
                {
                    if (warnMsg != "" && isShowMsg)
                    {
                        MessageBox.Show(Language.Msg("以下药品库存量不足下限：\n" + warnMsg));
                    }
                }

                this.SetFp();
            }
        }

        #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
        /// <summary>
        /// 显示界面上药品条数及总金额
        /// </summary>
        /// <returns></returns>
        private string ShowDrugsInfo()
        {
            /// <summary> 
            /// 界面显示的药品条数
            /// </summary>
            int drugNum = 0;
            /// <summary>
            /// 界面显示的药品的金额
            /// </summary>
            decimal drugCost = Decimal.Zero;

            drugNum = this.neuSpread1_Sheet1.Rows.Count;
            if (drugNum == 0)
            {
                return "药品：0 条        金额：0 元";
            }
            for (int i = 0; i < drugNum; i++)
            {
                decimal cost = Convert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 21].Text);
                drugCost += cost;
            }
            string result = "药品：" + drugNum.ToString() + " 条        金额：" + drugCost.ToString() + " 元";
            return result;
        }
        #endregion

        #endregion

        #region 组合过滤处理

        /// <summary>
        /// 过滤 只处理通过编码检索过滤
        /// </summary>
        protected virtual void CodeFilter()
        {
            if (this.dtData.Rows.Count <= 0)
                return;

            
            string lsFilter =  this.txtQueryCode.Text.Trim();

            lsFilter = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(lsFilter);

            try
            {
                string queryCode = "";
                queryCode = "%" + lsFilter + "%";
                string filter = "";
                this.cmbCondition.Text = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.cmbCondition.Text.Trim());
                if (this.cmbCondition.Text != "全部" && this.cmbCondition.Text != "")
                {
                    filter = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( this.cmbCondition.Text.Trim()) + "  LIKE '" + queryCode + "'";
                }
                else
                {
                    filter = Function.GetFilterStr(this.dvData, queryCode);
                }

                this.dvData.RowFilter = filter;

                this.SetDrugFlag(false);
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
                if (this.cmbStockFilterCondition.Text != "")
                {
                    decimal stockNum = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtStockNum.Text);
                    filterStr = Function.ConnectFilterStr(filterStr, string.Format("库存数量 - 预扣数量 {0} {1}",this.cmbStockFilterCondition.Text,stockNum.ToString()), "and");
                }
            }
            if (this.chbState.Checked == true)
            {
                if (this.cmbState.Text != "")
                {
                    if (this.cmbState.Text == "停用")
                        filterStr =  Function.ConnectFilterStr(filterStr, string.Format("停用 = {0}","true"), "and");
                    else
                        filterStr = Function.ConnectFilterStr(filterStr, string.Format("停用 = {0}", "false"), "and");
                }
            }
            if (this.cmbQuality.Tag != null && this.cmbQuality.Text != "" && this.cmbQuality.Text != "全部")
            {
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("药品性质 = '{0}'",this.cmbQuality.Text), "and");
            }

            if (this.cmbType.Tag != null && this.cmbType.Text != "" && this.cmbType.Text != "全部")
            {
                filterStr = Function.ConnectFilterStr(filterStr, string.Format("药品类别 = '{0}'",this.cmbType.Text), "and");
            }

            if (this.dvData != null)
            {
                this.dvData.RowFilter = filterStr;

                this.SetDrugFlag(false);
            }
        }

        #endregion

        #region Fp列顺序设置 Fp列跳转处理

        /// <summary>
        /// 列设置
        /// </summary>
        private void SetColumnDisplayOrder()
        {
            if (this.ucColumn == null)
            {
                this.ucColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
                this.ucColumn.DisplayEvent -= new EventHandler(ucColumn_DisplayEvent);
                this.ucColumn.DisplayEvent += new EventHandler(ucColumn_DisplayEvent);
            }

            this.isSetJump = false;

            this.ucColumn.IsShowUpDonw = false;
            this.ucColumn.SetDataTable(this.xmlFilePath, this.neuSpread1_Sheet1);
            this.ucColumn.SetColVisible(true, true, true, false);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucColumn);
        }

        ucEasySet ucJumpSet = null;

        /// <summary>
        /// 设置列跳转顺序
        /// </summary>
        /// <param name="isPopShow">初始化后 是否弹出</param>
        private void SetColumnJumpOrder(bool isPopShow)
        {
            //if (this.ucColumn == null)
            //{
            //    this.ucColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            //    this.ucColumn.DisplayEvent -= new EventHandler(ucColumn_DisplayEvent);
            //    this.ucColumn.DisplayEvent += new EventHandler(ucColumn_DisplayEvent);
            //}

            //this.isSetJump = true;

            //this.ucColumn.SetDataTable(this.xmlFilePath, this.neuSpread1_Sheet1);
            //this.ucColumn.SetColVisible(false, false, false, true);
            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "列跳转顺序设置";
            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucColumn);

            if (this.ucJumpSet == null)
            {
                this.ucJumpSet = new ucEasySet();

                this.ucJumpSet.SaveFinishedEvent -= new ucEasySet.DataManagerDelegate(ucJumpSet_SaveFinishedEvent);
                this.ucJumpSet.SaveFinishedEvent += new ucEasySet.DataManagerDelegate(ucJumpSet_SaveFinishedEvent);

                this.ucJumpSet.InitDataEvent -= new ucEasySet.DataManagerDelegate(ucJumpSet_InitDataEvent);
                this.ucJumpSet.InitDataEvent += new ucEasySet.DataManagerDelegate(ucJumpSet_InitDataEvent);
            }

            if (isPopShow)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "列跳转顺序设置";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucJumpSet);
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        private int ucJumpSet_InitDataEvent()
        {
            string strErr = "";

            //Neusoft.FrameWork.WinForms.Classes.Function.DefaultValueFilePath = Application.StartupPath + "\\HISDefaultValue.xml";
            
            //ArrayList al = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("PHA", "StorageManagerJump", out strErr);
            ArrayList al = new ArrayList();

            if (this.ucJumpSet == null)
            {
                this.SetColumnJumpOrder(false);
            }

            if (al == null || al.Count == 0)
            {
                for (int i = 0; i < this.ucJumpSet.FpSv.Rows.Count; i++)
                {
                    this.ucJumpSet.FpSv.Cells[i, 1].Value = false;
                }
            }

            int iValue = 0;
            foreach (string strValue in al)
            {
                this.ucJumpSet.FpSv.Cells[iValue, 1].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(strValue);

                iValue++;
            }
            return 1;
        }

        /// <summary>
        /// 跳转顺序保存
        /// </summary>
        /// <returns></returns>
        private int ucJumpSet_SaveFinishedEvent()
        {
            string strErr = "";

            string[] strValue = new string[this.ucJumpSet.FpSv.Rows.Count];

            //需跳转列赋值
            this.hsJumpColumn = new Hashtable();
            bool firstColumn = true;
            for(int i = 0;i < this.ucJumpSet.FpSv.Rows.Count;i++)
            {
                if (this.ucJumpSet.FpSv.Cells[i,1].Value == null)
                {
                    continue;
                }

                strValue[i] = this.ucJumpSet.FpSv.Cells[i, 1].Value.ToString();

                if (!Neusoft.FrameWork.Function.NConvert.ToBoolean(this.ucJumpSet.FpSv.Cells[i, 1].Value))
                {
                    continue;
                }
                string str = this.ucJumpSet.FpSv.Cells[i, 0].Text;

                int iIndex = this.GetColumnIndex(str);
                this.hsJumpColumn.Add(iIndex, str);

                if (firstColumn)
                {
                    this.nowEditColumn = str;
                    firstColumn = false;
                }
            }

            //Neusoft.FrameWork.WinForms.Classes.Function.DefaultValueFilePath = "\\HISDefaultValue.xml";

            //return Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("PHA", "StorageManagerJump", out strErr, strValue);             

            return 1;
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
                    continue;
                this.neuSpread1_Sheet1.Columns[i].CellType = this.readonlyTextCell;
            }

            if (this.qualityComboCellType == null)
            {
                this.qualityComboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                qualityComboCellType.Items = this.qualityNameCollection;
            }

            this.neuSpread1_Sheet1.Columns[this.GetColumnIndex("库存性质")].CellType = qualityComboCellType;

            if (this.cmbDept.SelectedItem != null && this.cmbDept.SelectedItem.ID != null)
            {
                this.InitStopPriv(this.cmbDept.SelectedItem.ID);
            }
        }

        #endregion

        #region 库存明细

        /// <summary>
        /// 查询当前选定药品的库存明细信息
        /// </summary>
        protected virtual void GetData()
        {
            this.neuSpread2_Sheet1.Rows.Count = 0;

            if (this.cmbDept.SelectedItem == null)
                return;

            //{DC448FDB-1743-4101-940B-B0994B1EDC2D} by niuxy
            if (this.neuSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            string drugCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.GetColumnIndex("药品编码")].Text;
            string deptCode = this.cmbDept.SelectedItem.ID;

            ArrayList alStorage = this.itemManager.QueryStorageList(deptCode, drugCode);
            if (alStorage == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.MessageBox("获取药品库存明细失败", this.itemManager.Err);
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Storage info in alStorage)
            {
                //if (info.StoreQty <= 0)
                //    continue;

                this.neuSpread2_Sheet1.Rows.Add(0, 1);
                this.neuSpread2_Sheet1.Cells[0, 0].Text = info.BatchNO;
                this.neuSpread2_Sheet1.Cells[0, 1].Text = info.Item.Name;
                this.neuSpread2_Sheet1.Cells[0, 2].Text = info.Item.Specs;
                this.neuSpread2_Sheet1.Cells[0, 3].Text = info.Item.PriceCollection.RetailPrice.ToString();
                this.neuSpread2_Sheet1.Cells[0, 4].Text = info.ValidTime.ToString("yyyy-MM-dd");
                this.neuSpread2_Sheet1.Cells[0, 5].Text = info.StoreQty.ToString();
                this.neuSpread2_Sheet1.Cells[0, 6].Text = info.Item.MinUnit;
                this.neuSpread2_Sheet1.Cells[0, 8].Text = info.Memo;

                this.btnDetailHead.Text = "库存明细 - " + info.Item.Name + "[" + info.Item.Specs + "]";
            }
        }

        #endregion

        #region 有效期检索

        /// <summary>
        /// 有效期检索过滤
        /// 
        /// //{F53FB515-9B8A-48ce-A395-C6A0F69B15DC} 效期判断 增加对于不满足条件的行隐藏
        /// </summary>
        private void ValidDateFilter()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在按照有效期进行查找\n满足条件的药品按颜色显示"));
            Application.DoEvents();
            
            string deptCode = this.cmbDept.SelectedItem.ID;
            this.dptValidDate.Value = new System.DateTime(dptValidDate.Value.Year, dptValidDate.Value.Month, dptValidDate.Value.Day, 0, 0, 0);
            DateTime minValidDate = System.DateTime.MaxValue;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                string drugCode = this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("药品编码")].Text;

                if (this.validDateQueryRealTime)
                {
                    minValidDate = this.GetMinValidDate(deptCode, drugCode);
                }
                else
                {
                    minValidDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[i, this.GetColumnIndex("有效期")].Text);
                }

                if (minValidDate == new DateTime(5000, 1, 1, 0, 0, 0))
                {
                    this.neuSpread1_Sheet1.Rows[i].Visible = false;
                    continue;
                }
                else
                {
                    this.neuSpread1_Sheet1.Rows[i].Visible = true;
                }

                minValidDate = minValidDate.Date;

                this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.White;
                switch (this.cmbValidDateFilterCondition.Text)
                {
                    case "<=":
                        if (minValidDate <= this.dptValidDate.Value)
                        {
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                            this.neuSpread1_Sheet1.Rows[i].Visible = true;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Rows[i].Visible = false;
                        }
                        break;
                    case ">=":
                        if (minValidDate >= this.dptValidDate.Value)
                        {
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                            this.neuSpread1_Sheet1.Rows[i].Visible = true;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Rows[i].Visible = false;
                        }
                        break;
                    case "=":
                        if (minValidDate == this.dptValidDate.Value)
                        {
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                            this.neuSpread1_Sheet1.Rows[i].Visible = true;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Rows[i].Visible = false;
                        }
                        break;
                    default:
                        if (minValidDate <= this.dptValidDate.Value)
                        {
                            this.neuSpread1_Sheet1.Rows[i].BackColor = this.validDateCautionColor;
                            this.neuSpread1_Sheet1.Rows[i].Visible = true;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Rows[i].Visible = false;
                        }
                        break;
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 获取药品有效库存记录的最小有效期
        /// </summary>
        protected virtual DateTime GetMinValidDate(string deptCode, string drugCode)
        {
            ArrayList alStorage = this.itemManager.QueryStorageList(deptCode, drugCode);
            if (alStorage == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.MessageBox("获取药品库存明细失败", this.itemManager.Err);
            }

            //{F53FB515-9B8A-48ce-A395-C6A0F69B15DC} 效期判断
            DateTime validDate = new DateTime(5000, 1, 1, 0, 0, 0);
            foreach (Neusoft.HISFC.Models.Pharmacy.Storage info in alStorage)
            {
                if (info.StoreQty <= 0)
                {
                    continue;
                }

                if (info.ValidTime < validDate)
                {
                    validDate = info.ValidTime;
                }
            }

            return validDate;
        }

        #endregion

        #region 快速查询条件设定

        /// <summary>
        /// 快速查询条件保存
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int SaveQuickQuery()
        {
            /*
             * 1、保存格式　Type: Quality: State: StoreCondition: StoreQty
            */

            string saveStr = "Type:{0}Quality:{1}State:{2}StoreCondition:{3}StoreQty:{4}";

            string type = this.cmbType.Tag == null ? "" : this.cmbType.Tag.ToString();
            string quality = this.cmbQuality.Tag == null ? "" : this.cmbQuality.Tag.ToString();

            string state = this.cmbState.Text;
            if (!this.chbState.Checked)
            {
                state = "";
            }

            string storeCondition = this.cmbStockFilterCondition.Text;            
            string storeQty = this.txtStockNum.Text;
            if (!this.chbStock.Checked)
            {
                storeCondition = "";
                storeQty = "";
            }

            frmEasyData frm = new frmEasyData();

            frm.EasyLabel = "查询设定名称";
            frm.MaxLength = 18;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }

            saveStr = string.Format(saveStr, type, quality, state, storeCondition, storeQty);

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();

            cons.ID = consManager.GetDateTimeFromSysDateTime().ToString("yyMMddHH:mm:ss");
            cons.Name = frm.EasyData;
            cons.Memo = saveStr;
            cons.IsValid = true;

            //同步更新快速查询控件指定行 by Sunjh 2010-8-23 {A115CC11-A5B8-4835-9D2E-41733059C82A}
            this.cmbQuickQuery.Items.Add(cons);
            this.hsQuickQuery.Add(cons.ID, cons);

            if (consManager.SetConstant("PhaQuickQuery", cons) == -1)
            {
                MessageBox.Show(Language.Msg("保存快速查询设定信息发生错误") + consManager.Err);
                return -1;
            }            

            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        /// <summary>
        /// 获取快速查询条件设定
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int GetQuickQuery(string quickQueryStr)
        {
            /*
            * 1、保存格式　Type: Quality: State: StoreCondition: StoreQty;
           */

            int privPos = quickQueryStr.IndexOf("Type:");
            int nextPos = quickQueryStr.IndexOf("Quality:");                       

            //获取药品类别查询设定
            string queryType = quickQueryStr.Substring(privPos + 5, nextPos - privPos - 5);
            if (queryType != null)
            {
                this.cmbType.Tag = queryType;
            }

            privPos = nextPos;
            nextPos = quickQueryStr.IndexOf("State:");
            //获取药品性质查询设定
            string queryQuality = quickQueryStr.Substring(privPos + 8, nextPos - privPos - 8);
            if (queryQuality != null)
            {
                this.cmbQuality.Tag = queryQuality;
            }

            privPos = nextPos;
            nextPos = quickQueryStr.IndexOf("StoreCondition:");
            //获取库存状态查询设定
            string queryState = quickQueryStr.Substring(privPos + 6, nextPos - privPos - 6);
            if (queryState != null && queryState != "")
            {                
                this.chbState.Checked = true;
            }
            else
            {                 
                this.chbState.Checked = false;
            }
            this.cmbState.Text = queryState;

            privPos = nextPos;
            nextPos = quickQueryStr.IndexOf("StoreQty:");

            //获取库存数量查询设定
            string queryCondition = quickQueryStr.Substring(privPos + 15, nextPos - privPos - 15);
            if (queryCondition != null && queryCondition != "")
            {
                this.cmbStockFilterCondition.Text = queryCondition;
                this.chbStock.Checked = true;
            }
            else
            {
                this.chbStock.Checked = false;
            }

            privPos = nextPos;
            string queryStore = quickQueryStr.Substring(privPos + 9);
            if (queryStore != null && queryStore != "")
            {
                this.txtStockNum.Text = queryStore;
                this.chbStock.Checked = true;
            }
            else
            {
                this.chbStock.Checked = false;
            }

            return 1;
        }

        /// <summary>
        /// 删除快速查询设定
        /// </summary>
        /// <returns>删除快速查询设定</returns>
        public int DelQuickQuery()
        {
            if (this.cmbQuickQuery.Text == "" || this.cmbQuickQuery.Tag == null)
            {
                MessageBox.Show(Language.Msg("请先选择需删除的条件"));
                return 0;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("确认删除当前显示的快速查询设定吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return -1;
            }
            if (this.hsQuickQuery.ContainsKey(this.cmbQuickQuery.Tag.ToString()))
            {
                Neusoft.FrameWork.Models.NeuObject quickObj = this.hsQuickQuery[this.cmbQuickQuery.Tag.ToString()] as Neusoft.FrameWork.Models.NeuObject;

                Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

                if (consManager.DelConstant("PhaQuickQuery", quickObj.ID) == -1)
                {
                    MessageBox.Show(Language.Msg("删除快速查询设定信息发生错误") + consManager.Err);
                    return -1;
                }
                //同步更新快速查询控件指定行 by Sunjh 2010-8-23 {A115CC11-A5B8-4835-9D2E-41733059C82A}
                this.cmbQuickQuery.Items.RemoveAt(this.cmbQuickQuery.SelectedIndex);

                MessageBox.Show(Language.Msg("删除成功"));
            }

            return 1;
        }

        #endregion

        #region 警戒线设置

        /// <summary>
        /// 自动生成警戒线
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        public int SetCaution()
        {
            //{F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 增加属性赋值
            if (this.cmbDept.SelectedItem == null)
            {
                return -1;
            }

            using (ucPhaAlter uc = new ucPhaAlter())            
            {
                //{F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 增加属性赋值
                uc.DeptCode = this.cmbDept.SelectedItem.ID;
                uc.IsQueryExpandData = true;

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                if (uc.Result == DialogResult.OK)
                {
                    List<Neusoft.FrameWork.Models.NeuObject> alList = uc.ExpandList;
                    if (alList != null)
                    {
                        System.Collections.Hashtable hsList = new Hashtable();
                        foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
                        {
                            hsList.Add(info.ID,info);
                        }
                        foreach (DataRow dr in this.dtData.Rows)
                        {
                            if (hsList.ContainsKey(dr["药品编码"].ToString()))
                            {
                                Neusoft.FrameWork.Models.NeuObject temp = hsList[dr["药品编码"].ToString()] as Neusoft.FrameWork.Models.NeuObject;
                                dr["最低库存量"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp.User02);
                                dr["最高库存量"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(temp.User03);
                               
                                // 消耗为负数的  最高最低设为0
                                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["最低库存量"])<0)
                                { dr["最低库存量"] = 0; }
                                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(dr["最高库存量"])<0)
                                { dr["最高库存量"] = 0; }
                            }
                            else
                            {
                                //没有消耗的 最高最低设为0
                                dr["最低库存量"] = 0;
                                dr["最高库存量"] = 0;
                            }
                        }
                    }

                    MessageBox.Show("警戒线设置成功");
                }
            }

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                if (!this.DesignMode)
                {
                    //if (!Neusoft.HISFC.BizProcess.Integrate.Pharmacy.ChoosePiv("0302"))
                    //    return;

                    this.InitControlParam();

                    this.xmlFilePath = Application.StartupPath + "\\" + this.xmlFilePath;

                    this.InitData();                    

                    this.SetDataTable();

                    this.Focus();

                    this.sysDate = this.itemManager.GetDateTimeFromSysDateTime().Date;

                    this.InitDeptList();

                    this.neuLabel8.AutoSize = false;

                    this.neuLabel8.Width = 180;
                    this.neuLabel8.Height = 34;

                    //跳转列初始化 设置
                    this.ucJumpSet_InitDataEvent();
                    this.ucJumpSet_SaveFinishedEvent();

                    this.PrivManager();

                    #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
                    this.lblShowInfo.Text = this.ShowDrugsInfo();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQueryCode_TextChanged(object sender, EventArgs e)
        {
            this.CodeFilter();
            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
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

        private void neuSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.neuSpread1.ActiveSheet.RowCount <= 0)
            {
                return;
            }
            int activeRowindex = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            string sHwh = this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("货位号")].Text;
            if (sHwh.Length >= this.placeNoLength)
            {
                MessageBox.Show("货位号长度不能大于" + this.placeNoLength.ToString() + "位\n 请查看您刚才输入的货位号");
                this.neuSpread1.ActiveSheet.SetActiveCell(e.Row, e.Column);
                return;
            }
            //限制最低库存量不能大于最大库存量 by Sunjh 2010-8-24 {CCAE2615-E287-4629-A163-41675012998B}
            if (e.Column == this.GetColumnIndex("最低库存量") || e.Column == this.GetColumnIndex("最高库存量"))
            {
                //decimal lowNums = Convert.ToDecimal(this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("最低库存量")].Text);
                //decimal highNums = Convert.ToDecimal(this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("最高库存量")].Text);
                decimal lowNums = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("最低库存量")].Text);
                decimal highNums = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1.ActiveSheet.Cells[activeRowindex, this.GetColumnIndex("最高库存量")].Text);
                if (lowNums > highNums)
                {
                    MessageBox.Show("最低库存量不能大于最高库存量");
                    this.neuSpread1.ActiveSheet.SetActiveCell(e.Row, e.Column);
                    this.neuSpread1.ActiveSheet.Cells[e.Row, this.GetColumnIndex("最低库存量")].Text = "0";
                    return;
                }
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.isShowDrugDetail)
            {
                if (this.neuSpread1_Sheet1.Rows.Count <= 0)
                    return;
                Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.GetColumnIndex("药品编码")].Text);
                if (item != null)
                {
                    this.PopDrugDetail(item);
                }
            }
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh(false);

            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
        }

        private void chbState_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbState.Enabled = this.chbState.Checked;

            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
        }

        private void chbStock_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbStockFilterCondition.Enabled = this.chbStock.Checked;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.CombinedFilter();

            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
        }

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

        private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnFormatProperty(this.neuSpread1_Sheet1, this.xmlFilePath);
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
            }

            return base.ProcessDialogKey(keyData);
        }

        private void lnkShowDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelDetail.Visible)
                this.lnkShowDetail.Text = "显示";
            else
                this.lnkShowDetail.Text = "关闭";

            this.panelDetail.Visible = !this.panelDetail.Visible;
        }

        private void btnValidQuery_Click(object sender, EventArgs e)
        {
            this.ValidDateFilter();

            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
        }

        private void cmbQuickQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbQuickQuery.Tag != null)
            {
                if (this.hsQuickQuery.ContainsKey(this.cmbQuickQuery.Tag.ToString()))
                {
                    Neusoft.FrameWork.Models.NeuObject quickObj = this.hsQuickQuery[this.cmbQuickQuery.Tag.ToString()] as Neusoft.FrameWork.Models.NeuObject;

                    this.GetQuickQuery(quickObj.Memo);
                }
            }

            #region  {8697E862-C5F8-4e42-A7E0-10CB9B18EEBC} 显示界面上药品条数及总金额 by guanyx
            this.lblShowInfo.Text = this.ShowDrugsInfo();
            #endregion
        }
    }
}
