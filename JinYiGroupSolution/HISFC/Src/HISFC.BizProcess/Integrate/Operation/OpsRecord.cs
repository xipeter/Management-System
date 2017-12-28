using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Operation
{
    /// <summary>
    /// [功能描述: 手术安排业务层]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-31]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class OpsRecord : Neusoft.HISFC.BizLogic.Operation.OpsRecord
    {
#region 字段
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new RADT();
        private Operation operation = new Operation();
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
#endregion
        
        #region 属性
        protected override Neusoft.HISFC.BizLogic.Operation.Operation operationManager
        {
            get
            {
                return this.operation;
            }
        }
        #endregion

#region 方法
        protected override Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string id)
        {
            return this.radtManager.GetPatientInfomation(id);
        }

        protected override Neusoft.HISFC.Models.Base.Department GetDeptmentById(string id)
        {
            return this.deptManager.GetDeptmentById(id);
        }
#endregion
    }
}
