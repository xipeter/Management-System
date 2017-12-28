using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ucCheckPrint : System.Windows.Forms.Form, Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint
    {
        /// <summary>
        /// 医嘱检查单
        /// </summary>
        public ucCheckPrint()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizProcess.Integrate.Manager mgrIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #region ICheckPrint 成员

        /// <summary>
        /// 门诊检查 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="orderList"></param>
        public void ControlValue(Neusoft.HISFC.Models.Registration.Register patient, List<Neusoft.HISFC.Models.Order.OutPatient.Order> orderList)
        {
            if (patient.Pact.Name != null)
                this.neuSpread1_Sheet1.Cells[2, 9].Value = patient.Pact.Name.ToString();//费用类别
            if (patient.Name != null)
                this.neuSpread1_Sheet1.Cells[3, 1].Value = patient.Name.ToString();//姓名
            if (patient.Sex != null)
                this.neuSpread1_Sheet1.Cells[3, 3].Value = patient.Sex.ToString();//性别
            if (patient.Age != null)
                this.neuSpread1_Sheet1.Cells[3, 5].Value = patient.Age.ToString();//年龄
        }
        /// <summary>
        /// 住院检查
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="orderList"></param>
        public void ControlValue(Neusoft.HISFC.Models.RADT.Patient patient, List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {

            this.neuSpread1_Sheet1.Cells[0, 0].Value = this.mgrIntegrate.GetHospitalName() + orderList[0].Item.Name.ToString() + "检查申请单";

            if (orderList[0].IsEmergency)
            {
                this.neuSpread1_Sheet1.Cells[0, 9].Value = "加  急";//加急
                this.neuSpread1_Sheet1.Cells.Get(0, 9).ForeColor = System.Drawing.Color.Red;
            }
            if (orderList[0].BeginTime!=null)
                this.neuSpread1_Sheet1.Cells[2, 1].Value = orderList[0].BeginTime.ToString();//申请日期
            if (patient.PID.PatientNO!=null)
                this.neuSpread1_Sheet1.Cells[2, 5].Value = patient.PID.PatientNO.ToString();//住院号
            if (patient.Pact.Name!=null)
                this.neuSpread1_Sheet1.Cells[2, 9].Value = patient.Pact.Name.ToString();//费用类别
            if (patient.Name!=null)
                this.neuSpread1_Sheet1.Cells[3, 1].Value = patient.Name.ToString();//姓名
            if (patient.Sex!=null)
                this.neuSpread1_Sheet1.Cells[3, 3].Value = patient.Sex.ToString();//性别
            if (patient.Age!=null)
                this.neuSpread1_Sheet1.Cells[3, 5].Value = patient.Age.ToString();//年龄
            if (orderList[0].NurseStation.Name!=null)
                this.neuSpread1_Sheet1.Cells[3, 7].Value = orderList[0].NurseStation.Name.ToString();//病区
            if (orderList[0].Patient.PVisit.PatientLocation.Bed.ID!= null)
                this.neuSpread1_Sheet1.Cells[3, 9].Value = orderList[0].Patient.PVisit.PatientLocation.Bed.ID.ToString();//床号         

            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();

            Neusoft.HISFC.BizLogic.Fee.Item item = new Neusoft.HISFC.BizLogic.Fee.Item();

            undrug = item.GetValidItemByUndrugCode(orderList[0].Item.ID.ToString());

            if (undrug.CheckRequest != null)
                this.neuSpread1_Sheet1.Cells[4, 1].Value = undrug.CheckRequest.ToString();//检查部位/要求 

            #region  诊断(代码摘自ucDiagnosis FillList())
            Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC diagnoseMgrMc = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBaseMC();
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            Neusoft.HISFC.Models.HealthRecord.Diagnose diagns = null;
            Neusoft.HISFC.Models.Base.Spell dsType = null;
            Neusoft.HISFC.Models.Base.Employee emp = null;

            //ArrayList diagnoseList = diagnoseMgrMc.QueryDiagnoseBoth(orderList[0].Patient.PVisit.PatientLocation.Bed.InpatientNO.ToString());
            ArrayList diagnoseList = diagnoseMgrMc.QueryDiagnoseBoth(orderList[0].Patient.ID);
            ArrayList dsTypeList = Neusoft.HISFC.Models.HealthRecord.DiagnoseType.SpellList();
            ArrayList drList = managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            String strDsType = "";
            String strDrName = "";
            string diag = string.Empty;
            if (diagnoseList != null)
            {
                for (int i = 0; i < diagnoseList.Count; i++)
                {
                    diagns = (Neusoft.HISFC.Models.HealthRecord.Diagnose)diagnoseList[i];
                    for (int j = 0; j < dsTypeList.Count; j++)
                    {
                        dsType = (Neusoft.HISFC.Models.Base.Spell)dsTypeList[j];
                        if (dsType.ID.ToString() == diagns.DiagInfo.DiagType.ID)
                        {
                            strDsType = dsType.Name;//诊断类型
                            break;
                        }
                    }
                    //填入诊断医生姓名
                    for (int j = 0; j < drList.Count; j++)
                    {
                        emp = (Neusoft.HISFC.Models.Base.Employee)drList[j];
                        if (emp.ID.ToString() == diagns.DiagInfo.Doctor.ID)
                        {
                            strDrName = emp.Name;
                            break;
                        }
                    }
                    if (i == 0)
                        diag = "[" + strDsType + "-" + diagns.DiagInfo.ICD10.Name.ToString() + "-" + strDrName + "]";
                    else
                        diag = diag + "[" + strDsType + "-" + diagns.DiagInfo.ICD10.Name.ToString() + "-" + strDrName + "]";

                }
            }
            this.neuSpread1_Sheet1.Cells[9, 1].Value = diag;
            #endregion

            if (orderList[0].ReciptDoctor.Name != null)
                this.neuSpread1_Sheet1.Cells[19, 1].Value = orderList[0].Memo.ToString();//备注
            if (orderList[0].Memo != null)
                this.neuSpread1_Sheet1.Cells[25, 9].Value = orderList[0].ReciptDoctor.Name.ToString();//医师

            if (undrug.Notice != null)
                this.neuSpread1_Sheet1.Cells[22, 1].Value = undrug.Notice.ToString();//注意事项          

        }
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Reset()
        {
            this.neuSpread1_Sheet1.Cells[0, 9].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[2, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[2, 5].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[2, 9].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[3, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[3, 3].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[3, 5].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[3, 7].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[4, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[9, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[11, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[16, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[19, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[22, 1].Value = string.Empty;
            this.neuSpread1_Sheet1.Cells[25, 1].Value = string.Empty;
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        public void Show()
        {
            //Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "项目检查单";
            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this);
            base.ShowDialog();
        }

        #endregion

        #region IReportPrinter 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Export()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int  Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            //print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.SetPageSize(new System.Drawing.Printing.PaperSize("A4", 800, 860));
            //print.PrintPreview(27, 73, this.neuPanel1);
            print.PrintPage(32, 64, this.neuPanel1);
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int PrintPreview()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 1;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>      
        private void neuButton1_Click_1(object sender, EventArgs e)
        {
            this.Print();
        }     
        #endregion


    }
}
