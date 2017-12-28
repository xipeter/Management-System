using System;
using System.Collections;

using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{

	/// <summary>
	/// BalanceTypeEnumService<br></br>
	/// [功能描述: 结算类型枚举服务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class BalanceTypeEnumService : EnumServiceBase 
	{
		static BalanceTypeEnumService() 
		{
			items[EnumBalanceType.I] = "中途结算";
			items[EnumBalanceType.O] = "出院结算";
			items[EnumBalanceType.D] = "直接结算";
			items[EnumBalanceType.S] = "结转结算";
			items[EnumBalanceType.C] = "门诊结算";
			items[EnumBalanceType.E] = "急诊结算";
			items[EnumBalanceType.P] = "体检结算";
            items[EnumBalanceType.Q] = "欠费结算";
		}

		#region 变量

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();
		
		/// <summary>
		/// 结算类型
		/// </summary>
		private EnumBalanceType enumBalanceType;

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
		/// 结算类型
		/// </summary>
		protected override Enum EnumItem
		{
			get
			{
				return this.enumBalanceType;
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
	/// 结算类型
	/// </summary>
	public enum EnumBalanceType 
	{
		/// <summary>
		/// 中途结算 I
		/// </summary>
		I,

		/// <summary>
		/// 出院结算 O
		/// </summary>
		O,
		
		/// <summary>
		/// 直接结算
		/// </summary>
		D,
		
		/// <summary>
		/// 结转结算
		/// </summary>
		S,
		
		/// <summary>
		/// 门诊结算
		/// </summary>
		C,
		
		/// <summary>
		/// 急诊结算
		/// </summary>
		E,
		
		/// <summary>
		/// 体检结算
		/// </summary>
		P,
        /// <summary>
        /// 欠费结算
        /// </summary>
        Q
	}

	#endregion
}
