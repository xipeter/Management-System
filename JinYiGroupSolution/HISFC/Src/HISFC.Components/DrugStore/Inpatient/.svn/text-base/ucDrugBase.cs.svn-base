using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 住院摆药基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public class ucDrugBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugBase ()
        {

        }

        #region 域变量

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        private bool isAutoPrint = false;

        /// <summary>
        /// 摆药单格式是否打印标签
        /// </summary>
        private bool isPrintLabel = false;

        /// <summary>
        /// 摆药单打印时是否需要预览
        /// </summary>
        private bool isNeedPreview = true;

        /// <summary>
        /// 显示时是否按照科室优先显示
        /// </summary>
        private bool isDeptFirst = true;

        /// <summary>
        /// 摆药药柜科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject arkDept = null;

        /// <summary>
        /// 摆药核准科室 （实际扣库科室）
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveDept = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否打印标签
        /// </summary>
        [Description("打印时是否打印标签"), Category("设置"), DefaultValue(false)]
        public bool IsPrintLabel
        {
            get
            {
                return this.isPrintLabel;
            }
            set
            {
                this.isPrintLabel = value;
            }
        }

        /// <summary>
        /// 是否自动打印摆药单
        /// </summary>
        [Description("是否自动打印摆药单"), Category("设置"), DefaultValue(false)]
        public bool IsAutoPrint
        {
            get
            {
                return this.isAutoPrint;
            }
            set
            {
                this.isAutoPrint = value;
            }
        }

        /// <summary>
        /// 摆药单打印时是否需要预览 自动打印或标签打印时该参数无效
        /// </summary>
        [Description("摆药单打印时是否需要预览 自动打印或标签打印时该参数无效"), Category("设置"), DefaultValue(true)]
        public bool IsNeedPreview
        {
            get
            {
                return this.isNeedPreview;
            }
            set
            {
                this.isNeedPreview = value;
            }
        }

        /// <summary>
        /// 显示时是否按照科室优先显示
        /// </summary>
        [Description("摆药单列表显示时 是否按照科室优先显示 该参数影响摆药通知的显示"), Category("设置"), DefaultValue(true)]
        public bool IsDeptFirst
        {
            get
            {
                return this.isDeptFirst;
            }
            set
            {
                this.isDeptFirst = value;
            }
        }

        /// <summary>
        /// 摆药药柜科室
        /// </summary>
        [Description("当前登陆药柜信息"), Category("设置"), DefaultValue(true)]
        public Neusoft.FrameWork.Models.NeuObject ArkDept
        {
            get
            {
                return this.arkDept;
            }
            set
            {
                this.arkDept = value;
            }
        }

        /// <summary>
        /// 摆药核准科室 （实际扣库科室）
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ApproveDept
        {
            get
            {
                return this.approveDept;
            }
            set
            {
                this.approveDept = value;
            }
        }

        #endregion
    }
}
