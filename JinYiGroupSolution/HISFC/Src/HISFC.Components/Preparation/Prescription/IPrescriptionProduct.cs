using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Preparation.Prescription
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成品处方维护－成品操作接口类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public interface IPrescriptionProduct
    {
        /// <summary>
        /// 明细检索事件
        /// </summary>
        event System.EventHandler ShowPrescriptionEvent;

        /// <summary>
        /// 增加成品
        /// </summary>
        /// <returns></returns>
        int AddProduct();

        /// <summary>
        /// 成品信息显示
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int ShowProduct(Neusoft.FrameWork.Models.NeuObject product);

        /// <summary>
        /// 删除成品
        /// </summary>
        /// <returns></returns>
        int DeleteProduct();

        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns></returns>
        int Clear();

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
