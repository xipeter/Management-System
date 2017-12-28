using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Common
{
    /// <summary>
    /// 参数维护接口
    /// </summary>
    public interface IControlParamMaint 
    {
        /// <summary>
        /// 控制参数维护UC的描述
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrText { get; set; }

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Init();

        /// <summary>
        /// 应用
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Apply();

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Save();

        /// <summary>
        /// 是否显示UC自带保存,退出按钮等
        /// </summary>
        bool IsShowOwnButtons { get; set;}

        /// <summary>
        /// 是否更改了参数信息
        /// </summary>
        bool IsModify { get; set; }
    }

    /// <summary>
    /// 提示信息接口，用于HIS启动/注销后的自动提示信息
    /// 
    /// {5BE03DF2-25DE-4e7a-9B47-85CE92911277} 修改接口定义
    /// </summary>
    public interface INoticeManager
    {
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <returns></returns>
        int Notice();

        /// <summary>
        /// 计划提示
        /// </summary>
        /// <returns></returns>
        int Schedule();

        /// <summary>
        /// 警示提示
        /// </summary>
        /// <returns></returns>
        int Warn();

        /// <summary>
        /// HIS系统注销前提示信息
        /// </summary>
        /// <returns></returns>
        int MsgOnLogout();
    }

    /// <summary>
    /// 插件设置接口
    /// </summary>
    public interface ISetup 
    {
        /// <summary>
        /// 恢复默认(慎用)
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Default();
        
        /// <summary>
        /// 是否设置界面为窗口
        /// </summary>
        bool IsWindow { get; }

        /// <summary>
        /// 打开设计界面
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Show();
    }

    /// <summary>
    /// 预览
    /// </summary>
    public interface IPreview 
    {
        /// <summary>
        /// 预览
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Preview();

        /// <summary>
        /// 当前预览控件
        /// </summary>
        System.Windows.Forms.Control PreviewControl { get; }
    }
}
