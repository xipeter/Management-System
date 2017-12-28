using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Interface.Common
{
    /// <summary>
    /// 获取项目扩展信息接口
    /// 此接口使用于医嘱项目列表中
    /// </summary>
    public interface IItemExtendInfo
    {
        /// <summary>
        /// 项目类别
        /// </summary>
        Neusoft.HISFC.Models.Base.EnumItemType ItemType
        {
            get;
            set;
        }

        /// <summary>
        /// 合同单位信息
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject PactInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 取扩展信息
        /// </summary>
        /// <param name="ItemID">项目编码</param>
        /// <param name="ExtendInfoTxt">返回扩展信息文本</param>
        /// <param name="AlExtendInfo">返回扩展信息数组</param>
        /// <returns></returns>
        int GetItemExtendInfo(string ItemID, ref string ExtendInfoTxt, ref ArrayList AlExtendInfo);

    }
}
