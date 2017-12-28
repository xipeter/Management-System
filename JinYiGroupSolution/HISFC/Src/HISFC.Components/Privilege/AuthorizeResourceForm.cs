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
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.HISFC.Components.Privilege.Common;
using System.Collections;


namespace Neusoft.HISFC.Components.Privilege
{
    public partial class AuthorizeResourceForm : Neusoft.HISFC.Components.Privilege.PermissionBaseForm
    {
        private IList<Role> _roles = new List<Role>();
        List<Role> childList = new List<Role>();
        AuthorizeResourceControl authorizeResourceControl = null;
        AuthorizeUserControl ucUser = null;

        public AuthorizeResourceForm()
        {
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(this.nTabControl1);
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            InitToolBar();
            LoadRole();
            InitControl();

            this.MainToolStrip.ItemClicked += new ToolStripItemClickedEventHandler(MainToolStrip_ItemClicked);

        }

        private void InitToolBar()
        {
            MainToolStrip.Items.Clear();
            ToolBarService _toolBarService = new ToolBarService();
            _toolBarService.Clear();
            _toolBarService.AddToolButton("增加角色", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J角色添加, true, false, null);
            //{8846BB2A-7B61-4a8a-9ED2-293F6F0A4ABA}
           // _toolBarService.AddToolButton("删除角色", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.J角色删除, true, false, null);
            _toolBarService.AddToolSeparator();
            if (nTabControl1.SelectedTab.Name == "UserRes")
            {
                _toolBarService.AddToolButton("增加用户", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员, true, false, null);
                _toolBarService.AddToolButton("修改用户", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R人员修改, true, false, null);
                _toolBarService.AddToolButton("查找用户", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, null);

            }
            if (nTabControl1.SelectedTab.Name == "MenuRes" || nTabControl1.SelectedTab.Name == "WebRes")
            {
                _toolBarService.AddToolButton("增加菜单", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C菜单添加, true, false, null);
                _toolBarService.AddToolButton("删除菜单", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C菜单删除, true, false, null);

            }
            if (nTabControl1.SelectedTab.Name == "DictionaryRes")
            {
                _toolBarService.AddToolButton("增加常数", "",Neusoft.FrameWork.WinForms.Classes.EnumImageList.M模版添加, true, false, null);
                _toolBarService.AddToolButton("删除常数", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.M模版删除, true, false, null);

            }
            if (nTabControl1.SelectedTab.Name == "ReportRes")
            {
                _toolBarService.AddToolButton("增加报表", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细添加, true, false, null);
                _toolBarService.AddToolButton("删除报表", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细删除, true, false, null);

            }
            if (nTabControl1.SelectedTab.Name == "OrgRes")
            {
                _toolBarService.AddToolButton("保存权限", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            }

            _toolBarService.AddToolSeparator();
            _toolBarService.AddToolButton("退出", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出, true, false, null);

            ArrayList toolButtons=_toolBarService.GetToolButtons();
            for (int i = 0; i < toolButtons.Count; i++)
            {
                this.MainToolStrip.Items.Add(toolButtons[i] as ToolStripItem);
            }
            for (int i = 0; i < MainToolStrip.Items.Count; i++)
            {
                this.MainToolStrip.Items[i].TextImageRelation = TextImageRelation.ImageAboveText;
            }
        }

        private void MainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加角色":
                    AddRole();
                    break;
                case "删除角色":
                    DelRole();
                    break;
                case "增加用户":
                    ucUser.AddUser();
                    break;
                case "修改用户":
                    ucUser.ModifyUser();
                    break;
                case "增加菜单":
                    authorizeResourceControl.AddRoleRes();
                    break;
                case "删除菜单":
                    authorizeResourceControl.DelettRoleRes();
                    break;
                case "增加常数":
                    authorizeResourceControl.AddRoleRes();
                    break;
                case "删除常数":
                    authorizeResourceControl.DelettRoleRes();
                    break;
                case "增加报表":
                    authorizeResourceControl.AddRoleRes();
                    break;
                case "删除报表":
                    authorizeResourceControl.DelettRoleRes();
                    break;
                case "保存权限":
                    //ucOrganization.SaveRoleOrg();
                    break;
                case "退出":
                    this.Close();
                    break;
            }
        }

        private void LoadRole()
        {
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();

                using (_proxy as IDisposable)
                {
                    _roles = _proxy.QueryRole();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            TreeNode _root = NewNode((Role)((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup, 6);
            this.tvRole.Nodes.Add(_root);

            this.AddRoleNode(_root, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup.ID);
            _root.Expand();
        }

        private TreeNode NewNode(Role role, int index)
        {
            TreeNode _node = new TreeNode(role.Name);
            _node.Tag = role;
            _node.ImageIndex = index;
            _node.SelectedImageIndex = index;

            return _node;
        }

        private void AddRoleNode(TreeNode parent, string parentId)
        {
            if (_roles != null)
            {
                foreach (Role _item in _roles)
                {
                    if (_item.ParentId == parentId)
                    {
                        TreeNode _node = NewNode(_item, 5);
                        parent.Nodes.Add(_node);

                        AddRoleNode(_node, _item.ID);
                    }
                }
            }
        }

        private void AddRole()
        {
            TreeNode _current = tvRole.SelectedNode;
            if (_current == null) return;

            AddRoleForm _frmAddRole = new AddRoleForm((Role)_current.Tag);
            _frmAddRole.ShowDialog();
            Role _role = _frmAddRole.Current;

            if (_role != null)
            {
                TreeNode _node = NewNode(_role, 5);
                _current.Nodes.Add(_node);
            }

            _frmAddRole.Dispose();
        }

        private void DelRole()
        {
            TreeNode _node = this.tvRole.SelectedNode;
            if (_node == null) return;

            if ((_node.Tag as Role).ID == "roleadmin")
            {
                MessageBox.Show("该角色为系统默认角色,不能删除!", "提示");
                return;
            }

            if (MessageBox.Show("是否要删除该角色?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (_node.Nodes.Count > 0)
            {
                MessageBox.Show("该角色有子角色，不能删除");
                return;
            }

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    try
                    {
                        FrameWork.Management.PublicTrans.BeginTransaction();
                        _proxy.RemoveRole(_node.Tag as Role);
                        FrameWork.Management.PublicTrans.Commit();
                    }
                    catch (Exception e)
                    {
                        FrameWork.Management.PublicTrans.RollBack();
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            _node.Parent.Nodes.Remove(_node);
        }

        private void ModifyRole()
        {
            TreeNode _node = this.tvRole.SelectedNode;
            if (_node == null) return;

            if ((_node.Tag as Role).ID == "roleadmin")
            {
                MessageBox.Show("该角色为系统默认角色,不能修改!", "提示");
                return;
            }

            AddRoleForm _frmAddRole = new AddRoleForm((Role)_node.Parent.Tag, (Role)_node.Tag);
            _frmAddRole.ShowDialog();
            Role _role = _frmAddRole.Current;

            if (_role != null)
            {
                TreeNode _parent = _node.Parent;
                int _index = _parent.Nodes.IndexOf(_node);
                TreeNodeCollection _childs = _node.Nodes;
                _parent.Nodes.Remove(_node);

                TreeNode _current = NewNode(_role, 5);
                foreach (TreeNode _child in _childs)
                {
                    _current.Nodes.Add(_child);
                }

                _parent.Nodes.Insert(_index, _current);
            }

            _frmAddRole.Dispose();
        }

        private void InitControl()
        {
            nTabControl1.SelectedTab.Controls.Clear();
            if (nTabControl1.SelectedTab.Name == "OrgRes")
            {
                //ucOrganization = new AuthorizeOrganizationControl();
                //ucOrganization.currentRole = tvRole.SelectedNode.Tag as Role;
                //ucOrganization.Dock = DockStyle.Fill;
                //nTabControl1.SelectedTab.Controls.Add(ucOrganization);
            }
            else if (nTabControl1.SelectedTab.Name == "UserRes")
            {
                ucUser = new AuthorizeUserControl();
                if (tvRole.SelectedNode != null)
                {
                    ucUser.currentRole = tvRole.SelectedNode.Tag as Role;
                    ucUser.Dock = DockStyle.Fill;
                    nTabControl1.SelectedTab.Controls.Add(ucUser);
                }
            }
            else
            {
                authorizeResourceControl = new AuthorizeResourceControl();
                authorizeResourceControl.pageJudge = nTabControl1.SelectedTab.Name.Trim();
                if (tvRole.SelectedNode != null)
                {
                    authorizeResourceControl.currentRole = tvRole.SelectedNode.Tag as Role;
                    if (tvRole.SelectedNode.Parent != null)
                    {
                        authorizeResourceControl.parentRole = tvRole.SelectedNode.Parent.Tag as Role;
                    }
                    childList.Clear();
                    SetChildRoleList(tvRole.SelectedNode.Nodes);
                    authorizeResourceControl.ChildList = childList;
                }
                authorizeResourceControl.Dock = DockStyle.Fill;
                nTabControl1.SelectedTab.Controls.Add(authorizeResourceControl);
            }
        }

        private void AddRoleMenu_Click(object sender, EventArgs e)
        {
            AddRole();
        }

        private void ModifyRoleMenu_Click(object sender, EventArgs e)
        {
            ModifyRole();
        }

        private void DelRoleMenu_Click(object sender, EventArgs e)
        {
            DelRole();
        }

        private void nTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitToolBar();

            InitControl();
        }

        private void tvRole_AfterSelect(object sender, TreeViewEventArgs e)
        {
            InitControl();
        }

        private void tvRole_DoubleClick(object sender, EventArgs e)
        {
            ModifyRole();
        }

        private void SetChildRoleList(TreeNodeCollection ChildNodes)
        {
            if (ChildNodes == null) return;
            foreach (TreeNode newNode in ChildNodes)
            {
                childList.Add(newNode.Tag as Role);
                SetChildRoleList(newNode.Nodes);
            }
        }


    }
}