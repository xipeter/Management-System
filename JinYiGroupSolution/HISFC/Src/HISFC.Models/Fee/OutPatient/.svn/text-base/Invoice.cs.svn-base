using System;

namespace Neusoft.HISFC.Object.Fee.OutPatient
{
	/// <summary>
	/// Invoice 继承Neusoft.NFC.Object.NeuObject
	/// ID 发票号
	/// 
	/// 作者: wangYu 编写于: 05/07/02
	/// </summary>
	public class Invoice : Neusoft.NFC.Object.NeuObject 
	{
		public Invoice() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Neusoft.HISFC.Object.Base.TransTypes transType  = new Neusoft.HISFC.Object.Base.TransTypes(); //交易类型
		/// <summary>
		/// 交易类型
		/// </summary>
		public Neusoft.HISFC.Object.Base.TransTypes TransType 
		{
			get 
			{
				return transType;
			}
			set 
			{
				transType = value;
			}
		}

		private string cardNo;//患者就诊卡号
		/// <summary>
		/// 患者就诊卡号
		/// </summary>
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

		private Neusoft.HISFC.Object.Fee.FT ft = new FT() ;
		/// <summary>
		/// 费用信息类
		/// </summary>
		public Neusoft.HISFC.Object.Fee.FT FT
		{
			get
			{
				return ft;
			}
			set
			{
				ft = value;
			}
		}
		private Neusoft.HISFC.Object.RADT.PID pID = new Neusoft.HISFC.Object.RADT.PID();
		/// <summary>
		/// 卡标识
		/// </summary>
		public Neusoft.HISFC.Object.RADT.PID PID
		{
			get
			{
				return pID;
			}
			set
			{
				pID = value;
			}
		}
		private DateTime regDate;
		/// <summary>
		/// 挂号日期
		/// </summary>
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
		private Neusoft.HISFC.Object.Fee.PayKind payKind = new PayKind();
		/// <summary>
		/// 结算类别
		/// </summary>
		public Neusoft.HISFC.Object.Fee.PayKind PayKind 
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

		private Neusoft.NFC.Object.NeuObject pactUnit = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.NFC.Object.NeuObject PactUnit 
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

		private Neusoft.NFC.Object.NeuObject medicalType = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 医疗类别
		/// </summary>
		public Neusoft.NFC.Object.NeuObject MedicalType
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
		private Neusoft.NFC.Object.NeuObject balanceOper = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 结算员
		/// </summary>
		public Neusoft.NFC.Object.NeuObject BalanceOper
		{
			get
			{
				return balanceOper;
			}
			set
			{
				balanceOper = value;
			}
		}

		private string examineFlag;
		/// <summary>
		/// 体检标志 0不是体检/1个人体检/2团体体检 
		/// </summary>
		public string ExamineFlag 
		{
			get
			{
				return examineFlag;
			}
			set
			{
				examineFlag = value;
			}
		}
		private Neusoft.HISFC.Object.Base.CancelTypes cancelFlag;
		//private bool isCancel = false;
		/// <summary>
		/// 作废标志
		/// </summary>
		public Neusoft.HISFC.Object.Base.CancelTypes CancelFlag
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

		private string cancelOper = "";
		/// <summary>
		/// 作废操作员
		/// </summary>
		public string CancelOper 
		{
			get
			{
				return cancelOper;
			}
			set
			{
				cancelOper = value;
			}
		}
		private DateTime cancelDate;
		/// <summary>
		/// 作废时间
		/// </summary>
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

		private Neusoft.NFC.Object.NeuObject checkOper = new Neusoft.NFC.Object.NeuObject() ;
		/// <summary>
		/// 核查人
		/// </summary>
		public Neusoft.NFC.Object.NeuObject CheckOper 
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
		private string invoiceSeq;//发票序号，一次结算产生多张发票的combNo
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNo
		/// </summary>
		public string InvoiceSeq
		{
			get
			{
				return invoiceSeq;
			}
			set
			{
				invoiceSeq = value;
			}
		}
		decimal myCTFee;//CT费
		/// <summary>
		/// CT费
		/// </summary>
		public decimal CTFee
		{
			get
			{
				return myCTFee;
			}
			set
			{
				myCTFee = value;
			}
		}
		decimal myMRIFee;//MRI费
		/// <summary>
		/// MRI费
		/// </summary>
		public decimal MRIFee
		{
			get
			{
				return myMRIFee;
			}
			set
			{
				myMRIFee = value;
			}
		}
		decimal mySXFee;//输血费
		/// <summary>
		/// 输血费
		/// </summary>
		public decimal SXFee
		{
			get
			{
				return mySXFee;
			}
			set
			{
				mySXFee = value;
			}
		}
		decimal mySYFee;//输氧费
		/// <summary>
		/// 输氧费
		/// </summary>
		public decimal SYFee
		{
			get
			{
				return mySYFee;
			}
			set
			{
				mySYFee = value;
			}
		}
		private DateTime printDisplayDate;//发票显示的打印时间
		/// <summary>
		/// 发票显示打印时间
		/// </summary>
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

		private InvoiceExtend invoiceExtend = new InvoiceExtend();
		/// <summary>
		/// 发票扩展
		/// </summary>
		public InvoiceExtend InvoiceExtend
		{
			get
			{
				return invoiceExtend;
			}
			set
			{
				invoiceExtend = value;
			}
		}

		/// <summary>
		/// 克隆本身
		/// </summary>
		/// <returns></returns>
		public new Neusoft.HISFC.Object.Fee.OutPatient.Invoice Clone()
		{
			Neusoft.HISFC.Object.Fee.OutPatient.Invoice obj = base.Clone() as Neusoft.HISFC.Object.Fee.OutPatient.Invoice;
			obj.TransType = this.transType;
			obj.FT = this.FT.Clone();
			obj.PID = this.PID.Clone();
			obj.PayKind = this.PayKind.Clone();
			obj.PactUnit = this.PactUnit.Clone();
			obj.MedicalType = this.MedicalType.Clone();
			obj.BalanceOper = this.BalanceOper.Clone();
			obj.CheckOper = this.CheckOper.Clone();
			obj.InvoiceExtend = this.InvoiceExtend.Clone();

			return obj;
		}
	}
}
