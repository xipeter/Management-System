using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.MET.MetCas
{
    public partial class ucMetZyOpbList : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetZyOpbList()
        {
            InitializeComponent();
            base.LeftControl = QueryControls.Tree;
        }
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager myDepartmentStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList deptList = this.myDepartmentStatManager.LoadDepartmentStatAndByNodeKind("72", "1");

            TreeNode parentTreeNode = new TreeNode("全部");
            parentTreeNode.Tag = "ALL";
            parentTreeNode.Text = "全院";
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.Base.DepartmentStat dept in deptList)
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
            string deptName = selectNode.Text.ToString();

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptCode, deptName);
        }

        private void ucMetZyOpbList_Load(object sender, EventArgs e)
        {
             DateTime sysTime = this.myDepartmentStatManager.GetDateTimeFromSysDateTime();
            this.dtpBeginTime.Text = sysTime.AddDays(-1).ToShortDateString() + " 00:00:00";
            this.dtpEndTime.Text = sysTime.ToShortDateString() + " 00:00:00";
        }

        //private void ucMetOpbList_Click(object sender, EventArgs e)
        //{
        //    DateTime sysTime = this.myDepartmentStatManager.GetDateTimeFromSysDateTime();

        //    this.dtpBeginTime.Text = sysTime.AddDays(-1).ToShortDateString() + " 00:00:00";
        //    this.dtpEndTime.Text = sysTime.ToShortDateString() + " 00:00:00";
        //}

    }
    }

