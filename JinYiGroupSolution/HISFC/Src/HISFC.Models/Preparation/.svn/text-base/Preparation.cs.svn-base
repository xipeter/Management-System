using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Preparation<br></br>
	/// [功能描述: 制剂管理 主类]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Preparation:PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Preparation()
		{
		}

		#region 变量

        /// <summary>
        /// 计划制定---人，日期
        /// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment planEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 配制--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment confectEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        ///  半成品量(配制量)
        /// </summary>
        private decimal confectQty;

		/// <summary>
		/// 检验是否合格  默认合格
		/// </summary>
		private bool isAssayEligible = true;

		/// <summary>
		/// 检验---人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment assayEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 入库状态 0 暂入库 1 正式入库
		/// </summary>
		private string inputState;

		/// <summary>
		/// 入库数量
		/// </summary>
		private decimal inputQty;

		/// <summary>
		/// 入库---人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment inputEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 审核意见
		/// </summary>
		private string checkResult;

		/// <summary>
		/// 审核员
		/// </summary>
		private string checkOper;

        /// <summary>
        /// 生产流程标志
        /// </summary>
        private string processState;

        /// <summary>
        /// 有效期
        /// </summary>
        private DateTime validDate = System.DateTime.MaxValue;

        /// <summary>
        /// 成本价
        /// </summary>
        private decimal costPrice;
		#endregion

		#region  属性

		/// <summary>
		/// 检验结果是否合格 默认合格
		/// </summary>
		public bool IsAssayEligible
		{
			get
			{
				return this.isAssayEligible;
			}
			set
			{
				this.isAssayEligible = value;
			}
		}

		/// <summary>
		/// 入库状态 0 暂入库 1 正式入库
		/// </summary>
		public string InputState
		{
			get
			{
				return this.inputState;
			}
			set
			{
				this.inputState = value;
			}
		}

		/// <summary>
		/// 入库数量
		/// </summary>
		public decimal InputQty
		{
			get
			{
				return this.inputQty;
			}
			set
			{
				this.inputQty = value;
			}
		}

		/// <summary>
		/// 审核意见
		/// </summary>
		public string CheckResult
		{
			get
			{
				return this.checkResult;
			}
			set
			{
				this.checkResult = value;
			}
		}

		/// <summary>
		/// 审核员
		/// </summary>
		public string CheckOper
		{
			get			
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}

        /// <summary>
        /// 半成品量(配制量)
        /// </summary>
        public decimal ConfectQty
        {
            get
            {
                return this.confectQty;
            }
            set
            {
                this.confectQty = value;
            }
        }

		/// <summary>
		/// 入库---人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment InputEnv
		{
			get
			{
				return this.inputEnv;
			}
			set
			{
				this.inputEnv = value;
			}
		}

		/// <summary>
		/// 检验---人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment AssayEnv
		{
			get
			{
				return this.assayEnv;
			}
			set
			{
				this.assayEnv = value;
			}
		}

		/// <summary>
		/// 计划制定---人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment PlanEnv
		{
			get
			{
				return this.planEnv;
			}
			set
			{
				this.planEnv = value;
			}
		}

		/// <summary>
		/// 配制--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ConfectEnv
		{
			get
			{
				return this.confectEnv;
			}
			set
			{
				this.confectEnv = value;
			}
		}

        /// <summary>
        /// 生产流程标志
        /// </summary>
        public string ProcessState
        {
            get
            {
                return this.processState;
            }
            set
            {
                this.processState = value;
            }
        }

        /// <summary>
        /// 有效期、仅用于数据传递。不存储数据库
        /// </summary>
        public DateTime ValidDate
        {
            get
            {
                return this.validDate;
            }
            set
            {
                this.validDate = value;
            }
        }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice
        {
            get
            {
                return this.costPrice;
            }
            set
            {
                this.costPrice = value;
            }
        }

		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Preparation</returns>
		public new Preparation Clone()
		{
			Preparation preparation = base.Clone() as Preparation;
			preparation.inputEnv = this.inputEnv.Clone();
			preparation.planEnv = this.planEnv.Clone();
			preparation.confectEnv = this.confectEnv.Clone();
			preparation.assayEnv = this.assayEnv.Clone();
			return preparation;
		}

		#endregion

		#region  过期属性
		/// <summary>
		/// 入库数量
		/// </summary>
		[System.Obsolete("已经过期，使用InputQty", true)]
		public decimal InputNum
		{
			get
			{
				return 0;
			}
			set
			{
			//	this.inputNum = value;
			}
		}
		/// <summary>
		/// 计划制定人
		/// </summary>
		[System.Obsolete("已经过期，使用PlanEnv", true)]
		public string PlanOper
		{
			get
			{
				return null;
			}
			set
			{
				//this.planOper = value;
			}
		}
		/// <summary>
		/// 计划时间 
		/// </summary>
		[System.Obsolete("已经过期，使用PlanEnv", true)]
		public DateTime PlanDate
		{
			get
			{
				return DateTime.Now;
			}
			set
			{
				//this.planDate = value;
			}
		}
		/// <summary>
		/// 配制员
		/// </summary>
		[System.Obsolete("已经过期，使用ConfectEnv", true)]
		public string ConfectOper
		{
			get
			{
				return null;
			}
			set
			{
				//this.confectOper = value;
			}
		}
		/// <summary>
		/// 配制时间
		/// </summary>
		[System.Obsolete("已经过期，使用ConfectEnv", true)]
		public DateTime ConfectDate
		{
			get
			{
				return DateTime.Now;
			}
			set
			{
				//this.confectDate = value;
			}
		}
		/// <summary>
		/// 检验人
		/// </summary>
		[System.Obsolete("已经过期，使用AssayEnv", true)]
		public string AssayOper
		{
			get
			{
				return null;
			}
			set
			{
				//this.assayOper = value;
			}
		}

		/// <summary>
		/// 检验时间
		/// </summary>
		[System.Obsolete("已经过期，使用AssayEnv", true)]
		public DateTime AssayDate
		{
			get
			{
				return DateTime.Now;
			}
			set
			{
				//this.assayDate = value;
			}
		}
		/// <summary>
		/// 入库操作员
		/// </summary>
		[System.Obsolete("已经过期，使用InputEnv", true)]
		public string InputOper
		{
			get
			{
				return null;
			}
			set
			{
				//this.inputOper = value;
			}
		}
		/// <summary>
		/// 入库时间
		/// </summary>
		[System.Obsolete("已经过期，使用InputEnv", true)]
		public DateTime InputDate
		{
			get
			{
				return DateTime.Now;
			}
			set
			{
				//this.inputDate = value;
			}
		}
		#endregion
	}
}
