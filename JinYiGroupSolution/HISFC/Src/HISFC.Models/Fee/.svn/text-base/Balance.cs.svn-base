using System;
using System.Collections;
using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Balance 的摘要说明。
	/// id 结算序号
	/// 结算信息类
	/// </summary>
	public class Balance:Neusoft.NFC.Object.NeuObject 
	{
		public Balance()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 作废标记
		/// </summary>
		public string WasteFlag;
		/// <summary>
		/// 费用
		/// </summary>
		public FT Fee=new FT();
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime DtBegin;
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime DtEnd;
       /// <summary>
       /// 结算时间
       /// </summary>
        public DateTime DtBalance;  
		/// <summary>
		/// 结算类型
		///  0 在院结算 I
		/// 1转科结算 R
		/// 2 出院结算 O
		/// 3 重结算 M
		/// 4 结转 S
		/// </summary>
		public BalanceType BalanceType=new BalanceType();
		/// <summary>
		/// 发票
		/// </summary>
		public Invoice Invoice=new Invoice();
		/// <summary>
		/// 交易类型
		/// </summary>
		public string TransType;
        /// <summary>
		/// 结算操作员
		/// </summary>
		public NeuObject BalanceOper = new NeuObject();
		/// <summary>
		/// 打印次数(控制类控制补打相同发票号使用)
		/// </summary>
		public int PrintTimes;
		/// <summary>
		/// 财务组代码
		/// </summary>
		public NeuObject FinGrp = new NeuObject();
		/// <summary>
		/// 审核序号
		/// </summary>
		public string CheckNo;
		/// <summary>
		/// 合同单位
		/// </summary>
		public NeuObject Pact = new NeuObject();
		/// <summary>
		/// 结算类别
		/// </summary>
		public NeuObject PayKind = new NeuObject();
		/// <summary>
		/// 是否主发票
		/// </summary>
		public bool IsMainInvoice;
		/// <summary>
		/// 是否为生育保险最后结算
		/// </summary>
		public bool IsLastFlag;
		/// <summary>
		/// 结算员科室
		/// </summary>
		public NeuObject BalanceOperDept = new NeuObject();
		/// <summary>
		/// 作废操作员
		/// </summary>
		public NeuObject WasteOper = new NeuObject();
		/// <summary>
		/// 作废时间
		/// </summary>
		public DateTime  DtWaste;

	

		public new Balance Clone()
		{
			Balance obj = base.Clone() as Balance;
			obj.BalanceOper= this.BalanceOper.Clone();
			obj.Invoice=this.Invoice.Clone();//(Neusoft.HISFC.Object.Fee.Invoice)Invoice.Clone();

			obj.FinGrp=this.FinGrp.Clone();
			obj.BalanceType=this.BalanceType.Clone();
			obj.Fee=this.Fee.Clone();
			obj.Pact=this.Pact.Clone();
			obj.BalanceOperDept=this.BalanceOperDept.Clone();

			return obj;
		}

	}
}
