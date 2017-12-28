using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Material
{
    /// <summary>
    /// 物资入库/出库单据打印
    /// </summary>
    public interface IBillPrint
    {

        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="alInData">待打印数据</param>
        /// <returns></returns>
        int SetData(List<Neusoft.HISFC.Models.Material.Input> alInData);

        /// <summary>
        /// 传送出库待打印数据
        /// </summary>
        /// <param name="alOutData"></param>
        /// <returns></returns>
        int SetData(List<Neusoft.HISFC.Models.Material.Output> alOutData);

        /// <summary>
        /// 传送入库计划待打印数据
        /// </summary>
        /// <param name="alPlan"></param>
        /// <returns></returns>
        int SetData(List<Neusoft.HISFC.Models.Material.InputPlan> alPlan);

        /// <summary>
        /// 传送盘点待打印数据
        /// </summary>
        /// <param name="alCheck"></param>
        /// <returns></returns>
        int SetData(List<Neusoft.HISFC.Models.Material.Check> alCheck);

        int Print();

        int Prieview();
    }
}
