using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucFinOpbStatDoct : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinOpbStatDoct()
        {
            InitializeComponent();
            this.plQueryCondition.Visible = false;
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            //this.Init();

            base.OnLoad();
            //设置时间范围
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;

            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetConstantList("FEECODESTAT");
            foreach (Neusoft.HISFC.Models.Base.Const con in constantList)
            {
                cboReportCode.Items.Add(con);
            }
            if (cboReportCode.Items.Count > 0)
            {
                cboReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).Name;
            }

        }

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);

            TreeNode parentTreeNode = new TreeNode("所有科室");
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

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            TreeNode selectNode = tvLeft.SelectedNode;

            if (selectNode.Level == 0)
            {
                return -1;
            }
            string deptCode = selectNode.Tag.ToString();
            string deptName = selectNode.Text.ToString();

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, reportCode, deptCode, reportName, deptName);
        }

        private void cboReportCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportCode.SelectedIndex >= 0)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).Name;
            }
        }

    }
}

