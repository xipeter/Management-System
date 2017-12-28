using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// 预先处理接口
    /// 实现该接口的类将在窗口打开时调用 当返回值为－1时，窗口不再继续加载
    /// </summary>
    public interface IPreArrange
    {
        int PreArrange();
    }
}
