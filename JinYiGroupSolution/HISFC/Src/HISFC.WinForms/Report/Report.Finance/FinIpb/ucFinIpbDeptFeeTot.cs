using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbDeptFeeTot :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbDeptFeeTot()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string operName = string.Empty;
            //Neusoft.FrameWork.Public.ObjectHelper oh = new Neusoft.FrameWork.Public.ObjectHelper();
            //Neusoft.HISFC.BizProcess.Integrate.Manager mg = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //oh.ArrayObject =  mg.QueryEmployeeAll();
            operName = Neusoft.FrameWork.Management.Connection.Operator.Name;
            return base.OnRetrieve(operName);
        }

    }
}
