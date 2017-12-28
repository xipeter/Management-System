using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShenYangCitySI.Control
{
    public partial class frmProcessBackground : Form
    {
        public frmProcessBackground()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 患者基本信息综合实体
        /// </summary>
        Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();

        /// <summary>
        /// <summary>
        /// 入出转integrate层
        /// </summary>
        Neusoft.HISFC.Integrate.RADT radtIntegrate = new Neusoft.HISFC.Integrate.RADT();

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
                Neusoft.NFC.Interface.Classes.Function.Msg(this.ucQueryInpatientNo.Err, 211);

                this.ucQueryInpatientNo.Focus();
                return;
            }
            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
        }

        private void btnCallBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInvoice.Text))
            {
                MessageBox.Show("请填写发票号");
                return;
            }
            if (this.patientInfo == null)
            {
                MessageBox.Show("请选择患者");
                return;
            }
            if (this.myProcess.GetRegInfoInpatient(this.patientInfo) < 0)
            {
                MessageBox.Show("读卡失败" + this.myProcess.ErrMsg);
                return;
            }
            string medicaltype = this.localManager.GetMedicalType(this.patientInfo.ID, this.txtInvoice.Text, "2");
            if (medicaltype == null || medicaltype == "")
            {
                MessageBox.Show("医保类别不能为空" + this.localManager.Err);
                return;
            }
            this.patientInfo.SIMainInfo.MedicalType.ID = medicaltype;

            this.patientInfo.SIMainInfo.InvoiceNo = this.txtInvoice.Text;

            StringBuilder dataBuffer = new StringBuilder(1024);

            int returnValue = Functions.ExpenseCalc(-1,
                                                   "1",
                                                   this.patientInfo.SIMainInfo.MedicalType.ID,
                                                   this.patientInfo.ID,
                                                   this.patientInfo.SIMainInfo.InvoiceNo,
                                                   this.patientInfo.SIMainInfo.Memo,
                                                   this.patientInfo.SIMainInfo.OperInfo.ID,
                                                   DateTime.Now.ToString(DATE_TIME_FORMAT),
                                                   this.patientInfo.SIMainInfo.Disease.ID,
                                                   this.patientInfo.SIMainInfo.Disease.Name,
                                                   1,
                                                   dataBuffer);

            if (returnValue != 0)
            {
                MessageBox.Show(dataBuffer.ToString());
                return;
            }
            MessageBox.Show("操作成功！");
        }
    }
}