using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucDrugCompound : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.IPrintExecDrug    
    {
        public ucDrugCompound()
        {
            InitializeComponent();
        }

        #region IPrintExecDrug 成员

        public void SetTitle(Neusoft.HISFC.Models.Base.OperEnvironment oper,Neusoft.FrameWork.Models.NeuObject dept)
        {
            this.lbTitle.Text = dept.Name + " 配液单";

            this.lbOper.Text = "配液人：" + oper.Name;

            if (oper.OperTime == System.DateTime.MinValue)
            {
                Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
                oper.OperTime = dataManager.GetDateTimeFromSysDateTime();
            }

            this.lbOperTime.Text = "配液时间：" + oper.OperTime.ToString();

            this.lbDept.Text = "配液科室：" + oper.Dept.Name;
        }

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
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetExecOrder(System.Collections.ArrayList alExecOrder, System.Collections.Hashtable hsPatient)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            int iRowIndex = 0;
            foreach (Neusoft.HISFC.Models.Order.ExecOrder info in alExecOrder)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = null;
                if (hsPatient.ContainsKey(info.Order.Patient.ID))
                {
                    p = hsPatient[info.Order.Patient.ID] as Neusoft.HISFC.Models.RADT.PatientInfo;
                }
                else
                {
                    p = info.Order.Patient;
                }

                this.neuSpread1_Sheet1.Rows.Add(iRowIndex, 1);

                this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text = "[" + p.PVisit.PatientLocation.Bed.ID + "]" + p.Name;

                Neusoft.HISFC.Models.Pharmacy.Item item = (Neusoft.HISFC.Models.Pharmacy.Item)info.Order.Item;
                //商品名称[规格]
                this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text = item.Name + "[" + item.Specs + "]";
                //组标记
                //每次量
                this.neuSpread1_Sheet1.Cells[iRowIndex, 3].Text = info.Order.DoseOnce.ToString() + info.Order.DoseUnit;
                //频次
                this.neuSpread1_Sheet1.Cells[iRowIndex, 4].Text = info.Order.Frequency.ID;
                //用法
                this.neuSpread1_Sheet1.Cells[iRowIndex, 5].Text = info.Order.Usage.ID;
                //数量
                this.neuSpread1_Sheet1.Cells[iRowIndex, 6].Text = info.Order.Qty.ToString() + info.Order.Unit;
                //备注
                this.neuSpread1_Sheet1.Cells[iRowIndex, 7].Text = info.Memo;
                //组合号
                this.neuSpread1_Sheet1.Cells[iRowIndex, 8].Text = info.Order.Combo.ID + info.DateUse.ToString();

                iRowIndex++;
            }

            HISFC.Components.Order.Classes.Function.DrawCombo(this.neuSpread1_Sheet1, 8, 2);
        }

        #endregion
    }
}
