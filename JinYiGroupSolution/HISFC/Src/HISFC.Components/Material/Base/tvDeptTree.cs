using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>
    /// [功能描述: 物资科室列表显示控件]
    /// [创 建 者: 王维]
    /// [创建时间: 2008-03-16]
    /// </summary>
    public partial class tvDeptTree1 : Common.Controls.baseTreeView
    {
        public tvDeptTree1()
        {
            InitializeComponent();
        }

        public tvDeptTree1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            try
            {
                this.InitTree();
            }
            catch
            { }
        }

        /// <summary>
        /// 获取或设置所选中的节点
        /// </summary>
        public List<Neusoft.HISFC.Models.Material.MaterialStorage> SelectNodes
        {
            get
            {
                List<Neusoft.HISFC.Models.Material.MaterialStorage> selectNodes = new List<Neusoft.HISFC.Models.Material.MaterialStorage>();
                foreach (TreeNode node in this.Nodes)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            selectNodes.Add(childNode.Tag as Neusoft.HISFC.Models.Material.MaterialStorage);
                        }
                    }
                }
                return selectNodes;
            }
        }

        /// <summary>
        /// 物资仓库
        /// </summary>
        private ArrayList deptList;

        /// <summary>
        /// 科室列表数据加载
        /// </summary>
        /// <returns>数据加载成功返回1 加载存在错误返回-1</returns>
        protected virtual int InitDept()
        {
            Neusoft.HISFC.BizLogic.Material.Baseset matDeptManagment = new Neusoft.HISFC.BizLogic.Material.Baseset();
            deptList = matDeptManagment.GetStorageInfo("A", "A", "1", "A");
            if (deptList == null)
            {
                MessageBox.Show("获取科室数据发生错误" + matDeptManagment.Err);
                return -1;
            }

            Hashtable hsDeptList = new Hashtable();

            foreach (Neusoft.HISFC.Models.Material.MaterialStorage dept in deptList)
            {
                hsDeptList.Add(dept.ID, dept);
            }

            return 1;
        }

        /// <summary>
        /// 根据科室数据 加载树型列表
        /// </summary>
        /// <returns>成功加载返回1 失败返回-1</returns>
        protected virtual int InitTree()
        {
            if (this.DesignMode)
            {
                return 1;
            }
            this.ImageList = this.deptImageList;

            if (this.InitDept() == -1)
            {
                return -1;
            }

            this.SuspendLayout();

            this.Nodes.Clear();

            TreeNode mRootNode = new TreeNode("物资仓库", 0, 0);

            this.Nodes.Add(mRootNode);

            foreach (Neusoft.HISFC.Models.Material.MaterialStorage dept in deptList)
            {
                TreeNode node = new TreeNode(dept.Name);
                node.ImageIndex = 4;
                node.StateImageIndex = 5;

                node.Tag = dept;
                mRootNode.Nodes.Add(node);
            }

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