using System;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{
	/// <summary>
	/// Balance<br></br>
	/// [功能描述: 门诊结算类 ID:患者门诊流水号 Name:患者姓名]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Balance : BalanceBase 
	{
		#region 变量

        public Balance() 
        {
            this.Patient = new Neusoft.HISFC.Models.Registration.Register();  
        }

		/// <summary>
		/// 挂号日期
		/// </summary>
		private DateTime regTime;
		
		/// <summary>
		/// 体检标志 0不是体检/1个人体检/2团体体检 
		/// </summary>
		private string examineFlag;
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		private string combNO;
		
		/// <summary>
		/// 发票上的打印号
		/// </summary>
		private string printedInvoiceNO;
		
		/// <summary>
		/// 发药窗口信息
		/// </summary>
		private string drugWindowsNO;
		
		/// <summary>
		/// 日结标识号
		/// </summary>
		private string balanceID;

        /// <summary>
        /// 是否账户支付
        /// </summary>
        private bool isAccount = false;

        /// <summary>
        /// 发票组号
        /// </summary>
        private string invoiceCombo = string.Empty;

 
		#endregion

		#region 属性
		
		/// <summary>
		/// 挂号日期
		/// </summary>
		public DateTime RegTime
		{
			get
			{
				return this.regTime;
			}
			set
			{
				this.regTime = value;
			}
		}

		/// <summary>
		/// 体检标志 0不是体检/1个人体检/2团体体检 
		/// </summary>
		public string ExamineFlag
		{
			get
			{
				return this.examineFlag;
			}
			set
			{
				this.examineFlag = value;
			}
		}
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		public string CombNO
		{
			get
			{
				return this.combNO;
			}
			set
			{
				this.combNO = value;
			}
		}
		
		/// <summary>
		/// 发票上的打印号
		/// </summary>
		public string PrintedInvoiceNO
		{
			get
			{
				return this.printedInvoiceNO;
			}
			set
			{
				this.printedInvoiceNO = value;
			}
		}
		
		/// <summary>
		/// 发药窗口信息
		/// </summary>
		public string DrugWindowsNO
		{
			get
			{
				return this.drugWindowsNO;
			}
			set
			{
				this.drugWindowsNO = value;
			}
		}

		/// <summary>
		/// 日结标识号
		/// </summary>
		public string BalanceID
		{
			get
			{
				return this.balanceID;
			}
			set
			{
				this.balanceID = value;
			}
		}
        /// <summary>
        /// 是否账户集中打印发票
        /// </summary>
        public bool IsAccount
        {
            get
            {
                return isAccount;
            }
            set
            {
                isAccount = value;
            }
        }

        /// <summary>
        /// 发票组号
        /// </summary>
        public string InvoiceCombo
        {
            get { return invoiceCombo; }
            set { invoiceCombo = value; }
        }
		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例</returns>
		public new Balance Clone()
		{
			return base.Clone() as Balance;
		} 

		#endregion

		#endregion
		
		#region 无用变量,属性

		private string cardNo;//患者就诊卡号
		/// <summary>
		/// 患者就诊卡号
		/// </summary>
		[Obsolete("作废,已经继承Patinet.PID.CardNO", true)]
		public string CardNo 
		{
			get
			{
				return cardNo;
			}
			set
			{
				cardNo = value;
			}
		}

		private DateTime regDate;
		/// <summary>
		/// 挂号日期
		/// </summary>
		[Obsolete("作废,RegTime代替", true)]
		public DateTime RegDate
		{
			get
			{
				return regDate;
			}
			set
			{
				regDate = value;
			}
		}
		private string patientName = "";
		/// <summary>
		/// 患者姓名
		/// </summary>
		[Obsolete("作废,Base.Name", true)]
		public string PatientName 
		{
			get
			{
				return patientName;
			}
			set
			{
				patientName = value;
			}
		}
		private Neusoft.HISFC.Models.Base.PayKind payKind = new Neusoft.HISFC.Models.Base.PayKind();
		[Obsolete("作废,已经继承this.Patient.Pact.PayKind", true)]
		public Neusoft.HISFC.Models.Base.PayKind PayKind 
		{
			get
			{
				return payKind;
				
			}
			set
			{
				payKind = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject pactUnit = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 合同单位
		/// </summary>
		[Obsolete("作废,已经继承this.Patient.Pact", true)]
		public Neusoft.FrameWork.Models.NeuObject PactUnit 
		{
			get
			{
				return pactUnit;
			}
			set
			{
				pactUnit = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject medicalType = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 医疗类别
		/// </summary>
		[Obsolete("should use Pact property",true)]
		public Neusoft.FrameWork.Models.NeuObject MedicalType
		{
			get
			{
				return medicalType;
			}
			set
			{
				medicalType = value;
			}
		}
		
		private DateTime balanceDate;
		/// <summary>
		/// 结算日期
		/// </summary>
		[Obsolete("BalanceOper.OperTime",true)]
		public DateTime BalanceDate 
		{
			get
			{
				return balanceDate;
			}
			set
			{
				balanceDate = value;
			}
		}
		private Neusoft.FrameWork.Models.NeuObject balanceOper = new Neusoft.FrameWork.Models.NeuObject();

		
		private Neusoft.HISFC.Models.Base.CancelTypes cancelFlag;
		//private bool isCancel = false;
		/// <summary>
		/// 作废标志
		/// </summary>
		[Obsolete("CancelType",true)]
		public Neusoft.HISFC.Models.Base.CancelTypes CancelFlag
		{
			get
			{
				return cancelFlag;
			}
			set
			{
				cancelFlag = value;
			}
		}

		private string cancelInvoice = "";
		/// <summary>
		/// 作废票据号
		/// </summary>
		[Obsolete("canceledInvoiceNO",true)]
		public string CancelInvoice 
		{
			get
			{
				return cancelInvoice;
			}
			set
			{
				cancelInvoice = value;
			}
		}

		private DateTime cancelDate;
		/// <summary>
		/// 作废时间
		/// </summary>
		[Obsolete("CancelOper.OperTime",true)]
		public DateTime CancelDate 
		{
			get
			{
				return cancelDate;
			}
			set
			{
				cancelDate = value;
			}
		}

		private bool isCheck;
		/// <summary>
		/// 是否核查
		/// </summary>
		[Obsolete("IsAuditing",true)]
		public bool IsCheck 
		{
			get
			{
				return isCheck;
			}
			set
			{
				isCheck = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject checkOper = new Neusoft.FrameWork.Models.NeuObject() ;
		/// <summary>
		/// 核查人
		/// </summary>
		[Obsolete("AuditingOper.Oper",true)]
		public Neusoft.FrameWork.Models.NeuObject CheckOper 
		{
			get
			{
				return checkOper;
			}
			set
			{
				checkOper = value;
			}
		}

		private string checkDate = "";
		/// <summary>
		/// 核查时间
		/// </summary>
		[Obsolete("AuditingOper.OperTime",true)]
		public string CheckDate 
		{
			get
			{
				return checkDate;
			}
			set
			{
				checkDate = value;
			}
		}

		private DateTime dayBalanceDate ;
		/// <summary>
		/// 日结时间
		/// </summary>
		[Obsolete("DayBalanceOper.OperTime",true)]
		public DateTime DayBalanceDate 
		{
			get
			{
				return dayBalanceDate;
			}
			set
			{
				dayBalanceDate = value;
			}
		}
		
		private bool isBalanced;
		/// <summary>
		/// 是否日结
		/// </summary>
		[Obsolete("IsDayBalanced",true)]
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
		
		
		private DateTime printDisplayDate;//发票显示的打印时间
		/// <summary>
		/// 发票显示打印时间
		/// </summary>
		[Obsolete("PrintTime",true)]
		public DateTime PrintDisplayDate
		{
			get
			{
				return printDisplayDate;
			}
			set
			{
				printDisplayDate = value;
			}
		}
		private string clinicNO;//挂号流水号
		/// <summary>
		/// 挂号流水号
		/// </summary>
		[Obsolete("Base.ID",true)]
		public string ClinicNO
		{
			get
			{
				return clinicNO;
			}
			set
			{
				clinicNO = value;
			}
		}
		
		#endregion
	}
}
