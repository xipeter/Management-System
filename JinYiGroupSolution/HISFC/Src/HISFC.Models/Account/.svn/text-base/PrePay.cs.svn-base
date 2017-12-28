using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Account
{
    [Serializable]
    public class PrePay : NeuObject,IValidState,IValid
    {

        #region 变量

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient = new Neusoft.HISFC.Models.RADT.Patient();
        /// <summary>
        /// 帐号
        /// </summary>
        private string accountNO = string.Empty;

        /// <summary>
        /// 发生序号
        /// </summary>
        private int happenNo = 0;

        /// <summary>
        /// 预交金发票号
        /// </summary>
        private string invoiceNO = string.Empty;
   
        /// <summary>
        /// 支付类型{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
        /// </summary>
        //private Fee.EnumPayTypeService payType = new Neusoft.HISFC.Models.Fee.EnumPayTypeService();
        private Neusoft.FrameWork.Models.NeuObject payType =  new NeuObject ();

        /// <summary>
        /// 费用信息 包含预交金费用等
        /// </summary>
        private FT ft = new FT();

        /// <summary>
        /// 开户银行
        /// </summary>
        private Bank bank = new Bank();
   
        /// <summary>
        /// 预交金操作信息
        /// </summary>
        private OperEnvironment prePayOper = new OperEnvironment();

        /// <summary>
        /// 状态 0反还，1收取，2重打
        /// </summary>
        private EnumValidState validState = EnumValidState.Valid;

        /// <summary>
        /// 结算操作信息
        /// </summary>
        private OperEnvironment balanceOper = new OperEnvironment();

        /// <summary>
        /// 是否日结
        /// </summary>
        private bool valid = false;

        /// <summary>
        /// 原票据号
        /// </summary>
        private string oldInvoice = string.Empty;

        /// <summary>
        /// 重打次数
        /// </summary>
        private int printTimes = 0;

        /// <summary>
        /// 日结序号
        /// </summary>
        private string balanceNo=string.Empty;

        /// <summary>
        /// 是否历史数据
        /// </summary>
        private bool isHostory = false;
        #endregion

        #region 属性

        /// <summary>
        /// 患者基本信息
        /// </summary>
        public HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        /// <summary>
        /// 帐号
        /// </summary>
        public string AccountNO
        {
            get { return accountNO; }
            set { accountNO = value; }
        }

        /// <summary>
        /// 发生序号
        /// </summary>
        public int HappenNO
        {
            get
            {
                return happenNo;
            }
            set
            {
                happenNo = value;
            }
        }

        /// <summary>
        ///  预交金发票号
        /// </summary>
        public string InvoiceNO
        {
            get { return invoiceNO; }
            set { invoiceNO = value; }
        }

        /// <summary>
        /// 支付类型{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
        /// </summary>
        //public Fee.EnumPayTypeService PayType
        public NeuObject PayType
        {
            get { return payType; }
            set { payType = value; }
        }

        /// <summary>
        /// 费用信息 包含预交金费用等
        /// </summary>
        public FT FT
        {
            get { return ft; }
            set { ft = value; }

        }

        /// <summary>
        /// 开户银行
        /// </summary>
        public Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        /// <summary>
        /// 预交金操作信息
        /// </summary>
        public OperEnvironment PrePayOper
        {
            get { return prePayOper; }
            set { prePayOper = value; }
        }

        /// <summary>
        /// 结算操作信息
        /// </summary>
        public OperEnvironment BalanceOper
        {
            get { return balanceOper; }
            set { balanceOper = value; }
        }

        /// <summary>
        /// 日结序号
        /// </summary>
        public string BalanceNO
        {
            get
            {
                return balanceNo;
            }
            set
            {
                balanceNo = value;
            }
        }

        /// <summary>
        /// 原票据号
        /// </summary>
        public string OldInvoice
        {
            get
            {
                return oldInvoice;
            }
            set
            {
                oldInvoice = value;
            }
        }

        /// <summary>
        /// 重打次数
        /// </summary>
        public int PrintTimes
        {
            get
            {
                return printTimes;
            }
            set
            {
                printTimes = value;
            }
        }

        /// <summary>
        /// 是否历史数据(在结清帐户时以前的的预交金为历史数据)
        /// </summary>
        public bool IsHostory
        {
            get 
            { 
                return isHostory; 
            }
            set 
            { 
                isHostory = value; 
            }
        }
        #endregion

        #region IValidState 成员
        /// <summary>
        /// 预交金状态 0反还，1收取，2重打
        /// </summary>
        public EnumValidState ValidState
        {
            get
            {
                return validState;
            }
            set
            {
                validState = value;
            }
        }

        #endregion

        #region IValid 成员
        /// <summary>
        /// 是否日结
        /// </summary>
        public bool IsValid
        {
            get
            {
                return valid;
            }
            set
            {
                valid = value;

            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new PrePay Clone()
        {
            PrePay prepay = base.Clone() as PrePay;
            prepay.patient = this.Patient.Clone();
            prepay.FT = this.FT.Clone();
            prepay.prePayOper = this.PrePayOper.Clone();
            prepay.balanceOper = this.BalanceOper.Clone();
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //prepay.payType = this.PayType.Clone() as Fee.EnumPayTypeService;
            prepay.payType = this.PayType.Clone();
            prepay.bank = this.Bank.Clone();

            return prepay;
        }
        #endregion
    }
}
