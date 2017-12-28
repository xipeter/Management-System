using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Nurse
{
    /// <summary>
    /// IGetInjectOrderNo<br></br>
    /// <Font color='#FF1111'>[功能描述:获得门诊注射号码接口{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public interface IGetInjectOrderNo
    {
        /// <summary>
        /// 获得门诊注射号码
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        string GetOrderNo(Neusoft.HISFC.Models.Registration.Register reg);

        /// <summary>
        /// 相同患者根据当前顺序号生成下一个顺序号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        string GetSamePatientNextOrderNo(string orderNo);

        /// <summary>
        /// 获得打印序号
        /// </summary>
        /// <param name="injectList"></param>
        void SetPrintNo(ArrayList injectList);
    }
}
