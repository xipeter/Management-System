using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品管理入库信息类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自StorageBase基类'
	///  />
	///  ID 入库单流水号
	///  TargetDept跟Company取值相同
	/// </summary>
    [Serializable]
    public class Input : StorageBase
	{
		public Input () 
		{
            //此处应该存储用户自定义的入库类型 不应该存储0310
            //this.PrivType = "0310";	//入库权限编码

            this.Class2Type = "0310";
		}

		#region 变量

		private string   myInListCode;

		private string   myOutBillCode = "0";

		private int      myOutSerialNo;

		private string   myOutListCode;

		private decimal  myApplyNum;

		private string   myApplyOperCode;

		private DateTime myApplyDate;

		private decimal  myExamNum;

		private string   myExamOperCode;

		private DateTime myExamDate;

		private string   myApproveOperCode;

		private DateTime myApproveDate;

		private string   myMedID;

		private string   myDeliveryNo;

		private string   myTenderNo;

		private string   myPayState;

		private string   myCashFlag;

		private decimal  myActualRate;

		private decimal	 myReturnNum;

        private string myStockNO;

        private DateTime invoiceDate;

        private decimal commonPurchasePrice;

        /// <summary>
        /// 入库时间
        /// 
        /// {24E12384-34F7-40c1-8E2A-3967CECAF615}
        /// </summary>
        private DateTime inDate;

        /// <summary>
        /// 源科室（供货单位）类型  1 院内科室 2 供货单位 3 扩展
        /// 
        /// {24E12384-34F7-40c1-8E2A-3967CECAF615}
        /// </summary>
        private string sourceCompanyType;

		#endregion

		/// <summary>
		/// 入库单据号
		/// </summary>
		public string InListNO 
		{
			get	
			{
				return  myInListCode;
			}
			set	
			{ 
				myInListCode = value; 
			}
		}


		/// <summary>
		/// 出库单号
		/// </summary>
		public string OutBillNO 
		{
			get	
			{
				return  myOutBillCode;
			}
			set	
			{
				myOutBillCode = value;
			}
		}


		/// <summary>
		/// 出库单内序号
		/// </summary>
		public int OutSerialNO 
		{
			get	
			{
				return  myOutSerialNo;
			}
			set	
			{
				myOutSerialNo = value; 
			}
		}


		/// <summary>
		/// 出库单据号
		/// </summary>
		public string OutListNO 
		{
			get	
			{
				return  myOutListCode;
			}
			set	
			{ 
				myOutListCode = value;
			}
		}


		/// <summary>
		/// 制剂序号
		/// </summary>
		public string MedNO 
		{
			get	
			{
				return  myMedID;
			}
			set	
			{ 
				myMedID = value; 
			}
		}


		/// <summary>
		/// 送货单
		/// </summary>
		public string DeliveryNO 
		{
			get	
			{
				return  myDeliveryNo;
			}
			set	
			{
				myDeliveryNo = value;
			}
		}

		
		/// <summary>
		/// 招标单序号
		/// </summary>
		public string TenderNO
		{
			get 
			{
				return this.myTenderNo;
			}
			set 
			{
				this.myTenderNo = value;
			}
		}
		
		
		/// <summary>
		/// 供货商结存标志 0 未付 1 未全付 2 付清
		/// </summary>
		public string PayState 
		{
			get 
			{
				return this.myPayState;
			}
			set 
			{
				this.myPayState = value;
			}
		}
		
		
		/// <summary>
		/// 现金标志
		/// </summary>
		public string CashFlag 
		{
			get 
			{
				return this.myCashFlag;
			}
			set 
			{
				this.myCashFlag = value;
			}
		}
		
		
		/// <summary>
		/// 实际扣率
		/// </summary>
		public decimal ActualRate 
		{
			get 
			{
				return this.myActualRate;
			}
			set 
			{
				this.myActualRate = value;
			}
		}

		
		/// <summary>
		/// 供货公司
		/// </summary>
		public new Neusoft.FrameWork.Models.NeuObject Company 
		{
			get	
			{
				return  this.TargetDept;
			}
			set	
			{
				this.TargetDept = value;
			}
		}

        /// <summary>
        /// 采购计划流水号
        /// </summary>
        public string StockNO
        {
            get
            {
                return this.myStockNO;
            }
            set
            {
                this.myStockNO = value;
            }
        }
        //{D28CC3CF-C502-4987-BC01-1AEBF2F9D17F} sel 增加下面两个属性
        /// <summary>
        /// 发票上的发票时间 
        /// </summary>
        public DateTime InvoiceDate
        {
            get
            {
                return this.invoiceDate;
            }
            set
            {
                this.invoiceDate=value;
            }
        }

        /// <summary>
        /// 一般入库时的购入价
        /// </summary>
        public decimal CommonPurchasePrice
        {
            get
            {
                return this.commonPurchasePrice;
            }
            set
            {
                this.commonPurchasePrice = value;
            }
        }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime InDate
        {
            get
            {
                return this.inDate;
            }
            set
            {
                this.inDate = value;
            }
        }

        /// <summary>
        /// 源科室（供货单位）类型  1 院内科室 2 供货单位 3 扩展
        /// </summary>
        public string SourceCompanyType
        {
            get
            {
                return this.sourceCompanyType;
            }
            set
            {
                this.sourceCompanyType = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new Input Clone()
		{
			Input obj = base.Clone() as Input;
			obj.Company = this.Company.Clone();
			return obj;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 入库单据号
		/// </summary>
		[System.Obsolete("程序整合 更改为InListNO属性",true)]
		public string InListCode 
		{
			get	{ return  myInListCode;}
			set	{  myInListCode = value; }
		}


		/// <summary>
		/// 出库单号
		/// </summary>
		[System.Obsolete("程序整合 更改为OutBillNO属性",true)]
		public string OutBillCode 
		{
			get	{ return  myOutBillCode;}
			set	{  myOutBillCode = value; }
		}


		/// <summary>
		/// 出库单内序号
		/// </summary>
		[System.Obsolete("程序整合 更改为OutSerialNO属性",true)]
		public int OutSerialNo 
		{
			get	{ return  myOutSerialNo;}
			set	{  myOutSerialNo = value; }
		}


		/// <summary>
		/// 出库单据号
		/// </summary>
		[System.Obsolete("程序整合 更改为OutListNO属性",true)]
		public string OutListCode 
		{
			get	{ return  myOutListCode;}
			set	{  myOutListCode = value; }
		}


		/// <summary>
		/// 制剂序号
		/// </summary>
		[System.Obsolete("程序整合 更改为MedNO属性",true)]
		public string MedID 
		{
			get	{ return  myMedID;}
			set	{  myMedID = value; }
		}


		/// <summary>
		/// 送货单
		/// </summary>
		[System.Obsolete("程序整合 更改为DeliveryNO属性",true)]
		public string DeliveryNo 
		{
			get	{ return  myDeliveryNo;}
			set	{  myDeliveryNo = value; }
		}

		
		/// <summary>
		/// 招标单序号
		/// </summary>
		[System.Obsolete("程序整合 更改为tenderNO属性",true)]
		public string TenderNo
		{
			get {return this.myTenderNo;}
			set {this.myTenderNo = value;}
		}
		

		/// <summary>
		/// 申请出库数量
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public decimal ApplyNum 
		{
			get	{ return  myApplyNum;}
			set	{  myApplyNum = value; }
		}


		/// <summary>
		/// 申请出库人编码
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public string ApplyOperCode 
		{
			get	{ return  myApplyOperCode;}
			set	{  myApplyOperCode = value; }
		}


		/// <summary>
		/// 申请出库日期
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public DateTime ApplyDate 
		{
			get	{ return  myApplyDate;}
			set	{  myApplyDate = value; }
		}


		/// <summary>
		/// 审批数量（摆药）
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public decimal ExamNum 
		{
			get	{ return  myExamNum;}
			set	{  myExamNum = value; }
		}


		/// <summary>
		/// 审批人编码（摆药）
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public string ExamOperCode 
		{
			get	{ return  myExamOperCode;}
			set	{  myExamOperCode = value; }
		}


		/// <summary>
		/// 审批日期（摆药）
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public DateTime ExamDate 
		{
			get	{ return  myExamDate;}
			set	{  myExamDate = value; }
		}


		/// <summary>
		/// 核准人编码
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public string ApproveOperCode 
		{
			get	{ return  myApproveOperCode;}
			set	{  myApproveOperCode = value; }
		}


		/// <summary>
		/// 核准日期
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public DateTime ApproveDate 
		{
			get	{ return  myApproveDate;}
			set	{  myApproveDate = value; }
		}


		/// <summary>
		/// 退库数量
		/// </summary>
		[System.Obsolete("程序整合 更改为由基类内Operation属性获取",true)]
		public decimal ReturnNum 
		{
			get	{ return  myReturnNum;}
			set	{  myReturnNum = value; }
		}



		#endregion
	}
}
