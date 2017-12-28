using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Account;

namespace Neusoft.HISFC.BizProcess.Interface.Account
{
    /// <summary>
    /// 根据预交金信息处理预交金优惠信息
    /// </summary>
    public interface IAccountProcessPrepay
    {
        /// <summary>
        /// 更具
        /// </summary>
        /// <param name="p"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        int GetDerateCost(PrePay p ,ref string errText);
    }
}
