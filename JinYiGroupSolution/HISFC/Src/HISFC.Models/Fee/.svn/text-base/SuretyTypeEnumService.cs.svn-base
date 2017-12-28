using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;
using System.Collections;

namespace Neusoft.HISFC.Models.Fee
{
    [System.Serializable]
    public class SuretyTypeEnumService : EnumServiceBase
    {
        public SuretyTypeEnumService()
        {
            this.Items[EnumSuretyType.E] = "人员担保";
            this.Items[EnumSuretyType.U] = "单位担保";
            this.Items[EnumSuretyType.F] = "财务担保";
        }
        #region 变量
        private EnumSuretyType enumSuretype;
        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected static Hashtable items = new Hashtable();
        #endregion

        #region 属性
        /// <summary>
        /// 存贮枚举
        /// </summary>
        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }
        /// <summary>
        /// 枚举项目
        /// </summary>
        protected override System.Enum EnumItem
        {
            get
            {
                return enumSuretype;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 得到枚举的NeuObject数组
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
        #endregion  
    }

    #region 担保类型
    /// <summary>
    /// 担保类型
    /// </summary>
    public enum EnumSuretyType
    {
        /// <summary>
        /// 人员担保
        /// </summary>
        E = 0,
        /// <summary>
        /// 单位担保
        /// </summary>
        U = 1,
        /// <summary>
        /// 财务担保
        /// </summary>
        F = 2
    }
    #endregion
}
