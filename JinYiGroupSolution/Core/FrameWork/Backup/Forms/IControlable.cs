using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// [功能描述: 功能控件的接口]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IControlable
    {

        /// <summary>
        /// 初始化控件函数
        /// </summary>
        /// <param name="sender">传入TreeView</param>
        /// <param name="neuObject">传入当前选择信息,如果没有则为Null</param>
        /// <param name="param">窗口Tag</param>
        /// <returns></returns>
        ToolBarService Init(object sender, object  neuObject, object param);

        /// <summary>
        /// toolbar Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolStrip_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e);

        /// <summary>
        /// 初始化开始
        /// </summary>
        event System.EventHandler BeginInit;

        /// <summary>
        /// 初始化结束
        /// </summary>
        event System.EventHandler EndInit;

        /// <summary>
        /// 设置数值前调用的函数
        /// </summary>
        /// <param name="neuObject">传入当前选择信息,如果没有则为Null</param>
        /// <param name="e">窗口Tag</param>
        /// <returns></returns>
        int BeforSetValue(object neuObject, System.Windows.Forms.TreeViewCancelEventArgs e);

        /// <summary>
        /// 设置单个数值
        /// </summary>
        /// <param name="neuObject">传入当前选择信息,如果没有则为Null</param>
        /// <param name="e">窗口Tag</param>
        /// <returns></returns>
        int SetValue(object neuObject, System.Windows.Forms.TreeNode e);

        /// <summary>
        /// 设置数值开始
        /// </summary>
        event System.EventHandler BeginSetValue;

        /// <summary>
        /// 设置数值结束
        /// </summary>
        event System.EventHandler EndSetValue;

        /// <summary>
        /// 设置批量数值
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int SetValues(System.Collections.ArrayList alValues,object param);

        /// <summary>
        /// 刷新树事件
        /// </summary>
        event System.EventHandler RefreshTree;

        /// <summary>
        /// 当前系统消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        int GetMessage(object sender, string msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        event MessageEventHandle SendMessage;

        /// <summary>
        /// 添加状态条显示信息
        /// </summary>
        event MessageEventHandle StatusBarInfo;

        /// <summary>
        /// 发送参数给控件
        /// </summary>
        event SendParamToControlHandle SendParamToControl;

        #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
        /// <summary>
        /// 根据索引增加StatusBarPanel的信息 
        /// </summary>
        event SendIconToStatusBar AddStastusBarPanel;

        #endregion

    }

    #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
    /// <summary>
    /// 增加带图标的状态栏
    /// </summary>
    /// <param name="icon">图标文件</param>
    /// <param name="msg">消息</param>
    /// <param name="Index">插入位置 0,1,2,3</param>
    public delegate void SendIconToStatusBar(System.Drawing.Icon icon, string msg, int Index); 
    #endregion

    /// <summary>
    /// 消息事件代理
    /// </summary>
    public delegate void MessageEventHandle(object sender, string msg);
    
    /// <summary>
    /// 发送参数给控件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="dllName"></param>
    /// <param name="controlName"></param>
    /// <param name="objParams"></param>
    public delegate void SendParamToControlHandle(object sender, string dllName, string controlName,object objParams);
}
