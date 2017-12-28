using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 科室列表显示控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public partial class tvDeptTree : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvDeptTree()
        {
            InitializeComponent();

            try
            {
                this.InitTree();
            }
            catch
            { }
        }

        public tvDeptTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            try
            {
                this.InitTree( );
            }
            catch
            { }
        }

        #region 域变量

        /// <summary>
        /// 是否显示根节点
        /// </summary>
        bool isShowRoot = true;

        /// <summary>
        /// 是否显示药房
        /// </summary>
        bool isShowP = true;

        /// <summary>
        /// 是否显示药库
        /// </summary>
        bool isShowPI = true;

        /// <summary>
        /// 是否对节点自动展开
        /// </summary>
        bool autoExpand = true;

        /// <summary>
        /// 药房列表
        /// </summary>
        List<Neusoft.HISFC.Models.Base.Department> pList = null;

        /// <summary>
        /// 药库列表
        /// </summary>
        List<Neusoft.HISFC.Models.Base.Department> piList = null;

        /// <summary>
        /// 药库大类编码
        /// </summary>
        private string piStatCode = "S001";

        /// <summary>
        /// 药房大类编码
        /// </summary>
        private string pStatCode = "S002";

        /// <summary>
        /// 是否使用科室结构树显示
        /// </summary>
        private bool isUseDeptStruct = false;
        #endregion

        #region 属性

        /// <summary>
        /// 是否显示根节点(药房、药库根节点)
        /// </summary>
        [Description("加载树列表时 是否显示药房、药库根节点"),Category("设置"),DefaultValue(true)]
        public bool IsShowRoot
        {
            get
            {
                return this.isShowRoot;
            }
            set
            {
                this.isShowRoot = value;

                this.InitTree();
            }
        }

        /// <summary>
        /// 是否显示药房
        /// </summary>
        [Description("加载列表时 是否加载药房列表"),Category("设置"),DefaultValue(true)]
        public bool IsShowP
        {
            get
            {
                return this.isShowP;
            }
            set
            {
                this.isShowP = value;

                this.InitTree();
            }
        }

        /// <summary>
        /// 是否显示药库
        /// </summary>
        [Description("加载列表时 是否加载药库列表"),Category("设置"),DefaultValue(true)]
        public bool IsShowPI
        {
            get
            {
                return this.isShowPI;
            }
            set
            {
                this.isShowPI = value;

                this.InitTree();
            }
        }

        /// <summary>
        /// 是否对节点自动展开
        /// </summary>
        [Description("列表加载后 是否对各级节点自动展开"),Category("设置"),DefaultValue(true)]
        public bool AutoExpand
        {
            get
            {
                return this.autoExpand;
            }
            set
            {
                this.autoExpand = value;

                this.InitTree();
            }
        }

        /// <summary>
        /// 药库大类编码
        /// </summary>
        [Description("科室结构中维护的药库大类编码，默认为S001"), Category("设置"), DefaultValue("S001")]
        public string PIStatCode
        {
            get
            {
                return this.piStatCode;
            }
            set
            {
                this.piStatCode = value;
            }
        }

        /// <summary>
        /// 药房大类编码
        /// </summary>
        [Description("科室结构中维护的药房大类编码，默认为S002"), Category("设置"), DefaultValue("S002")]
        public string PStatCode
        {
            get
            {
                return this.pStatCode;
            }
            set
            {
                this.pStatCode = value;
            }
        }

        /// <summary>
        /// 是否使用科室结构树显示
        /// </summary>
        [Description("是否使用科室结构树显示。设置为True使用科室结构显示时，需注意设置PIStatCode与PStatCode属性值"), Category("设置"), DefaultValue(false)]
        public bool IsUseDeptStruct
        {
            get
            {
                return this.isUseDeptStruct;
            }
            set
            {
                this.isUseDeptStruct = value;
            }
        }
        #endregion

        /// <summary>
        /// 获取或设置所选中的节点
        /// </summary>
        public List<Neusoft.HISFC.Models.Base.Department> SelectNodes
        {
            get
            {
                List<Neusoft.HISFC.Models.Base.Department> selectNodes = new List<Neusoft.HISFC.Models.Base.Department>();
                foreach (TreeNode node in this.Nodes)
                {
                    if (this.IsShowRoot)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.Checked)
                            {
                                selectNodes.Add(childNode.Tag as Neusoft.HISFC.Models.Base.Department);
                            }
                        }
                    }
                    else
                    {
                        if (node.Checked)
                            selectNodes.Add(node.Tag as Neusoft.HISFC.Models.Base.Department);
                    }
                }

                return selectNodes;
            }
        }

        /// <summary>
        /// 科室列表数据加载
        /// </summary>
        /// <returns>数据加载成功返回1 加载存在错误返回-1</returns>
        protected virtual int InitDept()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManagment = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList deptList = deptManagment.GetDeptmentAll();
            if (deptList == null)
            {
                System.Windows.Forms.MessageBox.Show("获取科室数据发生错误" + deptManagment.Err);
                return 1;
            }

            System.Collections.Hashtable hsDeptList = new Hashtable();

            pList = new List<Neusoft.HISFC.Models.Base.Department>();
            piList = new List<Neusoft.HISFC.Models.Base.Department>();

            #region 按照科室类型加载

            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                hsDeptList.Add(dept.ID, dept);

                if (dept.DeptType.ID.ToString() == Neusoft.HISFC.Models.Base.EnumDepartmentType.P.ToString())
                {
                    pList.Add(dept);
                    continue;
                }
                if (dept.DeptType.ID.ToString() == Neusoft.HISFC.Models.Base.EnumDepartmentType.PI.ToString())
                {
                    piList.Add(dept);
                    continue;
                }
            }

            #endregion

            //使用科室结构树显示时，代码继续执行。否则返回
            if (!this.isUseDeptStruct)
            {
                return 0;
            }


            #region 按照科室结构加载

            pList.Clear();
            piList.Clear();

            //创建科室分类等级树，返回一级节点列表
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager statMgr = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();            
            ArrayList deptStruct = statMgr.LoadLevelViewDepartemt("03");
            if (deptStruct == null)
            {
                System.Windows.Forms.MessageBox.Show("获取科室结构数据发生错误" + deptManagment.Err);
                return 1;
            }
            foreach (Neusoft.HISFC.Models.Base.DepartmentStat info in deptStruct)
            {
                if (info.DeptCode == this.piStatCode)       //加载大类药库
                {
                    foreach (Neusoft.HISFC.Models.Base.DepartmentStat piInfo in info.Childs)
                    {
                        if (hsDeptList.ContainsKey(piInfo.DeptCode))
                        {
                            piList.Add(hsDeptList[piInfo.ID] as Neusoft.HISFC.Models.Base.Department);
                        }
                    }
                }
                if (info.DeptCode == this.pStatCode)        //加载大类药房
                {
                    foreach (Neusoft.HISFC.Models.Base.DepartmentStat pInfo in info.Childs)
                    {
                        if (hsDeptList.ContainsKey(pInfo.DeptCode))
                        {
                            pList.Add(hsDeptList[pInfo.ID] as Neusoft.HISFC.Models.Base.Department);
                        }
                    }
                }
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 根据科室数据 加载树型列表
        /// </summary>
        /// <returns>成功加载返回1 失败返回-1</returns>
        protected virtual int InitTree()
        {
            if (this.DesignMode)
                return 1;

            this.ImageList = this.deptImageList;

            if (this.pList == null || this.piList == null)
            {
                if (this.InitDept() == -1)
                    return -1;
            }

            this.SuspendLayout();

            this.Nodes.Clear();

            TreeNode pRootNode = new TreeNode("药房", 0, 0);
            TreeNode piRootNode = new TreeNode("药库", 0, 0);

            if (this.isShowRoot)
            {
                if (this.isShowP)
                    this.Nodes.Add(pRootNode);
                if (this.isShowPI)
                    this.Nodes.Add(piRootNode);
            }
            if (this.isShowP)
            {
                foreach (Neusoft.HISFC.Models.Base.Department dept in pList)
                {
                    TreeNode node = new TreeNode(dept.Name);
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;

                    node.Tag = dept;
                    if (this.isShowRoot)
                        pRootNode.Nodes.Add(node);
                    else
                        this.Nodes.Add(node);
                }
            }
            if (this.IsShowPI)
            {
                foreach (Neusoft.HISFC.Models.Base.Department dept in piList)
                {
                    TreeNode node = new TreeNode(dept.Name);
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;

                    node.Tag = dept;
                    if (this.isShowPI)
                        piRootNode.Nodes.Add(node);
                    else
                        piRootNode.Nodes.Add(node);
                }
            }

            if (this.AutoExpand)
                this.ExpandAll();

            this.ResumeLayout();

            return 1;
        }

        /// <summary>
        /// 数据重置
        /// </summary>
        /// <returns></returns>
        public virtual int Reset()
        {
            this.InitDept();

            this.InitTree();

            return 1;
        }

        /// <summary>
        /// 选中根节点时 对所有子节点选中 
        /// </summary>
        /// <param name="e">Select事件信息</param>
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            if (this.CheckBoxes)
            {
                if (e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
            }
            base.OnAfterSelect(e);
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (this.CheckBoxes)
            {
                if (e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        node.Checked = e.Node.Checked;
                    }
                }
            }
            base.OnAfterCheck(e);
        }


    }
}
