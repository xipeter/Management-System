using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 打印输液卡接口]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IPrintTransFusion
    {
        /// <summary>
        /// 打印
        /// </summary>
        void Print();

        /// <summary>
        /// 查询批量患者的指定时间段，指定用法的输液卡
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="usagecode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usagecode, DateTime dtBegin, DateTime dtEnd,bool isPrinted);

        /// <summary>
        /// 查询批量患者指定时间点的，指定用法的输液卡
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="usagecode"></param>
        /// <param name="dtTime"></param>
        void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usagecode, DateTime dtTime,bool isPrinted);

        /// <summary>
        /// 打印设置
        /// </summary>
        void PrintSet();
        

    }
}
