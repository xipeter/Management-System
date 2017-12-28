using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// 门诊处方打印接口
    /// </summary>
    public interface IRecipePrint
    {
        /// <summary>
        /// 患者信息
        /// </summary>
        /// <param name="register"></param>
        void SetPatientInfo(Neusoft.HISFC.Models.Registration.Register register);

        /// <summary>
        /// 处方号
        /// </summary>
        string RecipeNO 
        { 
            get; 
            set;
        }

        /// <summary>
        /// 打印
        /// </summary>
        void PrintRecipe();
    }

    /// <summary>
    /// 门诊医生叫号接口
    /// </summary>
    public interface IDiagInDisplay
    {
        /// <summary>
        /// 患者挂号信息
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register RegInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 医生诊室
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject ObjRoom
        {
            get;
            set;
        }

        /// <summary>
        /// 医生叫号
        /// </summary>
        void DiagInDisplay();
    }

}
