using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.Pharmacy
{
    public partial class ucPhaCheckBill : NeuDataWindow.Controls.ucQueryBaseForDataWindow
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
            this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

           // return base.OnRetrieve(this.txtName.Text.Trim(),employee.Dept.ID);//this.dwMain.Retrieve(objects);

           return base.OnRetrieve(this.txtName.Text.Trim());
        }
    }
}

