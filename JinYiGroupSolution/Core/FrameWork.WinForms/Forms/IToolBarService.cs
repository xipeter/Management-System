using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// 用户工具条功能服务接口
    /// 可以添加工具栏按钮服务
    /// 限制目录：本地目录/
    /// </summary>
    public interface IToolBarService
    {
        /// <summary>
        /// 初始化，传入ToolStrip
        /// 不支持ToolBar
        /// </summary>
        /// <param name="toolbar"></param>
        /// <returns></returns>
        int Init(System.Windows.Forms.ToolStrip toolbar);


        /// <summary>
        /// 工具栏Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="param"></param>
        void ToolBarClick(object sender, object param);

        /// <summary>
        /// 参数变化
        /// </summary>
        /// <param name="param"></param>
        void InfoChanged(object param);

    }

}


