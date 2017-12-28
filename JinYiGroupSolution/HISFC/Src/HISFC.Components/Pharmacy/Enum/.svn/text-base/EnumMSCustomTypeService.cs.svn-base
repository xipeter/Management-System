using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace UFC.Pharmacy.Enum
{
    /// <summary>
    /// [功能描述: 药品自定义月结类型枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-07-30]<br></br>
    /// </summary>
    internal class EnumMSCustomTypeService : Neusoft.HISFC.Object.Base.EnumServiceBase
    {

        static EnumMSCustomTypeService()
        {
            items[EnumMSCustomType.入库] = "0310";
            items[EnumMSCustomType.出库] = "0320";
            items[EnumMSCustomType.盘点] = "0305";
            items[EnumMSCustomType.调价] = "0304";
            items[EnumMSCustomType.科室] = "1000";
            items[EnumMSCustomType.门诊患者领药] = "2001";
            items[EnumMSCustomType.门诊患者退药] = "2002";
            items[EnumMSCustomType.住院患者领药] = "2101";
            items[EnumMSCustomType.住院患者退药] = "2102";
            items[EnumMSCustomType.小计] = "SUB";
        }

        EnumMSCustomType msCustomType = EnumMSCustomType.入库;

        /// <summary>
        /// 存贮枚举ID
        /// </summary>
        protected static Hashtable items = new Hashtable();

        protected override System.Enum EnumItem
        {
            get
            {
                return this.msCustomType;
            }
        }

        protected override System.Collections.Hashtable Items
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 药品自定义月结类型
    /// </summary>
    internal enum EnumMSCustomType
    {
        入库,
        出库,
        盘点,
        调价,
        科室,
        门诊患者领药,
        门诊患者退药,
        住院患者领药,
        住院患者退药,
        小计
    }
}
