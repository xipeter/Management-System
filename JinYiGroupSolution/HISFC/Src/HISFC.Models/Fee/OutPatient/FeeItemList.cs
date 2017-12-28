using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{
	/// <summary>
	/// FeeItemList<br></br>
	/// [功能描述: 门诊费用明细类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-13]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class FeeItemList : FeeItemBase
	{
		
		public FeeItemList()
		{
            this.Patient = new Registration.Register();
		}
		
		#region 变量

		/// <summary>
		/// 院内注射次数
		/// </summary>
		private int injectCount; 
		
		/// <summary>
		/// 已确认院注次数
		/// </summary>
		private int confirmedInjectCount; 
		
		/// <summary>
		/// 是否加急
		/// </summary>
		private bool isUrgent;
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		private string invoiceCombNO;
		
		/// <summary>
		/// 项目原始比例
		/// </summary>
		private decimal orgItemRate;
		
		/// <summary>
		/// 修改后得项目比例
		/// </summary>
		private decimal newItemRate;
		
		/// <summary>
		/// 收费序列,每次医嘱保存,根据此序列形成多张收费处方
		/// </summary>
		private string recipeSequence;
		
		/// <summary>
		/// 特殊单价,应用公费修改项目单价
		/// </summary>
		private decimal specialPrice;

        /// <summary>
        /// 用于修改优惠单价时保存原始单价
        /// </summary>
        private decimal orgPrice;

        /// <summary>
        /// 项目比例标志 1 自费 2 记帐 3 特殊
        /// </summary>
        private string itemRateFlag = string.Empty;

        /// <summary>
        /// 体检标志 0不是体检/1个人体检/2团体体检 
        /// </summary>
        private string examineFlag = string.Empty;

        /// <summary>
        /// 是否已经扣取账户
        /// </summary>
        private bool isAccounted = false;

        /// <summary>
        /// 账户账号
        /// </summary>
        private string accountNO = string.Empty;

       

		#endregion
		
		#region 属性

        /// <summary>
        /// 是否已经扣取账户
        /// </summary>
        public bool IsAccounted 
        {
            get 
            {
                return this.isAccounted;
            }
            set 
            {
                this.isAccounted = value;
            }
        }
		

        /// <summary>
		/// 体检标志 0不是体检/1个人体检/2团体体检 
		/// </summary>
		public string ExamineFlag
		{
			get
			{
				return this.examineFlag;
			}
			set
			{
				this.examineFlag = value;
			}
		}

        /// <summary>
        /// 项目比例标志 1 自费 2 记帐 3 特殊
        /// </summary>
        public string ItemRateFlag 
        {
            get 
            {
                return this.itemRateFlag;
            }
            set 
            {
                this.itemRateFlag = value;
            }
        }

        /// <summary>
        /// 用于修改优惠单价时保存原始单价
        /// </summary>
        public decimal OrgPrice 
        {
            get 
            {
                return this.orgPrice;
            }
            set 
            {
                this.orgPrice = value;
            }
        }
		
		/// <summary>
		/// 院内注射次数
		/// </summary>
		public int InjectCount
		{
			get
			{
				return this.injectCount;
			}
			set
			{
				this.injectCount = value;
			}
		}

		/// <summary>
		/// 已确认院注次数
		/// </summary>
		public int ConfirmedInjectCount
		{
			get
			{
				return this.confirmedInjectCount;
			}
			set
			{
				this.confirmedInjectCount = value;
			}
		}

		/// <summary>
		/// 项目是否加急 true 是 false 不是
		/// </summary>
		public bool IsUrgent
		{
			get
			{
				return this.isUrgent;
			}
			set
			{
				this.isUrgent = value;
			}
		}
		
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNO
		/// </summary>
		public string InvoiceCombNO
		{
			get
			{
				return this.invoiceCombNO;
			}
			set
			{
				this.invoiceCombNO = value;
			}
		}

		/// <summary>
		/// 项目原始比例
		/// </summary>
		public decimal OrgItemRate
		{
			get
			{
				return this.orgItemRate;
			}
			set
			{
				this.orgItemRate = value;
			}
		}

		/// <summary>
		/// 修改后得项目比例
		/// </summary>
		public decimal NewItemRate
		{
			get
			{
				return this.newItemRate;
			}
			set
			{
				this.newItemRate = value;
			}
		}

		/// <summary>
		/// 收费序列,每次医嘱保存,根据此序列形成多张收费处方
		/// </summary>
		public string RecipeSequence
		{
			get
			{
				return this.recipeSequence;
			}
			set
			{
				this.recipeSequence = value;
			}
		}

		/// <summary>
		/// 特殊单价,应用公费修改项目单价
		/// </summary>
		public decimal SpecialPrice
		{
			get
			{
				return this.specialPrice;
			}
			set
			{
				this.specialPrice = value;
			}
		}

        /// <summary>
        /// 账户账号
        /// </summary>
        public string AccountNO
        {
            get { return accountNO; }
            set { accountNO = value; }
        }
		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例</returns>
		public new FeeItemList Clone()
		{
			return base.Clone() as FeeItemList;
		} 

		#endregion

		#endregion
		
		#region 无用变量属性

		/// <summary>
		/// 药品超标金额
		/// </summary>
		private decimal excessCost;
		
		/// <summary>
		/// 自费药金额
		/// </summary>
		private decimal drugOwnCost;

		/// <summary>
		/// 药品超标金额
		/// </summary>
        [Obsolete("作废,使用FT.ExcessCost", true)]
		public decimal ExcessCost
		{
			set
			{
				this.excessCost = value;
			}
			get
			{
				return this.excessCost;
			}
		}

		/// <summary>
		/// 自费药金额
		/// </summary>
        [Obsolete("作废,FT.DrugOwnCost", true)]
		public decimal DrugOwnCost
		{
			set
			{
				drugOwnCost = value;
			}
			get
			{
				return drugOwnCost;
			}
		}

		private string costSource;//费用来源
		/// <summary>
		/// 费用来源0 收费员操作 1 医嘱 2 终端 3 体检 
		/// </summary>
		[Obsolete("作废,已经继承使用FTSource", true)]
		public string CostSource
		{
			set
			{
				costSource = value;
			}
			get
			{
				return costSource;
			}
		}
		private string subJobFlag;//附材标志
		/// <summary>
		/// 1是附材0不是
		/// </summary>
		[Obsolete("作废,已经继承使用IsMaterial", true)]
		public string SubJobFlag
		{
			set
			{
				subJobFlag = value;
			}
			get
			{
				return subJobFlag;
			}
		}
		
		private string recipeSeq;//收费序列
		/// <summary>
		/// 收费序列
		/// </summary>
		[Obsolete("作废,已经继承使用RecipeSequence", true)]
		public string RecipeSeq
		{
			get
			{
				return recipeSeq;
			}
			set
			{
				recipeSeq = value;
			}
		}
		private decimal spPrice;//特殊单价
		/// <summary>
		/// 特殊单价
		/// </summary>
		[Obsolete("作废,使用SpecialPrice", true)]
		public decimal SpPrice
		{
			set
			{
				spPrice = value;
			}
			get
			{
				return spPrice;
			}
		}
		/// <summary>
		/// 对照信息
		/// </summary>
		[Obsolete("作废,已经继承使用Compare", true)]
		public Neusoft.HISFC.Models.SIInterface.Compare CompareItem = new Neusoft.HISFC.Models.SIInterface.Compare();
		private string extFlag; //扩展标志,代表修改比例后得项目情况 1 自费 2 记帐 3 特殊
		/// <summary>
		/// 扩展标志,代表修改比例后得项目情况 1 自费 2 记帐 3 特殊
		/// </summary>
		[Obsolete("作废,已经继承使用SpecialFlag", true)]
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
		private string extFlag1;//扩展标志1
		/// <summary>
		/// 扩展标志1
		/// </summary>
		[Obsolete("作废,已经继承使用SpecialFlag1", true)]
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
		private string extFlag2;//扩展标志2
		/// <summary>
		/// 扩展标志2
		/// </summary>
		[Obsolete("作废,已经继承使用SpecialFlag2", true)]
		public string ExtFlag2
		{
			get
			{
				return extFlag2;
			}
			set
			{
				extFlag2 = value;
			}
		}
		private string extFlag3;//扩展标志3
		/// <summary>
		/// 扩展标志3
		/// </summary>
		[Obsolete("作废,已经继承使用SpecialFlag3", true)]
		public string ExtFlag3
		{
			get
			{
				return extFlag3;
			}
			set
			{
				extFlag3 = value;
			}
		}
        //
        //private Neusoft.HISFC.Models.Fee.Item.UndrugComb package = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
		/// <summary>
		/// 复合项目信息
		/// </summary>
		[Obsolete("作废,已经继承使用UndrugComb", true)]
		public Neusoft.HISFC.Models.Fee.Item.UndrugComb Package
		{
			get
			{
				return null;
			}
            //set
            //{
            //    package = value;
            //}
		}
		private decimal noBackNum;//可退数量
		/// <summary>
		/// 可退数量
		/// </summary>
		[Obsolete("作废,已经继承使用NoBackQty", true)]
		public decimal NoBackNum
		{
			get
			{
				return noBackNum;
			}
			set
			{
				noBackNum = value;
			}
		}

		private decimal confirmNum;//确认数量
		/// <summary>
		/// 确认数量
		/// </summary>
		[Obsolete("作废,已经继承使用ConfirmedQty", true)]
		public decimal ConfirmNum
		{
			get
			{
				return confirmNum;
			}
			set
			{
				confirmNum = value;
			}
		}
		private string moOrder;//医嘱或者体检项目流水号
		/// <summary>
		/// 医嘱或者体检项目流水号
		/// </summary>
		[Obsolete("作废,已经继承使用Order", true)]
		public string MoOrder
		{
			get
			{
				return moOrder;
			}
			set
			{
				moOrder = value;
			}
		}

		private string invoiceSeq;//发票序号，一次结算产生多张发票的combNo
		/// <summary>
		/// 发票序号，一次结算产生多张发票的combNo
		/// </summary>
		[Obsolete("作废,已经使用InvoiceCombNO", true)]
		public string InvoiceSeq
		{
			get
			{
				return invoiceSeq;
			}
			set
			{
				invoiceSeq = value;
			}
		}
		private string needBespeak;//项目是否需要预约 1需要
		/// <summary>
		/// 项目是否需要预约 1需要
		/// </summary>
		[Obsolete("作废,已经继承使用IsNeedBespeak", true)]
		public string NeedBespeak
		{
			get
			{
				return needBespeak;
			}
			set
			{
				needBespeak = value;
			}
		}

		private int seqNo; //项目内处方号
		/// <summary>
		/// 项目内处方号
		/// </summary>
		[Obsolete("作废,已经继承使用SequenceNO", true)]
		public int SeqNo
		{
			get
			{
				return seqNo;
			}
			set
			{
				seqNo = value;
			}
		}
		private string clinicCode;//门诊流水号
		/// <summary>
		/// 门诊流水号
		/// </summary>
		[Obsolete("作废,已经继承使用ID", true)]
		public string ClinicCode
		{
			get
			{
				return clinicCode;
			}
			set
			{
				clinicCode = value;
			}
		}
		private string cardNo; //门诊卡号
		/// <summary>
		/// 门诊卡号
		/// </summary>
		[Obsolete("作废,已经继承使用Patient.PID.CardNO", true)]
		public string CardNo
		{
			get
			{
				return cardNo;
			}
			set
			{
				cardNo = value;
			}
		}

		private DateTime regDate; ///挂号日期
		[Obsolete("作废,Register", true)]
		public DateTime RegDate
		{
			get
			{
				return regDate;
			}
			set
			{
				regDate = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject regDeptInfo = new Neusoft.FrameWork.Models.NeuObject(); //挂号科室信息
		/// <summary>
		/// 挂号科室信息 id 科室编码 Name 科室名称
		/// </summary>
		[Obsolete("作废,Register转换为", true)]
		public Neusoft.FrameWork.Models.NeuObject RegDeptInfo
		{
			get
			{
				return regDeptInfo;
			}
			set
			{
				regDeptInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject doctInfo = new Neusoft.FrameWork.Models.NeuObject(); //开方医师信息
		/// <summary>
		/// 开方医师信息 ID 员工编码 Name 员工姓名
		/// </summary>
		[Obsolete("作废 使用RecipeOper.ID(Name)", true)]
		public Neusoft.FrameWork.Models.NeuObject DoctInfo
		{
			get
			{
				return doctInfo;
			}
			set
			{
				doctInfo = value;
			}
		}
		
		private Neusoft.FrameWork.Models.NeuObject doctDeptInfo = new Neusoft.FrameWork.Models.NeuObject(); //开方医师所在科室信息
		/// <summary>
		/// 开方医师所在科室信息 ID 科室编码 Name 科室名称
		/// </summary>
		[Obsolete("作废,使用RecipeOper.Dept", true)]
		public Neusoft.FrameWork.Models.NeuObject DoctDeptInfo
		{
			get
			{
				return doctDeptInfo;
			}
			set
			{
				doctDeptInfo = value;
			}
		}
		
		private bool isSelfMade;//自制项目标志
		/// <summary>
		/// 自制项目标志 true 是 false 不是
		/// </summary>
		[Obsolete("作废,Item转换为Pharmarcy.Item后取属性", true)]
		public bool IsSelfMade
		{
			get
			{
				return isSelfMade;
			}
			set
			{
				isSelfMade = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject drugQualityInfo = new Neusoft.FrameWork.Models.NeuObject(); //药品性质信息
		/// <summary>
		/// 药品性质信息 ID 代码  Name 名称
		/// </summary>
		[Obsolete("作废", true)]
		public Neusoft.FrameWork.Models.NeuObject DrugQualityInfo
		{
			get
			{
				return drugQualityInfo;
			}
			set
			{
				drugQualityInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject doseInfo = new Neusoft.FrameWork.Models.NeuObject(); //剂型信息
		/// <summary>
		/// 剂型信息 ID 剂型代码 Name 剂型名称
		/// </summary>
		[Obsolete("作废", true)]
		public Neusoft.FrameWork.Models.NeuObject DoseInfo
		{
			get
			{	
				return doseInfo;
			}
			set
			{
				doseInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject freqInfo = new Neusoft.FrameWork.Models.NeuObject(); //频次信息
		/// <summary>
		/// 频次信息 ID 频次代码 Name 频次名称
		/// </summary>
		[Obsolete("作废,已经继承使用Order.Frenquence", true)]
		public Neusoft.FrameWork.Models.NeuObject FreqInfo
		{
			get
			{
				return freqInfo;
			}
			set
			{
				freqInfo = value;
			}
		}
		
		private Neusoft.FrameWork.Models.NeuObject usageInfo = new Neusoft.FrameWork.Models.NeuObject(); //用法信息
		/// <summary>
		/// 用法信息 ID 用法代码 Name 用法名称
		/// </summary>
		[Obsolete("作废,已经继承使用Order.Usage", true)]
		public Neusoft.FrameWork.Models.NeuObject UsageInfo
		{
			get
			{
				return usageInfo;
			}
			set
			{
				usageInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject labTypeInfo = new Neusoft.FrameWork.Models.NeuObject();//样本类型
		/// <summary>
		/// 样本类型信息 ID 样本类型代码 Name 样本类型名称
		/// </summary>
		[Obsolete("作废,已经继承使用Order.Sample", true)]
		public Neusoft.FrameWork.Models.NeuObject LabTypeInfo
		{
			get
			{
				return labTypeInfo;
			}
			set
			{
				labTypeInfo = value;
			}
		}

		private string checkBody; //检体
		/// <summary>
		/// 检体
		/// </summary>
		[Obsolete("作废,已经继承使用Order.Sample", true)]
		public string CheckBody
		{
			get
			{
				return checkBody;
			}
			set
			{
				checkBody = value;
			}
		}

		private decimal doseOnce; //每次用量
		/// <summary>
		/// 每次用量
		/// </summary>
		[Obsolete("作废,已经继承使用Order.DoseOnce", true)]
		public decimal DoseOnce
		{
			get
			{
				return doseOnce;
			}
			set
			{
				doseOnce = value;
			}
		}
		
		private string doseUnit; //每次用量单位
		/// <summary>
		/// 每次用量单位
		/// </summary>
		[Obsolete("作废,已经继承使用Order.DoseUnit", true)]
		public string DoseUnit
		{
			get
			{
				return doseUnit;
			}
			set
			{
				doseUnit = value;
			}
		}

		private decimal baseDose; //基本用量
		/// <summary>
		/// 基本用量
		/// </summary>
		[Obsolete("作废,已经继承使用Item转换为Pharmacy.Item的BaseDose属性", true)]
		public decimal BaseDose
		{
			get
			{
				return baseDose;
			}
			set
			{
				baseDose = value;
			}
		}

		private FT cost = new FT(); //费用信息;
		/// <summary>
		/// 费用信息
		/// </summary>
		[Obsolete("作废,已经继承使用FT", true)]
		public FT Cost
		{
			get
			{
				return cost;
			}
			set
			{
				cost = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject exeDeptInfo = new Neusoft.FrameWork.Models.NeuObject();//执行科室信息
		/// <summary>
		/// 执行科室信息 ID 科室代码 Name 科室名称
		/// </summary>
		[Obsolete("作废,已经继承使用ExecOper.Dept", true)]
		public Neusoft.FrameWork.Models.NeuObject ExeDeptInfo
		{
			get
			{
				return exeDeptInfo;
			}
			set
			{
				exeDeptInfo = value;
			}
		}

		private Neusoft.HISFC.Models.SIInterface.Item centerInfo = new Neusoft.HISFC.Models.SIInterface.Item();//医保对照信息

		/// <summary>
		/// 医保对照信息 包括中心编码， 项目类别(甲，乙， 自费)
		/// </summary>
		[Obsolete("作废,已经继承使用Compare", true)]
		public Neusoft.HISFC.Models.SIInterface.Item CenterInfo 
		{
			get
			{
				return centerInfo;
			}
			set
			{
				centerInfo = value;
			}
		}
		
		private bool isMainDrug; //是否主药
		/// <summary>
		/// 是否主药 true 是 false 不是
		/// </summary>
		[Obsolete("作废,已经继承使用Order", true)]
		public bool IsMainDrug
		{
			get
			{
				return isMainDrug;
			}
			set
			{
				isMainDrug = value;
			}
		}

		private string combNo;//组合号
		/// <summary>
		/// 组合号
		/// </summary>
		[Obsolete("作废,已经继承使用Order.Combo.ID", true)]
		public string CombNo
		{
			get
			{
				return combNo;
			}
			set
			{
				combNo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject chargeOperInfo = new Neusoft.FrameWork.Models.NeuObject();//划价人信息
		/// <summary>
		/// 划价人信息 ID 划价人代码 Name 姓名
		/// </summary>
		[Obsolete("作废,已经继承使用ChargeOper.ID(Name)", true)]
		public Neusoft.FrameWork.Models.NeuObject ChargeOperInfo
		{
			get
			{
				return chargeOperInfo;
			}
			set
			{
				chargeOperInfo = value;
			}
		}

		private DateTime chargeDate;//划价日期
		/// <summary>
		/// 划价日期
		/// </summary>
		[Obsolete("作废,已经继承使用ChargeOper.OperTime", true)]
		public DateTime ChargeDate
		{
			get
			{
				return chargeDate;
			}
			set
			{
				chargeDate = value;
			}
		}


		private Neusoft.FrameWork.Models.NeuObject feeOperInfo = new Neusoft.FrameWork.Models.NeuObject();//收费人信息
		/// <summary>
		/// 收费人信息 ID 收费人代码 Name 姓名
		/// </summary>
		[Obsolete("作废,已经继承使用FeeOper.ID(Name)", true)]
		public Neusoft.FrameWork.Models.NeuObject FeeOperInfo
		{
			get
			{
				return feeOperInfo;
			}
			set
			{
				feeOperInfo = value;
			}
		}

		private DateTime feeDate;//收费日期
		/// <summary>
		/// 收费日期
		/// </summary>
		[Obsolete("作废,已经继承使用FeeOper.OperTime", true)]
		public DateTime FeeDate
		{
			get
			{
				return feeDate;
			}
			set
			{
				feeDate = value;
			}
		}
		private string invoiceNo;//发票号
		/// <summary>
		/// 发票号
		/// </summary>
		[Obsolete("作废,已经继承使用Invoice.ID", true)]
		public string InvoiceNo
		{
			get
			{
				return invoiceNo;
			}
			set
			{
				invoiceNo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject invoiceTypeInfo = new Neusoft.FrameWork.Models.NeuObject();//发票科目信息
		/// <summary>
		/// 发票科目信息  ID 科目代码 Name 科目名称
		/// </summary>
		[Obsolete("作废,已经继承使用Invoice", true)]
		public Neusoft.FrameWork.Models.NeuObject InvoiceTypeInfo
		{
			get
			{
				return invoiceTypeInfo;
			}
			set
			{
				invoiceTypeInfo = value;
			}
		}

		private int invoiceSeqNo;//发票内流水号
		/// <summary>
		/// 发票内流水号
		/// </summary>
		[Obsolete("作废,已经继承使用Invoice", true)]
		public int InvoiceSeqNo
		{
			get
			{
				return invoiceSeqNo;
			}
			set
			{
				invoiceSeqNo = value;
			}
		}
		
		private bool isConfirm; //是否终端确认
		/// <summary>
		/// 是否终端确认 true 确认 false 没有确认
		/// </summary>
		[Obsolete("作废,已经继承使用IsConfirmed", true)]
		public bool IsConfirm
		{
			get
			{
				return isConfirm;
			}
			set
			{
				isConfirm = value;
			}
		}
		
		private Neusoft.FrameWork.Models.NeuObject confirmOperInfo = new Neusoft.FrameWork.Models.NeuObject();//确认人信息
		/// <summary>
		/// 确认人信息 ID 确认人代码 Name 姓名
		/// </summary>
		[Obsolete("作废,已经继承使用ConfirmOper.ID(Name)", true)]
		public Neusoft.FrameWork.Models.NeuObject ConfirmOperInfo
		{
			get
			{
				return confirmOperInfo;
			}
			set
			{
				confirmOperInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject confirmDeptInfo = new Neusoft.FrameWork.Models.NeuObject();//确认科室信息
		/// <summary>
		/// 确认科室信息 ID 确认科室代码 Name 科室名称
		/// </summary>
		[Obsolete("作废,已经继承使用ConfirmOper.Dept", true)]
		public Neusoft.FrameWork.Models.NeuObject ConfirmDeptInfo
		{
			get
			{
				return confirmDeptInfo;
			}
			set
			{
				confirmDeptInfo = value;
			}
		}

		private DateTime confirmDate;//确认日期
		/// <summary>
		/// 确认日期
		/// </summary>
		[Obsolete("作废,已经继承使用ConfirmOper.OperTime", true)]
		public DateTime ConfirmDate
		{
			get
			{
				return confirmDate;
			}
			set
			{
				confirmDate = value;
			}
		}

		#endregion
		
	}
}
