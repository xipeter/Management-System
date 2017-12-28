using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// SanReturnStateEnumService<br></br>
    /// [功能描述: 回收状态类型枚举服务类]<br></br>
    /// [创 建 者: SHIZJ]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class SanReturnStateEnumService:Neusoft.HISFC.Object.Base.EmployeeTypeEnumService
    {
        static SanReturnStateEnumService()
        {
            items[QCReturnState.APPLY] = "申请";
            items[QCReturnState.APPROVE] = "收污确认";
            items[QCReturnState.STERAPPROVE] = "清洁确认";
            items[QCReturnState.PACKAPPROVE] = "打包确认";
            items[QCReturnState.GETAPPROVE] = "领取确认";
        }

        QCReturnState qcReturnState;

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
                return this.qcReturnState;
            }
        }

        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 申请标记1申请2收污确认3清洁确认4打包确认5领取确认
    /// </summary>
    public enum QCReturnState
    {
        /// <summary>
        /// 1申请
        /// </summary>
        APPLY = 1,

        /// <summary>
        /// 2收污确认
        /// </summary>
        APPROVE = 2,

        /// <summary>
        /// 3清洁确认
        /// </summary>
        STERAPPROVE = 3,

        /// <summary>
        /// 4打包确认
        /// </summary>
        PACKAPPROVE = 4,

        /// <summary>
        /// 5领取确认
        /// </summary>
        GETAPPROVE = 5

    }
}
