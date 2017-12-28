using System.Collections;
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// BedAttributeEnumService<br></br>
	/// [功能描述: 床位编制枚举服务类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
	public class BedRankEnumService : EnumServiceBase
	{
		static BedRankEnumService()
		{
			items[EnumBedRank.I] = "编制内";
			items[EnumBedRank.O] = "编制外";
			items[EnumBedRank.A] = "加床";
			items[EnumBedRank.F] = "家庭病床";
		}
		EnumBedRank enumBadRank;
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
				return this.enumBadRank;
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
	   

    	#region 枚举
		/// <summary>
		/// 床位编制
		/// </summary>
		public enum EnumBedRank
		{
			/// <summary>
			/// 编制内
			/// </summary>
			I,
			/// <summary>
			/// 编制外
			/// </summary>
			O,
			/// <summary>
			/// 加床
			/// </summary>
			A,
			/// <summary>
			/// 家庭病床
			/// </summary>
			F
		}	

		#endregion
}
