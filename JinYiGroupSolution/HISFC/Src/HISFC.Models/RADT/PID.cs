using System;
 
namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// PID <br></br>
	/// [功能描述: 患者各种号码,ID - 住院号]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2004-05]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-09-11'
	///		修改目的='版本整合'
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PID : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 患者索引号
		/// </summary>
		public PID()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		
		}

		#region 变量

		/// <summary>
		/// 门诊卡号
		/// </summary>
		private string cardNO;

		/// <summary>
		/// 病历号
		/// </summary>
		private string caseNO;

		/// <summary>
		/// 健康档案号(体检号)
		/// </summary>
		private string healthNO;

		/// <summary>
		/// 母亲住院流水号.如果患者是婴儿,那么用于对于母亲的住院流水号
		/// </summary>
		private string motherInpatientNO = "";

		#endregion

		#region 属性

		/// <summary>
		/// 门诊卡号
		/// </summary>
		public string CardNO
		{
			get
			{
				return this.cardNO;
			}
			set
			{
				this.cardNO = value;
			}
		}

		/// <summary>
		/// 病历号
		/// </summary>
		public string CaseNO
		{
			get
			{
				return this.caseNO;
			}
			set
			{
				this.caseNO = value;
			}
		}

		/// <summary>
		/// 住院号
		/// </summary>
		public string PatientNO
		{
			get
			{
				return this.ID;
			}
			set
			{
				this.ID=value;
			}
		}

		/// <summary>
		/// 健康档案号(体检号)
		/// </summary>
		public string HealthNO
		{
			get
			{
				return this.healthNO;
			}
			set
			{
				this.healthNO = value;
			}
		}

		/// <summary>
		/// 母亲住院流水号.如果患者是婴儿,用于对于母亲的住院流水号
		/// </summary>
		public string MotherInpatientNO
		{
			get
			{
				return this.motherInpatientNO;
			}
			set
			{
				this.motherInpatientNO = value;
			}
		}

		//		private string babyInpatientNo;
		//		/// <summary>
		//		/// 婴儿住院流水号, 专为婴儿主表用,用于关联住院主表的婴儿信息.
		//		/// </summary>
		//		public string BabyInpatientNo
		//		{
		//			get
		//			{
		//				return babyInpatientNo;
		//			}
		//			set
		//			{
		//				babyInpatientNo = value;
		//			}
		//		}

		#endregion

		#region 过期

		/// <summary>
		/// 门诊卡号
		/// </summary>
		[Obsolete("已经过期，更改为CardNO", true)]
		public string CardNo;

		/// <summary>
		/// 病历号
		/// </summary>
		[Obsolete("已经过期，更改为CaseNO", true)]
		public string RecordNo;

		/// <summary>
		/// 母亲住院流水号.如果患者是婴儿,此字段用于对于母亲的住院流水号
		/// </summary>
		[Obsolete("已经过期，更改为MotherInpatientNO", true)]
		public string MotherInpatientNo 
		{
			get 
			{
				return this.motherInpatientNO;
			}
			set 
			{
				motherInpatientNO = value;
			}
		}



		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PID Clone()
		{
			return this.MemberwiseClone() as PID;
		}

		#endregion
	}
}
