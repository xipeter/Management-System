using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MET.MetCas
{
    public partial class ucMetCasDiagnoseAnalyse : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetCasDiagnoseAnalyse()
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
            if (this.cmbSelect.SelectedIndex == 0)
            {
                if (neuCheckBox1.Checked)
                {
                    this.MainDWDataObject = "d_met_cas_diagnose_bydept_notelseicd";
                    this.dwMain.DataWindowObject = "d_met_cas_diagnose_bydept_notelseicd";
                }
                else
                {
                    this.MainDWDataObject = "d_met_cas_diagnose_bydept";
                    this.dwMain.DataWindowObject = "d_met_cas_diagnose_bydept";

                }
            }

            if (this.cmbSelect.SelectedIndex == 1)
            {
                if (neuCheckBox1.Checked)
                {
                    this.MainDWDataObject = "d_met_cas_diagnose_byicd_notelseicd";
                    this.dwMain.DataWindowObject = "d_met_cas_diagnose_byicd_notelseicd";
                }
                else
                {
                    this.MainDWDataObject = "d_met_cas_diagnose_byicd";
                    this.dwMain.DataWindowObject = "d_met_cas_diagnose_byicd";

                }
            }

            return base.OnRetrieve(this.beginTime, this.endTime);
        }
        #endregion
    }
}
