using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 初始化发票号
    /// </summary>
    public partial class ucChangeInvoiceNO : UserControl
    {
        public ucChangeInvoiceNO()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 发票实体
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Invoice invoice = new Neusoft.HISFC.Models.Fee.Invoice ();

        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        public event EventHandler my;

        #endregion

        #region 属性

        /// <summary>
        /// 传入发票实体
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Invoice Invoice
        {
            set
            {
                this.invoice = value;
                this.SetValue(this.invoice);
            }
            get
            {
                return this.invoice;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 赋值
        /// </summary>
        private void SetValue(Neusoft.HISFC.Models.Fee.Invoice invoiceJumpRecord)
        {
            this.lblBeginNO.Text = invoiceJumpRecord.BeginNO;
            this.lblEndNO.Text = invoiceJumpRecord.EndNO;
            this.lblInvoiceTypeID.Text = invoiceJumpRecord.Type.ID;
            this.lblInvoiceTypeName.Text = invoiceJumpRecord.Type.Name;
            this.lblUseNO.Text = invoiceJumpRecord.UsedNO;
            this.lblAcceptPerson.Text = invoiceJumpRecord.AcceptOper.ID;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            string nextInoviceNo = this.feeIntegrate.GetNewInvoiceNO(invoiceJumpRecord.Type.ID);
            if (nextInoviceNo == string.Empty)
            {
                this.lblNextNO.Text = "本号段已经使用完";
            }
            else
            {
                this.lblNextNO.Text = nextInoviceNo;
            }
            Neusoft.FrameWork.Management.PublicTrans.RollBack();

            this.txtInput.Focus();

        }

        /// <summary>
        /// 校验输入号
        /// </summary>
        /// <param name="inputNO"></param>
        /// <returns></returns>
        private int ValidInputNO(string inputNO)
        {
            Int64 intInutno;
            try
            {
                intInutno = Int64.Parse(inputNO);
            }
            catch (Exception)
            {

                MessageBox.Show("输入发票号应该为数字，请重新输入");
                this.txtInput.Focus();
                return -1;
            }

            Int64 intBegin = Int64.Parse(this.invoice.BeginNO);
            Int64 intEnd = Int64.Parse(this.invoice.EndNO);
            Int64 intUsedNO = Int64.Parse(this.invoice.UsedNO);
            Int64 intNextNO;
            try
            {
                intNextNO = Int64.Parse(this.lblNextNO.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("该号段已经使用完，不能调号");
                return -1;
            }

            //该号段已经使用完，不能调号
            if (intEnd == intUsedNO)
            {
                MessageBox.Show("该号段已经使用完，不能调号");
                return -1;
            }

            //Int64 intInputTemp = intInutno -1;

            //校验号在区间内

            if (!(intInutno >= intBegin && intInutno <= intEnd))
            {
                MessageBox.Show("输号应该在号段之间，请重新输入");
                return -1;
            }

            if (intInutno <= intUsedNO)
            {
                MessageBox.Show("输入号已经使用不能调号");
                return -1;
            }

            if (intInutno == intNextNO)
            {
                MessageBox.Show("输入号与下一号相同，无需调号");
                return -1;
            }

            return 1;
        }

        protected virtual int Save()
        {
          
            string inputNO = this.txtInput.Text;

            if (string.IsNullOrEmpty(inputNO))
            {
                MessageBox.Show("请输入发票号");
                return -1;
            }

            inputNO = inputNO.PadLeft(12,'0');

            int returnValue =  this.ValidInputNO(inputNO);
            if (returnValue == -1)
            {
                this.txtInput.Focus();
                return -1;
            }

            Neusoft.HISFC.Models.Fee.InvoiceJumpRecord invoiceJumpRecord = this.GetInvoiceChangeRecord();


            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            returnValue = this.feeIntegrate.InsertInvoiceJumpRecord(invoiceJumpRecord);
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.Trans.Rollback();
                MessageBox.Show("设置出错" + this.feeIntegrate.Err);
                return -1;
            }
            //Neusoft.FrameWork.Management.PublicTrans.Trans.Commit();
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("调号成功");
            this.SetValue(invoiceJumpRecord.Invoice);

            return 1;
        }

        /// <summary>
        /// 获取保存记录
        /// </summary>
        /// <returns></returns>
        protected virtual Neusoft.HISFC.Models.Fee.InvoiceJumpRecord GetInvoiceChangeRecord()
        {
            Neusoft.HISFC.Models.Fee.InvoiceJumpRecord invoiceJumpRecord = new Neusoft.HISFC.Models.Fee.InvoiceJumpRecord();

            invoiceJumpRecord.Invoice = this.Invoice;
            invoiceJumpRecord.OldUsedNO = this.Invoice.UsedNO;
            invoiceJumpRecord.Invoice.UsedNO = (Int64.Parse(this.txtInput.Text) - 1).ToString().PadLeft(12, '0');
            invoiceJumpRecord.NewUsedNO = (Int64.Parse(this.txtInput.Text) - 1).ToString().PadLeft(12, '0');
            invoiceJumpRecord.Oper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
           

            return invoiceJumpRecord;
        }

        #endregion


        protected override void OnLoad(EventArgs e)
        {
            this.FindForm().Text = "发票调号";
            this.txtInput.Focus();
            base.OnLoad(e);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
           
           int returnValue =  this.Save();

           if (returnValue == -1)
           {
               return;
           }
           else
           {
               this.FindForm().DialogResult = DialogResult.OK;
               this.FindForm().Close();
           }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void neuTabControl1_Enter(object sender, EventArgs e)
        {
            this.txtInput.Focus();
        }

    }
}
