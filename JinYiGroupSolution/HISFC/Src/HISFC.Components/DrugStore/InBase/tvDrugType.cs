using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.InBase
{
    /// <summary>
    /// [控件名称:ucDrugBill]<br></br>
    /// [功能描述: 药品属性数控件，包括药品类别、性质、药理作用、用法、剂型、以及医嘱类型等，通过属性设置]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-7]<br></br>
    /// <修改记录 
    ///		修改人='梁俊泽' 
    ///		修改时间='2007-04' 
    ///		修改目的=' 增加显示用法与剂型的大类 及 变量命名调整'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class tvDrugType : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvDrugType()
        {
            InitializeComponent();
            //初始化
            try
            {
                if (!this.DesignMode)
                {
                    this.InitTreeView();
                }
            }
            catch
            {
            }
        }

        public tvDrugType(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //初始化
            try
            {
                if (!this.DesignMode)
                {
                    this.InitTreeView();
                }
            }
            catch
            {
            }
        }

        #region 变量

        /// <summary>
        /// 是否显示药品性质、药品剂型、药理作用、用法
        /// </summary>
        private ShowDrugKind showDrugKind = new ShowDrugKind();

        /// <summary>
        /// 是否嵌套显示
        /// </summary>
        private bool isShowNested = true;

        /// <summary>
        /// 是否自动展开节点
        /// </summary>
        private bool isExpandAll = false;

        /// <summary>
        /// 是否显示剂型与用法大类而不是显示明细
        /// </summary>
        private bool isShowUsageDosageClass = false;

        #endregion

        #region  属性

        /// <summary>
        /// 是否显示药品性质、药品剂型、药理作用、用法
        /// </summary>
        [Description("是否显示药品性质、药品剂型、药理作用、用法"), Category("设置"), DefaultValue(0)]
        public ShowDrugKind ShowKind
        {
            get
            {
                return this.showDrugKind;
            }
            set
            {
                if (value != this.showDrugKind)
                {
                    if (value == ShowDrugKind.ShowAll)
                    {
                        this.isShowNested = false;
                    }

                    this.showDrugKind = value;

                    this.InitTreeView();
                }
            }
        }

        /// <summary>
        /// 是否嵌套显示
        /// </summary>
        [Description("是否嵌套显示"), Category("设置"), DefaultValue(true)]
        public bool ShowNested
        {
            get
            {
                return this.isShowNested;
            }
            set
            {
                if (value != this.isShowNested)
                {
                    if (this.showDrugKind == ShowDrugKind.ShowAll)
                    {
                        this.isShowNested = false;
                    }
                    else
                    {
                        this.isShowNested = value;
                    }

                    this.InitTreeView();
                }
            }
        }

        /// <summary>
        /// 是否自动展开节点
        /// </summary>
        [Description("是否自动展开节点"), Category("设置"), DefaultValue(false)]
        public bool ExpandAllNodes
        {
            get
            {
                return this.isExpandAll;
            }
            set
            {
                this.isExpandAll = value;

                this.ExpandAll();
            }
        }

        /// <summary>
        /// 获取选中的节点列表
        /// </summary>
        [Description("选中的节点信息列表(仅在药品属性单选时返回)"), Category("设置")]
        public List<Neusoft.HISFC.Models.Base.Const> SelectedNodes
        {
            get
            {
                List<Neusoft.HISFC.Models.Base.Const> selectednodes = new List<Neusoft.HISFC.Models.Base.Const>();

                foreach (TreeNode node in this.Nodes)
                {
                    if (this.showDrugKind == ShowDrugKind.ShowModeOnly || this.showDrugKind == ShowDrugKind.ShowQualityOnly || this.showDrugKind == ShowDrugKind.ShowTypeOnly || this.showDrugKind == ShowDrugKind.ShowUsageOnly)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.Checked)
                            {
                                selectednodes.Add(childNode.Tag as Neusoft.HISFC.Models.Base.Const);
                            }
                        }
                    }
                    else
                    {
                        selectednodes = null;
                    }
                }

                return selectednodes;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化树型列表,调用前先配置好控件的相关属性
        /// </summary>
        public void InitTreeView()
        {
            if (this.DesignMode)
            {
                return;
            }
            try
            {
                this.ImageList = this.groupImageList;

                Neusoft.HISFC.BizProcess.Integrate.Manager drugconstant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.SuspendLayout();
                this.Nodes.Clear();

                switch (showDrugKind)
                {
                    case ShowDrugKind.ShowTypeOnly:
                        this.AddFirstNode("药品类别");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                        break;
                    case ShowDrugKind.ShowFunctionOnly:
                        //显示三级药理作用
                        this.InitPharmacyFunction();
                        break;
                    case ShowDrugKind.ShowQualityOnly:
                        this.AddFirstNode("药品性质");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY), 0);
                        break;
                    case ShowDrugKind.ShowUsageOnly:
                        this.AddFirstNode("药品用法");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE), 0);
                        break;
                    case ShowDrugKind.ShowModeOnly:
                        this.AddFirstNode("药品剂型");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM), 0);
                        break;
                    case ShowDrugKind.ShowAdviceKindOnly:
                        this.AddFirstNode("医嘱类别");
                        this.AddSecondNode(drugconstant.QueryOrderTypeList(), 0);
                        break;
                    case ShowDrugKind.ShowTypeAndQuality:
                        if (this.isShowNested)
                        {
                            this.AddFirstNode("药品信息");
                            this.AddThirdNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY));
                        }
                        else
                        {
                            this.AddFirstNode("药品类别");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                            this.AddFirstNode("药品性质");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY), 1);
                        }
                        break;
                    case ShowDrugKind.ShowTypeAndUsage:
                        if (this.isShowNested)
                        {
                            this.AddFirstNode("药品信息");
                            this.AddThirdNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE));
                        }
                        else
                        {
                            this.AddFirstNode("药品类别");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                            this.AddFirstNode("药品用法");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE), 1);
                        }
                        break;
                    case ShowDrugKind.ShowTypeAndMode:
                        if (this.isShowNested)
                        {
                            this.AddFirstNode("药品信息");
                            this.AddThirdNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM));
                        }
                        else
                        {
                            this.AddFirstNode("药品类别");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                            this.AddFirstNode("药品剂型");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM), 1);
                        }
                        break;
                    case ShowDrugKind.ShowTypeAndFunction:
                        if (this.isShowNested)
                        {
                            this.AddFirstNode("药品信息");
                            this.AddThirdNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PHYFUNCTION));
                        }
                        else
                        {
                            this.AddFirstNode("药品类别");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                            this.AddFirstNode("药理作用");
                            this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PHYFUNCTION), 1);
                        }
                        break;
                    case ShowDrugKind.ShowAll:
                        this.AddFirstNode("药品类别");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE), 0);
                        this.AddFirstNode("药品性质");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY), 1);
                        this.AddFirstNode("药品剂型");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM), 2);
                        this.AddFirstNode("药品用法");
                        this.AddSecondNode(drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE), 3);
                        //显示三级药理作用
                        this.InitPharmacyFunction();
                        break;
                    case ShowDrugKind.ShowDosageClass:          //显示剂型大类
                        this.isShowUsageDosageClass = true;
                        this.AddDosage();
                        break;
                    case ShowDrugKind.ShowUsageClass:           //显示用法大类
                        this.isShowUsageDosageClass = true;
                        this.AddUsage();
                        break;
                }

            }
            catch
            {

            }
            finally
            {
                if (this.isExpandAll)
                {
                    this.ExpandAll();
                }
                this.ResumeLayout();
            }
            return;
        }

        /// <summary>
        /// 增加药品用法
        /// </summary>
        protected void AddUsage()
        {
            this.AddFirstNode("药品用法");

            Neusoft.HISFC.BizProcess.Integrate.Manager drugconstant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alUsage = new ArrayList();

            if (this.isShowUsageDosageClass)        //显示用法/剂型大类
            {
                alUsage = drugconstant.GetConstantList("USAGECLASS");
            }
            else
            {
                alUsage = drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            }

            this.AddSecondNode(alUsage, this.Nodes.Count - 1);
        }

        /// <summary>
        /// 增加药品剂型
        /// </summary>
        protected void AddDosage()
        {
            this.AddFirstNode("药品剂型");

            Neusoft.HISFC.BizProcess.Integrate.Manager drugconstant = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alDosage = new ArrayList();

            if (this.isShowUsageDosageClass)        //显示用法/剂型大类
            {
                alDosage = drugconstant.GetConstantList("DOSAGECLASS");
            }
            else
            {
                alDosage = drugconstant.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM);
            }

            this.AddSecondNode(alDosage, this.Nodes.Count - 1);
        }

        #region 树节点操作

        /// <summary>
        /// 添加根节点
        /// </summary>
        private void AddFirstNode(string text)
        {
            TreeNode currentnode = new TreeNode();
            currentnode.Text = text;
            currentnode.Tag = "ALL";
            currentnode.ImageIndex = 0;
            currentnode.SelectedImageIndex = 0;
            this.Nodes.Add(currentnode);
        }
        /// <summary>
        /// 添加二级节点
        /// </summary>
        /// <param name="al"></param>
        private void AddSecondNode(ArrayList al, int index)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                TreeNode currentnode = new TreeNode();
                currentnode.Text = obj.Name;
                currentnode.Tag = obj;
                currentnode.ImageIndex = 2;
                currentnode.SelectedImageIndex = 4;
                this.Nodes[index].Nodes.Add(currentnode);
            }
        }
        /// <summary>
        /// 嵌套添加二三级节点
        /// </summary>
        /// <param name="parent">药品类别</param>
        /// <param name="child">其他类别</param>
        private void AddThirdNode(ArrayList parent, ArrayList child)
        {
            int i = 0;
            foreach (Neusoft.HISFC.Models.Base.Const drugtype in parent)
            {

                TreeNode parentnode = new TreeNode();
                parentnode.Text = drugtype.Name;
                parentnode.Tag = drugtype;
                parentnode.ImageIndex = 3;
                parentnode.SelectedImageIndex = 3;
                this.Nodes[0].Nodes.Add(parentnode);

                foreach (Neusoft.HISFC.Models.Base.Const other in child)
                {
                    TreeNode childnode = new TreeNode();
                    childnode.Text = other.Name;
                    childnode.Tag = other;
                    childnode.ImageIndex = 3;
                    childnode.SelectedImageIndex = 3;
                    this.Nodes[0].Nodes[i].Nodes.Add(childnode);
                }

                i++;
            }

        }
        #endregion

        #region 三级药理作用
        /// <summary>
        /// 生成药理作用DataView，用于根据父节点过虑子节点
        /// </summary>
        /// <returns></returns>
        private DataView CreateDataView()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant pharmacyConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            DataTable myDataTable = new DataTable("tbFunction");
            DataRow myDataRow;
            myDataTable.Columns.Add("NODE_CODE", typeof(String));
            myDataTable.Columns.Add("PARENT_NODE", typeof(String));
            myDataTable.Columns.Add("NODE_NAME", typeof(String));
            myDataTable.Columns.Add("NODE_KIND", typeof(int));
            foreach (Neusoft.HISFC.Models.Pharmacy.PhaFunction phafun in pharmacyConstant.QueryPhaFunction())
            {
                myDataRow = myDataTable.NewRow();
                myDataRow["PARENT_NODE"] = phafun.ParentNode;
                myDataRow["NODE_CODE"] = phafun.ID;
                myDataRow["NODE_NAME"] = phafun.Name;
                myDataRow["NODE_KIND"] = phafun.NodeKind;
                myDataTable.Rows.Add(myDataRow);
            }
            DataView custDV = new DataView(myDataTable);
            return custDV;

        }
        /// <summary>
        /// 添加三级药理作用
        /// </summary>
        /// <param name="arDataView"></param>
        /// <param name="currNodes"></param>
        /// <param name="ParentNodeID">是否显示根节点，如果显示传入0否则传入R</param>
        private void InitTree(DataView arDataView, TreeNodeCollection currNodes, string ParentNodeID)
        {
            string FilterString, NodeName, NodeCode;
            FilterString = "PARENT_NODE = " + "'" + ParentNodeID + "'";
            arDataView.RowFilter = FilterString;
            arDataView.Sort = "NODE_KIND DESC";
            foreach (DataRowView drvRow in arDataView)
            {
                NodeCode = drvRow["NODE_CODE"].ToString();
                NodeName = drvRow["NODE_NAME"].ToString().Trim();
                TreeNode NewNode = new TreeNode();
                NewNode.Tag = NodeCode;
                NewNode.Text = NodeName;
                //检查是否还有子项
                arDataView.RowFilter = "PARENT_NODE = " + "'" + NodeCode + "'";
                currNodes.Add(NewNode);
                //如果存在子项，递归调用，创建子树
                if (arDataView.Count > 0)
                {
                    NewNode.ImageIndex = 2;
                    NewNode.SelectedImageIndex = 4;
                    InitTree(arDataView, NewNode.Nodes, NodeCode);
                }
                else
                {
                    NewNode.ImageIndex = 0;
                    NewNode.SelectedImageIndex = 0;
                }

                //当前节点不存在子节点则还原为父级的过滤条件
                arDataView.RowFilter = FilterString;
            }
        }

        /// <summary>
        /// 显示三级药理作用
        /// </summary>
        private void InitPharmacyFunction()
        {
            DataView dv = this.CreateDataView();
            this.InitTree(dv, this.Nodes, "0");
        }
        #endregion

        #endregion

        #region 事件

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

        #endregion

        /// <summary>
        /// 是否显示药品性质和药理作用
        /// </summary>
        public enum ShowDrugKind
        {
            /// <summary>
            /// 只显示药品类别
            /// </summary>
            ShowTypeOnly = 0,
            /// <summary>
            /// 只显示药品性质
            /// </summary>
            ShowQualityOnly = 1,
            /// <summary>
            /// 只显示药品剂型
            /// </summary>
            ShowModeOnly = 2,
            /// <summary>
            /// 只显示药理作用（三级显示）
            /// </summary>
            ShowFunctionOnly = 3,
            /// <summary>
            /// 只显示用法
            /// </summary>
            ShowUsageOnly = 4,
            /// <summary>
            /// 显示药品类别和性质
            /// </summary>
            ShowTypeAndQuality = 5,
            /// <summary>
            /// 显示药品类别和药理作用
            /// </summary>
            ShowTypeAndFunction = 6,
            /// <summary>
            /// 显示药品类别和用法
            /// </summary>
            ShowTypeAndUsage = 7,
            /// <summary>
            /// 显示药品类别和剂型
            /// </summary>
            ShowTypeAndMode = 8,
            /// <summary>
            /// 全部显示药品属性信息
            /// </summary>
            ShowAll = 9,
            /// <summary>
            /// 显示医嘱类别
            /// </summary>
            ShowAdviceKindOnly,
            /// <summary>
            /// 显示用法大类
            /// </summary>
            ShowUsageClass,
            /// <summary>
            /// 显示剂型大类
            /// </summary>
            ShowDosageClass

        }


    }
}
