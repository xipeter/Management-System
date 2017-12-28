using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucMaterialKindTree的摘要说明。<br></br>
    /// [功能描述: 物资信息查询]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-03-28<br></br>
    /// </summary>
    public partial class ucMaterialKindTree : UserControl
    {
        public ucMaterialKindTree()
        {
            InitializeComponent();
        }

        private string filter;

        private string nodeName;

        public string storagecode;

        private Neusoft.HISFC.BizLogic.Material.Baseset matBase = new Neusoft.HISFC.BizLogic.Material.Baseset();

        public string NodeTag
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
            }
        }

        public string NodeName
        {
            get
            {
                return this.nodeName;
            }
            set
            {
                this.nodeName = value;
            }
        }

        public delegate void GetLevelAndKind(object sender, System.Windows.Forms.TreeViewEventArgs e);

        public event GetLevelAndKind GetLak;

        #region 初始化树形控件

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
                al = this.matBase.GetMetKindByPreID(preID);
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

                    if (!materialKind.EndGrade)
                    {
                        this.InsertNode(kindTree, materialKind.ID);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("添加节点失败：" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        public void InitTreeView()
        {
            this.neuTreeView1.ImageList = this.neuTreeView1.groupImageList;

            this.neuTreeView1.Nodes.Clear();
            TreeNode title = new TreeNode("全部科目信息", 1, 2);
            title.ImageIndex = 4;

            title.Tag = "0";

            //添加根节点
            this.neuTreeView1.Nodes.Add(title);

            ArrayList al = new ArrayList();

            try
            {
                //取默认一级科目
                al = this.matBase.GetMetKindByPreID("0");
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
            catch (Exception e)
            {
                MessageBox.Show("初始化科目树失败：" + e.Message);
                return;
            }

            this.neuTreeView1.ExpandAll();
        }

        #endregion

        private void ucMaterialKindTree_Load(object sender, System.EventArgs e)
        {
            this.InitTreeView();
        }

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //设置过滤条件
            this.filter = e.Node.Tag.ToString();
            this.nodeName = e.Node.Text;

            this.GetLak(sender, e);

        }

    }
}
