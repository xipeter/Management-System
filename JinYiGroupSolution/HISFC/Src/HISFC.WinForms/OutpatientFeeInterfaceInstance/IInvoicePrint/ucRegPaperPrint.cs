using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ReceiptPrint
{
    public partial class ucRegPaperPrint : UserControl, Neusoft.HISFC.Integrate.IRecipePrint
    {
        public ucRegPaperPrint()
        {
            InitializeComponent();
        }



        #region IRecipePrint 成员

        public void PrintRecipe()
        {
            try
            {
                Neusoft.NFC.Interface.Classes.Print print = null;
                try
                {
                    print = new Neusoft.NFC.Interface.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);
                    return;
                }
                string paperName = string.Empty;
                //if (this.InvoiceType == "MZ02")
                //{
                paperName = "MZBLB";

                //}
                //else if (this.InvoiceType == "MZ01")
                //{
                //    paperName = "MZYB";
                //}

                Neusoft.HISFC.Object.Base.PageSize ps = new Neusoft.HISFC.Object.Base.PageSize(paperName, 0, 0);
                ////纸张宽度
                //ps.Width = this.Width;
                ////纸张高度
                //ps.Height = this.Height;
                ps.Printer = "MZBLB";
                //上边距
                ps.Top = 0;
                //左边距
                ps.Left = 0;
                print.SetPageSize(ps);
                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public string RecipeNO
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void SetPatientInfo(Neusoft.HISFC.Object.Registration.Register register)
        {
            this.lblAdress.Text = register.AddressHome;
            this.lblAge.Text = register.Age;
            this.lblGms.Text = register.User03.ToString();
            this.lblName.Text = register.Name;
            this.lblPaytype.Text = register.Pact.Name;
            this.lblSex.Text = register.Sex.Name;
        }

        #endregion
    }
}
