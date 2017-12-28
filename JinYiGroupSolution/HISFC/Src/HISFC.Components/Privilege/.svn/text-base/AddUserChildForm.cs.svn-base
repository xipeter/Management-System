using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.Privilege.BizLogic.Model;
using Neusoft.Privilege.BizLogic.Service;
using Neusoft.HISFC.Object.Privilege;




namespace Neusoft.UFC.Privilege
{
    public partial class AddUserChildForm : Form
    {
        /// <summary>
        /// 当前用户所有的权限信息
        /// </summary>
        IList<Priv> privs = new List<Priv>();
        IList<ResourceType> resTypes = new List<ResourceType>();
        /// <summary>
        /// 记录权限和组织结构关系。
        /// </summary>
        private Dictionary<String, TreeNode> OrgTreeMapping = new Dictionary<String, TreeNode>();
        /// <summary>
        /// 获得所有组织信息
        /// </summary>
        public IList<Organization> organizations = new List<Organization>();

        private User currentUser = null;
        private List<String> currentRoleIdList = null;
        /// <summary>
        /// 权限和组织结构数据字典
        /// </summary>
        public Dictionary<String, List<String>> privOrgDictionary = null;
       

        public AddUserChildForm(User user, List<String> roleIdList)
        {
            InitializeComponent();
            currentUser = user;
            currentRoleIdList = roleIdList;
        }

        private void LoadPrivOrg()
        {
            PrivilegeService proxy = Common.Util.CreateProxy();
            using (proxy as IDisposable)
            {
                privOrgDictionary = proxy.QueryAuthorityPrivOrg(currentUser);
                if (privOrgDictionary == null)
                {
                    privOrgDictionary = new Dictionary<string, List<string>>();
                }
            }
        }

        private void LoadOrg()
        {
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    organizations = _proxy.QueryUnit("HIS");             
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }
        }

        private void LoadTreeView()
        {
            tvOrg.Nodes.Clear();

            //设置但前根节点Tag
            Organization rootOrg = organizations[0];

            TreeNode rootNode = new TreeNode();
            rootNode.Text = rootOrg.Department.Name.ToString();
            rootNode.Tag = rootOrg;
            rootNode.Expand();
            tvOrg.Nodes.Add(rootNode);

            //删除根节点，准备遍历子节点
            organizations.RemoveAt(0);

            SetChildNode(rootNode, organizations);

            organizations.Insert(0, rootOrg);

            tvOrg.Nodes[0].Expand();
        }

        private void SetChildNode(TreeNode parentNode, IList<Organization> organizations)
        {
            List<TreeNode> childs = null;
            if (parentNode != null)
            {
                childs = new List<TreeNode>();
                Organization parentOrg = parentNode.Tag as Organization;
                List<Organization> childOrgList = new List<Organization>();

                foreach (Organization org in organizations)
                {
                    if (org.ParentId == parentOrg.ID)
                    {
                        childOrgList.Add(org);
                    }
                }

                for (int j = 1; j < childOrgList.Count; j++)
                {
                    for (int i = 0; i < childOrgList.Count - j; i++)
                    {
                        if (childOrgList[i].OrderNumber > childOrgList[i + 1].OrderNumber)
                        {
                            Organization orgChange = null;
                            orgChange = childOrgList[i];
                            childOrgList[i] = childOrgList[i + 1];
                            childOrgList[i + 1] = orgChange;
                        }
                    }
                }

                foreach (Organization newOrg in childOrgList)
                {

                    TreeNode newNode = new TreeNode();
                    newNode.Text = newOrg.Department.Name;
                    newNode.Tag = newOrg;
                    childs.Add(newNode);
                }

                foreach (TreeNode node in childs)
                {
                    parentNode.Nodes.Add(node);
                    //便于以后根据Iorg查找树节点。
                    OrgTreeMapping.Add((node.Tag as Organization).ID, node);
                    SetChildNode(node, organizations);
                }

            }

        }

        private void InitInfo()
        {

        }

        private void InitPrivilegeTree()//树节点为root时，不显示组织结构信息。
        {
            GetAllPrivilegeList();
            LoadResourceType();

            foreach (ResourceType resType in resTypes)
            {
                TreeNode rootNode = new TreeNode(resType.Name);
                Neusoft.Privilege.BizLogic.Model.Resource _res = new Neusoft.Privilege.BizLogic.Model.Resource();
                _res.Id = "root";
                _res.Name = resType.Name;
                _res.Type = resType.Id;
                rootNode.Tag = _res;
                rootNode.Expand();
                SetChildNode(rootNode);
                tvPri.Nodes.Add(rootNode);
            }
        }

        private void SetChildNode(TreeNode parentNode)
        {
            Priv parentRes = parentNode.Tag as Priv;
            foreach (Priv res in privs)
            {
                if (res.ParentId == parentRes.Id && res.Type == parentRes.Type)
                {
                    TreeNode newNode = new TreeNode(res.Name);
                    newNode.Tag = res;
                    parentNode.Nodes.Add(newNode);
                    SetChildNode(newNode);
                }
            }
        }

        private void LoadResourceType()
        {

            PrivilegeService _proxy = Common.Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                resTypes = _proxy.GetResourceTypes();
            }

        }

        /// <summary>
        /// 获取上个页面传进来角色所拥有的权限
        /// </summary>
        private void GetAllPrivilegeList()
        {
            IDictionary<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> permissionsList = null;
            PrivilegeService _proxy = Common.Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                if (currentRoleIdList != null)
                {
                    privs = _proxy.QueryPriv(currentRoleIdList);
                }
            }
        }

        //判断在数据字典里是否存在Iorg
        private bool JudgeOrg(String checkedOrgId)
        {
            return privOrgDictionary[(tvPri.SelectedNode.Tag as Priv).Id].Contains(checkedOrgId);
        }

        private bool Judge(Dictionary<Priv, List<Organization>> privOrg, Priv currentPriv)
        {
            foreach (Priv priv in privOrg.Keys)
            {
                if (currentPriv.Id == priv.Id)
                {
                    return true;
                }
            }

            return false;
        }



        private void AddUserChildForm_Load(object sender, EventArgs e)
        {
            InitPrivilegeTree();
            LoadOrg();
            LoadTreeView();
            LoadPrivOrg();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PrivilegeService proxy = Common.Util.CreateProxy();

           
            using(proxy as IDisposable)
            {
                try
                {
                    NFC.Management.PublicTrans.BeginTransaction();
                    int ret = proxy.SaveAuthorityPrivOrg(currentUser, privOrgDictionary);
                    if (ret == 1)
                    {
                        MessageBox.Show("保存成功！");
                    }
                    NFC.Management.PublicTrans.Commit();
                }
                catch (Exception ex)
                {
                   
                    NFC.Management.PublicTrans.RollBack();
                    throw ex;
                }
            }

            base.Close();
        }

        private void btnChanel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tvOrg_AfterCheck(object sender, TreeViewEventArgs e)
        {

            //没有选择权限，则返回。
            if (tvPri.SelectedNode == null)
            {
                MessageBox.Show("请选择权限！");
                return;
            }
            if ((tvPri.SelectedNode.Tag as Priv).Id == "root")
            {
                MessageBox.Show("根为权限分类，不能分配组织结构！");
                tvOrg.AfterCheck -= tvOrg_AfterCheck;
                e.Node.Checked = false;
                tvOrg.AfterCheck += tvOrg_AfterCheck;
                return;
            }
            //组织结构根节点为分类根节点，不能选中。
            if ((e.Node.Tag as Organization).ID == null)
            {
                tvOrg.AfterCheck -= tvOrg_AfterCheck;
                e.Node.Checked = false;
                tvOrg.AfterCheck += tvOrg_AfterCheck;
                return;
            }

            if (e.Node.Checked == true)
            {
                if (!JudgeOrg((e.Node.Tag as Organization).ID))
                {
                    privOrgDictionary[(tvPri.SelectedNode.Tag as Priv).Id].Add((e.Node.Tag as Organization).ID);
                }
            }
            else
            {
                if (JudgeOrg((e.Node.Tag as Organization).ID))
                {
                    privOrgDictionary[(tvPri.SelectedNode.Tag as Priv).Id].Remove((e.Node.Tag as Organization).ID);
                }
            }


        }

        private void tvPri_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //权限分类去除
            if ((e.Node.Tag as Priv).Id == "root")
            {
                return;
            }
            if (!privOrgDictionary.ContainsKey((e.Node.Tag as Priv).Id))
            {
                privOrgDictionary.Add((e.Node.Tag as Priv).Id, new List<String>());
            }

            //初始化节点checked值
            foreach (KeyValuePair<String, TreeNode> pairTree in OrgTreeMapping)
            {
                tvOrg.AfterCheck -= tvOrg_AfterCheck;
                pairTree.Value.Checked = false;
                tvOrg.AfterCheck += tvOrg_AfterCheck;
            }

            //选择不同权限，设置以选择的组织结构
            if (privOrgDictionary != null)
            {
                foreach (String org in privOrgDictionary[(e.Node.Tag as Priv).Id])
                {
                    if (OrgTreeMapping.ContainsKey(org))
                    {
                        OrgTreeMapping[org].Checked = true;
                    }
                }
            }
        }

    }
}