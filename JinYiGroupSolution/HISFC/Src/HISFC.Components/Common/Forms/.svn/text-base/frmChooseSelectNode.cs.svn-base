using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Forms
{
    /// <summary>
    ///{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
    /// </summary>
    public partial class frmChooseSelectNode : Form
    {

        private TreeNode selectedNode = null;

        private Neusoft.HISFC.BizLogic.Manager.ComGroup grpMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroup();

        private Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
        public TreeNode SelectedNode
        {
            get { return selectedNode; }
            set { selectedNode = value; }
        }

        
             
        public frmChooseSelectNode()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.neuTreeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择节点！");
                return;
            }

            this.selectedNode = this.neuTreeView1.SelectedNode;

            

            this.DialogResult = DialogResult.OK;
        }

        private int InitTreeView( Neusoft.FrameWork.Models.NeuObject dept)
        {
            this.neuTreeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.Tag = dept;
            rootNode.Text = dept.Name;
            this.neuTreeView1.Nodes.Add(rootNode);
            ArrayList al = this.grpMgr.GetAllGroupsByRoot("1");
            foreach (Neusoft.HISFC.Models.Fee.ComGroup group in al)
            {
                if (group.deptCode == dept.ID)
                {
                    //AddGroup(parent, group);
                    this.AddGroupsRecursion(rootNode, group);
                }
            }

            rootNode.ExpandAll();
            return 1;


        }

        private int InitDept()
        {
            ArrayList al = this.deptMgr.QueryValidDept();

            this.cmbDept.AddItems(al);
            this.cmbDept.Focus();
            return 1;

        }

        private int AddGroupsRecursion(TreeNode parent, Neusoft.HISFC.Models.Fee.ComGroup group)
        {

            ArrayList al = this.grpMgr.GetGroupsByDeptParent("1", group.deptCode, group.ID);
            if (al.Count == 0)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = group;
                newNode.Text = group.Name + "[" + group.ID + "]";
                parent.Nodes.Add(newNode);

                return -1;
            }
            else
            {

                foreach (Neusoft.HISFC.Models.Fee.ComGroup item in al)
                {
                    //if (item.ID == "aaa")
                    //{
                    //    MessageBox.Show("aaa");
                    //}
                    TreeNode newNode = new TreeNode();
                    newNode.Tag = group;
                    newNode.Text = group.Name + "[" + group.ID + "]";
                    parent.Nodes.Add(newNode);
                    return this.AddGroupsRecursion(newNode, item);
                }
            }


            return 1;
        }
        protected override void OnLoad(EventArgs e)
        {
            //this.InitTreeView();
            this.InitDept();
            base.OnLoad(e);
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = null;
            try
            {
               obj  = this.cmbDept.SelectedItem as Neusoft.FrameWork.Models.NeuObject;
            }
            catch (Exception)
            {

                return;
            }
            
            
            this.InitTreeView(obj);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
