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
    /// 住院配置标签打印
    /// 
    /// <功能说明>
    ///     1、 配置标签打印 
    ///     2、在打印该标签的同时 打印配置清单
    ///     3、该单据根据肿瘤医院项目同时完成
    /// </功能说明>
    /// </summary>
    public partial class ucCompoundLabel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Pharmacy.ICompoundPrint
    {
        public ucCompoundLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 本次医嘱总贴数
        /// </summary>
        private decimal labelTotNum = 0;

        /// <summary>
        /// 患者信息显示
        /// </summary>
        private System.Collections.Hashtable hsPatientInfo = new Hashtable();

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private static Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        private bool isPrintDetailBill = false;

        /// <summary>
        /// 明细单打印
        /// </summary>
        private ucDrugBillDetail ucDetail = null;

        /// <summary>
        /// 清单
        /// </summary>
        private ucCompoundList ucList = null;

        /// <summary>
        /// 配置清单
        /// </summary>
        private ArrayList alCompoundListData = new ArrayList();

        /// <summary>
        /// 医嘱批次
        /// </summary>
        private static List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> orderGroupList = null;

        private static string GetCompoundGroup(DateTime useTime)
        {
            if (orderGroupList == null)
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                orderGroupList = consManager.QueryOrderGroup();
            }

            DateTime juegeTime = new DateTime(2000, 12, 12, useTime.Hour, useTime.Minute, useTime.Second);
            if (orderGroupList != null)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.OrderGroup info in orderGroupList)
                {
                    if (juegeTime >= info.BeginTime && juegeTime <= info.EndTime)
                    {
                        return info.ID;
                    }
                }
            }

            return "";
        }

        #region ICompoundPrint 成员

        /// <summary>
        /// 屏幕清空
        /// </summary>
        public void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        public void AddAllData(System.Collections.ArrayList al)
        {
            //if (ucDetail == null)
            //{
            //    ucDetail = new ucDrugBillDetail();
            //}

            //Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
            //drugBillClass.Name = "配置明细单";

            //ucDetail.Clear();
            ////郁闷的转换 为啥业务层就不统一呢？？？
            //ArrayList alList = new ArrayList();
            //string compoundGroup = "";
            //foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
            //{
            //    Neusoft.HISFC.Models.Pharmacy.ApplyOut tempApply = info.Clone();

            //    string temp = tempApply.User01;
            //    tempApply.User01 = tempApply.User02;
            //    tempApply.User02 = temp;

            //    compoundGroup = GetCompoundGroup(tempApply.UseTime);

            //    alList.Add(tempApply);
            //}

            //ucDetail.IfBPrint = "配置批次：" + compoundGroup;
            //ucDetail.ShowData(alList, drugBillClass);            

            if (this.ucList == null)
            {
                this.ucList = new ucCompoundList();
            }

            this.ucList.Clear();

            this.alCompoundListData = al;

            this.isPrintDetailBill = true;

        }

        public void AddCombo(System.Collections.ArrayList alCombo)
        {
            this.Clear();

            if (deptHelper == null)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptmentAll();
                if (alDept == null)
                {
                    MessageBox.Show("获取科室帮助类信息发生错误");
                }
                deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);
            }

            this.hsPatientInfo.Clear();

            int iCount = 0;
            
            foreach (ArrayList alGroup in alCombo)
            {
                this.neuSpread1_Sheet1.Rows.Count = 0;

                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alGroup)
                {
                    #region 设置患者信息

                    if (info.PatientNO.Substring(0, 1) == "Z")
                    {
                        this.lbPatientInfo.Text = info.CompoundGroup + "  " + info.UseTime.ToString("yyyy-MM-dd") + string.Format("    {0}   共{1}贴 此第{2}贴", GetCompoundGroup(info.UseTime), this.labelTotNum.ToString(), (iCount + 1).ToString()); ;
                    }
                    else
                    {
                        this.lbPatientInfo.Text = info.UseTime.ToString("yyyy-MM-dd HH;mm:ss") + string.Format("      共{0}贴 此第{1}贴", this.labelTotNum.ToString(), (iCount + 1).ToString()); ;                    
                    }

                    if (this.hsPatientInfo.Contains(info.PatientNO))
                    {
                        this.lbDrugInfo.Text = this.hsPatientInfo[info.PatientNO].ToString();
                    }
                    else
                    {
                        if (info.PatientNO.Substring(0, 1) == "Z")
                        {
                            if (info.User01.Length > 3)
                            {
                                this.lbDrugInfo.Text = info.PatientNO.Substring(5) + "     " + info.User01.Substring(4) + "床  " + info.User02 + "  " + deptHelper.GetName(info.ApplyDept.ID);
                            }
                            else
                            {
                                this.lbDrugInfo.Text = info.PatientNO.Substring(5) + "     " + info.User01 + "床  " + info.User02 + "  " + deptHelper.GetName(info.ApplyDept.ID);
                            }
                        }
                        else
                        {
                            this.lbDrugInfo.Text = info.PatientNO + "    " + info.User02 + "  " + deptHelper.GetName(info.ApplyDept.ID);                           
                        }
                        this.hsPatientInfo.Add(info.PatientNO, this.lbDrugInfo.Text);
                    }

                    #endregion

                    #region 设置用药信息

                    //this.lbDrugInfo.Text = string.Format("用药时间：{0}  共 {1} 贴  此第 {2} 贴",info.UseTime.ToString("HH:mm:ss"),this.labelTotNum.ToString(), (iCount + 1).ToString());

                    #endregion

                    string strDosage = string.Empty;
                    //功能好使，现在不用，打不下，用的时候打开  20100507
                    //strDosage = Function.DrugDosage.GetStaticDosage(info.Item.ID);

                    this.neuSpread1_Sheet1.Rows.Add(0, 1);
                    this.neuSpread1_Sheet1.Cells[0, 0].Text = info.Item.Name + "[" + strDosage + info.Item.Specs + "]";
                    this.neuSpread1_Sheet1.Cells[0, 1].Text = info.Operation.ApplyQty.ToString();
                    this.neuSpread1_Sheet1.Cells[0, 2].Text = info.Usage.Name;
                }

                iCount++;

                if (iCount != alCombo.Count)
                {
                    this.Print();
                }
            }

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
            set 
            {
                this.labelTotNum = value;
            }
        }

        public int Prieview()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("compound", ref print);
                //print.SetPageSize(new System.Drawing.Printing.PaperSize("compound", 420, 320));

                print.PrintPreview(0, 45, this);
            }

            if (ucDetail != null)            
            {
                ucDetail.PrintPreview();
            }

            return 1;
        }

        public int Print()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("compound", ref print);

                //print.SetPageSize(new System.Drawing.Printing.PaperSize("compound", 420, 320));

                print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                print.PrintPage(0, 45, this);
            }

            //if (ucDetail != null && this.isPrintDetailBill)
            //{
            //    ucDetail.PrintPreview();
            //    this.isPrintDetailBill = false;
            //}

            if (this.ucList != null && this.isPrintDetailBill)
            {
                this.ucList.ShowData(this.alCompoundListData,false);
                this.isPrintDetailBill = false;
            }

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
        }
    }
}
