using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.Order
{
    /// <summary>
    /// 医生站辅材处理
    /// </summary>
    public interface IDealSubjob
    {
        /// <summary>
        /// 医生站处理辅材
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="alFee">费用信息</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        int DealSubjob(Neusoft.HISFC.Models.Registration.Register r, ArrayList alFee, ref string errText);
    }
}
