using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucCaseWriteCatalog : UserControl
    {
        public ucCaseWriteCatalog()
        {
            InitializeComponent();
        }
        //private Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
        private string deptCode = string.Empty;
        private bool isManager = true;

        #region 属性
        /// <summary>
        /// 树控件
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuTreeView CatalogTree
        {
            get
            {
                return this.ntvCatalog;
            }
        }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DeptCode
        {
            set
            {
                this.deptCode = value;
            }
        }
        /// <summary>
        /// 登录者是否是管理员
        /// </summary>
        public bool IsManager
        {
            set
            {
                this.isManager = value;
            }
        }
        /// <summary>
        /// 查询框
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuTextBox SearchBox
        {
            get
            {
                return this.ntbSearch;
            }
        }
        #endregion

        #region 方法
        public void init()
        {
            ArrayList allCatalog = new ArrayList();
            TreeNode rootNode = new TreeNode();
            if (isManager)
            {
                allCatalog = this.GetAllCatalog();
            }
            else
            {
                allCatalog = this.GetAllCatalogByDeptCode();
            }

            TreeNode parentNode = new TreeNode();
            if (allCatalog != null)
            {
                foreach (Neusoft.HISFC.Models.EPR.CaseWriteRule cwr in allCatalog)
                {
                    TreeNode node = new TreeNode();
                    node.Text = cwr.RuleName;
                    node.Tag = cwr;
                    node.Name = cwr.RuleCode;// +"_" + cwr.DeptCode;

                    if (cwr.ParentCode =="0" )
                    {
                        rootNode = node;
                        this.ntvCatalog.Nodes.Add(rootNode);
                        continue;
                    }
                    if (rootNode == null)
                    {
                        break;
                    }
                    parentNode = this.FindParentNode(cwr.ParentCode);
                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(node);
                    }
                    
                }
            }
            this.ntvCatalog.ExpandAll();
            if (this.ntvCatalog.Nodes.Count > 0)
            {
                this.ntvCatalog.SelectedNode = this.ntvCatalog.Nodes[0];
            }
            this.ntvCatalog.ItemDrag += new ItemDragEventHandler(ntvCatalog_ItemDrag);
            this.ntvCatalog.DragEnter += new DragEventHandler(ntvCatalog_DragEnter);
            this.ntvCatalog.DragDrop += new DragEventHandler(ntvCatalog_DragDrop);

        }
        /// <summary>
        /// 得到所有目录列表
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAllCatalog()
        {
            return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryAllCatalog();
        }
        private ArrayList GetAllCatalogByDeptCode()
        {
            return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryCatalogByDeptCode(this.deptCode);
        }
        /// <summary>
        /// 通过目录ID得到某个目录
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.EPR.CaseWriteRule GetCatalogByID(string ruleId)
        {
            return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetCatalogByID(ruleId);
        }
        /// <summary>
        /// 通过目录名称得到某个目录
        /// </summary>
        /// <returns></returns>
        private ArrayList GetCatalogByName(string ruleName)
        {
            return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryCatalogByName(ruleName);
        }

        private TreeNode FindParentNode(string parentCode)
        {
            if (this.ntvCatalog.Nodes.Count < 0)
            {
                return null;
            }
            else
            {
                TreeNode[] nodes = this.ntvCatalog.Nodes.Find(parentCode,true);
                if (nodes.Length > 0)
                {
                    return nodes[0];
                }
            }
            return null;
        }
        private void ntvCatalog_ItemDrag(object sender,ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void ntvCatalog_DragEnter(object sender,DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion

        #region 节点操作
        /// <summary>
        /// 拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ntvCatalog_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode dragNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = ((TreeView)sender).GetNodeAt(pt);
                dragNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (destinationNode != null && dragNode != destinationNode && destinationNode.TreeView == dragNode.TreeView)
                {
                    if ((destinationNode.Tag as Neusoft.HISFC.Models.EPR.CaseWriteRule).DeptCode != (dragNode.Tag as Neusoft.HISFC.Models.EPR.CaseWriteRule).DeptCode)
                    {
                        MessageBox.Show("不同科室之间不能拖拽！");
                        return;
                    }
                    ((TreeView)sender).SelectedNode = destinationNode;
                    Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = new Neusoft.HISFC.Models.EPR.CaseWriteRule();
                    if (dragNode.Tag != null)
                    {
                        cwr = (Neusoft.HISFC.Models.EPR.CaseWriteRule)dragNode.Tag;

                        Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
                        //Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();

                        if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteRule(cwr, false) == -1)
                        {
                            Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                            MessageBox.Show("由于数据库操作失败，规范移动失败！");
                            return;
                        }
                        //string newRuleCode = this.MakeRuleCode();

                        if (dragNode.Nodes.Count > 0)
                        {
                            if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.ModifyForDrag(cwr, (destinationNode.Tag as Neusoft.HISFC.Models.EPR.CaseWriteRule).RuleCode) == -1)
                            {
                                Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                                MessageBox.Show("由于数据库操作失败，规范移动失败！");
                                return;
                            }
                        }
                        //cwr.RuleCode = newRuleCode;
                        cwr.ParentCode = ((Neusoft.HISFC.Models.EPR.CaseWriteRule)(destinationNode.Tag)).RuleCode;
                        dragNode.Tag = cwr;
                        dragNode.Name = cwr.RuleCode;// +"_" + cwr.DeptCode;
                        if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertRule(cwr) == -1)
                        {
                            Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                            MessageBox.Show("由于数据库操作失败，规范移动失败！");
                            return;
                        }
                        else
                        {
                            Neusoft.HISFC.BizProcess.Factory.Function.Commit();

                            destinationNode.Nodes.Add((TreeNode)dragNode.Clone());
                            destinationNode.ExpandAll();

                            this.RemoveChildren(dragNode);
                            dragNode.Remove();
                        }
                        this.SearchBox.Text = string.Empty;

                    }

                }
            }
        }
        /// <summary>
        /// 递归删除子节点
        /// </summary>
        /// <param name="parentNode"></param>
        private void RemoveChildren(TreeNode parentNode)
        {
            if (parentNode != null && parentNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Nodes.Count > 0)
                    {
                        RemoveChildren(node);
                    }
                    else
                    {
                        node.Remove();
                    }
                }
            }
        }
        #endregion
    }
}
