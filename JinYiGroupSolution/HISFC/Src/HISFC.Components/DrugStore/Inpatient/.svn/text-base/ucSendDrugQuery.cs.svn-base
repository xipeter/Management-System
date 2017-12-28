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
    public partial class ucSendDrugQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSendDrugQuery()
        {
            InitializeComponent();
 

            //默认不显示退费信息/处方单信息
            this.IsShowQuitBill = false;
            this.IsShowOutBill = false;
        }

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

        /// <summary>
        /// 当前选择查询的层数
        /// </summary>
        private int showLevel = 0;

        #endregion

        #region 属性

        /// <summary>
        /// 树节点类型 0 护理站 Patient 显示患者 1 病区 Dept 取药病区
        /// </summary>
        [Description("左侧树节点加载数据类型"), Category("设置"), DefaultValue(ucSendDrugQuery.NodeType.Patient)]
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
        [Description("取药部门类型 科室或护理站"), Category("设置"), DefaultValue(ucSendDrugQuery.ReciveDrugType.Dept)]
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
        [Description("是否显示处方单查询Tab"), Category("设置"), DefaultValue(false),Browsable(false)]
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
        [Description("是否显示退费单查询Tab"), Category("设置"), DefaultValue(false),Browsable(false)]
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
        [Description("是否显示已摆/未摆过滤选择框"), Category("设置"), DefaultValue(true),Browsable(false)]
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
            this.Print();

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
            this.dtpEnd.Value = this.itemManager.GetDateTimeFromSysDateTime().Date.AddDays(1).AddSeconds(-1);
            this.dtpBegin.Value = this.dtpEnd.Value.Date;

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
                //this.deptInfo = new ArrayList();
//{723DB273-E312-4bc6-9879-C7B311D157D9}
                //Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();
                //info.ID = this.operVar.Nurse.ID;
                //info.Name = this.operVar.Nurse.Name;
                //this.deptInfo.Add(info);
                //{46CCD091-05AB-4964-8C09-5CB4E3A129D8}
                //this.deptInfo = departmentManager.QueryDepartment(this.operVar.Nurse.ID);
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
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.FpInit();

            this.OperInit();

            this.DataInit();

            this.tvDept.ImageList = this.tvDept.deptImageList;

            this.ucQueryInpatientNo1.InputType = 0;			//输入类型 住院号
            this.InitHashTable();
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

            ArrayList al = new ArrayList();
            //{723DB273-E312-4bc6-9879-C7B311D157D9}
            //al = radtManager.QueryPatient(this.operVar.Dept.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
            //al = radtManager.QueryPatientByNurseCellAndState (this.operVar.Dept.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
            //{46CCD091-05AB-4964-8C09-5CB4E3A129D8}
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

            //neusoft.HISFC.Object.RADT.Location loc = new neusoft.HISFC.Object.RADT.Location();
            //loc.NurseCell = this.operVar.User.Nurse.Clone();
            //loc.Dept = this.operVar.User.Dept.Clone();
            //neusoft.HISFC.Object.RADT.VisitStatus state = new neusoft.HISFC.Object.RADT.VisitStatus();
            //state.ID = neusoft.HISFC.Object.RADT.VisitStatus.enuVisitStatus.I;
            //al = inPatient.PatientQuery(loc, state);                       
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
        /// 获取未确认的退费申请或医嘱记帐信息
        /// </summary>
        public void QueryNoExamData()
        {
            //屏蔽对退费申请的查询功能 {42E9350D-EDFD-43fa-9DF8-0AEEECDBB9EA}
            return;

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
                dv.RowFilter = "(拼音码 LIKE '" + this.txtFilter.Text + "%') OR " +
                    "(五笔码 LIKE '" + this.txtFilter.Text + "%') OR " +
                    "(自定义码 LIKE '" + this.txtFilter.Text + "%') OR " +
                    "(药品名称 LIKE '" + this.txtFilter.Text + "%') ";
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
                    dv.RowFilter = "(拼音码 LIKE '" + this.txtFilter.Text + "%') OR " +
                        "(五笔码 LIKE '" + this.txtFilter.Text + "%') OR (药品名称 LIKE '" + this.txtFilter.Text + "%')";
                    this.sheetViewTot.DataSource = dv;
                    this.SetNurseFormat();
                }
            }


            this.SetFpColor();
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

        #endregion

        private void ucSendDrugQuery_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() != "devenv")
            {

                this.IsShowCheck = false;

                this.Init();

                this.ShowData();
                this.neuTabControl1.TabPages.Remove(this.tpQuality);
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
                    this.nowObj = null;
                    this.showLevel = 0;
                }
                else
                {
                    if (this.treeType == NodeType.Dept && this.neuTabControl1.SelectedTab == this.tpQuality)
                        this.nowObj = (e.Node.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
                    else
                        this.nowObj = e.Node.Tag;
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
                this.InPatientNo = this.ucQueryInpatientNo1.InpatientNo;
                this.Query(this.InPatientNo, 2);
                this.nowObj = this.InPatientNo;
                this.showLevel = 1;
                this.QueryNoExamData();
                this.ucQueryInpatientNo1.Text = this.InPatientNo.Substring(4);
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
                {
                    return;
                }

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

                    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        return;
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
            if (this.neuTabControl1.SelectedTab == this.tpQuality)
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
 
       
    }
}
