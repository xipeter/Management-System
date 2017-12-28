using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetOpd
{
    public partial class ucMetOpdPlanAnes : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdPlanAnes()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(beginTime, endTime);
        }
    }
}
