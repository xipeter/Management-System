using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品库存管理基类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自IMAStoreBase基类'
	///  />
	///  ID 申请序号
	/// </summary>
    [Serializable]
    public class StorageBase : Neusoft.HISFC.Models.IMA.IMAStoreBase
	{
		#region  变量

		private int mySerialNo;

		private Neusoft.FrameWork.Models.NeuObject myDept = new Neusoft.FrameWork.Models.NeuObject();

		private Neusoft.FrameWork.Models.NeuObject myTargetDept = new Neusoft.FrameWork.Models.NeuObject();

		private Item myItem = new Item();

		private decimal myGroupNo;

		private string myBatchNo = "";

		private DateTime myValidDate;

		private Neusoft.FrameWork.Models.NeuObject myProducer = new Neusoft.FrameWork.Models.NeuObject();

		private Neusoft.FrameWork.Models.NeuObject myCompany = new Neusoft.FrameWork.Models.NeuObject();

		private string myPlaceCode = "";

		private decimal myStoreNum;

		private string myShowFlag = "0";

		private string myShowUnit = "";

		private string myOperCode = "";

		private DateTime myOperDate;

		private string myInvoiceNo;

        private string myInvoiceType;

        /// <summary>
        /// 是否药柜管理
        /// </summary>
        private bool isChestManager;

        /// <summary>
        /// 药柜管理库存量
        /// </summary>
        private decimal chestQty;

		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public StorageBase()
		{
			
		}

		/// <summary>
		/// 药品实体
		/// </summary>
		public Item Item 
		{
			get	
			{ 
				return  myItem;
			}
			set	
			{
				myItem = value; 
				base.IMAItem = value;
                base.PriceCollection = value.PriceCollection;
			}
		}

		/// <summary>
		/// 库存批次
		/// </summary>
		public decimal GroupNO
		{
			get	
			{ 
				return  myGroupNo;
			}
			set	
			{  
				myGroupNo = value; 
			}
		}

		/// <summary>
		/// 批号
		/// </summary>
		public string BatchNO 
		{
			get	
			{
				return  myBatchNo;
			}
			set	
			{
				myBatchNo = value;
			}
		}

		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidTime
		{
			get	
			{
				return  myValidDate;
			}
			set	
			{
				myValidDate = value; 
			}
		}

		/// <summary>
		/// 显示单位标记（1包装单位，0最小单位）
		/// </summary>
		public string ShowState
		{
			get	
			{
				return  myShowFlag;
			}
			set	
			{
				myShowFlag = value; 
			}
		}

		/// <summary>
		/// 显示单位
		/// </summary>
		public string ShowUnit 
		{
			get	
			{
				return  myShowUnit;
			}
			set	
			{
				myShowUnit = value; 
			}
		}

		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNO 
		{
			get	
			{
				return  myInvoiceNo;
			}
			set	
			{  
				myInvoiceNo = value;
			}
		}

        /// <summary>
        /// 发票类别
        /// </summary>
        public string InvoiceType
        {
            get
            {
                return this.myInvoiceType;
            }
            set
            {
                this.myInvoiceType = value;
            }
        }

        /// <summary>
        /// 是否药柜管理
        /// </summary>
        public bool IsArkManager
        {
            get
            {
                return isChestManager;
            }
            set
            {
                isChestManager = value;
            }
        }

        /// <summary>
        /// 药柜管理库存量
        /// </summary>
        public decimal ArkQty
        {
            get
            {
                return chestQty;
            }
            set
            {
                chestQty = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new StorageBase Clone()
		{
			StorageBase storageBase = base.Clone() as StorageBase;

			storageBase.Item = this.Item.Clone();

			return storageBase;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 货位号
		/// </summary>
		[System.Obsolete("程序整合 更改为PlaceNO属性",true)]
		public string PlaceCode 
		{
			get	{ return  myPlaceCode;}
			set	{  myPlaceCode = value; }
		}


		/// <summary>
		/// 有效期
		/// </summary>
		[System.Obsolete("程序整合 更改为ValidTime属性",true)]
		public DateTime ValidDate 
		{
			get	{ return  myValidDate;}
			set	{  myValidDate = value; }
		}


		/// <summary>
		/// 库存批次
		/// </summary>
		[System.Obsolete("程序整合 更改为GroupNO属性")]
		public decimal GroupNo
		{
			get	{ return  myGroupNo;}
			set	{  myGroupNo = value; }
		}


		/// <summary>
		/// 批号
		/// </summary>
		[System.Obsolete("程序整合 更改为BatchNO属性")]
		public string BatchNo 
		{
			get	{ return  myBatchNo;}
			set	{  myBatchNo = value; }
		}


		/// <summary>
		/// 部门
		/// </summary>
		[System.Obsolete("程序整合 更改为StockDept属性")]
		public Neusoft.FrameWork.Models.NeuObject Dept 
		{
			get	{ return  myDept;}
			set	{  myDept = value; }
		}


		/// <summary>
		/// 操作员编码
		/// </summary>
		[System.Obsolete("程序整合 更改为基类内的Opertation属性",true)]
		public string OperCode {
			get	{ return  myOperCode;}
			set	{  myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[System.Obsolete("程序整合 更改为基类内的Opertation属性",true)]
		public DateTime OperDate {
			get	{ return  myOperDate;}
			set	{  myOperDate = value; }
		}

		
		/// <summary>
		/// 单内序号
		/// </summary>
		[System.Obsolete("程序整合 更改为SerialNO属性",true)]
		public int SerialNo 
		{
			get	{ return  mySerialNo;}
			set	{  mySerialNo = value; }
		}


		/// <summary>
		/// 发票号
		/// </summary>
		[System.Obsolete("程序整合 更改为InvoiceNO属性",true)]
		public string InvoiceNo 
		{
			get	{ return  myInvoiceNo;}
			set	{  myInvoiceNo = value; }
		}


		/// <summary>
		/// 同种药品库存数量合计
		/// </summary>
		[System.Obsolete("程序整合 更改为StoreQty属性",true)]
		public decimal StoreNum 
		{
			get	{ return  myStoreNum;}
			set	{  myStoreNum = value; }
		}


		#endregion
	}
}
