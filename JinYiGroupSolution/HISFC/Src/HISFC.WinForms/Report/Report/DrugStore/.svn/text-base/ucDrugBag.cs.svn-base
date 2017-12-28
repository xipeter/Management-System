using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.DrugStore
{
    /// <summary>
    /// 药袋打印
    /// 
    ///  <功能说明>
    ///     1、药袋打印采用横打
    ///     2、格式参照肿瘤医院项目的
    /// </功能说明>
    /// </summary>
    public partial class ucDrugBag : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint
    {
        public ucDrugBag()
        {
            InitializeComponent();
        }

        private int MaxRows = 5;

        private static Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 每个患者的总数
        /// </summary>
        private int patientTotNum = 1;

        private static int DataInit()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList alDept = deptManager.GetDeptmentAll();
            if (alDept != null)
            {
                deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);
            }

            return 1;
        }

        #region IDrugPrint 成员

        public void AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
           
        }

        public void AddAllData(System.Collections.ArrayList al)
        {
            System.Collections.Hashtable hsPatientApply = new System.Collections.Hashtable();

            #region 按患者分组 将同一患者的所有申请集中在一起

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)            
            {
                if (hsPatientApply.ContainsKey(info.PatientNO))
                {
                    (hsPatientApply[info.PatientNO] as List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>).Add(info);
                }
                else
                {
                    List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> temp = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
                    temp.Add(info);

                    hsPatientApply.Add(info.PatientNO, temp);
                }
            }

            #endregion

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime sysTime = dataManager.GetDateTimeFromSysDateTime();

            this.lbPrintDate.Text = "打印时间：" + sysTime.ToString("HH:mi:ss");

            #region 患者打印 按患者打印每个患者的用药明细

            foreach (List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alPatient in hsPatientApply.Values)
            {
                if (alPatient.Count <= 0)
                {
                    break;
                }
                
                //按照用药时间点排序
                SortOrder sort = new SortOrder();
                alPatient.Sort(sort);

                #region Label信息显示

                Neusoft.HISFC.Models.Pharmacy.ApplyOut temp = alPatient[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (deptHelper == null)
                {
                    DataInit();
                }
                if (deptHelper != null)
                {
                    this.lbDept.Text = deptHelper.GetName(temp.ApplyDept.ID);
                }
                else
                {
                    this.lbDept.Text = temp.ApplyDept.ID;
                }
                if (temp.User02.Length > 3)
                {
                    this.lbBed.Text = temp.User02.Substring(4);
                }
                else
                {
                    this.lbBed.Text = temp.User02;
                }
                this.lbName.Text = "     " + temp.User01;
                this.lbPatientNO.Text = "     " + temp.PatientNO.Substring(4);

                #endregion

                string privUsePoint = "-1";

                this.neuSpread1_Sheet1.Rows.Count = 0;

                List<List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>> patientList = new List<List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>>();

                List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> useList = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();

                int iCount = 1;
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut apply in alPatient)
                {
                    #region 对每个患者的 按照医嘱组合号、用药时间进行分组

                    if (privUsePoint == "-1")            //第一次添加
                    {
                        useList = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
                        useList.Add(apply);

                        privUsePoint = apply.User03;
                        iCount = 1;
                    }
                    else if (privUsePoint == apply.User03)         //同一频次点的药品
                    {
                        if (iCount > 5)                 //第五个药品 需换页
                        {
                            patientList.Add(useList);

                            useList = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
                            useList.Add(apply);
                            iCount = 1;
                        }
                        else
                        {
                            useList.Add(apply);
                            iCount++;
                        }
                    }
                    else                              //不同频次点的药品
                    {
                        patientList.Add(useList);

                        useList = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
                        useList.Add(apply);
                        iCount = 1;

                        privUsePoint = apply.User03;
                    }

                    #endregion
                }

                if (useList.Count > 0)
                {
                    patientList.Add(useList);
                }

                //patientList.Count 为该患者的所有单据数
                int iPageNO = 1;
                foreach (List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> singleList in patientList)
                {
                    this.neuSpread1_Sheet1.Rows.Count = 0;

                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut apply in singleList)
                    {
                        string useTime = this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(apply.User03), sysTime);

                        int iRowIndex = this.neuSpread1_Sheet1.Rows.Count;
                        this.neuSpread1_Sheet1.Rows.Add(iRowIndex, 1);
                        this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text = apply.Item.Name + "－" + Function.DrugDosage.GetStaticDosage(apply.Item.ID) + "[" + apply.Item.Specs + "]";
                        this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text = (apply.Operation.ApplyQty * apply.Days).ToString() + apply.Item.MinUnit;
                        this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text = useTime;

                        this.lbDate.Text = "         " + Neusoft.FrameWork.Function.NConvert.ToDateTime(apply.User03).ToString("yy-MM-dd");
                        this.lbTime.Text = "         " + useTime;
                        this.lbPage.Text = iPageNO.ToString() + " / " + patientList.Count.ToString();                        
                    }

                    this.Print();

                    iPageNO++;
                }

                //foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut apply in alPatient)
                //{
                //    if (privOrderID == "")                  //第一个药
                //    {
                //        privOrderID = apply.OrderNO;
                //        useTime = this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(apply.User03), sysTime);

                //        this.neuSpread1_Sheet1.Cells[iCount, 0].Text = apply.Item.Name + "－" + Function.DrugDosage.GetStaticDosage(apply.Item.ID) + "[" + apply.Item.Specs + "]";
                //        this.neuSpread1_Sheet1.Cells[iCount, 1].Text = "";
                //        this.neuSpread1_Sheet1.Cells[iCount, 2].Text = useTime;

                //        useList.Add(apply);
                //    }
                //    else if (privOrderID == apply.OrderNO)        //是一个药
                //    {
                //        useTime = useTime + this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(apply.User03), sysTime);
                //        this.neuSpread1_Sheet1.Cells[iCount, 2].Text = useTime;

                //        useList.Add(apply);
                //    }
                //    else                                    //不同的药品
                //    {
                //        if (iCount == this.MaxRows - 1)
                //        {
                //            #region 打印每个时间点明细

                //            this.PrintDetail(useList, sysTime);

                //            useList.Clear();

                //            #endregion

                //            this.Clear();
                //        }
                //        else
                //        {
                //            iCount++;

                //            privOrderID = apply.OrderNO;
                //            useTime = this.FormatDateTime(Neusoft.FrameWork.Function.NConvert.ToDateTime(apply.User03), sysTime);

                //            this.neuSpread1_Sheet1.Cells[iCount, 0].Text = apply.Item.Name + "－" + Function.DrugDosage.GetStaticDosage(apply.Item.ID) + "[" + apply.Item.Specs + "]";
                //            this.neuSpread1_Sheet1.Cells[iCount, 1].Text = "";
                //            this.neuSpread1_Sheet1.Cells[iCount, 2].Text = useTime;

                //            useList.Add(apply);
                //        }
                //    }
                //}

                //if (useList.Count > 0)
                //{
                //    this.PrintDetail(useList, sysTime);
                //}
            }

            #endregion
        }

        public void AddCombo(System.Collections.ArrayList alCombo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut info)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public decimal DrugTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public Neusoft.HISFC.Models.RADT.PatientInfo InpatientInfo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public decimal LabelTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public Neusoft.HISFC.Models.Registration.Register OutpatientInfo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void Preview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("DrugBag", ref print);

            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPreview(30, 10, this);
        }

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("DrugBag", ref print);

            System.Drawing.Printing.PageSettings pSet = new System.Drawing.Printing.PageSettings();
            pSet.Landscape = true;

            print.PrintDocument.DefaultPageSettings.Landscape = true;

            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPage(0, 100, this);

            this.neuSpread1_Sheet1.Rows.Count = 0;

        }

        #endregion

        private void Clear()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count - 1; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Text = "";
                this.neuSpread1_Sheet1.Cells[i, 1].Text = "";
                this.neuSpread1_Sheet1.Cells[i, 2].Text = "";
            }
        }

        private string FormatDateTime(DateTime dt, DateTime sysdate)
        {
            try
            {
                if (sysdate.Date.AddDays(-1) == dt.Date)
                {
                    return "昨" + dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
                }
                else if (sysdate.Date == dt.Date)
                {
                    return dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
                }
                else if (sysdate.Date.AddDays(1) == dt.Date)
                {
                    return "明" + dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
                }
                else if (sysdate.Date.AddDays(2) == dt.Date)
                {
                    return "后" + dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
                }
                else
                {
                    return dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
                }
            }
            catch
            {
                return dt.Hour.ToString().PadLeft(2, '0') + dt.ToString("tt");
            }
        }

        public class SortOrder : IComparer<Neusoft.HISFC.Models.Pharmacy.ApplyOut>
        {
            #region IComparer<ApplyOut> 成员

            public int Compare(Neusoft.HISFC.Models.Pharmacy.ApplyOut o1, Neusoft.HISFC.Models.Pharmacy.ApplyOut o2)
            {
                string oX = o1.User03;          //用药时间
                string oY = o2.User03;          //用药时间              

                int nComp;

                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
            }

            #endregion
        }
    }
}
