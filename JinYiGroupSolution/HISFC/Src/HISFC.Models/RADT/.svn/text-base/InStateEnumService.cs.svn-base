using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// InStateEnumService <br></br>
	/// [功能描述: 住院患者在院状态枚举服务实体]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2009-9-13'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class InStateEnumService : EnumServiceBase
	{
        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
		public InStateEnumService()
		{
			this.Items[EnumInState.R] = "住院登记完成,等待接诊";
			this.Items[EnumInState.I] = "病房接诊完成,在院状态";
			this.Items[EnumInState.B] = "出院登记完成,结算状态";
			this.Items[EnumInState.O] = "出院结算完成";
			this.Items[EnumInState.P] = "预约出院";
			this.Items[EnumInState.N] = "无费退院";
			this.Items[EnumInState.C] = "封账状态";
            this.Items[EnumInState.E] = "转住院";
		}

		#region 变量

		/// <summary>
		/// 患者类别
		/// </summary>
		EnumInState enumInState;

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
				return this.enumInState;
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

	
}
