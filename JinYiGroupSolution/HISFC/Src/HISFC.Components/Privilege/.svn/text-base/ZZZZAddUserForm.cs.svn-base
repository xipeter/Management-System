using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.Privilege.ServiceContracts.Contract;
using Neusoft.Privilege.ServiceContracts.Model;
using Neusoft.Privilege.ServiceContracts.Model.Impl;
//using Neusoft.Framework;
//using Neusoft.WinForms.Forms;
using Neusoft.Privilege.WinForms.Forms;
namespace Neusoft.Privilege.WinForms
{
    public partial class ZZZZAddUserForm : InputBaseForm
    {
        public ZZZZAddUserForm(IRole role)
        {
            InitializeComponent();

            _currentRole = role;
            this.Init();            
        }

        public ZZZZAddUserForm(IUser user,IRole role)
        {
            InitializeComponent();

            this._origin = user;
            this._currentRole = role;
            this.Init();
        }

        /// <summary>
        /// 全部系统人员列表
        /// </summary>
        private IList<IPerson> _persons = new List<IPerson>();
        private IList<IRole> _roles = new List<IRole>();
        private IRole _currentRole = null;
        private IUser _origin = null;
        private IUser _current = null;
        private IList<string> _newRoles = new List<string>();
        private List<IUser> _newModifyUser = new List<IUser>();
        public List<IUser> NewModifyUser
        {
            get { return _newModifyUser; }            
        }

        private void Init()
        {

            //加载全部人员信息
            LoadPerson();
            //加载全部角色
            LoadRole();

            if (_origin != null)//修改用户
            {
                ModifyUser(_origin);
            }
            else//新增用户
            {
                //新用户,默认一个角色
                NewRole();
            }

            this.Shown += new EventHandler(frmAddUser_Shown);
            this.btnSelectUser.Click += new EventHandler(btnSelectUser_Click);
            this.chbOriginPass.CheckedChanged += new EventHandler(chbOriginPass_CheckedChanged);
            this.chbOriginPass.KeyDown += new KeyEventHandler(chbOriginPass_KeyDown);
            this.chbLock.KeyDown += new KeyEventHandler(chbLock_KeyDown);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnDel.Click += new EventHandler(btnDel_Click);

            this.lvRoleOfUser.MouseDoubleClick += new MouseEventHandler(lvRoleOfUser_MouseDoubleClick);
            this.tvAllRole.MouseDoubleClick += new MouseEventHandler(tvAllRole_MouseDoubleClick);
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

        private int LoadPerson()
        {
            IPrivilegeService _proxy = Common.Util.CreateProxy();

            try
            {
                IList<string> _keys;
                using (_proxy as IDisposable)
                {
                    _keys = _proxy.QueryAppID();
                    foreach (string _key in _keys)
                    {
                        IList<IPerson> _collection = _proxy.QueryPerson(_key);
                        foreach (IPerson _person in _collection)
                        {
                            _persons.Add(_person);
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

        private void LoadRole()
        {
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _roles = _proxy.QueryChildRole((Facade.Context.Operator as NeuPrincipal).CurrentRole.Id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            TreeNode _root = NewNode((Facade.Context.Operator as NeuPrincipal).CurrentRole);
            tvAllRole.Nodes.Add(_root);
            AddSubRoleNode((_root.Tag as IRole), _root);
            _root.Expand();
        }

        private void AddSubRoleNode(IRole parent,TreeNode parentNode)
        {
            foreach (IRole _role in _roles)
            {
                if (_role.ParentId == parent.Id)
                {
                    TreeNode _node = NewNode(_role);
                    parentNode.Nodes.Add(_node);

                    AddSubRoleNode(_role, _node);
                }
            }
        }

        private TreeNode NewNode(IRole role)
        {
            TreeNode _node = new TreeNode(role.Name);
            _node.Tag = role;

            return _node;
        }

        private void ModifyUser(IUser user)
        {
            this.txtUserName.Text = user.Name;
            this.txtUserName.Tag = user.AppId + "||" + user.PersonId;
            this.txtAccount.Text = user.Account;
            this.chbOriginPass.Checked = false;
            this.chbLock.Checked = user.IsLock;
            this.txtMemo.Text = user.Description;

            //获得用户所属角色
            LoadRoleOfUser(user.Id);
        }

        /// <summary>
        /// 获取用户所属角色
        /// </summary>
        /// <param name="userId"></param>
        private void LoadRoleOfUser(string userId)
        {
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                IList<IRole> _rolesOfUser;
                using (_proxy as IDisposable)
                {
                    _rolesOfUser = _proxy.QueryRole(userId);
                }

                AddRoleToList(_rolesOfUser);
                _newRoles = new List<string>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }
        }

        private void AddRoleToList(IList<IRole> roles)
        {
            lvRoleOfUser.Items.Clear();

            foreach (IRole _role in roles)
            {
                ListViewItem _item = NewItem(_role);
                lvRoleOfUser.Items.Add(_item);
            }
        }

        private ListViewItem NewItem(IRole role)
        {
            ListViewItem _item = new ListViewItem(role.Name);
            _item.Tag = role;
            return _item;
        }

        private void NewRole()
        {
            //新用户,默认一个角色
            IList<IRole> _userRoles = new List<IRole>();
            _userRoles.Add(_currentRole);
            AddRoleToList(_userRoles);

            _newRoles = new List<string>();
            _newRoles.Add(_currentRole.Id);
        }

        void frmAddUser_Shown(object sender, EventArgs e)
        {
            if (_origin != null)//修改
                this.txtAccount.Focus();
            else
                this.btnSelectUser.Focus();
        }   

        void btnSelectUser_Click(object sender, EventArgs e)
        {
            SelectItemForm<IPerson> _frmSelect = new SelectItemForm<IPerson>();
            _frmSelect.Id = "Id";
            _frmSelect.Value = "Name";
            _frmSelect.Description = "Remark";
            _frmSelect.SecondKey = "AppId";
            _frmSelect.InitItem(_persons);
            
            if (_frmSelect.ShowDialog() == DialogResult.OK)
            {
                IPerson _person = _frmSelect.SelectedItem;
                this.txtUserName.Text = _person.Name;

                ///判断该用户是否已经增加,如果增加检索出该用户
                ///
                IUser _user = IsExistUser(_person.AppId, _person.Id);

                if (_user != null)
                {
                    ModifyUser(_user);
                    _origin = _user;
                }
                else
                {
                    _origin = null;

                    this.txtUserName.Text = _person.Name;
                    this.txtUserName.Tag = _person.AppId + "||" + _person.Id;
                    this.txtAccount.Text = _person.Id;
                    this.chbOriginPass.Checked = true;
                    this.chbLock.Checked = false;
                    this.txtMemo.Text = "";

                    //新用户,默认一个角色
                    NewRole();

                    this.txtAccount.Focus();
                    this.txtAccount.SelectAll();
                }
            }

            _frmSelect.Dispose();
        }

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

        void chbOriginPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMemo.Focus();
            }
        }

        void chbOriginPass_CheckedChanged(object sender, EventArgs e)
        {
            if (_origin == null&&chbOriginPass.Checked == false )
                this.chbOriginPass.Checked = true;
        }

        void chbLock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK.Focus();
            }
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (!Check()) return;

            IUser _user = GetValue();

            if (!string.IsNullOrEmpty(_user.Id) && _user.Id == "admin")
            {
                MessageBox.Show("该用户为系统默认用户,不能修改!", "提示");
                return;
            }

            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _user = _proxy.SaveUser(_user, _newRoles);
                }
                if (_user == null) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }

            _newRoles = new List<string>();
            AddUser(_user);
            _origin = _user;

            MessageBox.Show("保存成功!", "提示");
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

            //验证帐户是否已经存在
            try
            {         
                string userId = "";

                if (_current != null)
                    userId = _current.Id;
                else if (_origin != null)
                    userId = _origin.Id;

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

        private IUser GetValue()
        {            
            _current = new User();

            if (_origin != null)
            {
                _current.Id = _origin.Id;
                _current.Password = _origin.Password;
            }

            _current.Name = txtUserName.Text.Trim();
            string[] _array = txtUserName.Tag.ToString().Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
            _current.AppId = _array[0];
            _current.PersonId = _array[1];
            _current.Account = txtAccount.Text.Trim();

            if (chbOriginPass.Checked)
            {
                _current.Password = Common.Util.CreateHash(GetDefaultPassword());
            }

            _current.IsLock = chbLock.Checked;
            _current.Description = txtMemo.Text.Trim();
            //_current.UserID = ((Facade.Context.Operator as NeuPrincipal).Identity as NeuIdentity).User.ID;
            //_current.OperDate = Common.Util.GetDateTime();

            return _current;
        }

        private void AddUser(IUser user)
        {
            foreach (IUser _user in _newModifyUser)
            {
                if (_user.Id == user.Id)
                {
                    _newModifyUser.Remove(_user);
                    break;
                }
            }

            _newModifyUser.Add(user);
        }

        void btnDel_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection _items = lvRoleOfUser.SelectedItems;
            if (_items.Count == 0) return;

            if (MessageBox.Show("是否要删除该角色?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            try
            {
                string userId = "";

                if (_current != null)
                    userId = _current.Id;
                else if (_origin != null)
                    userId = _origin.Id;

                if (userId != "")
                {
                    IPrivilegeService _proxy = Common.Util.CreateProxy();
                    using (_proxy as IDisposable)
                    {
                        _proxy.RemoveRoleUserMap((_items[0].Tag as IRole).Id, userId);
                    }
                }

                _newRoles.Remove((_items[0].Tag as IRole).Id);
                lvRoleOfUser.Items.Remove(_items[0]);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            TreeNode _node = tvAllRole.SelectedNode;
            if (_node == null) return;

            foreach (ListViewItem _item in lvRoleOfUser.Items)
            {
                if ((_item.Tag as IRole).Id == (_node.Tag as IRole).Id)
                {
                    MessageBox.Show("该角色已经存在,不能重复添加!", "提示");
                    return;
                }
            }

            ListViewItem _newItem = NewItem(_node.Tag as IRole);
            lvRoleOfUser.Items.Add(_newItem);
            _newRoles.Add((_newItem.Tag as IRole).Id);
        }

        void tvAllRole_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdd_Click(null, null);
        }

        void lvRoleOfUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnDel_Click(null, null);
        }       
    }
}

