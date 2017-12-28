using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Account.PrintRecipe
{
    public partial class ucCancelVacancyPrint : UserControl, HISFC.BizProcess.Interface.Account.IPrintCancelVacancy
    {
        public ucCancelVacancyPrint()
        {
            InitializeComponent();
        }



        #region IPrintCancelVacancy 成员
        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
        }

        public void SetValue(Neusoft.HISFC.Models.Account.AccountRecord accountRecord)
        {
            if (accountRecord.Patient.IsEncrypt)
            {
                this.lblName.Text = accountRecord.Patient.DecryptName;
            }
            else
            {
                this.lblName.Text = accountRecord.Patient.Name;
            }
            this.lbldate.Text = accountRecord.OperTime.ToString("yyyy-MM-dd");
            this.lblAccountNO.Text = accountRecord.AccountNO;
            this.lblMoney.Text = accountRecord.Money.ToString() + "元";
            this.lblCaption.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(accountRecord.Money) + "元";
            this.lblSate.Text = accountRecord.OperType.Name;
            this.lblOper.Text = accountRecord.Oper;
            this.lblHospitalName.Text = (new Neusoft.HISFC.BizProcess.Integrate.Manager()).GetHospitalName();
        }

        #endregion
    }
}
