using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Preparation.Prescription
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成品处方维护－原材料操作接口类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public interface IPrescriptionMaterial
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        int AddMaterial();

        /// <summary>
        /// 原材料信息显示
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int ShowMaterial(Neusoft.FrameWork.Models.NeuObject product);

        /// <summary>
        /// 原材料删除
        /// </summary>
        /// <returns></returns>
        int DeleteMaterial();

        /// <summary>
        /// 原材料清空
        /// </summary>
        /// <returns></returns>
        int Clear();

        /// <summary>
        /// 原材料信息获取(由界面获取数据)
        /// </summary>
        /// <returns></returns>
        List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> GetMaterial();

        /// <summary>
        /// 界面展现UI
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.ucBaseControl ProductControl
        {
            get;
        }

        /// <summary>
        /// 项目类别
        /// </summary>
        Neusoft.HISFC.Models.Base.EnumItemType ItemType
        {
            set;
        }
    }
}
