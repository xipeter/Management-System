using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// [功能描述: 药品自定义月结类型枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-07-30]<br></br>
    /// </summary>

    [System.Serializable]
    public class EnumMSCustomTypeService : EnumServiceBase
    {

        static EnumMSCustomTypeService()
        {
            itemCollection[EnumMSCustomType.入库] = "0310";
            itemCollection[EnumMSCustomType.出库] = "0320";
            itemCollection[EnumMSCustomType.盘点] = "0305";
            itemCollection[EnumMSCustomType.调价] = "0304";
            itemCollection[EnumMSCustomType.科室] = "1000";
            itemCollection[EnumMSCustomType.门诊患者领药] = "2001";
            itemCollection[EnumMSCustomType.门诊患者退药] = "2002";
            itemCollection[EnumMSCustomType.住院患者领药] = "2101";
            itemCollection[EnumMSCustomType.住院患者退药] = "2102";
            itemCollection[EnumMSCustomType.小计] = "SUB";
        }

        EnumMSCustomType msCustomType = EnumMSCustomType.入库;

        /// <summary>
        /// 存贮枚举ID
        /// </summary>
        protected static Hashtable itemCollection = new Hashtable();

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
                return itemCollection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(itemCollection)));
        }

        /// <summary>
        /// 根据ID获取对应枚举类
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public static EnumMSCustomType GetEnumFromID(string typeID)
        {
            return (EnumMSCustomType)(Enum.Parse(typeof(EnumMSCustomType), typeID));
        }

        /// <summary>
        /// 根据Name获取对应枚举类
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static EnumMSCustomType GetEnumFromName(string typeName)
        {
            foreach (EnumMSCustomType customType in itemCollection.Keys)
            {
                if (itemCollection[customType].ToString() == typeName)
                {
                    return customType;
                }
            }

            return EnumMSCustomType.入库;
        }

        /// <summary>
        /// 根据枚举获取 
        /// </summary>
        /// <param name="msCustomType"></param>
        /// <returns></returns>
        public static string GetNameFromEnum(EnumMSCustomType msCustomType)
        {
            return itemCollection[msCustomType].ToString();
        }
    }

    /// <summary>
    /// 药品自定义月结类型
    /// </summary>
    public enum EnumMSCustomType
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
