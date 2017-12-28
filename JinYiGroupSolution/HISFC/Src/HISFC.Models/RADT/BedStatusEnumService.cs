using System;
using System.Collections;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 床位状态实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	public class BedStatusEnumService:EnumServiceBase	
	{

		/// <summary>
		/// 枚举定义 床位状态实体中文名
		/// </summary>
		public BedStatusEnumService()
		{
			items[EnumBedStatus.C] = "关闭";//Closed
			items[EnumBedStatus.U] = "空床";//Unoccupied
			items[EnumBedStatus.K] = "污染";
			items[EnumBedStatus.I] = "隔离";
			items[EnumBedStatus.O] = "占用";
			items[EnumBedStatus.R] = "假床";
			items[EnumBedStatus.W] = "包床";
			items[EnumBedStatus.H] = "挂床";
		}

       
		#region 变量

		private EnumBedStatus enumBedStatus;	
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
		
		protected override Enum EnumItem
		{
			get
			{
				return this.enumBedStatus;
			}
		}

		#endregion  	
	}
}
