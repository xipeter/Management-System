using System;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// MedItemList 的摘要说明。
	/// 药品费用信息类
	/// </summary>
	public class MedItemList:Neusoft.HISFC.Object.Base.Item
	{
		public MedItemList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 费用信息
		/// </summary>
		public FeeInfo FeeInfo=new FeeInfo();
		/// <summary>
		/// 项目信息
		/// </summary>
		public Object.Base.Item  Item=new Neusoft.HISFC.Object.Base.Item();
		/// <summary>
		/// 处方内流水号
		/// </summary>
		public int SequenceNo;
		/// <summary>
		/// 更新库存流水号
		/// </summary>
		public int UpdateSequenceNo;
		/// <summary>
		/// 发药单序列号
		/// </summary>
		public int SendSequenceNo;
		/// <summary>
		/// 0划价1收费2摆药
		/// </summary>
		public string SendState;
		/// <summary>
		/// 急诊抢救标记
		/// </summary>
		public bool IsEmergency;
		/// <summary>
		/// 是否出院带药
		/// </summary>
		public bool IsBrought;
		/// <summary>
		/// 项目中心编码(医保用)
		/// </summary>
		public string CenterCode;
		/// <summary>
		/// 审批号(医保用)
		/// </summary>
		public string ApprNo;
		/// <summary>
		/// 医嘱流水号
		/// </summary>
		public string MoOrder;
		/// <summary>
		/// 医嘱执行单流水号
		/// </summary>
		public string MoExecSqn;
		/// <summary>
		/// 发药人
		/// </summary>
		public NeuObject SendDrugOper = new NeuObject();
		/// <summary>
		/// 发药日期
		/// </summary>
		public DateTime DtSendDrug;
		/// <summary>
		/// 是否自制
		/// </summary>
        public bool IsMadeSelf;
		/// <summary>
		/// 药品类别
		/// </summary>
		public NeuObject DrugType = new NeuObject();
		/// <summary>
		/// 药品性质
		/// </summary>
		public string DrugQuality;
		/// <summary>
		/// 审核人
		/// </summary>
		public NeuObject CheckOper = new NeuObject();


	}
}
