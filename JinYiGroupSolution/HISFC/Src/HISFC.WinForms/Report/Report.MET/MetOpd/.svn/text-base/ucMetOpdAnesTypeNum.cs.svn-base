using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.MET.MetOpd
{
    public partial class ucMetOpdAnesTypeNum : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdAnesTypeNum()
        {
            InitializeComponent();
        }

        private string str = "(Âé×íÒ½Éú like '{0}%')";

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(this.beginTime, this.endTime);
        }


        private void tbDocName_TextChanged(object sender, EventArgs e)
        {

            string opd = this.tbDocName.Text.Trim().ToUpper().Replace(@"\", "");

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
