using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Account
{

    /// <summary>
    /// Neusoft.HISFC.Models.Account.AccountRecord<br></br>
    /// [功能描述: 门诊帐户授权实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2008-06-23]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class AccountEmpower : NeuObject
    {
        #region 变量
        /// <summary>
        /// 授权帐户信息
        /// </summary>
        private AccountCard accountCard = new AccountCard();

        /// <summary>
        /// 被授权帐户信息
        /// </summary>
        private AccountCard empowerCard = new AccountCard();

        /// <summary>
        /// 授权密码
        /// </summary>
        private string passWord = string.Empty;

        /// <summary>
        /// 授权限额
        /// </summary>
        private decimal empowerLimit = 0.0m;

        /// <summary>
        /// 操作信息
        /// </summary>
        private Base.OperEnvironment oper = new Base.OperEnvironment();

        /// <summary>
        /// 余额
        /// </summary>
        private decimal vacancy = 0.0m;

        /// <summary>
        /// 是否可用0停用 1正常
        /// </summary>
        private Base.EnumValidState valid =  Base.EnumValidState.Valid;
        /// <summary>
        /// 帐号
        /// </summary>
        private string accountNO = string.Empty;
        #endregion

        #region 属性　
        /// <summary>
        /// 授权帐户信息
        /// </summary>
        public AccountCard AccountCard
        {
            get { return accountCard; }
            set { accountCard = value; }
        }

        /// <summary>
        /// 被授权帐户信息
        /// </summary>
        public AccountCard EmpowerCard
        {
            get { return empowerCard; }
            set { empowerCard = value; }
        }

        /// <summary>
        /// 授权密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        /// <summary>
        /// 授权限额
        /// </summary>
        public decimal EmpowerLimit
        {
            get { return empowerLimit; }
            set { empowerLimit = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal Vacancy
        {
            get { return vacancy; }
            set { vacancy = value; }
        }
        /// <summary>
        /// 帐号
        /// </summary>
        public string AccountNO
        {
            get
            {
                return accountNO;
            }
            set
            {
                accountNO = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new AccountEmpower Clone()
        {
            AccountEmpower accountEmpower = base.Clone() as AccountEmpower;
            accountEmpower.accountCard = this.AccountCard.Clone();
            accountEmpower.empowerCard = this.EmpowerCard.Clone();
            accountEmpower.oper = Oper.Clone();
            return accountEmpower;
        }
        #endregion

        #region IValid 成员
        /// <summary>
        /// 是否在用 0停用 1在用
        /// </summary>
        public Base.EnumValidState ValidState
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
    }
}
