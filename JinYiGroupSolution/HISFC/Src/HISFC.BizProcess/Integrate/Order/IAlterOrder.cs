using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 医嘱信息处理接口]<br></br>
    /// [创 建 者: Dorian]<br></br>
    /// [创建时间: 2008－01－22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public interface IAlterOrder
    {
        /// <summary>
        /// 住院医嘱信息变更  
        /// 此方法内传入参数 orderList内没有医嘱流水号
        /// 
        /// {76FBAEE1-C996-41b4-9D77-F6CE457F6518}  更改原方法为增加保存前、保存后两个方法
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        int AlterOrderOnSaving(Neusoft.HISFC.Models.RADT.PatientInfo patient,Neusoft.FrameWork.Models.NeuObject recipeDoc,Neusoft.FrameWork.Models.NeuObject recipeDept,ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList);

        /// <summary>
        /// 住院医嘱信息变更 
        ///  {76FBAEE1-C996-41b4-9D77-F6CE457F6518}  更改原方法为增加保存前、保存后两个方法
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        int AlterOrderOnSaved(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList);

        /// <summary>
        /// 住院医嘱信息变更
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="order">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        int AlterOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc,Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.Inpatient.Order order);

        /// <summary>
        /// 住院医嘱信息变更{48E6BB8C-9EF0-48a4-9586-05279B12624D}
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc,Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.OutPatient.Order> orderList);

        /// <summary>
        /// 住院医嘱信息变更{48E6BB8C-9EF0-48a4-9586-05279B12624D}
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="order">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc,Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.OutPatient.Order order);
    }
}
