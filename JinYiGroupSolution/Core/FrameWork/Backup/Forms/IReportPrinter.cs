using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// [功能描述: 报表打印接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IReportPrinter
    {
        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        int Print();

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <returns></returns>
        int PrintPreview();

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        int Export();
    }
}
