using System;
using System.Collections.Generic;
using System.Collections;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// [功能描述: 物资加价率实体]
    /// [创 建 者: Sunm]
    /// [创建时间: 2007-11-23]
    /// </summary>
    public class MaterialAddRate : Neusoft.NFC.Object.NeuObject
    {
        #region 变量

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 加价方式
        /// </summary>
        private MaterialAddRateEnumService rateKind = new MaterialAddRateEnumService();

        /// <summary>
        /// 价格下限
        /// </summary>
        private decimal priceLow;

        /// <summary>
        /// 价格上限
        /// </summary>
        private decimal priceHigh;

        /// <summary>
        /// 加价率
        /// </summary>
        private decimal addRate;

        /// <summary>
        /// 附加费
        /// </summary>
        private decimal appendFee;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 操作日期
        /// </summary>
        private DateTime operDate;

        /// <summary>
        /// 物资科目
        /// </summary>
        private Neusoft.NFC.Object.NeuObject materialKind = new Neusoft.NFC.Object.NeuObject();

        #endregion

        #region 属性

        /// <summary>
        /// 加价方式
        /// </summary>
        public MaterialAddRateEnumService RateKind
        {
            get 
            {
                return this.rateKind;
            }
            set 
            {
                this.rateKind = value;
            }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specs
        {
            get 
            {
                return this.specs;
            }
            set 
            {
                this.specs = value;
            }
        }

        /// <summary>
        /// 价格下限
        /// </summary>
        public decimal PriceLow
        {
            get 
            {
                return this.priceLow;
            }
            set
            {
                this.priceLow = value;
            }
        }

        /// <summary>
        /// 价格上限
        /// </summary>
        public decimal PriceHigh
        {
            get 
            {
                return this.priceHigh;
            }
            set 
            {
                this.priceHigh = value;
            }
        }

        /// <summary>
        /// 加价率
        /// </summary>
        public decimal AddRate
        {
            get 
            {
                return this.addRate;
            }
            set 
            {
                this.addRate = value;
            }
        }

        /// <summary>
        /// 附加费
        /// </summary>
        public decimal AppendFee
        {
            get 
            {
                return this.appendFee;
            }
            set 
            {
                this.appendFee = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.NFC.Object.NeuObject Oper
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
        /// 操作日期
        /// </summary>
        public DateTime OperDate
        {
            get 
            {
                return this.operDate;
            }
            set 
            {
                this.operDate = value;
            }
        }

        /// <summary>
        /// 物资科目
        /// </summary>
        public Neusoft.NFC.Object.NeuObject MaterialKind
        {
            get 
            {
                return this.materialKind;
            }
            set 
            {
                this.materialKind = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// Clone方法
        /// </summary>
        /// <returns></returns>
        public new MaterialAddRate Clone()
        {
            MaterialAddRate materialAddRate = base.Clone() as MaterialAddRate;

            materialAddRate.oper = this.oper.Clone();

            materialAddRate.materialKind = this.materialKind.Clone();

            return materialAddRate;
        }

        #endregion
    }

    /// <summary>
    /// 枚举
    /// </summary>
    public enum EnumRateKind
    {
        /// <summary>
        /// 不加价
        /// </summary>
        N = 0,
        /// <summary>
        /// 按规格加价
        /// </summary>
        S = 1,
        /// <summary>
        /// 按价格加价
        /// </summary>
        P = 2,
        /// <summary>
        /// 按固定加价率
        /// </summary>
        R = 3
    }

    /// <summary>
    /// 枚举
    /// </summary>
    public class MaterialAddRateEnumService : Neusoft.HISFC.Object.Base.EnumServiceBase
    {
        public MaterialAddRateEnumService()
        {
            items[EnumRateKind.N] = "不加价";
            items[EnumRateKind.S] = "按规格加价";
            items[EnumRateKind.P] = "按价格加价";
            items[EnumRateKind.R] = "按固定加价率";
        }

        #region 变量
        /// <summary>
        /// 加价方式
        /// </summary>
        EnumRateKind enumRateKind;

        /// <summary>
        /// 存储枚举定义
        /// </summary>
        protected static Hashtable items = new Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// 枚举项目
        /// </summary>
        protected override System.Enum EnumItem
        {
            get
            {
                return this.enumRateKind;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }

    }
}
