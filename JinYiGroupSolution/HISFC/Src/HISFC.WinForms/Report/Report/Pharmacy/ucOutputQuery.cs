using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucOutputQuery : Common.ucQueryBaseForDataWindow
    {
        public ucOutputQuery()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region 方法

        /// <summary>
        /// 画树,成功 1 失败 -1
        /// </summary>
        /// <returns></returns>
        protected override int OnDrawTree()
        {
            if (this.tvLeft == null) 
            {
                return -1;
            }
            
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

            this.dwMain.Retrieve(deptCode, base.beginTime, base.endTime);
            
            return base.OnRetrieve();
        }

        #endregion
    }
}
