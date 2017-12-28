using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MetCas
{
    public partial class ucMetHos : Common.ucQueryBaseForDataWindow
    {
        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        private string bblx = string.Empty;

        public ucMetHos()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            bblx = "医院工作（月）报表";
            TimeSpan times=base.endTime - base.beginTime;
            int days=times.Days;
            if (days > 365)
            {
                bblx = "医院工作（年）报表";
            }
            else if (days > 182)
            {
                bblx = "医院工作（半年）报表";
            }
            else if (days > 90)
            {
                bblx = "医院工作（季）报表";
            }
            int RetrieveRow = base.OnRetrieve(base.beginTime, base.endTime);
            dwMain.Modify("t_bblx.text = '" + bblx + "'");
            dwMain.Modify("t_zbr.text = '" + oper.Name + "'");
            return RetrieveRow;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (bblx.Equals("医院工作（月）报表"))
            {
                return base.OnPrint(sender, neuObject);
            }
            else
            {
                MessageBox.Show("只能打印月报！");
                return -1;
            }
            
        }

    }
}
