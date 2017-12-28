using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// [功能描述: 住院摆药查询 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}]<br></br>
    /// [修 改 者: 孙久海]<br></br>
    /// [修改时间: 2010-11-17]<br></br>
    /// <修改记录>
    ///    1.兼容住院集中发药相关 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
    /// </修改记录>
    /// </summary>
    public partial class ucSendDrugByNurse : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSendDrugByNurse()
        {
            InitializeComponent();
 

            //默认不显示退费信息/处方单信息
            this.IsShowQuitBill = false;
            this.IsShowOutBill = false;
        }

        #region 枚举

        /// <summary>
        /// 列表节点加载类型
        /// </summary>
        public enum NodeType
        {
            /// <summary>
            /// 患者
            /// </summary>
            Patient,
            /// <summary>
            /// 取药科室
            /// </summary>
            Dept
        }

        /// <summary>
        /// 取药部门类型 
        /// </summary>
        public enum ReciveDrugType
        {
            /// <summary>
            /// 科室
            /// </summary>
            Dept,
            /// <summary>
            /// 护理站
            /// </summary>
            NurseCell
        }

        #endregion

        #region 域变量

        /// <summary>
        /// 药房管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 药库管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 基础信息管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager departmentManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 控制参数管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 树节点类型 0 护理站 Patient 显示患者 1 病区 Dept 取药病区
        /// </summary>
        protected NodeType treeType = NodeType.Patient;

        /// <summary>
        /// 取药部门类型
        /// </summary>
        protected ReciveDrugType reciveType = ReciveDrugType.Dept;

        /// <summary>
        /// 住院号查询
        /// </summary>
        protected string InPatientNo = "";

        /// <summary>
        /// 药品性质
        /// </summary>
        protected DataSet QualityDataSet = new DataSet();

        /// <summary>
        /// 按病区查询
        /// </summary>
        protected DataSet DeptDataSet = new DataSet();

        /// <summary>
        /// 护理站查询的DataSet
        /// </summary>
        protected DataSet NurseDtaSet = new DataSet();

        /// <summary>
        /// 查询科室 可查询本护理站的所有科室
        /// </summary>
        private ArrayList deptInfo = null;

        /// <summary>
        /// 帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 当前操作员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee operVar = null;

        /// <summary>
        /// 当前查询的数据条件
        /// </summary>
        private object nowObj = null;

        private string billClassName = "";

        /// <summary>
        /// 当前选择查询的层数
        /// </summary>
        private int showLevel = 0;

        /// <summary>
        /// 是否按摆药单汇总显示
        /// </summary>
        private bool isShowDrugBill = true;

        /// <summary>
        /// 是否按病案号查询
        /// </summary>
        private bool isQueryByCaseNO = false;

        private Hashtable hsSelected = new Hashtable();

        /// <summary>
        /// 是否正在保存
        /// </summary>
        private bool isBusy = false;

        /// <summary>
        /// 是否按病区显示领药信息
        /// </summary>
        private bool ShowByNurseCell = false;

        string deptTemp = "";

        /// <summary>
        /// 是否提示消息 更新程序变更流程 {55B34E3A-7741-4420-A947-29DE881A0119} wbo 2010-12-28
        /// </summary>
        private bool isShowMessage = true;

        #endregion

        #region 属性

        /// <summary>
        /// 树节点类型 0 护理站 Patient 显示患者 1 病区 Dept 取药病区
        /// </summary>
        [Description("左侧树节点加载数据类型"), Category("设置"), DefaultValue(ucSendDrugByNurse.NodeType.Patient)]
        public NodeType TreeType
        {
            get
            {
                return this.treeType;
            }
            set
            {
                this.treeType = value;

                if (value == NodeType.Patient)			//护理站使用 显示患者列表/退费信息/处方单信息
                {              
                    if (this.SpreadDrug.Sheets.Contains(this.sheetViewDetail))
                        this.SpreadDrug.Sheets.Remove(this.sheetViewDetail);
                    //不显示药品性质列表
                    if (this.neuTabControl1.TabPages.Contains(this.tpQuality))
                        this.neuTabControl1.TabPages.Remove(this.tpQuality);

                    this.IsShowCheck = false;
                    //this.ShowNurse();

                    this.lbTime.Text = "申请时间：";
                }
                else					//药房摆药查询 显示取药病区/药品性质列表
                {
                    //不显示退费信息/处方单信息列表
                    if (this.neuTabControl2.TabPages.Contains(this.tpQuitFee))
                        this.neuTabControl2.TabPages.Remove(this.tpQuitFee);
                    if (this.neuTabControl2.TabPages.Contains(this.tpOutBill))
                        this.neuTabControl2.TabPages.Remove(this.tpOutBill);

                    //this.ShowDept();
                    //this.ShowDrugQuality();

                    this.lbTime.Text = "发药时间：";
                }
            }
        }

        /// <summary>
        /// 取药部门类型
        /// </summary>
        [Description("取药部门类型 科室或护理站"), Category("设置"), DefaultValue(ucSendDrugByNurse.ReciveDrugType.Dept)]
        public ReciveDrugType ReciveType
        {
            get
            {
                return this.reciveType;
            }
            set
            {
                this.reciveType = value;
            }
        }

        /// <summary>
        /// 是否显示处方单查询Tab
        /// </summary>
        [Description("是否显示处方单查询Tab"), Category("设置"), DefaultValue(false)]
        public bool IsShowOutBill
        {
            get
            {
                return this.neuTabControl2.TabPages.Contains(this.tpOutBill);
            }
            set
            {
                if (value && !this.neuTabControl2.TabPages.Contains(this.tpOutBill))
                    this.neuTabControl2.TabPages.Add(this.tpOutBill);
                if (!value && this.neuTabControl2.TabPages.Contains(this.tpOutBill))
                    this.neuTabControl2.TabPages.Remove(this.tpOutBill);
            }
        }

        /// <summary>
        /// 是否显示退费单查询Tab
        /// </summary>
        [Description("是否显示退费单查询Tab"), Category("设置"), DefaultValue(false)]
        public bool IsShowQuitBill
        {
            get
            {
                return this.neuTabControl2.TabPages.Contains(this.tpQuitFee);
            }
            set
            {
                if (value && !this.neuTabControl2.TabPages.Contains(this.tpQuitFee))
                    this.neuTabControl2.TabPages.Add(this.tpQuitFee);
                if (!value && this.neuTabControl2.TabPages.Contains(this.tpQuitFee))
                    this.neuTabControl2.TabPages.Remove(this.tpQuitFee);
            }
        }

        /// <summary>
        /// 是否显示已摆/未摆过滤选择框
        /// </summary>
        [Description("是否显示已摆/未摆过滤选择框"), Category("设置"), DefaultValue(true)]
        public bool IsShowCheck
        {
            get
            {
                return this.rbSended.Visible;
            }
            set
            {
                this.rbSended.Visible = value;
                this.rbSending.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示过滤框
        /// </summary>
        [Description("是否显示过滤框"), Category("设置"), DefaultValue(true)]
        public bool IsShowFilter
        {
            set
            {
                this.lbFilter.Visible = value;
                this.txtFilter.Visible = value;
            }
        }

        /// <summary>
        ///  是否有查询权限 具有查询权限可以对查询时间进行修改
        /// </summary>
        [Description("是否需要查询权限 如需要权限 如无查询权限时不能对查询时间进行修改"), Category("设置"), 
        DefaultValue(true),Browsable(false)]
        public bool IsPrivQuery
        {
            set
            {
                this.dtpBegin.Enabled = value;
                this.dtpEnd.Enabled = value;
            }
        }

        /// <summary>
        /// 查询科室 可查询本护理站的所有科室
        /// </summary>
        [Description("查询科室"), Category("设置"), DefaultValue(true),Browsable(false)]
        public ArrayList DeptInfo
        {
            get
            {
                if (this.deptInfo == null)
                    this.deptInfo = new ArrayList();
                return this.deptInfo;
            }
            set
            {
                this.deptInfo = value;
            }
        }

        /// <summary>
        /// 是否按摆药单汇总显示 Add by Sunjh 2009-2-5 
        /// </summary>
        [Description("是否按摆药单汇总显示"), Category("设置"), DefaultValue(true)]
        public bool IsShowDrugBill
        {
            get 
            {
                return isShowDrugBill; 
            }
            set 
            { 
                isShowDrugBill = value; 
            }
        }

        /// <summary>
        /// 是否按病区显示领药信息 Add by Sunjh 2010-8-9 
        /// </summary>
        [Description("是否按病区显示领药信息"), Category("设置"), DefaultValue(false)]
        public bool ShowByNurseCell1
        {
            get 
            {
                return ShowByNurseCell;
            }
            set 
            { 
                ShowByNurseCell = value; 
            }
        }

        /// <summary>
        /// 是否提示消息 更新程序变更流程 {55B34E3A-7741-4420-A947-29DE881A0119} wbo 2010-12-28
        /// </summary>
        [Description("是否进入窗口显示提示信息，提示取消申请在病区直接可以取消"), Category("设置")]
        public bool IsShowMessage
        {
            get { return this.isShowMessage; }
            set { this.isShowMessage = value; }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return 1;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
            if (isNursePrint)
            {
                this.SetInterface();
                if (this.neuTabControl1.SelectedIndex == 1)
                {
                    this.RePrintDrugBill();
                }                
            }
            else
            {
                this.Print();
            }
            
            return 1;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
            if (isNursePrint)
            {
                this.SetInterface();
                if (this.neuTabControl1.SelectedIndex == 0)
                {
                    this.PrintDrugBill();
                }
                //else
                //{
                //    this.RePrintDrugBill();
                //}                
                this.Query();
            }
            //else
            //{
            //    this.Print();
            //}
            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            object obj = this.hashTableFp[this.neuTabControl2.SelectedTab];

            FarPoint.Win.Spread.FpSpread fp = obj as FarPoint.Win.Spread.FpSpread;

            SaveFileDialog op = new SaveFileDialog();

            op.Title = "请选择保存的路径和名称";
            op.CheckFileExists = false;
            op.CheckPathExists = true;
            op.DefaultExt = "*.xls";
            op.Filter = "(*.xls)|*.xls";

            DialogResult result = op.ShowDialog();

            if (result == DialogResult.Cancel || op.FileName == string.Empty)
            {
                return -1;
            }

            string filePath = op.FileName;

            bool returnValue = fp.SaveExcel(filePath, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);


            return base.Export(sender, neuObject);
        
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化Fp设置
        /// </summary>
        protected void FpInit()
        {
            //对汇总数据显示时 对第一列 第二列进行相同数值合并
            this.sheetViewTot.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);
            this.sheetViewTot.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always);
            //对明细数据显示时 对第一列进行相同数值合并
            this.sheetViewDetail.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);
            //设置对齐显示
            this.sheetViewTot.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.sheetViewTot.Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetViewTot.Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetViewDetail.Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
        }

        /// <summary>
        /// 初始化人员信息
        /// </summary>
        protected void OperInit()
        {
            if (this.operVar == null)
                this.operVar = ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator);
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        protected void DataInit()
        {
            this.dtpEnd.Value = this.itemManager.GetDateTimeFromSysDateTime();
            this.dtpBegin.Value = this.dtpEnd.Value.AddDays(-1);

            //取全院科室信息
            deptHelper.ArrayObject = this.departmentManager.GetDepartment();

            if (this.reciveType == ReciveDrugType.Dept)
            {
                this.deptInfo = departmentManager.QueryDepartment(this.operVar.Nurse.ID);
                if (this.deptInfo == null)
                {
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                    info.ID = this.operVar.Dept.ID;
                    info.Name = this.operVar.Dept.Name;
                    this.deptInfo.Add(info);
                }
            }
            else
            {
                this.deptInfo = new ArrayList();

                Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                info.ID = this.operVar.Nurse.ID;
                info.Name = this.operVar.Nurse.Name;
                this.deptInfo.Add(info);
            }

            //取人员信息
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            this.personHelper.ArrayObject = managerIntegrate.QueryEmployeeAll();
        }

        /// <summary>
        /// 导出设置
        /// </summary>
        protected Hashtable hashTableFp = new Hashtable();

        /// <summary>
        /// 初始化哈希表
        /// </summary>
        private void InitHashTable()
        {
            foreach (TabPage t in this.neuTabControl2.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is FarPoint.Win.Spread.FpSpread)
                    {
                        this.hashTableFp.Add(t, c);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化药房列表
        /// </summary>
        private void DeptInit()
        {
            ArrayList alTemp = this.departmentManager.GetConstantList("PHARMACYTYPE");
            //this.cbbPharmacy.AddItems(alTemp);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.FpInit();

            this.OperInit();

            this.DataInit();

            //this.DeptInit();

            this.tvDept.ImageList = this.tvDept.deptImageList;

            this.ucQueryInpatientNo1.InputType = 0;			//输入类型 住院号
            this.InitHashTable();

            //Function.dtDrugStore = this.GetDept();//获取药房科室

            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
            if (isNursePrint)
            {
                this.ucQueryInpatientNo1.Visible = false;
                this.neuPanel2.Visible = false;
                this.neuPanel1.Visible = true;
                this.tpBill.Show();
            }
            else
            {
                this.tpBill.Hide();
            }
            
            ArrayList alNurse = this.departmentManager.QueryNurseStationByDept(this.operVar.Dept, "01");
            foreach (Neusoft.FrameWork.Models.NeuObject infoTemp in alNurse)
            {
                ArrayList deptCell = this.departmentManager.QueryDepartment(infoTemp.ID);
                foreach (Neusoft.FrameWork.Models.NeuObject info in deptCell)
                {
                    if (deptTemp == "")
                    {
                        deptTemp = info.ID;
                    }
                    else
                    {
                        deptTemp = deptTemp + "','" + info.ID;
                    }
                }
            }

            this.neuTabControl1.TabPages.Remove(tpQuality);

        }

        /// <summary>
        /// 数据检索显示
        /// </summary>
        public void ShowData()
        {
            if (this.treeType == NodeType.Patient)			//护理站使用 显示患者列表/退费信息/处方单信息
            {
                this.ShowNurse();
            }
            else					//药房摆药查询 显示取药病区/药品性质列表
            {         
                this.ShowDept();
                this.ShowDrugQuality();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示护理站列表
        /// </summary>
        public void ShowNurse()
        {
            Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            this.OperInit();

            TreeNode deptNode = new TreeNode();
            deptNode.Text = this.operVar.Nurse.Name;
            deptNode.ImageIndex = 0;// (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T房间;
            deptNode.SelectedImageIndex = 0;

            //屏蔽原先的"摆药单"tab页
            //this.neuTabControl1.TabPages[2].Hide();
            //判断是否按摆药单分类 by sunjh 2009-2-5 {0057B27E-5BDD-4211-9CDC-D0F4608D6C79}
            if (this.IsShowDrugBill == true)
            {
                this.tpDept.Text = "摆药单";
                ArrayList al = new ArrayList();
                al = drugStoreManager.QueryDrugBillClassList();
                if (al == null)
                {
                    MessageBox.Show(Language.Msg("查询摆药单分类列表出错!"));
                    return;
                }

                TreeNode billNode;
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugBillClass billInfo in al)
                {
                    billNode = new TreeNode();
                    billNode.Text = billInfo.Name;
                    billNode.SelectedImageIndex = 1;
                    billNode.ImageIndex = 5;
                    billNode.Tag = billInfo.ID;
                    deptNode.Nodes.Add(billNode);
                }
                this.tvDept.Nodes.Add(deptNode);
                this.tvDept.ExpandAll();
            }
            else
            {
                this.tpDept.Text = "取药病区";
                ArrayList al = new ArrayList();
                al = radtManager.QueryPatient(this.operVar.Dept.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                if (al == null)
                {
                    MessageBox.Show(Language.Msg("查询本区患者列表出错!"));
                    return;
                }

                TreeNode patientNode;

                foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in al)
                {
                    patientNode = new TreeNode();
                    patientNode.Text = "【" + patientInfo.PVisit.PatientLocation.Bed.Name + "】" + patientInfo.Name;
                    patientNode.SelectedImageIndex = 1;
                    patientNode.ImageIndex = 5;// (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A人员;
                    patientNode.Tag = patientInfo.ID;
                    deptNode.Nodes.Add(patientNode);
                }
                this.tvDept.Nodes.Add(deptNode);
                this.tvDept.ExpandAll();
            }
            
            #region Not used
            //Neusoft.HISFC.Models.RADT.Location loc = new Neusoft.HISFC.Models.RADT.Location();
            //loc.NurseCell = this.operVar.User.Nurse.Clone();
            //loc.Dept = this.operVar.User.Dept.Clone();
            //Neusoft.HISFC.Models.RADT.VisitStatus state = new Neusoft.HISFC.Models.RADT.VisitStatus();
            //state.ID = Neusoft.HISFC.Models.RADT.VisitStatus.enuVisitStatus.I;
            //al = inPatient.PatientQuery(loc, state);    
            #endregion

        }

        /// <summary>
        /// 显示病区列表
        /// </summary>
        public void ShowDept()
        {
            this.OperInit();

            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            ArrayList al = phaConstant.QueryReciveDrugDept(this.operVar.Dept.ID);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取取药科室列表出错！" + phaConstant.Err));
                return;
            }

            TreeNode deptNode;
            TreeNode rootNode = new TreeNode("取药病区");
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;
            rootNode.Tag = "AAAA";
            foreach (Neusoft.FrameWork.Models.NeuObject info in al)
            {
                if (info == null) 
                    continue;
                deptNode = new TreeNode();
                deptNode.Text = info.Name;
                deptNode.ImageIndex = 4;
                deptNode.SelectedImageIndex = 5;
                deptNode.Tag = info.ID;
                rootNode.Nodes.Add(deptNode);
            }
            this.tvDept.Nodes.Add(rootNode);
            this.tvDept.ExpandAll();
        }

        /// <summary>
        /// 显示药品性质列表
        /// </summary>
        public void ShowDrugQuality()
        {

        }

        /// <summary>
        /// 公开函数 检索数据
        /// </summary>
        public void Query()
        {
            try
            {
                if (this.treeType == NodeType.Dept && this.neuTabControl1.SelectedTab == this.tpQuality && this.showLevel == 1)
                {
                    this.tvDrugType1.SelectedNode = this.tvDrugType1.Nodes[0];
                }

                this.Query(this.nowObj, this.showLevel);

                this.QueryNoExamData();

                this.SetFpColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("查询执行出错" + ex.Message));
                return;
            }
        }

        /// <summary>
        /// 查询函数
        /// </summary>
        /// <param name="obj">传入信息</param>
        /// <param name="level">0 点击根节点 1 点击子节点 2 通过住院号查询</param>
        protected void Query(object obj, int level)
        {            
            if (this.treeType == NodeType.Dept)             //列表显示取药病区 供药房进行摆药查询
            {
                this.SpreadDrug.ActiveSheet = this.sheetViewTot;

                if (this.SpreadDrug.Sheets.Contains(this.sheetViewDetail))
                    this.SpreadDrug.Sheets.Remove(this.sheetViewDetail);

                this.neuTabControl2.SelectedTab = this.tpDruged;
            }

            if (level == 1 && obj == null) 
                return;

            DataSet ds = new DataSet();
            if (this.treeType == NodeType.Patient)			//列表显示护理组患者 供病区进行取药查询
            {
                if (this.IsShowDrugBill == true && !this.isQueryByCaseNO)
                {
                    //对该护理站对应的摆药单进行查询
                    string dept = "";
                    foreach (Neusoft.FrameWork.Models.NeuObject info in this.deptInfo)
                    {
                        if (dept == "")
                            dept = info.ID;
                        else
                            dept = dept + "','" + info.ID;
                    }
                    if (level == 0)                             //根节点查询 查询本病区所有患者的汇总摆药情况
                    {
                        this.NurseDtaSet = new DataSet();
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByTime" };
                        this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, dept, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                    }
                    else                                      //子节点查询 查询指定患者的摆药情况
                    {
                        this.NurseDtaSet = new DataSet();
                        string[] strIndex;//new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient.BillClass" };
                        bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                        if (isNursePrint)
                        {
                            if (this.ShowByNurseCell)
                            {
                                //string deptTemp = "";
                                //ArrayList alNurse = this.departmentManager.QueryNurseStationByDept(this.operVar.Dept, "01");
                                //foreach (Neusoft.FrameWork.Models.NeuObject infoTemp in alNurse)
                                //{
                                //    ArrayList deptCell = this.departmentManager.QueryDepartment(infoTemp.ID);
                                //    foreach (Neusoft.FrameWork.Models.NeuObject info in deptCell)
                                //    {
                                //        if (deptTemp == "")
                                //        {
                                //            deptTemp = info.ID;
                                //        }
                                //        else
                                //        {
                                //            deptTemp = deptTemp + "','" + info.ID;
                                //        }
                                //    }
                                //}
                                strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByNurseCell.BillClass.ByStoreDept" };
                                this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, obj as string, deptTemp);
                            }
                            else
                            {
                                strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient.BillClass.ByStoreDept" };
                                this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, obj as string, this.operVar.Dept.ID);
                            }                            
                        }
                        else
                        {
                            strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient.BillClass" };
                            this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, obj as string, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(), this.operVar.Dept.ID);
                        }
                        
                        if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
                        {
                            try
                            {
                                for (int i = 0; i < NurseDtaSet.Tables[0].Rows.Count; i++)
                                {
                                    if (NurseDtaSet.Tables[0].Rows[i]["申请科室"] != null)
                                    {
                                        NurseDtaSet.Tables[0].Rows[i]["申请科室"] = deptHelper.GetName(NurseDtaSet.Tables[0].Rows[i]["申请科室"].ToString());
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
                    {
                        DataView dv = new DataView(this.NurseDtaSet.Tables[0]);
                        if (this.rbSended.Checked == true)
                        {
                            dv.RowFilter = string.Format("是否摆药 = '{0}'", "已摆");
                        }
                        if (this.rbSending.Checked == true)
                        {
                            dv.RowFilter = string.Format("是否摆药 = '{0}'", "未摆");
                        }
                        this.sheetViewTot.DataSource = dv;
                    }

                    this.SetFormat();
                }
                else
                {
                    #region 护理站

                    //对该护理站对应的科室进行查询
                    string dept = "";
                    foreach (Neusoft.FrameWork.Models.NeuObject info in this.deptInfo)
                    {
                        if (dept == "")
                            dept = info.ID;
                        else
                            dept = dept + "','" + info.ID;
                    }
                    if (level == 0)                             //根节点查询 查询本病区所有患者的汇总摆药情况
                    {
                        this.NurseDtaSet = new DataSet();
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByTime" };
                        this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, dept, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                    }
                    else                                      //子节点查询 查询指定患者的摆药情况
                    {
                        this.NurseDtaSet = new DataSet();
                        this.ucQueryInpatientNo1.Text = obj as string;
                        this.ucQueryInpatientNo1.Text = this.ucQueryInpatientNo1.Text.Substring(4);
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient" };
                        this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, obj as string, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                        if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
                        {
                            try
                            {
                                for (int i = 0; i < NurseDtaSet.Tables[0].Rows.Count; i++)
                                {
                                    if (NurseDtaSet.Tables[0].Rows[i]["申请科室"] != null)
                                    {
                                        NurseDtaSet.Tables[0].Rows[i]["申请科室"] = deptHelper.GetName(NurseDtaSet.Tables[0].Rows[i]["申请科室"].ToString());
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
                    {
                        DataView dv = new DataView(this.NurseDtaSet.Tables[0]);
                        if (this.rbSended.Checked == true)
                        {
                            dv.RowFilter = string.Format("是否摆药 = '{0}'", "已摆");
                        }
                        if (this.rbSending.Checked == true)
                        {
                            dv.RowFilter = string.Format("是否摆药 = '{0}'", "未摆");
                        }
                        this.sheetViewTot.DataSource = dv;
                    }

                    this.SetFormat();

                    #endregion
                }

                this.SetFpColor();
            }
            else
            {
                if (level == 2)                           //根据患者住院号查询
                {
                    string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient" };
                    this.itemManager.ExecQuery(strIndex, ref ds, obj as string, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (ds.Tables[0].Columns.Contains("申请科室"))
                            {
                                dr["申请科室"] = this.deptHelper.GetName(dr["申请科室"].ToString());
                            }
                            if (ds.Tables[0].Columns.Contains("发送人"))
                            {
                                dr["发送人"] = this.personHelper.GetName(dr["发送人"].ToString());
                            }
                            if (ds.Tables[0].Columns.Contains("发药人"))
                            {
                                dr["发药人"] = this.personHelper.GetName(dr["发药人"].ToString());
                            }
                        }
                        this.sheetViewTot.DataSource = ds;
                    }
                    this.SetNurseFormat();
                    return;
                }

                #region 病区
                if (this.neuTabControl1.SelectedTab == this.tpQuality)
                {
                    #region 按照药品性质检索
                    string qualityCode = "";
                    if (level == 0)
                    {

                        string applyState = "0','2','1";
                        if (this.rbSended.Checked)
                            applyState = "2','1";
                        if (this.rbSending.Checked)
                            applyState = "0";
                        this.QualityDataSet = new DataSet();
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOut.ByDrugQuality" };
                        this.itemManager.ExecQuery(strIndex, ref QualityDataSet, this.operVar.Dept.ID, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(), applyState);
                        if (QualityDataSet != null && QualityDataSet.Tables.Count > 0)
                            this.sheetViewTot.DataSource = QualityDataSet;
                        else
                            return;
                        if (this.QualityDataSet.Tables[0].Rows.Count > 0)
                        {
                            if (this.QualityDataSet.Tables[0].Rows[this.QualityDataSet.Tables[0].Rows.Count - 1][1].ToString() == "合计：")
                            {
                                this.QualityDataSet.Tables[0].Rows.RemoveAt(this.QualityDataSet.Tables[0].Rows.Count - 1);
                            }
                        }
                        DataRow row = this.QualityDataSet.Tables[0].NewRow();
                        row[1] = "合计：";
                        row["拼音码"] = "%";
                        row[6] = this.QualityDataSet.Tables[0].Compute("sum(金额)", "");
                        this.QualityDataSet.Tables[0].Rows.Add(row);
                    }
                    if (level == 1)
                    {
                        if (QualityDataSet == null || QualityDataSet.Tables.Count <= 0)
                            return;
                        try
                        {
                            if (obj != null) qualityCode = obj as string;
                            DataView dv = new DataView(QualityDataSet.Tables[0]);
                            dv.RowFilter = "药品性质 = " + "'" + qualityCode + "'";
                            this.sheetViewTot.DataSource = dv;
                            if (dv.Table.Rows.Count > 0)
                            {
                                if (dv.Table.Rows[dv.Table.Rows.Count - 1][1].ToString() == "合计：")
                                {
                                    dv.Table.Rows.RemoveAt(dv.Table.Rows.Count - 1);
                                }
                            }

                            DataRow row = dv.Table.NewRow();
                            row[1] = "合计：";
                            row["拼音码"] = "%";
                            row["药品性质"] = qualityCode;
                            row[6] = dv.Table.Compute("sum(金额)", "药品性质 = " + "'" + qualityCode + "'");
                            dv.Table.Rows.Add(row);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Language.Msg("过滤药品性质出错!" + ex.Message));
                            return;
                        }
                    }
                    this.SetQualityFormat();
                    #endregion
                }
                else
                {
                    #region 病区
                    if (level == 0)
                    {
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByMedDept" };
                        this.itemManager.ExecQuery(strIndex, ref ds, this.operVar.Dept.ID, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                        if (ds != null && ds.Tables.Count > 0)
                            this.sheetViewTot.DataSource = ds;
                        else
                            return;

                        DataRow row = ds.Tables[0].NewRow();
                        row[0] = "合计：";
                        row[1] = ds.Tables[0].Compute("sum(取药金额)", "");
                        ds.Tables[0].Rows.Add(row);
                        this.SetMedDeptFormat();
                    }
                    if (level == 1)
                    {
                        string dept = obj as string;
                        DeptDataSet = new DataSet();
                        string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByDept" };
                        this.itemManager.ExecQuery(strIndex, ref DeptDataSet, this.operVar.Dept.ID, dept, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
                        if (DeptDataSet != null && DeptDataSet.Tables.Count > 0)
                            this.sheetViewTot.DataSource = DeptDataSet;

                        DataRow row = this.DeptDataSet.Tables[0].NewRow();
                        row[1] = "合计：";
                        row["拼音码"] = "%";
                        row[7] = this.DeptDataSet.Tables[0].Compute("sum(金额)", "");
                        this.DeptDataSet.Tables[0].Rows.Add(row);
                        this.SetTotFormat();
                    }
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// 按摆药单号查询待摆药明细
        /// </summary>
        /// <param name="drugBill"></param>
        protected void Query(string drugBill)
        {
            this.chkUpdatePrintFlag.Checked = false;
            //对该护理站对应的摆药单进行查询
            string dept = "";
            foreach (Neusoft.FrameWork.Models.NeuObject info in this.deptInfo)
            {
                if (dept == "")
                    dept = info.ID;
                else
                    dept = dept + "','" + info.ID;
            }

            this.NurseDtaSet = new DataSet();
            string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByPatient.BillClass.ByNursePrintBill" };
            this.itemManager.ExecQuery(strIndex, ref NurseDtaSet, drugBill);

            if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
            {
                try
                {
                    for (int i = 0; i < NurseDtaSet.Tables[0].Rows.Count; i++)
                    {
                        if (NurseDtaSet.Tables[0].Rows[i]["申请科室"] != null)
                        {
                            NurseDtaSet.Tables[0].Rows[i]["申请科室"] = deptHelper.GetName(NurseDtaSet.Tables[0].Rows[i]["申请科室"].ToString());
                        }
                    }
                }
                catch { }
            }

            if (NurseDtaSet != null && NurseDtaSet.Tables.Count > 0)
            {
                DataView dv = new DataView(this.NurseDtaSet.Tables[0]);
                if (this.rbSended.Checked == true)
                {
                    dv.RowFilter = string.Format("是否摆药 = '{0}'", "已摆");
                }
                if (this.rbSending.Checked == true)
                {
                    dv.RowFilter = string.Format("是否摆药 = '{0}'", "未摆");
                }
                this.sheetViewTot.DataSource = dv;
            }

            this.SetFormat();
            this.SetFpColor();            
        }

        /// <summary>
        /// 获取未确认的退费申请或医嘱记帐信息
        /// </summary>
        public void QueryNoExamData()
        {
            if (this.treeType == NodeType.Dept) return;
            if (this.nowObj == null) return;
            string inPatientNo = this.nowObj.ToString();
            DataSet ds = new DataSet();
            DataSet dsOutput = new DataSet();
            string[] strIndex = new string[1] { "Pharmacy.Item.GetFeeOrderAffirmInfo.ByPatient" };
            int parm = this.itemManager.ExecQuery(strIndex, ref ds, inPatientNo, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
            if (parm == -1)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                this.SpreadQuitFee_Sheet1.DataSource = ds;
            }
            strIndex = new string[1] { "Pharmacy.Item.GetOutputAffirm.ByPatient" };
            parm = this.itemManager.ExecQuery(strIndex, ref dsOutput, inPatientNo, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString());
            if (parm == -1)
            {
                MessageBox.Show(Language.Msg(this.itemManager.Err));
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                this.SpreadOut_Sheet1.DataSource = dsOutput;
                this.SetOutputFormat();
            }
        }

        /// <summary>
        /// 过滤
        /// </summary>
        public void Filter()
        {
            if (this.treeType == NodeType.Dept)
            {
                if (this.neuTabControl1.SelectedTab == this.tpDept && this.tvDept.SelectedNode == this.tvDept.Nodes[0])
                    return;
                DataView dv;
                if (this.neuTabControl1.SelectedTab == this.tpQuality)
                {
                    dv = new DataView(this.QualityDataSet.Tables[0]);
                }
                else
                {
                    dv = new DataView(this.DeptDataSet.Tables[0]);
                }
                //dv.RowFilter = Function.GetFilterStr(dv, this.txtFilter.Text);
                this.sheetViewTot.DataSource = dv;
                this.SetFormat();
            }
            else
            {
                if (this.NurseDtaSet == null || this.NurseDtaSet.Tables.Count <= 0)
                    return;
                DataView dv;
                if (this.neuTabControl2.SelectedTab == this.tpDruged)
                {
                    dv = new DataView(this.NurseDtaSet.Tables[0]);
                    //dv.RowFilter = Function.GetFilterStr(dv, this.txtFilter.Text);
                    this.sheetViewTot.DataSource = dv;
                    this.SetNurseFormat();
                }
            }


            this.SetFpColor();
        }

        /// <summary>
        /// 返回药房的科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetDept()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al=deptMgr.GetDeptmentByType("P");
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("科室代码",typeof(System.String)));
            dt.Columns.Add(new DataColumn("科室名称",typeof(System.String)));
            dt.Columns.Add(new DataColumn("拼音码",typeof(System.String)));
            dt.Columns.Add(new DataColumn("五笔码",typeof(System.String)));
            dt.Columns.Add(new DataColumn("自定义码",typeof(System.String)));
            dt.PrimaryKey=new DataColumn[]{dt.Columns[0]};

            dt.Rows.Clear();
            foreach (Neusoft.HISFC.Models.Base.Department dept in al)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                dr[0] = dept.ID;
                dr[1] = dept.Name;
                dr[2] = dept.SpellCode;
                dr[3] = dept.WBCode;
                dr[4] = dept.UserCode;
                dr.EndEdit();
                dt.Rows.Add(dr);
            }

            return dt;
            
        }

        /// <summary>
        /// 统计汇总
        /// </summary>
        public void Sum()
        {
            if (this.treeType == NodeType.Patient)	//对护理站查询不进行汇总统计
                return;
            int iIndex = this.sheetViewTot.Rows.Count;
            if (iIndex == 0)
                return;
            int iSumIndex = 0;
            if (this.neuTabControl1.SelectedTab == this.tpDept)
            {
                if (this.tvDept.SelectedNode != null && this.tvDept.Nodes != null && this.tvDept.SelectedNode == this.tvDept.Nodes[0])
                    iSumIndex = 1;
                else
                    iSumIndex = 6;
            }
            else
            {
                iSumIndex = 4;
            }
            try
            {
                this.sheetViewTot.Rows.Add(iIndex, 1);
                this.sheetViewTot.Cells[iIndex, 1].Text = "合计：";
                this.sheetViewTot.Cells[iIndex, iSumIndex].Formula = "SUM(" + (char)(65 + iSumIndex) + "1:" + (char)(65 + iSumIndex) + iIndex.ToString() + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("汇总统计出错!" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsDataAutoExtend = true;//p.ShowPageSetup();
            Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
            page.Height = 1060;
            page.Width = 800;
            page.Left = 100;
            page.Name = "Letter";
            p.SetPageSize(page);
            System.Windows.Forms.Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.White;
            FarPoint.Win.Spread.FpSpread fp = new FarPoint.Win.Spread.FpSpread();
            FarPoint.Win.Spread.SheetView fpView = new FarPoint.Win.Spread.SheetView();
            fp.Sheets.Add(fpView);
            fpView.Columns.Count = this.sheetViewTot.Columns.Count;
            for (int i = 0; i < this.sheetViewTot.Columns.Count; i++)
            {
                fpView.Columns[i].Visible = this.sheetViewTot.Columns[i].Visible;
                fpView.Columns[i].Width = this.sheetViewTot.Columns[i].Width;
                fpView.Columns[i].Label = this.sheetViewTot.Columns[i].Label;
                fpView.Columns[i].BackColor = this.sheetViewTot.Columns[i].BackColor;
            }
            for (int i = 0; i < this.sheetViewTot.Rows.Count; i++)
            {
                fpView.Rows[i].Visible = this.sheetViewTot.Rows[i].Visible;
                fpView.Rows[i].Height = this.sheetViewTot.Rows[i].Height;
                fpView.Rows[i].BackColor = this.sheetViewTot.Rows[i].BackColor;
                for (int j = 0; j < this.sheetViewTot.Columns.Count; j++)
                {
                    fpView.Cells[i, j].Value = this.sheetViewTot.Cells[i, j].Value;
                }
            }
            panel.Controls.Add(fp);
            fp.Dock = System.Windows.Forms.DockStyle.Fill;
            p.PrintPreview(100, 30, panel);
        }

        #region Fp显示设置 对无效记录显示红色

        /// <summary>
        /// 设置Fp显示设置
        /// </summary>
        private void SetFpColor()
        {
            if (this.sheetViewTot.Columns.Count > 16)
            {
                for (int i = 0; i < this.sheetViewTot.Rows.Count; i++)
                {
                    this.sheetViewTot.SetRowLabel(i, 0, " ");
                    if (this.sheetViewTot.Cells[i, 18].Text == "无效")
                    {
                        this.sheetViewTot.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.sheetViewTot.Rows[i].ForeColor = System.Drawing.Color.Black;
                    }
                    //if (this.sheetViewTot.Cells[i, 17].Text != null &&
                    //    this.sheetViewTot.Cells[i, 17].Text != "")
                    //{
                    //    this.sheetViewTot.SetRowLabel(i, 0, "！");
                    //    this.sheetViewTot.RowHeader.Cells[i, 0].BackColor = System.Drawing.Color.White;
                    //}
                }
            }
            if (this.sheetViewDetail.Columns.Count > 15)
            {
                for (int i = 0; i < this.sheetViewDetail.Rows.Count; i++)
                {
                    this.sheetViewDetail.SetRowLabel(i, 0, " ");
                    if (this.sheetViewDetail.Cells[i, 16].Text == "无效")
                    {
                        this.sheetViewDetail.Rows[i].ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.sheetViewDetail.Rows[i].ForeColor = System.Drawing.Color.Black;
                    }

                    if (this.sheetViewDetail.Cells[i, 16].Text != null &&
                        this.sheetViewDetail.Cells[i, 16].Text != "")
                    {
                        this.sheetViewDetail.SetRowLabel(i, 0, "！");
                        this.sheetViewDetail.RowHeader.Cells[i, 0].BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        #endregion

        #region FarPoint格式化

        public void SetFormat()
        {
            if (this.treeType == NodeType.Patient)		//护理站查询用
            {
                this.SetNurseFormat();
                return;
            }
            if (this.treeType == NodeType.Dept)
            {
                if (this.neuTabControl1.SelectedTab == this.tpDept)
                {
                    if (this.tvDept.SelectedNode == this.tvDept.Nodes[0])
                    {
                        this.SetMedDeptFormat();
                    }
                    else
                    {
                        this.SetTotFormat();
                    }
                }
                else
                {
                    this.SetQualityFormat();
                }
            }
        }
        /// <summary>
        /// 格式化
        /// </summary>
        private void SetNurseFormat()
        {

            try
            {
                bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
                if (isNursePrint)
                {
                    if (this.neuTabControl1.SelectedIndex == 0)
                    {
                        this.sheetViewTot.DefaultStyle.Locked = false;
                        this.sheetViewTot.GrayAreaBackColor = System.Drawing.Color.Honeydew;
                        this.sheetViewTot.SelectionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(225)), ((System.Byte)(243)));

                        #region 新增列
                        FarPoint.Win.Spread.CellType.TextCellType textType = new FarPoint.Win.Spread.CellType.TextCellType();
                        FarPoint.Win.Spread.CellType.CheckBoxCellType chkType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        this.sheetViewTot.Columns[2].CellType = chkType;
                        this.sheetViewTot.Columns.Get(2).Width = 20F;
                        this.sheetViewTot.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.sheetViewTot.Columns[3].CellType = textType;
                        this.sheetViewTot.Columns.Get(3).Width = 60F;
                        this.sheetViewTot.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.chkSelectAll.Checked = false;

                        #endregion

                        this.sheetViewTot.Columns.Get(0).Width = 30F;
                        this.sheetViewTot.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;

                        this.sheetViewTot.Columns.Get(1).Width = 50F;
                        this.sheetViewTot.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;

                        this.sheetViewTot.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(4).Width = 160F;
                        this.sheetViewTot.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(5).Width = 100F;
                        this.sheetViewTot.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(6).Width = 0F;		//每次量
                        this.sheetViewTot.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(7).Width = 0F;		//单位
                        this.sheetViewTot.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(8).Width = 45F;		//频次
                        this.sheetViewTot.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(9).Width = 60F;		//用法
                        this.sheetViewTot.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(10).Width = 40F;
                        this.sheetViewTot.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(11).Width = 40F;
                        this.sheetViewTot.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(12).Width = 80F;

                        this.sheetViewTot.Columns.Get(13).Width = 100F;
                        this.sheetViewTot.Columns.Get(14).Width = 80F;
                        this.sheetViewTot.Columns.Get(15).Width = 70F;
                        this.sheetViewTot.Columns.Get(16).Width = 120F;
                        this.sheetViewTot.Columns.Get(17).Width = 60F;
                        try
                        {
                            this.sheetViewTot.Columns.Get(18).Width = 80F;
                        }
                        catch { }
                    }
                    else
                    {
                        this.sheetViewTot.DefaultStyle.Locked = true;
                        this.sheetViewTot.GrayAreaBackColor = System.Drawing.Color.Honeydew;
                        this.sheetViewTot.SelectionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(225)), ((System.Byte)(243)));

                        this.sheetViewTot.Columns.Get(0).Width = 30F;
                        this.sheetViewTot.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.sheetViewTot.Columns.Get(1).Width = 50F;
                        this.sheetViewTot.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                        this.sheetViewTot.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        this.sheetViewTot.Columns.Get(2).Width = 160F;
                        this.sheetViewTot.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(3).Width = 100F;
                        this.sheetViewTot.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(4).Width = 0F;		//每次量
                        this.sheetViewTot.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(5).Width = 0F;		//单位
                        this.sheetViewTot.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(6).Width = 45F;		//频次
                        this.sheetViewTot.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        this.sheetViewTot.Columns.Get(7).Width = 60F;		//用法
                        this.sheetViewTot.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(8).Width = 40F;
                        this.sheetViewTot.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(9).Width = 40F;
                        this.sheetViewTot.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        this.sheetViewTot.Columns.Get(10).Width = 80F;

                        this.sheetViewTot.Columns.Get(11).Width = 100F;
                        this.sheetViewTot.Columns.Get(12).Width = 80F;
                        this.sheetViewTot.Columns.Get(13).Width = 70F;
                        this.sheetViewTot.Columns.Get(14).Width = 120F;
                        this.sheetViewTot.Columns.Get(15).Width = 60F;
                        try
                        {
                            this.sheetViewTot.Columns.Get(16).Width = 80F;
                        }
                        catch { }
                    }
                }
                else
                {
                    this.sheetViewTot.DefaultStyle.Locked = true;
                    this.sheetViewTot.GrayAreaBackColor = System.Drawing.Color.Honeydew;
                    this.sheetViewTot.SelectionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(225)), ((System.Byte)(243)));

                    this.sheetViewTot.Columns.Get(0).Width = 0F;
                    this.sheetViewTot.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.sheetViewTot.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    this.sheetViewTot.Columns.Get(1).Width = 50F;
                    this.sheetViewTot.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    this.sheetViewTot.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    this.sheetViewTot.Columns.Get(2).Width = 160F;
                    this.sheetViewTot.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.sheetViewTot.Columns.Get(3).Width = 100F;
                    this.sheetViewTot.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    this.sheetViewTot.Columns.Get(4).Width = 0F;		//每次量
                    this.sheetViewTot.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    this.sheetViewTot.Columns.Get(5).Width = 0F;		//单位
                    this.sheetViewTot.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.sheetViewTot.Columns.Get(6).Width = 45F;		//频次
                    this.sheetViewTot.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    this.sheetViewTot.Columns.Get(7).Width = 60F;		//用法
                    this.sheetViewTot.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.sheetViewTot.Columns.Get(8).Width = 40F;
                    this.sheetViewTot.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.sheetViewTot.Columns.Get(9).Width = 40F;
                    this.sheetViewTot.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.sheetViewTot.Columns.Get(10).Width = 80F;

                    this.sheetViewTot.Columns.Get(11).Width = 100F;
                    this.sheetViewTot.Columns.Get(12).Width = 80F;
                    this.sheetViewTot.Columns.Get(13).Width = 70F;
                    this.sheetViewTot.Columns.Get(14).Width = 120F;
                    this.sheetViewTot.Columns.Get(15).Width = 60F;
                    try
                    {
                        this.sheetViewTot.Columns.Get(16).Width = 80F;
                    }
                    catch { }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void SetTotFormat()
        {
            this.sheetViewTot.DefaultStyle.Locked = true;
            this.sheetViewTot.Columns.Get(0).Width = 0F;		//药品编码
            this.sheetViewTot.Columns.Get(1).Width = 80F;			//摆药状态
            this.sheetViewTot.Columns.Get(2).Width = 160F;			//名称
            this.sheetViewTot.Columns.Get(3).Width = 100F;			//规格
            this.sheetViewTot.Columns.Get(4).Width = 75F;			//零售价
            this.sheetViewTot.Columns.Get(5).Width = 75F;			//总量
            this.sheetViewTot.Columns.Get(6).Width = 50F;			//单位
            this.sheetViewTot.Columns.Get(7).Width = 80F;			//金额            
            this.sheetViewTot.Columns.Get(8).Width = 0F;			//拼音码
            this.sheetViewTot.Columns.Get(9).Width = 0F;			//五笔码
            this.sheetViewTot.Columns.Get(10).Width = 0F;			//自定义码
        }
        private void SetDetailFormat()
        {
            this.sheetViewDetail.DefaultStyle.Locked = true;
            this.sheetViewDetail.Columns.Get(0).Width = 40F;		//床号
            this.sheetViewDetail.Columns.Get(1).Width = 80F;		//姓名
            this.sheetViewDetail.Columns.Get(2).Width = 160F;		//药品名称
            this.sheetViewDetail.Columns.Get(3).Width = 85F;		//规格
            this.sheetViewDetail.Columns.Get(4).Width = 75F;		//零售价
            this.sheetViewDetail.Columns.Get(5).Width = 75F;		//每次量
            this.sheetViewDetail.Columns.Get(6).Width = 50F;		//单位
            this.sheetViewDetail.Columns.Get(7).Width = 50F;		//频次
            this.sheetViewDetail.Columns.Get(8).Width = 50F;		//用法
            this.sheetViewDetail.Columns.Get(9).Width = 75F;		//总量
            this.sheetViewDetail.Columns.Get(10).Width = 50F;		//单位  
            this.sheetViewDetail.Columns.Get(11).Width = 90F;		//摆药单
            this.sheetViewDetail.Columns.Get(12).Width = 80F;		//发药人
            this.sheetViewDetail.Columns.Get(13).Width = 100F;		//发药时间
        }

        private void SetAffirmFormat()
        {
            this.SpreadQuitFee_Sheet1.DefaultStyle.Locked = true;
        }
        private void SetOutputFormat()
        {
            this.SpreadOut_Sheet1.DefaultStyle.Locked = true;
            this.SpreadOut_Sheet1.Columns[0].Width = 70F;	//姓名
            this.SpreadOut_Sheet1.Columns[1].Width = 70F;	//处方号
            this.SpreadOut_Sheet1.Columns[2].Width = 150F;	//药品名称
            this.SpreadOut_Sheet1.Columns[3].Width = 80F;
            this.SpreadOut_Sheet1.Columns[4].Width = 55F;	//数量
            this.SpreadOut_Sheet1.Columns[5].Width = 100F;	//取药药房
            this.SpreadOut_Sheet1.Columns[6].Width = 80F;
            this.SpreadOut_Sheet1.Columns[7].Width = 70F;
            this.SpreadOut_Sheet1.Columns[8].Width = 80F;
        }
        private void SetMedDeptFormat()
        {
            this.sheetViewTot.DefaultStyle.Locked = true;
            this.sheetViewTot.Columns[0].Visible = true;
            this.sheetViewTot.Columns[0].Width = 150F;
            this.sheetViewTot.Columns[1].Width = 100F;
            this.sheetViewTot.Columns[2].Width = 100F;
        }
        private void SetQualityFormat()
        {
            this.sheetViewTot.DefaultStyle.Locked = true;
            this.sheetViewTot.Columns[0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.sheetViewTot.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.sheetViewTot.Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

            this.sheetViewTot.Columns[0].Visible = false;

            this.sheetViewTot.Columns[1].Visible = true;
            this.sheetViewTot.Columns[1].Width = 120F;          //类别
            this.sheetViewTot.Columns[2].Width = 140F;          //药品名称
            this.sheetViewTot.Columns[3].Width = 80F;           //规格
            this.sheetViewTot.Columns[4].Width = 80F;           //摆药量
            this.sheetViewTot.Columns[5].Width = 60F;           //单位
            this.sheetViewTot.Columns[6].Width = 80F;           //金额

            this.sheetViewTot.Columns[7].Visible = false;       //药品性质
            this.sheetViewTot.Columns[7].Width = 60F;
            this.sheetViewTot.Columns[8].Width = 0F;
            this.sheetViewTot.Columns[9].Width = 0F;
            this.sheetViewTot.Columns[10].Width = 0F;
        }

        #endregion

        #region 新领药单打印接口

        /// <summary>
        /// 领药单打印接口实例化
        /// </summary>
        private void SetInterface()
        {
            //object[] o = new object[] { };
            //try
            //{
            //    //门诊标签打印接口实现类
            //    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //    string billValue = ctrlIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Inpatient_Print_Fun, true, "Report.DrugStore.InpatientBillPrint");

            //    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
            //    object oLabel = objHandel.Unwrap();

            //    Function.IDrugPrint = oLabel as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;
            //    if (Function.IDrugPrint == null)
            //    {
            //        MessageBox.Show("摆药单控件实现错误 需实现基类IDrugPrint接口");
            //        return;
            //    }
                
            //}
            //catch (System.TypeLoadException ex)
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //    MessageBox.Show(Language.Msg("摆药单命名空间无效\n" + ex.Message));
            //    return;
            //}
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="deptCodes"></param>
        /// <param name="storageDeptCode"></param>
        /// <returns></returns>
        private ArrayList QueryData(string deptCodes, string storageDeptCode)
        {
            ArrayList alTemp = new ArrayList();
            //查询住院药品出库申请信息<方法未重载>            
            alTemp = this.itemManager.QueryApplyOutList(this.nowObj.ToString(), deptCodes, storageDeptCode, "0");
            return alTemp;
        }

        /// <summary>
        /// 打印摆药单
        /// </summary>
        private void PrintDrugBill()
        {
            //查询数据
            //对该护理站对应的科室进行查询
            //string depts = "";
            //foreach (Neusoft.FrameWork.Models.NeuObject info in this.deptInfo)
            //{
            //    if (depts == "")
            //        depts = info.ID;
            //    else
            //        depts = depts + "','" + info.ID;
            //}

            //hsSelected
            if (this.isBusy)
            {
                MessageBox.Show("正在保存，不能重复操作，请稍后...");
                return;
            }
            this.isBusy = true;
            this.hsSelected = new Hashtable();
            for (int j = 0; j < this.sheetViewTot.RowCount; j++)
            {
                if (this.sheetViewTot.Cells[j, 2].Text == "True")
                {
                    this.hsSelected.Add(this.sheetViewTot.Cells[j, 3].Text, null);
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存发送申请，请稍后...");

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //按住院药房循环生成和打印每个药房的摆药单（摆药单号不同）
            ArrayList alTemp = this.departmentManager.GetConstantList("PHARMACYTYPE");
            for (int i = 0; i < alTemp.Count; i++)
            {
                Application.DoEvents();
                Neusoft.FrameWork.Models.NeuObject phaDept = alTemp[i] as Neusoft.FrameWork.Models.NeuObject;
                if (phaDept.Memo != "住院")
                {
                    continue;
                }

                ArrayList alAll = new ArrayList();
                if (this.ShowByNurseCell1)
                {
                    alAll = this.QueryData(this.deptTemp, phaDept.ID);
                }
                else
                {
                    alAll = this.QueryData(this.operVar.Dept.ID, phaDept.ID);
                }
                
                ArrayList al = new ArrayList();

                //获取界面选择数据
                for (int k = 0; k < alAll.Count; k++)
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut appoutObj = alAll[k] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    if (this.hsSelected.ContainsKey(appoutObj.ID))
                    {
                        al.Add(appoutObj);
                    }
                }

                if (al == null || al.Count == 0)
                {
                    continue;
                }
                Neusoft.HISFC.Models.Pharmacy.DrugBillClass dbc = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
                dbc.ApplyDept.ID = this.operVar.Nurse.ID;
                dbc.ApplyDept.Name = this.operVar.Nurse.Name;
                dbc.ApplyDept.User01 = "护士打印";
                dbc.ApplyState = "0";
                dbc.DrugBillNO = "";

                //生成摆药单号并写入出库申请表
                string tempDrugBill = this.itemManager.GetNewDrugBillNO();
                if (tempDrugBill == null || tempDrugBill == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("获取领药单号失败!请重新保存.", "提示", MessageBoxButtons.OK);
                    this.isBusy = false;
                    return;
                }
                for (int a = 0; a < al.Count; a++)
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut appTemp = al[a] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    if (this.itemManager.UpdateApplyDrugBillByNumber(tempDrugBill, appTemp.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("生成领药单号失败!", "提示", MessageBoxButtons.OK);
                        this.isBusy = false;
                        return;
                    }
                }

                //草药、退药、毒麻、输液直接更新发药状态=5，不需要药房再次进行打印
                if (this.itemManager.UpdateApplyDrugBill(phaDept.ID, tempDrugBill) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("更新发药状态失败!", "提示", MessageBoxButtons.OK);
                    this.isBusy = false;
                    return;
                }
                #region 更新摆药申请档IamRabbit by Sunjh 2010-7-20 {2ACDE2D8-C7A2-4ad4-919F-EFAA6EC58A03}
                Neusoft.HISFC.Models.Pharmacy.ApplyOut appOutTemp = al[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                drugMessage.ApplyDept = appOutTemp.ApplyDept;    //科室或者病区
                drugMessage.DrugBillClass.ID = this.nowObj.ToString();        //摆药单分类
                drugMessage.DrugBillClass.Name = this.billClassName;        //摆药单分类
                drugMessage.SendType = appOutTemp.SendType;     //发送类型0全部,1-集中,2-临时
                drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
                drugMessage.StockDept = phaDept;   //发药科室
                if (this.drugStoreManager.SetDrugMessage(drugMessage) != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("更新摆药档状态失败!", "提示", MessageBoxButtons.OK);
                    this.isBusy = false;
                    return;
                }
                #endregion

                dbc.ID = this.nowObj.ToString(); ;
                dbc.Name = this.billClassName;

                //根据生成的摆药单号打印领药单
                dbc.DrugBillNO = tempDrugBill;

                //护士站直接打印摆药单（待设计同时打印汇总单和明细单）
                //Function.IDrugPrint.AddAllData(al, dbc);
                //Function.IDrugPrint.Print();

                #region 屏蔽自定义摆药单类型打印

                //根据摆药单打印设置进行多种形式打印
                //Neusoft.FrameWork.Models.NeuObject printObj = new Neusoft.FrameWork.Models.NeuObject();
                //printObj.ID = phaDept.ID;
                //printObj.User01 = this.nowObj.ToString();
                ////ArrayList alPrintSet = drugStoreManager.QueryPrintSetting(printObj);
                //ArrayList alPrintSet = new ArrayList();
                //if (alPrintSet != null && alPrintSet.Count > 0)
                //{
                //    for (int j = 0; j < alPrintSet.Count; j++)
                //    {
                //        Neusoft.HISFC.Models.Pharmacy.DrugBillClass tempBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
                //        tempBillClass = dbc;
                //        Neusoft.FrameWork.Models.NeuObject tempPrintObj = alPrintSet[j] as Neusoft.FrameWork.Models.NeuObject;
                //        tempBillClass.PrintType.ID = tempPrintObj.User03;
                //        Function.IDrugPrint.AddAllData(al, dbc);
                //        Function.IDrugPrint.Print();
                //        //Function.IDrugPrint.Preview();
                //    }
                //}
                //else
                //{
                //    Function.IDrugPrint.AddAllData(al, dbc);
                //    Function.IDrugPrint.Print();
                //    //Function.IDrugPrint.Preview();
                //}

                #endregion

            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            MessageBox.Show("保存并发送到药房成功!");
            this.isBusy = false;

            //调用打印接口
            //Function.IDrugPrint.AddAllData(al, dbc);
            //Function.IDrugPrint.Preview();
        }

        /// <summary>
        /// 重新打印摆药单
        /// </summary>
        private void RePrintDrugBill()
        {
            if (this.tvBill.SelectedNode == null)
            {
                MessageBox.Show("没有选择摆药单进行打印!");
                return;
            }
            ArrayList al = this.itemManager.QueryApplyOutListByNurseBill(this.tvBill.SelectedNode.Text);
            if (al == null || al.Count == 0)
            {
                MessageBox.Show("没有可以打印的数据!");
                return;
            }

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyoutObj = al[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;                       

            Neusoft.HISFC.Models.Pharmacy.DrugBillClass dbc = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
            dbc.ApplyDept.ID = this.operVar.Nurse.ID;
            dbc.ApplyDept.Name = this.operVar.Nurse.Name;
            dbc.ApplyDept.User01 = "护士补打";
            dbc.ApplyState = "0";
            dbc.DrugBillNO = this.tvBill.SelectedNode.Text;
            //根据摆药单打印设置进行多种形式打印
            Neusoft.FrameWork.Models.NeuObject printObj = new Neusoft.FrameWork.Models.NeuObject();
            printObj.ID = applyoutObj.StockDept.ID;
            Neusoft.HISFC.Models.Pharmacy.DrugBillClass dbcObj = this.drugStoreManager.GetDrugBillClass(applyoutObj.BillClassNO);
            printObj.User01 = dbcObj.ID;//this.nowObj.ToString();
            dbc.ID = applyoutObj.BillClassNO;
            //ArrayList alPrintSet = drugStoreManager.QueryPrintSetting(printObj);
            ArrayList alPrintSet = new ArrayList();
            if (alPrintSet != null && alPrintSet.Count > 0)
            {
                for (int j = 0; j < alPrintSet.Count; j++)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugBillClass tempBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
                    tempBillClass = dbc;
                    Neusoft.FrameWork.Models.NeuObject tempPrintObj = alPrintSet[j] as Neusoft.FrameWork.Models.NeuObject;
                    tempBillClass.PrintType.ID = tempPrintObj.User03;                 
                    Function.IDrugPrint.AddAllData(al, dbc);
                    Function.IDrugPrint.Print();
                    //Function.IDrugPrint.Preview();
                }
            }
            else
            {
                Function.IDrugPrint.AddAllData(al, dbc);
                Function.IDrugPrint.Print();
                //Function.IDrugPrint.Preview();
            }

            #region 如果护士站先打印了，药房就不需要打印了 by Sunjh {C0985F9D-F26F-49be-803E-783FD0451FC3}

            if (this.chkUpdatePrintFlag.Checked)
            {
                //直接更新发药状态=5，不需要药房再次进行打印
                if (this.itemManager.UpdateApplyDrugBill(applyoutObj.StockDept.ID, this.tvBill.SelectedNode.Text) == -1)
                {
                    MessageBox.Show("更新发药状态失败!", "提示", MessageBoxButtons.OK);
                    return;
                }
                #region 更新摆药申请档IamRabbit by Sunjh 2010-7-20 {2ACDE2D8-C7A2-4ad4-919F-EFAA6EC58A03}
                Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage = new Neusoft.HISFC.Models.Pharmacy.DrugMessage();
                drugMessage.ApplyDept = applyoutObj.ApplyDept;    //科室或者病区
                drugMessage.DrugBillClass.ID = applyoutObj.BillClassNO;        //摆药单分类
                drugMessage.DrugBillClass.Name = dbcObj.Name; // applyoutObj.BillClassNO;        //摆药单分类
                drugMessage.SendType = applyoutObj.SendType;     //发送类型0全部,1-集中,2-临时
                drugMessage.SendFlag = 0;                     //状态0-通知,1-已摆
                drugMessage.StockDept = applyoutObj.StockDept;   //发药科室
                if (this.drugStoreManager.SetDrugMessage(drugMessage) != 1)
                {
                    MessageBox.Show("更新摆药档状态失败!", "提示", MessageBoxButtons.OK);
                    return;
                }
                #endregion
            }
            

            #endregion 
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelectAll.Checked)
            {
                for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                {
                    this.sheetViewTot.Cells[i, 2].Text = "True";
                    this.sheetViewTot.Rows[i].BackColor = Color.GreenYellow;
                }
            }
            else
            {
                for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                {
                    this.sheetViewTot.Cells[i, 2].Text = "False";
                    this.sheetViewTot.Rows[i].BackColor = Color.White;
                }
            }
        }

        #endregion

        #endregion

        #region 事件

        private void ucSendDrugQuery_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() != "devenv")
            {
                this.Init();

                this.ShowData();
            }
            /// 是否提示消息 更新程序变更流程 {55B34E3A-7741-4420-A947-29DE881A0119} wbo 2010-12-28
            if (this.isShowMessage)
            {
                MessageBox.Show("已经发送到药房的药品如果需要取消，在本科取消即可：\r\n1、药品集中发送 菜单下面，药品集中发送取消\r\n2、请不要频繁发送、取消，以免影响药房发药", "友情提示");
            }
        }

        private void rbSend_CheckedChanged(object sender, EventArgs e)
        {
            this.Query();
        }

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == null)          //根节点
                {
                    if (this.SpreadDrug.Sheets[0].Rows.Count > 0) {
                        this.SpreadDrug.Sheets[0].Rows.Count = 0;
                    }
                    return;//此处屏蔽掉modified by xizf {F3BB8B98-09BD-4bef-9720-B40AD4892F4B}
                    this.nowObj = null;
                    this.showLevel = 0;
                }
                else
                {
                    if (this.treeType == NodeType.Dept && this.neuTabControl1.SelectedTab == this.tpQuality)
                    {
                        this.nowObj = (e.Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
                    }                        
                    else
                    {
                        this.nowObj = e.Node.Tag;
                        this.billClassName = e.Node.Text;
                    }
                        
                    this.showLevel = 1;
                }
                this.Query(this.nowObj, this.showLevel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("查询统计执行出错" + ex.Message));
                return;
            }
        }

        private void nlbFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ucQueryInpatientNo1_myEvent_1()
        {
            try
            {
                this.isQueryByCaseNO = true;
                this.InPatientNo = this.ucQueryInpatientNo1.InpatientNo;
                this.Query(this.InPatientNo, 2);
                this.nowObj = this.InPatientNo;
                this.showLevel = 1;
                this.QueryNoExamData();
                this.ucQueryInpatientNo1.Text = this.InPatientNo.Substring(4);
                this.isQueryByCaseNO = false;
            }
            catch
            {
                MessageBox.Show(Language.Msg("通过住院号进行取药/确认信息查询出错!"));
                return;
            }
        }

        private void SpreadDrug_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.treeType == NodeType.Dept)//只有树型列表显示为病区时才有效
            {              
                //显示明细信息时 不对双击进行处理
                if (this.SpreadDrug.ActiveSheet == this.sheetViewDetail)
                    return;

                string drugCode = this.sheetViewTot.Cells[e.Row, 0].Text;
                string class3Meaning = this.sheetViewTot.Cells[e.Row, 1].Text;

                DataSet ds = new DataSet();
                if (this.neuTabControl1.SelectedTab == this.tpQuality)		//在药品性质Tab页
                {
                    #region 药品性质Tab页显示明细

                    string[] strIndex = new string[1] { "Pharmacy.Item.GetAppplyOutTot.ByQuality.Drug" };
                    this.itemManager.ExecQuery(strIndex, ref ds, this.operVar.Dept.ID, drugCode, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(),class3Meaning);
                    if (ds != null && ds.Tables.Count > 0)
                        this.sheetViewDetail.DataSource = ds;
                    if (!this.SpreadDrug.Sheets.Contains(this.sheetViewDetail))
                        this.SpreadDrug.Sheets.Add(this.sheetViewDetail);
                    this.SpreadDrug.ActiveSheet = this.sheetViewDetail;

                    #region 格式化
                    try
                    {
                        this.sheetViewDetail.DefaultStyle.Locked = true;
                        this.sheetViewDetail.Columns[0].Width = 100F;       //类别
                        this.sheetViewDetail.Columns[1].Width = 100F;       //取药病区
                        this.sheetViewDetail.Columns[2].Width = 160F;		//药品名称
                        this.sheetViewDetail.Columns[3].Width = 80F;		//规格
                        this.sheetViewDetail.Columns[4].Width = 80F;		//摆药量
                        this.sheetViewDetail.Columns[5].Width = 50F;		//单位
                    }
                    catch { }
                    #endregion

                    #endregion
                }
                else															//在取药病区Tab页
                {

                    #region 取药病区Tab页显示明细

                    if (this.tvDept.SelectedNode != null && this.tvDept.Nodes != null && this.tvDept.SelectedNode == this.tvDept.Nodes[0])
                        return;                    

                    string[] strIndex = new string[1] { "Pharmacy.Item.GetApplyOutTot.ByMedDept.Drug" };

                    if (this.nowObj != null)
                    {
                        this.itemManager.ExecQuery(strIndex, ref ds, this.operVar.Dept.ID, this.nowObj as string,drugCode, this.dtpBegin.Value.ToString(), this.dtpEnd.Value.ToString(),class3Meaning);
                    }

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        this.sheetViewDetail.DataSource = ds;
                    }
                    if (!this.SpreadDrug.Sheets.Contains(this.sheetViewDetail))
                        this.SpreadDrug.Sheets.Add(this.sheetViewDetail);
                    this.SpreadDrug.ActiveSheet = this.sheetViewDetail;
                    this.SetDetailFormat();

                    #endregion
                }

                this.SetFpColor();
            }
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chkComb.Enabled = true;
            this.chkIsByPatient.Enabled = true;
            this.chkSelectAll.Enabled = true;
            this.chkUpdatePrintFlag.Enabled = false;

            if (this.neuTabControl1.SelectedIndex == 1)
            {
                this.sheetViewTot.RowCount = 0;
            }

            if (this.neuTabControl1.SelectedTab == this.tpBill)
            {
                this.chkComb.Enabled = false;
                this.chkIsByPatient.Enabled = false;
                this.chkSelectAll.Enabled = false;
                this.chkUpdatePrintFlag.Enabled = true;
                this.tvBill.Nodes.Clear();

                ArrayList alBill = new ArrayList();
                if (this.ShowByNurseCell1)
                {
                    //对该护理站对应的摆药单进行查询
                    string dept = "";
                    ArrayList alNurse = this.departmentManager.QueryNurseStationByDept(this.operVar.Dept, "01");
                    foreach (Neusoft.FrameWork.Models.NeuObject infoTemp in alNurse)
                    {
                        ArrayList deptCell = this.departmentManager.QueryDepartment(infoTemp.ID);
                        foreach (Neusoft.FrameWork.Models.NeuObject info in deptCell)
                        {
                            if (dept == "")
                            {
                                dept = info.ID;
                            }
                            else
                            {
                                dept = dept + "','" + info.ID;
                            }                                
                        }                        
                    }
                    alBill = this.itemManager.QueryNursePrintBill(dept);
                }
                else
                {
                    alBill = this.itemManager.QueryNursePrintBill(this.operVar.Dept.ID);
                }
                
                for (int i = 0; i < alBill.Count; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject nodeObj = alBill[i] as Neusoft.FrameWork.Models.NeuObject;
                    this.tvBill.Nodes.Add(nodeObj.ID);
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpQuality)
            {
                if (this.tvDrugType1.Nodes.Count > 0)
                {
                    this.tvDrugType1.SelectedNode = this.tvDrugType1.Nodes[0];
                    //屏蔽对已摆、未摆的显示 该显示不再使用
                    //this.IsShowCheck = true;
                }
            }
            else
            {
                if (this.tvDept.Nodes.Count > 0)
                {
                    this.tvDept.SelectedNode = this.tvDept.Nodes[0];
                    this.IsShowCheck = false;
                }
            }
        }

        private void tvBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Query(e.Node.Text);
        }

        private void neuTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl2.SelectedTab == this.tpQuitFee || this.neuTabControl2.SelectedTab == this.tpOutBill)
            {
                this.QueryNoExamData();
            }
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }
        //打印
        //protected override void OnPrint(PaintEventArgs e)
        //{
        //    Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
        //    print.PrintPage(0,0,this.neuTabControl2.SelectedTab);
        //    base.OnPrint(e);
        //}
        //打印按钮
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPreview(0,0,this.neuTabControl2.SelectedTab);
            return base.OnPrintPreview(sender, neuObject);
        }

        #endregion

        private void SpreadDrug_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (this.chkIsByPatient.Checked)
            {
                if (this.sheetViewTot.Cells[e.Row, 2].Text == "True")
                {
                    for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                    {
                        if (this.sheetViewTot.Cells[i, 0].Text == this.sheetViewTot.Cells[e.Row, 0].Text)
                        {
                            this.sheetViewTot.Cells[i, 2].Text = "True";
                            this.sheetViewTot.Rows[i].BackColor = Color.GreenYellow;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                    {
                        if (this.sheetViewTot.Cells[i, 0].Text == this.sheetViewTot.Cells[e.Row, 0].Text)
                        {
                            this.sheetViewTot.Cells[i, 2].Text = "False";
                            this.sheetViewTot.Rows[i].BackColor = Color.White;
                        }
                    }
                }
            }
            else if (this.chkComb.Checked)
            {
                if (this.sheetViewTot.Cells[e.Row, 2].Text == "True")
                {
                    for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                    {
                        if (this.sheetViewTot.Cells[i, 24].Text == this.sheetViewTot.Cells[e.Row, 24].Text)
                        {
                            this.sheetViewTot.Cells[i, 2].Text = "True";
                            this.sheetViewTot.Rows[i].BackColor = Color.GreenYellow;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.sheetViewTot.RowCount; i++)
                    {
                        if (this.sheetViewTot.Cells[i, 24].Text == this.sheetViewTot.Cells[e.Row, 24].Text)
                        {
                            this.sheetViewTot.Cells[i, 2].Text = "False";
                            this.sheetViewTot.Rows[i].BackColor = Color.White;
                        }
                    }
                }
            }
            else
            {
                if (this.sheetViewTot.Cells[e.Row, 2].Text == "True")
                {
                    this.sheetViewTot.Rows[e.Row].BackColor = Color.GreenYellow;
                }
                else
                {
                    this.sheetViewTot.Rows[e.Row].BackColor = Color.White;
                }
            }
        }

        private void chkIsByPatient_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsByPatient.Checked)
            {
                this.chkComb.Checked = false;
            }
        }

        private void chkComb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkComb.Checked)
            {
                this.chkIsByPatient.Checked = false;
            }
        }

    }
}
