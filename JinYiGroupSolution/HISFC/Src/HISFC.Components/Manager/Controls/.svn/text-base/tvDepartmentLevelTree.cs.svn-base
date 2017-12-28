using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Neusoft.HISFC.Models.Base;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 程序中TreeView类]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－11－27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class tvDepartmentLevelTree :System.Windows.Forms.TreeView
    {
        #region 字段
        private System.Collections.Hashtable hashTable = new System.Collections.Hashtable();

        /// <summary>
        /// 科室名称集合  {31FD985A-A165-4812-8CBE-CA2E2C7B9A7B}
        /// </summary>
        private Dictionary<string, string> deptNameDictionary = new Dictionary<string, string>();
        #endregion

        /// <summary>
        /// 加载当前结点科室
        /// </summary>
        public DepartmentStat departmentStat
        {
            get 
            {
                if (this.SelectedNode.Tag.GetType() == typeof(DepartmentStat))
                {
                    return (DepartmentStat)this.SelectedNode.Tag;
                }
                else
                {
                    
                    return null;
                }
            }
        }

        /// <summary>
        /// 取全部科室列表
        /// </summary>
        public void BeforeLoad(string statCode)
        {
            try
            {
                Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager statMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
                //创建科室分类等级树，返回一级节点列表
                ArrayList depts = statMgr.LoadLevelViewDepartemt(statCode);
                foreach (Neusoft.HISFC.Models.Base.DepartmentStat info in depts)
                {
                    hashTable.Add(info.PkID, info);
                }

                //{31FD985A-A165-4812-8CBE-CA2E2C7B9A7B}  加载科室编码、名称对照字典
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptAllUserStopDisuse();
                if (alDept != null)
                {
                    this.deptNameDictionary = new Dictionary<string, string>();
                    foreach (Neusoft.HISFC.Models.Base.Department info in alDept)
                    {
                        this.deptNameDictionary.Add(info.ID, info.Name);
                    }
                }

                //在TreeView总显示科室信息
                AddView(statCode);
            }
            catch { }
        }


        /// <summary>
        /// 根据参数，在树型控件中显示可维护的科室分类和科室节点
        /// </summary>
        /// <param name="statCode">参数</param>
        private void AddView(string statCode)
        {
            //取可维护的大类，显示在树型控件的根节点。
            Neusoft.HISFC.BizLogic.Manager.PowerLevel1Manager class1 = new Neusoft.HISFC.BizLogic.Manager.PowerLevel1Manager();
            ArrayList al = class1.LoadLevel1Available(statCode);
            if (al.Count == 0) return;

            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass1 info in al)
            {
                TreeNode node = this.Nodes.Add(info.Name);
                node.Text = info.Class1Name;
                node.ToolTipText = info.Class1Name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                node.Tag = info.Class1Code;
            }

            //找到一级节点的所属分类，并添加到分类下的节点中
            foreach (Neusoft.HISFC.Models.Base.DepartmentStat stat in hashTable.Values)
            {

                TreeNode parentnode = SearchParentNode(stat);

                //{31FD985A-A165-4812-8CBE-CA2E2C7B9A7B}  更新科室名称
                if (this.deptNameDictionary.ContainsKey(stat.DeptCode))
                {
                    stat.DeptName = this.deptNameDictionary[stat.DeptCode];
                }

                TreeNode statNode = new TreeNode(stat.DeptName);
                statNode.Text = stat.DeptName;
                if (stat.NodeKind == 0)
                    statNode.ImageIndex = 1;  //分类
                else
                    statNode.ImageIndex = 2; //科室

                statNode.SelectedImageIndex = statNode.ImageIndex;
                statNode.Tag = stat;
                parentnode.Nodes.Add(statNode);
                //根据父级节点和父级科室，在树型控件中递归显示其子节点
                AddStatNode(statNode, stat);
            }
        }


        /// <summary>
        /// 根据父级节点和父级科室，在树型控件中递归显示其子节点
        /// </summary>
        /// <param name="statNode">父级节点位置</param>
        /// <param name="stat">父级科室</param>
        private void AddStatNode(TreeNode statNode, Neusoft.HISFC.Models.Base.DepartmentStat stat)
        {
            if (stat.Childs.Count > 0)
            {
                //将所有儿子节点显示在树型控件中
                foreach (Neusoft.HISFC.Models.Base.DepartmentStat child in stat.Childs)
                {
                    //{31FD985A-A165-4812-8CBE-CA2E2C7B9A7B}  更新科室名称
                    if (this.deptNameDictionary.ContainsKey(child.DeptCode))
                    {
                        child.DeptName = this.deptNameDictionary[child.DeptCode];
                    }

                    TreeNode node = new TreeNode(child.DeptName);
                    node.Text = child.DeptName;
                    node.ToolTipText = child.DeptName;
                    if (child.NodeKind == 0)
                        node.ImageIndex = 1;  //分类
                    else
                        node.ImageIndex = 2; //科室
                    node.SelectedImageIndex = node.ImageIndex;

                    node.Tag = child;
                    statNode.Nodes.Add(node);
                    //插入完本节点后，继续找其子节点
                    AddStatNode(node, child);
                }
            }
        }


        /// <summary>
        /// 根据传入的科室实体，找出其所属分类
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        private TreeNode SearchParentNode(Neusoft.HISFC.Models.Base.DepartmentStat stat)
        {
            //在一级节点中找科室的所属分类
            foreach (TreeNode node in this.Nodes)
            {
                if (node.Tag.ToString() == stat.StatCode)
                {
                    return node;
                }
            }

            //如果在一级节点中找不到科室的所属分类，则增加一个统计分类
            TreeNode statnode = new TreeNode(stat.StatCode);
            statnode.Tag = stat.StatCode;
            statnode.Text = stat.StatCode;
            statnode.ToolTipText = stat.StatCode;
            this.Nodes.Add(statnode);
            return statnode;
        }


        /// <summary>
        /// 根据父级节点和父级科室，在树型控件中插入一个新的子节点
        /// </summary>
        /// <param name="node">父级节点</param>
        /// <param name="dept">父级科室</param>
        public void AddDepartment(TreeNode node, Neusoft.HISFC.Models.Base.DepartmentStat dept)
        {
            //将添加的节点显示在TreeView中
            TreeNode deptNode = new TreeNode(dept.DeptName);
            deptNode.Text = dept.DeptName;
            if (dept.NodeKind == 0)
                deptNode.ImageIndex = 1;  //分类
            else
                deptNode.ImageIndex = 2; //科室

            deptNode.SelectedImageIndex = deptNode.ImageIndex;
            deptNode.Tag = dept;
            node.Nodes.Add(deptNode);

            //将此科室付与其父级科室的Childs属性。
            Neusoft.HISFC.Models.Base.DepartmentStat parentDept = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
            if (parentDept != null)
            {
                parentDept.Childs.Add(dept);
            }

        }


        /// <summary>
        /// 要插入的子节点插入在父级节点下
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        /// <param name="node">要插入的节点</param>
        public void AddDepartment(TreeNode parentNode, TreeNode node)
        {
            //在父级节点中插入子节点
            parentNode.Nodes.Add(node);
            //将父级节点转换成科室。
            Neusoft.HISFC.Models.Base.DepartmentStat parentDept = parentNode.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
            if (parentDept != null)
            {
                Neusoft.HISFC.Models.Base.DepartmentStat dept = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                parentDept.Childs.Add(dept);
            }
            //选中当前节点
            this.SelectedNode = node;
        }


        /// <summary>
        /// 删除传入的节点
        /// </summary>
        /// <param name="node">待删除的节点</param>
        public void DelDepartment(TreeNode node)
        {
            try
            {
                //将此科室从其父级科室的Childs属性中删除。
                Neusoft.HISFC.Models.Base.DepartmentStat parentDept = node.Parent.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                //将节点删除
                node.Remove();
                if (parentDept != null)
                {
                    //取本级科室信息
                    Neusoft.HISFC.Models.Base.DepartmentStat dept = node.Tag as Neusoft.HISFC.Models.Base.DepartmentStat;
                    parentDept.Childs.Remove(dept);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        public tvDepartmentLevelTree()
        {
            InitializeComponent();
        }

        public tvDepartmentLevelTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
