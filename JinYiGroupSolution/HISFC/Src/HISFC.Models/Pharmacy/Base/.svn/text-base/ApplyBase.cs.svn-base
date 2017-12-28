using System;

namespace Neusoft.HISFC.Object.Pharmacy.Base
{
	/// <summary>
	/// [功能描述: 药品、物资管理申请信息基类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	///  ID 申请序号
	/// </summary>
	public abstract class ApplyBase : Neusoft.NFC.Object.NeuObject
	{
		public ApplyBase()
		{

		}


		#region 变量

		/// <summary>
		/// 申请科室
		/// </summary>
		private Neusoft.NFC.Object.NeuObject applyDept;

		/// <summary>
		/// 库存科室
		/// </summary>
		private Neusoft.NFC.Object.NeuObject stockDept;

		/// <summary>
		/// 申请单号
		/// </summary>
		private string billCode;

		/// <summary>
		/// 申请操作信息
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment applyOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 状态
		/// </summary>
		private string state;

		/// <summary>
		/// 申请数量
		/// </summary>
		private decimal applyQty;

		/// <summary>
		/// 审批信息
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment examOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 核准数量
		/// </summary>
		private decimal approveQty;

		/// <summary>
		/// 核准操作信息
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment approveOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 操作信息
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

		#endregion

		/// <summary>
		/// 申请项目
		/// </summary>
		public abstract object Item
		{
			get;
			set;
		}


		/// <summary>
		/// 申请科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ApplyDept
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
		/// 库存科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject StockDept
		{
			get
			{
				return this.stockDept;
			}
			set
			{
				this.stockDept = value;
			}
		}


	


		/// <summary>
		/// 申请单号
		/// </summary>
		public string BillNO
		{
			get
			{
				return this.billCode;
			}
			set
			{
				this.billCode = value;
			}
		}


		/// <summary>
		/// 申请操作信息
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ApplyOper
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
		/// 状态
		/// </summary>
		public string State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}


		/// <summary>
		/// 申请数量
		/// </summary>
		public decimal ApplyQty
		{
			get
			{
				return this.applyQty;
			}
			set
			{
				this.applyQty = value;
			}
		}


		/// <summary>
		/// 审批操作信息
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ExamOper 
		{
			get
			{
				return this.examOper;
			}
			set
			{
				this.examOper = value;
			}
		}


		/// <summary>
		/// 核准数量
		/// </summary>
		public decimal ApproveQty
		{
			get
			{
				return this.approveQty;
			}
			set
			{
				this.approveQty = value;
			}
		}


		/// <summary>
		/// 核准操作信息
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ApproveOper
		{
			get
			{
				return this.approveOper;
			}
			set
			{
				this.approveOper = value;
			}
		}


		/// <summary>
		/// 操作信息
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment Oper
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


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例的副本</returns>
		public new ApplyBase Clone()
		{
			ApplyBase applyBase = base.Clone() as ApplyBase;
			
			applyBase.ApplyDept = this.ApplyDept.Clone();
			applyBase.StockDept = this.StockDept.Clone();
			applyBase.ApplyOper = this.ApplyOper.Clone();
			applyBase.ExamOper = this.ExamOper.Clone();
			applyBase.ApproveOper = this.ApproveOper.Clone();
			applyBase.Oper = this.Oper.Clone();

			return applyBase;

		}


		#endregion
	}
}
