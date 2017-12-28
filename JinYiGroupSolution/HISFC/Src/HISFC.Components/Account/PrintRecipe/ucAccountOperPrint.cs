using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Interface.Account;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Account.PrintRecipe
{
    public partial class ucAccountOperPrint : UserControl,IPrintOperRecipe
    {
        public ucAccountOperPrint()
        {
            InitializeComponent();
        }



        #region IPrintOperRecipe 成员

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, this);
        }

        public void SetValue(Neusoft.HISFC.Models.Account.AccountRecord accountRecord)
        {
            //停用帐户
            if (NConvert.ToInt32(accountRecord.OperType.ID) == (int)HISFC.Models.Account.OperTypes.StopAccount)
            {
                this.ckStop.Checked = true;
            }
            //注销帐户
            if (NConvert.ToInt32(accountRecord.OperType.ID) == (int)HISFC.Models.Account.OperTypes.CancelAccount)
            {
                this.ckCancel.Checked = true;
            }
            //修改密码
            if (NConvert.ToInt32(accountRecord.OperType.ID) == (int)HISFC.Models.Account.OperTypes.EditPassWord)
            {
                this.ckCancelPwd.Checked = true;
            }
            //启用
            if (NConvert.ToInt32(accountRecord.OperType.ID) == (int)HISFC.Models.Account.OperTypes.AginAccount)
            {
                this.ckAgain.Checked = true;
            }
            if (accountRecord.Patient.IsEncrypt)
            {
                this.lblName.Text = accountRecord.Patient.DecryptName;
            }
            else
            {
                this.lblName.Text = accountRecord.Patient.Name;
            }
            this.lblTel.Text = accountRecord.Patient.PhoneHome;
            this.lblAdress.Text = accountRecord.Patient.AddressHome;
            this.lbldate.Text = accountRecord.OperTime.ToString();
            this.lblIDENO.Text = accountRecord.Patient.IDCard;
            this.label1.Text = (new Neusoft.HISFC.BizProcess.Integrate.Manager()).GetHospitalName();
        }

        #endregion
    }
}
