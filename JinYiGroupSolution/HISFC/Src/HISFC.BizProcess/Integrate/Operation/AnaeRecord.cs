using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.Operation
{
    /// <summary>
    /// [功能描述: 麻醉安排业务层]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-31]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class AnaeRecord : Neusoft.HISFC.BizLogic.Operation.AnaeRecord
    {
        #region 字段
        private Operation operation = new Operation();
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
    }
}
