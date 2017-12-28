using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// EnumBloodKindEnumService<br></br>
    /// [功能描述: 模版项目类型枚举类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-02]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    [Serializable]
    public class EnumStencilItemTypeService : Base.EnumServiceBase
    {

        static EnumStencilItemTypeService()
        {
            items[EnumStencilItemType.Person] = "人员";
            items[EnumStencilItemType.Dept] = "科室";
            items[EnumStencilItemType.Number] = "数值";
            items[EnumStencilItemType.Date] = "时间";
            items[EnumStencilItemType.String] = "自定义信息";
            items[EnumStencilItemType.Extend] = "扩展";
        }

        EnumStencilItemType enumBloodKind;

        #region 变量

        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected static Hashtable items = new Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// 存贮枚举名称
        /// </summary>
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
                return this.enumBloodKind;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    #region 模版项目类型枚举


    /// <summary>
    /// 模版项目类型枚举
    /// </summary>
    public enum EnumStencilItemType
    {
        /// <summary>
        /// 人员
        /// </summary>
        Person = 0,
        /// <summary>
        /// 科室
        /// </summary>
        Dept = 1,
        /// <summary>
        /// 数值
        /// </summary>
        Number = 2,
        /// <summary>
        /// 时间
        /// </summary>
        Date = 3,
        /// <summary>
        /// 自定义信息
        /// </summary>
        String = 4,
        /// <summary>
        /// 扩展
        /// </summary>
        Extend = 5
    }

    #endregion
}
