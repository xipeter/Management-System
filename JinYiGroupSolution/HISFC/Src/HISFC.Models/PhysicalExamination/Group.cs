using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.PhysicalExamination
{
    /// <summary>
    /// Group<br></br>
    /// [功能描述: 体检组套管理类]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-03-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Group : Neusoft.HISFC.Models.Fee.ComGroup
    {
        #region 私有变量
        /// <summary>
        /// 自费比例
        /// </summary>
        private decimal ownRate;
        /// <summary>
        /// 自付比例
        /// </summary>
        private decimal payRate;
        /// <summary>
        /// 公费比例
        /// </summary>
        private decimal pubRate;
        /// <summary>
        /// 优惠比例
        /// </summary>
        private decimal ecoRate;
        /// <summary>
        /// 是否共享
        /// </summary>
        private string isShare;
        /// <summary>
        /// 自费金额
        /// </summary>
        private decimal ownCost;
        /// <summary>
        /// 自付金额
        /// </summary>
        private decimal payCost;
        /// <summary>
        /// 公费金额
        /// </summary>
        private decimal pubCost;
        /// <summary>
        /// 优惠金额
        /// </summary>
        private decimal ecoCost;
        #endregion

        #region 属性
        /// <summary>
        /// 自负金额
        /// </summary>
        public decimal OwnCost
        {
            get
            {
                return ownCost;
            }
            set
            {
                ownCost = value;
            }
        }
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal PayCost
        {
            get
            {
                return payCost;
            }
            set
            {
                payCost = value;
            }
        }
        /// <summary>
        /// 公费金额
        /// </summary>
        public decimal PubCost
        {
            get
            {
                return pubCost;
            }
            set
            {
                pubCost = value;
            }
        }
        /// <summary>
        ///优惠金额 
        /// </summary>
        public decimal EcoCost
        {
            get
            {
                return ecoCost;
            }
            set
            {
                ecoCost = value;
            }
        }
        /// <summary>
        /// 自负比例
        /// </summary>
        public decimal OwnRate
        {
            get
            {
                return ownRate;
            }
            set
            {
                ownRate = value;
            }
        }
        /// <summary>
        /// 自付比例
        /// </summary>
        public decimal PayRate
        {
            get
            {
                return payRate;
            }
            set
            {
                payRate = value;
            }
        }
        /// <summary>
        /// 公费比例
        /// </summary>
        public decimal PubRate
        {
            get
            {
                return pubRate;
            }
            set
            {
                pubRate = value;
            }
        }
        /// <summary>
        ///优惠比例 
        /// </summary>
        public decimal EcoRate
        {
            get
            {
                return ecoRate;
            }
            set
            {
                ecoRate = value;
            }
        }
        /// <summary>
        /// 是否共享 
        /// </summary>
        public string IsShare
        {
            get
            {
                return isShare;
            }
            set
            {
                isShare = value;
            }
        }
        #endregion

        #region 克隆函数
        public new Group Clone()
        {
            Group obj = base.Clone() as Group;
            return obj;
        }
        #endregion 
    }
}
