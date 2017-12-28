using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.Operation
{
    /// <summary>
    /// [功能描述: 手术安排通知单打印接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IArrangeNotifyFormPrint : IApplicationFormPrint
    {
        /// <summary>
        /// 是否打印加台申请单
        /// </summary>
        bool IsPrintExtendTable
        {
            set;
        }
    }
}
