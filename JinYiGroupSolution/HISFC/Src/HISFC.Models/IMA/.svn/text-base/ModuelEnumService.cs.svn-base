using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品、物资枚举服务类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class ModuelEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
	{
		static ModuelEnumService()
		{
			moduelHash[EnumModuelType.Phamacy] = "药品";
			moduelHash[EnumModuelType.Equipment] = "固定资产";
			moduelHash[EnumModuelType.Material] = "物资";
            moduelHash[EnumModuelType.Blood] = "血库";
			moduelHash[EnumModuelType.All] = "全部";
		}
		

		EnumModuelType moduelEnum;

		/// <summary>
		/// 枚举名称存储
		/// </summary>
		protected static System.Collections.Hashtable moduelHash = new System.Collections.Hashtable();

		/// <summary>
		/// 存储枚举名称
		/// </summary>
		protected override System.Collections.Hashtable Items
		{
			get
			{
				return moduelHash;
			}
		}

		/// <summary>
		/// 枚举
		/// </summary>
		protected override Enum EnumItem
		{
			get
			{
				return this.moduelEnum;
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static System.Collections.ArrayList List()
        {
            return (new System.Collections.ArrayList(GetObjectItems(moduelHash)));
        }

	}

	/// <summary>
	/// 药品物资管理模块枚举
	/// </summary>
    [Serializable]
	public enum EnumModuelType
	{
		/// <summary>
		/// 药品
		/// </summary>
		Phamacy = 1,
		/// <summary>
		/// 物质
		/// </summary>
		Material = 2,
		/// <summary>
		/// 固定资产
		/// </summary>
		Equipment = 3,
        /// <summary>
        /// 血库
        /// </summary>
        Blood = 4,
		/// <summary>
		/// 全部
		/// </summary>
		All = 0,
	}
}
