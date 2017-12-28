using System;

namespace Neusoft.HISFC.Models.EPR
{
	/// <summary>
	/// Record 的摘要说明。
	/// id code
	/// name EMRName 病历名称
	/// </summary>
    [Serializable]
	public class Record:Neusoft.HISFC.Models.Base.Record
	{
		public Record()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		protected string myEMRType = "";
		/// <summary>
		/// 病历类型
		/// </summary>
		public string EMRType 
		{
			get
			{
				return myEMRType;
			}
			set
			{
				myEMRType = value;
			}
		}

		protected Neusoft.FrameWork.Models.NeuObject myType = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 日志操作类型-付给ID就可以
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Type
		{
			get
			{
				return this.myType;
			}
			set
			{
				this.myType = value;
				if(this.myType.ID == enuRecordType.EMROperation.GetHashCode().ToString())
				{
					this.myType.Name = "病历操作";
				}
				if(this.myType.ID == enuRecordType.EMRModify.GetHashCode().ToString())
				{
					this.myType.Name = "病历修改";
				}
				if(this.myType.ID == enuRecordType.System.GetHashCode().ToString())
				{
					this.myType.Name = "系统操作";
				}
			}
		}
		protected string myNodeName ="";
		/// <summary>
		/// 节点名字
		/// </summary>
		public string NodeName
		{
			get
			{
				return this.myNodeName;
			}
			set
			{
				this.myNodeName =value;
			}
		}
	}
	/// <summary>
	/// 日志类型
	/// </summary>
	public enum enuRecordType
	{
		/// <summary>
		/// 病历操作
		/// </summary>
		EMROperation =1,//病历操作
		/// <summary>
		/// 病历修改
		/// </summary>
		EMRModify = 2,//病历修改
		/// <summary>
		/// 系统操作
		/// </summary>
		System = 3 //系统操作
	
	}
	
}
