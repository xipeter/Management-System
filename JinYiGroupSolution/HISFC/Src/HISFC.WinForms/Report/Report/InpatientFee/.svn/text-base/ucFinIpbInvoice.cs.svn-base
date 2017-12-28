using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.InpatientFee
{
    public partial class ucFinIpbInvoice : Report.Common.ucQueryBaseForDataWindow
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


        private void dwMain_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            int currRow = e.RowNumber;
            if (currRow == 0)
            {
                return;
            }

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("ÕýÔÚ¼ìË÷Ã÷Ï¸£¬ÇëÉÔºò...");
            string sInvoiceNo;
            double dbBalanceNo;
            string sInpatientNo;
            sInvoiceNo = dwMain.GetItemString(currRow, "fin_ipb_balancehead_invoice_no");
            dbBalanceNo = dwMain.GetItemDouble(currRow, "fin_ipb_balancehead_balance_no");
            sInpatientNo = dwMain.GetItemString(currRow, "fin_ipb_balancehead_inpatient_no");

            dwDetail.Retrieve(sInvoiceNo, dbBalanceNo, sInpatientNo);

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();

            return;
        }

    }
}

