using System;

namespace Neusoft.HISFC.Models.Medical

{
	#region 课题实体
	/// <summary>
	/// [功能描述: 课题实体]<br></br>
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
	public class Task
	{
		public Task()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 表
		/*
			PRIMARY_ID     VARCHAR2(20)                   主键列                
			CURRENT_CODE   VARCHAR2(14)  Y                本级医疗机构编码      
			TASK_ID        VARCHAR2(20)  Y                科题编号              
			TASK_FILEINFO  VARCHAR2(50)  Y                批文                  
			PROJECT_ID     VARCHAR2(20)  Y                项目编号              
			PROJECT_NAME   VARCHAR2(100) Y                项目名称              
			PROJECT_TYPE   VARCHAR2(20)  Y                项目类别              
			PROJECT_KIND   VARCHAR2(20)  Y                科题性质              
			TASK_LEVEL     VARCHAR2(20)  Y                科题级别              
			TASK_PRINCIPAL VARCHAR2(6)   Y                项目负责人            
			BEGIN_DATE     DATE          Y                开始时间              
			END_DATE       DATE          Y                结束时间              
			CONFIRM_COST   NUMBER(12,2)  Y                批准经费              
			MARK           VARCHAR2(500) Y                备注                  
			VALID_STATE    VARCHAR2(1)   Y                有效性状态  0 是 1 非 
			OPER_CODE      VARCHAR2(6)   Y                操作员                
			OPER_DATE      DATE          Y                操作日期 
			confirm_Date
		*/
		#endregion

		#region 域
		private System.String primaryId = "";
		private System.String taskId = "";
		private System.String taskFileInfo = "";
		private System.String kind = "";
		private System.String type = "";
		private System.String level = "";
		private System.String principal = "";
		private System.DateTime beginTime = System.DateTime.MinValue;
		private System.DateTime endTime = System.DateTime.MinValue;
		private System.Decimal cost = 0;
		private System.String mark = "";
		private System.String valid = "";
		private System.String operCode = "";
		private System.DateTime operDate = System.DateTime.MinValue;
		private Neusoft.FrameWork.Models.NeuObject project = new Neusoft.FrameWork.Models.NeuObject();
		private System.DateTime confirmDate = System.DateTime.MinValue;
		private System.String oneDept = "";
		private System.String twoDept = "";
		#endregion

		/// <summary>
		/// 主键列
		/// </summary>
		public string PrimaryId
		{
			get
			{
				return this.primaryId;
			}
			set
			{
				this.primaryId = value;
			}
		}
		/// <summary>
		/// 科题编号
		/// </summary>
		public string TaskId
		{
			get
			{
				return this.taskId;
			}
			set
			{
				this.taskId = value;
			}
		}
		/// <summary>
		/// 批文
		/// </summary>
		public string TaskFileInfo
		{
			get
			{
				return this.taskFileInfo;
			}
			set
			{
				this.taskFileInfo = value;
			}
		}
		/// <summary>
		/// 项目
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Project
		{
			get
			{

				return this.project;
			}
			set
			{
				this.project = value;
			}
		}
		/// <summary>
		/// 项目类别
		/// </summary>
		public string Kind
		{
			get
			{
				return this.kind;
			}
			set
			{
				this.kind = value;
			}
		}
		/// <summary>
		/// 课题性质
		/// </summary>
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}
		/// <summary>
		/// 课题级别
		/// </summary>
		public string Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}
		/// <summary>
		/// 项目负责人
		/// </summary>
		public string Principal
		{
			get
			{
				return this.principal;
			}
			set
			{
				this.principal = value;
			}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}
		/// <summary>
		/// 批准经费
		/// </summary>
		public decimal Cost
		{
			get
			{
				return this.cost;
			}
			set
			{
				this.cost = value;
			}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Mark
		{
			get
			{
				return this.mark;
			}
			set
			{
				this.mark = value;
			}
		}
		/// <summary>
		/// 有效状态
		/// </summary>
		public string Valid
		{
			get
			{
				return this.valid;
			}
			set
			{
				this.valid = value;
			}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode
		{
			get
			{
				return this.operCode;
			}
			set
			{
				this.operCode = value;
			}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return this.operDate;
			}
			set
			{
				this.operDate = value;
			}
		}
		/// <summary>
		/// 确定时间
		/// </summary>
		public DateTime ConfirmDate
		{
			get
			{
				return this.confirmDate;
			}
			set
			{
				this.confirmDate = value;
			}
		}
		/// <summary>
		/// 一级单位
		/// </summary>
		public string OneDept
		{
			get
			{
				return this.oneDept;
			}
			set
			{
				this.oneDept = value;
			}
		}
		/// <summary>
		/// 二级单位
		/// </summary>
		public string TwoDept
		{
			get
			{
				return this.twoDept;
			}
			set
			{
				this.twoDept = value;
			}
		}
//		/// <summary>
//		/// 所属科室
//		/// </summary>
//		public ArrayList AlPertainDept
//		{
//			get
//			{
//				return this.alpertainDept;
//			}
//			set
//			{
//				this.alpertainDept = value;
//			}
//		}
//		/// <summary>
//		/// 课题来源	
//		/// </summary>
//		public ArrayList AlSource
//		{
//			get
//			{
//				return this.alsource;
//			}
//			set
//			{
//				this.alsource = value;
//			}
//		}
//		/// <summary>
//		/// 参加单位
//		/// </summary>
//		public ArrayList AlJoinDept
//		{
//			get
//			{
//				return this.aljoinDept;
//			}
//			set
//			{
//				this.aljoinDept = value;
//			}
//		}
//		/// <summary>
//		/// 科室
//		/// </summary>
//		public ArrayList AlDept
//		{
//			get
//			{
//				return this.aldept;
//			}
//			set
//			{
//				this.aldept = value;
//			}
//		}
//		/// <summary>
//		/// 专科
//		/// </summary>
//		public ArrayList AlSpecialDept
//		{
//			get
//			{
//				return this.alspecialDept;
//			}
//			set
//			{
//				this.alspecialDept = value;
//			}
//		}
//		/// <summary>
//		/// 小组成员
//		/// </summary>
//		public ArrayList AlLeaguer
//		{
//			get
//			{
//				return this.alleaguer;
//			}
//			set
//			{
//				this.alleaguer = value;
//			}
//		}
//		/// <summary>
//		/// 扩张字段
//		/// </summary>
//		public ArrayList AlExtent
//		{
//			get
//			{
//				return this.alsxtent;
//			}
//			set
//			{
//				this.alextent = value;
//			}
//		}
//		

	}

	#endregion
}
