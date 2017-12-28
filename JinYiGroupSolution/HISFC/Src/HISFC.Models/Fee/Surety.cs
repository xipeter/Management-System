using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Fee
{
    [System.Serializable]
    public class Surety : Neusoft.FrameWork.Models.NeuObject
    {
        #region  变量
        /// <summary>
        /// 担保人
        /// </summary>
        private NeuObject suretyPerson = new NeuObject();
        /// <summary>
        /// 审批人
        /// </summary>
        private NeuObject applyPerson = new NeuObject();
        /// <summary>
        /// 担保金额
        /// </summary>
        private decimal suretyCost = 0m;
        /// <summary>
        /// 备注
        /// </summary>
        private string mark;
        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        /// 担保类型
        /// </summary>
        private SuretyTypeEnumService suretyType = new SuretyTypeEnumService();

        /// <summary>
        /// 发生序号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private int happenNO = 0;

        /// <summary>
        /// 开户行 {0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private Base.Bank bank = new Neusoft.HISFC.Models.Base.Bank();

        /// <summary>
        /// 状态{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private string state = string.Empty;


       
        /// <summary>
        /// 支付方式{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private NeuObject payType = new NeuObject();

        /// <summary>
        /// 发票号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private string invoiceNO = string.Empty;

        /// <summary>
        /// 旧发票号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        private string oldInvoiceNO = string.Empty;

        

       

        #endregion

        #region 属性
        /// <summary>
        /// 担保人
        /// </summary>
        public NeuObject SuretyPerson
        {
            get
            {
                return suretyPerson;
            }
            set
            {
                suretyPerson = value;
            }

        }
        /// <summary>
        /// 审批人
        /// </summary>
        public NeuObject ApplyPerson
        {
            get
            {
                return applyPerson;
            }
            set
            {
                applyPerson = value;
            }
        }
        /// <summary>
        /// 担保金额
        /// </summary>
        public decimal SuretyCost
        {
            get
            {
                return suretyCost;
            }
            set
            {
                suretyCost = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }
        /// <summary>
        /// 担保类型
        /// </summary>
        public SuretyTypeEnumService SuretyType
        {
            get
            {
                return suretyType;
            }
            set
            {
                suretyType = value;
            }
        }

        /// <summary>
        /// 发生序号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public int HappenNO
        {
            get { return happenNO; }
            set { happenNO = value; }
        }
        /// <summary>
        /// 开户行{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public Base.Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }
        /// <summary>
        /// 状态{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        // <summary>
        /// 支付方式{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public NeuObject PayType
        {
            get { return payType; }
            set { payType = value; }
        }

        /// <summary>
        /// 发票号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public string InvoiceNO
        {
            get { return invoiceNO; }
            set { invoiceNO = value; }
        }
        /// <summary>
        /// 旧发票号{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        public string OldInvoiceNO
        {
            get { return oldInvoiceNO; }
            set { oldInvoiceNO = value; }
        }
        
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Surety Clone()
        {
            Surety obj = base.Clone() as Surety;
            obj.SuretyType = this.SuretyType.Clone() as SuretyTypeEnumService;
            obj.SuretyPerson = this.SuretyPerson.Clone();
            obj.Oper = this.Oper.Clone();
            obj.ApplyPerson = this.ApplyPerson.Clone();

            // 开户行{0374EA05-782E-4609-9CDC-03236AB97906}
        
            obj.Bank = this.Bank.Clone();
            obj.PayType = this.PayType.Clone();
            return obj;
        }
        #endregion
    }
}
