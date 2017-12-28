using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// [功能描述: 后台召回处理程序]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: ]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间='2009-2-13'
    ///	修改目的='代码格式修改及诊断属性修改'
    ///	修改描述=''
    ///  >
    /// </summary>
    public partial class frmProcessBackground : Form
    {
        public frmProcessBackground()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 患者基本信息综合实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// <summary>
        /// 入出转integrate层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 医保业务层
        /// </summary>
        private LocalManager localManager = new LocalManager();

        /// <summary>
        /// 日期格式
        /// </summary>
        protected const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";

        Process myProcess = new Process();

        private void ucQueryInpatientNo_myEvent()
        {
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo.Err == "")
                {
                    ucQueryInpatientNo.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo.Err, 211);

                this.ucQueryInpatientNo.Focus();
                return;
            }
            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
        }

        private void btnCallBack_Click(object sender, EventArgs e)
        {
        }
    }
}