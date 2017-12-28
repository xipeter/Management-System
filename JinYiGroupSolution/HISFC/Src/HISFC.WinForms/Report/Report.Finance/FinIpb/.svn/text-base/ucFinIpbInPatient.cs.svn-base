using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbInPatient : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbInPatient()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }


            return base.OnRetrieve(base.beginTime, base.endTime);
        }
    }
}

