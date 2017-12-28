using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.MET.MetTec
{
    public partial class ucMetTecStatIncome : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetTecStatIncome()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);

        }
    }
}
