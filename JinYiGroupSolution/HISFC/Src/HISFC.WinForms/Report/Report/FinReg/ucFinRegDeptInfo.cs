using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinReg
{
    public partial class ucFinRegDeptInfo : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinRegDeptInfo()
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
            dwMain.Retrieve(this.dtpBeginTime.Value.ToString(), this.dtpEndTime.Value.ToString());
            return base.OnRetrieve(this.dtpBeginTime.Value.ToString(), this.dtpEndTime.Value.ToString());
        }
    }
}
