using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 摆药单分类实体]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理'
	///  />
	///  ID		摆药单分类编码
	///  Name   摆药单分类名称
	/// </summary>
    [Serializable]
    public class DrugBillClass: Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
	{
		public DrugBillClass()
		{
			
		}
		

		#region 变量

        /// <summary>
        /// 申请科室(申请发送科室)
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject applyDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 打印类型
		/// </summary>
		private BillPrintType myPrintType = new BillPrintType();

		/// <summary>
		/// 摆药属性
		/// </summary>
		private DrugAttribute myDrugAttribute = new DrugAttribute();

		/// <summary>
		/// 有效性
		/// </summary>
		private System.Boolean  myIsValid;

		/// <summary>
		/// 操作环境信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 摆药单号
        /// </summary>
        private string drugBillNO;

        /// <summary>
        /// 申请状态
        /// </summary>
        private string applyState;

		#endregion

        /// <summary>
        /// 申请科室(申请发送科室)  不存入数据库 程序处理中使用
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ApplyDept
        {
            get
            {
                return this.applyDept;
            }
            set
            {
                this.applyDept = value;
            }
        }

        /// <summary>
        /// 摆药单号 不存入数据库 程序处理中使用
        /// </summary>
        public string DrugBillNO
        {
            get
            {
                return this.drugBillNO;
            }
            set
            {
                this.drugBillNO = value;
            }
        }

        /// <summary>
        /// 申请状态  不存入数据库 程序处理中使用
        /// </summary>
        public string ApplyState
        {
            get
            {
                return this.applyState;
            }
            set
            {
                this.applyState = value;
            }
        }

		/// <summary>
		/// 打印类型1汇总2明细3草药4大处方
		/// </summary>
		public BillPrintType PrintType
		{
			get
			{
				return this.myPrintType;
			}
			set
			{ 
				this.myPrintType = value;
			}
		}

		/// <summary>
		/// 摆药属性
		/// </summary>
		public DrugAttribute DrugAttribute
		{
			get
			{
				return this.myDrugAttribute; 
			}
			set
			{
				this.myDrugAttribute = value; 
			}
		}

		/// <summary>
		/// 是否有效1-有效0－无效
		/// </summary>
		public bool IsValid
		{
			get
			{ 
				return this.myIsValid; 
			}
			set
			{ 
				this.myIsValid = value; 
			}
		}

		/// <summary>
		/// 操作信息
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
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例的副本</returns>
		public new DrugBillClass Clone()
		{
			DrugBillClass drugBillClass = base.Clone() as DrugBillClass;

            drugBillClass.ApplyDept = this.ApplyDept.Clone();

			drugBillClass.PrintType = this.PrintType.Clone();

			drugBillClass.DrugAttribute = this.DrugAttribute.Clone();

			drugBillClass.Oper = this.Oper.Clone();

			return drugBillClass;
		}

		#region 无效属性

		private System.String   myOperCode ;

		private System.DateTime myOperDate ;

		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public System.String OperCode
		{
			get{ return this.myOperCode; }
			set{ this.myOperCode = value; }
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public System.DateTime OperDate
		{
			get{ return this.myOperDate; }
			set{ this.myOperDate = value; }
		}


		#endregion

	}
}
