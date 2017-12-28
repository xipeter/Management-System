using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// FeeItemBase<br></br>
	/// [功能描述: 住院费用信息类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-13]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class FeeInfo : Inpatient.FeeItemList																			
	{
		public FeeInfo()
		{
			this.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
		}
		
		#region 变量
		
		#endregion

		#region 属性

		#endregion
		
		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new FeeInfo Clone()
		{
			FeeInfo feeInfo = base.Clone() as FeeInfo;
			
			return feeInfo;
		}

		#endregion

		#endregion

		#region 接口实现

		#region IBaby 成员

		#endregion

		#endregion
		
		#region 无用属性变量

		/// <summary>
		/// 扩展人员编码
		/// </summary>
		[Obsolete("作废,基类ExtOper代替", true)]
		public string ExtOperCode = "";
		/// <summary>
		/// 扩展日期
		/// </summary>
		[Obsolete("作废,基类ExtOper.OperTime代替", true)]
		public DateTime ExtDate;

		/// <summary>
		/// 处方流水号
		/// </summary>
		[Obsolete("作废,基类RecipeNO代替", true)]
		public string NoteNO;
		/// <summary>
		/// 费用信息
		/// </summary>
		[Obsolete("作废,基类FT代替", true)]
		public FT Fee=new FT();
		/// <summary>
		/// 结算类别
		/// </summary>
		[Obsolete("作废,基类Patient.Pact.PayKind代替", true)]
		public NeuObject PayKind=new NeuObject();
		/// <summary>
		/// 合同单位
		/// </summary>
		[Obsolete("作废,基类Patient.Pact代替", true)]
		public Neusoft.FrameWork.Models.NeuObject  Pact=new NeuObject();
		/// <summary>
		/// 结算序号
		/// </summary>
		[Obsolete("作废,BalanceNO代替", true)]
		public int BalanceSequance;
		/// <summary>
		/// 结算状态
		/// </summary>
		[Obsolete("作废,基类BalanceState代替", true)]
		public string BalanceStatus;
		
		/// <summary>
		/// 收费时间
		/// </summary>
		[Obsolete("作废,基类FeeOper.OperTime代替", true)]
		public DateTime DtFee = new DateTime();

		/// <summary>
		/// 划价时间
		/// </summary>
		[Obsolete("作废,基类ChargeOper.OperTime代替", true)]
		public DateTime  DtCharge;
	
		/// <summary>
		/// 结算时间
		/// </summary>
		[Obsolete("作废,基类BalanceOper.OperTime代替", true)]
		public DateTime  DtBalance;
		/// <summary>
		/// 结算发票号
		/// </summary>
		[Obsolete("作废,基类Invoice.ID代替", true)]
		public string BalanceInvoice;
		/// <summary>
		/// 审核序号
		/// </summary>
		[Obsolete("作废,基类AuditingNO代替", true)]
		public string CheckNo;
	   
		/// <summary>
		/// 收费员科室
		/// </summary>
		[Obsolete("作废,基类FeeOper.Dept代替", true)]
		public NeuObject FeeOperDept = new NeuObject();

		/// <summary>
		/// 开单医生
		/// </summary>
		[Obsolete("作废,基类RecipeOper代替", true)]
		public NeuObject ReciptDoctor = new NeuObject();

		#endregion		
	}
}
