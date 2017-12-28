using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinReg
{
    public partial class ucFinRegDeptSum : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinRegDeptSum()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(base.beginTime, base.endTime);
        }
    }
}
