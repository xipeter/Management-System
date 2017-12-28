using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ShenYangCitySI.Control
{
    public partial class ucSiPatientInfoOutPatient : UserControl
    {
        public ucSiPatientInfoOutPatient()
        {
            InitializeComponent();
        } 
        #region 变量
        private Neusoft.HISFC.Models.Registration.Register patient = null;
        private string chooseType = string.Empty;
        #endregion
        #region 属性
        /// <summary>
        /// 患者
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                if (DesignMode) return;
                this.patient = value;
                if (value != null)
                    this.SetPatientInfo();
            }
        }
        #endregion
        protected int SetPatientInfo()
        {
            this.txtName.Text = patient.Name;
            this.txtSex.Text = patient.Sex.Name;
            this.txtSiBegionDate.Text = patient.SIMainInfo.SiBegionDate.ToShortDateString();
            this.txtSSN.Text = this.patient.SSN;
            EnumPersonTypeService eps = new EnumPersonTypeService();
            foreach (Neusoft.FrameWork.Models.NeuObject pTObj in EnumPersonTypeService.List())
            {
                if (pTObj.ID == this.patient.SIMainInfo.PersonType.ID)
                {
                    this.txtMedicalType.Text = pTObj.Name;
                }
            }
        //    this.txtMedicalType.Text = this.patient.SIMainInfo.PersonType.ID;
            this.txtICCardCode.Text = this.patient.SIMainInfo.ICCardCode;
            this.txtBirthday.Text = this.patient.Birthday.ToShortDateString();
            this.txtCorporationID.Text = this.patient.SIMainInfo.Corporation.ID;
            this.txtIDCard.Text = this.patient.IDCard;
            this.txtIndividualBalance.Text = this.patient.SIMainInfo.IndividualBalance.ToString();
            this.txtBirthPlace.Text = this.patient.SIMainInfo.BirthPlace;
            if (this.patient.SIMainInfo.IsOffice)
            {
                this.txtIsGWY.Text = "是";
            }
            else
            {
                this.txtIsGWY.Text = "否";
            }

            return 1;
        }


    }
}
