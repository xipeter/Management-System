using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbStatDoct :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbStatDoct()
        {
            InitializeComponent();
         
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        private string deptCode = string.Empty;
        private string deptName = string.Empty;
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

            //填充数据、费用类别
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

            //填充数据、科室
            Neusoft.HISFC.Models.Base.Department allDept = new Neusoft.HISFC.Models.Base.Department(); 
            System.Collections.ArrayList alDeptconstantList = manager.QueryDeptmentsInHos(true);
            allDept.ID = "%%";
            allDept.Name = "全部";
            allDept.SpellCode = "QB";
            alDeptconstantList.Insert(0, allDept);
            this.cboDeptCode.AddItems(alDeptconstantList);
            if (cboDeptCode.Items.Count > 0)
            {
                cboDeptCode.SelectedIndex = 0;
                deptCode = this.cboDeptCode.Tag.ToString();
                deptName = this.cboDeptCode.Text;
            }
            
        }

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        //protected override int OnDrawTree()
        //{
        //    if (tvLeft == null)
        //    {
        //        return -1;
        //    }
        //    ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

        //    TreeNode parentTreeNode = new TreeNode("所有部门");
        //    tvLeft.Nodes.Add(parentTreeNode);
        //    foreach (Neusoft.HISFC.Models.Base.Department dept in deptList)
        //    {
        //        TreeNode deptNode = new TreeNode();
        //        deptNode.Tag = dept.ID;
        //        deptNode.Text = dept.Name;
        //        parentTreeNode.Nodes.Add(deptNode);
        //    }


        //    parentTreeNode.ExpandAll();

        //    return base.OnDrawTree();
        //}

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

            //TreeNode selectNode = tvLeft.SelectedNode;

            //if (selectNode.Level == 0)
            //{
            //    return -1;
            //}
            
            //string deptCode = selectNode.Tag.ToString();
            //string deptName = selectNode.Text.ToString();

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

        private void cboDeptCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDeptCode.SelectedIndex >= 0)
            {
                deptCode = this.cboDeptCode.Tag.ToString();
                deptName = this.cboDeptCode.Text;
            }
        }

    }
}

