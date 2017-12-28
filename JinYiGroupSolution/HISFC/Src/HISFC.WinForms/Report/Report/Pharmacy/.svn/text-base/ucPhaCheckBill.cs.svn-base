using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucPhaCheckBill : Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaCheckBill()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.txtName.Text.Trim().Equals(""))
            {
                return -1;
            }
            return base.OnRetrieve(this.txtName.Text.Trim());//this.dwMain.Retrieve(objects);
        }
    }
}

