using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse
{
    /// <summary>
    /// [功能描述: 排班管理]<br></br>
    /// [创 建 者: 潘铁俊]<br></br>
    /// [创建时间: 2007-09-18]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucEmplWork : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEmplWork()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 排班控件数组,方便操作
        /// </summary>
        protected Nurse.ucWork[] controls;
        /// <summary>
        /// 当前人员类别
        /// </summary>
        Neusoft.HISFC.Models.Base.EnumEmployeeType emplType = (Neusoft.HISFC.Models.Base.EnumEmployeeType)Enum.Parse(typeof(Neusoft.HISFC.Models.Base.EnumEmployeeType), ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).EmployeeType.ID.ToString());
        /// <summary>
        /// 当前人员类别
        /// </summary>
        Neusoft.HISFC.Models.Base.EmployeeTypeEnumService emplType2 = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).EmployeeType;
        /// <summary>
        /// 当前科室代码
        /// </summary>
        string deptCode = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.ID;
        /// <summary>
        /// 当前科室名称
        /// </summary>
        string deptName = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.Name;
        /// <summary>
        /// 新建工具按钮
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 排班历史
        /// </summary>
        private Hashtable htHistory = new Hashtable();
        /// <summary>
        ///更改neuTabControl1 选择页面的前一个选项
        /// </summary>
        private int tabPreSelected;
        /// <summary>
        /// 设置是否显示全部类型的人员
        /// </summary>
        bool displayAllType = false;
        /// <summary>
        /// 树节点动态数组
        /// </summary>
        ArrayList emp = new ArrayList();

        #endregion

        #region 属性

        public bool DisplayAllType
        {
            get { return displayAllType; }
            set { displayAllType = value; }
        }

        
        #endregion

        #region 方法

        #region 初始化方法

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucEmplWork_Load(object sender, EventArgs e)
        {
            this.Text = "人员排班模板维护";

            this.InitTab();

            this.InitArray();

            this.InitControls();

            this.InitEmployee();

            this.QueryTodayWork();

            this.LoadHistory();

        }
        /// <summary>
        /// 生成排班日期
        /// </summary>
        private void InitTab()
        {
            Neusoft.HISFC.BizLogic.Registration.Schema sMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
            DateTime Current = sMgr.GetDateTimeFromSysDateTime();

            DateTime Monday = this.GetMonday(Current);

            this.setWeek(Monday);
        }
        private void setWeek(DateTime Monday)
        {
            string[] Week = new string[] { "一", "二", "三", "四", "五", "六", "日" };

            for (int i = 0; i < 7; i++)
            {
                this.neuTabControl1.TabPages[i].Tag = Monday.AddDays(i);
                this.neuTabControl1.TabPages[i].Text = Monday.AddDays(i).ToString("yyyy-MM-dd") + "  " + Week[i];
            }
        }
        /// <summary>
        /// 初始化数组
        /// </summary>
        private void InitArray()
        {
            controls = new Nurse.ucWork[7];
            controls[0] = this.ucWork1;
            controls[1] = this.ucWork2;
            controls[2] = this.ucWork3;
            controls[3] = this.ucWork4;
            controls[4] = this.ucWork5;
            controls[5] = this.ucWork6;
            controls[6] = this.ucWork7;
        }

        /// <summary>
        /// 初始化模板控间
        /// </summary>
        private void InitControls()
        {
            Nurse.ucWork obj;

            for (int i = 0; i < 7; i++)
            {
                obj = controls[i];
                obj.Init((DayOfWeek)((i + 1) == 7 ? 0 : (i + 1)));
            }
        }

        /// <summary>
        /// 生成树
        /// </summary>
        private void InitEmployee()
        {
            //设置父节点为当前登录科室
            this.baseTreeView1.Nodes.Clear();
            TreeNode parent = new TreeNode(deptName);
            this.baseTreeView1.ImageList = this.baseTreeView1.deptImageList;
            parent.ImageIndex = 5;
            parent.SelectedImageIndex = 5;
            this.baseTreeView1.Nodes.Add(parent);

            Neusoft.HISFC.BizProcess.Integrate.Manager Mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            //默认先添加一个子节点 为登录人员的人员类型
            TreeNode empTypeNode = new TreeNode();
            empTypeNode.Text = emplType2.Name;
            empTypeNode.ImageIndex = 0;
            empTypeNode.SelectedImageIndex = 1;
            parent.Nodes.Add(empTypeNode);

            //初始化树包含的节点类型
            Hashtable htSonNode = new Hashtable();

            foreach (TreeNode node in parent.Nodes)
            {
                htSonNode.Add(node.Text, node);
            }

            //判断是否列出整个科室的所有类型的人员
            if (this.displayAllType)
            {
                emp = Mgr.QueryEmployeeByDeptID(deptCode);

                if (emp == null)
                {
                    MessageBox.Show("获取人员列表时出错!" + Mgr.Err, "提示");
                    return;
                }

                foreach (Neusoft.HISFC.Models.Base.Employee employee in emp)
                {
                    //判断又没有该人员类型的节点
                    if (!htSonNode.ContainsKey(employee.EmployeeType.Name))
                    {
                        //如果没有设置人员类型的节点
                        TreeNode empTypeNode2 = new TreeNode();
                        empTypeNode2.Text = employee.EmployeeType.Name;
                        empTypeNode2.ImageIndex = 0;
                        empTypeNode2.SelectedImageIndex = 1;
                        parent.Nodes.Add(empTypeNode2);
                        htSonNode.Add(employee.EmployeeType.Name, empTypeNode2);

                        //添加该人员类型的下一节点
                        TreeNode empNode = new TreeNode();
                        empNode.Text = employee.Name;
                        empNode.ImageIndex = 4;
                        empNode.SelectedImageIndex = 3;
                        empNode.Tag = employee;
                        empTypeNode2.Nodes.Add(empNode);

                    }
                    else //如果存在该人员类型的节点
                    {

                        TreeNode empNode = new TreeNode();
                        empNode.Text = employee.Name;
                        empNode.ImageIndex = 4;
                        empNode.SelectedImageIndex = 3;
                        empNode.Tag = employee;
                        ((TreeNode)htSonNode[employee.EmployeeType.Name]).Nodes.Add(empNode);
                    }

                }
            }
            else
            {
                emp = Mgr.QueryEmployee(emplType, deptCode);

                if (emp == null)
                {
                    MessageBox.Show("获取人员列表时出错!" + Mgr.Err, "提示");
                    return;
                }

                foreach (Neusoft.HISFC.Models.Base.Employee employee in emp)
                {
                    TreeNode empNode = new TreeNode();
                    empNode.Tag = employee;
                    empNode.Text = employee.Name;
                    empNode.ImageIndex = 4;
                    empNode.SelectedImageIndex = 3;
                    empTypeNode.Nodes.Add(empNode);
                }
            }
            this.cmbEmp.AddItems(emp);
            parent.ExpandAll();
        }
        /// <summary>
        /// 加载历史排班列表
        /// </summary>
        private void LoadHistory()
        {
            this.htHistory.Clear();
            int Index = this.neuTabControl1.SelectedIndex;
            DayOfWeek historyWeek = this.controls[Index].Week;
            string selectedDate = this.controls[Index].ArrangeDate.ToString("yyyy-MM-dd");
            Neusoft.HISFC.BizLogic.Nurse.Work workMgr = new Neusoft.HISFC.BizLogic.Nurse.Work();
            ArrayList al = workMgr.QueryHistory(Index + 1, this.deptCode);

            //设置父节点为当前登录科室
            this.baseTreeView2.Nodes.Clear();
            TreeNode parent = new TreeNode(GetChineseWeek(historyWeek) + " 排班历史");
            this.baseTreeView2.ImageList = this.baseTreeView2.deptImageList;
            parent.ImageIndex = 5;
            parent.SelectedImageIndex = 5;
            this.baseTreeView2.Nodes.Add(parent);
            StringBuilder dateString = new StringBuilder("#");
            ArrayList alDate = new ArrayList();
            int index = 1;
            string preDate = string.Empty;
            foreach (Neusoft.HISFC.Models.Nurse.Work tempWork in al)
            {
                if (dateString.ToString().IndexOf("#" + tempWork.WorkDate.Date.ToString("yyyy-MM-dd") + "#") == -1)
                {
                    if (alDate.Count > 0)
                    {
                        htHistory.Add(preDate, alDate);

                    }
                    alDate = new ArrayList();
                    dateString.Append(tempWork.WorkDate.Date.ToString("yyyy-MM-dd") + "#");
                    //不显示当前选中的日期
                    if (selectedDate != tempWork.WorkDate.Date.ToString("yyyy-MM-dd"))
                    {
                        TreeNode historyNode = new TreeNode();
                        historyNode.Tag = null;
                        historyNode.Text = tempWork.WorkDate.Date.ToString("yyyy-MM-dd");
                        historyNode.ImageIndex = 4;
                        historyNode.SelectedImageIndex = 3;
                        parent.Nodes.Add(historyNode);
                    }
                }
                alDate.Add(tempWork);
                preDate = tempWork.WorkDate.Date.ToString("yyyy-MM-dd");
                //最后的一组排班信息添加到哈希列表中
                if ((index++ == al.Count) && alDate.Count > 0)
                {
                    htHistory.Add(preDate, alDate);
                }

            }

            parent.ExpandAll();

        }
        /// <summary>
        /// 初始化工具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加(+)", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除(-)", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("复制模板", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);
            toolBarService.AddToolButton("下周", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, null);
            toolBarService.AddToolButton("上周", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S上一个, true, false, null);
            toolBarService.AddToolButton("全部删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加(+)":
                    this.Add();
                    break;
                case "删除(-)":
                    this.Del();
                    break;
                case "全部删除":
                    this.DelAll();
                    break;
                case "复制模板":
                    this.LoadTemplet();
                    break;
                case "上周":
                    Prior();
                    break;
                case "下周":
                    Next();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 设置热键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            {
                this.Del();
                return true;
            }
            else if (keyData == Keys.Add || keyData == Keys.Oemplus)
            {
                this.Add();
                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            {
                this.Save();
                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
            }
            else if (keyData == Keys.F1)
            {
                this.cmbEmp.Focus();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                this.Find();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 处理事件方法
        /// <summary>
        /// 人员树选中后方法，该方法中对选中的 tabpage 中的 CurrentPerson 和  DeptName 赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.baseTreeView1.SelectedNode;

            if (node == null) return;

            int Index = this.neuTabControl1.SelectedIndex;

            if (node.Level == 2)
            {
                this.controls[Index].CurrentPerson = (Neusoft.HISFC.Models.Base.Employee)node.Tag;
                this.controls[Index].DeptName = ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.Name;
            }
            else
            {
                this.controls[Index].CurrentPerson = null;
            }

        }

        /// <summary>
        /// tabpage 切换时，如果前面的页面有更改，则提示保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (controls[this.tabPreSelected].IsChange())
            {
                if (MessageBox.Show("数据已经修改,是否保存变动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (controls[this.tabPreSelected].Save() == -1)
                    {
                        return;
                    }
                }
            }

        }
        /// <summary>
        /// tabpage 选中后加载排班信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            object obj = this.neuTabControl1.TabPages[this.neuTabControl1.SelectedIndex].Tag;

            if (obj == null || obj.ToString() == "")
            {
                this.baseTreeView1.SelectedNode = this.baseTreeView1.Nodes[0];
                this.baseTreeView1_AfterSelect(new object(), new System.Windows.Forms.TreeViewEventArgs(new TreeNode(), System.Windows.Forms.TreeViewAction.Unknown));
                this.neuTabControl1.TabPages[this.neuTabControl1.SelectedIndex].Tag = "Has Retrieve";
            }
            this.baseTreeView1.SelectedNode = null;
            int Index = this.neuTabControl1.SelectedIndex;
            this.controls[Index].ArrangeDate = DateTime.Parse(this.neuTabControl1.TabPages[Index].Tag.ToString()); ;
            this.controls[Index].Query(this.deptCode);
            this.LoadHistory();
            this.tabPreSelected = this.neuTabControl1.SelectedIndex;
        }
        /// <summary>
        ///查找人员事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.baseTreeView1.Nodes[0].Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (((Neusoft.HISFC.Models.Base.Employee)childNode.Tag).ID == this.cmbEmp.Tag.ToString())
                    {
                        this.baseTreeView1.SelectedNode = childNode;
                        this.baseTreeView1.Focus();
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 如果查找人员的combox中有值，回车后在人员树中选中该人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Index = this.neuTabControl1.SelectedIndex;

                controls[Index].Focus();
                cmbEmp_SelectedIndexChanged(sender, e);
            }
        }
        /// <summary>
        /// 添加排班历史到当前排班
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baseTreeView2_DoubleClick(object sender, EventArgs e)
        {
            if(this.baseTreeView2.SelectedNode.Level != 1)
            {
                return;
            }
            if (MessageBox.Show("是否添加历史排班到当前的排班中？\r\n该操作将删除原来的排班！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.DelAllNoMessageBox();
                string selectedDate = this.baseTreeView2.SelectedNode.Text;
                ArrayList al = (ArrayList)this.htHistory[selectedDate];
                int Index = this.neuTabControl1.SelectedIndex;
                foreach (Neusoft.HISFC.Models.Nurse.Work tempWork in al)
                {
                    this.controls[Index].Add(tempWork);
                }
            }
        }
        #endregion

        #region 排班相关方法

        /// <summary>
        /// 默认显示当日排班
        /// </summary>
        private void QueryTodayWork()
        {
            Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();

            DateTime today = SchemaMgr.GetDateTimeFromSysDateTime();

            int Index = (int)today.DayOfWeek;
            Index--;
            if (Index == -1) Index = 6;

            this.neuTabControl1.SelectedIndex = Index;
            this.controls[Index].ArrangeDate = today;
            this.controls[Index].Query(this.deptCode);
        }
        /// <summary>
        /// 获取当前日期所在星期的星期一
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private DateTime GetMonday(DateTime current)
        {
            DayOfWeek today = current.DayOfWeek;

            int interval = 1 - (int)today;

            if (interval == 1)//星期日
            {
                interval = -6;//将星期日归到上星期
            }

            return current.AddDays(interval);
        }

        /// <summary>
        /// 下一星期
        /// </summary>
        private void Next()
        {
            DateTime Monday;

            Monday = this.GetMonday(DateTime.Parse(this.tabPage7.Tag.ToString()).AddDays(2));

            this.setWeek(Monday);

            for (int i = 0; i < 7; i++)
            {
                this.controls[i].Tag = null;
                this.controls[i].ArrangeDate = DateTime.Parse(this.neuTabControl1.TabPages[i].Tag.ToString());
            }


            this.controls[this.neuTabControl1.SelectedIndex].Query("ALL");
            this.LoadHistory();
        }
        /// <summary>
        /// 上一星期
        /// </summary>
        private void Prior()
        {
            DateTime Monday;

            Monday = this.GetMonday(DateTime.Parse(this.tabPage1.Tag.ToString()).AddDays(-3));

            this.setWeek(Monday);

            for (int i = 0; i < 7; i++)
            {
                this.controls[i].Tag = null;
                this.controls[i].ArrangeDate = DateTime.Parse(this.neuTabControl1.TabPages[i].Tag.ToString());
            }
            this.controls[this.neuTabControl1.SelectedIndex].Query("ALL");
            this.LoadHistory();
        }
        /// <summary>
        /// 载入模板
        /// </summary>
        private void LoadTemplet()
        {
            Neusoft.HISFC.Components.Registration.frmSelectWeek f = new Neusoft.HISFC.Components.Registration.frmSelectWeek();

            DateTime week = DateTime.Parse(this.neuTabControl1.SelectedTab.Tag.ToString());
            f.SelectedWeek = week.DayOfWeek;
            if (f.ShowDialog() == DialogResult.Yes)
            {
                Neusoft.HISFC.BizLogic.Nurse.WorkTemplet templetMgr = new Neusoft.HISFC.BizLogic.Nurse.WorkTemplet();
                //获取全部模板信息
                ArrayList al = templetMgr.Query(f.SelectedWeek, this.deptCode);
                if (al == null)
                {
                    MessageBox.Show("查询模板信息时出错!" + templetMgr.Err, "提示");
                    return;
                }

                foreach (Neusoft.HISFC.Models.Nurse.WorkTemplet templet in al)
                {
                    controls[this.neuTabControl1.SelectedIndex].Add(templet);
                }

                controls[this.neuTabControl1.SelectedIndex].Focus();
                f.Dispose();
            }
        }
        #endregion

        #region 增、删、改、打印、查找、导出操作
        /// <summary>
        /// 重载保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return 0;
        }
        /// <summary>
        /// 增加
        /// </summary>
        private void Add()
        {
            int Index = this.neuTabControl1.SelectedIndex;

            controls[Index].Add();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            int Index = this.neuTabControl1.SelectedIndex;

            controls[Index].Del();
        }

        /// <summary>
        /// 删除全部
        /// </summary>
        private void DelAll()
        {
            int Index = this.neuTabControl1.SelectedIndex;

            controls[Index].DelAll();
        }
        private void DelAllNoMessageBox()
        {
            int Index = this.neuTabControl1.SelectedIndex;

            controls[Index].DelAllNoMessageBox();
        
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            int Index = this.neuTabControl1.SelectedIndex;
            this.controls[Index].ArrangeDate = DateTime.Parse(this.neuTabControl1.TabPages[Index].Tag.ToString());

            if (controls[Index].Save() == -1)
            {
                controls[Index].Focus();
                return;
            }

            MessageBox.Show("保存成功!", "提示");

            controls[Index].Focus();
        }

        /// <summary>
        /// 搜索人员
        /// </summary>
        private void Find()
        {
            int Index = this.neuTabControl1.SelectedIndex;

            if (Index == 6)
            {
                Index = 0;
            }
            else
            {
                Index = Index + 1;
            }

            this.cmbEmp.Focus();
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
        private void Print()
        {
            int Index = this.neuTabControl1.SelectedIndex;
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPage(0, 0, this.controls[Index].FpSpread);
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            int Index = this.neuTabControl1.SelectedIndex;
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPreview(0, 0, this.controls[Index].FpSpread);
            return base.OnPrintPreview(sender, neuObject);
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            this.Export();
            return 1;
        }
        private void Export()
        {
            try
            {
                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel (*.xls)|*.xls";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    int Index = this.neuTabControl1.SelectedIndex;
                    this.controls[Index].FpSpread.SaveExcel(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// 获取英文星期对应的中文表达式
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        private string GetChineseWeek(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Saturday:
                    return "星期六";
                case DayOfWeek.Sunday:
                    return "星期日";
                default:
                    return "";
            }
        }
        #endregion

        #region 删除方法
        //private void baseTreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        //{
        //    //int Index = this.neuTabControl1.SelectedIndex;
        //    //Index++;

        //    //if (Index == 7) Index = 0;

        //    //if (controls[Index].IsChange())
        //    //{
        //    //    if (MessageBox.Show("数据已经改变,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //    //        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //    //    {
        //    //        if (controls[Index].Save() == -1)
        //    //        {
        //    //            e.Cancel = true;
        //    //            controls[Index].Focus();
        //    //        }
        //    //    }
        //    //}

        //}
        #endregion

        #endregion

    }
}
