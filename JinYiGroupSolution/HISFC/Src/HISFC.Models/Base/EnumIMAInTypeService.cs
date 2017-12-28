using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// [功能描述: 物流管理系统类型枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// </summary>
    [System.Serializable]
    public class EnumIMAInTypeService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        static EnumIMAInTypeService()
        {
            itemCollection[EnumIMAInType.InnerApply] = "13";
            itemCollection[EnumIMAInType.OuterApply] = "12";
            itemCollection[EnumIMAInType.InnerBackApply] = "18";
            itemCollection[EnumIMAInType.OuterBackApply] = "17";
            itemCollection[EnumIMAInType.BorrowApply] = "14";
            itemCollection[EnumIMAInType.BorrowBack] = "15";
            itemCollection[EnumIMAInType.CommonInput] = "11";
            itemCollection[EnumIMAInType.ExamInput] = "1A";
            itemCollection[EnumIMAInType.ApproveInput] = "16";
            itemCollection[EnumIMAInType.BackInput] = "19";
            itemCollection[EnumIMAInType.SpecialInput] = "1C";
            itemCollection[EnumIMAInType.ProduceInput] = "1B";
        }

        EnumIMAInType inTypeEnum = EnumIMAInType.CommonInput;

        /// <summary>
        /// 存贮枚举ID
        /// </summary>
        protected static Hashtable itemCollection = new Hashtable();

        protected override System.Enum EnumItem
        {
            get
            {
                return this.inTypeEnum;
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
        public static EnumIMAInType GetEnumFromID(string typeID)
        {
            return (EnumIMAInType)(Enum.Parse(typeof(EnumIMAInType), typeID));
        }

        /// <summary>
        /// 根据Name获取对应枚举类
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static EnumIMAInType GetEnumFromName(string typeName)
        {
            foreach (EnumIMAInType inType in itemCollection.Keys)
            {
                if (itemCollection[inType].ToString() == typeName)
                {
                    return inType;
                }
            }

            return EnumIMAInType.CommonInput;
        }

        /// <summary>
        /// 根据枚举获取 
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static string GetNameFromEnum(EnumIMAInType inType)
        {
            return itemCollection[inType].ToString();
        }
    }

    public enum EnumIMAInType
    {
        /// <summary>
        /// 内部入库申请
        /// </summary>
        InnerApply,
        /// <summary>
        /// 外部入库申请
        /// </summary>
        OuterApply,
        /// <summary>
        /// 内部入库退库申请
        /// </summary>
        InnerBackApply,
        /// <summary>
        /// 外部入库退库申请
        /// </summary>
        OuterBackApply,
        /// <summary>
        /// 病区借药申请
        /// </summary>
        BorrowApply,
        /// <summary>
        /// 病区还药确认
        /// </summary>
        BorrowBack,
        /// <summary>
        /// 一般入库
        /// </summary>
        CommonInput,
        /// <summary>
        /// 发票入库
        /// </summary>
        ExamInput,
        /// <summary>
        /// 核准入库
        /// </summary>
        ApproveInput,
        /// <summary>
        /// 入库退库
        /// </summary>
        BackInput,
        /// <summary>
        /// 特殊入库
        /// </summary>
        SpecialInput,
        /// <summary>
        /// 生产入库
        /// </summary>
        ProduceInput
    }
}
