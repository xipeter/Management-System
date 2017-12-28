using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 配置标签打印 ]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
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
}
