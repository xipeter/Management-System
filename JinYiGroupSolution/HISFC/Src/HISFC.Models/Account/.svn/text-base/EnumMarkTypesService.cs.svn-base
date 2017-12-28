using System.Collections;
using System;

namespace Neusoft.HISFC.Models.Account
{
    [Serializable]
    public class EnumMarkTypesService : Base.EnumServiceBase
    {
        public EnumMarkTypesService()
        {
            this.Items[MarkTypes.NoneCard] = "无卡";
            this.Items[MarkTypes.Magcard] = "磁卡";
            this.Items[MarkTypes.IC] = "IC卡";
        }


        #region 变量
        /// <summary>
        /// 卡类别
        /// </summary>
        MarkTypes markTypes;
        /// <summary>
        /// 存储枚举
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
                return markTypes; 
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
    #region 卡类型枚举
    /// <summary>
    /// 身份标识卡类别 1磁卡 2IC卡 3保障卡
    /// </summary>
    public enum MarkTypes
    {
        /// <summary>
        /// 无卡
        /// </summary>
        NoneCard=0,
        /// <summary>
        /// 磁卡
        /// </summary>
        Magcard = 1,
        /// <summary>
        /// IC卡
        /// </summary>
        IC=2

    };
    #endregion

}
