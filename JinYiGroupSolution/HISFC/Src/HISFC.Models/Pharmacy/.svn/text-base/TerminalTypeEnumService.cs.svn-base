using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// TerminalTypeEnumService<br></br>
    /// [功能描述: 门诊终端类别枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class TerminalTypeEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        static TerminalTypeEnumService()
        {
            items[EnumTerminalType.配药台] = "配药台";
            items[EnumTerminalType.发药窗口] = "发药窗口";
        }

        EnumTerminalType enumType;

        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected static Hashtable items = new Hashtable();

        protected override System.Collections.Hashtable Items
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
                return enumType;
            }
        }

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 门诊终端类型枚举
    /// </summary>
    public enum EnumTerminalType
    {
        发药窗口 = 0,
        配药台 = 1
    }
}
