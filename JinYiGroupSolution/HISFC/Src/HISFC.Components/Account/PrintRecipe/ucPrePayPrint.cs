using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Account.PrintRecipe
{
    public partial class ucPrePayPrint : UserControl,Neusoft.HISFC.BizProcess.Interface.Account.IPrintPrePayRecipe
    {
        public ucPrePayPrint()
        {
            InitializeComponent();
        }

        #region 域
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region IPrintPrePayRecipe 成员
        /// <summary>
        /// 打印发票
        /// </summary>
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
        }
        /// <summary>
        /// 为UC赋值
        /// </summary>
        /// <param name="prepay"></param>
        public void SetValue(Neusoft.HISFC.Models.Account.PrePay prepay)
        {
            if (!prepay.Patient.IsEncrypt)
            {
                this.lblName.Text = prepay.Patient.Name;
            }
            else
            {
                this.lblName.Text = prepay.Patient.DecryptName;
            }
            this.lblDate.Text = prepay.PrePayOper.OperTime.ToString("yyyy-MM-dd");
            this.lblAccountNO.Text = prepay.AccountNO;
            this.lblMoney.Text = prepay.FT.PrepayCost.ToString() + "元";
            this.lblCaption.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(prepay.FT.PrepayCost);
            this.lblPayType.Text = prepay.PayType.Name;
            this.lblInvoice.Text = prepay.Bank.InvoiceNO;
            this.lblRecipeNO.Text = prepay.InvoiceNO;
            this.lblOper.Text = prepay.PrePayOper.Name;
            this.lblHospalName.Text = this.managerIntegrate.GetHospitalName();
        }

        #endregion
    }
}
