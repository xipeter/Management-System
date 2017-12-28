using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.Logistics.DrugStore
{
    public partial class ucStoLastmonthOutput :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        int year = 0;
        int lMonth = 0;
        int tMonth = 0;

        string deptCode = string.Empty;

        public ucStoLastmonthOutput()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.Models.Base.Employee employee = dept.Operator as Neusoft.HISFC.Models.Base.Employee;
            deptCode = employee.Dept.ID;
            string time = dept.GetSysDate("");
            tMonth =Convert.ToInt32( time.Substring(4, 2));
            year=Convert.ToInt32(time.Substring(0,4));
            if (tMonth != 1)
                lMonth = tMonth - 1;
            else
            {
                lMonth = 12;
                year=year-1;
            }
            DateTime dtBegin = new DateTime(year, lMonth, 1);
            DateTime dtEnd = new DateTime(year, tMonth, 1);
                      

            return base.OnRetrieve(deptCode, dtBegin, dtEnd);
        }
    }
}