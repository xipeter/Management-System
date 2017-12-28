using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Bank 银行实体 id 银行id name 银行名称
	/// </summary>
	public class Bank:Neusoft.NFC.Object.NeuObject 
	{
		public Bank()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 费用
		/// </summary>
		public FT fee=new FT();
		/// <summary>
		/// pos交易流水号或支票号
		/// </summary>
		public string InvoiceNo;
		/// <summary>
		/// 帐号
		/// </summary>
		public string Account;
		/// <summary>
		/// 开据单位
		/// </summary>
		public string WorkName;
		public new Bank Clone()
		{
			Bank obj=base.Clone() as Bank;
			obj.fee=this.fee.Clone();
			return obj;
		}
	}
}
