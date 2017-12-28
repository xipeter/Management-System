using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace  Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// [功能描述: 物流管理系统类型枚举服务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// </summary>
    [System.Serializable]
    public class EnumIMAOutTypeService : EnumServiceBase
    {
        static EnumIMAOutTypeService()
        {
            itemCollection[EnumIMAOutType.CommonOutput] = "21";
            itemCollection[EnumIMAOutType.BackOutput] = "22";
            itemCollection[EnumIMAOutType.BorrowExamOutput] = "23";
            itemCollection[EnumIMAOutType.ApplyOutput] = "24";
            itemCollection[EnumIMAOutType.ExamOutput] = "25";

            itemCollection[EnumIMAOutType.SpecialOutput] = "26";
            itemCollection[EnumIMAOutType.InnerBackOutput] = "27";

            itemCollection[EnumIMAOutType.TransferOutput] = "29";
            itemCollection[EnumIMAOutType.ChangeOutput] = "30";
            itemCollection[EnumIMAOutType.ProduceOutput] = "31";

            itemCollection[EnumIMAOutType.OutpatientOutput] = "M1";
            itemCollection[EnumIMAOutType.OutpatientBackOutput] = "M2";
            itemCollection[EnumIMAOutType.InpatientOutput] = "Z1";
            itemCollection[EnumIMAOutType.InpatientBackOutput] = "Z2";
        }

        EnumIMAOutType outTypeEnum = EnumIMAOutType.CommonOutput;

        /// <summary>
        /// 存贮枚举ID
        /// </summary>
        protected static Hashtable itemCollection = new Hashtable();

        protected override System.Enum EnumItem
        {
            get
            {
                return this.outTypeEnum;
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
        public static EnumIMAOutType GetEnumFromID(string typeID)
        {
            return (EnumIMAOutType)(Enum.Parse(typeof(EnumIMAOutType), typeID));
        }

        /// <summary>
        /// 根据Name获取对应枚举类
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static EnumIMAOutType GetEnumFromName(string typeName)
        {
            foreach (EnumIMAOutType inType in itemCollection.Keys)
            {
                if (itemCollection[inType].ToString() == typeName)
                {
                    return inType;
                }
            }

            return EnumIMAOutType.CommonOutput;
        }

        /// <summary>
        /// 根据枚举获取 
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static string GetNameFromEnum(EnumIMAOutType inType)
        {
            return itemCollection[inType].ToString();
        }
    }

    public enum EnumIMAOutType
    {
        /// <summary>
        /// 一般出库 21
        /// </summary>
        CommonOutput,
        /// <summary>
        /// 出库退库 22
        /// </summary>
        BackOutput,
        /// <summary>
        /// 借药审核 23
        /// </summary>
        BorrowExamOutput,
        /// <summary>
        /// 出库申请 24
        /// </summary>
        ApplyOutput,
        /// <summary>
        /// 出库审批 25
        /// </summary>
        ExamOutput,
        /// <summary>
        /// 特殊出库 26
        /// </summary>
        SpecialOutput,
        /// <summary>
        /// 内部还药确认 27
        /// </summary>
        InnerBackOutput,
        /// <summary>
        /// 价让出库    29 
        /// </summary>
        TransferOutput,
        /// <summary>
        /// 换药出库    30 待实行
        /// </summary>
        ChangeOutput,
        /// <summary>
        /// 生产出库    31
        /// </summary>
        ProduceOutput,
        /// <summary>
        /// 门诊摆药 M1
        /// </summary>
        OutpatientOutput,
        /// <summary>
        /// 门诊退药 M2
        /// </summary>
        OutpatientBackOutput,
        /// <summary>
        /// 住院摆药 Z1
        /// </summary>
        InpatientOutput,
        /// <summary>
        /// 住院退药 Z2
        /// </summary>
        InpatientBackOutput
    }
}
