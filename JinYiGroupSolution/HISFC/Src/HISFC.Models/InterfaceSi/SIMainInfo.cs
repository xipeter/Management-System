using System;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Object.InterfaceSi
{
	/// <summary>
	/// SIMainInfo 的摘要说明。
	/// Id inpatientNo, name 患者姓名
	/// </summary>
	public class SIMainInfo:neusoft.neuFC.Object.neuObject
	{
		public SIMainInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int feeTimes;
		/// <summary>
		/// 费用批次
		/// </summary>
		public int FeeTimes
		{
			set
			{
				feeTimes = value;
			}
			get
			{
				return feeTimes;
			}
		}
		private int readFlag;
		/// <summary>
		/// 读入标志
		/// </summary>
		public int ReadFlag
		{
			get
			{
				return readFlag;
			}
			set
			{
				readFlag = value;
			}
		}

		private string regNo;
		/// <summary>
		/// 就诊登记号、铁路医保个人编号
		/// </summary>
		public string RegNo
		{
			set
			{
				regNo = value;
			}
			get
			{
				return regNo;
			}
		}

		private string hosNo;
		/// <summary>
		/// 医院编号
		/// </summary>
		public string HosNo
		{
			set{hosNo = value;}
			get{return hosNo;}
		}

		private string balNo;
		/// <summary>
		///  结算序号
		/// </summary>
		public string BalNo
		{
			get
			{
				if(balNo == null || balNo == "")
				{
					balNo = "0";
				}
				return balNo;
			}
			set{balNo = value;}
		}
		private string invoiceNo;
		/// <summary>
		/// 主发票号
		/// </summary>
		public string InvoiceNo
		{
			get{return invoiceNo;}
			set{invoiceNo = value;}
		}
		private neusoft.neuFC.Object.neuObject medicalType = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 医疗类别 1-住院 2 -门诊特定项目
		/// </summary>
		public neusoft.neuFC.Object.neuObject MedicalType
		{
			get{return medicalType;}
			set{medicalType = value;}
		}
//		private string patientNo;
//		/// <summary>
//		/// 住院号
//		/// </summary>
//		public string PatientNo
//		{
//			get{return patientNo;}
//			set{patientNo = value;}
//		}
//		private string cardNo;
//		/// <summary>
//		/// 就诊卡号
//		/// </summary>
//		public string CardNo
//		{
//			get{return cardNo;}
//			set{cardNo = value;}
//		}
//		private string mCardNo;
//		/// <summary>
//		/// 医疗证号
//		/// </summary>
//		public string MCardNo
//		{
//			get{return mCardNo;}
//			set{mCardNo = value;}
//		}
		private string proceatePcNo;
		/// <summary>
		/// 生育保险患者电脑号
		/// </summary>
		public string ProceatePcNo
		{
			get{return proceatePcNo;}
			set{proceatePcNo = value;}
		}
		private DateTime siBeginDate;
		/// <summary>
		/// 参保日期
		/// </summary>
		public DateTime SiBegionDate
		{
			get{return siBeginDate;}
			set{siBeginDate = value;}
		}
		private string siState;
		/// <summary>
		/// 参保状态 3-参保缴费、4-暂停缴费、7-终止参保
		/// </summary>
		public string SiState
		{
			get{return siState;}
			set{siState = value;}
		}
		private string emplType;
		/// <summary>
		/// 人员类别 1-在职、2-退休
		/// </summary>
		public string EmplType
		{
			get{return emplType;}
			set{emplType = value;}
		}
		private string clinicDiagNose;
		/// <summary>
		/// 门诊诊断
		/// </summary>
		public string ClinicDiagNose
		{
			get{return clinicDiagNose;}
			set{clinicDiagNose = value;}
		}
		private DateTime inDiagnoseDate;
		/// <summary>
		/// 入院诊断日期
		/// </summary>
		public DateTime InDiagnoseDate
		{
			get{return inDiagnoseDate;}
			set{inDiagnoseDate = value;}
		}
		
		private neusoft.neuFC.Object.neuObject inDiagnose = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 入院诊断信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject InDiagnose
		{
			get{return inDiagnose;}
			set{inDiagnose = value;}
		}

		private decimal totCost;
		/// <summary>
		/// 住院总金额
		/// </summary>
		public decimal TotCost
		{
			get{return totCost;}
			set{totCost = value;}
		}
		private decimal payCost;
		/// <summary>
		/// 帐户支付金额
		/// </summary>
		public decimal PayCost
		{
			get{return payCost;}
			set{payCost = value;}
		}

		private decimal pubCost;
		/// <summary>
		/// 社保支付金额
		/// </summary>
		public decimal PubCost
		{
			get{return pubCost;}
			set{pubCost = value;}
		}

		private decimal itemPayCost;
		/// <summary>
		/// 部分项目自付金额 
		/// </summary>
		public decimal ItemPayCost
		{
			get{return itemPayCost;}
			set{itemPayCost = value;}
		}
		private decimal baseCost;
		/// <summary>
		/// 个人起付金额
		/// </summary>
		public decimal BaseCost
		{
			get{return baseCost;}
			set{baseCost = value;}
		}
		private decimal ownCost;
		/// <summary>
		/// 个人自费项目金额
		/// </summary>
		public decimal OwnCost
		{
			get{return ownCost;}
			set{ownCost = value;}
		}
		private decimal itemYLCost;
		/// <summary>
		/// 个人自付金额（乙类自付部分）
		/// </summary>
		public decimal ItemYLCost
		{
			get{return itemYLCost;}
			set{itemYLCost = value;}
		}

		private decimal pubOwnCost;
		/// <summary>
		/// 个人自负金额
		/// </summary>
		public decimal PubOwnCost
		{
			set{pubOwnCost = value;}
			get{return pubOwnCost;}
		}

		private decimal overTakeOwnCost;
		/// <summary>
		/// 超统筹支付限额个人自付金额
		/// </summary>
		public decimal OverTakeOwnCost
		{
			get{return overTakeOwnCost;}
			set{overTakeOwnCost = value;}
		}
		
		private decimal hosCost;
		/// <summary>
		/// 医药机构分担金额
		/// </summary>
		public decimal HosCost
		{
			set
			{
				hosCost = value;
			}
			get
			{
				return hosCost;
			}
		}

		private neusoft.neuFC.Object.neuObject operInfo = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 操作员信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject OperInfo
		{
			get{return operInfo;}
			set{operInfo = value;}
		}
		private DateTime operDate;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get{return operDate;}
			set{operDate = value;}
		}
		private int appNo;
		/// <summary>
		/// 审批号
		/// </summary>
		public int AppNo
		{
			get{return appNo;}
			set{appNo = value;}
		}
		private DateTime balanceDate;
		/// <summary>
		/// 结算时间
		/// </summary>
		public DateTime BalanceDate
		{
			get{return balanceDate;}
			set{balanceDate = value;}
		}
		private decimal yearCost;
		/// <summary>
		/// 本年度可用定额
		/// </summary>
		public decimal YearCost
		{
			get
			{
				return yearCost;
			}
			set
			{
				yearCost = value;
			}
		}
		private neusoft.neuFC.Object.neuObject outDiagnose = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 出院诊断
		/// </summary>
		public neusoft.neuFC.Object.neuObject OutDiagnose
		{
			set{outDiagnose = value;}
			get{return outDiagnose;}
		}
		
		private bool isValid;
		/// <summary>
		/// 是否有效 True有效 False 无效
		/// </summary>
		public bool IsValid
		{
			set
			{
				isValid = value;
			}
			get
			{
				return isValid;
			}
		}

		private bool isBalanced;
		/// <summary>
		/// 是否结算 True 结算 False 未结算
		/// </summary>
		public bool IsBalanced
		{
			get
			{
				return isBalanced;
			}
			set
			{
				isBalanced = value;
			}
		}


		#region 铁路医保附加属性
		#region 变量
		string icCardCode = "";
		neusoft.neuFC.Object.neuObject personType = new neuObject();
		neusoft.neuFC.Object.neuObject civilianGrade = new neuObject();
		neusoft.neuFC.Object.neuObject specialCare = new neuObject();
		string duty = "";
        neusoft.neuFC.Object.neuObject anotherCity = new neuObject();
		neusoft.neuFC.Object.neuObject corporation = new neuObject();
		decimal individualBalance = 0;
		string freezeMessage = "";
		string applySequence = "";
		neusoft.neuFC.Object.neuObject disease = new neuObject();
		neusoft.neuFC.Object.neuObject applyType = new neuObject();
		neusoft.neuFC.Object.neuObject fund = new neuObject();
		string businessSequence = "";
		neusoft.neuFC.Object.neuObject specialWorkKind = new neuObject();
		string hospitalBusinessSequence = "";
		string opositeBusinessSequence = "";
		#endregion
		/// <summary>
		/// IC卡号码
		/// </summary>
		public string ICCardCode
		{
			get
			{
				return this.icCardCode;
			}
			set
			{
				this.icCardCode = value;
			}
		}
		
		/// <summary>
		/// 人员类别
		/// </summary>
		public neusoft.neuFC.Object.neuObject PersonType
		{
			get
			{
				return this.personType;
			}
			set
			{
				this.personType = value;
			}
		}
		/// <summary>
		/// 公务员级别
		/// </summary>
		public neusoft.neuFC.Object.neuObject CivilianGrade
		{
			get
			{
				return this.civilianGrade;
			}
			set
			{
				this.civilianGrade = value;
			}
		}
		/// <summary>
		/// 特殊照顾人群
		/// </summary>
		public neusoft.neuFC.Object.neuObject SpecialCare
		{
			get
			{
				return this.specialCare;
			}
			set
			{
				this.specialCare = value;
			}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string Duty
		{
			get
			{
				return this.duty;
			}
			set
			{
				this.duty = value;
			}
		}
		/// <summary>
		/// 异地安置城市
		/// </summary>
		public neusoft.neuFC.Object.neuObject AnotherCity
		{
			get
			{
				return this.anotherCity;
			}
			set
			{
				this.anotherCity = value;
			}
		}
		/// <summary>
		/// 参保人单位
		/// </summary>
		public neusoft.neuFC.Object.neuObject Corporation
		{
			get
			{
				return this.corporation;
			}
			set
			{
				this.corporation = value;
			}
		}
		/// <summary>
		/// 个人帐户余额
		/// </summary>
		public decimal IndividualBalance
		{
			get
			{
				return this.individualBalance;
			}
			set
			{
				this.individualBalance = value;
			}
		}
		/// <summary>
		/// 已冻结基金信息
		/// </summary>
		public string FreezeMessage
		{
			get
			{
				return this.freezeMessage;
			}
			set
			{
				this.freezeMessage = value;
			}
		}
		/// <summary>
		/// 申请序号
		/// </summary>
		public string ApplySequence
		{
			get
			{
				return this.applySequence;
			}
			set
			{
				this.applySequence = value;
			}
		}
		/// <summary>
		/// 疾病
		/// </summary>
		public neusoft.neuFC.Object.neuObject Disease
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
		/// 申请类型
		/// </summary>
		public neusoft.neuFC.Object.neuObject ApplyType
		{
			get
			{
				return this.applyType;
			}
			set
			{
				this.applyType = value;
			}
		}
		/// <summary>
		/// 基金
		/// </summary>
		public neusoft.neuFC.Object.neuObject Fund
		{
			get
			{
				return this.fund;
			}
			set
			{
				this.fund = value;
			}
		}
		/// <summary>
		/// 业务序号
		/// </summary>
		public string BusinessSequence
		{
			get
			{
				return this.businessSequence;
			}
			set
			{
				this.businessSequence = value;
			}
		}
		/// <summary>
		/// 特殊工种
		/// </summary>
		public neusoft.neuFC.Object.neuObject SpecialWorkKind
		{
			get
			{
				return this.specialWorkKind;
			}
			set
			{
				this.specialWorkKind = value;
			}
		}
		/// <summary>
		/// 医院费用序列号
		/// </summary>
		public string HospitalBusinessSequence
		{
			get
			{
				return this.hospitalBusinessSequence;
			}
			set
			{
				this.hospitalBusinessSequence = value;
			}
		}
		/// <summary>
		/// 对应费用序列号
		/// </summary>
		public string OpositeBusinessSequence
		{
			get
			{
				return this.opositeBusinessSequence;
			}
			set
			{
				this.opositeBusinessSequence = value;
			}
		}

		public new SIMainInfo Clone()
		{
			SIMainInfo obj = base.Clone() as SIMainInfo;
			obj.medicalType = this.medicalType.Clone();
			obj.inDiagnose = this.inDiagnose.Clone();
			obj.operInfo = this.operInfo.Clone();
			obj.PersonType = this.PersonType.Clone();
			obj.CivilianGrade = this.CivilianGrade.Clone();
			obj.SpecialCare = this.SpecialCare.Clone();
			obj.AnotherCity = this.AnotherCity.Clone();
			obj.Corporation = this.Corporation.Clone();
			obj.Disease = this.Disease.Clone();
			obj.ApplyType = this.ApplyType.Clone();
			obj.Fund = this.Fund.Clone();
			obj.SpecialWorkKind = this.SpecialWorkKind.Clone();

			return obj;
		}
		#endregion
	}
}
