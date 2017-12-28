using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.DrugStore
{
    /// <summary>
    /// [功能描述: 虚库存管理]<br></br>
    /// [创 建 者: liangjz]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDummyStockManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDummyStockManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper produceHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelpre = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 服务属性
        /// </summary>
        private Neusoft.HISFC.Models.Base.ServiceTypes type = Neusoft.HISFC.Models.Base.ServiceTypes.C;

        /// <summary>
        /// 科室虚库存数据表
        /// </summary>
        private DataTable dtDeptPreStock = null;

        /// <summary>
        /// 科室虚库存数据视图
        /// </summary>
        private DataView dvDeptPreStock = null;
        #endregion

        #region 属性

        /// <summary>
        /// 服务属性
        /// </summary>
        [Description("患者列表加载类型 C 门诊 I 住院"),Category("设置")]
        public Neusoft.HISFC.Models.Base.ServiceTypes Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        protected DateTime DtBegin
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpBegin.Text);
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        protected DateTime DtEnd
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpEnd.Text);
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            return this.toolBarService;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (this.neuTabControl1.SelectedTab == this.tabPage1)
            {
                this.SavePatientPreStock();
            }
            else
            {
                this.SaveDeptPreStock();
            }

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.neuTabControl1.SelectedTab == this.tabPage1)
            {
                if (this.type == Neusoft.HISFC.Models.Base.ServiceTypes.C)
                {
                    this.ShowOutPatientTree();
                }
                else
                {
                    this.ShowInPatientTree();
                }
            }
            else
            {
                this.ShowDeptPreStock();
            }

            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "全选":

                    break;
                case "全不选":
                    break;

            }

        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int Init()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            ArrayList alProduce = consManager.QueryCompany("0");
            if (alProduce == null)
            {
                MessageBox.Show(Language.Msg("获取生产厂家列表发生错误" + consManager.Err));
                return -1;
            }
            this.produceHelper = new Neusoft.FrameWork.Public.ObjectHelper(alProduce);

            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)consManager.Operator).Dept;

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDept = managerIntegrate.GetDeptmentAllValid();
            this.deptHelpre = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            this.InitDataSet();

            DateTime sysTime = consManager.GetDateTimeFromSysDateTime();

            this.dtpEnd.Value = sysTime.Date.AddDays(1);
            this.dtpBegin.Value = sysTime.Date.AddDays(-7);

            this.tvPatient.ImageList = this.tvPatient.deptImageList;

            return 1;
        }

        /// <summary>
        /// DataSet初始化
        /// </summary>
        /// <returns></returns>
        protected void InitDataSet()
        {
            this.dtDeptPreStock = new DataTable();

            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDTime = System.Type.GetType("System.DateTime");

            this.dtDeptPreStock.Columns.AddRange(new DataColumn[] {
														new DataColumn("药品名称",    dtStr),//0
														new DataColumn("规格",        dtStr),//1
                                                        new DataColumn("零售价",      dtDec),
														new DataColumn("生产厂家",    dtStr),//2
														new DataColumn("实际库存",    dtDec),//3
                                                        new DataColumn("原预扣量",    dtDec),
														new DataColumn("预扣库存",    dtDec),//5
														new DataColumn("单位",        dtStr),//6
                                                        new DataColumn("药品编码",    dtStr),//7
														new DataColumn("拼音码",      dtStr),//8
														new DataColumn("五笔码",      dtStr),//9	
														new DataColumn("自定义码",    dtStr),//10
                    								});

            this.deptSpread_Sheet1.DataSource = this.dtDeptPreStock;
        }

        #endregion

        /// <summary>
        /// 将数据加入数据表
        /// </summary>
        /// <param name="storage">库存数据</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDataToDataTable(Neusoft.HISFC.Models.Pharmacy.Storage storage)
        {
            DataRow row = this.dtDeptPreStock.NewRow();
            try
            {
                row["药品名称"] = storage.Item.Name;
                row["规格"] = storage.Item.Specs;
                row["零售价"] = storage.Item.PriceCollection.RetailPrice;
                if (storage.Producer.ID != "")
                {
                    row["生产厂家"] = this.produceHelper.GetName(storage.Producer.ID);
                }
                row["实际库存"] = storage.StoreQty;
                row["原预扣量"] = storage.PreOutQty;
                row["预扣库存"] = storage.PreOutQty;

                row["单位"] = storage.Item.MinUnit;

                row["药品编码"] = storage.Item.ID;                                                               
                row["拼音码"] = storage.Item.NameCollection.SpellCode;
                row["五笔码"] = storage.Item.NameCollection.WBCode;
                row["自定义码"] = storage.Item.UserCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("根据库存信息对数据行进行赋值时发生错误!") + ex.Message);
                return -1;
            }

            this.dtDeptPreStock.Rows.Add(row);

            return 1;
        }

        /// <summary>
        /// 科室虚库存加载
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowDeptPreStock()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载科室库存信息,请稍候..."));
            Application.DoEvents();

            ArrayList alStock = this.itemManager.QueryStockinfoList(this.privDept.ID);
            if (alStock == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("查询科室库存汇总信息发生错误") + this.itemManager.Err);
                return -1;
            }

            this.deptSpread_Sheet1.Rows.Count = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.Storage info in alStock)
            {
                this.AddDataToDataTable(info);
            }

            this.dtDeptPreStock.AcceptChanges();

            this.dvDeptPreStock = this.dtDeptPreStock.DefaultView;

            this.deptSpread_Sheet1.DataSource = this.dvDeptPreStock;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 科室虚库存管理保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SaveDeptPreStock()
        {
            this.deptSpread.StopCellEditing();

            this.dvDeptPreStock.RowFilter = "1=1";
            for (int i = 0; i < this.dvDeptPreStock.Count; i++)
            {
                this.dvDeptPreStock[i].EndEdit();
            }

            DataTable dtModify = this.dtDeptPreStock.GetChanges(DataRowState.Modified);
            if (dtModify == null || dtModify.Rows.Count <= 0)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (DataRow dr in dtModify.Rows)
            {
                decimal storeQty = NConvert.ToDecimal(dr["实际库存"]);
                decimal preQty = NConvert.ToDecimal(dr["预扣库存"]);
                decimal originalQty = NConvert.ToDecimal(dr["原预扣量"]);

                if (preQty > storeQty)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存不能进行。【" + dr["药品名称"].ToString() + "】虚库存量不能大于实际库存量！"), "提示");
                    return -1;
                }

                //虚库存管理模式变更 此处未来得及修改

                //if (this.itemManager.UpdateStockinfoPreOutNum(this.privDept.ID, dr["药品编码"].ToString(), preQty - originalQty) == -1)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show(Language.Msg("保存操作 更新库存失败") + this.itemManager.Err);
                //    return -1;
                //}
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        /// <summary>
        /// 向树内加入节点
        /// </summary>
        /// <param name="alNodePatient">用药申请患者信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDataToTree(List<Neusoft.FrameWork.Models.NeuObject> alNodePatient)
        {
            this.tvPatient.Nodes.Clear();

            string preDeptCode = "";
            TreeNode deptNode = null;           //科室节点

            foreach (Neusoft.FrameWork.Models.NeuObject info in alNodePatient)
            {
                if (info.Memo == preDeptCode)          //同一科室
                {
                    TreeNode node = new TreeNode(info.Name);
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                    node.Tag = info;

                    deptNode.Nodes.Add(node);
                }
                else
                {
                    deptNode = new TreeNode(this.deptHelpre.GetName(info.Memo));
                    deptNode.ImageIndex = 0;
                    deptNode.SelectedImageIndex = deptNode.ImageIndex;

                    deptNode.Tag = null;

                    this.tvPatient.Nodes.Add(deptNode);

                    TreeNode node = new TreeNode(info.Name);
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;
                    node.Tag = info;

                    deptNode.Nodes.Add(node);
                }
            }

            return 1;
        }

        /// <summary>
        /// 显示住院患者虚库存预扣列表
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowInPatientTree()
        {
            List<Neusoft.FrameWork.Models.NeuObject> alInPatientApply = this.itemManager.QueryInPatientApplyOutList(this.privDept.ID, this.DtBegin, this.DtEnd, "0");
            if (alInPatientApply == null)
            {
                MessageBox.Show(Language.Msg("获取住院患者申请列表发生错误") + this.itemManager.Err);
                return -1;
            }

            this.AddDataToTree(alInPatientApply);

            return 1;
        }

        /// <summary>
        /// 显示门诊患者虚库存预扣列表
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowOutPatientTree()
        {
            List<Neusoft.FrameWork.Models.NeuObject> alOutPatientApply = this.itemManager.QueryOutPatientApplyOutList(this.privDept.ID, this.DtBegin, this.DtEnd, "0","1");
            if (alOutPatientApply == null)
            {
                MessageBox.Show(Language.Msg("获取门诊患者申请列表发生错误") + this.itemManager.Err);
                return -1;
            }

            this.AddDataToTree(alOutPatientApply);

            return 1;
        }

        /// <summary>
        /// 将患者预扣药品申请信息加入Fp
        /// </summary>
        /// <param name="applyOut">预扣申请信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDataToFp(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            int rowCount = this.patientSpread1_Sheet1.Rows.Count;

            this.patientSpread1_Sheet1.Rows.Add(rowCount, 1);

            this.patientSpread1_Sheet1.Cells[rowCount, 0].Value = false;
            this.patientSpread1_Sheet1.Cells[rowCount, 1].Text = applyOut.Item.Name;
            this.patientSpread1_Sheet1.Cells[rowCount, 2].Text = applyOut.Item.Specs;
            this.patientSpread1_Sheet1.Cells[rowCount, 3].Text = applyOut.Item.PriceCollection.RetailPrice.ToString();
            this.patientSpread1_Sheet1.Cells[rowCount, 4].Text = applyOut.Days.ToString();
            this.patientSpread1_Sheet1.Cells[rowCount, 5].Text = applyOut.Operation.ApplyQty.ToString();
            this.patientSpread1_Sheet1.Cells[rowCount, 6].Text = applyOut.Item.MinUnit;
            this.patientSpread1_Sheet1.Cells[rowCount, 7].Text = System.Math.Round((applyOut.Operation.ApplyQty * applyOut.Days * applyOut.Item.PriceCollection.RetailPrice / applyOut.Item.PackQty), 2).ToString();
            this.patientSpread1_Sheet1.Cells[rowCount, 8].Text = applyOut.Operation.ApplyOper.OperTime.ToString();

            this.patientSpread1_Sheet1.Rows[rowCount].Tag = applyOut;

            return 1;
        }

        /// <summary>
        /// 患者虚库存加载
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ShowPatientPreStock(string patientID,string applyDept)
        {
            this.patientSpread1_Sheet1.Rows.Count = 0;

            ArrayList alApplyOut = this.itemManager.GetPatientApply(patientID, this.privDept.ID, applyDept,this.DtBegin, this.DtEnd, "0");
            if (alApplyOut == null)
            {
                MessageBox.Show(Language.Msg("获取患者用药申请信息发生错误" + this.itemManager.Err));
                return -1;
            }            

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alApplyOut)
            {
                this.AddDataToFp(info);
            }

            return 1;
        }

        /// <summary>
        /// 患者虚库存管理保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePatientPreStock()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool isHaveChecked = false;
            for(int i = 0;i < this.patientSpread1_Sheet1.Rows.Count;i++)
            {
                if (NConvert.ToBoolean(this.patientSpread1_Sheet1.Cells[i, 0].Value))
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.patientSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                    if (this.itemManager.UpdateStockinfoPreOutNum(applyOut,-applyOut.Operation.ApplyQty ,applyOut.Days) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("保存操作 更新库存失败") + this.itemManager.Err);
                        return -1;
                    }

                    isHaveChecked = true;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            if (isHaveChecked)
            {
                MessageBox.Show(Language.Msg("保存成功"));
            }
            else
            {
                MessageBox.Show(Language.Msg("请选择需保存的患者虚扣药品"));
            }

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }

            base.OnLoad(e);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.dtDeptPreStock.Rows.Count <= 0)
            {
                return;
            }

            if (this.dvDeptPreStock == null)
            {
                return;
            }

            try
            {
                string queryCode = "%" + this.txtFilter.Text.Trim() + "%";
                string filterStr = string.Format("拼音码 like '{0}' or 五笔码 like '{0}' or 自定义码 like '{0}' or 药品名称 like '{0}'", queryCode);
                
                this.dvDeptPreStock.RowFilter = filterStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.deptSpread.Focus();
                this.deptSpread_Sheet1.ActiveRowIndex = 0;
                this.deptSpread_Sheet1.ActiveColumnIndex = 6;
            }
        }

        private void tvPatient_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Neusoft.FrameWork.Models.NeuObject info = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.ShowPatientPreStock(info.ID, info.Memo);
            }
        }
    }
}
