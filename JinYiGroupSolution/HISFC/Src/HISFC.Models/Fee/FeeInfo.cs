using System;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Object;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	///费用信息类 
	///ID住院流水号
	///name 患者姓名
	///
	/// </summary>
	public class FeeInfo:Neusoft.NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.IDept																						
	{
		/// <summary>
		/// 费用项目信息
		/// </summary>
		public FeeInfo()
		{
		}
		/// <summary>
		/// 处方流水号
		/// </summary>
		public string NoteNO;
		/// <summary>
		/// 住院科室
		/// </summary>
		private NeuObject InpatientDept=new NeuObject();
		/// <summary>
		/// 最小费用
		/// </summary>
		public NeuObject MinFee=new NeuObject();
		/// <summary>
		/// 开立医生
		/// </summary>
		private NeuObject Doctor=new NeuObject();
		/// <summary>
		/// 费用信息
		/// </summary>
		public FT Fee=new FT();
		/// <summary>
		/// 结算类别
		/// </summary>
		public NeuObject PayKind=new NeuObject();
		/// <summary>
		/// 执行科室
		/// </summary>
		protected NeuObject ExecDept=new NeuObject();
		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.NFC.Object.NeuObject  Pact=new NeuObject();
		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceSequance;
		/// <summary>
		/// 结算状态
		/// </summary>
		public string BalanceStatus;
		/// <summary>
		/// 婴儿标记
		/// </summary>
		public bool IsBaby;
		/// <summary>
		/// 开立科室
		/// </summary>
		private NeuObject RecDept = new NeuObject();
		/// <summary>
		/// 扣库科室
		/// </summary>
		private NeuObject StoDept = new NeuObject();
		/// <summary>
		/// 收费时间
		/// </summary>
		public DateTime DtFee = new DateTime();
		/// <summary>
		/// 交易类型 1 正交易 2 反交易
		/// </summary>
		public string  TransType;
		/// <summary>
		/// 划价员
		/// </summary>
		public NeuObject ChargeOper = new NeuObject();
		/// <summary>
		/// 划价时间
		/// </summary>
		public DateTime  DtCharge;
		/// <summary>
		/// 收费员
		/// </summary>
        public NeuObject FeeOper = new NeuObject();
		/// <summary>
		/// 结算员
		/// </summary>
		public NeuObject BalanceOper = new NeuObject();
		/// <summary>
		/// 结算时间
		/// </summary>
		public DateTime  DtBalance;
		/// <summary>
		/// 结算发票号
		/// </summary>
		public string BalanceInvoice;
		/// <summary>
		/// 审核序号
		/// </summary>
		public string CheckNo;
	    /// <summary>
	    /// 护士站
	    /// </summary>
		private NeuObject NurseCell = new NeuObject();
		/// <summary>
		/// 收费员科室
		/// </summary>
		public NeuObject FeeOperDept = new NeuObject();

		/// <summary>
		/// 扩展标志:中山一程序中用此字段表示是否为限制用药(即自费项目) 0非限制,1限制
		/// </summary>
		public string ExtFlag = "";
		/// <summary>
		/// 扩展标志1
		/// </summary>
		public string ExtFlag1 = "";
		/// <summary>
		/// 扩展标志2
		/// </summary>
		public string ExtFlag2 = "";
		/// <summary>
		/// 扩展编码
		/// </summary>
		public string ExtCode = "";
		/// <summary>
		/// 扩展人员编码
		/// </summary>
		public string ExtOperCode = "";
		/// <summary>
		/// 扩展日期
		/// </summary>
		public DateTime ExtDate;

		#region IDept 成员

		public NeuObject InDept
		{
			get
			{
				// TODO:  添加 FeeInfo.Neusoft.HISFC.Object.Base.IDept.InDept getter 实现
				return this.InpatientDept;
			}
			set
			{
				InpatientDept = value;
				// TODO:  添加 FeeInfo.Neusoft.HISFC.Object.Base.IDept.InDept setter 实现
			}
		}

		public NeuObject ExeDept
		{
			get
			{
				// TODO:  添加 FeeInfo.ExeDept getter 实现
				return this.ExecDept;
			}
			set
			{
				// TODO:  添加 FeeInfo.ExeDept setter 实现
				ExecDept = value;
			}
		}

		public NeuObject ReciptDept
		{
			get
			{
				// TODO:  添加 FeeInfo.ReciptDept getter 实现
				return this.RecDept;
			}
			set
			{
				// TODO:  添加 FeeInfo.ReciptDept setter 实现
				this.RecDept = value;
			}
		}

		public NeuObject NurseStation
		{
			get
			{
				// TODO:  添加 FeeInfo.NurseStation getter 实现
				return this.NurseCell;
			}
			set
			{
				// TODO:  添加 FeeInfo.NurseStation setter 实现
				this.NurseCell =value;
			}
		}

		public NeuObject StockDept
		{
			get
			{
				// TODO:  添加 FeeInfo.StockDept getter 实现
				return this.StoDept;
			}
			set
			{
				// TODO:  添加 FeeInfo.StockDept setter 实现
				this.StoDept = value;
			}
		}

		public NeuObject ReciptDoct
		{
			get
			{
				// TODO:  添加 FeeInfo.ReciptDoc getter 实现
				return this.Doctor;
			}
			set
			{
				// TODO:  添加 FeeInfo.ReciptDoc setter 实现
				this.Doctor=value;
			}
		}

		#endregion
		public new FeeInfo Clone()
		{
			FeeInfo Obj = base.Clone() as FeeInfo;
			Obj.InpatientDept= this.InpatientDept.Clone();
			Obj.MinFee=this.MinFee.Clone();
			Obj.Doctor=this.Doctor.Clone();
			Obj.Fee=this.Fee.Clone();
			Obj.PayKind=this.PayKind.Clone();
			Obj.Pact=this.Pact.Clone();
			Obj.ExecDept=this.ExecDept.Clone();
			Obj.StoDept=this.StoDept.Clone();
			Obj.RecDept=this.RecDept.Clone();
			Obj.NurseCell=this.NurseCell.Clone();
			Obj.ChargeOper=this.ChargeOper.Clone();
			Obj.FeeOper=this.FeeOper.Clone();
			Obj.FeeOperDept=this.FeeOperDept.Clone();
			return Obj;
		}
	}
}
