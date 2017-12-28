using System;

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血液成分实体]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2007-4-17]<br></br>
    /// <修改记录
    ///		修改人='王彦'
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    [System.Serializable]
	public class BloodComponents : Neusoft.HISFC.Models.Base.Spell {

		public BloodComponents()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region

        /// <summary>
        /// 序号
        /// </summary>
        private int order;

        /// <summary>
        /// 是否需要配血 
        /// </summary>
        private bool isNeedMixed;

        /// <summary>
        /// 保存天数
        /// </summary>
        private int keepingDays;

        /// <summary>
        /// 贮存温度
        /// </summary>
        private decimal keepingTemperature;

        /// <summary>
        /// 单位
        /// </summary>
        private string baseUnit;

        /// <summary>
        /// 最小计费数量
        /// </summary>
        private decimal minAmount;

        /// <summary>
        /// 购入价
        /// </summary>
        private decimal tradePrice;

        /// <summary>
        /// 零售价
        /// </summary>
        private decimal salePrice;

        /// <summary>
        /// 申请单有效天数 0 为一直有效
        /// </summary>
        private int applyValidDays;

        /// <summary>
        /// 是否有效 true有效 false无效
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 操作人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 序号
        /// </summary>
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }


        /// <summary>
        /// 是否需要配血 true 需要 fase 不需要
        /// </summary>
        public bool IsNeedMixed
        {
            get
            {
                return isNeedMixed;
            }
            set
            {
                isNeedMixed = value;
            }
        }


        /// <summary>
        /// 保存天数
        /// </summary>
        public int KeepingDays
        {
            get
            {
                return keepingDays;
            }
            set
            {
                keepingDays = value;
            }
        }


        /// <summary>
        /// 贮存温度
        /// </summary>
        public decimal KeepingTemperature
        {
            get
            {
                return keepingTemperature;
            }
            set
            {
                keepingTemperature = value;
            }
        }


        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                return this.baseUnit;
            }
            set
            {
                this.baseUnit = value;
            }
        }


        /// <summary>
        /// 最小计费数量
        /// </summary>
        public decimal MinAmount
        {
            get
            {
                return minAmount;
            }
            set
            {
                minAmount = value;
            }
        }


        /// <summary>
        /// 购入价
        /// </summary>
        public decimal TradePrice
        {
            get
            {
                return tradePrice;
            }
            set
            {
                tradePrice = value;
            }
        }


        /// <summary>
        /// 零售价
        /// </summary>
        public decimal SalePrice
        {
            get
            {
                return salePrice;
            }
            set
            {
                salePrice = value;
            }
        }


        /// <summary>
        /// 申请单有效天数 0 为一直有效
        /// </summary>
        public int ApplyValidDays
        {
            get
            {
                return applyValidDays;
            }
            set
            {
                applyValidDays = value;
            }
        }


        /// <summary>
        /// 是否有效 true有效 false无效
        /// </summary>
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }


        /// <summary>
        /// 操作员信息 ID 编号 Name 姓名
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }


        #endregion

        //#region ISpellCode 成员

        ///// <summary>
        ///// 拼音码
        ///// </summary>
        //private string spellCode;

        ///// <summary>
        ///// 五笔码
        ///// </summary>
        //private string wbCode;

        ///// <summary>
        ///// 自定义码
        ///// </summary>
        //private string userCode;

        ///// <summary>
        ///// 拼音码
        ///// </summary>
        //public string Spell_Code
        //{
        //    get
        //    {
        //        return spellCode;
        //    }
        //    set
        //    {
        //        spellCode = value;
        //    }
        //}


        ///// <summary>
        ///// 五笔码
        ///// </summary>
        //public string WB_Code
        //{
        //    get
        //    {
        //        return wbCode;
        //    }
        //    set
        //    {
        //        wbCode = value;
        //    }
        //}


        ///// <summary>
        ///// 自定义码
        ///// </summary>
        //public string User_Code
        //{
        //    get
        //    {
        //        return userCode;
        //    }
        //    set
        //    {
        //        userCode = value;
        //    }
        //}


        //#endregion

        #region Clone函数

        /// <summary>
        /// Clone实体本身
        /// </summary>
        /// <returns></returns>
        public new BloodComponents Clone()
        {
            BloodComponents clone = base.Clone() as BloodComponents;

            clone.operInfo = this.operInfo.Clone();

            return clone;
        }

        #endregion
	}
}
