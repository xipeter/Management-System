using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历更换实体]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/09/14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// ID:病历更换标识, MEMO:病历更换说明 
    /// </summary>
    [Serializable]
    public class CaseChange :Neusoft.FrameWork.Models.NeuObject , Neusoft.HISFC.Models.Base.IValid
    {
        private string oldCardNO;
        private string newCardNO;

        private Neusoft.HISFC.Models.Base.OperEnvironment doctorEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        private bool isValid;
        private decimal chargeCost;

        /// <summary>
        /// 交费金额
        /// </summary>
        public decimal ChargeCost
        {
            get
            {
                return this.chargeCost;
            }
            set
            {
                this.chargeCost = value;
            }
        }

        /// <summary>
        /// 旧病历号
        /// </summary>
        public string OldCardNO
        {
            get
            {
                return this.oldCardNO;
            }
            set
            {
                this.oldCardNO = value;
            }
        }

        /// <summary>
        /// 新病历号
        /// </summary>
        public string NewCardNO
        {
            get
            {
                return this.newCardNO;
            }
            set
            {
                this.newCardNO = value;
            }
        }

        /// <summary>
        /// 病历更换申请医生信息
        /// ID:医生编号, OperTime:时间
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment DoctorEnv
        {
            get
            {
                return this.doctorEnv;
            }
            set
            {
                this.doctorEnv = value;
            }
        }

        /// <summary>
        /// 病历更换操作员
        /// ID:操作员编号, OperTime:时间
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
        {
            get
            {
                return this.operEnv;
            }
            set
            {
                this.operEnv = value;
            }
        }

        #region IValid 成员

        /// <summary>
        /// 是否收费
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion


        public new CaseChange Clone()
        {
            CaseChange cc = base.Clone() as CaseChange;

            cc.doctorEnv = this.doctorEnv.Clone();
            cc.operEnv = this.operEnv.Clone();

            return cc;
        }
    }
}