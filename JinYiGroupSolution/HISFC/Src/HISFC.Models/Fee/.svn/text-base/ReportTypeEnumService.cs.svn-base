using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// ReportTypeEnumService<br></br>
	/// [功能描述: 统计大类类别枚举]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class ReportTypeEnumService : EnumServiceBase
	{
		static ReportTypeEnumService() 
		{
			items[EnumReportType.FP] = "发票";
			items[EnumReportType.TJ] = "统计";
			items[EnumReportType.BA] = "病案";
			items[EnumReportType.ZQ] = "知情权";
		}

		#region 变量

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();
		
		/// <summary>
		/// 结算类型
		/// </summary>
		private EnumReportType enumReportType;

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
		/// 统计大类类型
		/// </summary>
		protected override Enum EnumItem
		{
			get
			{
				return this.enumReportType;
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
	/// 统计大类类型
	/// </summary>
	public enum EnumReportType
	{
		/// <summary>
		/// 发票
		/// </summary>
		FP = 0,

		/// <summary>
		/// 统计
		/// </summary>
		TJ = 1,

		/// <summary>
		/// 病案
		/// </summary>
		BA = 2,

		/// <summary>
		/// 知情权
		/// </summary>
		ZQ = 3
	}

	#endregion
}
