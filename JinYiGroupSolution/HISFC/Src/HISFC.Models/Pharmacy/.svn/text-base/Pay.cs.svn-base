using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 供货商付款实体]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	///  ID 付款序号
	/// </summary>
    [Serializable]
    public class Pay : Neusoft.FrameWork.Models.NeuObject
	{
		public Pay()
		{

		}


		#region 变量

		/// <summary>
		/// 发票号
		/// </summary>
		string invoiceNo = "";								
		
		/// <summary>
		/// 发票日期
		/// </summary>
		DateTime invoiceTime = System.DateTime.MinValue;	

		/// <summary>
		/// 零售金额
		/// </summary>
		decimal retailCost;									

		/// <summary>
		/// 批发金额
		/// </summary>
		decimal wholesaleCost;								

		/// <summary>
		/// 购入金额(发票金额)
		/// </summary>
		decimal purchaseCost;								

		/// <summary>
		/// 优惠金额
		/// </summary>
		decimal discountCost;								

		/// <summary>
		/// 运费
		/// </summary>
		decimal deliveryCost;	
		
		/// <summary>
		/// 同一发票内付款序号
		/// </summary>
		int sequenceNo;			
		
		/// <summary>
		/// 付款标志 0未付款  1已付款 2完成付款
		/// </summary>
		string payState;
		
		/// <summary>
		/// 付款类型 现金/支票
		/// </summary>
		string payType;										

		/// <summary>
		/// 付款金额
		/// </summary>
		decimal payCost;
		
		/// <summary>
		/// 未付金额
		/// </summary>
		decimal unPayCost;				
		
		/// <summary>
		/// 付款信息(人员 时间)
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment payOper = new Neusoft.HISFC.Models.Base.OperEnvironment();	

		/// <summary>
		/// 入库科室
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();		

		/// <summary>
		/// 供货单位
		/// </summary>
		Neusoft.HISFC.Models.Pharmacy.Company company = new Company();			
		
		/// <summary>
		/// 操作信息
		/// </summary>
		Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 扩展字段
		/// </summary>
		string extend;										

		/// <summary>
		/// 扩展字段2 
		/// </summary>
		string extend1;									

		/// <summary>
		/// 扩展字段2
		/// </summary>
		string extend2;									

		/// <summary>
		/// 扩展日期
		/// </summary>
		DateTime extendTime = System.DateTime.MinValue;		

		/// <summary>
		/// 扩展数量
		/// </summary>
		decimal extendQty;		
							
		#endregion

		/// <summary>
		/// 入库单据号
		/// </summary>
		public string InListNO
		{
			get
			{
				return this.inListCode;
			}
			set
			{
				this.inListCode = value;
			}
		}


		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNO
		{
			get
			{
				return this.invoiceNo;
			}
			set
			{
				this.invoiceNo = value;
			}
		}


		/// <summary>
		/// 发票日期
		/// </summary>
		public DateTime InvoiceTime
		{
			get
			{
				return this.invoiceTime;
			}
			set
			{
				this.invoiceTime = value;
			}
		}


		/// <summary>
		/// 零售金额
		/// </summary>
		public decimal RetailCost
		{
			get
			{
				return this.retailCost;
			}
			set
			{
				this.retailCost = value;
			}
		}


		/// <summary>
		/// 批发金额
		/// </summary>
		public decimal WholeSaleCost
		{
			get
			{
				return this.wholesaleCost;
			}
			set
			{
				this.wholesaleCost = value;
			}
		}


		/// <summary>
		/// 购入金额（发票金额）
		/// </summary>
		public decimal PurchaseCost
		{
			get
			{
				return this.purchaseCost;
			}
			set
			{
				this.purchaseCost = value;
			}
		}


		/// <summary>
		/// 优惠金额
		/// </summary>
		public decimal DisCountCost
		{
			get
			{
				return this.discountCost;
			}
			set
			{
				this.discountCost = value;
			}
		}


		/// <summary>
		/// 运费
		/// </summary>
		public decimal DeliveryCost
		{
			get
			{
				return this.deliveryCost;
			}
			set
			{
				this.deliveryCost = value;
			}
		}


		/// <summary>
		/// 同一发票内付款序号
		/// </summary>
		public int SequenceNO
		{
			get
			{
				return this.sequenceNo;
			}
			set
			{
				this.sequenceNo = value;
			}
		}


		/// <summary>
		/// 付款标志 0未付款  1已付款 2完成付款
		/// </summary>
		public string PayState
		{
			get
			{
				return this.payState;
			}
			set
			{
				this.payState = value;
			}
		}
	

		/// <summary>
		/// 付款类型 现金/支票
		/// </summary>
		public string PayType
		{
			get
			{
				return this.payType;
			}
			set
			{
				this.payType = value;
			}
		}


		/// <summary>
		/// 付款金额
		/// </summary>
		public decimal PayCost
		{
			get
			{
				return this.payCost;
			}
			set
			{
				this.payCost = value;
			}
		}


		/// <summary>
		/// 未付金额
		/// </summary>
		public decimal UnPayCost
		{
			get
			{
				return this.unPayCost;
			}
			set
			{
				this.unPayCost = value;
			}
		}


		/// <summary>
		/// 付款信息(付款人 付款时间)
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment PayOper
		{
			get
			{
				return this.payOper;
			}
			set
			{
				this.payOper = value;
			}
		}


		/// <summary>
		/// 入库科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept
		{
			get
			{
				return this.stockDept;
			}
			set
			{
				this.stockDept = value;
			}
		}
		

		/// <summary>
		/// 供货单位
		/// </summary>
		public Company Company
		{
			get
			{
				return this.company;
			}
			set
			{
				this.company = value;
			}
		}
		

		/// <summary>
		/// 操作人员信息
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
		/// 扩展字段
		/// </summary>
		public string Extend
		{
			get
			{
				return this.extend;
			}
			set
			{
				this.extend = value;
			}
		}


		/// <summary>
		/// 扩展字段1
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
		/// 扩展字段2
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
		/// 扩展日期
		/// </summary>
		public DateTime ExtendTime
		{
			get
			{
				return this.extendTime;
			}
			set
			{
				this.extendTime = value;
			}
		}


		/// <summary>
		/// 扩展数量
		/// </summary>
		public decimal ExtendQty
		{
			get
			{
				return this.extendQty;
			}
			set
			{
				this.extendQty = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例副本</returns>
		public new Pay Clone()
		{
			Pay pay = base.Clone() as Pay;

			pay.PayOper = this.PayOper.Clone();
			
			pay.StockDept = this.StockDept.Clone();

			pay.Company = this.Company.Clone();

			pay.Oper = this.Oper.Clone();

			return pay;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 入库单据号
		/// </summary>
		string inListCode = "";	
		
		/// <summary>
		/// 发票日期
		/// </summary>
		DateTime invoiceDate = System.DateTime.MinValue;	

		/// <summary>
		/// 付款标志 0未付款  1已付款 2完成付款
		/// </summary>
		string payFlag;					
		
		/// <summary>
		/// 付款日期
		/// </summary>
		DateTime payDate = System.DateTime.MinValue;	
		
		/// <summary>
		/// 付款人
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject payer = new Neusoft.FrameWork.Models.NeuObject();	
	
		/// <summary>
		/// 入库科室
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject drugDept = new Neusoft.FrameWork.Models.NeuObject();		//入库科室

		/// <summary>
		/// 操作员
		/// </summary>
		string operCode;				
					
		/// <summary>
		/// 操作日期
		/// </summary>
		DateTime operDate;									//操作日期

		/// <summary>
		/// 扩展字段
		/// </summary>
		string extCode;										

		/// <summary>
		/// 扩展字段1 
		/// </summary>
		string extCode1;									

		/// <summary>
		/// 扩展字段2
		/// </summary>
		string extCode2;									

		/// <summary>
		/// 扩展日期
		/// </summary>
		DateTime extDate = System.DateTime.MinValue;		

		/// <summary>
		/// 扩展数量
		/// </summary>
		decimal extNumber;									

		/// <summary>
		/// 入库单据号
		/// </summary>
		[System.Obsolete("程序重构 更改为InListNO属性",true)]
		public string InListCode
		{
			get
			{
				return this.inListCode;
			}
			set
			{
				this.inListCode = value;
			}
		}


		/// <summary>
		/// 发票号
		/// </summary>
		[System.Obsolete("程序重构 更改为InvoiceNO属性",true)]
		public string InvoiceNo
		{
			get
			{
				return this.invoiceNo;
			}
			set
			{
				this.invoiceNo = value;
			}
		}


		/// <summary>
		/// 发票日期
		/// </summary>
		[System.Obsolete("程序重构 更改为InvoiceTime属性",true)]
		public DateTime InvoiceDate
		{
			get
			{
				return this.invoiceDate;
			}
			set
			{
				this.invoiceDate = value;
			}
		}


		/// <summary>
		/// 同一发票内付款序号
		/// </summary>
		[System.Obsolete("程序重构 更改为SequenceNO属性",true)]
		public int SequenceNo
		{
			get
			{
				return this.sequenceNo;
			}
			set
			{
				this.sequenceNo = value;
			}
		}


		/// <summary>
		/// 付款标志 0未付款  1已付款 2完成付款
		/// </summary>
		[System.Obsolete("程序重构 更改为PayState属性",true)]
		public string PayFlag
		{
			get
			{
				return this.payFlag;
			}
			set
			{
				this.payFlag = value;
			}
		}

		
		/// <summary>
		/// 付款日期
		/// </summary>
		[System.Obsolete("程序重构 更改为PayOper属性",true)]
		public DateTime PayDate
		{
			get
			{
				return this.payDate;
			}
			set
			{
				this.payDate = value;
			}
		}


		/// <summary>
		/// 付款人
		/// </summary>
		[System.Obsolete("程序重构 更改为PayOper属性",true)]
		public Neusoft.FrameWork.Models.NeuObject Payer
		{
			get
			{
				return this.payer;
			}
			set
			{
				this.payer = value;
			}
		}


		/// <summary>
		/// 入库科室
		/// </summary>
		[System.Obsolete("程序重构 更改为StockDept属性",true)]
		public Neusoft.FrameWork.Models.NeuObject DrugDept
		{
			get
			{
				return this.drugDept;
			}
			set
			{
				this.drugDept = value;
			}
		}


		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public string OperCode
		{
			get
			{
				return this.operCode;
			}
			set
			{
				this.operCode = value;
			}
		}


		/// <summary>
		/// 操作日期
		/// </summary>
		[System.Obsolete("程序重构 更改为Oper属性",true)]
		public DateTime OperDate
		{
			get
			{
				return this.operDate;
			}
			set
			{
				this.operDate = value;
			}
		}


		/// <summary>
		/// 扩展字段
		/// </summary>
		[System.Obsolete("程序重构 更改为Extend属性",true)]
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
		/// 扩展字段1
		/// </summary>
		[System.Obsolete("程序重构 更改为Extend1属性",true)]
		public string ExtCode1
		{
			get
			{
				return this.extCode1;
			}
			set
			{
				this.extCode1 = value;
			}
		}

		
		/// <summary>
		/// 扩展字段2
		/// </summary>
		[System.Obsolete("程序重构 更改为Extend2属性",true)]
		public string ExtCode2
		{
			get
			{
				return this.extCode2;
			}
			set
			{
				this.extCode2 = value;
			}
		}


		/// <summary>
		/// 扩展日期
		/// </summary>
		[System.Obsolete("程序重构 更改为ExtendTime属性",true)]
		public DateTime ExtDate
		{
			get
			{
				return this.extDate;
			}
			set
			{
				this.extDate = value;
			}
		}

		/// <summary>
		/// 扩展数量
		/// </summary>
		[System.Obsolete("程序重构 更改为ExtendQty属性",true)]
		public decimal ExtNumber
		{
			get
			{
				return this.extNumber;
			}
			set
			{
				this.extNumber = value;
			}
		}

		#endregion
	}
}
