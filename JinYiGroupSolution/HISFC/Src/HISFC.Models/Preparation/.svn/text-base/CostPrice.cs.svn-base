using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// [功能描述: 制剂加价公式信息类]<br></br>
    /// [创 建 者: Dorian]<br></br>
    /// [创建时间: 2008-04-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class CostPrice : Neusoft.FrameWork.Models.NeuObject
    {
        public CostPrice()
        {

        }

        #region 域变量

        /// <summary>
        /// 成品(药品)信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item drugItem = new Neusoft.HISFC.Models.Pharmacy.Item();

        /// <summary>
        /// 成本价计算公式
        /// </summary>
        private string costPriceFormula;

        /// <summary>
        /// 零售价计算公式
        /// </summary>
        private string salePriceFormula;

        /// <summary>
        /// 公式来源
        /// </summary>
        private string priceSource;

        /// <summary>
        /// 成本利润率
        /// </summary>
        private decimal priceRate;

        /// <summary>
        /// 扩展信息
        /// </summary>
        private string extend;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        /// <summary>
        ///包装单位 
        /// </summary>
        private string pactUnit;
       

        /// <summary>
        /// 包装数量
        /// </summary>
        private int pactQty;
       
        /// <summary>
        /// 最小单位
        /// </summary>
        private string minUnit;
       

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;
       
        #endregion

        #region 属性

        /// <summary>
        /// 成品(药品)信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item DrugItem
        {
            get
            {
                return this.drugItem;
            }
            set
            {
                this.drugItem = value;
            }
        }

        /// <summary>
        /// 成本价计算公式
        /// </summary>
        public string CostPriceFormula
        {
            get
            {
                return this.costPriceFormula;
            }
            set
            {
                this.costPriceFormula = value;
            }
        }

        /// <summary>
        /// 零售价计算公式
        /// </summary>
        public string SalePriceFormula
        {
            get
            {
                return this.salePriceFormula;
            }
            set
            {
                this.salePriceFormula = value;
            }
        }

        /// <summary>
        /// 公式来源
        /// </summary>
        public string PriceSource
        {
            get
            {
                return this.priceSource;
            }
            set
            {
                this.priceSource = value;
            }
        }

        /// <summary>
        /// 成本利润率
        /// </summary>
        public decimal PriceRate
        {
            get
            {
                return this.priceRate;
            }
            set
            {
                this.priceRate = value;
            }
        }

        /// <summary>
        /// 扩展信息
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
        /// 操作员
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
        ///包装单位 
        /// </summary>
        public string PactUnit
        {
            get
            {
                return pactUnit;
            }
            set
            {
                pactUnit = value;
            }
        }

        /// <summary>
        /// 包装数量
        /// </summary>
        public int PactQty
        {
            get
            {
                return pactQty;
            }
            set
            {
                pactQty = value;
            }
        }
        /// <summary>
        /// 最小单位
        /// </summary>
        public string MinUnit
        {
            get
            {
                return minUnit;
            }
            set
            {
                minUnit = value;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specs
        {
            get
            {
                return specs;
            }
            set
            {
                specs = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回克隆后的实体 失败返回null</returns>
        public new CostPrice Clone()
        {
            CostPrice c = base.Clone() as CostPrice;

            c.oper = this.oper.Clone();
            c.drugItem = this.drugItem.Clone();

            return c;
        }

        #endregion

    }
}
