using Neusoft.FrameWork.Models;
using System;

namespace Neusoft.HISFC.Models.Base
{


	/// <summary>
	/// Pact<br></br>
	/// [功能描述: 合同单位实体，用于常数维护]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Pact : Spell,  ISort, IValid
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Pact( ) 
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 分组信息
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject group = new NeuObject();

		/// <summary>
		/// 有效性标识
		/// </summary>
		private bool isValid;
		
		/// <summary>
		/// 操作环境
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();

		/// <summary>
		/// 排列序号
		/// </summary>
		private int sortID;
		
		private string validState;
		#endregion
		
		#region 属性
		
		/// <summary>
		/// 分组信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Group
		{
			get
			{
				return this.group;
			}
			set
			{
				this.group = value;
			}
		}

		/// <summary>
		/// 有效性标识
		/// </summary>
		public string ValidState
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public OperEnvironment OperEnvironment
		{
			get
			{
				return this.operEnvironment;
			}
			set
			{
				this.operEnvironment = value;
			}
		}
		#endregion

		#region 方法
		
		#region 释放资源
		
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

			if (this.group != null)
			{
				this.group.Dispose();
				this.group = null;
			}
			if (this.operEnvironment != null)
			{
				this.operEnvironment.Dispose();
				this.operEnvironment = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Pact Clone()
		{
			Pact pact = base.Clone() as Pact;

			pact.Group = this.Group.Clone();
			pact.OperEnvironment = this.OperEnvironment.Clone();

			return pact;
		}

		#endregion

		#endregion

		#region 接口实现

		#region ISort 成员

		/// <summary>
		/// 排列序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
			}
		}

		#endregion

		#region IValid 成员

		/// <summary>
		/// 有效性
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}

		#endregion

		#endregion
	}
}
