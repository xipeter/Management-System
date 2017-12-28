using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Material.Apply
{
    public partial class frmApply : Material.frmIMABaseForm
    {
        public frmApply()
        {
            InitializeComponent();
            this.Text = "…Í«Îµ•¬º»Î";
        }

        protected override void OnLoad(EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            try
            {
                Apply.ucApply ucMatApply = new ucApply();
                this.AddIMABaseCompoent(ucMatApply);
            }
            catch
            {
            }

            base.OnLoad(e);
        }
    }
}