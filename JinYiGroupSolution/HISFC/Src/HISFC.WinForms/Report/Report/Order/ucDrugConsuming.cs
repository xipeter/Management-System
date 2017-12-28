using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucDrugConsuming : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.IPrintExecDrug
    {
        public ucDrugConsuming()
        {
            InitializeComponent();
        }

        #region IPrintExecDrug 成员

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel1);
        }

        public void PrintPreview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(40, 10, this.neuPanel1);
        }

        public void SetExecOrder(System.Collections.ArrayList alExecOrder)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            System.Collections.Hashtable hsPatientName = new System.Collections.Hashtable();
            System.Collections.Hashtable hsPatientOrderItem = new System.Collections.Hashtable();
            foreach (Neusoft.HISFC.Models.Order.ExecOrder info in alExecOrder)
            {
                string patientName = "";
                if (hsPatientName.ContainsKey(info.Order.Patient.ID))
                {
                    patientName = hsPatientName[info.Order.Patient.ID] as string;
                }
                else
                {
                    Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
                    Neusoft.HISFC.Models.RADT.PatientInfo p = radtIntegrate.GetPatientInfoByPatientNO(info.Order.Patient.ID);

                    patientName = p.PVisit.PatientLocation.Bed.ID + p.Name;

                    hsPatientName.Add(p.ID, patientName);
                }

                if (hsPatientOrderItem.ContainsKey(info.Order.Patient.ID + info.Order.Item.ID))
                {
                    Neusoft.HISFC.Models.Order.ExecOrder execOrder = hsPatientOrderItem[info.Order.Patient.ID + info.Order.Item.ID] as Neusoft.HISFC.Models.Order.ExecOrder;

                    execOrder.Order.Qty = execOrder.Order.Qty + info.Order.Qty;
                }
                else
                {
                    Neusoft.HISFC.Models.Order.ExecOrder execOrder = info.Clone();
                    execOrder.Order.Patient.Name = patientName;

                    hsPatientOrderItem.Add(execOrder.Order.Patient.ID + info.Order.Item.ID,execOrder);
                }
            }

            int iRow = 0;
            foreach (Neusoft.HISFC.Models.Order.ExecOrder totalExecOrder in hsPatientOrderItem.Values)
            {
                this.neuSpread1_Sheet1.Rows.Add(iRow, 1);

                this.neuSpread1_Sheet1.Cells[iRow, 0].Text = totalExecOrder.Order.Patient.Name;

                Neusoft.HISFC.Models.Pharmacy.Item item = totalExecOrder.Order.Item as Neusoft.HISFC.Models.Pharmacy.Item;

                this.neuSpread1_Sheet1.Cells[iRow, 1].Text = item.Name + "[" + item.Specs + "]";
                this.neuSpread1_Sheet1.Cells[iRow, 2].Text = totalExecOrder.Order.Qty.ToString();
                this.neuSpread1_Sheet1.Cells[iRow, 3].Text = totalExecOrder.Order.Unit;
                this.neuSpread1_Sheet1.Cells[iRow, 4].Value = item.PriceCollection.RetailPrice / item.PackQty;
                this.neuSpread1_Sheet1.Cells[iRow, 5].Value = totalExecOrder.Order.Qty * item.PriceCollection.RetailPrice / item.PackQty;
            }
        }

        public void SetExecOrder(System.Collections.ArrayList alExecOrder, System.Collections.Hashtable hsPatient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetTitle(Neusoft.HISFC.Models.Base.OperEnvironment oper, Neusoft.FrameWork.Models.NeuObject dept)
        {
            if (oper.OperTime == System.DateTime.MinValue)
            {
                Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
                oper.OperTime = dataManager.GetDateTimeFromSysDateTime();
            }

            this.lbTitl.Text = dept.Name + "领药单";

            this.lbPrintTime.Text = "打印时间：" + oper.OperTime.ToString();
        }

        #endregion
    }
}
