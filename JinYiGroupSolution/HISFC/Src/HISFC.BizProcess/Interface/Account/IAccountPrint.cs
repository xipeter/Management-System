using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Account;

namespace Neusoft.HISFC.BizProcess.Interface.Account
{
    /// <summary>
    /// 打印建帐户打印凭证
    /// </summary>
    public interface IPrintCreateAccount
    {
        /// <summary>
        /// 为打印UC赋值
        /// </summary>
        /// <param name="account">帐户实体</param>
        void SetValue(HISFC.Models.Account.Account account);
        /// <summary>
        /// 打印
        /// </summary>
        void Print();

    }

    /// <summary>
    /// 打印预交金收据
    /// </summary>
    public interface IPrintPrePayRecipe
    {
        /// <summary>
        /// 为打印UC赋值
        /// </summary>
        /// <param name="account">帐户实体</param>
        void SetValue(HISFC.Models.Account.PrePay prepay);
        /// <summary>
        /// 打印
        /// </summary>
        void Print();
    }

    /// <summary>
    /// 打印退帐户余额
    /// </summary>
    public interface IPrintCancelVacancy
    {
        /// <summary>
        /// 为打印UC赋值
        /// </summary>
        /// <param name="account">帐户实体</param>
        void SetValue(HISFC.Models.Account.AccountRecord accountRecord);
        /// <summary>
        /// 打印
        /// </summary>
        void Print();
    }

    /// <summary>
    /// 帐户操作凭证打印
    /// </summary>
    public interface IPrintOperRecipe
    {
        /// <summary>
        /// 为打印UC赋值
        /// </summary>
        /// <param name="accountRecord"></param>
        void SetValue(HISFC.Models.Account.AccountRecord accountRecord);
        /// <summary>
        /// 打印
        /// </summary>
        void Print();
    }

    /// <summary>
    /// 高保患者标签打印
    /// </summary>
    public interface IPrintLable
    {
        /// <summary>
        /// 打印高保患者标签
        /// </summary>
        /// <param name="accountCard"></param>
        void PrintLable(AccountCard accountCard);
    }

    /// <summary>
    /// [功能描述: 门诊帐户预交金打印]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2006-6-22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IAccountPrint
    {
        /// <summary>
        /// 设置打印数据
        /// </summary>
        /// <param name="account">帐户实体</param>
        /// <returns></returns>
        int PrintSetValue(Neusoft.HISFC.Models.Account.Account account);
        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        int Print();
    }

    public interface IPassWord
    {
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <returns></returns>
        bool ValidPassWord
        {
            get;
        }
        /// <summary>
        /// 门诊卡号
        /// </summary>
        Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get;
            set;
        }
        /// <summary>
        /// 是否验证密码
        /// </summary>
        bool IsOK
        {
            get;
        }
    }
    
}
