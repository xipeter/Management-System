using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// [功能描述: 双击查询窗口弹出的修改控件接口]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IMaintenanceModifyControl
    {
        /// <summary>
        /// 数据
        /// </summary>
        List<string> Data
        {
            get;
            set;
        }
    }
}
