using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{

    /// <summary>
    /// 制剂状态类
    /// </summary>
    public enum EnumState
    {
        /// <summary>
        /// 计划
        /// </summary>
        Plan,
        /// <summary>
        /// 配制
        /// </summary>
        Confect,
        /// <summary>
        /// 半成品分装
        /// </summary>
        Division,
        /// <summary>
        /// 半成品检验
        /// </summary>
        SemiAssay,
        /// <summary>
        /// 成品外包装
        /// </summary>
        Package,
        /// <summary>
        /// 成品检验
        /// </summary>
        PackAssay,
        /// <summary>
        /// 成品入库
        /// </summary>
        Input
    }

    /// <summary>
    /// 制剂模版类型
    /// </summary>
    public enum EnumStencialType
    {
        /// <summary>
        /// 半成品检验
        /// </summary>
        SemiAssayStencial,
        /// <summary>
        /// 成品检验模版
        /// </summary>
        ProductAssayStencial,
        /// <summary>
        /// 生产流程
        /// </summary>
        ProductStencial,
        /// <summary>
        /// 扩展
        /// </summary>
        Extend
    }

    /// <summary>
    /// 制剂处方原料类型枚举类
    /// </summary>
    public enum EnumMaterialType
    {
        /// <summary>
        /// 生产原料
        /// </summary>
        Material = 1,
        /// <summary>
        /// 包装材料
        /// </summary>
        Wrapper = 0
    }

}
