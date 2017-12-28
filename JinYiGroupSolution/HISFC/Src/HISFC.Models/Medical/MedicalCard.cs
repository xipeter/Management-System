using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Medical
{
	/// <summary>
	/// [功能描述: 医疗证实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class MedicalCard: Neusoft.FrameWork.Models.NeuObject
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
		public Neusoft.HISFC.Models.Base.Employee EmployeeInfo = new Employee();

		/// <summary>
		/// 人员分类1 人事科对人员进行的分类，跟工号的开头字母有联系，
		/// 比如1字开头的是行政机关人员，2字开头的是医教人员等
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject EmplKind1 = new Neusoft.FrameWork.Models.NeuObject();
	
		/// <summary>
		/// 人员分类2 院内合同人员，博士后等
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject EmplKind2 = new Neusoft.FrameWork.Models.NeuObject();

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
		public Neusoft.FrameWork.Models.NeuObject BlkReasonid = new Neusoft.FrameWork.Models.NeuObject();

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
