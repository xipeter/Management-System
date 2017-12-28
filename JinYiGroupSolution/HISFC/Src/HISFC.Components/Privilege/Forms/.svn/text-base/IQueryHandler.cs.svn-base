using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.UFC.Privilege.Forms
{
    /// <summary>
    /// [功能描述: 查询功能的控件接口]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IQueryHandler
    {
        /// <summary>
        /// 开始查询
        /// </summary>
        event System.EventHandler BeginQuery;
        /// <summary>
        /// 结束查询
        /// </summary>
        event System.EventHandler EndQuery;
        /// <summary>
        /// 开始保存
        /// </summary>
        event System.EventHandler BeginSave;
        /// <summary>
        /// 结束保存
        /// </summary>
        event System.EventHandler EndSave;
        /// <summary>
        /// 开始打印
        /// </summary>
        event System.EventHandler BeginPrint;
        /// <summary>
        /// 结束打印
        /// </summary>
        event System.EventHandler EndPrint;
        /// <summary>
        /// 开始刷新
        /// </summary>
        event System.EventHandler BeginRefresh;
        /// <summary>
        /// 结束刷新
        /// </summary>
        event System.EventHandler EndRefresh;
        /// <summary>
        /// 刷新按钮变化
        /// </summary>
        event System.EventHandler RefreshChanged;
        /// <summary>
        /// 打印按钮变化
        /// </summary>
        event System.EventHandler PrintChanged;
        /// <summary>
        /// 查询按钮变化
        /// </summary>
        event System.EventHandler QueryChanged;
        /// <summary>
        /// 打印设置按钮变化
        /// </summary>
        event System.EventHandler PrintSetChanged;
        /// <summary>
        /// 打印预览变化
        /// </summary>
        event System.EventHandler PrintPreviewChanged;
        /// <summary>
        /// 退出按钮变化
        /// </summary>
        event System.EventHandler ExitChanged;
        /// <summary>
        /// 保存按钮变化
        /// </summary>
        event System.EventHandler SaveChanged;


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int Query(object sender, object neuObject);

        /// <summary>
        /// 保存，确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int Save(object sender, object neuObject);

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int Print(object sender, object neuObject);

        /// <summary>
        /// 设置打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int SetPrint(object sender, object neuObject);

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int PrintPreview(object sender, object neuObject);

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int Exit(object sender, object neuObject);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        int Export(object sender, object neuObject);

        /// <summary>
        /// 刷新
        /// </summary>
        /// <returns></returns>
        void Refresh();

        /// <summary>
        /// 控件文本
        /// </summary>
        string ControlText { get;}
    }
}
