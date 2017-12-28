using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// TransferPrepay<br></br>
	/// [功能描述: 转入预交金类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class TransferPrepay : NeuObject 
	{
		#region 变量
		
		/// <summary>
		/// 转入医疗机构信息
		/// </summary>
		private NeuObject source = new NeuObject();
		
		/// <summary>
		/// 转入类型 1 门诊转入，2 住院转入 3 分院转入   
		/// </summary>
		private NeuObject transferType = new NeuObject();
		
		/// <summary>
		/// 合同单位信息
		/// </summary>
		private PactInfo pact = new PactInfo();
		
		/// <summary>
		/// 费用信息
		/// </summary>
		private FT ft = new FT();
		
		/// <summary>
		/// 结算序号
		/// </summary>
		private string balanceNO;
		
		/// <summary>
		/// 结算状态
		/// </summary>
		private string balanceState;
		
		/// <summary>
		/// 操作信息(操作员,操作时间,操作科室)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();

		#endregion

		#region 属性
		
		/// <summary>
		/// 转入医疗机构信息
		/// </summary>
		public NeuObject Source
		{
			get
			{
				return this.source;
			}
			set
			{
				this.source = value;
			}
		}
		
		/// <summary>
		/// 转入类型 1 门诊转入，2 住院转入 3 分院转入   
		/// </summary>
		public NeuObject Type
		{
			get
			{
				return this.transferType;
			}
			set
			{
				this.transferType = value;
			}
		}
		
		/// <summary>
		/// 合同单位信息
		/// </summary>
		public PactInfo Pact
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
		/// 费用信息
		/// </summary>
		public FT FT
		{
			get
			{
				return this.ft;
			}
			set
			{
				this.ft = value;
			}
		}
		
		/// <summary>
		/// 结算序号
		/// </summary>
		public string BalanceNO
		{
			get
			{
				return this.balanceNO;
			}
			set
			{
				this.balanceNO = value;
			}
		}
		
		/// <summary>
		/// 结算状态
		/// </summary>
		public string BalanceState
		{
			get
			{
				return this.balanceState;
			}
			set
			{
				this.balanceState = value;
			}
		}
		
		/// <summary>
		/// 操作信息(操作员,操作时间,操作科室)
		/// </summary>
		public OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}
		
		#endregion
		
		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new TransferPrepay Clone()
		{
			TransferPrepay transferPrepay = base.Clone() as TransferPrepay;

			transferPrepay.FT = this.FT.Clone();
			transferPrepay.Oper = this.Oper.Clone();
			transferPrepay.Pact = this.Pact.Clone();
			transferPrepay.Source = this.Source.Clone();
			transferPrepay.Type = this.Type.Clone();

			return transferPrepay;
		}

		#endregion

		#endregion
		
		#region 无用属性,方法
		/// <summary>
		/// 转入类型
		/// </summary>
		[Obsolete("作废,用属性Type.ID代替", true)]
		public string ChangeType;
		/// <summary>
		/// 医疗流水号
		/// </summary>
		[Obsolete("作废,用属性base.ID代替", true)]
		public string ClinicNo;
	
		/// <summary>
		/// 结算类别
		/// </summary>
		[Obsolete("作废,用属性Pact.PayKind代替", true)]
		public Neusoft.HISFC.Models.Base.PayKind payKind = new Neusoft.HISFC.Models.Base.PayKind();
		
		/// <summary>
		/// 转入预交金额
		/// </summary>
		[Obsolete("作废,用属性FT.TransPrepay代替", true)]
		public decimal ChangePrepayCost = 0m;
		/// <summary>
		/// 转入操作员
		/// </summary>
		[Obsolete("作废,用属性Oper代替", true)]
		public Neusoft.FrameWork.Models.NeuObject ChangeOper =new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 转入时间
		/// </summary>
		[Obsolete("作废,用属性Oper.OperTime代替", true)]
		public DateTime ChangeOperDate;

		#endregion
	}
}
