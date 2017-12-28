using System;
namespace Neusoft.HISFC.Models.Base
{	
	/// <summary>
	/// Bank<br></br>
	/// [功能描述: 银行实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Bank : Neusoft.FrameWork.Models.NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Bank()
		{
		}


		#region 变量

	

		/// <summary>
		/// 费用
		/// </summary>
		private FT fee = new FT();

		/// <summary>
		/// pos交易流水号或支票号
		/// </summary>
		private string invoiceNO = string.Empty;

		/// <summary>
		/// 帐号
		/// </summary>
		private string account = string.Empty;

		/// <summary>
		/// 开据单位
		/// </summary>
		private string workName = string.Empty;

		#endregion

		#region 属性

		/// <summary>
		/// 费用
		/// </summary>
		public FT Fee
		{
			get
			{
				return this.fee;
			}
			set
			{
				this.fee = value;
			}
		}


		/// <summary>
		/// pos交易流水号或支票号
		/// </summary>
		public string InvoiceNO
		{
			get
			{
				return this.invoiceNO;
			}
			set
			{
				this.invoiceNO = value;
			}
		}


		/// <summary>
		/// 帐号
		/// </summary>
		public string Account
		{
			get
			{
				return this.account;
			}
			set
			{
				this.account = value;
			}
		}


		/// <summary>
		/// 开据单位
		/// </summary>
		public string WorkName
		{
			get
			{
				return this.workName;
			}
			set
			{
				this.workName = value;
			}
		}

		#endregion

		#region 方法

		

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Bank Clone()
		{
			Bank bank ;
			bank = base.Clone() as Bank;
			bank.fee = this.fee.Clone();
			return bank;
		}
		#endregion

		#endregion

		

	}
}
