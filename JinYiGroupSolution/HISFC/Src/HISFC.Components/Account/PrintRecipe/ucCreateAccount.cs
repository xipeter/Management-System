using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Account.PrintRecipe
{
    public partial class ucCreateAccount : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,HISFC.BizProcess.Interface.Account.IPrintCreateAccount
    {
        public ucCreateAccount()
        {
            InitializeComponent();
        }

        #region 变量
        Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIteger = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region IPrintCreateAccount 成员

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
        }

        public void SetValue(Neusoft.HISFC.Models.Account.Account account)
        {
            this.lblMarkNO.Text = account.AccountCard.MarkNO;
            this.lblCaseNO.Text = account.AccountCard.Patient.PID.CaseNO;
            if (!account.AccountCard.Patient.IsEncrypt)
            {
                this.lblName.Text = account.AccountCard.Patient.Name;
            }
            else
            {
                this.lblName.Text = account.AccountCard.Patient.DecryptName;
            }
            this.lblSex.Text = account.AccountCard.Patient.Sex.Name;
            Neusoft.FrameWork.Models.NeuObject tempobj = managerIteger.GetConstant("NATION", account.AccountCard.Patient.Nationality.ID);
            if (tempobj != null)
            {
                this.lblNation.Text = tempobj.Name;
            }
            this.lblage.Text = accountManager.GetAge(account.AccountCard.Patient.Birthday);
            this.lblBirthDay.Text = account.AccountCard.Patient.Birthday.ToString("yyyy-MM-dd");
            this.lblIDENType.Text = account.AccountCard.Patient.IDCardType.Name;
            this.lblLinkTel.Text = account.AccountCard.Patient.Kin.RelationPhone;
            this.lblIDENO.Text = account.AccountCard.Patient.IDCard;
            this.lblhj.Text = account.AccountCard.Patient.DIST;
            this.lblAdress.Text = account.AccountCard.Patient.AddressHome;
            this.lblHospitalName.Text = this.managerIteger.GetHospitalName();
        }

        #endregion
    }
}
