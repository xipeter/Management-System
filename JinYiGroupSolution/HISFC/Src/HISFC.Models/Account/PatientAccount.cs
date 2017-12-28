using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Account
{
    [Serializable]
    public class PatientAccount : Neusoft.HISFC.Models.RADT.PatientInfo
    {

        #region 变量
        Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion 

        #region 属性
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            set
            {
                oper = value;
            }
            get
            {
                return oper;
            }
        }
        #endregion

        #region 方法
        public new PatientAccount Clone()
        {
            PatientAccount patient = base.Clone() as PatientAccount;
            patient.Oper = this.Oper.Clone();
            return patient;
        }

        #endregion
    }
}
