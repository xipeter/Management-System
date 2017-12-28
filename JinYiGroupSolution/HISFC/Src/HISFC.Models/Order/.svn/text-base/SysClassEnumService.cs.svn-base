using System;
using System.Collections;


namespace Neusoft.HISFC.Object.Order
{

	/// <summary>
	/// Neusoft.HISFC.Object.Order.SysClassEnumService<br></br>
	/// [功能描述: 医嘱开立项目类别]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class SysClassEnumService:Neusoft.HISFC.Object.Base.EnumServiceBase {

		static SysClassEnumService()
		{
			items[EnumSysClass.M] = "描述医嘱";
			items[EnumSysClass.MC] = "会诊";
			items[EnumSysClass.MF] = "膳食";
			items[EnumSysClass.MRB] = "转床";
			items[EnumSysClass.MRD] = "转科";
			items[EnumSysClass.MRH] = "预约出院";
			items[EnumSysClass.P] = "西药";
			items[EnumSysClass.PCC] = "中草药";
			items[EnumSysClass.PCZ] = "中成药";
			items[EnumSysClass.U] = "非药品";
			items[EnumSysClass.UC] = "检查";
			items[EnumSysClass.UJ] = "计量";
			items[EnumSysClass.UN] = "护理级别";
			items[EnumSysClass.UO] = "手术";
			items[EnumSysClass.UT] = "其它";
			items[EnumSysClass.UZ] = "治疗";
		}

		#region 变量
			
		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();

		EnumSysClass enumSysClass;
		
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
				return this.enumSysClass;
			}
		}

		#endregion
		
		#region 变量
	
		
		/// <summary>
		/// 互斥
		/// </summary>
		protected EnumMutex myMutex= EnumMutex.None;
		#endregion

		


		/// <summary>
		/// 互斥
		/// </summary>
		public EnumMutex Mutex
		{
			get
			{
				return this.myMutex;
			}
			set
			{
				this.myMutex = value;
			}
		}


	
		#region 方法


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new SysClassEnumService Clone()
		{
			return base.Clone() as SysClassEnumService;
		}

		#endregion

	}
	#region 枚举

	/// <summary>
	/// 
	/// </summary>
	public enum EnumSysClass
	{
		/// <summary>
		/// 西药
		/// </summary>
		P = 0,
		/// <summary>
		/// 中成药
		/// </summary>
		PCZ = 1,
		/// <summary>
		/// 中草药
		/// </summary>
		PCC = 2,
		/// <summary>
		/// 描述医嘱
		/// </summary>
		M = 3,
		/// <summary>
		/// 护理级别
		/// </summary>
		UN = 4,
		/// <summary>
		/// 膳食
		/// </summary>
		MF = 5,
		/// <summary>
		///转科 
		/// </summary>
		MRD = 6,
		/// <summary>
		/// 转床
		/// </summary>
		MRB = 7,
		/// <summary>
		/// 预约出院
		/// </summary>
		MRH = 8,
		/// <summary>
		/// 会诊
		/// </summary>
		MC = 14,
		/// <summary>
		/// 非药品
		/// </summary>
		U = 9,
		/// <summary>
		/// 检验
		/// </summary>
		UL = 10,
		/// <summary>
		/// 检查
		/// </summary>
		UC = 11,
		/// <summary>
		/// 手术
		/// </summary>
		UO = 12,
		/// <summary>
		/// 治疗
		/// </summary>
		UZ = 13,
		/// <summary>
		/// 计量
		/// </summary>
		UJ = 15,
		/// <summary>
		/// 其它
		/// </summary>
		UT = 16
			
	}	

		
	#endregion

}
