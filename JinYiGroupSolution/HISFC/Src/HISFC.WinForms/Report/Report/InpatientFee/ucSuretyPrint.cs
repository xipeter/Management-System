using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucSuretyPrint : UserControl,Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrintSurety
    {
        public ucSuretyPrint()
        {
            InitializeComponent();
        }

        #region 域
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region IPrintSurety 成员

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print() ;
            p.PrintPage(0, 0, this.neuPanel1);
        }

        public void PrintView()
        {
            throw new NotImplementedException();
        }

        public void SetValue(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfoTemp = new Neusoft.HISFC.Models.RADT.PatientInfo();
            Neusoft.FrameWork.Public.ObjectHelper deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
            Neusoft.FrameWork.Public.ObjectHelper suretyHelper = new Neusoft.FrameWork.Public.ObjectHelper();
            ArrayList alSuretyType = Neusoft.HISFC.Models.Fee.SuretyTypeEnumService.List();
            suretyHelper.ArrayObject = alSuretyType;
            ArrayList alDept = this.managerIntegrate.GetDepartment();
            deptHelper.ArrayObject = alDept;

            patientInfoTemp = this.radtIntegrate.GetPatientInfomation(patientInfo.ID);


            this.lblInvoiceNO.Text = patientInfo.Surety.InvoiceNO;
            this.lblname.Text = patientInfoTemp.Name;
            this.lblPatientNO.Text = patientInfoTemp.PID.PatientNO;
            this.lblDept.Text = deptHelper.GetName(patientInfo.PVisit.PatientLocation.Dept.ID);
            this.lblSuretyCost.Text = patientInfo.Surety.SuretyCost.ToString();
            this.lblSuretyPerson.Text = patientInfo.Surety.SuretyPerson.Name;
            this.lblSuretyType.Text = suretyHelper.GetName(patientInfo.Surety.SuretyType.ID.ToString());



        }

        #endregion
    }
}
