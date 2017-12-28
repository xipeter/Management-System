using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucFinIpbFeeListQuery : Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbFeeListQuery()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizLogic.RADT.InPatient managerIntegrate = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        protected override int OnDrawTree()
        {
            if (tvLeft == null)
            {
                return -1;
            }

            Neusoft.HISFC.Models.RADT.InStateEnumService inState = new Neusoft.HISFC.Models.RADT.InStateEnumService();

            inState.ID = Neusoft.HISFC.Models.Base.EnumInState.I.ToString();

            ArrayList emplList = managerIntegrate.QueryPatientBasic(base.employee.Dept.ID, inState);

            TreeNode parentTreeNode = new TreeNode("±¾¿Æ»¼Õß");
            tvLeft.Nodes.Add(parentTreeNode);
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo empl in emplList)
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

            if (selectNode == null) 
            {
                return -1;
            }

            if (selectNode.Level == 0)
            {
                return -1;
            }
            string emplCode = selectNode.Tag.ToString();

            return base.OnRetrieve(base.beginTime, base.endTime, emplCode);
        }
    }
}

