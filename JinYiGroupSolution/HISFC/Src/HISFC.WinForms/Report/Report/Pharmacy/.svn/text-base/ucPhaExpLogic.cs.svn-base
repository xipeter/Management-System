using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucPhaExpLogic : Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaExpLogic()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);

            TreeNode parentTreeNode = new TreeNode("所有药房药库");
            parentTreeNode.Tag = "ALL";
            tvLeft.Nodes.Add(parentTreeNode);

            TreeNode childTreeNode = new TreeNode("药库");
            childTreeNode.Tag = "PI";
            parentTreeNode.Nodes.Add(childTreeNode);

            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                TreeNode deptNode = new TreeNode();
                deptNode.Tag = dept.ID;
                deptNode.Text = dept.Name;
                childTreeNode.Nodes.Add(deptNode);
            }

            deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);

          　childTreeNode = new TreeNode("药房");
            childTreeNode.Tag = "P";
            parentTreeNode.Nodes.Add(childTreeNode);

            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                TreeNode deptNode = new TreeNode();
                deptNode.Tag = dept.ID;
                deptNode.Text = dept.Name;
                childTreeNode.Nodes.Add(deptNode);
            }

            parentTreeNode.ExpandAll();

            return base.OnDrawTree();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            TreeNode selectNode = tvLeft.SelectedNode;

           
            string deptCode = selectNode.Tag.ToString();

            return base.OnRetrieve(deptCode, base.beginTime, base.endTime);
        }

    }
}

