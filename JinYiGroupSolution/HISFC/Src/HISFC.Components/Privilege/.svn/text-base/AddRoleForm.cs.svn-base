using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



using System.ServiceModel;
//using Neusoft.Framework;
//using Neusoft.WinForms.Forms;
using Neusoft.HISFC.Components.Privilege;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;


namespace Neusoft.HISFC.Components.Privilege
{
    public partial class AddRoleForm : InputBaseForm
    {

        /// <summary>
        /// 父级角色
        /// </summary>
        private Role _parent = null;

        /// <summary>
        /// 当前角色
        /// </summary>
        private Role _origin = null;
        private Role _current = null;
        private IList<User> _userCollection = null;
        private IList<string> _newUserID = new List<string>();

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="parent"></param>
        public AddRoleForm(Role parent)
        {
            _parent = parent;

            this.Init();
            
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="current"></param>
        public AddRoleForm(Role parent, Role current)
        {
            _parent = parent;
            _origin = current;

            this.Init();
        }

        public Role Current
        {
            get { return _current; }
        }

        private void Init()
        {
            InitializeComponent();

            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(nTabControl1);
            Neusoft.FrameWork.WinForms.Classes.Function.SetListViewStyle(lvUser);
            this.Load += new EventHandler(frmAddRole_Load);
            this.Shown += new EventHandler(frmAddRole_Shown);
            this.bnOK.Click += new EventHandler(bnOK_Click);

            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnDel.Click += new EventHandler(btnDel_Click);

            this.lvUser.DoubleClick += new EventHandler(lvUser_DoubleClick);
        }
      
        void frmAddRole_Load(object sender, EventArgs e)
        {
            // _unitCollection = GetSubUnit();

            //修改角色
            if (_origin != null)
            {
                this.txtRoleName.Text = _origin.Name;//角色名称
                //this.txtUnitName.Text = getUnitByID(_origin.AppId, _origin.UnitId).Name;
                //this.txtUnitName.Tag = _origin.AppId + "||" + _origin.UnitId;
                this.txtMemo.Text = _origin.Description;

                //获得角色包含的用户 
                try
                {

                    PrivilegeService _proxy = Common.Util.CreateProxy();
                    using (_proxy as IDisposable)
                    {
                        //用于表更改，修改了SQL语句Security.Org.User.GetByRoleID
                        _userCollection = _proxy.QueryUser(_origin.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                    return;
                }

                AddUserOfRole();
            }
            else//新增角色
            {
                ////组织单元默认为上级角色的所属单元
                //this.txtUnitName.Text = getUnitByID(_parent.AppId, _parent.UnitId).Name;
                //this.txtUnitName.Tag = _parent.AppId + "||" + _parent.UnitId;
            }

            this.txtParentName.Text = _parent.Name;
        }

        void frmAddRole_Shown(object sender, EventArgs e)
        {
            this.txtRoleName.Focus();
        }

        private void AddUserOfRole()
        {
            if (_userCollection != null)
            {
                foreach (User _user in _userCollection)
                {
                    AddUserToList(_user);
                }
            }
        }

        private void AddUserToList(User user)
        {
            ListViewItem _item = new ListViewItem(new string[] { user.PersonId,user.Name,user.Account,
                                         (user.IsLock?"是":"否"),user.Description});
            _item.Tag = user;
            this.lvUser.Items.Add(_item);
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            if (Check() == -1) return;
            Role _role = GetValue();

            try
            {
                FrameWork.Management.PublicTrans.BeginTransaction();

                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _current = _proxy.SaveRole(_role, _newUserID);
                }
                FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception ex)
            {
                _current = null;
                FrameWork.Management.PublicTrans.RollBack();

                MessageBox.Show(ex.Message);
                return;
            }

            _newUserID = new List<string>();
            MessageBox.Show("保存成功!", "提示");
        }

        private int Check()
        {
            if (string.IsNullOrEmpty(this.txtRoleName.Text.Trim()))
            {
                MessageBox.Show("角色名称不能为空!", "提示");
                this.txtRoleName.Focus();
                return -1;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtRoleName.Text.Trim(), 32))
            {
                MessageBox.Show("角色名称长度不能超过16个汉字!", "提示");
                this.txtRoleName.Focus();
                return -1;
            }

            //if (this.txtUnitName.Tag == null || this.txtUnitName.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择角色的所属单元!", "提示");
            //    this.nButton1.Focus();
            //    return -1;
            //}

            if (!FrameWork.Public.String.ValidMaxLengh(this.txtMemo.Text.Trim(), 100))
            {
                MessageBox.Show("备注长度不能超过50个汉字!", "提示");
                this.txtMemo.Focus();
                return -1;
            }

            return 0;
        }

        private Role GetValue()
        {
            if (_current == null) _current = new Role();

            if (_origin != null)
            {
                _current.ID = _origin.ID;
            }

            _current.Name = txtRoleName.Text.Trim();
            _current.ParentId = _parent.ID;
            //string[] _array = txtUnitName.Tag.ToString().Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
            // _current.AppId = _array[0];
            //_current.UnitId = _array[1];
            _current.Description = txtMemo.Text.Trim();
            _current.UserId = Neusoft.FrameWork.Management.Connection.Operator.ID;
            _current.OperDate = FrameWork.Function.NConvert.ToDateTime(new FrameWork.Management.DataBaseManger().GetSysDateTime());

            return _current;
        }

        void btnDel_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection _items = lvUser.SelectedItems;
            if (_items.Count == 0) return;

            if (MessageBox.Show("是否在" + _origin.Name + "角色中，取消" + (_items[0].Tag as User).Name + "用户?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            try
            {
                string _roleId = "";

                if (_current != null)
                    _roleId = _current.ID;
                else if (_origin != null)
                    _roleId = _origin.ID;

                if (_roleId != "")
                {
                    PrivilegeService _proxy = Common.Util.CreateProxy();
                    using (_proxy as IDisposable)
                    {
                        //角色和权限的对应关系表改变
                        //_proxy.RemoveRoleUserMap(_roleId, (_items[0].Tag as User).Id);
                        _proxy.CancelAuthority((_items[0].Tag as User).Id, _roleId);
                    }
                }

                _newUserID.Remove((_items[0].Tag as User).Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }

            lvUser.Items.Remove(_items[0]);

            MessageBox.Show("删除成功!", "提示");
        }

        void lvUser_DoubleClick(object sender, EventArgs e)
        {
            btnDel_Click(null, null);
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            SelectItemForm<User> _frmSelect = new SelectItemForm<User>();
            _frmSelect.Id = "Id";
            _frmSelect.Value = "Name";
            _frmSelect.Description = "Description";

            IList<User> _users = null;

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _users = _proxy.QueryUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }

            _frmSelect.InitItem(_users);

            if (_frmSelect.ShowDialog() == DialogResult.OK)
            {
                User _user = _frmSelect.SelectedItem;
                if (_user == null) return;

                //存在该用户,提示返回
                if (IsExistUser(_user))
                {
                    MessageBox.Show("角色下面已经存在该用户,不能重复添加!", "提示");
                    return;
                }

                //添加用户
                AddUserToList(_user);

                _newUserID.Add(_user.Id);
            }

            _frmSelect.Dispose();
        }

        private bool IsExistUser(User user)
        {
            foreach (ListViewItem _item in lvUser.Items)
            {
                if ((_item.Tag as User).Id == user.Id) return true;
            }

            return false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        


        #region 去掉新建角色中，增加组织结构代码
        // private IList<Organization> _unitCollection = null;

        ///// <summary>
        ///// 选择所属单元
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void nButton1_Click(object sender, EventArgs e)
        //{
        //    this.txtUnitName.Tag = null;
        //    this.txtUnitName.Text = "";

        //    TreeForm<Organization> _tree = new TreeForm<Organization>();
        //    _tree.DataMember = "Id";
        //    _tree.DisplayMember = "Name";
        //    _tree.ParentMember = "ParentId";

        //    Point _p = this.ContentPanel.PointToScreen(new Point(nButton1.Location.X + nButton1.Width+tabPage1.Padding.Left, nButton1.Location.Y));

        //    _tree.Show(_unitCollection, _parent.AppId + "||" + _parent.UnitId, _p );

        //    if (_tree.DialogResult == DialogResult.OK)
        //    {
        //        IList<Organization> _list = _tree.GetSelectedNode();

        //        if (_list.Count > 0)
        //        {
        //            //所选组织单元级别不能小于下级角色的组织单元
        //            string[] _array = _list[0].Id.Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
        //            if (!IsOneTree(_array[0], _array[1]))
        //            {
        //                MessageBox.Show("该组织单元级别低于下属角色的组织级别!", "提示");
        //                return;
        //            }

        //            this.txtUnitName.Text = _list[0].Name;
        //            this.txtUnitName.Tag = _list[0].Id;
        //        }
        //    }

        //    _tree.Dispose();
        //}

        /// <summary>
        /// 所选组织单元级别不能小于下级角色的组织单元
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        //private bool IsOneTree(string appId, string unitId)
        //{
        //    //得到当前角色下包含的角色
        //    string roleId;

        //    if (_current != null)//新增保存后,又保存
        //    {
        //        roleId = _current.Id;
        //    }
        //    else if (_origin != null)//修改角色
        //    {
        //        roleId = _origin.Id;
        //    }
        //    else return true;//新增,不判断

        //    PrivilegeService _proxy = Common.Util.CreateProxy();
        //    IList<Role> _childs;
        //    using (_proxy as IDisposable)
        //    {
        //        _childs = _proxy.QueryChildRole(roleId);
        //    }

        //    foreach (Role _child in _childs)
        //    {
        //        if (_child.ParentId == roleId)//儿子,不是孙子以下
        //        {
        //            bool _isFather = IsParent(_child, appId, unitId);
        //            if (!_isFather) return false;
        //        }
        //    }

        //    return true;
        //}

        //private bool IsParent(Role child, string appId, string unitId)
        //{
        //    Organization _unit = getUnitByID(child.AppId,child.UnitId);
        //    Organization _parentUnit = getUnitByID(_parent.AppId, _parent.UnitId);

        //    while (_unit != null && _unit.Id != _parentUnit.ParentId)//没到父级角色组织机构的父亲
        //    {
        //        if (_unit.Id == appId + "||" + unitId)
        //        {
        //            return true;
        //        }

        //        string[] _array = _unit.ParentId.Split(new char[] { '|', '|' }, StringSplitOptions.RemoveEmptyEntries);
        //        if (_unit.ParentId == "NEU||")
        //            _unit = null;//到根了,没有父亲了
        //        else
        //            _unit = getUnitByID(_array[0], _array[1]);
        //    }

        //    return false;
        //}


        //private IList<Organization> GetSubUnit()
        //{
        //    NeuPrincipal _principal = (NeuPrincipal)Facade.Context.Operator;
        //    IList<Organization> _units = new List<Organization>();
        //    PrivilegeService _securityProxy = Common.Util.CreateProxy();

        //    if (_principal.CurrentRole.UnitId == "root" && _principal.CurrentRole.AppId == "NEU")//系统管理员,返回所有单元
        //    {
        //        IList<string> _keys;
        //        using (_securityProxy as IDisposable)
        //        {
        //            _keys = _securityProxy.QueryAppID();

        //            foreach (string _key in _keys)
        //            {
        //                IList<Organization> _subUnits;
        //                _subUnits = _securityProxy.QueryUnit(_key);

        //                foreach (Organization _unit in _subUnits)
        //                {
        //                    _unit.Id = _key + "||" + _unit.Id;
        //                    if (_unit.ParentId == "root")
        //                    {
        //                        _unit.ParentId = "NEU||" + _unit.ParentId;
        //                    }
        //                    else
        //                    {
        //                        _unit.ParentId = _key + "||" + _unit.ParentId;
        //                    }

        //                    _units.Add(_unit);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        IList<Organization> _subUnits;
        //        using (_securityProxy as IDisposable)
        //        {
        //            _subUnits = _securityProxy.QueryUnit(_principal.CurrentRole.AppId);
        //        }

        //        foreach (Organization _unit in _subUnits)
        //        {
        //            _unit.Id = _principal.CurrentRole.AppId + "||" + _unit.Id;
        //            if (_unit.ParentId == "root")
        //            {
        //                _unit.ParentId = "NEU||" + _unit.ParentId;
        //            }
        //            else
        //            {
        //                _unit.ParentId = _principal.CurrentRole.AppId + "||" + _unit.ParentId;
        //            }
        //            _units.Add(_unit);
        //        }
        //    }

        //    return _units;
        //}        

        ///// <summary>
        ///// 根据代码获得组织单元
        ///// </summary>
        ///// <param name="appId"></param>
        ///// <param name="unitId"></param>
        ///// <returns></returns>
        //private Organization getUnitByID(string appId, string unitId)
        //{      
        //    if (_unitCollection != null)
        //    {
        //        foreach (Organization _unit in _unitCollection)
        //        {
        //            if (_unit.Id == appId + "||" + unitId) return _unit;
        //        }
        //    }

        //    return null;
        //}

        #endregion
    }
}