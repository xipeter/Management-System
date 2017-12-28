using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.WinForms.Report.OutpatientFee.Query
{
    public partial class ucQueryFeeDetail : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryFeeDetail()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Outpatient outPatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 患者挂号信息
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();

        /// <summary>
        /// 人员管理业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Person perManager = new Neusoft.HISFC.BizLogic.Manager.Person();

        /// <summary>
        /// 科室管理业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();

        /// <summary>
        /// 打印
        /// </summary>
        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

        Neusoft.HISFC.BizLogic.Pharmacy.Item phaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        #endregion

        private void txtInvoiceNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Clear();
            string invoiceNO = this.txtInvoiceNO.Text.Trim();
            if(string.IsNullOrEmpty(invoiceNO))
            {
                MessageBox.Show("请输入发票号！");
                this.txtInvoiceNO.Focus();
                return;
            }
            invoiceNO = invoiceNO.PadLeft(12, '0');
            if (!this.SetInfo(invoiceNO))
            {
                Clear();
                return;
            }
        }

        private bool SetInfo(string invoiceNO)
        {
             ArrayList alBalance = outPatientManager.QueryBalancesByInvoiceNO(invoiceNO);
             if (alBalance == null)
             {
                 MessageBox.Show("查询发票信息失败！");
                 return false;
             }
             if (alBalance.Count > 0)
             {
                 foreach (Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice in alBalance)
                 {
                     if (invoice.TransType == TransTypes.Positive && invoice.CancelType == CancelTypes.Valid)
                     {
                         ArrayList alPatient = registerManager.QueryPatient(invoice.Patient.ID);
                         Neusoft.HISFC.Models.Registration.Register r = alPatient[0] as Neusoft.HISFC.Models.Registration.Register;
                         this.lblName.Text =  r.Name;
                         this.lblSex.Text =  r.Sex.Name;
                         this.lblAge.Text =  this.outPatientManager.GetAge(r.Birthday);
                         this.lblDate.Text =  invoice.BalanceOper.OperTime.ToString();
                         this.lblCardNO.Text = r.PID.CardNO;
                         this.txtCost.Text = invoice.FT.TotCost.ToString();
                         this.txtOwnCost.Text = invoice.FT.OwnCost.ToString();
                         this.txtPubCost.Text = invoice.FT.PubCost.ToString();
                         this.txtPayCost.Text = invoice.FT.PayCost.ToString();
                         FrameWork.Models.NeuObject obj = perManager.GetPersonByID(invoice.BalanceOper.ID);
                         if (obj != null)
                         {
                             this.lblFeeOper.Text = obj.Name;
                         }

                         this.lblInvoiceNO.Text = invoice.Invoice.ID;
                         if (!SetFeeInfo(invoiceNO))
                         {
                             return false;
                         }
                         return true;
                     }
                 }
             }
             return false;

        }

        private bool SetFeeInfo(string invoiceNO)
        {
            ArrayList alFee = outPatientManager.QueryFeeItemListsByInvoiceNO(invoiceNO);
            if (alFee == null)
            {
                MessageBox.Show("查询费用明细失败！" + outPatientManager.Err);
                return false;
            }
            if (alFee.Count == 0)
            {
                MessageBox.Show("该发票号不存在，请重新输入！");
                this.txtInvoiceNO.Focus();
                this.txtInvoiceNO.SelectAll();
                return false;
            }
            int count = 0;
            decimal cost = 0;
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tempf = null;
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFee)
            {
                string priceUnit = string.Empty;
                decimal price = 0m, qty = 0m;
                if (f.PayType == PayTypes.Balanced && f.CancelType == CancelTypes.Valid)
                {
                    price = f.Item.Price;
                    priceUnit = f.Item.PriceUnit;
                    qty = f.Item.Qty;
                    if (f.Item.ItemType == EnumItemType.Drug)
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item item = phaManager.GetItem(f.Item.ID);
                        if (item == null)
                        {
                            MessageBox.Show("查询药品信息失败！" + phaManager.Err);
                            return false;
                        }
                        if (item.SplitType == "0")
                        {
                            if (f.Item.PriceUnit != item.PackUnit)
                            {
                                price = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price / f.Item.PackQty, 2);
                            }
                            else
                            {
                                qty = qty / item.PackQty;
                                priceUnit = item.PackUnit;
                            }
                        }
                        else
                        {
                            qty = Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty,2);
                            priceUnit = item.PackUnit;
                        }
                    }

                    count = this.neuSpread1_Sheet1.Rows.Count;
                    this.neuSpread1_Sheet1.Rows.Add(count, 1);
                    this.neuSpread1_Sheet1.Cells[count, 0].Text = f.Item.ID;
                    this.neuSpread1_Sheet1.Cells[count, 1].Text = f.Item.Name;
                    this.neuSpread1_Sheet1.Cells[count, 2].Text = f.Item.Specs;
                    this.neuSpread1_Sheet1.Cells[count, 3].Text = Neusoft.FrameWork.Public.String.FormatNumber(price,2).ToString();
                    this.neuSpread1_Sheet1.Cells[count, 4].Text = priceUnit;
                    this.neuSpread1_Sheet1.Cells[count, 5].Text = Neusoft.FrameWork.Public.String.FormatNumber(qty,2).ToString();
                    this.neuSpread1_Sheet1.Cells[count, 6].Text = (f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost).ToString();
                    cost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                    if (tempf == null)
                    {
                        tempf = f;
                    }
                }
            }
            count = this.neuSpread1_Sheet1.Rows.Count;
            this.neuSpread1_Sheet1.Rows.Add(count, 1);
            this.neuSpread1_Sheet1.Cells[count, 0].Text = "合计";
            this.neuSpread1_Sheet1.Cells[count, 6].Text = cost.ToString();

            FrameWork.Models.NeuObject obj = perManager.GetPersonByID(tempf.RecipeOper.ID);
            if (obj != null)
            {
                lblDoct.Text = obj.Name;
            }

            obj = deptManager.GetDeptmentById(tempf.RecipeOper.Dept.ID);
            if (obj != null)
            {
                lblDept.Text = obj.Name;
            }

            return true;
        }

        private void Clear()
        {
            this.lblName.Text = string.Empty;
            this.lblSex.Text = string.Empty;
            this.lblAge.Text = string.Empty;
            this.lblDate.Text = string.Empty;
            this.lblCardNO.Text = string.Empty;
            this.txtCost.Text = string.Empty;
            this.txtOwnCost.Text = string.Empty;
            this.txtPubCost.Text = string.Empty;
            this.txtPayCost.Text = string.Empty;
            this.lblInvoiceNO.Text = string.Empty;
            this.lblFeeOper.Text = string.Empty;
            lblDoct.Text = string.Empty;
            lblDept.Text = string.Empty;
            int count = this.neuSpread1_Sheet1.Rows.Count;
            if (count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, count);
            }
        }

        private void ucQueryFeeDetail_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtInvoiceNO;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            print.PrintPage(0, 0, this.plPrint);
            return base.OnPrint(sender, neuObject);
        }
    }
}
