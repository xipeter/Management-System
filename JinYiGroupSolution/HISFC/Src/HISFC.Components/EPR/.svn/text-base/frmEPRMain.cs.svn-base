using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class frmEPRMain : Form
    {
        public frmEPRMain()
        {
            InitializeComponent();
           
        }
        bool isShowInterface = true;
        string eprID = "";
        public frmEPRMain(bool isShowInterface,string eprid)
        {
            InitializeComponent();
            this.isShowInterface = isShowInterface;
            this.eprID = eprid;
        }

        public ucEMRControl control = new ucEMRControl();

        private void frmEPRMain_Load(object sender, EventArgs e)
        {
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.Visible = true;
            control.IsShowInterface = this.isShowInterface;
            control.IsShowToolFunction = true;
            
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    //if (control.AllowClosed()) return;
        //    //e.Cancel = true;
        //}
    }
}