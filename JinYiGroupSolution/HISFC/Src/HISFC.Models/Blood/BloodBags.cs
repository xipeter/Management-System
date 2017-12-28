using System;
using System.Collections.Generic;
using System.Text;


namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血袋信息]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-05]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		1、ID 血袋编码

    ///		2、献血人员信息 包括献血日期
    /// </说明>
    /// </summary>
    /// 

    [System.Serializable]
    public class BloodBags : Neusoft.FrameWork.Models.NeuObject
    {
        public BloodBags()
        {

        }


        #region 域变量


        /// <summary>
        /// 血袋号
        /// </summary>
        private string bloodCode;

        /// <summary>
        /// 血型

        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind bloodType = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 血液成分

        /// </summary>
        private Neusoft.HISFC.Models.Blood.BloodComponents bloodCompoent = new Neusoft.HISFC.Models.Blood.BloodComponents();

        /// <summary>
        /// RH
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult rh = Neusoft.HISFC.Models.Base.EnumTestResult.待查;

        /// <summary>
        /// 储血量

        /// </summary>
        private decimal quality;

        /// <summary>
        /// 单位
        /// </summary>
        private string baseUnit;

        /// <summary>
        /// 购入价

        /// </summary>
        private decimal purchasePrice;

        /// <summary>
        /// 零售价

        /// </summary>
        private decimal tradePrice;

        /// <summary>
        /// 献血人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment donor = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 来源
        /// </summary>
        private string source;

        /// <summary>
        /// 失效日期
        /// </summary>
        private DateTime invalidDate;

        /// <summary>
        /// 采血日期
        /// </summary>
        private DateTime gatherDate;

        #endregion

        #region 属性


        /// <summary>
        /// 血袋号
        /// </summary>
        public string BloodCode
        {
            get
            {
                return this.bloodCode;
            }
            set
            {
                this.bloodCode = value;
            }
        }


        /// <summary>
        /// 血型

        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind BloodKind
        {
            get
            {
                return this.bloodType;
            }
            set
            {
                this.bloodType = value;
            }
        }


        /// <summary>
        /// 血液成分

        /// </summary>
        public Neusoft.HISFC.Models.Blood.BloodComponents BloodCompoent
        {
            get
            {
                return this.bloodCompoent;
            }
            set
            {
                this.bloodCompoent = value;
            }
        }


        /// <summary>
        /// RH
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult RH
        {
            get
            {
                return this.rh;
            }
            set
            {
                this.rh = value;
            }
        }


        /// <summary>
        /// 储血量

        /// </summary>
        public decimal Quality
        {
            get
            {
                return this.quality;
            }
            set
            {
                this.quality = value;
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
        /// 购入价

        /// </summary>
        public decimal PurchasePrice
        {
            get
            {
                return this.purchasePrice;
            }
            set
            {
                this.purchasePrice = value;
            }
        }


        /// <summary>
        /// 零售价

        /// </summary>
        public decimal TradePrice
        {
            get
            {
                return this.tradePrice;
            }
            set
            {
                this.tradePrice = value;
            }
        }

        /// <summary>
        /// 献血人员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Donor
        {
            get
            {
                return this.donor;
            }
            set
            {
                this.donor = value;
            }
        }


        /// <summary>
        /// 采血日期
        /// </summary>
        public DateTime GatherDate
        {
            get
            {
                return this.gatherDate;
            }
            set
            {
                this.gatherDate = value;
            }
        }


        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }


        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime ValidDate
        {
            get
            {
                return this.invalidDate;
            }
            set
            {
                this.invalidDate = value;
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new BloodBags Clone()
        {
            BloodBags bloodBags = base.Clone() as BloodBags;

            bloodBags.BloodCompoent = this.bloodCompoent.Clone();

            bloodBags.donor = this.donor.Clone();

            return bloodBags;
        }

        #endregion

    }
}
