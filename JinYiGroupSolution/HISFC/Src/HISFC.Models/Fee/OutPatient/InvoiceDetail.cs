using System;

namespace Neusoft.HISFC.Object.Fee.OutPatient
{
	/// <summary>
	/// InvoiceDetail 的摘要说明。write by lisn
	/// Id发票号
	/// </summary>
	public class InvoiceDetail: Neusoft.NFC.Object.NeuObject
	{
		public InvoiceDetail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Neusoft.HISFC.Object.Base.TransTypes transType = new Neusoft.HISFC.Object.Base.TransTypes(); //交易类型
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

		private int invoSequence;
		/// <summary>
		/// 发票内部流水号
		/// </summary>
		public int InvoSequence
		{
			get{return invoSequence;}
			set{invoSequence = value;}
		}

		private Neusoft.NFC.Object.NeuObject invoItem = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 发票科目
		/// </summary>
		public Neusoft.NFC.Object.NeuObject InvoItem 
		{
			get
			{
				return invoItem;
			}
			set
			{
				invoItem = value;
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

		private Neusoft.NFC.Object.NeuObject execDept = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 执行科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ExecDept 
		{
			get
			{
				return execDept;
			}
			set
			{
				execDept = value;
			}
		}

		private DateTime operDate;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate 
		{
			get
			{
				return operDate;
			}
			set
			{
				operDate = value;
			}
		}

		private string oper;
		/// <summary>
		/// 操作员
		/// </summary>
		public string Oper
		{
			get
			{
				return oper;
			}
			set
			{
				oper = value;
			}
		}

		private string balanceOper;
		/// <summary>
		/// 日结人员
		/// </summary>
		public string BalanceOper
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

		private string balanceFlag;
		/// <summary>
		/// 日结标识1已日结/2未日结
		/// </summary>
		public string BalanceFlag
		{
			get
			{
				return balanceFlag;
			}
			set
			{
				balanceFlag = value;
			}
		}


		private string balanceNo;
		/// <summary>
		/// 日结标识号
		/// </summary>
		public string BalanceNo
		{
			get
			{
				return balanceNo;
			}
			set
			{
				balanceNo = value;
			}
		}

		private DateTime balanceDate;
		/// <summary>
		/// 日结标识号
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
		private Neusoft.HISFC.Object.Base.CancelTypes cancelFlag;
		/// <summary>
		/// 项目状态0正常，1退费，2重打，3注销 
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


		/// <summary>
		/// 克隆本身
		/// </summary>
		/// <returns></returns>
		public new Neusoft.HISFC.Object.Fee.OutPatient.InvoiceDetail Clone()
		{
			Neusoft.HISFC.Object.Fee.OutPatient.InvoiceDetail obj = base.Clone() as Neusoft.HISFC.Object.Fee.OutPatient.InvoiceDetail;
			
			obj.TransType = this.transType;
			obj.InvoItem = this.InvoItem.Clone();
			obj.FT = this.FT.Clone();
			obj.ExecDept = this.ExecDept.Clone();


			return obj;
		}


	}
}
