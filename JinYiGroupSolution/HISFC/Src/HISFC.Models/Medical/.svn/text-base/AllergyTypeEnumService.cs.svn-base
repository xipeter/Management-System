using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Medical
{
    public class AllergyTypeEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        #region 构造方法

        static AllergyTypeEnumService()
        {
            items[AllergyType.DA] = "药物过敏";
            items[AllergyType.FA] = "食物过敏";
            items[AllergyType.MA] = "混合型过敏";
            items[AllergyType.MC] = "混合型禁忌";
        }

        #endregion

        #region 字段

        AllergyType enumAllergyType;

        protected static Hashtable items = new Hashtable();

        #endregion

        #region 属性

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
                return this.enumAllergyType;
            }
        }

        protected override Enum DefaultItem
        {
            get
            {
                return AllergyType.DA;
            }
        }

        #endregion

        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    /// <summary>
    /// 过敏类型
    /// </summary>
    public enum AllergyType
    {
        /// <summary>
        /// 药物过敏
        /// </summary>
        DA = 0,
        /// <summary>
        /// 食物过敏
        /// </summary>
        FA = 1,
        /// <summary>
        /// 混合型过敏
        /// </summary>
        MA = 2,
        /// <summary>
        /// 混合型禁忌
        /// </summary>
        MC = 3
    }
}
