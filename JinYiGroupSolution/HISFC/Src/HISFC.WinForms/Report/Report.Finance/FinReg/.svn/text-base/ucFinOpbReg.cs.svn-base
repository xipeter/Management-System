using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinOpb
{
    public partial class ucFinOpbReg : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinOpbReg()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
        }

        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();
        }

        //private void d_localreport_reg_Load(object sender, EventArgs e)
        //{
        //    DateTime now = DateTime.Now;
        //    this.dtpBeginTime.Value = new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);
        //    this.dtpEndTime.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

        //    this.isAcross = true;
        //    this.isSort = false;


        //}
    }
}
