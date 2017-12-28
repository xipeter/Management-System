using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.ClinicPath
{
    /// <summary>
    /// add by xuewj 2010-10-19 临床路径接口 {10962AE3-C0B9-4cf7-91B6-CA956C1AFC2D}
    /// </summary>
    public interface IClinicPath
    {
        /// <summary>
        /// 患者是否在临床路径
        /// </summary>
        /// <param name="inpatientNo">患者住院号</param>
        /// <returns>成功返回true 失败返回false</returns>
        bool PatientIsSelectedPath(string inpatientNo);

        /// <summary>
        /// 点击患者
        /// </summary>
        /// <param name="inpatientNo">患者住院号</param>
        ///  <returns>在临床路径返回1 不在返回-1</returns>
        int ClickClinicPath(string inpatientNo);

        /// <summary>
        /// 护士站出院操作
        /// </summary>
        /// <param name="inpatientNO">患者住院号</param>
        /// <returns>成功返回true 失败返回false</returns>
        bool PatientOutByNurse(string inpatientNO,DateTime dtOutDate);

        /// <summary>
        /// 停止临床路径
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        bool StopClinicPath(string inpatientNO);

        /// <summary>
        /// 医生站出院操作
        /// </summary>
        /// <param name="inpatientNO">患者住院号</param>
        /// <returns>成功返回true 失败返回false</returns>
        bool PatientOutByDoctor(string inpatientNO);

        /// <summary>
        /// 保存医嘱时，自动判断医生开立的医嘱，是否在路径中，如不在路径中，则弹出提示，填写变异原因。
        /// </summary>
        /// <param name="inpatientNo">患者住院号</param>
        /// <param name="orderList">医嘱列表</param>
        /// <returns>成功返回true 失败返回false</returns>
        bool PatientSaveOrder(string inpatientNo, List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList);
    }
}
