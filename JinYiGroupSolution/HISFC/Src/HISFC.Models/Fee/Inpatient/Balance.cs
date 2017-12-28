using System;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// Balance<br></br>
	/// [功能描述: 住院结算类]<br></br>
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
		
		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime beginTime;
		
		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime endTime;
		
		/// <summary>
		/// 打印次数
		/// </summary>
		private int printTimes;
		
		/// <summary>
		/// 审核序号
		/// </summary>
		private string auditingNO;

		/// <summary>
		/// 是否主发票
		/// </summary>
		private bool isMainInvoice;
		
		/// <summary>
		/// 是否为生育保险最后结算
		/// </summary>
		private bool isLastBalance;
		
		#endregion

		#region  属性

		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}
		
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime		
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}
		
		/// <summary>
		/// 打印次数
		/// </summary>
		public int PrintTimes
		{
			get
			{
				return this.printTimes;
			}
			set
			{
				this.printTimes = value;
			}
		}
		
		/// <summary>
		/// 审核序号
		/// </summary>
		public string AuditingNO
		{
			get
			{
				return this.auditingNO;
			}
			set
			{
				this.auditingNO = value;
			}
		}
		
		/// <summary>
		/// 是否主发票
		/// </summary>
		public bool IsMainInvoice
		{
			get
			{
				return this.isMainInvoice;
			}
			set
			{
				this.isMainInvoice = value;
			}
		}
		
		/// <summary>
		/// 是否为生育保险最后结算
		/// </summary>
		public bool IsLastBalance
		{
			get
			{
				return this.isLastBalance;
			}
			set
			{
				this.isLastBalance = value;
			}
		}
		
		#endregion

		#region 无用变量属性
		/// <summary>
		/// 作废标记
		/// </summary>
		[Obsolete("作废,已经继承", true)]
		public string WasteFlag;
		
		/// <summary>
		/// 开始时间
		/// </summary>
		[Obsolete("作废,用BeginTime属性代替", true)]
		public DateTime DtBegin;
		/// <summary>
		/// 结束时间
		/// </summary>
			[Obsolete("作废,用EndTime属性代替", true)]
		public DateTime DtEnd;
        /// <summary>
        /// 结算时间
        /// </summary>
       [Obsolete("作废,已经继承", true)]
        public DateTime DtBalance;  
		
		/// <summary>
		/// 审核序号
		/// </summary>
		[Obsolete("作废,AuditingNO代替", true)]
		public string CheckNo;
		
		/// <summary>
		/// 结算类别
		/// </summary>已写成new Pact
		/// 设置成为属性  
		[Obsolete("作废,基类的Patient.Pact.PayKind代替", true)]
		public NeuObject PayKind = new NeuObject();
		/// <summary>
		/// 是否为生育保险最后结算
		/// </summary>
		[Obsolete("作废,IsLastBalance代替", true)]
		public bool IsLastFlag;
	
		[Obsolete("作废,已经继承", true)]
		public DateTime  DtWaste;

		#endregion
		
        #region 方法

        #region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前类的实例副本</returns>
		public new Balance Clone()
		{
			return base.Clone() as Balance;
		}

		#endregion
		
		#endregion
	}
}
