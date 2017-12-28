using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品摆药单/标签 打印接口 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public interface IDrugPrint
    {
        /// <summary>
        /// 门诊患者信息
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register OutpatientInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 住院患者信心
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo InpatientInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 本次打印标签总页数
        /// </summary>
        decimal LabelTotNum
        {
            set;
        }

        /// <summary>
        /// 一次打印药品种类总数量
        /// </summary>
        decimal DrugTotNum
        {
            set;
        }

        /// <summary>
        /// 打印新摆药标签 单个药品
        /// </summary>
        /// <param name="info">摆药数据</param>
        void AddSingle(ApplyOut info);

        /// <summary>
        /// 打印配药标签 组合打印 
        /// </summary>
        /// <param name="alCombo">打印组合数据</param>
        void AddCombo(ArrayList alCombo);

        /// <summary>
        /// 打印配药清单
        /// </summary>
        /// <param name="al">所有待打印数据</param>
        void AddAllData(ArrayList al);

        /// <summary>
        /// 摆药单打印 显示全部数据
        /// </summary>
        /// <param name="al">待打印的摆药申请信息</param>
        /// <param name="drugBillClass">摆药通知信息</param>
        void AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass);

        /// <summary>
        /// 摆药单打印 显示全部数据
        /// </summary>
        /// <param name="al">待打印的摆药申请信息</param>
        /// <param name="drugRecipe">门诊处方调剂信息</param>
        void AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe);

        /// <summary>
        /// 打印摆药单
        /// </summary>
        void Print();

        /// <summary>
        /// 预览摆药单
        /// </summary>
        void Preview();
    }
}
