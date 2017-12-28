using System;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// ICDCompare诊断码类<br></br>
    /// [功能描述: ICDCompare]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ICDCompare : NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        public ICDCompare()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region  私有变量
        private ICD icd10 = new ICD(); //承载ICD10信息
        private ICD icd9 = new ICD();  //承载ICD9信息
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();  //操作员信息, ID 编码 Name 姓名
        private bool isValid; //有效性标识

        #endregion

        #region  公有属性


        public ICD ICD10
        {
            //承载ICD10信息
            get
            {
                return icd10;
            }
            set
            {
                icd10 = value;
            }
        }
        public ICD ICD9
        {
            //承载ICD9信息
            get
            {
                return icd9;
            }
            set
            {
                icd9 = value;
            }
        }
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            //操作人 信息
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        #endregion

        #region 函数

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new ICDCompare Clone()
        {
            //克隆函数
            ICDCompare icdCompare = base.Clone() as ICDCompare; // 克隆父类
            icdCompare.operInfo = operInfo.Clone(); //克隆
            icdCompare.icd10 = icd10.Clone(); //克隆CD10信息 操作员信息
            icdCompare.icd9 = icd9.Clone(); //克隆CD9信息
            return icdCompare;
        }
        #endregion

        #region IValid 成员

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

        #endregion

        #region 废弃
        [Obsolete("废弃 用OperInfo.OperTime代替")]
        private DateTime operDate;                   //录入时间
        [Obsolete("废弃 用OperInfo.OperTime代替", true)]
        public DateTime OperDate
        {
            //操作时间
            get
            {
                return operDate;
            }
            set
            {
                operDate = value;
            }
        }
        #endregion
    }
}
