using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// TerminalTypeEnumService<br></br>
    /// [功能描述: 门诊打印类型枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-01]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ClinicPrintTypeEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        static ClinicPrintTypeEnumService()
        {
            items[EnumClinicPrintType.标签] = "标签";
            items[EnumClinicPrintType.扩展] = "扩展";
            items[EnumClinicPrintType.清单] = "清单";
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
    /// 门诊终端打印类型枚举
    /// </summary>
    public enum EnumClinicPrintType
    {
        标签 = 0,
        清单 = 1,
        扩展 = 2
    }
}
