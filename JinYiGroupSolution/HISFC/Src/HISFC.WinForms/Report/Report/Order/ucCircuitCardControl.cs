using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucCircuitCardControl : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow, Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        private string hosname;

        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
        Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
        Neusoft.HISFC.BizProcess.Integrate.RADT inpatientManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        ArrayList curValues = null; //当前显示的数据
        /// <summary>
        /// 
        /// </summary>
        protected string inpatientNo;
        /// <summary>
        /// 
        /// </summary>
        bool isPrint = false;
        List<Neusoft.HISFC.Models.RADT.PatientInfo> myPatients = null;
        DateTime dt1;
        DateTime dt2;
        string usCode;
        ArrayList al;
        /// <summary>
        /// 
        /// </summary>
        public ucCircuitCardControl()
        {
            InitializeComponent();

            Neusoft.HISFC.BizProcess.Integrate.Manager managermgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            hosname = managermgr.GetHospitalName();
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="usagecode"></param>
        /// <param name="dtTime"></param>
        /// <param name="isPrinted"></param>
        public void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usagecode, DateTime dtTime, bool isPrinted)
        {
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="usageCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="isPrinted"></param>
        public void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usageCode, DateTime dtBegin, DateTime dtEnd, bool isPrinted)
        {
            this.myPatients = patients;
            this.usCode = usageCode;
            this.dt1 = dtBegin;
            this.dt2 = dtEnd;
            this.IsPrint = isPrinted;
            this.OnRetrieve(new object[1]);

        }

        /// <summary>
        /// 
        /// </summary>
        public void PrintSet()
        {
            print.ShowPrintPageDialog();
            this.Print();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            try
            {

                for (int idx = 0; idx < myPatients.Count ; idx++)
                {

                    #region dw处理

                    dwMain.Reset();
                    dwMain.Retrieve(new string[] { myPatients[idx].ID }, this.usCode, this.dt1, this.dt2, Neusoft.FrameWork.Function.NConvert.ToInt32(this.IsPrint).ToString());

                    if (this.dwMain.RowCount < 1)
                    {
                        continue;
                    }
                    
                    this.dwMain.CalculateGroups();

                    dwMain.Modify("t_1.text = '" + hosname + "输液观察卡'");

                    string curComboID = "";
                    //取组合号，注意datawindow是从1开始，和。net不一样
                    string tmpComboID = this.dwMain.GetItemString(1, 11) + this.dwMain.GetItemDateTime(1, 12).ToString("yyyyMMddHHmm");
                    for (int i = 2; i <= this.dwMain.RowCount; i++)
                    {
                        curComboID = this.dwMain.GetItemString(i, 11) + this.dwMain.GetItemDateTime(i, 12).ToString("yyyyMMddHHmm");
                        if (tmpComboID == curComboID)
                        {
                            //组合号相等，如果上一个没有标志说明是组合的第一个
                            if (string.IsNullOrEmpty(this.dwMain.GetItemString(i - 1, 17).Trim()))
                            {
                                //组合第一个赋值
                                this.dwMain.SetItemString(i - 1, "comb_text", "┏");
                                //如果是最后一行
                                if (i == this.dwMain.RowCount)
                                    this.dwMain.SetItemString(i, "comb_text", "┗");
                                else
                                    this.dwMain.SetItemString(i, "comb_text", "┃");//这里不管是否是一组最后一个，最后一个在组合号不等时才设置
                            }
                            else
                            {
                                //如果是最后一行┏┗
                                if (i == this.dwMain.RowCount)
                                    this.dwMain.SetItemString(i, "comb_text", "┗");
                                else
                                    this.dwMain.SetItemString(i, "comb_text", "┃");
                            }
                        }
                        else
                        {
                            //组合号不等，这时会改变在组合号相等时设置的"┃"或者"┓"，为"┛"
                            if (!string.IsNullOrEmpty(this.dwMain.GetItemString(i - 1, "comb_text").Trim()))
                            {
                                //设置一组的最后一个符合
                                if (this.dwMain.GetItemString(i - 1, "comb_text") == "┃" || this.dwMain.GetItemString(i - 1, "comb_text") == "┏")
                                    this.dwMain.SetItemString(i - 1, "comb_text", "┗");
                            }
                        }
                        tmpComboID = curComboID;
                    }

                    #endregion


                    #region 打印处理

                    int ge = Convert.ToInt32(this.dwMain.GetItemDecimal(1, "compute_7"));
                    int ren = Convert.ToInt32(this.dwMain.GetItemDecimal(1, "compute_8"));
                    int length = Convert.ToInt32((30 + 75 * ren + this.dwMain.RowCount * 25 + ge * 3) / 3.9);

                    this.dwMain.PrintProperties.PrinterName = "165";
                    this.dwMain.PrintProperties.PaperSize = 256;

                    this.dwMain.PrintProperties.CustomPageLength = (length + 40) > 100 ? (length + 40) : 94;
                    this.dwMain.PrintProperties.CustomPageWidth = 165;

                    this.dwMain.PrintProperties.MarginTop = 0;
                    this.dwMain.PrintProperties.MarginLeft = 0;

                    this.dwMain.Print(false, false);

                    #endregion


                    #region 更新已经打印标记

                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    ArrayList al = this.orderManager.QueryOrderCircult(this.myPatients[idx].ID, this.dt1, this.dt2, this.usCode, this.IsPrint);
                    
                    foreach (Neusoft.HISFC.Models.Order.ExecOrder obj in al)
                    {
                        if (this.orderManager.UpdateTransfusionPrinted(obj.ID) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新打印标记失败!" + orderManager.Err);
                            return;
                        }
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    #endregion

                }

            } 
            catch 
            {
                MessageBox.Show("打印机参数或设置不正确！");
            }


            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            inpatientNo = "";
            List<string> listInpatientNo = new List<string>();

            for (int i = 0; i <= this.myPatients.Count - 1; i++)
            {
                string pNo = this.myPatients[i].ID;
                inpatientNo += pNo + ",";
                listInpatientNo.Add(this.myPatients[i].ID);
            }
            inpatientNo = inpatientNo.Substring(0, inpatientNo.Length - 1);
            #region {B7DD6B22-FFE2-4920-852D-690EF10C09A8}
            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managermgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                string hosname = managermgr.GetHospitalName();

                dwMain.Modify("t_1.text = '" + hosname + "输液观察卡'");
            }
            catch { }
            #endregion
            string[] myPatientNO = listInpatientNo.ToArray();            //dwMain.Retrieve(inpatientNo, this.dtpBeginTime.Value, this.dtpEndTime.Value);
            base.OnRetrieve(myPatientNO, this.usCode, this.dt1, this.dt2, Neusoft.FrameWork.Function.NConvert.ToInt32(this.IsPrint).ToString());

            #region {B5986A1A-8244-43eb-975E-940A0FB45B5F}
            //高人教导三层的datawindow如果使用了分组必须调用一下这个方法
            this.dwMain.CalculateGroups();
            #region 画组合号
            if (this.dwMain.RowCount < 1)//如果没有医嘱返回
            {
                return 1;
            }
            string curComboID = "";
            //取组合号，注意datawindow是从1开始，和。net不一样
            string tmpComboID = this.dwMain.GetItemString(1, 11) + this.dwMain.GetItemDateTime(1, 12).ToString("yyyyMMddHHmm");
            for (int i = 2; i <= this.dwMain.RowCount; i++)
            {
                curComboID = this.dwMain.GetItemString(i, 11) + this.dwMain.GetItemDateTime(i, 12).ToString("yyyyMMddHHmm");
                if (tmpComboID == curComboID)
                {
                    //组合号相等，如果上一个没有标志说明是组合的第一个
                    if (string.IsNullOrEmpty(this.dwMain.GetItemString(i - 1, 17).Trim()))
                    {
                        //组合第一个赋值
                        this.dwMain.SetItemString(i - 1, "comb_text", "┏");
                        //如果是最后一行
                        if (i == this.dwMain.RowCount)
                            this.dwMain.SetItemString(i, "comb_text", "┗");
                        else
                            this.dwMain.SetItemString(i, "comb_text", "┃");//这里不管是否是一组最后一个，最后一个在组合号不等时才设置
                    }
                    else
                    {
                        //如果是最后一行┏┗
                        if (i == this.dwMain.RowCount)
                            this.dwMain.SetItemString(i, "comb_text", "┗");
                        else
                            this.dwMain.SetItemString(i, "comb_text", "┃");
                    }
                }
                else
                {
                    //组合号不等，这时会改变在组合号相等时设置的"┃"或者"┓"，为"┛"
                    if (!string.IsNullOrEmpty(this.dwMain.GetItemString(i - 1, "comb_text").Trim()))
                    {
                        //设置一组的最后一个符合
                        if (this.dwMain.GetItemString(i - 1, "comb_text") == "┃" || this.dwMain.GetItemString(i - 1, "comb_text") == "┏")
                            this.dwMain.SetItemString(i - 1, "comb_text", "┗");
                    }
                }
                tmpComboID = curComboID;
            }

           
            #endregion
            #endregion
            return 1;

        }


    }
}

