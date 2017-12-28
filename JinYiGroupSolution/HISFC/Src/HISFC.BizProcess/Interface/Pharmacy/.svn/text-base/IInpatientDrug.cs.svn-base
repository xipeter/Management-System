using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 住院摆药业务接口]<br></br>
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
}
