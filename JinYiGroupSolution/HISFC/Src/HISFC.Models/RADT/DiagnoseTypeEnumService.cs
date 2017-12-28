using System;
using System.Collections;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 诊断类型实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	public class DiagnoseTypeEnumService:EnumServiceBase	
	{
		public DiagnoseTypeEnumService()
		{
			items[EnumDiagnoseType.IN] = "入院诊断";
			items[EnumDiagnoseType.TURNIN] = "转入诊断";
			items[EnumDiagnoseType.OUT] = "出院诊断";
			items[EnumDiagnoseType.TURNOUT] = "转出诊断";
			items[EnumDiagnoseType.SURE] = "确诊诊断";
			items[EnumDiagnoseType.DEAD] = "死亡诊断";
			items[EnumDiagnoseType.OPSAFTER] = "术前诊";
			items[EnumDiagnoseType.INFECT] = "术后诊断";
			items[EnumDiagnoseType.DAMNIFY] = "感染诊断";
			items[EnumDiagnoseType.DAMNIFY] ="损伤中毒诊断";
			items[EnumDiagnoseType.COMPLICATION] = "并发症诊断";
			items[EnumDiagnoseType.PATHOLOGY] = "病理诊断";
			items[EnumDiagnoseType.SAVE] = "抢救诊断";
			items[EnumDiagnoseType.FAIL] = "病危诊断";
			items[EnumDiagnoseType.CLINIC] = "门诊诊断";
			items[EnumDiagnoseType.OTHER] = "其他诊断";
			items[EnumDiagnoseType.BALANCE] = "结算诊断";
		}

		#region 变量

        protected EnumDiagnoseType enuDimagnoseType;
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
				return this.enuDimagnoseType;
			}
		}

		#endregion  	
		
	}
//	#region 诊断类型枚举
//
//	public enum EnumDiagnoseType
//	{	
//		/// <summary>
//		/// 入院诊断
//		/// </summary>
//		IN = 1,
//		/// <summary>
//		/// 转入诊断
//		/// </summary>
//		TURNIN = 2,
//		/// <summary>
//		/// 出院诊断
//		/// </summary>
//		OUT = 3,
//		/// <summary>
//		/// 转出诊断
//		/// </summary>
//		TURNOUT = 4,
//		/// <summary>
//		/// 确诊诊断
//		/// </summary>
//		SURE = 5,
//		/// <summary>
//		/// 死亡诊断
//		/// </summary>
//		DEAD = 6,
//		/// <summary>
//		/// 术前诊断
//		/// </summary>
//		OPSFRONT = 7,
//		/// <summary>
//		/// 术后诊断
//		/// </summary>
//		OPSAFTER = 8,
//		/// <summary>
//		/// 感染诊断
//		/// </summary>
//		INFECT = 9,
//		/// <summary>
//		/// 损伤中毒诊断
//		/// </summary>
//		DAMNIFY = 10,
//		/// <summary>
//		/// 并发症诊断
//		/// </summary>
//		COMPLICATION = 11,
//		/// <summary>
//		/// 病理诊断
//		/// </summary>
//		PATHOLOGY = 12,
//		/// <summary>
//		/// 抢救诊断
//		/// </summary>
//		SAVE = 13,
//		/// <summary>
//		/// 病危诊断
//		/// </summary>
//		FAIL = 14,
//		/// <summary>
//		/// 门诊诊断
//		/// </summary>
//		CLINIC = 15,
//		/// <summary>
//		/// 其他诊断
//		/// </summary>
//		OTHER = 16,
//		/// <summary>
//		/// 结算诊断
//		/// </summary>
//		BALANCE = 17
//
//	};
//	#endregion
}
