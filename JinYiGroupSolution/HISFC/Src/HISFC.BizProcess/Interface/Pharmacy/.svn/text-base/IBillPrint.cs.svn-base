using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品入库/出库单据打印 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public interface IBillPrint
    {
        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="billNO">单据号</param>
        /// <returns></returns>
        int SetData(string billNO);

        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="alPrintData">待打印数据</param>
        /// <param name="privType">系统类型 Class3_Meaning_Code</param>
        /// <returns></returns>
        int SetData(ArrayList alPrintData, string privType);

        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="alPrintData"></param>
        /// <param name="billType">enum BillType</param>
        /// <returns></returns>
        int SetData(ArrayList alPrintData, BillType billType);

        int Print();

        int Prieview();
    }

    /// <summary>
    /// 单据类型
    /// </summary>
    public enum BillType
    {
        /// <summary>
        /// 入库
        /// </summary>
        Input,
        /// <summary>
        /// 出库
        /// </summary>
        Output,
        /// <summary>
        /// 入库计划
        /// </summary>
        InPlan,
        /// <summary>
        /// 采购计划
        /// </summary>
        StockPlan,
        /// <summary>
        /// 盘点
        /// </summary>
        Check,
        /// <summary>
        /// 调价
        /// </summary>
        Adjust,
        /// <summary>
        /// 内部入库申请              //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
        /// </summary>
        InnerApplyIn
    }
}
