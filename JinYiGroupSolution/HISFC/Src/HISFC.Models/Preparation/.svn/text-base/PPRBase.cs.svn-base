using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// PPRBase<br></br>
	/// [功能描述: 制剂管理基类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PPRBase:Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PPRBase()
		{

		}

		#region 变量

		/// <summary>
		/// 成品
		/// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item drug = new Pharmacy.Item();

		/// <summary>
		/// 生产计划编号 
		/// </summary>
		private string planNO = "";
		
		/// <summary>
		/// 状态 0 计划 1 配置 2 半成品分装 3 半成品检验 4 成品外包装 5 成品检验 6 成品入库
		/// </summary>
		private EnumState state = EnumState.Plan;
		
		/// <summary>
		/// 计划配液量
		/// </summary>
		private decimal planQty;
		
		/// <summary>
		/// 检验量
		/// </summary>
		private decimal assayQty;

		/// <summary>
		/// 制剂 单位
		/// </summary>
		private string unit;

		/// <summary>
		/// 成品批号
		/// </summary>
		private string batchNO;

		/// <summary>
		/// 是否清场 
		/// </summary>
		private bool isClear;

		/// <summary>
		/// 设备是否完好
		/// </summary>
		private bool isWhole;

		/// <summary>
		/// 设备是否清洁
		/// </summary>
		private bool isCleanness;

		/// <summary>
		/// 规程名
		/// </summary>
		private string regulations;

		/// <summary>
		/// 质量情况
		/// </summary>
		private string quality;

		/// <summary>
		/// 工艺执行情况
		/// </summary>
		private string execute;

		/// <summary>
		/// 操作信息--人员、日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 备注
		/// </summary>
		private string mark;

		/// <summary>
		/// 扩展标记
		/// </summary>
		private string extend1;

		/// <summary>
		/// 扩展标记1
		/// </summary>
		private string extend2;

		/// <summary>
		/// 扩展标记2
		/// </summary>
		private string extend3;


		#endregion

		#region 属性
		/// <summary>
		/// 制剂成品
		/// </summary>
        public Pharmacy.Item Drug
		{
			get
			{
				return this.drug;
			}
			set
			{
				this.drug = value;
			}
		}


		/// <summary>
		/// 生产计划编号
		/// </summary>
		public string PlanNO
		{
			get
			{
				return this.planNO;
			}
			set
			{
				this.ID = value;
                this.planNO = value;
			}
		}


		/// <summary>
		/// 状态 0 计划 1 配置 2 半成品检验 3 半成品分装 4 成品外包装 5 成品检验 6 成品入库
		/// </summary>
		public EnumState State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}


		/// <summary>
		/// 计划配液量
		/// </summary>
		public decimal PlanQty
		{
			get
			{
				return this.planQty;
			}
			set
			{
                this.planQty = value;
			}
		}


		/// <summary>
		/// 检验量
		/// </summary>
		public decimal AssayQty
		{
			get
			{
				return this.assayQty;
			}
			set
			{
				this.assayQty = value;
			}
		}


		/// <summary>
		/// 制剂 单位
		/// </summary>
		public string Unit
		{
			get
			{
				return this.unit;
			}
			set
			{
				this.unit = value;
			}
		}

        
		/// <summary>
		/// 成品批号
		/// </summary>
		public string BatchNO
		{
			get
			{
				return this.batchNO;
			}
			set
			{
				this.batchNO = value;
			}
		}


		/// <summary>
		/// 是否清场
		/// </summary>
		public bool IsClear
		{
			get
			{
				return this.isClear;
			}
			set
			{
				this.isClear = value;
			}
		}


		/// <summary>
		/// 设备是否完好
		/// </summary>
		public bool IsWhole
		{
			get
			{
				return this.isWhole;
			}
			set
			{
				this.isWhole = value;
			}
		}

		/// <summary>
		/// 设备是否清洁
		/// </summary>
		public bool IsCleanness
		{
			get
			{
				return this.isCleanness;
			}
			set
			{
				this.isCleanness = value;
			}
		}


		/// <summary>
		/// 规程名
		/// </summary>
		public string Regulations
		{
			get
			{
				return this.regulations;
			}
			set
			{
				this.regulations = value;
			}
		}

		
		/// <summary>
		/// 质量情况
		/// </summary>
		public string Quality
		{
			get
			{
				return this.quality;
			}
			set
			{
				this.quality = value;
			}
		}


		/// <summary>
		/// 工艺执行情况
		/// </summary>
		public string Execute
		{
			get
			{
				return this.execute;
			}
			set
			{
				this.execute = value;
			}
		}


		/// <summary>
		/// 操作信息--人员、日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
		{
			get
			{
				return this.operEnv;
			}
			set
			{
				this.operEnv = value;
			}
		}

		/// <summary>
		/// 扩展标记1
		/// </summary>
		public string Extend1
		{
			get
			{
				return this.extend1;
			}
			set
			{
				this.extend1 = value;
			}
		}

		/// <summary>
		/// 扩展标记2
		/// </summary>
		public string Extend2
		{
			get
			{
				return this.extend2;
			}
			set
			{
				this.extend2 = value;
			}
		}
		/// <summary>
		/// 扩展标记3
		/// </summary>
		public string Extend3
		{
			get
			{
				return this.extend3;
			}
			set
			{
				this.extend3 = value;
			}
		}


		#endregion

		#region 无效属性		

		/// <summary>
		/// 备注
		/// </summary>
		[System.Obsolete("已经过期，使用NeuObject的属性", true)]
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
		/// 扩展标记2
		/// </summary>
		[System.Obsolete("已经过期，使用Extend3", true)]
		public string ExtFlag2
		{
			get
			{
				return this.extend3;
			}
			set
			{
				this.extend3 = value;
			}
		}

		/// <summary>
		/// 扩展标记
		/// </summary>
		[System.Obsolete("已经过期，使用Extend1", true)]
		public string ExtFlag
		{
			get
			{
				return this.extend1;
			}
			set
			{
				this.extend1 = value;
			}
		}
		/// <summary>
		/// 扩展标记1
		/// </summary>
		[System.Obsolete("已经过期，使用Extend2", true)]
		public string ExtFlag1
		{
			get
			{
				return this.extend2;
			}
			set
			{
				this.extend2 = value;
			}
		}
		/// <summary>
		/// 生产计划编号
		/// </summary>
		[System.Obsolete("已经过期，使用PlanNO", true)]
		public string PlanNo
		{
			get
			{
				return this.planNO;
			}
			set
			{
				this.ID = value;
				this.planNO = value;
			}
		}
		
		/// <summary>
		/// 计划配液量
		/// </summary>
		[System.Obsolete("已经过期，使用PlanQty", true)]
		public decimal PlanNum
		{
			get
			{
				return this.planQty;
			}
			set
			{
				this.planQty = value;
			}
		}

		/// <summary>
		/// 检验数量
		/// </summary>
		[System.Obsolete("已经过期，使用AssayQty", true)]
		public decimal AssayNum
		{
			get
			{
				return this.assayQty;
			}
			set
			{
				this.assayQty = value;
			}
		}

		/// <summary>
		/// 成品批号
		/// </summary>
		[System.Obsolete("程序整合 更改为BatchNO属性",true)]
		public string BatchNo
		{
			get
			{
				return this.batchNO;
			}
			set
			{
				this.batchNO = value;
			}
		}


		#region 可能要改
		//		/// <summary>
		//		/// 操作员
		//		/// </summary>
		//		public string OperCode;
		//		/// <summary>
		//		/// 操作时间
		//		/// </summary>
		//		public DateTime OperDate;
		#endregion



		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>PPRBase</returns>
		public new PPRBase Clone()
		{
			PPRBase pprbase = base.Clone() as PPRBase;
			pprbase.drug = this.drug.Clone();
			pprbase.operEnv = this.operEnv.Clone();
			return pprbase;
		}

		#endregion
	}
}