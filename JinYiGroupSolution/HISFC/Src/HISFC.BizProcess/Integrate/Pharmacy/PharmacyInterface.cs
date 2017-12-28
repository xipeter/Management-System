using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;

namespace Neusoft.HISFC.BizProcess.Integrate.PharmacyInterface
{
    /// <summary>
    /// [功能描述: 药品业务接口]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public interface IInpatientDrug
    {
        /// <summary>
        /// 保存前
        /// </summary>
        event System.EventHandler BeginSaveEvent;

        /// <summary>
        /// 保存后
        /// </summary>
        event System.EventHandler EndSaveEvent;

        /// <summary>
        /// 根据传入的出库申请数据，显示在控件中
        /// </summary>
        /// <param name="alApplyOut">出库申请数据</param>
        void ShowData(ArrayList alApplyOut);

        /// <summary>
        /// Check全部数据
        /// </summary>
        void CheckAll();

        /// <summary>
        /// 没有Check任何数据
        /// </summary>
        void CheckNone();

        /// <summary>
        /// 清空全部数据
        /// </summary>
        void Clear();

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>1成功，-1失败</returns>
        int Save(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage);

        /// <summary>
        /// 打印
        /// </summary>
        void Print();

        /// <summary>
        /// 预览
        /// </summary>
        void Preview();
    }

    /// <summary>
    /// 药品摆药单/标签 打印接口 
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

    /// <summary>
    /// 患者信息显示接口
    /// </summary>
    public interface IOutpatientShow
    {
        /// <summary>
        /// 需显示患者数据
        /// </summary>
        /// <param name="drugRecipe"></param>
        void ShowInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe);
    }

    /// <summary>
    /// 药品LED大屏显示接口
    /// </summary>
    public interface IOutpatientLEDShow
    {
        /// <summary>
        /// 传送数据
        /// </summary>
        /// <param name="drugRecipe">需显示数据</param>
        void SetShowData(List<Neusoft.HISFC.Models.Pharmacy.DrugRecipe> drugRecipe);

        /// <summary>
        /// 大屏幕显示
        /// </summary>
        void Show();
    }

    /// <summary>
    /// 药品入库/出库单据打印
    /// </summary>
    public interface IBillPrint
    {
        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="billNO">单据号</param>
        /// <returns></returns>
        int SetData(string billNO);

        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="alPrintData">待打印数据</param>
        /// <param name="privType">系统类型 Class3_Meaning_Code</param>
        /// <returns></returns>
        int SetData(ArrayList alPrintData, string privType);

        /// <summary>
        /// 传送打印数据
        /// </summary>
        /// <param name="alPrintData"></param>
        /// <param name="billType">enum BillType</param>
        /// <returns></returns>
        int SetData(ArrayList alPrintData, BillType billType);

        int Print();

        int Prieview();
    }

    /// <summary>
    /// 单据类型
    /// </summary>
    public enum BillType
    {
        /// <summary>
        /// 入库
        /// </summary>
        Input,
        /// <summary>
        /// 出库
        /// </summary>
        Output,
        /// <summary>
        /// 入库计划
        /// </summary>
        InPlan,
        /// <summary>
        /// 采购计划
        /// </summary>
        StockPlan,
        /// <summary>
        /// 盘点
        /// </summary>
        Check,
        /// <summary>
        /// 调价
        /// </summary>
        Adjust,
        /// <summary>
        /// 内部入库申请              //{0084F0DF-44E5-4fe9-9DBC-E92CFCDC0636} 实现内部入库申请单打印
        /// </summary>
        InnerApplyIn
    }


    /// <summary>
    /// 配置标签打印
    /// </summary>
    public interface ICompoundPrint
    {
        /// <summary>
        /// 本次打印标签总页数
        /// </summary>
        decimal LabelTotNum
        {
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
        /// 打印 组合打印 
        /// </summary>
        /// <param name="alCombo">打印组合数据</param>
        void AddCombo(ArrayList alCombo);

        /// <summary>
        /// 对所有打印数据传出
        /// </summary>
        /// <param name="al">所有待打印数据</param>
        void AddAllData(ArrayList al);

        void Clear();

        int Print();

        int Prieview();
    }

    /// <summary>
    /// 门诊打印接口工厂 通过该接口工厂返回打印接口IDrugPrint
    /// </summary>
    public interface IOutpatientPrintFactory
    {
        IDrugPrint GetInstance(Neusoft.HISFC.Models.Pharmacy.DrugTerminal terminal);
    }
}
