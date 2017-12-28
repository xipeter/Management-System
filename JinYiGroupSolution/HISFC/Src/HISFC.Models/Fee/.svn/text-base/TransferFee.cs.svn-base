using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// TransferFee<br></br>
	/// [功能描述: 转入费用类]<br></br>
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
	public class TransferFee : NeuObject
	{
   
		#region 变量
		
		/// <summary>
		/// 转入医疗机构信息
		/// </summary>
		private NeuObject source = new NeuObject();
		
		/// <summary>
		/// 最小费用信息, 如果minFee.ID = "all"那么代表所有费用
		/// </summary>
		private NeuObject minFee = new NeuObject();
		
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
		/// 最小费用信息, 如果minFee.ID = "all"那么代表所有费用
		/// </summary>
		public NeuObject MinFee
		{
			get
			{
				return this.minFee;
			}
			set
			{
				this.minFee = value;
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
		public new TransferFee Clone()
		{
			TransferFee transferFee = base.Clone() as TransferFee;

			transferFee.FT = this.FT.Clone();
			transferFee.MinFee = this.MinFee.Clone();
			transferFee.Oper = this.Oper.Clone();
			transferFee.Pact = this.Pact.Clone();
			transferFee.Source = this.Source.Clone();
			transferFee.Type = this.Type.Clone();

			return transferFee;
		}

		#endregion

		#endregion

		#region 无用属性,方法
		/// <summary>
		/// 转入医疗机构编码
		/// </summary>
		[Obsolete("作废,用属性Source.ID代替", true)]
		public string  ChangeCode ;
		/// <summary>
		/// 最小费用
		/// </summary>
		[Obsolete("作废,用属性MinFee代替", true)]
		public Neusoft.FrameWork.Models.NeuObject Fee = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 转入类型
		/// </summary>
		[Obsolete("作废,用属性Type代替", true)]
		public Neusoft.FrameWork.Models.NeuObject ChangeType = new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 医疗流水号
		/// </summary>
		[Obsolete("作废,用属性base.ID代替", true)]
		public string ClinicNo ;
		/// <summary>
		/// 结算类型
		/// </summary>
		[Obsolete("作废,用属性Pact.PayKind代替", true)]
		public Neusoft.FrameWork.Models.NeuObject PayKind = new Neusoft.FrameWork.Models.NeuObject();
		

		/// <summary>
		/// 费用金额
		/// </summary>
		[Obsolete("作废,用属性FT.TotCost代替", true)]
		public decimal TotCost ;
		/// <summary>
		/// 自费金额
		/// </summary>
		[Obsolete("作废,用属性FT.OwnCost代替", true)]
		public decimal OwnCost;
		/// <summary>
		/// 自付金额
		/// </summary>
		[Obsolete("作废,用属性FT.PayCost代替", true)]
	    public decimal PayCost;
		/// <summary>
		/// 公费金额
		/// </summary>
		[Obsolete("作废,用属性FT.PubCost代替", true)]
		public decimal pubCost;
		/// <summary>
		/// 优惠金额
		/// </summary>
		[Obsolete("作废,用属性FT.EcoCost代替", true)]
		public decimal EcoCost;
		[Obsolete("作废,用属性BalanceNO代替", true)]
		public string BalanceNo;

		#endregion
	}
}
