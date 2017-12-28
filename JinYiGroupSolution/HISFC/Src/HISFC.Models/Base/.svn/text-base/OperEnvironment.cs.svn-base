using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// OperEnvironment<br></br>
	/// [功能描述: 操作环境实体:包括操作员、科室和时间]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-31]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class OperEnvironment :NeuObject
	{
		public OperEnvironment()
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 操作时间
		/// </summary>
		private DateTime operTime = new DateTime();
		
		/// <summary>
		/// 操作员
		/// </summary>
		private Operator oper = new Operator();

		/// <summary>
		/// 科室
		/// </summary>
		private NeuObject dept = new NeuObject();

		#endregion

		#region 属性

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperTime
		{
			get
			{
				return this.operTime;
			}
			set
			{
				this.operTime = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		[Obsolete("用本身的ID,Name来代替",true)]
		public Operator Oper
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
		/// 科室
		/// </summary>
		public NeuObject Dept
		{
			get
			{
				return this.dept;
			}
			set
			{
				this.dept = value;
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

			if (this.dept != null)
			{
				this.dept.Dispose();
				this.dept = null;
			}
			if (this.oper != null)
			{
				this.oper.Dispose();
				this.oper = null;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new OperEnvironment Clone()
		{
			OperEnvironment operEnvironment = base.Clone() as OperEnvironment;

			//operEnvironment.Oper = this.Oper.Clone();
			operEnvironment.Dept = this.Dept.Clone();

			return operEnvironment;
		}

		#endregion
	}
}
