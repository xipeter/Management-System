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
    /// [功能描述: 排班模板管理]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2007-05-03]<br></br>
    /// <修改记录
    ///		修改人='潘铁俊'
    ///		修改时间='2007-09-18'
    ///		修改目的='完善功能'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucEmplWorkTemplet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEmplWorkTemplet()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 排班控件数组,方便操作
        /// </summary>
        protected Nurse.ucWorkTemplet[] controls;
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
        /// 设置是否显示全部类型的人员
        /// </summary>
        bool displayAllType = false;
        /// <summary>
        /// 更改neuTabControl1 选择页面的前一个选项
        /// </summary>
        private int tabPreSelected;
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
        private void ucEmplWorkTemplet_Load(object sender, EventArgs e)
        {
            this.Text = "人员排班模板维护";

            this.InitArray();

            this.InitControls();

            this.InitEmployee();

            this.controls[0].Query(this.deptCode);

        }
        /// <summary>
        /// 初始化数组
        /// </summary>
        private void InitArray()
        {
            controls = new Nurse.ucWorkTemplet[7];
            controls[0] = this.ucWorkTemplet1;
            controls[1] = this.ucWorkTemplet2;
            controls[2] = this.ucWorkTemplet3;
            controls[3] = this.ucWorkTemplet4;
            controls[4] = this.ucWorkTemplet5;
            controls[5] = this.ucWorkTemplet6;
            controls[6] = this.ucWorkTemplet7;
        }

        /// <summary>
        /// 初始化模板控间
        /// </summary>
        private void InitControls()
        {
            Nurse.ucWorkTemplet obj;

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
        /// 初始化工具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("增加(+)", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            this.toolBarService.AddToolButton("删除(-)", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            this.toolBarService.AddToolButton("全部删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);

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
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

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
            
            //第二层为人员列表层
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
            this.controls[Index].Query(this.deptCode);
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
                cmbEmp_SelectedIndexChanged(sender,e);
            }
        }
        #endregion

        #endregion

        #region 增、删、改、打印、查找、导出操作

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

        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            int Index = this.neuTabControl1.SelectedIndex;

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

        #endregion

        #region delete method

        //private void baseTreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        //{
        //    int Index = this.neuTabControl1.SelectedIndex;
        //    Index++;

        //    if (Index == 7) Index = 0;

        //    if (controls[Index].IsChange())
        //    {
        //        if (MessageBox.Show("数据已经改变,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //        {
        //            if (controls[Index].Save() == -1)
        //            {
        //                e.Cancel = true;
        //                controls[Index].Focus();
        //            }
        //        }
        //    }

        //}

        #endregion

    }
}
