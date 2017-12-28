using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.WinForms.Forms;
using Neusoft.Privilege.ServiceContracts.Model.Impl;
using Neusoft.Framework;
using Neusoft.Privilege.ServiceContracts.Model;
using Neusoft.Privilege.ServiceContracts.Contract;

namespace Neusoft.Privilege.WinForms
{
    public partial class AddUserForm : InputBaseForm
    {
        private IList<IRole> roles = new List<IRole>();
        private IList<IOrganization> organizations = new List<IOrganization>();
        private IRole currentRole = null;
        private IList<IPerson> persons = new List<IPerson>();
        private List<IUser> newModifyUser = new List<IUser>();
        private IList<IRole> allRolesOfUser = new List<IRole>();
        ////当前角色组织结构关系
        //private Dictionary<IRole, List<IOrganization>> roleOrgMapping = new Dictionary<IRole, List<IOrganization>>();
        //当前角色组织结构关系
        private Dictionary<String, List<String>> roleOrgDictionary = new Dictionary<String, List<String>>();
        //组织结构树
        private Dictionary<String, TreeNode> orgTreeDictionary = new Dictionary<String, TreeNode>();
        //角色树
        private Dictionary<String, TreeNode> roleTreeDictionary = new Dictionary<String, TreeNode>();
        //修改时，传过来的用户信息
        private IUser origin = null;
        //当前获取控件的用户信息
        private IUser currentUser = null;

        public AddUserForm(IRole _currentRole)
        {
            currentRole = _currentRole;
            InitializeComponent();
        }

        public AddUserForm(IUser user, IRole _currentRole)
        {
            currentRole = _currentRole;
            origin = user;
            InitializeComponent();
        }

        public void AddUser()
        {
            AddUserForm_Load(null, null);
        }


        #region 私有方法
        /// <summary>
        ///  加载组织结构
        /// </summary>
        /// 
        private void LoadOrg()
        {
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
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

        private void LoadRole()
        {
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    roles = _proxy.QueryChildRole((Facade.Context.Operator as NeuPrincipal).CurrentRole.Id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            TreeNode _root = NewNode((Facade.Context.Operator as NeuPrincipal).CurrentRole);
            roles.Add((Facade.Context.Operator as NeuPrincipal).CurrentRole);
            roleTreeDictionary.Add((Facade.Context.Operator as NeuPrincipal).CurrentRole.Id,_root);
            tvRole.Nodes.Add(_root);
            AddSubRoleNode((_root.Tag as IRole), _root);
            _root.Expand();
        }

        private int LoadPerson()
        {
            IPrivilegeService proxy = Common.Util.CreateProxy();

            try
            {
                IList<string> keys;
                using (proxy as IDisposable)
                {
                    keys = proxy.QueryAppID();
                    foreach (string _key in keys)
                    {
                        IList<IPerson> collection = proxy.QueryPerson(_key);
                        foreach (IPerson person in collection)
                        {
                            persons.Add(person);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            return 0;
        }

        private void LoadTreeView()
        {
            tvOrganization.Nodes.Clear();

            //设置但前根节点Tag
            IOrganization rootOrg = organizations[0];

            TreeNode rootNode = new TreeNode();
            rootNode.Text = rootOrg.Department.Name.ToString();
            rootNode.Tag = rootOrg;
            rootNode.Expand();
            tvOrganization.Nodes.Add(rootNode);

            //删除根节点，准备遍历子节点
            organizations.RemoveAt(0);

            SetChildNode(rootNode, organizations);

        }

        private void SetChildNode(TreeNode parentNode, IList<IOrganization> organizations)
        {
            List<TreeNode> childs = null;
            if (parentNode != null)
            {
                childs = new List<TreeNode>();
                IOrganization parentOrg = parentNode.Tag as IOrganization;
                List<IOrganization> childOrgList = new List<IOrganization>();

                foreach (IOrganization org in organizations)
                {
                    if (org.ParentId == parentOrg.Id)
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
                            IOrganization orgChange = null;
                            orgChange = childOrgList[i];
                            childOrgList[i] = childOrgList[i + 1];
                            childOrgList[i + 1] = orgChange;
                        }
                    }
                }

                foreach (IOrganization newOrg in childOrgList)
                {

                    TreeNode newNode = new TreeNode();
                    newNode.Text = newOrg.Department.Name;
                    newNode.Tag = newOrg;
                    childs.Add(newNode);
                }

                foreach (TreeNode node in childs)
                {
                    parentNode.Nodes.Add(node);
                    orgTreeDictionary.Add((node.Tag as IOrganization).Id, node);
                    SetChildNode(node, organizations);
                }

            }

        }

        private void AddSubRoleNode(IRole parent, TreeNode parentNode)
        {
            foreach (IRole _role in roles)
            {
                if (_role.ParentId == parent.Id)
                {
                    TreeNode _node = NewNode(_role);
                    _node.Tag = _role;
                    roleTreeDictionary.Add(_role.Id, _node);
                    parentNode.Nodes.Add(_node);

                    AddSubRoleNode(_role, _node);
                }
            }
        }

        private TreeNode NewNode(IRole role)
        {
            TreeNode _node = new TreeNode(role.Name);
            _node.Tag = role;
            _node.Name = role.Id;
            return _node;
        }

        private string GetDefaultPassword()
        {
            string _value = System.Configuration.ConfigurationManager.AppSettings["DefaultPassword"];
            if (string.IsNullOrEmpty(_value))
            {
                return "his";
            }
            else
            {
                return _value;
            }
        }

        private bool JudgeSameLevel(TreeNode parentNode)
        {
            int count = 0;
            foreach (TreeNode roleNode in parentNode.Nodes)
            {
                if (roleNode.Checked == true)
                {
                    count++;
                }
            }

            if (count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //判断当前用户是否重复。
        private IUser IsExistUser(string appId, string personId)
        {
            IUser _user = null;
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _user = _proxy.GetUserByPersonId(appId, personId);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return null;
            }

            return _user;
        }

        private void ModifyUser(IUser user)
        {
            this.txtUserName.Text = user.Name;
            this.txtUserName.Tag = user.AppId + "||" + user.PersonId;
            this.txtAccount.Text = user.Account;
            this.chbOriginPass.Checked = false;
            this.chbLock.Checked = user.IsLock;
            this.txtMemo.Text = user.Description;

        }

        //判断在数据字典里是否存在Iorg
        private bool JudgeOrg(String checkedOrgId)
        {
            return roleOrgDictionary[(tvRole.SelectedNode.Tag as IRole).Id].Contains(checkedOrgId);
        }
        //判断角色是否存在
        private bool JudgeRole(String checkedRoleId)
        {
            return roleOrgDictionary.ContainsKey(checkedRoleId);
        }

        //初始化角色树checked设置
        private void InitRoleTreeChecked()
        {
            foreach (String roleId in roleTreeDictionary.Keys)
            {
                if (JudgeRole(roleId))
                {
                    roleTreeDictionary[roleId].Checked = true;
                }
            }
        }

        //获得当前用户信息
        private IUser GetValue()
        {
            currentUser = new User();

            if (origin != null)
            {
                currentUser.Id = origin.Id;
                currentUser.Password = origin.Password;
            }

            currentUser.Name = txtUserName.Text.Trim();
            if (txtUserName.Tag != null)
            {
                string[] _array = txtUserName.Tag.ToString().Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
                currentUser.AppId = _array[0];
                currentUser.PersonId = _array[1];
            }
            currentUser.Account = txtAccount.Text.Trim();

            if (chbOriginPass.Checked)
            {
                currentUser.Password = Common.Util.CreateHash(GetDefaultPassword());
            }

            currentUser.IsLock = chbLock.Checked;
            currentUser.Description = txtMemo.Text.Trim();
            //currentUser.UserId = ((Facade.Context.Operator as NeuPrincipal).Identity as NeuIdentity).User.Id;
            //currentUser.OperDate = Common.Util.GetDateTime();

            return currentUser;
        }

        private void GetRoleOrgMapping()
        {
            IPrivilegeService proxy = Common.Util.CreateProxy();
            using (proxy as IDisposable)
            {
                roleOrgDictionary = proxy.QueryAuthorityRoleOrg(origin);
            }
        }

        private int Save()
        {
            GetValue();
            if (Check())
            {
                IPrivilegeService proxy = Common.Util.CreateProxy();
                using (proxy as IDisposable)
                {
                    int ret = proxy.SaveAuthorityRoleOrg(currentUser, roleOrgDictionary);
                    return ret;
                }
            }
            return 0;
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                MessageBox.Show("请选择用户人员!", "提示");
                this.btnSelectUser.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtAccount.Text.Trim()))
            {
                MessageBox.Show("登录帐户不能为空!", "提示");
                this.txtAccount.Focus();
                return false;
            }

            if (!Neusoft.Framework.Util.StringHelper.ValidMaxLengh(this.txtAccount.Text.Trim(), 20))
            {
                MessageBox.Show("登录帐户长度不能超过20个字符!", "提示");
                this.txtAccount.Focus();
                return false;
            }
            //如果用户没有授权角色，提示
            if (roleOrgDictionary.Count == 0)
            {
                MessageBox.Show("没有给用户授权角色！", "提示");
                return false;
            }

            //验证帐户是否已经存在
            try
            {
                string userId = "";

                if (currentUser != null)
                    userId = currentUser.Id;
                else if (origin != null)
                    userId = origin.Id;

                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    IUser _user = _proxy.GetUserByAccount(txtAccount.Text.Trim());
                    if (_user != null && _user.Id != userId)
                    {
                        MessageBox.Show("该登录帐户已经存在,请使用其他帐户!", "提示");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return false;
            }

            /*if (!Neusoft.Framework.Util.StringHelper.ValidMaxLengh(this.txtPassword.Text.Trim(), 20))
            {
                MessageBox.Show("登录口令长度不能超过20个字符!", "提示");
                this.txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                MessageBox.Show("确认口令和登录口令不符,请重新输入!", "提示");
                txtConfirmPass.Focus();
                return false;
            }*/

            if (!Neusoft.Framework.Util.StringHelper.ValidMaxLengh(this.txtMemo.Text.Trim(), 256))
            {
                MessageBox.Show("备注长度不能超过128个汉字!", "提示");
                this.txtMemo.Focus();
                return false;
            }

            return true;
        }


        #endregion


        #region 事件
        private void AddUserForm_Load(object sender, EventArgs e)
        {
            LoadRole();
            LoadPerson();
            LoadOrg();
            LoadTreeView();
            //修改时初始化设置
            if (origin != null)
            {
                ModifyUser(origin);
                GetRoleOrgMapping();
                InitRoleTreeChecked();
            }
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            SelectItemForm<IPerson> frmSelect = new SelectItemForm<IPerson>();
            frmSelect.Id = "Id";
            frmSelect.Value = "Name";
            frmSelect.Description = "Remark";
            frmSelect.SecondKey = "AppId";
            frmSelect.InitItem(persons);
            frmSelect.ShowDialog();

            if (frmSelect.DialogResult == DialogResult.OK)
            {
                IPerson person = frmSelect.SelectedItem;
                this.txtUserName.Text = person.Name;

                ///判断该用户是否已经增加,如果增加检索出该用户
                IUser user = IsExistUser(person.AppId, person.Id);

                if (user != null)
                {
                    ModifyUser(user);
                    origin = user;

                    //获得用户所属角色
                    GetRoleOrgMapping();
                    //初始化角色树的Checked属性
                    InitRoleTreeChecked();
                }
                else
                {
                    origin = null;

                    this.txtUserName.Text = person.Name;
                    this.txtUserName.Tag = person.AppId + "||" + person.Id;
                    this.txtAccount.Text = person.Id;
                    this.chbOriginPass.Checked = true;
                    this.chbLock.Checked = false;
                    this.txtMemo.Text = "";

                    //新用户,默认一个角色,把当前角色传过来作为默认角色
                    allRolesOfUser.Add(currentRole);

                    this.txtAccount.Focus();
                    this.txtAccount.SelectAll();
                }
            }

            frmSelect.Dispose();
        }

        private void tvRole_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //当前角色没有checked，不可以选择
            if (tvRole.SelectedNode.Checked == false)
            {
                tvOrganization.Enabled = false;
            }
            else
            {
                tvOrganization.Enabled = true;
            }

            //初始化节点checked值
            foreach (KeyValuePair<String, TreeNode> pairTree in orgTreeDictionary)
            {
                tvOrganization.AfterCheck -= tvOrganization_AfterCheck;
                pairTree.Value.Checked = false;
                tvOrganization.AfterCheck += tvOrganization_AfterCheck;
            }

            //选择不同权限，设置以选择的组织结构
            if (roleOrgDictionary != null&&roleOrgDictionary.Count!=0)
            {
                //如果角色组织结构字典里不包含该角色，就不去查找其组织单元的设置，直接返回。
                if(!roleOrgDictionary.ContainsKey((e.Node.Tag as IRole).Id))
                {
                    return;
                }

                foreach (String org in roleOrgDictionary[(e.Node.Tag as IRole).Id])
                {
                    if(org==null)
                    {
                        continue;
                    }
                    if (orgTreeDictionary.ContainsKey(org))
                    {
                        orgTreeDictionary[org].Checked = true;
                    }
                }
            }
        }

        private void tvOrganization_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //没有选择角色，则返回。
            if (tvRole.SelectedNode == null)
            {
                MessageBox.Show("请选择角色！");
                return;
            }
            //判断组织结构是分类节点，不可以Checked
            if ((e.Node.Tag as IOrganization).Id == null)
            {
                tvOrganization.AfterCheck -= tvOrganization_AfterCheck;
                e.Node.Checked = false;
                tvOrganization.AfterCheck += tvOrganization_AfterCheck;
                return;
            }
            if (e.Node.Checked == true)
            {
                if (!JudgeOrg((e.Node.Tag as IOrganization).Id))
                {
                    roleOrgDictionary[(tvRole.SelectedNode.Tag as IRole).Id].Add((e.Node.Tag as IOrganization).Id);
                }
            }
            else
            {
                if (JudgeOrg((e.Node.Tag as IOrganization).Id))
                {
                    roleOrgDictionary[(tvRole.SelectedNode.Tag as IRole).Id].Remove((e.Node.Tag as IOrganization).Id);
                }
            }
        }

        private void tvRole_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tvRole.SelectedNode = e.Node;

            if (e.Node.Checked == true)
            {
                //创建角色和组织结构对应表
                if (!roleOrgDictionary.ContainsKey((e.Node.Tag as IRole).Id))
                {
                    roleOrgDictionary.Add(((e.Node.Tag as IRole).Id), new List<String>());
                }
            }
            if (e.Node.Checked == false)
            {
                if (roleOrgDictionary.ContainsKey((e.Node.Tag as IRole).Id))
                {
                    roleOrgDictionary.Remove((e.Node.Tag as IRole).Id);
                }
            }
            tvRole_AfterSelect(sender, e);
        }

        private void btnChanel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save() == 1)
            {
                MessageBox.Show("保存成功", "消息");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            //先执行保存操作，把当前状态的角色信息，用户信息传到下个Form中。
            if (Save() == 1)
            {
                List<String> roleIdList = new List<string>();
                foreach (String roleId in roleOrgDictionary.Keys)
                {
                    roleIdList.Add(roleId);
                }
                AddUserChildForm frmUserChild = new AddUserChildForm(currentUser, roleIdList);

                frmUserChild.ShowDialog();
            
            }

        }

        private void nTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (nTabControl1.SelectedTab.Name == "tpRoleInfo")
            {
                btnDetail.Visible = true;
            }
            else
            {
                btnDetail.Visible = false;
            }
        }

        #endregion
    }
}