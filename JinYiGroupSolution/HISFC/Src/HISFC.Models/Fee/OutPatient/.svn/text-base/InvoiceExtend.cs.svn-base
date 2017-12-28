using System;

namespace Neusoft.HISFC.Object.Fee.OutPatient
{
	/// <summary>
	/// InvoiceExtend 的摘要说明。
	/// </summary>
	public class InvoiceExtend : Neusoft.NFC.Object.NeuObject 
	{
		public InvoiceExtend()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private string invoiceSeq;
		/// <summary>
		/// 发票序列
		/// </summary>
		public string InvoiceSeq
		{
			set
			{
				invoiceSeq = value;
			}
			get
			{
				return invoiceSeq;
			}
		}
		private string invoiceNo;//电脑号
		/// <summary>
		/// 电脑号
		/// </summary>
		public string InvoiceNo
		{
			set
			{
				invoiceNo = value;
			}
			get
			{
				return invoiceNo;
			}
		}
		private string realInvoiceNo;//实际发票号
		/// <summary>
		/// 实际发票号,发票上原始印的号
		/// </summary>
		public string RealInvoiceNo
		{
			set
			{
				realInvoiceNo = value;
			}
			get
			{
				return realInvoiceNo;
			}
		}
		private string windowsNo;//发药窗口
		/// <summary>
		/// 发药窗口
		/// </summary>
		public string WindowsNo
		{
			get
			{
				return windowsNo;
			}
			set
			{
				windowsNo = value;
			}
		}
		private string operCode;//操作员
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode
		{
			set
			{
				operCode = value;
			}
			get
			{
				return operCode;
			}
		}
		private DateTime operDate;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			set
			{
				operDate = value;
			}
			get
			{
				return operDate;
			}
		}
		/// <summary>
		/// Clone
		/// </summary>
		/// <returns></returns>
		public new Neusoft.HISFC.Object.Fee.OutPatient.InvoiceExtend Clone()
		{
			Neusoft.HISFC.Object.Fee.OutPatient.InvoiceExtend obj = base.Clone() as Neusoft.HISFC.Object.Fee.OutPatient.InvoiceExtend;

			return obj;
		}
	}
}
