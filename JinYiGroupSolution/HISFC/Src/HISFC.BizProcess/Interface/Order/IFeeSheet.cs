using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Order
{
    /// <summary>
    /// {2D97BF3B-C09C-433d-9C8C-F80CC2751261}
    /// </summary>
    public interface IFeeSheet 
    {
        /// <summary>
        /// 调用病区记账单
        /// </summary>
        /// <param name="beginDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <param name="paramRecipeNo">处方号串</param>
        /// <returns></returns>
        int NurseFeeBill(DateTime beginDt, DateTime endDt, string paramRecipeNo);
    }
}
