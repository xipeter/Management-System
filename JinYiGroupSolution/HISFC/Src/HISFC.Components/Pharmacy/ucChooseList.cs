using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品列表基类控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucChooseList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucChooseList()
        {
            InitializeComponent();
        }

        public delegate void ChooseDataHandler(FarPoint.Win.Spread.SheetView sv,int activeRowIndex);

        public event System.EventHandler TvNodeAfterSelect;

        public event System.EventHandler TvNodeAfterClick;

        public event System.EventHandler TvNodeDoubleClick;

        public event System.EventHandler TvMouseRight;

        public event ChooseDataHandler ChooseDataEvent;        

        #region 属性

        /// <summary>
        /// 是否显示树节点
        /// </summary>
        [Description("是否显示树型列表"), Category("设置"), DefaultValue(true)]
        public bool IsShowTree
        {
            get
            {
                return this.tvList.Visible;
            }
            set
            {
                this.tvList.Visible = value;

                this.titlePanel.Visible = value;
            }
        }

        /// <summary>
        /// 列表名称
        /// </summary>
        [Description("列表名称设置"), Category("设置"), DefaultValue("列 表")]
        public string ListTitle
        {
            get
            {
                return this.lbTitle.Text;
            }
            set
            {
                this.lbTitle.Text = value;
            }
        }

        /// <summary>
        /// 当前选中节点
        /// </summary>
        public TreeNode SelectedNode
        {
            get
            {
                return this.tvList.SelectedNode;
            }
        }

        /// <summary>
        /// 当前树实例
        /// </summary>
        public Neusoft.HISFC.Components.Common.Controls.baseTreeView TvList
        {
            get
            {
                return this.tvList;
            }
        }

        #endregion

        /// <summary>
        /// 焦点设置
        /// </summary>
        public void SetFoucs()
        {
            this.ucDrugList1.Select();
            this.ucDrugList1.SetFocusSelect();
        }

        /// <summary>
        /// 显示药品列表
        /// </summary>
        public void ShowPharmacyList()
        {
            this.ucDrugList1.ShowPharmacyList();                   
        }

        /// <summary>
        /// 显示库存药品列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="isBatch">是否管理库存</param>
        public void ShowDeptStorage(string deptCode, bool isBatch)
        {
            this.ucDrugList1.ShowDeptStorage(deptCode, isBatch, 0);
        }

        /// <summary>
        /// 获取显示指定列的宽度
        /// </summary>
        /// <param name="columnNum"></param>
        /// <param name="iWidth"></param>
        public void GetColumnWidth(int columnNum,ref int iWidth)
        {
            this.ucDrugList1.GetColumnWidth(columnNum, ref iWidth);
        }

        /// <summary>
        /// 树清空
        /// </summary>
        public void TreeClear()
        {
            this.tvList.Nodes.Clear();
        }

        /// <summary>
        /// 向树列表内添加节点
        /// </summary>
        /// <param name="node">需添加的节点</param>
        /// <param name="isRootNode">是否根节点</param>
        /// <param name="isBrotherNode">是否当前选中节点的兄弟节点</param>
        public void AddTreeNode(TreeNode node,bool isRootNode,bool isBrotherNode)
        {
            if (isRootNode)
            {
                this.tvList.Nodes.Add(node);
            }
            else
            {
                if (isBrotherNode)
                {
                    if (this.tvList.SelectedNode.Parent != null)
                        this.tvList.SelectedNode.Parent.Nodes.Add(node);
                }
                else
                {
                    if (this.tvList.SelectedNode != null)
                        this.tvList.SelectedNode.Nodes.Add(node);
                }
            }
                
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && this.TvNodeAfterSelect != null)
            {
                this.TvNodeAfterSelect(sender, null);
            }
        }

        private void tvList_DoubleClick(object sender, EventArgs e)
        {
            if (this.TvNodeDoubleClick != null)
            {
                this.TvNodeDoubleClick(sender, null);
            }
        }

        private void tvList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && this.TvNodeAfterClick != null)
            {
                this.TvNodeAfterClick(sender, null);
            }
        }

        private void tvList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = this.tvList.GetNodeAt(e.X, e.Y);
                if (node != null && this.TvMouseRight != null)                
                {
                    this.TvMouseRight(sender, null);
                }
            }
        }

        public virtual void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            if (this.ChooseDataEvent != null)
            {
                this.ChooseDataEvent(sv, activeRow);
            }
        }
    }
}
