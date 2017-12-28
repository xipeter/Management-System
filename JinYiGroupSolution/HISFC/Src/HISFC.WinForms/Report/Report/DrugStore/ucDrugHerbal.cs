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
    /// 住院草药单打印
    /// 
    /// <功能说明>
    ///     1、增加了组合号的显示
    /// </功能说明>
    /// </summary>
    public partial class ucDrugHerbal : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDrugHerbal()
        {
            InitializeComponent();
        }

        private static System.Collections.Hashtable hsDept = new Hashtable();

        /// <summary>
        /// Fp设置
        /// </summary>
        private void InitFp()
        {
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

            this.neuSpread1_Sheet1.ColumnHeader.Rows[0].Height = 30;
            this.neuSpread1_Sheet1.Rows.Default.Height = 30;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        public void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="alData"></param>
        /// <param name="drugBillClass"></param>
        public void ShowData(ArrayList alData, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            if (ucDrugHerbal.hsDept.Count == 0)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDept = deptManager.GetDeptmentAll();
                foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
                {
                    ucDrugHerbal.hsDept.Add(dept.ID, dept.Name);
                }
            }
            this.SuspendLayout();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            this.lbPrintTime.Text = "打印时间:" + dataManager.GetDateTimeFromSysDateTime().ToString();

            this.lbPrintTime.Text = "打印时间:" + drugBillClass.Oper.OperTime.ToString();

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();

            int iRow = 0;
            string comboNO = "-1";
            decimal subTot = 0;
            decimal tot = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alData)
            {
                if (ucDrugHerbal.hsDept.ContainsKey(info.ApplyDept.ID))
                    this.lbTitle.Text = "                       " + ucDrugHerbal.hsDept[info.ApplyDept.ID] + drugBillClass.Name;
                else
                    this.lbTitle.Text = "                       " + info.ApplyDept.Name + drugBillClass.Name;

                this.neuSpread1_Sheet1.Rows.Add(iRow, 1);

                if (comboNO == info.CombNO)         //相同组合号
                {
                    this.neuSpread1_Sheet1.Cells[iRow, 0].Text = "[" + info.User02 + "]" + info.User01;
                    this.neuSpread1_Sheet1.Cells[iRow, 1].Text = info.Item.Name + "[" + info.Item.Specs + "]";
                    this.neuSpread1_Sheet1.Cells[iRow, 2].Text = info.Operation.ApplyQty.ToString();
                    this.neuSpread1_Sheet1.Cells[iRow, 3].Text = (info.Operation.ApplyQty * info.Days).ToString();
                    this.neuSpread1_Sheet1.Cells[iRow, 4].Text = info.Item.MinUnit;
                    this.neuSpread1_Sheet1.Cells[iRow, 5].Text = info.Frequency.ID;
                    this.neuSpread1_Sheet1.Cells[iRow, 6].Text = info.PlaceNO;
                    this.neuSpread1_Sheet1.Cells[iRow, 7].Text = info.Item.PriceCollection.RetailPrice.ToString();

                    subTot = subTot + (info.Operation.ApplyQty * info.Days / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                    this.neuSpread1_Sheet1.Cells[iRow, 8].Value = (info.Operation.ApplyQty * info.Days / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                    this.neuSpread1_Sheet1.Cells[iRow, 9].Text = info.Memo;
                }
                else                              //不同组合号
                {
                    if (comboNO != "-1")
                    {
                        this.neuSpread1_Sheet1.Cells[iRow, 1].Text = "小计";
                        this.neuSpread1_Sheet1.Cells[iRow, 8].Text = subTot.ToString();
                        this.neuSpread1_Sheet1.Rows[iRow].Font = new Font("宋体", 9.5F, FontStyle.Bold);
                        iRow++;
                        this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
                    }

                    this.neuSpread1_Sheet1.Cells[iRow, 1].Text = "剂数";
                    this.neuSpread1_Sheet1.Cells[iRow, 1].Text = info.Days.ToString();
                    this.neuSpread1_Sheet1.Cells[iRow, 1].ColumnSpan = 7;
                    this.neuSpread1_Sheet1.Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    this.neuSpread1_Sheet1.Rows[iRow].Font = new Font("宋体",9.5F,FontStyle.Bold);
                    iRow++;
                    this.neuSpread1_Sheet1.Rows.Add(iRow, 1);

                    tot = tot + subTot;
                    subTot = 0;
                    comboNO = info.CombNO;

                    this.neuSpread1_Sheet1.Cells[iRow, 0].Text = "[" + info.User02 + "]" + info.User01;
                    this.neuSpread1_Sheet1.Cells[iRow, 1].Text = info.Item.Name + "[" + info.Item.Specs + "]";
                    this.neuSpread1_Sheet1.Cells[iRow, 2].Text = info.Operation.ApplyQty.ToString();
                    this.neuSpread1_Sheet1.Cells[iRow, 3].Text = (info.Operation.ApplyQty * info.Days).ToString();
                    this.neuSpread1_Sheet1.Cells[iRow, 4].Text = info.Item.MinUnit;
                    this.neuSpread1_Sheet1.Cells[iRow, 5].Text = info.Frequency.ID;
                    this.neuSpread1_Sheet1.Cells[iRow, 6].Text = info.PlaceNO;
                    this.neuSpread1_Sheet1.Cells[iRow, 7].Text = info.Item.PriceCollection.RetailPrice.ToString();

                    subTot = subTot + (info.Operation.ApplyQty * info.Days / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                    this.neuSpread1_Sheet1.Cells[iRow, 8].Value = (info.Operation.ApplyQty * info.Days / info.Item.PackQty * info.Item.PriceCollection.RetailPrice);
                    this.neuSpread1_Sheet1.Cells[iRow, 9].Text = info.Memo;                    
                }
               
                iRow++;
            }

            this.neuSpread1_Sheet1.Rows.Add(iRow, 1);
            this.neuSpread1_Sheet1.Cells[iRow, 1].Text = "小计";
            this.neuSpread1_Sheet1.Cells[iRow, 8].Text = subTot.ToString();
            this.neuSpread1_Sheet1.Rows[iRow].Font = new Font("宋体", 9.5F, FontStyle.Bold);
            iRow++;
            this.neuSpread1_Sheet1.Rows.Add(iRow, 1);

            tot = tot + subTot;
            this.neuSpread1_Sheet1.Cells[iRow, 1].Text = "合计";
            this.neuSpread1_Sheet1.Cells[iRow, 8].Text = tot.ToString();
            this.neuSpread1_Sheet1.Rows[iRow].Font = new Font("宋体", 9.5F, FontStyle.Bold);

            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();

            this.ResumeLayout(true);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.SetPageSize(new System.Drawing.Printing.PaperSize("Letter", 780, 640));
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPage(20, 10, this);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPreview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPreview(30, 10, this);
        }
    }
}
