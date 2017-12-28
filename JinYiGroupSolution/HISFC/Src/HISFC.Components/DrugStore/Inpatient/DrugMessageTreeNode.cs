using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 摆药通知节点]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008 - 04]<br></br>
    /// <说明>
    ///   {AB3B4EEB-A1C5-4a37-AD42-4EF66DF8F859}  
    /// </说明>
    /// </summary>
    public partial class DrugMessageTreeNode : System.Windows.Forms.TreeNode
    {
        private DrugMessageNodeType nodeType = DrugMessageNodeType.ApplyDept;

        /// <summary>
        /// 摆药通知节点
        /// </summary>
        internal DrugMessageNodeType NodeType
        {
            get
            {
                return this.nodeType;
            }
            set
            {
                this.nodeType = value;
            }
        }       
    }

    /// <summary>
    /// 摆药通知节点类型枚举
    /// </summary>
    internal enum DrugMessageNodeType
    {
        /// <summary>
        /// 申请科室
        /// </summary>
        ApplyDept,
        /// <summary>
        /// 摆药单
        /// </summary>
        DrugBill,
        /// <summary>
        /// 患者信息
        /// </summary>
        Patient
    }
}
