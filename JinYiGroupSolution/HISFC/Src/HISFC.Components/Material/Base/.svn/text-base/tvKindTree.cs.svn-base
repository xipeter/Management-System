using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>
    /// [功能描述: 物资类别树]
    /// [创 建 者: 王维]
    /// [创建时间: 2008-03-16]
    /// </summary>
    public partial class tvKindTree1 : Common.Controls.baseTreeView
    {
        public tvKindTree1()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.BizLogic.Material.Baseset matBase = new Neusoft.HISFC.BizLogic.Material.Baseset();

        public tvKindTree1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            try
            {
                this.InitTreeView();
            }
            catch
            { }
        }

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        public void InitTreeView()
        {
            if (this.DesignMode)
            {
                return;
            }

            this.ImageList = this.groupImageList;
            this.SuspendLayout();
            this.Nodes.Clear();

            TreeNode title = new TreeNode("全部科目信息", 1, 2);

            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;

            title.Tag = "0";
            this.Nodes.Add(title);

            ArrayList al = new ArrayList();

            try
            {
                //取默认一级科目
                al = this.matBase.QueryKindAllByPreID("0");
                if (al == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载物资科室信息发生错误") + this.matBase.Err);
                    return;
                }
                if (al.Count > 0)
                {
                    //添加子节点
                    this.InsertNode(title, "0");
                }
            }
            catch { }
        }

        /// <summary>
        /// 添加TreeView的节点信息
        /// </summary>
        /// <param name="preID">上级科目编码</param>
        /// <param name="curNode">上级节点</param>
        public void InsertNode(System.Windows.Forms.TreeNode node, string preID)
        {
            ArrayList al = new ArrayList();

            try
            {
                //取子节点信息
                al = this.matBase.QueryKindAllByPreID(preID);
                if (al == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载物资科室信息发生错误") + this.matBase.Err);
                    return;
                }

                if (al.Count <= 0)
                {
                    return;
                }

                //添加子节点信息
                foreach (Neusoft.HISFC.Models.Material.MaterialKind materialKind in al)
                {

                    TreeNode kindTree = new TreeNode(materialKind.Name, 2, 1);

                    kindTree.ImageIndex = 0;
                    kindTree.SelectedImageIndex = 0;

                    kindTree.Tag = materialKind.ID;

                    node.Nodes.Add(kindTree);

                    if (materialKind.EndGrade)
                    {
                        this.InsertNode(kindTree, materialKind.ID);
                    }

                }
            }
            catch { }
        }

        /// <summary>
        /// 数据重置
        /// </summary>
        /// <returns></returns>
        public virtual int Reset()
        {
            this.InitTreeView();

            return 1;
        }

        /// <summary>
        /// 遍历当前节点的所有子节点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (this.CheckBoxes)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        if (node.Checked != e.Node.Checked)
                        {
                            node.Checked = e.Node.Checked;
                        }
                    }
                }
            }
            base.OnAfterCheck(e);
        }

    }
}
