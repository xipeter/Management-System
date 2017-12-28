using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
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
    /// {93E6443C-1FB5-45a7-B89D-F21A92200CF6}
    [Obsolete("废弃", true)]
	public class InvoiceTypeEnumService : EnumServiceBase
	{
		static InvoiceTypeEnumService( ) 
		{
			items[EnumInvoiceType.R] = "挂号收据";
			items[EnumInvoiceType.C] = "门诊收据";
			items[EnumInvoiceType.I] = "住院收据";
			items[EnumInvoiceType.P] = "预交收据";
            items[EnumInvoiceType.A] = "门诊帐户";
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

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例副本</returns>
		public new InvoiceTypeEnumService Clone()
		{
			return base.Clone() as InvoiceTypeEnumService;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
		#endregion

		#endregion

	}
	
	#region 枚举

	/// <summary>
	/// 收据(发票)分类
    /// </summary>{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
    [Obsolete("废弃",true)]
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
		P=4,

        /// <summary>
        /// 门诊帐户
        /// </summary>
        A=5
	}

	#endregion

}
