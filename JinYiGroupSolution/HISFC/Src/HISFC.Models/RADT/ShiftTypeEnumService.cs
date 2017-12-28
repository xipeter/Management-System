using System;
using System.Collections;

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
    public class ShiftTypeEnumService : Base.EnumServiceBase
	{
        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
		/// <summary>
		/// 构造函数
		/// </summary>
		public ShiftTypeEnumService()
		{
			items[Base.EnumShiftType.RD] = "转科";
			items[Base.EnumShiftType.RB] = "转床1";
			items[Base.EnumShiftType.RI] = "转入";
			items[Base.EnumShiftType.RO] = "转出";
			items[Base.EnumShiftType.K] = "接诊2";
			items[Base.EnumShiftType.B] = "住院登记3";
			items[Base.EnumShiftType.C] = "召回4";
			items[Base.EnumShiftType.OF] = "无费退院";
			items[Base.EnumShiftType.BA] = "结算";
			items[Base.EnumShiftType.BB] = "结算召回";
			items[Base.EnumShiftType.MB] = "中途结算";
			items[Base.EnumShiftType.F] = "患者信息修改";
			items[Base.EnumShiftType.LB] = "超标床和超标空调修改";
			items[Base.EnumShiftType.DL] = "公费日限额变更";
			items[Base.EnumShiftType.BT] = "公费日限额累计";
			items[Base.EnumShiftType.BP] = "结算清单打印";
			items[Base.EnumShiftType.CP] = "身份变更";
			items[Base.EnumShiftType.ZM] = "开医疗收费证明单";
			items[Base.EnumShiftType.O] = "出院登记5";
            items[Base.EnumShiftType.EB] = "留观登记";
            items[Base.EnumShiftType.CPI] = "留观转住院";
            items[Base.EnumShiftType.CI] = "留观组员";
            items[Base.EnumShiftType.IC] = "留观转住院召回";
		}
		
		
		#region 变量

		private Base.EnumShiftType  enumShiftType ;
		
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
				return this.enumShiftType;
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
            return (new ArrayList(items.Values));
        }
		#endregion
	}
}
