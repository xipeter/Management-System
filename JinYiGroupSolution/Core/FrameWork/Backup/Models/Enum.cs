using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// 缓存数据类型
    /// </summary>
    public enum CacheDataType
    {
        /// <summary>
        /// 科室
        /// </summary>
        Department,
        /// <summary>
        /// 人员
        /// </summary>
        Employee,
        /// <summary>
        /// 常数类别
        /// </summary>
        Constant,
        /// <summary>
        /// ICD诊断
        /// </summary>
        ICDDiagnose,
        /// <summary>
        /// 药品字典
        /// </summary>
        DrugDictionary,
        /// <summary>
        /// 非药品字典
        /// </summary>
        UndrugDictionary,
        /// <summary>
        /// 住院患者药品字典列表
        /// </summary>
        DrugInpatientList,
        /// <summary>
        /// 非药品医嘱术语
        /// </summary>
        MedicalTerm
    }
}
