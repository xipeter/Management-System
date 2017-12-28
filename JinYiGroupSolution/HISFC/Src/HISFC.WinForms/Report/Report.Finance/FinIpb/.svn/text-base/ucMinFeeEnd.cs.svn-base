using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucMinFeeEnd : UserControl
    {
        private Neusoft.HISFC.BizLogic.RADT.InPatient LogicPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        private DateTime beginTime;
        private DateTime endTime;
        private Decimal ThisCost;

        public ucMinFeeEnd(string patientNo, DateTime begin, DateTime end, Decimal cost)
        {
            InitializeComponent();
            this.patient = LogicPatient.QueryPatientInfoByInpatientNO(patientNo);
            this.beginTime = begin;
            this.endTime = end;
            this.ThisCost = cost;
        }

        private void ucMinFeeEnd_Load(object sender, EventArgs e)
        {
            this.label5.Text = patient.FT.PrepayCost.ToString();
            this.label6.Text = patient.FT.TotCost.ToString();
            this.label7.Text = (patient.FT.PrepayCost - patient.FT.TotCost).ToString();
            this.label8.Text = this.ThisCost.ToString();
        }
    }
}
