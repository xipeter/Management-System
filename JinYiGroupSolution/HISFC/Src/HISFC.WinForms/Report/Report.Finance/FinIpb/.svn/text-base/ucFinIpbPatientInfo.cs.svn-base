using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbPatientInfo :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbPatientInfo()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            
            string deptName = "ALL";
            string doctCode = "ALL";
            string operCode = "ALL";
            string sueryName = "ALL";
            string pactCode = "ALL";
            string patientNO = "ALL";
            if (this.cmbDept.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDept.SelectedItem.Name))
                {
                    deptName = this.cmbDept.SelectedItem.Name;
                }

            }
            if (this.cmbDoct.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDoct.SelectedItem.ID))
                {
                    doctCode = this.cmbDoct.SelectedItem.ID;
                }
            }
            if (this.cmbOper.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbOper.SelectedItem.ID))
                {
                    operCode = this.cmbOper.SelectedItem.ID;
                }
            }
            if (this.cmbSuery.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbSuery.SelectedItem.Name))
                {
                    sueryName = this.cmbSuery.SelectedItem.Name;
                }
            }
            if (this.cmbPactType.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbPactType.SelectedItem.ID))
                {
                    pactCode = this.cmbPactType.SelectedItem.ID;
                }
            }
            if (!string.IsNullOrEmpty(this.txtPatientNO.Text))
            {
                patientNO = this.txtPatientNO.Text;
            }
            else
            {
                patientNO = "ALL";
            }


            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptName, operCode, sueryName, doctCode,pactCode,patientNO);
            
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            ArrayList deptList = new ArrayList();
            ArrayList doctList = new ArrayList();
            ArrayList pactList = new ArrayList();
           
            Neusoft.HISFC.BizProcess.Integrate.Manager mg = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizLogic.Manager.Constant conManger = new Neusoft.HISFC.BizLogic.Manager.Constant();
            deptList = mg.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            doctList = mg.QueryEmployeeAll();
            pactList = conManger.GetAllList("PACTUNIT");

            this.cmbDept.AddItems(deptList);
            this.cmbDoct.AddItems(doctList);
            this.cmbOper.AddItems(doctList);
            this.cmbSuery.AddItems(doctList);
            this.cmbPactType.AddItems(pactList);
            
        }
        private void lblSuery_Click(object sender, EventArgs e)
        {

        }

    }
}
