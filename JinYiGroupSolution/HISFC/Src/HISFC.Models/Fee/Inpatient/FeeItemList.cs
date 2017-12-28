using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Order;
using System.Collections.Generic;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{


	/// <summary>
	///费用项目信息类
	///ID住院流水号
	///name 患者姓名
	/// </summary>
    /// 

    [System.Serializable]
	public class FeeItemList : FeeItemBase, IBaby
	{
		/// <summary>
		/// FeeItemBase<br></br>
		/// [功能描述: 住院费用明细类]<br></br>
		/// [创 建 者: 王宇]<br></br>
		/// [创建时间: 2006-09-13]<br></br>
		/// <修改记录 
		///		修改人='' 
		///		修改时间='yyyy-mm-dd' 
		///		修改目的=''
		///		修改描述=''
		///  />
		/// </summary>
		public FeeItemList()
		{
			this.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
            this.Order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
		}
		
		#region 变量

		/// <summary>
		/// 结算序号
		/// </summary>
		private int balanceNO;
		
		/// <summary>
		/// 结算状态
		/// </summary>
		private string balanceState = string.Empty;

		/// <summary>
		/// 婴儿序号
		/// </summary>
		private string babyNO = string.Empty;
		
		/// <summary>
		/// 是否婴儿
		/// </summary>
		private bool isBaby;
		
		/// <summary>
		/// 出库单号
		/// </summary>
		private int sendSequence;


		/// <summary>
		/// 设备编号
		/// </summary>
		private string machineNO = string.Empty;
		
		/// <summary>
		/// 费用比例(这里为手术比例服务)
		/// </summary>
		private FTRate ftRate = new FTRate();

		/// <summary>
		/// 审核序号
		/// </summary>
		private string auditingNO = string.Empty;
		
		/// <summary>
		/// 结算操作环境(结算人，结算时间，结算人所在科室）
		/// </summary>
		private OperEnvironment balanceOper = new OperEnvironment();
		
		/// <summary>
		/// 医嘱执行档
		/// </summary>
		private ExecOrder execOrder = new ExecOrder();
		
		/// <summary>
		/// 扩展标志
		/// </summary>
		private string extFlag = string.Empty;

        /// <summary>
        /// 扩展标志1
        /// </summary>
        private string extFlag1 = string.Empty;

        /// <summary>
        /// 扩展标志2
        /// </summary>
        private string extFlag2 = string.Empty;

        /// <summary>
        /// 扩展编码
        /// </summary>
        private string extCode = string.Empty;

        /// <summary>
        /// 扩展操作环境(扩展人,扩展时间,扩展人所在科室)
        /// </summary>
        private OperEnvironment extOper = new OperEnvironment();

		/// <summary>
		/// 审批号
		/// </summary>
		private string approveNO = string.Empty;

        /// <summary>
        /// 是否需要更新可退数量 true 需要 false 不需要
        /// </summary>
        private bool isNeedUpdateNoBackQty;

        //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        /// <summary>
        /// 医疗组
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject medicalTeam = new NeuObject();

        /// <summary>
        /// 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
        /// </summary>
        private string operationNO = string.Empty;

        

        
		#endregion

		#region 属性

        /// <summary>
        /// 医嘱信息
        /// </summary>
        public new Order.Inpatient.Order Order
        {
            get
            {
                return base.Order as Order.Inpatient.Order;
            }
            set
            {
                base.Order = value;
            }
        }

		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceNO
		{
			get
			{
				return this.balanceNO;
			}
			set
			{
				this.balanceNO = value;
			}
		}
		
		/// <summary>
		/// 结算状态
		/// </summary>
		public string BalanceState
		{
			get
			{
				return this.balanceState;
			}
			set
			{
				this.balanceState = value;
			}
		}

		/// <summary>
		/// 出库单号
		/// </summary>
		public int SendSequence
		{
			get
			{
				return this.sendSequence;
			}
			set
			{
				this.sendSequence = value;
			}
		}



		/// <summary>
		/// 设备编号
		/// </summary>
		public string MachineNO
		{
			get
			{
				return this.machineNO;
			}
			set
			{
				this.machineNO = value;
			}
		}

		/// <summary>
		/// 费用比例(这里为手术比例服务)
		/// </summary>
		public FTRate FTRate
		{
			get
			{
				return this.ftRate;
			}
			set
			{
				this.ftRate = value;
			}
		}

		/// <summary>
		/// 审核序号
		/// </summary>
		public string AuditingNO
		{
			get
			{
				return this.auditingNO;
			}
			set
			{
				this.auditingNO = value;
			}
		}

		/// <summary>
		/// 结算操作环境(结算人，结算时间，结算人所在科室）
		/// </summary>
		public OperEnvironment BalanceOper
		{
			get
			{
				return this.balanceOper;
			}
			set
			{
				this.balanceOper = value;
			}
		}

		/// <summary>
		/// 扩展标志
		/// </summary>
		public string ExtFlag
		{
			get
			{
				return this.extFlag;	
			}
			set
			{
				this.extFlag = value;
			}
		}

        /// <summary>
        /// 扩展标志1
        /// </summary>
        public string ExtFlag1
        {
            get
            {
                return this.extFlag1;
            }
            set
            {
                this.extFlag1 = value;
            }
        }

        /// <summary>
        /// 扩展标志2
        /// </summary>
        public string ExtFlag2
        {
            get
            {
                return this.extFlag2;
            }
            set
            {
                this.extFlag2 = value;
            }
        }

        /// <summary>
        /// 扩展编码
        /// </summary>
        public string ExtCode
        {
            get
            {
                return this.extCode;
            }
            set
            {
                this.extCode = value;
            }
        }

        /// <summary>
        ///  扩展操作环境(扩展人,扩展时间,扩展人所在科室)
        /// </summary>
        public OperEnvironment ExtOper
        {
            get
            {
                return this.extOper;
            }
            set
            {
                this.extOper = value;
            }
        }

		/// <summary>
		/// 医嘱执行档
		/// </summary>
		public ExecOrder ExecOrder 
		{
			get
			{
				return this.execOrder;
			}
			set
			{
				this.execOrder = value;
			}
		}

		/// <summary>
		/// 审批号
		/// </summary>
		public string ApproveNO
		{
			get
			{
				return this.approveNO;
			}
			set
			{
				this.approveNO = value;
			}
		}

        /// <summary>
        /// 是否需要更新可退数量 true 需要 false 不需要
        /// </summary>
        public bool IsNeedUpdateNoBackQty 
        {
            get 
            {
                return this.isNeedUpdateNoBackQty;
            }
            set 
            {
                this.isNeedUpdateNoBackQty = value;
            }
        }

        

        //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        /// <summary>
        /// 医疗组
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject MedicalTeam
        {
            get { return medicalTeam; }
            set { medicalTeam = value; }
        }

        /// <summary>
        /// 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
        /// </summary>
        public string OperationNO
        {
            get { return operationNO; }
            set { operationNO = value; }
        }
       
		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new FeeItemList Clone()
		{
			FeeItemList feeItemList = base.Clone() as FeeItemList;

			feeItemList.FTRate = this.FTRate.Clone();
			feeItemList.BalanceOper = this.BalanceOper.Clone();
			feeItemList.ExecOrder = this.ExecOrder.Clone();
            //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
            feeItemList.MedicalTeam = this.MedicalTeam.Clone();
			return feeItemList;
		}

		#endregion

		#endregion 

		#region 接口实现
		
		#region IBaby 成员
		
		/// <summary>
		/// 婴儿序号
		/// </summary>
		public string BabyNO
		{
			get
			{
				return this.babyNO;
			}
			set
			{
				this.babyNO = value;
			}
		}
		
		/// <summary>
		/// 是否婴儿
		/// </summary>
		public bool IsBaby
		{
			get
			{
				return this.isBaby;
			}
			set
			{
				this.isBaby = value;
			}
		}

		#endregion

		#endregion

		#region 无用方法属性

		//[Obsolete("作废", true)]
		//public FeeInfo FeeInfo=new FeeInfo();

		/// <summary>
		/// 医嘱流水号
		/// </summary>
		[Obsolete("作废,基类Order.ID代替", true)]
		public string MoOrder
		{
			get
			{	
				return "";
			}
			set
			{
				
			}
		}
		
		/// <summary>
		/// 新物价组套信息
		/// </summary>
		[Obsolete("作废,基类UndrugComb代替", true)]
		public NeuObject ItemGroup = new NeuObject()   ;
		/// <summary>
		/// 0划价1收费2执行发放
		/// </summary>
		[Obsolete("作废,基类PayType代替", true)]
		public string SendState;

		/// <summary>
		/// 是否出院带疗(改为医嘱类型)
		/// </summary>
		[Obsolete("作废,基类Order代替", true)]
		public string IsBrought;
		
		[Obsolete("作废,基类NoBackQty代替", true)]
		public decimal NoBackNum=0m;
		/// <summary>
		/// 收费比例(手术用)
		/// </summary>
		[Obsolete("作废,FTRate代替", true)]
		public decimal Rate=0m;

		#endregion
	}
}
