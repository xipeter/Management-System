using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Medical.Controls
{
    /// <summary>
    /// <br>tvCheckPerson</br>
    /// [功能描述: 人事管理用到树型控件，显示每个科室，科室下面显示人员]<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2008-07-17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    public partial class tvCheckPerson : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        #region 字段
        /// <summary>
        /// 集成业务类对象，提供各个模块的业务功能

        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 人员数组
        /// </summary>
        private ArrayList alPersonAll = null;
        /// <summary>
        /// 科室代码
        /// </summary>
        private string deptID;
        /// <summary>
        /// 科室节点类型常量字符串

        /// </summary>
        private const string DEPT_NODE_TYPE = "科室";
        /// <summary>
        /// 人员节点类型常量字符串

        /// </summary>
        private const string PERSON_NODE_TYPE = "人员";

        private int filterFlag = 0;

        #endregion

        #region 属性


        #endregion

        #region 方法

        #region 公共方法
        /// <summary>
        /// 构造函数

        /// </summary>
        public tvCheckPerson()
        {
            InitializeComponent();
            alPersonAll = integrateManager.QueryEmployeeAll();

            initTreeStyle();
            loadDeptAndPerson();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 设置树控件的样式
        /// </summary>
        private void initTreeStyle()
        {
            this.ImageList = this.deptImageList;
            //this.CheckBoxes = true;
            this.Width = 210;
            this.Height = 600;
        }
        /// <summary>
        /// 加载数据，将科室和人员列表加载到树形控件上

        /// </summary>
        private void loadDeptAndPerson()
        {
            this.Nodes.Clear();

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "所有科室";
            rootNode.Tag = null;
            rootNode.ImageIndex = 0;//根节点图标


            ArrayList alDept = integrateManager.GetDeptmentAllValid();
            if (alDept == null || alDept.Count < 1)
            {
                return;
            }

            TreeNode curNode = null;
            //添加所有科室

            foreach (Neusoft.HISFC.Models.Base.Department curDept in alDept)
            {
                curNode = new TreeNode();
                curNode.Text = curDept.Name;
                curNode.Tag = curDept;
                curNode.ImageIndex = 1;//表示显示代表科室的图片

                curNode.ToolTipText = DEPT_NODE_TYPE;
                loadPersonQuickly(curNode);

                rootNode.Nodes.Add(curNode);
            }
            rootNode.Expand();
            this.Nodes.Add(rootNode);
        }
        /// <summary>
        /// 在科室下加载人员
        /// </summary>
        /// <param name="node"></param>
        private void loadPersonQuickly(TreeNode node)
        {
            if (node.Tag == null)
            {
                return;
            }
            this.deptID = ((Neusoft.HISFC.Models.Base.Department)node.Tag).ID;
            TreeNode curNode = null;
            foreach (Neusoft.HISFC.Models.Base.Employee curPerson in alPersonAll)
            {
                if (this.deptID.Equals(curPerson.Dept.ID))
                {
                    curNode = new TreeNode();
                    curNode.Text = curPerson.Name;
                    curNode.Tag = curPerson;
                    curNode.ImageIndex = 2;//代表人员的图标

                    curNode.ToolTipText = PERSON_NODE_TYPE;


                    if (filterFlag == 1)
                    {
                        //Neusoft.HISFC.Models.Base.EnumEmployeeType.D
                        if (curPerson.EmployeeType.ID.ToString() == "D")
                        {
                            node.Nodes.Add(curNode);
                        }
                    }
                    else
                        if (filterFlag == 2)
                        {
                            if (curPerson.EmployeeType.ID.ToString() == "N")
                            {
                                node.Nodes.Add(curNode);
                            }
                        }
                        else
                        {
                            node.Nodes.Add(curNode);
                        }

                }
            }

        }
        #endregion

        private void neuContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "item0")
            {
                Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
                frm.Init(this);
                frm.ShowDialog();
            }
            if (e.ClickedItem.Name == "item1")
            {
                filterFlag = 0;
                loadDeptAndPerson();
            }
            if (e.ClickedItem.Name == "item2")
            {
                filterFlag = 1;
                loadDeptAndPerson();
            }
            if (e.ClickedItem.Name == "item3")
            {
                filterFlag = 2;
                loadDeptAndPerson();
            }
        }

        #region 事件处理方法
        /// <summary>
        /// 选中父节点时自动选中子节点

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void tvDeptAndPerson_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    if (this.CheckBoxes == false)
        //    {
        //        return;
        //    }
        //    TreeNodeCollection nodeCol = e.Node.Nodes;
        //    if (nodeCol == null || nodeCol.Count < 1)
        //    {
        //        return;
        //    }
        //    if (e.Node.Checked == true)
        //    {
        //        foreach (TreeNode node in nodeCol)
        //        {
        //            node.Checked = true;
        //        }
        //        return;
        //    }
        //    if (e.Node.Checked == false)
        //    {
        //        foreach (TreeNode node in nodeCol)
        //        {
        //            node.Checked = false;
        //        }
        //        return;
        //    }
        //}
        #endregion

        #endregion
    }
}
