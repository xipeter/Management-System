using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Material.Check
{
    ///{83246F26-E161-4f5b-BC3A-ECBED5B1B3A8}
    /// <summary>
    /// [功能描述：批量盘点设置]
    /// [创 建 者：薛文进]
    /// [创建时间：2008-08-21]
    /// </summary>
    public partial class ucTypeOrQualityChoose : UserControl
    {
        public ucTypeOrQualityChoose()
        {
            InitializeComponent();
        }

        public ucTypeOrQualityChoose(bool isKindType): this()
        {
            this.IsKindType = isKindType;

            this.InitTreeView();
        }

        #region 域变量

        /// <summary>
        /// 选择的药品类别/药品性质
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> kindList = new List<Neusoft.FrameWork.Models.NeuObject>();

        /// <summary>
        /// 是否显示物资科目类别
        /// </summary>
        private bool IsKindType = true;

        /// <summary>
        /// 结果类型 0 取消 1 确认 2 全部科目
        /// </summary>
        private string resultFlag = "1";

        /// <summary>
        /// 选择的物资科目类别
        /// </summary>
        private string kindType = "";

        /// <summary>
        /// 物资基础数据类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.Baseset matBase = new Neusoft.HISFC.BizLogic.Material.Baseset();

        #endregion

        #region 属性

        /// <summary>
        /// 结果类型
        /// </summary>
        public string ResultFlag
        {
            get
            {
                return this.resultFlag;
            }
            set
            {
                this.resultFlag = value;
            }
        }

        /// <summary>
        /// 是否对库存为零的物资进行封帐处理
        /// </summary>
        public bool IsCheckZeroStock
        {
            get
            {
                return this.ckZeroState.Checked;
            }
        }

        /// <summary>
        /// 是否对停用物资(本库房停用)进行封帐处理
        /// </summary>
        public bool IsCheckStopMaterial
        {
            get
            {
                return this.ckValidDrug.Checked;
            }
        }

        /// <summary>
        /// 选择的物资科目类别
        /// </summary>
        public string KindType
        {
            get
            {
                return this.kindType;
            }
            set
            {
                this.kindType = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化TreeView
        /// </summary>
        public void InitTreeView()
        {
            this.tvObject.Nodes.Clear();

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
                    foreach (Neusoft.HISFC.Models.Material.MaterialKind title in al)
                    {
                        TreeNode kindTree = new TreeNode(title.Name, 0, 0);
                        kindTree.Tag = "";
                        this.tvObject.Nodes.Add(kindTree);
                        //添加子节点
                        this.InsertNode(kindTree, title.ID);
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("初始化科目树失败：" + e.Message);
                return;
            }
            this.tvObject.ExpandAll();
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

                    TreeNode kindTree = new TreeNode(materialKind.Name,0,0);
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
        /// 将treeview中选中的数据保存到数组中
        /// </summary>
        public void Save()
        {
            //清空数组中的数据。
            this.kindList.Clear();

            if (this.tvObject.Nodes.Count == 0)
                return;

            foreach (TreeNode node in this.tvObject.Nodes)
            {
                foreach (TreeNode tn in node.Nodes)
                {
                    //将选中的项保存到数组中
                    if (tn.Checked) this.kindList.Add(tn.Tag as Neusoft.FrameWork.Models.NeuObject);
                }
            }
        }

        /// <summary>
        /// 对药品性质与药品类别的选择返回字符串
        /// </summary>
        public void SaveForKind()
        {
            //清空数据
            this.kindType = "AAAA";
            if (this.tvObject.Nodes.Count == 0)
            {
                return;
            }

            this.TraversTreeView(this.tvObject);
            //foreach (TreeNode node in this.tvObject.Nodes)
            //{
            //    if (node.Checked)
            //    {
            //        if (this.kindType == "AAAA")
            //            this.kindType = "";
            //        this.kindType += node.Tag.ToString() + "','";
            //    }
            //}

        }

        /// <summary>
        /// 遍历父节点
        /// </summary>
        /// <param name="treeView"></param>
        public void TraversTreeView(Neusoft.FrameWork.WinForms.Controls.NeuTreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                this.TraversTreeNode(n);
            }
        }

        /// <summary>
        /// 遍历子结点
        /// </summary>
        /// <param name="treeNode"></param>
        public void TraversTreeNode(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked)
                {
                    if (this.kindType == "AAAA")
                        this.kindType = "";
                    this.kindType += tn.Tag.ToString() + "','";
                }
                this.TraversTreeNode(tn);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (this.ParentForm != null)
                this.ParentForm.Close();
        }

        #endregion

        #region 事件

        private void tvObject_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //如果选中的是根节点，则选中其所有子节点
            if (e.Node.Nodes!= null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    if (node.Checked != e.Node.Checked) node.Checked = e.Node.Checked;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.IsKindType)
            {
                this.SaveForKind();
                this.resultFlag = "1";
            }
            else
            {
                this.Save();
                this.resultFlag = "1";
            }

            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.resultFlag = "0";

            this.Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.resultFlag = "2";

            this.Close();
        }

        #endregion
        
    }
}
