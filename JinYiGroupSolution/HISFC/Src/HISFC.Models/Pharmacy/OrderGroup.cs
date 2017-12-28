using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 医嘱批次设置类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// </summary>
    [Serializable]
    public class OrderGroup : Neusoft.FrameWork.Models.NeuObject
    {
        public OrderGroup()
        {
 
        }

        /// <summary>
        /// 本批次医嘱开始时间指医嘱执行时间)
        /// </summary>
        private DateTime beginTime = System.DateTime.MinValue;

        /// <summary>
        /// 本批次医嘱截至时间(指医嘱执行时间)
        /// </summary>
        private DateTime endTime = System.DateTime.MaxValue;

        /// <summary>
        /// 操作时间
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = null;

        /// <summary>
        /// 本批次医嘱开始时间指医嘱执行时间)
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return this.beginTime;
            }
            set
            {
                this.beginTime = value;
            }
        }

        /// <summary>
        /// 本批次医嘱截至时间(指医嘱执行时间)
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                if (this.oper == null)
                {
                    this.oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
                }
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new OrderGroup Clone()
        {
            OrderGroup cloneOrderGroup = base.Clone() as OrderGroup;

            cloneOrderGroup.Oper = this.Oper.Clone();

            return cloneOrderGroup;
        }
    }
}
