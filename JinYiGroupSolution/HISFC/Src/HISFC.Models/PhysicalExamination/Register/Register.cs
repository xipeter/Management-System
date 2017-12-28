using System;

namespace Neusoft.HISFC.Object.PhysicalExamination.Register
{
	/// <summary>
	/// Register <br></br>
	/// <br> ID - 体检序号 </br>
	/// <br> Name - 顾客姓名 </br>
	/// [功能描述: 体检登记]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Register : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Register()
		{
		}

		#region 变量


		/// <summary>
		/// 各种总金额
		/// </summary>
		private SumCost sumCost;

		/// <summary>
		/// 体检收费的发票信息
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Base.PE invoice;

		/// <summary>
		/// 合同单位
		/// </summary>
		private Neusoft.NFC.Object.NeuObject pact;

		/// <summary>
		/// 健康档案
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.HealthArchieve.HealthArchieve archieve;

		#endregion

		#region 属性


		/// <summary>
		/// 各种总金额
		/// </summary>
		public SumCost SumCost
		{
			get
			{
				return this.sumCost;
			}
			set
			{
				this.sumCost = value;
			}
		}

		/// <summary>
		/// 体检收费的发票信息
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Base.PE Invoice
		{
			get
			{
				return this.invoice;
			}
			set
			{
				this.invoice = value;
			}
		}

		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Pact
		{
			get
			{
				return this.pact;
			}
			set
			{
				this.pact = value;
			}
		}

		/// <summary>
		/// 健康档案
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.HealthArchieve.HealthArchieve Archieve
		{
			get
			{
				return this.archieve;
			}
			set
			{
				this.archieve = value;
			}
		}

		#endregion

		#region 方法


		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检登记</returns>
		public new Register Clone()
		{
			Register register = base.Clone() as Register;

			register.Invoice = this.Invoice;
			register.SumCost = this.SumCost.Clone();
			register.Pact = this.Pact.Clone();
			register.Archieve = this.Archieve.Clone();

			return register;
		}
		#endregion

	}
}
