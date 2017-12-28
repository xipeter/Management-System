using System.Collections;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// PatientTypeEnumService <br></br>
	/// [功能描述: 患者类别枚举服务实体]<br></br>
	/// [急诊 - E]<br></br>
	/// [住院 - I]<br></br>
	/// [门诊 - O]<br></br>
	/// [预约 - P]<br></br>
	/// [Recurring - R]<br></br>
	/// [孕妇 - B]<br></br>
	/// [体检 - C]<br></br>
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
    public class PatientTypeEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PatientTypeEnumService()
		{
			this.Items[EnumPatientType.E] = "急诊";
			this.Items[EnumPatientType.I] = "住院";
			this.Items[EnumPatientType.O] = "门诊";
			this.Items[EnumPatientType.P] = "预约";
			this.Items[EnumPatientType.R] = "Recurring";
			this.Items[EnumPatientType.B] = "孕妇";
			this.Items[EnumPatientType.C] = "体检";
		}

		#region 变量

		/// <summary>
		/// 患者类别
		/// </summary>
		Neusoft.HISFC.Models.RADT.EnumPatientType enumPatientType;

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
				return this.enumPatientType;
			}
		}

		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PatientTypeEnumService Clone()
		{
			PatientTypeEnumService patientTypeEnumService = base.Clone() as PatientTypeEnumService;

			return patientTypeEnumService;
		}

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

	/// <summary>
	/// 患者类别枚举
	/// </summary>
	public enum EnumPatientType
	{
		/// <summary>
		/// 急诊:0
		/// </summary>
		E,
		/// <summary>
		/// 住院:1
		/// </summary>
		I,
		/// <summary>
		/// 门诊:2
		/// </summary>
		O,
		/// <summary>
		/// 预约:3
		/// </summary>
		P,
		/// <summary>
		/// Recurring Patient--暂时不用:4
		/// </summary>
		R,
		/// <summary>
		/// 孕妇 --暂时不用:5
		/// </summary>
		B,
		/// <summary>
		/// 体检:6
		/// </summary>
		C
	};
}
