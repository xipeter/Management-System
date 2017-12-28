using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Operation
{
    /// <summary>
    /// [功能描述: 报表管理类]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class OperationReport : Neusoft.HISFC.BizLogic.Operation.OpsReport
    {
        Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Manager();

        protected override Neusoft.HISFC.Models.Base.Department GetDeptmentById(string id)
        {
            return this.deptManager.GetDeptmentById(id);    
        }

        protected override Neusoft.HISFC.Models.Base.Employee GetEmployee(string id)
        {
            return this.manager.GetEmployeeInfo(id);
        }
    }
}
