using System;

namespace neusoft.HISFC.Object.HealthCare
{
	/// <summary>
	/// 医疗证实体 
	/// 健康护理：通过由医学和相关的保健行业提供的服务预防、治疗和处理疾病，并保持心理和生理上的健康
	/// </summary>
	public class MedicalCard: neusoft.neuFC.Object.neuObject
	{
		private System.String myId ;
		private System.String myMcardNo ;
		private System.String myRegisterId ;
		private System.DateTime myRegisterDate ;
		private System.String myAutditingId ;
		private System.DateTime myAutditingDate ;
		private StatusTypeENUM myStatus ;
		private System.String myBlockId ;
		private System.DateTime myBlockDate ;

		public MedicalCard() 
		{
			// TODO: 在此处添加构造函数逻辑
		}
	

		/// <summary>
		/// 业务序号
		/// </summary>
		public System.String Id
		{
			get{ return this.myId; }
			set{ this.myId = value; }
		}


        /// <summary>
        /// 员工基本信息
        /// </summary>
		public Object.RADT.Person EmployeeInfo=new Object.RADT.Person();

		/// <summary>
		/// 人员分类1 人事科对人员进行的分类，跟工号的开头字母有联系，
		/// 比如1字开头的是行政机关人员，2字开头的是医教人员等
		/// </summary>
		public neusoft.neuFC.Object.neuObject EmplKind1 = new neusoft.neuFC.Object.neuObject();
	
		/// <summary>
		/// 人员分类2 院内合同人员，博士后等
		/// </summary>
		public neusoft.neuFC.Object.neuObject EmplKind2 = new neusoft.neuFC.Object.neuObject();

		/// <summary>
		/// 医疗证号
		/// </summary>
		public System.String McardNo
		{
			get{ return this.myMcardNo; }
			set{ this.myMcardNo = value; }
		}

		/// <summary>
		/// 登记人
		/// </summary>
		public System.String RegisterId
		{
			get{ return this.myRegisterId; }
			set{ this.myRegisterId = value; }
		}


		/// <summary>
		/// 登记时间
		/// </summary>
		public System.DateTime RegisterDate
		{
			get{ return this.myRegisterDate; }
			set{ this.myRegisterDate = value; }
		}


		/// <summary>
		/// 最后一次年审人
		/// </summary>
		public System.String AutditingId
		{
			get{ return this.myAutditingId; }
			set{ this.myAutditingId = value; }
		}


		/// <summary>
		/// 最后一次年审时间
		/// </summary>
		public System.DateTime AutditingDate
		{
			get{ return this.myAutditingDate; }
			set{ this.myAutditingDate = value; }
		}

		/// <summary>
		/// 医疗证状态, 0作废,1有效,2冻结
		/// </summary>
		public StatusTypeENUM Status
		{
			get{ return this.myStatus; }
			set{ this.myStatus = value; }
		}


		/// <summary>
		/// 作废/冻结人
		/// </summary>
		public System.String BlockId
		{
			get{ return this.myBlockId; }
			set{ this.myBlockId = value; }
		}


		/// <summary>
		/// 作废/冻结时间
		/// </summary>
		public System.DateTime BlockDate
		{
			get{ return this.myBlockDate; }
			set{ this.myBlockDate = value; }
		}


		/// <summary>
		/// 冻结原因
		/// </summary>
		public neusoft.neuFC.Object.neuObject BlkReasonid = new neusoft.neuFC.Object.neuObject();

	}
		/// <summary>
		/// 卡状态
		/// </summary>
		public enum StatusTypeENUM
		{
			/// <summary>
			/// 作废
			/// </summary>
			Cancel,
			/// <summary>
			/// 有效
			/// </summary>
			Valid,
			/// <summary>
			/// 冻结
			/// </summary>
			Block
		}
	
}
