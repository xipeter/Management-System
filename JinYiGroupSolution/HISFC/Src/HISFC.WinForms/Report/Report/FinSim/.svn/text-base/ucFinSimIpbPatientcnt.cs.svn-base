using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Neusoft.WinForms.Report.FinSim
{
    public partial class ucFinSimIpbPatientcnt : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimIpbPatientcnt()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.Init();
            base.OnLoad();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
        }
    }
}
