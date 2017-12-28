using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Order
{
    /// <summary>
    /// Neusoft.HISFC.Models.Order.PharmacyLimit<br></br>
    /// [功能描述: 医嘱药品限制实体]<br></br>
    /// [创 建 者: Sunm]<br></br>
    /// [创建时间: 2007-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class PharmacyLimit : Neusoft.FrameWork.Models.NeuObject
    {
        public PharmacyLimit()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 是否需要上级医生检查
        /// </summary>
        private bool isLeaderCheck;

        /// <summary>
        /// 是否需要手工处方
        /// </summary>
        private bool isNeedRecipe;

        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 是否需要上级医生检查
        /// </summary>
        public bool IsLeaderCheck
        {
            get { return this.isLeaderCheck; }
            set { this.isLeaderCheck = value; }
        }

        /// <summary>
        /// 是否需要手工处方
        /// </summary>
        public bool IsNeedRecipe
        {
            get { return this.isNeedRecipe; }
            set { this.isNeedRecipe = value; }
        }

        /// <summary>
        /// 有效性
        /// </summary>
        public bool IsValid
        {
            get { return this.isValid; }
            set { this.isValid = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return this.remark; }
            set { this.remark = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return this.oper; }
            set { this.oper = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new PharmacyLimit Clone()
        {
            // TODO:  添加 CurePhase.Clone 实现
            PharmacyLimit obj = base.Clone() as PharmacyLimit;

            obj.oper = this.oper.Clone();

            return obj;
        }

        #endregion

    }
}
