using System;

namespace neusoft.HISFC.Object.Pharmacy
{
	/// <summary>
	/// StoreBase 的摘要说明。
	/// </summary>
	public class StoreBase : neusoft.neuFC.Object.neuObject
	{
		// Internal member variables
		private neusoft.neuFC.Object.neuObject myDept = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myTargetDept = new neusoft.neuFC.Object.neuObject();
		private Item myItem = new Item();
		private string  myGroupNo;
		private string  myBatchNo;
		private DateTime myValidDate;
		private neusoft.neuFC.Object.neuObject myProducer = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myCompany = new neusoft.neuFC.Object.neuObject();
		private decimal myRetailPrice;
		private decimal myWholesalePrice;
		private decimal myPurchasePrice;
		private decimal myQuantity;
		private string  myPlaceCode;
		private decimal myStoreNum;
		private decimal myStoreCost;
		private string  myState;
		private string  myShowFlag;
		private string  myShowUnit;


		public StoreBase()
		{
		    //
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 部门
		/// </summary>
		public neusoft.neuFC.Object.neuObject Dept 
		{
			get	{ return  myDept;}
			set	{  myDept = value; }
		}

		/// <summary>
		/// 目标部门
		/// </summary>
		public neusoft.neuFC.Object.neuObject TargetDept 
		{
			get	{ return  myTargetDept;}
			set	{  myTargetDept = value; }
		}

		/// <summary>
		/// 药品实体
		/// </summary>
		public Item Item 
		{
			get	{ return  myItem;}
			set	{  myItem = value; }
		}

		/// <summary>
		/// 库存批次
		/// </summary>
		public string GroupNo
		{
			get	{ return  myGroupNo;}
			set	{  myGroupNo = value; }
		}

		/// <summary>
		/// 批号
		/// </summary>
		public string BatchNo 
		{
			get	{ return  myBatchNo;}
			set	{  myBatchNo = value; }
		}

		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidDate 
		{
			get	{ return  myValidDate;}
			set	{  myValidDate = value; }
		}

		/// <summary>
		/// 生成厂家
		/// </summary>
		public neusoft.neuFC.Object.neuObject Producer 
		{
			get	{ return  myProducer;}
			set	{  myProducer = value; }
		}

		/// <summary>
		/// 供货公司
		/// </summary>
		public neusoft.neuFC.Object.neuObject Company 
		{
			get	{ return  myCompany;}
			set	{  myCompany = value; }
		}

		/// <summary>
		/// 零售价
		/// </summary>
		public string RetailPrice 
		{
			get	{ return myRetailPrice; }
			set	{ myRetailPrice = value; }
		}

		/// <summary>
		/// 批发价
		/// </summary>
		public string WholesalePrice {
			get	{ return myWholesalePrice; }
			set	{ myWholesalePrice = value; }
		}

		/// <summary>
		/// 购入价
		/// </summary>
		public string PurchasePrice	
		{
			get	{ return myPurchasePrice; }
			set	{ myPurchasePrice = value; }
		}

		/// <summary>
		/// 数量
		/// </summary>
		public string Quantity {
			get	{ return myQuantity; }
			set	{ myQuantity = value; }
		}

		/// <summary>
		/// 零售金额
		/// </summary>
		public string RetailCost {
			get	{ return myRetailPrice * myQuantity; }
		}


		/// <summary>
		/// 批发金额
		/// </summary>
		public string WholesaleCost {
			get	{ return myWholesalePrice * myQuantity; }
		}
		/// <summary>
		/// 够入金额
		/// </summary>
		public string PurchaseCost {
			get	{ return myPurchasePrice * myQuantity; }
		}


		/// <summary>
		/// 货位号
		/// </summary>
		public string PlaceCode 
		{
			get	{ return  myPlaceCode;}
			set	{  myPlaceCode = value; }
		}

		/// <summary>
		/// 库存数量
		/// </summary>
		public decimal StoreNum 
		{
			get	{ return  myStoreNum;}
			set	{  myStoreNum = value; }
		}

		/// <summary>
		/// 库存金额
		/// </summary>
		public decimal StoreCost 
		{
			get	{ return  myStoreCost;}
			set	{  myStoreCost = value; }
		}

		/// <summary>
		/// 状态
		/// </summary>
		public string State 
		{
			get	{ return  myState;}
			set	{  myState = value; }
		}

		/// <summary>
		/// 显示单位标记（1包装单位，0最小单位）
		/// </summary>
		public string ShowFlag 
		{
			get	{ return  myShowFlag;}
			set	{  myShowFlag = value; }
		}

		/// <summary>
		/// 显示单位
		/// </summary>
		public string ShowUnit 
		{
			get	{ return  myShowUnit;}
			set	{  myShowUnit = value; }
		}
	}
}
