/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			TerminalApply.cs
            // 文件功能描述：	医技终端确认申请单实体层类
            //
            // 
            // 创建标识：		2006-3-17
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/
using System;
using neusoft.HISFC.Object.Fee.OutPatient;
using neusoft.HISFC.Object.Registration;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// 医技终端确认申请单
	/// [ID：申请单流水号]
	/// [user01：扩展标志1]
	/// [user02：扩展标志2]
	/// [user03：备注]
	/// </summary>
	public class TerminalApply:neusoft.neuFC.Object.neuObject
	{

		#region 构造函数
		public TerminalApply()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion
		
		#region 变量

		/// <summary>
		/// 项目信息
		/// </summary>
		neusoft.HISFC.Object.Fee.OutPatient.FeeItemList item = new FeeItemList();

		/// <summary>
		/// 患者/顾客基本信息
		/// </summary>
		neusoft.HISFC.Object.Registration.Register patient = new Register();

		/// <summary>
		/// 医技设备信息
		/// </summary>
		neusoft.neuFC.Object.neuObject machine = new neuObject();

		/// <summary>
		/// 插入申请单人信息
		/// </summary>
		neusoft.neuFC.Object.neuObject insertOperator = new neuObject();

		/// <summary>
		/// 插入申请单时间
		/// </summary>
		DateTime insertDate = DateTime.MinValue;

		/// <summary>
		/// 终端执行人信息
		/// </summary>
		neusoft.neuFC.Object.neuObject confirmOperator = new neuObject();

		/// <summary>
		/// 终端执行时间
		/// </summary>
		DateTime confirmDate = DateTime.MinValue;

		/// <summary>
		/// 已经确认数量
		/// </summary>
		decimal alreadyConfirmCount = 0;

		/// <summary>
		/// 发药科室信息
		/// </summary>
		neusoft.neuFC.Object.neuObject drugDepartment = new neuObject();

		/// <summary>
		/// 更新库存的流水号
		/// </summary>
		int updateStoreSequence = 0;

		/// <summary>
		/// 药品发放时间
		/// </summary>
		DateTime sendDrugDate = DateTime.MinValue;

		/// <summary>
		/// 医嘱信息
		/// </summary>
		neusoft.HISFC.Object.Order.Order order = new Order.Order();

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

		/// <summary>
		/// 患者类别：1-门诊；2-住院；3-急诊；4-体检
		/// </summary>
		string patientType = "";

		#endregion

		#region 属性

		#region 项目信息
		/// <summary>
		/// 项目信息
		/// </summary>
		public neusoft.HISFC.Object.Fee.OutPatient.FeeItemList Item
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
		#endregion

		#region 患者/顾客信息
		/// <summary>
		/// 患者/顾客信息
		/// </summary>
		public neusoft.HISFC.Object.Registration.Register Patient
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
		#endregion

		#region 医技设备信息
		/// <summary>
		/// 医技设备信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject Machine
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
		#endregion

		#region 插入申请单人信息
		/// <summary>
		/// 插入申请单人信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject InsertOperator
		{
			get
			{
				return this.insertOperator;
			}
			set
			{
				this.insertOperator = value;
			}
		}
		#endregion

		#region 插入申请单时间
		/// <summary>
		/// 插入申请单时间
		/// </summary>
		public DateTime InsertDate
		{
			get
			{
				return this.insertDate;
			}
			set
			{
				this.insertDate = value;
			}
		}
		#endregion

		#region 终端执行人信息
		/// <summary>
		/// 终端执行人信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject ConfirmOperator
		{
			get
			{
				return this.confirmOperator;
			}
			set
			{
				this.confirmOperator = value;
			}
		}
		#endregion

		#region 终端执行时间
		/// <summary>
		/// 终端执行时间
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
		#endregion

		#region 已经确认数量
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
		#endregion

		#region 发药科室信息
		/// <summary>
		/// 发药科室信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject DrugDepartment
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
		#endregion

		#region 更新库存的流水号
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
		#endregion

		#region 药品发放时间
		/// <summary>
		/// 药品发放时间
		/// </summary>
		public DateTime SendDrugDate
		{
			get
			{
				return this.sendDrugDate;
			}
			set
			{
				this.sendDrugDate = value;
			}
		}
		#endregion

		#region 医嘱信息
		/// <summary>
		/// 医嘱信息
		/// </summary>
		public neusoft.HISFC.Object.Order.Order Order
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
		#endregion

		#region 医嘱执行单流水号
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
		#endregion

		#region 项目状态（0 划价  1 批费 2 执行（药品发放））
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
		#endregion

		#region 新旧项目标志：0-老项目/1-新项目
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
		#endregion

		#region 患者类别：1-门诊；2-住院；3-急诊；4-体检
		
		/// <summary>
		/// 患者类别：1-门诊；2-住院；3-急诊；4-体检
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
		#endregion

		#endregion
		
		#region 克隆
		public new TerminalApply Clone()
		{
			TerminalApply terminalApply = base.Clone() as TerminalApply;
			terminalApply.Item = this.Item.Clone();
			terminalApply.Patient = (neusoft.HISFC.Object.Registration.Register)this.Patient.Clone();
			terminalApply.Machine = this.Machine.Clone();
			terminalApply.ConfirmOperator = this.ConfirmOperator.Clone();
			terminalApply.DrugDepartment = this.DrugDepartment.Clone();
			terminalApply.Order = this.Order.Clone();
			terminalApply.InsertOperator = this.InsertOperator.Clone();
			return terminalApply;
		}
		#endregion
	}
}

