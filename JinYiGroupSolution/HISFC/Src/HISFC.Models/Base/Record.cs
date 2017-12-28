using System;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Record<br></br>
	/// [功能描述: 变更日志记录实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Record : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Record()
		{

		}

		#region 变量

		/// <summary>
		/// 操作环境
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();
		
		/// <summary>
		/// 释放资源标志
		/// </summary>
		private bool alreadyDisposed = false;
		
		/// <summary>
		/// 旧数据
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject oldData = new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 新数据
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject newData = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

		#region 属性

		/// <summary>
		/// 旧资料
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OldData
		{
			get
			{
				return this.oldData;
			}
			set
			{
				this.oldData = value;
			}
		}

		/// <summary>
		/// 新资料
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject NewData
		{
			get
			{
				return this.newData;
			}
			set
			{
				this.newData = value;
			}
		}

		/// <summary>
		/// 操作环境
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

			if (this.oldData != null)
			{
				this.oldData.Dispose();
				this.oldData = null;
			}
			if (newData != null)
			{
				this.newData.Dispose();
				this.newData = null;
			}

			base.Dispose(isDisposing);
			
			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例的副本</returns>
		public new Record Clone()
		{
			Record record = base.Clone() as Record;

			record.NewData = this.NewData.Clone();
			record.OldData = this.OldData.Clone();
			
			return record;
		}

		#endregion

		#endregion
		
	}
}
