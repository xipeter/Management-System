using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// SanLogOperTypeEnumService<br></br>
    /// [功能描述: 操作分类枚举服务类]<br></br>
    /// [创 建 者: SHIZJ]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class SanLogOperTypeEnumService : Neusoft.HISFC.Object.Base.EnumServiceBase
    {
        static SanLogOperTypeEnumService()
        {
            items[LogType.Add] = "添加";
            items[LogType.Del] = "删除";
            items[LogType.Edit] = "修改";
            items[LogType.Query] = "查询";
        }

        LogType logType;

        protected static Hashtable items = new Hashtable();

        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }

        protected override Enum EnumItem
        {
            get
            {
                return this.logType;
            }
        }

        public new static ArrayList list()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }
    /// <summary>
    /// 操作分类1添加2删除3修改4查询
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Del = 2,
        /// <summary>
        /// 修改
        /// </summary>
        Edit = 3,
        /// <summary>
        /// 查询
        /// </summary>
        Query = 4
    }
}
