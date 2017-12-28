using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord
{
    /// <summary>
    /// [功能描述: 病案接口类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-4-4 ]<br></br>
    /// </summary>
    public interface HealthRecordInterface : Neusoft.FrameWork.WinForms.Forms.IReportPrinter
    {
        /// <summary>
        /// 病案实体 ,因为此实体聚合了Neusoft.HISFC.Models.RADT.PatientInfo，所以住院实体可以先转化成病案实体
        /// </summary>
        /// <param name="obj"></param>
        void ControlValue(Neusoft.HISFC.Models.HealthRecord.Base obj);
        /// <summary>
        /// 清空数据
        /// </summary>
        void Reset();
    }

    /// <summary>
    ///病案首页第二页  {DC8452B8-FF77-4639-9522-A2CCED4B8A5C}
    /// </summary>
    public interface HealthRecordInterfaceBack : Neusoft.FrameWork.WinForms.Forms.IReportPrinter
    {
        /// <summary>
        /// 病案实体 ,因为此实体聚合了Neusoft.HISFC.Models.RADT.PatientInfo，所以住院实体可以先转化成病案实体
        /// </summary>
        /// <param name="obj"></param>
        void ControlValue(Neusoft.HISFC.Models.HealthRecord.Base obj);
        /// <summary>
        /// 清空数据
        /// </summary>
        void Reset();
    }
}
