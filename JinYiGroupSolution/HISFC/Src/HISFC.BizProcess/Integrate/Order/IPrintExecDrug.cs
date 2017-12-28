using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// 药品执行医嘱打印接口 
    /// 配液单、领药单使用此接口
    /// </summary>
    public interface IPrintExecDrug
    {
        /// <summary>
        /// 操作环境信息
        /// </summary>
        /// <param name="oper">配液人员信息</param>
        /// <param name="dept">需配液科室</param>
        void SetTitle(Neusoft.HISFC.Models.Base.OperEnvironment oper,Neusoft.FrameWork.Models.NeuObject dept);

        /// <summary>
        /// 执行医嘱信息
        /// </summary>
        /// <param name="alExecOrder">执行医嘱信息</param>
        /// <param name="hsPatient">医嘱内包含患者信息</param>
        void SetExecOrder(System.Collections.ArrayList alExecOrder, System.Collections.Hashtable hsPatient);

        /// <summary>
        /// 执行医嘱信息
        /// </summary>
        /// <param name="alExecOrder">执行医嘱信息</param>
        void SetExecOrder(System.Collections.ArrayList alExecOrder);

        /// <summary>
        /// 打印
        /// </summary>
        void Print();

        /// <summary>
        /// 打印预览
        /// </summary>
        void PrintPreview();
    }
}
