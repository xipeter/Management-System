using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// SanApplyStateEnumService<br></br>
    /// [功能描述: 申请登记类型枚举服务类]<br></br>
    /// [创 建 者: SHIZJ]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class SanApplyStateEnumService:Neusoft.HISFC.Object.Base.EmployeeTypeEnumService
    {
        static SanApplyStateEnumService()
        {
            items[QCApplyState.APPLY] = "申请";
            items[QCApplyState.APPROVE] = "审批";
            items[QCApplyState.USEAPPLY] = "借用申请";
            items[QCApplyState.USEAPPROLY] = "借用审批";
            items[QCApplyState.RETURN] = "归还";
        }

        QCApplyState qcApplyState;

        protected static Hashtable items = new Hashtable();

        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }

        protected override System.Enum EnumItem
        {
            get
            {
                return this.qcApplyState;
            }
        }

        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 申请标记1申请2审批3借用申请4借用审批5归还
    /// </summary>
    public enum QCApplyState
    {
        /// <summary>
        /// 1申请
        /// </summary>
        APPLY=1,

        /// <summary>
        /// 2审批
        /// </summary>
        APPROVE=2,

        /// <summary>
        /// 3借用申请
        /// </summary>
        USEAPPLY=3,

        /// <summary>
        /// 4借用审批
        /// </summary>
        USEAPPROLY=4,

        /// <summary>
        /// 5归还
        /// </summary>
        RETURN=5

    }
}
