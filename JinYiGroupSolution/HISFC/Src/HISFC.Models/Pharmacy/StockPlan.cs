using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 采购计划类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-11]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	///  ID 采购计划流水号
	/// </summary>
    [Serializable]
    public class StockPlan : Base.PlanBase
	{
		public StockPlan() 
		{

		}

		#region 变量

		/// <summary>
		/// 采购类型
		/// </summary>
		private System.String myPlanType ;

		/// <summary>
		/// 供货公司
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myCompany = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 计划购入价
		/// </summary>
		private System.Decimal myStockPrice ;		

		/// <summary>
		/// 审批量
		/// </summary>
		private System.Decimal myApproveQty;

		/// <summary>
		/// 入库量
		/// </summary>
		private System.Decimal myInQty;

		/// <summary>
		/// 入库单据号
		/// </summary>
		private System.String myInListNO ;

		/// <summary>
		/// 审批人
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment approveOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 入库人
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment inOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 计划单流水号 计划单号 多条计划时以' | ' 分割
        /// </summary>
        private string planNO;

		#endregion      


		/// <summary>
		/// 供药公司
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Company 
		{
			get
			{ 
				return this.myCompany; 
			}
			set
			{ 
				this.myCompany = value; 
			}
		}

        /// <summary>
        /// 计划购入价
        /// </summary>
        public System.Decimal StockPrice
        {
            get
            {
                return this.myStockPrice;
            }
            set
            {
                this.myStockPrice = value;
            }
        }
		
		/// <summary>
		/// 采购审批数量
		/// </summary>
		public System.Decimal StockApproveQty 
		{
			get
			{ 
				return this.myApproveQty;
			}
			set
			{
				this.myApproveQty = value;
			}
		}

		/// <summary>
		/// 审批人信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ApproveOper
		{
			get
			{
				return this.approveOper;
			}
			set
			{
				this.approveOper = value;
			}
		}

		/// <summary>
		/// 实际入库数量
		/// </summary>
		public System.Decimal InQty 
		{
			get
			{ 
				return this.myInQty; 
			}
			set
			{ 
				this.myInQty = value; 
			}
		}

		/// <summary>
		/// 入库人员信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment InOper
		{
			get
			{
				return this.inOper;
			}
			set
			{
				this.inOper = value;
			}
		}

		/// <summary>
		/// 入库单据号
		/// </summary>
		public System.String InListNO 
		{
			get
			{ 
				return this.myInListNO; 
			}
			set
			{ 
				this.myInListNO = value; 
			}
		}

        /// <summary>
        /// 计划单流水号 计划单号 多条计划时以' | ' 分割
        /// </summary>
        public string PlanNO
        {
            get
            {
                return this.planNO;
            }
            set
            {
                this.planNO = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的克隆实体</returns>
		public new StockPlan Clone()
		{
			StockPlan stockPlan = base.Clone() as StockPlan;

			stockPlan.Company = this.Dept.Clone();

			stockPlan.ApproveOper = this.ApproveOper.Clone();
			stockPlan.InOper = this.InOper.Clone();

			return stockPlan;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 采购单号
		/// </summary>
		private System.String myBillCode ;

		/// <summary>
		/// 计划人 
		/// </summary>
		private System.String myPlanEmpl ;

		/// <summary>
		/// 计划日前
		/// </summary>
		private System.DateTime myPlanDate ;

		/// <summary>
		/// 采购人
		/// </summary>
		private System.String myStockEmpl ;

		/// <summary>
		/// 采购日期
		/// </summary>
		private System.DateTime myStockDate ;

		/// <summary>
		/// 入库人
		/// </summary>
		private System.String myInEmpl ;

		/// <summary>
		/// 入库日期
		/// </summary>
		private System.DateTime myInDate ;

		/// <summary>
		/// 审批人
		/// </summary>
		private System.String myApproveEmpl ;

		/// <summary>
		/// 审批日期
		/// </summary>
		private System.DateTime myApproveDate ;

		/// <summary>
		/// 操作人
		/// </summary>
		private System.String myOperCode ;

		/// <summary>
		/// 操作时间
		/// </summary>
		private System.DateTime myOperDate ;

		/// <summary>
		/// 本科室库存量
		/// </summary>
		private System.Decimal myStoreNum ;

		/// <summary>
		/// 全院库存量
		/// </summary>
		private System.Decimal myStoreTotsum ;

		/// <summary>
		/// 全院出库总量
		/// </summary>
		private System.Decimal myOutputSum ;

		/// <summary>
		/// 计划购入量
		/// </summary>
		private System.Decimal myPlanNum ;

		/// <summary>
		/// 审批数量
		/// </summary>
		private System.Decimal myApproveNum ;

		/// <summary>
		/// 入库量
		/// </summary>
		private System.Decimal myInNum ;
		
		/// <summary>
		/// 入库单据号
		/// </summary>
		private System.String myInListCode ;

		/// <summary>
		/// 采购单号
		/// </summary>
		[System.Obsolete("程序重构 更改为BillNO属性",true)]
		public System.String BillCode 
		{
			get
			{ 
				return this.myBillCode;
			}
			set
			{ 
				this.myBillCode = value; 
				this.ID = value;
			}
		}


		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public System.String OperCode 
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 操作日期
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public System.DateTime OperDate 
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		/// <summary>
		/// 入库操作人
		/// </summary>
		[System.Obsolete("程序重构 更改为InOper属性",true)]
		public System.String InEmpl 
		{
			get{ return this.myInEmpl; }
			set{ this.myInEmpl = value; }
		}


		/// <summary>
		/// 入库时间
		/// </summary>
		[System.Obsolete("程序重构 更改为InOper属性",true)]
		public System.DateTime InDate 
		{
			get{ return this.myInDate; }
			set{ this.myInDate = value; }
		}


		/// <summary>
		/// 审批人
		/// </summary>
		[System.Obsolete("程序重构 更改为ApproveOper属性",true)]
		public System.String ApproveEmpl 
		{
			get{ return this.myApproveEmpl; }
			set{ this.myApproveEmpl = value; }
		}


		/// <summary>
		/// 审批时间
		/// </summary>
		[System.Obsolete("程序重构 更改为ApproveOper属性",true)]
		public System.DateTime ApproveDate 
		{
			get{ return this.myApproveDate; }
			set{ this.myApproveDate = value; }
		}


		/// <summary>
		/// 计划人
		/// </summary>
		[System.Obsolete("程序重构 更改为PlanOper属性",true)]
		public System.String PlanEmpl 
		{
			get
			{ 
				return this.myPlanEmpl; 
			}
			set
			{ 
				this.myPlanEmpl = value; 
			}
		}


		/// <summary>
		/// 计划日期
		/// </summary>
		[System.Obsolete("程序重构 更改为PlanOper属性",true)]
		public System.DateTime PlanDate 
		{
			get{ return this.myPlanDate; }
			set{ this.myPlanDate = value; }
		}


		/// <summary>
		/// 采购人
		/// </summary>
		[System.Obsolete("程序重构 更改为StockOper属性",true)]
		public System.String StockEmpl 
		{
			get{ return this.myStockEmpl; }
			set{ this.myStockEmpl = value; }
		}


		/// <summary>
		/// 采购日期
		/// </summary>
		[System.Obsolete("程序重构 更改为StockOper属性",true)]
		public System.DateTime StockDate 
		{
			get{ return this.myStockDate; }
			set{ this.myStockDate = value; }
		}


		/// <summary>
		/// 本科室库存数量
		/// </summary>
		[System.Obsolete("程序重构 更改为StoreQty属性",true)]
		public System.Decimal StoreNum 
		{
			get
			{ 
				return this.myStoreNum;
			}
			set
			{ 
				this.myStoreNum = value; 
			}
		}


		/// <summary>
		/// 全院库存总和
		/// </summary>
		[System.Obsolete("程序重构 更改为StoreTotQty属性",true)]
		public System.Decimal StoreTotsum 
		{
			get
			{ 
				return this.myStoreTotsum;
			}
			set
			{ 
				this.myStoreTotsum = value; 
			}
		}


		/// <summary>
		/// 全院出库总量
		/// </summary>
		[System.Obsolete("程序重构 更改为OutputQty属性",true)]
		public System.Decimal OutputSum 
		{
			get
			{ 
				return this.myOutputSum;
			}
			set
			{ 
				this.myOutputSum = value;
			}
		}


		/// <summary>
		/// 计划入库量
		/// </summary>
		[System.Obsolete("程序重构 更改为PlanQty属性",true)]
		public System.Decimal PlanNum 
		{
			get
			{ 
				return this.myPlanNum; 
			}
			set
			{ 
				this.myPlanNum = value; 
			}
		}


		/// <summary>
		/// 审批数量
		/// </summary>
		[System.Obsolete("程序重构 更改为ApproveQty属性",true)]
		public System.Decimal ApproveNum 
		{
			get{ return this.myApproveNum; }
			set{ this.myApproveNum = value; }
		}


		/// <summary>
		/// 实际入库数量
		/// </summary>
		[System.Obsolete("程序重构 更改为InQty属性",true)]
		public System.Decimal InNum 
		{
			get{ return this.myInNum; }
			set{ this.myInNum = value; }
		}


		/// <summary>
		/// 入库单据号
		/// </summary>
		[System.Obsolete("程序重构 更改为InListNO属性",true)]
		public System.String InListCode 
		{
			get
			{ 
				return this.myInListCode; 
			}
			set
			{ 
				this.myInListCode = value; 
			}
		}

        /// <summary>
        /// 审批数量
        /// </summary>
        [System.Obsolete("程序重构 更改为StockApproveQty属性", true)]
        public System.Decimal ApproveQty
        {
            get
            {
                return this.myApproveQty;
            }
            set
            {
                this.myApproveQty = value;
            }
        }


		#endregion

	}
}
