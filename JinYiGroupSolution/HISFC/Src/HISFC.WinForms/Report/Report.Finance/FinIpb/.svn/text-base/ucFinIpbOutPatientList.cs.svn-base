using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbOutPatientList : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbOutPatientList()
        {
            InitializeComponent();
        }

        string deptCode = string.Empty;
        string deptName = string.Empty;
        string patientName = string.Empty;
        string patientNo = string.Empty;
        string date = string.Empty;

        protected override void OnLoad()
        {
            base.OnLoad();
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            Neusoft.HISFC.Models.Base.Department top = new Neusoft.HISFC.Models.Base.Department();
            top.ID = "ALL";
            top.Name = "È«  ²¿";
            this.ncboDept.Items.Add(top);
            foreach (Neusoft.HISFC.Models.Base.Department con in constantList)
            {
                ncboDept.Items.Add(con);
            }
            this.ncboDept.alItems.Add(top);
            this.ncboDept.alItems.AddRange(constantList);
            if (ncboDept.Items.Count > 0)
            {
                ncboDept.SelectedIndex = 0;
                deptCode = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).Name;
            }            
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
                return -1;

            patientName = ntxtPatientName.Text.Trim().ToUpper().Replace(@"\", "");
            patientNo = ntxtPatientNo.Text.Trim().ToUpper().Replace(@"\", "");

            if (string.IsNullOrEmpty(patientName))
            {
                patientName = "ALL";
            }
            else
            {
                patientName = "%" + patientName + "%";
            }

            if (string.IsNullOrEmpty(patientNo))
            {
                patientNo = "ALL";
            }
            else
            {
                patientNo = "%" + patientNo + "%";
            }

            return base.OnRetrieve(patientName, patientNo, deptCode, base.beginTime, base.endTime, date);
        }

        private void ncboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDept.SelectedIndex > -1)
            {
                deptCode = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).Name;
            }
        }

        private void ncbkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ncbkTime.Checked)
            {
                dtpBeginTime.Enabled = true;
                dtpEndTime.Enabled = true;
                date = "";
            }
            else
            {
                dtpEndTime.Enabled = false;
                dtpBeginTime.Enabled = false;
                date = "ALL";
            }
        }

        

        //private string queryStr = "((name like '{0}%') or (name_spell_code like '{0}%') or (name_wb_code like '{0}%')) and ((patient_no like '{1}%') or (patient_no_spell_code like '{1}%') or (patient_no_wb_code like '{1}%')))";

        //private void txtPatientNo_TextChanged(object sender, EventArgs e)
        //{
        //    string patientName = this.ntxtPatientName.Text.Trim().ToUpper().Replace(@"\", "");
        //    string patientNo = this.ntxtPatientNo.Text.Trim().ToUpper().Replace(@"\", "");

        //    if (patientName.Equals("") && patientNo.Equals(""))
        //    {
        //        this.dwMain.SetFilter("");
        //        this.dwMain.Filter();
        //        return;
        //    }

        //    string str = string.Format(this.queryStr, patientName, patientNo);
        //    this.dwMain.SetFilter(str);
        //    this.dwMain.Filter();
        //}
    }
}