using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.BizLogic.HL7
{
    public partial class frmLisResult : Form, ILisResult
    {
        public frmLisResult()
        {
            InitializeComponent();
        }

        #region ILisResult ≥…‘±

        public int ShowResult(string id)
        {
            return this.ucLisResult1.ShowResult(id);
        }

        public bool IsValid(string id)
        {
            return this.ucLisResult1.IsValid(id);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
        #endregion
    }
}