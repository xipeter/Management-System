using System;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{
	/// <summary>
	/// BalancePay<br></br>
	/// [功能描述: 门诊支付方式类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-13]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class BalancePay : BalancePayBase
	{
		#region 变量
		
		/// <summary>
		/// 交易流水号
		/// </summary>
		private string squence;

		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		private string invoiceCombNO;

        /// <summary>
        /// 发票组号
        /// </summary>
        private string invoiceUnion;

  
		#endregion

		#region 属性
		
		/// <summary>
		/// 交易流水号
		/// </summary>
		public string Squence
		{
			get
			{
				return this.squence;
			}
			set
			{
				this.squence = value;
			}
		}

		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		public string InvoiceCombNO
		{
			get
			{
				return this.invoiceCombNO;
			}
			set
			{
				this.invoiceCombNO = value;
			}
		}

        /// <summary>
        /// 发票组号
        /// </summary>
        public string InvoiceUnion
        {
            get { return invoiceUnion; }
            set { invoiceUnion = value; }
        }
		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例</returns>
		public new BalancePay Clone()
		{
			return base.Clone() as BalancePay;
		} 

		#endregion

		#endregion
	}
}
