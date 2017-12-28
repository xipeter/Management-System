using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// [功能描述: 患者信息控件]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>

    public partial class ucSiPatientInfoInPatient : UserControl
    {

        public ucSiPatientInfoInPatient()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 住院患者实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;

        #endregion
        #region 属性

        /// <summary>
        /// 患者实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
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

        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <returns></returns>
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
            //         this.txtMedicalType.Text = this.patient.SIMainInfo.PersonType.ID;
            this.txtICCardCode.Text = this.patient.SIMainInfo.ICCardCode;
            this.txtBirthday.Text = this.patient.Birthday.ToShortDateString();
            this.txtIDCard.Text = this.patient.IDCard;
            this.txtIndividualBalance.Text = this.patient.SIMainInfo.IndividualBalance.ToString();
            this.txtCorporationID.Text = this.patient.SIMainInfo.Corporation.ID;
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
