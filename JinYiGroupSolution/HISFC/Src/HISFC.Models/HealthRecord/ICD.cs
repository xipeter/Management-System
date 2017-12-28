using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// ICD<br></br>
    /// [功能描述: ICD]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-3]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ICD : Spell, IValid
    {

        public ICD()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 私有变量
        /// <summary>
        /// //序号
        /// </summary>
        private string seqNO;
        /// <summary>
        /// //医保中心代码
        /// </summary>
        private string siCode;
        /// <summary>
        /// //死亡原因
        /// </summary>
        private string deadReason;
        /// <summary>
        /// //疾病分类码
        /// </summary>
        private string diseaseCode;
        /// <summary>
        /// //标准住院日
        /// </summary>
        private int standardDays;
        /// <summary>
        /// //住院等级
        /// </summary>
        private string inpGrade;
        /// <summary>
        /// //是否30种疾病 True 是 False 不是
        /// </summary>
        private string is30Illness;
        /// <summary>
        /// //是否传染病 True 是 False 不是
        /// </summary>
        private string isInfection;
        /// <summary>
        /// //是否恶性肿瘤 True 是 False 不是
        /// </summary>
        private string isTumour;
        /// <summary>
        /// //是否有效  True 有效 False 作废
        /// </summary>
        private bool isValid;
        /// <summary>
        /// //主键,更新利用此属性
        /// </summary>
        private string keyCode;
        private bool traditionalDiag;
        /// <summary>
        /// 	//操作员信息 ID 工号 Name 姓名
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new OperEnvironment();
        /// <summary>
        /// //适用性别 
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject sexType = new NeuObject();

        #endregion

        #region 属性
        /// <summary>
        /// 中医诊断
        /// </summary>
        public bool TraditionalDiag
        {
            get
            {
                return traditionalDiag;
            }
            set 
            {
                traditionalDiag = value;
            }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public string SeqNo
        {
            get
            {
                return seqNO;
            }
            set
            {
                seqNO = value;
            }
        }

        /// <summary>
        /// 医保中心代码
        /// </summary>
        public string SICode
        {
            get
            {
                return siCode;
            }
            set
            {
                siCode = value;
            }
        }

        /// <summary>
        /// 死亡原因
        /// </summary>
        public string DeadReason
        {
            get
            {
                return deadReason;
            }
            set
            {
                deadReason = value;
            }
        }

        /// <summary>
        /// 分类疾病码
        /// </summary>
        public string DiseaseCode
        {
            get
            {
                return diseaseCode;
            }
            set
            {
                diseaseCode = value;
            }
        }

        /// <summary>
        /// 标准住院日
        /// </summary>
        public int StandardDays
        {
            get
            {
                return standardDays;
            }
            set
            {
                standardDays = value;
            }
        }

        /// <summary>
        /// 住院等级
        /// </summary>
        public string InpGrade
        {
            get
            {
                return inpGrade;
            }
            set
            {
                inpGrade = value;
            }
        }

        /// <summary>
        /// 是否30种疾病 
        /// </summary>
        public string Is30Illness
        {
            get
            {
                return is30Illness;
            }
            set
            {
                is30Illness = value;
            }
        }
        /// <summary>
        /// 是否传染病 
        /// </summary>
        public string IsInfection
        {
            get
            {
                return isInfection;
            }
            set
            {
                isInfection = value;
            }
        }

        /// <summary>
        /// 是否恶性肿瘤
        /// </summary>
        public string IsTumour
        {
            get
            {
                return isTumour;
            }
            set
            {
                isTumour = value;
            }
        }

        /// <summary>
        /// 更新利用此属性
        /// </summary>
        public string KeyCode
        {
            get
            {
                return keyCode;
            }
            set
            {
                keyCode = value;
            }
        }

        /// <summary>
        /// 操作员信息 ID 工号 Name 姓名
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        /// <summary>
        /// 适用性别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SexType
        {
            get
            {
                return sexType;
            }
            set
            {
                sexType = value; ;
            }
        }

        #endregion

        #region 克隆函数


        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new ICD Clone()
        {
            ICD icd = base.Clone() as ICD; //克隆父类
            icd.operInfo = this.operInfo.Clone(); //克隆操作员
            icd.sexType = this.sexType.Clone();

            return icd;
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

        #region 操作时间
        /// <summary>
        ///操作时间
        /// </summary>
        [Obsolete("废弃 用OperInfo.OperTime代替", true)]
        public DateTime OperDate
        {
            get
            {
                return System.DateTime.Now;
            }
        }
        #endregion
    }
}
