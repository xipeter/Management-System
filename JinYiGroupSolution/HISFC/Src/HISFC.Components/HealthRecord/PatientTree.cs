using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.HealthRecord
{
    class PatientTree :Common.Controls.tvPatientList
    {
        #region к╫сп╠Да©
        TextBox txtPatientNo = new TextBox();
        #endregion 
        public PatientTree()
        {
            base.Controls.Add(txtPatientNo);
            txtPatientNo.Top = 10;
            txtPatientNo.Left = 20;
        }

    }
}
