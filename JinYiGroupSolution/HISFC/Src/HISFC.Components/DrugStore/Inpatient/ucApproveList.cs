using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    public partial class ucApproveList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucApproveList()
        {
            InitializeComponent();
        }

        public delegate void SelectBillHandler(Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass);

        public event SelectBillHandler SelectBillEvent;

        public event System.EventHandler RootNodeCheckedEvent;

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示查找框
        /// </summary>
        public bool ShowOperTimeFilter
        {
            get
            {
                return this.panelFind.Visible;
            }
            set
            {
                this.panelFind.Visible = value;
            }
        }

        /// <summary>
        /// 摆药时间
        /// </summary>
        protected DateTime DrugedDate
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtpDrugedDate.Text).Date;
            }
        }

        /// <summary>
        /// 操作科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperDept
        {
            get
            {
                return this.operDept;
            }
            set
            {
                this.operDept = value;
            }
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 刷新当前摆药单列表
        /// </summary>
        public void RefreshBill()
        {
            if (this.operDept == null)
            {
                this.ShowList(((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept.ID, this.DrugedDate);
            }
            else
            {
                this.ShowList(this.operDept.ID, this.DrugedDate);
            }
        }

        /// <summary>
        /// 节点展开
        /// </summary>
        /// <param name="isDrugTree">是否处理未核准树</param>
        /// <param name="isExpandAll">是否全部展开</param>
        public virtual void ExpandNode(bool isDrugTree, bool isExpandAll)
        {
            TreeView tempTree;
            if (isDrugTree)
                tempTree = this.tvDrugBill;
            else
                tempTree = this.tvApproveBill;

            if (isExpandAll)
            {
                tempTree.ExpandAll();
            }
            else
            {
                if (tempTree.Nodes.Count > 0)
                    tempTree.Nodes[0].Expand();
            }
        }

        /// <summary>
        /// 取摆药单列表中，被选中的摆药单组合。并返回是否可以对摆药单进行核准
        /// </summary>
        /// <param name="billCodes">选中的摆药单编码组合 由逗号间隔</param>
        /// <returns>返回是否允许进行核准操作 True 允许 Flase 不允许</returns>
        public virtual bool GetCheckBill(ref string billCodes)
        {
            if( this.neuTabControl1.SelectedTab == this.tpDrugBill )
            {
                return this.GetCheckBill( this.tvDrugBill , ref billCodes );
            }
            else
            {
                return this.GetCheckBill( this.tvApproveBill , ref billCodes );
            }
        }

        /// <summary>
        /// 焦点设置
        /// </summary>
        public new void Focus()
        {
            this.neuTabControl1.SelectedTab = this.tpDrugBill;
            if (this.tvDrugBill.Nodes.Count > 0)
                this.tvDrugBill.SelectedNode = this.tvDrugBill.Nodes[0];
            this.tvDrugBill.Select();
            this.tvDrugBill.Focus();
        }

        /// <summary>
        /// 设置焦点到DateTimePicker
        /// </summary>
        public void DateFocus()
        {
            this.dtpDrugedDate.Select();
            this.dtpDrugedDate.Focus();
        }

        /// <summary>
        /// 设置焦点到摆药日期查找框
        /// </summary>
        public void FindTextFocus()
        {
            this.txtDrugBillCode.SelectAll();
            this.txtDrugBillCode.Focus();
        }

        #endregion

        /// <summary>
        /// 显示本科室，某一天的摆药单列表
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="dateTime">摆药时间</param>
        protected virtual void ShowList(string deptCode, DateTime dateTime)
        {
            //取摆药单信息DrugBillClass
            ArrayList al = this.itemManager.QueryDrugBillByDay(deptCode, dateTime);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取" + dateTime.ToString() + "的摆药单列表信息发生错误!") + this.itemManager.Err);
                return;
            }

            //显示已核准的摆药单
            this.AddListToTree(this.tvApproveBill, al, "2");

            //显示未核准的摆药单
            this.AddListToTree(this.tvDrugBill, al, "1");

            if (this.neuTabControl1.SelectedTab == this.tpDrugBill)
            {
                if (this.tvDrugBill.Nodes.Count > 0)
                    this.tvDrugBill.SelectedNode = this.tvDrugBill.Nodes[0];
            }
            if (this.neuTabControl1.SelectedTab == this.tpApproveBill)
            {
                if (this.tvApproveBill.Nodes.Count > 0)
                    this.tvApproveBill.SelectedNode = this.tvApproveBill.Nodes[0];
            }
        }

        /// <summary>
        /// 显示摆药单列表
        /// </summary>
        /// <param name="tvBill">树型列表</param>
        /// <param name="alBill">摆药单数组</param>
        /// <param name="applyState">摆药申请状态</param>
        protected virtual void AddListToTree(Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvBill, ArrayList alBill, string applyState)
        {
            //清除树型列表中的节点
            tvBill.Nodes.Clear();

            //传入参数数组是按照摆药单类型、科室、发送时间（倒序）排序的
            string privBillClassCode = "";
            TreeNode nodeBillClass = new TreeNode();
            foreach (DrugBillClass info in alBill)
            {
                if( info.ApplyState == null )
                {
                    info.ApplyState = "2";
                }
                if( info.ApplyState != applyState )
                    continue;

                if (info.ID != privBillClassCode)
                {
                    nodeBillClass = this.GetBillClassNode(info, tvBill.Nodes);

                    privBillClassCode = info.ID; //保存最新一次添加的摆药单节点
                }

                this.GetDeptBillNode(info, nodeBillClass.Nodes);
            }

            this.ExpandNode(true, false);
        }

        /// <summary>
        /// 将摆药单信息加入列表 返回形成的摆药单节点
        /// </summary>
        /// <param name="drugBillClass">摆药单信息</param>
        /// <param name="nodeCollection">父节点集合</param>
        /// <returns>返回摆药单节点</returns>
        private TreeNode GetBillClassNode(Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass,TreeNodeCollection nodeCollection)
        {
            TreeNode nodeBillClass = new TreeNode(drugBillClass.Name);
            nodeBillClass.Tag = drugBillClass;

            nodeCollection.Add(nodeBillClass);

            return nodeBillClass;
        }

        /// <summary>
        /// 将摆药单信息加入列表 返回形成科室的摆药单节点
        /// </summary>
        /// <param name="drugBillClass">摆药单信息</param>
        /// <param name="nodeCollection">父节点集合(摆药单节点)</param>
        /// <returns>返回科室摆药单节点</returns>
        private TreeNode GetDeptBillNode(Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass, TreeNodeCollection nodeCollection)
        {
            //添加摆药单列表
            TreeNode nodeDeptBill = new TreeNode();
            nodeDeptBill.Text = drugBillClass.ApplyDept.Name + "[" + drugBillClass.Oper.OperTime.ToString("Hmmss") + "]";
            if (drugBillClass.ApplyState == "1")
            {
                nodeDeptBill.ImageIndex = 2;
                nodeDeptBill.SelectedImageIndex = 2;
            }
            else
            {
                nodeDeptBill.ImageIndex = 3;
                nodeDeptBill.SelectedImageIndex = 3;
            }
            nodeDeptBill.Tag = drugBillClass;
            nodeCollection.Add(nodeDeptBill);

            return nodeDeptBill;
        }

        /// <summary>
        /// 取摆药单列表中，被选中的摆药单组合。并返回是否可以对摆药单进行核准
        /// </summary>
        /// <param name="tvBill">需判断是否选中的节点树</param>
        /// <param name="billCodes">选中的摆药单编码组合 由逗号间隔</param>
        /// <returns>返回是否允许进行核准操作 True 允许 Flase 不允许</returns>
        protected bool GetCheckBill(Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvBill, ref string billCodes)
        {
            billCodes = "''";
            bool enabledApprove = false;        //是否允许对本组摆药单进行核准操作

            if (tvBill.Nodes.Count <= 0)
                return false;

            foreach (TreeNode billClassNode in tvBill.Nodes)
            {
                foreach (TreeNode deptBillNode in billClassNode.Nodes)
                {
                    if (!deptBillNode.Checked)
                        continue;

                    DrugBillClass drugBillClass = deptBillNode.Tag as DrugBillClass;

                    billCodes = billCodes + string.Format(",'{0}'",drugBillClass.DrugBillNO);

                    if (drugBillClass.ApplyState == "1")
                        enabledApprove = true;
                }
            }

            if (billCodes == "" || billCodes == "''")
            {
                MessageBox.Show(Language.Msg("请选择待核准摆药单"));
                billCodes = null;
            }
            //为何增加此处代码？
            if (billCodes == "''" && tvBill.SelectedNode.Level == 1)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugBillClass selectBillClass = tvBill.SelectedNode.Tag as Neusoft.HISFC.Models.Pharmacy.DrugBillClass;

                if (selectBillClass.DrugBillNO.IndexOf("'") == -1)
                    billCodes = string.Format("'{0}'", selectBillClass.DrugBillNO);
                else
                    billCodes = selectBillClass.DrugBillNO;

                if (selectBillClass.ApplyState == "1")
                    enabledApprove = true;
            }
           
            return enabledApprove;
        }

        /// <summary>
        /// 查找指定时间点打印的摆药单的节点
        /// </summary>
        /// <param name="strOperTime">指定的摆药时间点</param>
        private void FindNode(string strOperTime)
        {
            TreeView tvBill;
            if (this.neuTabControl1.SelectedTab == this.tpDrugBill)
                tvBill = this.tvDrugBill;
            else
                tvBill = this.tvApproveBill;

            foreach (TreeNode billClassNode in tvBill.Nodes)
            {
                foreach (TreeNode deptBillNode in billClassNode.Nodes)
                {
                    DrugBillClass drugBillClass = deptBillNode.Tag as DrugBillClass;

                    if (drugBillClass.Oper.OperTime.ToString("Hmmss") == strOperTime)
                    {
                        tvBill.SelectedNode = deptBillNode;
                        return;
                    }
                }
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                DateTime dtpDate = this.itemManager.GetDateTimeFromSysDateTime().Date;

                this.dtpDrugedDate.Value = dtpDate;
            }
            catch
            { }
        }

        private void tvBill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)          //如果点击的为摆药单分类节点 且 节点未选中 则对所有子节点取消选中
            {
                if (!e.Node.Checked)
                {
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        if (node.Checked)
                            node.Checked = false;
                    }
                }
            }

            if (this.SelectBillEvent != null)
                this.SelectBillEvent(e.Node.Tag as DrugBillClass);
        }

        private void tvBill_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)                      //选中的为根节点 则其子节点与根节点选中状态相同
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
                if (this.RootNodeCheckedEvent != null)
                {
                    this.RootNodeCheckedEvent(e.Node.Checked, e);
                }
            }
            else                                          //如对本级所有节点取消选中 则对父节点取消选中
            {
                bool hasCheck = false;
                foreach (TreeNode tempNode in e.Node.Parent.Nodes)
                {
                    if (tempNode.Checked)
                    {
                        hasCheck = true;
                        break;
                    }
                }

                if (!hasCheck && e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = false;
                }
                //if (e.Node.Checked)
                //{
                //    (sender as Neusoft.FrameWork.WinForms.Controls.NeuTreeView).SelectedNode = e.Node;                    
                //}
            }
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedTab == this.tpDrugBill)
            {
                if (this.tvDrugBill.Nodes.Count > 0)
                    this.tvDrugBill.SelectedNode = this.tvDrugBill.Nodes[0];
            }
            else
            {
                if (this.tvApproveBill.Nodes.Count > 0)
                    this.tvApproveBill.SelectedNode = this.tvApproveBill.Nodes[0];
            }
        }

        private void dtpDrugedDate_ValueChanged(object sender, EventArgs e)
        {
            this.RefreshBill();
        }

        private void txtDrugBillCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FindNode(this.txtDrugBillCode.Text);
            }
        }
    }
}
