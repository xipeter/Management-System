using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// [功能描述: 生产工艺流程记录]<br></br>
    /// [创 建 者: liangjz]<br></br>
    /// [创建时间: 2007-11]<br></br>
    /// </summary>
    [Serializable]
    public class Process : Neusoft.FrameWork.Models.NeuObject
    {
        public Process()
        {

        }

        #region 域变量

        /// <summary>
        /// 制剂管理信息
        /// </summary>
        private Neusoft.HISFC.Models.Preparation.Preparation preparation = new Preparation();

        /// <summary>
        /// 工艺流程项目
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject processItem = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 流程执行结果值
        /// </summary>
        private decimal resultQty;

        /// <summary>
        /// 流程执行描述
        /// </summary>
        private string resultStr;

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 扩展值
        /// </summary>
        private string extend;

        /// <summary>
        /// 项目类别
        /// </summary>
        private string itemType;

        /// <summary>
        /// 是否合格
        /// </summary>
        private bool isEligibility;
        #endregion

        #region 属性

        /// <summary>
        /// 制剂管理信息
        /// </summary>
        public Neusoft.HISFC.Models.Preparation.Preparation Preparation
        {
            get
            {
                return this.preparation;
            }
            set
            {
                this.preparation = value;
            }

        }

        /// <summary>
        /// 工艺流程项目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ProcessItem
        {
            get
            {
                return this.processItem;
            }
            set
            {
                this.processItem = value;
            }
        }

        /// <summary>
        /// 流程执行结果值
        /// </summary>
        public decimal ResultQty
        {
            get
            {
                return this.resultQty;
            }
            set
            {
                this.resultQty = value;
            }
        }

        /// <summary>
        /// 流程执行描述
        /// </summary>
        public string ResultStr
        {
            get
            {
                return this.resultStr;
            }
            set
            {
                this.resultStr = value;
            }
        }

        /// <summary>
        /// 操作环境信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 扩展值
        /// </summary>
        public string Extend
        {
            get
            {
                return this.extend;
            }
            set
            {
                this.extend = value;
            }
        }

        /// <summary>
        /// 项目类别
        /// </summary>
        public string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        /// <summary>
        /// 是否合格
        /// </summary>
        public bool IsEligibility
        {
            get
            {
                return this.isEligibility;
            }
            set
            {
                this.isEligibility = value;
            }
        }

        #endregion

        #region 方法

        public new Process Clone()
        {
            Process p = base.Clone() as Process;

            p.preparation = this.preparation.Clone();
            p.processItem = this.processItem.Clone();
            p.oper = this.oper.Clone();

            return p;
        }

        #endregion
    }
}
