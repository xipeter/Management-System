using System;

using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	///费用项目信息类  
    ///ID住院流水号
	///name 患者姓名
	/// </summary>
	public class FeeItemList:Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		/// 费用项目信息
		/// </summary>
		public FeeItemList()
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
		/// 项目信息 药品/非药品
		/// </summary>
		public Object.Base.Item  Item
		{
			get
			{
				return this.pOrder.Order.Item;
			}
			set
			{
				this.pOrder.Order.Item= value;
			}
		}
		protected Neusoft.HISFC.Object.Order.ExecOrder pOrder=new Neusoft.HISFC.Object.Order.ExecOrder();
		/// <summary>
		/// 执行单信息
		/// 需要项目信息，需要执行单号，医嘱流水号
		/// </summary>
		public Neusoft.HISFC.Object.Order.ExecOrder  Order
		{
			get
			{
				return this.pOrder;		
			}set
			{
				 this.pOrder = value;
			}
		}
		/// <summary>
		/// 医嘱流水号
		/// </summary>
		public string MoOrder
		{
			get
			{
				return this.Order.Order.ID;
			}
			set
			{
				this.Order.Order.ID=value;
			}
		}
		
		/// <summary>
		/// 新物价组套信息
		/// </summary>
		public NeuObject ItemGroup = new NeuObject()   ;
		/// <summary>
		/// 处方内流水号
		/// </summary>
		public int SequenceNo;
		/// <summary>
		/// 0划价1收费2执行发放
		/// </summary>
		public string SendState;
		/// <summary>
		/// 执行人
		/// </summary>
		public NeuObject ExecOper = new NeuObject();
		/// <summary>
		/// 执行日期
		/// </summary>
		public DateTime DtExec;
		/// <summary>
		/// 是否出院带疗(改为医嘱类型)
		/// </summary>
		public string IsBrought;
		/// <summary>
		/// 出库单号
		/// </summary>
		public int SendSequence;
		/// <summary>
		/// 扣库流水号
		/// </summary>
		public int UpdateSequence;
		/// <summary>
		/// 设备编号
		/// </summary>
		public string MachineNo;
		/// <summary>
		/// 可退数量
		/// </summary>
		public decimal NoBackNum=0m;
		/// <summary>
		/// 收费比例(手术用)
		/// </summary>
		public decimal Rate=0m;
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new FeeItemList Clone()
		{
			FeeItemList obj = base.Clone() as FeeItemList;
			obj.FeeInfo =this.FeeInfo.Clone();
			obj.pOrder=this.pOrder.Clone();
			obj.ItemGroup=this.ItemGroup.Clone();
			obj.ExecOper=this.ExecOper.Clone();
			return obj;
		}

	}
}
