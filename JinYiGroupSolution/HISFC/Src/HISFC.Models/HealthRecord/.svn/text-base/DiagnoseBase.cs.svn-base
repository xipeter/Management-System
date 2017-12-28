using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// DiagnoseBase<br></br>
    /// [功能描述: 病案诊断类]<br></br>
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
    public class DiagnoseBase : Neusoft.HISFC.Models.Base.Spell, Neusoft.HISFC.Models.Base.IValid
    {
        public DiagnoseBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //.
        }
        #region 私有变量
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient = new Neusoft.HISFC.Models.RADT.Patient();
        /// <summary>
        /// 发生序号(10位整数)
        /// </summary>
        private int happenNo;
        /// <summary>
        /// 诊断类别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject diagType = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// ICD10
        /// </summary>
        private ICD icd10 = new ICD();
        /// <summary>
        /// 诊断时间
        /// </summary>
        private DateTime diagDate;
        /// <summary>
        /// 诊断医生
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject doctor = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 诊断科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 手术序号
        /// </summary>
        private string operationNo = "";
        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid;
        /// <summary>
        /// 是否主诊断
        /// </summary>
        private bool isMain;
        #endregion

        #region 属性
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }
        /// <summary>
        /// 发生序号(10位整数)
        /// </summary>
        public int HappenNo
        {
            get
            {
                return happenNo;
            }
            set
            {
                happenNo = value;
            }
        }
        /// <summary>
        /// 诊断类别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DiagType
        {
            get
            {
                return diagType;
            }
            set
            {
                diagType = value;
            }
        }
        /// <summary>
        /// ICD10
        /// </summary>
        public ICD ICD10
        {
            get
            {
                return icd10;
            }
            set
            {
                icd10 = value;
            }
        }
        /// <summary>
        /// 诊断时间
        /// </summary>
        public DateTime DiagDate
        {
            get
            {
                return diagDate;
            }
            set
            {
                diagDate = value;
            }
        }
        /// <summary>
        /// 诊断医生
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
            }
        }
        /// <summary>
        /// 诊断科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }
        /// <summary>
        /// 手术序号
        /// </summary>
        public string OperationNo
        {
            get
            {
                return operationNo;
            }
            set
            {
                operationNo = value;
            }
        }
        /// <summary>
        /// 是否有效
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
        /// 是否主诊断
        /// </summary>
        public bool IsMain
        {
            get
            {
                return isMain;
            }
            set
            {
                isMain = value;
            }
        }

        #endregion

        #region 函数
        public new DiagnoseBase Clone()
        {
            DiagnoseBase obj = base.Clone() as DiagnoseBase;
            obj.patient = patient.Clone();
            obj.DiagType = DiagType.Clone();
            obj.ICD10 = ICD10.Clone();
            obj.Dept = Dept.Clone();
            obj.Doctor = Doctor.Clone();
            return obj;
        }
        #endregion

        #region 废弃
        ///// <summary>
        ///// 检索编码
        ///// </summary>
        //[Obsolete("废弃 用继承代替",true)]
        //public Neusoft.HISFC.Models.Base.Spell SpellCode = new Neusoft.HISFC.Models.Base.Spell();
        #endregion

        #region IValid 成员

        bool Neusoft.HISFC.Models.Base.IValid.IsValid
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
    }
}
