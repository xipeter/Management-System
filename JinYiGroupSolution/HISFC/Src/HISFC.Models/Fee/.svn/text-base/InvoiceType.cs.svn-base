using System;
using System.Collections;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// InvoiceTypeEnumService<br></br>
	/// [功能描述: 收据(发票)类型枚举服务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class InvoiceTypeEnumService : EnumServiceBase
	{
		static InvoiceTypeEnumService( ) 
		{
			items[EnumInvoiceType.R] = "挂号收据";
			items[EnumInvoiceType.C] = "门诊收据";
			items[EnumInvoiceType.I] = "住院收据";
			items[EnumInvoiceType.P] = "预交收据";
		}

		#region 变量

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();
		
		/// <summary>
		/// 收据(发票)分类
		/// </summary>
		private EnumInvoiceType enumInvoiceType;

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
		/// 收据(发票)分类
		/// </summary>
		protected override Enum EnumItem
		{
			get
			{
				return this.enumInvoiceType;
			}
		}

		#endregion

	}
	
	#region 枚举

	/// <summary>
	/// 收据(发票)分类
	/// </summary>
	public enum EnumInvoiceType
	{
		/// <summary>
		/// 挂号收据
		/// </summary>
		R=0,

		/// <summary>
		/// 门诊收据
		/// </summary>
		C=1,

		/// <summary>
		/// 住院收据
		/// </summary>
		I=2,

		/// <summary>
		/// 预交收据
		/// </summary>
		P=4
	}

	#endregion

}
