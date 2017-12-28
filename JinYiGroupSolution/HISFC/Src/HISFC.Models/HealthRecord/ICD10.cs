using System;


namespace Neusoft.HISFC.Models.HealthRecord
{

    /// <summary>
    /// ICD10诊断码类<br></br>
    /// [功能描述: ICD10]<br></br>
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
    public class ICD10 : Neusoft.FrameWork.Models.NeuObject
    {
        public ICD10()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //.
        }
        #region  私有变量
        /// <summary>
        /// 疾病分类码
        /// </summary>
        private string diseaseCode;
        /// <summary>
        /// 副诊断码
        /// </summary>
        private string sICD10;
        /// <summary>
        /// 死亡原因
        /// </summary>
        private string deadReason;
        /// <summary>
        /// 标准住院日
        /// </summary>
        private int inDays;
        /// <summary>
        /// 操作员类
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        private Neusoft.FrameWork.Models.NeuObject diagnoseType = new Neusoft.FrameWork.Models.NeuObject();
        #endregion

        #region 属性
        /// <summary>
        /// 操作员类
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
        /// 疾病分类码
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
        /// 副诊断码
        /// </summary>
        public string SICD10
        {
            get
            {
                return sICD10;
            }
            set
            {
                sICD10 = value;
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
        /// 标准住院日
        /// </summary>
        public int InDays
        {
            get
            {
                return inDays;
            }
            set
            {
                inDays = value;
            }
        }
        /// <summary>
        /// 诊断类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DiagnoseType
        {
            get
            {
                return diagnoseType;
            }
            set
            {
                diagnoseType = value;
            }
        }

        public Neusoft.HISFC.Models.Base.Spell SpellCode = new Neusoft.HISFC.Models.Base.Spell();
        #endregion

        #region 函数
        public new ICD10 Clone()
        {
            ICD10 obj = base.Clone() as ICD10;
            obj.DiagnoseType = this.DiagnoseType.Clone();
            obj.SpellCode = this.SpellCode.Clone();
            return obj;
        }
        #endregion

        #region 废弃
        /// <summary>
        /// 操作时间
        /// </summary>
        [Obsolete("废弃 用 OperInfo.OperTime代替", true)]
        public DateTime OperDate;
        #endregion
    }
}
