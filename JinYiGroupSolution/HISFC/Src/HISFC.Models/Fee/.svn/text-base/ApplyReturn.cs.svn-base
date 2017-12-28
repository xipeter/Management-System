using System;
using System.Collections;
using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Fee 
{
	public class ApplyReturn: Neusoft.NFC.Object.NeuObject 
	{
		private System.String myBillCode ;
		private System.String myInpatientNo ;
		private System.Boolean isBaby;
		private Neusoft.NFC.Object.NeuObject myDept = new Neusoft.NFC.Object.NeuObject();
		private Neusoft.NFC.Object.NeuObject myNurseCellCode = new Neusoft.NFC.Object.NeuObject();
		private System.String myDrugFlag ;
		private Neusoft.HISFC.Object.Base.Item item = new Neusoft.HISFC.Object.Base.Item();
		private System.Decimal myDays ;
		private System.String myPriceUnit ;
		private System.String myExecDpcd ;
		private System.String myOperCode ;
		private System.DateTime myOperDate ;
		private System.String myOperDpcd ;
		private System.String myRecipeNo ;
		private System.Int32 mySequenceNo ;
		private string myBillNo;
		private System.String myConfirmFlag ;
		private System.String myConfirmDpcd ;
		private System.String myConfirmCode ;
		private System.DateTime myConfirmDate ;
		private System.String myChargeFlag ;
		private System.String myChargeCode ;
		private System.DateTime myChargeDate ;
		private string extFlag3 ; //  1 包装 单位 0, 最小单位    

		/// <summary>
		/// 退费申请实体
		/// ID    申请流水号
		/// Name  患者姓名
		/// </summary>
		public ApplyReturn() 
		{
			// TODO: 在此处添加构造函数逻辑
		}


		/// <summary>
		/// 申请单据号
		/// </summary>
		public System.String BillCode 
		{
			get{ return this.myBillCode; }
			set{ this.myBillCode = value; }
		}


		/// <summary>
		/// 住院流水号
		/// </summary>
		public System.String InpatientNo 
		{
			get{ return this.myInpatientNo; }
			set{ this.myInpatientNo = value; }
		}


		/// <summary>
		/// 婴儿标记
		/// </summary>
		public System.Boolean IsBaby 
		{
			get{ return this.isBaby; }
			set{ this.isBaby = value; }
		}


		/// <summary>
		/// 患者所在科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Dept 
		{
			get{ return this.myDept; }
			set{ this.myDept = value; }
		}


		/// <summary>
		/// 所在病区
		/// </summary>
		public Neusoft.NFC.Object.NeuObject NurseCellCode 
		{
			get{ return this.myNurseCellCode; }
			set{ this.myNurseCellCode = value; }
		}


		/// <summary>
		/// 药品标志,1药品/2非药
		/// </summary>
		public System.String DrugFlag 
		{
			get{ return this.myDrugFlag; }
			set{ this.myDrugFlag = value; }
		}


		/// <summary>
		/// 收费项目信息(药品/非药品)
		/// </summary>
		public Neusoft.HISFC.Object.Base.Item Item 
		{
			get{return this.item;}
			set{this.item = value;}
		}


		/// <summary>
		/// 付数
		/// </summary>
		public System.Decimal Days 
		{
			get{ return this.myDays; }
			set{ this.myDays = value; }
		}


		/// <summary>
		/// 计价单位
		/// </summary>
		public System.String PriceUnit 
		{
			get{ return this.myPriceUnit; }
			set{ this.myPriceUnit = value; }
		}


		/// <summary>
		/// 执行科室
		/// </summary>
		public System.String ExecDpcd 
		{
			get{ return this.myExecDpcd; }
			set{ this.myExecDpcd = value; }
		}


		/// <summary>
		/// 操作员编码
		/// </summary>
		public System.String OperCode 
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		public System.DateTime OperDate 
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		/// <summary>
		/// 操作员所在科室
		/// </summary>
		public System.String OperDpcd 
		{
			get{ return this.myOperDpcd; }
			set{ this.myOperDpcd = value; }
		}


		/// <summary>
		/// 对应收费明细处方号
		/// </summary>
		public System.String RecipeNo 
		{
			get{ return this.myRecipeNo; }
			set{ this.myRecipeNo = value; }
		}


		/// <summary>
		/// 对应处方内流水号
		/// </summary>
		public System.Int32 SequenceNo 
		{
			get{ return this.mySequenceNo; }
			set{ this.mySequenceNo = value; }
		}

		
		/// <summary>
		/// 退费单据号 门诊系统中保存退费的发票号
		/// </summary>
		public string BillNo
		{
			get
			{
				return this.myBillNo;
			}
			set
			{
				this.myBillNo = value;
			}
		}

		/// <summary>
		/// 退药确认标识 0未确认/1确认
		/// </summary>
		public System.String ConfirmFlag 
		{
			get{ return this.myConfirmFlag; }
			set{ this.myConfirmFlag = value; }
		}


		/// <summary>
		/// 确认科室代码
		/// </summary>
		public System.String ConfirmDpcd 
		{
			get{ return this.myConfirmDpcd; }
			set{ this.myConfirmDpcd = value; }
		}


		/// <summary>
		/// 确认人编码
		/// </summary>
		public System.String ConfirmCode 
		{
			get{ return this.myConfirmCode; }
			set{ this.myConfirmCode = value; }
		}


		/// <summary>
		/// 确认时间
		/// </summary>
		public System.DateTime ConfirmDate 
		{
			get{ return this.myConfirmDate; }
			set{ this.myConfirmDate = value; }
		}


		/// <summary>
		/// 退费标识 0未退费/1退费
		/// </summary>
		public System.String ChargeFlag 
		{
			get{ return this.myChargeFlag; }
			set{ this.myChargeFlag = value; }
		}


		/// <summary>
		/// 退费确认人
		/// </summary>
		public System.String ChargeCode 
		{
			get{ return this.myChargeCode; }
			set{ this.myChargeCode = value; }
		}


		/// <summary>
		/// 退费确认时间
		/// </summary>
		public System.DateTime ChargeDate 
		{
			get{ return this.myChargeDate; }
			set{ this.myChargeDate = value; }
		}

		/// <summary>
		/// 包装 单位 0, 最小单位
		/// </summary>
		public string ExtFlage3
		{
			get
			{
				return extFlag3;
			}
			set
			{
				extFlag3 = value;
			}
		}
	}
}