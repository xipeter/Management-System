using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.Report.InpatientFee
{
    #region 住院患者一日清单
    public partial class ucDayList : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDayList()
        {
            InitializeComponent();
        }
        private System.ComponentModel.Container components = null;
        private int ReportrowsCount = 0;
        Neusoft.HISFC.Management.Fee.FeeReport repMgr = new Neusoft.HISFC.Management.Fee.FeeReport();
        Neusoft.HISFC.Management.Fee.Interface siMgr = new Neusoft.HISFC.Management.Fee.Interface();
        public Report.InpatientFee.crDayList cr = new Report.InpatientFee.crDayList();
        Report.ReportClass rep = new Report.ReportClass();

        /// <summary>
        /// 返回记录总数
        /// </summary>
        public int RowsCount
        {
            get
            {
                return ReportrowsCount;
            }
            set
            {
                ReportrowsCount = value;
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            rep.PrintDoc.PrintToPrinter(1, false, 0, 0);
        }
        /// <summary>
        /// 根据传入的患者基本信息和查询日期检索费用明细
        /// </summary>
        /// <param name="alPatient">患者信息(RADT.PatientInfo)</param>
        /// <param name="dtQuery">日期(datetime型)</param>
        public void queryPatientFee(ArrayList alPatient, DateTime dtQuery)
        {
            if (alPatient == null) return;
            string sDtFrom = dtQuery.ToShortDateString() + " 00:00:00";
            string sDtTo = dtQuery.ToShortDateString() + " 23:59:59";
            string sPrintDt = this.repMgr.GetDateTimeFromSysDateTime().ToString();
            Report.InpatientFee.dsFeeList dsFeeList = new dsFeeList();
            Neusoft.NFC.Object.NeuObject obj;
            try
            {
                foreach (Neusoft.HISFC.Object.RADT.PatientInfo patientInfo in alPatient)
                {
                    DataSet ds = this.repMgr.GetPatientDuimalFee(patientInfo.ID, sDtFrom, sDtTo);
                    //取那一时刻(end)的费用情况
                    obj = this.repMgr.GetPatientFeeTot(patientInfo.ID, DateTime.Parse(sDtTo));
                    if (obj == null || ds == null)
                    {
                        MessageBox.Show("查询患者费用信息出错" + this.repMgr.Err);
                        return;
                    }
                    decimal decTotCost = Neusoft.NFC.Function.NConvert.ToDecimal(ds.Tables[0].Compute("sum(TOT_COST)", "").ToString());
                    decimal decOwnCost = Neusoft.NFC.Function.NConvert.ToDecimal(ds.Tables[0].Compute("sum(OWNCOST)","").ToString());
                    decimal decPayCost = Neusoft.NFC.Function.NConvert.ToDecimal(ds.Tables[0].Compute("sum(PAYCOST)","").ToString());
                    decimal decPubCost = Neusoft.NFC.Function.NConvert.ToDecimal(ds.Tables[0].Compute("sum(PUBCOST)","").ToString());
                    ////广州医保
                    //if (patientInfo.Patient.Pact.ID == "2")
                    //{
                    //    decimal decSiPub = 0;
                    //    decimal decSiOwn = 0;
                    //    decimal decSiRealPub = 0;
                    //    decimal decSiRealOwn = 0;
                    //    string  sErr = "";
                    //    if(this.siMgr.ExecutePackage(patientInfo.ID, 
                    //                                 DateTime.MinValue, 
                    //                                 Neusoft.NFC.Function.NConvert.ToDateTime(sDtTo),
                    //                                 ref decSiOwn,
                    //                                 ref decSiPub,
                    //                                 ref decSiRealOwn,
                    //                                 ref decSiRealPub,
                    //                                 ref sErr ) == -1)
                    //    {
                    //        MessageBox.Show("计算医保费用出错" + Err);
                    //        return;
                    //    }
                    //    decSiPub = System.Convert.ToDecimal(obj.ID) - decSiOwn;
                    //    obj.User01 = decSiPub.ToString();
                    //    obj.Name = decSiOwn.ToString();
                    //}
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow newRow = dsFeeList.Tables[0].NewRow();
                        newRow[0] = row[1];//分类,
                        newRow[1] = row[0];//项目名称,                      
                        newRow[2] = row[9];//规格,
                        newRow[3] = row[2];//单价,
                        newRow[4] = row[3];//数量,
                        newRow[5] = row[4];//单位,
                        newRow[6] = row[5];//金额,
                        newRow[7] = row[6];//自费,
                        newRow[8] = row[7];//自付,
                        newRow[9] = row[8];//公费,
                        newRow[10] = patientInfo.PID.ID;//住院号,
                        newRow[11] = patientInfo.Name;//姓名,
                        newRow[12] = patientInfo.PVisit.PatientLocation.Dept.Name;//病区,
                        newRow[13] = patientInfo.PVisit.PatientLocation.Bed.Name;//床号,
                        newRow[14] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.ID);
                        newRow[15] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.User01);//info.Fee.Pub_Cost;//    总公费,
                        newRow[16] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.User02);//info.Fee.Balance_Cost;//    已清费用,
                        newRow[17] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.Name);//info.Fee.Own_Cost+info.Fee.Pay_Cost;//    未清费用,
                        newRow[18] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.User03);//info.Fee.Prepay_Cost;//   预交金,
                        newRow[19] = Neusoft.NFC.Function.NConvert.ToDecimal(obj.User03) - Neusoft.NFC.Function.NConvert.ToDecimal(obj.Name);//   结余,
                        newRow[20] = decTotCost;//今天发生,
                        newRow[21] = decPubCost;//今天公费,
                        newRow[22] = decPayCost + decOwnCost;//应交
                        newRow[23] = dtQuery;
                        newRow[24] = patientInfo.PVisit.PatientLocation.Dept.ID;//病区代码
                        newRow[25] = row[10];
                        dsFeeList.Tables[0].Rows.Add(newRow);
                    }
                }
                CrystalDecisions.CrystalReports.Engine.TextObject printTime = cr.ReportDefinition.ReportObjects["txtPrintDate"] as CrystalDecisions.CrystalReports.Engine.TextObject;
                if (printTime != null)
                {
                    printTime.Text = sPrintDt;
                }
                rep.ReportView.ShowCloseButton = false;
                rep.ReportView.ShowPageNavigateButtons = true;
                rep.ReportView.ShowRefreshButton = false;
                rep.ReportView.ShowTextSearchButton = true;
                rep.ShowReportOnce(this.panel1, cr, dsFeeList.Tables[0]);
                
                ReportrowsCount = dsFeeList.Tables[0].Rows.Count;
                

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            

        }


    }
    #endregion
}
