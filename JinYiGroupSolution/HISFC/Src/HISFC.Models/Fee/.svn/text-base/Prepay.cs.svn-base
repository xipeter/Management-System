using System;
 
using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 预交金费用信息类
	/// ID 发生序号 ,Name 患者姓名
	/// 
	/// </summary>
	public class Prepay:Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		///  预交金类
		/// </summary>
		public Prepay()
		{
		}
		/// <summary>
		///  预交金额
		/// </summary>
		public decimal Pre_Cost;
		/// <summary>
		/// 付费方式
		/// 
		/// </summary>
		public NeuObject PayType=new NeuObject();
		/// <summary>
		/// 患者科室
		/// </summary>
		public NeuObject Dept=new NeuObject();
		
		/// <summary>
		/// 结算发票号
		/// </summary>
		public string InvoiceNo;
		
		/// <summary>
		/// 统计日期
		/// </summary>
		public DateTime StatisticDate;
		/// <summary>
		/// 结算日期
		/// </summary>
		public DateTime DtBalanceDate;
		/// <summary>
		/// 结算员代码
		/// </summary>
		public NeuObject BalanceOper = new NeuObject();
		/// <summary>
		/// 结算状态
		/// </summary>
		public string BalanceStatus;
		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceSequece;
		/// <summary>
		/// 返回标记 三种状态
		/// </summary>
		public string PrepayState;
		/// <summary>
		/// 开户银行
		/// </summary>
		public Bank AccountBank=new Bank();
		/// <summary>
		/// 是否上缴
		/// </summary>
		public bool IsReport;
		/// <summary>
		/// 财务组代码
		/// </summary>
		public NeuObject FinGrpCode = new NeuObject();
		/// <summary>
		/// 转押金状态 0非转押金，1转押金，2转押金已打印
		/// </summary>
		public string  TransPrepayState;
		/// <summary>
		/// 转押金时间
		/// </summary>
		public DateTime DtTransPrepay;
		/// <summary>
		/// 预交金发票号
		/// </summary>
		public string ReceiptNo;
		/// <summary>
		/// 原发票号
		/// </summary>
		public string OldReceiptNo;
        /// <summary>
		/// 财务审核序号
		/// </summary>
		public string CheckNo;
		/// <summary>
		/// 转押金操作员
		/// </summary>
		public NeuObject TransPrepayOper = new NeuObject();
		/// <summary>
		/// 预交金操作员
		/// </summary>
		public NeuObject PrepayOper = new NeuObject();
		/// <summary>
		/// 操作员科室
		/// </summary>
		public NeuObject OperDept = new NeuObject();
		/// <summary>
		/// 预交金操作时间
		/// </summary>
		public DateTime DtOperate;
		/// <summary>
		/// 转押金时结算序号 
		/// </summary>
		public int ChangeBalanceNo;
		
		public new Prepay Clone()
		{
			Prepay obj = base.Clone() as Prepay;
			obj.PrepayOper=this.PrepayOper.Clone();
			obj.TransPrepayOper=this.TransPrepayOper.Clone();
			obj.FinGrpCode=this.FinGrpCode.Clone();
			obj.BalanceOper=this.BalanceOper.Clone();
			obj.AccountBank=this.AccountBank.Clone();
			obj.Dept=this.Dept.Clone();
			obj.PayType=this.PayType.Clone();
			obj.OperDept=this.OperDept.Clone();
			return obj;
		}
		
	}
}