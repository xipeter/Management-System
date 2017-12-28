using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucFeeAlertQueryPrintPanelDetail :Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMoneyAlert
    {
        public ucFeeAlertQueryPrintPanelDetail()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizLogic.Fee.InPatient inPatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        //患者信息实体
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        /// <summary>
        /// 患者基本信息

        #region IMoneyAlert 成员

        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.patientInfo;

            }
            set
            {
                this.patientInfo = value;
                this.SetPatientInfo();
            }
        }

        public void SetPatientInfo()
        {
            this.lblDate.Text += this.inPatientManager.GetDateTimeFromSysDateTime().ToString();
            this.lblName.Text += this.patientInfo.Name;
            this.lblPatientNO.Text += this.patientInfo.PID.PatientNO;
            this.lblMoneyAlert.Text += this.patientInfo.PVisit.MoneyAlert.ToString() + "元";
            this.lblFreeCost.Text += this.patientInfo.FT.LeftCost.ToString() + "元";
            this.lblPreCost.Text += this.patientInfo.FT.PrepayCost.ToString() + "元";
            //this.lblNeedSupply.Text += this.patientInfo.PVisit.MoneyAlert.ToString() + "元";
            this.lblOwnCost.Text += this.patientInfo.FT.OwnCost.ToString() + "元";
            this.lblBedNO.Text += this.patientInfo.PVisit.PatientLocation.Bed.ID;
            this.lblDept.Text += this.patientInfo.PVisit.PatientLocation.Dept.Name;
            this.lblNurse.Text += this.patientInfo.PVisit.PatientLocation.NurseCell.Name;
            this.lblPact.Text += this.patientInfo.Pact.Name;

        }

        #endregion

    }

}
