using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Object.Fee;

namespace Neusoft.UFC.InpatientFee.Maintenance
{
    /// <summary>
    /// [功能描述: 调整收费员默认发票号]<br></br>
    /// [创建者:   郝武]<br></br>
    /// [创建时间: 2008-11-24]<br></br>
    /// <说明>
    /// </说明>
    /// <修改记录>
    ///     <修改时间>本次修改时间</修改时间>
    ///     <修改内容>
    ///            本次修改内容
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public partial class ucInvoiceChange : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        Neusoft.HISFC.Management.Fee.InvoiceServiceNoEnum manager = new Neusoft.HISFC.Management.Fee.InvoiceServiceNoEnum();

        /// <summary>
        /// 登陆操作员
        /// </summary>
        Neusoft.HISFC.Object.Base.Employee oper = null;

        /// <summary>
        /// 发票类型
        /// </summary>
        private string invoiceTypeID = "C";

        /// <summary>
        ///  发票类型
        /// </summary>
        public string InvoiceTypeID
        {
            get { return invoiceTypeID; }
            set { invoiceTypeID = value; }
        }

        /// <summary>
        /// 发票类型名称
        /// </summary>
        private string invoiceTypeName = "门诊发票";

        /// <summary>
        /// 发票类型名称
        /// </summary>
        public string InvoiceTypeName
        {
            get { return invoiceTypeName; }
            set
            {
                invoiceTypeName = value;
                this.lbInvoiceTypeName.Text = string.Format("发票类型：{0}", InvoiceTypeName);
            }
        }


        public ucInvoiceChange()
        {
            InitializeComponent();

            OnLoad();
        }

        protected void OnLoad()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.oper = (Neusoft.HISFC.Object.Base.Employee)Neusoft.NFC.Management.Connection.Operator;

                ArrayList invoiceList = manager.QueryInvoices(this.oper.ID, this.InvoiceTypeID);

                InitSheet(invoiceList);
            }

        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="invoiceList"></param>
        private void InitSheet(ArrayList invoiceList)
        {
            if (invoiceList != null && invoiceList.Count > 0)
            {
                this.invoiceSheet.RowCount = 0;
                int i = 0;
                foreach (Invoice invoice in invoiceList)
                {
                    if (invoice.EndNO != invoice.UsedNO && invoice.ValidState != "-1")
                    {
                        this.invoiceSheet.Rows.Add(this.invoiceSheet.RowCount, 1);
                        this.invoiceSheet.Cells[i, 0].Text = invoice.AcceptTime.ToString("yyyy-MM-dd");
                        this.invoiceSheet.Cells[i, 1].Text = invoice.BeginNO.ToString();
                        this.invoiceSheet.Cells[i, 2].Text = invoice.EndNO;
                        this.invoiceSheet.Cells[i, 3].Text = invoice.UsedNO;
                        this.invoiceSheet.Cells[i, 4].Value = invoice.ValidState == "1" ? true : false;
                        this.invoiceSheet.Rows[i].Tag = invoice;
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// 更新发票数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidDefaultState())
            {
                MessageBox.Show("只能有一个默认号段");
                return;
            }

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            for (int i = 0, j = this.invoiceSheet.RowCount; i < j; i++)
            {
                Invoice invoice = (Invoice)this.invoiceSheet.Rows[i].Tag;
                invoice.ValidState = Boolean.Parse(this.invoiceSheet.Cells[i, 4].Value.ToString()) ? "1" : "0";
                if (manager.UpdateInvoiceDefaltState(invoice) == -1)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新出差：" + manager.Err);
                    return;
                }
            }
            Neusoft.NFC.Management.PublicTrans.Commit();
            this.FindForm().Close();
        }

        private void neuFpEnter1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            //if (!ValidDefaultState())
            //{
            //    MessageBox.Show("只能有一个默认号段");
            //}
        }

        private bool ValidDefaultState()
        {
            int count = 0;
            for (int i = 0, j = this.invoiceSheet.RowCount; i < j; i++)
            {
                if (Boolean.Parse(this.invoiceSheet.Cells[i, 4].Value.ToString()) == true)
                {
                    count++;

                    if (count > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
