using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucPrintAccountPrePay : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.HISFC.BizProcess.Interface.Account.IAccountPrint
    {

        public ucPrintAccountPrePay()
        {
            InitializeComponent();
        }
        private Neusoft.HISFC.Models.Account.Account account = null;
        public Neusoft.HISFC.Models.Account.Account Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
            }
        }

        #region IAccountPrint ≥…‘±

        public int Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
            return 0;
        }

        public int PrintSetValue(Neusoft.HISFC.Models.Account.Account account)
        {
            this.lblCardNo.Text = account.AccountRecord[0].Patient.PID.CardNO;
            this.lbldate.Text = account.AccountRecord[0].OperTime.ToString();
            this.lblInvoiceNo.Text = account.AccountRecord[0].ReMark;
            this.lblMoney.Text = account.AccountRecord[0].Money.ToString();
            this.lblMoneyUpper.Text =Neusoft.FrameWork.Function.NConvert.ToCapital(account.AccountRecord[0].Money);
            //if(account.Patient!=null)
            //    this.lblName.Text = account.Patient.DecryptName;
            this.lblOper.Text = account.AccountRecord[0].Oper;
            this.lblInvoiceNo.Text = account.AccountRecord[0].ReMark;
            this.lblCardNo.Text = account.AccountRecord[0].Patient.PID.CardNO;
            this.lblPrePayMoney.Text = account.AccountRecord[0].Money.ToString();
            return 1;
        }

        #endregion
    }
}
