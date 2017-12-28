using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.UFC.Privilege.Forms;
using Neusoft.Privilege.BizLogic.Model;
namespace Neusoft.UFC.Privilege
{
    public partial class SelectRoleForm : InputBaseForm
    {
        public SelectRoleForm(IList<Role> roles)
        {
            InitializeComponent();

            _roles = roles;

            this.Init();
            this.IsStatusStripVisible = false;
        }

        private IList<Role> _roles;

        private void Init()
        {
            this.nTreeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(nTreeView1_NodeMouseDoubleClick);

            foreach (Role _role in _roles)
            {
                TreeNode _node = new TreeNode(_role.Name);
                _node.ImageIndex = 0;
                _node.Tag = _role;
                this.nTreeView1.Nodes.Add(_node);
            }
            this.nTreeView1.ExpandAll();
        }

        void nTreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public Role SelectedRole
        {
            get
            {
                TreeNode _node = this.nTreeView1.SelectedNode;
                if (_node == null) return null;

                return _node.Tag as Role;
            }
        }
       
    }
}