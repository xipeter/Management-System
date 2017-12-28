using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.EnumServer
{
    [Serializable]
    class EnumServer
    {
    }
    #region 其他枚举

    #region 疾病分类
    [Serializable]
    public enum ReportIndexs
    {
        /// <summary>
        ///姓名索引卡 
        /// </summary>
        NameIndex,
        /// <summary>
        ///死亡分类卡
        /// </summary>
        DeathIndex,
        /// <summary>
        /// 出院分科表
        /// </summary>
        DepartDept,
        /// <summary>
        /// 职道办病人问卷调查表
        /// </summary>
        Zhidaoban,
        /// <summary>
        /// 疾病索引卡
        /// </summary>
        DiseaseClassify,
        /// <summary>
        /// 手术索引卡
        /// </summary>
        OperationClassisy,
        /// <summary>
        /// 科室术前平均住院日统计
        /// </summary>
        BeforeODept,
        /// <summary>
        /// 科室术后平均住院日统计
        /// </summary>
        AfterODept,
        /// <summary>
        ///手术种手术率统计表
        /// </summary>
        BeforeOperation,
        /// <summary>
        /// 一周内复入院
        /// </summary>
        ComeBackInWeek,
        /// <summary>
        /// 传染病
        /// </summary>
        Infection,
        /// <summary>
        /// 病案使用频率
        /// </summary>
        CaseUserfrequence,
        /// <summary>
        /// 医生使用情况及频率统计表
        /// </summary>
        DoctorUserfrequence,
        /// <summary>
        /// 录入人员工作量统计 
        /// </summary>
        InputPerson,
        /// <summary>
        /// 诊断编码人员工作量统计
        /// </summary>
        ICDDiagPerson,
        /// <summary>
        /// 诊断编码人员工作量统计表2
        /// </summary>
        DiagCoding,
        /// <summary>
        /// 病种发病率转归统计表
        /// </summary>
        DiseaseAndOutState,
        /// <summary>
        /// 恶性肿瘤转归统计表
        /// </summary>
        TumourDiseaseAndOutState,
        /// <summary>
        /// 病案借阅经办人工作量统计表 
        /// </summary>
        BorrowCase,
        /// <summary>
        /// 病案整理员工作量统计
        /// </summary>
        BackUpCase,
        /// <summary>
        /// 手术编码人员工作量统计表1
        /// </summary>
        OperationCoding1,
        /// <summary>
        /// 手术编码人员工作量统计表1
        /// </summary>
        OperationCoding2,

    }
    #endregion

    #region 调用类型
    [Serializable]
    public enum frmTypes
    {
        /// <summary>
        /// 医生站调用
        /// </summary>
        DOC,
        /// <summary>
        /// 病案室调用
        /// </summary>
        CAS
    }
    #endregion

    #region   窗口类型
    [Serializable]
    public enum FormStyleInfo
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 双击自动关闭
        /// </summary>
        DCAutoClose
    }
    #endregion

    #region  诊断类型枚举  ICD类型分别是ICD10, ICD 9, ICD手术
    /// <summary>
    /// ICD类型分别是ICD10, ICD 9, ICD手术
    /// </summary>
    /// Creator: zhangjunyi@neusoft.com  2005/05/30
    [Serializable]
    public enum ICDTypes //ICD类型分别是ICD10, ICD 9, ICD手术
    {
        None, //什么不查
        ICD10, // ICD10
        ICD9,  // ICD 9
        ICDOperation// 手术ICD
    }
    #endregion

    #region  查询类型枚举 ,查询类型分别为所有(All), 有效(Valid) 作废(Cancel)
    /// <summary>
    /// 查询类型分别为所有(All), 有效(Valid) 作废(Cancel)
    /// </summary>
    /// Creator: zhangjunyi@neusoft.com  2005/05/30
    [Serializable]
    public enum QueryTypes //查询类型分别为所有(All), 有效(Valid) 作废(Cancel)
    {
        All,  //所有
        Valid, //有效
        Cancel //作废
    }
    #endregion

    #region 类型 增加，修改，停用
    [Serializable]
    public enum EditTypes
    {
        Add, //增加
        Modify,//修改
        Delete,//删除
        Disuse //废弃
    }
    # endregion
    [Serializable]
    public enum SelectTypes
    {
        /// <summary>
        /// 科室祖套
        /// </summary>
        DEPT,
        /// <summary>
        /// 个人祖套
        /// </summary>
        EMPOYE
    }
    /// <summary>
    ///要查询的表 
    /// </summary>
    [Serializable]
    public enum TablesName
    {
        /// <summary>
        /// 无
        /// </summary>
        NONE,
        /// <summary>
        /// 病案首页
        /// </summary>
        BASE,
        /// <summary>
        /// 非同一次入院 中根据住院流水号获取住院号，再查询住院号相同的住院流水号
        /// </summary>
        BASESUB,
        /// <summary>
        /// 诊断表
        /// </summary>
        DIAG,
        /// <summary>
        /// 诊断表 且单诊断
        /// </summary>
        DIAGSINGLE,
        /// <summary>
        /// 手术表
        /// </summary>
        OPERATION,
        /// <summary>
        /// 单手术
        /// </summary>
        OPERATIONSINGLE,
        /// <summary>
        /// 病案首页和 诊断表 
        /// </summary>
        BASEANDDIAG,
        /// <summary>
        /// 病案首页和手术表
        /// </summary>
        BASEANDOPERATION,
        /// <summary>
        /// 诊断和手术
        /// </summary>
        DIAGANDOPERATION,
        /// <summary>
        /// 病案首页 手术表，诊断表
        /// </summary>
        BASEANDDIAGANDOPERATION
    }
    [Serializable]
    public enum LendType
    {
        /// <summary>
        /// 病案已经借出
        /// </summary>
        O,
        /// <summary>
        /// 病案在架 
        /// </summary>
        I
    }
    #endregion 
}
