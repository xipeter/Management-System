using System;


namespace Neusoft.HISFC.Models.SIInterface {


	/// <summary>
	/// Insurance 的摘要说明。
	/// </summary>
    [Serializable]
    public class Insurance:Neusoft.FrameWork.Models.NeuObject
	{
		public Insurance()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Neusoft.FrameWork.Models.NeuObject pactInfo = new Neusoft.FrameWork.Models.NeuObject();
		private Neusoft.FrameWork.Models.NeuObject kind = new Neusoft.FrameWork.Models.NeuObject();
		private string partId;
		private Decimal rate;
		private Decimal beginCost;
		private Decimal endCost;
		private Neusoft.FrameWork.Models.NeuObject operCode =  new Neusoft.FrameWork.Models.NeuObject();
		private DateTime operDate;
		/// <summary>
		/// 合同单位信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PactInfo
		{
			set{pactInfo = value;}
			get{return pactInfo;}
		}
		/// <summary>
		/// 人员类别
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Kind
		{
			set{kind = value;}
			get{return kind;}
		}
		/// <summary>
		/// 分段序号
		/// </summary>
		public string PartId
		{
			set{partId = value;}
			get{return partId;}
		}
		/// <summary>
		/// 区间自负比例
		/// </summary>
		public Decimal Rate
		{
			set{rate = value;}
			get{return rate;}
		}
		/// <summary>
		/// 区间开始
		/// </summary>
		public Decimal BeginCost
		{
			set{beginCost = value;}
			get{return beginCost;}
		}
		/// <summary>
		/// 区间结束
		/// </summary>
		public Decimal EndCost
		{
			set{endCost = value;}
			get{return endCost;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject OperCode
		{
			set{operCode = value;}
			get{return operCode;}
		}
		public DateTime OperDate
		{
			set{operDate = value;}
			get{return operDate;}
		}
	}
}
