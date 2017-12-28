using System;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// BalancePay 的摘要说明。
	/// </summary>
	public class BalancePay
	{
		public BalancePay()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNo;
		/// <summary>
		/// 交易类型
		/// </summary>
		public string TransType;
		/// <summary>
		/// 交易种类
		/// </summary>
		public string TransKind;
		/// <summary>
		/// 支付方式
		/// </summary>
		public NeuObject PayType = new NeuObject();
		/// <summary>
		/// 金额
		/// </summary>
		public decimal Cost= 0m;
		/// <summary>
		/// 张数
		/// </summary>
		public int Qty;
		/// <summary>
		/// 银行实体
		/// </summary>
		public Bank Bank = new Bank();
		/// <summary>
		/// 返还补收标记 1补收2返还
		/// </summary>
		public string ReturnOrSupplyFlag;
		/// <summary>
		/// 结算人
		/// </summary>
		public NeuObject BalanceOper= new NeuObject();
		/// <summary>
		/// 结算时间
		/// </summary>
		public DateTime DtBalance;
		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceNo;
		public new BalancePay Clone()
		{
			BalancePay obj = new BalancePay() as BalancePay;
			obj.BalanceOper=this.BalanceOper.Clone();
			obj.Bank=this.Bank.Clone();
			obj.PayType=this.PayType.Clone();
			return obj;
		}

	}
}
