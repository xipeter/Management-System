using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 入库管理]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-4-18]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    public class BloodInputRecord : Spell, ISort, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodInputRecord()
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
        /// 血型，Hr等继承自BloodComponents
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodApply bloodApply = new BloodApply();

        /// <summary>
        /// 血液类型,单位等继承自BloodComponents
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodComponents bloodComponents = new BloodComponents();

        /// <summary>
        /// 采血者,采血日期
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment adoptBloodPerson = new OperEnvironment();

        /// <summary>
        /// 入库操作员，入库时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment bloodIntputPerson = new OperEnvironment();

        /// <summary>
        /// 血源
        /// </summary>
        private string bloodResource;

        /// <summary>
        /// 献血人
        /// </summary>
        private string bloodDonor;

        /// <summary>
        /// 储血量
        /// </summary>
        private string bloodQuality;

        /// <summary>
        /// 血袋号
        /// </summary>
        private string bloodBagNo;

        /// <summary>
        /// 血袋编码
        /// </summary>
        private string bloodBagID;

        /// <summary>
        /// 入库单号
        /// </summary>
        private string inputNo;

        /// <summary>
        /// 入库类型
        /// </summary>
        private string isInputType;

        /// <summary>
        /// 购入价
        /// </summary>
        private decimal bloodBuyPrice;

        /// <summary>
        /// 零售价
        /// </summary>
        private decimal bloodSalePrice;

        /// <summary>
        /// 金额
        /// </summary>
        private decimal bloodPrice;

        /// <summary>
        /// 失效日期
        /// </summary>
        private DateTime invalidDate;

   #endregion

        #region 属性

        /// <summary>
        /// 血型，Hr等继承自BloodComponents
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodApply BloodApply
        {
            get { return bloodApply; }
            set { bloodApply = value; }
        }

        /// <summary>
        /// 血液类型,单位等继承自BloodComponents
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodComponents BloodComponents
        {
            get { return bloodComponents; }
            set { bloodComponents = value; }
        }

        /// <summary>
        /// 入库操作员，入库时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment BloodIntputPerson
        {
            get { return bloodIntputPerson; }
            set { bloodIntputPerson = value; }
        }

        /// <summary>
        /// 采血者,采血日期
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment AdoptBloodPerson
        {
            get { return adoptBloodPerson; }
            set { adoptBloodPerson = value; }
        }

        /// <summary>
        /// 献血人
        /// </summary>
        public string BloodDonor
        {
            get { return bloodDonor; }
            set { bloodDonor = value; }
        }

        /// <summary>
        /// 储血量
        /// </summary>
        public string BloodQuality
        {
            get { return bloodQuality; }
            set { bloodQuality = value; }
        }

        /// <summary>
        /// 血源
        /// </summary>
        public string BloodResource
        {
            get { return bloodResource; }
            set { bloodResource = value; }
        }

        /// <summary>
        /// 血袋号
        /// </summary>
        public string BloodBagNo
        {
            get { return bloodBagNo; }
            set { bloodBagNo = value; }
        }

        /// <summary>
        /// 血袋编码
        /// </summary>
        public string BloodBagID
        {
            get { return bloodBagID; }
            set { bloodBagID = value; }
        }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string InputNo
        {
            get { return inputNo; }
            set { inputNo = value; }
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        public string IsInputType
        {
            get { return isInputType; }
            set { isInputType = value; }
        }

        /// <summary>
        /// 购入价
        /// </summary>
        public decimal BloodBuyPrice
        {
            get { return bloodBuyPrice; }
            set { bloodBuyPrice = value; }
        }

        /// <summary>
        /// 零售价
        /// </summary>
        public decimal BloodSalePrice
        {
            get { return bloodSalePrice; }
            set { bloodSalePrice = value; }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal BloodPrice
        {
            get { return bloodPrice; }
            set { bloodPrice = value; }
        }

        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime InvalidDate
        {
            get { return invalidDate; }
            set { invalidDate = value; }
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
        public new BloodInputRecord Clone()
        {
            BloodInputRecord bloodInputRecord = base.Clone() as BloodInputRecord;

            bloodInputRecord.BloodComponents = this.BloodComponents.Clone();
            bloodInputRecord.BloodIntputPerson = this.BloodIntputPerson.Clone();
            bloodInputRecord.AdoptBloodPerson = this.AdoptBloodPerson.Clone();
            bloodInputRecord.BloodApply = this.BloodApply.Clone();
            return bloodInputRecord;
        }
        #endregion
    }
}
