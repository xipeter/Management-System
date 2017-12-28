using System;

namespace Neusoft.HISFC.Models.EPR
{
	/// <summary>
	/// QCData 的摘要说明。
	/// 质量控制数据实体
	/// 基类及接口：object
	/// </summary>
    [Serializable]
	public class QCData
	{
		/// <summary>
		/// 
		/// </summary>
		public QCData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		/// <summary>
		/// 数据文件状态
		/// </summary>
		protected int myState = 0;
		/// <summary>
		/// 建立者
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject myCreater = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 签名者
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject mySaver = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 封存者
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject mySealer = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 删除者
		/// </summary>
		protected Neusoft.FrameWork.Models.NeuObject myDeleter = new Neusoft.FrameWork.Models.NeuObject();
		
		/// <summary>
		/// 当前状态
		/// </summary>
		public int State
		{
			get
			{
				return myState;
			}
			set
			{
				myState = value;
			}
		}
		/// <summary>
		/// 建立者 id code name 
		/// memo 日期
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Creater
		{
			get
			{
				return this.myCreater;
			}
			set
			{
				this.myCreater = value;
			}
		}
		/// <summary>
		/// 签名者 id code name 
		/// memo 日期
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Saver
		{
			get
			{
				return this.mySaver;
			}
			set
			{
				this.mySaver = value;
			}
		}
		/// <summary>
		/// 封存者 id code name 
		/// memo 日期
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Sealer
		{
			get
			{
				return this.mySealer;
			}
			set
			{
				this.mySealer = value;
			}
		}
		/// <summary>
		/// 删除者 id code name 
		/// memo 日期
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Deleter
		{
			get
			{
				return this.myDeleter;
			}
			set
			{
				this.myDeleter = value;
			}
		}

		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public  QCData Clone()
		{
			QCData newObj = new QCData();
			newObj.myCreater = this.myCreater.Clone();
			newObj.mySaver = this.mySaver.Clone();
			newObj.mySealer = this.mySealer.Clone();
			newObj.myDeleter = this.myDeleter.Clone();
			return newObj;
		}
	}
}
