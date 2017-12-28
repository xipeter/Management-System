using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// 出库类型（方向）
    /// </summary>
    public enum EnumBloodOutTrans
    {
        /// <summary>
        /// 正常出库
        /// </summary>
        NormalOut = 1,
        /// <summary>
        /// 内部出库
        /// </summary>
        InnerOut = 2,
        /// <summary>
        /// 外调
        /// </summary>
        OuterOut = 3,
        /// <summary>
        /// 作废
        /// </summary>
        Cancel = 4,
        /// <summary>
        /// 患者退库

        /// </summary>
        PatientBack,
        /// <summary>
        /// 外部退库

        /// </summary>
        OuterBack
    }


    /// <summary>
    /// 入库类型
    /// </summary>
    public enum EnumBloodInTrans : int
    {
        /// <summary>
        /// 入库
        /// </summary>
        In = 1,
        /// <summary>
        /// 退库

        /// </summary>
        Back,
    }

    public enum EnumBloodState : int
    {
        /// <summary>
        /// 申请
        /// </summary>
        Apply = 1,
        /// <summary>
        /// 配血
        /// </summary>
        Test = 2,
        /// <summary>
        /// 发血
        /// </summary>
        Send = 3,
        /// <summary>
        /// 作废
        /// </summary>
        Cancel = 4
    }


}
