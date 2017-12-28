using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.OutpatientFee.Forms
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ¼ÓÔØÊÂ¼þ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) 
            {
                return;
            }

            this.ucSetting1.Init();
        }
    }
}