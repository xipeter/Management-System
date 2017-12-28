using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.MetOpd
{
    /// <summary>
    /// ucFinIpbPatientDetail<br></br>
    /// [功能描述: 住院病人费用明细清单UC]<br></br>
    /// [创 建 者: 孙刚]<br></br>
    /// [创建时间: 2007-10-07]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMetOpdPatientList : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        /// <summary>
        /// 构造函数


        /// </summary>
        public ucMetOpdPatientList()
        {
            InitializeComponent();
        }


        private Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();



        Neusoft.HISFC.BizProcess.Integrate.RADT managerRadt = new Neusoft.HISFC.BizProcess.Integrate.RADT();


        private void ucQueryInpatientNo1_myEvent()
        {
            PatientInfo = managerRadt.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo.ToString());
            if (PatientInfo == null)
            {
                if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("无此患者信息", 111) == DialogResult.Yes)
                {
 
                }
                return;
            }
        
            base.OnRetrieve(PatientInfo.ID, base.employee.Dept.ID.ToString());
        }

        private void ucQueryInpatientNo1_Load(object sender, EventArgs e)
        {

        }
    }
}
      

       
       

        