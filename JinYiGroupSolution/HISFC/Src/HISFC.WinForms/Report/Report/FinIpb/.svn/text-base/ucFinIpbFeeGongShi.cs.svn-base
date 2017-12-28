using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class ucFinIpbFeeGongShi : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbFeeGongShi()
        {
            InitializeComponent();
        }

        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 绘制科室树
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            TreeNode parentTreeNode = new TreeNode("所有科室");
            parentTreeNode.Tag = "ALL";
            parentTreeNode.Text = "所有科室";
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
            {
                TreeNode deptNode = new TreeNode();
                deptNode.Tag = dept.ID;
                deptNode.Text = dept.Name;
                parentTreeNode.Nodes.Add(deptNode);
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

             

            dwMain.Modify("t_dept.text = '" + selectNode.Text + "'");
            dwMain.Modify("t_date.text = '打印时间：" + base.beginTime.ToString() + "'");
            dwMain.Retrieve(base.beginTime, deptCode);

            return 1;
        }


        

    }
}
