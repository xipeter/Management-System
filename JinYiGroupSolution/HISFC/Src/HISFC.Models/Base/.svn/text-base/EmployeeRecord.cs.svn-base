using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EmployeeRecord<br></br>
	/// [功能描述: 人员科室变更实体]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class EmployeeRecord: Record 
    {
		/// <summary>
		/// 构造函数
		/// </summary>
		public EmployeeRecord() 
        {
		}


		#region 变量

		/// <summary>
		/// 员工信息 ID 员工编号 Name 姓名
		/// </summary>
		private NeuObject employee = new NeuObject();

		/// <summary>
		/// 变动类型（DEPT科室，NURSE护士站等）
		/// </summary>
		private NeuObject shiftType = new NeuObject();

		/// <summary>
		/// 当前状态（0申请，1确认，2作废）
		/// </summary>
		private string state ;

		/// <summary>
		/// 申请操作员
		/// </summary>
		private NeuObject applyOperator = new NeuObject();

		/// <summary>
		/// 申请的操作时间
		/// </summary>
		private DateTime applyTime ;

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		#endregion
                           
		#region 属性

		/// <summary>
		/// 员工信息 ID 员工编号 Name 姓名
		/// </summary>
		public NeuObject Employee 
		{
			get
			{ 
				return this.employee; 
			}
			set
			{ 
				this.employee = value; 
			}
		}
		/// <summary>
		/// 变动类型（DEPT科室，NURSE护士站等）
		/// </summary>
		public NeuObject ShiftType 
		{
			get
			{ 
				return this.shiftType; 
			}
			set
			{ 
				this.shiftType = value; 
			}
		}
		/// <summary>
		/// 当前状态（0申请，1确认，2作废）
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
		/// 申请操作员
		/// </summary>
		public NeuObject ApplyOperator 
		{
			get
			{ 
				return this.applyOperator; 
			}
			set
			{ 
				this.applyOperator = value; 
			}
		}
		/// <summary>
		/// 申请的操作时间
		/// </summary>
		public DateTime ApplyTime
		{
			get
			{ 
				return this.applyTime;
			}
			set
			{ 
				this.applyTime = value; 
			}
		}
		/// <summary>
		/// 操作员（核准，作废）
		/// </summary>
		public string ComfirmOperator 
		{
			get
			{ 
				return base.OperEnvironment.ID; 
			}
			set
			{ 
				 base.OperEnvironment.ID = value;
			}
		}
		/// <summary>
		/// 操作时间（核准，作废）
		/// </summary>
		public new System.DateTime OperDate 
		{
			get
			{ 
				return base.OperEnvironment.OperTime;
			}
			set
			{ 
				base.OperEnvironment.OperTime = value;
			}
		}

		#endregion
	
		#region 方法

		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			if (isDisposing)
			{
				if (this.applyOperator != null)
				{
					this.applyOperator.Dispose();
					this.applyOperator = null;
				}
				if (this.employee != null)
				{
					this.employee.Dispose();
					this.employee = null;
				}
				if (this.shiftType != null)
				{
					this.shiftType.Dispose();
					this.shiftType = null;
				}
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}
 
		#endregion
	
		#region 克隆

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new EmployeeRecord Clone()
        {
            EmployeeRecord employeeRecord  = base.Clone() as EmployeeRecord;

            employeeRecord.Employee = this.Employee.Clone();
            employeeRecord.ShiftType = this.ShiftType.Clone();
			employeeRecord.ApplyOperator = this.ApplyOperator.Clone();

            return employeeRecord;
        }
		#endregion
	}
}
