using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasInjury2 : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasInjury2()
        {
            InitializeComponent();
            cmbSex.SelectedIndex = 0;
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string strSex = string.Empty;

            if (cmbSex.SelectedIndex == 0)
            {
                strSex = "ALL";
                this.dwMain.Modify("t_sex.text ='全部'");
            }

            if (cmbSex.SelectedIndex == 1)
            {
                strSex = "M";
                this.dwMain.Modify("t_sex.text ='男'");
            }

            if (cmbSex.SelectedIndex == 2)
            {
                strSex = "F";
                this.dwMain.Modify("t_sex.text ='女'");
            }


            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, strSex);
        }
    }
}
