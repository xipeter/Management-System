using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历跟踪]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/09/13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// ID：跟踪记录ID,  User01：病历使用类型编码
    /// </summary>
    [Serializable]
    public class CaseTrack : Neusoft.FrameWork.Models.NeuObject
    {
        public CaseTrack()
        {
        }

        /// <summary>
        /// 患者病历
        /// </summary>
        private CaseInfo patientCase = new CaseInfo();

        /// <summary>
        /// 病历使用时间, 病历使用人工号, 病历使用科室编码, 病历使用类型编码，对应常数表CASE05
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment useCaseEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 患者病历信息
        /// </summary>
        public CaseInfo PatientCase
        {
            get
            {
                return this.patientCase;
            }
            set
            {
                this.patientCase = value;
            }
        }

        /// <summary>
        /// 病历使用信息记录
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment UseCaseEnv
        {
            get
            {
                return this.useCaseEnv;
            }
            set
            {
                this.useCaseEnv = value;
            }
        }

        /// <summary>
        /// 返回新对实体
        /// </summary>
        /// <returns>null失败</returns>
        public new CaseTrack Clone()
        {
            CaseTrack ct = base.Clone() as CaseTrack;

            if (ct == null)
            {
                return null;
            }

            ct.useCaseEnv = this.useCaseEnv.Clone();
            ct.patientCase = this.patientCase.Clone();

            return ct;
        }

    }
}
