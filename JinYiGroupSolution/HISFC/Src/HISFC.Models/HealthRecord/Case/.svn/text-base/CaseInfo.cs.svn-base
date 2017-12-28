using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历基本信息]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/08/16]<br></br>
    /// ID - 流水主键<br></br>
    /// User01 - 初诊病历号<br></br>
    /// User02 - 门诊病历号<br></br>
    /// User03 - 住院病历号<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class CaseInfo : Neusoft.FrameWork.Models.NeuObject
    {
        public CaseInfo()
        {
            
        }

        #region 私有变量

        /// <summary>
        /// 患者信息

        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 病案所在病案库及病案柜
        /// </summary>
        private CaseCabinet cabinet = new CaseCabinet();

        /// <summary>
        /// 病案所在科室信息

        /// </summary>
        private Neusoft.HISFC.Models.Base.Department inDept = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 病案所在人员信息

        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee inEmployee = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 病案所在类型 0-个人，1-科室
        /// </summary>
        private int inType;

        /// <summary>
        /// 病历状态

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject caseState = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 病历缺失状态

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject loseState = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 患者主索引号

        /// </summary>
        private string empiID;

        /// <summary>
        /// 病案柜格号

        /// </summary>
        private string gridNO;

        #endregion

        #region 属性


        /// <summary>
        /// 患者基本信息

        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }


        /// <summary>
        /// 病案所在病案库及病案柜
        /// </summary>
        public CaseCabinet Cabinet
        {
            get
            {
                return this.cabinet;
            }
            set
            {
                this.cabinet = value;
            }
        }

        /// <summary>
        /// 病案所在科室信息

        /// </summary>
        public Neusoft.HISFC.Models.Base.Department InDept
        {
            get
            {
                return this.inDept;
            }
            set
            {
                this.inDept = value;
            }
        }

        /// <summary>
        /// 病案所在人员信息

        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee InEmployee
        {
            get
            {
                return this.inEmployee;
            }
            set
            {
                this.inEmployee = value;
            }
        }

        /// <summary>
        /// 病案所在类型 0-个人，1-科室
        /// </summary>
        public int InType
        {
            get
            {
                return this.inType;
            }
            set
            {
                this.inType = value;
            }
        }

        /// <summary>
        /// 病历状态

        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CaseState
        {
            get
            {
                return this.caseState;
            }
            set
            {
                this.caseState = value;
            }
        }

        /// <summary>
        /// 病历缺失状态

        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject LoseState
        {
            get
            {
                return this.loseState;
            }
            set
            {
                this.loseState = value;
            }
        }

        /// <summary>
        /// 患者主索引号

        /// </summary>
        public string EmpiID
        {
            get
            {
                return this.empiID;
            }
            set
            {
                this.empiID = value;
            }
        }

        /// <summary>
        /// 病案柜格号

        /// </summary>
        public string GridNO
        {
            get
            {
                return this.gridNO;
            }
            set
            {
                this.gridNO = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>CaseInfo对象</returns>
        public new CaseInfo Clone()
        {
            CaseInfo caseinfo = base.Clone() as CaseInfo;

            caseinfo.cabinet = this.cabinet.Clone();
            caseinfo.inDept = this.inDept.Clone();
            caseinfo.inEmployee = this.inEmployee.Clone();
            caseinfo.caseState = this.caseState.Clone();
            caseinfo.LoseState = this.loseState.Clone();
            caseinfo.Patient = this.Patient.Clone();

            return caseinfo;
        }

        #endregion
    }
}
