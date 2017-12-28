using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Report 的摘要说明。
	/// </summary>
	public class Report:Neusoft.HISFC.Object.RADT.PatientInfo,Neusoft.HISFC.Object.Fee.IFeeItem
	{
		public Report()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public new Report Clone() {
			Neusoft.HISFC.Object.Fee.Report obj=base.MemberwiseClone() as Report;
			
			//			obj.SIMainInfo = this.SIMainInfo.Clone();
			return obj;
		}
		#region IFeeItem 成员
		private decimal feeCost1 = 0m;
		private decimal feeCost2 = 0m;
		private decimal feeCost3 = 0m;
		private decimal feeCost4 = 0m;
		private decimal feeCost5 = 0m;
		private decimal feeCost6 = 0m;
		private decimal feeCost7 = 0m;
		private decimal feeCost8 = 0m;
		private decimal feeCost9 = 0m;
		private decimal feeCost10 = 0m;

		private string feeItem1 = "";
		private string feeItem2 = "";
		private string feeItem3 = "";
		private string feeItem4 = "";
		private string feeItem5 = "";
		private string feeItem6 = "";
		private string feeItem7 = "";
		private string feeItem8 = "";
		private string feeItem9 = "";
		private string feeItem10 = "";
		private string feeItem11 = "";
		private string feeItem12 = "";
		private string feeItem13 = "";
		private string feeItem14 = "";
		private string feeItem15 = "";
		private string feeItem16 = "";
		private string feeItem17 = "";
		private string feeItem18 = "";
		private string feeItem19 = "";
		private string feeItem20 = "";
		private string feeItem21 = "";

		public string FeeItem1 {
			get {
				// TODO:  添加 Report.FeeItem1 getter 实现
				return this.feeItem1;
			}
			set {
				// TODO:  添加 Report.FeeItem1 setter 实现
				this.feeItem1 = value;
			}
		}

		public string FeeItem2 {
			get {
				// TODO:  添加 Report.FeeItem2 getter 实现
				return this.feeItem2;
			}
			set {
				// TODO:  添加 Report.FeeItem2 setter 实现
				this.feeItem2 = value;
			}
		}

		public string FeeItem3 {
			get {
				// TODO:  添加 Report.FeeItem3 getter 实现
				return this.feeItem3;
			}
			set {
				// TODO:  添加 Report.FeeItem3 setter 实现
				this.feeItem3 = value;
			}
		}

		public string FeeItem4 {
			get {
				// TODO:  添加 Report.FeeItem4 getter 实现
				return this.feeItem4;
			}
			set {
				// TODO:  添加 Report.FeeItem4 setter 实现
				this.feeItem4 = value;
			}
		}

		public string FeeItem5 {
			get {
				// TODO:  添加 Report.FeeItem5 getter 实现
				return this.feeItem5;
			}
			set {
				// TODO:  添加 Report.FeeItem5 setter 实现
				this.feeItem5 = value;
			}
		}

		public string FeeItem6 {
			get {
				// TODO:  添加 Report.FeeItem6 getter 实现
				return this.feeItem6;
			}
			set {
				// TODO:  添加 Report.FeeItem6 setter 实现
				this.feeItem6 = value;
			}
		}

		public string FeeItem7 {
			get {
				// TODO:  添加 Report.FeeItem7 getter 实现
				return this.feeItem7;
			}
			set {
				// TODO:  添加 Report.FeeItem7 setter 实现
				this.feeItem7 = value;
			}
		}

		public string FeeItem8 {
			get {
				// TODO:  添加 Report.FeeItem8 getter 实现
				return this.feeItem8;
			}
			set {
				// TODO:  添加 Report.FeeItem8 setter 实现
				this.feeItem8 = value;
			}
		}

		public string FeeItem9 {
			get {
				// TODO:  添加 Report.FeeItem9 getter 实现
				return this.feeItem9;
			}
			set {
				// TODO:  添加 Report.FeeItem9 setter 实现
				this.feeItem9 = value;
			}
		}

		public string FeeItem10 {
			get {
				// TODO:  添加 Report.FeeItem10 getter 实现
				return this.feeItem10;
			}
			set {
				// TODO:  添加 Report.FeeItem10 setter 实现
				this.feeItem10 = value;
			}
		}

		public string FeeItem11 {
			get {
				// TODO:  添加 Report.FeeItem11 getter 实现
				return this.feeItem11;
			}
			set {
				// TODO:  添加 Report.FeeItem11 setter 实现
				this.feeItem11 = value;
			}
		}

		public string FeeItem12 {
			get {
				// TODO:  添加 Report.FeeItem12 getter 实现
				return this.feeItem12;
			}
			set {
				// TODO:  添加 Report.FeeItem12 setter 实现
				this.feeItem12 = value;
			}
		}

		public string FeeItem13 {
			get {
				// TODO:  添加 Report.FeeItem13 getter 实现
				return this.feeItem13;
			}
			set {
				// TODO:  添加 Report.FeeItem13 setter 实现
				this.feeItem13 = value;
			}
		}

		public string FeeItem14 {
			get {
				// TODO:  添加 Report.FeeItem14 getter 实现
				return this.feeItem14;
			}
			set {
				// TODO:  添加 Report.FeeItem14 setter 实现
				this.feeItem14 = value;
			}
		}

		public string FeeItem15 {
			get {
				// TODO:  添加 Report.FeeItem15 getter 实现
				return this.feeItem15;
			}
			set {
				// TODO:  添加 Report.FeeItem15 setter 实现
				this.feeItem15 = value;
			}
		}

		public string FeeItem16 {
			get {
				// TODO:  添加 Report.FeeItem16 getter 实现
				return this.feeItem16;
			}
			set {
				// TODO:  添加 Report.FeeItem16 setter 实现
				this.feeItem16 = value;
			}
		}

		public string FeeItem17 {
			get {
				// TODO:  添加 Report.FeeItem17 getter 实现
				return this.feeItem17;
			}
			set {
				// TODO:  添加 Report.FeeItem17 setter 实现
				this.feeItem17 = value;
			}
		}

		public string FeeItem18 {
			get {
				// TODO:  添加 Report.FeeItem18 getter 实现
				return this.feeItem18;
			}
			set {
				// TODO:  添加 Report.FeeItem18 setter 实现
				this.feeItem18 = value;
			}
		}

		public string FeeItem19 {
			get {
				// TODO:  添加 Report.FeeItem19 getter 实现
				return this.feeItem19;
			}
			set {
				// TODO:  添加 Report.FeeItem19 setter 实现
				this.feeItem19 = value;
			}
		}

		public string FeeItem20 {
			get {
				// TODO:  添加 Report.FeeItem20 getter 实现
				return this.feeItem20;
			}
			set {
				// TODO:  添加 Report.FeeItem20 setter 实现
				this.feeItem20 = value;
			}
		}

		public string FeeItem21 {
			get {
				// TODO:  添加 Report.FeeItem21 getter 实现
				return this.feeItem21;
			}
			set {
				// TODO:  添加 Report.FeeItem21 setter 实现
				this.feeItem21 = value;
			}
		}

		public decimal FeeCost1 {
			get {
				// TODO:  添加 Report.FeeCost1 getter 实现
				return this.feeCost1;
			}
			set {
				// TODO:  添加 Report.FeeCost1 setter 实现
				this.feeCost1 = value;
			}
		}

		public decimal FeeCost2 {
			get {
				// TODO:  添加 Report.FeeCost2 getter 实现
				return this.feeCost2;
			}
			set {
				// TODO:  添加 Report.FeeCost2 setter 实现
				this.feeCost2 = value;
			}
		}

		public decimal FeeCost3 {
			get {
				// TODO:  添加 Report.FeeCost3 getter 实现
				return this.feeCost3;
			}
			set {
				// TODO:  添加 Report.FeeCost3 setter 实现
				this.feeCost3 = value;
			}
		}

		public decimal FeeCost4 {
			get {
				// TODO:  添加 Report.FeeCost4 getter 实现
				return this.feeCost4;
			}
			set {
				// TODO:  添加 Report.FeeCost4 setter 实现
				this.feeCost4 = value;
			}
		}

		public decimal FeeCost5 {
			get {
				// TODO:  添加 Report.FeeCost5 getter 实现
				return this.feeCost5;
			}
			set {
				// TODO:  添加 Report.FeeCost5 setter 实现
				this.feeCost5 = value;
			}
		}

		public decimal FeeCost6 {
			get {
				// TODO:  添加 Report.FeeCost6 getter 实现
				return this.feeCost6;
			}
			set {
				// TODO:  添加 Report.FeeCost6 setter 实现
				this.feeCost6 = value;
			}
		}

		public decimal FeeCost7 {
			get {
				// TODO:  添加 Report.FeeCost7 getter 实现
				return this.feeCost7;
			}
			set {
				// TODO:  添加 Report.FeeCost7 setter 实现
				this.feeCost7 = value;
			}
		}

		public decimal FeeCost8 {
			get {
				// TODO:  添加 Report.FeeCost8 getter 实现
				return this.feeCost8;
			}
			set {
				// TODO:  添加 Report.FeeCost8 setter 实现
				this.feeCost8 = value;
			}
		}

		public decimal FeeCost9 {
			get {
				// TODO:  添加 Report.FeeCost9 getter 实现
				return this.feeCost9;
			}
			set {
				// TODO:  添加 Report.FeeCost9 setter 实现
				this.feeCost9 = value;
			}
		}

		public decimal FeeCost10 {
			get {
				// TODO:  添加 Report.FeeCost10 getter 实现
				return this.feeCost10;
			}
			set {
				// TODO:  添加 Report.FeeCost10 setter 实现
				this.feeCost10 = value;
			}
		}

		#endregion
	}


	/// <summary>
	/// 公费最小费用21项目
	/// </summary>
	public interface IFeeItem {
		string FeeItem1{get;set;}
		string FeeItem2{get;set;}
		string FeeItem3{get;set;}
		string FeeItem4{get;set;}
		string FeeItem5{get;set;}
		string FeeItem6{get;set;}
		string FeeItem7{get;set;}
		string FeeItem8{get;set;}
		string FeeItem9{get;set;}
		string FeeItem10{get;set;}
		string FeeItem11{get;set;}
		string FeeItem12{get;set;}
		string FeeItem13{get;set;}
		string FeeItem14{get;set;}
		string FeeItem15{get;set;}
		string FeeItem16{get;set;}
		string FeeItem17{get;set;}
		string FeeItem18{get;set;}
		string FeeItem19{get;set;}
		string FeeItem20{get;set;}
		string FeeItem21{get;set;}

		decimal FeeCost1{get;set;}
		decimal FeeCost2{get;set;}
		decimal FeeCost3{get;set;}
		decimal FeeCost4{get;set;}
		decimal FeeCost5{get;set;}
		decimal FeeCost6{get;set;}
		decimal FeeCost7{get;set;}
		decimal FeeCost8{get;set;}
		decimal FeeCost9{get;set;}
		decimal FeeCost10{get;set;}
	}
}
