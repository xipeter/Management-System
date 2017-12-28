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
    public partial class UcFinIpbinpatientfeeback : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public UcFinIpbinpatientfeeback()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据病区过滤  add by wangyx 2007-12-20
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected override int OnDrawTree()
        {
            if (tvDept == null)
            {
                return -1;
            }
            this.tvDept.Width = 200;//树的宽度
            ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            TreeNode parentTreeNode = new TreeNode("全部");
            tvDept.Nodes.Add(parentTreeNode);
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
            TreeNode selectNode = tvDept.SelectedNode;

            if (selectNode.Level == 0)
            {
                return -1;
            }
            string deptCode = selectNode.Tag.ToString();
            string deptName = selectNode.Text;
            dwMain.Modify("t_1.text='" + deptName + "病人退费汇总"+"'");
            dwMain.Modify("t_date.text = '时间范围：" + this.dtpBeginTime.Value.ToString() + "－" + this.dtpEndTime.Value.ToString() + "'");
            dwMain.Modify("t_7.text='制表人：" + this.employee.Name.ToString() + "'");
            //return base.OnRetrieve(base.beginTime, base.endTime);
             return base.OnRetrieve(base.beginTime, base.endTime,deptCode);
        }

        protected override int OnExport()
        {
            return base.OnExport();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string inPatientNo;
            inPatientNo = this.textBox1.Text;
            if (e.KeyChar == (char)Keys.Enter)
                this.dwMain.SetFilter("compute_0001 like  '%" + inPatientNo + "%'");
            this.dwMain.Filter();
        }
    }
}
