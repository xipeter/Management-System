using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Report
{
    public partial class ucGeneralQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucGeneralQuery()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 明细数据表
        /// </summary>
        private DataTable dtDetail = new DataTable();

        /// <summary>
        /// 当前操作人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作权限类型
        /// </summary>
        private Neusoft.HISFC.Models.Admin.PowerLevelClass3 operPriv = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

        /// <summary>
        /// 当前操作科目分类 
        /// </summary>
        private AssortType assortType = AssortType.Mat;

        /// <summary>
        /// 管理基类
        /// </summary>
        private Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

        /// <summary>
        /// 报表管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Report reportManager = new Neusoft.HISFC.BizLogic.Material.Report();

        /// <summary>
        /// 
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store myStore = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 通用查询大类
        /// </summary>
        /*暂时屏掉"盘点"和"调价"*/
        //private string[] pList = { "入库|In", "出库|Out", "盘点|Check", "调价|Adjust" };
        private string[] pList = { "入库|In", "出库|Out" };

        /// <summary>
        /// 库房查询大类
        /// </summary>
        private string[] piList = { "入库计划|InPlan", "采购计划|Stock", "台帐|Record" };

        /// <summary>
        /// 通用查询大类
        /// </summary>
        /*暂时屏掉"盘点"和"调价"*/
        //private string pParam = "入库|In,出库|Out,盘点|Check,调价|Adjust";
        private string pParam = "入库|In,出库|Out";

        /// <summary>
        /// 库房查询大类
        /// </summary>
        private string piParam = "入库计划|InPlan,采购|Stock,台帐|Record";

        /// <summary>
        /// 权限管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerDetailManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime BeginTime = System.DateTime.MaxValue;

        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime EndTime = System.DateTime.MaxValue;

        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper producHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 数值CellType
        /// </summary>
        private FarPoint.Win.Spread.CellType.NumberCellType numFpCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

        /// <summary>
        /// 当前执行的Sql代码索引
        /// </summary>
        private string exeSqlIndex = "";

        /// <summary>
        /// 是否使用Sql配置文件方式
        /// </summary>
        private bool isUseSqlConfig = true;

        /// <summary>
        /// 明细信息检索时使用的Fp列数(索引由0开始)
        /// </summary>
        private int detailIndexNum = 3;

        /// <summary>
        /// 当前查询主键
        /// </summary>
        private string privIndex = "";

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示操作树节点列表
        /// </summary>
        public bool IsShowDeptList
        {
            get
            {
                return !this.tvOper.Visible;
            }
            set
            {
                this.tvOper.Visible = !value;
            }
        }


        /// <summary>
        /// 是否显示操作权限列表
        /// </summary>
        public bool IsShowPrivList
        {
            get
            {
                return !this.tvOper.Visible;
            }
            set
            {
                this.tvOper.Visible = !value;
            }
        }


        /// <summary>
        /// 是否显示科室/权限列表
        /// </summary>
        public bool IsShowList
        {
            get
            {
                return !this.tvDept.Visible;
            }
            set
            {
                this.tvDept.Visible = !value;
            }
        }


        /// <summary>
        /// 通用查询大类
        /// </summary>
        [Description("通用查询大类 以'|' 分隔名称与代码 入出库不可修改 该属性暂时未启用"), Category("设置")]
        public string[] PList
        {
            get
            {
                return this.pList;
            }
            set
            {
                bool isPirvIn = false;
                bool isPrivOut = false;
                foreach (string str in value)
                {
                    if (str.IndexOf("入库|In") != -1)
                        isPirvIn = true;
                    if (str.IndexOf("出库|Out") != -1)
                        isPrivOut = true;
                }
                if (!isPrivOut || !isPirvIn)
                {
                    MessageBox.Show("无效属性值 至少需包含 入库|In 出库|Out");
                }

                this.pList = value;
            }
        }


        /// <summary>
        /// 通用查询大类
        /// </summary>
        [Description("通用查询大类 以'|' 分隔名称与代码 入出库不可修改 不同类型通过','分割"), Category("设置")]
        public string PParam
        {
            get
            {
                return this.pParam;
            }
            set
            {
                this.pParam = value;

                this.PList = pParam.Split(',');
            }
        }


        /// <summary>
        /// 库房查询大类
        /// </summary>
        [Description("库房查询大类 以'|' 分隔名称与代码"), Category("设置")]
        public string[] PIList
        {
            get
            {
                return this.piList;
            }
            set
            {
                this.piList = value;
            }
        }


        /// <summary>
        /// 库房通用查询大类
        /// </summary>
        [Description("库房通用查询大类 以'|' 分隔名称与代码 入出库不可修改 不同类型通过','分割"), Category("设置")]
        public string PIParam
        {
            get
            {
                return this.piParam;
            }
            set
            {
                this.piParam = value;

                this.PIList = piParam.Split(',');
            }
        }


        /// <summary>
        /// 是否使用Sql配置文件方式
        /// </summary>
        [Description("是否使用Sql配置文件方式"), Category("设置"), DefaultValue(true)]
        public bool IsUseSqlConfig
        {
            get
            {
                return this.isUseSqlConfig;
            }
            set
            {
                this.isUseSqlConfig = value;
            }
        }


        /// <summary>
        /// 明细信息检索时使用的Fp列数(索引由0开始)
        /// </summary>
        [Description("明细信息检索时使用的Fp列数(索引由0开始)"), Category("设置"), DefaultValue(3)]
        public int DetailIndexNum
        {
            get
            {
                return detailIndexNum;
            }
            set
            {
                detailIndexNum = value;
            }
        }


        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("日  期", "设置检索日期", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            toolBarService.AddToolButton("按部门", "按部门汇总查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z转科, true, false, null);
            toolBarService.AddToolButton("按物品", "按物品汇总查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y药品, true, false, null);
            toolBarService.AddToolButton("按单据", "按单据汇总查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B摆药单, true, false, null);
            toolBarService.AddToolButton("配置设置", "设置配置文件", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "日  期")
            {
                //选择时间段，如果没有选择就返回
                if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.BeginTime, ref this.EndTime) == 0)
                    return;

                this.ShowData();
            }
            if (e.ClickedItem.Text == "按部门")
            {
                if (this.assortType == AssortType.MatCompany)
                    return;

                this.assortType = AssortType.MatCompany;

                this.ShowData();
            }
            if (e.ClickedItem.Text == "按物品")
            {
                if (this.assortType == AssortType.Mat)
                    return;

                this.assortType = AssortType.Mat;

                this.ShowData();
            }
            if (e.ClickedItem.Text == "按单据")
            {
                if (this.assortType == AssortType.MatBill)
                    return;

                this.assortType = AssortType.MatBill;

                this.ShowData();
            }
            if (e.ClickedItem.Text == "配置设置")
            {
                frmSetConfig frm = new frmSetConfig();
                frm.Show();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowData();

            return base.OnQuery(sender, neuObject);
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

        /// <summary>
        /// 按钮有效性设置
        /// </summary>
        protected void SetToolButton()
        {
            switch (this.operPriv.Name)
            {
                case "入库":
                    this.toolBarService.SetToolButtonEnabled("按单据", true);
                    this.toolBarService.SetToolButtonEnabled("按物品", true);
                    this.toolBarService.SetToolButtonEnabled("按部门", true);
                    break;
                case "出库":
                    this.toolBarService.SetToolButtonEnabled("按单据", true);
                    this.toolBarService.SetToolButtonEnabled("按物品", true);
                    this.toolBarService.SetToolButtonEnabled("按部门", true);
                    break;
                case "采购":
                    this.toolBarService.SetToolButtonEnabled("按单据", true);
                    this.toolBarService.SetToolButtonEnabled("按物品", true);
                    this.toolBarService.SetToolButtonEnabled("按部门", true);
                    break;
                case "盘点":
                    this.toolBarService.SetToolButtonEnabled("按单据", true);
                    this.toolBarService.SetToolButtonEnabled("按物品", true);
                    this.toolBarService.SetToolButtonEnabled("按部门", false);
                    break;
            }
        }

        /// <summary>
        /// 按钮有效性设置 对于无Sql语句的按钮 按钮设置无效
        /// </summary>
        /// <param name="indexPrifx">Sql语句前缀</param>
        protected void SetToolButton(string indexPrifx)
        {
            string index = "";

            index = indexPrifx + AssortType.Mat.ToString();
            if (this.hsSqlConfig.Contains(index))
            {
                this.toolBarService.SetToolButtonEnabled("按物品", true);
            }
            else
            {
                this.toolBarService.SetToolButtonEnabled("按物品", false);
            }

            index = indexPrifx + AssortType.MatBill.ToString();
            if (this.hsSqlConfig.Contains(index))
            {
                this.toolBarService.SetToolButtonEnabled("按单据", true);
            }
            else
            {
                this.toolBarService.SetToolButtonEnabled("按单据", false);
            }

            index = indexPrifx + AssortType.MatCompany.ToString();
            if (this.hsSqlConfig.Contains(index))
            {
                this.toolBarService.SetToolButtonEnabled("按部门", true);
            }
            else
            {
                this.toolBarService.SetToolButtonEnabled("按部门", false);
            }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            this.privOper = this.dataManager.Operator;

            bool isPriv = Neusoft.HISFC.Components.Common.Classes.Function.ChoosePiv("0530");
            if (isPriv)
            {
                this.BeginTime = this.dataManager.GetDateTimeFromSysDateTime().Date.AddYears(-1);
                this.EndTime = this.dataManager.GetDateTimeFromSysDateTime();
            }

            #region 获取帮助类

            Neusoft.HISFC.BizLogic.Material.ComCompany company = new Neusoft.HISFC.BizLogic.Material.ComCompany();
            ArrayList alCompany = company.QueryCompany("1", "A");
            if (alCompany != null)
            {
                this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alCompany);
            }
            ArrayList alProduce = company.QueryCompany("0", "A");
            if (alProduce != null)
            {
                this.producHelper = new Neusoft.FrameWork.Public.ObjectHelper(alProduce);
            }

            #endregion

            this.numFpCellType.DecimalPlaces = 4;

        }


        /// <summary>
        /// 权限科室初始化
        /// </summary>
        protected int InitPrivDept()
        {
            this.tvDept.ImageList = this.tvDept.deptImageList;

            this.tvDept.Nodes.Clear();

            List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = this.powerDetailManager.QueryUserPriv(this.privOper.ID, "0530");
            if (alPrivDept == null)
            {
                MessageBox.Show("获取人员权限发生错误" + this.powerDetailManager.Err);
                return -1;
            }
            if (alPrivDept.Count == 0)
            {
                MessageBox.Show("您尚未分配查询科室");
                return -1;
            }
            foreach (Neusoft.FrameWork.Models.NeuObject info in alPrivDept)
            {
                //获取有查询权限的科室
                TreeNode node = new TreeNode();
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;

                node.Text = info.Name;
                node.SelectedImageIndex = 1;

                //存储科室代码+科室类型，用于控制操作列表的显示
                node.Tag = info;

                this.tvDept.Nodes.Add(node);
            }
            this.tvDept.SelectedNode = this.tvDept.Nodes[0];

            return 1;
        }


        /// <summary>
        /// 权限科目初始化
        /// </summary>
        protected void InitPrivOper()
        {
            this.tvOper.ImageList = this.tvOper.groupImageList;

            this.tvOper.Nodes.Clear();

            Neusoft.HISFC.Models.Admin.PowerLevelClass3 privClass3;
            foreach (string tempStr in this.PList)
            {
                #region 加载通用类型

                privClass3 = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

                privClass3.ID = tempStr.Substring(tempStr.IndexOf("|") + 1);        //查询科目
                privClass3.Name = tempStr.Substring(0, tempStr.IndexOf("|"));       //查询名称
                privClass3.Memo = "AAAA";                                           //权限信息

                TreeNode parentNode = new TreeNode();
                parentNode.ImageIndex = 0;

                parentNode.Text = privClass3.Name;
                parentNode.Tag = privClass3;

                this.tvOper.Nodes.Add(parentNode);

                if (privClass3.ID == "In")           //获取入库权限类型
                {
                    #region 添加入库三级权限

                    List<Neusoft.FrameWork.Models.NeuObject> alInPriv = this.powerDetailManager.QueryUserPrivCollection(this.privOper.ID, "0510", this.operDept.ID);
                    if (alInPriv == null)
                    {
                        MessageBox.Show("读取操作员入库权限集合时出错！\n" + this.powerDetailManager.Err);
                        return;
                    }

                    foreach (Neusoft.FrameWork.Models.NeuObject inInfo in alInPriv)
                    {
                        if (this.operDept.Memo == "PI")
                        {
                            if (inInfo.ID == "M1" || inInfo.ID == "M2" || inInfo.ID == "Z1" || inInfo.ID == "Z2")
                                continue;
                        }

                        privClass3 = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

                        privClass3.ID = "In";
                        privClass3.Name = inInfo.Name;
                        privClass3.Memo = inInfo.ID;

                        TreeNode privNode = new TreeNode();
                        privNode.ImageIndex = 0;
                        privNode.SelectedImageIndex = 1;

                        privNode.Text = privClass3.Name;		//三级权限名称
                        privNode.Tag = privClass3;				//三级权限编码

                        parentNode.Nodes.Add(privNode);
                    }

                    #endregion
                }

                if (privClass3.ID == "Out")         //获取出库权限类型
                {
                    #region 添加出库三级权限

                    List<Neusoft.FrameWork.Models.NeuObject> alOutPriv = this.powerDetailManager.QueryUserPrivCollection(this.privOper.ID, "0520", this.operDept.ID);
                    if (alOutPriv == null)
                    {
                        MessageBox.Show("读取操作员出库权限集合时出错！\n" + this.powerDetailManager.Err);
                        return;
                    }

                    foreach (Neusoft.FrameWork.Models.NeuObject outInfo in alOutPriv)
                    {
                        privClass3 = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

                        privClass3.ID = "Out";
                        privClass3.Name = outInfo.Name;
                        privClass3.Memo = outInfo.ID;

                        TreeNode privNode = new TreeNode();

                        privNode.ImageIndex = 0;

                        privNode.SelectedImageIndex = 1;
                        privNode.Text = privClass3.Name;		//三级权限名称
                        privNode.Tag = privClass3;				//三级权限编码

                        parentNode.Nodes.Add(privNode);
                    }

                    #endregion
                }

                #endregion
            }

            if (this.operDept.Memo == "PI")
            {
                #region 加载库房通用类型

                foreach (string tempStr in this.PIList)
                {
                    privClass3 = new Neusoft.HISFC.Models.Admin.PowerLevelClass3();

                    privClass3.ID = tempStr.Substring(tempStr.IndexOf("|") + 1);	//查询科目
                    privClass3.Name = tempStr.Substring(0, tempStr.IndexOf("|"));	//查询名称

                    switch (privClass3.Name)
                    {
                        case "住院":
                            privClass3.Memo = "Z";
                            break;
                        case "门诊":
                            privClass3.Memo = "M";
                            break;
                        default:
                            privClass3.Memo = "AAAA";
                            break;
                    }

                    TreeNode node = new TreeNode();

                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;

                    node.Text = privClass3.Name;
                    node.Tag = privClass3;

                    this.tvOper.Nodes.Add(node);
                }

                #endregion
            }

            if (this.tvOper.Nodes.Count > 0)
                this.tvOper.SelectedNode = this.tvOper.Nodes[0];
        }


        #endregion

        #region 方法

        /// <summary>
        /// 设置过滤条件
        /// </summary>
        private void Filter()
        {
            if (this.dt == null || this.dt.DefaultView == null)
                return;

            string queryCode = "%" + this.txtFilter.Text.Trim() + "%";
            string filter = "";

            //获取过滤条件
            switch (this.assortType)
            {
                case AssortType.Mat:	    //按物品
                case AssortType.MatCompany:    //按供货公式
                    filter = Function.GetFilterStr(this.dt.DefaultView, queryCode);
                    break;
                case AssortType.MatBill:       //按单据
                    if (this.dt.Columns.Contains("单据号"))
                        filter = "单据号 LIKE '" + queryCode + "'";
                    break;
            }
            try
            {
                this.dt.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 获取执行查询的Sql索引
        /// </summary>
        /// <returns></returns>
        private string GetSqlIndex(bool isDetail)
        {
            string sqlIndex = "";
            if (isDetail)
            {
                //获取应查询的sql
                //{498DAEEA-4F5C-4bdc-8FE9-9AC3875D887B}
                if (this.operPriv.ID == "Out" && this.assortType == AssortType.MatBill)
                    sqlIndex = this.operPriv.ID + "By" + "DetailForBill";
                else
                    sqlIndex = this.operPriv.ID + "By" + "Detail";

                //门诊消耗
                if (this.operPriv.Memo == "M1" || this.operPriv.Memo == "M2")
                    sqlIndex = this.operPriv.ID + "ByClinicDetail";
                //住院消耗
                if (this.operPriv.Memo == "Z1" || this.operPriv.Memo == "Z2")
                    sqlIndex = this.operPriv.ID + "ByOutpatientDetail";
                //科室入库明细查询
                if (this.operDept.Memo == "P" && this.operPriv.ID == "In")
                {
                    sqlIndex = this.operPriv.ID + "ByPDetail";
                }
            }
            else
            {
                sqlIndex = this.operPriv.ID + "By" + this.assortType.ToString();
            }

            return sqlIndex;
        }


        /// <summary>
        /// 执行Sql语句获取DataTable
        /// </summary>
        /// <returns></returns>
        private int GetDataTable(string sqlIndex, bool isDetail)
        {
            if (isDetail)
            {
                DataSet ds = new DataSet();
                if (this.operPriv.ID == "Record")	//对台帐详细信息的检索通过物品编码进行，通过privcode变量传入
                {
                    string matCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
                    ds = this.reportManager.MaterialReportQueryBase(this.operDept.ID, this.BeginTime, this.EndTime, matCode, this.exeSqlIndex);
                }
                else
                {
                    ds = this.reportManager.MaterialReportQueryBase(this.operDept.ID, this.BeginTime, this.EndTime, this.operPriv.Memo, this.exeSqlIndex);
                }
                if (ds == null || ds.Tables.Count <= 0)
                {
                    MessageBox.Show(this.reportManager.Err);
                    return -1;
                }

                this.dtDetail = ds.Tables[0];
            }
            else
            {
                DataSet ds = this.reportManager.MaterialReportQueryBase(this.operDept.ID, this.BeginTime, this.EndTime, this.operPriv.Memo, sqlIndex);

                if (ds == null || ds.Tables.Count <= 0)
                {
                    MessageBox.Show(this.reportManager.Err);
                    return -1;
                }

                this.dt = ds.Tables[0];
            }
            return 1;
        }


        /// <summary>
        /// 根据配置文件获取Sql语句信息
        /// </summary>
        /// <param name="isDetail">是否明细信息显示</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int GetDataByConfig(bool isDetail)
        {
            DataSet ds = new DataSet();
            if (isDetail)
            {
                string index = this.operPriv.ID + "By" + this.operDept.Memo + "Detail";

                if (!this.hsSqlConfig.ContainsKey(index))
                {
                    if (this.hsSqlConfig.ContainsKey(index + "For" + this.assortType.ToString()))
                    {
                        index = index + "For" + this.assortType.ToString();
                    }
                    else
                    {
                        Function.ShowMsg("未找到" + index + "Sql语句");
                        return -1;
                    }
                }

                if (this.detailIndexNum >= this.neuSpread1_Sheet1.Columns.Count)
                {
                    this.detailIndexNum = this.neuSpread1_Sheet1.Columns.Count;
                }

                string[] detailData = new string[this.detailIndexNum];

                for (int i = 0; i < this.detailIndexNum; i++)
                {
                    detailData[i] = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, i].Text;
                }

                if (!this.hsSqlConfig.ContainsKey(index))
                {
                    Function.ShowMsg("未找到" + index + "对应Sql语句");
                    return -1;
                }

                ds = this.reportManager.MaterialReport(this.hsSqlConfig[index] as string, this.operDept.ID, this.BeginTime.ToString(),
                    this.EndTime.ToString(), this.operPriv.Memo, this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text,
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text,
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 2].Text);

                if (ds != null && ds.Tables.Count > 0)
                {
                    this.dtDetail = ds.Tables[0];
                }
                else
                {
                    Function.ShowMsg(this.reportManager.Err);
                    return -1;
                }
            }
            else
            {
                string index = this.operPriv.ID + "By" + this.assortType.ToString();

                //				this.SetToolButton(this.operPriv.ID + "By");

                if (!this.hsSqlConfig.ContainsKey(index))
                {
                    Function.ShowMsg("未找到" + index + "对应Sql语句");
                    return -1;
                }

                ds = this.reportManager.MaterialReport(this.hsSqlConfig[index] as string, this.operDept.ID, this.BeginTime.ToString(),
                    this.EndTime.ToString(), this.operPriv.Memo);

                if (ds != null && ds.Tables.Count > 0)
                {
                    this.dt = ds.Tables[0];

                    this.privIndex = index;

                    if (this.hsSqlFpPath.ContainsKey(index))
                    {
                        this.neuSpread1_Sheet1.DataAutoHeadings = false;
                        this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.DataAutoHeadings = true;
                        this.neuSpread1_Sheet1.DataAutoSizeColumns = true;
                    }
                }
                else
                {
                    Function.ShowMsg(this.reportManager.Err);
                    return -1;
                }
            }

            return 1;
        }


        /// <summary>
        /// 查询
        /// </summary>
        protected void ShowData()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            
            this.lbSubTitle.Text = string.Format("日期: {0} - {1}", this.BeginTime.ToString(), this.EndTime.ToString());

            switch (this.assortType)
            {
                case AssortType.Mat:
                    this.tpTotal.Text = "按物品 汇总查询";
                    this.lbTitle.Text = "按物品 汇总查询";
                    break;
                case AssortType.MatCompany:
                    this.tpTotal.Text = "按部门 汇总查询";
                    this.lbTitle.Text = "按部门 汇总查询";
                    break;
                case AssortType.MatBill:
                    this.tpTotal.Text = "按单据 汇总查询";
                    this.lbTitle.Text = "按单据 汇总查询";
                    break;
            }

            if (this.isUseSqlConfig)
            {
                if (this.GetDataByConfig(false) == -1)
                {
                    return;
                }
            }
            else
            {
                this.exeSqlIndex = this.GetSqlIndex(false);
                if (this.exeSqlIndex == null)
                {
                    this.exeSqlIndex = "";
                    return;
                }

                if (this.GetDataTable(this.exeSqlIndex, false) != 1)
                {
                    return;
                }
            }

            foreach (DataRow dr in this.dt.Rows)
            {
                if (this.dt.Columns.Contains("供货公司"))
                    dr["供货公司"] = this.companyHelper.GetName(dr["供货公司"].ToString());
                if (this.dt.Columns.Contains("生产厂家"))
                    dr["生产厂家"] = this.producHelper.GetName(dr["生产厂家"].ToString());
            }

            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;

            this.Sum();

            this.SetFormat();

            this.Filter();

            this.SetFormat();

            if (this.tabControl1.SelectedTab == this.tpDetail)
            {
                this.tabControl1.SelectedTab = this.tpTotal;
            }
        }


        /// <summary>
        /// 明细查询
        /// </summary>
        protected void ShowDetail()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索明细信息...请稍候");
                Application.DoEvents();

                if (this.isUseSqlConfig)
                {
                    if (this.GetDataByConfig(true) == -1)
                    {
                        return;
                    }
                }
                else
                {
                    this.exeSqlIndex = this.GetSqlIndex(true);

                    if (this.GetDataTable(this.exeSqlIndex, true) != 1)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return;
                    }
                }

                this.neuSpread2_Sheet1.DataSource = this.dtDetail.DefaultView;

                this.SetFormat();

                if (!this.tabControl1.TabPages.Contains(this.tpDetail))
                {
                    this.tabControl1.TabPages.Add(this.tpDetail);
                }

                this.tabControl1.SelectedTab = this.tpDetail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }


        /// <summary>
        /// 格式化
        /// </summary>
        protected void SetFormat()
        {
            this.GetFpSetting();
        }


        /// <summary>
        /// 合计计算
        /// </summary>
        protected void Sum()
        {
            //在列表内加入合计项
            DataRow row = this.dt.NewRow();

            #region 添加合计列
            switch (this.exeSqlIndex)
            {
                case "OutByMat":	//对住院按物品查询
                    row[1] = "合计:";
                    row[8] = this.dt.Compute("sum(金额)", "");
                    row[11] = this.dt.Compute("sum(库存金额)", "");
                    row["拼音码"] = "%";		//防止在调用过滤函数时该行被过滤掉
                    this.dt.Rows.Add(row);
                    break;
                case "OutByCompany":
                    row[1] = "合计:";
                    row[2] = this.dt.Compute("sum(金额)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);
                    break;
                case "StockByBill":
                    row[0] = "合计:";
                    row[2] = this.dt.Compute("sum(零售总金额)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "StockByMat":
                    row[1] = "合计:";
                    row[7] = this.dt.Compute("sum(采购计划金额)", "");
                    row[8] = this.dt.Compute("sum(审核金额)", "");
                    row[9] = this.dt.Compute("sum(零售金额)", "");
                    row["拼音码"] = "%";	//防止在调用过滤函数时该行被过滤掉
                    this.dt.Rows.Add(row);
                    break;
                case "StockByCompany":
                    row[1] = "合计:";
                    row[6] = this.dt.Compute("sum(采购计划金额)", "");
                    row[7] = this.dt.Compute("sum(零售金额)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);
                    break;
                case "CheckByBill":
                    row[0] = "合计:";
                    row[6] = this.dt.Compute("sum(盘盈金额)", "");
                    row[7] = this.dt.Compute("sum(盘亏金额)", "");
                    row[8] = this.dt.Compute("sum(盈亏合计)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "CheckByMat":
                    row[1] = "合计:";
                    row[6] = this.dt.Compute("sum(封帐库存)", "");
                    row[7] = this.dt.Compute("sum(盘点库存)", "");
                    row[8] = this.dt.Compute("sum(盈亏数量)", "");
                    row[9] = this.dt.Compute("sum(盈亏金额)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);
                    break;

                case "InByMat":
                    row[1] = "合计";
                    row[10] = this.dt.Compute("sum(零售总金额)", "");
                    row[12] = this.dt.Compute("sum(入库总金额)", "");
                    row[13] = this.dt.Compute("sum(批零差)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);
                    break;
                case "InByBill":
                    row[0] = "合计";
                    row[3] = this.dt.Compute("sum(零售总金额)", "");
                    row[4] = this.dt.Compute("sum(入库总金额)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "InByCompany":
                    row[1] = "合计";
                    row[4] = this.dt.Compute("sum(零售金额)", "");
                    row[5] = this.dt.Compute("sum(入库金额)", "");
                    row[6] = this.dt.Compute("sum(批零差)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);
                    break;
                case "SendByCompany":
                    row[1] = "合计";
                    row[3] = this.dt.Compute("sum(金额)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "SendByMat":
                    row[1] = "合计";
                    row[6] = this.dt.Compute("sum(金额)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "SendByBill":
                    row[0] = "合计";
                    row[6] = this.dt.Compute("sum(金额)", "");
                    this.dt.Rows.Add(row);
                    break;
                case "AdjustByCompany":
                    row[0] = "合计:";
                    row[13] = this.dt.Compute("sum(盈亏金额)", "");
                    row["拼音码"] = "%";
                    this.dt.Rows.Add(row);

                    break;
            }
            #endregion
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
                    this.neuSpread2.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 数据导出
        /// </summary>
        protected virtual void Export()
        {
            this.ExportInfo();
        }

        /// <summary>
        /// 打印
        /// </summary>
        protected void Print()
        {/*
            ArrayList al = new ArrayList();

            if (this.operPriv.Name.IndexOf("入库") >= 0)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value))
                    {
                        string applyNO = this.neuSpread1_Sheet1.Cells[i, 1].Text;

                        al = this.myStore.QueryInputDetailByListNO(this.operDept.ID, applyNO);

                        if (al != null && al.Count > 0)
                        {
                            Material.ucMatInput ucMat = new  Material.ucMatInput();
                            ucMat.Decimals = 2;
                            ucMat.MaxRowNo = 17;
                            ucMat.IsReprint = true;
                            ucMat.SetDataForInput(al, 1, this.myStore.Operator.ID, "1");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value))
                    {
                        string applyNO = this.neuSpread1_Sheet1.Cells[i, 0].Text;

                        al = this.myStore.QueryOutputByListNO(this.operDept.ID, applyNO, "A");

                        if (al != null && al.Count > 0)
                        {
                            Material.ucMatOutput ucMat = new Material.ucMatOutput();
                            ucMat.Decimals = 2;
                            ucMat.MaxRowNo = 17;
                            ucMat.IsReprint = true;
                            ucMat.SetDataForInput(al, 1, this.myStore.Operator.ID, "1");
                        }
                    }
                }
            }
            */
        }

        #endregion

        #region 配置文件读取

        private System.Collections.Hashtable hsFpPathConfig = new Hashtable();

        /// <summary>
        /// Sql语句存储
        /// </summary>
        private System.Collections.Hashtable hsSqlConfig = new Hashtable();

        /// <summary>
        /// Fp格式文件存储
        /// </summary>
        private System.Collections.Hashtable hsSqlFpPath = new Hashtable();

        /// <summary>
        /// 服务期路径
        /// </summary>
        private string serverPath = "";

        /// <summary>
        /// 用户配置路径
        /// </summary>
        private string configPath = "";

        /// <summary>
        /// 读取Sql配置信息
        /// </summary>
        /// <returns></returns>
        private int GetSetting()
        {
            #region 获取配置文件路径

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(Application.StartupPath + "\\url.xml");

            System.Xml.XmlNode node = doc.SelectSingleNode("//dir");
            if (node == null)
            {
                MessageBox.Show("url中找dir结点出错！");
                return -1;
            }

            this.serverPath = node.InnerText;
            this.configPath = "//Report_Setting.xml"; //远程配置文件名 			

            #endregion

            try
            {
                //doc.Load(serverPath + configPath);
                doc.Load(Application.StartupPath + "\\server" + configPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("装载HisProfile.xml失败！\n" + ex.Message);
                return -1;
            }

            System.Xml.XmlNode nodeCollection = doc.SelectSingleNode("/Setting/Fun[@ID='Mat']");

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            foreach (System.Xml.XmlNode reportConfigNode in nodeCollection.ChildNodes)
            {
                System.Xml.XmlNode sqlNode = reportConfigNode.ChildNodes[0];
                if (reportConfigNode.Attributes["sqlLocation"].Value == "1")        //Sql位于Xml内
                {
                    this.hsSqlConfig.Add(reportConfigNode.Attributes["ID"].Value, sqlNode.InnerText);
                }
                else
                {
                    string sql = "";
                    if (dataManager.Sql.GetSql(sqlNode.Attributes["index"].Value, ref sql) == -1)
                    {
                        MessageBox.Show("根据索引未获取Sql语句!" + sqlNode.Attributes["index"].Value);
                    }
                    this.hsSqlConfig.Add(reportConfigNode.Attributes["ID"].Value, sql);
                }

                System.Xml.XmlNode fpPathNode = reportConfigNode.ChildNodes[1];
                if (fpPathNode.Attributes["fileName"].Value.ToString() != "")
                {
                    this.hsSqlFpPath.Add(reportConfigNode.Attributes["ID"].Value, fpPathNode.Attributes["fileName"].Value);
                }
            }

            return 1;
        }


        /// <summary>
        /// Fp格式设置
        /// </summary>
        /// <returns></returns>
        private int GetFpSetting()
        {
            if (this.hsFpPathConfig.ContainsKey(this.privIndex))
            {
                System.Xml.XmlDocument hsDoc = this.hsFpPathConfig[this.privIndex] as System.Xml.XmlDocument;

                frmSetConfig.SetFpByConfig(this.neuSpread1_Sheet1, hsDoc);

                return 1;
            }

            string pathName = "";
            if (this.hsSqlFpPath.ContainsKey(this.privIndex))
            {
                pathName = this.hsSqlFpPath[this.privIndex] as string;

                if (pathName.IndexOf(".xml") == -1)
                {
                    pathName = pathName + ".xml";
                }
            }
            else
            {
                return -1;
            }

            #region 获取配置文件路径

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(Application.StartupPath + "\\url.xml");

            System.Xml.XmlNode node = doc.SelectSingleNode("//dir");
            if (node == null)
            {
                MessageBox.Show("url中找dir结点出错！");
                return -1;
            }

            this.serverPath = node.InnerText;

            this.configPath = "/FpSetting/" + pathName; //远程配置文件名 

            #endregion

            try
            {
                //doc.Load(serverPath + configPath);
                doc.Load(Application.StartupPath + "\\server" + configPath);

                frmSetConfig.SetFpByConfig(this.neuSpread1_Sheet1, doc);

                this.hsFpPathConfig.Add(this.privIndex, doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("装载HisProfile.xml失败！\n" + ex.Message);
                return -1;
            }

            return 1;
        }


        #endregion

        #region 事件

        private void ucGeneralQuery_Load(object sender, System.EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.GetSetting();
                this.InitData();

                if (this.InitPrivDept() == 1)
                {
                    this.operDept = this.tvDept.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;

                    this.InitPrivOper();
                }
            }
        }

        private void tvOper_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //取节点名称
            if (e.Node.Tag != null)
            {
                this.operPriv = e.Node.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass3;

                if (e.Node.Parent != null)
                {
                    this.operPriv.PowerLevelClass2 = e.Node.Parent.Tag as Neusoft.HISFC.Models.Admin.PowerLevelClass2;
                }
                //				this.SetToolButton();

                this.ShowData();
            }
        }

        private void tvDept_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //操作员选择的科室代码
            if (e.Node != null && e.Node.Tag != null)
            {
                this.operDept = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.InitPrivOper();
            }
        }

        private void txtFilter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
        }

        private void txtFilter_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.neuSpread1_Sheet1.RowCount == 0)
                    return;

                if (this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text == "合计:" || this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text == "合计:")
                    return;

                //显示详细信息
                this.ShowDetail();
            }
        }

        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            this.Filter();
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.tabControl1.Contains(this.tpDetail))
                    this.tabControl1.TabPages.Remove(this.tpDetail);
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.exeSqlIndex == "AdjustByCompany")
                return;

            if (e.ColumnHeader)
                return;

            if (this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text == "合计:" || this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text == "合计:")
                return;

            //显示详细信息
            this.ShowDetail();
        }


        #endregion

        /// <summary>
        /// 操作科目分类 
        /// </summary>
        private enum AssortType
        {
            /// <summary>
            /// 按物品
            /// </summary>
            Mat,
            /// <summary>
            /// 按供货单位
            /// {498DAEEA-4F5C-4bdc-8FE9-9AC3875D887B}
            /// </summary>
            MatCompany,
            /// <summary>
            /// 按单据
            /// {498DAEEA-4F5C-4bdc-8FE9-9AC3875D887B}
            /// </summary>
            MatBill
        }
    }
}
