using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 存储管理]<br></br>
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
    public class BloodStoreRecord : Spell, ISort, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodStoreRecord()
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
        /// 配血状态
        /// </summary>
        private bool isMatched;

        /// <summary>
        /// 储血号
        /// </summary>
        private string bloodStoreId;

        /// <summary>
        /// 继承自BloodApply的属性
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodApply bloodApply = new BloodApply();

        /// <summary>
        /// 继承自BloodOutputRecord的属性
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodInputRecord bloodInputRecord = new BloodInputRecord();

        /// <summary>
        /// 操作员，操作时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment bloodStoreOperator = new OperEnvironment();

        #endregion

        #region 属性

 

        /// <summary>
        /// 储血号
        /// </summary>
        public string BloodStoreId
        {
            get { return bloodStoreId; }
            set { bloodStoreId = value; }
        }

        /// <summary>
        /// 操作员，操作时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment BloodStoreOperator
        {
            get { return bloodStoreOperator; }
            set { bloodStoreOperator = value; }
        }

        /// <summary>
        /// 继承自BloodInputRecord的属性
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodInputRecord BloodInputRecord
        {
            get { return bloodInputRecord; }
            set { bloodInputRecord = value; }
        }

        /// <summary>
        /// 继承自BloodApply的属性
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodApply BloodApply
        {
            get { return bloodApply; }
            set { bloodApply = value; }
        }

        /// <summary>
        /// 配血状态
        /// </summary>
        public bool IsMatched
        {
            get { return isMatched; }
            set { isMatched = value; }
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
        public new BloodStoreRecord Clone()
        {
            BloodStoreRecord bloodStoreRecord = base.Clone() as BloodStoreRecord;

            bloodStoreRecord.BloodInputRecord = this.BloodInputRecord.Clone();

            return bloodStoreRecord;
        }
        #endregion

    }
}
