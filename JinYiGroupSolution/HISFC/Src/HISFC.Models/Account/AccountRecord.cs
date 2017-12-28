using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Account
{
    
    /// <summary>
    /// Neusoft.HISFC.Models.Account.AccountRecord<br></br>
    /// [功能描述: 门诊帐户交易实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-05-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class AccountRecord : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccountRecord()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        
        /// <summary>
        /// 帐户患者信息
        /// </summary>
        private HISFC.Models.RADT.Patient patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 帐号
        /// </summary>
        private string accountNO = string.Empty;

        /// <summary>
        /// 操作类型0预交金1建帐户2停帐户3重启帐户4支付5退费入户
        /// </summary>
        private EnumOperTypesService operType=new EnumOperTypesService();

        /// <summary>
        /// 金额
        /// </summary>
        private decimal money;

        /// <summary>
        /// 交费科室
        /// </summary>
        private string deptCode=string.Empty;

        /// <summary>
        /// 操作员
        /// </summary>
        private string oper = string.Empty;

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime opertime;

        /// <summary>
        /// 备注
        /// </summary>
        private string reMark = string.Empty;

        /// <summary>
        /// 交易状态
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 交易后余额
        /// </summary>
        private decimal vacancy;

        /// <summary>
        /// 被授权患者基本信息
        /// </summary>
        private HISFC.Models.RADT.Patient empwoerPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 授权金额
        /// </summary>
        private decimal empowerCost = 0m;

        /// <summary>
        /// 发票类型
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject invoiceType = new Neusoft.FrameWork.Models.NeuObject();
        #endregion

        #region 属性

        /// <summary>
        /// 帐户患者信息
        /// </summary>
        public RADT.Patient Patient
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
        /// 操作类型0预交金1建帐户2停帐户3重启帐户4支付5退费入户
        /// </summary>
        public EnumOperTypesService OperType
        {
            get
            {
                return operType;
            }
            set
            {
                operType = value;
            }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        /// <summary>
        /// 交费科室
        /// </summary>
        public string DeptCode
        {
            get
            {
                return deptCode;
            }
            set
            {
                deptCode = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public string Oper
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
        /// 操作时间
        /// </summary>
        public DateTime OperTime
        {
            get
            {
                return opertime;
            }
            set
            {
                opertime = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark
        {
            get
            {
                return reMark;
            }
            set
            {
                reMark = value;
            }
        }

        /// <summary>
        /// 交易状态
        /// </summary>
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        /// <summary>
        /// 交易后余额
        /// </summary>
        public decimal Vacancy
        {
            get
            {
                return vacancy;
            }
            set
            {
                vacancy = value;
            }
        }

        /// <summary>
        /// 被授权患者基本信息
        /// </summary>
        public HISFC.Models.RADT.Patient EmpowerPatient
        {
            get
            {
                return empwoerPatient;
            }
            set
            {
                empwoerPatient = value;
            }

        }

        /// <summary>
        /// 授权金额
        /// </summary>
        public decimal EmpowerCost
        {
            get
            {
                return empowerCost;
            }
            set
            {
                empowerCost = value;
            }
        }

        /// <summary>
        /// 发票类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InvoiceType
        {
            get
            {
                return invoiceType;
            }
            set
            {
                invoiceType = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new AccountRecord Clone()
        {
            AccountRecord accountCard = base.Clone() as AccountRecord;
            accountCard.patient = this.Patient.Clone();
            accountCard.empwoerPatient = this.EmpowerPatient.Clone();
            accountCard.operType = this.OperType.Clone() as EnumOperTypesService;
            accountCard.invoiceType = this.InvoiceType.Clone();
            return accountCard;
        }

        #endregion

    }
}
