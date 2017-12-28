using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.InterFacePassWord
{
    public interface IPassWord
    {
        //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
        ///// <summary>
        ///// 验证密码
        ///// </summary>
        ///// <returns></returns>
        //bool ValidPassWord
        //{
        //    get;
        //}
        ///// <summary>
        ///// 门诊卡号
        ///// </summary>
        //string CardNO
        //{
        //    get;
        //    set;
        //}
        ///// <summary>
        ///// 是否验证密码
        ///// </summary>
        //bool IsOK
        //{
        //    get;
        //}
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <returns></returns>
        bool ValidPassWord
        {
            get;
        }
        /// <summary>
        /// 门诊卡号
        /// </summary>
        Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get;
            set;
        }
        /// <summary>
        /// 是否验证密码
        /// </summary>
        bool IsOK
        {
            get;
        }
    }
}
