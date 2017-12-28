using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 月结管理]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-4-19]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class BloodStoreMonthRecord : Spell, ISort, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodStoreMonthRecord()
        {
        }

        #region 字段

        /// <summary>
        /// ISort
        /// </summary>
        private int iSort;

        /// <summary>
        /// IValid
        /// </summary>
        private bool iValid;

        /// <summary>
        ///  操作员，操作时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment bloodStoreMonthOperator = new OperEnvironment();

        /// <summary>
        ///  血液成分，血型
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodComponents bloodStoreMonthType = new BloodComponents();

        /// <summary>
        /// 单位
        /// </summary>
        private string stockUnit;

        /// <summary>
        /// 月结截至时间
        /// </summary>
        private DateTime bloodToDate;

        /// <summary>
        /// 上期期末库存数量
        /// </summary>
        private decimal bloodLastMonthNum;

        /// <summary>
        /// 本期入库购入数量
        /// </summary>
        private decimal bloodThisMonthNum;

        /// <summary>
        /// 本期期末库存购入数量
        /// </summary>
        private decimal bloodThisLastMonthNum;

        /// <summary>
        /// 上期期末库存最小包装数量单价
        /// </summary>
        private decimal bloodLastMinPrice;

        /// <summary>
        /// 本期入库购入单价
        /// </summary>
        private decimal bloodThisSinglePrice;
 
        /// <summary>
        /// 本期期末库存购入单价
        /// </summary>
        private decimal bloodThisLastSinglePrice;

        /// <summary>
        /// 上期期末库存购入金额
        /// </summary>
        private decimal bloodLastBuyPrice;

        /// <summary>
        /// 本期入库购入金额
        /// </summary>
        private decimal bloodThisBuyPrice;

        /// <summary>
        /// 本期期末库存购入金额
        /// </summary>
        private decimal bloodThisLastBuyPrice;

        /// <summary>
        /// 上期期末库存零售金额
        /// </summary>
        private decimal bloodLastSalePrice;

        /// <summary>
        /// 本期入库零售金额
        /// </summary>
        private decimal bloodThisSalePrice;

        /// <summary>
        /// 本期期末库存零售金额
        /// </summary>
        private decimal bloodThisLastSalePrice;

        #endregion

        #region 属性
        /// <summary>
        ///  操作员，操作时间
        /// </summary>

        public Neusoft.HISFC.Object.Base.OperEnvironment BloodStoreMonthOperator
        {
            get { return bloodStoreMonthOperator; }
            set { bloodStoreMonthOperator = value; }
        }

        /// <summary>
        ///  血液成分，血型
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodComponents BloodStoreMonthType
        {
            get { return bloodStoreMonthType; }
            set { bloodStoreMonthType = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string StockUnit
        {
            get { return stockUnit; }
            set { stockUnit = value; }
        }

        /// <summary>
        /// 月结截至时间
        /// </summary>
        public DateTime BloodToDate
        {
            get { return bloodToDate; }
            set { bloodToDate = value; }
        }

        /// <summary>
        /// 上期期末库存数量
        /// </summary>
        public decimal BloodLastMonthNum
        {
            get { return bloodLastMonthNum; }
            set { bloodLastMonthNum = value; }
        }

        /// <summary>
        /// 本期入库购入数量
        /// </summary>
        public decimal BloodThisMonthNum
        {
            get { return bloodThisMonthNum; }
            set { bloodThisMonthNum = value; }
        }

        /// <summary>
        /// 本期期末库存购入数量
        /// </summary>
        public decimal BloodThisLastMonthNum
        {
            get { return bloodThisLastMonthNum; }
            set { bloodThisLastMonthNum = value; }
        }

        /// <summary>
        /// 上期期末库存最小包装数量单价
        /// </summary>
        public decimal BloodLastMinPrice
        {
            get { return bloodLastMinPrice; }
            set { bloodLastMinPrice = value; }
        }

        /// <summary>
        /// 本期入库购入单价
        /// </summary>
        public decimal BloodThisSinglePrice
        {
            get { return bloodThisSinglePrice; }
            set { bloodThisSinglePrice = value; }
        }

        /// <summary>
        /// 本期期末库存购入单价
        /// </summary>
        public decimal BloodThisLastSinglePrice
        {
            get { return bloodThisLastSinglePrice; }
            set { bloodThisLastSinglePrice = value; }
        }

        /// <summary>
        /// 上期期末库存购入金额
        /// </summary>
        public decimal BloodLastBuyPrice
        {
            get { return bloodLastBuyPrice; }
            set { bloodLastBuyPrice = value; }
        }

        /// <summary>
        /// 本期入库购入金额
        /// </summary>
        public decimal BloodThisBuyPrice
        {
            get { return bloodThisBuyPrice; }
            set { bloodThisBuyPrice = value; }
        }

        /// <summary>
        /// 本期期末库存购入金额
        /// </summary>
        public decimal BloodThisLastBuyPrice
        {
            get { return bloodThisLastBuyPrice; }
            set { bloodThisLastBuyPrice = value; }
        }

        /// <summary>
        /// 上期期末库存零售金额
        /// </summary>
        public decimal BloodLastSalePrice
        {
            get { return bloodLastSalePrice; }
            set { bloodLastSalePrice = value; }
        }

        /// <summary>
        /// 本期入库零售金额
        /// </summary>
        public decimal BloodThisSalePrice
        {
            get { return bloodThisSalePrice; }
            set { bloodThisSalePrice = value; }
        }

        /// <summary>
        /// 本期期末库存零售金额
        /// </summary>
        public decimal BloodThisLastSalePrice
        {
            get { return bloodThisLastSalePrice; }
            set { bloodThisLastSalePrice = value; }
        }

        #endregion

        #region ISort 成员

        public int SortID
        {
            get
            {
                return iSort;
            }
            set
            {
                this.iSort = value;
            }
        }

        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return iValid;
            }
            set
            {
                this.iValid = value;
            }
        }

        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new BloodStoreMonthRecord Clone()
        {
            BloodStoreMonthRecord bloodStoreMonthRecord = base.Clone() as BloodStoreMonthRecord;

            bloodStoreMonthRecord.BloodStoreMonthOperator = this.BloodStoreMonthOperator.Clone();
            bloodStoreMonthRecord.BloodStoreMonthType = this.BloodStoreMonthType.Clone();

            return bloodStoreMonthRecord;
        }
        #endregion
    }
}
