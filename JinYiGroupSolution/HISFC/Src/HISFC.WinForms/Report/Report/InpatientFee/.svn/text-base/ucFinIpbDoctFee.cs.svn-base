using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.InpatientFee
{
    public partial class ucFinIpbDoctFee : Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbDoctFee()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }
            ArrayList emplList = managerIntegrate.QueryEmployee(Neusoft.HISFC.Object.Base.EnumEmployeeType.D);

            TreeNode parentTreeNode = new TreeNode("所有医生");
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Object.Base.Employee empl in emplList)
            {
                TreeNode emplNode = new TreeNode();
                emplNode.Tag = empl.ID;
                emplNode.Text = empl.Name;
                parentTreeNode.Nodes.Add(emplNode);
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

            if (selectNode.Level == 0)
            {
                return -1;
            }
            string emplCode = selectNode.Tag.ToString();

            return base.OnRetrieve(base.beginTime, base.endTime, emplCode);
        }
    }
}

