using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 配血管理]<br></br>
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
    
    public class BloodMatchRecord : Spell,ISort,IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodMatchRecord()
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
        /// 申请单号等继承自BloodApply
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodApply bloodApply = new BloodApply();

        /// <summary>
        /// 血袋编码,献血人等继承自BloodInputRecord
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodInputRecord bloodInputRecord = new BloodInputRecord();

        /// <summary>
        /// 病人信息
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
    
        /// <summary>
        /// 配血单号
        /// </summary>
        private string bloodMatchNo;

        /// <summary>
        /// 库存血袋号
        /// </summary>
        private string bloodBagNo;

        /// <summary>
        /// 输血性质
        /// </summary>
        private string bloodInType;

        /// <summary>
        /// 输血时间
        /// </summary>
        private string bloodInTime;

        /// <summary>
        /// 受血者血型
        /// </summary>
        private string bloodInPersonType;

        /// <summary>
        /// 复检血型
        /// </summary>
        private string bloodCheckType;

        /// <summary>
        /// 采血日期
        /// </summary>
        private DateTime adoptBloodDate;

        /// <summary>
        /// 有效日期
        /// </summary>
        private DateTime validDate;

        /// <summary>
        /// 单位
        /// </summary>
        private string stockUnit;

        /// <summary>
        /// 状态
        /// </summary>
        private string bloodStatic;

        /// <summary>
        /// 血源
        /// </summary>
        private string bloodSource;

        /// <summary>
        /// 交叉配血
        /// </summary>
        private bool isCrossMatchBlood;

        /// <summary>
        /// 不规则抗体筛选
        /// </summary>
        private bool isantifilterFlag;
 

        /// <summary>
        /// 配血者,配血时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment matchBloodOperator = new OperEnvironment();

        /// <summary>
        /// 复检者
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment matchBloodOperator2 = new OperEnvironment();

        /// <summary>
        /// 发血人，发血时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment bloodOutputPerson = new OperEnvironment();

        /// <summary>
        /// 病人资料
        /// </summary>
        private Object.Base.Item item = new Neusoft.HISFC.Object.Base.Item();

        #endregion

        #region 属性

        /// <summary>
        /// 病人信息
        /// </summary>
        public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
        {
            get { return patientInfo; }
            set { patientInfo = value; }
        } 

        /// <summary>
        /// 申请单号
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodApply BloodApply
        {
            get { return bloodApply; }
            set { bloodApply = value; }
        }

        /// <summary>
        /// 血袋编码,献血人等继承自BloodMatchRecord
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodInputRecord BloodInputRecord
        {
            get { return bloodInputRecord; }
            set { bloodInputRecord = value; }
        }

        /// <summary>
        /// 配血者,配血时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment MatchBloodOperator
        {
            get { return matchBloodOperator; }
            set { matchBloodOperator = value; }
        }

        /// <summary>
        /// 复检者
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment MatchBloodOperator2
        {
            get { return matchBloodOperator2; }
            set { matchBloodOperator2 = value; }
        }

        /// <summary>
        /// 发血人，发血时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment BloodOutputPerson
        {
            get { return bloodOutputPerson; }
            set { bloodOutputPerson = value; }
        }

        /// <summary>
        /// 配血单号
        /// </summary>
        public string BloodMatchNo
        {
            get { return bloodMatchNo; }
            set { bloodMatchNo = value; }
        }

        /// <summary>
        /// 库存血袋号
        /// </summary>
        public string BloodBagNo
        {
            get { return bloodBagNo; }
            set { bloodBagNo = value; }
        }

        /// <summary>
        /// 受血者血型
        /// </summary>
        public string BloodInPersonType
        {
            get { return bloodInPersonType; }
            set { bloodInPersonType = value; }
        }

        /// <summary>
        /// 复检血型
        /// </summary>
        public string BloodCheckType
        {
            get { return bloodCheckType; }
            set { bloodCheckType = value; }
        }

        /// <summary>
        /// 输血时间
        /// </summary>
        public string BloodInTime
        {
            get { return bloodInTime; }
            set { bloodInTime = value; }
        }

        /// <summary>
        /// 输血性质
        /// </summary>
        public string BloodInType
        {
            get { return bloodInType; }
            set { bloodInType = value; }
        }

        /// <summary>
        /// 采血日期
        /// </summary>
        public DateTime AdoptBloodDate
        {
            get { return adoptBloodDate; }
            set { adoptBloodDate = value; }
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
        /// 状态
        /// </summary>
        public string BloodStatic
        {
            get { return bloodStatic; }
            set { bloodStatic = value; }
        }

        /// <summary>
        /// 血源
        /// </summary>
        public string BloodSource
        {
            get { return bloodSource; }
            set { bloodSource = value; }
        }

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidDate
        {
            get { return validDate; }
            set { validDate = value; }
        }

        /// <summary>
        /// 交叉配血
        /// </summary>
        public bool IsCrossMatchBlood
        {
            get { return isCrossMatchBlood; }
            set { isCrossMatchBlood = value; }
        }

        /// <summary>
        /// 不规则抗体筛选 
        /// </summary>
        public bool IsantifilterFlag
        {
            get { return isantifilterFlag; }
            set { isantifilterFlag = value; }
        }

        /// <summary>
        /// 病人资料
        /// </summary>
        public Object.Base.Item Item
        {
            get { return item; }
            set { item = value; }
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
        public new BloodMatchRecord Clone()
        {
            BloodMatchRecord bloodMatchRecord = base.Clone() as BloodMatchRecord;

            bloodMatchRecord.PatientInfo = this.PatientInfo.Clone();
            bloodMatchRecord.BloodApply = this.BloodApply.Clone();
            bloodMatchRecord.MatchBloodOperator = this.MatchBloodOperator.Clone();
            bloodMatchRecord.MatchBloodOperator2 = this.MatchBloodOperator2.Clone();
            bloodMatchRecord.BloodOutputPerson = this.BloodOutputPerson.Clone();
            bloodMatchRecord.BloodInputRecord = this.BloodInputRecord.Clone();
            bloodMatchRecord.Item = this.Item.Clone();
            return bloodMatchRecord;
        }
        #endregion
    }
}
