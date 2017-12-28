using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
    //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
    public class EnumAlertTypeService : EnumServiceBase
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public EnumAlertTypeService()
		{
			this.Items[EnumAlertType.M] = "按金额";
            this.Items[EnumAlertType.D] = "按时间段";
		}

		#region 变量

		/// <summary>
		/// 患者类别
		/// </summary>
        EnumAlertType alertType = EnumAlertType.M;

		/// <summary>
		/// 存储枚举定义
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
		
		/// <summary>
		/// 枚举项目
		/// </summary>
		protected override System.Enum EnumItem
		{
			get
			{
                return this.alertType;
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

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new EnumAlertTypeService Clone()
        {
            EnumAlertTypeService alterEnumService = base.Clone() as EnumAlertTypeService;

            return alterEnumService;
        }
    }
}
