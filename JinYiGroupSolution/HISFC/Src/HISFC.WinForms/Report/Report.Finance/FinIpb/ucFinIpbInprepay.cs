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
    public partial class ucFinIpbInprepay : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbInprepay()
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
            ArrayList emplList = managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.F);

            TreeNode parentTreeNode = new TreeNode("所有操作员");
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.Base.Employee empl in emplList)
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
            string emplCode;
            switch (selectNode.Level)
            {
                case 0:
                    emplCode = "ALL";
                    break;
                default:
                    emplCode = selectNode.Tag.ToString();
                    break;
            }

            

            return base.OnRetrieve(base.beginTime, base.endTime, emplCode);
        }
    }
}

