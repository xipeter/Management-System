using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.Models.Operation
{
    /// <summary>
    /// [功能描述: 手术人员角色状态（目前只针对麻醉安排有用）]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-11]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class RoleOperKindEnumService : Base.EnumServiceBase
    {
        static RoleOperKindEnumService()
		{
            items[EnumRoleOperKind.ZC] = "正常";
            items[EnumRoleOperKind.ZL] = "直落";
            items[EnumRoleOperKind.JB] = "接班";
		}
		EnumRoleOperKind enumItem;
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
				return this.enumItem;
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

    public enum EnumRoleOperKind
    {
        /// <summary>
        ///正常
        /// </summary>
        ZC = 1,
        /// <summary>
        ///直落
        /// </summary>
        ZL = 2,
        /// <summary>
        ///接班
        /// </summary>
        JB = 3
    };
}
