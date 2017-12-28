using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    /// <summary>
    /// 住院发票查询
    /// </summary>
    public partial class ucFinIpbInvoice : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbInvoice()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }


            return base.OnRetrieve(base.beginTime, base.endTime);
        }

        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                //如果有两个以上DataWindow控件时需要打印输入时，根据焦点判断打印哪个DataWindow控件

                if (this.dwMain.Focused)
                {
                    this.dwMain.Print();
                }
                else if (this.dwDetail.Focused) //其它DataWindow控件打印，与此类推
                {
                    this.dwDetail.Print();
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错", "提示");
                return -1;
            }

        }
        /// <summary>
        /// 查询明细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dwMain_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            int currRow = e.RowNumber;
            if (currRow == 0)
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索明细，请稍候...");
            string sInvoiceNo;
            double dbBalanceNo;
            string sInpatientNo;
            sInvoiceNo = dwMain.GetItemString(currRow, "fin_ipb_balancehead_invoice_no");
            dbBalanceNo = dwMain.GetItemDouble(currRow, "fin_ipb_balancehead_balance_no");
            sInpatientNo = dwMain.GetItemString(currRow, "fin_ipb_balancehead_inpatient_no");

            dwDetail.Retrieve(sInvoiceNo, dbBalanceNo, sInpatientNo);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return;
        }

        /// <summary>
        /// 导出方法
        /// </summary>
        /// <returns></returns>
        protected override int OnExport()
        {
            //如果存在多个DataWindow时导出方法需要重写，否则不需要重写该方法，根据焦点判断导出具体哪个DataWindow
            try
            {
                //导出Excel格式文件
                SaveFileDialog saveDial = new SaveFileDialog();
                saveDial.Filter = "Excel文件（*.xls）|*.xls";
                //文件名
                string fileName = string.Empty;
                if (saveDial.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveDial.FileName;
                }
                else
                {
                    return 1;
                }

                //根据焦点判断导出哪个DataWindow
                if (this.dwMain.Focused)
                {
                    this.dwMain.SaveAs(fileName, Sybase.DataWindow.FileSaveAsType.Excel);
                }
                else if (this.dwDetail.Focused) //多个以此类推
                {
                    this.dwDetail.SaveAs(fileName, Sybase.DataWindow.FileSaveAsType.Excel);
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出出错", "提示");
                return -1;
            }
        }

    }
}

