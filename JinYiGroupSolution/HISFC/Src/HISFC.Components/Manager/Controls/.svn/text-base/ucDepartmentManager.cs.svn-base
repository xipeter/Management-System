using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 科室人员维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－7]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDepartmentManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        //科室管理类
        Neusoft.HISFC.BizLogic.Manager.Department departmentManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        //人员管理类
        Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
        private Neusoft.FrameWork.Public.ObjectHelper DutyHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper LevelHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        //实例化科室维护结点
        private TreeNode parentTreeNode = new TreeNode();
        //实例化科室列表结点
        private TreeNode deptTreeNode = new TreeNode();
        //实例化科室人员结点
        private TreeNode deptEmplTreeNode = new TreeNode();

        private TreeNode emplTreeNode = new TreeNode();

        //当前树选择结点
        private TreeNode curSelectedNode;
        //声明人员数据集
        private DataSet personDataSet = null;
        //人员信息缓存.
        private Hashtable personCache = new Hashtable();
        private Hashtable deptsCache = new Hashtable();

        private ArrayList DutyList = null;
        private ArrayList LevelList = null;


        public ucDepartmentManager()
        {
            InitializeComponent();
        }
        #region 定义工具栏

       protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏

       protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加科室", "添加科室", 0, true, false,null);
            toolBarService.AddToolButton("修改科室", "修改科室", 1, true, false,null);
            toolBarService.AddToolButton("添加人员", "添加人员", 2, true, false,null);
            toolBarService.AddToolButton("修改人员", "修改人员", 3, true, false,null);
            toolBarService.AddToolButton("查找", "查找", 4, true, false,null);
            return toolBarService;
        }



       #endregion

       #region 属性
       //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
        [Category("控件设置"),Description("是否挂号处使用：true，挂号处使用，只允许修改职级和备注 ，false：基本信息维护") ,DefaultValue(false)]
        private bool isModifedlevelAndRemark = false;

        public bool IsModifedlevelAndRemark
        {
            get { return isModifedlevelAndRemark; }
            set
            {
                isModifedlevelAndRemark = value;

            }
        }
       #endregion

       #region 重写工具栏按钮功能
       /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Exit(object sender, object neuObject)
        {
            return base.Exit(sender, neuObject);
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Print(object sender, object neuObject)
        {
            PrintInfo();
            return base.Print(sender, neuObject);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            ExportInfo();
            return base.Export(sender, neuObject);
        }

        #region 打印方法
        /// <summary>
        /// 打印方法
        /// </summary>
        private void PrintInfo()
        {
            Neusoft.FrameWork.WinForms.Classes.Print pr = new Neusoft.FrameWork.WinForms.Classes.Print();
            pr.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            pr.PrintPreview(this.splitContainer1.Panel2);
        }
        #endregion

        //修改时间：２００７－４－１０
        //修改人：路志鹏
        //修改目的：完善导出功能
        #region 导出方法
        private void ExportInfo()
        {
            bool tr = false;
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "excel|*.xls";
            saveFile.Title = "导出到Excel";

            saveFile.FileName = "科室人员管理 " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Replace(':', '-');

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (saveFile.FileName.Trim() != "")
                {
                    fileName = saveFile.FileName;
                    tr = this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                }
                else
                {
                    MessageBox.Show("文件名不能为空!");
                    return;
                }

                if (tr)
                {
                    MessageBox.Show("导出成功!");
                }
                else
                {
                    MessageBox.Show("导出失败!");
                }
            }
        }

        #endregion
        #endregion

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "添加科室":
                    AddNewDepartment();
                    break;
                case "修改科室":
                    ModifyDepartment();
                    break;
                case "添加人员":
                    AddEmployee();
                    break;
                case "修改人员":
                    if (this.tvDeptList1.SelectedNode.Parent != null && this.neuSpread1_Sheet1.RowCount > 0)
                    ModifyEmployee();
                    break;
                case "查找":
                    FindInfo();
                    break;
                default :
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 查找方法
        /// </summary>
        public void FindInfo()
        {
            ucFindDeptAndEmployee ucFindDeptEmpl = new ucFindDeptAndEmployee();
            ucFindDeptEmpl.UcDeptMgr = this;


            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "查找";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucFindDeptEmpl);
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        public void AddEmployee()
        {
            try
            {
                ucEmployeeInfoPanel employeeInfo = new ucEmployeeInfoPanel();
                employeeInfo.IsModify = false;
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "添加人员";
                DialogResult dia = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(employeeInfo);
                if (dia == DialogResult.OK)
                {
                                              
                }
                else if (dia == DialogResult.Cancel)
                {
                    if (employeeInfo.tr)
                    {
                       
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
        }
        
        /// <summary>
        /// 修改人员
        /// </summary>
        public void ModifyEmployee()
        {   
            try
            {
                 
                if (this.tvDeptList1.SelectedNode.Level == 2)
                {
                    if (this.neuSpread1_Sheet1.RowCount <= 0) return;
                    Neusoft.HISFC.Models.Base.Department dept = this.tvDeptList1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Department;
                    //获得当前结点科室ID
                    string deptId = dept.ID;
                    Neusoft.HISFC.Models.Base.Department department = departmentManager.GetDeptmentById(deptId);
                    if (department == null)
                    {
                        MessageBox.Show("选择的科室信息不存在！");
                        return;
                    }
                    //获得激活行对应的人员编码
                    string personId = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text.Trim();
                    Neusoft.HISFC.Models.Base.Employee employee = personManager.GetPersonByID(personId);
                    if (employee == null)
                    {
                        MessageBox.Show("选择的人员信息不存在！");
                        return; 
                    }
                    
                    ucEmployeeInfoPanel ucEmployeeInfo = new ucEmployeeInfoPanel(employee);
                    ucEmployeeInfo.IsModify = true;
                    //{3BAA59AB-14DE-496e-B77A-E7C298D3245B}
                    ucEmployeeInfo.IsModifedlevelAndRemark = this.isModifedlevelAndRemark;
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "修改人员信息";
                    DialogResult dia = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucEmployeeInfo);
                    if (dia == DialogResult.OK)
                    {
                        //根据当前结点科室ID，获得该科室下的人员
                        LoadPersons(deptId);
                    }
                }
                else 
                {
                    return;
                }
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
      
        /// <summary>
        /// 添加科室
        /// </summary>
        public void AddNewDepartment()
        {
            try
            {

                ucDeptmentInfoPanel ucDeptInfo = new ucDeptmentInfoPanel();
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "添加科室";

                DialogResult di = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucDeptInfo);
                if (di == DialogResult.OK)
                {
                    parentTreeNode.Nodes.Clear();
                    deptsCache = new Hashtable();
                    LoadDeptAll();
                }
                else if (di == DialogResult.Cancel)
                {
                    if (ucDeptInfo.tr)
                    {
                        parentTreeNode.Nodes.Clear();
                        deptsCache = new Hashtable();
                        LoadDeptAll();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 修改科室
        /// </summary>
        public void ModifyDepartment()
        {
            try
            {
                if (this.tvDeptList1.SelectedNode.Level == 2)
                {
                    Neusoft.HISFC.Models.Base.Department dept = this.tvDeptList1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Department;
                    //通过科室编码获得科室名称
                    Neusoft.HISFC.Models.Base.Department department = departmentManager.GetDeptmentById(dept.ID);
                    if (department == null) MessageBox.Show("选中的科室不存在！");
                    ucDeptmentInfoPanel ucDeptInfo = new ucDeptmentInfoPanel(dept);
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "修改科室";
                    DialogResult diaR = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucDeptInfo);
                    if (diaR == DialogResult.OK)
                    {
                        parentTreeNode.Nodes.Clear();
                        deptsCache = new Hashtable();                        
                        LoadDeptAll();
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void BeforeLoad()
        {
            parentTreeNode.Text = "科室维护";
            this.tvDeptList1.Nodes.Clear();
            parentTreeNode.ImageIndex = 3;
            this.tvDeptList1.Nodes.Add(parentTreeNode);
            deptTreeNode.Text = "科室列表";
            deptTreeNode.ImageIndex = 2;
            this.tvDeptList1.Nodes.Add(deptTreeNode);
            deptEmplTreeNode.Text = "科室人员列表";
            deptEmplTreeNode.ImageIndex = 0;
            this.tvDeptList1.Nodes.Add(deptEmplTreeNode);
            //加载All科室
            LoadDeptAll();
            //初始化人员数据集
            personDataSet = InitPersonDataSet();
            this.neuSpread1.DataSource = personDataSet.Tables[0];
            //设置FarPoint显示列
            SetColumn("person");
            this.tvDeptList1.SelectedNode = this.tvDeptList1.Nodes[0];

        }
        /// <summary>
        /// 设置FarPoint显示列
        /// </summary>
        /// <param name="flag"></param>
        private void SetColumn(string flag)
        {
            int width = 20;

            switch (flag)
            {
                case "person":
                    this.neuSpread1_Sheet1.Columns[0].Label = "人员编号";
                    this.neuSpread1_Sheet1.Columns[0].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[1].Label = "人员姓名";
                    this.neuSpread1_Sheet1.Columns[1].Width = width * 6;
                    this.neuSpread1_Sheet1.Columns[2].Label = "性别";
                    this.neuSpread1_Sheet1.Columns[2].Width = width * 3;
                    this.neuSpread1_Sheet1.Columns[3].Label = "人员类别";
                    this.neuSpread1_Sheet1.Columns[3].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[4].Label = "职务";
                    this.neuSpread1_Sheet1.Columns[4].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[5].Label = "职级";
                    this.neuSpread1_Sheet1.Columns[5].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[6].Label = "所属护士站";
                    this.neuSpread1_Sheet1.Columns[6].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[7].Label = "序号";
                    this.neuSpread1_Sheet1.Columns[7].Width = width * 4;
                    this.neuSpread1_Sheet1.Columns[8].Label = "是否停用";
                    this.neuSpread1_Sheet1.Columns[8].Width = width * 4;
                    break;
                case "dept":
                    this.neuSpread1_Sheet1.Columns[0].Label = "科室编号";
                    this.neuSpread1_Sheet1.Columns[0].Width = width * 7;
                    this.neuSpread1_Sheet1.Columns[1].Label = "科室名称";
                    this.neuSpread1_Sheet1.Columns[1].Width = width * 7;
                    this.neuSpread1_Sheet1.Columns[2].Label = "科室类型";
                    this.neuSpread1_Sheet1.Columns[2].Width = width * 7;
                    break;
                case "empl":
                    this.neuSpread1_Sheet1.Columns[0].Label = "人员编号";
                    this.neuSpread1_Sheet1.Columns[0].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[1].Label = "人员姓名";
                    this.neuSpread1_Sheet1.Columns[1].Width = width * 6;
                    this.neuSpread1_Sheet1.Columns[2].Label = "性别";
                    this.neuSpread1_Sheet1.Columns[2].Width = width * 3;
                    this.neuSpread1_Sheet1.Columns[3].Label = "人员类别";
                    this.neuSpread1_Sheet1.Columns[3].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[4].Label = "所属护士站";
                    this.neuSpread1_Sheet1.Columns[4].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[5].Label = "序号";
                    this.neuSpread1_Sheet1.Columns[5].Width = width * 4;
                    this.neuSpread1_Sheet1.Columns[6].Label = "是否停用";
                    this.neuSpread1_Sheet1.Columns[6].Width = width * 4;
                    break;
                case "deptEmpl":
                    this.neuSpread1_Sheet1.Columns[0].Label = "科室编号";
                    this.neuSpread1_Sheet1.Columns[0].Width = width * 4;
                    this.neuSpread1_Sheet1.Columns[1].Label = "科室名称";
                    this.neuSpread1_Sheet1.Columns[1].Width = width * 5;
                    this.neuSpread1_Sheet1.Columns[2].Label = "人员编号";
                    this.neuSpread1_Sheet1.Columns[2].Width = width * 3;
                    this.neuSpread1_Sheet1.Columns[3].Label = "人员姓名";
                    this.neuSpread1_Sheet1.Columns[3].Width = width * 4;
                    this.neuSpread1_Sheet1.Columns[4].Label = "性别";
                    this.neuSpread1_Sheet1.Columns[4].Width = width * 2;
                    this.neuSpread1_Sheet1.Columns[5].Label = "人员类别";
                    this.neuSpread1_Sheet1.Columns[5].Width = width * 4;
                    this.neuSpread1_Sheet1.Columns[6].Label = "所属护士站";
                  
                    break;
            }
        }

        /// <summary>
        /// 初始化人员数据集
        /// </summary>
        /// <returns></returns>
        private DataSet InitPersonDataSet()
        {
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            //人员编码
            DataColumn column1 = new DataColumn("EMPL_CODE");
            column1.DataType = typeof(System.String);
            //column1.ReadOnly = true;
            table.Columns.Add(column1);
            //人员姓名
            DataColumn column2 = new DataColumn("EMPL_NAME");
            column2.DataType = typeof(System.String);
            table.Columns.Add(column2);
            //性别
            DataColumn column3 = new DataColumn("SEX_CODE");
            column3.DataType = typeof(System.String);
            table.Columns.Add(column3);
            //人员类别
            DataColumn column4 = new DataColumn("EMPL_TYPE");
            column4.DataType = typeof(System.String);
            table.Columns.Add(column4);
            //职务
            DataColumn column9 = new DataColumn("职务");
            column9.DataType = typeof(System.String);
            table.Columns.Add(column9);
            //职级
            DataColumn column10 = new DataColumn("职级");
            column10.DataType = typeof(System.String);
            table.Columns.Add(column10);
            //所属护理站
            DataColumn column5 = new DataColumn("NURSE_CELL_CODE");
            column5.DataType = typeof(System.String);
            table.Columns.Add(column5);
            //序号
            DataColumn column6 = new DataColumn("SORTID");
            column6.DataType = typeof(System.Int32);
            table.Columns.Add(column6);
            //是否用
            DataColumn column7 = new DataColumn("VALID_STATE");
            //column7.DataType = typeof(System.Int32);
            column7.DataType = typeof(System.String);
            table.Columns.Add(column7);

            dataSet.Tables.Add(table);

            return dataSet;
        }

        /// <summary>
        /// 加载所有科室
        /// </summary>
        /// <returns></returns>
        public bool LoadDeptAll()
        {

            //Insert Into TreeView. TreeNode Contains DeptID,DeptName,DeptType.
            parentTreeNode.Nodes.Clear();
            Neusoft.HISFC.Models.Base.Department deptInfo = new Neusoft.HISFC.Models.Base.Department();

            ArrayList depts = departmentManager.GetDeptAllUserStopDisuse();
            if (depts == null || depts.Count < 1)
                return false;

            foreach (Neusoft.HISFC.Models.Base.Department info in depts)
            {
                //科室类型
                TreeNode kindnode = this.GetParentNode(info);
                //科室
                TreeNode node = new TreeNode();
                node.Tag = info;
                node.Text = "(" + info.ID + ")" + info.Name;
                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)//可用
                {
                    node.BackColor = Color.White;
                }
                else
                {
                    node.BackColor = Color.Silver;
                }
                kindnode.Nodes.Add(node);

                deptsCache.Add(info.ID, info);
            }

            tvDeptList1.ExpandAll();
            //tvDeptList1.Sort();// {1C622422-422E-495b-AC12-9010873B7C05} 2010.12.10 hzl add:增加排序功能
            return true;

        }


        /// <summary>
        /// 根据传入的科室实体，找出其所属分类
        /// </summary>
        /// <param name="info">科室实体</param>
        /// <returns>科室类型节点</returns>
        private TreeNode GetParentNode(Neusoft.HISFC.Models.Base.Department info)
        {
            //在一级节点中找科室的类型
            foreach (TreeNode node in this.parentTreeNode.Nodes)
            {
                if (node.Tag.ToString() == info.DeptType.ID.ToString())
                {
                    return node;
                }
            }

            //如果在一级节点中找不到科室的所属类型，则增加一个科室类型
            TreeNode kindnode = new TreeNode();
            kindnode.Tag = info.DeptType.ID;
            kindnode.Text = info.DeptType.Name;
            this.parentTreeNode.Nodes.Add(kindnode);
            return kindnode;
        }


        /// <summary>
        /// 选择结点后发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDeptList1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (curSelectedNode == e.Node)
                return;

           Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
            LevelList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.LEVEL);
            DutyList = con.GetList(Neusoft.HISFC.Models.Base.EnumConstant.POSITION);
            this.DutyHelper.ArrayObject = DutyList;
            this.LevelHelper.ArrayObject = LevelList;

          if(this.tvDeptList1.SelectedNode.Level == 2)
            {
                    this.neuSpread1_Sheet1.DataSource = personDataSet.Tables[0];
                    this.SetColumn("person");
                    this.neuSpread1_Sheet1.Columns[6].Visible = false;
                    Neusoft.HISFC.Models.Base.Department dept = this.tvDeptList1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Department;
                    LoadPersons(dept.ID);
                    this.ModifySortableColumn(this.neuSpread1_Sheet1.ColumnCount);

            }
            else if (e.Node.Text == "科室列表")
            {
                this.LoadDepts();
                this.ModifySortableColumn(this.neuSpread1_Sheet1.ColumnCount);
            }
            else if (e.Node.Text == "科室维护")
            {
                this.neuSpread1_Sheet1.DataSource = personDataSet.Tables[0];
                personDataSet.Tables[0].Rows.Clear();
                this.SetColumn("person");
                this.neuSpread1_Sheet1.Columns[6].Visible = false;
            }
            else if (e.Node.Text == "科室人员列表")
            {
                LoadDeptEmpl();
                this.ModifySortableColumn(this.neuSpread1_Sheet1.ColumnCount);
            }
            else
            {
                this.LoadDeptsByType(e.Node.Tag.ToString());
                this.ModifySortableColumn(this.neuSpread1_Sheet1.ColumnCount);
            }
            curSelectedNode = e.Node;
        }

        /// <summary>
        /// 科室人员列表
        /// </summary>
        private void LoadDeptEmpl()
        {
            ArrayList depts = departmentManager.GetDeptmentAll();

            DataSet deptAll = new DataSet();
            DataTable dept = new DataTable("dept");

            DataColumn[] colDept = {new DataColumn("科室编码"),
								    new DataColumn("科室名称"),
									new DataColumn("人员代码"),
						            new DataColumn("人员姓名"),
						            new DataColumn("性别"),
						            new DataColumn("人员类型"),
						            new DataColumn("所属护士站")};
            dept.Columns.AddRange(colDept);
            
            dept.Rows.Clear();
                       
                ArrayList al = personManager.GetEmployeeAll();

                if (al == null)
                    return;
                Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper(depts);
                foreach (Neusoft.HISFC.Models.Base.Employee pInfo in al)
                {
                    DataRow row = dept.NewRow();

                    row["科室编码"] = pInfo.Dept.ID;
                    row["科室名称"] = helper.GetName(pInfo.Dept.ID);
                    row["人员代码"] = pInfo.ID;
                    row["人员姓名"] = pInfo.Name;
                    row["性别"] = pInfo.Sex.Name;
                    row["人员类型"] = pInfo.EmployeeType.Name;
                    if (pInfo.Nurse.ID != "" || deptsCache.Contains(pInfo.Nurse.ID))

                        row["所属护士站"] = deptsCache[pInfo.Nurse.ID].ToString();
                    else
                        row["所属护士站"] = "";
                    
                    dept.Rows.Add(row);
                }
          
            this.neuSpread1_Sheet1.DataSource = dept;
            this.SetColumn("deptEmpl");
        }

        /// <summary>
        /// 科室列表
        /// </summary>
        private void LoadDepts()
        {
            Neusoft.HISFC.Models.Base.Department obj = new Neusoft.HISFC.Models.Base.Department();
            
            //得到所有科室
            ArrayList depts = departmentManager.GetDeptAllUserStopDisuse();
           
            DataSet deptAll = new DataSet();
            DataTable dept = new DataTable("dept");
         
            DataColumn[] colDept = {new DataColumn("科室编码"),
								    new DataColumn("科室名称"),
                                    new DataColumn("科室类型")};
           
            dept.Columns.AddRange(colDept);
    
            dept.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Department deptInfo in depts)
            {
                DataRow row = dept.NewRow();
                row["科室编码"] = deptInfo.ID.ToString().Trim();
                row["科室名称"] = deptInfo.Name;
                row["科室类型"] = deptInfo.DeptType.Name;

                dept.Rows.Add(row);
            }
            deptAll.Tables.Add(dept);

            this.neuSpread1_Sheet1.DataSource = deptAll;
            this.SetColumn("dept");
        }

        /// <summary>
        /// 加载某一类型的科室
        /// </summary>
        /// <param name="deptType">类型编码</param>
        private void LoadDeptsByType(string deptType)
        {
            Neusoft.HISFC.Models.Base.Department obj = new Neusoft.HISFC.Models.Base.Department();

            //得到所有科室
            ArrayList depts = departmentManager.GetDeptmentByType(deptType);

            DataSet deptAll = new DataSet();
            DataTable dept = new DataTable("dept");

            DataColumn[] colDept = {new DataColumn("科室编码"),
								    new DataColumn("科室名称"),
                                    new DataColumn("科室类型")};

            dept.Columns.AddRange(colDept);

            dept.Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Department deptInfo in depts)
            {
                DataRow row = dept.NewRow();
                row["科室编码"] = deptInfo.ID.ToString().Trim();
                row["科室名称"] = deptInfo.Name;
                row["科室类型"] = deptInfo.DeptType.Name;

                dept.Rows.Add(row);
            }
            deptAll.Tables.Add(dept);

            this.neuSpread1_Sheet1.DataSource = deptAll;
            this.SetColumn("dept");
        }

        /// <summary>
        /// 根据结点信息加载信息
        /// </summary>
        /// <param name="deptID"></param>
        private void LoadPersons(string deptID)
        {   
            //根据科室ID获得全部人员信息
            ArrayList list = personManager.GetPersonsByDeptIDAll(deptID);
            
            personDataSet.Tables[0].Clear();

            if (list != null && list.Count > 0)
            {
                AddPersonsToTable(list, personDataSet.Tables[0]);
            }
            
            string valid;

            //如果人员的有效性不为"在用",即 0,则显示灰色。

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; ++i)
            {
                valid = this.neuSpread1_Sheet1.GetValue(i, 8).ToString();
                if (valid != "在用")
                    this.neuSpread1_Sheet1.Rows[i].BackColor = Color.MistyRose;
            }

            if (this.neuSpread1_Sheet1.Rows.Count > 0)
                this.neuSpread1_Sheet1.ActiveRowIndex = 0;
            this.SetColumn("person");
        }

        /// <summary>
        /// 根据ArryList填充DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private void AddPersonsToTable(ArrayList list, DataTable table)
        {

            foreach (Neusoft.HISFC.Models.Base.Employee info in list)
            {
                /*[2007/02/05] info.ValidState字段取值为:0(在用),1(停用),2(废弃)
                 *             原来显示的是数字,测试建议改为中文 
                 * 
                 * table.Rows.Add(new Object[]{info.ID, info.Name ,info.Sex.Name, info.EmployeeType.Name,
				 *							   DutyHelper.GetName(info.Duty.ID),LevelHelper.GetName(info.Level.ID),info.Nurse.Name, info.SortID,info.ValidState});
                 * 
                 */
                string validState = string.Empty;
                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    validState = "在用";
                }
                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    validState = "停用";
                }
                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                {
                    validState = "废弃";
                }
                table.Rows.Add(new Object[]{info.ID, info.Name ,info.Sex.Name, info.EmployeeType.Name,
											   DutyHelper.GetName(info.Duty.ID),LevelHelper.GetName(info.Level.ID),info.Nurse.Name, info.SortID,validState});

            }

        }


        private void tvDeptList1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.tvDeptList1.SelectedNode = this.tvDeptList1.GetNodeAt(e.X, e.Y);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void ucDepartmentManager_Load(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.Rows[-1].Locked = true;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            BeforeLoad();
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ModifyEmployee();
            
        }
        /// <summary>
        /// 增加排序功能
        /// </summary>
        private void ModifySortableColumn(int rowcount)
        {
            for(int i=0;i < rowcount;i++)
            {
            this.neuSpread1_Sheet1.Columns.Get(i).AllowAutoSort = true;
            }
        }
    }
}
