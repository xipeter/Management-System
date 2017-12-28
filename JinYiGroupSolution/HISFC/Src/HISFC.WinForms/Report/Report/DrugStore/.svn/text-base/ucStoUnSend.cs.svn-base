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
    public partial class ucStoUnSend : Report.Common.ucQueryBaseForDataWindow
    {
        public ucStoUnSend ( )
        {
            InitializeComponent();
        }
        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion
        /// <summary>
        /// 科室树
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {

            ArrayList deptList = this.managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            if (deptList == null)
            {
                return -1;
            }
            TreeNode parentTreeNode = new TreeNode("所有科室");
            this.tvLeft.Nodes.Add(parentTreeNode);

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

            TreeNode selectNode = this.tvLeft.SelectedNode;

            if (selectNode.Level == 0)
            {
                return -1;
            }

            string deptCode = selectNode.Tag.ToString();

            //this.dwMain.Retrieve();

            return base.OnRetrieve(base.beginTime, base.endTime, deptCode);
        }
    }
}

