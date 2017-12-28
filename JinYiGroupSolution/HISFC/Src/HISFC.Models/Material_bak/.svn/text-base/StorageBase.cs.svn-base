using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// StoreBase 的摘要说明。
	/// 药库库存基本信息（药品入库、出库、库存继承于本实体）
	/// ID     出,入库,盘点,调价单据号BillCode
	/// writed by cuipeng 
	/// 2004-12
	/// </summary>
	public class StorageBase : Neusoft.NFC.Object.NeuObject
	{
		#region  Internal member variables		
		private int      mySerialNo;
		private string   myPrivType = "";
		private string   mySystemType = "";
		private Neusoft.NFC.Object.NeuObject myDept = new Neusoft.NFC.Object.NeuObject();
		private Neusoft.NFC.Object.NeuObject myTargetDept = new Neusoft.NFC.Object.NeuObject();
		private MaterialItem myItem = new MaterialItem();
		private int      myGroupNo;
		private string   myBatchNo = "";
		private DateTime myValidDate;
		private Neusoft.NFC.Object.NeuObject myProducer = new Neusoft.NFC.Object.NeuObject();
		private Neusoft.NFC.Object.NeuObject myCompany = new Neusoft.NFC.Object.NeuObject();
		private decimal  myQuantity;
		private decimal  myRetailCost;
		private decimal  myWholesaleCost;
		private decimal  myPurchaseCost;
		private string   myPlaceCode = "";
		private decimal  myStoreNum;
		private decimal  myStoreCost;
		private string   myState = "";
		private string   myShowFlag = "0";
		private string   myShowUnit = "";
		private string   myOperCode = "";
		private DateTime myOperDate;
		private string   myInvoiceNo;
		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public StorageBase()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 单内序号
		/// </summary>
		public int SerialNo 
		{
			get	{ return  mySerialNo;}
			set	{  mySerialNo = value; }
		}


		/// <summary>
		/// 权限类型
		/// </summary>
		public string PrivType 
		{
			get	{ return  myPrivType;}
			set	{  myPrivType = value; }
		}


		/// <summary>
		/// 系统类型
		/// </summary>
		public string SystemType 
		{
			get	{ return  mySystemType;}
			set	{  mySystemType = value; }
		}


		/// <summary>
		/// 部门
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Dept 
		{
			get	{ return  myDept;}
			set	{  myDept = value; }
		}


		/// <summary>
		/// 目标部门
		/// </summary>
		public Neusoft.NFC.Object.NeuObject TargetDept 
		{
			get	{ return  myTargetDept;}
			set	{  myTargetDept = value; }
		}


		/// <summary>
		/// 药品实体
		/// </summary>
		public MaterialItem Item 
		{
			get	{ return  myItem;}
			set	{  myItem = value; }
		}


		/// <summary>
		/// 库存批次
		/// </summary>
		public int GroupNo
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
		public Neusoft.NFC.Object.NeuObject Producer 
		{
			get	{ return  myProducer;}
			set	{  myProducer = value; }
		}


		/// <summary>
		/// 供货公司
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Company 
		{
			get	{ return  myCompany;}
			set	{  myCompany = value; }
		}


		/// <summary>
		/// 数量
		/// </summary>
		public decimal Quantity 
		{
			get	{ return myQuantity; }
			set	{ myQuantity = value; }
		}


		/// <summary>
		/// 零售金额
		/// 只读
		/// </summary>
		public decimal RetailCost 
		{
			get	{ return myRetailCost; }
			set { myRetailCost = value; }
		}


		/// <summary>
		/// 批发金额
		/// 只读
		/// </summary>
		public decimal WholesaleCost 
		{
			get	{ return myWholesaleCost; }
			set { myWholesaleCost = value; }
		}


		/// <summary>
		/// 够入金额
		/// 只读
		/// </summary>
		public decimal PurchaseCost 
		{
			get	{ return myPurchaseCost; }
			set { myPurchaseCost = value; }
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
		/// 同种药品库存数量合计
		/// </summary>
		public decimal StoreNum 
		{
			get	{ return  myStoreNum;}
			set	{  myStoreNum = value; }
		}


		/// <summary>
		/// 同种药品库存金额合计，此处没有用数量×单价，因为库存汇总表中的金额是多个批次药品的总金额。
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
		public string ShowState
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


		/// <summary>
		/// 操作员编码
		/// </summary>
		public string OperCode 
		{
			get	{ return  myOperCode;}
			set	{  myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate 
		{
			get	{ return  myOperDate;}
			set	{  myOperDate = value; }
		}


		
		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNo 
		{
			get	{ return  myInvoiceNo;}
			set	{  myInvoiceNo = value; }
		}
	}
}
