using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MetCas
{
    public partial class ucMetOpbDay : Common.ucQueryBaseForDataWindow
    {
        public ucMetOpbDay()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            //MessageBox.Show(dtpEndTime.Value.ToString());
            return base.OnRetrieve(dtpEndTime.Value.Date);
        }

    }
}
