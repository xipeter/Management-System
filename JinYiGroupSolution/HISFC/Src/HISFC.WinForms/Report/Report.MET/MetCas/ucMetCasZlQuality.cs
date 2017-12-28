using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasZlQuality : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasZlQuality()
        {
            InitializeComponent();
            this.cmbSelect.SelectedIndex = 0;
        }

        #region 检索
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.beginTime, this.endTime);
        }
        #endregion

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSelect.SelectedIndex == 0)
            {

                this.MainDWDataObject = "d_met_cas_zlquality_bydeptdoc";
                this.dwMain.DataWindowObject = "d_met_cas_zlquality_bydeptdoc";
            }
            if (this.cmbSelect.SelectedIndex == 1)
            {

                this.MainDWDataObject = "d_met_cas_zlquality_bydept";
                this.dwMain.DataWindowObject = "d_met_cas_zlquality_bydept";
            }
            if (this.cmbSelect.SelectedIndex == 2)
            {

                this.MainDWDataObject = "d_met_cas_zlquality_bydoc";
                this.dwMain.DataWindowObject = "d_met_cas_zlquality_bydoc";
            }
        }

    }
}
