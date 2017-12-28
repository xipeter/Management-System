using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 门诊打印接口工厂 通过该接口工厂返回打印接口IDrugPrint]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public interface IOutpatientPrintFactory
    {
        IDrugPrint GetInstance(Neusoft.HISFC.Models.Pharmacy.DrugTerminal terminal);
    }
}
