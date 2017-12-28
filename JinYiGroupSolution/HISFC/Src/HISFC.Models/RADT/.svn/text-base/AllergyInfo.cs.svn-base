using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.RADT
{
    /// <summary>
    /// [功能描述: 过敏信息综合实体]<br></br>
    /// [创 建 者: 孙盟]<br></br>
    /// [创建时间: 2007-04-26]<br></br>
    /// <修改记录/>
    /// </summary> 
    public class AllergyInfo:Allergy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AllergyInfo()
        {

        }

        #region  变量

        /// <summary>
        /// 住院号或者门诊病历号
        /// </summary>
        private string patientNO;
        /// <summary>
        /// 患者类型
        /// </summary>
        private ServiceTypes patientType;
        /// <summary>
        /// 有效性
        /// </summary>
        private bool validState;
        /// <summary>
        /// 操作人信息
        /// </summary>
        private OperEnvironment oper = new OperEnvironment();
        /// <summary>
        /// 作废人信息
        /// </summary>
        private OperEnvironment cancelOper = new OperEnvironment();

        #endregion

        #region  属性

        /// <summary>
        /// 住院号或者门诊病历号
        /// </summary>
        public string PatientNO
        {
            get
            {
                return this.patientNO;
            }
            set
            {
                this.patientNO = value;
            }
        }

        /// <summary>
        /// 患者类型
        /// </summary>
        public ServiceTypes PatientType
        {
            get
            {
                return this.patientType;
            }
            set 
            {
                this.patientType = value;
            }
        }

        /// <summary>
        /// 有效性
        /// </summary>
        public bool ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                this.validState = value;
            }
        }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public OperEnvironment Oper
        {
            get 
            {
                return this.oper;
            }
            set 
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 作废人信息
        /// </summary>
        public OperEnvironment CancelOper
        {
            get 
            {
                return this.cancelOper;
            }
            set 
            {
                this.cancelOper = value;
            }
        }

        #endregion

        #region  方法

        public new AllergyInfo clone()
        {
            AllergyInfo obj = base.Clone() as AllergyInfo;
            obj.oper = this.oper.Clone();
            obj.cancelOper = this.cancelOper.Clone();
            return obj;
        }

        #endregion
    }
}
