using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.DrugStore
{
    public partial class ucStoQuit : Report.Common.ucQueryBaseForDataWindow
    {
        public ucStoQuit()
        {
            InitializeComponent();
            this.plRightBottom.Visible = false;
        }
        protected override int OnDrawTree()
        {
            if (this.tvLeft == null)
            {
                return -1;
            }

            Neusoft.HISFC.BizLogic.Manager.Department deptMagr = new Neusoft.HISFC.BizLogic.Manager.Department();

            ArrayList deptList = deptMagr.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);

            TreeNode root = new TreeNode();
            root.Text = "所有科室";
            root.Tag = "ROOT";
            this.tvLeft.Nodes.Add(root);

            TreeNode nodePI;
            nodePI = new TreeNode();
            nodePI.Tag = "ROOT";
            nodePI.Text = "药库";
            root.Nodes.Add(nodePI);
            TreeNode node;
            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                node = new TreeNode();
                node.Text = dept.Name;
                node.Tag = dept.ID;
                nodePI.Nodes.Add(node);
            }

            deptList = deptMagr.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

            TreeNode nodeP = new TreeNode();
            nodeP.Tag = "ROOT";
            nodeP.Text = "药房";
            root.Nodes.Add(nodeP);
            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                node = new TreeNode();
                node.Text = dept.Name;
                node.Tag = dept.ID;
                nodeP.Nodes.Add(node);
            }

            root.ExpandAll();


            if (base.OnDrawTree() == -1)
            {
                return -1;
            }
            else
            {
                root.ImageIndex = 1;
                root.SelectedImageIndex = 1;
                nodePI.ImageIndex = 1;
                nodePI.SelectedImageIndex = 1;
                nodeP.ImageIndex = 1;
                nodeP.SelectedImageIndex = 1;
            }

            return 0;
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            TreeNode node = this.tvLeft.SelectedNode;

            if (node.Tag.ToString().Equals("ROOT"))
            {
                return -1;
            }
            else
            {
                objects = new object[] { node.Tag.ToString(), this.beginTime, this.endTime, node.Text };
            }

            return this.dwMain.Retrieve(objects);
        }

       
    }
}

