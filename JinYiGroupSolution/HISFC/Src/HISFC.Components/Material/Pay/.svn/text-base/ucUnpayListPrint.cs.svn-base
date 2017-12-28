using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Material.Pay
{
    /// <summary>
    /// 未付款账单打印
    /// </summary>
    public partial class ucUnpayListPrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucUnpayListPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置打印数据
        /// </summary>
        public void SetPrintValue(string strTime,Neusoft.HISFC.Models.Material.MaterialCompany company,string strDeptName, List<Neusoft.HISFC.Models.Material.Pay> payList)
        {
            #region label赋值

            this.lblTime.Text += strTime;
            this.lblCompany.Text += company.Name; 

            #endregion

            #region 表格赋值

            foreach (Neusoft.HISFC.Models.Material.Pay pay in payList)
            {
                int index = this.neuSpread1_Sheet1.RowCount;
                this.neuSpread1_Sheet1.AddRows(index, 1);

                this.neuSpread1_Sheet1.Cells[index, 0].Text = pay.InvoiceNo;
                this.neuSpread1_Sheet1.Cells[index, 1].Text = pay.InvoiceTime.ToLongDateString();
                this.neuSpread1_Sheet1.Cells[index, 2].Text = pay.PurchaseCost.ToString();
                this.neuSpread1_Sheet1.Cells[index, 3].Text = pay.PayCost.ToString();
                this.neuSpread1_Sheet1.Cells[index, 4].Text = pay.UnpayCost.ToString();
                this.neuSpread1_Sheet1.Cells[index, 5].Text = strDeptName;
            }

            #endregion
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        private void Clear()
        {
            this.lblTime.Text = "时间：";
            this.lblCompany.Text = "供货公司：";
            this.neuSpread1_Sheet1.RowCount = 0;
        }

        public void Print() 
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPage(12, 2, this.neuPanel1);
        }

        private void ucUnpayListPrint_Load(object sender, EventArgs e)
        {
            //判断是否处于设计模式
            if (this.DesignMode == true)
            {
                return;
            }
            this.Clear();
        }

    }
}
