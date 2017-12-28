using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Account
{
    /// <summary>
    /// Neusoft.HISFC.Models.Account.Account<br></br>
    /// [功能描述: 门诊帐户实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-05-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Account :Neusoft.FrameWork.Models.NeuObject,IValidState
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Account()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNO = string.Empty;

        /// <summary>
        /// 帐户卡实体
        /// </summary>
        private AccountCard accountcard=new AccountCard();
        /// <summary>
        /// 帐户交易实体
        /// </summary>
        private List<AccountRecord> accountRecord = new List<AccountRecord>();
        
        /// <summary>
        /// 帐户状态
        /// </summary>
        private EnumValidState validState= EnumValidState.Valid;
        /// <summary>
        /// 余额
        /// </summary>
        private decimal avcancy;
        /// <summary>
        /// 帐户密码
        /// </summary>
        private string password = string.Empty;
        /// <summary>
        /// 单日消费限制
        /// </summary>
        private decimal daylimit;
        /// <summary>
        /// 是否授权
        /// </summary>
        private bool isEmpower=false;
        #endregion

        #region 属性


        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNO
        {
            get { return cardNO; }
            set { cardNO = value; }
        }


        /// <summary>
        /// 帐户卡实体
        /// </summary>
        public AccountCard AccountCard
        {
            get
            {
                return this.accountcard;
            }
            set
            {
                this.accountcard = value;
            }
        }
        /// <summary>
        /// 帐户交易实体
        /// </summary>
        public List<AccountRecord> AccountRecord
        {
            get
            {
                return this.accountRecord;
            }
            set
            {
                this.accountRecord = value;
            }
        }

        /// <summary>
        /// 帐户状态'1'正常'0'停用
        /// </summary>
        //public EnumValidState IsValid
        //{
        //    get
        //    {
        //        return validState;
        //    }
        //    set
        //    {
        //        validState = value;
        //    }
        //}

        /// <summary>
        /// 帐户余额
        /// </summary>
        public decimal Vacancy
        {
            get
            {
                return avcancy;
            }
            set
            {
                avcancy = value;
            }
        }

        /// <summary>
        /// 帐户密码
        /// </summary>
        public string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// 单日消费限制
        /// </summary>
        public decimal DayLimit
        {
            get
            {
                return this.daylimit;
            }
            set
            {
                this.daylimit = value;
            }
        }

        /// <summary>
        /// 是否授权
        /// </summary>
        public bool IsEmpower
        {
            get
            {
                return isEmpower;
            }
            set
            {
                isEmpower = value;
            }
        }
        #endregion 

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Account Clone()
        {
            Account account = base.Clone() as Account;
            account.AccountCard = this.AccountCard.Clone();
            if (AccountRecord.Count > 0)
            {
                foreach (AccountRecord ard in accountRecord)
                {
                    account.AccountRecord.Add(ard.Clone());
                }
            }

            return account;
        }
        #endregion

        #region IValidState 成员
        /// <summary>
        /// 帐户状态0停用 1正常 2注销
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
    }

 
}
