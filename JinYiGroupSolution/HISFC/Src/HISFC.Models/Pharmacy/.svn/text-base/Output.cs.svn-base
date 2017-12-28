using System;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 药品管理出库信息类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自StorageBase基类'
	///  />
	///  ID 出库单流水号
	/// </summary>
    [Serializable]
    public class Output : StorageBase 
	{
		public Output () 
		{
            //此处应该存储用户自定义的出库类型 而不应该存储0320
            //this.PrivType = "0320";	//出库权限编码

            this.Class2Type = "0320";
		}

		#region 变量

		private string   myOutListCode;

		private string   myInBillCode = "0";

		private int      myInSerialNo;

		private string   myInListCode;

		private decimal  myApplyNum;

		private string   myApplyOperCode;

		private DateTime myApplyDate;

		private decimal  myExamNum;

		private string   myExamOperCode;

		private DateTime myExamDate;

		private string   myApproveOperCode;

		private DateTime myApproveDate;

		private decimal  myReturnNum;

		private string   myDrugedBillCode;

		private string   myMedID;

		private string   myRecipeNo;

		private int      mySequenceNo;

		private string   myGetPerson;

        /// <summary>
        /// 药柜扣库流水号
        /// </summary>
        private string myChestOutNO;

        /// <summary>
        /// 出库时间   {F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}
        /// </summary>
        private DateTime outDate;
		#endregion

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
		/// 入库单号
		/// </summary>
		public string InBillNO 
		{
			get	
			{
				return  myInBillCode;
			}
			set	
			{
				myInBillCode = value;
			}
		}

		/// <summary>
		/// 入库单内序号
		/// </summary>
		public int InSerialNO 
		{
			get	
			{
				return  myInSerialNo;
			}
			set	
			{
				myInSerialNo = value; 
			}
		}

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
		/// 摆药单号
		/// </summary>
		public string DrugedBillNO 
		{
			get	
			{
				return  myDrugedBillCode;
			}
			set	
			{
				myDrugedBillCode = value; 
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
		/// 处方号
		/// </summary>
		public string RecipeNO 
		{
			get	
			{
				return  myRecipeNo;
			}
			set	
			{
				myRecipeNo = value; 
			}
		}

		/// <summary>
		/// 处方内序号
		/// </summary>
		public int SequenceNO 
		{
			get	
			{
				return  mySequenceNo;
			}
			set	
			{
				mySequenceNo = value;
			}
		}

		/// <summary>
		/// 取药人（或者门诊卡号、住院流水号）
		/// </summary>
		public string GetPerson 
		{
			get	
			{
				return  myGetPerson;
			}
			set	
			{
				myGetPerson = value; 
			}
		}

        /// <summary>
        /// 药柜扣库流水号
        /// </summary>
        public string ArkOutNO
        {
            get
            {
                return this.myChestOutNO;
            }
            set
            {
                this.myChestOutNO = value;
            }
        }

        /// <summary>
        /// 出库时间  {F46D26C1-FBA7-44bc-9323-BEC9CD2115F9}
        /// </summary>
        public DateTime OutDate
        {
            get
            {
                return this.outDate;
            }
            set
            {
                this.outDate = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new Output Clone()
		{
			return base.Clone() as Output;
		}


		#endregion

		#region 无效属性

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
		/// 入库单号
		/// </summary>
		[System.Obsolete("程序整合 更改为InBillNo属性",true)]
		public string InBillCode 
		{
			get	{ return  myInBillCode;}
			set	{  myInBillCode = value; }
		}


		/// <summary>
		/// 入库单内序号
		/// </summary>
		[System.Obsolete("程序整合 更改为InSerialNO属性",true)]
		public int InSerialNo 
		{
			get	{ return  myInSerialNo;}
			set	{  myInSerialNo = value; }
		}


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
		/// 摆药单号
		/// </summary>
		[System.Obsolete("程序整合 更改为DrugBillNO属性",true)]
		public string DrugedBillCode 
		{
			get	{ return  myDrugedBillCode;}
			set	{  myDrugedBillCode = value; }
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
		/// 处方号
		/// </summary>
		[System.Obsolete("程序整合 更改为RecipeNO属性",true)]
		public string RecipeNo 
		{
			get	{ return  myRecipeNo;}
			set	{  myRecipeNo = value; }
		}


		/// <summary>
		/// 处方内序号
		/// </summary>
		[System.Obsolete("程序整合 更改为SequenceNO属性",true)]
		public int SequenceNo 
		{
			get	{ return  mySequenceNo;}
			set	{  mySequenceNo = value; }
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
