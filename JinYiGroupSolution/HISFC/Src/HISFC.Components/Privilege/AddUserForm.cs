using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;
using Neusoft.HISFC.BizLogic.Privilege;
using Neusoft.HISFC.Models.Privilege;
//using Neusoft.WinForms.Forms;

//using Neusoft.Framework;



namespace Neusoft.HISFC.Components.Privilege
{
    public partial class AddUserForm : Neusoft.HISFC.Components.Privilege.InputBaseForm
    {
        private IList<Role> roles = new List<Role>();
        private IList<Organization> organizations = new List<Organization>();
        private Role currentRole = null;
        private IList<Person> persons = new List<Person>();
        private List<User> newModifyUser = new List<User>();
        private IList<Role> allRolesOfUser = new List<Role>();
        ////当前角色组织结构关系
        //private Dictionary<Role, List<Organization>> roleOrgMapping = new Dictionary<Role, List<Organization>>();
        //当前角色组织结构关系
        private Dictionary<String, List<String>> roleOrgDictionary = new Dictionary<String, List<String>>();
        //组织结构树
        private Dictionary<String, TreeNode> orgTreeDictionary = new Dictionary<String, TreeNode>();
        //角色树
        private Dictionary<String, TreeNode> roleTreeDictionary = new Dictionary<String, TreeNode>();
        //修改时，传过来的用户信息
        private User origin = null;
        //当前获取控件的用户信息
        private User currentUser = null;

        public AddUserForm(Role _currentRole)
        {
            currentRole = _currentRole;
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(this.nTabControl1);
        }

        public AddUserForm(User user, Role _currentRole)
        {
            currentRole = _currentRole;
            origin = user;
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(this.nTabControl1);
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
        //private void LoadOrg()
        //{
        //    try
        //    {
        //        PrivilegeService _proxy = Common.Util.CreateProxy();
        //        using (_proxy as IDisposable)
        //        {
        //            organizations = _proxy.QueryUnit("HIS");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "提示");
        //        return;
        //    }
        //}

        private void LoadRole()
        {
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    //roles = _proxy.QueryChildRole(((Role)((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup).ID);
                    roles = _proxy.QueryChildRole(currentRole.ID);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            //TreeNode _root = NewNode((Role)((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup);
            //roles.Add((Role)((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup);
            //roleTreeDictionary.Add(Neusoft.FrameWork.Management.Connection.Operator.ID, _root);
            //tvRole.Nodes.Add(_root);

            TreeNode _root = NewNode(currentRole);
            roles.Add(currentRole);
            roleTreeDictionary.Add(currentRole.ID, _root);
            tvRole.Nodes.Add(_root);
            AddSubRoleNode((_root.Tag as Role), _root);
            _root.Expand();
        }

        private int LoadPerson()
        {
            PrivilegeService proxy = Common.Util.CreateProxy();

            try
            {
                IList<string> keys;
                using (proxy as IDisposable)
                {
                    keys = proxy.QueryAppID();
                    foreach (string _key in keys)
                    {
                        IList<Person> collection = proxy.QueryPerson(_key);
                        foreach (Person person in collection)
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

        //private void LoadTreeView()
        //{
        //    tvOrganization.Nodes.Clear();

        //    //设置但前根节点Tag
        //    if (organizations != null)
        //    {
        //        Organization rootOrg = organizations[0];


        //        TreeNode rootNode = new TreeNode();
        //        rootNode.Text = rootOrg.Department.Name.ToString();
        //        rootNode.Tag = rootOrg;
        //        rootNode.Expand();
        //        tvOrganization.Nodes.Add(rootNode);

        //        //删除根节点，准备遍历子节点
        //        organizations.RemoveAt(0);

        //        SetChildNode(rootNode, organizations);
        //    }

        //}

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
                    orgTreeDictionary.Add((node.Tag as Organization).ID, node);
                    SetChildNode(node, organizations);
                }

            }

        }

        private void AddSubRoleNode(Role parent, TreeNode parentNode)
        {
            foreach (Role _role in roles)
            {
                if (_role.ParentId == parent.ID)
                {
                    TreeNode _node = NewNode(_role);
                    _node.Tag = _role;
                    roleTreeDictionary.Add(_role.ID, _node);
                    parentNode.Nodes.Add(_node);

                    AddSubRoleNode(_role, _node);
                }
            }
        }

        private TreeNode NewNode(Role role)
        {
            TreeNode _node = new TreeNode(role.Name);
            _node.Tag = role;
            _node.Name = role.ID;
            return _node;
        }

        private string GetDefaultPassword()
        {
            string _value = System.Configuration.ConfigurationManager.AppSettings["DefaultPassword"];
            if (string.IsNullOrEmpty(_value))
            {
                //return "-";
                //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
                return "F07ZpVACvxE=";
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
        private User IsExistUser(string appId, string personId)
        {
            User _user = null;
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
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

        private void ModifyUser(User user)
        {
            this.txtUserName.Text = user.Name;
            this.txtUserName.Tag = user.AppId + "||" + user.PersonId;
            this.txtAccount.Text = user.Account;
            this.chbOriginPass.Checked = false;
            this.chbLock.Checked = user.IsLock;
            this.txtMemo.Text = user.Description;
            //{46A2B736-8740-405a-8B0A-6DDF1B705B8D}
            this.chbManager.Checked = user.IsManager;

        }

        //判断在数据字典里是否存在Iorg
        private bool JudgeOrg(String checkedOrgId)
        {
            return roleOrgDictionary[(tvRole.SelectedNode.Tag as Role).ID].Contains(checkedOrgId);
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
                else
                {
                    roleTreeDictionary[roleId].Checked = false;
                }
            }
        }

        //获得当前用户信息
        private User GetValue()
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
                currentUser.Password =GetDefaultPassword();
            }

            currentUser.IsLock = chbLock.Checked;
            currentUser.Description = txtMemo.Text.Trim();
            currentUser.operId = Neusoft.FrameWork.Management.Connection.Operator.ID;
            currentUser.OperDate = FrameWork.Function.NConvert.ToDateTime(new FrameWork.Management.DataBaseManger().GetSysDateTime());
            //{46A2B736-8740-405a-8B0A-6DDF1B705B8D}
            currentUser.IsManager = this.chbManager.Checked;

            return currentUser;
        }

        private void GetRoleOrgMapping()
        {
            PrivilegeService proxy = Common.Util.CreateProxy();
            using (proxy as IDisposable)
            {
                roleOrgDictionary = proxy.QueryAuthorityRoleOrg(origin);
            }
        }

        private int Save()
        {
            int ret = -1;
            GetValue();
            if (Check())
            {
   
                PrivilegeService proxy = Common.Util.CreateProxy();
                using (proxy as IDisposable)
                {
                    try
                    {
                        FrameWork.Management.PublicTrans.BeginTransaction();
                        ret = proxy.SaveAuthorityRoleOrg(currentUser, roleOrgDictionary);
                        FrameWork.Management.PublicTrans.Commit();

                    }
                    catch (Exception e)
                    {
                        FrameWork.Management.PublicTrans.RollBack();
                        ret=-1;
                    }
                }

            }
            return ret;
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

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtAccount.Text.Trim(), 20))
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

                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    User _user = _proxy.GetUserByAccount(txtAccount.Text.Trim());
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

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtMemo.Text.Trim(), 256))
            {
                MessageBox.Show("备注长度不能超过128个汉字!", "提示");
                this.txtMemo.Focus();
                return false;
            }

            return true;
        }

        private void DeleteUser()
        {
            if (origin.Id == "admin")
            {
                MessageBox.Show("系统默认用户不能删除！");
                return;
            }
            //{8846BB2A-7B61-4a8a-9ED2-293F6F0A4ABA}
            if (MessageBox.Show("【删除用户】操作将删除用户下的所有权限，请您慎重！\n您确认要删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            PrivilegeService proxy = Common.Util.CreateProxy();
            using (proxy as IDisposable)
            {
                int ret = proxy.DeleteAuthority(origin);
                if (ret >= 0)
                {
                    this.DialogResult = DialogResult.OK;
                    base.Close();
                }
            }
            
        }

        #endregion


        #region 事件
        private void AddUserForm_Load(object sender, EventArgs e)
        {
            LoadRole();
            LoadPerson();
            //LoadOrg();
            //LoadTreeView();
            //修改时初始化设置
            if (origin != null)
            {
                ModifyUser(origin);
                GetRoleOrgMapping();
                InitRoleTreeChecked();
                btnDeleteUser.Enabled = true;
            }
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            SelectItemForm<Person> frmSelect = new SelectItemForm<Person>();
            frmSelect.Id = "Id";
            frmSelect.Value = "Name";
            frmSelect.Description = "Remark";
            frmSelect.SecondKey = "AppId";
            frmSelect.InitItem(persons);
            frmSelect.ShowDialog();

            if (frmSelect.DialogResult == DialogResult.OK)
            {
                Person person = frmSelect.SelectedItem;
                this.txtUserName.Text = person.Name;

                ///判断该用户是否已经增加,如果增加检索出该用户
                User user = IsExistUser(person.AppId, person.Id);

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
                    //获得用户所属角色
                    roleOrgDictionary = new Dictionary<string, List<string>>();
                    //初始化角色树的Checked属性
                    InitRoleTreeChecked();

                    this.txtUserName.Text = person.Name;
                    this.txtUserName.Tag = person.AppId + "||" + person.Id;
                    this.txtAccount.Text = person.Id;
                    this.chbOriginPass.Checked = true;
                    this.chbLock.Checked = false;
                    this.txtMemo.Text = "";

                    ////新用户,默认一个角色,把当前角色传过来作为默认角色
                    //allRolesOfUser.Add(currentRole);

                    this.txtAccount.Focus();
                    this.txtAccount.SelectAll();
                }
            }

            frmSelect.Dispose();
        }

        private void tvRole_AfterSelect(object sender, TreeViewEventArgs e)
        {

            ////当前角色没有checked，不可以选择
            //if (tvRole.SelectedNode.Checked == false)
            //{
            //    tvOrganization.Enabled = false;
            //}
            //else
            //{
            //    tvOrganization.Enabled = true;
            //}

            //初始化节点checked值
            //foreach (KeyValuePair<String, TreeNode> pairTree in orgTreeDictionary)
            //{
            //    tvOrganization.AfterCheck -= tvOrganization_AfterCheck;
            //    pairTree.Value.Checked = false;
            //    tvOrganization.AfterCheck += tvOrganization_AfterCheck;
            //}

            //选择不同权限，设置以选择的组织结构
            if (roleOrgDictionary != null&&roleOrgDictionary.Count!=0)
            {
                //如果角色组织结构字典里不包含该角色，就不去查找其组织单元的设置，直接返回。
                if (!roleOrgDictionary.ContainsKey((e.Node.Tag as Role).ID))
                {
                    return;
                }

                foreach (String org in roleOrgDictionary[(e.Node.Tag as Role).ID])
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
            ////判断组织结构是分类节点，不可以Checked
            //if ((e.Node.Tag as Organization).ID == null)
            //{
            //    tvOrganization.AfterCheck -= tvOrganization_AfterCheck;
            //    e.Node.Checked = false;
            //    tvOrganization.AfterCheck += tvOrganization_AfterCheck;
            //    return;
            //}
            if (e.Node.Checked == true)
            {
                if (!JudgeOrg((e.Node.Tag as Organization).ID))
                {
                    roleOrgDictionary[(tvRole.SelectedNode.Tag as Role).ID].Add((e.Node.Tag as Organization).ID);
                }
            }
            else
            {
                if (JudgeOrg((e.Node.Tag as Organization).ID))
                {
                    roleOrgDictionary[(tvRole.SelectedNode.Tag as Role).ID].Remove((e.Node.Tag as Organization).ID);
                }
            }
        }

        private void tvRole_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tvRole.SelectedNode = e.Node;

            if (e.Node.Checked == true)
            {
                //创建角色和组织结构对应表
                if (!roleOrgDictionary.ContainsKey((e.Node.Tag as Role).ID))
                {
                    roleOrgDictionary.Add(((e.Node.Tag as Role).ID), new List<String>());
                }
            }
            if (e.Node.Checked == false)
            {
                if (roleOrgDictionary.ContainsKey((e.Node.Tag as Role).ID))
                {
                    roleOrgDictionary.Remove((e.Node.Tag as Role).ID);
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
            if (Save() == 0)
            {
                MessageBox.Show("保存成功", "消息");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("保存失败", "消息");
            }
        }

        private void nTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            //if (nTabControl1.SelectedTab.Name == "tpRoleInfo")
            //{
            //    btnDetail.Visible = true;

            //}
            //else
            //{
            //    btnDetail.Visible = false;
            //}
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }
        #endregion


    }
}