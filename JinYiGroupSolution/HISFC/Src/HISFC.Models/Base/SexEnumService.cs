using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// SexEnumService <br></br>
	/// [功能描述: 性别枚举服务实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class SexEnumService : EnumServiceBase
	{
		public SexEnumService()
		{
			this.Items[EnumSex.U] = "未知";
			this.Items[EnumSex.M] = "男";
			this.Items[EnumSex.F] = "女";
            //this.Items[EnumSex.O] = "其他";//{348A3680-44B3-42be-9FD3-BC7CB5FA8D6E}
            //this.Items[EnumSex.A] = "全部";
		}

		#region 变量

		/// <summary>
		/// 患者类别
		/// </summary>
		EnumSex enumSex;

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
				return this.enumSex;
			}
		}

		#endregion

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new SexEnumService Clone()
		{
			SexEnumService sexEnumService = base.Clone() as SexEnumService;
            
			return sexEnumService;
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
