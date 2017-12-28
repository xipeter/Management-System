using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 患者费用查询]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQueryFee : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryFee()
        {
            InitializeComponent();
            
        }

#region 方法


        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <param name="patient"></param>
        private void DispPatientinfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.neuLabel3.Text = patient.Name + "[" + patient.PID.PatientNO + ", " + patient.Sex.Name + ",  " + patient.PVisit.PatientLocation.Dept.Name + " ]";
        }
#endregion

        private void ucQueryInpatientNo1_myEvent()
        {
            PatientInfo patientInfo = Environment.RadtManager.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);

            if (patientInfo == null)
            {
                MessageBox.Show("没有查到该患者信息");
                return;
            }
                //显示第一个患者费用明细
            this.ucQueryFeeDrug1.AddItems(patientInfo);
            this.ucQueryFeeUndrug1.AddItems(patientInfo);

            this.DispPatientinfo(patientInfo);
            
            
        }

        protected override int OnPrint(object sender, object neuObject)
        {

			if(this.neuTabControl1.SelectedIndex == 0)
			{
                this.ucQueryFeeDrug1.Print();
			}
            else if (this.neuTabControl1.SelectedIndex == 1)
			{
                this.ucQueryFeeUndrug1.Print();
			}
		
            return base.OnPrint(sender, neuObject);
        }
    }
}
