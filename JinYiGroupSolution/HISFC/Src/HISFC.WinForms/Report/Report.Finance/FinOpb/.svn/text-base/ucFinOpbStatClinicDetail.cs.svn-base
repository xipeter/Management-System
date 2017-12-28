using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinOpb
{
    public partial class ucFinOpbStatClinicDetail : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public ucFinOpbStatClinicDetail()
        {
            InitializeComponent();
        }

        string no = "";
        string inpatient = "";
        string dept = "";
        string doct = "";
        string operfee = "";
        string date = "";
        string ys = "";
        string ss = "";
        string title = "";
        public void Init(string No,string Inpatient,string Dept,string Doct,string Operfee,string Date,string Ys,string Ss,string Title)
        {
            no = No;
            inpatient = Inpatient;
            dept = Dept;
            doct = Doct;
            operfee = Operfee;
            date = Date;
            ys = Ys;
            ss = Ss;
            title = Title;
            if (Title == "门诊未取药处方明细")
            {
                this.neuDataWindow1.DataWindowObject = "d_fin_opb_stat_clinic_pop";
                this.neuDataWindow1.LibraryList = "Report\\\\finopb.pbd;Report\\\\finopb.pbl";
            }
            if (Title == "门诊未取药退费处方统计")
            {
                this.neuDataWindow1.DataWindowObject = "d_fin_opb_stat_clinci_pop1";
                this.neuDataWindow1.LibraryList = "Report\\\\finopb.pbd;Report\\\\finopb.pbl";
            }
            if (Title == "门诊处方发药处方明细")
            {
                this.neuDataWindow1.DataWindowObject = "d_fin_opb_stat_clinic_pop2";
                this.neuDataWindow1.LibraryList = "Report\\\\finopb.pbd;Report\\\\finopb.pbl";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (title != "门诊处方发药处方明细")
            {
                this.neuDataWindow1.Retrieve(no, title, inpatient, dept, doct, operfee, date, ys, ss);
            }
            else
            {
                this.neuDataWindow1.Retrieve(no, title, inpatient, dept, doct, operfee, date, ys);
            }
            base.OnLoad(e);
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.neuDataWindow1.Print();
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
