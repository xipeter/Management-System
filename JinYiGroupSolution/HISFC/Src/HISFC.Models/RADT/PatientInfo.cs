using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// PatientInfo <br></br>
	/// [功能描述: 患者综合实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2004-05]<br></br>
    /// User01 User02 User03 已被住院预约登记使用
	/// <修改记录
    /// 
	///		修改人='赫一阳'
	///		修改时间='2006-09-11'
	///		修改目的='版本整合'
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PatientInfo : Neusoft.HISFC.Models.RADT.Patient 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PatientInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		
		}

		#region 变量

		/// <summary>
		/// 患者费用信息
		/// </summary>
		private FT ft = new FT();

		/// <summary>
		/// 患者访问类
		/// </summary>
		private Neusoft.HISFC.Models.RADT.PVisit pVisit = new Neusoft.HISFC.Models.RADT.PVisit();

		/// <summary>
		/// 担保类型
		/// </summary>
		private Neusoft.HISFC.Models.RADT.Caution caution = new Neusoft.HISFC.Models.RADT.Caution();

		/// <summary>
		/// 家属类
		/// </summary>
		private Neusoft.HISFC.Models.RADT.Kin kin = new Kin();

		/// <summary>
		/// 结算类别  01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干               
		/// </summary>
		private Neusoft.HISFC.Models.Base.PayKind payKind = new Neusoft.HISFC.Models.Base.PayKind();

		/// <summary>
		/// 疾病护理信息类
		/// </summary>
		private Neusoft.HISFC.Models.RADT.PDisease disease = new PDisease();

		/// <summary>
		/// 诊断
		/// </summary>
		private System.Collections.ArrayList diagnoses = new System.Collections.ArrayList(); 

		/// <summary>
		/// 医保患者基本信息,结算信息
		/// </summary>
		private Neusoft.HISFC.Models.SIInterface.SIMainInfo siMainInfo = new Neusoft.HISFC.Models.SIInterface.SIMainInfo();

		/// <summary>
		/// 扩展标记  目前用于中山一院 标志公医超日限额是否同意：0不同意，1同意
		/// </summary>
		private string extendFlag;

		/// <summary>
		/// 扩展标记1
		/// </summary>
		private string extendFlag1;

		/// <summary>
		/// 扩展标记2
		/// </summary>
		private string extendFlag2;

        /// <summary>
        /// 患者住院号类型
        /// </summary>
        private EnumPatientNOType patientNOType;
        /// <summary>
        /// 结算时间
        /// </summary>
        private DateTime balanceDate = DateTime.MinValue;
        /// <summary>
        /// 担保
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Surety surety = new Neusoft.HISFC.Models.Fee.Surety();

        /// <summary>
        /// 封帐标志{2FA0D4CE-E2EB-4bc7-975A-3693B71C62CF}
        /// </summary>
        private bool isStopAcount = false;
		#endregion

		#region 属性

		/// <summary>
		/// 患者费用信息
		/// </summary>
		public FT FT
		{
			get
			{
				return this.ft;
			}
			set
			{
				this.ft = value;
			}
		}

		/// <summary>
		/// 患者访问类
		/// </summary>
		public Neusoft.HISFC.Models.RADT.PVisit PVisit
		{
			get
			{
				return this.pVisit;
			}
			set
			{
				this.pVisit = value;
			}
		}

		/// <summary>
		/// 担保类型
		/// </summary>
        [Obsolete("已经过期,替换为Surety", true)]
		public Neusoft.HISFC.Models.RADT.Caution Caution
		{
			get
			{
				return this.caution;
			}
			set
			{
				this.caution = value;
			}
		}

		/// <summary>
		/// 家属类
		/// </summary>
		public Neusoft.HISFC.Models.RADT.Kin Kin
		{
			get
			{
				return this.kin;
			}
			set
			{
				this.kin = value;
			}
		}

		/// <summary>
		/// 结算类别  01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
		/// </summary>
		[Obsolete("已经过期，在Patient属性中的Pact已经包含", true)]
		public Neusoft.HISFC.Models.Base.PayKind PayKind
		{
			get
			{
				return this.payKind;
			}
			set
			{
				this.payKind = value;
			}
		}

		/// <summary>
		/// 疾病护理信息类
		/// </summary>
		public Neusoft.HISFC.Models.RADT.PDisease Disease
		{
			get
			{
				return this.disease;
			}
			set
			{
				this.disease = value;
			}
		}

		/// <summary>
		/// 诊断
		/// </summary>
		public System.Collections.ArrayList Diagnoses
		{
			get
			{
				return this.diagnoses;
			}
			set
			{
				this.diagnoses = value;
			}
		}

		/// <summary>
		/// 医保患者基本信息,结算信息
		/// </summary>
		public Neusoft.HISFC.Models.SIInterface.SIMainInfo SIMainInfo
		{
			get
			{
				return this.siMainInfo;
			}
			set
			{
				this.siMainInfo = value;
			}
		}

		/// <summary>
		/// 扩展标记  目前用于中山一院 标志公医超日限额是否同意：0不同意，1同意
		/// </summary>
		public string ExtendFlag
		{
			get
			{
				return this.extendFlag;
			}
			set
			{
				this.extendFlag = value;
			}
		}

		/// <summary>
		/// 扩展标记1
		/// </summary>
		public string ExtendFlag1
		{
			get
			{
				return this.extendFlag1;
			}
			set
			{
				this.extendFlag1 = value;
			}
		}

		/// <summary>
		/// 扩展标记2
		/// </summary>
		public string ExtendFlag2
		{
			get
			{
				return this.extendFlag2;
			}
			set
			{
				this.extendFlag2 = value;
			}
		}

        /// <summary>
        /// 患者住院号类型
        /// </summary>
        public EnumPatientNOType PatientNOType 
        {
            get 
            {
                return this.patientNOType;
            }
            set 
            {
                this.patientNOType = value;
            }
        }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime BalanceDate
        {
            get
            {
                return this.balanceDate;
            }
            set
            {
                this.balanceDate = value;
            }
        }
        /// <summary>
        /// 担保
        /// </summary>
        public Neusoft.HISFC.Models.Fee.Surety Surety
        {
            get
            {
                return surety;
            }
            set
            {
                surety = value;
            }
        }

        /// <summary>
        /// 封帐标志{2FA0D4CE-E2EB-4bc7-975A-3693B71C62CF}
        /// </summary>
        public bool IsStopAcount
        {
            get { return isStopAcount; }
            set { isStopAcount = value; }
        }
		#endregion

		#region 过期

		/// <summary>
		/// 患者费用信息
		/// </summary>
		[Obsolete("已经过期，更改为FT", true)]
		public FT Fee=new FT();

		/// <summary>
		/// 患者基本信息
		/// </summary>
		private Neusoft.HISFC.Models.RADT.Patient patient = new Neusoft.HISFC.Models.RADT.Patient();

		/// <summary>
		/// 患者基本信息
		/// </summary>
		[System.Obsolete("已经过期，更改为继承",true)]
		public Neusoft.HISFC.Models.RADT.Patient Patient
		{
			get
			{
				return this.patient;
			}
			set
			{
				this.patient = value;
			}
		}
		
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PatientInfo Clone()
        {
            #region addby xuewj 2010-8-30 浅克隆无法克隆引用类型 {7CBA264D-7659-4cfb-9329-10F60A0A753D}
            //PatientInfo patientInfo = base.MemberwiseClone() as PatientInfo;
            PatientInfo patientInfo = base.Clone() as PatientInfo;
            #endregion
            patientInfo.FT = this.FT.Clone();
			patientInfo.PVisit = this.PVisit.Clone();
			//patientInfo.Caution = this.Caution.Clone();
			patientInfo.Kin = this.Kin.Clone();
			patientInfo.Disease = this.Disease.Clone();
			patientInfo.Diagnoses = ( System.Collections.ArrayList)this.Diagnoses.Clone();
            patientInfo.Surety = this.Surety.Clone();
//			obj.SIMainInfo = this.SIMainInfo.Clone();
			return patientInfo;
		}

		#endregion
	}
}
