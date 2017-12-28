using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.IHE
{
    /// <summary>
    /// [功能描述：OP接口]
    /// [创 建 者：薛文进]
    /// [创建时间：2010-03-08]
    /// </summary>
    public interface IOP
    {
        /// <summary>
        /// 传送医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int PlaceOrder(Neusoft.HISFC.Models.Order.Order order);

        /// <summary>
        /// 传送医嘱
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        int PlaceOrder(List<Neusoft.HISFC.Models.Order.Inpatient.Order> items);

        /// <summary>
        /// 传送医嘱
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        int PlaceOrder(System.Collections.ArrayList items);
    }
}
