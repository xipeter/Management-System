using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbInpatientFeeList :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbInpatientFeeList()
        {
            InitializeComponent();
        }

        //Neusoft.HISFC.BizLogic.RADT.InPatient managerRADTInPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.BizLogic.RADT.InPatient managerRADTInPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient(); 
        /// <summary>
        /// 住院流水号，like ZY010070000556
        /// </summary>
        private string inpatientNo = string.Empty;

        /// <summary>
        /// 患者摘要显示串
        /// </summary>
        private string patientInfo = "姓名：{0} 姓别：{1} 合同单位：{2} 住院科室：{3}";

        /// <summary>
        /// 事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.getInpatientNO();
            //查询
            OnRetrieve();
        }

        /// <summary>
        /// 根据输入住院号获取患者住院流水号
        /// </summary>
        private void getInpatientNO()
        {
            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo.Equals(string.Empty))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您输入的住院号错误,请重新输入!"));
                this.inpatientNo = "";
                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.managerRADTInPatient.QueryPatientInfoByInpatientNO(this.ucQueryInpatientNo1.InpatientNo);
            if (patientInfo == null || patientInfo.ID == null || patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取患者基本信息出错!") + this.managerRADTInPatient.Err);
                this.inpatientNo = "";
                return;
            }
            inpatientNo = patientInfo.ID;
            this.lbPatientInfo.Text = string.Format(this.patientInfo, patientInfo.Name, patientInfo.Sex, patientInfo.Pact.Name, patientInfo.PVisit.PatientLocation.Dept.Name);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
       // protected override int(params object[] objects)
        protected override int  OnRetrieve(params object[] objects)

        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            if (this.inpatientNo.Equals(string.Empty))
            {
                return -1;
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索数据，请稍候......");
                return this.dwMain.Retrieve(this.inpatientNo, this.beginTime, this.endTime);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                this.dwMain.Print(true, true);
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
