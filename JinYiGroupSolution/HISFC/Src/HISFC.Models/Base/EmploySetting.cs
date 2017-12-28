namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EmploySetting<br></br>
	/// [功能描述: 人员设置信息实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-30]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class EmploySetting : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public EmploySetting()
		{
		}


		#region 变量

		/// <summary>
		/// 等待时间
		/// </summary>
		private decimal waitTime ;

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 人员
		/// </summary>
		private Neusoft.HISFC.Models.Base.Employee employee = new Employee();

		#endregion

		#region 属性

		/// <summary>
		/// 等待时间
		/// </summary>
		public decimal WaitTime
		{
			get
			{
				return waitTime;
			}
			set
			{
				waitTime = value;
			}
		}
		/// <summary>
		/// 人员
		/// </summary>
		public Neusoft.HISFC.Models.Base.Employee Employee
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
		#endregion
		
		#region 方法
		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing">是否释放资源</param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			if (this.employee != null)
			{
				this.employee.Dispose();
				this.employee = null;
			}
			
			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例副本</returns>
		public new EmploySetting Clone()
		{
			EmploySetting employeeSetting = base.Clone() as EmploySetting;

			employeeSetting.Employee = this.Employee.Clone();

			return employeeSetting;
		}

		#endregion
	}
}
