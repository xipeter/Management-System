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
    /// [功能描述: 科室结构维护类]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－11－27]<br></br>
    /// 
    /// 说明：在Load方法中传入的Tag及为以后生成树的条件
    /// 在系统组维护中设置 各个模块窗体调用传递的Tag
    /// Tag的设置 可根据com_priv_class1 下的Class1_Code进行设置
    /// 如： Tag.toString()="@@"的时候及显示全部根结点
    ///      Tag.toString()="03"的时候显示药库权限管理结点
    ///     若Tag.toString()=""则不显示
    /// 
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDepartmentLevel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        
        public ucDepartmentLevel()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 用于在加科室时判断该该科室在本结构中是否已经存在
        /// </summary>
        bool bl = true;
        #endregion

        #region 属性 控制维护权限  {EC44E3F9-B8A9-4a85-8781-B92A7AEEE041}  通过一级权限设置 实现权限分离

        /// <summary>
        /// 一级权限码
        /// </summary>
        private string class1PrivCode = "@@";

        /// <summary>
        /// 一级权限码
        /// </summary>
        public string Class1PrivCode
        {
            get
            {
                return this.class1PrivCode;
            }
            set
            {
                this.class1PrivCode = value;
            }
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
           
            //增加工具栏
            this.toolBarService.AddToolButton("上级科室", "上级科室",0, true, false, null);
            this.toolBarService.AddToolButton("属性", "属性", 1, true, false, null);
            this.toolBarService.AddToolButton("删除", "删除", 2, true, false, null);
            this.toolBarService.AddToolButton("查找", "查找", 2, true, false, null);
            return this.toolBarService;
        }
        #endregion


        #region 重写已有按钮事件
        public override int Exit(object sender, object neuObject)
        {
            return base.Exit(sender, neuObject);
        }
        #endregion


        #region 工具栏增加按钮单击事件

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "上级科室":
                    if (this.tvDepartmentLevelTree1.SelectedNode.Parent != null)
                        this.tvDepartmentLevelTree1.SelectedNode = this.tvDepartmentLevelTree1.SelectedNode.Parent;
                    break;
                case "删除":
                    this.DelDepartment();
                    break;
                case "属性":
                    this.Property(true);
                    break;
                case "查找":
                    SearchTree();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void SearchTree()
        {
            Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
            frm.Init(tvDepartmentLevelTree1);
            frm.ShowDialog();
        }
    #endregion

        #region  将树型控件当前被选中节点的儿子节点（用户）显示在listView中
        /// <summary>
        /// 将树型控件当前被选中节点的儿子节点（用户）显示在listView中
        /// </summary>
        private void ShowListUser()
        {
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            Neusoft.HISFC.Models.Base.DepartmentStat dept = new Neusoft.HISFC.Models.Base.DepartmentStat();
            ParentNodeStat(this.tvDepartmentLevelTree1.SelectedNode, ref dept);
            System.Collections.ArrayList al = userManager.LoadUser(dept.StatCode, dept.PardepCode);
            foreach (Neusoft.HISFC.Models.Admin.UserPowerDetail info in al)
            {
                ListViewItem item = this.neuListView1.Items.Add(info.User.Name);
                item.Tag = info;
                if (info.User01 == "F")
                {
                    item.ImageIndex = 3;
                    item.StateImageIndex = 3;
                }
                else
                {
                    item.ImageIndex = 2;
                    item.StateImageIndex = 2;
                }
            }
        }
        #endregion

        #region 根据传入的节点，查找其根节点的所属大类编码
        /// <summary>
        /// 根据传入的节点，查找其根节点的所属大类编码
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void ParentNodeStat(TreeNode node, ref Neusoft.HISFC.Models.Base.DepartmentStat dept)
        {
            if (dept == null) dept = new Neusoft.HISFC.Models.Base.DepartmentStat();
            if (node.Parent == null)
            {
                //父级节点是统计大类时，直接取其编码
                dept.StatCode = node.Tag.ToString();  //取统计大类编码
                dept.PardepCode = "AAAA";             //取父级编码
                dept.PardepName = node.Text;          //取父级名称
                dept.GradeCode = 1;				  //取节点等级
            }
            else
            {
                //父级节点不是统计大类时，查找所属统计大类编码
                TreeNode thisNode = node;
                //找到根节点
                while (thisNode.Parent != null)
                {
                    thisNode = thisNode.Parent;
                }
                if (thisNode != null)
                    dept.StatCode = thisNode.Tag.ToString();
                else
                    dept.StatCode = "0000";

                Neusoft.HISFC.Models.Base.DepartmentStat parentStat = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                if (parentStat == null)
                {
                    MessageBox.Show("取科室" + dept.DeptName + "的父级科室时出错。", "保存失败");
                    return;
                }
                dept.PardepCode = parentStat.DeptCode;      //取父级编码
                dept.PardepName = parentStat.DeptName;      //取父级名称 
                dept.GradeCode = parentStat.GradeCode + 1; //取节点等级
            }
        }
        #endregion

        #region  显示科室或者人员的属性
        /// <summary>
        /// 显示科室或者人员的属性
        /// </summary>
        /// <param name="ShowProperty">true显示属性，false鼠标双击时显示科室的下一级内容</param>
        public void Property(bool ShowProperty)
        {
            if (this.neuListView1.SelectedItems.Count > 0 && this.neuListView1.Focused)
            {
                //假设当前节点为科室信息
                TreeNode node = this.neuListView1.SelectedItems[0].Tag as TreeNode;
                if (node == null)
                {
                    //人员属性修改
                    this.UserProperty();
                }
                else
                {
                    //ShowProperty   true显示属性，false鼠标双击时显示科室的下一级内容
                    if (ShowProperty)
                    {
                        //显示科室属性
                        this.DeptProperty();
                    }
                    else
                    {
                        //显示选中科室的下一级内容。
                        this.tvDepartmentLevelTree1.SelectedNode = node;
                    }
                }
            }
            else
            {
                if (this.tvDepartmentLevelTree1.SelectedNode != null && this.tvDepartmentLevelTree1.SelectedNode.Parent != null)
                {
                    //显示科室属性
                    this.DeptProperty();
                }
            }
        }
        #endregion

        #region 添加人员
        /// <summary>
        /// 添加人员
        /// </summary>
        public void AddUser()
        {
            //不可以在大类下及根结点下增加人员
            if (this.tvDepartmentLevelTree1.SelectedNode.Parent == null) return;

            //取得当前TreeView中的科室信息
            Neusoft.HISFC.Models.Base.DepartmentStat dept = this.tvDepartmentLevelTree1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;

            //取得当前ListView中要修改的人员数据
            //人员权限明细实体类
            Neusoft.HISFC.Models.Admin.UserPowerDetail userPower = new Neusoft.HISFC.Models.Admin.UserPowerDetail();

            userPower.Dept.ID = dept.DeptCode;
            userPower.Dept.Name = dept.DeptName;
            userPower.Class1Code = dept.StatCode;
            userPower.GrantDept = dept.DeptCode;
            if (dept != null)
            {
                Manager.Controls.ucPrivUserManager userManager = new Manager.Controls.ucPrivUserManager(userPower);
                //创建临时窗口用来修改数据
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "人员属性";
                DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(userManager);
                //取窗口返回参数
                if (dlg == DialogResult.OK)
                    //显示当前TreeView中选中节点的下级内容
                    this.ShowList();
            }
        }
        #endregion

        #region 人员属性
        /// <summary>
        /// 人员属性
        /// </summary>
        public void UserProperty()
        {
            //取得当前TreeView中的科室信息
            Neusoft.HISFC.Models.Base.DepartmentStat dept = this.tvDepartmentLevelTree1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
            //取得当前ListView中要修改的人员数据
            Neusoft.HISFC.Models.Admin.UserPowerDetail userPower = this.neuListView1.SelectedItems[0].Tag as Neusoft.HISFC.Models.Admin.UserPowerDetail;
            userPower.Dept.ID = dept.DeptCode;//科室编码
            userPower.Dept.Name = dept.DeptName;//科室名称
            userPower.GrantDept = dept.DeptCode;
            if (dept != null)
            {

                Manager.Controls.ucPrivUserManager userManager = new Manager.Controls.ucPrivUserManager(userPower);
                //创建临时窗口用来修改数据
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "人员属性";
                DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(userManager);
                //取窗口返回参数
                if (dlg == DialogResult.OK)
                {
                    //更新ListView中科室的名称
                    //this.lvInfo.SelectedItems[0].Text = userPower.User.Name;
                    //显示当前TreeView中选中节点的下级内容
                    this.ShowList();
                }
            }
        }
        #endregion

        #region 添加科室
        /// <summary>
        /// 添加科室
        /// </summary>
        public void AddDepartment()
        {
            //创建新增科室
            Neusoft.HISFC.Models.Base.DepartmentStat dept = new Neusoft.HISFC.Models.Base.DepartmentStat();

            //取新增节点的统计大类编码、父级编码、父级名称		
            ParentNodeStat(this.tvDepartmentLevelTree1.SelectedNode, ref dept);

            //新增节点为叶子节点。
            dept.NodeKind = 1;
                      
            ucDepartmentStat deptLevel = new ucDepartmentStat(dept);

            //定义事件(用于判断是否增加的是本科室)路志鹏,2007-4-11
            ucDepartmentStat.DoCheckNode += new ucDepartmentStat.CheckHander(ucDepartmentStat_DoCheckNode);
            
            //创建临时窗口用来修改数据
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "科室属性";
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(deptLevel);
            if (dlg == DialogResult.OK)
            {
                this.tvDepartmentLevelTree1.AddDepartment(this.tvDepartmentLevelTree1.SelectedNode, dept);
                //显示当前TreeView中选中节点的下级内容
                this.ShowList();
            }
            ucDepartmentStat.DoCheckNode -= new ucDepartmentStat.CheckHander(ucDepartmentStat_DoCheckNode);
        }
        #endregion

        #region 删除当前ListView中选中的科室
        /// <summary>
        /// 删除当前ListView中选中的科室
        /// </summary>
        public void DelDepartment()
        {
            //取得当前ListView中要修改的科室数据信息
            TreeNode node = this.neuListView1.SelectedItems[0].Tag as TreeNode;
            //只能删除科室数据
            if (node == null) return;

            //取要删除的科室信息
            Neusoft.HISFC.Models.Base.DepartmentStat dept = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
            if (dept != null)
            {
                if (dept.Childs.Count > 0)
                {
                    MessageBox.Show("此科室有下级科室，不允许删除。\n请先删除下级科室。", "删除无法进行", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //取此科室下级人员信息，如果存在人员则不允许删除。
               Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager userMgr = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
                ArrayList al = userMgr.LoadUser(dept.StatCode, dept.DeptCode);
                if (al == null)
                {
                    MessageBox.Show("取人员信息时出错:" + userMgr.Err);
                    return;
                }

                if (al.Count > 0)
                {
                    MessageBox.Show("此科室有下级人员，不允许删除。\n请先删除下级人员。", "删除无法进行", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("确定要把科室“" + dept.DeptName + "”删除吗？", "确认科室删除", MessageBoxButtons.YesNo) == DialogResult.No) return;

                //定义管理类，删除科室

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(deptStatMgr.Connection);
                //trans.BeginTransaction();
                //deptStatMgr.SetTrans(trans.Trans);
                try
                {

                    //删除一个科室数据
                    int parm = deptStatMgr.Delete(dept.StatCode, dept.DeptCode);
                    if (parm != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show("数据保存失败:" + deptStatMgr.Err);
                        return;
                    }
                }
                catch (Exception e)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("数据保存失败！" + e.Message, "提示");
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                //MessageBox.Show("数据保存失败！" + e.Message,"提示");
            }

            //在TreeView中移除被删掉的节点
            this.tvDepartmentLevelTree1.DelDepartment(node);

            //显示当前TreeView中选中节点的下级内容
            this.ShowList();
        }
        #endregion
        
        #region 修改科室属性
        /// <summary>
        /// 修改科室属性
        /// </summary>
        public void DeptProperty()
        {
            //判断修改的科室是否是树上的
            //当ListView中选中项目时，查看其ListView中选中项目的属性
            Neusoft.HISFC.Models.Base.DepartmentStat dept = null;
            if (this.neuListView1.SelectedItems.Count > 0 && this.neuListView1.Focused)
            {
                //取得当前ListView中要修改的科室数据信息
                dept = ((TreeNode)this.neuListView1.SelectedItems[0].Tag).Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
              
            }
            else
            {
                //当ListView中没有选中项目时，如果TreeView中选中了项目并且不是统计大类，则允许查看TreeView中节点的属性
                if (this.tvDepartmentLevelTree1.SelectedNode != null && this.tvDepartmentLevelTree1.SelectedNode.Parent != null)
                {
                    dept = this.tvDepartmentLevelTree1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                }
            }
            if (dept != null)
            {
                string s=dept.StatCode.ToString();
                #region 麻烦，顺序号保存在COM_DEPTSTAT里的，不是com_department的，但是取呢却是取com_department里的，先这么简单的取取吧
                //{9E9F36B8-74B0-482b-A5D4-7E3C919EBAE1} wbo 2010-12-11
                if ("16" == s)//16是维护挂号科室顺序的
                {
                    string sql = @"select sort_id from com_deptstat d
where d.stat_code = '16'
and d.dept_code = '{0}'";
                    try
                    {
                        sql = string.Format(sql, dept.ID);
                        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                        string result = deptManager.ExecSqlReturnOne(sql);
                        if (string.IsNullOrEmpty(result))
                        {
                            //取不出来就算了
                        }
                        else
                        {
                            //应该取得出来
                            dept.SortId = Neusoft.FrameWork.Function.NConvert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    { }
                }

                #endregion
                ucDepartmentStat deptLevel = new ucDepartmentStat(dept);
                //创建临时窗口用来修改数据
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "科室属性";
                DialogResult dialogResult=Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(deptLevel);
                if (dialogResult == DialogResult.OK)
                {
                    this.ShowList();
                }
            }
            
        }

        #endregion

        #region 新加如代码用于判断加入的节点 路志鹏　2007-4-11
        private bool ucDepartmentStat_DoCheckNode(string DeptCode)
        {
            TreeNode node = this.tvDepartmentLevelTree1.SelectedNode;
           //得到本科室的跟节点
            while (true)
            {
                if (node.Parent == null)
                {
                    break;
                }
                else
                {
                    node = node.Parent;
                }
            }
            bl = true;
            return CheckNode(node, DeptCode);
        }
        /// <summary>
        /// 递归查找本节点下的所有节点的Tag是否含有CheckStr
        /// </summary>
        /// <param name="node">传入的跟节点</param>
        /// /// <param name="CheckStr">要比较的值</param>
        /// <returns></returns>
        private bool CheckNode(TreeNode node,string CheckStr)
        {
            
            foreach (TreeNode tempNode in node.Nodes)
            {
                if ((tempNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat).DeptCode == CheckStr)
                {
                    bl=false;
                }

                if (tempNode.Nodes.Count > 0)
                {
                    if (!bl) return false;
                    CheckNode(tempNode, CheckStr);
                }
            }
            return bl;
        }
        #endregion

        #region UCLoad
        /// <summary>
        /// ucLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDepartmentLevel_Load(object sender, EventArgs e)
        {
            try
            {
                //{EC44E3F9-B8A9-4a85-8781-B92A7AEEE041}  通过一级权限设置 实现权限分离
                if (string.IsNullOrEmpty(this.class1PrivCode) == true)
                {
                    tvDepartmentLevelTree1.BeforeLoad("@@");
                }
                else
                {
                    tvDepartmentLevelTree1.BeforeLoad(this.class1PrivCode);
                }
                //{EC44E3F9-B8A9-4a85-8781-B92A7AEEE041}  通过一级权限设置 实现权限分离 
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        #endregion

        #region 显示当前TreeView中选中节点的下级内容
        /// <summary>
        /// 显示当前TreeView中选中节点的下级内容
        /// </summary>
        private void ShowList()
        {
            ShowListDept();//显示科室
            ShowListUser();//显示人员

            //设置菜单和工具栏中的项目是否可用
           this.SetEnable();
       }
        #endregion

        #region 将树型控件当前被选中节点的儿子节点（科室）显示在listView中
       /// <summary>
        /// 将树型控件当前被选中节点的儿子节点（科室）显示在listView中
        /// </summary>
        private void ShowListDept()
        {
            this.neuListView1.Items.Clear();
            if (this.tvDepartmentLevelTree1.SelectedNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in this.tvDepartmentLevelTree1.SelectedNode.Nodes)
                {
                    ListViewItem item = this.neuListView1.Items.Add(node.Text);
                    item.Tag = node;
                    //根据科室节点类型，显示不同的图片
                   Neusoft.HISFC.Models.Base.DepartmentStat dept = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                    if (dept != null)
                    {
                        item.ImageIndex = dept.NodeKind;
                    }
                }
            }
        }
       #endregion


        #region 设置菜单和工具栏中的项目是否可用
        /// <summary>
        /// 设置菜单和工具栏中的项目是否可用
        /// </summary>
        private void SetEnable()
        {
            //取当前TreeView中选中的节点
            Neusoft.HISFC.Models.Base.DepartmentStat departmentStat = this.tvDepartmentLevelTree1.SelectedNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;

            //如果当前的TreeView选中的节点不是统计大类（一级节点），则根据属性判断是否可以增加人，否则不允许增加人员
            if (departmentStat != null)
            {
                Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                
                #region 根据大类权限数量来判断是否可以增加人员（路志鹏、2007-6-15）
                int resultValue = deptStatMgr.DepartMentClassCount(departmentStat.StatCode);
                if (resultValue <= 0)
                {
                    this.menuItemAddUser.Enabled = false;
                }
                else
                {
                    this.menuItemAddUser.Enabled = true;
                }
                #endregion

            }
            else
            {
                this.menuItemAddUser.Enabled = false;
            }

            //如果当前的ListView中选中了项目，则属性菜单项可用，否则不可用
            if (this.neuListView1.SelectedItems.Count > 0 && this.neuListView1.Focused)
            {
                //当ListView中选中项目时，允许查看其属性
                this.menuItemProperty.Enabled = true;
                this.toolBarService.SetToolButtonEnabled("属性", true);

                //如果当前的ListView中选中了科室，则删除菜单项可用，否则不可用。人员不能在此处删除。
                Neusoft.HISFC.Models.Admin.UserPowerDetail userPower = this.neuListView1.SelectedItems[0].Tag as Neusoft.HISFC.Models.Admin.UserPowerDetail;
                if (userPower == null)
                {
                    this.menuItemDelete.Enabled = true;
                    this.toolBarService.SetToolButtonEnabled("删除", true);
                }
                else
                {
                    this.menuItemDelete.Enabled = false;
                    this.toolBarService.SetToolButtonEnabled("删除", false);
                }
            }
            else
            {
                //当ListView中没有选中项目时，如果TreeView中选中了项目则允许查看TreeView中节点的属性
                if (this.tvDepartmentLevelTree1.SelectedNode != null && this.tvDepartmentLevelTree1.SelectedNode.Parent != null)
                {
                    this.menuItemProperty.Enabled = true;
                    this.toolBarService.SetToolButtonEnabled("属性", true);
                }
                else
                {
                    this.menuItemProperty.Enabled = false;
                    this.toolBarService.SetToolButtonEnabled("属性", false);
                }
                this.menuItemDelete.Enabled = false;
                this.toolBarService.SetToolButtonEnabled("删除", false);
            }


        }
        #endregion

        /// <summary>
        /// 选择树结点后发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDepartmentLevelTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //显示当前TreeView中选中节点的下级内容
            this.ShowList();
        }
        
        /// <summary>
        /// 添加人员事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAddUser_Click(object sender, EventArgs e)
        {   
            //添加人员
            AddUser();
        }

        /// <summary>
        ///添加科室事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAddDept_Click(object sender, EventArgs e)
        { 
            //添加科室
            AddDepartment();
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            //删除科室
            this.DelDepartment();
        }

        /// <summary>
        /// 属性事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemProperty_Click(object sender, EventArgs e)
        {
            this.Property(true);
        }

        private void neuListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetEnable();
        }

        private void neuContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.SetEnable();
        }

        private void neuListView1_DoubleClick(object sender, EventArgs e)
        {
            this.Property(false);
        }
        
        private void tvDepartmentLevelTree1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode") || e.Data.GetDataPresent("System.Windows.Forms.ListViewItem"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tvDepartmentLevelTree1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.tvDepartmentLevelTree1.SelectedNode == null) return;
            Neusoft.HISFC.Models.Base.DepartmentStat dept = new Neusoft.HISFC.Models.Base.DepartmentStat();
            if (dept == null) return;
            //Control下的开始拖放操作
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvDepartmentLevelTree1_DragDrop(object sender, DragEventArgs e)
        {   
            /*该程序段变量注释！
             dragNode为【拖动】节点
             objectNode为【目标】节点
             * */
            try
            {                
                //获得进行"Drag"操作中【拖动】的节点
                TreeNode dragNode = null;
                ListViewItem item = null;
                
                //是在内部拖动
                dragNode = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
                
                //是从ListView拖动
                if (dragNode == null)
                {
                    item = e.Data.GetData("System.Windows.Forms.ListViewItem") as ListViewItem;
                    dragNode = (item.Tag) as TreeNode;
                }
                if (dragNode != null)
                { 
                    //根据窗口位置转换成TreeView位置
                    Point position = this.tvDepartmentLevelTree1.PointToClient(new Point(e.X, e.Y));
                    //根据TreeView位置取当前【目标】节点
                    TreeNode objectNode = this.tvDepartmentLevelTree1.GetNodeAt(position);
                    
                    //在目标组件中加入拖入的项目
                    if (objectNode != null)
                    {
                        //如果拖动后的位置跟拖动前的位置没变，则提示不能拖动
                        if (dragNode.Parent == objectNode)
                        {
                            MessageBox.Show("无法移动科室：源科室与目标科室相同！", "提示");
                            return;
                        }

                        //如果目标节点是拖动节点的子节点，则不允许拖动
                        if (objectNode.FullPath.IndexOf(dragNode.FullPath) > 0)
                        {
                            MessageBox.Show("无法移动科室：不能将科室移动到其下级科室中！", "提示");
                            return;
                        }

                        //更改拖动科室的父级科室编码和名称
                        Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                        Neusoft.HISFC.Models.Base.DepartmentStat parentDept = objectNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                        Neusoft.HISFC.Models.Base.DepartmentStat dept = dragNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;

                        //目标节点的统计大类编码，用于比较拖动的科室是否在同一个统计大类中
                        string statCode = "";
                    
                        //如果目标节点是统计大类（一级节点），则将大类付与拖动科室的父级
                        if (parentDept == null)
                        {
                            //取目标节点统计大类的编码
                            statCode = objectNode.Tag.ToString();

                            //只能在同一大类下进行拖动
                            if (statCode != dept.StatCode)
                            {
                                MessageBox.Show("无法移动科室：不能将科室移动到另一个科室分类中。", "提示");
                                return;
                            }
                            if (MessageBox.Show("确定要把科室" + dept.DeptName + "转到" + objectNode.Text + "下吗?", "科室转移提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                dept.PardepCode = "AAAA";
                                dept.PardepName = objectNode.Text;
                            }
                        }
                        else
                        {
                        	//取目标节点的统计大类编码
							statCode = parentDept.StatCode;

							//只能在同一大类下进行拖动
							if (statCode != dept.StatCode) 
							{
								MessageBox.Show("无法移动科室：不能将科室移动到另一个科室分类中。","提示");
								return;
							}

							if (MessageBox.Show("确定要把科室“" + dept.DeptName+ "”转到“"+parentDept.DeptName+"”下吗？" ,"科室转移提示",MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

							//如果目标节点是科室，则将科室信息付与拖动科室的父级
							dept.PardepCode = parentDept.DeptCode;
							dept.PardepName = parentDept.DeptName;

						}

						if (deptMgr.UpdateDepartmentStat(dept) != 1) 
						{
							MessageBox.Show("更新科室信息时出错:" + deptMgr.Err);
							return;
						}
						//删除拖动的节点以前的位置
						this.tvDepartmentLevelTree1.DelDepartment(dragNode);
						//在新的位置插入拖动的节点
						this.tvDepartmentLevelTree1.AddDepartment(objectNode,dragNode);
                    }
                                    
                }

            }
            catch
            { 
            }
        }
        
      

    }
}
