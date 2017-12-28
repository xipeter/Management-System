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
    /// <summary>
    /// OnlineController <br></br>
    /// [功能描述: 病例书写规范]<br></br>
    /// [创 建 者: 潘铁俊]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// <修改记录
    /// 
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCaseWriteRule : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCaseWriteRule()
        {
            InitializeComponent();
            init();          
        }

        #region 变量
        /// <summary>
        /// 操作管理类
        /// </summary>
        //private Neusoft.HISFC.Management.EPR.CaseWriteRule cwrManager = new Neusoft.HISFC.Management.EPR.CaseWriteRule();
        
        /// <summary>
        /// 获取登录人信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
        /// <summary>
        /// 是否是目录，在规范数据为空并且连接为空的情况下为目录，否则认为是规范
        /// </summary>
        //private bool isCatalog = false;
        /// <summary>
        /// 科室帮助类 
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper;
        /// <summary>
        /// 菜单
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBar = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        private bool isView = false;
        private string deptCode = string.Empty;
        /// <summary>
        /// 节点列表
        /// </summary>
        private ArrayList treeNodeList = new ArrayList();
        /// <summary>
        /// 当前查找的索引
        /// </summary>
        private int currentIndex = 0;
        /// <summary>
        /// 是否有查询到的节点
        /// </summary>
        private bool hasNode = false;
        #endregion

        #region 属性
        /// <summary>
        /// 设置控件是否可以编辑
        /// </summary>
        [Description("设置控件是否可以编辑"), Category("设置"), DefaultValue(false)] 
        public bool IsView
        {
            get
            {
                return this.isView;
            }
            set
            {
                this.isView = value;
                this.ResetSurface();
                if(value){
                    this.cwc.CatalogTree.AllowDrop = false;
                }
                
            }

        }
        /// <summary>
        /// 设置要检索的部门编码
        /// </summary>
        [Description("设置要检索的部门编码"), Category("设置"), DefaultValue("")] 
        public string DeptCode
        {
            get
            {
                return this.deptCode;
            }
            set
            {
                this.deptCode = value;
                this.initTree();
            }
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBar.AddToolButton("删除", "删除", 0, true, false, null);
            toolBar.AddToolButton("添加", "添加", 1, true, false, null);
            return toolBar;// base.OnInit(sender, neuObject, param);
        }
        /// <summary>
        /// 初始化菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case  "删除":
                    this.DeleteRule();
                    break;
                case "添加":
                    this.AddRule_Click(null, null);
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {

            ArrayList alDept = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryBaseDepartment();
            this.ncbDept.IsListOnly = true;
            if (alDept != null)
            {
                this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);
                this.ncbDept.AddItems(alDept);
                this.ncbDept.Text = person.Dept.Name;
            }
            if (person.IsManager)
            {
                this.ncbDept.Enabled = true;
                //this.cwc.IsManager = true;
            }
            else
            {
                this.ncbDept.Enabled = false;
                //this.cwc.IsManager = false;
            }

            this.initTree();
            
            this.cwc.CatalogTree.MouseDown += new MouseEventHandler(Catalog_MouseDown);
            this.cwc.CatalogTree.BeforeSelect += new TreeViewCancelEventHandler(CatalogTree_BeforeSelect);
            this.cwc.CatalogTree.AfterSelect += new TreeViewEventHandler(CatalogTree_AfterSelect);
        }
        private void initTree()
        {
            this.cwc.CatalogTree.Nodes.Clear();
            if (string.IsNullOrEmpty(this.deptCode))
            {
                this.cwc.DeptCode = person.Dept.ID;
            }
            else
            {
                this.cwc.DeptCode = this.deptCode;
            }
            this.cwc.init();
        }
        /// <summary>
        /// 填充树节点列表
        /// </summary>
        /// <param name="node"></param>
        private void FillNodeList(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                this.treeNodeList.Add(tn);
                if (tn.Nodes.Count > 0)
                {
                    FillNodeList(tn);
                }
            }
        }
        #endregion

        #region 数据操作 增、删、改、查
        /// <summary>
        /// 添加书写规范
        /// </summary>
        /// <returns>1 成功，-1 失败</returns>
        private int InsertRule()
        {
            //是否是浏览
            if (this.isView)
            {
                return 0;
            }
            TreeNode node = this.cwc.CatalogTree.SelectedNode.Parent;
            object cwrParent = (node!=null?node.Tag:null);
            Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = new Neusoft.HISFC.Models.EPR.CaseWriteRule();

            cwr.RuleCode = this.cwc.CatalogTree.SelectedNode.Name;//.Substring(0, this.cwc.CatalogTree.SelectedNode.Name.IndexOf("_"));// this.MakeRuleCode();

            cwr.RuleName = this.ntbName.Text;
            cwr.DeptName = this.ncbDept.Text;
            cwr.DeptCode = this.deptHelper.GetID(this.ncbDept.Text); 
            cwr.Descript = this.ntbDescript.Text;
            cwr.Sort = this.ntbSort.Text;
            cwr.Memo = this.ntbMemo.Text;
            cwr.RuleLink = this.ntbLink.Text;
            cwr.ParentCode = (cwrParent == null ? "0" : ((Neusoft.HISFC.Models.EPR.CaseWriteRule)(cwrParent)).RuleCode);
            cwr.RuleData = this.ntbData.Text;

            int ret = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertRule(cwr);
            if (ret == 1)
            {
                this.cwc.CatalogTree.SelectedNode.Tag = cwr;
                this.cwc.CatalogTree.SelectedNode.Text = cwr.RuleName;
                this.treeNodeList.Clear();
                this.FillNodeList(this.cwc.CatalogTree.Nodes[0]);
            }
            return ret;
        }
        /// <summary>
        /// 修改书写规范
        /// </summary>
        /// <returns>1 成功，-1 失败</returns>
        private int ModifyRule()
        {
            //是否是浏览
            if (this.isView)
            {
                return 0;
            }
            TreeNode node = this.cwc.CatalogTree.SelectedNode.Parent;
            object cwrParent = (node != null ? node.Tag : null);
            Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = new Neusoft.HISFC.Models.EPR.CaseWriteRule();

            cwr.RuleCode = this.cwc.CatalogTree.SelectedNode.Name;//.Substring(0, this.cwc.CatalogTree.SelectedNode.Name.IndexOf("_")); //this.MakeRuleCode();

            cwr.RuleName = this.ntbName.Text;
            cwr.DeptName = this.ncbDept.Text;
            cwr.DeptCode = this.deptHelper.GetID(this.ncbDept.Text);
            cwr.Descript = this.ntbDescript.Text;
            cwr.Sort = this.ntbSort.Text;
            cwr.Memo = this.ntbMemo.Text;
            cwr.RuleLink = this.ntbLink.Text;
            cwr.ParentCode = (cwrParent == null ? "0" : ((Neusoft.HISFC.Models.EPR.CaseWriteRule)(cwrParent)).RuleCode);
            cwr.RuleData = this.ntbData.Text;
            int ret = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.ModifyRule(cwr);
            if (ret == 1)
            {
                this.cwc.CatalogTree.SelectedNode.Tag = cwr;
                this.cwc.CatalogTree.SelectedNode.Text = cwr.RuleName;
                this.treeNodeList.Clear();
                this.FillNodeList(this.cwc.CatalogTree.Nodes[0]);
            }
            return ret;
        }
        /// <summary>
        /// 删除书写规范
        /// </summary>
        /// <returns>1 成功，-1 失败,0 取消操作</returns>
        private int DeleteRule()
        {
            //是否是浏览
            if (this.isView)
            {
                return 0;
            }
            TreeNode node = this.cwc.CatalogTree.SelectedNode;
            //if(node == null || node.Name == "0000"){ 
            //    return 0;
            //}

            bool hasGrandchildren = false;
            if (node != null && node.Nodes.Count > 0)
            {
                foreach (TreeNode temp in node.Nodes)
                {
                    if (temp.Nodes.Count > 0)
                    {
                        hasGrandchildren = true;
                    }

                }
            }
            if (hasGrandchildren)
            {
                MessageBox.Show("不能删除存在多于2层子节点的节点，请先删除其底层节点！");
                return -1;
            }
            DialogResult dr = MessageBox.Show("是否要删除该病例书写规范,\r\n该操作将删除其拥有的子节点", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = new Neusoft.HISFC.Models.EPR.CaseWriteRule();
                cwr.RuleCode = this.cwc.CatalogTree.SelectedNode.Name;//.Substring(0,this.cwc.CatalogTree.SelectedNode.Name.IndexOf("_")); //((Neusoft.HISFC.Models.EPR.CaseWriteRule)this.cwc.CatalogTree.SelectedNode.Tag).RuleCode;
                cwr.DeptCode = this.deptHelper.GetID(this.ncbDept.Text);
                TreeNode parent = this.cwc.CatalogTree.SelectedNode.Parent;
                this.RemoveChildren(this.cwc.CatalogTree.SelectedNode);
                if (this.cwc.CatalogTree.SelectedNode != null)
                {
                    this.cwc.CatalogTree.SelectedNode.Remove();
                }
                if (parent != null)
                {
                    this.cwc.CatalogTree.SelectedNode = parent;
                }
                if (this.cwc.CatalogTree.Nodes.Count > 0)
                {
                    this.treeNodeList.Clear();
                    this.FillNodeList(this.cwc.CatalogTree.Nodes[0]);
                }
                return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DeleteRule(cwr, true);
                
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 递归删除子节点
        /// </summary>
        /// <param name="parentNode"></param>
        private void RemoveChildren(TreeNode parentNode)
        {
            if (parentNode !=null && parentNode.Nodes.Count > 0)
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
        
        /// <summary>
        /// 获取病例规范内容
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.EPR.CaseWriteRule GetRuleByID(string id)
        {
            return Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetRule(id);
            
        }

        #endregion

        #region 响应事件
        /// <summary>
        /// 回车转换焦点
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ntbData.Focused)
                {
                    return false;
                }
                if (this.cwc.SearchBox.Focused)
                {
                    if (!string.IsNullOrEmpty(this.cwc.SearchBox.Text))
                    {
                        this.currentIndex = 0;
                        this.hasNode = false;
                        if(this.cwc.CatalogTree.Nodes.Count>0){
                            this.treeNodeList.Clear();
                            this.FillNodeList(this.cwc.CatalogTree.Nodes[0]);
                            //this.treeNodeList = this.cwrManager.QueryCatalogByName(this.cwc.SearchBox.Text);
                            this.LocateRule();
                        }
                        return false;
                    }else{
                        MessageBox.Show("查询值不能为空！");
                        this.cwc.SearchBox.Focus();
                        return false;
                    }
                }
                SendKeys.Send("{TAB}");
                return true;
            }
            if (keyData == Keys.F1)
            {
                this.cwc.SearchBox.Focus();
                return true;
            }
            if (keyData == Keys.F3)
            {
                if (string.IsNullOrEmpty(this.cwc.SearchBox.Text))
                {
                    MessageBox.Show("查询值不能为空！");
                    this.cwc.SearchBox.Focus();
                    return false;
                }
                if (this.currentIndex+1 >= this.treeNodeList.Count)
                {
                    this.currentIndex = 0;
                }
                this.currentIndex++;
                this.LocateRule();
            }
            return base.ProcessDialogKey(keyData);

        }

        /// <summary>
        /// 鼠标右键弹出contextMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Catalog_MouseDown(object sender, MouseEventArgs e)
        {
            //是否是浏览
            if (this.isView)
            {
                return ;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (((TreeView)sender).GetNodeAt(e.Location) == null)
                {
                    ((TreeView)sender).SelectedNode = null;
                }
                this.contextMenuStrip1.ShowCheckMargin = false;
                this.contextMenuStrip1.Show((TreeView)sender, e.Location);
                
            }
        }
        /// <summary>
        /// 判断是否保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogTree_BeforeSelect(object sender,TreeViewCancelEventArgs e)
        {
            if (this.isChanged())
            {
                DialogResult dr = MessageBox.Show("是否保存修改！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Save();
                }
                else
                {
                    TreeNode parentNode = ((TreeView)sender).SelectedNode.Parent;
                    if (((TreeView)sender).SelectedNode != null && ((TreeView)sender).SelectedNode.Tag == null)
                    {
                        ((TreeView)sender).SelectedNode.Remove();
                        if (parentNode != null)
                        {
                            ((TreeView)sender).SelectedNode = parentNode;
                        }
                    }
                    
                }
            }
        }
        
        /// <summary>
        /// 对页面赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogTree_AfterSelect(object sender,TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode.Tag != null)
            {
                Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = ((TreeView)sender).SelectedNode.Tag as Neusoft.HISFC.Models.EPR.CaseWriteRule;
                this.ntbName.Text = cwr.RuleName;
                this.ncbDept.Text = cwr.DeptName; 
                this.ncbDept.Enabled = false;
                this.ntbSort.Text = cwr.Sort;
                this.ntbDescript.Text = cwr.Descript;
                this.ntbLink.Text = cwr.RuleLink;
                this.ntbData.Text = cwr.RuleData;
                this.ntbMemo.Text = cwr.Memo;
            }
        }

        /// <summary>
        /// 添加规范事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRule_Click(object sender, EventArgs e)
        {
            //this.isCatalog = false;
            //是否是浏览
            if (this.isView)
            {
                return ;
            }
            TreeNode parentNode = this.cwc.CatalogTree.SelectedNode;
            if (parentNode != null && parentNode.Tag == null)
            {
                MessageBox.Show("请先保存当前添加的规范！");
                return;
            }
            TreeNode node = new TreeNode();
            node.Name = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetRuleSequence();// +"_" + this.deptHelper.GetID(this.ncbDept.Text); ;
            node.Tag = null;
            node.Text = "新增规范";

            if (parentNode == null)
            {
                this.cwc.CatalogTree.Nodes.Add(node);
            }
            else
            {
                parentNode.Nodes.Add(node);
            }

            this.cwc.CatalogTree.SelectedNode = node;
            if (parentNode != null)
            {
                string deptCode = (parentNode.Tag as Neusoft.HISFC.Models.EPR.CaseWriteRule).DeptCode;
                if (string.IsNullOrEmpty(deptCode))
                {
                    this.ncbDept.Enabled = true;
                }
                else
                {
                    this.ncbDept.Text = this.deptHelper.GetName(deptCode);
                    this.ncbDept.Enabled = false;
                }
            }
            else
            {
                this.ncbDept.Enabled = true;
            }
            ResetSurface();
            this.ntbName.Focus();
        }
        /// <summary>
        /// 根据名称查找规范
        /// </summary>
        /// <param name="ruleName"></param>
        private void LocateRule()
        {
            if (this.treeNodeList != null && this.treeNodeList.Count>0)
            {
                for(;this.currentIndex<this.treeNodeList.Count;this.currentIndex++)
                {
                    if (((TreeNode)treeNodeList[this.currentIndex]).Text.IndexOf(this.cwc.SearchBox.Text) != -1)
                    {
                        this.cwc.CatalogTree.SelectedNode = (TreeNode)treeNodeList[this.currentIndex];
                        this.hasNode = true;
                        break;
                    }
                    else
                    {
                        if (this.hasNode && this.currentIndex + 1 >= this.treeNodeList.Count)
                        {
                            this.currentIndex = 0;
                            continue;
                        }
                    }
                }
                if (!this.hasNode)
                {
                    MessageBox.Show("没有找到要搜索的节点！");
                }
            }
        }

        /// <summary>
        /// 打开链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nllb_Click(object sender, EventArgs e)
        {
            string link = this.ntbLink.Text;
            if (!string.IsNullOrEmpty(link))
            {
                if (link.ToLower().StartsWith("http://"))
                {
                    System.Diagnostics.Process.Start(link);    
                }
                else
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(link);
                    if (file.Exists)
                    {
                        System.Diagnostics.Process.Start(link);
                    }
                }

            }
        }
        #endregion

        #region 页面操作
        /// <summary>
        /// 重置页面
        /// </summary>
        /// <param name="isCatalog"></param>
        private void ResetSurface()
        {
            //是否是浏览
            if (this.isView)
            {
                this.ntbName.Enabled = false;
                this.ntbSort.Enabled = false;
                this.ntbDescript.Enabled = false;
                this.ntbMemo.Enabled = false;
                this.ntbLink.Enabled = false;
                this.ntbData.Enabled = false;
                return;
            }
            else
            {
                this.ntbName.Enabled = true;
                this.ntbSort.Enabled = true;
                this.ntbDescript.Enabled = true;
                this.ntbMemo.Enabled = true;
                this.ntbLink.Enabled = true;
                this.ntbData.Enabled = true;
            }
            this.ntbName.Text = string.Empty;
            this.ntbSort.Text = string.Empty;
            this.ntbDescript.Text = string.Empty;
            this.ntbMemo.Text = string.Empty;
            this.ntbLink.Text = string.Empty;
            this.ntbData.Text = string.Empty;
            
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            //是否是浏览
            if (this.isView)
            {
                return 0;
            }
            this.Save();
            return base.OnSave(sender, neuObject);
        }
        private void Save()
        {
            if (this.isValid())
            {
                if (this.cwc.CatalogTree.SelectedNode.Tag == null)//新增
                {
                    if (this.InsertRule() == -1)
                    {
                        MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err + "\r\n" );
                        return;
                    }
                }
                else//修改
                {
                    if (this.isChanged())
                    {
                        if (this.ModifyRule() == -1)
                        {
                            MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err + "\r\n" );
                            return;
                        }
                    }
                }
                MessageBox.Show("保存成功！");
            }
        }
        #endregion

        #region 判断
        /// <summary>
        /// 判断数据是否有效
        /// </summary>
        /// <param name="isCatalog"></param>
        /// <returns></returns>
        private bool isValid()
        {
            if (string.IsNullOrEmpty(this.ntbName.Text))
            {
                MessageBox.Show("名称不能为空！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否有数据更改
        /// </summary>
        /// <returns></returns>
        private bool isChanged()
        {
            //根节点
            TreeNode node = this.cwc.CatalogTree.SelectedNode;
            if (node == null)
            {
                return false;
            }
            //新增
            if (this.cwc.CatalogTree.SelectedNode != null && this.cwc.CatalogTree.SelectedNode.Tag == null)
            {
                return true;
            }
            object tag = this.cwc.CatalogTree.SelectedNode.Tag;
            //if (tag == null && this.cwc.CatalogTree.SelectedNode.Name.Substring(0, this.cwc.CatalogTree.SelectedNode.Name.IndexOf("_")) != "0000")
            //{
            //    return true;
            //}
            Neusoft.HISFC.Models.EPR.CaseWriteRule cwr = tag as Neusoft.HISFC.Models.EPR.CaseWriteRule;
            if (this.ntbName.Text != cwr.RuleName
               || (deptHelper.GetID(this.ncbDept.Text) != cwr.DeptCode && !string.IsNullOrEmpty(cwr.DeptCode))//
               || this.ntbSort.Text != cwr.Sort
               || this.ntbDescript.Text != cwr.Descript
               || this.ntbLink.Text != cwr.RuleLink
               || this.ntbData.Text != cwr.RuleData
               || this.ntbMemo.Text != cwr.Memo)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
