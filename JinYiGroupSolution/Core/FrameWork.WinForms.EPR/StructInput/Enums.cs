using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.EPRControl.StructInput
{
    /// <summary>
    /// 结构化查询方式：中文名、编码、英文名、拼音、五笔

    /// </summary>
    public enum enumSearchType
    {
        /// <summary>
        /// 中文名

        /// </summary>
        CNOMEN = 0,

        /// <summary>
        /// 编码
        /// </summary>
        TERMCODE = 1,

        /// <summary>
        /// 英文名

        /// </summary>
        ENOMEN = 2,

        /// <summary>
        /// 拼音
        /// </summary>
        PY_CODE = 3,

        /// <summary>
        /// 五笔
        /// </summary>
        WB_CODE = 4
    }
}
