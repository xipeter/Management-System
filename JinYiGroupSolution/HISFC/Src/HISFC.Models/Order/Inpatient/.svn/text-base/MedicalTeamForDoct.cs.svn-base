using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.Models.Order.Inpatient
{
    /// <summary>
    /// Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam<br></br>
    /// [功能描述: 医疗组实体]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2010-06-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class MedicalTeamForDoct:Neusoft.FrameWork.Models.NeuObject,Base.IValid
    {
        #region 变量
        /// <summary>
        /// 医疗组信息
        /// </summary>
        private Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam medcicalTeam = new MedicalTeam();
        /// <summary>
        /// 医生信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject doct = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作信息
        /// </summary>
        private Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 有效标记
        /// </summary>
        private bool isValid = true;
        #endregion

        #region 属性
        /// <summary>
        /// 医疗组信息
        /// </summary>
        public Neusoft.HISFC.Models.Order.Inpatient.MedicalTeam  MedcicalTeam
        {
            get { return medcicalTeam; }
            set { medcicalTeam = value; }
        }
        /// <summary>
        /// 医生信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Doct
        {
            get { return doct; }
            set { doct = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }


        #region IValid 成员
        /// <summary>
        /// 有效标记
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value ;
            }
        }

        #endregion
        #endregion

        #region 方法

        public new MedicalTeamForDoct Clone()
        {
            MedicalTeamForDoct medicalTeamForDoct = base.Clone() as MedicalTeamForDoct;
            medicalTeamForDoct.Doct = this.Doct.Clone();
            
            
            medicalTeamForDoct.MedcicalTeam = this.medcicalTeam.Clone();
            medicalTeamForDoct.Oper = this.Oper.Clone();
            return medicalTeamForDoct;
        }
        #endregion


    }
}
