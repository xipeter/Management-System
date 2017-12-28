using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
 
	public class BloodType : EnumServiceBase
	{
        public BloodType()
		{
			this.Items[EnumBloodTypeByABO.A] = "A型";
            this.Items[EnumBloodTypeByABO.AB] = "AB型";
            this.Items[EnumBloodTypeByABO.B] = "B型";
            this.Items[EnumBloodTypeByABO.O] = "O型";
            this.Items[EnumBloodTypeByABO.U] = "未知";
		}

		#region 变量
 
        EnumBloodTypeByABO enumBloodType;

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
		protected override Enum EnumItem
		{
			get
			{
				return this.enumBloodType;
			}
		}

		#endregion

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
        public new BloodType Clone()
		{
            BloodType bloodEnumService = base.Clone() as BloodType;

            return bloodEnumService;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList( GetObjectItems(items)));
        }
	}

	
}
