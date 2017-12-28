using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    /// <summary>
    /// 文本框回车处理
    /// </summary>
    /// <param name="register">患者挂号实体</param>
    public delegate void PatientEventHandler(Neusoft.HISFC.Models.Registration.Register register);

    public partial class ucPatientInfo : UserControl
    {
        public ucPatientInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文本框回车的事件
        /// </summary>
        public event PatientEventHandler PatientEvent;

        private Neusoft.HISFC.Models.Registration.Register register;

        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            get
            {
                return this.register;
            }
        }


        private void txtClinicInput1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.register = this.txtClinicInput1.Register;
                if (this.register == null)
                {
                    return;
                }
                if (this.PatientEvent != null)
                {
                    PatientEvent(this.register);
                }

                this.ShowPatientInfo();
            }
        }

        private void ShowPatientInfo()
        {
            this.ClearPatientPanel();
            this.lbName.Text = this.register.Name;
            this.lbSex.Text = this.register.Sex.Name;
            this.lbBirthday.Text = this.register.Birthday.ToShortDateString();
            this.lbDoct.Text = this.register.DoctorInfo.Templet.Doct.Name;
            this.lbDept.Text = this.register.DoctorInfo.Templet.Dept.Name;
        }

        public void ClearPatientPanel()
        {
            this.txtClinicInput1.Text = "";
            this.lbName.Text = "________";
            this.lbSex.Text = "____";
            this.lbBirthday.Text = "______________";
            this.lbDoct.Text = "__________";
            this.lbDept.Text = "__________";
            this.txtClinicInput1.Focus();
        }
    }
}
