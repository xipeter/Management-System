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
    /// 摆药单打印
    /// </summary>
    public partial class ucDrugBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint
    {
        /// <summary>
        /// 摆药单打印
        /// </summary>
        public ucDrugBill()
        {
            InitializeComponent();
        }

        private ucDrugBillDetail ucDetail = new ucDrugBillDetail();

        private Neusoft.HISFC.Models.Pharmacy.DrugBillClass tempDrugBill = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();

        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        
        #region IDrugPrint 成员

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(System.Collections.ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            this.SetTabPageShow(drugBillClass);

            switch (drugBillClass.PrintType.ID.ToString())
            {
                case "D":           //明细打印
                case "R":           //处方单
                    ArrayList alDetail = new ArrayList();
                    if (drugBillClass.DrugBillNO == null || drugBillClass.DrugBillNO == "")
                    {
                        alDetail = al;
                    }
                    else
                    {
                        alDetail = this.itemManager.QueryDrugBillDetail(drugBillClass.DrugBillNO);
                        if (alDetail == null || alDetail.Count == 0)
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据摆药单号获取摆药单详细信息发生错误") + this.itemManager.Err);
                            return;
                        }

                        System.Collections.Hashtable hsOriginal = new Hashtable();
                        foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut temp in al)
                        {
                            if (hsOriginal.ContainsKey(temp.User01+temp.User02))
                            {
                            }
                            else
                            {
                                hsOriginal.Add(temp.User01 + temp.User02, temp.PatientNO);
                            }
                        }

                        foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut detail in alDetail)
                        {
                            if (hsOriginal.ContainsKey((detail.User02).Substring(4) + detail.User01))
                            {
                                detail.PatientNO = hsOriginal[(detail.User02).Substring(4) + detail.User01] as string;
                            }
                        }
 
                    }
                     
                    this.ucDrugBillDetail1.Clear();
                    this.ucDrugBillDetail1.IfBPrint = "已发";
                    this.ucDrugTotal1.IfBPrint = "已发";
                    this.ucDrugBillDetail1.ShowData(alDetail, drugBillClass);
                    break;
                case "T":           //汇总打印
                    ArrayList alTotal = new ArrayList();
                    if (drugBillClass.DrugBillNO == null || drugBillClass.DrugBillNO == "")
                    {
                        alTotal = al;
                    }
                    else
                    {
                        alTotal = this.itemManager.QueryDrugBillTotal(drugBillClass.DrugBillNO);
                        if (alTotal == null || alTotal.Count == 0)
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据摆药单号获取摆药单汇总信息发生错误"));
                            return;
                        }
                    }

                    this.ucDrugTotal1.Clear();
                    this.ucDrugTotal1.IfBPrint = "已发";
                    this.ucDrugBillDetail1.IfBPrint = "已发";
                    this.ucDrugTotal1.ShowData(alTotal, drugBillClass);

                    ArrayList alDetailTemp = new ArrayList();
                    if (drugBillClass.DrugBillNO == null || drugBillClass.DrugBillNO == "")
                    {
                        alDetailTemp = al;
                    }
                    else
                    {
                        alDetailTemp = this.itemManager.QueryDrugBillDetail(drugBillClass.DrugBillNO);
                        if (alDetailTemp == null || alDetailTemp.Count == 0)
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据摆药单号获取摆药单详细信息发生错误") + this.itemManager.Err);
                            return;
                        }
                    }

                    this.ucDrugBillDetail1.Clear();
                    this.ucDrugBillDetail1.ShowData(alDetailTemp, drugBillClass);
                    break;
                case "H":           //草药单
                    ArrayList alHerbalDetail = new ArrayList();
                    if (drugBillClass.DrugBillNO == null || drugBillClass.DrugBillNO == "")
                    {
                        alHerbalDetail = al;
                    }
                    else
                    {
                        alHerbalDetail = this.itemManager.QueryDrugBillDetail(drugBillClass.DrugBillNO);
                        if (alHerbalDetail == null || alHerbalDetail.Count == 0)
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据摆药单号获取摆药单详细信息发生错误"));
                            return;
                        }
                    }

                    this.ucDrugHerbal1.Clear();
                    this.ucDrugHerbal1.ShowData(alHerbalDetail, drugBillClass);
                    break;
            }

            this.tempDrugBill = drugBillClass;
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(System.Collections.ArrayList al)
        {
            if (this.tempDrugBill == null)
            {
                this.ucDrugBillDetail1.Clear();

                this.ucDrugTotal1.Clear();

                this.ucDrugHerbal1.Clear();

                return;
            }

            this.SetTabPageShow(this.tempDrugBill);

            switch (this.tempDrugBill.PrintType.ID.ToString())
            {
                case "D":           //明细打印
                case "R":           //处方单                                     
                    this.ucDrugBillDetail1.Clear();
                    this.ucDrugBillDetail1.ShowData(al, this.tempDrugBill);
                    break;
                case "T":           //汇总打印
                   
                    this.ucDrugTotal1.Clear();
                    this.ucDrugTotal1.ShowData(al, this.tempDrugBill);

                    this.ucDrugBillDetail1.Clear();
                    this.ucDrugBillDetail1.ShowData(al, this.tempDrugBill);

                    break;
                case "H":           //草药单                  

                    this.ucDrugHerbal1.Clear();
                    this.ucDrugHerbal1.ShowData(al, this.tempDrugBill);
                    break;
            }

            //this.tempDrugBill = drugBillClass;
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddCombo(System.Collections.ArrayList alCombo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut info)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        decimal Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.DrugTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        Neusoft.HISFC.Models.RADT.PatientInfo Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.InpatientInfo
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

        decimal Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.LabelTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        Neusoft.HISFC.Models.Registration.Register Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.OutpatientInfo
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

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.Preview()
        {
            switch (this.tempDrugBill.PrintType.ID.ToString())            
            {
                case "D":           //明细打印
                case "R":           //处方单
                    this.ucDrugBillDetail1.PrintPreview();
                    break;
                case "T":           //汇总打印
                    this.ucDrugTotal1.PrintPreview();

                    this.ucDrugBillDetail1.PrintPreview();
                    break;
                case "H":           //草药单
                    this.ucDrugHerbal1.PrintPreview();
                    break;
            }
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.Print()
        {
            switch (this.tempDrugBill.PrintType.ID.ToString())
            {
                case "D":           //明细打印
                case "R":           //处方单
                    this.ucDrugBillDetail1.PrintPreview();
                    break;
                case "T":           //汇总打印
                    this.ucDrugTotal1.PrintPreview();

                    this.ucDrugBillDetail1.PrintPreview();
                    break;
                case "H":           //草药单
                    this.ucDrugHerbal1.PrintPreview();
                    break;
            }
        }

        #endregion

        private void SetTabPageShow(Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            //if (this.tempDrugBill.PrintType.ID.ToString() == drugBillClass.PrintType.ID.ToString())
            //{
            //    return;
            //}

            switch (drugBillClass.PrintType.ID.ToString())
            {
                case "D":
                case "R":
                    if (!this.neuTabControl1.TabPages.Contains(this.tabPage1))
                        this.neuTabControl1.TabPages.Add(this.tabPage1);
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage2))
                        this.neuTabControl1.TabPages.Remove(this.tabPage2);
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage3))
                        this.neuTabControl1.TabPages.Remove(this.tabPage3);
                    break;
                case "T":
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage1))
                        this.neuTabControl1.TabPages.Remove(this.tabPage1);
                    if (!this.neuTabControl1.TabPages.Contains(this.tabPage2))
                        this.neuTabControl1.TabPages.Add(this.tabPage2);
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage3))
                        this.neuTabControl1.TabPages.Remove(this.tabPage3);
                    break;
                case "H":
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage1))
                        this.neuTabControl1.TabPages.Remove(this.tabPage1);
                    if (this.neuTabControl1.TabPages.Contains(this.tabPage2))
                        this.neuTabControl1.TabPages.Remove(this.tabPage2);
                    if (!this.neuTabControl1.TabPages.Contains(this.tabPage3))
                        this.neuTabControl1.TabPages.Add(this.tabPage3);
                    break;
            }
        }
    }
}
