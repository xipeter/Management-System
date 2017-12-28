using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    [Serializable]
    public class TerminalPropertyEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        static TerminalPropertyEnumService()
        {
            items[EnumTerminalProperty.普通] = "普通";
            items[EnumTerminalProperty.专科] = "专科";
            items[EnumTerminalProperty.特殊] = "特殊";
        }

        EnumTerminalProperty enumProperty;

        protected static System.Collections.Hashtable items = new System.Collections.Hashtable();

        protected override System.Collections.Hashtable Items
        {
            get {
                return items;
            }
        }

        protected override Enum EnumItem
        {
            get 
            {
                return enumProperty;
            }
        }

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <returns></returns>
        public new static System.Collections.ArrayList List()
        {
            return (new System.Collections.ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 门诊终端性质枚举 
    /// </summary>
    public enum EnumTerminalProperty
    {
        普通 = 0,
        专科 = 1,
        特殊 = 2
    };
}
