using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucInput : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInput()
        {
            InitializeComponent();
        }

        private string patientNo = string.Empty;

        public string PatientNo
        {
            get { return patientNo; }
            set { patientNo = value; }
        }
        

        private void ucInput_Load(object sender, EventArgs e)
        {
         
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            patientNo = "";
            this.FindForm().Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            patientNo = this.txtInput.Text.Trim().PadLeft(10,'0');
            this.FindForm().Close();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
