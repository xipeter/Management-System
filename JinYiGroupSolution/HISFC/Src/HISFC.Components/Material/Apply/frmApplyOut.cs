using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Material.Apply
{
    public partial class frmApplyOut : Material.frmIMABaseForm
    {
        public frmApplyOut()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            try
            {
                Apply.ucApply ucMatApply = new ucApply();
                ucMatApply.IOType = "2";            //»Îø‚…Í«Î 
                this.AddIMABaseCompoent(ucMatApply);
            }
            catch
            {
            }

            base.OnLoad(e);
        }
    }
}