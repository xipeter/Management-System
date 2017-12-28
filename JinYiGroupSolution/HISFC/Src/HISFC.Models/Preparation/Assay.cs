using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Assay<br></br>
	/// [功能描述: 化验实体]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Assay : PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Assay()
		{
		}


		#region  变量
		/// <summary>
		/// 送检--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment applyEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 检验--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment assayEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();
		
		/// <summary>
		/// 检验内容
		/// </summary>
		private Stencil stencil = new Stencil();

		/// <summary>
		/// 检验含量
		/// </summary>
		private decimal content;

		/// <summary>
		/// 数值检验结果
		/// </summary>
		private decimal resultQty;

		/// <summary>
		/// 字符检验结果
		/// </summary>
		private string resultStr;

		/// <summary>
		/// 检验是否合格
		/// </summary>
		private bool isEligibility;

		/// <summary>
		/// 检验标准依据
		/// </summary>
		private string assayRule;

		/// <summary>
		/// 复核人
		/// </summary>
		private string checkOper;

		/// <summary>
		/// 报告书编号
		/// </summary>
		private string reportNum;

		/// <summary>
		/// 生产量(分装产品数量)
		/// </summary>
		private decimal divisionQty;


		#endregion

		#region 属性
		/// <summary>
		/// 送检--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ApplyEnv
		{
			get
			{
				return this.applyEnv;
			}
			set
			{
				this.applyEnv = value;
			}
		}

		/// <summary>
		/// 检验--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment AssayEnv
		{
			get
			{
				return this.assayEnv;
			}
			set
			{
				this.assayEnv = value;
			}
		}


		/// <summary>
		/// 检验内容
		/// </summary>
		public Stencil Stencil
		{
			get
			{
				return this.stencil;
			}
			set
			{
				this.stencil = value;
			}
		}


		/// <summary>
		/// 检验含量
		/// </summary>
		public decimal Content
		{
			get
			{
				return this.content;
			}
			set
			{
				this.content = value;
			}
		}

		/// <summary>
		/// 数值检验结果
		/// </summary>
		public decimal ResultQty
		{
			get
			{
				return this.resultQty;
			}
			set
			{
				this.resultQty = value;
			}
		}

		/// <summary>
		/// 字符检验结果
		/// </summary>
		public string ResultStr
		{
			get
			{
				return this.resultStr;
			}
			set
			{
				this.resultStr = value;
			}
		}
        
		/// <summary>
		/// 检验是否合格
		/// </summary>
		public bool IsEligibility
		{
			get
			{
				return this.isEligibility;
			}
			set
			{
				this.isEligibility = value;
			}
		}

		/// <summary>
		/// 检验标准依据
		/// </summary>
		public string AssayRule
		{
			get
			{
				return this.assayRule;
			}
			set
			{
				this.assayRule = value;
			}
		}

		/// <summary>
		/// 复核人
		/// </summary>
		public string CheckOper
		{
			get
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}

		/// <summary>
		/// 报告书编号
		/// </summary> 
		public string ReportNum
		{
			get
			{
				return this.reportNum;
			}
			set
			{
				this.reportNum = value;
			}
		}

		/// <summary>
		/// 生产量(分装产品数量)
		/// </summary>
		public decimal DivisionQty
		{
			get
			{
				return this.divisionQty;
			}
			set
			{
				this.divisionQty = value;
			}
		}
		#endregion

		#region 过期的属性
		
		/// <summary>
		/// 报告书编号
		/// </summary> 
		[System.Obsolete("已经过期，使用ReportNum", true)]
		public string ReportID
		{
			get
			{
				return this.reportNum;
			}
			set
			{
				this.reportNum = value;
			}
		}

		/// <summary>
		/// 数值检验结果
		/// </summary>
		[System.Obsolete("已经过期，使用ResultQty",true)]
		public decimal ResultNum
		{
			get
			{
				return this.resultQty;
			}
			set
			{
				this.resultQty = value;
			}
		}

		/// <summary>
		/// 送检人
		/// </summary>
		[System.Obsolete("已经过期，使用ApplyEnv", true)]
		public string ApplyOper
		{
			get
			{
				return this.applyOper;
			}
			set
			{
				this.applyOper = value;
			}
		}
		/// <summary>
		/// 送检日期
		/// </summary>
		[System.Obsolete("已经过期，使用ApplyEnv", true)]
		public DateTime ApplyDate
		{
			get
			{
				return this.applyDate;
			}
			set
			{
				this.applyDate = value;
			}
		}
				/// <summary>
				/// 检验日期(报告日期)
				/// </summary>
				private DateTime assayDate;
		
		/// <summary>
		/// 检验日期(报告日期)
		/// </summary>
		[System.Obsolete("已经过期，使用AssayEnv", true)]
		public DateTime AssayDate
		{
			get
			{
				return this.assayDate;
			}
			set
			{
				this.assayDate = value;
			}
		}
				/// <summary>
				/// 检验人
				/// </summary>
				private string assayOper;
		
		/// <summary>
		/// 检验人
		/// </summary>
		[System.Obsolete("已经过期，使用AssayEnv", true)]
		public string AssayOper
		{
			get
			{
				return this.assayOper;
			}
			set
			{
				this.assayOper = value;
			}
		}
				private string applyOper;
				private DateTime applyDate;
		#endregion

		#region  方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Assay</returns>
		public new Assay Clone()
		{
			Assay assay = base.Clone() as Assay;
			assay.applyEnv = applyEnv.Clone();
			assay.assayEnv = assayEnv.Clone();
			assay.stencil = stencil.Clone();
			return assay;
		}

		#endregion

	}
}