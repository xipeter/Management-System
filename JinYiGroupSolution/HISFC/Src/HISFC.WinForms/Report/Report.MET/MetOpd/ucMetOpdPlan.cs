using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetOpd
{
    public partial class ucMetOpdPlan :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdPlan()
        {
            InitializeComponent();
        }
       

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
            
           
        }
    }
}
