using System;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 药品管理申请信息类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自StorageBase基类'
	///  />
	///  ID 调价单流水号
	/// </summary>
    [Serializable]
    public class AdjustPrice : StorageBase 
	{

		public AdjustPrice () 
		{
			this.PrivType = "0304";	//调价权限编码

            this.Class2Type = "0304";
		}


		#region 变量

		private System.String myFileNo ;	

		private System.Decimal myAfterRetailPrice ;

		private System.Decimal myAfterWholesalePrice ;

        private System.Decimal myAfterPurchasePrice;//{82D5CEE7-A876-4582-ADC6-3545A7173467}

		private System.String myProfitFlag ;

		private System.DateTime myInureTime ;

		private System.String myOperName;

        /// <summary>
        /// 是否药库单科调价
        /// </summary>
        private bool isDDAdjust = false;

        /// <summary>
        /// 是否药房单科调价
        /// </summary>
        private bool isDSAdjust = false;

		#endregion

		/// <summary>
		/// 调价依据号
		/// </summary>
		public string FileNO
		{
			get	
			{
				return  myFileNo;
			}
			set	
			{  
				myFileNo = value;
			}
		}

		/// <summary>
		/// 调价后零售价
		/// </summary>
		public Decimal AfterRetailPrice 
		{
			get	{
				return  myAfterRetailPrice;
			}
			set	{
				myAfterRetailPrice = value; 
			}
		}

		/// <summary>
		/// 调价后批发价
		/// </summary>
		public Decimal AfterWholesalePrice 
		{
			get	
			{
				return  myAfterWholesalePrice;
			}
			set	
			{
				myAfterWholesalePrice = value;
			}
		}

        /// <summary>
        /// 调后购入价{82D5CEE7-A876-4582-ADC6-3545A7173467}
        /// </summary>
        public System.Decimal AfterPurchasePrice
        {
            get { return myAfterPurchasePrice; }
            set { myAfterPurchasePrice = value; }
        }

		/// <summary>
		/// 盈亏标记1-盈，0-亏
		/// </summary>
		public string ProfitFlag 
		{
			get	
			{
				return  myProfitFlag;
			}
			set	
			{
				myProfitFlag = value; 
			}
		}

		/// <summary>
		/// 调价生效时间
		/// </summary>
		public DateTime InureTime 
		{
			get	
			{
				return  myInureTime;
			}
			set	
			{
				myInureTime = value; 
			}
		}

        /// <summary>
        /// 是否药库单科调价
        /// </summary>
        public bool IsDDAdjust
        {
            get
            {
                return this.isDDAdjust;
            }
            set            
            {
                this.isDDAdjust = value;
            }
        }

        /// <summary>
        /// 是否药房单科调价
        /// </summary>
        public bool IsDSAdjust
        {
            get
            {
                return this.isDSAdjust;
            }
            set
            {
                this.isDSAdjust = value;
            }
        }

		#region 无效属性
		
		/// <summary>
		/// 操作人姓名
		/// </summary>
		[System.Obsolete("程序整合 更改为基类的Operation属性",true)]
		public string OperName 
		{
			get	{ return  myOperName;}
			set	{  myOperName = value; }
		}


		/// <summary>
		/// 调价依据号
		/// </summary>
		[System.Obsolete("程序重构 更改为FileNO属性",true)]
		public string FileNo 
		{
			get	
			{
				return  myFileNo;
			}
			set	{  myFileNo = value; }
		}


		#endregion
	}
}
