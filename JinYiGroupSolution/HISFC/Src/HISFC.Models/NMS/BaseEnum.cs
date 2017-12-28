using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    #region 护理项目类型

    [System.Serializable]
    public enum EnumNMSKindType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        String = 1,
        /// <summary>
        /// 数值
        /// </summary>
        Int = 2,
        /// <summary>
        /// 日期
        /// </summary>
        Date = 3,
        /// <summary>
        /// 人员
        /// </summary>
        Employee = 4,
        /// <summary>
        /// 科室
        /// </summary>
        Department = 5,
        /// <summary>
        /// 病区
        /// </summary>
        Area = 6,
        /// <summary>
        /// 是否
        /// </summary>
        IsOrNot = 7,
        /// <summary>
        /// 抽查
        /// </summary>
        Checks = 8,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom = 9

    }
    #endregion

    #region 护理项目分类分数标识

    [System.Serializable]
    public enum EnumNMSKindGradeState
    {
        /// <summary>
        /// 不管理分数
        /// </summary>
        Not = 0,
        /// <summary>
        /// 加分
        /// </summary>
        Add = 1,
        /// <summary>
        /// 扣分
        /// </summary>
        Reduce = 2
    }

    #endregion
}
