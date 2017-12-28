using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    public interface IFirsDayUseQuantity
    {
        /// <summary>
        /// 设置首日量的 rder.BeginTime
        ///order.CurMOTime = order.BeginTime;
        ///order.NextMOTime 
        /// </summary>
        /// <param name="order">医嘱信息</param>
        /// <param name="t">System.Data.IDbTransaction</param>
        /// <returns>反回医嘱信息</returns>
        Neusoft.HISFC.Models.Order.Inpatient.Order SetFirstUseQuanlity(Neusoft.HISFC.Models.Order.Inpatient.Order order, System.Data.IDbTransaction t);
    }
}
