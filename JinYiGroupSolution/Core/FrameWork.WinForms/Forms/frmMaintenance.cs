using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Interface.Controls;

namespace Neusoft.NFC.Interface.Forms
{
    public partial class frmMaintenance : frmQuery
    {
        public frmMaintenance()
        {
            InitializeComponent();

            
        }

        #region ×Ö¶Î
        private ucMaintenance maintenance;
        #endregion

#region ÊÂ¼þ
        protected override void OnLoad(EventArgs e)
        {
            this.maintenance = new ucMaintenance(this.Tag.ToString());
            this.MaintenanceControl = this.maintenance;
            base.OnLoad(e);
        }
#endregion

    }
}