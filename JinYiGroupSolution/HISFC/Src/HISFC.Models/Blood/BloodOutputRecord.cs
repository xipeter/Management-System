using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Blood
{
    /// <summary>
    /// [功能描述: 出库管理]<br></br>
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
    public class BloodOutputRecord : Spell, ISort, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BloodOutputRecord()
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
        /// 血型，血液成分等继承自BloodApply
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodApply bloodAppy = new Neusoft.HISFC.Object.Blood.BloodApply();

        /// <summary>
        /// 住院号，门诊号等继承自病人信息
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
        
        /// <summary>
        /// 配血单号等继承自BloodMatchRecord
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodMatchRecord bloodMatchRecord = new BloodMatchRecord();

        /// <summary>
        /// 血袋号等继承自BloodInputRecord
        /// </summary>
        private Neusoft.HISFC.Object.Blood.BloodInputRecord bloodInputRecord = new BloodInputRecord();

        /// <summary>
        /// 科室编码
        /// </summary>
        private Neusoft.HISFC.Object.Base.Employee clinicNo = new Employee();

        /// <summary>
        /// 出库操作员，出库时间
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment bloodOutputPerson = new OperEnvironment();

        /// <summary>
        /// 出库单号
        /// </summary>
        private string outputNo;

        /// <summary>
        /// 出库类型
        /// </summary>
        private string bloodOutputType;

        /// <summary>
        /// 出库方向
        /// </summary>
        private string bloodOutputDirect;

        /// <summary>
        /// 出库金额
        /// </summary>
        private string bloodOutputPrice;

        #endregion

        #region 属性

        /// <summary>
        /// 血型，血液成分等继承自BloodApply
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodApply BloodAppy
        {
            get { return bloodAppy; }
            set { bloodAppy = value; }
        }
   
        /// <summary>
        /// 住院号，门诊号等继承自病人信息
        /// </summary>
        public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
        {
            get { return patientInfo; }
            set { patientInfo = value; }
        }

        /// <summary>
        /// 配血单号等继承自BloodMatchRecord
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodMatchRecord BloodMatchRecord
        {
            get { return bloodMatchRecord; }
            set { bloodMatchRecord = value; }
        }

        /// <summary>
        /// 血袋号等继承自BloodInputRecord
        /// </summary>
        public Neusoft.HISFC.Object.Blood.BloodInputRecord BloodInputRecord
        {
            get { return bloodInputRecord; }
            set { bloodInputRecord = value; }
        }

        /// <summary>
        /// 科室编码
        /// </summary>
        public Neusoft.HISFC.Object.Base.Employee ClinicNo
        {
            get { return clinicNo; }
            set { clinicNo = value; }
        }

        /// <summary>
        /// 出库操作员，出库时间
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment BloodOutputPerson
        {
            get { return bloodOutputPerson; }
            set { bloodOutputPerson = value; }
        }

        /// <summary>
        /// 出库单号
        /// </summary>
        public string OutputNo
        {
            get { return outputNo; }
            set { outputNo = value; }
        }

        /// <summary>
        /// 出库类型
        /// </summary>
        public string BloodOutputType
        {
            get { return bloodOutputType; }
            set { bloodOutputType = value; }
        }

        /// <summary>
        /// 出库方向
        /// </summary>
        public string BloodOutputDirect
        {
            get { return bloodOutputDirect; }
            set { bloodOutputDirect = value; }
        }

        /// <summary>
        /// 出库金额
        /// </summary>
        public string BloodOutputPrice
        {
            get { return bloodOutputPrice; }
            set { bloodOutputPrice = value; }
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
        public new BloodOutputRecord Clone()
        {
            BloodOutputRecord bloodOutputRecord = base.Clone() as BloodOutputRecord;

            bloodOutputRecord.BloodInputRecord = this.BloodInputRecord.Clone();
            bloodOutputRecord.BloodMatchRecord = this.BloodMatchRecord.Clone();
            bloodOutputRecord.BloodAppy = this.BloodAppy.Clone();
            bloodOutputRecord.BloodOutputPerson = this.BloodOutputPerson.Clone();
            bloodOutputRecord.ClinicNo = this.ClinicNo.Clone();
            bloodOutputRecord.PatientInfo = this.PatientInfo.Clone();
            return bloodOutputRecord;
        }
        #endregion

    }
}
