using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 系统药品性质管理类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理'
	///  />
	///  ID 申请序号
	/// </summary>
    [Serializable]
    public class DrugQualityEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
	{
        public DrugQualityEnumService()
		{
            this.Items[EnumQuality.O] = "普药";
            this.Items[EnumQuality.S] = "麻药";
            this.Items[EnumQuality.V] = "贵药";
            this.Items[EnumQuality.T] = "大输液";
            this.Items[EnumQuality.P] = "精神药品";
            this.Items[EnumQuality.E] = "其他";
		}

        #region 变量

        /// <summary>
        /// 患者类别
        /// </summary>
        EnumQuality enumQuality;

        /// <summary>
        /// 存储枚举定义
        /// </summary>
        protected static Hashtable items = new Hashtable();

        #endregion

        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }

        protected override Enum EnumItem
        {
            get
            {
                return this.enumQuality;
            }
        }


        /// <summary>
        /// 返回中文  获得全部列表
        /// </summary>
        /// <returns>ArrayList(Quality)</returns>
        public static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
}

    /// <summary>
    /// 系统定义药品性质
    /// </summary>
    public enum EnumQuality
    {
        /// <summary>
        /// 普药
        /// </summary>
        O = 0,
        /// <summary>
        /// 麻药
        /// </summary>
        S = 1,
        /// <summary>
        /// 贵药
        /// </summary>
        V = 2,
        /// <summary>
        /// 大输液
        /// </summary>
        T = 3,
        /// <summary>
        /// 精神药品
        /// </summary>
        P = 4,
        /// <summary>
        /// 其他
        /// </summary>
        E = 5
    }	
}
