using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.Report.MET.MetOpd
{
    public partial class ucMetOpdPatient : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdPatient()
        {
            InitializeComponent();
            base.LeftControl = QueryControls.Tree;
        }
        
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = managerIntegrate.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            TreeNode parentTreeNode = new TreeNode("È«²¿");
            parentTreeNode.Tag = "00";

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


            //if (selectNode.Level == 0)
            //{
            // return -1;
            //}
            string deptCode = selectNode.Tag.ToString();
           // MessageBox.Show(deptCode);
            string deptName = selectNode.Text.ToString();

            return base.OnRetrieve(base.beginTime, base.endTime, deptCode);
        }

        private void ucMetOpdPatient_Load(object sender, EventArgs e)
        {
            
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            this.dtpEndTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 23, 59, 59);
            this.dtpBeginTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 00, 00, 00);
        }
    }
}
