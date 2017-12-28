using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Preparation.Dininfect
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂原材料消耗(供应室)]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///    1、制剂材料扣库实现
    ///    2、对不足库存原材料自动形成申请计划
    ///    3、根据入库设置。增加成品库存或形成成品入库申请
    ///    4、消耗信息根据物资出库数据获取
    /// </说明>
    /// </summary>
    public partial class ucExpandManager : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucExpandManager()
        {
            InitializeComponent();
        }

        #region 枚举

        private enum ExpandColumnSet
        {
            /// <summary>
            /// 原料名称
            /// </summary>
            ColMaterialName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 单价
            /// </summary>
            ColPrice,
            /// <summary>
            /// 标准处方量
            /// </summary>
            ColNormativeQty,
            /// <summary>
            /// 理论消耗量
            /// </summary>
            ColPlanExpand,
            /// <summary>
            /// 库存量
            /// </summary>
            ColStore,
            /// <summary>
            /// 实际消耗量
            /// </summary>
            ColFactualExpand,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo
        }

        #endregion
    }
}
