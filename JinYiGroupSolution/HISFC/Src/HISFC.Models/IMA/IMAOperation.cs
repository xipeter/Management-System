using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品、物资库存管理操作类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	///  
	/// </summary>
    [Serializable]
	public class IMAOperation : Neusoft.FrameWork.Models.NeuObject
	{
		public IMAOperation()
		{
			
		}


		#region 变量

		/// <summary>
		/// 申请数量
		/// </summary>
		private decimal applyQty;

		/// <summary>
		/// 申请操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment applyOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 审批数量
		/// </summary>
		private decimal examQty;
	
		/// <summary>
		/// 审批信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment examOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 核准数量
		/// </summary>
		private decimal approveQty;

		/// <summary>
		/// 核准操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment approveOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 退库数量
		/// </summary>
		private decimal returnNum;

		/// <summary>
		/// 操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		#endregion

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
		/// 申请操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ApplyOper
		{
			get
			{
				return this.applyOper;
			}
			set
			{
				this.applyOper = value;

				if (value != null)
				{
					base.ID = value.ID;
					base.Name = value.Name;
				}
			}
		}


		/// <summary>
		/// 审核数量
		/// </summary>
		public decimal ExamQty
		{
			get
			{
				return this.examQty;
			}
			set
			{
				this.examQty = value;
			}
		}


		/// <summary>
		/// 审批操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ExamOper 
		{
			get
			{
				return this.examOper;
			}
			set
			{
				this.examOper = value;

				if (value != null)
				{
					base.ID = value.ID;
					base.Name = value.Name;
				}
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
		public Neusoft.HISFC.Models.Base.OperEnvironment ApproveOper
		{
			get
			{
				return this.approveOper;
			}
			set
			{
				this.approveOper = value;

				if (value != null)
				{
					base.ID = value.ID;
					base.Name = value.Name;
				}
			}
		}


		/// <summary>
		/// 退库数量
		/// </summary>
		public decimal ReturnQty
		{
			get
			{
				return this.returnNum;
			}
			set
			{
				this.returnNum = value;
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

				if (value != null)
				{
					base.ID = value.ID;
					base.Name = value.Name;
				}
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例的副本</returns>
		public new IMAOperation Clone()
		{
			IMAOperation imaOperation = base.Clone() as IMAOperation;
			
			imaOperation.ApplyOper = this.ApplyOper.Clone();
			imaOperation.ExamOper = this.ExamOper.Clone();
			imaOperation.ApproveOper = this.ApproveOper.Clone();
			imaOperation.Oper = this.Oper.Clone();

			return imaOperation;

		}


		#endregion
	}
}
