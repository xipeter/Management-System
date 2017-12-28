using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetOpd
{
    public partial class ucMetOpdNumOps :NeuDataWindow.Controls.ucQueryBaseForDataWindow// NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdNumOps()
        {
            InitializeComponent();
        }

        private string str = "( ÷ ı√˚≥∆ like '{0}%')";

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(beginTime, endTime);
        }

        private void tbOpdName_TextChanged(object sender, EventArgs e)
        {

            string opd = this.tbOpdName.Text.Trim().ToUpper().Replace(@"\", "");
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (opd.Equals(""))
            {
                dv.RowFilter = "";
                return;
            }
            else
            {
                string str = string.Format(this.str, opd);
                dv.RowFilter = str;
            }

        }
    }
}
