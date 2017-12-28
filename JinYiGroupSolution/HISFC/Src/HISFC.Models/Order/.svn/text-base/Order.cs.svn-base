using System;
//using Neusoft.NFC;
using Neusoft.HISFC;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.Order<br></br>
	/// [功能描述: 医嘱资料实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Order:Neusoft.FrameWork.Models.NeuObject,
		Neusoft.HISFC.Models.Base.IDept,
		Neusoft.HISFC.Models.Base.IBaby,Neusoft.HISFC.Models.Base.ISort
		{

		/// <summary>
		/// 医嘱资料实体
		/// ID 医嘱流水号
		/// </summary>
		public Order()
		{
			
		}

		#region 变量

		#region 私有

		/// <summary>
		/// 患者基本信息
		/// </summary>
		private Neusoft.HISFC.Models.RADT.PatientInfo patient= new Neusoft.HISFC.Models.RADT.PatientInfo();
		
		/// <summary>
		/// 是否需要皮试　新加20050815
		/// 1 不需要皮试　２　需要皮试　３　阳性　４　阴性
		/// </summary>
		private int hypoTest = 1;

		private int injectCount; //院内注射次数
		
		/// <summary>
		/// 开立医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject  doctor =new Neusoft.FrameWork.Models.NeuObject();

        private Neusoft.FrameWork.Models.NeuObject doctorDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 审核/执行护士
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject nurse=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 记录者
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper=new Neusoft.HISFC.Models.Base.OperEnvironment();

		
		/// <summary>
		/// 停止者
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment dcOper=new Neusoft.HISFC.Models.Base.OperEnvironment();

		
		/// <summary>
		/// 执行者
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment execOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
		

		/// <summary>
		/// 停止原因
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dcReason = new Neusoft.FrameWork.Models.NeuObject();

		#region 时间

		/// <summary>
		/// 药品项目/非药品项目
		/// </summary>
		private Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();
	

		/// <summary>
		/// 医嘱开立时间
		/// </summary>
		private DateTime dtMOTime;
		
		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime beginTime;
		

		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime endTime;

	

		/// <summary>
		/// 下次分解时间
		/// </summary>
		private DateTime nextMOTime;

		/// <summary>
		/// 审核时间
		/// </summary>
		private DateTime confirmTime;

		#endregion

		/// <summary>
		/// 状态（0、保存 1、审核 2 执行 3 作废）
		/// </summary>
		private int status;

		/// <summary>
		/// 组合信息
		/// </summary>
		private Combo combo=new Combo();

		/// <summary>
		/// 用法
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject usage=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 每次剂量
		/// </summary>
		private decimal doseOnce;

		/// <summary>
		/// 每次剂量单位
		/// </summary>
		private string doseUnit;

		/// <summary>
		/// 频次
		/// </summary>
		private Frequency frequency=new Frequency();

		
		/// <summary>
		/// 草药付数
		/// </summary>
		private decimal herbalQty;

		/// <summary>
		/// 总量单位
		/// </summary>
		private string unit;

		/// <summary>
		/// 使用数量
		/// </summary>
		private int usetimes;

		/// <summary>
		/// 执行状态
		/// </summary>
		private int execStatus;

		/// <summary>
		/// 临时医嘱执行时间使用
		/// 备注1
		/// </summary>
		private string mark1;

		/// <summary>
		/// 备注2
		/// </summary>
		private string mark2;

		/// <summary>
		/// 备注3
		/// </summary>
		private string mark3;

		/// <summary>
		/// 检查部位记录
		/// </summary>
		private string checkPartRecord;

		/// <summary>
		/// 特殊备注 如：胰岛素用法 平片位置 药品服用注意事项
		/// </summary>
		private string note;

		/// <summary>
		/// 处方号
		/// </summary>
		private string recipeNO;

		/// <summary>
		/// 处方流水序号
		/// </summary>
		private int sequenceNO;

		/// <summary>
		/// 送检样本
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject sample = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 复合项目父项信息 ID 复合项目大项编码 NAME 复合项目大项名称
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject package = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 开单医生
		/// </summary>
		private NeuObject reciptDoctor = new NeuObject();

		/// <summary>
		/// <br>加急</br>
		/// </summary>
		private bool isEmergency;

		/// <summary>
		/// 是否附材
		/// </summary>
		private bool isSubtbl;

		/// <summary>
		/// 是否包含附材
		/// </summary>
		private bool isHaveSubtbl;

		/// <summary>
		/// 是否扣药房库存
		/// </summary>
		private bool isStock;

		/// <summary>
		/// 是否是医保患者同意用药
		/// </summary>
		private bool isPermission;

        /// <summary>
        /// 特殊频次，执行剂量
        /// 执行时间放在频次执行时间里面进行处理
        /// </summary>
        private string execDose = "";

        /// <summary>
        /// 配液信息
        /// </summary>
        private Compound compound = new Compound();

        //{E1902932-1839-4a92-8A6A-E42F448FA27F}
        /// <summary>
        /// 申请单号
        /// </summary>
        private string applyNo;

		#endregion

		#region 保护变量
		/// <summary>
		/// 开立科室
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject CreateDept=new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 执行科室
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject ExecDept=new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 药房科室
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject DrugDept=new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 医嘱排列序号（医生可以通过拖拽设置医嘱所在位置）
		/// </summary>
		protected int sortid;
		/// <summary>
		/// 整理医嘱标志
		/// </summary>
		public bool Reorder;
		/// <summary>
		/// 是否婴儿
		/// </summary>
		protected bool bIsBaby;
		/// <summary>
		/// 婴儿序号信息
		/// </summary>
		protected  string  strBabyNo;
		#endregion

		#endregion

		#region 作废的
		/// <summary>
		/// 执行时间
		/// </summary>
		[Obsolete("用ExecOper.OperTime",true)]
		public DateTime Date_Exec;

		/// <summary>
		/// 本次分解时间
		/// </summary>
		[Obsolete("用CurMOTime",true)]
		public DateTime Date_CurMO;

		/// <summary>
		/// 本次分解时间
		/// </summary>
		private DateTime curMOTime;
		/// <summary>
		/// 执行者
		/// </summary>
		[Obsolete("用ExecOper.Oper.ID",true)]
		private Neusoft.FrameWork.Models.NeuObject User_Exec=new Neusoft.FrameWork.Models.NeuObject();
		[Obsolete("Oper.Oper.ID代替",true)]
		public Neusoft.FrameWork.Models.NeuObject User_REC=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 停止者
		/// </summary>
		[Obsolete("用DCOper.Oper.ID",true)]
		public Neusoft.FrameWork.Models.NeuObject User_DC=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 停止操作时间
		/// </summary>
		[Obsolete("用DCOper.OperTime",true)]
		public DateTime DcOperTime;
		/// <summary>
		/// 医嘱开立时间
		/// </summary>
		[Obsolete("改为MOTime",true)]
		public DateTime Date_MO;
		/// <summary>
		/// 开始时间
		/// </summary>
		[Obsolete("改为BeginTime",true)]
		public DateTime Date_Bgn;

		/// <summary>
		/// 结束时间
		/// </summary>
		[Obsolete("改为EndTime",true)]
		public DateTime Date_End;
		/// <summary>
		/// 下次分解时间
		/// </summary>
		[Obsolete("用NextMOTime",true)]
		public DateTime Date_NexMO;

		[Obsolete("用ExtendFlag1代替",true)]
		public string Mark1
		{
			get
			{
				return this.mark1;
			}
			set
			{
				this.mark1 = value;
			}
		}
		/// <summary>
		/// 备注2
		/// </summary>
		[Obsolete("用ExtendFlag2代替",true)]
		public string Mark2
		{
			get
			{
				return this.mark2;
			}
			set
			{
				this.mark2 = value;
			}
		}
		/// <summary>
		/// 备注3
		/// </summary>
		[Obsolete("用ExtendFlag3代替",true)]
		public string Mark3
		{
			get
			{
				return this.mark3;
			}set
			 {
				 this.mark3 = value;
			 }
		}
		#endregion

		#region 属性
        /// <summary>
        /// 特殊频次，执行剂量
        /// 执行时间放在频次执行时间里面进行处理
        /// </summary>
        public string ExecDose
        {
            get
            {
                return execDose;
            }
            set
            {
                execDose = value;
            }
        }

		/// <summary>
		/// 患者基本信息
		/// </summary>
		public Neusoft.HISFC.Models.RADT.PatientInfo Patient
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
		/// 是否需要皮试　新加20050815
		/// 1 不需要皮试　２　需要皮试　３　阳性　４　阴性
		/// </summary>
		public int HypoTest
		{
			get
			{
				return this.hypoTest;
			}
			set
			{
				this.hypoTest = value;
			}
		}
		
		/// <summary>
		/// 院内注射次数
		///新加20050815
		/// </summary>
		public int InjectCount
		{
			get
			{
				return injectCount;
			}
			set
			{
				injectCount = value;
			}
		}
		
		/// <summary>
		/// 开立医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject  Doctor
		{
			get
			{
				return this.doctor;
			}
			set
			{
				this.doctor = value;
			}
		}

		/// <summary>
		/// 审核/执行护士
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Nurse
		{
			get
			{
				return this.nurse;
			}
			set
			{
				this.nurse = value;
			}
		}

		/// <summary>
		/// 记录者
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}
		/// <summary>
		/// 停止者
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment DCOper
		{
			get
			{
				return this.dcOper;
			}
			set
			{
				this.dcOper = value;
			}
		}

		/// <summary>
		/// 执行者
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ExecOper
		{
			get
			{
				return this.execOper;
			}
			set
			{
				this.execOper = value;
			}
		}
		
		
		/// <summary>
		/// 停止原因
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DcReason
		{
			get
			{
				return this.dcReason;
			}
			set
			{
				this.dcReason = value;
			}
		}

		#region 时间
		/// <summary>
		/// 药品项目/非药品项目
		/// </summary>
		public Neusoft.HISFC.Models.Base.Item Item
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
		/// 医嘱开立时间
		/// </summary>
		public DateTime MOTime
		{
			get
			{
				return this.dtMOTime;
			}
			set
			{
				this.dtMOTime = value;
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
		/// 本次分解时间
		/// </summary>
		public DateTime CurMOTime
		{
			get
			{
				return this.curMOTime;
			}
			set
			{
				this.curMOTime = value;
			}
		}

		/// <summary>
		/// 下次分解时间
		/// </summary>
		public DateTime NextMOTime
		{
			get
			{
				return this.nextMOTime;
			}
			set
			{
				this.nextMOTime = value;
			}
		}

		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime ConfirmTime
		{
			get
			{
				return this.confirmTime;
			}
			set
			{
				this.confirmTime = value;
			}
		}

		#endregion

		/// <summary>
		/// 状态（0、保存 1、审核 2 执行 3 作废）
		/// </summary>
		public int Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		/// <summary>
		/// 组合信息
		/// </summary>
		public Combo Combo
		{
			get
			{
				return this.combo;
			}
			set
			{
				this.combo = value;
			}
		}

		/// <summary>
		/// 用法
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Usage
		{
			get
			{
				return this.usage;
			}
			set
			{
				this.usage = value;
			}
		}

		/// <summary>
		/// 每次剂量
		/// </summary>
		public decimal DoseOnce
		{
			get
			{
				return this.doseOnce;
			}
			set
			{
				this.doseOnce = value;
			}
		}

		/// <summary>
		/// 每次剂量单位
		/// </summary>
		public string DoseUnit
		{
			get
			{
				return this.doseUnit;
			}
			set
			{
				this.doseUnit = value;
			}
		}

		/// <summary>
		/// 频次
		/// </summary>
		public Frequency Frequency
		{
			get
			{
				return this.frequency;
			}
			set
			{
				this.frequency = value;
			}
		}

		/// <summary>
		/// 总量
		/// 收费时候是草药的 ==数量*付数
		/// </summary>
		public decimal Qty
		{
			get
			{
				return this.Item.Qty;
			}
			set
			{
				this.Item.Qty = value;
			}
		}

		/// <summary>
		/// 草药付数
		/// </summary>
		public decimal HerbalQty
		{
			get
			{
				return this.herbalQty;
			}
			set
			{
				this.herbalQty = value;
			}
		}

		/// <summary>
		/// 总量单位
		/// </summary>
		public string Unit
		{
			get
			{
				return this.unit;
			}set
			 {
				 this.unit = value;
			 }
		}

		/// <summary>
		/// 使用数量
		/// </summary>
		public int Usetimes
		{
			get
			{
				return this.usetimes;
			}
			set
			{
				this.usetimes = value;
			}
		}

		/// <summary>
		/// 执行状态
		/// </summary>
		public int ExecStatus
		{
			get
			{
				return this.execStatus;
			}set
			 {
				 this.execStatus = value;
			 }
		}

		/// <summary>
		/// 临时医嘱执行时间使用
		/// </summary>
		public string ExtendFlag1
		{
			get
			{
				return this.mark1;
			}
			set
			{
				this.mark1 = value;
			}
		}

		/// <summary>
		/// 备注2
		/// </summary>
		public string ExtendFlag2
		{
			get
			{
				return this.mark2;
			}
			set
			{
				this.mark2 = value;
			}
		}

		/// <summary>
		/// 备注3
		/// </summary>
		public string ExtendFlag3
		{
			get
			{
				return this.mark3;
			}set
			 {
				 this.mark3 = value;
			 }
		}

		/// <summary>
		/// 检查部位记录
		/// </summary>
		public string CheckPartRecord
		{
			get
			{
				return this.checkPartRecord;
			}
			set
			{
				this.checkPartRecord = value;
			}
		}

		/// <summary>
		/// 特殊备注 如：胰岛素用法 平片位置 药品服用注意事项
		/// </summary>
		public string Note
		{
			get
			{
				return this.note;
			}
			set
			{
				this.note = value;
			}
		}

		/// <summary>
		/// 处方号
		/// </summary>
		public string ReciptNO
		{
			get
			{
				return this.recipeNO;
			}
			set
			{
				this.recipeNO = value;
			}
		}

		/// <summary>
		/// 处方流水序号
		/// </summary>
		public int SequenceNO
		{
			get
			{
				return this.sequenceNO;
			}
			set
			{
				this.sequenceNO = value;
			}
		}

		/// <summary>
		/// 送检样本
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Sample 
		{
			get
			{
				return this.sample;
			}
			set
			{
				this.sample = value;
			}
		}

		/// <summary>
		/// 复合项目父项信息 ID 复合项目大项编码 NAME 复合项目大项名称
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Package 
		{
			get
			{
				return this.package;
			}
			set
			{
				this.package = value;
			}
		}

		/// <summary>
		/// 开单医生
		/// </summary>
		public NeuObject ReciptDoctor 
		{
			get
			{
				return this.reciptDoctor;
			}
			set
			{
				this.reciptDoctor = value;
			}
		}

		#region 标志

		/// <summary>
		/// <br>加急</br>
		/// </summary>
		public bool IsEmergency
		{
			get
			{
				return this.isEmergency;
			}
			set
			{
				this.isEmergency = value;
			}
		}
		/// <summary>
		/// 是否附材
		/// </summary>
		public bool IsSubtbl
		{
			get
			{
				return this.isSubtbl;
			}
			set
			{
				this.isSubtbl = value;
			}
		}
		/// <summary>
		/// 是否包含附材
		/// </summary>
		public bool IsHaveSubtbl
		{
			get
			{
				return this.isHaveSubtbl;
			}
			set
			{
				this.isHaveSubtbl = value;
			}
		}
		/// <summary>
		/// 是否扣药房库存
		/// </summary>
		public bool IsStock
		{
			get
			{
				return this.isStock;
			}
			set
			{
				this.isStock = value;
			}
		}
		/// <summary>
		/// 是否是医保患者同意用药
		/// </summary>
		public bool IsPermission
		{
			get
			{
				return this.isPermission;
			}
			set
			{
				this.isPermission = value;
			}
		}

		#endregion

        /// <summary>
        /// 是否配液
        /// </summary>
        public Compound Compound
        {
            get
            {
                return this.compound;
            }
            set
            {
                this.compound = value;
            }
        }


        //{E1902932-1839-4a92-8A6A-E42F448FA27F}
        /// <summary>
        /// 申请单号
        /// </summary>
        public string ApplyNo
        {
            get { return applyNo; }
            set { applyNo = value; }
        }


		#endregion

		#region 接口实现
		
		#region IDept 成员
		/// <summary>
		/// 患者在院科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject InDept
		{
			get
			{
				// TODO:  添加 Order.InDept getter 实现
				return this.Patient.PVisit.PatientLocation.Dept;
			}
			set
			{
				// TODO:  添加 Order.InDept setter 实现
				this.Patient.PVisit.PatientLocation.Dept = value;
			}
		}

		/// <summary>
		/// 执行科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ExeDept
		{
			get
			{
				// TODO:  添加 Order.ExeDept getter 实现
				return this.ExecDept ;
			}
			set
			{
				// TODO:  添加 Order.ExeDept setter 实现
				this.ExecDept =value;
			}
		}

		/// <summary>
		/// 开立科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ReciptDept
		{
			get
			{
				// TODO:  添加 Order.ReciptDept getter 实现
				return this.CreateDept;
			}
			set
			{
				// TODO:  添加 Order.ReciptDept setter 实现
				this.CreateDept =value;
			}
		}

		/// <summary>
		/// 开立执行护士站
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject NurseStation
		{
			get
			{
				// TODO:  添加 Order.NurseStation getter 实现
				return this.Patient.PVisit.PatientLocation.NurseCell;
			}
			set
			{
				// TODO:  添加 Order.NurseStation setter 实现
				this.Patient.PVisit.PatientLocation.NurseCell=value;
			}
		}

		/// <summary>
		/// 扣库科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept
		{
			get
			{
				// TODO:  添加 Order.StockDept getter 实现
				return this.DrugDept ;
			}
			set
			{
				// TODO:  添加 Order.StockDept setter 实现
				this.DrugDept = value;
			}
		}

		/// <summary>
		/// 开立医生所在科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DoctorDept
		{
			get
			{
				// TODO:  添加 Order.ReciptDoct getter 实现
				return this.doctorDept;
			}
			set
			{
				// TODO:  添加 Order.ReciptDoct setter 实现
				this.doctorDept =value;
			}
		}

		#endregion

		#region IBaby 成员
		/// <summary>
		/// 婴儿序号
		/// </summary>
		public string BabyNO
		{
			get
			{
				// TODO:  添加 Order.Neusoft.HISFC.Models.Base.IBaby.BabyNo getter 实现
				if(strBabyNo ==null) this.strBabyNo="0";
				return this.strBabyNo;
			}
			set
			{
				// TODO:  添加 Order.Neusoft.HISFC.Models.Base.IBaby.BabyNo setter 实现
				strBabyNo = value;
			}
		}

		/// <summary>
		/// 是否婴儿
		/// </summary>
		public bool IsBaby
		{
			get
			{
				// TODO:  添加 Order.Neusoft.HISFC.Models.Base.IBaby.IsBaby getter 实现
				return this.bIsBaby;
			}
			set
			{
				// TODO:  添加 Order.Neusoft.HISFC.Models.Base.IBaby.IsBaby setter 实现
				this.bIsBaby = value;
			}
		}

		#endregion

		#region ISort 成员

		public int SortID
		{
			get
			{
				// TODO:  添加 Order.SortID getter 实现
				return this.sortid ;
			}
			set
			{
				// TODO:  添加 Order.SortID setter 实现
				this.sortid =value;
			}
		}

		#endregion

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Order Clone()
		{
			// TODO:  添加 Order.Clone 实现
			Order obj=base.Clone() as Order;
			obj.Combo=this.Combo.Clone();
			obj.DcReason=this.DcReason.Clone();
			
			obj.Frequency=(Frequency)this.Frequency.Clone();
			
			try{obj.ExeDept=this.ExeDept.Clone();}catch{};
			try{obj.InDept=this.InDept.Clone();}catch{};
			try{obj.NurseStation=this.NurseStation.Clone();}catch{};
			try{obj.ReciptDept=this.ReciptDept.Clone();}catch{};
			try{obj.DoctorDept=this.DoctorDept.Clone();}catch{};
			try{obj.StockDept=this.StockDept.Clone();}catch{};

			obj.Item=this.Item.Clone();
			obj.Nurse=this.Nurse.Clone();
			
			try{obj.Patient=this.Patient.Clone();}catch{};
			
			obj.Usage=this.Usage.Clone();
			obj.oper=this.oper.Clone();
			obj.execOper=this.execOper.Clone();
			obj.dcOper=this.dcOper.Clone();

            obj.compound = this.compound.Clone();
			return obj;
		}


		#endregion

		#endregion
	}
}
