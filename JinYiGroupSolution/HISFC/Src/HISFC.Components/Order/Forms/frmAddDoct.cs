using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Forms
{
    public partial class frmAddDoct : Form
    {
        public frmAddDoct()
        {
            InitializeComponent();
        }
        #region 变量

        Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medicalTeam = new Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam();

        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct medicalTeamForDoctLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct();

        #endregion

        #region  属性
        public Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam MedicalTeam
        {
            get { return medicalTeam; }
            set
            {
                medicalTeam = value;
                this.SetValue();
            }
        }
        #endregion

        #region 方法

        private int InitDoct()
        {
             ArrayList alDoct= this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
             this.cmbDoct.AddItems(alDoct);
             return 1;
        }

        private void SetValue()
        {
            this.txtDept.Text = this.medicalTeam.Dept.Name;
        }

        private int Save()
        {
            if (this.cmbDoct.SelectedItem == null)
            {
                MessageBox.Show("请选择医生");
                return -1;
            }

            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoct = new Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct();

            medicalTeamForDoct.IsValid = true;
            medicalTeamForDoct.MedcicalTeam = this.medicalTeam;
            medicalTeamForDoct.Oper.ID = this.medicalTeamForDoctLogic.Operator.ID;
            medicalTeamForDoct.Oper.OperTime = this.medicalTeamForDoctLogic.GetDateTimeFromSysDateTime();
            medicalTeamForDoct.Doct = this.cmbDoct.SelectedItem as Neusoft.FrameWork.Models.NeuObject;

          int returnValue=  this.medicalTeamForDoctLogic.InsertMedicalTeamForDoct(medicalTeamForDoct);
          if (returnValue < 0)
          {
              MessageBox.Show("插入医生失败!\n" + this.medicalTeamForDoctLogic.Err);
              return -1;
          }
          MessageBox.Show("添加成功");
          this.DialogResult = DialogResult.OK;
          return 1;


        }
        #endregion

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.InitDoct();
            base.OnLoad(e);
        }

    }
}
