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

namespace Neusoft.HISFC.Components.Material.Plan
{
    /// <summary>
    /// 
    /// 保存未测试
    /// 
    /// </summary>
    public partial class ucStockPlan : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public ucStockPlan()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 物品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 计划单管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Plan planManager = new Neusoft.HISFC.BizLogic.Material.Plan();

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
        [Description("采购计划指定后是否需要采购审核"), Category("设置"), DefaultValue(true)]
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

                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = false;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColCompany].Locked = false;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColPlanNum].Locked = false;
                    //this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockQty].Locked = false;
                }
                else
                {

                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = true;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColCompany].Locked = true;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColPlanNum].Locked = true;
                    //this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockQty].Locked = true;
                }
            }
        }

        /// <summary>
        /// 是否使用字典信息内默认的供货公司/购入价
        /// </summary>
        [Description("采购指定时是否使用字典信息内默认的供货公司/购入价"), Category("设置"), DefaultValue(true)]
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
        [Description("采购审核时 是否允许修改相应的采购信息"), Category("设置"), DefaultValue(false)]
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
        [Description("是否允许修改计划购入价"), Category("设置"), DefaultValue(true)]
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
        /// 过滤数据状态 满足该属性条件的状态将不在界面显示
        /// </summary>
        private string filterState = "";

        /// <summary>
        /// 弹出计划单状态
        /// </summary>
        private string popPlanListState = "0";

        /// <summary>
        /// 过滤数据状态集合
        /// </summary>
        private System.Collections.Hashtable hsFilterState = new Hashtable();

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

        /// <summary>
        /// 过滤数据状态集合
        /// </summary>
        [Description("过滤数据状态集合 存在多个时 以,间隔"), Category("设置"), DefaultValue("")]
        public string FilterState
        {
            get
            {
                return this.filterState;
            }
            set
            {
                this.filterState = value;
                string[] filterCollection = value.Split(',');
                this.hsFilterState.Clear();
                foreach (string str in filterCollection)
                {
                    this.hsFilterState.Add(str, null);
                }
            }
        }

        /// <summary>
        /// 弹出计划单状态
        /// </summary>
        [Description("弹出计划单状态"), Category("设置"), DefaultValue("0")]
        public string PopPlanListState
        {
            get
            {
                return this.popPlanListState;
            }
            set
            {
                this.popPlanListState = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("计 划 单", "计划单列表", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("日 消 耗", "调用模版生成计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R日消耗, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "计 划 单":
                    this.PopInPlanList();
                    break;
                case "日 消 耗":
                    this.PopExpandData();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.SaveStockPlan() == 1)
            {
                this.ShowPlanList();
            }

            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel1);
            return 1;
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        private int InitData()
        {
            this.fpStockApprove_Sheet1.DefaultStyle.Locked = true;
            this.fpHistory_Sheet1.DefaultStyle.Locked = true;

            FarPoint.Win.Spread.InputMap im;
            im = this.fpStockApprove.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            this.fpStockApprove_Sheet1.DefaultStyle.Locked = true;

            #region 获取生产厂家/供货公司帮助类

            //获得供货公司列表
            if (this.alCompany == null)
            {
                Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                this.alCompany = company.QueryCompany("1", "A");
                if (this.alCompany == null)
                {
                    MessageBox.Show("获取供货单位列表出错");
                    return -1;
                }

                this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alCompany);
            }
            if (this.alProduce == null)
            {
                Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                this.alProduce = company.QueryCompany("0", "A");
                if (this.alProduce == null)
                {
                    MessageBox.Show("获取生产厂家列表出错");
                    return -1;
                }
                this.produceHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.alProduce);
            }

            #endregion

            //采购计划 允许修改审核数量/供货公司
            //采购审核且属性设置为允许修改
            if (this.winFun == EnumWindowFun.采购计划 || (this.winFun == EnumWindowFun.采购审核 && this.isCanEditWhenApprove))
            {
                if (this.isCanEditPrice)
                {
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].Locked = false;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColPlanNum].Locked = false;
                    //this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockQty].Locked = false;
                    this.fpStockApprove_Sheet1.Columns[(int)ColumnStockSet.ColStockPrice].BackColor = System.Drawing.Color.SeaShell;
                }
            }

            return 1;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加入实体信息到Fp内
        /// </summary>
        /// <param name="plan">采购实体信息</param>
        /// <param name="rowIndex">需添加的行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(Neusoft.HISFC.Models.Material.InputPlan plan, int rowIndex)
        {
            #region 获取历史采购信息

            ArrayList alHistory = this.planManager.QueryHistoryInPlan(plan.StorageCode, plan.StoreBase.Item.ID, "2");
            ArrayList alHistoryIn = this.planManager.QueryHistoryInPlan(plan.StorageCode, plan.StoreBase.Item.ID, "3");
            alHistory.AddRange(alHistoryIn);
            if (alHistory == null)
            {
                Function.ShowMsg("获取历史采购信息出错" + this.itemManager.Err);
                return -1;
            }

            this.alPlanHistory.Add(alHistory);

            this.AddHistoryDataToFp(alHistory);

            #endregion

            if (plan.StoreBase.Item.PackQty == 0)
            {
                plan.StoreBase.Item.PackQty = 1;
            }

            #region 物品信息

            Neusoft.HISFC.Models.Material.MaterialItem tempItem = new Neusoft.HISFC.Models.Material.MaterialItem();
            tempItem = this.itemManager.GetMetItemByMetID(plan.StoreBase.Item.ID);
            if (tempItem == null)
            {
                Function.ShowMsg("未正确获取物品信息" + this.itemManager.Err);
                return -1;
            }

            #endregion

            #region 是否使用字典信息内默认的供货公司/购入价
            if (!this.isUseDefaultStockData)
            {
                if (alHistory.Count > 0)
                {
                    //Neusoft.HISFC.Models.Material.InputPlan planTemp = alHistory[0] as Neusoft.HISFC.Models.Material.InputPlan;
                    plan.Company = tempItem.Company;
                    plan.Producer = tempItem.Factory;
                    plan.StoreBase.PriceCollection.PurchasePrice = tempItem.PackPrice;
                }
            }
            #endregion

            this.fpStockApprove_Sheet1.Rows.Add(rowIndex, 1);

            #region Fp赋值

            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColTradeName].Value = tempItem.Name;		                //物品名称
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColSpecs].Value = plan.StoreBase.Item.Specs;							//规格
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Value = plan.PlanPrice;	//物品计划购入价				
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColPlanNum].Value = plan.PlanNum;		//计划采购数量(按包装单位显示)			
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColUnit].Value = tempItem.PackUnit;
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColApproveCost].Value = (plan.PlanNum * plan.PlanPrice).ToString("N");

            if (this.companyHelper.GetObjectFromID(plan.Company.ID) != null)
            {
                this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColCompany].Value = plan.Company.Name;							//供货公司名称
                this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColProduceName].Value = plan.Producer.Name;						//生产厂家
            }
            else
            {
                this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColCompany].Value = this.companyHelper.GetName(tempItem.Company.ID);         //供货公司名称
                this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColProduceName].Value = this.produceHelper.GetName(tempItem.Factory.ID);	//生产厂家               

                plan.Company.ID = tempItem.Company.ID;
                plan.Company.Name = this.companyHelper.GetName(tempItem.Company.ID);

                plan.Producer.ID = tempItem.Factory.ID;
                plan.Producer.Name = this.produceHelper.GetName(tempItem.Factory.ID);
            }

            if (plan.PlanPrice == 0)
            {
                if (tempItem.PackPrice == 0)
                    this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Text = tempItem.Price.ToString("N");
                else
                    this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColStockPrice].Text = tempItem.PackPrice.ToString("N");
            }

            //全院库存/本科库存 保存制定入库计划时的值

            #region 取本科库存 X（大包装）X（小包装）eg:1包4支
            string strStoreSum = (Math.Floor(plan.StoreSum / tempItem.PackQty)).ToString() + tempItem.PackUnit;
            decimal reQty = Math.Ceiling(plan.StoreSum % tempItem.PackQty);
            if (reQty > 0)
            {
                strStoreSum = strStoreSum + reQty.ToString() + tempItem.MinUnit;
            }
            #endregion

            #region 取全院库存 X（大包装）X（小包装）eg:1包4支
            string strStoreTotSum = (Math.Floor(plan.StoreTotsum / tempItem.PackQty)).ToString() + tempItem.PackUnit;
            decimal reTotQty = Math.Ceiling(plan.StoreTotsum % tempItem.PackQty);
            if (reTotQty > 0)
            {
                strStoreTotSum = strStoreTotSum + reTotQty.ToString() + tempItem.MinUnit;
            }
            #endregion

            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColOwnStockNum].Value = strStoreSum;
            this.fpStockApprove_Sheet1.Cells[rowIndex, (int)ColumnStockSet.ColAllStockNum].Value = strStoreTotSum;

            this.fpStockApprove_Sheet1.Rows[rowIndex].Tag = plan;

            #endregion

            //显示入库计划单信息
            if (rowIndex == 0)
            {
                #region 显示入库计划单信息

                //获得科室名称
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(plan.StorageCode);
                //获得操作员姓名
                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
                Neusoft.HISFC.Models.Base.Employee person = personManager.GetPersonByID(plan.StoreBase.Operation.Oper.ID);

                this.lbPlanBill.Text = "单据号:" + plan.StorageCode;                            //入库计划单号
                this.lbPlanInfo.Text = string.Format("计划科室 {0} 计划人 {1}", dept.Name, person.Name);     //操作科室

                #endregion
            }

            return 1;
        }

        /// <summary>
        /// 加入实体信息
        /// </summary>
        /// <param name="inPlan">入库计划实体信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToFp(Neusoft.HISFC.Models.Material.InputPlan inPlan)
        {
            return this.AddDataToFp(inPlan, this.fpStockApprove_Sheet1.Rows.Count);
        }

        /// <summary>
        /// 数据清空
        /// </summary>
        public void Clear()
        {
            //情况Fp显示
            this.fpHistory_Sheet1.Rows.Count = 0;
            this.fpStockApprove_Sheet1.Rows.Count = 0;

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
        public void ShowStockData(string listNO, string companyCode)
        {
            //清空数据
            this.Clear();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索入库计划单信息...");
            Application.DoEvents();

            ArrayList alDetail = this.planManager.QueryInPlanDetailCom(this.privDept.ID, listNO, companyCode);
            if (alDetail == null)
            {
                Function.ShowMsg("获取采购计划信息出错" + this.planManager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Material.InputPlan plan in alDetail)
            {
                if (this.hsFilterState.ContainsKey(plan.State))
                {
                    continue;
                }

                if (this.AddDataToFp(plan) == 1)
                {
                    this.hsStockPlan.Add(plan.ID, plan);
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //增加合计
            this.SetSum();

            this.fpStockApprove_Sheet1.ActiveRowIndex = 0;
            this.fpStockApprove_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColStockPrice;
        }

        /// <summary>
        /// 计算合计
        /// </summary>
        /// <returns></returns>
        private void SetSum()
        {
            try
            {
                if (this.fpStockApprove_Sheet1.Rows.Count <= 0)
                    return;

                decimal costSum = 0;
                for (int i = 0; i < this.fpStockApprove_Sheet1.Rows.Count; i++)
                {
                    costSum = costSum + NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text);
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
            int num = this.fpStockApprove_Sheet1.RowCount;

            if (num <= 0)
            {
                return false;
            }

            for (int i = 0; i < this.fpStockApprove_Sheet1.RowCount; i++)
            {
                string trandeName = this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColTradeName].Text;

                if (this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() == "")
                {
                    MessageBox.Show("请输入" + trandeName + " 供货公司");
                    this.fpStockApprove_Sheet1.ActiveRowIndex = i;
                    return false;
                }
                //如供货公司为"不详"，则可以不输入购入价
                if (this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() != "不详" && NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text) <= 0)
                {
                    MessageBox.Show("请输入" + trandeName + " 购入价!！");
                    this.fpStockApprove_Sheet1.ActiveRowIndex = i;
                    return false;
                }
                if (NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text) <= 0)
                {
                    MessageBox.Show("请输入" + trandeName + " 购入数量");
                    this.fpStockApprove_Sheet1.ActiveRowIndex = i;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取供货公司/生产厂家信息 并将对供货公司的更改反馈给行Tag实体
        /// </summary>
        private void PopStockCompany(int columnIndex)
        {
            //当前记录的行、列
            int i = this.fpStockApprove_Sheet1.ActiveRowIndex;
            int j = this.fpStockApprove_Sheet1.ActiveColumnIndex;
            //如无数据则返回
            if (this.fpStockApprove_Sheet1.RowCount == 0)
            {
                return;
            }

            if (i < 0) 
            { 
                return; 
            }

            Neusoft.HISFC.Models.Material.InputPlan stockPlanTemp = this.fpStockApprove_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Material.InputPlan;

            if (columnIndex == (int)ColumnStockSet.ColCompany)
            {
                //获得供货公司列表
                if (this.alCompany == null)
                {
                    Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                    this.alCompany = company.QueryCompany("1", "A");
                    if (this.alCompany == null)
                    {
                        MessageBox.Show("获取供货单位列表出错");
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
                    this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Value = companyTemp.Name;       //供货公司
                    stockPlanTemp.Company = companyTemp;
                }
            }
            if (columnIndex == (int)ColumnStockSet.ColProduceName)
            {
                //获得供货公司列表
                if (this.alProduce == null)
                {
                    Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
                    this.alProduce = company.QueryCompany("0", "A");
                    if (this.alProduce == null)
                    {
                        MessageBox.Show("获取生产厂家列表出错");
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
                    this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColProduceName].Value = producTemp.Name;     //供货公司                    
                    stockPlanTemp.Producer = producTemp;
                }
            }
        }

        /// <summary>
        /// 弹出日消耗计算控件
        /// </summary>
        public void PopExpandData()
        {
            if (this.fpStockApprove_Sheet1.Rows.Count <= 0)
                return;

            ucPhaExpand uc = new ucPhaExpand();

            uc.IsOnlyPatientInOut = true;

            Neusoft.HISFC.Models.Material.InputPlan plan = this.fpStockApprove_Sheet1.Rows[this.fpStockApprove_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Material.InputPlan;
            Neusoft.FrameWork.Models.NeuObject tempItem = plan.StoreBase.Item;

            Neusoft.FrameWork.Models.NeuObject tempDept = new Neusoft.FrameWork.Models.NeuObject();
            tempDept.ID = "AAAA";
            tempDept.Name = "全院";

            uc.SetData(tempDept, tempItem, 10);

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

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            ArrayList alSavePlanList = new ArrayList();

            for (int i = 0; i < this.fpStockApprove_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Material.InputPlan plan = this.fpStockApprove_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Material.InputPlan;
                if (plan == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("处理采购计划保存时 发生类型转换错误");
                    return -1;
                }

                #region 采购计划赋值

                //操作人员信息
                plan.StoreBase.Operation.Oper.ID = this.planManager.Operator.ID;
                plan.StoreBase.Operation.Oper.OperTime = sysTime;

                plan.StoreBase.PriceCollection.PurchasePrice = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text);     //物品购入价
                plan.StockNum = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text) * plan.StoreBase.Item.PackQty;   //采购数量
                plan.PlanNum = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text);
                plan.PlanPrice = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text);
                plan.PlanCost = plan.PlanNum * plan.PlanPrice;

                if (this.winFun == EnumWindowFun.采购计划)
                {
                    #region 采购计划制定

                    plan.StoreBase.PriceCollection.PurchasePrice = plan.PlanPrice;        //物品购入价 赋值为 物品计划购入价
                    plan.StockOper = plan.StoreBase.Operation.Oper;                       //采购人
                    //如供货公司为不详 则不改变计划单状态
                    if (this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Text.Trim() == "不详")
                        plan.State = this.listState;
                    else
                        plan.State = this.saveState;
                    //如采购不需要审核 则直接设置状态为2 审核
                    if (!this.isNeedApprove)
                    {
                        plan.StoreBase.Operation.ApproveOper = plan.StoreBase.Operation.Oper;
                        //plan.State = this.saveState;
                        plan.State = "2";
                    }

                    #endregion
                }
                else           //采购审核功能
                {
                    plan.StoreBase.Operation.ExamOper.ID = this.planManager.Operator.ID;
                    plan.StoreBase.Operation.ExamOper.OperTime = sysTime;
                    plan.StoreBase.Operation.ApproveOper = plan.StoreBase.Operation.Oper;
                    plan.State = this.saveState;
                }

                #endregion

                alSavePlanList.Add(plan);
            }

            #region 采购计划保存

            //Neusoft.HISFC.Models.Material.InputPlan planInfo = new Neusoft.HISFC.Models.Material.InputPlan();
            foreach (Neusoft.HISFC.Models.Material.InputPlan input in alSavePlanList)
            {
                //planInfo = input;


                int param = this.planManager.SaveStockPlan(input);
                if (param == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("采购计划信息更新失败" + this.itemManager.Err);
                    return -1;
                }
                if (param == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("入库计划数据已删除或已做完采购计划 请与入库计划人员联系");
                    return -1;
                }
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功");

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
        //暂时屏掉
        //private ucSplitPlan ucSplitPlan = null;

        /// <summary>
        /// 入库计划单显示
        /// </summary>
        /// <returns></returns>
        public int PopInPlanList()
        {
            if (this.ucMergeList == null)
            {
                this.ucMergeList = new ucPlanList();
            }

            this.ucMergeList.OperPrivDept = this.privDept;              //权限科室
            this.ucMergeList.State = this.popPlanListState;                    //单据状态 0

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucMergeList);
            if (this.ucMergeList.Result == DialogResult.OK)     //显示单据合并
            {
                ArrayList alterPlan = this.ucMergeList.AlterInPlan;

                this.Clear();

                foreach (Neusoft.HISFC.Models.Material.InputPlan inPlanObj in alterPlan)
                {
                    this.AddDataToFp(inPlanObj);
                }
            }
            this.SetSum();
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
            this.fpHistory_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 增加历史采购信息
        /// </summary>
        /// <param name="stockPlan">历史采购信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddHistoryDataToFp(Neusoft.HISFC.Models.Material.InputPlan stockPlan)
        {
            #region 物品信息

            Neusoft.HISFC.Models.Material.MaterialItem tempItem = new Neusoft.HISFC.Models.Material.MaterialItem();
            tempItem = this.itemManager.GetMetItemByMetID(stockPlan.StoreBase.Item.ID);
            if (tempItem == null)
            {
                Function.ShowMsg("未正确获取物品信息" + this.itemManager.Err);
                return -1;
            }

            #endregion

            int iRowIndx = this.fpHistory_Sheet1.Rows.Count;

            this.fpHistory_Sheet1.Rows.Add(iRowIndx, 1);
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColInTime].Value = stockPlan.StoreBase.Operation.ApproveOper.OperTime;									//入库日期
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColStockQty].Text = stockPlan.StockNum.ToString();//采购数量
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColUnit].Text = tempItem.PackUnit;											//单位
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColStockPrice].Text = stockPlan.StoreBase.PriceCollection.PurchasePrice.ToString();								//购入价
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColCompany].Text = stockPlan.Company.Name;											//供货公司
            this.fpHistory_Sheet1.Cells[iRowIndx, (int)ColumnHistorySet.ColProduce].Text = stockPlan.Producer.Name;							//生产厂家

            return 1;
        }

        /// <summary>
        /// 增加历史采购信息
        /// </summary>
        /// <param name="alHistory"></param>
        private void AddHistoryDataToFp(ArrayList alHistory)
        {
            foreach (Neusoft.HISFC.Models.Material.InputPlan info in alHistory)
            {
                this.AddHistoryDataToFp(info);
            }
        }

        /// <summary>
        /// 显示历史采购记录
        /// </summary>
        protected void ShowHistoryData()
        {
            if (this.fpStockApprove_Sheet1.RowCount <= 0)
                return;

            if (this.alPlanHistory.Count > this.fpStockApprove_Sheet1.ActiveRowIndex)
            {
                this.ClearHistoryData();

                //显示Tab页上提示信息
                this.tbStockHistory.Text = this.fpStockApprove_Sheet1.Cells[this.fpStockApprove_Sheet1.ActiveRowIndex, (int)ColumnStockSet.ColTradeName].Text + "[" + this.fpStockApprove_Sheet1.Cells[this.fpStockApprove_Sheet1.ActiveRowIndex, (int)ColumnStockSet.ColSpecs].Text + "]" + " 历史采购信息";

                this.AddHistoryDataToFp(this.alPlanHistory[this.fpStockApprove_Sheet1.ActiveRowIndex] as ArrayList);
            }
        }

        #endregion

        #region 树操作

        /// <summary>
        /// 入库单列表显示
        /// </summary>
        private void ShowPlanList()
        {
            this.tvList.ShowStockPlanList(this.privDept, this.listState);
        }

        #endregion

        #region 事件
        private void ucStockPlan_Load(object sender, System.EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.privOper = this.itemManager.Operator;

                //string class2Priv = "0512";
                //if (this.winFun == EnumWindowFun.采购计划)
                //{
                //    class2Priv = "0512";
                //}
                //else
                //{
                //    class2Priv = "0513";
                //}

                //Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
                //int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept(class2Priv, ref testPrivDept);
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

                //base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

                this.InitData();

                this.ShowPlanList();
            }
        }

        private void fpStockApprove_EditModeOff(object sender, EventArgs e)
        {
            if (this.fpStockApprove_Sheet1.RowCount == 0)
            {
                return;
            }
            int i = this.fpStockApprove_Sheet1.ActiveRowIndex;

            if (this.fpStockApprove_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColStockPrice || this.fpStockApprove_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColPlanNum)
            {
                
                if (this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColTradeName].Text == "合计")
                {
                    return; 
                }
                //计算计划金额
                try
                {
                    this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text = 
                        (NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text) * NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text)).ToString();

                    this.SetSum();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    return;
                }
            }
            //对表格里修改过的数据 重新赋值tag by yuyun 08-7-31{C5CF9164-BA45-4fb6-AA9F-506EC4B3FA42}
            Neusoft.HISFC.Models.Material.InputPlan plan = new Neusoft.HISFC.Models.Material.InputPlan();
            plan = this.fpStockApprove_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Material.InputPlan;

            if (this.fpStockApprove_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColStockPrice)
            {
                plan.PlanPrice = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColStockPrice].Text);
                plan.PlanCost = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text);
            }
            else if (this.fpStockApprove_Sheet1.ActiveColumnIndex == (int)ColumnStockSet.ColPlanNum)
            {
                plan.PlanNum = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColPlanNum].Text);
                plan.PlanCost = NConvert.ToDecimal(this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColApproveCost].Text);
            }

            this.fpStockApprove_Sheet1.Rows[i].Tag = plan;

        }

        /// <summary>
        /// 处理回车跳转、上下箭头移动时改变 历史采购显示
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.fpStockApprove.ContainsFocus)
            {
                if (keyData == Keys.Enter)
                {
                    #region 设置跳转
                    int iRow = this.fpStockApprove_Sheet1.ActiveRowIndex;
                    int iColumn = this.fpStockApprove_Sheet1.ActiveColumnIndex;

                    switch (iColumn)
                    {
                        case (int)ColumnStockSet.ColStockPrice:
                            this.fpStockApprove_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColCompany;
                            break;
                        case (int)ColumnStockSet.ColCompany:
                            this.fpStockApprove_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColProduceName;
                            break;
                        case (int)ColumnStockSet.ColProduceName:
                            this.fpStockApprove_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColMemo;
                            break;
                        case (int)ColumnStockSet.ColMemo:
                            this.fpStockApprove_Sheet1.ActiveColumnIndex = 0;		//使焦点先跳转到第一列 否则直接跳转到价格看不到第一列
                            this.fpStockApprove_Sheet1.ActiveColumnIndex = (int)ColumnStockSet.ColStockPrice;
                            this.fpStockApprove_Sheet1.ActiveRowIndex = this.fpStockApprove_Sheet1.ActiveRowIndex + 1;
                            this.ShowHistoryData();
                            break;
                    }
                    return true;
                    #endregion
                }
                if (keyData == Keys.Up)
                {
                    if (this.fpStockApprove_Sheet1.ActiveRowIndex != 0)
                        this.fpStockApprove_Sheet1.ActiveRowIndex = this.fpStockApprove_Sheet1.ActiveRowIndex - 1;
                    this.ShowHistoryData();
                    return true;
                }
                if (keyData == Keys.Down)
                {
                    if (this.fpStockApprove_Sheet1.ActiveRowIndex != this.fpStockApprove_Sheet1.Rows.Count - 1)
                    {
                        this.fpStockApprove_Sheet1.ActiveRowIndex = this.fpStockApprove_Sheet1.ActiveRowIndex + 1;
                    }
                    this.ShowHistoryData();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 处理对历史物品采购记录的弹出功能
        /// </summary>
        private void fpStockApprove_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //当前记录的行、列
            int i = this.fpStockApprove_Sheet1.ActiveRowIndex;
            int j = this.fpStockApprove_Sheet1.ActiveColumnIndex;

            //回车键键码 13 空格键键码 32
            if (e.KeyChar == 32)
            {
                this.PopStockCompany(j);
            }
            else
            {      //按下的为Backspace键
                if (e.KeyChar == (char)8 && j == (int)ColumnStockSet.ColCompany)
                {
                    this.fpStockApprove_Sheet1.Cells[i, (int)ColumnStockSet.ColCompany].Value = "不详";  //供货公司
                }
            }
        }

        /// <summary>
        /// 处理对历史物品采购记录的弹出功能
        /// </summary>
        private void fpStockApprove_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //如果点击的为行或列标题则直接返回
            if (e.ColumnHeader || e.RowHeader)
                return;
            //功能窗口为采购审核 且不允许修改采购单信息
            if (this.winFun == EnumWindowFun.采购审核 && !this.isCanEditWhenApprove)
                return;

            this.PopStockCompany(e.Column);
        }

        /// <summary>
        /// 选择不同行时显示不同历史采购信息
        /// </summary>
        private void fpStockApprove_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.ShowHistoryData();
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node != null && e.Node.Parent != null)
            {
                Neusoft.FrameWork.Models.NeuObject inPlanObj = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.ShowStockData(inPlanObj.ID, inPlanObj.Name);
            }
        }

        private void fpStockApprove_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {

        }

        private void fpStockApprove_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ShowHistoryData();
        }

        /// <summary>
        /// 按供货公司导出{C5CF9164-BA45-4fb6-AA9F-506EC4B3FA42}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            List<Neusoft.HISFC.Models.Material.InputPlan> listPlan = new List<Neusoft.HISFC.Models.Material.InputPlan>();

            foreach (FarPoint.Win.Spread.Row r in this.fpStockApprove_Sheet1.Rows)
            {
                listPlan.Add(this.fpStockApprove_Sheet1.Rows[r.Index].Tag as Neusoft.HISFC.Models.Material.InputPlan);
            }

            if (listPlan == null || listPlan.Count <= 0)
            {
                MessageBox.Show("没有数据需要导出。");

                return -1;
            }
            //将表格中的数据按供货公司和物资编码排序
            Neusoft.HISFC.BizProcess.Integrate.Material.MaterialSort.SortStockPlanByCompany(ref listPlan);

            this.SetDateToExport(listPlan);

            this.Clear();

            foreach (Neusoft.HISFC.Models.Material.InputPlan input in listPlan)
            {
                this.AddDataToFp(input); 
            }
            return 1;
        }

        /// <summary>
        /// 对排序后的list按供货公司导出{C5CF9164-BA45-4fb6-AA9F-506EC4B3FA42}
        /// </summary>
        /// <param name="listPlan"></param>
        private void SetDateToExport(List<Neusoft.HISFC.Models.Material.InputPlan> listPlan)
        {
            try
            {
                //把排序后的list分组放入新的list里供打印
                List<Neusoft.HISFC.Models.Material.InputPlan>[] alExport = new List<Neusoft.HISFC.Models.Material.InputPlan>[100];
                for (int i = 0; i < 100; i++)
                {
                    alExport[i] = new List<Neusoft.HISFC.Models.Material.InputPlan>();
                }

                string companyID = string.Empty;
                companyID = listPlan[0].Company.ID;
                alExport[0].Add(listPlan[0]);
                int index = 0;

                if (listPlan.Count > 1)
                {
                    for (int i = 1; i < listPlan.Count; i++)
                    {
                        if (listPlan[i].Company.ID == companyID)
                        {
                            alExport[index].Add(listPlan[i]);
                        }
                        else
                        {
                            index++;
                            companyID = listPlan[i].Company.ID;
                            alExport[index].Add(listPlan[i]);
                        }
                    }
                }

                for (int i = 0; i <= index; i++)
                {
                    this.ExportInfo(alExport[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 导出{C5CF9164-BA45-4fb6-AA9F-506EC4B3FA42}
        /// </summary>
        /// <param name="list"></param>
        private void ExportInfo(List<Neusoft.HISFC.Models.Material.InputPlan> list)
        {
            //将分组后的list存到fpStockApprove_Sheet1导出
            this.fpStockApprove_Sheet1.RowCount = 0;
            foreach (Neusoft.HISFC.Models.Material.InputPlan input in list)
            {
                this.AddDataToFp(input);
            }
            try
            {
                string fileName = "";

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel (*.xls)|*.*";
                dlg.FileName = list[0].Company.Name + "-" + planManager.GetSysDate();
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    this.fpStockApprove.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            /// 0 物品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 1 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 2 计划购入价
            /// </summary>
            ColStockPrice,
            /// <summary>
            /// 3 计划数量
            /// </summary>
            ColPlanNum,
            /// <summary>
            /// 4 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 5 审核金额
            /// </summary>
            ColApproveCost,
            /// <summary>
            /// 6 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 7 生产厂家
            /// </summary>
            ColProduceName,
            /// <summary>
            /// 8 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 9 科室库存
            /// </summary>
            ColOwnStockNum,
            /// <summary>
            /// 10 全院库存
            /// </summary>
            ColAllStockNum
        }

        /// <summary>
        /// 采购计划列设置
        /// </summary>
        private enum ColumnHistorySet
        {
            /// <summary>
            /// 0 入库日期
            /// </summary>
            ColInTime,
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
            /// 4 供货公司
            /// </summary>
            ColCompany,
            /// <summary>
            /// 5 生产厂家
            /// </summary>
            ColProduce,
            /// <summary>
            /// 6 备注
            /// </summary>
            ColMemo
        }

        #endregion

        #region IPreArrange 成员

        public int PreArrange()
        {
            string class2Priv = "0512";
            if (this.winFun == EnumWindowFun.采购计划)
            {
                class2Priv = "0512";
            }
            else
            {
                class2Priv = "0513";
            }

            Neusoft.FrameWork.Models.NeuObject testPrivDept = new Neusoft.FrameWork.Models.NeuObject();
            int parma = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePivDept(class2Priv, ref testPrivDept);
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

            base.OnStatusBarInfo(null, "操作科室： " + testPrivDept.Name);

            return 1;
        }
        #endregion

    }
}
