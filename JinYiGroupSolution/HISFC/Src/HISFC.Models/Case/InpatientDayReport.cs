using System;

namespace neusoft.HISFC.Object.Case {
	/// <summary>
	/// 住院日报实体
	/// ID   科室编码
	/// Name 科室名称
	/// </summary>
	public class InpatientDayReport: neusoft.neuFC.Object.neuObject {
		private System.DateTime myDateStat ;
		private neusoft.neuFC.Object.neuObject nurseStation = new neusoft.neuFC.Object.neuObject();
		private System.Int32 myBedStand ;
		private System.Int32 myBedAdd ;
		private System.Int32 myBedFree ;
		private System.Int32 myBeginningNum ;
		private System.Int32 myInNormal ;
		private System.Int32 myInEmergency ;
		private System.Int32 myInTransfer ;
		private System.Int32 myInTransferInner ;
		private System.Int32 myInReturn ;
		private System.Int32 myOutNormal ;
		private System.Int32 myOutTransfer ;
		private System.Int32 myOutTransferInner  ;
		private System.Int32 myOutWithdrawal ;
		private System.Int32 myEndNum ;
		private System.Int32 myDeadIn24 ;
		private System.Int32 myDeadOut24 ;
		private System.Decimal myBedRate ;
		private System.Int32 myOther1Num ;
		private System.Int32 myOther2Num ;
		private System.String myOperCode ;
		private System.DateTime myOperDate ;

		/// <summary>
		/// 住院日报实体
		/// ID   科室编码
		/// Name 科室名称
		/// </summary>
		public InpatientDayReport() {
			// TODO: 在此处添加构造函数逻辑
		}


		/// <summary>
		/// 统计日期
		/// </summary>
		public System.DateTime DateStat {
			get{ return this.myDateStat; }
			set{ this.myDateStat = value; }
		}

		
		/// <summary>
		/// 护士站
		/// </summary>
		public neusoft.neuFC.Object.neuObject  NurseStation {
			get{ return this.nurseStation; }
			set{ this.nurseStation = value; }
		}


		/// <summary>
		/// 编制内病床数
		/// </summary>
		public System.Int32 BedStand {
			get{ return this.myBedStand; }
			set{ this.myBedStand = value; }
		}


		/// <summary>
		/// 加床数
		/// </summary>
		public System.Int32 BedAdd {
			get{ return this.myBedAdd; }
			set{ this.myBedAdd = value; }
		}


		/// <summary>
		/// 空床数
		/// </summary>
		public System.Int32 BedFree {
			get{ return this.myBedFree; }
			set{ this.myBedFree = value; }
		}


		/// <summary>
		/// 期初病人数
		/// </summary>
		public System.Int32 BeginningNum {
			get{ return this.myBeginningNum; }
			set{ this.myBeginningNum = value; }
		}


		/// <summary>
		/// 常规入院数
		/// </summary>
		public System.Int32 InNormal {
			get{ return this.myInNormal; }
			set{ this.myInNormal = value; }
		}


		/// <summary>
		/// 急诊入院数
		/// </summary>
		public System.Int32 InEmergency {
			get{ return this.myInEmergency; }
			set{ this.myInEmergency = value; }
		}


		/// <summary>
		/// 其他科转入数
		/// </summary>
		public System.Int32 InTransfer {
			get{ return this.myInTransfer; }
			set{ this.myInTransfer = value; }
		}


		/// <summary>
		/// 其他科转入数(内部转入,中山一需求)
		/// </summary>
		public System.Int32 InTransferInner {
			get{ return this.myInTransferInner; }
			set{ this.myInTransferInner = value; }
		}


		/// <summary>
		/// 招回入院人数
		/// </summary>
		public System.Int32 InReturn {
			get{ return this.myInReturn; }
			set{ this.myInReturn = value; }
		}


		/// <summary>
		/// 常规出院数
		/// </summary>
		public System.Int32 OutNormal {
			get{ return this.myOutNormal; }
			set{ this.myOutNormal = value; }
		}


		/// <summary>
		/// 转出其他科数
		/// </summary>
		public System.Int32 OutTransfer {
			get{ return this.myOutTransfer; }
			set{ this.myOutTransfer = value; }
		}


		/// <summary>
		/// 转出其他科数(内部转出,中山一需求)
		/// </summary>
		public System.Int32 OutTransferInner {
			get{ return this.myOutTransferInner; }
			set{ this.myOutTransferInner = value; }
		}


		/// <summary>
		/// 退院人数
		/// </summary>
		public System.Int32 OutWithdrawal {
			get{ return this.myOutWithdrawal; }
			set{ this.myOutWithdrawal = value; }
		}


		/// <summary>
		/// 期末病人数
		/// </summary>
		public System.Int32 EndNum {
			get{ return this.myEndNum; }
			set{ this.myEndNum = value; }
		}


		/// <summary>
		/// 24小时内死亡数
		/// </summary>
		public System.Int32 DeadIn24 {
			get{ return this.myDeadIn24; }
			set{ this.myDeadIn24 = value; }
		}


		/// <summary>
		/// 24小时外死亡数
		/// </summary>
		public System.Int32 DeadOut24 {
			get{ return this.myDeadOut24; }
			set{ this.myDeadOut24 = value; }
		}


		/// <summary>
		/// 床位使用率
		/// </summary>
		public System.Decimal BedRate {
			get{ return this.myBedRate; }
			set{ this.myBedRate = value; }
		}


		/// <summary>
		/// 其他1数量
		/// </summary>
		public System.Int32 Other1Num {
			get{ return this.myOther1Num; }
			set{ this.myOther1Num = value; }
		}


		/// <summary>
		/// 其他2数量
		/// </summary>
		public System.Int32 Other2Num {
			get{ return this.myOther2Num; }
			set{ this.myOther2Num = value; }
		}


		/// <summary>
		/// 操作人
		/// </summary>
		public System.String OperCode {
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 整理日期
		/// </summary>
		public System.DateTime OperDate {
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}

	}
}