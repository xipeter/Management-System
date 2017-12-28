using System;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 药品管理申请信息类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 继承自ApplyBase基类'
	///  />
	///  ID 申请序号
	/// </summary>
    [Serializable]
    public class ApplyOut : Neusoft.HISFC.Models.IMA.IMAApplyBase
	{
		public ApplyOut ()
		{
			
		}

		#region 变量

		/// <summary>
		/// 药品实体
		/// </summary>
		private Neusoft.HISFC.Models.Pharmacy.Item item = new Item();

		/// <summary>
		/// 付数 草药
		/// </summary>
		private decimal days;

		/// <summary>
		/// 单位显示状态 1 包装单位 0 最小单位
		/// </summary>
		private string showState;

		/// <summary>
		/// 显示单位
		/// </summary>
		private string showUnit;

		/// <summary>
		/// 批次
		/// </summary>
		private decimal myGroupNo;

		/// <summary>
		/// 批号
		/// </summary>
		private string myBatchNo = "";

		/// <summary>
		/// 摆药单号
		/// </summary>
		private string drugNO;

		/// <summary>
		/// 预扣库存状态
		/// </summary>
		private bool isPreOut;

		/// <summary>
		/// 收费状态
		/// </summary>
		private bool isCharge;

		/// <summary>
		/// 患者ID
		/// </summary>
		private string  patientNO;

		/// <summary>
		/// 患者所在科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject patientDept= new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 每次剂量
		/// </summary>
		private decimal doseOnce;

		/// <summary>
		/// 用法
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myUsage = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 频次
		/// </summary>
		private Neusoft.HISFC.Models.Order.Frequency myFrequency = new Neusoft.HISFC.Models.Order.Frequency();

		/// <summary>
		/// 医嘱类型
		/// </summary>
		private Neusoft.HISFC.Models.Order.OrderType myOrderType = new Neusoft.HISFC.Models.Order.OrderType();

		/// <summary>
		/// 医嘱号
		/// </summary>
		private string  myOrderNo;

		/// <summary>
		/// 组合号
		/// </summary>
		private string  myCombNo;

		/// <summary>
		/// 执行档流水号
		/// </summary>
		private string  myExecNo;

		/// <summary>
		/// 处方号
		/// </summary>
		private string  myRecipeNo;

		/// <summary>
		/// 处方内项目流水号
		/// </summary>
		private int mySequenceNo;

		/// <summary>
		/// 发送类型
		/// </summary>
		private int mySendType;

		/// <summary>
		/// 摆药单分类代码
		/// </summary>
		private string myBillClassNo;

		/// <summary>
		/// 打印状态
		/// </summary>
		private string myPrintState;

		/// <summary>
		/// 出库单据号
		/// </summary>
		private string myOutBillNo = "0";

		/// <summary>
		/// 货位号
		/// </summary>
		private string myPlaceNo;

        /// <summary>
        /// 发药窗口号 只用于实体数据存储 不存在数据库表中
        /// </summary>
        private string sendWindow = "";

        /// <summary>
        /// 院注次数 只用于实体数据存储 不存在数据库表中
        /// </summary>
        private int injectQty;

        /// <summary>
        /// 开方信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment recipeInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否婴儿
        /// </summary>
        private bool isBaby;
   
        /// <summary>
        /// 扩展字段
        /// </summary>
        private string extFlag;

        /// <summary>
        /// 扩展字段1
        /// </summary>
        private string extFlag1;

        /// <summary>
        /// 配液信息类
        /// </summary>
        private Order.Compound compound = new Neusoft.HISFC.Models.Order.Compound();

        /// <summary>
        /// 配置批次流水号 批次号 + 医嘱组合号
        /// </summary>
        private string compoundGroup;

        /// <summary>
        /// 医嘱使用时间
        /// </summary>
        private DateTime useTime = System.DateTime.MinValue;

        /// <summary>
        /// 协定处方类
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject drugNostrum = new Neusoft.FrameWork.Models.NeuObject();
		#endregion

		/// <summary>
		/// Item实体
		/// </summary>
		public Neusoft.HISFC.Models.Pharmacy.Item Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
				base.IMAItem = value;
			}
		}

		/// <summary>
		/// 付数 草药
		/// </summary>
		public decimal Days
		{
			get
			{
				return this.days;
			}
			set
			{
				this.days = value;
			}
		}

		/// <summary>
		/// 批次
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
		/// 单位显示状态 1 包装单位 0 最小单位
		/// </summary>
		public string ShowState
		{
			get
			{
				return this.showState;
			}
			set
			{
				this.showState = value;
			}
		}

		/// <summary>
		/// 显示单位
		/// </summary>
		public string ShowUnit
		{
			get
			{
				return this.showUnit;
			}
			set
			{
				this.showUnit = value;
			}
		}

		/// <summary>
		/// 预扣库存状态（false未扣库存，true已扣库存）
		/// </summary>
		public bool IsPreOut 
		{
			get	
			{
				return this.isPreOut;
			}
			set	
			{ 
				this.isPreOut = value; 
			}
		}

		/// <summary>
		/// 收费状态（false未收费，true已收费）
		/// </summary>
		public bool IsCharge
		{
			get	
			{
				return  this.isCharge;
			}
			set	
			{
				this.isCharge = value;
			}
		}

		/// <summary>
		/// 患者ID号（门诊卡号或者住院号）
		/// </summary>
		public string PatientNO
		{
			get	
			{
				return  this.patientNO;
			}
			set	
			{ 
				this.patientNO = value; 
			}
		}

		/// <summary>
		/// 患者所在病区（申请领药的病区）
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PatientDept 
		{
			get	
			{ 
				return  this.patientDept;
			}
			set	
			{ 
				this.patientDept = value;
			}
		}

		/// <summary>
		/// 每次剂量
		/// </summary>
		public decimal DoseOnce 
		{
			get	
			{ 
				return  this.doseOnce;
			}
			set	
			{  
				this.doseOnce = value; 
			}
		}

		/// <summary>
		/// 用法
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Usage 
		{
			get	
			{
				return  myUsage;
			}
			set	
			{  
				myUsage = value; 
			}
		}

		/// <summary>
		/// 频次
		/// </summary>
		public Neusoft.HISFC.Models.Order.Frequency Frequency 
		{
			get	
			{
				return  myFrequency;
			}
			set	
			{  
				myFrequency = value; 
			}
		}

		/// <summary>
		/// 医嘱类型
		/// </summary>
		public Neusoft.HISFC.Models.Order.OrderType OrderType 
		{
			get	
			{
				return  myOrderType;
			}
			set	
			{  
				myOrderType = value;
			}
		}

		/// <summary>
		/// 医嘱流水号
		/// </summary>
		public string OrderNO 
		{
			get	
			{
				return  myOrderNo;
			}
			set	
			{ 
				myOrderNo = value; 
			}
		}

		/// <summary>
		/// 医嘱组合序号
		/// </summary>
		public string CombNO 
		{
			get	
			{
				return  myCombNo;
			}
			set	
			{
				myCombNo = value; 
			}
		}

		/// <summary>
		/// 执行单流水号
		/// </summary>
		public string ExecNO 
		{
			get	
			{
				return  myExecNo;
			}
			set	
			{
				myExecNo = value; 
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
		/// 处方内项目流水号
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
		/// 发送类型0-临时发送，1-集中发送
		/// </summary>
		public int SendType 
		{
			get
			{
				return this.mySendType;
			}
			set
			{
				this.mySendType = value;
			}
		}

		/// <summary>
		/// 摆药单分类代码
		/// </summary>
		public string BillClassNO 
		{
			get
			{ 
				return this.myBillClassNo; 
			}
			set
			{ 
				this.myBillClassNo = value; 
			}
		}

		/// <summary>
		/// 摆药单号
		/// </summary>
		public string DrugNO
		{
			get
			{
				return this.drugNO;
			}
			set
			{
				this.drugNO = value;
			}
		}

		/// <summary>
		/// 打印状态（0未打印，1已打印）
		/// </summary>
		public string PrintState 
		{
			get
			{
				return this.myPrintState;
			}
			set
			{
				this.myPrintState = value;
			}
		}

		/// <summary>
		/// 出库单号
		/// </summary>
		public string OutBillNO 
		{
			get	
			{ 
				return  this.myOutBillNo;
			}
			set	
			{  
				this.myOutBillNo = value; 
			}
		}

		/// <summary>
		/// 货位号
		/// </summary>
		public string PlaceNO
		{
			get	
			{ 
				return  myPlaceNo;
			}
			set	
			{ 
				myPlaceNo = value; 
			}
		}

        /// <summary>
        /// 发药窗口号 只用于实体数据存储 不存在数据库表中
        /// </summary>
        public string SendWindow
        {
            get
            {
                return this.sendWindow;
            }
            set
            {
                this.sendWindow = value;
            }
        }

        /// <summary>
        /// 院注次数 只用于实体数据存储 不存在数据库表中
        /// </summary>
        public int InjectQty
        {
            get
            {
                return this.injectQty;
            }
            set
            {
                this.injectQty = value;
            }
        }

        /// <summary>
        ///  开方信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment RecipeInfo
        {
            get
            {
                return this.recipeInfo;
            }
            set
            {
                this.recipeInfo = value;
            }
        }

        /// <summary>
        /// 是否婴儿
        /// </summary>
        public bool IsBaby
        {
            get
            {
                return isBaby;
            }
            set
            {
                isBaby = value;
            }
        }

        /// <summary>
        /// 配液信息类
        /// </summary>
        public Neusoft.HISFC.Models.Order.Compound Compound
        {
            get
            {
                return this.compound;
            }
            set
            {
                this.compound = value;
            }
        }

        /// <summary>
        /// 配置批次流水号 批次号 + 医嘱组合号
        /// </summary>
        public string CompoundGroup
        {
            get
            {
                return this.compoundGroup;
            }
            set
            {
                this.compoundGroup = value;
            }
        }

        /// <summary>
        /// 医嘱使用时间 对无效作废的申请记录为作废时间
        /// </summary>
        public DateTime UseTime
        {
            get
            {
                return this.useTime;
            }
            set
            {
                this.useTime = value;
            }
        }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExtFlag
        {
            get
            {
                return extFlag;
            }
            set
            {
                extFlag = value;
            }
        }

        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string ExtFlag1
        {
            get
            {
                return extFlag1;
            }
            set
            {
                extFlag1 = value;
            }
        }

        /// <summary>
        /// 协定处方类
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NostrumDrug
        {
            get
            {
                return this.drugNostrum;
            }
            set
            {
                this.drugNostrum = value;
            }
        }

		#region 方法

		public new ApplyOut Clone()
		{
			ApplyOut applyOut = base.Clone() as ApplyOut;

			applyOut.PatientDept = this.PatientDept.Clone();
			applyOut.Usage = this.Usage.Clone();
			applyOut.Frequency = this.Frequency.Clone();
			applyOut.OrderType = this.OrderType.Clone();
            applyOut.RecipeInfo = this.recipeInfo.Clone();
            applyOut.Compound = this.compound.Clone();
            applyOut.item = this.item.Clone();
            applyOut.NostrumDrug = this.NostrumDrug.Clone();

			return applyOut;

		}

		#endregion

		#region 无效属性

		/// <summary>
		/// 被申请科室(库存科室)
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myTargetDept = new Neusoft.FrameWork.Models.NeuObject();

		//私有字段
		private string  myDrugBill;

		/// <summary>
		/// 患者ID
		/// </summary>
		private string  patientId;

		/// <summary>
		/// 摆药单分类代码
		/// </summary>
		private string  myBillClassCode;

		/// <summary>
		/// 出库单据号
		/// </summary>
		private string  myOutBillCode = "0";

		/// <summary>
		/// 货位号
		/// </summary>
		private string  myPlaceCode;

		/// <summary>
		/// 申请类型
		/// </summary>
		private string applyType;

		/// <summary>
		/// 申请类型
		/// </summary>
		[System.Obsolete("程序整合 更改为SystemType属性",true)]
		public string ApplyType
		{
			get
			{
				return this.applyType;
			}
			set
			{
				this.applyType = value;
			}
		}


		/// <summary>
		/// 被申请科室
		/// </summary>
		[System.Obsolete("程序整合 继承自ApplyBase基类 更改为属性StockDept属性",true)]
		public Neusoft.FrameWork.Models.NeuObject TargetDept 
		{
			get	{ return  myTargetDept;}
			set	{  myTargetDept = value; }
		}


		/// <summary>
		/// 摆药单号
		/// </summary>
		[System.Obsolete("程序整合 更改为DrugNO属性",true)]
		public string DrugBill 
		{
			get	{ return  myDrugBill;}
			set	{  myDrugBill = value; }
		}


		/// <summary>
		/// 患者ID号（门诊卡号或者住院号）
		/// </summary>
		[System.Obsolete("程序整合 更改为PatientNO属性",true)]
		public string PatientID
		{
			get	
			{
				return  this.patientId;
			}
			set	
			{ 
				this.patientId = value; 
			}
		}


		/// <summary>
		/// 摆药单分类代码
		/// </summary>
		[System.Obsolete("程序整合 更改为BillClassNO",true)]
		public string BillClassCode 
		{
			get{ return this.myBillClassCode; }
			set{ this.myBillClassCode = value; }
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
		/// 货位号
		/// </summary>
		[System.Obsolete("程序整合 更改为PlaceNO",true)]
		public string PlaceCode 
		{
			get	{ return  myPlaceCode;}
			set	{  myPlaceCode = value; }
		}


		/// <summary>
		/// 医嘱流水号
		/// </summary>
		[System.Obsolete("程序整合 更改为OrderNO属性",true)]
		public string OrderNo 
		{
			get	{ return  myOrderNo;}
			set	{  myOrderNo = value; }
		}


		/// <summary>
		/// 医嘱组合序号
		/// </summary>
		[System.Obsolete("程序整合 更改为CombNO属性",true)]
		public string CombNo 
		{
			get	{ return  myCombNo;}
			set	{  myCombNo = value; }
		}


		/// <summary>
		/// 执行单流水号
		/// </summary>
		[System.Obsolete("程序整合 更改为ExecNO属性",true)]
		public string ExecNo 
		{
			get	{ return  myExecNo;}
			set	{  myExecNo = value; }
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
		/// 处方内项目流水号
		/// </summary>
		[System.Obsolete("程序整合 更改为SequenceNO属性",true)]
		public int SequenceNo 
		{
			get	{ return  mySequenceNo;}
			set	{  mySequenceNo = value; }
		}


		/// <summary>
		/// 批次
		/// </summary>
		[System.Obsolete("程序整合 更改为GroupNO属性",true)]
		public decimal GroupNo 
		{
			get	{ return  myGroupNo;}
			set	{  myGroupNo = value; }
		}


		/// <summary>
		/// 批号
		/// </summary>
		[System.Obsolete("BatchNO属性",true)]
		public string BatchNo 
		{
			get	{ return  myBatchNo;}
			set	{  myBatchNo = value; }
		}


		
		//以下是Apply基类内的成员属性 Apply类无效 改由IMAApplyBase雷继承

		private string myBillCode;
		private string   myApplyOperCode = "";
		private DateTime myApplyDate;
		private string   myApplyState = "";
		private decimal  myApplyNum;
		private DateTime myExamDate;
		private string   myExamOperCode = "";
		private decimal  myApproveNum;
		private DateTime myApproveDate;
		private string   myApproveOperCode = "";
		private Neusoft.FrameWork.Models.NeuObject myApproveDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请人
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public string ApplyOperCode 
		{
			get	{ return  myApplyOperCode;}
			set	{  myApplyOperCode = value; }
		}

		/// <summary>
		/// 申请日期
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public DateTime ApplyDate 
		{
			get	{ return  myApplyDate;}
			set	{  myApplyDate = value; }
		}

		/// <summary>
		/// 申请状态
		/// </summary>
		[System.Obsolete("程序整合 更改为State属性",true)]
		public string ApplyState 
		{
			get	{ return  myApplyState;}
			set	{  myApplyState = value; }
		}

		/// <summary>
		/// 申请出库量(每付的数量)
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public decimal ApplyNum 
		{
			get	{ return  myApplyNum;}
			set	{  myApplyNum = value; }
		}

		/// <summary>
		/// 审批日期（打印人）
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public DateTime ExamDate 
		{
			get	{ return  myExamDate;}
			set	{  myExamDate = value; }
		}

		/// <summary>
		/// 审批人（打印人）
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public string ExamOperCode 
		{
			get	{ return  myExamOperCode;}
			set	{  myExamOperCode = value; }
		}

		/// <summary>
		/// 核准数量
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public decimal ApproveNum 
		{
			get	{ return  myApproveNum;}
			set	{  myApproveNum = value; }
		}

		/// <summary>
		/// 核准日期
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public DateTime ApproveDate 
		{
			get	{ return  myApproveDate;}
			set	{  myApproveDate = value; }
		}

		/// <summary>
		/// 核准人
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public string ApproveOperCode 
		{
			get	{ return  myApproveOperCode;}
			set	{  myApproveOperCode = value; }
		}

		/// <summary>
		/// 核准科室
		/// </summary>
		[System.Obsolete("程序整合 调整所继承基类 更改为由IMAAppleBase基类内的Operation属性内获取",true)]
		public Neusoft.FrameWork.Models.NeuObject ApproveDept 
		{
			get	{ return  myApproveDept;}
			set	{  myApproveDept = value; }
		}

		/// <summary>
		/// 申请单号
		/// </summary>
		[System.Obsolete("程序整合 更改为BillNO属性",true)]
		public string BillCode 
		{
			get	{ return  myBillCode;}
			set	{  myBillCode = value; }
		}

		#endregion
	}
}
