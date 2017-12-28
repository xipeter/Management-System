using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 住院患者基本信息]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// <修改记录>
    ///     
    /// </修改记录>
    /// </summary>
    public partial class ucInpatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInpatientInfo()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 住院患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfoObj = null;

        #endregion

        #region 属性
        /// <summary>
        /// 住院患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfoObj
        {
            set
            {
                if (value != null)
                {
                    this.patientInfoObj = value;
                    this.SetValue();
                }
            }
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 界面赋值
        /// </summary>
        protected virtual void SetValue()
        {
            //姓名
            this.txtName.Text = this.patientInfoObj.Name;

            //合同单位
            this.txtPact.Text = this.patientInfoObj.Pact.Name;

            //住院科室
            this.txtDept.Text = this.patientInfoObj.PVisit.PatientLocation.Dept.Name;

            //所属病区
            this.txtNurseStation.Text = this.patientInfoObj.PVisit.PatientLocation.NurseCell.Name;

            //入院日期
            this.txtDateIn.Text = this.patientInfoObj.PVisit.InTime.ToShortDateString();

            //住院医生
            this.txtDoctor.Text = this.patientInfoObj.PVisit.AdmittingDoctor.Name;

            //床号
            this.txtBedNo.Text = this.patientInfoObj.PVisit.PatientLocation.Bed.ID;

            //出生日期
            this.txtBirthday.Text = this.patientInfoObj.Birthday.ToShortDateString();

            //费用总额
            this.txtTotCost.Text = this.patientInfoObj.FT.TotCost.ToString();

            //自费金额
            this.txtOwnCost.Text = this.patientInfoObj.FT.OwnCost.ToString();

            //自付金额
            this.txtPayCost.Text = this.patientInfoObj.FT.PayCost.ToString();

            //公费金额
            this.txtPubCost.Text = this.patientInfoObj.FT.PubCost.ToString();

            //预交金额
            this.txtPrepayCost.Text = this.patientInfoObj.FT.PrepayCost.ToString();

            //余额
            this.txtFreeCost.Text = this.patientInfoObj.FT.LeftCost.ToString();

        }

        /// <summary>
        /// 清屏
        /// </summary>
        public virtual void Clear()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuTextBox))
                {
                    ((Neusoft.FrameWork.WinForms.Controls.NeuTextBox)control).Text = "";
                }
            }
        }
        #endregion
    }
}
