using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Object.Registration;

namespace UFC.Registration
{
    public partial class ucRegBillPrint : Neusoft.NFC.Interface.Controls.ucBaseControl,Neusoft.HISFC.Integrate.Registration.IRegPrint
    {
        public ucRegBillPrint()
        {
            InitializeComponent();
        }


        private Neusoft.NFC.Management.Transaction trans = null;

        //public int SetPrintValue(Neusoft.HISFC.Object.Registration.Register register, Neusoft.HISFC.Management.Registration.Register regmr)
        public int SetPrintValue(Neusoft.HISFC.Object.Registration.Register register)
        {
            Neusoft.HISFC.Management.Registration.Register registerManager = new Neusoft.HISFC.Management.Registration.Register();
            Neusoft.HISFC.Management.Registration.Noon noonManager = new Neusoft.HISFC.Management.Registration.Noon();
            if (this.trans != null)
            {
                registerManager.SetTrans(this.trans.Trans);
            }

            //decimal reg_tot_cost = register.RegLvlFee.ChkFee + register.RegLvlFee.RegFee + register.RegLvlFee.OthFee + register.RegLvlFee.OwnDigFee ;
            //大写金额：备用
            //Function.ConvertNumberToChineseMoneyString(reg_tot_cost.ToString())
            this.lblCardNo.Text = register.PID.CardNO;//就诊卡号
            this.lblDeptName.Text = register.DoctorInfo.Templet.Dept.Name;
            this.lblDoct.Text = register.DoctorInfo.Templet.Doct.Name;
            this.lblPatientName.Text = register.Name;
            this.lblAge.Text = registerManager.GetAge(register.Birthday);
            this.lblRegDate.Text = register.DoctorInfo.SeeDate.ToString();
            this.lblRegLevel.Text = register.DoctorInfo.Templet.RegLevel.Name;
            this.lblSeeNo.Text = register.DoctorInfo.SeeNO.ToString();
            this.lblPhone.Text = register.PhoneHome;
            this.lblRegFee.Text = register.OwnCost.ToString();
            this.lblPaykind.Text = register.Pact.Name;
            this.lblNoon.Text = noonManager.Query(register.DoctorInfo.Templet.Noon.ID);
            this.lblRegOper.Text = register.InputOper.ID;
            this.lblAddress.Text = register.AddressHome;
            this.lblRegFeePub.Text = register.PubCost.ToString();
     
            


            return 0;
        }

        public int Print()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
            print.PrintPage(0, 0, this);
            return 0;
        }
        public int Clear()
        {
            return 0;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans.Trans = trans;
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                return this.trans.Trans;
            }
            set
            {
                this.trans.Trans = value;
            }
        }
        public int PrintView()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
            print.PrintPreview(0, 0, this);
            return 0;
        }
    }
}
