using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 婚姻状态实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [Serializable]
    public class MaritalStatusEnumService :EnumServiceBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public MaritalStatusEnumService()
		{
			items[EnumMaritalStatus.S] = "未婚";
			items[EnumMaritalStatus.M] = "已婚";
			items[EnumMaritalStatus.D] = "失婚";
			items[EnumMaritalStatus.R] = "再婚";
			items[EnumMaritalStatus.A] = "分居";
			items[EnumMaritalStatus.W] = "丧偶";
		}
		
		
		#region 变量

		private EnumMaritalStatus enumMaritalStatus;
		
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
				return this.enumMaritalStatus;
			}
		}

		#endregion  	
		
		#region 方法
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new MaritalStatusEnumService Clone()
        {
            return base.Clone() as MaritalStatusEnumService;
        }

		#endregion

	}
}
