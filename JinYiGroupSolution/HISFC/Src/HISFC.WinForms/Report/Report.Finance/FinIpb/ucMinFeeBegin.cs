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
    public partial class ucMinFeeBegin : UserControl
    {
        private Neusoft.HISFC.BizLogic.RADT.InPatient LogicPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        private DateTime beginTime ;
        private DateTime endTime ;
        public ucMinFeeBegin(string patientNo, DateTime begin, DateTime end)
        {
            InitializeComponent();

            this.patient = LogicPatient.QueryPatientInfoByInpatientNO(patientNo);
            this.beginTime = begin;
            this.endTime = end;
        }

        private void ucMinFeeBegin_Load(object sender, EventArgs e)
        {
            this.lbNo.Text = this.patient.ID.Substring(4);
            this.lbNum.Text = this.patient.InTimes.ToString();
            this.lbDept.Text = this.patient.PVisit.PatientLocation.Dept.Name;
            this.lbBedNo.Text = this.patient.PVisit.PatientLocation.Bed.ID;
            this.lbName.Text = this.patient.Name;
            this.lbSex.Text = this.patient.Sex.Name;
            this.lbAge.Text = (System.DateTime.Now.Year - this.patient.Birthday.Year).ToString();
            this.lbIntime.Text = this.patient.PVisit.InTime.ToString();
            this.lbPact.Text = this.patient.Pact.Name;
            this.lbQueryTime.Text = this.beginTime.ToString() + " 至 " + this.endTime.ToString();
            this.lbPrintTime.Text = System.DateTime.Now.ToString();
        }
    }
}
