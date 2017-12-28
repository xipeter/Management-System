using System;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// Neusoft.HISFC.Models.Fee.Inpatient.ChargeBill<br></br>
	/// [功能描述: 病区收费单]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///		/>
	/// </summary>
    [Serializable]
    public class ChargeBill:Neusoft.FrameWork.Models.NeuObject,Base.IBaby,Base.IDept
	{
		public ChargeBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量
		
		/// <summary>
		/// 收费单据号
		/// </summary>
		private string billNO;

		/// <summary>
		/// 医嘱ID
		/// </summary>
		private string orderID;

		/// <summary>
		/// 医嘱执行ID
		/// </summary>
		private string execOrderID;
		
		/// <summary>
		/// 医嘱组合实体
		/// </summary>
		private Order.Combo combo = new Neusoft.HISFC.Models.Order.Combo();

		/// <summary>
		/// 住院流水号
		/// </summary>
		private string inpatientNO;

		/// <summary>
		/// 是否婴儿收费
		/// </summary>
		private bool isBaby = false;

		/// <summary>
		/// 婴儿序号
		/// </summary>
		private string babyNO;

		/// <summary>
		/// 是否打印
		/// </summary>
		private bool isPrint = false;

		/// <summary>
		/// 是否收费
		/// </summary>
		private bool isCharge = false;

		/// <summary>
		/// 使用时间
		/// </summary>
		private DateTime dtuseTime;

		/// <summary>
		/// 出单类型  C 普通出单 Z 自费药出单 T 特殊项目出单 D 超标出单 XS 限制药出单 M1 医保甲出单 M2 医保乙出单 M3 医保自费药出单
		/// </summary>
		private string outputType = "C";

		
		/// <summary>
		/// 价格
		/// </summary>
		private decimal price;
		/// <summary>
		/// 数量
		/// </summary>
		private decimal qty;
		/// <summary>
		/// 单位
		/// </summary>
		private string priceUnit;
		/// <summary>
		/// 规格
		/// </summary>
		private string specs;
		/// <summary>
		/// 是否药品
		/// </summary>
		private bool isPharmacy;
		/// <summary>
		/// 付数
		/// </summary>
		private int useTimes;
		/// <summary>
		/// 总额
		/// </summary>
		private decimal totCost;
		
		
		/// <summary>
		/// 住院科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject inDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 护士站代码
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject nurseID = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 开方科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject recipeDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 执行科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject execDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 取药药房
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject storeDept = new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 开立医生科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctorDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 收费操作
		/// </summary>
		private Base.OperEnvironment reciptOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 操作记录
		/// </summary>
		private Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 打印操作
		/// </summary>
		private Base.OperEnvironment printOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 开立医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctor = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 频次
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject frequency = new Neusoft.FrameWork.Models.NeuObject();

		#region 处方信息
		/// <summary>
		/// 处方号
		/// </summary>
		private string recipeNO;

		/// <summary>
		/// 处方内流水号
		/// </summary>
		private int sequenceNO;

		#endregion

		#endregion

		#region 属性

		/// <summary>
		/// 收费单号
		/// </summary>
		public string BillNO
		{
			get
			{
				return this.billNO;
			}
			set
			{
				this.billNO = value;
			}
		}

		/// <summary>
		/// 医嘱号
		/// </summary>
		public string OrderID
		{
			get
			{
				return this.orderID;
			}
			set
			{
				this.orderID = value;
			}
		}

		/// <summary>
		/// 医嘱执行挡编号
		/// </summary>
		public string ExecOrderID
		{
			get
			{
				return this.execOrderID;
			}
			set
			{
				this.execOrderID = value;
			}
		}
		
		/// <summary>
		/// 组合
		/// </summary>
		public Order.Combo Combo
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
		/// 住院流水号
		/// </summary>
		public string InpatientNO
		{
			get
			{
				return this.inpatientNO;
			}
			set
			{
				this.inpatientNO = value;
			}
		}

		/// <summary>
		/// 是否打印
		/// </summary>
		public bool IsPrint
		{
			get
			{
				return this.isPrint;
			}
			set
			{
				this.isPrint = value;
			}
		}
		/// <summary>
		/// 是否收费
		/// </summary>
		public bool IsCharge
		{
			get
			{
				return this.isCharge;
			}
			set
			{
				this.isCharge = value;
			}
		}

		/// <summary>
		/// 使用时间
		/// </summary>
		public DateTime UseTime
		{
			get
			{
				return this.dtuseTime;
			}
			set
			{
				this.dtuseTime = value;
			}
		}

		/// <summary>
		/// 出单类型  C 普通出单 Z 自费药出单 T 特殊项目出单 D 超标出单 XS 限制药出单 M1 医保甲出单 M2 医保乙出单 M3 医保自费药出单
		/// 默认 普通出单
		/// </summary>
		public string OutputType
		{
			get
			{
				return this.outputType;
			}
			set
			{
				this.outputType = value;
			}
		}

		/// <summary>
		/// 价格
		/// </summary>
		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				this.price = value;
			}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string PriceUnit
		{
			get
			{
				return this.priceUnit;
			}
			set
			{
				this.priceUnit = value;
			}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Specs
		{
			get
			{
				return this.specs;
			}
			set
			{
				this.specs = value;
			}
		}
		/// <summary>
		/// 是否药品
		/// </summary>
		public bool IsPharmacy
		{
			get
			{
				return this.isPharmacy;
			}
			set
			{
				this.isPharmacy = value;
			}
		}
		/// <summary>
		/// 付数
		/// 使用次数
		/// </summary>
		public int HerbalQty
		{
			get
			{
				return this.useTimes;
			}
			set
			{
				this.useTimes = value;
			}
		}
		/// <summary>
		/// 总额
		/// </summary>
		public decimal TotCost
		{
			get
			{
				return this.totCost;
			}
			set
			{
				this.totCost = value;
			}
		}

		/// <summary>
		/// 收费操作
		/// </summary>
		public Base.OperEnvironment ReciptOper 
		{
			get
			{
				return this.reciptOper;
			}
			set
			{
				this.reciptOper = value;
			}
		}

		/// <summary>
		/// 操作记录
		/// </summary>
		public Base.OperEnvironment Oper
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
		/// 打印操作
		/// </summary>
		public Base.OperEnvironment PrintOper
		{
			get
			{
				return this.printOper;
			}
			set
			{
				this.printOper = value;
			}
		}

		/// <summary>
		/// 开立医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Doctor
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
		/// 处方内流水号
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
		/// 频次
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Frequency
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
		#endregion

		#region 作废的

		/// <summary>
		/// 项目序列号,主键
		/// </summary>
		[Obsolete("用ID代替了",true)]
		public string BillID;

		[Obsolete("用BillNO代替了",true)]
		public string BillNo;

		[Obsolete("用ExecOrderID代替了",true)]
		public string ExecID;

		[Obsolete("用Combo.ID代替了",true)]
		public string CombNo;

		[Obsolete("用InpatientNO代替了",true)]
		public string InpatientNo;

		[Obsolete("用IsBaby代替了",true)]
		public bool IsBabyCharge;

		[Obsolete("用UseTime代替了",true)]
		public DateTime useTime;

		[Obsolete("用HerbalQty代替了",true)]
		public int Days;

		[Obsolete("用ReciptNO代替了",true)]
		public string RecipeNo;

		[Obsolete("用Doctor.ID代替了",true)]
		public string DoctID;
		
		[Obsolete("用Oper.Oper.ID代替了",true)]
		public string RecordID;
		
		[Obsolete("用PrintOper.Oper.ID代替了",true)]
		public string PrintID;
		
		[Obsolete("用ChargeOper.Oper.ID代替了",true)]
		public string ChargeID;

		[Obsolete("用Oper.OperTime代替了",true)]
		public DateTime RecordDate;

		[Obsolete("用PrintOper.OperTime代替了",true)]
		public DateTime PrintDate;
		
		[Obsolete("用ChargeOper.OperTime代替了",true)]
		public DateTime ChargeDate;

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new ChargeBill Clone()
		{
			ChargeBill obj=base.Clone() as ChargeBill;		
			obj.combo = this.combo.Clone();
			obj.oper = this.oper.Clone();
			obj.printOper = this.printOper.Clone();
			obj.reciptOper = this.reciptOper.Clone();
			return obj;
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
				// TODO:  添加 ChargeBill.BabyNO getter 实现
				return this.babyNO;
			}
			set
			{
				// TODO:  添加 ChargeBill.BabyNO setter 实现
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
				// TODO:  添加 ChargeBill.IsBaby getter 实现
				return this.isBaby;
			}
			set
			{
				// TODO:  添加 ChargeBill.IsBaby setter 实现
				this.isBaby = value;
			}
		}

		#endregion

		#region IDept 成员
		
		/// <summary>
		/// 患者在院科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject InDept
		{
			get
			{
				// TODO:  添加 ChargeBill.InDept getter 实现
				return this.inDept;
			}
			set
			{
				// TODO:  添加 ChargeBill.InDept setter 实现
				this.inDept = value;
			}
		}
		
		/// <summary>
		/// 执行科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ExeDept
		{
			get
			{
				// TODO:  添加 ChargeBill.ExeDept getter 实现
				return this.execDept;
			}
			set
			{
				// TODO:  添加 ChargeBill.ExeDept setter 实现
				this.execDept = value;
			}
		}

		/// <summary>
		/// 开单科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ReciptDept
		{
			get
			{
				// TODO:  添加 ChargeBill.ReciptDept getter 实现
				return this.recipeDept;
			}
			set
			{
				// TODO:  添加 ChargeBill.ReciptDept setter 实现
				this.recipeDept = value;
			}
		}

		/// <summary>
		/// 患者在护士站
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject NurseStation
		{
			get
			{
				// TODO:  添加 ChargeBill.NurseStation getter 实现
				return this.nurseID;
			}
			set
			{
				// TODO:  添加 ChargeBill.NurseStation setter 实现
				this.nurseID = value;
			}
		}

		/// <summary>
		/// 扣库科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept
		{
			get
			{
				// TODO:  添加 ChargeBill.StockDept getter 实现
				return this.storeDept;
			}
			set
			{
				// TODO:  添加 ChargeBill.StockDept setter 实现
				this.storeDept = value;
			}
		}

		/// <summary>
		/// 开立医生所在科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DoctorDept
		{
			get
			{
				// TODO:  添加 ChargeBill.DoctorDept getter 实现
				return this.doctorDept;
			}
			set
			{
				// TODO:  添加 ChargeBill.DoctorDept setter 实现
				this.doctorDept = value;
			}
		}

		#endregion

		#endregion
	}
}
