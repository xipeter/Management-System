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

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品调价管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1、({4E0793B1-9BCF-44c0-BB71-7AEB89F0F5EE})
    ///         调价存储过程进行修改，根据参数Nostrum_Manage_Store (P00513) 的设置。如果管理库存 则明细药品调价时包含该明细的协定处方进行处理
    ///         如果不管理库存 则明细药品调价时对包含该明细的协定处方进行处理
    ///    2、处理选择部分药品后再点批量调价出现的BUG by Sunjh 2010-8-23 {DC7BD11C-3A3D-4485-9D25-DE1FE49B4687}
    ///    3、允许删除未生效的调价记录 by Sunjh 2010-8-31 {B56F6FDF-E7D0-4afd-953A-3006AFE257C1}
    ///    4、批量调价时自动计算批发价 by Sunjh 2010-9-1 {B978D218-127A-4511-BB47-0E132AB1860A}
    /// </修改记录>
    /// </summary>
    public partial class ucAdjustPrice : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucAdjustPrice()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// Fp单元格
        /// </summary>
        private FarPoint.Win.Spread.CellType.NumberCellType numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

        /// <summary>
        /// 价格显示位数
        /// </summary>
        private int decimalPlaces = 4;

        /// <summary>
        /// 零售价与批发价的比例系数
        /// </summary>
        private decimal scale = (decimal)1.5;

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper produceHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime dtBegin = System.DateTime.MaxValue;

        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime dtEnd = System.DateTime.MaxValue;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 自动生成调价后零售价
        /// </summary>
        private bool isAutoNewPrice = false;

        /// <summary>
        /// 调价单号
        /// </summary>
        private string adjustNO = "";

        /// <summary>
        /// 当前操作的调价记录
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.AdjustPrice tempOperAdjustPrice = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();

        /// <summary>
        /// 批量调价
        /// </summary>
        private frmGroupAdjust frmGroup = null;

        /// <summary>
        /// 是否刚进行完保存任务
        /// </summary>
        private bool isExeEditModeOffEvent = false;

        private EnumAdjustType adjustType = EnumAdjustType.全院调价;

        /// <summary>
        /// 调价原因CellType
        /// </summary>
        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        #endregion

        #region 属性

        /// <summary>
        /// 报表标题
        /// </summary>
        [Description("报表标题 根据不同医院名称设置"), Category("设置"), DefaultValue("调价单")]
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
        /// 零售价与批发价的比率       
        /// </summary>
        [Description("零售价与批发价的比例"), Category("设置"), DefaultValue(1.5)]
        public decimal Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                scale = value;
            }
        }

        /// <summary>
        /// 价格显示位数
        /// </summary>
        [Description("价格显示位数"), Category("设置"), DefaultValue(4)]
        public int PricePlaces
        {
            get
            {
                return this.decimalPlaces;
            }
            set
            {
                this.decimalPlaces = value;
            }
        }

        /// <summary>
        /// 调价范围
        /// </summary>
        [Description("调价范围"), Category("设置")]
        public EnumAdjustType AdjustType
        {
            get
            {
                return this.adjustType;
            }
            set
            {
                this.adjustType = value;

                if (value == EnumAdjustType.全院调价)
                {
                    this.chkValid.Visible = true;
                }
                else
                {
                    this.chkValid.Visible = false;
                }
            }
        }

        /// <summary>
        /// 是否可以编辑
        /// </summary>
        public bool IsCanEdit
        {
            set
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRetailPrice].Locked = !value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradePrice].Locked = !value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Locked = !value;

                this.chkValid.Enabled = value;
                this.dtpDateTime.Enabled = value;
            }
        }

        /// <summary>
        /// 调价是否即时生效
        /// </summary>
        private bool IsInitInsure
        {
            set
            {
                this.chkValid.Checked = value;
                this.dtpDateTime.Enabled = !value;
            }
        }

        /// <summary>
        /// 是否显示调价单列表节点
        /// </summary>
        private bool IsShowList
        {
            get
            {
                return this.ucChooseList1.IsShowTree;
            }
            set
            {
                this.ucChooseList1.IsShowTree = value;

                this.SetToolButton(value);
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("调价单", "显示调价单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("新  建", "新建调价单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("日  期", "设置调价单检索日期", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y预约, true, false, null);
            toolBarService.AddToolButton("删  除", "删除当前选择的调价药品 删除保存生效", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("批量调价", "按照调价公式进行调价", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "调价单")
            {
                this.ShowList();
            }
            if (e.ClickedItem.Text == "新  建")
            {
                this.New();
            }
            if (e.ClickedItem.Text == "日  期")
            {
                this.ChooseTime();
            }
            if (e.ClickedItem.Text == "删  除")
            {
                //原来判断是否可以删除方法错误 {D225FB27-7805-464f-BDE1-ECC476565456} wbo 2010-10-02
                ////{21347F76-B8F0-4eb6-84C5-49C70E31F467}删除时判断是否是未执行的调价单，如果是已执行的直接提示
                //string title = this.ucChooseList1.TvList.SelectedNode.Text;
                //string flag = title.Substring(title.IndexOf("[") + 1, title.LastIndexOf("]") - title.IndexOf("[") - 1);
                //if (flag == "未执行")
                //{
                //    this.DelData();
                //}
                //else
                //{                
                //    MessageBox.Show("该调价单已执行不能进行删除操作！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                if (this.ucChooseList1 == null || this.ucChooseList1.TvList == null ||
                    this.ucChooseList1.TvList.SelectedNode == null || string.IsNullOrEmpty(this.ucChooseList1.TvList.SelectedNode.Text))
                {
                    //如果左侧列表为空，那么肯定是新加的，直接删除。[业务层删除时也指定了状态是未调价的，所以纵然加载错误导致也无所谓]
                    this.DelData();
                }
                else
                {
                    string title = this.ucChooseList1.TvList.SelectedNode.Text;
                    bool flag = title.Contains("已执行");
                    if (flag == true)
                    {
                        MessageBox.Show("该调价单已执行不能进行删除操作！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.DelData();
                    }
                }
            }
            if (e.ClickedItem.Text == "批量调价")
            {
                this.GroupAdjust();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.adjustType == EnumAdjustType.全院调价)
            {
                this.Save();
            }
            else
            {
                this.SaveDeptAdjust();
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

            return 1;
        }

        public override int SetPrint(object sender, object neuObject)
        {
            return 1;
        }

        /// <summary>
        /// 设置工具栏按钮状态
        /// </summary>
        /// <param name="isShowList">是否处于节点编辑状态</param>
        protected void SetToolButton(bool isShowList)
        {
            this.toolBarService.SetToolButtonEnabled("调价单", !isShowList);
            this.toolBarService.SetToolButtonEnabled("新  建", isShowList);
            this.toolBarService.SetToolButtonEnabled("日  期", isShowList);
            //允许删除未生效的调价记录 by Sunjh 2010-8-31 {B56F6FDF-E7D0-4afd-953A-3006AFE257C1}
            //this.toolBarService.SetToolButtonEnabled("删  除", !isShowList);
            this.toolBarService.SetToolButtonEnabled("批量调价", !isShowList);
        }

        #endregion

        #region 初始化及Fp设置

        /// <summary>
        /// 数据表初始化
        /// </summary>
        private void InitDataTable()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            this.dt = new DataTable();
            //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
            this.dt.Columns.AddRange(
                                    new System.Data.DataColumn[] {
                                                                    new DataColumn("商品名称[规格]",  dtStr),
                                                                    new DataColumn("供货公司",      dtStr),
                                                                    new DataColumn("生产厂家",      dtStr),
                                                                    new DataColumn("原零售价",      dtDec),
                                                                    new DataColumn("原批发价",      dtDec),
                                                                    new DataColumn("原购入价",dtDec),//{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                                                    new DataColumn("现零售价",      dtDec),
                                                                    new DataColumn("现批发价",      dtDec),
                                                                    new DataColumn("现购入价",dtDec),//{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                                                    new DataColumn("差价",      dtDec),
                                                                    new DataColumn("批发价差价",    dtDec),
                                                                    new DataColumn("购入价差价",dtDec),//{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                                                    new DataColumn("调价原因",          dtStr),                                            
                                                                    new DataColumn("药品编码",      dtStr),
                                                                    new DataColumn("拼音码",        dtStr),
                                                                    new DataColumn("五笔码",        dtStr),
                                                                    new DataColumn("自定义码",      dtStr)
                                                                   }
                                  );

            DataColumn[] keys = new DataColumn[1];

            keys[0] = this.dt.Columns["药品编码"];

            this.dt.PrimaryKey = keys;

            this.dt.DefaultView.AllowDelete = true;
            this.dt.DefaultView.AllowEdit = true;
            this.dt.DefaultView.AllowNew = true;

            //this.neuSpread1_Sheet1.DataSource = this.dt;

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;
            this.SetFormat();
        }


        /// <summary>
        /// Fp显示格式化
        /// </summary>
        private void SetFormat()
        {

            //{98B686A3-343D-458a-A005-4B9E8CAAC2F7}
            

            FarPoint.Win.Spread.InputMap im;

            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            //im.Put(new FarPoint.Win.Spread.Keystroke(Keys.MButton, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.numCellType.DecimalPlaces = this.decimalPlaces;
            this.numCellType.SubEditor = null;

            //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPreRetailPrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPreTradePrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPrePurchasePrice].CellType = this.numCellType;//{82D5CEE7-A876-4582-ADC6-3545A7173467}
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRetailPrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradePrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].CellType = this.numCellType;//{82D5CEE7-A876-4582-ADC6-3545A7173467}
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalancePrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalanceTradePrice].CellType = this.numCellType;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalancePurchasePrice].CellType = this.numCellType;//{82D5CEE7-A876-4582-ADC6-3545A7173467}
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradeName].Width = 200F;       //商品名

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Width = 130F;            //调价原因

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPreRetailPrice].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRetailPrice].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalancePrice].Width = 100F;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalanceTradePrice].Width = 120F;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColCompany].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColProduce].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDrugNO].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUserCode].Visible = false;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRetailPrice].Locked = false;
            //{4E42F6D5-1F3C-4b12-BCB7-895239AB9D9A}调批发价
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradePrice].Locked = false;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Locked = false;

            //{82D5CEE7-A876-4582-ADC6-3545A7173467}
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColPurchasePrice].Locked = false;
            

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColRetailPrice].BackColor = System.Drawing.Color.SeaShell;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColTradePrice].BackColor = System.Drawing.Color.SeaShell;
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].BackColor = System.Drawing.Color.SeaShell;

            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBalancePrice].Font = new Font("宋体", 9F, FontStyle.Bold);

            //{8A8F8D41-843A-4b0a-9BA3-0FFBB1B84F10}  调价原因加载
            Neusoft.HISFC.BizProcess.Integrate.Manager manageIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alList = manageIntegrate.QueryConstantList("AdjustCausation");
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("加载调价原因列表发生错误"));
                return;
            }
            if (alList.Count > 0)
            {
                string[] strAdjustCausation = new string[alList.Count];
                int iIndex = 0;
                foreach (Neusoft.FrameWork.Models.NeuObject info in alList)
                {
                    strAdjustCausation[iIndex] = info.Name;
                    iIndex++;
                }
                this.cmbCellType.Items = strAdjustCausation;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].CellType = cmbCellType;
             
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaCons = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            ArrayList alCompany = phaCons.QueryCompany("1");
            if (alCompany == null)
            {
                MessageBox.Show(Language.Msg("加载供货公司列表发生错误"));
                return;
            }
            this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alCompany);
            ArrayList alProduce = phaCons.QueryCompany("0");
            if (alProduce == null)
            {
                MessageBox.Show(Language.Msg("加载生产厂家列表发生错误"));
                return;
            }
            this.produceHelper = new Neusoft.FrameWork.Public.ObjectHelper(alProduce);

            //设置药品列表
            this.ucChooseList1.ShowPharmacyList();            
            //int iDistiance = 140;
            //this.ucChooseList1.GetColumnWidth(2,ref iDistiance);
            //this.splitContainer1.SplitterDistance = iDistiance;
            //设置时间
            this.dtEnd = phaCons.GetDateTimeFromSysDateTime().AddDays(7);
            this.dtBegin = this.dtEnd.AddDays(-10);
            //权限科室 暂时使用操作员科室代替
            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)phaCons.Operator).Dept;

            if (this.adjustType == EnumAdjustType.单科调价)
            {
                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                dept = deptManager.GetDeptmentById(this.privDept.ID);
                if (dept.DeptType.ID.ToString() != "PI")
                {
                    MessageBox.Show(Language.Msg("只有药库允许进行单科调价操作"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.toolBarService.SetToolButtonEnabled("新  建", false);
                    this.toolBarService.SetToolButtonEnabled("保存", false);
                }
                else
                {
                    this.toolBarService.SetToolButtonEnabled("新  建", true);
                }
                return;
            }

            //设置批量调价数据
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            List<Neusoft.HISFC.Models.Pharmacy.Item> alItem = this.itemManager.QueryItemAvailableList(false);
            if (alItem != null)
            {
                if (this.frmGroup == null)
                {
                    this.frmGroup = new frmGroupAdjust();
                }

                List<Neusoft.HISFC.Models.Pharmacy.Item> itemListCollection = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
                foreach (Neusoft.HISFC.Models.Pharmacy.Item info in alItem)
                {
                    //{122BCCB2-A7B5-4644-9550-5AB1000CB663}  协定处方不参与调价
                    if (info.IsNostrum == true)             //协定处方不参与调价
                    {
                        continue;
                    }

                    itemListCollection.Add( info );
                }

                this.frmGroup.AllItem = itemListCollection;
            }
        }

        /// <summary>
        /// 事件处理程序
        /// </summary>
        private void InitEvent()
        {
            this.ucChooseList1.TvList.AfterSelect += new TreeViewEventHandler(TvList_AfterSelect);

            this.ucChooseList1.TvList.DoubleClick += new EventHandler(TvList_DoubleClick);

        }

        /// <summary>
        /// 设置Fp盈亏格式显示
        /// </summary>
        private void SetProfitFlag()
        {
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBalancePrice].Text) > 0)//调赢
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Blue;
                    else if (NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBalancePrice].Text) < 0)//调亏
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Red;
                    else
                        this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Black;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 向DataSet内加入数据
        /// </summary>
        /// <param name="adjust"></param>
        /// <returns></returns>
        private int AddDataToTable(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjust)
        {            
            try
            {
                //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
                this.dt.Rows.Add(new object[] { 
                                            adjust.Item.Name + "[" + adjust.Item.Specs + "]",       //药品名称规格
                                            adjust.Item.Product.Company.Name,                       //供货公司
                                            adjust.Item.Product.Producer.Name,                      //生产厂家
                                            adjust.Item.PriceCollection.RetailPrice.ToString(),                //原零售价
                                            adjust.Item.PriceCollection.WholeSalePrice.ToString(),             //原批发价
                                            adjust.Item.PriceCollection.PurchasePrice.ToString(),//原购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                            adjust.AfterRetailPrice,                                //调价后零售价
                                            adjust.AfterWholesalePrice,//调价后批发价
                                            adjust.AfterPurchasePrice,//调后购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                            adjust.AfterRetailPrice - adjust.Item.PriceCollection.RetailPrice,//差价
                                            adjust.AfterWholesalePrice- adjust.Item.PriceCollection.WholeSalePrice,//批发价差价
                                            adjust.AfterPurchasePrice-adjust.Item.PriceCollection.PurchasePrice,//购入价差价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                                            adjust.Memo,                                            //调价原因
                                            adjust.Item.ID,                                         //药品编码
                                            adjust.Item.NameCollection.SpellCode,                   //拼音码
                                            adjust.Item.NameCollection.WBCode,                      //五笔码
                                            adjust.Item.NameCollection.UserCode,                    //自定义码
                                           });
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
            //neuSpread1.EditModePermanent = true;
            //neuSpread1.EditMode = true;

            return 1;
        }

        /// <summary>
        /// 数据清除显示
        /// </summary>
        protected void Clear()
        {
            try
            {
                this.isExeEditModeOffEvent = true;
                //{7E9B21F7-DD3B-43a8-8E35-AE523E59C74D}防止显示错误页面
                //this.neuSpread1_Sheet1.Rows.Count = 0;//【屏蔽本句】处理选择部分药品后再点批量调价出现的BUG by Sunjh 2010-8-23 {DC7BD11C-3A3D-4485-9D25-DE1FE49B4687}
                this.dt.Rows.Clear();
                this.dt.AcceptChanges();
                //处理选择部分药品后再点批量调价出现的BUG by Sunjh 2010-8-23 {DC7BD11C-3A3D-4485-9D25-DE1FE49B4687}
                this.neuSpread1_Sheet1.RowCount = 0;

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();

                //this.neuSpread1_Sheet1.Rows.Count = 0;

                ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();

                this.lbOperInfo.Text = "";
                this.lblAdjustNumber.Text = "";
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <returns></returns>
        protected int DelData()
        {
            try
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    DialogResult rs = MessageBox.Show(Language.Msg("确认删除该条数据吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == DialogResult.No)
                        return 0;

                    //允许删除未生效的调价记录 by Sunjh 2010-8-31 {B56F6FDF-E7D0-4afd-953A-3006AFE257C1}
                    if (this.itemManager.DeleteAdjustPriceInfo(this.adjustNO, this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text) == -1)
                    {
                        MessageBox.Show("删除调价信息失败!" + this.itemManager.Err);

                        return -1;
                    }

                    this.neuSpread1.StopCellEditing();

                    string[] keys = new string[]{
                                                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text
                                            };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {                       
                        this.dt.Rows.Remove(dr);
                    }

                    this.neuSpread1.StartCellEditing(null, false);

                    this.SetProfitFlag();
                    
                }
            }
            catch (System.Data.DataException e)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("对数据表执行删除操作发生错误" + e.Message));
                return -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("对数据表执行删除操作发生错误" + ex.Message));
                return -1;
            }

            MessageBox.Show("删除调价信息成功!");

            return 1;
        }

        /// <summary>
        /// 获取自动生成零售价
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected decimal GetNewPrice(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            if (this.frmGroup != null)
            {
                return this.frmGroup.GetNewPrice(item);
            }
            else
            {
                return item.PriceCollection.RetailPrice;
            }
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        /// <param name="isFpFocus">是否设置Fp焦点</param>
        protected void SetFocus(bool isFpFocus)
        {
            if (isFpFocus)
            {
                this.neuSpread1.Select();
                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.neuSpread1_Sheet1.ActiveColumnIndex = (int)ColumnSet.ColRetailPrice;
            }
            else
            {
                if (this.neuSpread1_Sheet1.Rows.Count > 0)
                {
                    //最后一个不触发EditMode_Off事件
                    string[] keys = new string[] { this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text };
                    DataRow dr = this.dt.Rows.Find(keys);
                    if (dr != null)
                    {
                        if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColTradePrice)
                        {
                            dr["批发价差价"] = NConvert.ToDecimal(dr["现批发价"]) - NConvert.ToDecimal(dr["原批发价"]);
                            this.neuSpread1.Refresh();
                        }
                        else
                        {
                            //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
                            dr["现批发价"] = System.Math.Round((decimal)dr["现零售价"] / (decimal)Scale, 4);
                            dr["差价"] = NConvert.ToDecimal(dr["现零售价"]) - NConvert.ToDecimal(dr["原零售价"]);
                            dr["批发价差价"] = NConvert.ToDecimal(dr["现批发价"]) - NConvert.ToDecimal(dr["原批发价"]);
                            dr["购入价差价"] = NConvert.ToDecimal(dr["现购入价"]) - NConvert.ToDecimal(dr["原购入价"]);//{82D5CEE7-A876-4582-ADC6-3545A7173467}
                        }
                    }
                }

                this.ucChooseList1.SetFoucs();
            }
        }

        /// <summary>
        /// 检查药品是否在未生效的调用单中存在。
        /// 不可以出现这种情况，两次调价的起始价不连续。
        /// </summary>
        protected bool SearchItem(string drugNO)
        {
            string find = this.itemManager.SearchAdjustPriceByItem(drugNO);
            return (find != "0");
        }

        /// <summary>
        /// 日期选择
        /// </summary>
        protected void ChooseTime()
        {
            //选择时间段，如果没有选择就返回
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.dtBegin, ref this.dtEnd) == 0) 
                return;

            //根据时间，刷新调价单列表
            this.ShowList();
        }

        /// <summary>
        /// 显示一周内调价单列表
        /// </summary>
        protected void ShowList()
        {
            this.ucChooseList1.TreeClear();

            ArrayList alList = null;
            if (this.adjustType == EnumAdjustType.全院调价)
            {
                alList = this.itemManager.QueryAdjustPriceBillList(this.privDept.ID, this.dtBegin, this.dtEnd);
            }
            else
            {
                alList = this.itemManager.QueryAdjustPriceBillList(this.privDept.ID, this.dtBegin, this.dtEnd,true);
            }
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取调价单列表发生错误") + this.itemManager.Err);
                return;
            }
            if (alList.Count == 0)
            {
                TreeNode node = new TreeNode("没有调价单", 0, 0);
                this.ucChooseList1.TvList.Nodes.Add(node);
                this.IsShowList = true;//{D29602F8-5C87-4fe8-A4A1-5B59CBE214BF}
                return;
            }
            else
            {
                TreeNode node = new TreeNode("调价单列表", 0, 0);
                this.ucChooseList1.TvList.Nodes.Add(node);
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice in alList)
            {
                TreeNode node = new TreeNode();
                switch (adjustPrice.State)
                {
                    case "0":           //未执行
                        node.Text = adjustPrice.ID + "[未执行]";
                        node.ForeColor = System.Drawing.Color.Blue;     //蓝色字体显示未执行的
                        node.ImageIndex = 4;
                        node.SelectedImageIndex = 5;
                        break;
                    case "1":           //已执行
                        node.Text = adjustPrice.ID + "[已执行]";
                        node.ImageIndex = 4;
                        node.SelectedImageIndex = 5;
                        break;
                    case "2":           //作废
                        node.Text = adjustPrice.ID + "[作废]";
                        node.ForeColor = System.Drawing.Color.Red;      //红色字体显示作废的
                        node.ImageIndex = 4;
                        node.SelectedImageIndex = 5;
                        break;
                }
                node.Tag = adjustPrice;
                this.ucChooseList1.TvList.Nodes[0].Nodes.Add(node);
            }

            this.ucChooseList1.TvList.Nodes[0].ExpandAll();
            this.ucChooseList1.TvList.SelectedNode = this.ucChooseList1.TvList.Nodes[0];

            this.IsShowList = true;
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        protected void ShowData(Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice)
        {
            this.Clear();

            this.tempOperAdjustPrice = adjustPrice;
            this.adjustNO = adjustPrice.ID;
            //新增调价单
            if (adjustPrice.ID == "")
            {
                this.IsCanEdit = true;
                this.IsInitInsure = true;
                return;
            }

            if (adjustPrice.State == "0")       //修改的调价单       允许编辑
            {
                this.IsCanEdit = true;
                this.IsInitInsure = false;
            }
            else                                //已执行或作废调价单 不允许编辑
            {
                this.IsCanEdit = false;
            }

            ArrayList alDetail = this.itemManager.QueryAdjustPriceInfoList(adjustPrice.ID);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }
            bool isInit = false;            
            foreach (Neusoft.HISFC.Models.Pharmacy.AdjustPrice info in alDetail)
            {
                if (!isInit)
                {
                    this.lblAdjustNumber.Text = "调价单号" + info.ID;                //调价单号
                    this.dtpDateTime.Value = info.InureTime;            //生效时间
                    this.lbOperInfo.Text = string.Format("操作人 {0} 操作时间 {1}", info.Operation.Oper.Name, info.Operation.Oper.OperTime.ToString());
                    isInit = true;
                }

                //应改为由Sql语句内关联获取 此处临时重新获取项目实体来赋值
                Neusoft.HISFC.Models.Pharmacy.Item tempItem = this.itemManager.GetItem(info.Item.ID);

                info.Item.NameCollection.SpellCode = tempItem.NameCollection.SpellCode;
                info.Item.NameCollection.WBCode = tempItem.NameCollection.WBCode;
                info.Item.NameCollection.UserCode = tempItem.NameCollection.UserCode;

                this.AddDataToTable(info);
            }

            this.SetProfitFlag();            
        }

        /// <summary>
        /// 增加新调价项目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected int AddData(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            Neusoft.HISFC.Models.Pharmacy.AdjustPrice adjustPrice = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();

            adjustPrice.Item = item;
            adjustPrice.Item.Product.Company.Name = this.companyHelper.GetName(adjustPrice.Item.Product.Company.ID);
            adjustPrice.Item.Product.Producer.Name = this.produceHelper.GetName(adjustPrice.Item.Product.Producer.ID);
            adjustPrice.AfterWholesalePrice = adjustPrice.Item.PriceCollection.WholeSalePrice;//{DC10D9C4-062C-4a92-8F16-08B5491E817E}
            adjustPrice.AfterPurchasePrice = adjustPrice.Item.PriceCollection.PurchasePrice;//{82D5CEE7-A876-4582-ADC6-3545A7173467}
            if (this.isAutoNewPrice)
            {
                #region 自动生成新价格

                adjustPrice.AfterRetailPrice = this.GetNewPrice(adjustPrice.Item);

                #endregion
            }
            else
            {
                #region 手工输入新价格

                adjustPrice.AfterRetailPrice = adjustPrice.Item.PriceCollection.RetailPrice;

                #endregion
            }

            return this.AddDataToTable(adjustPrice);
        }

        /// <summary>
        /// 有效性
        /// </summary>
        /// <returns></returns>
        protected bool Valid()
        {
            if (this.tempOperAdjustPrice == null || this.tempOperAdjustPrice.State == "1" || this.tempOperAdjustPrice.State == "2")
            {
                MessageBox.Show(Language.Msg("已执行或作废的调价单不能在进行保存修改"));
                return false;
            }

            foreach (DataRow dr in this.dt.Rows)
            {
                if (NConvert.ToDecimal(dr["现零售价"]) <= 0)
                {
                    MessageBox.Show(Language.Msg("调价后零售价不能小于等于0"),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }
                if (NConvert.ToDecimal(dr["现批发价"]) <= 0)
                {
                    MessageBox.Show(Language.Msg("调价后批发价不能小于等于0"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (NConvert.ToDecimal(dr["原零售价"]) == NConvert.ToDecimal(dr["现零售价"]) && NConvert.ToDecimal(dr["原批发价"]) == NConvert.ToDecimal(dr["现批发价"]) && NConvert.ToDecimal(dr["原购入价"]) == NConvert.ToDecimal(dr["现购入价"]))//{82D5CEE7-A876-4582-ADC6-3545A7173467}
                {
                    MessageBox.Show(Language.Msg("调价前后零售价,批发价和购入价不能都相同"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 新建调价单
        /// </summary>
        /// <returns></returns>
        protected int New()
        {
            TreeNode node = new TreeNode();
            node.Text = "新建调价单";
            node.ImageIndex = 4;
            node.SelectedImageIndex = 4;
            node.Tag = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();

            this.ucChooseList1.TvList.Nodes[0].Nodes.Insert(0, node);

            //选中此新节点
            this.ucChooseList1.TvList.SelectedNode = node;

            this.IsShowList = false;

            this.ucChooseList1.SetFoucs();

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected int Save()
        {
            #region 有效性判断

            this.neuSpread1.StopCellEditing();

            if (!this.Valid())
            {
                return 0;
            }

            #endregion

            ////系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            #region 生效时间判断

            //生效时间
            DateTime insureTime;
            if (this.chkValid.Checked)
                insureTime = sysTime;
            else
                insureTime = this.dtpDateTime.Value;

            //判断生效时间是否大于当前时间
            if (insureTime < sysTime)
            {
                MessageBox.Show(Language.Msg("调价生效时间必须大于当前时间。"), "生效时间提示");
                return 0;
            }

            #endregion

            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                this.dt.Rows[i].EndEdit();
            }

            #region 事务定义

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            #region 对修改调价单删除原调价单信息 对新调价单获取调价单号

            if (this.adjustNO != "")
            {
                if (this.itemManager.DeleteAdjustPriceInfo(this.adjustNO) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存前删除原调价单信息发生错误" + this.itemManager.Err));
                    return -1;
                }
            }
            else
            {
                adjustNO = this.itemManager.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                if (adjustNO == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获取新调价单号出错" + this.itemManager.Err));
                    return -1;
                }
            }

            #endregion

            int serialNO = 0;
            ArrayList alAdjustData = new ArrayList();

            ///{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}     参与调价的协定方药品 以下1、2、3 ...标号的地方为变更点
            Dictionary<string, Neusoft.HISFC.Models.Pharmacy.AdjustPrice> adjustNostrumList = new Dictionary<string, Neusoft.HISFC.Models.Pharmacy.AdjustPrice>();
            //调价处方明细
            Dictionary<string, List<Neusoft.HISFC.Models.Pharmacy.Nostrum>> nostrumDetailList = new Dictionary<string, List<Neusoft.HISFC.Models.Pharmacy.Nostrum>>();

            foreach (DataRow dr in this.dt.Rows)
            {
                #region 调价信息处理

                Neusoft.HISFC.Models.Pharmacy.AdjustPrice info = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();
                string drugNO = dr["药品编码"].ToString();
                if (this.SearchItem(drugNO))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(dr["商品名称[规格]"].ToString() + "已经在未生效的调价单中存在，不能在此添加。"));
                    return -1;
                }

                info.Item = this.itemManager.GetItem(drugNO);

                info.ID = this.adjustNO;                        //调价单号
                info.SerialNO = serialNO;                       //调价单内序号
                info.StockDept = this.privDept;                 //调价科室
                info.State = "0";                               //调价单状态：0、未调价；1、已调价；2、无效
                info.Operation.Oper.ID = this.itemManager.Operator.ID;       //操作员
                info.Operation.Oper.Name = this.itemManager.Operator.Name;  //操作员姓名
                info.Operation.Oper.OperTime = sysTime;                     //操作时间

                info.InureTime = insureTime;                    //生效时间

                info.AfterRetailPrice = NConvert.ToDecimal(dr["现零售价"]); //调价后零售价
                //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
                info.AfterWholesalePrice = NConvert.ToDecimal(dr["现批发价"]); //调价后批发价
                info.AfterPurchasePrice = NConvert.ToDecimal(dr["现购入价"]);//调价后购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
                info.Memo = dr["调价原因"].ToString();

                if (info.Item.PriceCollection.RetailPrice > info.AfterRetailPrice)
                    info.ProfitFlag = "0";
                else
                    info.ProfitFlag = "1";

                if (this.itemManager.InsertAdjustPriceInfo(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存发生错误" + this.itemManager.Err));
                    return -1;
                }

                #endregion

                alAdjustData.Add(info);

                #region {E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}  协定方调价处理
                // 1. 根据当前调价药品ID，获取包含该药品的协定处方信息
                List<Neusoft.HISFC.Models.Pharmacy.Nostrum> nostrumList = this.itemManager.QueryNostrumListByDetail( info.Item.ID );
                if (nostrumList == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( "根据明细项目获取协定方列表信息发生错误   " + this.itemManager.Err );
                    return -1;
                }
                //2. 对所有包含该药品的协定处方 循环进行调价信息赋值处理
                foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum tempNostrum in nostrumList)
                {
                    //协定处方主信息
                    Neusoft.HISFC.Models.Pharmacy.AdjustPrice tempNostrumAdjust = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();

                    if (adjustNostrumList.ContainsKey( tempNostrum.ID ) == true)            //之前已生成调价信息，对价格重新赋值
                    {
                        #region 2.1 之前已形成过调价信息
                        //协定处方主信息
                        tempNostrumAdjust = adjustNostrumList[tempNostrum.ID];

                        tempNostrumAdjust.AfterRetailPrice = 0;
                        tempNostrumAdjust.AfterWholesalePrice = 0;

                        //2.1.1 根据明细计算新零售价
                        List<Neusoft.HISFC.Models.Pharmacy.Nostrum> tempNostrumDetail = new List<Neusoft.HISFC.Models.Pharmacy.Nostrum>();
                        if (nostrumDetailList.ContainsKey( tempNostrum.ID ) == true)          //已获取到处方明细信息
                        {
                            tempNostrumDetail = nostrumDetailList[tempNostrum.ID];
                        }
                        else
                        {
                            tempNostrumDetail = this.itemManager.QueryNostrumDetail( tempNostrum.ID );
                            if (tempNostrumDetail == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show( "根据明细调价生成协定处方调价信息时发生错误" + this.itemManager.Err );
                                return -1;
                            }
                            nostrumDetailList.Add( tempNostrum.ID, tempNostrumDetail );
                        }
                        foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum computeNostrum in tempNostrumDetail)
                        {
                            if (computeNostrum.Item.ID == info.Item.ID)                 //明细内ID = 当前调价ID
                            {
                                computeNostrum.Item.PriceCollection.RetailPrice = info.AfterRetailPrice;
                                computeNostrum.Item.PriceCollection.WholeSalePrice = info.AfterWholesalePrice;
                            }

                            tempNostrumAdjust.AfterRetailPrice += computeNostrum.Qty  / computeNostrum.Item.PackQty * computeNostrum.Item.PriceCollection.RetailPrice;
                            tempNostrumAdjust.AfterWholesalePrice += computeNostrum.Qty  / computeNostrum.Item.PackQty * computeNostrum.Item.PriceCollection.WholeSalePrice;
                        }

                        //2.1.2  形成调价记录 相关状态更新赋值
                        tempNostrumAdjust.AfterRetailPrice = Math.Round( tempNostrumAdjust.AfterRetailPrice, 2 );
                        tempNostrumAdjust.AfterWholesalePrice = Math.Round( tempNostrumAdjust.AfterWholesalePrice, 2 );

                        if (tempNostrumAdjust.Item.PriceCollection.RetailPrice > tempNostrumAdjust.AfterRetailPrice)
                        {
                            tempNostrumAdjust.ProfitFlag = "0";
                        }
                        else
                        {
                            tempNostrumAdjust.ProfitFlag = "1";
                        }

                        #endregion
                    }
                    else
                    {
                        #region 2.2 之前无调价信息 重新生成

                        serialNO++;                                                         //对新增记录序列号增加

                        //2.2.1 获取协定处方药品字典信息
                        tempNostrumAdjust.Item = this.itemManager.GetItem( tempNostrum.ID );

                        //2.2.2 协定处方调价信息赋值
                        tempNostrumAdjust.ID = this.adjustNO;
                        tempNostrumAdjust.SerialNO = serialNO;                       //调价单内序号
                        tempNostrumAdjust.StockDept = this.privDept;                 //调价科室
                        tempNostrumAdjust.State = "0";                               //调价单状态：0、未调价；1、已调价；2、无效
                        tempNostrumAdjust.Operation.Oper.ID = this.itemManager.Operator.ID;       //操作员
                        tempNostrumAdjust.Operation.Oper.Name = this.itemManager.Operator.Name;  //操作员姓名
                        tempNostrumAdjust.Operation.Oper.OperTime = sysTime;                     //操作时间

                        tempNostrumAdjust.InureTime = insureTime;                    //生效时间

                        tempNostrumAdjust.Memo = info.Item.ID + "  明细调整，对应协定处方调价";

                        //2.2.2 根据明细计算新零售价
                        tempNostrumAdjust.AfterRetailPrice = 0;
                        tempNostrumAdjust.AfterWholesalePrice = 0;

                        List<Neusoft.HISFC.Models.Pharmacy.Nostrum> tempNostrumDetail = new List<Neusoft.HISFC.Models.Pharmacy.Nostrum>();
                        if (nostrumDetailList.ContainsKey( tempNostrum.ID ) == true)          //已获取到处方明细信息
                        {
                            tempNostrumDetail = nostrumDetailList[tempNostrum.ID];
                        }
                        else
                        {
                            tempNostrumDetail = this.itemManager.QueryNostrumDetail( tempNostrum.ID );
                            if (tempNostrumDetail == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show( "根据明细调价生成协定处方调价信息时发生错误" + this.itemManager.Err );
                                return -1;
                            }
                            nostrumDetailList.Add( tempNostrum.ID, tempNostrumDetail );
                        }
                        foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum computeNostrum in tempNostrumDetail)
                        {
                            if (computeNostrum.Item.ID == info.Item.ID)                 //明细内ID = 当前调价ID
                            {
                                computeNostrum.Item.PriceCollection.RetailPrice = info.AfterRetailPrice;
                                computeNostrum.Item.PriceCollection.WholeSalePrice = info.AfterWholesalePrice;
                            }
                            //协定方价格计算：即生产一包装单位协定方所需明细总额即协定方单价
                            tempNostrumAdjust.AfterRetailPrice += computeNostrum.Qty / computeNostrum.Item.PackQty * computeNostrum.Item.PriceCollection.RetailPrice;
                            tempNostrumAdjust.AfterWholesalePrice += computeNostrum.Qty / computeNostrum.Item.PackQty * computeNostrum.Item.PriceCollection.WholeSalePrice;
                        }

                        //2.2.3  形成调价记录 相关状态更新赋值
                        tempNostrumAdjust.AfterRetailPrice = Math.Round( tempNostrumAdjust.AfterRetailPrice, 2 );
                        tempNostrumAdjust.AfterWholesalePrice = Math.Round( tempNostrumAdjust.AfterWholesalePrice, 2 );

                        if (tempNostrumAdjust.Item.PriceCollection.RetailPrice > tempNostrumAdjust.AfterRetailPrice)
                        {
                            tempNostrumAdjust.ProfitFlag = "0";
                        }
                        else
                        {
                            tempNostrumAdjust.ProfitFlag = "1";
                        }

                        adjustNostrumList.Add( tempNostrum.ID, tempNostrumAdjust );

                        #endregion
                    }                   
                }

                #endregion

                serialNO++;
            }

            #region 3. 对协定处方药品形成调价记录  {E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}

            foreach (Neusoft.HISFC.Models.Pharmacy.AdjustPrice tempAdjust in adjustNostrumList.Values)
            {
                if (this.itemManager.InsertAdjustPriceInfo( tempAdjust ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( Language.Msg( "保存发生错误" + this.itemManager.Err ) );
                    return -1;
                }
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.Print(alAdjustData);

            #region 对立即生效的执行存储过程

            if (this.chkValid.Checked)
            {
                if (this.itemManager.ExecProcedureChangPrice() == -1)
                {
                    MessageBox.Show(Language.Msg("执行调价存储过程发生错误" + this.itemManager.Err));
                    return -1;
                }
            }

            #endregion

            MessageBox.Show(Language.Msg(" 保存成功 "));

            this.Clear();

            this.ShowList();

            return 1;
        }

        /// <summary>
        /// 保存单科室调价信息
        /// </summary>
        /// <returns></returns>
        protected int SaveDeptAdjust()
        {
            #region 有效性判断

            if (!this.Valid())
            {
                return 0;
            }

            #endregion

            ////系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            #region 生效时间判断

            //生效时间
            DateTime insureTime;
            if (this.chkValid.Checked)
                insureTime = sysTime;
            else
                insureTime = this.dtpDateTime.Value;

            //判断生效时间是否大于当前时间
            if (insureTime < sysTime)
            {
                MessageBox.Show(Language.Msg("调价生效时间必须大于当前时间。"), "生效时间提示");
                return 0;
            }

            #endregion

            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                this.dt.Rows[i].EndEdit();
            }

            #region 事务定义
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            #region 对修改调价单删除原调价单信息 对新调价单获取调价单号

            if (this.adjustNO != "")
            {
                if (this.itemManager.DeleteAdjustPriceInfo(this.adjustNO) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存前删除原调价单信息发生错误" + this.itemManager.Err));
                    return -1;
                }
            }
            else
            {
                adjustNO = this.itemManager.GetSequence("Pharmacy.Item.GetNewAdjustPriceID");
                if (adjustNO == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获取新调价单号出错" + this.itemManager.Err));
                    return -1;
                }
            }

            #endregion

            int serialNO = 0;
            foreach (DataRow dr in this.dt.Rows)
            {
                #region 调价信息处理

                Neusoft.HISFC.Models.Pharmacy.AdjustPrice info = new Neusoft.HISFC.Models.Pharmacy.AdjustPrice();
                string drugNO = dr["药品编码"].ToString();

                #region 库存量判断

                decimal storageNum = 1;
                if (this.itemManager.GetStorageNum(this.privDept.ID, drugNO, out storageNum) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("获取科室当前库存时发生错误") + this.itemManager.Err);
                    return -1;
                }
                if (storageNum > 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(dr["商品名称[规格]"].ToString() + "当前仍存在库存量，不能进行单科调价"));
                    return -1;
                }

                #endregion

                if (this.SearchItem(drugNO))
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(dr["商品名称[规格]"].ToString() + "已经在未生效的调价单中存在，不能在此添加。"));
                    return -1;
                }

                info.Item = this.itemManager.GetItem(drugNO);               

                info.ID = this.adjustNO;                        //调价单号
                info.SerialNO = serialNO;                       //调价单内序号
                info.StockDept = this.privDept;                 //调价科室
                info.State = "1";                               //调价单状态：0、未调价；1、已调价；2、无效
                info.Operation.Oper.ID = this.itemManager.Operator.ID;       //操作员
                info.Operation.Oper.Name = this.itemManager.Operator.Name;  //操作员姓名
                info.Operation.Oper.OperTime = sysTime;                     //操作时间

                info.InureTime = insureTime;                    //生效时间

                info.AfterRetailPrice = NConvert.ToDecimal(dr["现零售价"]); //调价后零售价
                info.Memo = dr["调价原因"].ToString() + " - 单科调价";

                info.IsDDAdjust = true;

                if (info.Item.PriceCollection.RetailPrice > info.AfterRetailPrice)
                    info.ProfitFlag = "0";
                else
                    info.ProfitFlag = "1";

                if (this.itemManager.InsertAdjustPriceInfo(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("单科调价保存调价汇总发生错误" + this.itemManager.Err));
                    return -1;
                }

                if (this.itemManager.InsertAdjustPriceDetail(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("单科调价保存调价明细发生错误" + this.itemManager.Err));
                    return -1;
                }

                int param = this.itemManager.UpdateStoragePrice(info.StockDept.ID, info.Item.ID, info.AfterRetailPrice);
                if (param == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新单科价格信息发生错误") + this.itemManager.Err);
                    return -1;
                }
                else if (param == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(dr["商品名称[规格]"].ToString() + Language.Msg("单科调价药品必须是曾经做过入库的药品，当前药品在本科无库存"));
                    return -1;
                }

                serialNO++;

                #endregion
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg(" 保存成功 "));

            this.Clear();

            this.ShowList();

            return 1;
        }

        /// <summary>
        /// 批量调价
        /// </summary>
        /// <returns></returns>
        protected int GroupAdjust()
        {
            if (this.frmGroup == null)
            {
                this.frmGroup = new frmGroupAdjust();
            }

            DialogResult rsT = this.frmGroup.ShowDialog();
            if (rsT == System.Windows.Forms.DialogResult.OK)
            {
                //{D5CD15B5-617B-4a06-9EBC-7BC589CBD7D9} 允许按药品类别批量调价 需设置ckOnlyPrice.Visible = true
                if (this.frmGroup.PriceException == "")
                {
                    this.isAutoNewPrice = false;
                }
                else
                {
                    this.isAutoNewPrice = true;
                }

                if (this.frmGroup.AdjustItems == null)
                    return 0;

                if (this.frmGroup.AdjustItems.Count > 0)
                {
                    System.Windows.Forms.DialogResult rs;
                    rs = MessageBox.Show(Language.Msg("使用批量调价将清除当前数据 是否继续"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (rs == System.Windows.Forms.DialogResult.No)
                        return -1;

                    this.Clear();

                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在添加需调价药品数据 请稍候..");
                    Application.DoEvents();

                    int i = 1;
                    foreach (Neusoft.HISFC.Models.Pharmacy.Item info in this.frmGroup.AdjustItems)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, this.frmGroup.AdjustItems.Count);
                        Application.DoEvents();

                        i++;
                        
                        //this.AddData(info);
                        if (this.AddData(info) == -1)
                        {
                            i--;
                        }
                        //批量调价时自动计算批发价 by Sunjh 2010-9-1 {B978D218-127A-4511-BB47-0E132AB1860A}
                        if (this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
                        {
                            string[] keys = new string[] { this.neuSpread1_Sheet1.Cells[i - 2, (int)ColumnSet.ColDrugNO].Text };
                            DataRow dr = this.dt.Rows.Find(keys);
                            if (dr != null)
                            {
                                //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
                                dr["现批发价"] = System.Math.Round((decimal)dr["现零售价"] / (decimal)Scale, 4);
                                dr["差价"] = NConvert.ToDecimal(dr["现零售价"]) - NConvert.ToDecimal(dr["原零售价"]);
                                dr["批发价差价"] = NConvert.ToDecimal(dr["现批发价"]) - NConvert.ToDecimal(dr["原批发价"]);

                                this.SetProfitFlag();
                            }
                        }

                    }
                    this.SetProfitFlag();//{DC10D9C4-062C-4a92-8F16-08B5491E817E}
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                }
                this.isAutoNewPrice = true;
            }

            return 1;
        }

        protected int Print(ArrayList alAdjustData)
        {
            Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint billPrint = null;

            billPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint;

            if (billPrint != null)
            {
                DialogResult rs = MessageBox.Show("是否打印调价单", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    billPrint.SetData(alAdjustData, Neusoft.HISFC.BizProcess.Interface.Pharmacy.BillType.Adjust);
                    billPrint.Print();
                }
            }

            return 1;
        }

        /// <summary>
        /// 入出库业务中间数据校验提示
        /// </summary>
        /// <param name="itemCode">药品编码</param>
        /// <returns>成功返回True 失败返回False</returns>
        protected bool InterimDataVerify(string itemCode)
        {
            return true;
        }

        #endregion

        private void ucAdjustPrice_Load(object sender, EventArgs e)
        {
            this.ucChooseList1.TvList.ImageList = this.ucChooseList1.TvList.deptImageList;

            this.InitDataTable();

            this.SetFormat();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitData();

                this.InitEvent();

                this.ShowList();
            }
            
        }

        private void ucChooseList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRowIndex)
        {
            if (activeRowIndex < 0) 
                return;

            string drugNO = sv.Cells[activeRowIndex, 0].Value.ToString();

            string[] keys = new string[]{drugNO};
            DataRow dr = this.dt.Rows.Find(keys);
            if (dr != null)
            {
                MessageBox.Show(Language.Msg("该药品已添加"));
                return;
            }
            if (this.SearchItem(drugNO))
            {
                MessageBox.Show(Language.Msg("此药品的上次调价还未生效，不能重复调价。"), "");
                return;
            }

            //根据药品编码，取药品信息
            Neusoft.HISFC.Models.Pharmacy.Item item = this.itemManager.GetItem(drugNO);
            if (item == null)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
                return;
            }

            #region 协定处方调价提示

            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> nostrumList = this.itemManager.QueryNostrumListByDetail( item.ID );
            if (nostrumList == null)
            {
                MessageBox.Show( Language.Msg( this.itemManager.Err ) );
                return;
            }

            if (nostrumList.Count > 0)
            {
                MessageBox.Show( "该药品属于多个协定处方的组成成分内，对该药品调价将会引起关联协定处方的调价","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            #endregion

            if (this.AddData(item) == 1)
            {
                this.SetFocus(true);
            }
            else
            {
                this.SetFocus(false);
            }           
        }

        private void TvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.ucChooseList1.TvList.SelectedNode.Tag != null)
            {
                if (this.tempOperAdjustPrice.ID != "" && this.tempOperAdjustPrice.State == "0")
                    this.IsShowList = false;
            }
        }

        private void TvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                this.Clear();
            }
            else
            {
                this.ShowData(e.Node.Tag as Neusoft.HISFC.Models.Pharmacy.AdjustPrice);
            }
        }

        private void chkValid_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDateTime.Enabled = !this.chkValid.Checked;
        }
        
        private void neuSpread1_EditModeOff(object sender, EventArgs e)
        {
            //if (this.isExeEditModeOffEvent) 
            //{
            //    this.isExeEditModeOffEvent = false;
            //}
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                if ((int)ColumnSet.ColRetailPrice == this.neuSpread1_Sheet1.ActiveColumnIndex)
                {
                    if (this.neuSpread1_Sheet1.ActiveColumnIndex == (int)ColumnSet.ColRetailPrice && this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
                    {
                        string[] keys = new string[] { this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text };
                        DataRow dr = this.dt.Rows.Find(keys);
                        if (dr != null)
                        {
                            //{8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
                            dr["现批发价"] = System.Math.Round((decimal)dr["现零售价"] / (decimal)Scale, 4);
                            dr["差价"] = NConvert.ToDecimal(dr["现零售价"]) - NConvert.ToDecimal(dr["原零售价"]);
                            dr["批发价差价"] = NConvert.ToDecimal(dr["现批发价"]) - NConvert.ToDecimal(dr["原批发价"]);
                            dr["购入价差价"] = NConvert.ToDecimal(dr["现购入价"]) - NConvert.ToDecimal(dr["原购入价"]);

                            this.SetProfitFlag();
                        }
                    }
                }
                if ((int)ColumnSet.ColPurchasePrice == this.neuSpread1_Sheet1.ActiveColumnIndex)
                {
                    if (this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
                    {
                        string[] keys = new string[] { this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)ColumnSet.ColDrugNO].Text };
                        DataRow dr = this.dt.Rows.Find(keys);
                        if (dr != null)
                        {
                            dr["购入价差价"] = NConvert.ToDecimal(dr["现购入价"]) - NConvert.ToDecimal(dr["原购入价"]);

                            this.SetProfitFlag();
                        }
                    }
                }
            }
        }

        

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.neuSpread1.ContainsFocus)
            {
                //if (keyData == Keys.A)
                //{
                //    return true;
                //}
                if (keyData == Keys.Enter)
                {
                    this.neuSpread1.StopCellEditing();
                    this.SetFocus(false);
                    //if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.Rows.Count - 1)
                    //{
                    //    this.SetFocus(false);
                    //}
                    //else
                    //{
                    //    this.neuSpread1_Sheet1.ActiveRowIndex++;
                    //}
                }
            }
            if (keyData == Keys.F5)
            {
                this.SetFocus(false);
            }

            

            return base.ProcessDialogKey(keyData);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text != "")
                    this.dt.DefaultView.RowFilter = Function.GetFilterStr(this.dt.DefaultView, "%" + this.textBox1.Text + "%");
                else
                    this.dt.DefaultView.RowFilter = "1=1";

                this.SetProfitFlag();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
        }  

        private enum ColumnSet
        {
            /// <summary>
            /// 商品名称规格
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 生产厂家
            /// </summary>
            ColProduce,
            /// <summary>
            /// 原零售价		
            /// </summary>
            ColPreRetailPrice,
            /// <summary>
            /// 原批发价  {8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
            /// </summary>
            ColPreTradePrice,
            /// <summary>
            /// 原购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
            /// </summary>
            ColPrePurchasePrice,
            /// <summary>
            /// 现零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 现批发价  {8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
            /// </summary>
            ColTradePrice,
            /// <summary>
            ///  现购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
            /// </summary>
            ColPurchasePrice,
            /// <summary>
            /// 差价 
            /// </summary>
            ColBalancePrice,
            /// <summary>
            /// 批发价差价  {8CF898CC-847E-42dd-8BA9-47BCBF312F2E}吕山勇
            /// </summary>
            ColBalanceTradePrice,
            /// <summary>
            /// 购入价差价  {82D5CEE7-A876-4582-ADC6-3545A7173467}
            /// </summary>
            ColBalancePurchasePrice,
            /// <summary>
            /// 调价原因
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
            ColWBCode,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColUserCode
        }

        /// <summary>
        /// 调价范围
        /// </summary>
        public enum EnumAdjustType
        {
            全院调价,
            单科调价
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { 
                    typeof(Neusoft.HISFC.BizProcess.Interface.Pharmacy.IBillPrint)
                };
            }
        }

        #endregion

        #region IPreArrange 成员  {543F5224-6BCB-4645-8D86-4E7EA8BDF80E}  增加对单科调剂得到预先提示、判断

        public int PreArrange()
        {
            if (this.adjustType == EnumAdjustType.单科调价)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

                //权限科室 暂时使用操作员科室代替
                this.privDept = ((Neusoft.HISFC.Models.Base.Employee)deptManager.Operator).Dept;

                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

                dept = deptManager.GetDeptmentById(this.privDept.ID);
                if (dept.DeptType.ID.ToString() != "PI")
                {
                    MessageBox.Show(Language.Msg("只有药库允许进行单科调价操作"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return -1;
                }
                else
                {
                    MessageBox.Show(Language.Msg("请注意 您选择的是单科调价功能"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                return 1;
            }

            return 1;
        }

        #endregion
    }
}
