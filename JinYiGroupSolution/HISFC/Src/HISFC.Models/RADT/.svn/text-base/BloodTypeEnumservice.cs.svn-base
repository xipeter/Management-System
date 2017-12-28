using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 血液类型实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [Serializable]
    public class BloodTypeEnumService: EnumServiceBase	
	{
		/// <summary>
		/// 构造函数 定义枚举中文名称
		/// </summary>
		public BloodTypeEnumService()
		{
            items[EnumBloodTypeByABO.U] = "未知";
            items[EnumBloodTypeByABO.A] = "A型";
            items[EnumBloodTypeByABO.B] = "B型";
            items[EnumBloodTypeByABO.AB] = "AB型";
            items[EnumBloodTypeByABO.O] = "O型";
		}

		
		#region 变量

        private EnumBloodTypeByABO enumBloodType;

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();

		/// <summary>
		/// 是否 RH
		/// </summary>
		private bool bIsRH=false;

		#endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
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
				return this.enumBloodType;
			}
		}
		/// <summary>
		/// 是否RH血型
		/// </summary>
		public bool RH
		{
			get
			{
				return this.bIsRH;
			}
			set
			{
				this.bIsRH=value;
			}
		}
		
		#endregion
}
}
