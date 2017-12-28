using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.HISFC.Models.Registration;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.Terminal
{
	/// <summary>
	/// TerminalApply <br></br>
	/// [功能描述: 医技终端确认申请单]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2007-3-1]<br></br>
	/// [ID：申请单流水号]
	/// [user01：扩展标志1]
	/// [user02：扩展标志2]
	/// [user03：备注]
    /// <说明>
    ///     1、  {F8383442-78B0-40c2-B906-50BA52ADB139}  增加实体属性 执行人
    /// </说明>
	/// </summary>
    [Serializable]
    public class TerminalApply : Neusoft.FrameWork.Models.NeuObject,IValid
	{
		public TerminalApply()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 项目信息
		/// </summary>
		Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();

		/// <summary>
		/// 患者/顾客基本信息
		/// </summary>
		Neusoft.HISFC.Models.Registration.Register patient = new Register();

		/// <summary>
		/// 医技设备信息
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject machine = new NeuObject();

        /// <summary>
        /// 执行人
        /// </summary>
        Neusoft.HISFC.Models.Base.Employee execOper = new Employee();
		
		/// <summary>
		/// 插入申请单操作环境
		/// </summary>
		Neusoft.HISFC.Models.Base.OperEnvironment insertOperEnvironment = new OperEnvironment();

		/// <summary>
		/// 终端执行操作环境
		/// </summary>
		Neusoft.HISFC.Models.Base.OperEnvironment confirmOperEnvironment = new OperEnvironment();

		/// <summary>
		/// 已经确认数量
		/// </summary>
		decimal alreadyConfirmCount = 0;

		/// <summary>
		/// 发药科室信息
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject drugDepartment = new NeuObject();

		/// <summary>
		/// 更新库存的流水号
		/// </summary>
		int updateStoreSequence = 0;

		/// <summary>
		/// 药品发放时间
		/// </summary>
		DateTime sendDrugTime = DateTime.MinValue;

		/// <summary>
		/// 医嘱信息
		/// </summary>
		Neusoft.HISFC.Models.Order.Order order = new Order.Order();

		/// <summary>
		/// 医嘱执行单流水号
		/// </summary>
		int orderExeSequence = 0;

		/// <summary>
		/// 项目状态（0 划价  1 批费 2 执行（药品发放））
		/// </summary>
		string itemStatus = "";

		/// <summary>
		/// 新旧项目标志：0-老项目/1-新项目
		/// </summary>
		string newOrOld = "";

        string specalFlag = string.Empty;
		/// <summary>
		/// 患者类别：1-门诊；2-住院；3-急诊；4-体检
		/// </summary>
		string patientType = "";
        private bool isValid = true;
		#endregion

		#region 属性
        /// <summary>
        /// 特殊标记  1 扣门诊账户  2 住院扣费用
        /// </summary>
        public string SpecalFlag
        {
            get
            {
                return specalFlag;
            }
            set
            {
                specalFlag = value;
            }
        }
		/// <summary>
		/// 项目信息
		/// </summary>
		public Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}

		/// <summary>
		/// 患者/顾客信息
		/// </summary>
		public Neusoft.HISFC.Models.Registration.Register Patient
		{
			get
			{
				return this.patient;
			}
			set
			{
				this.patient = value;
			}
		}

		/// <summary>
		/// 医技设备信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Machine
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
		/// 插入申请单操作环境
		/// </summary>
		public Base.OperEnvironment InsertOperEnvironment
		{
			get
			{
				return this.insertOperEnvironment;
			}
			set
			{
				this.insertOperEnvironment = value;
			}
		}
		
		/// <summary>
		/// 终端执行操作环境
		/// </summary>
		public Base.OperEnvironment ConfirmOperEnvironment
		{
			get
			{
				return this.confirmOperEnvironment;
			}
			set
			{
				this.confirmOperEnvironment = value;
			}
		}

		/// <summary>
		/// 已经确认数量
		/// </summary>
		public decimal AlreadyConfirmCount
		{
			get
			{
				return this.alreadyConfirmCount;
			}
			set
			{
				this.alreadyConfirmCount = value;
			}
		}

		/// <summary>
		/// 发药科室信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DrugDepartment
		{
			get
			{
				return this.drugDepartment;
			}
			set
			{
				this.drugDepartment = value;
			}
		}

		/// <summary>
		/// 更新库存的流水号
		/// </summary>
		public int UpdateStoreSequence
		{
			get
			{
				return this.updateStoreSequence;
			}
			set
			{
				this.updateStoreSequence = value;
			}
		}

		/// <summary>
		/// 药品发放时间
		/// </summary>
		public DateTime SendDrugDate
		{
			get
			{
				return this.sendDrugTime;
			}
			set
			{
				this.sendDrugTime = value;
			}
		}

		/// <summary>
		/// 医嘱信息
		/// </summary>
		public Neusoft.HISFC.Models.Order.Order Order
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
		/// 医嘱执行单流水号
		/// </summary>
		public int OrderExeSequence
		{
			get
			{
				return this.orderExeSequence;
			}
			set
			{
				this.orderExeSequence = value;
			}
		}

		/// <summary>
		/// 项目状态（0 划价  1 批费 2 执行（药品发放））
		/// </summary>
		public string ItemStatus
		{
			get
			{
				return this.itemStatus;
			}
			set
			{
				this.itemStatus = value;
			}
		}

		/// <summary>
		/// 新旧项目标志：0-老项目/1-新项目
		/// </summary>
		public string NewOrOld
		{
			get
			{
				return this.newOrOld;
			}
			set
			{
				this.newOrOld = value;
			}
		}

		/// <summary>
		/// 患者类别：1-门诊；2-住院；3-急诊；4-个人体检  5 集体 
		/// </summary>
		public string PatientType
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
        /// 执行人
        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee ExecOper
        {
            get
            {
                return execOper;
            }
            set
            {
                execOper = value;
            }
        }
		#endregion

		#region 过时

		/// <summary>
		/// 插入申请单人信息
		/// </summary>
		[Obsolete("已经过时，更改为insertOperEnvironment", true)]
		Neusoft.FrameWork.Models.NeuObject insertOperator = new NeuObject();

		/// <summary>
		/// 插入申请单时间
		/// </summary>
		[Obsolete("已经过时，更改为insertOperEnvironment", true)]
		DateTime insertTime = DateTime.MinValue;

		/// <summary>
		/// 终端执行人信息
		/// </summary>
		[Obsolete("已经过时，更改为confirmOperEnvironment", true)]
		Neusoft.FrameWork.Models.NeuObject confirmOperator = new NeuObject();

		/// <summary>
		/// 终端执行时间
		/// </summary>
		[Obsolete("已经过时，更改为confirmOperEnvironment", true)]
		DateTime confirmDate = DateTime.MinValue;

		/// <summary>
		/// 插入申请单人信息
		/// </summary>
		[Obsolete("已经过时，更改为InsertOperEnvironment", true)]
		public Neusoft.FrameWork.Models.NeuObject InsertOperator
		{
			get
			{
				return this.insertOperEnvironment;
			}
			set
			{
				this.insertOperEnvironment.Dept = value;
			}
		}

		/// <summary>
		/// 插入申请单时间
		/// </summary>
		[Obsolete("已经过时，更改为InsertOperEnvironment", true)]
		public DateTime InsertDate
		{
			get
			{
				return this.insertOperEnvironment.OperTime;
			}
			set
			{
				this.insertOperEnvironment.OperTime = value;
			}
		}

		/// <summary>
		/// 终端执行人信息
		/// </summary>
		[Obsolete("已经过时，更改为ConfirmOperEnvironment", true)]
		public Neusoft.FrameWork.Models.NeuObject ConfirmOperator
		{
			get
			{
				return this.confirmOperEnvironment.Dept;
			}
			set
			{
				this.confirmOperEnvironment.Dept = value;
			}
		}

		/// <summary>
		/// 终端执行时间
		/// </summary>
		[Obsolete("已经过时，更改为ConfirmOperEnvrionment", true)]
		public DateTime ConfirmDate
		{
			get
			{
				return this.confirmOperEnvironment.OperTime;
			}
			set
			{
				this.confirmOperEnvironment.OperTime = value;
			}
		}
		
		#endregion

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>终端确认申请单</returns>
		public new TerminalApply Clone()
		{
			TerminalApply terminalApply = base.Clone() as TerminalApply;
			
			terminalApply.Item = this.Item.Clone();
			terminalApply.Patient = this.Patient.Clone();
			terminalApply.Machine = this.Machine.Clone();
			terminalApply.InsertOperEnvironment = this.InsertOperEnvironment.Clone();
			terminalApply.ConfirmOperEnvironment = this.ConfirmOperEnvironment.Clone();
			terminalApply.DrugDepartment = this.DrugDepartment.Clone();
			terminalApply.Order = this.Order.Clone();
            terminalApply.ExecOper = this.ExecOper.Clone();
			
			return terminalApply;
		}
		#endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        #endregion
    }
	
	/// <summary>
	/// 住院收费方式
	/// </summary>
	public enum InpatientChargeType
	{
		/// <summary>
		/// 直接批费方式0
		/// </summary>
		DirectChargeType = 0,
		/// <summary>
		/// 医嘱收费方式1
		/// </summary>
		OrderChargeType = 1,
		/// <summary>
		/// 其它收费方式9
		/// </summary>
		OtherChargeType = 9,
	}
    /// <summary>
    /// 扣门诊账户操作类型
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// 默认
        /// </summary>
        None,
        /// <summary>
        /// 终端扣账户收费且执行终端确认
        /// </summary>
        ClinicFee,
        /// <summary>
        /// 划价
        /// </summary>
        ClinicCharge
    }
}

