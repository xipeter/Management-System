using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Fee
{
    [System.Serializable]
    public class InvoiceJumpRecord : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量
        /// <summary>
        /// 发票类
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Invoice invoice = new Invoice();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 发生序号
        /// </summary>
        private int happenNO;

        /// <summary>
        /// 调号时发票已用号
        /// </summary>
        private string oldUsedNO = string.Empty;

        /// <summary>
        /// 调号后发票已用号
        /// </summary>
        private string newUsedNO = string.Empty;

        #endregion

        #region 属性
        /// <summary>
        /// 发票类
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Invoice Invoice
        {
            set
            {
                this.invoice = value;
            }
            get
            {
                return this.invoice;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            set
            {
                this.oper = value;
            }
            get
            {
                return this.oper;
            }
        }

        /// <summary>
        /// 发生序号
        /// </summary>
        public int HappenNO
        {
            set
            {
                this.happenNO = value;
            }
            get
            {
                return this.happenNO;
            }
        }

        /// <summary>
        /// 调号时发票已用号
        /// </summary>
        public string OldUsedNO
        {
            set
            {
                this.oldUsedNO = value;
            }
            get
            {
                return this.oldUsedNO;
            }
        }

        /// <summary>
        /// 调号后发票已用号
        /// </summary>
        public string NewUsedNO
        {
            set
            {
                this.newUsedNO = value;
            }
            get
            {
                return this.newUsedNO;
            }
        }

        #endregion

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new InvoiceJumpRecord Clone()
        {
            InvoiceJumpRecord invoiceJumpRecord = base.Clone() as InvoiceJumpRecord;
            invoiceJumpRecord.Oper = this.Oper.Clone();
            invoiceJumpRecord.Invoice = this.Invoice.Clone();
            return invoiceJumpRecord;
        }

    }
}
