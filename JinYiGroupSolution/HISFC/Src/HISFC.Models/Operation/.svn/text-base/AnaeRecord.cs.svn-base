using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// [功能描述: 麻醉(Anaesthesia)登记实体类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class AnaeRecord : NeuObject
	{
		public AnaeRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public AnaeRecord(OperationAppllication operationApplication)
		{
			this.operationApplication = operationApplication;
		}

		private OperationAppllication operationApplication;
		/// <summary>
		/// 手术申请单对象(包含了绝大部分要登记的信息)
		/// </summary>
		public OperationAppllication OperationApplication
		{
			get
			{
				if (this.operationApplication == null) 
				{
					this.operationApplication = new OperationAppllication();
				}
				return this.operationApplication;
			}
			set
			{
				this.operationApplication = value;
			}
		}
		[Obsolete("OperationApplication",true)]
		public OperationAppllication m_objOpsApp = new OperationAppllication();

		private DateTime anaeDate = DateTime.MinValue;
		/// <summary>
		/// 麻醉时间
		/// </summary>
		public DateTime AnaeDate
		{
			get
			{
				return this.anaeDate;
			}
			set
			{
				this.anaeDate = value;
			}
		}
		
		private NeuObject anaeResult = new NeuObject();
		/// <summary>
		/// 麻醉效果
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject AnaeResult
		{
			get
			{
				return this.anaeResult;
			}
			set
			{
				this.anaeResult = value;
			}
		}

		private bool isPACU;
		[Obsolete("IsPACU",true)]
		public bool bIsPACU
		{
			get
			{
				return this.isPACU;
			}
			set
			{
				this.isPACU = value;
			}
		}
		/// <summary>
		/// 是否入PACU 1是/0否
		/// </summary>
		public bool IsPACU
		{
			get
			{
				return this.isPACU;
			}
			set
			{
				this.isPACU = value;
			}
		}
		
		private DateTime inPacuDate = DateTime.MinValue;
		/// <summary>
		/// 入(PACU)室时间
		/// </summary>
		public DateTime InPacuDate
		{
			get
			{
				return this.inPacuDate;
			}
			set
			{
				this.inPacuDate = value;
			}
		}

		private DateTime outPacuDate = DateTime.MinValue;
		/// <summary>
		/// 出(PACU)室时间
		/// </summary>
		public DateTime OutPacuDate
		{
			get
			{
				return this.outPacuDate;
			}
			set
			{
				this.outPacuDate = value;
			}
		}

		private NeuObject inPacuStatus = new NeuObject();
		/// <summary>
		/// 入(PACU)室状态
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject InPacuStatus
		{
			get
			{
				return this.inPacuStatus;
			}
			set
			{
				this.inPacuStatus = value;
			}
		}

		private NeuObject outPacuStatus = new NeuObject();
		/// <summary>
		/// 出(PACU)室状态
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OutPacuStatus
		{
			get
			{
				return this.outPacuStatus;
			}
			set
			{
				this.outPacuStatus = value;
			}
		}


		/// <summary>
		/// 备注
		/// </summary>
		[Obsolete("Memo",true)]
		public string Remark = "";

		private bool isDemulcent;
		[Obsolete("IsDemulcent",true)]
		public bool bIsDemulcent
		{
			get
			{
				return this.isDemulcent;
			}
			set
			{
				this.isDemulcent = value;
			}
		}
		/// <summary>
		/// 是否术后镇痛
		/// </summary>
		public bool IsDemulcent
		{
			get
			{
				return this.isDemulcent;
			}
			set
			{
				this.isDemulcent = value;
			}
		}
		
		private NeuObject demulcentType =new NeuObject();
		/// <summary>
		/// 镇痛方式
		/// </summary>
		public NeuObject DemulcentType
		{
			get
			{
				return this.demulcentType;
			}
			set
			{
				this.demulcentType = value;
			}
		}
		[Obsolete("DemulcentType",true)]
		public Neusoft.FrameWork.Models.NeuObject DemuKind = new Neusoft.FrameWork.Models.NeuObject();
		
		private NeuObject demulcentModel = new NeuObject();
		/// <summary>
		/// 泵型
		/// </summary>
		public NeuObject DemulcentModel
		{
			get
			{
				return this.demulcentModel;
			}
			set
			{
				this.demulcentModel = value;
			}
		}
		[Obsolete("DemulcentModel",true)]
		public Neusoft.FrameWork.Models.NeuObject DemuModel = new Neusoft.FrameWork.Models.NeuObject();
		
		private int demulcentDays = 0;
		/// <summary>
		/// 镇痛天数
		/// </summary>
		public int DemulcentDays
		{
			get
			{
				return this.demulcentDays;
			}
			set
			{
				this.demulcentDays = value;
			}
		}

		private NeuObject demulcentEffect = new NeuObject();
		/// <summary>
		/// 镇痛效果
		/// </summary>
		public NeuObject DemulcentEffect
		{
			get
			{
				return this.demulcentEffect;
			}
			set
			{
				this.demulcentEffect = value;
			}
		}
		[Obsolete("DemulcentEffect",true)]
		public Neusoft.FrameWork.Models.NeuObject DemuResult = new Neusoft.FrameWork.Models.NeuObject();

		private DateTime pullOutDate = DateTime.MinValue;
		/// <summary>
		/// 拔管时间
		/// </summary>
		public DateTime PullOutDate
		{
			get
			{
				return this.pullOutDate;
			}
			set
			{
				this.pullOutDate = value;
			}
		}

		private NeuObject pullOutOperator = new NeuObject();
		/// <summary>
		/// 拔管人
		/// </summary>
		public NeuObject PullOutOperator
		{
			get
			{
				return this.pullOutOperator;
			}
			set
			{
				this.pullOutOperator = value;
			}
		}
		[Obsolete("PullOutOperator",true)]
		public Neusoft.FrameWork.Models.NeuObject PullOutOpcd = new Neusoft.FrameWork.Models.NeuObject();


		private bool chargeFlag;
		[Obsolete("IsCharged",true)]
		public bool bChargeFlag
		{
			get
			{
				return this.chargeFlag;
			}
			set
			{
				this.chargeFlag = value;
			}
		}	
		/// <summary>
		/// 是否记帐
		/// </summary>
		public bool IsCharged
		{
			get
			{
				return this.chargeFlag;
			}
			set
			{
				this.chargeFlag = value;
			}
		}

		private NeuObject execDept = new NeuObject();
		/// <summary>
		/// 执行科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ExecDept
		{
			get
			{
				return this.execDept;
			}
			set
			{
				this.execDept = value;
			}
		}
	}
}
