using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;
using Neusoft.HISFC.Models.Privilege;
using System.Collections;

namespace HIS
{
    public partial class SelectRoleForm : Form
    {

        public SelectRoleForm(User user,IList<Role> roles)
        {
            InitializeComponent();
            this.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _roles = roles;
            currentUser = user;
            //{36DEFA19-3650-443f-A173-E2A355FA00C2}
            //this.Init();
            this.Init(user);
        }

        private IList<Role> _roles;
        private User currentUser;

        private void Init(User user)
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

            //初始化科室信息，只通过人员信息判断其能登录的科室。
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager manager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();





            //System.Collections.ArrayList alDepts = manager.GetMultiDeptNew(currentUser.PersonId);

            System.Collections.ArrayList alDepts = null;

            //{36DEFA19-3650-443f-A173-E2A355FA00C2}
            Neusoft.HISFC.BizLogic.Manager.Person p = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.Models.Base.Employee empl = p.GetPersonByID(user.PersonId);
            ////{A4ED7668-8B4C-441f-9A0D-7029EA040B14}
            //if (empl.EmployeeType.ID.ToString() == "N")
            //{
            //    alDepts = manager.GetMultiDeptNewForNurser(currentUser.PersonId);
            //}
            //else
            //{
            //    alDepts = manager.GetMultiDeptNew(currentUser.PersonId);
            //}
            
                alDepts = manager.GetMultiDeptNew(currentUser.PersonId);
            

            //如果是管理员，默认科室信息。
            if (currentUser.Id == "admin")
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "admin";
                obj.Name = "admin";
                ArrayList list = new ArrayList();
                list.Add(obj);
                this.cmbDept.AddItems(list);
            }
            else
            {
                this.cmbDept.AddItems(alDepts);
            }
            if (alDepts != null)
            {
                this.cmbDept.SelectedIndex = 0;
            }

            //#region 默认上次登录信息
            ////{9DF35C63-1468-4fa5-BBEA-5D00197C0994} yangw 20100831
            //Neusoft.HISFC.BizLogic.Manager.UserManager userMgr = new Neusoft.HISFC.BizLogic.Manager.UserManager();
            //Neusoft.FrameWork.Models.NeuObject lastLoginInfo = userMgr.GetLastLoginInfo(currentUser.operId, 10);
            //if (lastLoginInfo != null)
            //{
            //    //登录科室
            //    foreach (Neusoft.FrameWork.Models.NeuObject o in cmbDept.alItems)
            //    {
            //        if (o.ID == lastLoginInfo.ID)
            //        {
            //            cmbDept.Tag = lastLoginInfo.ID;
            //            break;
            //        }
            //    }

            //    //登录模块
            //    foreach (TreeNode n in nTreeView1.Nodes)
            //    {
            //        if (n.Text == lastLoginInfo.Name)
            //        {
            //            nTreeView1.SelectedNode = n;
            //            break;
            //        }
            //    }
            //}
            //#endregion
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

                Role selectedRole = _node.Tag as Role;

                //该角色没有设置多科室，默认当前用户所在科室为登录科室。
                if (cmbDept.Tag != null)
                {
                    selectedRole.UnitId = cmbDept.Tag.ToString();
                }

                return selectedRole;
            }
        }

        private void nTreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

   
       
    }
}