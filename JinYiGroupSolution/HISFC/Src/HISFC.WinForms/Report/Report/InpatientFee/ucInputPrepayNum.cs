using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    /// <summary>
    /// {80C40729-D5C1-42ce-96C3-7CF09E562BA7}
    /// </summary>
    public partial class ucInputPrepayNum : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInputPrepayNum()
        {
            InitializeComponent();
        }
                
        public string InputValue
        {
            get
            {
                return this.txtInput.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

    }
}
