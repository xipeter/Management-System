using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Material
{
    public partial class ucOutputBill : Report.Common.ucQueryBaseForDataWindow
    {
        public ucOutputBill()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if(this.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.beginTime,this.endTime,this.employee.Dept.ID);
        }
    }
}

