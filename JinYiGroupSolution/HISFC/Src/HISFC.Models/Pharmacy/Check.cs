using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品盘点类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自StorageBase基类'
	///  />
	///  ID			盘点流水号
	///  GroupNO	批次
	///  State		盘点状态:0封帐,1结存,2取消
	/// </summary>
    [Serializable]
    public class Check : StorageBase
	{
		public Check()
		{
			this.PrivType = "0306";	//盘点结存权限编码

            this.Class2Type = "0306";
		}


		#region 变量

		private string myCheckCode;		//盘点单号
        private string myCheckName;     //盘点单名称
		private decimal	myFStoreNum;	//封帐数量
		private decimal myAdjustNum;	//盘点数量
		private decimal myCStoreNum;	//结存数量
		private decimal myMinNum;		//最小数量
		private	decimal myPackNum;		//包装数量
		private decimal myProfitLossNum;//盈亏数量
		private string myProfitStatic;	//盈亏标记 0 盘亏  1 盘盈 2 无盈亏
		private string myQualityFlag;	//质量标记 0 好	   1 不好
		private bool isAdd;			//附加药品标记  0 不附加  1 附加
		private string myDisposeWay;	//处理方式
		private string myCheckState;	//盘点状态:0封帐,1结存,2取消

		/// <summary>
		/// 封帐操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment fOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 结存操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment cOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		#endregion
		
		/// <summary>
		/// 盘点单号
		/// </summary>
		public string CheckNO
		{
			get 
			{
				return myCheckCode;
			}
			set 
			{
				myCheckCode = value;
			}
		}

        /// <summary>
        ///  盘点单名称
        /// </summary>
        public string CheckName
        {
            get
            {
                return myCheckName;
            }
            set
            {
                myCheckName = value;
                base.Name = value;
            }
        }


		/// <summary>
		/// 封帐数量
		/// </summary>
		public decimal FStoreQty
		{
			get 
			{
				return myFStoreNum;
			}
			set 
			{
				myFStoreNum = value;
			}
		}


		/// <summary>
		/// 盘点数量
		/// </summary>
		public decimal AdjustQty 
		{
			get 
			{
				return myAdjustNum;
			}
			set 
			{
				myAdjustNum = value;
			}
		}


		/// <summary>
		/// 结存数量
		/// </summary>
		public decimal CStoreQty
		{
			get 
			{
				return myCStoreNum;
			}
			set 
			{
				myCStoreNum = value;
			}
		}


		/// <summary>
		/// 最小数量
		/// </summary>
		public decimal MinQty
		{
			get 
			{
				return myMinNum;
			}
			set 
			{
				myMinNum = value;
			}
		}


		/// <summary>
		/// 包装数量
		/// </summary>
		public decimal PackQty 
		{
			get 
			{
				return myPackNum;
			}
			set 
			{
				myPackNum = value;
			}
		}


		/// <summary>
		/// 盈亏金额
		/// </summary>
		public decimal ProfitLossQty
		{
			get 
			{
				return myProfitLossNum;
			}
			set 
			{
				myProfitLossNum = value;
			}
		}


		/// <summary>
		/// 盈亏标记 0 盘亏 1 盘盈 2 无盈亏
		/// </summary>
		public string ProfitStatic
		{
			get 
			{
				return myProfitStatic;
			}
			set 
			{
				myProfitStatic = value;
			}
		}


		/// <summary>
		/// 质量标记
		/// </summary>
		public string QualityFlag
		{
			get 
			{
				return myQualityFlag;
			}
			set 
			{
				myQualityFlag = value;
			}
		}


		/// <summary>
		/// 是否附加药品
		/// </summary>
		public bool IsAdd
		{
			get 
			{
				return isAdd;
			}
			set 
			{
				isAdd = value;
			}
		}


		/// <summary>
		/// 处理方式
		/// </summary>
		public string DisposeWay
		{
			get 
			{
				return myDisposeWay;
			}
			set 
			{
				myDisposeWay = value;
			}
		}


		/// <summary>
		/// 封帐操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment FOper
		{
			get
			{
				return this.fOper;
			}
			set
			{
				this.fOper = value;
			}
		}


		/// <summary>
		/// 结存操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment COper
		{
			get
			{
				return this.cOper;
			}
			set
			{
				this.cOper = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new Check Clone()
		{
			Check check = base.Clone() as Check;

			check.FOper = this.FOper.Clone();
			check.COper = this.COper.Clone();

			return check;
		}


		#endregion

		#region 无效属性

		
		private string myFOperCode;		//封帐人
		private DateTime myFOperDate;	//封帐时间
		private string myCOperCode;		//结存人
		private DateTime myCOperDate;	//结存时间

		/// <summary>
		/// 盘点单号
		/// </summary>
		[System.Obsolete("程序整合 更改为CheckNO属性",true)]
		public string CheckCode 
		{
			get {return myCheckCode;}
			set {myCheckCode = value;}
		}


		/// <summary>
		/// 盘点状态:0封帐,1结存,2取消
		/// </summary>
		[System.Obsolete("程序整合 更改为基类内的State属性",true)]
		public string CheckState 
		{
			get {return myCheckState;}
			set {myCheckState = value;}
		}


		/// <summary>
		/// 封帐数量
		/// </summary>
		[System.Obsolete("程序整合 更改为FStoreQty属性",true)]
		public decimal FStoreNum
		{
			get {return myFStoreNum;}
			set {myFStoreNum = value;}
		}


		/// <summary>
		/// 盘点数量
		/// </summary>
		[System.Obsolete("程序整合 更改为AdjustQty属性",true)]
		public decimal AdjustNum 
		{
			get {return myAdjustNum;}
			set {myAdjustNum = value;}
		}


		/// <summary>
		/// 结存数量
		/// </summary>
		[System.Obsolete("程序整合 更改为CStoreQty属性",true)]
		public decimal CStoreNum
		{
			get {return myCStoreNum;}
			set {myCStoreNum = value;}
		}


		/// <summary>
		/// 最小数量
		/// </summary>
		[System.Obsolete("程序整合 更改为MinQty属性",true)]
		public decimal MinNum
		{
			get {return myMinNum;}
			set {myMinNum = value;}
		}


		/// <summary>
		/// 包装数量
		/// </summary>
		[System.Obsolete("程序整合 更改为PackQty属性",true)]
		public decimal PackNum 
		{
			get {return myPackNum;}
			set {myPackNum = value;}
		}


		/// <summary>
		/// 盈亏金额
		/// </summary>
		[System.Obsolete("程序整合 更改为ProfitLossQty属性",true)]
		public decimal ProfitLossNum
		{
			get {return myProfitLossNum;}
			set {myProfitLossNum = value;}
		}


		/// <summary>
		/// 封帐人
		/// </summary>
		[System.Obsolete("程序整合 更改为FOper属性",true)]
		public string FOperCode
		{
			get {return myFOperCode;}
			set {myFOperCode = value;}
		}


		/// <summary>
		/// 封帐时间
		/// </summary>
		[System.Obsolete("程序整合 更改为FOper属性",true)]
		public DateTime FOperDate
		{
			get {return myFOperDate;}
			set {myFOperDate = value;}
		}


		/// <summary>
		/// 结存人(解封人)
		/// </summary>
		[System.Obsolete("程序整合 更改COper属性",true)]
		public string COperCode
		{
			get {return myCOperCode;}
			set {myCOperCode = value;}
		}


		/// <summary>
		/// 结存时间(解封时间)
		/// </summary>
		[System.Obsolete("程序整合 更改COper属性",true)]
		public DateTime COperDate
		{
			get {return myCOperDate;}
			set {myCOperDate = value;}
		}


		#endregion
	}
}
