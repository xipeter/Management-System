using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{


	/// <summary>
	/// BalanceList<br></br>
	/// [功能描述: 费用结算明细类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>>
    /// 
    [System.Serializable]
	public class BalanceList : BalanceListBase 
	{
		public BalanceList( ) 
		{	
			this.balanceBase = new Balance();
		}

		#region 变量
		
		/// <summary>
		/// 发票内部流水号
		/// </summary>
		private int invoiceSquence;
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNo
		/// </summary>
		private string combNO;

        /// <summary>
        /// CT费
        /// </summary>
        decimal myCTFee;
        

        /// <summary>
        /// MRI费
        /// </summary>
        decimal myMRIFee;
        

        /// <summary>
        /// 输血费
        /// </summary>
        decimal mySXFee;
       
        /// <summary>
        /// 输氧费
        /// </summary>
        private decimal mySYFee;
        
		#endregion

		#region 属性

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
		/// 发票内部流水号
		/// </summary>
		public int InvoiceSquence
		{
			get
			{
				return this.invoiceSquence;
			}
			set
			{
				this.invoiceSquence = value;
			}
		}
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNo
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

		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例</returns>
		public new BalanceList Clone()
		{
			return base.Clone() as BalanceList;
		} 

		#endregion

		#endregion

		
		#region 无用 变量


		private int invoSequence;
		/// <summary>
		/// 发票内部流水号
		/// </summary>
		[Obsolete("作废,InvoiceSquence代替", true)]
		public int InvoSequence
		{
			get{return invoSequence;}
			set{invoSequence = value;}
		}

		private Neusoft.FrameWork.Models.NeuObject invoItem = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 发票科目
		/// </summary>
		[Obsolete("作废,FeeCodeStat代替", true)]
		public Neusoft.FrameWork.Models.NeuObject InvoItem 
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

		private Neusoft.FrameWork.Models.NeuObject execDept = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 执行科室
		/// </summary>
		[Obsolete("作废", true)]
		public Neusoft.FrameWork.Models.NeuObject ExecDept 
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
		[Obsolete("作废 Oper.OperTime", true)]
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

		private string balanceFlag;
		/// <summary>
		/// 日结标识1已日结/2未日结
		/// </summary>
		[Obsolete("作废 IsBalanced", true)]
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
		[Obsolete("无用", true)]
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
		[Obsolete("作废 BalanceOper.OperTime", true)]
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
		private Neusoft.HISFC.Models.Base.CancelTypes cancelFlag;
		/// <summary>
		/// 项目状态0正常，1退费，2重打，3注销 
		/// </summary>
		[Obsolete("作废 CancelType", true)]
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

		private string invoiceSeq;//发票序号，一次结算产生多张发票的combNo
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNo
		/// </summary>
		[Obsolete("作废 CombNO", true)]
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

		#endregion
	}
}
