using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base 
{  
	/// <summary>
	/// Job<br></br>
	/// [功能描述: Job实体]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Job : NeuObject 
    {
		/// <summary>
		/// 构造函数
		/// </summary>
        public Job() 
        {

		}

		#region 变量

		/// <summary>
		/// 类型 0 前台应用程序处理 1 后台job处理
		/// </summary>
        private string type;
		
		/// <summary>
		/// 部门信息－不区分部门
		/// </summary>
        private NeuObject department = new NeuObject();
		
		/// <summary>
		///上次执行时间
		/// </summary>
        private DateTime lastTime;
		
		/// <summary>
		/// 下次执行时间
		/// </summary>
        private DateTime nextTime;
		
		/// <summary>
		/// 间隔天数(只有当State为1的时候有用)
		/// </summary>
        private int intervalDays = 1;
		
		/// <summary>
		///  状态0_不统计, 1_每日统计,  2_每周统计, 3_每月统计，4_每季度统计,5_每年统计,7_自定义,S_正在统计
		/// </summary>
		private JobState state = new JobState();
		
		/// <summary>
		/// 是否已经释放资源 默认为false没有释放
		/// </summary>
		private bool alreadyDisposed = false;

		#endregion

		#region 属性

		/// <summary>
		/// 类型: 0 前台应用程序处理, 1 后台job处理
		/// </summary>
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				type = value;
			}
		}

		/// <summary>
		/// 部门信息－不区分部门
		/// </summary>
		public NeuObject Department 
		{
			get
			{
				return this.department;
			}
			set
			{
				this.department = value;
			}
		}

		/// <summary>
		/// 上次执行时间
		/// </summary>
		public DateTime LastTime
		{
			get
			{
				return this.lastTime;
			}
			set
			{
				this.lastTime = value;
			}
		}

		/// <summary>
		/// 下次执行时间
		/// </summary>
		public DateTime NextTime
		{
			get
			{
				return this.nextTime;
			}
			set
			{
				this.nextTime = value;
			}
		}

		/// <summary>
		/// 间隔天数(只有当JOB_STATE为1的时候有用)
		/// </summary>
		public int IntervalDays 
		{
			get
			{
				return this.intervalDays;
			}
			set
			{
				this.intervalDays = value;
			}
		}

		/// <summary>
		/// 状态0_不统计, 1_每日统计,  2_每周统计,  3_每月统计，4_每季度统计,5_每年统计,7_自定义,S_正在统计
		/// </summary>
		public Neusoft.HISFC.Models.Base.JobState State
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
		
		#endregion

		#region 方法

		#region 释放资源
		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing">是否释放 true是 false否</param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}
			
			if (this.state != null)
			{
				this.state.Dispose();
			}
			if (this.department != null)
			{
				this.department.Dispose();
			}
			
			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>克隆后的当前对象的实例</returns>
		public new Job Clone()
		{
			Job job = base.Clone() as Job;
			
			job.State = this.State.Clone();
			job.Department = this.Department.Clone();
			
			return job;
		}
		
		#endregion

		#endregion

		
	}
}
