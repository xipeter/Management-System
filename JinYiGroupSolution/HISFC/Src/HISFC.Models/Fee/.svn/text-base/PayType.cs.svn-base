using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// EnumPayTypeService<br></br>
	/// [功能描述: 支付类型枚举服务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
    /// </summary>{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
    [Obsolete("废弃", true)]
	public class EnumPayTypeService : EnumServiceBase
	{
		static EnumPayTypeService() 
		{
			items[EnumPayType.CA] = "现金";
			items[EnumPayType.CH] = "支票";
			items[EnumPayType.CD] = "信用卡";
			items[EnumPayType.DB] = "借记卡";
			items[EnumPayType.AJ] = "转押金";
			items[EnumPayType.PO] = "汇票";
			items[EnumPayType.PS] = "保险帐户";
            items[EnumPayType.YS] = "院内账户";
            items[EnumPayType.PB] = "统筹(医院垫付)";
            items[EnumPayType.HP] = "垫付款";

		}

		#region 变量

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();
		
		/// <summary>
		/// 支付类型
		/// </summary>
		private EnumPayType enumPayType;

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
		
		/// <summary>
		/// 支付类型
		/// </summary>
		protected override Enum EnumItem
		{
			get
			{
				return this.enumPayType;
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
    [Obsolete("废弃", true)]
	/// <summary>
    /// 支付类型{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
	/// </summary>
	public enum EnumPayType
	{
		/// <summary>
		/// 现金
		/// </summary>
		CA = 0,

		/// <summary>
		/// 支票
		/// </summary>
		CH = 1,
			
		/// <summary>
		/// 信用卡
		/// </summary>
		CD = 2,

		/// <summary>
		/// 借记卡
		/// </summary>
		DB = 3,
		
		/// <summary>
		/// 转押金
		/// </summary>
		AJ = 4,

		/// <summary>
		/// 汇票
		/// </summary>
		PO = 5,

		/// <summary>
		/// 保险帐户
		/// </summary>
		PS = 6,

        /// <summary>
        /// 院内账户
        /// </summary>
        YS = 7,
        /// <summary>
        /// 统筹(医院垫付)
        /// </summary>
        PB = 8,
        /// <summary>
        /// 垫付款
        /// </summary>
        HP = 9
	}

	#endregion
}
