using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Pharmacy
{
    /// <summary>
    /// [功能描述: 门诊患者信息显示接口]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public interface IOutpatientShow
    {
        /// <summary>
        /// 需显示患者数据
        /// </summary>
        /// <param name="drugRecipe"></param>
        void ShowInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe);
    }
}
