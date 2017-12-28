using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Account
{
    [Serializable]
    public class EnumMarkOperateTypesService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {

        public EnumMarkOperateTypesService()
        {
            this.Items[MarkOperateTypes.Begin] = "开始使用";
            this.Items[MarkOperateTypes.Stop] = "停止使用";
            this.Items[MarkOperateTypes.Cancel] = "取消使用";
        }

        #region 变量
        /// <summary>
        /// 卡类别
        /// </summary>
        MarkOperateTypes markOperateTypes;
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
                return markOperateTypes; 
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
    /// 卡操作枚举
    /// </summary>
    public enum MarkOperateTypes
    {
        /// <summary>
        /// 开始使用
        /// </summary>
        Begin=0,
        /// <summary>
        /// 停止使用
        /// </summary>
        Stop = 1,
        /// <summary>
        /// 取消使用
        /// </summary>
        Cancel=2

    };
    #endregion
}
