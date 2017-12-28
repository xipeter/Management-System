using System;
using System.Collections;

namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// EnumBedStatusService 的摘要说明。
	/// </summary>
	public class EnumBedStatusService:Base.EnumServiceBase	
	{
		public EnumBedStatusService()
		{
			items[EnumBedStatus.C] = "Closed";
			items[EnumBedStatus.O] = "编制外";
			items[EnumBedStatus.A] = "加床";
			items[EnumBedStatus.F] = "家庭病床";
		}
        EnumBedStatus enumBedStatus;
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
				return this.enumBedStatus;
			}
		}

		#endregion
        
	
	}
	#region 枚举
	/// <summary>
	/// 病床状态
	/// </summary>
	public enum EnumBedStatus
	{
		/// <summary>
		/// Closed
		/// </summary>
		C,
		/// <summary>
		/// Unoccupied
		/// </summary>
		U,
		/// <summary>
		/// Contaminated污染的
		/// </summary>
		K,
		/// <summary>
		/// 隔离的
		/// </summary>
		I,
		/// <summary>
		/// Occupied
		/// </summary>
		O,
		/// <summary>
		/// 假床  user define
		/// </summary>
		R,
		/// <summary>
		/// 包床 user define
		/// </summary>
		W,
		/// <summary>
		/// 挂床
		/// </summary>
		H
	}	

	#endregion
}
