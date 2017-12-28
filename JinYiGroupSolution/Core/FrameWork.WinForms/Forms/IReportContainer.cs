using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.NFC.Interface.Forms
{
    /// <summary>
    /// [功能描述: 报表容器接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IReportContainer
    {
        /// <summary>
        /// 所容纳的报表的名称
        /// </summary>
        Type[] ReportPrinterTypes
        {
            get;
        }

        /// <summary>
        /// 所容纳的报表
        /// </summary>
        object[] ReportPrinters
        {
            set;
        }
    }
}
