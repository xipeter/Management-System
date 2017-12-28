using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Forms
{

    public partial class frmMedcialTeam : Form
    {
        public frmMedcialTeam()
        {
            InitializeComponent();
        }

        #region 变量
         
        /// <summary>
        /// 医疗组信息
        /// </summary>
        private Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medicalTeam = new Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam();

        /// <summary>
        /// 医疗组业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.MedicalTeam medicalTeamLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeam();

        
        #endregion
        #region 属性
        /// <summary>
        

        /// <summary>
        /// 医疗组信息
        /// </summary>
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
        /// <summary>
        /// 获取值
        /// </summary>
        private void SetValue()
        {
            this.txtDeptName.Text = this.medicalTeam.Dept.Name;
            this.txtMecialTeam.Text = this.medicalTeam.Name;
            this.ckbValid.Checked = this.medicalTeam.IsValid;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="medcialTeam"></param>
        private void Save()
        {

            int reuturnValue = 1;
            string strMsg = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medcialTeamClone = this.MedicalTeam.Clone();
            medcialTeamClone.Name = this.txtMecialTeam.Text;
            medcialTeamClone.IsValid = this.ckbValid.Checked;
            medcialTeamClone.Oper.ID = this.medicalTeamLogic.Operator.ID;
            medcialTeamClone.Oper.OperTime = this.medicalTeamLogic.GetDateTimeFromSysDateTime();
            if (string.IsNullOrEmpty(MedicalTeam.ID)) //新增
            {
                string seqNO = this.medicalTeamLogic.GetSequence("MedicalTeam.GetSeq");
                medcialTeamClone.ID = seqNO.PadLeft(8, '0');

               reuturnValue = this.medicalTeamLogic.InsertMedicalTeam(medcialTeamClone);
               if (reuturnValue < 0)
               {
                   MessageBox.Show("插入表出错!\n" + this.medicalTeamLogic.Err);
                   return;
               }
               strMsg = "保存成功";

            }
            else //修改
            {
                reuturnValue = this.medicalTeamLogic.UpdateMedicalTeam(medcialTeamClone);
                if (reuturnValue < 0)
                {
                    MessageBox.Show("更新表出错!\n" + this.medicalTeamLogic.Err);
                    return;
                }
                strMsg = "修改成功";
            }

            MessageBox.Show(strMsg);
            this.DialogResult = DialogResult.OK;


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
    }
}
