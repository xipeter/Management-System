using System;


namespace Neusoft.HISFC.Models.SIInterface {


	/// <summary>
	/// BlackList 的摘要说明。
	/// </summary>
    [Serializable]
    public class BlackList:Neusoft.FrameWork.Models.NeuObject
	{
		public BlackList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		private string mCardNo;
		private string kind;
		private string validState;
		private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();
		private DateTime operDate;
		/// <summary>
		/// 合同单位编码或医疗证号
		/// </summary>
		public string MCardNo
		{
			get{return mCardNo;}
			set{mCardNo = value;}
		}
		/// <summary>
		/// 种类 0 单位 1 个人
		/// </summary>
		public string Kind
		{
			get{return kind;}
			set{kind = value;}
		}
		/// <summary>
		/// 有效性标识 0 在用 1 停用 2 废弃
		/// </summary>
		public string ValidState
		{
			get{return validState;}
			set{validState = value;}
		}
		/// <summary>
		/// 操作员信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OperInfo
		{
			get{return operInfo;}
			set{operInfo = value;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get{return operDate;}
			set{operDate = value;}
		}

		public new BlackList Clone()
		{
			BlackList obj = base.Clone() as BlackList;
			obj.OperInfo = this.OperInfo.Clone();

			return obj;
		}

	}
}
