using System;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using System.Collections.Generic;

namespace Neusoft.HISFC.Models.Fee 
{
	/// <summary>
	/// ReturnApply<br></br>
	/// [功能描述: 退费申请类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class ReturnApply : Inpatient.FeeItemList, IBaby
	{
		
		#region 变量
		
		/// <summary>
		/// 申请单据号
		/// </summary>
		private string applyBillNO = string.Empty;

        /// <summary>
        /// 确认单号
        /// </summary>
        private string confirmBillNO = string.Empty;
		
		/// <summary>
		/// 是否婴儿
		/// </summary>
		private bool isBaby;
		
		/// <summary>
		/// 婴儿序号
		/// </summary>
		private string babyNO = string.Empty;
		
		/// <summary>
		/// 患者所在科室
		/// </summary>
		private NeuObject dept = new NeuObject();
		
		/// <summary>
		/// 患者所在护士站
		/// </summary>
		private NeuObject nurseStation = new NeuObject();
		
		/// <summary>
		/// 操作环境(操作员,操作科室,操作时间)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();

        /// <summary>
        /// 是否按照包装单位退费
        /// </summary>
        private bool isPackUnit = false;

        private System.Collections.Generic.List<ReturnApplyMet> applyMateList = new System.Collections.Generic.List<ReturnApplyMet>();

		#endregion
		
		#region 属性
		
		/// <summary>
		/// 申请单据号
		/// </summary>
		public string ApplyBillNO
		{
			get
			{
				return this.applyBillNO;
			}
			set
			{
				this.applyBillNO = value;
			}
		}

        /// <summary>
        /// 确认单号
        /// </summary>
        public string ConfirmBillNO 
        {
            get 
            {
                return this.confirmBillNO;
            }
            set 
            {
                this.confirmBillNO = value;
            }
        }
		
		
		
		/// <summary>
		/// 操作环境(操作员,操作科室,操作时间)
		/// </summary>
		public OperEnvironment Oper
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
        /// 是否按照包装单位退费
        /// </summary>
        public bool IsPackUnit 
        {
            get 
            {
                return this.isPackUnit;
            }
            set 
            {
                this.isPackUnit = value;
            }
        }

        /// <summary>
        /// 物资申请信息
        /// </summary>
        //{25934862-5C82-409c-A0D7-7BE5A24FFC75}
        public System.Collections.Generic.List<ReturnApplyMet> ApplyMateList
        {
            get
            {
                return applyMateList;
            }
            set
            {
                applyMateList = value;
            }
        }

        
		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new ReturnApply Clone()
		{
			ReturnApply returnApply = base.Clone() as ReturnApply;

            //returnApply.Dept = this.Dept.Clone();
            //returnApply.NurseStation = this.NurseStation.Clone();
            returnApply.Oper = this.Oper.Clone();
            List<ReturnApplyMet> list= new List<ReturnApplyMet>();
            foreach (ReturnApplyMet item in this.ApplyMateList)
            {
                list.Add(item.Clone());
            }
            returnApply.ApplyMateList = list;
			return returnApply;
		}

		#endregion

		#endregion

		#region 接口实现

		#region IBaby 成员
		
		/// <summary>
		/// 婴儿序号
		/// </summary>
		public string BabyNO
		{
			get
			{
				return this.babyNO;
			}
			set
			{
				this.babyNO = value;
			}
		}
		
		/// <summary>
		/// 是否婴儿
		/// </summary>
		public bool IsBaby
		{
			get
			{
				return this.isBaby;
			}
			set
			{
				this.isBaby = value;
			}
		}

		#endregion

		#endregion

		#region 无用变量 属性


		private System.String myBillCode ;
		private System.String myInpatientNo ;
		
		private Neusoft.FrameWork.Models.NeuObject myDept = new Neusoft.FrameWork.Models.NeuObject();
		private Neusoft.FrameWork.Models.NeuObject myNurseCellCode = new Neusoft.FrameWork.Models.NeuObject();
		private System.String myDrugFlag ;
		private Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();
		
		
		private System.String myExecDpcd ;
		private System.String myOperCode ;
		private System.DateTime myOperDate ;
		private System.String myOperDpcd ;
		private System.String myRecipeNo ;
		private System.Int32 mySequenceNo ;
		private string myBillNo;
		private System.String myConfirmFlag ;
		private System.String myConfirmDpcd ;
		private System.String myConfirmCode ;
		private System.DateTime myConfirmDate ;
		private System.String myChargeFlag ;
		private System.String myChargeCode ;
		private System.DateTime myChargeDate ;
		private string extFlag3 ; //  1 包装 单位 0, 最小单位

		/// <summary>
		/// 申请单据号
		/// </summary>
		[Obsolete("作废,用属性BillNO代替", true)]
		public System.String BillCode 
		{
			get{ return this.myBillCode; }
			set{ this.myBillCode = value; }
		}


		/// <summary>
		/// 住院流水号
		/// </summary>
		[Obsolete("作废,用属性Base.ID代替", true)]
		public System.String InpatientNo 
		{
			get{ return this.myInpatientNo; }
			set{ this.myInpatientNo = value; }
		}

		/// <summary>
		/// 所在病区
		/// </summary>
		[Obsolete("作废,用属性NurseStation代替", true)]
		public Neusoft.FrameWork.Models.NeuObject NurseCellCode 
		{
			get{ return this.myNurseCellCode; }
			set{ this.myNurseCellCode = value; }
		}


		/// <summary>
		/// 药品标志,1药品/2非药
		/// </summary>
		[Obsolete("作废,用IsFharmacy代替", true)]
		public System.String DrugFlag 
		{
			get{ return this.myDrugFlag; }
			set{ this.myDrugFlag = value; }
		}

		/// <summary>
		/// 执行科室
		/// </summary>
		[Obsolete("作废,用属性ExecOper.Dept代替", true)]
		public System.String ExecDpcd 
		{
			get{ return this.myExecDpcd; }
			set{ this.myExecDpcd = value; }
		}


		/// <summary>
		/// 操作员编码
		/// </summary>
		[Obsolete("作废,用属性ExecOper.Employee代替", true)]
		public System.String OperCode 
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[Obsolete("作废,用属性ExecOper.OperTime代替", true)]
		public System.DateTime OperDate 
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		/// <summary>
		/// 操作员所在科室
		/// </summary>
		[Obsolete("作废,用属性Oper.Dept代替", true)]
		public System.String OperDpcd 
		{
			get{ return this.myOperDpcd; }
			set{ this.myOperDpcd = value; }
		}


		/// <summary>
		/// 对应收费明细处方号
		/// </summary>
		[Obsolete("作废,用属性RecipeNO代替", true)]
		public System.String RecipeNo 
		{
			get{ return this.myRecipeNo; }
			set{ this.myRecipeNo = value; }
		}


		/// <summary>
		/// 对应处方内流水号
		/// </summary>
		[Obsolete("作废,用属性SequenceNO代替", true)]
		public System.Int32 SequenceNo 
		{
			get{ return this.mySequenceNo; }
			set{ this.mySequenceNo = value; }
		}

		
		/// <summary>
		/// 退费单据号 门诊系统中保存退费的发票号
		/// </summary>
		[Obsolete("作废,用属性Invoice.ID代替", true)]
		public string BillNo
		{
			get
			{
				return this.myBillNo;
			}
			set
			{
				this.myBillNo = value;
			}
		}

		/// <summary>
		/// 退药确认标识 0未确认/1确认
		/// </summary>
		[Obsolete("作废,用属性IsComfrimed代替", true)]
		public System.String ConfirmFlag 
		{
			get{ return this.myConfirmFlag; }
			set{ this.myConfirmFlag = value; }
		}


		/// <summary>
		/// 确认科室代码
		/// </summary>
		[Obsolete("作废,用属性ConfirmOper.Dept代替", true)]
		public System.String ConfirmDpcd 
		{
			get{ return this.myConfirmDpcd; }
			set{ this.myConfirmDpcd = value; }
		}


		/// <summary>
		/// 确认人编码
		/// </summary>
		[Obsolete("作废,用属性ConfirmOper.Employee代替", true)]
		public System.String ConfirmCode 
		{
			get{ return this.myConfirmCode; }
			set{ this.myConfirmCode = value; }
		}


		/// <summary>
		/// 确认时间
		/// </summary>
		[Obsolete("作废,用属性ConfirmOper.OperTime代替", true)]
		public System.DateTime ConfirmDate 
		{
			get{ return this.myConfirmDate; }
			set{ this.myConfirmDate = value; }
		}


		/// <summary>
		/// 退费标识 0未退费/1退费
		/// </summary>
		[Obsolete("作废,用属性CancelType代替", true)]
		public System.String ChargeFlag 
		{
			get{ return this.myChargeFlag; }
			set{ this.myChargeFlag = value; }
		}


		/// <summary>
		/// 退费确认人
		/// </summary>
		[Obsolete("作废,用属性CancelOper.Employee代替", true)]
		public System.String ChargeCode 
		{
			get{ return this.myChargeCode; }
			set{ this.myChargeCode = value; }
		}


		/// <summary>
		/// 退费确认时间
		/// </summary>
		[Obsolete("作废,用属性CancelOper.OperTime代替", true)]
		public System.DateTime ChargeDate 
		{
			get{ return this.myChargeDate; }
			set{ this.myChargeDate = value; }
		}

		/// <summary>
		/// 包装 单位 0, 最小单位
		/// </summary>
		[Obsolete("作废,用属性FeePack代替", true)]
		public string ExtFlage3
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

		#endregion
	}
    /// <summary>
    /// ReturnApply<br></br>
    /// [功能描述: 退费申请物资信息类]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2008-04-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    //{25934862-5C82-409c-A0D7-7BE5A24FFC75}
    public class ReturnApplyMet : NeuObject
    {
        #region 变量
        /// <summary>
        /// 申请流水号
        /// </summary>
        private string applyNo = string.Empty;
        /// <summary>
        /// 出库单流水号
        /// </summary>
        private string outNo = string.Empty;
        /// <summary>
        /// 库存序号
        /// </summary>
        private string stockNo = string.Empty;
        /// <summary>
        /// 处方号
        /// </summary>
        private string recipeNo = string.Empty;
        /// <summary>
        /// 处方内项目流水号
        /// </summary>
        private string sequenceNo = string.Empty;
        /// <summary>
        /// 退费标识
        /// </summary>
        HISFC.Models.Base.CancelTypes applyFlag = CancelTypes.Canceled;
        /// <summary>
        /// 物资信息
        /// </summary>
        private HISFC.Models.FeeStuff.MaterialItem item = new Neusoft.HISFC.Models.FeeStuff.MaterialItem();
        #endregion

        #region 属性
        /// <summary>
        /// 申请流水号
        /// </summary>
        public string ApplyNo
        {
            get
            {
                return applyNo;
            }
            set
            {
                applyNo = value;
            }
        }

        /// <summary>
        /// 出库单流水号
        /// </summary>
        public string OutNo
        {
            get
            {
                return outNo;
            }
            set
            {
                outNo = value;
            }
        }

        /// <summary>
        /// 库存序号
        /// </summary>
        public string StockNo
        {
            get
            {
                return stockNo;
            }
            set
            {
                stockNo = value;
            }
        }

        /// <summary>
        /// 处方号
        /// </summary>
        public string RecipeNo
        {
            get
            {
                return recipeNo;
            }
            set
            {
                recipeNo = value;
            }
        }

        /// <summary>
        /// 处方内项目流水号
        /// </summary>
        public string SequenceNo
        {
            get
            {
                return sequenceNo;
            }
            set
            {
                sequenceNo = value;
            }
        }
        /// <summary>
        /// 退费标识
        /// </summary>
        public CancelTypes ApplyFlag
        {
            get
            {
                return applyFlag;
            }
            set
            {
                applyFlag = value;
            }
        }

        /// <summary>
        /// 物资信息
        /// </summary>
        public HISFC.Models.FeeStuff.MaterialItem Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new ReturnApplyMet Clone()
        {
            ReturnApplyMet returnApplyMet = base.Clone() as ReturnApplyMet;
            returnApplyMet.Item = this.Item.Clone();
            return returnApplyMet;
        }
        #endregion
    }
}