using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 转入金额 ChangeCost 的摘要说明。
	/// </summary>
	public class ChangeCost
	{
		public ChangeCost()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
//		FEE_CODE        VARCHAR2(3)                   最小费用代码 如果为 all 话为全部费用                          
//		CHANGE_TYPE     VARCHAR2(1)                   转入类型,1 门诊转入，2 住院转入 3 分院转入                    
//		CLINIC_NO       VARCHAR2(14)                  医疗流水号                                                    
//		NAME            VARCHAR2(20)                  姓名                                                          
//		PAYKIND_CODE    VARCHAR2(2)                   结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干 
//		PACT_CODE       VARCHAR2(10)                  合同单位                                                      
//		TOT_COST        NUMBER(10,2) Y                费用金额                                                      
//		OWN_COST        NUMBER(10,2) Y                自费金额                                                      
//		PAY_COST        NUMBER(10,2) Y                自付金额                                                      
//		PUB_COST        NUMBER(10,2) Y                公费金额                                                      
//		ECO_COST        NUMBER(10,2) Y                优惠金额                                                      
//		CHARGE_OPERCODE VARCHAR2(6)                   转入操作员                                                    
//		CHARGE_DATE     DATE                          转入日期                                                      
//		BALANCE_NO      VARCHAR2(2)  Y                结算序号                                                      
//		BALANCE_STATE   VARCHAR2(1)                   结算标志 0:未结算；1:已结算 2:已结转                          
//		OPER_CODE       VARCHAR2(6)                   操作员                                                        
//		OPER_DATE       DATE                          操作日期    
		/// <summary>
		/// 转入医疗机构编码
		/// </summary>
		public string  ChangeCode ;
		/// <summary>
		/// 最小费用
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Fee = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 转入类型
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ChangeType = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 医疗流水号
		/// </summary>
		public string ClinicNo ;
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name ;
		/// <summary>
		/// 结算类型
		/// </summary>
		public Neusoft.NFC.Object.NeuObject PayKind = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Pact = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 费用金额
		/// </summary>
		public decimal TotCost ;
		/// <summary>
		/// 自费金额
		/// </summary>
		public decimal OwnCost;
		/// <summary>
		/// 自付金额
		/// </summary>
	    public decimal PayCost;
		/// <summary>
		/// 公费金额
		/// </summary>
		public decimal pubCost;
		/// <summary>
		/// 优惠金额
		/// </summary>
		public decimal EcoCost;
		public string BalanceNo;
		public string  BalanceState;  //结算状态

	}
}
