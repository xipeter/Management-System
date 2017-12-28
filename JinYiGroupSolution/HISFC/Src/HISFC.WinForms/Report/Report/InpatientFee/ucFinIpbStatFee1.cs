using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucFinIpbStatFee1 : Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbStatFee1()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            int iRow;
            decimal dFee;
            dwMain.Retrieve(base.beginTime, base.endTime);
            iRow = dwMain.CurrentRow;

            if (iRow > 0)
            {
                dFee = Convert.ToDecimal(dwMain.GetItemDouble(iRow, "feecost"));

                string value = Neusoft.FrameWork.Function.NConvert.ToCapital(dFee);

                dwMain.SetItemString(iRow, "temp", value);
            }
            return 1;
            //return base.OnRetrieve(base.beginTime, base.endTime);
        }
    }
}
