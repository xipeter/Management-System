namespace Neusoft.HISFC.Object.MedTech 
{
    /// <summary>
    /// [功能描述: 医技终端]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Obsolete("已经过时，此类已经变成HISFC.OBJECT.Medtech.Terminal.TerminalApplyInfo", true)]
    public class TerminalOld : Neusoft.HISFC.Object.Base.Spell
	{
		/// <summary>
		/// 构造函数
		/// </summary>
        public TerminalOld() 
		{
			
		}

		#region 变量

        
		/// <summary>
		/// 所属医技组
		/// </summary>
        private MedTech.Management.Group group = new Neusoft.HISFC.Object.MedTech.Management.Group();

		/// <summary>
		/// 设备
		/// </summary>
        private Neusoft.NFC.Object.NeuObject machine = new Neusoft.NFC.Object.NeuObject();

		/// <summary>
		/// 患者类别
		/// </summary>
		private Neusoft.HISFC.Object.RADT.EnumPatientType patientType;

		/// <summary>
		/// 患者的卡号
		/// </summary>
		private string cardNO;//last

		/// <summary>
		/// 患者的本次就诊号
		/// </summary>
		private string currentNO;//last

		/// <summary>
		/// 医嘱
		/// </summary>
		private Neusoft.HISFC.Object.Order.Order order = new Neusoft.HISFC.Object.Order.Order();

		/// <summary>
		/// 医技项目属性
		/// </summary>
        private Neusoft.HISFC.Object.Base.DeptItem itemProperty = new Neusoft.HISFC.Object.Base.DeptItem();

		//创建科室，已经从MTObject继承

		/// <summary>
		/// 项目收费时间
		/// </summary>
		private System.DateTime chargeTime = System.DateTime.MinValue;//last

		// 项目开立信息，暂时没加

		/// <summary>
		/// 是否组套, 1-yes, 0-no;
		/// </summary>
		private string isGroup = "0";//last

		/// <summary>
		/// 执行医院
		/// </summary>
        private Neusoft.HISFC.Object.Base.Hospital executeHospital = new Neusoft.HISFC.Object.Base.Hospital();

		/// <summary>
		/// 执行操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment executeEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 预约操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment precontractEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 午别
		/// </summary>
        private Neusoft.HISFC.Object.Base.Noon noon = new Neusoft.HISFC.Object.Base.Noon();

		/// <summary>
		/// 医技预约后的执行地点
		/// </summary>
        private MedTech.Management.Location.Building location = new Neusoft.HISFC.Object.MedTech.Management.Location.Building();//last

		/// <summary>
		/// 已经执行的数量
		/// </summary>
		private decimal alreadyExecuteQty;

		/// <summary>
		/// 最后一次执行的操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment lastEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 项目状态
		/// </summary>
        private MedTech.Booking.EnumBookingState itemState;

		/// <summary>
		/// 医技预约确认人
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment confirmEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();
		
		#endregion

		#region 属性

		/// <summary>
		/// 医技预约确认人
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ConfirmEnvironment
		{
			get
			{
				return this.confirmEnvironment;
			}
			set
			{
				this.confirmEnvironment = value;
			}
		}
		/// <summary>
		/// 项目收费时间
		/// </summary>
		public System.DateTime ChargeTime
		{
			get
			{
				return this.chargeTime;
			}
			set
			{
				this.chargeTime = value;
			}
		}
	
		/// <summary>
		/// 医技预约后的执行地点
		/// </summary>
        public MedTech.Management.Location.Building Location
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
			}
		}

		/// <summary>
		/// 是否组套，1-yes, 0-no
		/// </summary>
		public string IsGroup
		{
			get
			{
				return this.isGroup;
			}
			set
			{
				this.isGroup = value;
			}
		}

		/// <summary>
		/// 患者的卡号
		/// </summary>
		public string CardNO
		{
			get
			{
				return this.cardNO;
			}
			set
			{
				this.cardNO = value;
			}
		}

		/// <summary>
		/// 患者的本次就诊号卡号
		/// </summary>
		public string CurrentNO
		{
			get
			{
				return this.currentNO;
			}
			set
			{
				this.currentNO = value;
			}
		}

		/// <summary>
		/// 设备
		/// </summary>
        public Neusoft.NFC.Object.NeuObject Machine 
		{
			get 
			{
				return this.machine;
			}
			set 
			{
				this.machine = value;
			}
		}

		/// <summary>
		/// 患者类别
		/// </summary>
		public Neusoft.HISFC.Object.RADT.EnumPatientType PatientType 
		{
			get 
			{
				return this.patientType;
			}
			set 
			{
				this.patientType = value;
			}
		}
		
		/// <summary>
		/// 所属医技组
		/// </summary>
        public MedTech.Management.Group Group 
		{
			get 
			{
				return this.group;
			}
			set 
			{
				this.group = value;
			}
		}

		/// <summary>
		/// 医嘱
		/// </summary>
		public Neusoft.HISFC.Object.Order.Order Order 
		{
			get 
			{
				return this.order;
			}
			set 
			{
				this.order = value;
			}
		}

		/// <summary>
		/// 执行医院
		/// </summary>
        public Neusoft.HISFC.Object.Base.Hospital ExecuteHospital 
		{
			get 
			{
				return this.executeHospital;
			}
			set 
			{
				this.executeHospital = value;
			}
		}

		/// <summary>
		/// 执行操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ExecuteEnvironment 
		{
			get 
			{
				return this.executeEnvironment;
			}
			set 
			{
				this.executeEnvironment = value;
			}
		}

		/// <summary>
		/// 预约操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment PrecontractEnvironment 
		{
			get 
			{
				return this.precontractEnvironment;
			}
			set 
			{
				this.precontractEnvironment = value;
			}
		}

		/// <summary>
		/// 午别
		/// </summary>
        public Neusoft.HISFC.Object.Base.Noon Noon 
		{
			get 
			{
				return this.noon;
			}
			set 
			{
				this.noon = value;
			}
		}

		/// <summary>
		/// 医技项目属性
		/// </summary>
        public Neusoft.HISFC.Object.Base.DeptItem ItemProperty 
		{
			get 
			{
				return this.itemProperty;
			}
			set 
			{
				this.itemProperty = value;
			}
		}

		/// <summary>
		/// 已经执行的数量
		/// </summary>
		public decimal AlreadyExecuteQty 
		{
			get 
			{
				return this.alreadyExecuteQty;
			}
			set 
			{
				this.alreadyExecuteQty = value;
			}
		}

		/// <summary>
		/// 最后一次执行的操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment LastEnvironment 
		{
			get 
			{
				return this.lastEnvironment;
			}
			set 
			{
				this.lastEnvironment = value;
			}
		}

		/// <summary>
		/// 项目状态
		/// </summary>
        public MedTech.Booking.EnumBookingState ItemState 
		{
			get 
			{
				return this.itemState;
			}
			set 
			{
				this.itemState = value;
			}
		}
		#endregion

	}
}
