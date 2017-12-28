using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.Terminal
{
    /// <summary>
    /// {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}
    /// [功能描述：门诊病历接口显示]
    /// </summary>
    public interface IOutpatientCase
    {
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        int InitUC();

        /// <summary>
        /// 患者信息赋值
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register Register
        {
            set;
        }

        bool IsBrowse
        {
            set;
        }

        void Show();
    }
}
