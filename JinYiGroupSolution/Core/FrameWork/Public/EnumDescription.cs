using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.Public
{
    /// <summary>
    /// 枚举实体的特性
    /// 用来为枚举增加特性值(description)
    /// 用途：通过EnumHelper可以取得某个枚举的该特性值:description
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 描述
        /// </summary>
        string description;

        /// <summary>
        /// 构造，并初始化描述
        /// </summary>
        /// <param name="description">描述</param>
        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
    }
}
