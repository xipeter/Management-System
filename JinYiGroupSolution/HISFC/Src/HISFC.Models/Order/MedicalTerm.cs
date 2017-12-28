using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Order
{
    /// <summary>
    /// Neusoft.HISFC.Object.Order.IatricalTerm<br></br>
    /// [功能描述: 医嘱术语实体]<br></br>
    /// [创 建 者: Sunm]<br></br>
    /// [创建时间: 2008-06-19]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class MedicalTerm : Neusoft.HISFC.Object.Fee.Item.Undrug
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public MedicalTerm()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            this.ItemType = Neusoft.HISFC.Object.Base.EnumItemType.Term;
		}

        #region 变量
        /// <summary>
        /// 是否父子医嘱
        /// </summary>
        private bool isParent = false;
        /// <summary>
        /// 算法（排他医嘱算法）
        /// </summary>
        private string arithmetic = string.Empty;

        /// <summary>
        /// 互斥
        /// </summary>
        private string mutex = string.Empty;

        /// <summary>
        /// 术语级别
        /// </summary>
        private string termLevel = string.Empty;

        /// <summary>
        /// 约束
        /// </summary>
        private string constraints = string.Empty;

        /// <summary>
        /// 报告时限
        /// </summary>
        private int reportTimeLimit = 0;

        /// <summary>
        /// 是否需要药品
        /// </summary>
        private bool isNeedDrug = false;

        #endregion

        #region 属性
        /// <summary>
        /// 是否父子医嘱
        /// </summary>
        public bool IsParent
        {
            get
            {
                return this.isParent;
            }
            set
            {
                this.isParent = value;
            }
        }

        /// <summary>
        /// 算法（排他医嘱算法）
        /// </summary>
        public string Arithmetic
        {
            get 
            {
                return this.arithmetic;
            }
            set 
            {
                this.arithmetic = value;
            }
        }

        /// <summary>
        /// 互斥
        /// </summary>
        public string Mutex
        {
            get 
            {
                return this.mutex;
            }
            set 
            {
                this.mutex = value;
            }
        }

        /// <summary>
        /// 术语级别
        /// </summary>
        public string TermLevel
        {
            get 
            {
                return this.termLevel;
            }
            set
            {
                this.termLevel = value;
            }
        }
        
        /// <summary>
        /// 约束
        /// </summary>
        public string Constraints
        {
            get 
            {
                return this.constraints;
            }
            set 
            {
                this.constraints = value;
            }
        }

        /// <summary>
        /// 报告时限
        /// </summary>
        public int ReportTimeLimit
        {
            get { return reportTimeLimit; }
            set { reportTimeLimit = value; }
        }


        /// <summary>
        /// 是否需要药品
        /// </summary>
        public bool IsNeedDrug
        {
            get { return isNeedDrug; }
            set { isNeedDrug = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>当前类实例的副本</returns>
        public new MedicalTerm Clone()
        {
            MedicalTerm obj = base.Clone() as MedicalTerm;
            
            return obj;
        }

        #endregion
    }
}
